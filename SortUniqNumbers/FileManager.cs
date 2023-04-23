﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortUniqNumbers
{
	public class FileManager
	{
		private const string Extention = ".txt";

		private static readonly Random _random = new Random();
		private static FileManager _fileManager;
		private static NumberManager _numberManager = new NumberManager();;

		private readonly FileSystemWatcher _watcher = new FileSystemWatcher();
		private List<string> _filesInFolder = new List<string>(100);
		private List<string> _filesForRead = new List<string>(100);
		private string _path;

		public Action<string> ChangedPath;
		public Action<IReadOnlyList<string>> ChangedFilesListInFolder;
		public Action<IReadOnlyList<string>> ChangedFilesListForRead;

		public static FileManager Instance()
		{
			if (_fileManager is null)
				_fileManager = new FileManager();

			return _fileManager;
		}

		public void Init()
		{
			ChangePath($"{Directory.GetCurrentDirectory()}\\Source");
			UpdateList();
			ListenFolder();
		}

		public void ChangePath(string newPath)
		{
			_path = $"{newPath}\\";

			if (!Directory.Exists(newPath))
				Directory.CreateDirectory(_path);

			ChangedPath?.Invoke(_path);

			ClearFilesListForRead();
		}

		public void AddFilesListForRead(IEnumerable<string> files)
		{
			foreach (var file in files)
				if (_filesInFolder.Contains(file) && !_filesForRead.Contains(file))
					_filesForRead.Add(file);

			ChangedFilesListForRead?.Invoke(_filesForRead);
		}

		public void RemoveFilesListForRead(IEnumerable<string> files)
		{
			foreach (var file in files)
				if (_filesForRead.Contains(file))
					_filesForRead.Remove(file);

			ChangedFilesListForRead?.Invoke(_filesForRead);
		}

		public void ReadFiles(int divider, int modulo)
		{
			if (_filesInFolder.Count < 0)
				return;

			_numberManager.Init(divider, modulo);
			FilterByUniq.Reset();

			foreach (string file in _filesForRead)
				ReadFile(file);
		}

		public void SaveResult()
		{
			List<string> result = _numberManager.GetResult();

			string resultFileName = $"{_path}Result{Extention}";
			GenerateFile(resultFileName);

			using StreamWriter writer = new StreamWriter(resultFileName);

			foreach (var element in result)
				writer.WriteLine(element);
		}

		public void GenerateFiles(int filesCount)
		{
			for (int i = 0; i < filesCount; i++)
			{
				string fileName = $"{_path}/{i}{Extention}";
				GenerateFile(fileName);
			}

			UpdateFilesListInFolder();
		}

		public void FillFiles(int minCount, int maxCount, int minNumber, int maxNumber)
		{
			if (IsValidateRange(minCount, maxCount) &&
				IsValidateRange(minNumber, maxNumber))
			{
				foreach (string file in _filesInFolder)
				{
					using StreamWriter writer = new StreamWriter(file);
					int dataCount = _random.Next(minCount, maxCount);

					for (int i = 0; i < dataCount; i++)
						writer.WriteLine(_numberManager.GetData(minNumber, maxNumber));
				}
			}
		}

		private void ListenFolder()
		{
			_watcher.Path = _path;
			_watcher.Filter = $"*{Extention}";

			_watcher.Created += (sender, @event) => UpdateList();
			_watcher.Deleted += (sender, @event) => UpdateList();
			_watcher.Renamed += (sender, @event) => RenameFile(@event.OldName, @event.Name);

			_watcher.EnableRaisingEvents = true;
		}

		private void RenameFile(string oldName, string newName)
		{
			_filesInFolder[_filesInFolder.IndexOf(oldName)] = newName;
			ChangedFilesListInFolder?.Invoke(_filesInFolder);

			if(_filesForRead.IndexOf(oldName) >= 0)
			{
				_filesForRead[_filesForRead.IndexOf(oldName)] = newName;
				ChangedFilesListForRead?.Invoke(_filesForRead);
			}
		}

		private void UpdateList()
		{
			UpdateFilesListForRead();
			UpdateFilesListInFolder();
		}

		private void UpdateFilesListForRead()
		{
			_filesForRead = Directory.GetFiles(_path)
				.Where(file => _filesForRead.Contains(Path.GetFileName(file)))
				.Select(file => Path.GetFileName(file))
				.ToList();

			ChangedFilesListForRead?.Invoke(_filesForRead);
		}

		private void UpdateFilesListInFolder()
		{
			_filesInFolder = Directory.GetFiles(_path)
				.Where(path => Path.GetExtension(path) == Extention)
				.Select(file => Path.GetFileName(file))
				.ToList();

			ChangedFilesListInFolder?.Invoke(_filesInFolder);
		}

		private void ClearFilesListForRead()
		{
			_filesForRead.Clear();
			ChangedFilesListForRead?.Invoke(_filesForRead);
		}

		private void GenerateFile(string fileName)
		{
			FileStream file = File.Create(fileName);
			file.Close();
			file.Dispose();
		}

		private bool IsValidateRange(int minValue, int maxValue) =>
			minValue < maxValue;

		private void ReadFile(string file)
		{
			string fileName = $"{_path}{file}";

			if (!File.Exists(fileName))
				return;

			using StreamReader reader = new StreamReader(fileName);
			string line = reader.ReadLine();

			while (line != null)
			{
				int numbersCount = 0;
				int maxNumbersCount = 1000;

				while (numbersCount < maxNumbersCount || line != null)
				{
					numbersCount++;
					_numberManager.Add(line);

					line = reader.ReadLine();
				}

				_numberManager.ProcessData();
			}
		}
	}
}
