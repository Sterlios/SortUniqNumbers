using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ComparingTexts
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			ClearBackgroundColor(sourceText);
			ClearBackgroundColor(resultText);

			TextComparer comparer = new TextComparer(sourceText.Text, resultText.Text);
			comparer.Compare(out List<SelectionRange> sourceFoundedWords, out List<SelectionRange> resultFoundedWords);

			PaintText(sourceText, sourceFoundedWords);
			PaintText(resultText, resultFoundedWords);
		}

		private void ClearBackgroundColor(RichTextBox richTextBox)
		{
			richTextBox.SelectAll();
			richTextBox.SelectionBackColor = Color.White;
		}

		private void PaintText(RichTextBox richTextBox, List<SelectionRange> words)
		{
			foreach (var word in words)
				PaintWord(richTextBox, word);
		}

		private void PaintWord(RichTextBox richTextBox, SelectionRange selectionRange)
		{
			richTextBox.Select(selectionRange.Start, selectionRange.Length);
			richTextBox.SelectionBackColor = selectionRange.Color;
		}
	}
}
