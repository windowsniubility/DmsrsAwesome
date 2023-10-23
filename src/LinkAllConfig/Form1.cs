namespace LinkAllConfig;

/// <summary> The form1. </summary>
public partial class Form1 : Form
{
  private Helper helper;
  private readonly Action<string> output = s =>
  {
    Debug.WriteLine(s);
   // this
  };
  /// <summary> Initializes a new instance of the <see cref="Form1"/> class. </summary>
  public Form1()
  {
    InitializeComponent();
    this.txtFsutilPath.Text = @"C:\Windows\System32\fsutil.exe";
    this.helper = new Helper(this.txtFsutilPath.Text, output);
  }

  private async void btnCreateLinks_Click(object sender, EventArgs e)
  {
    await helper.MakeFileHardLinks(txtLIinks.Text,txtTargets.Text);
  }

  private void btnSelectLinkFolder_Click(object sender, EventArgs e)
  {
    _ = folderBrowserDialog1.ShowDialog(this);
    txtLIinks.Text = folderBrowserDialog1.SelectedPath;
  }

  /// <summary> btns the sel targets_ click. </summary>
  private async void BtnSelTargets_ClickAsync(object sender, EventArgs e)
  {
    switch (folderBrowserDialog1.ShowDialog(this))
    {
      case DialogResult.OK:
        txtTargets.Text = folderBrowserDialog1.SelectedPath;
        await helper.ListLinks(txtTargets.Text);
        break;
      case DialogResult.Abort:

      case DialogResult.Cancel:
        break;
    }


  }

  private void btnSelectTool_Click(object sender, EventArgs e)
  {
    switch (this.openFileDialog1.ShowDialog(this))
    {
      case DialogResult.OK:
        txtFsutilPath.Text = openFileDialog1.FileName;
        helper = new Helper(txtFsutilPath.Text, output);
        break;
      case DialogResult.Abort:

      case DialogResult.Cancel:
        break;
    }

  }
}