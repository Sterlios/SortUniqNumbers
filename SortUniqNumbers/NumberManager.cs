using System;
using System.Collections.Generic;
using System.Linq;

namespace SortUniqNumbers
{
    public class NumberManager
    {
        private static Random _random = new Random();

        private int _minNumber;
        private int _maxNumber;
        private List<int> _numbers = new List<int>(1000);
        private List<int> _uniqNumbers = new List<int>(1000);

        public string GetData(int minCount, int maxCount)
        {
            if (_minNumber == 0 && _maxNumber == 0)
                Question.GetRange("\nЧисла в диапазоне:", out _minNumber, out _maxNumber);

            return _random.Next(_minNumber, _maxNumber).ToString();
        }

        public bool TryAdd(string input)
        {
            if (!int.TryParse(input, out int number))
                return false;

            _numbers.Add(number);
            return true;
        }

        public void ProcessData()
        {
            _uniqNumbers = FilterByUniq.GetUniqueNumbers(_numbers);

            _numbers = _numbers
                    .Where(number => FilterByModulo.Use(number) && _uniqNumbers.Contains(number))
                    .OrderByDescending(number => number)
                    .ToList();
        }

        public List<string> GetResult()
        {
            return _numbers.Select(number => number.ToString()).ToList();
        }
    }
}
