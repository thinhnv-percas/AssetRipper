using DevXUnityUnpackerTools.Properties;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

[FunAttr(Num = "57386656BAF504D050F524792BA0D038")]
internal class Loader
{
	public class Filter : IMessageFilter
	{
		internal static ushort WM_SYSKEYDOWN;

		public bool PreFilterMessage(ref Message m)
		{
			if (m.Msg == WM_SYSKEYDOWN)
			{
				return Control.ModifierKeys != Keys.None;
			}
			return false;
		}

		static Filter()
		{
			WM_SYSKEYDOWN = 260;
		}
	}

	internal static Random random;

	[DllImport("kernel32.dll", SetLastError = true)]
	internal static extern bool AllocConsole();

	[DllImport("kernel32.dll", SetLastError = true)]
	internal static extern bool FreeConsole();

	[DllImport("kernel32", SetLastError = true)]
	internal static extern bool AttachConsole(int i);

	[DllImport("user32.dll")]
	internal static extern IntPtr GetForegroundWindow();

	[DllImport("user32.dll", SetLastError = true)]
	internal static extern uint GetWindowThreadProcessId(IntPtr ptr, out int i);

	internal static void InitConsole()
	{
		AttachConsole(-1);
		AllocConsole();
	}

	internal static void Load()
	{
		DevXSystemInfo.DeviceName = Environment.MachineName;
		DevXSystemInfo.UserName = Environment.UserName;
		DevXSystemInfo.FullExecuteblePath = Process.GetCurrentProcess().MainModule.FileName;
		DevXSystemInfo.TempPath = Path.GetTempPath();
		DevXSystemInfo.Is64BitProcess = Environment.Is64BitProcess;
		DevXSystemInfo.OSVersion = Environment.OSVersion.ToString();
		DevXSystemInfo.CurrentCulture = Thread.CurrentThread.CurrentCulture.Name;
		DevXSystemInfo.LocalApplicationData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
		DevXSystemInfo.PersistentDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DevXUnityUnpacker");
		DevXSystemInfo.UnpackerRootDirectory = Application.StartupPath;
		DevXSystemInfo.Platform = "Windows.WinForms";
		DevXSystemInfo.IsWin_Forms = true;
		DevXSystemInfo.IsWin_OS = true;
		DevXSystemInfo.LogDir = Application.StartupPath;
		DevXSystemInfo.PluginsDir = Path.Combine(Application.StartupPath, "Library");
		DevXSystemInfo.StreamingAssets = Path.Combine(Application.StartupPath, "StreamingAssets");
		LogEnvironment();
		if (!Directory.Exists(DevXSystemInfo.PersistentDataPath))
		{
			Directory.CreateDirectory(DevXSystemInfo.PersistentDataPath);
		}
		Directory.SetCurrentDirectory(Application.StartupPath);
		if (Environment.GetCommandLineArgs().Length > 1 && Environment.GetCommandLineArgs()[1].StartsWith("/"))
		{
			InitConsole();
			new MainForm().Init();
		}
		else
		{
			try
			{
				Application.AddMessageFilter(new Filter());
				Application.Run(new MainForm());
			}
			catch (Exception arg)
			{
				MessageBox.Show(string.Concat(arg));
			}
		}
	}

	// Debug tracing only — see DbgLog. Every runtime data dependency the IL2CPP
	// pipeline needs is resolved off these paths, so record what is actually there.
	private static void LogEnvironment()
	{
		DbgLog.W("ENV", "log file is " + DbgLog.LogPath);
		DbgLog.Probe("ENV", "StartupPath", DevXSystemInfo.UnpackerRootDirectory);
		DbgLog.Probe("ENV", "PluginsDir (Library)", DevXSystemInfo.PluginsDir);
		DbgLog.Probe("ENV", "StreamingAssets", DevXSystemInfo.StreamingAssets);
		DbgLog.Probe("ENV", "PersistentDataPath", DevXSystemInfo.PersistentDataPath);
		try
		{
			string sa = DevXSystemInfo.StreamingAssets;
			DbgLog.Probe("ENV", "ArmCP/x64/arm_cp.dll", Path.Combine(sa, "ArmCP", "x64", "arm_cp.dll"));
			DbgLog.Probe("ENV", "ArmCP/x86/arm_cp.dll", Path.Combine(sa, "ArmCP", "x86", "arm_cp.dll"));
			DbgLog.Probe("ENV", "UnityDLL", Path.Combine(sa, "UnityDLL"));
			// DB layout struct runtime IL2CPP. Thay cho IL2CPPStructs/*.dvxil2c cũ.
			string structDb = Path.Combine(sa, Il2CppStructDbJson.DirectoryName);
			DbgLog.Probe("ENV", "structdb", structDb);
			if (Directory.Exists(structDb))
			{
				DbgLog.W("ENV", "structdb: " + Directory.GetFiles(structDb, "*-x64.json").Length + " phiên bản Unity");
			}
			else
			{
				DbgLog.W("ENV", "structdb KHÔNG CÓ -> thân hàm IL2CPP sẽ chỉ có offset thô, không có tên field");
			}
			if (Directory.Exists(Path.Combine(sa, "UnityDLL")))
			{
				DbgLog.W("ENV", "UnityDLL zips = " + Directory.GetFiles(Path.Combine(sa, "UnityDLL"), "*.zip").Length);
			}
			// Type-tree của Unity built-in classes. Thay cho ClassAll.zip/UnityType.zip cũ.
			// Thiếu bộ này thì mọi asset parse ra "unknown type" mà KHÔNG báo lỗi ở đâu cả,
			// nên phải probe ngay tại đây.
			string typeTreeDb = Path.Combine(sa, @as.UnityTypeTreeDb.DirectoryName);
			DbgLog.Probe("ENV", "typetreedb", typeTreeDb);
			if (Directory.Exists(typeTreeDb))
			{
				DbgLog.W("ENV", "typetreedb: " + Directory.GetFiles(typeTreeDb, "*.json").Length + " file JSON");
			}
			else
			{
				DbgLog.W("ENV", "typetreedb KHÔNG CÓ -> không đọc được .assets/AssetBundle, "
					+ "mọi type sẽ là unknown. Sinh bằng: python tools/typetreedb_gen.py");
			}
		}
		catch (Exception ex)
		{
			DbgLog.Ex("ENV", "probing StreamingAssets failed", ex);
		}
		DbgLog.W("ENV", "FileManager.FakePath = \"" + FileManager.FakePath + "\" (canary would compute \"" + FileManager.FakePathCanary + "\"; anything but \"\" breaks every filename lookup)");
	}

	internal static string RandomString(int length)
	{
		return new string((from s in Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", length)
			select s[random.Next(s.Length)]).ToArray());
	}

	public static void ChangeInfo()
	{
	}

	public static string GetDate()
	{
		return DateTime.Now.ToString("yyyy.MM.dd");
	}

	public static Bitmap getCrackPng()
	{
		return null;
	}

	static Loader()
	{
		random = new Random();
	}

	public static void ShowCrackInfo()
	{
	}

	public static void CheckConnection()
	{
		ConsoleManager.WriteInfo("Connection ok to server: " + ServerLink.GetLink());
		ManyCodeCls.LoadAssets();
		MainForm.instance.AddAction(MainForm.instance.EnableSth1);
	}
}
