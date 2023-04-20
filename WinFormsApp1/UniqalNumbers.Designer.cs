
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
			this.Handle = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.NumberRange = new System.Windows.Forms.GroupBox();
			this.label7 = new System.Windows.Forms.Label();
			this.MinNumber = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.MaxNumber = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.NumbersCount = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.MinNumbersCount = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.MaxNumbersCount = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.FilesCount = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.MinFilesCount = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.MaxFilesCount = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.GenerateFiles = new System.Windows.Forms.Button();
			this.FilterParameters = new System.Windows.Forms.GroupBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.Devider = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.NumberRange.SuspendLayout();
			this.NumbersCount.SuspendLayout();
			this.FilesCount.SuspendLayout();
			this.FilterParameters.SuspendLayout();
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
			// Handle
			// 
			this.Handle.AutoSize = true;
			this.Handle.Location = new System.Drawing.Point(6, 88);
			this.Handle.Name = "Handle";
			this.Handle.Size = new System.Drawing.Size(233, 25);
			this.Handle.TabIndex = 10;
			this.Handle.Text = "Обработать данные";
			this.Handle.UseVisualStyleBackColor = true;
			this.Handle.Click += new System.EventHandler(this.Handle_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.NumberRange);
			this.groupBox1.Controls.Add(this.NumbersCount);
			this.groupBox1.Controls.Add(this.FilesCount);
			this.groupBox1.Controls.Add(this.GenerateFiles);
			this.groupBox1.Location = new System.Drawing.Point(543, 9);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(245, 289);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Создание файлов";
			// 
			// NumberRange
			// 
			this.NumberRange.Controls.Add(this.label7);
			this.NumberRange.Controls.Add(this.MinNumber);
			this.NumberRange.Controls.Add(this.label8);
			this.NumberRange.Controls.Add(this.MaxNumber);
			this.NumberRange.Controls.Add(this.label9);
			this.NumberRange.Location = new System.Drawing.Point(6, 176);
			this.NumberRange.Name = "NumberRange";
			this.NumberRange.Size = new System.Drawing.Size(230, 71);
			this.NumberRange.TabIndex = 21;
			this.NumberRange.TabStop = false;
			this.NumberRange.Text = "Диапазон чисел";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(125, 19);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(36, 15);
			this.label7.TabIndex = 5;
			this.label7.Text = "Макс";
			// 
			// MinNumber
			// 
			this.MinNumber.Location = new System.Drawing.Point(6, 37);
			this.MinNumber.Name = "MinNumber";
			this.MinNumber.Size = new System.Drawing.Size(95, 23);
			this.MinNumber.TabIndex = 2;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(6, 19);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(32, 15);
			this.label8.TabIndex = 3;
			this.label8.Text = "Мин";
			// 
			// MaxNumber
			// 
			this.MaxNumber.Location = new System.Drawing.Point(125, 37);
			this.MaxNumber.Name = "MaxNumber";
			this.MaxNumber.Size = new System.Drawing.Size(95, 23);
			this.MaxNumber.TabIndex = 4;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(107, 40);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(12, 15);
			this.label9.TabIndex = 6;
			this.label9.Text = "-";
			// 
			// NumbersCount
			// 
			this.NumbersCount.Controls.Add(this.label1);
			this.NumbersCount.Controls.Add(this.MinNumbersCount);
			this.NumbersCount.Controls.Add(this.label5);
			this.NumbersCount.Controls.Add(this.MaxNumbersCount);
			this.NumbersCount.Controls.Add(this.label6);
			this.NumbersCount.Location = new System.Drawing.Point(6, 99);
			this.NumbersCount.Name = "NumbersCount";
			this.NumbersCount.Size = new System.Drawing.Size(230, 71);
			this.NumbersCount.TabIndex = 20;
			this.NumbersCount.TabStop = false;
			this.NumbersCount.Text = "Количество чисел в файле";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(125, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(36, 15);
			this.label1.TabIndex = 5;
			this.label1.Text = "Макс";
			// 
			// MinNumbersCount
			// 
			this.MinNumbersCount.Location = new System.Drawing.Point(6, 37);
			this.MinNumbersCount.Name = "MinNumbersCount";
			this.MinNumbersCount.Size = new System.Drawing.Size(95, 23);
			this.MinNumbersCount.TabIndex = 2;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 19);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(32, 15);
			this.label5.TabIndex = 3;
			this.label5.Text = "Мин";
			// 
			// MaxNumbersCount
			// 
			this.MaxNumbersCount.Location = new System.Drawing.Point(125, 37);
			this.MaxNumbersCount.Name = "MaxNumbersCount";
			this.MaxNumbersCount.Size = new System.Drawing.Size(95, 23);
			this.MaxNumbersCount.TabIndex = 4;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(107, 40);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(12, 15);
			this.label6.TabIndex = 6;
			this.label6.Text = "-";
			// 
			// FilesCount
			// 
			this.FilesCount.Controls.Add(this.label3);
			this.FilesCount.Controls.Add(this.MinFilesCount);
			this.FilesCount.Controls.Add(this.label2);
			this.FilesCount.Controls.Add(this.MaxFilesCount);
			this.FilesCount.Controls.Add(this.label4);
			this.FilesCount.Location = new System.Drawing.Point(6, 22);
			this.FilesCount.Name = "FilesCount";
			this.FilesCount.Size = new System.Drawing.Size(230, 71);
			this.FilesCount.TabIndex = 19;
			this.FilesCount.TabStop = false;
			this.FilesCount.Text = "Количество файлов";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(125, 19);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(36, 15);
			this.label3.TabIndex = 5;
			this.label3.Text = "Макс";
			// 
			// MinFilesCount
			// 
			this.MinFilesCount.Location = new System.Drawing.Point(6, 37);
			this.MinFilesCount.Name = "MinFilesCount";
			this.MinFilesCount.Size = new System.Drawing.Size(95, 23);
			this.MinFilesCount.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 19);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 15);
			this.label2.TabIndex = 3;
			this.label2.Text = "Мин";
			// 
			// MaxFilesCount
			// 
			this.MaxFilesCount.Location = new System.Drawing.Point(125, 37);
			this.MaxFilesCount.Name = "MaxFilesCount";
			this.MaxFilesCount.Size = new System.Drawing.Size(95, 23);
			this.MaxFilesCount.TabIndex = 4;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(107, 40);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(12, 15);
			this.label4.TabIndex = 6;
			this.label4.Text = "-";
			// 
			// GenerateFiles
			// 
			this.GenerateFiles.Location = new System.Drawing.Point(6, 260);
			this.GenerateFiles.Name = "GenerateFiles";
			this.GenerateFiles.Size = new System.Drawing.Size(233, 23);
			this.GenerateFiles.TabIndex = 0;
			this.GenerateFiles.Text = "Создать файлы";
			this.GenerateFiles.UseVisualStyleBackColor = true;
			// 
			// FilterParameters
			// 
			this.FilterParameters.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.FilterParameters.Controls.Add(this.textBox2);
			this.FilterParameters.Controls.Add(this.label10);
			this.FilterParameters.Controls.Add(this.textBox1);
			this.FilterParameters.Controls.Add(this.Devider);
			this.FilterParameters.Controls.Add(this.Handle);
			this.FilterParameters.Location = new System.Drawing.Point(543, 304);
			this.FilterParameters.Name = "FilterParameters";
			this.FilterParameters.Size = new System.Drawing.Size(245, 119);
			this.FilterParameters.TabIndex = 12;
			this.FilterParameters.TabStop = false;
			this.FilterParameters.Text = "Фильтр данных";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(127, 22);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(95, 23);
			this.textBox1.TabIndex = 11;
			// 
			// Devider
			// 
			this.Devider.AutoSize = true;
			this.Devider.Location = new System.Drawing.Point(6, 25);
			this.Devider.Name = "Devider";
			this.Devider.Size = new System.Drawing.Size(59, 15);
			this.Devider.TabIndex = 12;
			this.Devider.Text = "Делитель";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(127, 51);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(95, 23);
			this.textBox2.TabIndex = 13;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(7, 54);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(114, 15);
			this.label10.TabIndex = 14;
			this.label10.Text = "Остаток от деления";
			// 
			// UniqalNumbers
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(800, 465);
			this.Controls.Add(this.FilterParameters);
			this.Controls.Add(this.groupBox1);
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
			this.groupBox1.ResumeLayout(false);
			this.NumberRange.ResumeLayout(false);
			this.NumberRange.PerformLayout();
			this.NumbersCount.ResumeLayout(false);
			this.NumbersCount.PerformLayout();
			this.FilesCount.ResumeLayout(false);
			this.FilesCount.PerformLayout();
			this.FilterParameters.ResumeLayout(false);
			this.FilterParameters.PerformLayout();
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
		private System.Windows.Forms.Button Handle;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox FilterParameters;
		private System.Windows.Forms.GroupBox NumberRange;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox MinNumber;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox MaxNumber;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.GroupBox NumbersCount;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox MinNumbersCount;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox MaxNumbersCount;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.GroupBox FilesCount;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox MinFilesCount;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox MaxFilesCount;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button GenerateFiles;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label Devider;
	}
}

