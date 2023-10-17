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
    openFileDialog1 = new OpenFileDialog();
    textBox1 = new TextBox();
    button1 = new Button();
    folderBrowserDialog1 = new FolderBrowserDialog();
    textBox2 = new TextBox();
    button2 = new Button();
    button3 = new Button();
    textBox3 = new TextBox();
    panel1 = new Panel();
    panel1.SuspendLayout();
    SuspendLayout();
    // 
    // openFileDialog1
    // 
    openFileDialog1.FileName = "openFileDialog1";
    // 
    // textBox1
    // 
    textBox1.Location = new Point(73, 28);
    textBox1.Name = "textBox1";
    textBox1.Size = new Size(703, 23);
    textBox1.TabIndex = 0;
    // 
    // button1
    // 
    button1.Location = new Point(782, 27);
    button1.Name = "button1";
    button1.Size = new Size(75, 23);
    button1.TabIndex = 1;
    button1.Text = "选择";
    button1.UseVisualStyleBackColor = true;
    button1.Click += button1_Click;
    // 
    // textBox2
    // 
    textBox2.Location = new Point(73, 72);
    textBox2.Name = "textBox2";
    textBox2.Size = new Size(703, 23);
    textBox2.TabIndex = 2;
    // 
    // button2
    // 
    button2.Location = new Point(782, 72);
    button2.Name = "button2";
    button2.Size = new Size(75, 23);
    button2.TabIndex = 3;
    button2.Text = "选择";
    button2.UseVisualStyleBackColor = true;
    button2.Click += button2_Click;
    // 
    // button3
    // 
    button3.Location = new Point(782, 120);
    button3.Name = "button3";
    button3.Size = new Size(75, 23);
    button3.TabIndex = 5;
    button3.Text = "button3";
    button3.UseVisualStyleBackColor = true;
    button3.Click += button3_Click;
    // 
    // textBox3
    // 
    textBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    textBox3.Location = new Point(12, 180);
    textBox3.Multiline = true;
    textBox3.Name = "textBox3";
    textBox3.ScrollBars = ScrollBars.Both;
    textBox3.Size = new Size(931, 411);
    textBox3.TabIndex = 6;
    // 
    // panel1
    // 
    panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
    panel1.Controls.Add(textBox1);
    panel1.Controls.Add(textBox2);
    panel1.Controls.Add(button3);
    panel1.Controls.Add(button1);
    panel1.Controls.Add(button2);
    panel1.Location = new Point(12, 12);
    panel1.Name = "panel1";
    panel1.Size = new Size(931, 162);
    panel1.TabIndex = 7;
    // 
    // Form1
    // 
    AutoScaleDimensions = new SizeF(7F, 15F);
    AutoScaleMode = AutoScaleMode.Font;
    ClientSize = new Size(955, 603);
    Controls.Add(panel1);
    Controls.Add(textBox3);
    Name = "Form1";
    Text = "Form1";
    panel1.ResumeLayout(false);
    panel1.PerformLayout();
    ResumeLayout(false);
    PerformLayout();
  }

  #endregion

  private OpenFileDialog openFileDialog1;
  private TextBox textBox1;
  private Button button1;
  private FolderBrowserDialog folderBrowserDialog1;
  private TextBox textBox2;
  private Button button2;
  private Button button3;
  private TextBox textBox3;
  private Panel panel1;
}
