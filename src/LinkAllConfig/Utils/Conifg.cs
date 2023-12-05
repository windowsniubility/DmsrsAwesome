using MessagePack;

namespace LinkAllConfig.Utils;

[MessagePackObject]
public class Conifg
{
	[Key(0)]
	public string? SourceFolder { get; set; } = @"C:\ScriptsApplications\code\DmsrsAwesome\src\LinkAllConfig\configs";

	[Key(1)]
	public string? DestinationFolder { get; set; } = @"C:\ScriptsApplications\code";

	[Key(2)]
	public string[]? SelectedFiles { get; set; }
}
