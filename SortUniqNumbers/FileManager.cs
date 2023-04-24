using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SortUniqNumbers
{
	public class FileManager
	{
		private const string Extention = ".txt";

		private static readonly Random _random = new Random();
		private static readonly NumberManager _numberManager = new NumberManager();
		private static FileManager _fileManager;

		private readonly FileSystemWatcher _watcher = new FileSystemWatcher();
		private List<string> _filesInFolder = new List<string>(100);
		private List<string> _selectedFiles = new List<string>(100);
		private string _path;

		public Action<string> ChangedPath;
		public Action<string, MessageType> SentMessage;
		public Action<IReadOnlyList<string>> ChangedFilesListInFolder;
		public Action<IReadOnlyList<string>> ChangedSelectedFilesList;

		public static FileManager Instance()
		{
			if (_fileManager is null)
				_fileManager = new FileManager();

			return _fileManager;
		}

		public void Init() =>
			ChangePath($"{Directory.GetCurrentDirectory()}\\Source");

		public void ChangePath(string newPath)
		{
			_path = $"{newPath}\\";

			if (!Directory.Exists(newPath))
				Directory.CreateDirectory(_path);

			ChangedPath?.Invoke(_path);
			SentMessage?.Invoke("Путь к папке с данными изменен", MessageType.Info);

			ListenFolder();
			UpdateList();
			ClearFilesListForRead();
		}

		public void AddToSelectedFilesList(IEnumerable<string> files)
		{
			foreach (var file in files)
				if (_filesInFolder.Contains(file) && !_selectedFiles.Contains(file))
					_selectedFiles.Add(file);

			SentMessage?.Invoke("Список выбранных файлов изменен", MessageType.Info);
			ChangedSelectedFilesList?.Invoke(_selectedFiles);
		}

		public void RemoveFromSelectedFilesList(IEnumerable<string> files)
		{
			foreach (var file in files)
				if (_selectedFiles.Contains(file))
					_selectedFiles.Remove(file);

			SentMessage?.Invoke("Список выбранных файлов изменен", MessageType.Info);
			ChangedSelectedFilesList?.Invoke(_selectedFiles);
		}

		public void ReadFiles(int divider, int modulo)
		{
			if (_selectedFiles.Count <= 0)
			{
				SentMessage?.Invoke("Список выбранных файлов пуст", MessageType.Error);
				return;
			}

			SentMessage?.Invoke("Данные обрабатываются", MessageType.Info);
			_numberManager.Init(divider, modulo);

			foreach (string file in _selectedFiles)
				ReadFile(file);

			SentMessage?.Invoke("Все данные обработаны", MessageType.Ready);
		}

		public void SaveResult()
		{
			List<string> result = _numberManager.Result;

			string resultFileName = $"Result{Extention}";
			string fullResultFileName = $"{_path}{resultFileName}";

			SentMessage?.Invoke($"Результат сохраняется в файл {resultFileName}", MessageType.Info);

			using StreamWriter writer = new StreamWriter(fullResultFileName);

			foreach (var element in result)
				writer.WriteLine(element);

			SentMessage?.Invoke($"Результат сохранен в файл {resultFileName}", MessageType.Ready);
		}

		public void GenerateSourceFiles(int filesCount)
		{
			if (filesCount <= 0)
			{
				SentMessage?.Invoke($"Количество файлов должно быть больше 0", MessageType.Error);
				return;
			}

			SentMessage?.Invoke("Файлы создаются", MessageType.Info);

			for (int i = 0; i < filesCount; i++)
			{
				string fileName = $"{_path}/{i}{Extention}";
				using FileStream file = File.Create(fileName);
			}

			UpdateFilesListInFolder();
			SentMessage?.Invoke("Файлы созданы", MessageType.Ready);
		}

		public void FillFiles(int minCount, int maxCount, int minNumber, int maxNumber)
		{
			if (!IsValideRange(minCount, maxCount) || minCount <= 0)
			{
				SentMessage?.Invoke("Диапазон количества чисел некорректен", MessageType.Error);
				return;
			}

			if (!IsValideRange(minNumber, maxNumber))
			{
				SentMessage?.Invoke("Диапазон чисел некорректен", MessageType.Error);
				return;
			}

			SentMessage?.Invoke("Заполнение файлов", MessageType.Info);

			foreach (string file in _filesInFolder)
				FillFile(file, minCount, maxCount, minNumber, maxNumber);

			SentMessage?.Invoke("Все файлы заполнены", MessageType.Ready);
		}

		private void FillFile(string file, int minCount, int maxCount, int minNumber, int maxNumber)
		{
			SentMessage?.Invoke($"Заполнение файлa {file}", MessageType.Info);

			using StreamWriter writer = new StreamWriter($"{_path}{file}");
			int dataCount = _random.Next(minCount, maxCount);

			for (int i = 0; i < dataCount; i++)
				writer.WriteLine(_numberManager.GetData(minNumber, maxNumber));

			SentMessage?.Invoke($"Файл {file} заполнен", MessageType.Ready);
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

			if (_selectedFiles.IndexOf(oldName) >= 0)
			{
				_selectedFiles[_selectedFiles.IndexOf(oldName)] = newName;
				ChangedSelectedFilesList?.Invoke(_selectedFiles);
			}
		}

		private void UpdateList()
		{
			UpdateFilesListForRead();
			UpdateFilesListInFolder();
		}

		private void UpdateFilesListForRead()
		{
			_selectedFiles = Directory.GetFiles(_path)
				.Where(file => _selectedFiles.Contains(Path.GetFileName(file)))
				.Select(file => Path.GetFileName(file))
				.ToList();

			ChangedSelectedFilesList?.Invoke(_selectedFiles);
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
			_selectedFiles.Clear();
			ChangedSelectedFilesList?.Invoke(_selectedFiles);
		}
    
		private bool IsValideRange(int minValue, int maxValue) =>
			minValue < maxValue;

		private void ReadFile(string file)
		{
			string fileName = $"{_path}{file}";

			if (!File.Exists(fileName))
				return;

			SentMessage?.Invoke($"Обрабатывается файл {file}", MessageType.Info);

			using StreamReader reader = new StreamReader(fileName);
			string line = reader.ReadLine();

			while (line != null)
			{
				int numbersCount = 0;
				int maxNumbersCount = 1000;

				while (numbersCount < maxNumbersCount && line != null)
				{
					numbersCount++;
					_numberManager.Add(line);

					line = reader.ReadLine();
				}

				_numberManager.ProcessData();
			}

			SentMessage?.Invoke($"Файл {file} обработан", MessageType.Ready);
		}
	}
}
