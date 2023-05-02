using System;
using System.Drawing;

namespace ComparingTexts
{
	struct SelectionRange
	{
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
