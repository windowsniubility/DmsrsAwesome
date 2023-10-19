namespace LinkAllConfig;

/// <summary>
/// The helper.
/// </summary>
internal static class Helper
{
  /// <summary>
  /// The target file path.
  /// </summary>
  private const string TargetFilePath = @"C:\Windows\System32\fsutil.exe";

  /// <summary>
  /// Lists the links.
  /// </summary>
  /// <param name="target">   The target. </param>
  /// <param name="callback"> The callback. </param>
  /// <returns> A Task. </returns>
  public static async Task<string> ListLinks(string target, Action<string> callback)
  {
    var result = new StringBuilder();
    _ = await Cli.Wrap(TargetFilePath)
    .WithArguments(args => args.Add("hardlink").Add("list").Add(target))
    .WithStandardOutputPipe(PipeTarget.ToStringBuilder(result))
    .ExecuteAsync();
    return await Task.FromResult(result.ToString());
  }

  /// <summary>
  /// Makes the file hard links.
  /// </summary>
  /// <param name="links">  The links. </param>
  /// <param name="target"> The target. </param>
  /// <param name="result"> The result. </param>
  /// <returns> A Task. </returns>
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
        _ = await cmd.ExecuteBufferedAsync();
        _ = result.AppendLine();
      }
      catch (Exception ex)
      {
        _ = result.AppendLine(ex.ToString());
      }
    }
  }
}
