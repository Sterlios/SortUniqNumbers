using SortUniqNumbers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

			_fileManager.Init();
		}

		private void OnChangedPath(string newPath)
		{
			Path.Text = newPath;
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
