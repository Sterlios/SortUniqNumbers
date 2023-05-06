using System;
using System.Collections.Generic;
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

			_comparable.Compare(sourceText.Text, resultText.Text, out List<SelectionRange> text1ComparedRanges, out List<SelectionRange> text2ComparedRanges);

			PaintText(sourceText, text1ComparedRanges);
			PaintText(resultText, text2ComparedRanges);
		}

		private void ClearBackgroundColor(RichTextBox richTextBox)
		{
			richTextBox.SelectAll();
			richTextBox.SelectionBackColor = Color.White;
		}

		private void PaintText(RichTextBox richTextBox, List<SelectionRange> words)
		{
			foreach (var word in words)
				PaintRange(richTextBox, word);
		}

		private void PaintRange(RichTextBox richTextBox, SelectionRange selectionRange)
		{
			richTextBox.Select(selectionRange.Start, selectionRange.Length);
			richTextBox.SelectionBackColor = selectionRange.Color;
		}
	}
}
