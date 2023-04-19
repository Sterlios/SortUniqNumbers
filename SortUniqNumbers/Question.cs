using System;
using System.Collections.Generic;
using System.Text;

namespace SortUniqNumbers
{
    static class Question
    {
        public static bool GetAnswerYesOrNo(string question)
        {
            const string yesCommand = "y";
            const string noCommand = "n";

            bool isCorrectAnswer = false;
            bool answer = false;

            while (isCorrectAnswer == false)
            {
                Console.WriteLine($"{question} (Y/N)");
                Console.Write("Ответ: ");

                switch (Console.ReadLine().ToLower())
                {
                    case yesCommand:
                        answer = true;
                        isCorrectAnswer = true;
                        break;
                        
                    case noCommand:
                        answer = false;
                        isCorrectAnswer = true;
                        break;

                    default:
                        Console.WriteLine("Ответ не понятен. Попробуйте еще раз!");
                        break;
                }
            }

            return answer;
        }

        public static int GetNumber(string question)
        {
            int value = 0;
            bool isCorrectAnswer = false;

            while (isCorrectAnswer == false)
            {
                Console.WriteLine($"{question}");
                Console.Write("Ответ: ");

                if (int.TryParse(Console.ReadLine(), out value))
                    isCorrectAnswer = true;
                else
                    Console.WriteLine("Ответ не понятен. Попробуйте еще раз!");
            }

            return value;
        }

        public static void GetRange(string description, out int minValue, out int maxValue)
        {
            minValue = 0;
            maxValue = 0;
            bool isCorrectAnswer = minValue < maxValue;

            while (isCorrectAnswer == false)
            {
                Console.WriteLine(description);

                minValue = Question.GetNumber("Минимум");
                maxValue = Question.GetNumber("Максимум");

                isCorrectAnswer = minValue < maxValue;
                
                if (isCorrectAnswer == false)
                {
                    Console.WriteLine($"Минимальное значение ({minValue}) должно быть меньше максимального ({maxValue}).\n" +
                        $"Попробуйте еще раз!");
                }
            }
        }
    }
}
