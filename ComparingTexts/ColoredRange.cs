using System;
using System.Drawing;

namespace ComparingTexts
{
	public struct ColoredRange
	{
		public static readonly Color ChangedRangeColor = Color.Yellow;
		public static readonly Color AdditionalRangeColor = Color.LightGreen;
		public static readonly Color NonChangedRangeColor = Color.White;

		private int _start;
		private string _part;

		public ColoredRange(int start, string part, Color color)
		{
			_start = start;
			_part = part;
			Color = color;
		}

		public int Start {
			get
			{
				if (IsVisiblePart)
					return Math.Max(_start, 0);

				return Math.Max(_start + 1, 0);
			}
		}

		public int Length => _part.Length;

		public Color Color { get; private set; }

		private bool IsVisiblePart => _part != "\n";
	}
}
