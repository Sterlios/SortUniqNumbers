using System;

namespace SortUniqNumbers
{
    public static class FilterByModulo
    {
		public static bool Use(int number, int divider, int modulo) => 
            number % divider == modulo;
    }
}
