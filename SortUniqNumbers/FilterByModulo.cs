using System;

namespace SortUniqNumbers
{
    public static class FilterByModulo
    {
		private static int _divider;
		private static int _modulo;

		internal static void Init(int divider, int modulo)
		{
			_divider = divider;
			_modulo = modulo;
		}

		internal static bool Use(int number) => 
            number % _divider == _modulo;
	}
}
