using CliWrap;
using CliWrap.Buffered;
using LinkAllConfig.Properties;
using System.Diagnostics;
using System.Text;

namespace LinkAllConfig;

internal class Helper
{
  /// <summary>
  /// The target file path.
  /// </summary>
  private const string TargetFilePath = @"C:\Windows\System32\fsutil.exe";

  public static async Task<string> ListLinks(string target, Action<string> callback)
  {
    StringBuilder result = new StringBuilder();
    await Cli.Wrap(TargetFilePath)
    .WithArguments(args => args.Add("hardlink").Add("list").Add(target))
    .WithStandardOutputPipe(PipeTarget.ToStringBuilder(result))
    .ExecuteAsync();
    return await Task.FromResult(result.ToString());
  }

  public static async Task MakeFileHardLinks(IEnumerable<string> links, string target, StringBuilder result)
  {
    var outpipe = PipeTarget.ToStringBuilder(result, Encoding.UTF8);
    foreach (var link in links)
    {
      if (File.Exists(link))
      {
        File.Delete(link);
      }
      try
      {
        var cmd = Cli.Wrap(TargetFilePath)
         .WithArguments(args => args.Add("hardlink").Add("create").Add(link).Add(target))
         .WithStandardOutputPipe(outpipe)
       .WithStandardErrorPipe(outpipe)
       // .WithValidation(CommandResultValidation.None)
       ;
        await cmd.ExecuteBufferedAsync();
        result.AppendLine();
      }
      catch (Exception ex)
      {
        result.AppendLine(ex.ToString());
      }
    }
  }
}