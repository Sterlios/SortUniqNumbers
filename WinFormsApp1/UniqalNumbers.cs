using SortUniqNumbers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace WinFormsApp1
{
	public partial class UniqalNumbers : Form
	{
		private FileManager _fileManager;

		public UniqalNumbers()
		{
			InitializeComponent();

			_fileManager = FileManager.Instance();

			_fileManager.ChangedPath += OnChangedPath;
			_fileManager.ChangedFilesList += OnChangedFilesList;

			_fileManager.Init();
		}

		private void OnChangedFilesList(IReadOnlyList<string> files)
		{
			Files.Items.Clear();

			foreach(var file in files)
				Files.Items.Add(Path.GetFileName(file));
		}

		private void OnChangedPath(string newPath)
		{
			PathText.Text = newPath;
		}

		private void ChooseFolder_Click(object sender, EventArgs e)
		{
			using (var dialog = new FolderBrowserDialog())
			{
				DialogResult result = dialog.ShowDialog();

				if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
				{
					_fileManager.ChangePath(dialog.SelectedPath);
				}
			}
		}
	}
}
