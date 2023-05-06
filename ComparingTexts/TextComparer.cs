using System.Collections.Generic;
using System.Drawing;

namespace ComparingTexts
{
	class TextComparer : IComparable
	{
		public void Compare(string text1, string text2, out List<SelectionRange> text1ComparedRanges, out List<SelectionRange> text2ComparedRanges)
		{
			Text comparingText1 = new Text(text1);
			Text comparingText2 = new Text(text2);

			text1ComparedRanges = new List<SelectionRange>();
			text2ComparedRanges = new List<SelectionRange>();

			while (!comparingText1.IsEnd || !comparingText2.IsEnd)
			{
				if (comparingText1.Word == comparingText2.Word)
				{
					comparingText1.MoveNext();
					comparingText2.MoveNext();

					continue;
				}

				if (comparingText1.Word != string.Empty && comparingText2.Word != string.Empty)
					AddWordsByMatch(comparingText1, comparingText2, text1ComparedRanges, text2ComparedRanges); 
				else if (comparingText1.Word == string.Empty)
					AddCurrentWord(text1ComparedRanges, comparingText2, SelectionRange.AdditionalRangeColor);
				else
					AddCurrentWord(text1ComparedRanges, comparingText1, SelectionRange.AdditionalRangeColor);
			}
		}

		private void AddWordsByMatch(Text text1, Text text2, List<SelectionRange> text1ComparedRanges, List<SelectionRange> text2ComparedRanges)
		{
			bool sourceWordFounded = text1.TryGetDistanceToClosest(text2.Word, out int sourceWordDistance);
			bool resultWordFounded = text2.TryGetDistanceToClosest(text1.Word, out int resultWordDistance);

			if (!sourceWordFounded && !resultWordFounded)
				AddChangedWords(text1, text2, text1ComparedRanges, text2ComparedRanges);
			else if (sourceWordFounded && resultWordFounded)
				AddClosestWord(text1, text2, text1ComparedRanges, text2ComparedRanges, sourceWordDistance, resultWordDistance);
			else if (sourceWordFounded)
				AddCurrentWord(text1ComparedRanges, text1, SelectionRange.AdditionalRangeColor);
			else
				AddCurrentWord(text2ComparedRanges, text2, SelectionRange.AdditionalRangeColor);
		}

		private void AddClosestWord(Text text1, Text text2, List<SelectionRange> text1ComparedRanges, List<SelectionRange> text2ComparedRanges, int sourceWordDistance, int resultWordDistance)
		{
			if (sourceWordDistance <= resultWordDistance)
				AddCurrentWord(text1ComparedRanges, text1, SelectionRange.AdditionalRangeColor);
			else
				AddCurrentWord(text2ComparedRanges, text2, SelectionRange.AdditionalRangeColor);
		}

		private void AddChangedWords(Text text1, Text text2, List<SelectionRange> text1ComparedRanges, List<SelectionRange> text2ComparedRanges)
		{
			AddCurrentWord(text1ComparedRanges, text1, SelectionRange.ChangedRangeColor);
			AddCurrentWord(text2ComparedRanges, text2, SelectionRange.ChangedRangeColor);
		}

		private void AddCurrentWord(List<SelectionRange> comparedRanges, Text text, Color color)
		{
			comparedRanges.Add(new SelectionRange(text.GetCurrentPosition(), text.Word.Length, color));

			text.MoveNext();
		}
	}
}
