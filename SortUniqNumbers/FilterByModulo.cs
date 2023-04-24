namespace SortUniqNumbers
{
	public class FilterByModulo
	{
		private int _divider;
		private int _modulo;

		internal void Init(int divider, int modulo)
		{
			if (modulo < divider)
			{
				_divider = divider;
				_modulo = modulo;
			}
		}

		internal bool Use(int number) =>
			number % _divider == _modulo;
	}
}