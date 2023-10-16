using LinkAllConfig.Properties;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace LinkAllConfig;

internal class Helper
{
  public static async Task<string> ListLinks(string target, Action<string> callback)
  {
    try
    {
      var processStartInfo = new ProcessStartInfo
      {
        FileName = "cmd",
        UseShellExecute = false,
        CreateNoWindow = true,
        RedirectStandardError = true,
        RedirectStandardOutput = true,
        RedirectStandardInput = true,
      };

      using var process = new Process { StartInfo = processStartInfo, EnableRaisingEvents = true };

      process.ErrorDataReceived += (sender, e) => callback(e.Data);
      process.OutputDataReceived += (sender, e) => callback(e.Data);
      _ = process.Start();
      process.BeginOutputReadLine();
      process.BeginErrorReadLine();

      process.StandardInput.WriteLine($"fsutil hardlink list \"{target}\" & exit");

      process.StandardInput.AutoFlush = true;
      process.WaitForExit();
      process.Close();
      return await Task.FromResult(process.StandardOutput.ReadToEnd());
    }
    catch (Exception)
    {
      _ = MessageBox.Show(
      Resources.CmdNotFound,
      Resources.MessageBoxErrorTitle,
      MessageBoxButtons.OK,
      MessageBoxIcon.Error);

      return await Task.FromResult("");
    }
  }

  /// <summary>
  /// Makes the file hard links.
  /// </summary>
  /// <param name="links">The links.</param>
  /// <param name="target">The target.</param>
  /// <returns>A Task.</returns>
  public static async Task<string> MakeFileHardLinks(IEnumerable<string> links, string target)
  {
    try
    {
      var processStartInfo = new ProcessStartInfo
      {
        FileName = "cmd",
        UseShellExecute = false,
        CreateNoWindow = true,
        RedirectStandardError = true,
        RedirectStandardOutput = true,
        RedirectStandardInput = true,
      };

      using var process = new Process { StartInfo = processStartInfo, EnableRaisingEvents = true };

      process.ErrorDataReceived += process_ErrorDataReceived;
      process.OutputDataReceived += process_OutputDataReceived;
      _ = process.Start();
      process.BeginOutputReadLine();
      process.BeginErrorReadLine();
      foreach (var link in links)
      {
        process.StandardInput.WriteLine($"fsutil hardlink create \"{link}\" \"{target}\" & exit");
      }
      process.StandardInput.AutoFlush = true;
      process.WaitForExit();
      process.Close();
      return await Task.FromResult(process.StandardOutput.ReadToEnd());
    }
    catch (Exception)
    {
      _ = MessageBox.Show(
      Resources.CmdNotFound,
      Resources.MessageBoxErrorTitle,
      MessageBoxButtons.OK,
      MessageBoxIcon.Error);

      return await Task.FromResult("");
    }
  }

  private static void process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
  {
    if (!string.IsNullOrEmpty(e.Data))
    {
      _ = MessageBox.Show(e.Data, Resources.MessageBoxErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
  }

  private static void process_OutputDataReceived(object sender, DataReceivedEventArgs e)
  {
    if (!string.IsNullOrEmpty(e.Data))
    {
      _ = MessageBox.Show(e.Data, Resources.MessageBoxSuccessTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
  }
}