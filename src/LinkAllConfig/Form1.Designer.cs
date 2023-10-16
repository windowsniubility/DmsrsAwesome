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
    SuspendLayout();
    // 
    // openFileDialog1
    // 
    openFileDialog1.FileName = "openFileDialog1";
    // 
    // textBox1
    // 
    textBox1.Location = new Point(94, 60);
    textBox1.Name = "textBox1";
    textBox1.Size = new Size(609, 23);
    textBox1.TabIndex = 0;
    // 
    // button1
    // 
    button1.Location = new Point(731, 60);
    button1.Name = "button1";
    button1.Size = new Size(75, 26);
    button1.TabIndex = 1;
    button1.Text = "button1";
    button1.UseVisualStyleBackColor = true;
    button1.Click += button1_Click;
    // 
    // textBox2
    // 
    textBox2.Location = new Point(94, 110);
    textBox2.Name = "textBox2";
    textBox2.Size = new Size(609, 23);
    textBox2.TabIndex = 2;
    // 
    // button2
    // 
    button2.Location = new Point(731, 110);
    button2.Name = "button2";
    button2.Size = new Size(75, 26);
    button2.TabIndex = 3;
    button2.Text = "button2";
    button2.UseVisualStyleBackColor = true;
    button2.Click += button2_Click;
    // 
    // button3
    // 
    button3.Location = new Point(731, 180);
    button3.Name = "button3";
    button3.Size = new Size(75, 26);
    button3.TabIndex = 5;
    button3.Text = "button3";
    button3.UseVisualStyleBackColor = true;
    button3.Click += button3_Click;
    // 
    // textBox3
    // 
    textBox3.Location = new Point(94, 249);
    textBox3.Multiline = true;
    textBox3.Name = "textBox3";
    textBox3.ScrollBars = ScrollBars.Both;
    textBox3.Size = new Size(609, 267);
    textBox3.TabIndex = 6;
    // 
    // Form1
    // 
    AutoScaleDimensions = new SizeF(7F, 17F);
    AutoScaleMode = AutoScaleMode.Font;
    ClientSize = new Size(955, 683);
    Controls.Add(textBox3);
    Controls.Add(button3);
    Controls.Add(button2);
    Controls.Add(textBox2);
    Controls.Add(button1);
    Controls.Add(textBox1);
    Name = "Form1";
    Text = "Form1";
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
}
