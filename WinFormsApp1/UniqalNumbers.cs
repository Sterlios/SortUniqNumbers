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
		private FileManager _fileManager;

		public UniqalNumbers()
		{
			InitializeComponent();

			_fileManager = FileManager.Instance();

			_fileManager.ChangedPath += OnChangedPath;
			_fileManager.ChangedFilesListInFolder += OnChangedFilesListInFolder;
			_fileManager.ChangedFilesListForRead += OnChangedFilesListForRead;

			_fileManager.Init();
		}

		private void OnChangedFilesListForRead(IReadOnlyList<string> files)
		{
			FilesForRead.Items.Clear();

			foreach (var file in files)
				FilesForRead.Items.Add(Path.GetFileName(file));

			FilterParameters.Enabled = files.Count > 0;
		}

		private void OnChangedFilesListInFolder(IReadOnlyList<string> files)
		{
			FilesInFolder.Items.Clear();

			foreach (var file in files)
				FilesInFolder.Items.Add(Path.GetFileName(file));
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
					_fileManager.ChangePath(dialog.SelectedPath);
			}
		}

		private void AddFiles_Click(object sender, EventArgs e)
		{
			_fileManager.AddFilesListForRead(FilesInFolder.SelectedItems.OfType<string>());
		}

		private void RemoveFiles_Click(object sender, EventArgs e)
		{
			_fileManager.RemoveFilesListForRead(FilesForRead.SelectedItems.OfType<string>());
		}

		private void Handle_Click(object sender, EventArgs e)
		{

		}
	}
}
