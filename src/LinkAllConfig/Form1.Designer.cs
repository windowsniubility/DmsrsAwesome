namespace LinkAllConfig;

partial class Form1
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
    components = new System.ComponentModel.Container();
    openFileDialog1 = new OpenFileDialog();
    txtTargets = new TextBox();
    btnSelTargets = new Button();
    folderBrowserDialog1 = new FolderBrowserDialog();
    txtLIinks = new TextBox();
    btnSelectLinkFolder = new Button();
    btnCreateLinks = new Button();
    txtOutput = new TextBox();
    panel1 = new Panel();
    txtFsutilPath = new TextBox();
    btnSelectTool = new Button();
    ListTargetFiles = new ListView();
    errorProvider1 = new ErrorProvider(components);
    panel1.SuspendLayout();
    ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
    SuspendLayout();
    // 
    // openFileDialog1
    // 
    openFileDialog1.FileName = "openFileDialog1";
    // 
    // txtTargets
    // 
    txtTargets.Location = new Point(3, 32);
    txtTargets.Name = "txtTargets";
    txtTargets.PlaceholderText = "选择配置目录";
    txtTargets.Size = new Size(757, 23);
    txtTargets.TabIndex = 0;
    // 
    // btnSelTargets
    // 
    btnSelTargets.Location = new Point(763, 32);
    btnSelTargets.Name = "btnSelTargets";
    btnSelTargets.Size = new Size(75, 23);
    btnSelTargets.TabIndex = 1;
    btnSelTargets.Text = "选择";
    btnSelTargets.UseVisualStyleBackColor = true;
    btnSelTargets.Click += BtnSelTargets_ClickAsync;
    // 
    // txtLIinks
    // 
    txtLIinks.Location = new Point(3, 61);
    txtLIinks.Name = "txtLIinks";
    txtLIinks.PlaceholderText = "选择分发目录";
    txtLIinks.Size = new Size(757, 23);
    txtLIinks.TabIndex = 2;
    // 
    // btnSelectLinkFolder
    // 
    btnSelectLinkFolder.Location = new Point(763, 61);
    btnSelectLinkFolder.Name = "btnSelectLinkFolder";
    btnSelectLinkFolder.Size = new Size(75, 23);
    btnSelectLinkFolder.TabIndex = 3;
    btnSelectLinkFolder.Text = "选择";
    btnSelectLinkFolder.UseVisualStyleBackColor = true;
    btnSelectLinkFolder.Click += BtnSelectLinkFolder_Click;
    // 
    // btnCreateLinks
    // 
    btnCreateLinks.Location = new Point(844, 61);
    btnCreateLinks.Name = "btnCreateLinks";
    btnCreateLinks.Size = new Size(75, 23);
    btnCreateLinks.TabIndex = 5;
    btnCreateLinks.Text = "Create";
    btnCreateLinks.UseVisualStyleBackColor = true;
    btnCreateLinks.Click += BtnCreateLinks_Click;
    // 
    // txtOutput
    // 
    txtOutput.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    txtOutput.Location = new Point(12, 396);
    txtOutput.Multiline = true;
    txtOutput.Name = "txtOutput";
    txtOutput.ScrollBars = ScrollBars.Both;
    txtOutput.Size = new Size(931, 195);
    txtOutput.TabIndex = 6;
    txtOutput.WordWrap = false;
    // 
    // panel1
    // 
    panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
    panel1.Controls.Add(txtFsutilPath);
    panel1.Controls.Add(txtTargets);
    panel1.Controls.Add(txtLIinks);
    panel1.Controls.Add(btnCreateLinks);
    panel1.Controls.Add(btnSelectTool);
    panel1.Controls.Add(btnSelTargets);
    panel1.Controls.Add(btnSelectLinkFolder);
    panel1.Location = new Point(12, 12);
    panel1.Name = "panel1";
    panel1.Size = new Size(931, 106);
    panel1.TabIndex = 7;
    // 
    // txtFsutilPath
    // 
    txtFsutilPath.Location = new Point(3, 3);
    txtFsutilPath.Name = "txtFsutilPath";
    txtFsutilPath.PlaceholderText = "fsutil路径";
    txtFsutilPath.Size = new Size(757, 23);
    txtFsutilPath.TabIndex = 0;
    txtFsutilPath.Validated += txtFsutilPath_Validated;
    // 
    // btnSelectTool
    // 
    btnSelectTool.Location = new Point(763, 3);
    btnSelectTool.Name = "btnSelectTool";
    btnSelectTool.Size = new Size(75, 23);
    btnSelectTool.TabIndex = 1;
    btnSelectTool.Text = "选择";
    btnSelectTool.UseVisualStyleBackColor = true;
    btnSelectTool.Click += BtnSelectTool_Click;
    // 
    // ListTargetFiles
    // 
    ListTargetFiles.Location = new Point(12, 145);
    ListTargetFiles.Name = "ListTargetFiles";
    ListTargetFiles.Size = new Size(927, 97);
    ListTargetFiles.TabIndex = 8;
    ListTargetFiles.UseCompatibleStateImageBehavior = false;
    // 
    // errorProvider1
    // 
    errorProvider1.ContainerControl = this;
    // 
    // Form1
    // 
    AutoScaleDimensions = new SizeF(7F, 15F);
    AutoScaleMode = AutoScaleMode.Font;
    ClientSize = new Size(955, 603);
    Controls.Add(ListTargetFiles);
    Controls.Add(panel1);
    Controls.Add(txtOutput);
    Name = "Form1";
    Text = "Form1";
    panel1.ResumeLayout(false);
    panel1.PerformLayout();
    ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
    ResumeLayout(false);
    PerformLayout();
  }

  #endregion

  private OpenFileDialog openFileDialog1;
  private TextBox txtTargets;
  private Button btnSelTargets;
  private FolderBrowserDialog folderBrowserDialog1;
  private TextBox txtLIinks;
  private Button btnSelectLinkFolder;
  private Button btnCreateLinks;
  private TextBox txtOutput;
  private Panel panel1;
  private ListView ListTargetFiles;
  private TextBox txtFsutilPath;
  private Button btnSelectTool;
  private ErrorProvider errorProvider1;
}
