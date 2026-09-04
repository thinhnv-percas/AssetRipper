using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

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
		internal sealed class Data
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

		internal static Dictionary<int, ConsoleData> hashes;

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

		internal static ConsoleData MakeConsoleData(VerFormat ver, int i1, int i2, string s = null, int i4 = 0, int[] iArr = null)
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
				// Nguồn duy nhất là typetreedb (JSON trên đĩa). Nhánh mạng cũ
				// (MakeRequest -> devxdevelopment.com -> EncryptDecryptManager.Decrypt)
				// đã bị gỡ: CrackSettings.AllowOffline mặc định true nên nó vốn đã
				// không bao giờ chạy, và nó mang theo cả payload license lẫn nhánh
				// "CleanProgramm:" do server điều khiển.
				StrSth strSth = CrackSettings.AllowDemoAssetRead
					? MakeDemoRequest(data.ver, i1, iArr, s, data.i)
					: null;
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
						int key = getHash(num2, s, ref data);
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

		public static IEnumerable<string> Format1(string s)
		{
			VerFormat ver = new VerFormat(s);
			foreach (string item in Format2(ver))
			{
				yield return item;
			}
		}

		internal static IEnumerable<string> Format2(VerFormat ver)
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

		internal static ConsoleData ForReqData(int i, VerFormat ver, int i2 = 0)
		{
			return UnityTypeTreeDb.LoadNearest(ver)?.FindByInt(i);
		}

		/// <summary>
		/// Cây type của phiên bản Unity gần nhất có trong typetreedb.
		/// Thay cho cặp TryGetStrSth/TryGetStrSth2 cũ: hai hàm đó quét substring
		/// "_v&lt;version&gt;" trên toàn bộ dictionary 718 key, một lần cho MỖI chuỗi
		/// version ứng viên mà Format2 sinh ra.
		/// </summary>
		internal static StrSth GetStrSth(VerFormat ver)
		{
			return UnityTypeTreeDb.LoadNearest(ver);
		}

		/// <summary>Quá tải cũ theo chuỗi version, giữ cho phần gọi bên ngoài.</summary>
		internal static StrSth GetStrSth(string unityVersion)
		{
			return string.IsNullOrEmpty(unityVersion) ? null : UnityTypeTreeDb.LoadNearest(new VerFormat(unityVersion));
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
			hashes = new Dictionary<int, ConsoleData>();
		}

		[CompilerGenerated]
		internal static int getHash(int i, string s, ref data data)
		{
			return (int)MaybeHashCalc.toHash(data.ver + "_" + i + (string.IsNullOrEmpty(s) ? null : ("_" + s)) + "_" + data.i);
		}

		[CIntA(Num = 3uL)]
		internal static StrSth MakeDemoRequest(VerFormat ver, int i1, int[] iArr, string s, int i2)
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

		/// <summary>
		/// Gom nhiều classID trong một lượt. Cả mảng dùng chung một cây nên chỉ tra
		/// typetreedb đúng MỘT lần, thay vì mỗi classID một lần quét toàn bộ DB.
		/// </summary>
		internal static StrSth ReqIsNonEmptyArr(VerFormat ver, int i1, int[] iArr, int i2 = 0)
		{
			if (iArr == null || iArr.Length == 0)
			{
				return null;
			}
			StrSth source = UnityTypeTreeDb.LoadNearest(ver);
			if (source == null)
			{
				return null;
			}
			StrSth result = new StrSth(0);
			int num = 0;
			int[] array = iArr;
			foreach (int classId in array)
			{
				ConsoleData consoleData = source.FindByInt(classId);
				if (consoleData != null)
				{
					result.AddData(consoleData, num++);
				}
			}
			return (num == 0) ? null : result;
		}

		/// <summary>
		/// Tra theo tên type (MonoBehaviour...). Trả nguyên cây để phía gọi tự
		/// FindByStr — đúng hợp đồng cũ: bản cũ với bool2 == true cũng trả cây đầu
		/// tiên khớp version mà không kiểm tra nó có chứa "s" hay không.
		/// </summary>
		internal static StrSth ReqIsEmptyArr(VerFormat ver, int i1, string s, int i2 = 0)
		{
			return UnityTypeTreeDb.LoadNearest(ver);
		}
	}
}
