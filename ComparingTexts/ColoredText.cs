using System.Collections.Generic;

namespace ComparingTexts
{
	public class ColoredText : IReadOnlyColoredText
	{
		private readonly List<ColoredRange> _ranges;

		public ColoredText()
		{
			_ranges = new List<ColoredRange>();
		}

		public IReadOnlyList<ColoredRange> Ranges => _ranges;

		public void Add(ColoredRange selectionRange)
		{
			_ranges.Add(selectionRange);
		}
	}
}
