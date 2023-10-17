using System.IO.Abstractions;
using System.Text;

namespace LinkAllConfig;

public partial class Form1 : Form
{
  public Form1()
  {
    InitializeComponent();
  }

  private async void button1_Click(object sender, EventArgs e)
  {
    folderBrowserDialog1.ShowDialog(this);
    this.textBox1.Text = folderBrowserDialog1.SelectedPath;

    var r = await Helper.ListLinks(this.textBox1.Text, result => { });
    this.textBox3.Text = r;
  }

  private void button2_Click(object sender, EventArgs e)
  {
    folderBrowserDialog1.ShowDialog(this);
    this.textBox2.Text = folderBrowserDialog1.SelectedPath;
  }

  private async void button3_Click(object sender, EventArgs e)
  {
    var result = new StringBuilder();
    foreach (var target in Directory.EnumerateFiles(this.textBox1.Text))
    {
      var folders = Directory.EnumerateDirectories(this.textBox2.Text);

      var links = from folder in folders select Path.Combine(folder, Path.GetFileName(target));
      await Helper.MakeFileHardLinks(links, target, result);
    }

    this.textBox3.Text = result.ToString();
  }
}