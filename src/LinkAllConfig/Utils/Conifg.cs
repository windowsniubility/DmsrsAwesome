using MessagePack;

namespace LinkAllConfig.Utils;

[MessagePackObject]
public class Conifg
{
	/// <summary>
	/// Gets or Sets the destination folder.
	/// </summary>
	/// <value>A string?.</value>
	[Key(1)]
	public string? DestinationFolder { get; set; } = @"C:\ScriptsApplications\code";

	/// <summary>
	/// Gets or Sets the selected files.
	/// </summary>
	/// <value>A string[]?.</value>
	[Key(2)]
	public string[]? SelectedFiles { get; set; }

	/// <summary>
	/// Gets or Sets the source folder.
	/// </summary>
	/// <value>A string?.</value>
	[Key(0)]
	public string? SourceFolder { get; set; } = @"C:\ScriptsApplications\code\DmsrsAwesome\src\LinkAllConfig\configs";
}