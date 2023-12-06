using LinkAllConfig.Properties;
using LinkAllConfig.Utils;

namespace LinkAllConfig;

/// <summary> The form1. </summary>
public partial class Form1 : Form
{
	private readonly Action<string> output;
	private Helper helper;

	/// <summary> Initializes a new instance of the <see cref="Form1"/> class. </summary>
	public Form1()
	{
		InitializeComponent();
		txtFsutilPath.Text = @"C:\Windows\System32\fsutil.exe";
		output = s =>
		{
			Debug.WriteLine(s);

			Invoke(() =>
		{
			txtOutput.AppendText(s);
			txtOutput.AppendText(Environment.NewLine);
		});
		};
		helper = new Helper(txtFsutilPath.Text, output);
	}

	/// <summary>
	/// btns the create links_ click.
	/// </summary>
	/// <param name="sender">The sender.</param>
	/// <param name="e">The e.</param>
	private async void BtnCreateLinks_ClickAsync(object sender, EventArgs e)
	{
		await helper.MakeFileHardLinksAsync(txtLIinks.Text, txtTargets.Text).ConfigureAwait(false);
	}

	/// <summary>
	/// btns the select link folder_ click.
	/// </summary>
	/// <param name="sender">The sender.</param>
	/// <param name="e">The e.</param>
	private void BtnSelectLinkFolder_Click(object sender, EventArgs e)
	{
		_ = folderBrowserDialog1.ShowDialog(this);
		txtLIinks.Text = folderBrowserDialog1.SelectedPath;
	}

	/// <summary>
	/// btns the select tool_ click.
	/// </summary>
	/// <param name="sender">The sender.</param>
	/// <param name="e">The e.</param>
	private void BtnSelectTool_Click(object sender, EventArgs e)
	{
		switch (openFileDialog1.ShowDialog(this))
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

	/// <summary> btns the sel targets_ click. </summary>
	private async void BtnSelTargets_ClickAsync(object sender, EventArgs e)
	{
		switch (folderBrowserDialog1.ShowDialog(this))
		{
			case DialogResult.OK:
				txtTargets.Text = folderBrowserDialog1.SelectedPath;
				await helper.ListLinksAsync(txtTargets.Text).ConfigureAwait(false);
				break;
			case DialogResult.Abort:

			case DialogResult.Cancel:
				break;
		}
	}

	private void TxtFsutilPath_Validated(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(txtFsutilPath.Text) || File.Exists(txtFsutilPath.Text))
		{
			errorProvider1.SetError(txtFsutilPath, "请指定工具路径");
		}
		else
		{
			errorProvider1.SetError(txtFsutilPath, string.Empty);
		}
	}

	private void button1_Click(object sender, EventArgs e)
	{
		Settings.Default.SourceFolder = "xxxxx";
		Settings.Default.Save();
	}
}