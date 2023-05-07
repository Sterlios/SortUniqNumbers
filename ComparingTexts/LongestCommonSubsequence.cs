using System;
using System.Drawing;

namespace ComparingTexts
{
	class LongestCommonSubsequence : IComparable
	{
		private string _text1;
		private string _text2;
		private int[,] _matrix;

		public void Compare(string text1, string text2, out IReadOnlyColoredText iColoredText1, out IReadOnlyColoredText iColoredText2)
		{
			_text1 = text1;
			_text2 = text2;
			_matrix = FillMatrix();

			GetResult(out ColoredText coloredText1, out ColoredText coloredText2);

			iColoredText1 = coloredText1;
			iColoredText2 = coloredText2;

			_text1 = null;
			_text2 = null;
			_matrix = null;
		}

		private int[,] FillMatrix()
		{
			int[,] matrix = new int[_text1.Length + 1, _text2.Length + 1];

			for (int row = 0; row < _text1.Length; row++)
				for (int column = 0; column < _text2.Length; column++)
					matrix[row + 1, column + 1] = GetLengthSubsequence(row, column);

			return matrix;
		}

		private int GetLengthSubsequence(int row, int column)
		{
			if (_text1[row] == _text2[column])
				return 1 + _matrix[row, column];
			else
				return Math.Max(_matrix[row + 1, column], _matrix[row, column + 1]);
		}

		private void GetResult(out ColoredText coloredText1, out ColoredText coloredText2)
		{
			int startPositionInText = 0;
			int row = _matrix.GetLength(0) - 1;
			int column = _matrix.GetLength(1) - 1;

			coloredText1 = new ColoredText();
			coloredText2 = new ColoredText();

			while (_matrix[row, column] > 0)
			{
				bool isAddedRange1 = TryAddRange(_matrix[row, column], _matrix[row - 1, column], _matrix[row, column - 1], _text1, coloredText1, row);
				bool isAddedRange2 = TryAddRange(_matrix[row, column], _matrix[row, column - 1], _matrix[row - 1, column], _text2, coloredText2, column);

				if (isAddedRange1)
					row--;

				if (isAddedRange2)
					column--;
			}

			AddRange(coloredText1, _text1.Substring(startPositionInText, row), ColoredRange.AdditionalRangeColor, startPositionInText);
			AddRange(coloredText2, _text2.Substring(startPositionInText, column), ColoredRange.AdditionalRangeColor, startPositionInText);
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
