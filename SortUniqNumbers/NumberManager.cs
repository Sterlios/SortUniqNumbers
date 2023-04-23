using System;
using System.Collections.Generic;
using System.Linq;

namespace SortUniqNumbers
{
    public class NumberManager
    {
        private static readonly Random _random = new Random();

        private FilterByModulo _filterByModulo = new FilterByModulo();
        private FilterByUniq _filterByUniq = new FilterByUniq();
        private List<int> _numbers = new List<int>(1000);

		public List<string> Result => 
            _numbers.Select(number => number.ToString()).ToList();

		public string GetData(int minCount, int maxCount) => 
            _random.Next(minCount, maxCount).ToString();
        
        public void Init(int divider, int modulo)
		{
            _filterByModulo.Init(divider, modulo);

            _numbers.Clear();
        }

		public void Add(string input)
        {
            if (!int.TryParse(input, out int number))
                return;

            _numbers.Add(number);
        }

        public void ProcessData()
        {
            List<int> uniqNumbers = _filterByUniq.GetUniqueNumbers(_numbers);

            _numbers = _numbers
                    .Where(number => _filterByModulo.Use(number) && uniqNumbers.Contains(number))
                    .OrderByDescending(number => number)
                    .ToList();
        }
	}
}
