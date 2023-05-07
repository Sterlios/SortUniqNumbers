using System.Collections.Generic;

namespace ComparingTexts
{
	public class ColoredText : IReadOnlyColoredText
	{
		private readonly List<ColoredRange> _ranges;

		public ColoredText(string text, int startIndex)
		{
			Text = text;
			CurrentIndex = startIndex;
			_ranges = new List<ColoredRange>();
		}

		public int CurrentIndex { get; private set; }
		public string Text { get; private set; }
		public IReadOnlyList<ColoredRange> Ranges => _ranges;

		public void MovePrevious()
		{
			if (CurrentIndex == 0)
				return;

			CurrentIndex--;
		}

		public void Add(ColoredRange selectionRange)
		{
			_ranges.Add(selectionRange);
		}
	}
}
