using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.UDP.Analytics
{
	[Token(Token = "0x2000025")]
	internal class PlatformWrapper
	{
		[Token(Token = "0x60000B6")]
		[Address(RVA = "0x15C60B0", Offset = "0x15C60B0", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = &v7 @ stack_-10_v2;\n\tgoto L_0013;\n\tv14 = *([1ECB3E0]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20299A2]) = v35;\nL_0013:\n\t*([v6 @ X29_v1-8]) = 0;\n\tgoto L_0020;\n\tv43 = *([v39 @ X0_v2+E0]);\n\tv44 = v43 == 0;\n\tv45 = ~v44;\n\tgoto L_0020;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v39, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0020:\n\tv51 = System.DateTime::get_UtcNow();\n\t*([v6 @ X29_v1-8]) = v51;\n\tv53 = 0;\n\tv51 = 0xE93738(&v53 @ stack_-30_v1, 0x7B2, 1, 1, 0, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv51 = &v7 @ stack_-10_v2 - 8;\n\tv51 = 0xE95DA0(v51, 0, 0, 1, 0, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv51 = 0x9B7F4C(&v51 @ X0_v5 (System.DateTime), 0, 0, 1, 0, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\treturn v24;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ulong GetCurrentMillisecondsInUTC()
		{
			//IL_0024: Expected O, but got I4
			//IL_0047: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			_ = 0;
			DateTime utcNow = DateTime.UtcNow;
			object obj3 = 0;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @E93738 (inside System.DBNull::.cctor +0x360)");
			utcNow = (DateTime)((long)(IntPtr)obj2 - 8L);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @E95DA0 (inside System.DateTime::ParseExact +0xD8)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9B7F4C (inside System.Threading.ThreadPool::RegisterWaitForSingleObject +0x134)");
			ulong result = default(ulong);
			return result;
		}

		[Token(Token = "0x60000B7")]
		[Address(RVA = "0x15C56C0", Offset = "0x15C56C0", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv14 = *([1EF1CA0]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20299A3]) = v35;\nL_0012:\n\tv37 = UnityEngine.Application::get_platform();\n\tv53 = v37 != 0xB;\n\tif (v53) goto L_FFFFFFFF;\n\tgoto L_002B;\nL_002B:\n\treturn *([v56 @ X8_v5 (System.String)]);\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string GetRuntimePlatformString()
		{
			RuntimePlatform platform = Application.platform;
			if (platform == RuntimePlatform.Android)
			{
				return "Android";
			}
			return "";
		}

		[Token(Token = "0x60000B8")]
		[Address(RVA = "0x15C5720", Offset = "0x15C5720", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.SystemInfo::get_deviceModel();\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string GetSystemInfo()
		{
			return SystemInfo.deviceModel;
		}

		[Token(Token = "0x60000B9")]
		[Address(RVA = "0x15C6168", Offset = "0x15C6168", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1EAF080]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20299A4]) = v38;\nL_001D:\n\treturnVal1 = UnityEngine.PlayerPrefs::GetString(name, \"\");\n\treturn returnVal1;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string GetPlayerPrefsString(string name)
		{
			return PlayerPrefs.GetString(name, "");
		}

		[Token(Token = "0x60000BA")]
		[Address(RVA = "0x15C625C", Offset = "0x15C625C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.PlayerPrefs::SetString(name, value);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetPlayerPrefsString(string name, string value)
		{
			PlayerPrefs.SetString(name, value);
		}

		[Token(Token = "0x60000BB")]
		[Address(RVA = "0x15C61BC", Offset = "0x15C61BC", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = UnityEngine.PlayerPrefs::GetInt(name, 0);\n\treturn v8;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ulong GetPlayerPrefsUInt64(string name)
		{
			//IL_0017: Expected I8, but got I4
			int num = PlayerPrefs.GetInt(name, 0);
			return (ulong)num;
		}

		[Token(Token = "0x60000BC")]
		[Address(RVA = "0x15C6264", Offset = "0x15C6264", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.PlayerPrefs::SetInt(name, value);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetPlayerPrefsUInt64(string name, ulong value)
		{
			//IL_000d: Expected I4, but got I8
			PlayerPrefs.SetInt(name, (int)value);
		}

		[Token(Token = "0x60000BD")]
		[Address(RVA = "0x15C4F7C", Offset = "0x15C4F7C", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = *([1F0C800]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20299A5]) = v35;\nL_0016:\n\tv41 = UnityEngine.PlayerPrefs::GetInt(\"udp.app_install\", 0);\n\tv48 = v41 == 0;\n\tv53 = ~v48;\n\treturn v53;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool GetAppInstalled()
		{
			int num = PlayerPrefs.GetInt("udp.app_install", 0);
			bool flag = num == 0;
			return !flag;
		}

		[Token(Token = "0x60000BE")]
		[Address(RVA = "0x15C5B94", Offset = "0x15C5B94", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1EDADD0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20299A6]) = v38;\nL_001D:\n\tUnityEngine.PlayerPrefs::SetInt(\"udp.app_install\", v);\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetAppInstalled(bool v)
		{
			PlayerPrefs.SetInt("udp.app_install", v ? 1 : 0);
		}

		[Token(Token = "0x60000BF")]
		[Address(RVA = "0x15C61DC", Offset = "0x15C61DC", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv14 = *([1ED3FC8]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20299A7]) = v35;\nL_0019:\n\tgoto L_0020;\n\tv44 = *([v40 @ X0_v2+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_0020;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v40, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0020:\n\tv52 = System.Guid::NewGuid();\n\treturnVal1 = 0xC12510(&v52 @ X0_v5 (System.Guid), 0, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string GenerateRandomId()
		{
			Guid guid = Guid.NewGuid();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @C12510 (inside System.Guid::StringToLong +0x320)");
			string result = default(string);
			return result;
		}
	}
}
