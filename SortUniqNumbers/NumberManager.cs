using System;
using System.Collections.Generic;
using System.Linq;

namespace SortUniqNumbers
{
    public class NumberManager
    {
        private static Random _random = new Random();

        private int _divider;
        private int _modulo;

        private List<int> _numbers = new List<int>(1000);
        private List<int> _uniqNumbers = new List<int>(1000);

		public string GetData(int minCount, int maxCount) => 
            _random.Next(minCount, maxCount).ToString();
        
        public void Init(int  divider, int modulo)
		{
            _divider = divider;
            _modulo = modulo;

            _numbers.Clear();
            _uniqNumbers.Clear();
        }

		public void Add(string? input)
        {
            if (!int.TryParse(input, out int number))
                return;

            _numbers.Add(number);
        }

        public void ProcessData()
        {
            _uniqNumbers = FilterByUniq.GetUniqueNumbers(_numbers);

            _numbers = _numbers
                    .Where(number => FilterByModulo.Use(number, _divider, _modulo) && _uniqNumbers.Contains(number))
                    .OrderByDescending(number => number)
                    .ToList();
        }

        public List<string> GetResult()
        {
            return _numbers.Select(number => number.ToString()).ToList();
        }
    }
}
