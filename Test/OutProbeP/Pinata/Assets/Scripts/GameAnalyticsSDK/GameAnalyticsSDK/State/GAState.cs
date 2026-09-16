using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using GameAnalyticsSDK.Setup;
using UnityEngine;

namespace GameAnalyticsSDK.State
{
	[Token(Token = "0x200000C")]
	internal static class GAState
	{
		[Token(Token = "0x4000034")]
		private static Settings _settings;

		[Token(Token = "0x600008B")]
		[Address(RVA = "0x15A2C9C", Offset = "0x15A2C9C", Length = "0x1C4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv16 = *([1EE1818]);\n\tv17 = *([v16 @ X8_v29]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2029822]) = v37;\nL_001B:\n\tgoto L_0023;\n\tv47 = *([v40 @ X0_v2+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0023;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0023:\n\tv56 = System.Type::GetTypeFromHandle(GameAnalyticsSDK.Setup.Settings);\n\tv62 = UnityEngine.Resources::Load(\"GameAnalytics/Settings\", v56);\n\tv67 = v62 == 0;\n\tif (v67) goto L_0050;\n\tgoto L_FFFFFFFF;\n\tv88 = v88_asT == 0;\n\tif (v88) goto L_0057;\nL_0050:\n\tv66._settings = v62;\n\treturn;\nL_0057:\n\tv139 = new System.InvalidCastException();\n\tgoto L_0064;\n\tgoto L_0064;\nL_0064:\n\tv147 = GameAnalyticsSDK.Setup.Settings != 1;\n\tif (v147) goto L_00A5;\n\tv191 = 0x6D2BC0(v139, GameAnalyticsSDK.Setup.Settings, 0, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv203 = *([v191 @ X0_v14]);\n\tv173 = *([v203 @ X19_v6]);\n\tv207 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v203 @ X19_v6]), 0, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv208 = v207 & 1;\n\tv209 = v208 == 0;\n\tif (v209) goto L_0099;\n\tv210 = 0x6D2490(v207, v173, 0, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv213 = v203 == 0;\n\tif (v213) goto L_00A1;\n\tv219 = *([v203 @ X19_v6]);\n\t*([v219 @ X8_v19+160])(v223, v203, *([v219 @ X8_v19+168]), 0, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv229 = System.String::Concat(\"Could not get Settings during event validation \\n\", v223);\n\tgoto L_0096;\n\tv239 = *([v181 @ X8_v25+E0]);\n\tv240 = v239 == 0;\n\tv241 = ~v240;\n\tif (v241) goto L_0096;\n\tv244 = v181;\n\tv243 = \"il2cpp_codegen_runtime_class_init\"(v244, v226, v169, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0096:\n\tUnityEngine.Debug::Log(v229);\n\treturn;\nL_0099:\n\tv212 = 0x6D1E60(8, *([v203 @ X19_v6]), 0, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\t*([v212 @ X0_v22]) = *([v191 @ X0_v14]);\n\tv173 = 0x1E8A000 + 0x870;\n\tv218 = 0x6D2A00(v212, v173, 0, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_00A1:\n\tv232 = new System.NullReferenceException();\n\tv196 = 0x6D2490(v232, v173, v170, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_00A5:\n\tv201 = 0x6D2380(v185, v173, v170, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv176 = 0x846AA4(v201, v173, v170, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\treturn;\n// 111 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Init()
		{
			//IL_00af: Expected O, but got I4
			//IL_00bd: Expected I, but got O
			//IL_00f2: Expected I, but got O
			//IL_01d8: Expected O, but got I4
			//IL_0159: Expected O, but got I4
			Type typeFromHandle = typeof(Settings);
			UnityEngine.Object obj = Resources.Load("GameAnalytics/Settings", typeFromHandle);
			if ((object)obj != null)
			{
				Settings settings = obj as Settings;
				if ((object)settings == null)
				{
					InvalidCastException ex = new InvalidCastException();
					bool flag = (IntPtr)typeof(Settings) != (IntPtr)1;
					object obj2 = 0;
					IntPtr intPtr = (IntPtr)typeof(Settings);
					InvalidCastException ex2 = ex;
					if (!flag)
					{
						Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
						object obj4 = default(object);
						object obj3 = obj4;
						intPtr = (IntPtr)obj3;
						Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
						object obj5 = default(object);
						if ((uint)((ulong)(long)(IntPtr)obj5 & 1uL) != 0)
						{
							Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
							bool flag2 = obj3 == null;
							obj2 = 0;
							if (!flag2)
							{
								object obj6 = obj3;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v219 @ X8_v19+160] (should have been resolved before IL gen)");
								string text = default(string);
								string message = "Could not get Settings during event validation \n" + text;
								Debug.Log(message);
								return;
							}
						}
						else
						{
							Il2CppRuntime.Boundary("SYSTEM_API:__cxa_allocate_exception", "Method not found @6D1E60 (native __cxa_allocate_exception)");
							object obj7 = obj4;
							intPtr = (IntPtr)(32022528 + 2160);
							Il2CppRuntime.Boundary("SYSTEM_API:__cxa_throw", "Method not found @6D2A00 (native __cxa_throw)");
							obj2 = 0;
						}
						NullReferenceException ex3 = new NullReferenceException();
						Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
						ex2 = (InvalidCastException)(object)ex3;
					}
					Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
					return;
				}
			}
			_settings = (Settings)obj;
		}

		[Token(Token = "0x600008C")]
		[Address(RVA = "0x15A63BC", Offset = "0x15A63BC", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv22 = *([1EAB1A0]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, _string, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2029823]) = v41;\nL_0022:\n\treturnVal1 = System.Collections.Generic.List`1<System.String>::Contains(_list, _string);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static bool ListContainsString(List<string> _list, string _string)
		{
			return _list.Contains(_string);
		}

		[Token(Token = "0x600008D")]
		[Address(RVA = "0x15A6428", Offset = "0x15A6428", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = *([1EDC948]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029824]) = v35;\nL_0015:\n\tv40 = v39._settings;\n\treturn v40.UseManualSessionHandling;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsManualSessionHandlingEnabled()
		{
			Settings settings = _settings;
			return settings.UseManualSessionHandling;
		}

		[Token(Token = "0x600008E")]
		[Address(RVA = "0x15A6488", Offset = "0x15A6488", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EC08C0]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029825]) = v38;\nL_0017:\n\tv43 = v42._settings;\n\treturnVal1 = GameAnalyticsSDK.State.GAState::ListContainsString(v43.ResourceCurrencies, _currency);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool HasAvailableResourceCurrency(string _currency)
		{
			Settings settings = _settings;
			return ListContainsString(settings.ResourceCurrencies, _currency);
		}

		[Token(Token = "0x600008F")]
		[Address(RVA = "0x15A64F0", Offset = "0x15A64F0", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EF6A30]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029826]) = v38;\nL_0017:\n\tv43 = v42._settings;\n\treturnVal1 = GameAnalyticsSDK.State.GAState::ListContainsString(v43.ResourceItemTypes, _itemType);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool HasAvailableResourceItemType(string _itemType)
		{
			Settings settings = _settings;
			return ListContainsString(settings.ResourceItemTypes, _itemType);
		}

		[Token(Token = "0x6000090")]
		[Address(RVA = "0x15A6558", Offset = "0x15A6558", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EB38F0]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029827]) = v38;\nL_0017:\n\tv43 = v42._settings;\n\treturnVal1 = GameAnalyticsSDK.State.GAState::ListContainsString(v43.CustomDimensions01, _dimension01);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool HasAvailableCustomDimensions01(string _dimension01)
		{
			Settings settings = _settings;
			return ListContainsString(settings.CustomDimensions01, _dimension01);
		}

		[Token(Token = "0x6000091")]
		[Address(RVA = "0x15A65C0", Offset = "0x15A65C0", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EFB488]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029828]) = v38;\nL_0017:\n\tv43 = v42._settings;\n\treturnVal1 = GameAnalyticsSDK.State.GAState::ListContainsString(v43.CustomDimensions02, _dimension02);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool HasAvailableCustomDimensions02(string _dimension02)
		{
			Settings settings = _settings;
			return ListContainsString(settings.CustomDimensions02, _dimension02);
		}

		[Token(Token = "0x6000092")]
		[Address(RVA = "0x15A6628", Offset = "0x15A6628", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EE0F08]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029829]) = v38;\nL_0017:\n\tv43 = v42._settings;\n\treturnVal1 = GameAnalyticsSDK.State.GAState::ListContainsString(v43.CustomDimensions03, _dimension03);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool HasAvailableCustomDimensions03(string _dimension03)
		{
			Settings settings = _settings;
			return ListContainsString(settings.CustomDimensions03, _dimension03);
		}
	}
}
