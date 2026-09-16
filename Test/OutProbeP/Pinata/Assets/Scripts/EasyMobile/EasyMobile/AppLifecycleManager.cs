using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using EasyMobile.Internal;
using UnityEngine;

namespace EasyMobile
{
	[Token(Token = "0x200000A")]
	public class AppLifecycleManager : MonoBehaviour
	{
		[Token(Token = "0x4000064")]
		private static IAppLifecycleHandler sAppLifecycleHandler;

		[Token(Token = "0x17000003")]
		[field: Token(Token = "0x4000063")]
		public static AppLifecycleManager Instance
		{
			[Token(Token = "0x600003F")]
			[Address(RVA = "0xA4DDF0", Offset = "0xA4DDF0", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EDD338]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021F33]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<EasyMobile.AppLifecycleManager>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = EasyMobile.AppLifecycleManager;\nL_0024:\n\treturn v49.<Instance>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x6000040")]
			[Address(RVA = "0xA4DE58", Offset = "0xA4DE58", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EB5EA0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021F34]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<EasyMobile.AppLifecycleManager>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = EasyMobile.AppLifecycleManager;\nL_0021:\n\tv52.<Instance>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x6000041")]
		[Address(RVA = "0xA4DEC4", Offset = "0xA4DEC4", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1ECB8B8]);\n\tv23 = *([v22 @ X8_v32]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021F35]) = v42;\nL_001B:\n\tgoto L_0025;\n\tv49 = *([v45 @ X0_v2+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0025;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0025:\n\tgoto L_0030;\n\tv61 = *([1ED26E8]);\n\tv62 = *([v61 @ X8_v28]);\n\tv63 = \"il2cpp_codegen_initialize_method\"(v62, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv66 = 0 | 1;\n\t*([2021FDD]) = v66;\nL_0030:\n\tgoto L_003F;\n\tv71 = *([v67 @ X0_v5 (Il2CppClass<EasyMobile.AppLifecycleManager>)+E0]);\n\tv72 = v71 == 0;\n\tv73 = ~v72;\n\tgoto L_003F;\n\tv86 = \"il2cpp_codegen_runtime_class_init\"(v67, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv75 = EasyMobile.AppLifecycleManager;\nL_003F:\n\tgoto L_0049;\n\tv87 = *([v81 @ X8_v9+E0]);\n\tv88 = v87 == 0;\n\tv89 = ~v88;\n\tgoto L_0049;\n\tv98 = v81;\n\tv92 = \"il2cpp_codegen_runtime_class_init\"(v98, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0049:\n\tv97 = UnityEngine.Object::op_Inequality(v80.<Instance>k__BackingField, 0);\n\tv100 = v97 == 0;\n\tif (v100) goto L_0066;\n\tgoto L_0060;\n\tv109 = *([v101 @ X0_v20+E0]);\n\tv110 = v109 == 0;\n\tv111 = ~v110;\n\tif (v111) goto L_0060;\n\tv113 = \"il2cpp_codegen_runtime_class_init\"(v101, v95, v96, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0060:\n\tUnityEngine.Object::Destroy(this);\n\treturn;\nL_0066:\n\tgoto L_0070;\n\tv124 = *([v105 @ X0_v10+E0]);\n\tv125 = v124 == 0;\n\tv126 = ~v125;\n\tif (v126) goto L_0070;\n\tv128 = \"il2cpp_codegen_runtime_class_init\"(v105, v95, v96, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0070:\n\tgoto L_007B;\n\tv136 = *([1EA8BD0]);\n\tv137 = *([v136 @ X8_v19]);\n\tv138 = \"il2cpp_codegen_initialize_method\"(v137, v95, v96, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv141 = 0 | 1;\n\t*([2021FDE]) = v141;\nL_007B:\n\tgoto L_0083;\n\tv165 = *([v142 @ X0_v13 (Il2CppClass<EasyMobile.AppLifecycleManager>)+E0]);\n\tv166 = v165 == 0;\n\tv167 = ~v166;\n\tgoto L_0083;\n\tv170 = \"il2cpp_codegen_runtime_class_init\"(v142, v95, v96, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv168 = EasyMobile.AppLifecycleManager;\nL_0083:\n\tv160.<Instance>k__BackingField = this;\n\treturn;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Awake()
		{
			if (Instance != null)
			{
				UnityEngine.Object.Destroy(this);
			}
			else
			{
				Instance = this;
			}
		}

		[Token(Token = "0x6000042")]
		[Address(RVA = "0xA4E03C", Offset = "0xA4E03C", Length = "0x148")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EBFA30]);\n\tv21 = *([v20 @ X8_v31]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021F36]) = v40;\nL_001A:\n\tgoto L_0024;\n\tv47 = *([v43 @ X0_v2+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0024;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\tgoto L_002F;\n\tv59 = *([1ED26E8]);\n\tv60 = *([v59 @ X8_v27]);\n\tv61 = \"il2cpp_codegen_initialize_method\"(v60, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv64 = 0 | 1;\n\t*([2021FDD]) = v64;\nL_002F:\n\tgoto L_003E;\n\tv69 = *([v65 @ X0_v5 (Il2CppClass<EasyMobile.AppLifecycleManager>)+E0]);\n\tv70 = v69 == 0;\n\tv71 = ~v70;\n\tgoto L_003E;\n\tv84 = \"il2cpp_codegen_runtime_class_init\"(v65, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv73 = EasyMobile.AppLifecycleManager;\nL_003E:\n\tgoto L_0048;\n\tv85 = *([v79 @ X8_v11+E0]);\n\tv86 = v85 == 0;\n\tv87 = ~v86;\n\tgoto L_0048;\n\tv96 = v79;\n\tv90 = \"il2cpp_codegen_runtime_class_init\"(v96, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0048:\n\tv95 = UnityEngine.Object::op_Equality(v78.<Instance>k__BackingField, this);\n\tv98 = v95 == 0;\n\tif (v98) goto L_0074;\n\tgoto L_005A;\n\tv116 = *([v99 @ X0_v11+E0]);\n\tv117 = v116 == 0;\n\tv118 = ~v117;\n\tif (v118) goto L_005A;\n\tv120 = \"il2cpp_codegen_runtime_class_init\"(v99, v93, v94, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_005A:\n\tgoto L_0065;\n\tv127 = *([1EA8BD0]);\n\tv128 = *([v127 @ X8_v22]);\n\tv129 = \"il2cpp_codegen_initialize_method\"(v128, v93, v94, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv132 = 0 | 1;\n\t*([2021FDE]) = v132;\nL_0065:\n\tgoto L_006D;\n\tv137 = *([v133 @ X0_v14 (Il2CppClass<EasyMobile.AppLifecycleManager>)+E0]);\n\tv138 = v137 == 0;\n\tv139 = ~v138;\n\tgoto L_006D;\n\tv142 = \"il2cpp_codegen_runtime_class_init\"(v133, v93, v94, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv140 = EasyMobile.AppLifecycleManager;\nL_006D:\n\tv110.<Instance>k__BackingField = 0;\nL_0074:\n\treturn;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDestroy()
		{
			if (Instance == this)
			{
				Instance = null;
			}
		}

		[Token(Token = "0x6000043")]
		[Address(RVA = "0xA4E184", Offset = "0xA4E184", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EFE468]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, isFocus, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([2021F37]) = v38;\nL_0019:\n\tgoto L_002A;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<EasyMobile.AppLifecycleManager>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\t// 29 Jump @b17\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v41, isFocus, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv49 = EasyMobile.AppLifecycleManager;\nL_002A:\n\tgoto L_0057;\n\tv64 = *([v57 @ X8_v6+B0]);\n\tv65 = 0;\n\tv66 = v64 + 8;\n\tv68 = *([v115 @ X11_v5-8]);\n\tv121 = v68 == v60;\n\tif (v121) goto L_004A;\n\tv101 = v116 + 1;\n\tv176 = v101 < v59;\n\tv95 = ~v176;\n\tv98 = v115 + 0x10;\n\tv71 = ~v95;\n\tif (v71) goto L_FFFFFFFF;\n\tv102 = v53;\n\tv103 = 0;\n\tv104 = 0x8909C4(v102, v60, v103, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tgoto L_0057;\nL_004A:\n\tv177 = *([v115 @ X11_v5]);\n\tv178 = v177 << 4;\n\tv179 = v57 + v178;\n\tv180 = v179 + 0x130;\nL_0057:\n\tEasyMobile.Internal.IAppLifecycleHandler::OnApplicationFocus(v52.sAppLifecycleHandler, isFocus);\n\tthrow System.NullReferenceException;\n\treturn;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnApplicationFocus(bool isFocus)
		{
			sAppLifecycleHandler.OnApplicationFocus(isFocus);
		}

		[Token(Token = "0x6000044")]
		[Address(RVA = "0xA4E264", Offset = "0xA4E264", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EC4450]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, isPaused, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([2021F38]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<EasyMobile.AppLifecycleManager>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v41, isPaused, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv49 = EasyMobile.AppLifecycleManager;\nL_0021:\n\tv53 = v52.sAppLifecycleHandler;\n\tv57 = *([v53 @ X20_v4 (EasyMobile.Internal.IAppLifecycleHandler)]);\n\tv61 = *([v57 @ X8_v6 (Il2CppClass<EasyMobile.Internal.IAppLifecycleHandler>)+126]) == 0;\n\tif (v61) goto L_0048;\n\tv115 = *([v57 @ X8_v6 (Il2CppClass<EasyMobile.Internal.IAppLifecycleHandler>)+B0]) + 8;\nL_0033:\n\tv121 = *([v115 @ X11_v5-8]) == EasyMobile.Internal.IAppLifecycleHandler;\n\tif (v121) goto L_004B;\n\tv116 = v116 + 1;\n\tv176 = v116 < *([v57 @ X8_v6 (Il2CppClass<EasyMobile.Internal.IAppLifecycleHandler>)+126]);\n\tv95 = ~v176;\n\tv115 = v115 + 0x10;\n\tv71 = ~v95;\n\tif (v71) goto L_0033;\nL_0048:\n\tv183 = 0x8909C4(v53, EasyMobile.Internal.IAppLifecycleHandler, 1, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tgoto L_004F;\nL_004B:\n\tv178 = *([v115 @ X11_v5]) + 1;\n\tv179 = v178 << 4;\n\tv180 = v57 + v179;\n\tv183 = v180 + 0x130;\nL_004F:\n\tv129 = *([v183 @ X0_v6]);\n\tv136 = *([v183 @ X0_v6+8]);\n\t// 88 IndirectJump v129 @ X3_v1, v53 @ X20_v4 (EasyMobile.Internal.IAppLifecycleHandler), v53 @ X20_v4 (EasyMobile.Internal.IAppLifecycleHandler), isPaused @ X1 (System.Boolean), v136 @ X2_v2, v129 @ X3_v1, v23 @ X4, v24 @ X5, v25 @ X6, v26 @ X7, v27 @ V0, v28 @ V1, v29 @ V2, v30 @ V3, v31 @ V4, v32 @ V5, v33 @ V6, v34 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnApplicationPause(bool isPaused)
		{
			//IL_000d: Expected I, but got O
			//IL_0155: Expected O, but got I
			//IL_0048: Expected O, but got I
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Expected O, but got Unknown
			//IL_00ec: Expected O, but got I
			//IL_00fb: Expected O, but got I
			//IL_0094: Expected O, but got I
			IAppLifecycleHandler appLifecycleHandler = sAppLifecycleHandler;
			IntPtr intPtr = (IntPtr)appLifecycleHandler;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ X8_v6 (Il2CppClass<EasyMobile.Internal.IAppLifecycleHandler>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ X8_v6 (Il2CppClass<EasyMobile.Internal.IAppLifecycleHandler>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IAppLifecycleHandler))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ X8_v6 (Il2CppClass<EasyMobile.Internal.IAppLifecycleHandler>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00ad;
			}
			object obj2 = obj + 1;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_013d;
			IL_00ad:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_013d;
			IL_013d:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ X0_v6+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v129 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000045")]
		[Address(RVA = "0xA4E348", Offset = "0xA4E348", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F10BA0]);\n\tv15 = *([v14 @ X8_v12]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021F39]) = v35;\nL_0017:\n\tgoto L_001F;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<EasyMobile.AppLifecycleManager>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001F;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = EasyMobile.AppLifecycleManager;\nL_001F:\n\tv50 = v49.sAppLifecycleHandler;\n\tv54 = *([v50 @ X19_v4 (EasyMobile.Internal.IAppLifecycleHandler)]);\n\tv58 = *([v54 @ X8_v6 (Il2CppClass<EasyMobile.Internal.IAppLifecycleHandler>)+126]) == 0;\n\tif (v58) goto L_0046;\n\tv112 = *([v54 @ X8_v6 (Il2CppClass<EasyMobile.Internal.IAppLifecycleHandler>)+B0]) + 8;\nL_0031:\n\tv118 = *([v112 @ X11_v5-8]) == EasyMobile.Internal.IAppLifecycleHandler;\n\tif (v118) goto L_0049;\n\tv113 = v113 + 1;\n\tv169 = v113 < *([v54 @ X8_v6 (Il2CppClass<EasyMobile.Internal.IAppLifecycleHandler>)+126]);\n\tv92 = ~v169;\n\tv112 = v112 + 0x10;\n\tv68 = ~v92;\n\tif (v68) goto L_0031;\nL_0046:\n\tv176 = 0x8909C4(v50, EasyMobile.Internal.IAppLifecycleHandler, 2, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tgoto L_004D;\nL_0049:\n\tv171 = *([v112 @ X11_v5]) + 2;\n\tv172 = v171 << 4;\n\tv173 = v54 + v172;\n\tv176 = v173 + 0x130;\nL_004D:\n\tv131 = *([v176 @ X0_v6]);\n\tv153 = *([v176 @ X0_v6+8]);\n\t// 84 IndirectJump v131 @ X2_v2, v50 @ X19_v4 (EasyMobile.Internal.IAppLifecycleHandler), v50 @ X19_v4 (EasyMobile.Internal.IAppLifecycleHandler), v153 @ X1_v2, v131 @ X2_v2, v19 @ X3, v20 @ X4, v21 @ X5, v22 @ X6, v23 @ X7, v24 @ V0, v25 @ V1, v26 @ V2, v27 @ V3, v28 @ V4, v29 @ V5, v30 @ V6, v31 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnApplicationQuit()
		{
			//IL_000d: Expected I, but got O
			//IL_0155: Expected O, but got I
			//IL_0048: Expected O, but got I
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Expected O, but got Unknown
			//IL_00ec: Expected O, but got I
			//IL_00fb: Expected O, but got I
			//IL_0094: Expected O, but got I
			IAppLifecycleHandler appLifecycleHandler = sAppLifecycleHandler;
			IntPtr intPtr = (IntPtr)appLifecycleHandler;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X8_v6 (Il2CppClass<EasyMobile.Internal.IAppLifecycleHandler>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X8_v6 (Il2CppClass<EasyMobile.Internal.IAppLifecycleHandler>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IAppLifecycleHandler))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X8_v6 (Il2CppClass<EasyMobile.Internal.IAppLifecycleHandler>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00ad;
			}
			object obj2 = obj + 2;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_013d;
			IL_00ad:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_013d;
			IL_013d:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ X0_v6+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v131 @ X2_v2 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000046")]
		[Address(RVA = "0xA4E424", Offset = "0xA4E424", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1EE5448]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021F3A]) = v35;\nL_0014:\n\tv39 = new EasyMobile.Internal.AndroidAppLifecycleHandler();\n\tEasyMobile.Internal.AndroidAppLifecycleHandler::.ctor(v39);\n\treturn v39;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static IAppLifecycleHandler GetPlatformAppLifecycleHandler()
		{
			return new AndroidAppLifecycleHandler();
		}

		[Token(Token = "0x6000047")]
		[Address(RVA = "0xA4E480", Offset = "0xA4E480", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AppLifecycleManager()
		{
		}

		[Token(Token = "0x6000048")]
		[Address(RVA = "0xA4E488", Offset = "0xA4E488", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv14 = *([1ED6DA0]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021F3B]) = v35;\nL_0011:\n\tv36 = EasyMobile.AppLifecycleManager::GetPlatformAppLifecycleHandler();\n\tv40.sAppLifecycleHandler = v36;\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static AppLifecycleManager()
		{
			IAppLifecycleHandler platformAppLifecycleHandler = GetPlatformAppLifecycleHandler();
			sAppLifecycleHandler = platformAppLifecycleHandler;
		}
	}
}
