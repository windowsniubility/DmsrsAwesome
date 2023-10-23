namespace LinkAllConfig;

/// <summary> The helper. </summary>
internal class Helper
{
  /// <summary> The target file path. </summary>
  private readonly string targetFilePath;

  /// <summary>
  /// Initializes a new instance of the <see cref="Helper"/> class.
  /// </summary>
  /// <param name="targetPath">The target path.</param>
  /// <param name="output">The output.</param>
  public Helper(string targetPath, Action<string> output)
  {
    targetFilePath = targetPath;
    Output = output;
  }

  /// <summary> Gets the output. </summary>
  private Action<string> Output { get; }

  /// <summary> Lists the links. </summary>
  /// <param name="target"> The target. </param>
  /// <returns> A Task. </returns>
  public async Task ListLinks(string target)
  {
    try
    {
      _ = await Cli.Wrap(targetFilePath)
  .WithArguments(args => args.Add("hardlink").Add("list").Add(target))
  .WithStandardOutputPipe(PipeTarget.ToDelegate(Output))
  .ExecuteAsync();
    }
    catch (Exception ex)
    {
      Output(ex.ToString());
    }
  }

  /// <summary>
  /// Makes the file hard links.
  /// </summary>
  /// <param name="linkFolder">The link folder.</param>
  /// <param name="targetsParent">The targets parent.</param>
  /// <returns>A Task.</returns>
  public async Task MakeFileHardLinks(string linkFolder, string targetsParent)
  {
    var outpipe = PipeTarget.ToDelegate(Output);
    foreach (var target in Directory.EnumerateFiles(targetsParent))
    {
      var folders = Directory.EnumerateDirectories(linkFolder);

      var links = from folder in folders select Path.Combine(folder, Path.GetFileName(target));

      foreach (var link in links)
      {
        if (File.Exists(link))
        {
          File.Delete(link);
        }

        try
        {
          var cmd = Cli.Wrap(targetFilePath)
              .WithArguments(args => args.Add("hardlink").Add("create").Add(link).Add(target))
              .WithStandardOutputPipe(outpipe)
              .WithStandardErrorPipe(outpipe)

      // .WithValidation(CommandResultValidation.None)
      ;
          _ = await cmd.ExecuteBufferedAsync();
        }
        catch (Exception ex)
        {
          Output(ex.ToString());
        }
      }
    }
  }
}