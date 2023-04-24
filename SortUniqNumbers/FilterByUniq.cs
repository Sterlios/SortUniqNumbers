using System.Collections.Generic;
using System.Linq;

namespace SortUniqNumbers
{
	public class FilterByUniq
	{
		private readonly List<int> _notUniqNumbers = new List<int>();

		public void Reset() =>
			_notUniqNumbers.Clear();
    
		public List<int> GetUniqueNumbers(List<int> numbers)
		{
			_notUniqNumbers.AddRange(numbers
				.GroupBy(currentNumber => currentNumber)
				.Where(uniqueNumber => uniqueNumber.Count() > 1)
				.Select(uniqueNumber => uniqueNumber.Key)
				.ToList());

			return numbers
				.Where(number => !_notUniqNumbers.Contains(number))
				.ToList();
		}
	}
}
