using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparingTexts
{
	public interface IReadOnlyColoredText
	{
		IReadOnlyList<ColoredRange> ColoredRanges { get; }
	}
}
