using System;

namespace SortUniqNumbers
{
    public static class FilterByModulo
    {
        private static int _devider;
        private static int _remainder;
        private static bool _isInit;

        public static void Reset()
        {
            _isInit = false;
        }

        public static bool Use(int number)
        {
            if (_isInit == false)
                Init();

            return number % _devider == _remainder;
        }

        private static void Init()
        {
            _isInit = true;

            InitDevider();
            InitRemainder();
        }

        private static void InitDevider()
        {
            bool isCorrectNumber = false;
            int devider = 1;

            while (isCorrectNumber == false)
            {
                devider = Question.GetNumber("\nВведите делитель.");

                if (devider <= 0)
                    Console.WriteLine("Делитель должен быть больше 0.\n" +
                        "Попробуйте еще раз!");
                else
                    isCorrectNumber = true;
            }

            _devider = devider;
        }

        private static void InitRemainder()
        {
            bool isCorrectNumber = false;
            int remainder = 0;

            while (isCorrectNumber == false)
            {
                remainder = Question.GetNumber("\nВведите остаток от деления");
                int maxRemainder = _devider - 1;

                if (remainder < 0 || remainder > maxRemainder)
                    Console.WriteLine($"Остаток от деления должен быть в диапазоне [0,{maxRemainder}].\n" +
                        "Попробуйте еще раз!");
                else
                    isCorrectNumber = true;
            }

            _remainder = remainder;
        }
    }
}
