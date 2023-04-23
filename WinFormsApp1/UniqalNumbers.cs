using SortUniqNumbers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;

namespace WinFormsApp1
{
	public partial class UniqalNumbers : Form
	{
		private readonly FileManager _fileManager;

		public UniqalNumbers()
		{
			InitializeComponent();

			_fileManager = FileManager.Instance();

			_fileManager.ChangedPath += OnChangedPath;
			_fileManager.ChangedFilesListInFolder += OnChangedFilesListInFolder;
			_fileManager.ChangedFilesForRead += OnChangedFilesListForRead;

			_fileManager.Init();
		}

		private void OnChangedFilesListForRead(IReadOnlyList<string> files)
		{
			if (FilesForRead.InvokeRequired)
			{
				FilesForRead.Invoke(new Action(() => OnChangedFilesListForRead(files)));
				return;
			}

			FilesForRead.Items.Clear();

			foreach (var file in files)
				FilesForRead.Items.Add(Path.GetFileName(file));

			FilterParameters.Enabled = FilesForRead.Items.Count > 0;
		}

		private void OnChangedFilesListInFolder(IReadOnlyList<string> files)
		{
			if (FilesInFolder.InvokeRequired)
			{
				FilesInFolder.Invoke(new Action(() => OnChangedFilesListInFolder(files)));
				return;
			}

			FilesInFolder.Items.Clear();

			foreach (var file in files)
				FilesInFolder.Items.Add(file);

			CreateFilesGroup.Enabled = FilesInFolder.Items.Count == 0;
		}

		private void OnChangedPath(string newPath)
		{
			PathText.Text = newPath;
		}

		private void ParseNumber(TextBox textBox)
		{
			if (!int.TryParse(textBox.Text, out int number))
			{
				textBox.Text = string.Concat(textBox.Text
					.Where(symbol => int.TryParse(symbol.ToString(), out int number)));
			}
		}

		private void ChooseFolder_Click(object sender, EventArgs e)
		{
			using var dialog = new FolderBrowserDialog();
			DialogResult result = dialog.ShowDialog();

			if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
				_fileManager.ChangePath(dialog.SelectedPath);
		}

		private void AddFiles_Click(object sender, EventArgs e)
		{
			var files = FilesInFolder.SelectedItems.OfType<string>();
			_fileManager.AddToListForRead(files);
		}

		private void RemoveFiles_Click(object sender, EventArgs e)
		{
			_fileManager.RemoveFromListForRead(FilesForRead.SelectedItems.OfType<string>());
		}

		private void MinNumbersCount_TextChanged(object sender, EventArgs e)
		{
			ParseNumber(MinNumbersCount);
		}

		private void MaxNumbersCount_TextChanged(object sender, EventArgs e)
		{
			ParseNumber(MaxNumbersCount);
		}

		private void MinNumber_TextChanged(object sender, EventArgs e)
		{
			ParseNumber(MinNumber);
		}

		private void MaxNumber_TextChanged(object sender, EventArgs e)
		{
			ParseNumber(MaxNumber);
		}

		private void FilesCount_TextChanged(object sender, EventArgs e)
		{
			ParseNumber(FilesCount);
		}

		private void Handle_Click(object sender, EventArgs e)
		{

			if (int.TryParse(Divider.Text, out int divider) &&
				int.TryParse(Modulo.Text, out int modulo))
			{
				_fileManager.ReadFiles(divider, modulo);
				_fileManager.SaveResult();
			}


		}

		private void GenerateFiles_Click(object sender, EventArgs e)
		{
			if (int.TryParse(FilesCount.Text, out int filesCount))
				_fileManager.GenerateSourceFiles(filesCount);

			if (int.TryParse(MinNumbersCount.Text, out int minNumbersCount) &&
				int.TryParse(MaxNumbersCount.Text, out int maxNumbersCount) &&
				int.TryParse(MinNumber.Text, out int minNumber) &&
				int.TryParse(MaxNumber.Text, out int maxNumber))
			{
				_fileManager.FillFiles(minNumbersCount, maxNumbersCount, minNumber, maxNumber);
			}
		}

		private void Divider_TextChanged(object sender, EventArgs e)
		{
			ParseNumber(Divider);
		}

		private void Modulo_TextChanged(object sender, EventArgs e)
		{
			ParseNumber(Modulo);
		}
	}
}
