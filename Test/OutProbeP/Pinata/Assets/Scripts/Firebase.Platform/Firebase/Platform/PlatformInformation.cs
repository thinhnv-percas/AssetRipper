using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Firebase.Platform
{
	[Token(Token = "0x2000009")]
	public static class PlatformInformation
	{
		[Token(Token = "0x4000018")]
		private static string runtimeVersion;

		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x72B3C0", Offset = "0x72B3C0")]
		[CompilerGenerated]
		[Token(Token = "0x4000019")]
		internal static float _003CRealtimeSinceStartupSafe_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x400001A")]
		private static Func<string> _003C_003Ef__am_0024cache0;

		[CompilerGenerated]
		[Token(Token = "0x400001B")]
		private static Func<string> _003C_003Ef__am_0024cache1;

		[Token(Token = "0x1700000D")]
		public static bool IsAndroid
		{
			[Token(Token = "0x600003E")]
			[Address(RVA = "0x15E87D0", Offset = "0x15E87D0", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = UnityEngine.Application::get_platform();\n\tv10 = v7 - 0xB;\n\tv12 = v10 == 0;\n\treturn v12;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				RuntimePlatform platform = Application.platform;
				int num = (int)(platform - 11);
				return num == 0;
			}
		}

		[Token(Token = "0x1700000E")]
		public static bool IsIOS
		{
			[Token(Token = "0x600003F")]
			[Address(RVA = "0x15E87F0", Offset = "0x15E87F0", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = UnityEngine.Application::get_platform();\n\tv10 = v7 - 8;\n\tv12 = v10 == 0;\n\treturn v12;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				RuntimePlatform platform = Application.platform;
				int num = (int)(platform - 8);
				return num == 0;
			}
		}

		[Token(Token = "0x1700000F")]
		public static string DefaultConfigLocation
		{
			[Token(Token = "0x6000040")]
			[Address(RVA = "0x15E8810", Offset = "0x15E8810", Length = "0xCC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv16 = *([1EC6418]);\n\tv17 = *([v16 @ X8_v17]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2029F80]) = v37;\nL_0017:\n\tv43 = v41.<>f__am$cache0 == 0;\n\tv44 = ~v43;\n\tif (v44) goto L_0032;\n\tv48 = new System.Func`1<System.String>();\n\tSystem.Func`1<System.String>::.ctor(v48, 0, Il2CppMethodInfo);\n\tv56.<>f__am$cache0 = v48;\nL_0032:\n\tgoto L_0041;\n\tv73 = *([v65 @ X0_v3+E0]);\n\tv74 = v73 == 0;\n\tv75 = ~v74;\n\tgoto L_0041;\n\tv77 = \"il2cpp_codegen_runtime_class_init\"(v65, v53, v51, v49, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0041:\n\treturnVal1 = Firebase.Platform.FirebaseHandler::RunOnMainThread(v58.<>f__am$cache0);\n\treturn returnVal1;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (_003C_003Ef__am_0024cache0 == null)
				{
					Func<string> func = [Token(Token = "0x6000045")] [Address(RVA = "0x15E8A70", Offset = "0x15E8A70", Length = "0x8")] [NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.Application::get_streamingAssetsPath();\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")] () => Application.streamingAssetsPath;
					_003C_003Ef__am_0024cache0 = func;
				}
				return FirebaseHandler.RunOnMainThread(_003C_003Ef__am_0024cache0);
			}
		}

		[Token(Token = "0x17000010")]
		internal static float RealtimeSinceStartup
		{
			[Token(Token = "0x6000041")]
			[Address(RVA = "0x15E852C", Offset = "0x15E852C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.Time::get_realtimeSinceStartup();\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Time.realtimeSinceStartup;
			}
		}

		[Token(Token = "0x17000011")]
		internal static float RealtimeSinceStartupSafe
		{
			[CompilerGenerated]
			[Token(Token = "0x6000042")]
			[Address(RVA = "0x15E88DC", Offset = "0x15E88DC", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1ED54D8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, value, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([2029F81]) = v38;\nL_0017:\n\tv42.<RealtimeSinceStartupSafe>k__BackingField = value;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_003CRealtimeSinceStartupSafe_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000012")]
		public static string RuntimeName
		{
			[Token(Token = "0x6000043")]
			[Address(RVA = "0x15E8938", Offset = "0x15E8938", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1EB7AC0]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029F82]) = v35;\nL_0018:\n\treturn \"unity\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return "unity";
			}
		}

		[Token(Token = "0x17000013")]
		public static string RuntimeVersion
		{
			[Token(Token = "0x6000044")]
			[Address(RVA = "0x15E8980", Offset = "0x15E8980", Length = "0xF0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv16 = *([1EF4058]);\n\tv17 = *([v16 @ X8_v22]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2029F83]) = v37;\nL_0016:\n\treturnVal1 = v41.runtimeVersion;\n\tv43 = v41.runtimeVersion == 0;\n\tv44 = ~v43;\n\tif (v44) goto L_004C;\n\tv46 = v41.<>f__am$cache1 == 0;\n\tv47 = ~v46;\n\tif (v47) goto L_0036;\n\tv72 = new System.Func`1<System.String>();\n\tSystem.Func`1<System.String>::.ctor(v72, 0, Il2CppMethodInfo);\n\tv78.<>f__am$cache1 = v72;\nL_0036:\n\tgoto L_0040;\n\tv93 = *([v86 @ X0_v5+E0]);\n\tv94 = v93 == 0;\n\tv95 = ~v94;\n\tgoto L_0040;\n\tv97 = \"il2cpp_codegen_runtime_class_init\"(v86, v75, v51, v49, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0040:\n\tv102 = Firebase.Platform.FirebaseHandler::RunOnMainThread(v80.<>f__am$cache1);\n\tv105.runtimeVersion = v102;\n\treturnVal1 = v62.runtimeVersion;\nL_004C:\n\treturn returnVal1;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				string result = runtimeVersion;
				if (runtimeVersion == null)
				{
					if (_003C_003Ef__am_0024cache1 == null)
					{
						Func<string> func = [Token(Token = "0x6000046")] [Address(RVA = "0x15E8A78", Offset = "0x15E8A78", Length = "0x8")] [NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.Application::get_unityVersion();\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")] () => Application.unityVersion;
						_003C_003Ef__am_0024cache1 = func;
					}
					string text = FirebaseHandler.RunOnMainThread(_003C_003Ef__am_0024cache1);
					runtimeVersion = text;
					result = runtimeVersion;
				}
				return result;
			}
		}
	}
}
