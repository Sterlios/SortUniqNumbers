using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparingTexts
{
	public interface IColoredText
	{
		IReadOnlyList<ColoredRange> ColoredRanges { get; }
	}
}
