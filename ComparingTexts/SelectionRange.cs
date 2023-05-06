using System;
using System.Drawing;

namespace ComparingTexts
{
	public struct SelectionRange
	{
		public static readonly Color ChangedRangeColor = Color.Yellow;
		public static readonly Color AdditionalRangeColor = Color.LightGreen;
		public static readonly Color NonChangedRangeColor = Color.White;

		public SelectionRange(int start, int length, Color color)
		{
			Start = Math.Max(start, 0);
			Length = Math.Max(length, 1);
			Color = color;
		}

		public int Start { get; private set; }
		public int Length { get; private set; }
		public Color Color { get; private set; }
	}
}
