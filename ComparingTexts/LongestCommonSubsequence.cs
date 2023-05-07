using System;
using System.Drawing;

namespace ComparingTexts
{
	class LongestCommonSubsequence : IComparable
	{
		public void Compare(string text1, string text2, out IReadOnlyColoredText iColoredText1, out IReadOnlyColoredText iColoredText2)
		{
			int[,] matrix = new int[text1.Length + 1, text2.Length + 1];

			for (int i = 0; i < text1.Length; i++)
				for (int j = 0; j < text2.Length; j++)
					matrix[i + 1, j + 1] = GetLengthSubsequence(text1, text2, matrix, i, j);

			GetResult(matrix, text1, text2, out ColoredText coloredText1, out ColoredText coloredText2);

			iColoredText1 = coloredText1;
			iColoredText2 = coloredText2;
		}

		private int GetLengthSubsequence(string text1, string text2, int[,] matrix, int i, int j)
		{
			if (text1[i] == text2[j])
				return 1 + matrix[i, j];
			else
				return Math.Max(matrix[i + 1, j], matrix[i, j + 1]);
		}

		private void GetResult(int[,] matrix, string text1, string text2, out ColoredText coloredText1, out ColoredText coloredText2)
		{
			coloredText1 = new ColoredText();
			coloredText2 = new ColoredText();

			int i = matrix.GetLength(0) - 1;
			int j = matrix.GetLength(1) - 1;

			while (matrix[i, j] > 0)
			{
				bool canAddRange1 = TryAddRange(matrix[i, j], matrix[i - 1, j], matrix[i, j - 1], text1, coloredText1, i);
				bool canAddRange2 = TryAddRange(matrix[i, j], matrix[i, j - 1], matrix[i - 1, j], text2, coloredText2, j);

				if (canAddRange1)
					i--;

				if (canAddRange2)
					j--;
			}

			coloredText1.Add(new ColoredRange(0, text1.Substring(0, i), ColoredRange.AdditionalRangeColor));
			coloredText2.Add(new ColoredRange(0, text2.Substring(0, j), ColoredRange.AdditionalRangeColor));
		}

		private bool TryAddRange(int currentElement, int previousElementInCurrentText, int previousElementInOtherText, string text, ColoredText coloredText, int index)
		{
			if (currentElement != previousElementInCurrentText && currentElement != previousElementInOtherText)
			{
				AddRange(coloredText, text.Substring(index - 1, 1), ColoredRange.NonChangedRangeColor, index);
				return true;
			}
			
			return TryAddChangedElement(currentElement, previousElementInCurrentText, text, coloredText, index);
		}

		private bool TryAddChangedElement(int currentElement, int previousElement, string text, ColoredText coloredText, int index)
		{
			if (currentElement != previousElement)
				return false;

			AddRange(coloredText, text.Substring(index - 1, 1), ColoredRange.AdditionalRangeColor, index);
			return true;
		}

		private void AddRange(ColoredText coloredText, string part, Color color, int index)
		{
			coloredText.Add(new ColoredRange(index - 1, part, color));
		}
	}
}
