using System.Collections.Generic;
using System.Linq;

namespace SortUniqNumbers
{
    static class FilterByUniq
    {
        public static List<int> GetUniqueNumbers(List<int> numbers)
        {
            return numbers
                .GroupBy(currentNumber => currentNumber)
                .Where(uniqueNumber => uniqueNumber.Count() == 1)
                .Select(uniqueNumber => uniqueNumber.Key)
                .ToList();
        }
    }
}
