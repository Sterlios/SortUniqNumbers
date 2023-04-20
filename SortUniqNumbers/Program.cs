using System;

namespace SortUniqNumbers
{
	internal class Program
	{
		public static void Main()
		{
			bool isWork = true;

			while (isWork)
			{
				Console.Clear();

				FilterByModulo.Reset();
				FileManager fileManager = FileManager.Instance(new NumberManager());

				fileManager.InitFiles();
				fileManager.ReadFiles();
				fileManager.SaveResult();

				isWork = Question.GetAnswerYesOrNo("\nПродолжить?");
			}
		}
	}
}