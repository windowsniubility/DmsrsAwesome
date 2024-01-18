namespace LinkAllConfig;

/// <summary>
///     The program.
/// </summary>
internal static class Program
{
	/// <summary>
	///     The main entry point for the application.
	/// </summary>
	[STAThread]
	private static void Main()
	{
		// To customize application configuration such as set high DPI settings or default font,
		// see https://aka.ms/applicationconfiguration.
		ApplicationConfiguration.Initialize();
		using (var form = new Form1())
		{
			Application.Run(form);
		}
	}
}