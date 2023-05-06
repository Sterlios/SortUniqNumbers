using System.Collections.Generic;

namespace ComparingTexts
{
	public class ColoredText
	{
		private List<ColoredRange> _coloredRanges;

		public ColoredText()
		{
			_coloredRanges = new List<ColoredRange>();
		}

		public IReadOnlyList<ColoredRange> ColoredRanges => _coloredRanges;

		public void Add(ColoredRange selectionRange)
		{
			_coloredRanges.Add(selectionRange);
		}
	}
}
