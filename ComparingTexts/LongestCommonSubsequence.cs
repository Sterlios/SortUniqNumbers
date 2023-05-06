using System;
using System.Drawing;

namespace ComparingTexts
{
	class LongestCommonSubsequence : IComparable
	{
		public void Compare(string text1, string text2, out IReadOnlyColoredText coloredText1, out IReadOnlyColoredText coloredText2)
		{
			int[,] matrix = new int[text1.Length + 1, text2.Length + 1];

			for (int i = 0; i < text1.Length; i++)
				for (int j = 0; j < text2.Length; j++)
					matrix[i + 1, j + 1] = GetLengthSubsequence(text1, text2, matrix, i, j);

			GetResult(matrix, out coloredText1, out coloredText2);
		}

		private int GetLengthSubsequence(string text1, string text2, int[,] matrix, int i, int j)
		{
			if (text1[i] == text2[j])
				return 1 + matrix[i, j];
			else
				return Math.Max(matrix[i + 1, j], matrix[i, j + 1]);
		}

		private void GetResult(int[,] matrix, out IReadOnlyColoredText coloredText1, out IReadOnlyColoredText coloredText2)
		{
			coloredText1 = new ColoredText();
			coloredText2 = new ColoredText();

			int i = matrix.GetLength(0) - 1;
			int j = matrix.GetLength(1) - 1;

			while (matrix[i, j] > 0)
			{
				if (matrix[i, j] != matrix[i, j - 1] && matrix[i, j] != matrix[i - 1, j])
				{
					AddRange(coloredText1 as ColoredText, ref i, ColoredRange.NonChangedRangeColor);
					AddRange(coloredText2 as ColoredText, ref j, ColoredRange.NonChangedRangeColor);
				}
				else
				{
					if (matrix[i, j] == matrix[i, j - 1])
						AddRange(coloredText2 as ColoredText, ref j, ColoredRange.AdditionalRangeColor);
				
					if (matrix[i, j] == matrix[i - 1, j])
						AddRange(coloredText1 as ColoredText, ref i, ColoredRange.AdditionalRangeColor);
				}
			}

			if (i > 0)
				(coloredText1 as ColoredText).Add(new ColoredRange(0, i, ColoredRange.AdditionalRangeColor));

			if (j > 0)
				(coloredText2 as ColoredText).Add(new ColoredRange(0, j, ColoredRange.AdditionalRangeColor));
		}

		private void AddRange(ColoredText coloredText, ref int indexInText, Color color)
		{
			coloredText.Add(new ColoredRange(indexInText - 1, 1, color));
			indexInText--;
		}
	}
}
