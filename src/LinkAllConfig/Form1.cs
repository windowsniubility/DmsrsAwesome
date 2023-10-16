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

    listView1.Items.Add(r);
  }

  private void button2_Click(object sender, EventArgs e)
  {
    folderBrowserDialog1.ShowDialog(this);
    this.textBox2.Text = folderBrowserDialog1.SelectedPath;
  }
}