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
using static System.Windows.Forms.LinkLabel;
using CliWrap;
using CliWrap.Buffered;
namespace LinkAllConfig;

internal class Helper
{
  public static async Task<string> ListLinks(string target, Action<string> callback)
  {
    StringBuilder result = new StringBuilder();
    await Cli.Wrap("cmd.exe")
    .WithArguments($"/c fsutil hardlink list \"{target}\"")
    .WithStandardOutputPipe(PipeTarget.ToStringBuilder(result))
    .ExecuteAsync();
    return await Task.FromResult(result.ToString());
  }
  public static async Task<string> ListLinks1(string target, Action<string> callback)
  {
    try
    {

      using var process = new Process();
      process.StartInfo = new ProcessStartInfo
      {
        FileName = "cmd",

        UseShellExecute = false,
        CreateNoWindow = true,
        RedirectStandardError = true,
        RedirectStandardOutput = true,
        RedirectStandardInput = true,
      };
      ;
      process.EnableRaisingEvents = false;

      //process.ErrorDataReceived += (sender, e) => callback(e.Data);
      //process.OutputDataReceived += (sender, e) => callback(e.Data);
      //process.ErrorDataReceived += process_ErrorDataReceived;
      //process.OutputDataReceived += process_OutputDataReceived;
      _ = process.Start();
      process.StandardInput.AutoFlush = true;
      //process.BeginOutputReadLine();
      //process.BeginErrorReadLine();

      process.StandardInput.WriteLine($"fsutil hardlink list \"{target}\" & exit");


      process.WaitForExit();
      //  process.Close();
      return await Task.FromResult(process.StandardOutput.ReadToEnd());
    }
    catch (Exception ex)
    {
      _ = MessageBox.Show(
      Resources.CmdNotFound,
      Resources.MessageBoxErrorTitle,
      MessageBoxButtons.OK,
      MessageBoxIcon.Error);

      return await Task.FromResult(ex.Message);
    }
  }
  public static async Task<string> MakeFileHardLinks(IEnumerable<string> links, string target)
  {
    var cmd = links.Aggregate(new StringBuilder(), (ret, link) =>
    {
      if (!File.Exists(link))
        return ret.AppendLine($"fsutil hardlink create \"{link}\" \"{target}\"");
      else
        return ret.AppendLine($"echo \"文件已存在：{link}\"");
    });
    cmd.Replace("\r\n", " && ");
    if (cmd.Length > 4) { cmd.Length -= 4; }

    StringBuilder result = new StringBuilder();
    //await Cli.Wrap("cmd.exe")
    //  .WithArguments($"/c")
    //  .WithStandardInputPipe(PipeSource.FromString(cmd.ToString()))
    //  .WithStandardOutputPipe(PipeTarget.ToStringBuilder(result))
    //  .WithStandardErrorPipe(PipeTarget.ToStringBuilder(result))
    //  .ExecuteAsync();
    var cli = cmd.ToString() | Cli.Wrap("cmd.exe") | result;
    await cli.ExecuteAsync();
    return await Task.FromResult(result.ToString());
  }
  /// <summary>
  /// Makes the file hard links.
  /// </summary>
  /// <param name="links">The links.</param>
  /// <param name="target">The target.</param>
  /// <returns>A Task.</returns>
  public static async Task<string> MakeFileHardLinks1(IEnumerable<string> links, string target)
  {
    try
    {


      using var process = new Process();
      process.StartInfo = new ProcessStartInfo
      {
        FileName = "cmd",
        UseShellExecute = false,
        CreateNoWindow = true,
        RedirectStandardError = true,
        RedirectStandardOutput = true,
        RedirectStandardInput = true,

      };
      process.EnableRaisingEvents = false;

      //process.ErrorDataReceived += process_ErrorDataReceived;
      //process.OutputDataReceived += process_OutputDataReceived;
      _ = process.Start();
      process.StandardInput.AutoFlush = true;
      //process.BeginOutputReadLine();
      //process.BeginErrorReadLine();

      var cmd = links.Aggregate(new StringBuilder(), (ret, link) =>
      {
        if (!File.Exists(link))
          return ret.Append($"fsutil hardlink create \"{link}\" \"{target}\" &&");
        else
          return ret.Append($"echo \"文件已存在：{link}\" &&");
      });
      if (cmd.Length > 2)
      {
        cmd.Length -= 2;

        await process.StandardInput.WriteLineAsync(cmd.ToString());
      }

      await process.WaitForExitAsync();
      //process.Close();
      return await process.StandardOutput.ReadToEndAsync();
    }
    catch (Exception ex)
    {
      _ = MessageBox.Show(
      Resources.CmdNotFound,
      Resources.MessageBoxErrorTitle,
      MessageBoxButtons.OK,
      MessageBoxIcon.Error);

      return await Task.FromResult(ex.ToString());
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