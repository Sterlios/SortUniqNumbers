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

		private void button1_Click(object sender, EventArgs e)
		{
			ClearBackgroundColor(sourceText);
			ClearBackgroundColor(resultText);

			TextComparer comparer = new TextComparer(sourceText.Text, resultText.Text);
			comparer.Compare(out List<SelectionRange> sourceWordsSelection, out List<SelectionRange> resultWordsSelection);

			ChangeTextBackgroundColor(sourceText, sourceWordsSelection);
			ChangeTextBackgroundColor(resultText, resultWordsSelection);
		}

		private void ClearBackgroundColor(RichTextBox richTextBox)
		{
			richTextBox.SelectAll();
			richTextBox.SelectionBackColor = Color.White;
		}

		private void ChangeTextBackgroundColor(RichTextBox richTextBox, List<SelectionRange> wordsSelection)
		{
			foreach (var word in wordsSelection)
				ChangeWordBackgroundColor(richTextBox, word);
		}

		private void ChangeWordBackgroundColor(RichTextBox richTextBox, SelectionRange selectionRange)
		{
			richTextBox.Select(selectionRange.Start, selectionRange.Length);
			richTextBox.SelectionBackColor = selectionRange.Color;
		}
	}
}
