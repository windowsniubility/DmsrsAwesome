namespace LinkAllConfig;

/// <summary> The form1. </summary>
public partial class Form1 : Form
{
  /// <summary> Initializes a new instance of the <see cref="Form1"/> class. </summary>
  public Form1()
  {
    InitializeComponent();
  }

  private async void btnCreateLinks_Click(object sender, EventArgs e)
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

  private void btnSelectLinkFolder_Click(object sender, EventArgs e)
  {
    _ = folderBrowserDialog1.ShowDialog(this);
    textBox2.Text = folderBrowserDialog1.SelectedPath;
  }

  /// <summary> btns the sel targets_ click. </summary>
  private async void BtnSelTargets_ClickAsync(object sender, EventArgs e)
  {
    var result = new StringBuilder();
    switch (folderBrowserDialog1.ShowDialog(this))
    {
      case DialogResult.OK:
        textBox1.Text = folderBrowserDialog1.SelectedPath;
        await Helper.ListLinks(textBox1.Text, result);
        textBox3.Text = result.ToString();
        break;
      case DialogResult.Abort:

      case DialogResult.Cancel:
        break;
    }


  }
}