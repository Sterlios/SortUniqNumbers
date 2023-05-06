using System.Collections.Generic;

namespace ComparingTexts
{
	public interface IReadOnlyColoredText
	{
		IReadOnlyList<ColoredRange> Ranges { get; }
	}
}
