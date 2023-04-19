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
                NumberManager numberManager = new NumberManager();
                FileManager fileManager = FileManager.Instance(numberManager);

                fileManager.InitPath();
                fileManager.InitFiles();
                fileManager.ReadFiles();
                fileManager.SaveResult();

                isWork = Question.GetAnswerYesOrNo("\nПродолжить?");
            }
        }
    }
}