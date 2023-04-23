﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SortUniqNumbers
{
    public class NumberManager
    {
        private static readonly Random _random = new Random();

        private int _divider;
        private int _modulo;

        private List<int> _numbers = new List<int>(1000);

		public List<string> Result => 
            _numbers.Select(number => number.ToString()).ToList();

		public string GetData(int minCount, int maxCount) => 
            _random.Next(minCount, maxCount).ToString();
        
        public void Init(int  divider, int modulo)
		{
            _divider = divider;
            _modulo = modulo;

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
            List<int> uniqNumbers = FilterByUniq.GetUniqueNumbers(_numbers);

            _numbers = _numbers
                    .Where(number => FilterByModulo.Use(number, _divider, _modulo) && uniqNumbers.Contains(number))
                    .OrderByDescending(number => number)
                    .ToList();
        }
	}
}
