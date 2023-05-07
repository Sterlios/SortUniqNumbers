using System;
using System.Drawing;

namespace ComparingTexts
{
	class LongestCommonSubsequence : IComparable
	{
		public void Compare(string text1, string text2, out IReadOnlyColoredText iColoredText1, out IReadOnlyColoredText iColoredText2)
		{
			int[,] matrix = FillMatrix(text1, text2);

			GetResult(matrix, text1, text2, out ColoredText coloredText1, out ColoredText coloredText2);

			iColoredText1 = coloredText1;
			iColoredText2 = coloredText2;
		}

		private int[,] FillMatrix(string text1, string text2)
		{
			int[,] matrix = new int[text1.Length + 1, text2.Length + 1];

			for (int i = 0; i < text1.Length; i++)
				for (int j = 0; j < text2.Length; j++)
					matrix[i + 1, j + 1] = GetLengthSubsequence(text1[i], text2[j], matrix[i, j], matrix[i + 1, j], matrix[i, j + 1]);

			return matrix;
		}

		private int GetLengthSubsequence(char letter1, char letter2, int diagonalElement, int horizontalElement, int verticalElement)
		{
			if (letter1 == letter2)
				return 1 + diagonalElement;
			else
				return Math.Max(horizontalElement, verticalElement);
		}

		private void GetResult(int[,] matrix, string text1, string text2, out ColoredText coloredText1, out ColoredText coloredText2)
		{
			int startPositionInText = 0;
			int row = matrix.GetLength(0) - 1;
			int column = matrix.GetLength(1) - 1;

			coloredText1 = new ColoredText();
			coloredText2 = new ColoredText();

			while (matrix[row, column] > 0)
			{
				bool isAddedRange1 = TryAddRange(matrix[row, column], matrix[row - 1, column], matrix[row, column - 1], text1, coloredText1, row);
				bool isAddedRange2 = TryAddRange(matrix[row, column], matrix[row, column - 1], matrix[row - 1, column], text2, coloredText2, column);

				if (isAddedRange1)
					row--;

				if (isAddedRange2)
					column--;
			}

			AddRange(coloredText1, text1.Substring(startPositionInText, row), ColoredRange.AdditionalRangeColor, startPositionInText);
			AddRange(coloredText2, text2.Substring(startPositionInText, column), ColoredRange.AdditionalRangeColor, startPositionInText);
		}

		private bool TryAddRange(int currentElement, int previousElementInCurrentText, int previousElementInOtherText, string text, ColoredText coloredText, int index)
		{
			bool isEqual = TryAddEqualsElement(currentElement, previousElementInCurrentText, previousElementInOtherText, text, coloredText, index);
			bool isChanged = TryAddChangedElement(currentElement, previousElementInCurrentText, previousElementInOtherText, text, coloredText, index);
			bool isNewElement = TryAddNewElement(currentElement, previousElementInCurrentText, previousElementInOtherText, text, coloredText, index);

			return isEqual || isChanged || isNewElement;
		}

		private bool TryAddEqualsElement(int currentElement, int previousElementInCurrentText, int previousElementInOtherText, string text, ColoredText coloredText, int index)
		{
			bool expression = currentElement != previousElementInCurrentText && currentElement != previousElementInOtherText;

			return TryAddRangeByExpression(expression, text, coloredText, index, ColoredRange.NonChangedRangeColor);
		}

		private bool TryAddChangedElement(int currentElement, int previousElementInCurrentText, int previousElementInOtherText, string text, ColoredText coloredText, int index)
		{
			bool expression = currentElement == previousElementInCurrentText && currentElement == previousElementInOtherText;

			return TryAddRangeByExpression(expression, text, coloredText, index, ColoredRange.ChangedRangeColor);
		}

		private bool TryAddNewElement(int currentElement, int previousElementInCurrentText, int previousElementInOtherText, string text, ColoredText coloredText, int index)
		{
			bool expression = currentElement == previousElementInCurrentText && currentElement != previousElementInOtherText;

			return TryAddRangeByExpression(expression, text, coloredText, index, ColoredRange.AdditionalRangeColor);
		}

		private bool TryAddRangeByExpression(bool expression, string text, ColoredText coloredText, int index, Color color)
		{
			if (!expression)
				return false;

			AddRange(coloredText, text.Substring(index - 1, 1), color, index);
			return true;
		}

		private void AddRange(ColoredText coloredText, string part, Color color, int index)
		{
			coloredText.Add(new ColoredRange(index - 1, part, color));
		}
	}
}
