using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace LunarConsolePluginInternal
{
	[Token(Token = "0x200001E")]
	public static class LunarConsoleConfig
	{
		[Token(Token = "0x400005B")]
		public static readonly bool consoleEnabled;

		[Token(Token = "0x400005C")]
		public static readonly bool consoleSupported;

		[Token(Token = "0x400005D")]
		public static readonly bool freeVersion;

		[Token(Token = "0x400005E")]
		public static readonly bool fullVersion;

		[Token(Token = "0x17000020")]
		public static bool actionsEnabled
		{
			[Token(Token = "0x60000BE")]
			[Address(RVA = "0x13E1B70", Offset = "0x13E1B70", Length = "0xA8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EB9798]);\n\tv15 = *([v14 @ X8_v14]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2028AE1]) = v35;\nL_0017:\n\tgoto L_0020;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<LunarConsolePluginInternal.LunarConsoleConfig>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0020;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = LunarConsolePluginInternal.LunarConsoleConfig;\nL_0020:\n\tv51 = ~v49.consoleSupported;\n\tif (v51) goto L_FFFFFFFF;\n\tgoto L_002E;\n\tv65 = *([v45 @ X0_v3 (Il2CppClass<LunarConsolePluginInternal.LunarConsoleConfig>)+E0]);\n\tv66 = v65 == 0;\n\tv67 = ~v66;\n\tif (v67) goto L_002E;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v45, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv106 = LunarConsolePluginInternal.LunarConsoleConfig;\n\tv71 = *([v106 @ X8_v10+B8]);\nL_002E:\n\tv61 = ~v70.consoleEnabled;\n\tif (v61) goto L_FFFFFFFF;\n\tv105 = UnityEngine.Application::get_platform();\n\tv92 = v105 - 0xB;\n\tv86 = v92 == 0;\n\tgoto L_0042;\nL_0042:\n\treturn returnVal1;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (consoleSupported && consoleEnabled)
				{
					RuntimePlatform platform = Application.platform;
					int num = (int)(platform - 11);
					return num == 0;
				}
				return false;
			}
		}

		[Token(Token = "0x60000BD")]
		[Address(RVA = "0x13E2978", Offset = "0x13E2978", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = *([1EC1560]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2028AE0]) = v35;\nL_0016:\n\tv40.consoleEnabled = 1;\n\tv42.consoleSupported = 1;\n\tv44.freeVersion = 0;\n\tv46.fullVersion = 1;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static LunarConsoleConfig()
		{
			consoleEnabled = true;
			consoleSupported = true;
			freeVersion = false;
			fullVersion = true;
		}
	}
}
