using System;
using System.Collections.Generic;
using System.Linq;

namespace SortUniqNumbers
{
    public class NumberManager
    {
        private static Random _random = new Random();

        private List<int> _numbers = new List<int>(1000);
        private List<int> _uniqNumbers = new List<int>(1000);

		public string GetData(int minCount, int maxCount) => 
            _random.Next(minCount, maxCount).ToString();

		public bool TryAdd(string input)
        {
            if (!int.TryParse(input, out int number))
                return false;

            _numbers.Add(number);
            return true;
        }

        public void ProcessData(int divider, int modulo)
        {
            _uniqNumbers = FilterByUniq.GetUniqueNumbers(_numbers);

            _numbers = _numbers
                    .Where(number => FilterByModulo.Use(number, divider, modulo) && _uniqNumbers.Contains(number))
                    .OrderByDescending(number => number)
                    .ToList();
        }

        public List<string> GetResult()
        {
            return _numbers.Select(number => number.ToString()).ToList();
        }
    }
}
