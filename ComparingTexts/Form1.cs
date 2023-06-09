﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace ComparingTexts
{
	public partial class Form1 : Form
	{
		private IComparable _comparable;

		public Form1(IComparable comparable)
		{
			InitializeComponent();
			_comparable = comparable;
		}

		private void CompareButton_Click(object sender, EventArgs e)
		{
			ClearBackgroundColor(sourceText);
			ClearBackgroundColor(resultText);

			_comparable.Compare(sourceText.Text, resultText.Text, out IReadOnlyColoredText coloredText1, out IReadOnlyColoredText coloredText2);

			PaintText(sourceText, coloredText1);
			PaintText(resultText, coloredText2);
		}

		private void ClearBackgroundColor(RichTextBox richTextBox)
		{
			richTextBox.SelectAll();
			richTextBox.SelectionBackColor = Color.White;
		}

		private void PaintText(RichTextBox richTextBox, IReadOnlyColoredText coloredText)
		{
			foreach (var range in coloredText.Ranges)
				PaintRange(richTextBox, range);
		}

		private void PaintRange(RichTextBox richTextBox, ColoredRange range)
		{
			richTextBox.Select(range.Start, range.Length);
			richTextBox.SelectionBackColor = range.Color;
		}
	}
}
