namespace LinkAllConfig.Utils;

/// <summary> The helper. </summary>
/// <remarks>
/// <para>Initializes a new instance of the <see cref="Helper"/> class.</para>
/// </remarks>
/// <param name="targetPath">The target path.</param>
/// <param name="output">The output.</param>
internal sealed class Helper(string targetPath, Action<string> output)
{
	/// <summary> The target file path. </summary>
	private readonly string targetFilePath = targetPath;

	/// <summary> Gets the output. </summary>
	private Action<string> Output { get; } = output;

	/// <summary> Lists the links. </summary>
	/// <param name="target"> The target. </param>
	/// <returns> A Task. </returns>
	public async Task ListLinksAsync(string target)
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
	/// <param name="signal">The signal.</param>
	/// <returns>A Task.</returns>
	public async Task MakeFileHardLinksAsync(string linkFolder, string targetsParent, CancellationToken signal = default)
	{
		var outputPipe = PipeTarget.ToDelegate(Output);
		foreach (var target in Directory.EnumerateFiles(targetsParent))
		{
			if (signal.IsCancellationRequested)
			{
				break;
			}

			foreach (var link in from folder in Directory.EnumerateDirectories(linkFolder) select Path.Combine(folder, Path.GetFileName(target)))
			{
				if (signal.IsCancellationRequested)
				{
					break;
				}

				if (File.Exists(link))
				{
					File.Delete(link);
				}

				try
				{
					var cmd = Cli.Wrap(targetFilePath)
						.WithArguments(args => args.Add("hardlink").Add("create").Add(link).Add(target))
						.WithStandardOutputPipe(outputPipe)
						.WithStandardErrorPipe(outputPipe)

				// .WithValidation(CommandResultValidation.None)
				;
					_ = await cmd.ExecuteBufferedAsync(cancellationToken: signal);
				}
				catch (Exception ex)
				{
					Output(ex.ToString());
				}
			}
		}
	}
}