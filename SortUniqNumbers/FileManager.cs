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

		private List<string> _files;
		private string _path;

		private FileManager()
		{
			_files = new List<string>(100);
			_path = $"{Directory.GetCurrentDirectory()}\\Source\\";
			ChangedPath?.Invoke(_path);
		}

		public Action<string> ChangedPath;

		public static FileManager Instance()
		{
			if (_fileManager is null)
				_fileManager = new FileManager();

			_numberManager = new NumberManager();
			return _fileManager;
		}

		public void Init()
		{
			ChangePath($"{Directory.GetCurrentDirectory()}\\Source\\");
		}

		public void ChangePath(string newPath)
		{
			if (!Directory.Exists(newPath))
				_path = Directory.CreateDirectory(newPath).FullName;

			_path = newPath;
			ChangedPath?.Invoke(_path);
		}

		public void InitFiles()
		{
			if (IsEmptyPath())
				return;

			bool isInit = false;

			while (isInit == false)
			{
				_files = Directory.GetFiles(_path).Where(path => Path.GetExtension(path) == Extention).ToList();

				Console.WriteLine($"\nКоличество '{Extention}' файлов в каталоге: {_files.Count}");

				if (_files.Count > 0)
				{
					isInit = DeleteFiles() == false;
				}
				else
				{
					GenerateFiles();
					FillFiles();
					isInit = true;
				}
			}
		}

		public void ReadFiles()
		{
			if (_files.Count < 0)
			{
				Console.WriteLine("\nСначала надо получить список файлов из каталога!");
				return;
			}

			foreach (string file in _files)
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

		private bool TrySetPath()
		{
			bool isCorrectPath;

			Console.WriteLine("\nВведите каталог: ");
			string path = Console.ReadLine();

			if (!Directory.Exists(path))
				Console.WriteLine("\nТакого каталога не существует! (Будет создан новый каталог)");

			try
			{
				path = new DirectoryInfo(path).FullName;

				isCorrectPath = TryChangePath(path);
			}
			catch
			{
				Console.WriteLine($"\nЧто-то пошло не так. Каталог [{path}] не удалось получить.");

				isCorrectPath = TrySetDefaultPath();
			}

			return isCorrectPath;
		}

		private bool TrySetDefaultPath()
		{
			string path = $"{Directory.GetCurrentDirectory()}\\Source\\";

			return TryChangePath(path);
		}

		private bool TryChangePath(string path)
		{
			bool isCorrectPath = IsConfirmedPath(path);

			if (isCorrectPath)
				ChangePath(path);

			return isCorrectPath;
		}

		private bool IsConfirmedPath(string path)
		{
			Console.WriteLine($"\nКаталог: {path}");

			return Question.GetAnswerYesOrNo("Перейти к каталогу?");
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

		private void GenerateFiles()
		{
			int filesCount = GetFilesCount();

			for (int i = 0; i < filesCount; i++)
			{
				string fileName = $"{_path}/{i}{Extention}";
				GenerateFile(fileName);
				_files.Add(fileName);
			}
		}

		private int GetFilesCount()
		{
			bool isCorrectCount = false;
			int filesCount = 0;

			while (isCorrectCount == false)
			{
				filesCount = Question.GetNumber("\nСколько файлов создать?");

				if (filesCount <= 0)
					Console.WriteLine("Количество должно быть больше 0.\n" +
						"Попробуйте еще раз!");
				else
					isCorrectCount = true;
			}

			return filesCount;
		}

		private void GenerateFile(string fileName)
		{
			FileStream file = File.Create(fileName);
			file.Close();
			file.Dispose();
		}

		private void FillFiles()
		{
			GetDataCountRange(out int minCount, out int maxCount);

			foreach (string file in _files)
			{
				using (StreamWriter writer = new StreamWriter(file))
				{
					int dataCount = _random.Next(minCount, maxCount);

					for (int i = 0; i < dataCount; i++)
						writer.WriteLine(_numberManager.GetData());
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
				foreach (string file in _files)
					File.Delete(file);

				_files.Clear();
			}

			return confirmedDelete;
		}
	}
}
