using System;
using System.Drawing;

namespace ComparingTexts
{
	class LongestCommonSubsequence : IComparable
	{
		private ColoredText _coloredText1;
		private ColoredText _coloredText2;
		private int[,] _matrix;

		public void Compare(string text1, string text2, out IReadOnlyColoredText iColoredText1, out IReadOnlyColoredText iColoredText2)
		{
			_coloredText1 = new ColoredText(text1, text1.Length - 1);
			_coloredText2 = new ColoredText(text2, text2.Length - 1);

			FillMatrix();

			FillRanges();

			iColoredText1 = _coloredText1;
			iColoredText2 = _coloredText2;

			_matrix = null;
		}

		private void FillMatrix()
		{
			_matrix = new int[_coloredText1.Text.Length + 1, _coloredText2.Text.Length + 1];

			for (int row = 0; row < _coloredText1.Text.Length; row++)
				for (int column = 0; column < _coloredText2.Text.Length; column++)
					_matrix[row + 1, column + 1] = GetLengthSubsequence(row, column);
		}

		private int GetLengthSubsequence(int row, int column)
		{
			if (_coloredText1.Text[row] == _coloredText2.Text[column])
				return 1 + _matrix[row, column];
			else
				return Math.Max(_matrix[row + 1, column], _matrix[row, column + 1]);
		}

		private void FillRanges()
		{
			int startPositionInText = 0;

			int row = _matrix.GetLength(0) - 1;
			int column = _matrix.GetLength(1) - 1;

			while (_matrix[row, column] > 0)
			{
				bool isAddedRange1 = TryAddRange(_coloredText1, _matrix[row, column], _matrix[row - 1, column], _matrix[row, column - 1]);
				bool isAddedRange2 = TryAddRange(_coloredText2, _matrix[row, column], _matrix[row, column - 1], _matrix[row - 1, column]);

				if (isAddedRange1)
					row--;

				if (isAddedRange2)
					column--;
			}

			_coloredText1.Add(new ColoredRange(startPositionInText, _coloredText1.Text.Substring(startPositionInText, _coloredText1.CurrentIndex), ColoredRange.AdditionalRangeColor));
			_coloredText2.Add(new ColoredRange(startPositionInText, _coloredText2.Text.Substring(startPositionInText, _coloredText2.CurrentIndex), ColoredRange.AdditionalRangeColor));
		}

		private bool TryAddRange(ColoredText coloredText, int currentElement, int previousElementInCurrentText, int previousElementInOtherText)
		{
			bool isEqual = TryAddEqualsElement(coloredText, currentElement, previousElementInCurrentText, previousElementInOtherText);
			bool isChanged = TryAddChangedElement(coloredText, currentElement, previousElementInCurrentText, previousElementInOtherText);
			bool isNewElement = TryAddNewElement(coloredText, currentElement, previousElementInCurrentText, previousElementInOtherText);

			return isEqual || isChanged || isNewElement;
		}

		private bool TryAddEqualsElement(ColoredText coloredText, int currentElement, int previousElementInCurrentText, int previousElementInOtherText)
		{
			bool expression = currentElement != previousElementInCurrentText && currentElement != previousElementInOtherText;

			return TryAddRangeByExpression(expression, coloredText, ColoredRange.NonChangedRangeColor);
		}

		private bool TryAddChangedElement(ColoredText coloredText, int currentElement, int previousElementInCurrentText, int previousElementInOtherText)
		{
			bool expression = currentElement == previousElementInCurrentText && currentElement == previousElementInOtherText;

			return TryAddRangeByExpression(expression, coloredText, ColoredRange.ChangedRangeColor);
		}

		private bool TryAddNewElement(ColoredText coloredText, int currentElement, int previousElementInCurrentText, int previousElementInOtherText)
		{
			bool expression = currentElement == previousElementInCurrentText && currentElement != previousElementInOtherText;

			return TryAddRangeByExpression(expression, coloredText, ColoredRange.AdditionalRangeColor);
		}

		private bool TryAddRangeByExpression(bool expression, ColoredText coloredText, Color color)
		{
			if (!expression)
				return false;

			AddRange(coloredText, coloredText.Text.Substring(coloredText.CurrentIndex, 1), color);
			return true;
		}

		private void AddRange(ColoredText coloredText, string part, Color color)
		{
			coloredText.Add(new ColoredRange(coloredText.CurrentIndex, part, color));
			coloredText.MovePrevious();
		}
	}
}
