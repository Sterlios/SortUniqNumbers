
namespace WinFormsApp1
{
	partial class UniqalNumbers
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.PathText = new System.Windows.Forms.TextBox();
			this.PathTitle = new System.Windows.Forms.Label();
			this.ChooseFolder = new System.Windows.Forms.Button();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.FilesInFolderTitle = new System.Windows.Forms.Label();
			this.FilesInFolder = new System.Windows.Forms.ListBox();
			this.FilesForRead = new System.Windows.Forms.ListBox();
			this.AddFiles = new System.Windows.Forms.Button();
			this.RemoveFiles = new System.Windows.Forms.Button();
			this.FilesForReadTitle = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// PathText
			// 
			this.PathText.Location = new System.Drawing.Point(12, 30);
			this.PathText.Name = "PathText";
			this.PathText.ReadOnly = true;
			this.PathText.Size = new System.Drawing.Size(399, 23);
			this.PathText.TabIndex = 1;
			// 
			// PathTitle
			// 
			this.PathTitle.AutoSize = true;
			this.PathTitle.Location = new System.Drawing.Point(12, 9);
			this.PathTitle.Name = "PathTitle";
			this.PathTitle.Size = new System.Drawing.Size(140, 15);
			this.PathTitle.TabIndex = 2;
			this.PathTitle.Text = "Путь к папке с данными";
			// 
			// ChooseFolder
			// 
			this.ChooseFolder.BackgroundImage = global::WindowsForm.Properties.Resources.filderIcon;
			this.ChooseFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.ChooseFolder.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.ChooseFolder.Location = new System.Drawing.Point(417, 30);
			this.ChooseFolder.Name = "ChooseFolder";
			this.ChooseFolder.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ChooseFolder.Size = new System.Drawing.Size(34, 23);
			this.ChooseFolder.TabIndex = 0;
			this.ChooseFolder.UseMnemonic = false;
			this.ChooseFolder.UseVisualStyleBackColor = false;
			this.ChooseFolder.Click += new System.EventHandler(this.ChooseFolder_Click);
			// 
			// FilesInFolderTitle
			// 
			this.FilesInFolderTitle.AutoSize = true;
			this.FilesInFolderTitle.Location = new System.Drawing.Point(12, 56);
			this.FilesInFolderTitle.Name = "FilesInFolderTitle";
			this.FilesInFolderTitle.Size = new System.Drawing.Size(92, 15);
			this.FilesInFolderTitle.TabIndex = 4;
			this.FilesInFolderTitle.Text = "Файлы в папке:";
			// 
			// FilesInFolder
			// 
			this.FilesInFolder.FormattingEnabled = true;
			this.FilesInFolder.HorizontalScrollbar = true;
			this.FilesInFolder.ItemHeight = 15;
			this.FilesInFolder.Location = new System.Drawing.Point(12, 74);
			this.FilesInFolder.Name = "FilesInFolder";
			this.FilesInFolder.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.FilesInFolder.Size = new System.Drawing.Size(239, 349);
			this.FilesInFolder.TabIndex = 5;
			// 
			// FilesForRead
			// 
			this.FilesForRead.FormattingEnabled = true;
			this.FilesForRead.HorizontalScrollbar = true;
			this.FilesForRead.ItemHeight = 15;
			this.FilesForRead.Location = new System.Drawing.Point(298, 74);
			this.FilesForRead.Name = "FilesForRead";
			this.FilesForRead.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.FilesForRead.Size = new System.Drawing.Size(239, 349);
			this.FilesForRead.TabIndex = 6;
			// 
			// AddFiles
			// 
			this.AddFiles.Location = new System.Drawing.Point(257, 200);
			this.AddFiles.Name = "AddFiles";
			this.AddFiles.Size = new System.Drawing.Size(35, 23);
			this.AddFiles.TabIndex = 7;
			this.AddFiles.Text = ">>";
			this.AddFiles.UseVisualStyleBackColor = true;
			this.AddFiles.Click += new System.EventHandler(this.AddFiles_Click);
			// 
			// RemoveFiles
			// 
			this.RemoveFiles.Location = new System.Drawing.Point(257, 240);
			this.RemoveFiles.Name = "RemoveFiles";
			this.RemoveFiles.Size = new System.Drawing.Size(35, 23);
			this.RemoveFiles.TabIndex = 8;
			this.RemoveFiles.Text = "<<";
			this.RemoveFiles.UseVisualStyleBackColor = true;
			this.RemoveFiles.Click += new System.EventHandler(this.RemoveFiles_Click);
			// 
			// FilesForReadTitle
			// 
			this.FilesForReadTitle.AutoSize = true;
			this.FilesForReadTitle.Location = new System.Drawing.Point(298, 56);
			this.FilesForReadTitle.Name = "FilesForReadTitle";
			this.FilesForReadTitle.Size = new System.Drawing.Size(132, 15);
			this.FilesForReadTitle.TabIndex = 9;
			this.FilesForReadTitle.Text = "Файлы для обработки:";
			// 
			// UniqalNumbers
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.FilesForReadTitle);
			this.Controls.Add(this.RemoveFiles);
			this.Controls.Add(this.AddFiles);
			this.Controls.Add(this.FilesForRead);
			this.Controls.Add(this.FilesInFolder);
			this.Controls.Add(this.FilesInFolderTitle);
			this.Controls.Add(this.PathTitle);
			this.Controls.Add(this.PathText);
			this.Controls.Add(this.ChooseFolder);
			this.Name = "UniqalNumbers";
			this.Text = "Uniqal Numbers";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.TextBox PathText;
		private System.Windows.Forms.Label PathTitle;
		private System.Windows.Forms.Button ChooseFolder;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Label FilesInFolderTitle;
		private System.Windows.Forms.ListBox FilesInFolder;
		private System.Windows.Forms.ListBox FilesForRead;
		private System.Windows.Forms.Button AddFiles;
		private System.Windows.Forms.Button RemoveFiles;
		private System.Windows.Forms.Label FilesForReadTitle;
	}
}

