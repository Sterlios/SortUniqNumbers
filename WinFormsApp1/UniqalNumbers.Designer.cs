
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
			this.Path = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.Folder = new System.Windows.Forms.Button();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.SuspendLayout();
			// 
			// Path
			// 
			this.Path.Location = new System.Drawing.Point(12, 30);
			this.Path.Name = "Path";
			this.Path.ReadOnly = true;
			this.Path.Size = new System.Drawing.Size(399, 23);
			this.Path.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(140, 15);
			this.label1.TabIndex = 2;
			this.label1.Text = "Путь к папке с данными";
			// 
			// Folder
			// 
			this.Folder.BackgroundImage = global::WindowsForm.Properties.Resources.filderIcon;
			this.Folder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.Folder.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Folder.Location = new System.Drawing.Point(417, 30);
			this.Folder.Name = "Folder";
			this.Folder.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Folder.Size = new System.Drawing.Size(34, 23);
			this.Folder.TabIndex = 0;
			this.Folder.UseMnemonic = false;
			this.Folder.UseVisualStyleBackColor = false;
			this.Folder.Click += new System.EventHandler(this.ChooseFolder_Click);
			// 
			// UniqalNumbers
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.Path);
			this.Controls.Add(this.Folder);
			this.Name = "UniqalNumbers";
			this.Text = "Uniqal Numbers";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.TextBox Path;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button Folder;
		private System.Windows.Forms.ToolTip toolTip1;
	}
}

