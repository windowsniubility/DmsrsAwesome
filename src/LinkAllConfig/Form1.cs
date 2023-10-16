using System.IO.Abstractions;

namespace LinkAllConfig;

public partial class Form1 : Form
{
  public Form1()
  {
    InitializeComponent();
  }

  private async void button1_Click(object sender, EventArgs e)
  {
    openFileDialog1.ShowDialog(this);
    this.textBox1.Text = openFileDialog1.FileName;

    var r = await Helper.ListLinks(this.textBox1.Text, result => { });
    this.textBox3.Text = r;
    // listView1.Items.Add(r);
  }

  private void button2_Click(object sender, EventArgs e)
  {
    folderBrowserDialog1.ShowDialog(this);
    this.textBox2.Text = folderBrowserDialog1.SelectedPath;
  }

  private async void button3_Click(object sender, EventArgs e)
  {
    var folders = Directory.EnumerateDirectories(this.textBox2.Text);
    var links = from folder in folders select Path.Combine(folder, Path.GetFileName(this.textBox1.Text));
    var result = await Helper.MakeFileHardLinks(links, this.textBox1.Text);
    this.textBox3.Text = result;
  }
}