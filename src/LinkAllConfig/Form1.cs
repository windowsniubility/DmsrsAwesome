namespace LinkAllConfig;

/// <summary> The form1. </summary>
public partial class Form1 : Form
{
  /// <summary> Initializes a new instance of the <see cref="Form1"/> class. </summary>
  public Form1()
  {
    InitializeComponent();
  }

  /// <summary> button1_S the click. </summary>
  /// <param name="sender"> The sender. </param>
  /// <param name="e">      The e. </param>
  private async void button1_Click(object sender, EventArgs e)
  {
    _ = folderBrowserDialog1.ShowDialog(this);
    textBox1.Text = folderBrowserDialog1.SelectedPath;
    var result = new StringBuilder();
    await Helper.ListLinks(textBox1.Text, result);
    textBox3.Text = result.ToString();
  }

  /// <summary> button2_S the click. </summary>
  /// <param name="sender"> The sender. </param>
  /// <param name="e">      The e. </param>
  private void button2_Click(object sender, EventArgs e)
  {
    _ = folderBrowserDialog1.ShowDialog(this);
    textBox2.Text = folderBrowserDialog1.SelectedPath;
  }

  /// <summary> button3_S the click. </summary>
  /// <param name="sender"> The sender. </param>
  /// <param name="e">      The e. </param>
  private async void button3_Click(object sender, EventArgs e)
  {
    var result = new StringBuilder();
    foreach (var target in Directory.EnumerateFiles(textBox1.Text))
    {
      var folders = Directory.EnumerateDirectories(textBox2.Text);

      var links = from folder in folders select Path.Combine(folder, Path.GetFileName(target));
      await Helper.MakeFileHardLinks(links, target, result);
    }

    textBox3.Text = result.ToString();
  }
}