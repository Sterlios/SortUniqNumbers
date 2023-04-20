
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
			this.Files = new System.Windows.Forms.ListView();
			this.FilesListTitle = new System.Windows.Forms.Label();
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
			// Files
			// 
			this.Files.HideSelection = false;
			this.Files.Location = new System.Drawing.Point(12, 74);
			this.Files.Name = "Files";
			this.Files.Size = new System.Drawing.Size(165, 359);
			this.Files.TabIndex = 3;
			this.Files.UseCompatibleStateImageBehavior = false;
			// 
			// FilesListTitle
			// 
			this.FilesListTitle.AutoSize = true;
			this.FilesListTitle.Location = new System.Drawing.Point(12, 56);
			this.FilesListTitle.Name = "FilesListTitle";
			this.FilesListTitle.Size = new System.Drawing.Size(92, 15);
			this.FilesListTitle.TabIndex = 4;
			this.FilesListTitle.Text = "Файлы в папке:";
			// 
			// UniqalNumbers
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.FilesListTitle);
			this.Controls.Add(this.Files);
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
		private System.Windows.Forms.ListView Files;
		private System.Windows.Forms.Label FilesListTitle;
	}
}

