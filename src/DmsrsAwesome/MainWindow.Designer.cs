namespace DmsrsAwesome
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			var resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
			label1 = new Label();
			linkLocationTextBox = new TextBox();
			folderBrowser = new FolderBrowserDialog();
			exploreButton1 = new Button();
			label2 = new Label();
			groupBox1 = new GroupBox();
			linkNameComboBox = new TextBox();
			groupBox2 = new GroupBox();
			label5 = new Label();
			linkTypeComboBox = new ComboBox();
			exploreButton2 = new Button();
			destinationLocationTextBox = new TextBox();
			label3 = new Label();
			createLinkButton = new Button();
			aboutButton = new PictureBox();
			filesBrowser = new OpenFileDialog();
			TypeSelector = new ComboBox();
			groupBox3 = new GroupBox();
			errorProvider = new ErrorProvider(components);
			toolTip = new ToolTip(components);
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)aboutButton).BeginInit();
			groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(10, 24);
			label1.Margin = new Padding(4, 0, 4, 0);
			label1.Name = "label1";
			label1.Size = new Size(263, 15);
			label1.TabIndex = 0;
			label1.Text = "Please select the place where you want your link:";
			// 
			// linkLocationTextBox
			// 
			linkLocationTextBox.AllowDrop = true;
			linkLocationTextBox.Location = new Point(14, 45);
			linkLocationTextBox.Margin = new Padding(4, 3, 4, 3);
			linkLocationTextBox.Name = "linkLocationTextBox";
			linkLocationTextBox.Size = new Size(363, 23);
			linkLocationTextBox.TabIndex = 1;
			linkLocationTextBox.WordWrap = false;
			linkLocationTextBox.DragDrop += TextBox_DragDrop;
			linkLocationTextBox.DragEnter += TextBox_DragEnter;
			linkLocationTextBox.DragOver += TextBox_DragOver;
			// 
			// folderBrowser
			// 
			folderBrowser.Description = "Please select a folder";
			folderBrowser.ShowNewFolderButton = false;
			// 
			// exploreButton1
			// 
			exploreButton1.Location = new Point(385, 43);
			exploreButton1.Margin = new Padding(4, 3, 4, 3);
			exploreButton1.Name = "exploreButton1";
			exploreButton1.Size = new Size(92, 27);
			exploreButton1.TabIndex = 2;
			exploreButton1.Text = "Explore...";
			exploreButton1.UseVisualStyleBackColor = true;
			exploreButton1.Click += ExploreButton1Click;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(13, 76);
			label2.Margin = new Padding(4, 0, 4, 0);
			label2.Name = "label2";
			label2.Size = new Size(158, 15);
			label2.TabIndex = 3;
			label2.Text = "Now give a name to the link:";
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(linkNameComboBox);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(label1);
			groupBox1.Controls.Add(exploreButton1);
			groupBox1.Controls.Add(linkLocationTextBox);
			groupBox1.Location = new Point(14, 82);
			groupBox1.Margin = new Padding(4, 3, 4, 3);
			groupBox1.Name = "groupBox1";
			groupBox1.Padding = new Padding(4, 3, 4, 3);
			groupBox1.Size = new Size(491, 106);
			groupBox1.TabIndex = 4;
			groupBox1.TabStop = false;
			groupBox1.Text = "Link Folder";
			// 
			// linkNameComboBox
			// 
			linkNameComboBox.Location = new Point(205, 73);
			linkNameComboBox.Margin = new Padding(4, 3, 4, 3);
			linkNameComboBox.Name = "linkNameComboBox";
			linkNameComboBox.Size = new Size(172, 23);
			linkNameComboBox.TabIndex = 3;
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(label5);
			groupBox2.Controls.Add(linkTypeComboBox);
			groupBox2.Controls.Add(exploreButton2);
			groupBox2.Controls.Add(destinationLocationTextBox);
			groupBox2.Controls.Add(label3);
			groupBox2.Location = new Point(15, 196);
			groupBox2.Margin = new Padding(4, 3, 4, 3);
			groupBox2.Name = "groupBox2";
			groupBox2.Padding = new Padding(4, 3, 4, 3);
			groupBox2.Size = new Size(490, 118);
			groupBox2.TabIndex = 5;
			groupBox2.TabStop = false;
			groupBox2.Text = "Destination Folder";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(12, 77);
			label5.Margin = new Padding(4, 0, 4, 0);
			label5.Name = "label5";
			label5.Size = new Size(123, 15);
			label5.TabIndex = 4;
			label5.Text = "Select the type of link:";
			// 
			// linkTypeComboBox
			// 
			linkTypeComboBox.FormattingEnabled = true;
			linkTypeComboBox.ImeMode = ImeMode.Off;
			linkTypeComboBox.Items.AddRange(new object[] { "Symbolic Link", "Hard Link", "Directory Junction" });
			linkTypeComboBox.Location = new Point(204, 74);
			linkTypeComboBox.Margin = new Padding(4, 3, 4, 3);
			linkTypeComboBox.Name = "linkTypeComboBox";
			linkTypeComboBox.Size = new Size(172, 23);
			linkTypeComboBox.TabIndex = 3;
			linkTypeComboBox.MouseHover += ComboBox1MouseHover;
			// 
			// exploreButton2
			// 
			exploreButton2.Location = new Point(384, 40);
			exploreButton2.Margin = new Padding(4, 3, 4, 3);
			exploreButton2.Name = "exploreButton2";
			exploreButton2.Size = new Size(88, 27);
			exploreButton2.TabIndex = 2;
			exploreButton2.Text = "Explore...";
			exploreButton2.UseVisualStyleBackColor = true;
			exploreButton2.Click += Explorebutton2Click;
			// 
			// destinationLocationTextBox
			// 
			destinationLocationTextBox.AllowDrop = true;
			destinationLocationTextBox.Location = new Point(13, 43);
			destinationLocationTextBox.Margin = new Padding(4, 3, 4, 3);
			destinationLocationTextBox.Name = "destinationLocationTextBox";
			destinationLocationTextBox.Size = new Size(363, 23);
			destinationLocationTextBox.TabIndex = 1;
			destinationLocationTextBox.DragDrop += TextBox_DragDrop;
			destinationLocationTextBox.DragEnter += TextBox_DragEnter;
			destinationLocationTextBox.DragOver += TextBox_DragOver;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(9, 23);
			label3.Margin = new Padding(4, 0, 4, 0);
			label3.Name = "label3";
			label3.Size = new Size(301, 15);
			label3.TabIndex = 0;
			label3.Text = "Please select the path to the real folder you want to link:";
			// 
			// createLinkButton
			// 
			createLinkButton.Location = new Point(399, 321);
			createLinkButton.Margin = new Padding(4, 3, 4, 3);
			createLinkButton.Name = "createLinkButton";
			createLinkButton.Size = new Size(106, 27);
			createLinkButton.TabIndex = 6;
			createLinkButton.Text = "Create Link";
			createLinkButton.UseVisualStyleBackColor = true;
			createLinkButton.Click += CreateLinkClick;
			// 
			// aboutButton
			// 
			aboutButton.Image = Resources.info;
			aboutButton.Location = new Point(15, 329);
			aboutButton.Margin = new Padding(4, 3, 4, 3);
			aboutButton.Name = "aboutButton";
			aboutButton.Size = new Size(19, 18);
			aboutButton.TabIndex = 7;
			aboutButton.TabStop = false;
			aboutButton.Click += HelpImageClick;
			// 
			// TypeSelector
			// 
			TypeSelector.FormattingEnabled = true;
			TypeSelector.ImeMode = ImeMode.Off;
			TypeSelector.Items.AddRange(new object[] { "Folder symbolic link", "File symbolic link" });
			TypeSelector.Location = new Point(16, 22);
			TypeSelector.Margin = new Padding(4, 3, 4, 3);
			TypeSelector.Name = "TypeSelector";
			TypeSelector.Size = new Size(278, 23);
			TypeSelector.TabIndex = 1;
			TypeSelector.SelectedIndexChanged += TypeSelectorSelectedIndexChanged;
			TypeSelector.MouseHover += TypeSelectorMouseHover;
			// 
			// groupBox3
			// 
			groupBox3.Controls.Add(TypeSelector);
			groupBox3.Location = new Point(14, 14);
			groupBox3.Margin = new Padding(4, 3, 4, 3);
			groupBox3.Name = "groupBox3";
			groupBox3.Padding = new Padding(4, 3, 4, 3);
			groupBox3.Size = new Size(491, 61);
			groupBox3.TabIndex = 10;
			groupBox3.TabStop = false;
			groupBox3.Text = "Select the type of symlink that you want to create:";
			// 
			// errorProvider
			// 
			errorProvider.ContainerControl = this;
			// 
			// MainWindow
			// 
			AllowDrop = true;
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(532, 366);
			Controls.Add(groupBox3);
			Controls.Add(aboutButton);
			Controls.Add(createLinkButton);
			Controls.Add(groupBox2);
			Controls.Add(groupBox1);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Icon = (Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(4, 3, 4, 3);
			MaximizeBox = false;
			Name = "MainWindow";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Symbolic Link Creator";
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)aboutButton).EndInit();
			groupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox linkLocationTextBox;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.Button exploreButton1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox linkNameComboBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button exploreButton2;
        private System.Windows.Forms.TextBox destinationLocationTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button createLinkButton;
        private System.Windows.Forms.PictureBox aboutButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox linkTypeComboBox;
        private System.Windows.Forms.OpenFileDialog filesBrowser;
        private System.Windows.Forms.ComboBox TypeSelector;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ErrorProvider errorProvider;
		private ToolTip toolTip;
	}
}

