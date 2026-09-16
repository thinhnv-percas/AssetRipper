using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using EasyMobile.Internal;
using UnityEngine;

namespace EasyMobile
{
	[Token(Token = "0x2000011")]
	public static class RuntimeManager
	{
		[Token(Token = "0x4000088")]
		private const string APP_INSTALLATION_TIMESTAMP_PPKEY = "EM_APP_INSTALLATION_TIMESTAMP";

		[Token(Token = "0x4000089")]
		public static bool mIsInitialized;

		[Token(Token = "0x600006E")]
		[Address(RVA = "0xFD3C38", Offset = "0xFD3C38", Length = "0x220")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EBF728]);\n\tv23 = *([v22 @ X8_v43]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 0 | 1;\n\t*([20256B8]) = v43;\nL_001B:\n\tgoto L_0024;\n\tv50 = *([v46 @ X0_v2 (Il2CppClass<EasyMobile.RuntimeManager>)+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0024;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v46, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = EasyMobile.RuntimeManager;\nL_0024:\n\tv59 = ~v57.mIsInitialized;\n\tv60 = ~v59;\n\tif (v60) goto L_00BD;\n\tv63 = UnityEngine.Application::get_isPlaying();\n\tv66 = v63 == 0;\n\tif (v66) goto L_00BD;\n\tgoto L_0039;\n\tv111 = *([v107 @ X0_v7+E0]);\n\tv112 = v111 == 0;\n\tv113 = ~v112;\n\tif (v113) goto L_0039;\n\tv115 = \"il2cpp_codegen_runtime_class_init\"(v107, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0039:\n\tEasyMobile.Internal.RuntimeHelper::Init();\n\tv122 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v122, \"EasyMobile\");\n\tgoto L_004F;\n\tv132 = *([v128 @ X0_v12+E0]);\n\tv133 = v132 == 0;\n\tv134 = ~v133;\n\tif (v134) goto L_004F;\n\tv136 = \"il2cpp_codegen_runtime_class_init\"(v128, v127, v125, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_004F:\n\tEasyMobile.RuntimeManager::Configure(v122);\n\tgoto L_0063;\n\tv146 = *([v142 @ X0_v15 (Il2CppClass<EasyMobile.Internal.Util>)+E0]);\n\tv147 = v146 == 0;\n\tv148 = ~v147;\n\tif (v148) goto L_0063;\n\tv160 = \"il2cpp_codegen_runtime_class_init\"(v142, v127, v125, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv150 = EasyMobile.Internal.Util;\nL_0063:\n\tv159 = EasyMobile.Internal.StorageUtil::GetTime(\"EM_APP_INSTALLATION_TIMESTAMP\", v154.UnixEpoch);\n\tgoto L_0078;\n\tv170 = *([v166 @ X8_v20+E0]);\n\tv171 = v170 == 0;\n\tv172 = ~v171;\n\tgoto L_0078;\n\tv181 = v166;\n\tv175 = \"il2cpp_codegen_runtime_class_init\"(v181, v157, v156, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0078:\n\tv180 = System.DateTime::op_Equality(v159, v165.UnixEpoch);\n\tv183 = v180 == 0;\n\tif (v183) goto L_0091;\n\tgoto L_0087;\n\tv201 = *([v184 @ X0_v31+E0]);\n\tv202 = v201 == 0;\n\tv203 = ~v202;\n\tif (v203) goto L_0087;\n\tv205 = \"il2cpp_codegen_runtime_class_init\"(v184, v178, v179, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0087:\n\tv208 = System.DateTime::get_Now();\n\tEasyMobile.Internal.StorageUtil::SetTime(\"EM_APP_INSTALLATION_TIMESTAMP\", v208);\nL_0091:\n\tgoto L_009A;\n\tv209 = *([v197 @ X0_v23 (Il2CppClass<EasyMobile.RuntimeManager>)+E0]);\n\tv210 = v209 == 0;\n\tv211 = ~v210;\n\tif (v211) goto L_009A;\n\tv223 = \"il2cpp_codegen_runtime_class_init\"(v197, v188, v94, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv213 = EasyMobile.RuntimeManager;\nL_009A:\n\tv216.mIsInitialized = 1;\n\tgoto L_00B3;\n\tv224 = *([v219 @ X0_v25+E0]);\n\tv225 = v224 == 0;\n\tv226 = ~v225;\n\tgoto L_00B3;\n\tv228 = \"il2cpp_codegen_runtime_class_init\"(v219, v188, v94, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_00B3:\n\tUnityEngine.Debug::Log(\"Easy Mobile runtime has been initialized.\");\n\treturn;\nL_00BD:\n\treturn;\n// 112 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Init()
		{
			if (!mIsInitialized && Application.isPlaying)
			{
				RuntimeHelper.Init();
				GameObject go = new GameObject("EasyMobile");
				Configure(go);
				DateTime time = StorageUtil.GetTime("EM_APP_INSTALLATION_TIMESTAMP", Util.UnixEpoch);
				if (time == Util.UnixEpoch)
				{
					DateTime now = DateTime.Now;
					StorageUtil.SetTime("EM_APP_INSTALLATION_TIMESTAMP", now);
				}
				mIsInitialized = true;
				Debug.Log("Easy Mobile runtime has been initialized.");
			}
		}

		[Token(Token = "0x600006F")]
		[Address(RVA = "0xFD3F6C", Offset = "0xFD3F6C", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EDF7C0]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20256B9]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<EasyMobile.RuntimeManager>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = EasyMobile.RuntimeManager;\nL_0024:\n\treturn v49.mIsInitialized;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsInitialized()
		{
			return mIsInitialized;
		}

		[Token(Token = "0x6000070")]
		[Address(RVA = "0xFD3FD4", Offset = "0xFD3FD4", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F0CA90]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20256BA]) = v35;\nL_0017:\n\tgoto L_0028;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<EasyMobile.Internal.Util>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0028;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = EasyMobile.Internal.Util;\nL_0028:\n\treturnVal1 = EasyMobile.Internal.StorageUtil::GetTime(\"EM_APP_INSTALLATION_TIMESTAMP\", v50.UnixEpoch);\n\treturn returnVal1;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static DateTime GetAppInstallationTimestamp()
		{
			return StorageUtil.GetTime("EM_APP_INSTALLATION_TIMESTAMP", Util.UnixEpoch);
		}

		[Token(Token = "0x6000071")]
		[Address(RVA = "0xFD404C", Offset = "0xFD404C", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EE8FC0]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20256BB]) = v38;\nL_0019:\n\tgoto L_0020;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0020;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0020:\n\tv53 = UnityEngine.Debug::get_unityLogger();\n\tv57 = *([v53 @ X0_v5 (UnityEngine.ILogger)]);\n\tv61 = *([v57 @ X8_v7 (Il2CppClass<UnityEngine.ILogger>)+126]) == 0;\n\tif (v61) goto L_0048;\n\tv114 = *([v57 @ X8_v7 (Il2CppClass<UnityEngine.ILogger>)+B0]) + 8;\nL_0033:\n\tv120 = *([v114 @ X11_v5-8]) == UnityEngine.ILogger;\n\tif (v120) goto L_004B;\n\tv115 = v115 + 1;\n\tv175 = v115 < *([v57 @ X8_v7 (Il2CppClass<UnityEngine.ILogger>)+126]);\n\tv94 = ~v175;\n\tv114 = v114 + 0x10;\n\tv70 = ~v94;\n\tif (v70) goto L_0033;\nL_0048:\n\tv182 = 0x8909C4(v53, UnityEngine.ILogger, 1, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_004F;\nL_004B:\n\tv177 = *([v114 @ X11_v5]) + 1;\n\tv178 = v177 << 4;\n\tv179 = v57 + v178;\n\tv182 = v179 + 0x130;\nL_004F:\n\tv128 = *([v182 @ X0_v7]);\n\tv135 = *([v182 @ X0_v7+8]);\n\t// 88 IndirectJump v128 @ X3_v1, v53 @ X0_v5 (UnityEngine.ILogger), v53 @ X0_v5 (UnityEngine.ILogger), isEnabled @ X0 (System.Boolean), v135 @ X2_v2, v128 @ X3_v1, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void EnableUnityDebugLog(bool isEnabled)
		{
			//IL_001b: Expected I, but got O
			//IL_0150: Expected O, but got I
			//IL_0056: Expected O, but got I
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Expected O, but got Unknown
			//IL_00f5: Expected O, but got I
			//IL_0104: Expected O, but got I
			//IL_00a2: Expected O, but got I
			ILogger unityLogger = Debug.unityLogger;
			IntPtr intPtr = (IntPtr)unityLogger;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ X8_v7 (Il2CppClass<UnityEngine.ILogger>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00bb;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ X8_v7 (Il2CppClass<UnityEngine.ILogger>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(ILogger))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ X8_v7 (Il2CppClass<UnityEngine.ILogger>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00bb;
			}
			object obj2 = obj + 1;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0138;
			IL_00bb:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0138;
			IL_0138:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ X0_v7+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v128 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000072")]
		[Address(RVA = "0xFD3E58", Offset = "0xFD3E58", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ED9C58]);\n\tv19 = *([v18 @ X8_v23]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20256BC]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0021:\n\tUnityEngine.Object::DontDestroyOnLoad(go);\n\tv59 = UnityEngine.GameObject::AddComponent(go);\n\tv63 = EasyMobile.EM_Settings::get_IsAdModuleEnable();\n\tv65 = v63 == 0;\n\tif (v65) goto L_0034;\n\tv93 = UnityEngine.GameObject::AddComponent(go);\nL_0034:\n\tv98 = EasyMobile.EM_Settings::get_IsIAPModuleEnable();\n\tv100 = v98 == 0;\n\tif (v100) goto L_003E;\n\tv105 = UnityEngine.GameObject::AddComponent(go);\nL_003E:\n\tv110 = EasyMobile.EM_Settings::get_IsGameServicesModuleEnable();\n\tv112 = v110 == 0;\n\tif (v112) goto L_0048;\n\tv117 = UnityEngine.GameObject::AddComponent(go);\nL_0048:\n\tv74 = EasyMobile.EM_Settings::get_IsNotificationsModuleEnable();\n\tv76 = v74 == 0;\n\tif (v76) goto L_005C;\n\tv73 = UnityEngine.GameObject::AddComponent(go);\n\treturn;\nL_005C:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void Configure(GameObject go)
		{
			UnityEngine.Object.DontDestroyOnLoad(go);
			AppLifecycleManager appLifecycleManager = go.AddComponent<AppLifecycleManager>();
			if (EM_Settings.IsAdModuleEnable)
			{
				Advertising advertising = go.AddComponent<Advertising>();
			}
			if (EM_Settings.IsIAPModuleEnable)
			{
				InAppPurchasing inAppPurchasing = go.AddComponent<InAppPurchasing>();
			}
			if (EM_Settings.IsGameServicesModuleEnable)
			{
				GameServices gameServices = go.AddComponent<GameServices>();
			}
			if (EM_Settings.IsNotificationsModuleEnable)
			{
				Notifications notifications = go.AddComponent<Notifications>();
			}
		}
	}
}
