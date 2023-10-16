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
    listView1 = new ListView();
    button3 = new Button();
    SuspendLayout();
    // 
    // openFileDialog1
    // 
    openFileDialog1.FileName = "openFileDialog1";
    // 
    // textBox1
    // 
    textBox1.Location = new Point(94, 53);
    textBox1.Name = "textBox1";
    textBox1.Size = new Size(609, 23);
    textBox1.TabIndex = 0;
    // 
    // button1
    // 
    button1.Location = new Point(731, 53);
    button1.Name = "button1";
    button1.Size = new Size(75, 23);
    button1.TabIndex = 1;
    button1.Text = "button1";
    button1.UseVisualStyleBackColor = true;
    button1.Click += button1_Click;
    // 
    // textBox2
    // 
    textBox2.Location = new Point(94, 97);
    textBox2.Name = "textBox2";
    textBox2.Size = new Size(609, 23);
    textBox2.TabIndex = 2;
    // 
    // button2
    // 
    button2.Location = new Point(731, 97);
    button2.Name = "button2";
    button2.Size = new Size(75, 23);
    button2.TabIndex = 3;
    button2.Text = "button2";
    button2.UseVisualStyleBackColor = true;
    button2.Click += button2_Click;
    // 
    // listView1
    // 
    listView1.Location = new Point(94, 220);
    listView1.Name = "listView1";
    listView1.Size = new Size(609, 236);
    listView1.TabIndex = 4;
    listView1.UseCompatibleStateImageBehavior = false;
    // 
    // button3
    // 
    button3.Location = new Point(731, 159);
    button3.Name = "button3";
    button3.Size = new Size(75, 23);
    button3.TabIndex = 5;
    button3.Text = "button3";
    button3.UseVisualStyleBackColor = true;
    // 
    // Form1
    // 
    AutoScaleDimensions = new SizeF(7F, 15F);
    AutoScaleMode = AutoScaleMode.Font;
    ClientSize = new Size(955, 603);
    Controls.Add(button3);
    Controls.Add(listView1);
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
  private ListView listView1;
  private Button button3;
}
