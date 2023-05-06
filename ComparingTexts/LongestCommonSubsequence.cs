using System;
using System.Collections.Generic;
using System.Drawing;

namespace ComparingTexts
{
	class LongestCommonSubsequence : IComparable
	{
		public void Compare(string text1, string text2, out List<SelectionRange> ranges1, out List<SelectionRange> ranges2)
		{
			int[,] matrix = new int[text1.Length + 1, text2.Length + 1];

			for (int i = 0; i < text1.Length; i++)
				for (int j = 0; j < text2.Length; j++)
					matrix[i + 1, j + 1] = GetLengthSubsequence(text1, text2, matrix, i, j);

			GetResult(matrix, out ranges1, out ranges2);
		}

		private int GetLengthSubsequence(string text1, string text2, int[,] matrix, int i, int j)
		{
			if (text1[i] == text2[j])
				return 1 + matrix[i, j];
			else
				return Math.Max(matrix[i + 1, j], matrix[i, j + 1]);
		}

		private void GetResult(int[,] matrix, out List<SelectionRange> ranges1, out List<SelectionRange> ranges2)
		{
			ranges1 = new List<SelectionRange>();
			ranges2 = new List<SelectionRange>();

			int i = matrix.GetLength(0) - 1;
			int j = matrix.GetLength(1) - 1;

			while (matrix[i, j] > 0)
			{
				if (matrix[i, j] != matrix[i, j - 1] && matrix[i, j] != matrix[i - 1, j])
				{
					AddRange(ranges1, ref i, SelectionRange.NonChangedRangeColor);
					AddRange(ranges2, ref j, SelectionRange.NonChangedRangeColor);
				}
				else
				{
					if (matrix[i, j] == matrix[i, j - 1])
						AddRange(ranges2, ref j, SelectionRange.AdditionalRangeColor);
				
					if (matrix[i, j] == matrix[i - 1, j])
						AddRange(ranges1, ref i, SelectionRange.AdditionalRangeColor);
				}
			}

			if (i > 0)
				ranges1.Add(new SelectionRange(0, i, SelectionRange.AdditionalRangeColor));

			if (j > 0)
				ranges2.Add(new SelectionRange(0, j, SelectionRange.AdditionalRangeColor));
		}

		private void AddRange(List<SelectionRange> target, ref int indexInText, Color color)
		{
			target.Add(new SelectionRange(indexInText - 1, 1, color));
			indexInText--;
		}
	}
}
