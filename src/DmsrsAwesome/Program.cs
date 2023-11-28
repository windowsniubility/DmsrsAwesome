// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DmsrsAwesome;

/// <summary>The program.</summary>
internal static class Program
{
	/// <summary>
	///   The main entry point for the application.
	/// </summary>
	[STAThread]
	private static void Main(string[] args)
	{
		// if (string.IsNullOrEmpty((from o in args where o == "--engage" select o).FirstOrDefault()))
		// {
		//    var btnElevate = new Button { FlatStyle = FlatStyle.System };

		// SendMessage(btnElevate.Handle, BCM_SETSHIELD, 0, (IntPtr)1);

		// var processInfo = new ProcessStartInfo();
		//  //  processInfo.Verb = "runas";
		//    processInfo.FileName = Application.ExecutablePath;
		//    processInfo.Arguments = string.Join(" ", args.Concat(new[] { "--engage" }).ToArray());
		//    try
		//    {
		//        var p = Process.Start(processInfo);
		//        p.WaitForExit();
		//    }
		//    catch (Win32Exception)
		//    {
		//        //Do nothing. Probably the user cancelled the UAC window or provided invalid credentials.
		//    }

		// Application.Exit();
		// }
		// else
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainWindow());
		}
	}

	// [DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
	// private static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, IntPtr lParam);
}