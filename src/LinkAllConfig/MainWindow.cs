// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// <summary>
//   This class manages the window
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Globalization;
using System.Reflection;
using System.Text;
using LinkAllConfig.Properties;

namespace DmsrsAwesome;

/// <summary>
///     This class manages the window.
/// </summary>
public partial class MainWindow : Form
{
	private static readonly CompositeFormat AboutDesc = CompositeFormat.Parse(Resources.AboutDescription);

	/// <summary>The tool tip.</summary>
	private readonly ToolTip toolTip = new();

	/// <summary>The folder.</summary>
	private bool folder;

	/// <summary>
	///     Initializes a new instance of the <see cref="MainWindow" /> class.
	///     The constructor.
	/// </summary>
	public MainWindow()
	{
		InitializeComponent();
		toolTip.IsBalloon = true;
		linkTypeComboBox.SelectedIndex = 0;
		TypeSelector.SelectedIndex = 0;
	}

	/// <summary>The combo box 1 mouse hover.</summary>
	/// <param name="sender">The sender.</param>
	/// <param name="e">The e.</param>
	private void ComboBox1MouseHover(object sender, EventArgs e)
	{
		toolTip.ToolTipIcon = ToolTipIcon.Info;
		toolTip.UseAnimation = true;
		toolTip.UseFading = true;
		toolTip.AutoPopDelay = 5000;
		toolTip.ToolTipTitle = "Symbolic Link types";

		toolTip.SetToolTip(linkTypeComboBox, "This option allows you to select the style of your symbolic link, either\nyou choose to use symbolic links, hard links or directory junctions.\n use symbolic links as a default");
	}

	/// <summary>
	///     This Method lets you select the type of link you want to create.
	/// </summary>
	/// <returns>String with the type of link to create.</returns>
	private string ComboBoxSelection() =>
		linkTypeComboBox.SelectedIndex switch
		{
			1 => "/H ",
			2 => "/J ",
			_ => string.Empty
		};

