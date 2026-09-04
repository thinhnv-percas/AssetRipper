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
		CrackSettings.Load();
		DevXSystemInfo.DeviceName = Environment.MachineName;
		DevXSystemInfo.UserName = Environment.UserName;
		if (CrackSettings.AllowFakeDeviceInfo)
		{
			ChangeInfo();
		}
		if (CrackSettings.AllowOffline)
		{
			CrackSettings.AllowActivation = (CrackSettings.AllowDemoAssetRead = true);
		}
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
		DbgLog.W("ENV", "CrackSettings: AllowOffline=" + CrackSettings.AllowOffline + " AllowActivation=" + CrackSettings.AllowActivation + " AllowDemoAssetRead=" + CrackSettings.AllowDemoAssetRead);
		DbgLog.W("ENV", "FileManager.FakePath = \"" + FileManager.FakePath + "\" (canary would compute \"" + FileManager.FakePathCanary + "\"; anything but \"\" breaks every filename lookup)");
	}

	internal static string RandomString(int length)
	{
		return new string((from s in Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", length)
			select s[random.Next(s.Length)]).ToArray());
	}

	public static void ChangeInfo()
	{
		DevXSystemInfo.DeviceName = ((CrackSettings.AllowFakeDeviceInfo && CrackSettings.FakeMachineName != null && CrackSettings.FakeMachineName.Length != 0) ? CrackSettings.FakeMachineName : DevXSystemInfo.DeviceName);
		DevXSystemInfo.UserName = ((CrackSettings.AllowFakeDeviceInfo && CrackSettings.FakeUserName != null && CrackSettings.FakeUserName.Length != 0) ? CrackSettings.FakeUserName : DevXSystemInfo.UserName);
	}

	public static string GetDate()
	{
		return DateTime.Now.ToString("yyyy.MM.dd");
	}

	public static Bitmap getCrackPng()
	{
		return (Bitmap)Resources.ResourceManager.GetObject("Fox");
	}

	static Loader()
	{
		random = new Random();
	}

	public static void ShowCrackInfo()
	{
		new SoundPlayer(new MemoryStream((byte[])Resources.ResourceManager.GetObject("FoxSound"))).Play();
		new CrackWindow().ShowDialog(MainForm.instance);
	}

	public static void CheckConnection()
	{
		if (CrackSettings.AllowOffline)
		{
			ConsoleManager.WriteInfo("Connection ok to server: " + ServerLink.GetLink());
			ManyCodeCls.LoadAssets();
			MainForm.instance.AddAction(MainForm.instance.EnableSth1);
		}
		else
		{
			try
			{
				string[] obj = new string[5]
				{
					"https://devxdevelopment.com",
					"http://devxdevelopment.com",
					"https://mirror.devxdevelopment.com",
					"http://mirror.devxdevelopment.com",
					"http://mirror2.devxdevelopment.com"
				};
				string text = null;
				string[] array = obj;
				foreach (string text2 in array)
				{
					try
					{
						if (text != "OK")
						{
							text = WebReqManager.MakeReq2(text2 + "/AppSecurityUnpackerTools/Ping", "temp=" + DateTime.UtcNow.Ticks.ToString(), 10);
							if (text == "OK")
							{
								ServerLink.SetLink(text2);
								break;
							}
							ConsoleManager.WriteInfo("Connection error to  server: " + text2 + ", res: " + text);
						}
					}
					catch (Exception ex)
					{
						ConsoleManager.WriteInfo("Connection error to  server: " + text2 + "\r\n" + ex);
					}
				}
				if (text == "OK")
				{
					ConsoleManager.WriteInfo("Connection ok to server: " + ServerLink.GetLink());
					try
					{
						string text3 = WebReqManager.MakeReq2(ServerLink.GetLink() + "/AppSecurityUnpackerTools/RedirectTo", "temp=" + DateTime.UtcNow.Ticks.ToString(), 5);
						if (text3 != null && text3.StartsWith("RedirectTo:"))
						{
							ConsoleManager.WriteInfo("Redirect to server: " + text3);
							ServerLink.SetLink(text3.Substring("RedirectTo:".Length));
						}
					}
					catch
					{
					}
				}
				if (text != "OK")
				{
					MaybeAlertManager.ShowAlert("There is no connection to devxdevelopment.com\nFor the correct operation of the program - you need a network connection.");
					MainForm.instance.AddAction(MainForm.instance.killMe2);
				}
				else
				{
					string text4 = WebReqManager.MakeReq2(ServerLink.GetLink() + "/AppSecurityUnpackerTools/DateString", "temp=" + DateTime.UtcNow.Ticks.ToString());
					string text5 = DateTime.UtcNow.ToString("yyyy.MM.dd");
					if (DateTime.UtcNow.ToString("yyyy.MM.dd") != text4)
					{
						MaybeAlertManager.ShowAlert(TranslationManager.CalcHash("Warning! Server date and local date  not equal!!!\nFor the program to work, you need the date and time to be correct.(Server UTC date: " + text4 + ", Local UTC date=" + text5 + ")") + "---\n" + HashManager.DoNothing("Warning! Server date and local date  not equal!!!\nFor the program to work, you need the date and time to be correct.(Server UTC date: " + text4 + ", Local UTC date=" + text5 + ")"));
					}
					ManyCodeCls.LoadAssets();
					MainForm.instance.AddAction(MainForm.instance.EnableSth1);
				}
			}
			catch (Exception ex2)
			{
				MainForm.ExManager exManager = new MainForm.ExManager
				{
					instance = MainForm.instance
				};
				Exception ex3 = exManager.ex = ex2;
				ConsoleManager.LogExeption(string.Concat(exManager.ex));
				MainForm.instance.AddAction(exManager.kill);
			}
		}
	}

	public static Icon getCrackIcon()
	{
		return (Icon)Resources.ResourceManager.GetObject("FoxIco");
	}
}
