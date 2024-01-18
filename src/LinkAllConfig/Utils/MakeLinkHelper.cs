using System.IO.Abstractions;

namespace LinkAllConfig.Utils;

/// <summary>
/// The helper.
/// </summary>
/// <remarks>
/// <para>
/// Initializes a new instance of the <see cref="MakeLinkHelper"/> class.
/// </para>
/// </remarks>
/// <param name="targetPath">The target path.</param>
/// <param name="output">The output.</param>
internal sealed class MakeLinkHelper(string targetPath, Action<string> output)
{
	private static readonly string[] FileNames = [
		".clang-format",
		".editorconfig",
		".gitattributes",
		".gitignore",
		"CodeMaid.config",
		"Directory.Analyzers.props",
		"Directory.Build.props",
		"Directory.Build.rsp",
		"Directory.Debug.props",
		"Directory.Debug.Sys.props",
		"Directory.Packages.props",
		"NuGet.config"];

	/// <summary>
	/// The target file path.
	/// </summary>
	private readonly string targetFilePath = targetPath;

	/// <summary>
	/// Gets the output.
	/// </summary>
	private Action<string> Output { get; } = output;

	/// <summary>
	/// Lists the links.
	/// </summary>
	/// <param name="target">The target.</param>
	/// <returns>A Task.</returns>
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
	/// <param name="linkBaseFolder">The link folder.</param>
	/// <param name="targetParentFolder">The targets parent.</param>
	/// <param name="signal">The signal.</param>
	/// <returns>A Task.</returns>
	public async Task MakeFileHardLinksAsync(string linkBaseFolder, string targetParentFolder, CancellationToken signal = default)
	{
		var outputPipe = PipeTarget.ToDelegate(s => Output(s.Insert(0, new string(' ', 8))));

		foreach (var tar in FileNames.Select(fileName => new { fileName, folder = targetParentFolder, target = Path.Combine(targetParentFolder, fileName) })
			.Where(t => File.Exists(t.target)))
		{
			if (signal.IsCancellationRequested)
			{
				Output("Stop");

				break;
			}

			Output(tar.fileName);

			foreach (var lnk in Directory.EnumerateDirectories(linkBaseFolder).Select(folder => new { folder, linkFile = Path.Combine(folder, tar.fileName) }))
			{
				if (tar.folder == lnk.folder)
				{
					continue;
				}

				if (signal.IsCancellationRequested)
				{
					Output("Stop");
					break;
				}

				var link = lnk.linkFile;
				Output(lnk.folder.Insert(0, new string(' ', 4)));

				if (File.Exists(link))
				{
					File.Delete(link);
				}

				try
				{
					var cmd = Cli.Wrap(targetFilePath)
							.WithArguments(args => args.Add("hardlink").Add("create").Add(link).Add(tar.target))
							.WithStandardOutputPipe(outputPipe)
							.WithStandardErrorPipe(outputPipe)

						// .WithValidation(CommandResultValidation.None)
						;

					_ = await cmd.ExecuteBufferedAsync(signal);
				}
				catch (Exception ex)
				{
					Output(ex.ToString());
				}
			}
		}
	}
}