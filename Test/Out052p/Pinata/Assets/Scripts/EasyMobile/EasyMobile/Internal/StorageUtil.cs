using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile.Internal
{
	[Token(Token = "0x20000CB")]
	internal static class StorageUtil
	{
		[Token(Token = "0x600075F")]
		[Address(RVA = "0xB528B4", Offset = "0xB528B4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.PlayerPrefs::DeleteAll();\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void DeleteAll()
		{
			PlayerPrefs.DeleteAll();
		}

		[Token(Token = "0x6000760")]
		[Address(RVA = "0xB528BC", Offset = "0xB528BC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.PlayerPrefs::DeleteKey(key);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void DeleteKey(string key)
		{
			PlayerPrefs.DeleteKey(key);
		}

		[Token(Token = "0x6000761")]
		[Address(RVA = "0xB528C4", Offset = "0xB528C4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.PlayerPrefs::GetFloat(key, defaultValue);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float GetFloat(string key, float defaultValue)
		{
			return PlayerPrefs.GetFloat(key, defaultValue);
		}

		[Token(Token = "0x6000762")]
		[Address(RVA = "0xB528CC", Offset = "0xB528CC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.PlayerPrefs::GetInt(key, defaultValue);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int GetInt(string key, int defaultValue)
		{
			return PlayerPrefs.GetInt(key, defaultValue);
		}

		[Token(Token = "0x6000763")]
		[Address(RVA = "0xB528D4", Offset = "0xB528D4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.PlayerPrefs::GetString(key, defaultValue);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string GetString(string key, string defaultValue)
		{
			return PlayerPrefs.GetString(key, defaultValue);
		}

		[Token(Token = "0x6000764")]
		[Address(RVA = "0xB528DC", Offset = "0xB528DC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.PlayerPrefs::HasKey(key);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool HasKey(string key)
		{
			return PlayerPrefs.HasKey(key);
		}

		[Token(Token = "0x6000765")]
		[Address(RVA = "0xB528E4", Offset = "0xB528E4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.PlayerPrefs::Save();\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Save()
		{
			PlayerPrefs.Save();
		}

		[Token(Token = "0x6000766")]
		[Address(RVA = "0xB528EC", Offset = "0xB528EC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.PlayerPrefs::SetFloat(key, value);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetFloat(string key, float value)
		{
			PlayerPrefs.SetFloat(key, value);
		}

		[Token(Token = "0x6000767")]
		[Address(RVA = "0xB528F4", Offset = "0xB528F4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.PlayerPrefs::SetInt(key, value);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetInt(string key, int value)
		{
			PlayerPrefs.SetInt(key, value);
		}

		[Token(Token = "0x6000768")]
		[Address(RVA = "0xB528FC", Offset = "0xB528FC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.PlayerPrefs::SetString(key, value);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetString(string key, string value)
		{
			PlayerPrefs.SetString(key, value);
		}

		[Token(Token = "0x6000769")]
		[Address(RVA = "0xB52904", Offset = "0xB52904", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = &v7 @ stack_-10_v2;\n\t*([v6 @ X29_v1-8]) = time;\n\tv31 = &v7 @ stack_-10_v2 - 8;\n\tv31 = 0xE954FC(v31, 0, methodInfo, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27);\n\tv31 = 0xDC4024(&v31 @ X0_v4 (System.String), 0, methodInfo, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27);\n\tUnityEngine.PlayerPrefs::SetString(v31, v31);\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetTime(string ppkey, DateTime time)
		{
			//IL_001c: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			string text = (string)((long)(IntPtr)obj2 - 8L);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @E954FC (inside System.DateTime::SpecifyKind +0x34)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @DC4024 (inside System.Int32::TryParse +0x8C8)");
			PlayerPrefs.SetString(text, text);
		}

		[Token(Token = "0x600076A")]
		[Address(RVA = "0xB52958", Offset = "0xB52958", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1ECC2B8]);\n\tv23 = *([v22 @ X8_v17]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, defaultTime, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20227A0]) = v41;\nL_001C:\n\tv49 = UnityEngine.PlayerPrefs::GetString(ppkey, v47.Empty);\n\tv52 = System.String::IsNullOrEmpty(v49);\n\tv54 = v52 == 0;\n\tif (v54) goto L_0031;\n\treturn defaultTime;\nL_0031:\n\tgoto L_0039;\n\tv88 = *([v63 @ X0_v5+E0]);\n\tv89 = v88 == 0;\n\tv90 = ~v89;\n\tif (v90) goto L_0039;\n\tv92 = \"il2cpp_codegen_runtime_class_init\"(v63, v50, v45, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0039:\n\tv97 = System.Convert::ToInt64(v49);\n\tgoto L_0050;\n\tv104 = *([v83 @ X8_v13+E0]);\n\tv105 = v104 == 0;\n\tv106 = ~v105;\n\tif (v106) goto L_0050;\n\tv110 = v83;\n\tv108 = \"il2cpp_codegen_runtime_class_init\"(v110, v96, v45, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0050:\n\treturnVal2 = System.DateTime::FromBinary(v97);\n\treturn returnVal2;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static DateTime GetTime(string ppkey, DateTime defaultTime)
		{
			string value = PlayerPrefs.GetString(ppkey, string.Empty);
			if (string.IsNullOrEmpty(value))
			{
				return defaultTime;
			}
			long dateData = Convert.ToInt64(value);
			return DateTime.FromBinary(dateData);
		}
	}
}
