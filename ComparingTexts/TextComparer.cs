﻿using System.Drawing;

namespace ComparingTexts
{
	class TextComparer : IComparable
	{
		public void Compare(string text1, string text2, out IReadOnlyColoredText coloredText1, out IReadOnlyColoredText coloredText2)
		{
			Text comparingText1 = new Text(text1);
			Text comparingText2 = new Text(text2);

			coloredText1 = new ColoredText(text1, 0);
			coloredText2 = new ColoredText(text2, 0);

			while (!comparingText1.IsEnd || !comparingText2.IsEnd)
			{
				if (comparingText1.Word == comparingText2.Word)
				{
					comparingText1.MoveNext();
					comparingText2.MoveNext();

					continue;
				}

				if (comparingText1.Word != string.Empty && comparingText2.Word != string.Empty)
					AddWordsByMatch(comparingText1, comparingText2, coloredText1 as ColoredText, coloredText2 as ColoredText); 
				else if (comparingText1.Word == string.Empty)
					AddCurrentWord(coloredText1 as ColoredText, comparingText2, ColoredRange.AdditionalRangeColor);
				else
					AddCurrentWord(coloredText2 as ColoredText, comparingText1, ColoredRange.AdditionalRangeColor);
			}
		}

		private void AddWordsByMatch(Text text1, Text text2, ColoredText coloredText1, ColoredText coloredText2)
		{
			bool sourceWordFounded = text1.TryGetDistanceToClosest(text2.Word, out int sourceWordDistance);
			bool resultWordFounded = text2.TryGetDistanceToClosest(text1.Word, out int resultWordDistance);

			if (!sourceWordFounded && !resultWordFounded)
				AddChangedWords(text1, text2, coloredText1, coloredText2);
			else if (sourceWordFounded && resultWordFounded)
				AddClosestWord(text1, text2, coloredText1, coloredText2, sourceWordDistance, resultWordDistance);
			else if (sourceWordFounded)
				AddCurrentWord(coloredText1, text1, ColoredRange.AdditionalRangeColor);
			else
				AddCurrentWord(coloredText2, text2, ColoredRange.AdditionalRangeColor);
		}

		private void AddClosestWord(Text text1, Text text2, ColoredText coloredText1, ColoredText coloredText2, int sourceWordDistance, int resultWordDistance)
		{
			if (sourceWordDistance <= resultWordDistance)
				AddCurrentWord(coloredText1, text1, ColoredRange.AdditionalRangeColor);
			else
				AddCurrentWord(coloredText2, text2, ColoredRange.AdditionalRangeColor);
		}

		private void AddChangedWords(Text text1, Text text2, ColoredText coloredText1, ColoredText coloredText2)
		{
			AddCurrentWord(coloredText1, text1, ColoredRange.ChangedRangeColor);
			AddCurrentWord(coloredText2, text2, ColoredRange.ChangedRangeColor);
		}

		private void AddCurrentWord(ColoredText coloredText, Text text, Color color)
		{
			coloredText.Add(new ColoredRange(text.GetCurrentPosition(), text.Word, color));

			text.MoveNext();
		}
	}
}
