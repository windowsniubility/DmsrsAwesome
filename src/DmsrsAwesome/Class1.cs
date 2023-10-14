using System.Runtime.InteropServices;

namespace DmsrsAwesome;

internal static partial class NativeMethods
{
  [LibraryImport("user32.dll", SetLastError = true)]
  private static partial IntPtr SendMessage(IntPtr hWnd, uint Msg, UIntPtr wParam, IntPtr lParam);
}