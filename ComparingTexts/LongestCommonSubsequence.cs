using System;
using System.Collections.Generic;
using System.Drawing;

namespace ComparingTexts
{
	class LongestCommonSubsequence : IComparable
	{
		private string _text1;
		private string _text2;

		public void Compare(string text1, string text2, out List<SelectionRange> ranges1, out List<SelectionRange> ranges2)
		{
			int[,] matrix = new int[text1.Length + 1, text2.Length + 1];

			_text1 = text1;
			_text2 = text2;

			for (int i = 0; i < matrix.GetLength(0) - 1; i++)
				for (int j = 0; j < matrix.GetLength(1) - 1; j++)
					matrix[i + 1, j + 1] = GetLengthSubsequence(matrix, i, j);

			Split(matrix, out ranges1, out ranges2);
		}

		private int GetLengthSubsequence(int[,] matrix, int i, int j)
		{
			if (_text1[i] == _text2[j])
				return 1 + matrix[i, j];
			else
				return Math.Max(matrix[i + 1, j], matrix[i, j + 1]);
		}

		private void Split(int[,] matrix, out List<SelectionRange> ranges1, out List<SelectionRange> ranges2)
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
