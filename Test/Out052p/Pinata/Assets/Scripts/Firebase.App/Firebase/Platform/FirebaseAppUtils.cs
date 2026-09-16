using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Firebase.Platform
{
	[Token(Token = "0x2000010")]
	internal class FirebaseAppUtils : Firebase.Platform.IFirebaseAppUtils
	{
		[Token(Token = "0x4000032")]
		internal static FirebaseAppUtils instance;

		[Token(Token = "0x17000014")]
		public static FirebaseAppUtils Instance
		{
			[Token(Token = "0x6000079")]
			[Address(RVA = "0x16016B8", Offset = "0x16016B8", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EFB8E0]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202A1AC]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Firebase.Platform.FirebaseAppUtils>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = Firebase.Platform.FirebaseAppUtils;\nL_0024:\n\treturn v49.instance;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return instance;
			}
		}

		[Token(Token = "0x6000078")]
		[Address(RVA = "0x16016B0", Offset = "0x16016B0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FirebaseAppUtils()
		{
		}

		[Token(Token = "0x600007A")]
		[Address(RVA = "0x1601720", Offset = "0x1601720", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EDED58]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, action, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([202A1AD]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, action, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0025:\n\tFirebase.FirebaseApp::TranslateDllNotFoundException(action);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void TranslateDllNotFoundException(Action action)
		{
			FirebaseApp.TranslateDllNotFoundException(action);
		}

		[Token(Token = "0x600007B")]
		[Address(RVA = "0x1601784", Offset = "0x1601784", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tFirebase.AppUtil::PollCallbacks();\n\treturn;\n")]
		public void PollCallbacks()
		{
			AppUtil.PollCallbacks();
		}

		[Token(Token = "0x600007C")]
		[Address(RVA = "0x1601788", Offset = "0x1601788", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EBC378]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202A1AE]) = v35;\nL_0017:\n\tgoto L_001D;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Firebase.FirebaseApp>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001D;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001D:\n\tv49 = Firebase.FirebaseApp::get_DefaultInstance();\n\treturnVal1 = Firebase.FirebaseApp::get_AppPlatform(v49);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Firebase.Platform.IFirebaseAppPlatform GetDefaultInstance()
		{
			FirebaseApp defaultInstance = FirebaseApp.DefaultInstance;
			return defaultInstance.AppPlatform;
		}

		[Token(Token = "0x600007D")]
		[Address(RVA = "0x16017F0", Offset = "0x16017F0", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F05428]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202A1AF]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Firebase.FirebaseApp>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0021:\n\treturnVal1 = Firebase.FirebaseApp::get_DefaultName();\n\treturn returnVal1;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string GetDefaultInstanceName()
		{
			return FirebaseApp.DefaultName;
		}

		[Token(Token = "0x600007E")]
		[Address(RVA = "0x160184C", Offset = "0x160184C", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EF38E8]);\n\tv15 = *([v14 @ X8_v14]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202A1B0]) = v35;\nL_0017:\n\tgoto L_001D;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Firebase.FirebaseApp>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001D;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001D:\n\tv49 = Firebase.FirebaseApp::get_LogLevel();\nL_0025:\n\tgoto L_002D;\n\tv57 = *([v53 @ X0_v5+E0]);\n\tv58 = v57 == 0;\n\tv59 = ~v58;\n\tgoto L_002D;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v53, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_002D:\n\tv66 = v49 < 5;\n\tv67 = ~v66;\n\tv75 = ~v67;\n\tv76 = ~v75;\n\tif (v76) goto L_FFFFFFFF;\n\tgoto L_003F;\nL_003F:\n\treturn returnVal1;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX19 = X0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0065;\n\tX0 = X19;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = X0;\n\tX8 = *([X19]);\n\tX9 = *([1EDF060]);\n\tX1 = *([X8]);\n\tX0 = *([X9]);\n\tX0 = 0x8D845C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_005B;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = 0 | 1;\n\tgoto L_0025;\nL_005B:\n\tX0 = 0 | 8;\n\tX0 = 0x6D1E60(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X19]);\n\t*([X0]) = X8;\n\tX1 = X1 + 0x870;\n\tX2 = 0;\n\tX0 = 0x6D2A00(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = X0;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0065:\n\tX0 = X19;\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = 0x846AA4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn X0;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Firebase.Platform.PlatformLogLevel GetLogLevel()
		{
			LogLevel logLevel = FirebaseApp.LogLevel;
			if (logLevel < LogLevel.Assert)
			{
				return (Firebase.Platform.PlatformLogLevel)logLevel;
			}
			return Firebase.Platform.PlatformLogLevel.Debug;
		}

		[Token(Token = "0x600007F")]
		[Address(RVA = "0x160194C", Offset = "0x160194C", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1EB4C80]);\n\tv17 = *([v16 @ X8_v6]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([202A1B1]) = v37;\nL_0015:\n\tv41 = new Firebase.Platform.FirebaseAppUtils();\n\tSystem.Object::.ctor(v41);\n\tv45.instance = v41;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static FirebaseAppUtils()
		{
			FirebaseAppUtils firebaseAppUtils = new FirebaseAppUtils();
			instance = firebaseAppUtils;
		}
	}
}