	/// <summary>
	///     Creates the link if the conditions are met.
	/// </summary>
	private void CreateLink()
	{
		try
		{
			if (!string.IsNullOrEmpty(linkLocationTextBox.Text) && !string.IsNullOrEmpty(linkNameComboBox.Text) && !string.IsNullOrEmpty(destinationLocationTextBox.Text))
			{
				// Everything needs to be filled...
				if (folder && Directory.Exists(linkLocationTextBox.Text) && Directory.Exists(destinationLocationTextBox.Text))
				{
					// Ask if the folders exist
					var link = $"\"{linkLocationTextBox.Text}\\{linkNameComboBox.Text}\" ";

					// concatenates the link name with the folder name and then it adds a pair of ", to allow using directories with spaces..
					var directories = Directory.GetDirectories(linkLocationTextBox.Text);

					// gets the folders in the selected directory
					if (directories.Any(e => e.Split('\\').Last().Equals(linkNameComboBox.Text, StringComparison.Ordinal)))
					{
						// looks for folders with the same name of the link name
						// if found the program ask the user if he wants to delete the folder that is already there
						var answer = MessageBox.Show(Resources.DialogFolderExists, Resources.DialogFolderExistsDialog, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

						if (answer == DialogResult.Yes)
						{
							// if the answer is yes, the folder is deleted in order to create a new one
							var dir2Delete = directories.First(e => e.Split('\\').Last().Equals(linkNameComboBox.Text, StringComparison.Ordinal));

							Directory.Delete(dir2Delete);
							SendCommand(link);

							return;
						}

						_ = MessageBox.Show(Resources.LinkCreationAborted, Resources.LinkCreationAbortedWarning, MessageBoxButtons.OK, MessageBoxIcon.Stop);
					}
					else
					{
						SendCommand(link);
					}
				}
				else if (Directory.Exists(linkLocationTextBox.Text) && File.Exists(destinationLocationTextBox.Text))
				{
					// same thing as above... it just deletes files instead of folders
					var link = $"\"{linkLocationTextBox.Text}\\{linkNameComboBox.Text}\" ";

					var files = Directory.GetFiles(linkLocationTextBox.Text);

					if (files.Any(e => e.Split('\\').Last().Equals(linkNameComboBox.Text, StringComparison.Ordinal)))
					{
						var answer = MessageBox.Show(Resources.DialogDeleteFile, Resources.DialogDeleteFileWarning, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

						if (answer == DialogResult.Yes)
						{
							var file2Delete = files.First(e => e.Split('\\').Last().Equals(linkNameComboBox.Text, StringComparison.Ordinal));

							File.Delete(file2Delete);
							SendCommand(link);

							return;
						}

						_ = MessageBox.Show(Resources.LinkCreationAborted, Resources.LinkCreationAbortedWarning, MessageBoxButtons.OK, MessageBoxIcon.Stop);
					}
					else
					{
						SendCommand(link);
					}
				}
				else
				{
					_ = MessageBox.Show(Resources.FilesOrFolderNotExists, Resources.MessageBoxErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
			else
			{
				_ = MessageBox.Show(Resources.FillBlanks, Resources.MessageBoxErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		catch (Exception exception)
		{
			_ = MessageBox.Show(Resources.MessageBoxExceptionOcurred + exception.Message, Resources.MessageBoxErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}

	/// <summary>
	///     Creates the link click.
	/// </summary>
	/// <param name="sender">The sender.</param>
	/// <param name="e">The e.</param>
	private void CreateLinkClick(object sender, EventArgs e) => CreateLink();

	/// <summary>
	///     Explores the button1 click.
	/// </summary>
	/// <param name="sender">The sender.</param>
	/// <param name="e">The e.</param>
	private void ExploreButton1Click(object sender, EventArgs e)
	{
		_ = folderBrowser.ShowDialog();
		linkLocationTextBox.Text = folderBrowser.SelectedPath;
	}

	/// <summary>
	///     Explorebutton2S the click.
	/// </summary>
	/// <param name="sender">The sender.</param>
	/// <param name="e">The e.</param>
	private void Explorebutton2Click(object sender, EventArgs e)
	{
		// if folder is true the folder browser will be shown
		if (folder)
		{
			_ = folderBrowser.ShowDialog();
			destinationLocationTextBox.Text = folderBrowser.SelectedPath;
		}
		else
		{
			_ = filesBrowser.ShowDialog();
			destinationLocationTextBox.Text = filesBrowser.FileName;
		}
	}

	/// <summary>
	///     Helps the image click.
	/// </summary>
	/// <param name="sender">The sender.</param>
	/// <param name="e">The e.</param>
	private void HelpImageClick(object sender, EventArgs e)
	{
		string? version;
		var assembly = Assembly.GetExecutingAssembly();
		var fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
		version = fvi.FileVersion;

		// try
		// {
		//  version = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
		// }
		// catch
		// {
		//  var assembly = Assembly.GetExecutingAssembly();
		//  var fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
		//  version = fvi.FileVersion;
		// }
		_ = MessageBox.Show(string.Format(CultureInfo.CurrentCulture, AboutDesc, version), Resources.MessageBoxAboutTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
	}

	/// <summary>
	///     Process_S the error data received.
	/// </summary>
	/// <param name="sender">The sender.</param>
	/// <param name="e">The e.</param>
	private void Process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
	{
		if (!string.IsNullOrEmpty(e.Data))
		{
			_ = MessageBox.Show(e.Data, Resources.MessageBoxErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}

	/// <summary>
	///     Process_S the output data received.
	/// </summary>
	/// <param name="sender">The sender.</param>
	/// <param name="e">The e.</param>
	private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
	{
		if (!string.IsNullOrEmpty(e.Data))
		{
			_ = MessageBox.Show(e.Data, Resources.MessageBoxSuccessTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}

	/// <summary>
	///     This method build a string using the paramethers provided by the user, after that, it start a new
	///     cmd.exe process with the string just built.
	/// </summary>
	/// <param name="link">Path to the place you want your symlink.</param>
	private void SendCommand(string link)
	{
		try
		{
			var target = string.Format(CultureInfo.InvariantCulture, "\"{0}\"", destinationLocationTextBox.Text);

			// concatenates a pair of "", this is to make folders with spaces to work
			var typeLink = ComboBoxSelection();
			var directory = folder ? "/D " : string.Empty;

			var stringCommand = string.Format(CultureInfo.InvariantCulture, "/c mklink {0}{1}{2}{3}", directory, typeLink, link, target);

			var processStartInfo = new ProcessStartInfo
			{
				FileName = "cmd",
				Arguments = stringCommand,
				UseShellExecute = false,
				CreateNoWindow = true,
				RedirectStandardError = true,
				RedirectStandardOutput = true
			};

			var process = new Process { StartInfo = processStartInfo, EnableRaisingEvents = true };
			process.ErrorDataReceived += Process_ErrorDataReceived;
			process.OutputDataReceived += Process_OutputDataReceived;
			_ = process.Start();
			process.BeginOutputReadLine();
			process.BeginErrorReadLine();
			process.WaitForExit();
			process.Close();
			process.Dispose();
		}
		catch (Exception)
		{
			_ = MessageBox.Show(Resources.CmdNotFound, Resources.MessageBoxErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}

	/// <summary>
	///     This method allows to switch modes between file or folder symlinks.
	/// </summary>
	private void Switcher()
	{
		if (TypeSelector.SelectedIndex == 0)
		{
			groupBox1.Text = Resources.MainWindow_Switcher_Link_Folder;
			groupBox2.Text = Resources.MainWindow_Switcher_Destination_Folder;
			label2.Text = Resources.MainWindow_Switcher_Now_give_a_name_to_the_link_;
			label3.Text = Resources.MainWindow_Switcher_Please_select_the_path_to_the_real_folder_you_want_to_link_;
			folder = true;
		}
		else
		{
			groupBox1.Text = Resources.MainWindow_Switcher_Link_File;
			groupBox2.Text = Resources.MainWindow_Switcher_Destination_File;
			label2.Text = Resources.MainWindow_Switcher_Now_give_a_name_to_your_file_;
			label3.Text = Resources.MainWindow_Switcher_Please_select_the_path_to_the_real_file_you_want_to_link_;
			folder = false;
		}
	}

	/// <summary>
	///     Texts the box_ drag drop.
	/// </summary>
	/// <param name="sender">The sender.</param>
	/// <param name="e">The e.</param>
	private void TextBox_DragDrop(object sender, DragEventArgs e)
	{
#pragma warning disable CS8602 // Dereference of a possibly null reference.
		if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
		{
			e.Effect = DragDropEffects.All;
		}
#pragma warning restore CS8602 // Dereference of a possibly null reference.
	}

	/// <summary>
	///     Texts the box_ drag enter.
	/// </summary>
	/// <param name="sender">The sender.</param>
	/// <param name="e">The e.</param>
	private void TextBox_DragEnter(object sender, DragEventArgs e)
	{
		var textBox = (TextBox)sender;

#pragma warning disable CS8602 // Dereference of a possibly null reference.
		if (e.Data.GetData(DataFormats.FileDrop) is string[] files && files.Length != 0)
		{
			textBox.Text = files[0];
		}
#pragma warning restore CS8602 // Dereference of a possibly null reference.
	}

	/// <summary>
	///     Texts the box_ drag over.
	/// </summary>
	/// <param name="sender">The sender.</param>
	/// <param name="e">The e.</param>
	private void TextBox_DragOver(object sender, DragEventArgs e)
	{
#pragma warning disable CS8602 // Dereference of a possibly null reference.
		e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
	}

	/// <summary>The type selector_ mouse hover.</summary>
	/// <param name="sender">The sender.</param>
	/// <param name="e">The e.</param>
	private void TypeSelectorMouseHover(object sender, EventArgs e)
	{
		toolTip.ToolTipIcon = ToolTipIcon.Info;
		toolTip.UseAnimation = true;
		toolTip.UseFading = true;
		toolTip.AutoPopDelay = 10000;
		toolTip.ToolTipTitle = Resources.TooltipTypeSelectorTitle;
		toolTip.SetToolTip(TypeSelector, Resources.TooltipTypeSelectorDescription);
	}

	/// <summary>The type selector_ selected index changed.</summary>
	/// <param name="sender">The sender.</param>
	/// <param name="e">The e.</param>
	private void TypeSelectorSelectedIndexChanged(object sender, EventArgs e) => Switcher();
}