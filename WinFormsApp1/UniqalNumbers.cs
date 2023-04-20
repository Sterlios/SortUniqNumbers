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
		public UniqalNumbers()
		{
			InitializeComponent();

			FileManager fileManager = FileManager.Instance(new NumberManager());
			
			fileManager.ChangedPath += OnChangedPath;

			fileManager.Init();
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
					string selectedFolder = dialog.SelectedPath;
				}
			}
		}
	}
}
