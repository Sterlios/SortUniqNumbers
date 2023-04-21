using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SortUniqNumbers
{
	public class FileManager
	{
		private const string Extention = ".txt";

		private static FileManager _fileManager;
		private static Random _random = new Random();
		private static NumberManager _numberManager;

		private List<string> _filesInFolder;
		private List<string> _filesForRead;
		private string _path;

		private FileManager()
		{
			_filesInFolder = new List<string>(100);
			_filesForRead = new List<string>(100);
			_path = $"{Directory.GetCurrentDirectory()}\\Source\\";
			ChangedPath?.Invoke(_path);
		}

		public Action<string> ChangedPath;
		public Action<IReadOnlyList<string>> ChangedFilesListInFolder;
		public Action<IReadOnlyList<string>> ChangedFilesListForRead;

		public static FileManager Instance()
		{
			if (_fileManager is null)
				_fileManager = new FileManager();

			_numberManager = new NumberManager();
			return _fileManager;
		}

		public void Init()
		{
			ChangePath(_path);
		}

		public void ChangePath(string newPath)
		{
			_path = $"{newPath}\\";;

			if (!Directory.Exists(newPath))
				Directory.CreateDirectory(_path);

			ChangedPath?.Invoke(_path);

			UpdateFilesListInFolder();
			ClearFilesListForRead();
		}

		private void ClearFilesListForRead()
		{
			_filesForRead.Clear();
			ChangedFilesListForRead?.Invoke(_filesForRead);
		}

		public void AddFilesListForRead(IEnumerable<string> files)
		{
			foreach (var file in files)
				if (_filesInFolder.Contains($"{_path}{file}") && !_filesForRead.Contains(file))
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

		private void UpdateFilesListInFolder()
		{
			_filesInFolder = Directory.GetFiles(_path).Where(path => Path.GetExtension(path) == Extention).ToList();
			
			ChangedFilesListInFolder?.Invoke(_filesInFolder);
		}

		public void InitFiles()
		{
			if (IsEmptyPath())
				return;

			bool isInit = false;

			while (isInit == false)
			{
				_filesInFolder = Directory.GetFiles(_path).Where(path => Path.GetExtension(path) == Extention).ToList();

				Console.WriteLine($"\nКоличество '{Extention}' файлов в каталоге: {_filesInFolder.Count}");

				if (_filesInFolder.Count > 0)
				{
					isInit = DeleteFiles() == false;
				}
				else
				{
					isInit = true;
				}
			}
		}

		public void ReadFiles()
		{
			if (_filesInFolder.Count < 0)
			{
				Console.WriteLine("\nСначала надо получить список файлов из каталога!");
				return;
			}

			foreach (string file in _filesInFolder)
				ReadFile(file);

			Console.WriteLine("\nВсе файлы обработаны!");
		}

		public void SaveResult()
		{
			List<string> result = _numberManager.GetResult();

			string resultFileName = $"{_path}\\Result{Extention}";
			GenerateFile(resultFileName);

			using (StreamWriter writer = new StreamWriter(resultFileName))
				foreach (var element in result)
					writer.WriteLine(element);

			Console.WriteLine("\nРезультат сохранен в файле:\n" +
				$"{resultFileName}");
		}

		private bool IsEmptyPath()
		{
			if (string.IsNullOrEmpty(_path))
			{
				Console.WriteLine("Сначала задайте каталог.");
				return true;
			}

			return false;
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

		private void GenerateFile(string fileName)
		{
			FileStream file = File.Create(fileName);
			file.Close();
			file.Dispose();
		}

		public void FillFiles(int minCount, int maxCount, int minNumber, int maxNumber)
		{
			foreach (string file in _filesInFolder)
			{
				using (StreamWriter writer = new StreamWriter(file))
				{
					int dataCount = _random.Next(minCount, maxCount);

					for (int i = 0; i < dataCount; i++)
						writer.WriteLine(_numberManager.GetData(minNumber, maxNumber));
				}
			}
		}

		private void ReadFile(string file)
		{
			if (!File.Exists(file))
				return;

			using (StreamReader reader = new StreamReader(file))
			{
				bool endOfFile = false;
				StringBuilder line = new StringBuilder();

				while (!endOfFile)
				{
					int numbersCount = 0;
					int maxNumbersCount = 1000;
					bool isContinue = true;

					while (isContinue)
					{
						line.Clear();
						line.AppendLine(reader.ReadLine());
						isContinue = !string.IsNullOrWhiteSpace(line.ToString());

						if (!isContinue)
						{
							endOfFile = true;
						}
						else if (_numberManager.TryAdd(line.ToString()))
						{
							numbersCount++;
							isContinue = numbersCount < maxNumbersCount;
						}
					}

					_numberManager.ProcessData();
				}
			}
		}

		private void GetDataCountRange(out int minCount, out int maxCount)
		{
			bool isCorrectRange = false;

			minCount = 0;
			maxCount = 0;

			while (isCorrectRange == false)
			{
				Question.GetRange("\nКоличество данных в каждом файле:", out minCount, out maxCount);

				if (minCount < 0 || maxCount < 0)
					Console.WriteLine("Количество должно быть больше 0.\n" +
						"Попробуйте еще раз!");
				else
					isCorrectRange = true;
			}
		}

		private bool DeleteFiles()
		{
			bool confirmedDelete = Question.GetAnswerYesOrNo($"\nУдалить '{Extention}' файлы?");

			if (confirmedDelete)
			{
				foreach (string file in _filesInFolder)
					File.Delete(file);

				_filesInFolder.Clear();
			}

			return confirmedDelete;
		}
	}
}
