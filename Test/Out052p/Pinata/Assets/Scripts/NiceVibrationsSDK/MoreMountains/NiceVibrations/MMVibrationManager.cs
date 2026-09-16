using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace MoreMountains.NiceVibrations
{
	[Token(Token = "0x2000003")]
	public static class MMVibrationManager
	{
		[Token(Token = "0x400000A")]
		public static long LightDuration;

		[Token(Token = "0x400000B")]
		public static long MediumDuration;

		[Token(Token = "0x400000C")]
		public static long HeavyDuration;

		[Token(Token = "0x400000D")]
		public static int LightAmplitude;

		[Token(Token = "0x400000E")]
		public static int MediumAmplitude;

		[Token(Token = "0x400000F")]
		public static int HeavyAmplitude;

		[Token(Token = "0x4000010")]
		private static int _sdkVersion;

		[Token(Token = "0x4000011")]
		private static long[] _lightimpactPattern;

		[Token(Token = "0x4000012")]
		private static int[] _lightimpactPatternAmplitude;

		[Token(Token = "0x4000013")]
		private static long[] _mediumimpactPattern;

		[Token(Token = "0x4000014")]
		private static int[] _mediumimpactPatternAmplitude;

		[Token(Token = "0x4000015")]
		private static long[] _HeavyimpactPattern;

		[Token(Token = "0x4000016")]
		private static int[] _HeavyimpactPatternAmplitude;

		[Token(Token = "0x4000017")]
		private static long[] _successPattern;

		[Token(Token = "0x4000018")]
		private static int[] _successPatternAmplitude;

		[Token(Token = "0x4000019")]
		private static long[] _warningPattern;

		[Token(Token = "0x400001A")]
		private static int[] _warningPatternAmplitude;

		[Token(Token = "0x400001B")]
		private static long[] _failurePattern;

		[Token(Token = "0x400001C")]
		private static int[] _failurePatternAmplitude;

		[Token(Token = "0x400001D")]
		private static AndroidJavaClass UnityPlayer;

		[Token(Token = "0x400001E")]
		private static AndroidJavaObject CurrentActivity;

		[Token(Token = "0x400001F")]
		private static AndroidJavaObject AndroidVibrator;

		[Token(Token = "0x4000020")]
		private static AndroidJavaClass VibrationEffectClass;

		[Token(Token = "0x4000021")]
		private static AndroidJavaObject VibrationEffect;

		[Token(Token = "0x4000022")]
		private static int DefaultAmplitude;

		[Token(Token = "0x4000023")]
		private static IntPtr AndroidVibrateMethodRawClass;

		[Token(Token = "0x4000024")]
		private static jvalue[] AndroidVibrateMethodRawClassParameters;

		[Token(Token = "0x4000025")]
		private static bool iOSHapticsInitialized;

		[Token(Token = "0x6000001")]
		[Address(RVA = "0x1679334", Offset = "0x1679334", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool Android()
		{
			return true;
		}

		[Token(Token = "0x6000002")]
		[Address(RVA = "0x167933C", Offset = "0x167933C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool iOS()
		{
			return false;
		}

		[Token(Token = "0x6000003")]
		[Address(RVA = "0x1679344", Offset = "0x1679344", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv14 = *([1EC9640]);\n\tv15 = *([v14 @ X8_v10]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202B4FD]) = v35;\nL_0013:\n\tv38 = MoreMountains.NiceVibrations.MMVibrationManager;\n\tv40 = *([v38 @ X0_v2 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>)+12E]) & 0x200;\n\tv41 = v40 == 0;\n\tif (v41) goto L_001D;\n\tv43 = *([v38 @ X0_v2 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>)+E0]) == 0;\n\tif (v43) goto L_002B;\nL_001D:\n\tgoto L_0032;\n\tv57 = *([v51 @ X0_v5+E0]);\n\tv58 = v57 == 0;\n\tv59 = ~v58;\n\tgoto L_0032;\n\tv72 = \"il2cpp_codegen_runtime_class_init\"(v51, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv62 = MoreMountains.NiceVibrations.MMVibrationManager;\n\tgoto L_0032;\nL_002B:\n\tgoto L_0032;\nL_0032:\n\tMoreMountains.NiceVibrations.MMVibrationManager::AndroidVibrate(v65.MediumDuration);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Vibrate()
		{
			//IL_004d: Expected I, but got O
			IntPtr intPtr = (IntPtr)typeof(MMVibrationManager);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X0_v2 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>)+12E]");
			if (0u != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X0_v2 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>)+E0]");
				if ((IntPtr)0 == (IntPtr)0)
				{
				}
			}
			AndroidVibrate(MediumDuration);
		}

		[Token(Token = "0x6000004")]
		[Address(RVA = "0x1679510", Offset = "0x1679510", Length = "0x1B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv18 = *([1EC0630]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, defaultToRegularVibrate, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202B4FE]) = v38;\n\tgoto L_001F;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_001F;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, defaultToRegularVibrate, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_001F:\n\tv52 = type < 6;\n\tv53 = ~v52;\n\tv54 = type - 6;\n\tv56 = v54 == 0;\n\tv61 = ~v56;\n\tv62 = v53 & v61;\n\tif (v62) goto L_004B;\n\tv65 = 0x1862000 + 0xEC;\n\tv67 = *([v65 @ X9_v2 (System.Int32)+type @ X0 (MoreMountains.NiceVibrations.HapticTypes)*4]) + v65;\n\t// 48 IndirectJump v67 @ X8_v7, v48 @ X0_v3 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>), v48 @ X0_v3 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>), defaultToRegularVibrate @ X1 (System.Boolean), methodInfo @ X2 (Il2CppMethodInfo), v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tX0 = *([X20]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_003C;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_003C;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X20]);\nL_003C:\n\tX8 = *([X0+B8]);\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX0 = *([X8]);\n\tX1 = *([X8+18]);\n\tX20 = stack[0];\n\tX19 = stack[8];\n\t// 67 ShiftStack 32\n\tMoreMountains.NiceVibrations.MMVibrationManager::AndroidVibrate(X0, X1, X2);\n\treturn;\nL_004B:\n\treturn;\n\tX0 = *([X20]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0057;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0057;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X20]);\nL_0057:\n\tX8 = *([X0+B8]);\n\tX0 = *([X8+58]);\n\tX1 = *([X8+60]);\n\tgoto L_00A5;\n\tX0 = *([X20]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0066;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0066;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X20]);\nL_0066:\n\tX8 = *([X0+B8]);\n\tX0 = *([X8+68]);\n\tX1 = *([X8+70]);\n\tgoto L_00A5;\n\tX0 = *([X20]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0075;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0075;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X20]);\nL_0075:\n\tX8 = *([X0+B8]);\n\tX0 = *([X8+78]);\n\tX1 = *([X8+80]);\n\tgoto L_00A5;\n\tX0 = *([X20]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0084;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0084;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X20]);\nL_0084:\n\tX8 = *([X0+B8]);\n\tX0 = *([X8+28]);\n\tX1 = *([X8+30]);\n\tgoto L_00A5;\n\tX0 = *([X20]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0093;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0093;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X20]);\nL_0093:\n\tX8 = *([X0+B8]);\n\tX0 = *([X8+38]);\n\tX1 = *([X8+40]);\n\tgoto L_00A5;\n\tX0 = *([X20]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_00A2;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00A2;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X20]);\nL_00A2:\n\tX8 = *([X0+B8]);\n\tX0 = *([X8+48]);\n\tX1 = *([X8+50]);\nL_00A5:\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX2 = 0xFFFFFFFF;\n\tX20 = stack[0];\n\tX19 = stack[8];\n\t// 170 ShiftStack 32\n\tMoreMountains.NiceVibrations.MMVibrationManager::AndroidVibrate(X0, X1, X2, X3);\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Haptic(HapticTypes type, bool defaultToRegularVibrate = false)
		{
			//IL_009f: Expected I, but got O
			//IL_0086: Expected O, but got I
			IntPtr intPtr = (IntPtr)typeof(MMVibrationManager);
			bool flag = type < HapticTypes.HeavyImpact;
			bool flag2 = !flag;
			int num = (int)(type - 6);
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num2 = 25567232 + 236;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ X9_v2 (System.Int32)+type @ X0 (MoreMountains.NiceVibrations.HapticTypes)*4]");
				object obj = 0L + (long)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v67 @ X8_v7 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x6000005")]
		[Address(RVA = "0x16793CC", Offset = "0x16793CC", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EF5D78]);\n\tv19 = *([v18 @ X8_v17]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202B4FF]) = v38;\nL_0015:\n\tv41 = MoreMountains.NiceVibrations.MMVibrationManager;\n\tv43 = *([v41 @ X0_v2 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>)+12E]) & 0x200;\n\tv44 = v43 == 0;\n\tif (v44) goto L_001F;\n\tv46 = *([v41 @ X0_v2 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>)+E0]) == 0;\n\tif (v46) goto L_002D;\nL_001F:\n\tgoto L_002F;\n\tv60 = *([v54 @ X0_v14+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tgoto L_002F;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v54, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv65 = MoreMountains.NiceVibrations.MMVibrationManager;\n\tgoto L_002F;\nL_002D:\n\tgoto L_002F;\nL_002F:\n\tv69 = v68.AndroidVibrateMethodRawClassParameters;\n\tv75 = v69.Length == 0;\n\tif (v75) goto L_004B;\n\t*([v69 @ X8_v6 (UnityEngine.jvalue[])+20]) = milliseconds;\n\tv87 = UnityEngine.AndroidJavaObject::GetRawObject(v79.AndroidVibrator);\n\tUnityEngine.AndroidJNI::CallVoidMethod(v87, v102.AndroidVibrateMethodRawClass, v102.AndroidVibrateMethodRawClassParameters);\n\treturn;\n\tv77 = new System.NullReferenceException();\nL_004B:\n\tv85 = new System.IndexOutOfRangeException();\n\tthrow v85;\n\tthrow System.NullReferenceException;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void AndroidVibrate(long milliseconds)
		{
			//IL_00ae: Expected I, but got O
			IntPtr intPtr = (IntPtr)typeof(MMVibrationManager);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ X0_v2 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>)+12E]");
			if (0u != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ X0_v2 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>)+E0]");
				if ((IntPtr)0 == (IntPtr)0)
				{
				}
			}
			jvalue[] androidVibrateMethodRawClassParameters = AndroidVibrateMethodRawClassParameters;
			if (androidVibrateMethodRawClassParameters.Length != 0)
			{
				IntPtr rawObject = AndroidVibrator.GetRawObject();
				AndroidJNI.CallVoidMethod(rawObject, AndroidVibrateMethodRawClass, AndroidVibrateMethodRawClassParameters);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000006")]
		[Address(RVA = "0x16796C0", Offset = "0x16796C0", Length = "0x264")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv28 = *([1ED8E78]);\n\tv29 = *([v28 @ X8_v39]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, amplitude, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([202B500]) = v47;\nL_001A:\n\tv50 = MoreMountains.NiceVibrations.MMVibrationManager;\n\tv52 = *([v50 @ X0_v2 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>)+12E]) & 0x200;\n\tv53 = v52 == 0;\n\tif (v53) goto L_FFFFFFFF;\n\tv55 = *([v50 @ X0_v2 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>)+E0]) == 0;\n\tif (v55) goto L_FFFFFFFF;\n\tgoto L_0032;\n\tv69 = *([v63 @ X0_v43+E0]);\n\tv70 = v69 == 0;\n\tv71 = ~v70;\n\tgoto L_0032;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v63, amplitude, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_0032;\n\tgoto L_0032;\nL_0032:\n\tv118 = MoreMountains.NiceVibrations.MMVibrationManager::AndroidSDKVersion();\n\tv93 = v118 > 0x19;\n\tif (v93) goto L_0059;\n\tgoto L_0055;\n\tv98 = *([v80 @ X8_v5+E0]);\n\tv99 = v98 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_0055;\n\tv121 = v80;\n\tv103 = \"il2cpp_codegen_runtime_class_init\"(v121, amplitude, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0055:\n\tMoreMountains.NiceVibrations.MMVibrationManager::AndroidVibrate(milliseconds);\n\treturn;\nL_0059:\n\tgoto L_0060;\n\tv114 = *([v80 @ X8_v5+E0]);\n\tv115 = v114 == 0;\n\tv116 = ~v115;\n\tif (v116) goto L_0060;\n\tv122 = v80;\n\tv119 = \"il2cpp_codegen_runtime_class_init\"(v122, amplitude, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0060:\n\tMoreMountains.NiceVibrations.MMVibrationManager::VibrationEffectClassInitialization();\n\t// 104 NewArr v130 @ X0_v7 (System.Object[]), typeof(System.Object[]), 2\n\t// 111 Box v50 @ X0_v2 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>), typeof(System.Int64), &milliseconds @ X0 (System.Int64)\n\tv213 = v50 == 0;\n\tif (v213) goto L_007C;\n\t// 120 IsInst v50 @ X0_v2 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>), typeof(System.Object), v50 @ X0_v2 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>)\nL_007C:\n\tv258 = v130.Length == 0;\n\tif (v258) goto L_00D4;\n\tv130[0] = v50;\n\t// 132 Box v50 @ X0_v2 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>), typeof(System.Int32), &amplitude @ X1 (System.Int32)\n\tv341 = v50 == 0;\n\tif (v341) goto L_008F;\n\t// 139 IsInst v50 @ X0_v2 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>), typeof(System.Object), v50 @ X0_v2 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>)\nL_008F:\n\tv347 = v130.Length < 1;\n\tv181 = ~v347;\n\tv178 = v130.Length - 1;\n\tv172 = v178 == 0;\n\tv348 = ~v181;\n\tv157 = v348 | v172;\n\tif (v157) goto L_00D4;\n\tv130[1] = v50;\n\tv355 = UnityEngine.AndroidJavaObject::CallStatic(v126.VibrationEffectClass, \"createOneShot\", v130);\n\tv184.VibrationEffect = v355;\n\t// 174 NewArr v275 @ X0_v27 (System.Object[]), typeof(System.Object[]), 1\n\tv360 = v359.VibrationEffect == 0;\n\tif (v360) goto L_00BE;\n\t// 186 IsInst v50 @ X0_v2 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>), typeof(System.Object), v359.VibrationEffect (UnityEngine.AndroidJavaObject)\nL_00BE:\n\tv306 = v275.Length == 0;\n\tif (v306) goto L_00D4;\n\tv275[0] = v359.VibrationEffect;\n\tUnityEngine.AndroidJavaObject::Call(v281.AndroidVibrator, \"vibrate\", v275);\n\treturn;\nL_00D4:\n\tv311 = new System.IndexOutOfRangeException();\n\tgoto L_00DB;\n\tv283 = new System.NullReferenceException();\n\tv340 = new System.ArrayTypeMismatchException();\nL_00DB:\n\tthrow v344;\n// 145 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void AndroidVibrate(long milliseconds, int amplitude)
		{
			//IL_0298: Expected I, but got O
			//IL_0038: Expected I, but got O
			//IL_004b: Expected I, but got O
			//IL_00af: Expected I, but got O
			//IL_00da: Expected O, but got I
			//IL_00de: Expected I, but got O
			//IL_0114: Expected O, but got I
			//IL_0121: Expected I, but got O
			//IL_017c: Expected O, but got I4
			//IL_0147: Expected O, but got I
			//IL_014b: Expected I, but got O
			//IL_01c3: Expected O, but got I
			//IL_0227: Expected I, but got O
			IntPtr intPtr = (IntPtr)typeof(MMVibrationManager);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X0_v2 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>)+12E]");
			if (0u != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X0_v2 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>)+E0]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					intPtr = (IntPtr)typeof(MMVibrationManager);
					goto IL_0050;
				}
			}
			intPtr = (IntPtr)typeof(MMVibrationManager);
			goto IL_0050;
			IL_0050:
			int num = AndroidSDKVersion();
			if (num <= 25)
			{
				AndroidVibrate(milliseconds);
				return;
			}
			VibrationEffectClassInitialization();
			object[] array = new object[2];
			intPtr = (IntPtr)(object)milliseconds;
			if (intPtr != (IntPtr)0)
			{
				intPtr = (IntPtr)(((long)intPtr) as object);
			}
			if (array.Length != 0)
			{
				array[0] = (long)intPtr;
				intPtr = (IntPtr)(object)amplitude;
				if (intPtr != (IntPtr)0)
				{
					intPtr = (IntPtr)(((long)intPtr) as object);
				}
				bool flag = array.Length < 1;
				bool flag2 = !flag;
				object obj = array.Length - 1;
				bool flag3 = obj == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = (long)intPtr;
					AndroidJavaObject vibrationEffect = VibrationEffectClass.CallStatic<AndroidJavaObject>("createOneShot", array);
					VibrationEffect = vibrationEffect;
					object[] array2 = new object[1];
					if (VibrationEffect != null)
					{
						intPtr = (IntPtr)(VibrationEffect as object);
					}
					if (array2.Length != 0)
					{
						array2[0] = VibrationEffect;
						AndroidVibrator.Call("vibrate", array2);
						return;
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x6000007")]
		[Address(RVA = "0x1679DFC", Offset = "0x1679DFC", Length = "0x2D8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv28 = *([1EDE6E0]);\n\tv29 = *([v28 @ X8_v51]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, repeat, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([202B501]) = v47;\nL_001A:\n\tv50 = MoreMountains.NiceVibrations.MMVibrationManager;\n\tv52 = *([v50 @ X0_v2 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>)+12E]) & 0x200;\n\tv53 = v52 == 0;\n\tif (v53) goto L_FFFFFFFF;\n\tv55 = *([v50 @ X0_v2 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>)+E0]) == 0;\n\tif (v55) goto L_FFFFFFFF;\n\tgoto L_0032;\n\tv69 = *([v63 @ X0_v53+E0]);\n\tv70 = v69 == 0;\n\tv71 = ~v70;\n\tgoto L_0032;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v63, repeat, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_0032;\n\tgoto L_0032;\nL_0032:\n\tv118 = MoreMountains.NiceVibrations.MMVibrationManager::AndroidSDKVersion();\n\tv93 = v118 > 0x19;\n\tif (v93) goto L_0088;\n\tgoto L_0052;\n\tv98 = *([v80 @ X8_v5 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>)+E0]);\n\tv99 = v98 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_0052;\n\tv121 = v80;\n\tv103 = \"il2cpp_codegen_runtime_class_init\"(v121, repeat, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv106 = MoreMountains.NiceVibrations.MMVibrationManager;\nL_0052:\n\t// 82 NewArr v113 @ X0_v40 (System.Object[]), typeof(System.Object[]), 2\n\tv133 = pattern == 0;\n\tif (v133) goto L_005F;\n\t// 91 IsInst v182 @ X0_v49, typeof(System.Object), pattern @ X0 (System.Int64[])\nL_005F:\n\tv189 = v113.Length == 0;\n\tif (v189) goto L_00FC;\n\tv113[0] = pattern;\n\t// 103 Box v240 @ X0_v43, typeof(System.Int32), &repeat @ X1 (System.Int32)\n\tv319 = v240 == 0;\n\tif (v319) goto L_0072;\n\t// 110 IsInst v214 @ X0_v47, typeof(System.Object), v240 @ X0_v43\nL_0072:\n\tv355 = v113.Length < 1;\n\tv269 = ~v355;\n\tv267 = v113.Length - 1;\n\tv263 = v267 == 0;\n\tv356 = ~v269;\n\tv253 = v356 | v263;\n\tif (v253) goto L_00FC;\n\tv113[1] = v240;\n\tgoto L_00F1;\nL_0088:\n\tgoto L_008F;\n\tv114 = *([v80 @ X8_v5 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>)+E0]);\n\tv115 = v114 == 0;\n\tv116 = ~v115;\n\tif (v116) goto L_008F;\n\tv124 = v80;\n\tv119 = \"il2cpp_codegen_runtime_class_init\"(v124, repeat, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_008F:\n\tMoreMountains.NiceVibrations.MMVibrationManager::VibrationEffectClassInitialization();\n\t// 151 NewArr v132 @ X0_v19 (System.Object[]), typeof(System.Object[]), 2\n\tv235 = pattern == 0;\n\tif (v235) goto L_00A4;\n\t// 160 IsInst v215 @ X0_v35, typeof(System.Object), pattern @ X0 (System.Int64[])\nL_00A4:\n\tv278 = v132.Length == 0;\n\tif (v278) goto L_00FC;\n\tv132[0] = pattern;\n\t// 172 Box v352 @ X0_v22, typeof(System.Int32), &repeat @ X1 (System.Int32)\n\tv357 = v352 == 0;\n\tif (v357) goto L_00B7;\n\t// 179 IsInst v216 @ X0_v33, typeof(System.Object), v352 @ X0_v22\nL_00B7:\n\tv412 = v132.Length < 1;\n\tv163 = ~v412;\n\tv161 = v132.Length - 1;\n\tv157 = v161 == 0;\n\tv413 = ~v163;\n\tv147 = v413 | v157;\n\tif (v147) goto L_00FC;\n\tv132[1] = v352;\n\tv434 = UnityEngine.AndroidJavaObject::CallStatic(v128.VibrationEffectClass, \"createWaveform\", v132);\n\tv165.VibrationEffect = v434;\n\t// 214 NewArr v167 @ X0_v27 (System.Object[]), typeof(System.Object[]), 1\n\tv439 = v438.VibrationEffect == 0;\n\tif (v439) goto L_00E6;\n\t// 226 IsInst v217 @ X0_v31, typeof(System.Object), v438.VibrationEffect (UnityEngine.AndroidJavaObject)\nL_00E6:\n\tv280 = v167.Length == 0;\n\tif (v280) goto L_00FC;\n\tv167[0] = v438.VibrationEffect;\nL_00F1:\n\tUnityEngine.AndroidJavaObject::Call(v397, *([v405 @ X8_v6 (System.String)]), v369);\n\treturn;\nL_00FC:\n\tv289 = new System.IndexOutOfRangeException();\n\tgoto L_0102;\n\tv178 = new System.NullReferenceException();\n\tv234 = new System.ArrayTypeMismatchException();\nL_0102:\n\tthrow v307;\n\tthrow System.NullReferenceException;\n// 167 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void AndroidVibrate(long[] pattern, int repeat)
		{
			//IL_03a0: Expected I, but got O
			//IL_0279: Expected O, but got I4
			//IL_0129: Expected O, but got I4
			IntPtr intPtr = (IntPtr)typeof(MMVibrationManager);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X0_v2 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>)+12E]");
			if (0u != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X0_v2 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>)+E0]");
				if ((IntPtr)0 == (IntPtr)0)
				{
				}
			}
			int num = AndroidSDKVersion();
			object[] args;
			AndroidJavaObject androidVibrator;
			string methodName;
			if (num <= 25)
			{
				object[] array = new object[2];
				if (pattern != null)
				{
					object obj = pattern as object;
				}
				if (array.Length != 0)
				{
					array[0] = pattern;
					object obj2 = repeat;
					if (obj2 != null)
					{
						object obj3 = obj2 as object;
					}
					bool flag = array.Length < 1;
					bool flag2 = !flag;
					object obj4 = array.Length - 1;
					bool flag3 = obj4 == null;
					bool flag4 = !flag2;
					if (!(flag4 || flag3))
					{
						array[1] = obj2;
						args = array;
						androidVibrator = AndroidVibrator;
						methodName = "vibrate";
						goto IL_03e6;
					}
				}
			}
			else
			{
				VibrationEffectClassInitialization();
				object[] array2 = new object[2];
				if (pattern != null)
				{
					object obj5 = pattern as object;
				}
				if (array2.Length != 0)
				{
					array2[0] = pattern;
					object obj6 = repeat;
					if (obj6 != null)
					{
						object obj7 = obj6 as object;
					}
					bool flag5 = array2.Length < 1;
					bool flag6 = !flag5;
					object obj8 = array2.Length - 1;
					bool flag7 = obj8 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array2[1] = obj6;
						AndroidJavaObject vibrationEffect = VibrationEffectClass.CallStatic<AndroidJavaObject>("createWaveform", array2);
						VibrationEffect = vibrationEffect;
						object[] array3 = new object[1];
						if (VibrationEffect != null)
						{
							object obj9 = VibrationEffect as object;
						}
						if (array3.Length != 0)
						{
							array3[0] = VibrationEffect;
							args = array3;
							androidVibrator = AndroidVibrator;
							methodName = "vibrate";
							goto IL_03e6;
						}
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
			IL_03e6:
			androidVibrator.Call(methodName, args);
		}

		[Token(Token = "0x6000008")]
		[Address(RVA = "0x1679924", Offset = "0x1679924", Length = "0x304")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv32 = *([1ED6BF8]);\n\tv33 = *([v32 @ X8_v54]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, amplitudes, repeat, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([202B502]) = v50;\nL_001C:\n\tv53 = MoreMountains.NiceVibrations.MMVibrationManager;\n\tv55 = *([v53 @ X0_v2 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>)+12E]) & 0x200;\n\tv56 = v55 == 0;\n\tif (v56) goto L_FFFFFFFF;\n\tv58 = *([v53 @ X0_v2 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>)+E0]) == 0;\n\tif (v58) goto L_FFFFFFFF;\n\tgoto L_0034;\n\tv72 = *([v66 @ X0_v56+E0]);\n\tv73 = v72 == 0;\n\tv74 = ~v73;\n\tgoto L_0034;\n\tv77 = \"il2cpp_codegen_runtime_class_init\"(v66, amplitudes, repeat, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_0034;\n\tgoto L_0034;\nL_0034:\n\tv121 = MoreMountains.NiceVibrations.MMVibrationManager::AndroidSDKVersion();\n\tv96 = v121 > 0x19;\n\tif (v96) goto L_008A;\n\tgoto L_0054;\n\tv101 = *([v83 @ X8_v5 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>)+E0]);\n\tv102 = v101 == 0;\n\tv103 = ~v102;\n\tif (v103) goto L_0054;\n\tv124 = v83;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v124, amplitudes, repeat, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv109 = MoreMountains.NiceVibrations.MMVibrationManager;\nL_0054:\n\t// 84 NewArr v116 @ X0_v43 (System.Object[]), typeof(System.Object[]), 2\n\tv136 = pattern == 0;\n\tif (v136) goto L_0061;\n\t// 93 IsInst v212 @ X0_v52, typeof(System.Object), pattern @ X0 (System.Int64[])\nL_0061:\n\tv219 = v116.Length == 0;\n\tif (v219) goto L_0115;\n\tv116[0] = pattern;\n\t// 105 Box v276 @ X0_v46, typeof(System.Int32), &repeat @ X2 (System.Int32)\n\tv370 = v276 == 0;\n\tif (v370) goto L_0074;\n\t// 112 IsInst v351 @ X0_v50, typeof(System.Object), v276 @ X0_v46\nL_0074:\n\tv431 = v116.Length < 1;\n\tv248 = ~v431;\n\tv246 = v116.Length - 1;\n\tv242 = v246 == 0;\n\tv432 = ~v248;\n\tv232 = v432 | v242;\n\tif (v232) goto L_0115;\n\tv116[1] = v276;\n\tgoto L_0109;\nL_008A:\n\tgoto L_0091;\n\tv117 = *([v83 @ X8_v5 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>)+E0]);\n\tv118 = v117 == 0;\n\tv119 = ~v118;\n\tif (v119) goto L_0091;\n\tv127 = v83;\n\tv122 = \"il2cpp_codegen_runtime_class_init\"(v127, amplitudes, repeat, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0091:\n\tMoreMountains.NiceVibrations.MMVibrationManager::VibrationEffectClassInitialization();\n\t// 153 NewArr v135 @ X0_v19 (System.Object[]), typeof(System.Object[]), 3\n\tv271 = pattern == 0;\n\tif (v271) goto L_00A5;\n\t// 162 IsInst v325 @ X0_v38, typeof(System.Object), pattern @ X0 (System.Int64[])\nL_00A5:\n\tv319 = v135.Length;\n\tv310 = v135.Length == 0;\n\tif (v310) goto L_0115;\n\tv135[0] = pattern;\n\tv425 = amplitudes == 0;\n\tif (v425) goto L_00B2;\n\t// 174 IsInst v352 @ X0_v36, typeof(System.Object), amplitudes @ X1 (System.Int32[])\n\tv319 = v135.Length;\nL_00B2:\n\tv435 = v319 < 1;\n\tv303 = ~v435;\n\tv301 = v319 - 1;\n\tv297 = v301 == 0;\n\tv436 = ~v303;\n\tv287 = v436 | v297;\n\tif (v287) goto L_0115;\n\tv135[1] = amplitudes;\n\t// 196 Box v441 @ X0_v23, typeof(System.Int32), &repeat @ X2 (System.Int32)\n\tv446 = v441 == 0;\n\tif (v446) goto L_00CF;\n\t// 203 IsInst v353 @ X0_v34, typeof(System.Object), v441 @ X0_v23\nL_00CF:\n\tv460 = v135.Length < 2;\n\tv184 = ~v460;\n\tv181 = v135.Length - 2;\n\tv175 = v181 == 0;\n\tv461 = ~v184;\n\tv160 = v461 | v175;\n\tif (v160) goto L_0115;\n\tv135[2] = v441;\n\tv468 = UnityEngine.AndroidJavaObject::CallStatic(v131.VibrationEffectClass, \"createWaveform\", v135);\n\tv187.VibrationEffect = v468;\n\t// 238 NewArr v190 @ X0_v28 (System.Object[]), typeof(System.Object[]), 1\n\tv473 = v472.VibrationEffect == 0;\n\tif (v473) goto L_00FE;\n\t// 250 IsInst v354 @ X0_v32, typeof(System.Object), v472.VibrationEffect (UnityEngine.AndroidJavaObject)\nL_00FE:\n\tv312 = v190.Length == 0;\n\tif (v312) goto L_0115;\n\tv190[0] = v472.VibrationEffect;\nL_0109:\n\tUnityEngine.AndroidJavaObject::Call(v410, *([v420 @ X8_v6 (System.String)]), v384);\n\treturn;\nL_0115:\n\tv321 = new System.IndexOutOfRangeException();\n\tgoto L_011A;\n\tv369 = new System.ArrayTypeMismatchException();\nL_011A:\n\tthrow v428;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n// 179 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void AndroidVibrate(long[] pattern, int[] amplitudes, int repeat)
		{
			//IL_03fa: Expected I, but got O
			//IL_01ea: Expected O, but got I4
			//IL_047b: Expected O, but got I
			//IL_0129: Expected O, but got I4
			//IL_0254: Expected O, but got I4
			//IL_02d3: Expected O, but got I4
			IntPtr intPtr = (IntPtr)typeof(MMVibrationManager);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X0_v2 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>)+12E]");
			if (0u != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X0_v2 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>)+E0]");
				if ((IntPtr)0 == (IntPtr)0)
				{
				}
			}
			int num = AndroidSDKVersion();
			object[] args;
			AndroidJavaObject androidVibrator;
			string methodName;
			if (num <= 25)
			{
				object[] array = new object[2];
				if (pattern != null)
				{
					object obj = pattern as object;
				}
				if (array.Length != 0)
				{
					array[0] = pattern;
					object obj2 = repeat;
					if (obj2 != null)
					{
						object obj3 = obj2 as object;
					}
					bool flag = array.Length < 1;
					bool flag2 = !flag;
					object obj4 = array.Length - 1;
					bool flag3 = obj4 == null;
					bool flag4 = !flag2;
					if (!(flag4 || flag3))
					{
						array[1] = obj2;
						args = array;
						androidVibrator = AndroidVibrator;
						methodName = "vibrate";
						goto IL_0440;
					}
				}
			}
			else
			{
				VibrationEffectClassInitialization();
				object[] array2 = new object[3];
				if (pattern != null)
				{
					object obj5 = pattern as object;
				}
				object obj6 = array2.Length;
				if (array2.Length != 0)
				{
					array2[0] = pattern;
					if (amplitudes != null)
					{
						object obj7 = amplitudes as object;
						obj6 = array2.Length;
					}
					bool flag5 = (long)(IntPtr)obj6 < 1L;
					bool flag6 = !flag5;
					object obj8 = (long)(IntPtr)obj6 - 1L;
					bool flag7 = obj8 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array2[1] = amplitudes;
						object obj9 = repeat;
						if (obj9 != null)
						{
							object obj10 = obj9 as object;
						}
						bool flag9 = array2.Length < 2;
						bool flag10 = !flag9;
						object obj11 = array2.Length - 2;
						bool flag11 = obj11 == null;
						bool flag12 = !flag10;
						if (!(flag12 || flag11))
						{
							array2[2] = obj9;
							AndroidJavaObject vibrationEffect = VibrationEffectClass.CallStatic<AndroidJavaObject>("createWaveform", array2);
							VibrationEffect = vibrationEffect;
							object[] array3 = new object[1];
							if (VibrationEffect != null)
							{
								object obj12 = VibrationEffect as object;
							}
							if (array3.Length != 0)
							{
								array3[0] = VibrationEffect;
								args = array3;
								androidVibrator = AndroidVibrator;
								methodName = "vibrate";
								goto IL_0440;
							}
						}
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
			IL_0440:
			androidVibrator.Call(methodName, args);
		}

		[Token(Token = "0x6000009")]
		[Address(RVA = "0x167A0D4", Offset = "0x167A0D4", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EBC290]);\n\tv19 = *([v18 @ X8_v25]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([202B503]) = v39;\nL_0015:\n\tv42 = MoreMountains.NiceVibrations.MMVibrationManager;\n\tv44 = *([v42 @ X0_v2 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>)+12E]) & 0x200;\n\tv45 = v44 == 0;\n\tif (v45) goto L_001F;\n\tv47 = *([v42 @ X0_v2 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>)+E0]) == 0;\n\tif (v47) goto L_002D;\nL_001F:\n\tgoto L_0034;\n\tv61 = *([v55 @ X0_v23+E0]);\n\tv62 = v61 == 0;\n\tv63 = ~v62;\n\tgoto L_0034;\n\tv82 = \"il2cpp_codegen_runtime_class_init\"(v55, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv66 = MoreMountains.NiceVibrations.MMVibrationManager;\n\tgoto L_0034;\nL_002D:\n\tgoto L_0034;\nL_0034:\n\tv75 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_003D;\n\tv83 = v75;\n\tv84 = 0x8907BC(v83, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv87 = *([v75 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_003D:\n\tv88 = *([v75 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv89 = v88 == 0;\n\tif (v89) goto L_005E;\n\tv91 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_004A;\n\tv113 = v91;\n\tv114 = 0x8907BC(v113, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_004A:\n\tv115 = *([v91 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv103 = ~v115;\n\tif (v103) goto L_005E;\n\tgoto L_005E;\n\tv137 = v97;\n\tv138 = 0x8907BC(v137, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_005E:\n\tgoto L_0070;\n\tv116 = v108;\n\tv117 = 0x8907BC(v116, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0070:\n\tUnityEngine.AndroidJavaObject::Call(v71.AndroidVibrator, \"cancel\", v124.Value);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 71 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void AndroidCancelVibrations()
		{
			//IL_00a7: Expected I, but got O
			IntPtr intPtr = (IntPtr)typeof(MMVibrationManager);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X0_v2 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>)+12E]");
			if (0u != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X0_v2 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>)+E0]");
				if ((IntPtr)0 == (IntPtr)0)
				{
				}
			}
			IntPtr intPtr2 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr3 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			AndroidVibrator.Call("cancel");
		}

		[Token(Token = "0x600000A")]
		[Address(RVA = "0x1679D44", Offset = "0x1679D44", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1ECEA60]);\n\tv17 = *([v16 @ X8_v18]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([202B504]) = v37;\nL_0018:\n\tgoto L_0021;\n\tv44 = *([v40 @ X0_v2 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_0021;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv48 = MoreMountains.NiceVibrations.MMVibrationManager;\nL_0021:\n\tv53 = v51.VibrationEffectClass == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_0040;\n\tv59 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v59, \"android.os.VibrationEffect\");\n\tgoto L_003A;\n\tv82 = *([v78 @ X0_v7 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>)+E0]);\n\tv83 = v82 == 0;\n\tv84 = ~v83;\n\tif (v84) goto L_003A;\n\tv87 = \"il2cpp_codegen_runtime_class_init\"(v78, v61, v63, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv85 = MoreMountains.NiceVibrations.MMVibrationManager;\nL_003A:\n\tv69.VibrationEffectClass = v59;\nL_0040:\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void VibrationEffectClassInitialization()
		{
			if (VibrationEffectClass == null)
			{
				AndroidJavaClass vibrationEffectClass = new AndroidJavaClass("android.os.VibrationEffect");
				VibrationEffectClass = vibrationEffectClass;
			}
		}

		[Token(Token = "0x600000B")]
		[Address(RVA = "0x1679C28", Offset = "0x1679C28", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1EE4580]);\n\tv17 = *([v16 @ X8_v21]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([202B505]) = v37;\nL_0018:\n\tgoto L_0020;\n\tv44 = *([v40 @ X0_v2 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_0020;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv48 = MoreMountains.NiceVibrations.MMVibrationManager;\nL_0020:\n\tv84 = v51._sdkVersion;\n\tv53 = v51._sdkVersion + 1;\n\tv55 = v53 == 0;\n\tif (v55) goto L_0035;\n\tgoto L_005E;\n\tv64 = *([v47 @ X0_v3 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>)+E0]);\n\tv65 = v64 == 0;\n\tv66 = ~v65;\n\tif (v66) goto L_005E;\n\tv78 = \"il2cpp_codegen_runtime_class_init\"(v47, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv112 = MoreMountains.NiceVibrations.MMVibrationManager;\n\tv83 = *([v112 @ X8_v16+B8]);\n\tv86 = *([v83 @ X8_v17+24]);\n\tgoto L_005E;\nL_0035:\n\tv63 = UnityEngine.SystemInfo::get_operatingSystem();\n\tv94 = UnityEngine.SystemInfo::get_operatingSystem();\n\tv117 = System.String::IndexOf(v94, \"-\");\n\tv122 = v117 + 1;\n\tv124 = System.String::Substring(v63, v122, 3);\n\tv125 = System.Int32::Parse(v124);\n\tgoto L_0057;\n\tv130 = *([v126 @ X8_v10 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>)+E0]);\n\tv131 = v130 == 0;\n\tv132 = ~v131;\n\tif (v132) goto L_0057;\n\tv136 = v126;\n\tv133 = \"il2cpp_codegen_runtime_class_init\"(v136, v73, v75, v71, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv135 = MoreMountains.NiceVibrations.MMVibrationManager;\nL_0057:\n\tv82._sdkVersion = v125;\nL_005E:\n\treturn v84;\n\tthrow System.NullReferenceException;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int AndroidSDKVersion()
		{
			int result = _sdkVersion;
			if (_sdkVersion + 1 == 0)
			{
				string operatingSystem = SystemInfo.operatingSystem;
				string operatingSystem2 = SystemInfo.operatingSystem;
				int num = operatingSystem2.IndexOf("-");
				int startIndex = num + 1;
				string s = operatingSystem.Substring(startIndex, 3);
				result = (_sdkVersion = int.Parse(s));
			}
			return result;
		}

		[Token(Token = "0x600000C")]
		[Address(RVA = "0x167A210", Offset = "0x167A210", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private static void InstantiateFeedbackGenerators()
		{
		}

		[Token(Token = "0x600000D")]
		[Address(RVA = "0x167A214", Offset = "0x167A214", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private static void ReleaseFeedbackGenerators()
		{
		}

		[Token(Token = "0x600000E")]
		[Address(RVA = "0x167A218", Offset = "0x167A218", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private static void SelectionHaptic()
		{
		}

		[Token(Token = "0x600000F")]
		[Address(RVA = "0x167A21C", Offset = "0x167A21C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private static void SuccessHaptic()
		{
		}

		[Token(Token = "0x6000010")]
		[Address(RVA = "0x167A220", Offset = "0x167A220", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private static void WarningHaptic()
		{
		}

		[Token(Token = "0x6000011")]
		[Address(RVA = "0x167A224", Offset = "0x167A224", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private static void FailureHaptic()
		{
		}

		[Token(Token = "0x6000012")]
		[Address(RVA = "0x167A228", Offset = "0x167A228", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private static void LightImpactHaptic()
		{
		}

		[Token(Token = "0x6000013")]
		[Address(RVA = "0x167A22C", Offset = "0x167A22C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private static void MediumImpactHaptic()
		{
		}

		[Token(Token = "0x6000014")]
		[Address(RVA = "0x167A230", Offset = "0x167A230", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private static void HeavyImpactHaptic()
		{
		}

		[Token(Token = "0x6000015")]
		[Address(RVA = "0x167A234", Offset = "0x167A234", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv14 = *([1EDFD38]);\n\tv15 = *([v14 @ X8_v10]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202B506]) = v35;\nL_0013:\n\tv38 = MoreMountains.NiceVibrations.MMVibrationManager;\n\tv40 = *([v38 @ X0_v2 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>)+12F]) & 2;\n\tv41 = v40 == 0;\n\tif (v41) goto L_001F;\n\tv43 = *([v38 @ X0_v2 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>)+E0]) == 0;\n\tif (v43) goto L_0025;\nL_001F:\n\treturn;\nL_0025:\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void iOSInitializeHaptics()
		{
			//IL_003a: Expected I, but got O
			IntPtr intPtr = (IntPtr)typeof(MMVibrationManager);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X0_v2 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>)+12F]");
			if (0u != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X0_v2 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>)+E0]");
				if ((IntPtr)0 == (IntPtr)0)
				{
				}
			}
		}

		[Token(Token = "0x6000016")]
		[Address(RVA = "0x167A298", Offset = "0x167A298", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv14 = *([1EC61A0]);\n\tv15 = *([v14 @ X8_v10]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202B507]) = v35;\nL_0013:\n\tv38 = MoreMountains.NiceVibrations.MMVibrationManager;\n\tv40 = *([v38 @ X0_v2 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>)+12F]) & 2;\n\tv41 = v40 == 0;\n\tif (v41) goto L_001F;\n\tv43 = *([v38 @ X0_v2 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>)+E0]) == 0;\n\tif (v43) goto L_0025;\nL_001F:\n\treturn;\nL_0025:\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void iOSReleaseHaptics()
		{
			//IL_003a: Expected I, but got O
			IntPtr intPtr = (IntPtr)typeof(MMVibrationManager);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X0_v2 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>)+12F]");
			if (0u != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X0_v2 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>)+E0]");
				if ((IntPtr)0 == (IntPtr)0)
				{
				}
			}
		}

		[Token(Token = "0x6000017")]
		[Address(RVA = "0x167A2FC", Offset = "0x167A2FC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool HapticsSupported()
		{
			return false;
		}

		[Token(Token = "0x6000018")]
		[Address(RVA = "0x16794AC", Offset = "0x16794AC", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv14 = *([1ED4ED0]);\n\tv15 = *([v14 @ X8_v10]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, defaultToRegularVibrate, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202B508]) = v35;\nL_0013:\n\tv38 = MoreMountains.NiceVibrations.MMVibrationManager;\n\tv40 = *([v38 @ X0_v2 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>)+12F]) & 2;\n\tv41 = v40 == 0;\n\tif (v41) goto L_001F;\n\tv43 = *([v38 @ X0_v2 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>)+E0]) == 0;\n\tif (v43) goto L_0025;\nL_001F:\n\treturn;\nL_0025:\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void iOSTriggerHaptics(HapticTypes type, bool defaultToRegularVibrate = false)
		{
			//IL_003a: Expected I, but got O
			IntPtr intPtr = (IntPtr)typeof(MMVibrationManager);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X0_v2 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>)+12F]");
			if (0u != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X0_v2 (Il2CppClass<MoreMountains.NiceVibrations.MMVibrationManager>)+E0]");
				if ((IntPtr)0 == (IntPtr)0)
				{
				}
			}
		}

		[Token(Token = "0x6000019")]
		[Address(RVA = "0x167A304", Offset = "0x167A304", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string iOSSDKVersion()
		{
			return null;
		}

		[Token(Token = "0x600001A")]
		[Address(RVA = "0x167A30C", Offset = "0x167A30C", Length = "0x63C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv20 = *([1EAEC28]);\n\tv21 = *([v20 @ X8_v111]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([202B509]) = v41;\nL_001D:\n\tv50.LightDuration = 0x14;\n\tv52.MediumDuration = 0x28;\n\tv53.HeavyDuration = 0x50;\n\tv54.LightAmplitude = 0x28;\n\tv55.MediumAmplitude = 0x78;\n\tv57.HeavyAmplitude = 0xFF;\n\tv59._sdkVersion = 0xFFFFFFFF;\n\t// 48 NewArr v63 @ X0_v3 (System.Int64[]), typeof(System.Int64[]), 2\n\tv63[1] = v299.LightDuration;\n\tv277._lightimpactPattern = v63;\n\t// 75 NewArr v245 @ X0_v16 (System.Int32[]), typeof(System.Int32[]), 2\n\tv245[1] = v530.LightAmplitude;\n\tv278._lightimpactPatternAmplitude = v245;\n\t// 100 NewArr v246 @ X0_v18 (System.Int64[]), typeof(System.Int64[]), 2\n\tv246[1] = v537.MediumDuration;\n\tv279._mediumimpactPattern = v246;\n\t// 125 NewArr v247 @ X0_v20 (System.Int32[]), typeof(System.Int32[]), 2\n\tv247[1] = v544.MediumAmplitude;\n\tv280._mediumimpactPatternAmplitude = v247;\n\t// 150 NewArr v248 @ X0_v22 (System.Int64[]), typeof(System.Int64[]), 2\n\tv248[1] = v551.HeavyDuration;\n\tv281._HeavyimpactPattern = v248;\n\t// 175 NewArr v249 @ X0_v24 (System.Int32[]), typeof(System.Int32[]), 2\n\tv249[1] = v558.HeavyAmplitude;\n\tv282._HeavyimpactPatternAmplitude = v249;\n\t// 200 NewArr v250 @ X0_v26 (System.Int64[]), typeof(System.Int64[]), 4\n\tv250[1] = v566.LightDuration;\n\tv250[2] = v569.LightDuration;\n\tv250[3] = v572.HeavyDuration;\n\tv283._successPattern = v250;\n\t// 255 NewArr v251 @ X0_v28 (System.Int32[]), typeof(System.Int32[]), 4\n\tv251[1] = v580.LightAmplitude;\n\tv251[3] = v583.HeavyAmplitude;\n\tv284._successPatternAmplitude = v251;\n\t// 296 NewArr v252 @ X0_v30 (System.Int64[]), typeof(System.Int64[]), 4\n\tv252[1] = v591.HeavyDuration;\n\tv252[2] = v594.LightDuration;\n\tv252[3] = v597.MediumDuration;\n\tv285._warningPattern = v252;\n\t// 351 NewArr v253 @ X0_v32 (System.Int32[]), typeof(System.Int32[]), 4\n\tv253[1] = v605.HeavyAmplitude;\n\tv253[3] = v608.MediumAmplitude;\n\tv286._warningPatternAmplitude = v253;\n\t// 392 NewArr v254 @ X0_v34 (System.Int64[]), typeof(System.Int64[]), 8\n\tv254[1] = v616.MediumDuration;\n\tv254[2] = v619.LightDuration;\n\tv254[3] = v623.MediumDuration;\n\tv254[4] = v626.LightDuration;\n\tv254[5] = v630.HeavyDuration;\n\tv254[6] = v633.LightDuration;\n\tv254[7] = v636.LightDuration;\n\tv287._failurePattern = v254;\n\t// 507 NewArr v255 @ X0_v36 (System.Int32[]), typeof(System.Int32[]), 8\n\tv255[1] = v644.MediumAmplitude;\n\tv255[3] = v648.MediumAmplitude;\n\tv255[5] = v652.HeavyAmplitude;\n\tv255[7] = v655.LightAmplitude;\n\tv658._failurePatternAmplitude = v255;\n\tv662 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v662, \"com.unity3d.player.UnityPlayer\");\n\tv98.UnityPlayer = v662;\n\tv671 = UnityEngine.AndroidJavaObject::GetStatic(v288.UnityPlayer, \"currentActivity\");\n\tv673.CurrentActivity = v671;\n\t// 611 NewArr v257 @ X0_v42 (System.Object[]), typeof(System.Object[]), 1\n\tv678 = \"vibrator\" == 0;\n\tif (v678) goto L_0275;\n\t// 622 IsInst v524 @ X0_v52, typeof(System.Object), \"vibrator\"\n\tv525 = v524 == 0;\n\tif (v525) goto L_02AF;\nL_0275:\n\tv257[0] = \"vibrator\";\n\tv686 = UnityEngine.AndroidJavaObject::Call(v289.CurrentActivity, \"getSystemService\", v257);\n\tv100.AndroidVibrator = v686;\n\tv689 = UnityEngine.AndroidJavaObject::GetRawClass(v290.AndroidVibrator);\n\tv698 = UnityEngine.AndroidJNIHelper::GetMethodID(v689, \"vibrate\", \"(J)V\", 0);\n\tv701.AndroidVibrateMethodRawClass = v698;\n\t// 666 NewArr v705 @ X0_v51 (UnityEngine.jvalue[]), typeof(UnityEngine.jvalue[]), 1\n\tv707.AndroidVibrateMethodRawClassParameters = v705;\n\tv708.iOSHapticsInitialized = 0;\n\treturn;\n\tv476 = new System.IndexOutOfRangeException();\nL_02AB:\n\tv244 = new System.TypeLoadException();\n\tthrow System.NullReferenceException;\n\tv499 = new System.NullReferenceException();\nL_02AF:\n\tv518 = new System.ArrayTypeMismatchException();\n\tgoto L_02AB;\n\treturn;\n// 598 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static MMVibrationManager()
		{
			//IL_04a0: Expected I8, but got I4
			//IL_04aa: Expected I8, but got I4
			//IL_04b4: Expected I8, but got I4
			LightDuration = 20L;
			MediumDuration = 40L;
			HeavyDuration = 80L;
			LightAmplitude = 40;
			MediumAmplitude = 120;
			HeavyAmplitude = 255;
			_sdkVersion = -1;
			_lightimpactPattern = new long[2] { 0L, LightDuration };
			_lightimpactPatternAmplitude = new int[2] { 0, LightAmplitude };
			_mediumimpactPattern = new long[2] { 0L, MediumDuration };
			_mediumimpactPatternAmplitude = new int[2] { 0, MediumAmplitude };
			_HeavyimpactPattern = new long[2] { 0L, HeavyDuration };
			_HeavyimpactPatternAmplitude = new int[2] { 0, HeavyAmplitude };
			_successPattern = new long[4] { 0L, LightDuration, LightDuration, HeavyDuration };
			_successPatternAmplitude = new int[4] { 0, LightAmplitude, 0, HeavyAmplitude };
			_warningPattern = new long[4] { 0L, HeavyDuration, LightDuration, MediumDuration };
			_warningPatternAmplitude = new int[4] { 0, HeavyAmplitude, 0, MediumAmplitude };
			_failurePattern = new long[8] { 0L, MediumDuration, LightDuration, MediumDuration, LightDuration, HeavyDuration, LightDuration, LightDuration };
			_failurePatternAmplitude = new int[8] { 0, MediumAmplitude, 0, MediumAmplitude, 0, HeavyAmplitude, 0, LightAmplitude };
			AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			UnityPlayer = unityPlayer;
			AndroidJavaObject currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
			CurrentActivity = currentActivity;
			object[] array = new object[1];
			if ("vibrator" != null)
			{
				object obj = "vibrator" as object;
				if (obj == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					TypeLoadException ex2 = new TypeLoadException();
					throw new NullReferenceException();
				}
			}
			array[0] = "vibrator";
			AndroidJavaObject androidVibrator = CurrentActivity.Call<AndroidJavaObject>("getSystemService", array);
			AndroidVibrator = androidVibrator;
			IntPtr rawClass = AndroidVibrator.GetRawClass();
			IntPtr methodID = AndroidJNIHelper.GetMethodID(rawClass, "vibrate", "(J)V", isStatic: false);
			AndroidVibrateMethodRawClass = methodID;
			jvalue[] androidVibrateMethodRawClassParameters = new jvalue[1];
			AndroidVibrateMethodRawClassParameters = androidVibrateMethodRawClassParameters;
			iOSHapticsInitialized = false;
		}
	}
}
