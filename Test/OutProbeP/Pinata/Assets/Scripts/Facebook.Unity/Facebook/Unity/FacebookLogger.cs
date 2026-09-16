using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Facebook.Unity
{
	[Token(Token = "0x2000038")]
	internal static class FacebookLogger
	{
		[Token(Token = "0x2000039")]
		private class DebugLogger : IFacebookLogger
		{
			[Token(Token = "0x6000140")]
			[Address(RVA = "0xD2E128", Offset = "0xD2E128", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public DebugLogger()
			{
			}

			[Token(Token = "0x6000141")]
			[Address(RVA = "0xD2E28C", Offset = "0xD2E28C", Length = "0x98")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ED1720]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, msg, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([2023C2B]) = v38;\nL_0019:\n\tgoto L_0020;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0020;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, msg, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0020:\n\tv53 = UnityEngine.Debug::get_isDebugBuild();\n\tv55 = v53 == 0;\n\tif (v55) goto L_003C;\n\tgoto L_0035;\n\tv64 = *([v56 @ X0_v6+E0]);\n\tv65 = v64 == 0;\n\tv66 = ~v65;\n\tif (v66) goto L_0035;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v56, msg, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0035:\n\tUnityEngine.Debug::Log(msg);\n\treturn;\nL_003C:\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public void Log(string msg)
			{
				if (Debug.isDebugBuild)
				{
					Debug.Log(msg);
				}
			}

			[Token(Token = "0x6000142")]
			[Address(RVA = "0xD2E324", Offset = "0xD2E324", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EEC320]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, msg, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([2023C2C]) = v38;\nL_0019:\n\tgoto L_0026;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0026;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, msg, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0026:\n\tUnityEngine.Debug::Log(msg);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public void Info(string msg)
			{
				Debug.Log(msg);
			}

			[Token(Token = "0x6000143")]
			[Address(RVA = "0xD2E38C", Offset = "0xD2E38C", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EDC070]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, msg, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([2023C2D]) = v38;\nL_0019:\n\tgoto L_0026;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0026;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, msg, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0026:\n\tUnityEngine.Debug::LogWarning(msg);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public void Warn(string msg)
			{
				Debug.LogWarning(msg);
			}
		}

		[Token(Token = "0x17000051")]
		[field: Token(Token = "0x400006B")]
		internal static IFacebookLogger Instance
		{
			[Token(Token = "0x600013A")]
			[Address(RVA = "0xD2E130", Offset = "0xD2E130", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EC3570]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023C25]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Facebook.Unity.FacebookLogger>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = Facebook.Unity.FacebookLogger;\nL_0024:\n\treturn v49.<Instance>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private get;
			[Token(Token = "0x600013B")]
			[Address(RVA = "0xD2E198", Offset = "0xD2E198", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EEE5F8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023C26]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<Facebook.Unity.FacebookLogger>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = Facebook.Unity.FacebookLogger;\nL_0021:\n\tv52.<Instance>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set;
		}

		[Token(Token = "0x6000139")]
		[Address(RVA = "0xD2E080", Offset = "0xD2E080", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1EB6F08]);\n\tv17 = *([v16 @ X8_v15]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2023C24]) = v37;\nL_0015:\n\tv41 = new Facebook.Unity.FacebookLogger+DebugLogger();\n\tSystem.Object::.ctor(v41);\n\tgoto L_002A;\n\tv49 = *([1ECB208]);\n\tv50 = *([v49 @ X8_v12]);\n\tv51 = \"il2cpp_codegen_initialize_method\"(v50, v42, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv54 = 0 | 1;\n\t*([2023CB1]) = v54;\nL_002A:\n\tgoto L_0032;\n\tv61 = *([v57 @ X0_v5 (Il2CppClass<Facebook.Unity.FacebookLogger>)+E0]);\n\tv62 = v61 == 0;\n\tv63 = ~v62;\n\tgoto L_0032;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v57, v42, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv65 = Facebook.Unity.FacebookLogger;\nL_0032:\n\tv68.<Instance>k__BackingField = v41;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static FacebookLogger()
		{
			DebugLogger debugLogger = new DebugLogger();
			Instance = debugLogger;
		}

		[Token(Token = "0x600013C")]
		[Address(RVA = "0xD24038", Offset = "0xD24038", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EDB278]);\n\tv21 = *([v20 @ X8_v20]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023C27]) = v40;\nL_001A:\n\tgoto L_0024;\n\tv47 = *([v43 @ X0_v2+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0024;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\tgoto L_002F;\n\tv59 = *([1EB1CE8]);\n\tv60 = *([v59 @ X8_v16]);\n\tv61 = \"il2cpp_codegen_initialize_method\"(v60, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv64 = 0 | 1;\n\t*([2023CB2]) = v64;\nL_002F:\n\tgoto L_0040;\n\tv69 = *([v65 @ X0_v5 (Il2CppClass<Facebook.Unity.FacebookLogger>)+E0]);\n\tv70 = v69 == 0;\n\tv71 = ~v70;\n\t// 51 Jump @b23\n\tv79 = \"il2cpp_codegen_runtime_class_init\"(v65, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv73 = Facebook.Unity.FacebookLogger;\nL_0040:\n\tgoto L_006E;\n\tv88 = *([v81 @ X8_v10+B0]);\n\tv89 = 0;\n\tv90 = v88 + 8;\n\tv92 = *([v139 @ X11_v5-8]);\n\tv145 = v92 == v84;\n\tif (v145) goto L_0060;\n\tv125 = v140 + 1;\n\tv202 = v125 < v83;\n\tv119 = ~v202;\n\tv122 = v139 + 0x10;\n\tv95 = ~v119;\n\tif (v95) goto L_FFFFFFFF;\n\tv126 = v77;\n\tv127 = 0;\n\tv128 = 0x8909C4(v126, v84, v127, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_006E;\nL_0060:\n\tv203 = *([v139 @ X11_v5]);\n\tv204 = v203 << 4;\n\tv205 = v81 + v204;\n\tv206 = v205 + 0x130;\nL_006E:\n\tFacebook.Unity.IFacebookLogger::Log(v76.<Instance>k__BackingField, msg);\n\tthrow System.NullReferenceException;\n\treturn;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Log(string msg)
		{
			Instance.Log(msg);
		}

		[Token(Token = "0x600013D")]
		[Address(RVA = "0xD2AC30", Offset = "0xD2AC30", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EF3FD8]);\n\tv21 = *([v20 @ X8_v20]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023C28]) = v40;\nL_001A:\n\tgoto L_0024;\n\tv47 = *([v43 @ X0_v2+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0024;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\tgoto L_002F;\n\tv59 = *([1EB1CE8]);\n\tv60 = *([v59 @ X8_v16]);\n\tv61 = \"il2cpp_codegen_initialize_method\"(v60, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv64 = 0 | 1;\n\t*([2023CB2]) = v64;\nL_002F:\n\tgoto L_0037;\n\tv69 = *([v65 @ X0_v5 (Il2CppClass<Facebook.Unity.FacebookLogger>)+E0]);\n\tv70 = v69 == 0;\n\tv71 = ~v70;\n\tgoto L_0037;\n\tv79 = \"il2cpp_codegen_runtime_class_init\"(v65, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv73 = Facebook.Unity.FacebookLogger;\nL_0037:\n\tv77 = v76.<Instance>k__BackingField;\n\tv81 = *([v77 @ X20_v4 (Facebook.Unity.IFacebookLogger)]);\n\tv85 = *([v81 @ X8_v10 (Il2CppClass<Facebook.Unity.IFacebookLogger>)+126]) == 0;\n\tif (v85) goto L_005E;\n\tv139 = *([v81 @ X8_v10 (Il2CppClass<Facebook.Unity.IFacebookLogger>)+B0]) + 8;\nL_0049:\n\tv145 = *([v139 @ X11_v5-8]) == Facebook.Unity.IFacebookLogger;\n\tif (v145) goto L_0061;\n\tv140 = v140 + 1;\n\tv202 = v140 < *([v81 @ X8_v10 (Il2CppClass<Facebook.Unity.IFacebookLogger>)+126]);\n\tv119 = ~v202;\n\tv139 = v139 + 0x10;\n\tv95 = ~v119;\n\tif (v95) goto L_0049;\nL_005E:\n\tv209 = 0x8909C4(v77, Facebook.Unity.IFacebookLogger, 1, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_0065;\nL_0061:\n\tv204 = *([v139 @ X11_v5]) + 1;\n\tv205 = v204 << 4;\n\tv206 = v81 + v205;\n\tv209 = v206 + 0x130;\nL_0065:\n\tv153 = *([v209 @ X0_v9]);\n\tv160 = *([v209 @ X0_v9+8]);\n\t// 111 IndirectJump v153 @ X3_v1, v77 @ X20_v4 (Facebook.Unity.IFacebookLogger), v77 @ X20_v4 (Facebook.Unity.IFacebookLogger), msg @ X0 (System.String), v160 @ X2_v2, v153 @ X3_v1, v26 @ X4, v27 @ X5, v28 @ X6, v29 @ X7, v30 @ V0, v31 @ V1, v32 @ V2, v33 @ V3, v34 @ V4, v35 @ V5, v36 @ V6, v37 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Info(string msg)
		{
			//IL_0012: Expected I, but got O
			//IL_015f: Expected O, but got I
			//IL_004d: Expected O, but got I
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d4: Expected O, but got Unknown
			//IL_00f1: Expected O, but got I
			//IL_0100: Expected O, but got I
			//IL_0099: Expected O, but got I
			IFacebookLogger facebookLogger = Instance;
			IntPtr intPtr = (IntPtr)facebookLogger;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ X8_v10 (Il2CppClass<Facebook.Unity.IFacebookLogger>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00b2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ X8_v10 (Il2CppClass<Facebook.Unity.IFacebookLogger>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IFacebookLogger))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ X8_v10 (Il2CppClass<Facebook.Unity.IFacebookLogger>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00b2;
			}
			object obj2 = obj + 1;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0147;
			IL_00b2:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_0147;
			IL_0147:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ X0_v9+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v153 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x600013E")]
		[Address(RVA = "0xD1E184", Offset = "0xD1E184", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1ECD7F0]);\n\tv21 = *([v20 @ X8_v20]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023C29]) = v40;\nL_001A:\n\tgoto L_0024;\n\tv47 = *([v43 @ X0_v2+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0024;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\tgoto L_002F;\n\tv59 = *([1EB1CE8]);\n\tv60 = *([v59 @ X8_v16]);\n\tv61 = \"il2cpp_codegen_initialize_method\"(v60, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv64 = 0 | 1;\n\t*([2023CB2]) = v64;\nL_002F:\n\tgoto L_0037;\n\tv69 = *([v65 @ X0_v5 (Il2CppClass<Facebook.Unity.FacebookLogger>)+E0]);\n\tv70 = v69 == 0;\n\tv71 = ~v70;\n\tgoto L_0037;\n\tv79 = \"il2cpp_codegen_runtime_class_init\"(v65, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv73 = Facebook.Unity.FacebookLogger;\nL_0037:\n\tv77 = v76.<Instance>k__BackingField;\n\tv81 = *([v77 @ X20_v4 (Facebook.Unity.IFacebookLogger)]);\n\tv85 = *([v81 @ X8_v10 (Il2CppClass<Facebook.Unity.IFacebookLogger>)+126]) == 0;\n\tif (v85) goto L_005E;\n\tv139 = *([v81 @ X8_v10 (Il2CppClass<Facebook.Unity.IFacebookLogger>)+B0]) + 8;\nL_0049:\n\tv145 = *([v139 @ X11_v5-8]) == Facebook.Unity.IFacebookLogger;\n\tif (v145) goto L_0061;\n\tv140 = v140 + 1;\n\tv202 = v140 < *([v81 @ X8_v10 (Il2CppClass<Facebook.Unity.IFacebookLogger>)+126]);\n\tv119 = ~v202;\n\tv139 = v139 + 0x10;\n\tv95 = ~v119;\n\tif (v95) goto L_0049;\nL_005E:\n\tv209 = 0x8909C4(v77, Facebook.Unity.IFacebookLogger, 2, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_0065;\nL_0061:\n\tv204 = *([v139 @ X11_v5]) + 2;\n\tv205 = v204 << 4;\n\tv206 = v81 + v205;\n\tv209 = v206 + 0x130;\nL_0065:\n\tv153 = *([v209 @ X0_v9]);\n\tv160 = *([v209 @ X0_v9+8]);\n\t// 111 IndirectJump v153 @ X3_v1, v77 @ X20_v4 (Facebook.Unity.IFacebookLogger), v77 @ X20_v4 (Facebook.Unity.IFacebookLogger), msg @ X0 (System.String), v160 @ X2_v2, v153 @ X3_v1, v26 @ X4, v27 @ X5, v28 @ X6, v29 @ X7, v30 @ V0, v31 @ V1, v32 @ V2, v33 @ V3, v34 @ V4, v35 @ V5, v36 @ V6, v37 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Warn(string msg)
		{
			//IL_0012: Expected I, but got O
			//IL_015f: Expected O, but got I
			//IL_004d: Expected O, but got I
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d4: Expected O, but got Unknown
			//IL_00f1: Expected O, but got I
			//IL_0100: Expected O, but got I
			//IL_0099: Expected O, but got I
			IFacebookLogger facebookLogger = Instance;
			IntPtr intPtr = (IntPtr)facebookLogger;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ X8_v10 (Il2CppClass<Facebook.Unity.IFacebookLogger>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00b2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ X8_v10 (Il2CppClass<Facebook.Unity.IFacebookLogger>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IFacebookLogger))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ X8_v10 (Il2CppClass<Facebook.Unity.IFacebookLogger>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00b2;
			}
			object obj2 = obj + 2;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0147;
			IL_00b2:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_0147;
			IL_0147:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ X0_v9+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v153 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x600013F")]
		[Address(RVA = "0xD2E204", Offset = "0xD2E204", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1ED1400]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, args, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023C2A]) = v41;\nL_0018:\n\tv45 = System.String::Format(format, args);\n\tgoto L_002E;\n\tv53 = *([v49 @ X8_v5+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tgoto L_002E;\n\tv66 = v49;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v66, v43, v44, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002E:\n\tFacebook.Unity.FacebookLogger::Warn(v45);\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Warn(string format, params string[] args)
		{
			string msg = string.Format(format, args);
			Warn(msg);
		}
	}
}
