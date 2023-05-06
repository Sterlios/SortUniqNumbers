using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
