using System.Collections.Generic;

namespace ComparingTexts
{
	public interface IComparable
	{
		void Compare(string text1, string text2, out List<SelectionRange> text1ComparedRanges, out List<SelectionRange> text2ComparedRanges);
	}
}
