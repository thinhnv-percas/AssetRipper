using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace CodeStage.AntiCheat.Utils
{
	[Token(Token = "0x2000008")]
	internal class TimeUtils
	{
		[Token(Token = "0x4000009")]
		public const long TicksPerSecond = 10000000L;

		[Token(Token = "0x400000A")]
		private const string RoutinesClassPath = "net.codestage.actk.androidnative.ACTkAndroidRoutines";

		[Token(Token = "0x400000B")]
		private static AndroidJavaClass routinesClass;

		[Token(Token = "0x400000C")]
		private static bool androidTimeReadAttemptWasMade;

		[Token(Token = "0x6000024")]
		[Address(RVA = "0xBD509C", Offset = "0xBD509C", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_000E;\n\tv10 = System.DateTime;\n\tv11 = \"il2cpp_codegen_initialize_runtime_metadata\"(v10, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26);\n\tv30 = 1;\n\t*([1A353E7]) = v30;\nL_000E:\n\treturnVal1 = CodeStage.AntiCheat.Utils.TimeUtils::TryReadTicksFromAndroidRoutine();\n\tv32 = returnVal1 == 0;\n\tv33 = ~v32;\n\tif (v33) goto L_0023;\n\tgoto L_001B;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v36, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26);\nL_001B:\n\tv54 = System.DateTime::get_UtcNow();\n\treturnVal1 = System.DateTime::get_Ticks(&v54 @ X0_v7 (System.DateTime));\nL_0023:\n\treturn returnVal1;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static long GetReliableTicks()
		{
			long num = TryReadTicksFromAndroidRoutine();
			if (num == 0)
			{
				num = DateTime.UtcNow.Ticks;
			}
			return num;
		}

		[Token(Token = "0x6000025")]
		[Address(RVA = "0xBD5430", Offset = "0xBD5430", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = System.Environment::get_TickCount();\n\treturnVal1 = v3 * 0x2710;\n\treturn returnVal1;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static long GetEnvironmentTicks()
		{
			//IL_0017: Expected I8, but got I4
			int tickCount = Environment.TickCount;
			return tickCount * 10000;
		}

		[Token(Token = "0x6000026")]
		[Address(RVA = "0xBD544C", Offset = "0xBD544C", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = UnityEngine.Time::get_realtimeSinceStartup();\n\tv9 = v3 * 10000000f;\n\tv20 = v9 != 0x7F800000;\n\tif (v20) goto L_FFFFFFFF;\n\tgoto L_001C;\nL_001C:\n\treturn returnVal1;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static long GetRealtimeTicks()
		{
			//IL_0055: Expected I8, but got F4
			float realtimeSinceStartup = UnityEngine.Time.realtimeSinceStartup;
			float num = realtimeSinceStartup * 10000000f;
			if (num == float.PositiveInfinity)
			{
				return long.MinValue;
			}
			return (long)num;
		}

		[Token(Token = "0x6000027")]
		[Address(RVA = "0xBD5108", Offset = "0xBD5108", Length = "0x328")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv14 = UnityEngine.AndroidJavaClass;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv42 = Il2CppMethodInfo;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv64 = Il2CppMethodInfo;\n\tv65 = \"il2cpp_codegen_initialize_runtime_metadata\"(v64, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv76 = CodeStage.AntiCheat.Utils.TimeUtils;\n\tv77 = \"il2cpp_codegen_initialize_runtime_metadata\"(v76, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv114 = \"net.codestage.actk.androidnative.ACTkAndroidRoutines\";\n\tv115 = \"il2cpp_codegen_initialize_runtime_metadata\"(v114, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv122 = \"GetSystemNanoTime\";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v122, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A353E8]) = v35;\nL_0023:\n\tv39 = ~v37.androidTimeReadAttemptWasMade;\n\tv40 = ~v39;\n\tif (v40) goto L_0038;\n\tv37.androidTimeReadAttemptWasMade = 1;\n\tv48 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v48, \"net.codestage.actk.androidnative.ACTkAndroidRoutines\");\n\tv56.routinesClass = v48;\nL_0038:\n\tv62 = v60.routinesClass == 0;\n\tif (v62) goto L_FFFFFFFF;\n\tgoto L_0049;\n\tv80 = System.Array::Empty();\nL_0049:\n\tgoto L_004E;\n\tv116 = 0xB348B0(v84, v51, v49, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_004E:\n\tgoto L_0056;\n\tv123 = \"il2cpp_codegen_runtime_class_init\"(v117, v51, v49, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0056:\n\tgoto L_0061;\n\tv130 = 0xB348B0(v126, v51, v49, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0061:\n\tv137 = UnityEngine.AndroidJavaObject::CallStatic(v60.routinesClass, \"GetSystemNanoTime\", v133.Value);\n\t// 102 NotImplemented \"Instruction SMULH not yet implemented.\"\n\tv108 = 0xA3D70A3D70A3D70B + v137;\n\tv102 = v108 >> 6;\n\tv91 = v108 >> 0x3F;\n\treturnVal1 = v102 + v91;\n\tgoto L_00EF;\n\tgoto L_00B3;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX19 = X0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_00FA;\n\tX0 = X19;\n\tX0 = 0x1854E70(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = X0;\n\tX0 = *([19352D8]);\n\tX0 = 0xAD94AC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X19]);\n\tX1 = *([X8]);\n\tX0 = 0xAD9AE8(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_00A7;\n\tX20 = *([X19]);\n\tX0 = 0x1854E80(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([19352E0]);\n\tX0 = 0xAD94AC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = X0;\n\tif (TEMP) goto L_0094;\n\tX8 = *([X20]);\n\tX0 = X20;\n\tX9 = *([X8+168]);\n\tX1 = *([X8+170]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = X0;\n\tgoto L_0095;\nL_0094:\n\tX1 = 0;\nL_0095:\n\tX0 = X19;\n\tX2 = 0;\n\tX0 = System.String::Concat(X0, X1, X2);\n\tX19 = X0;\n\tX0 = *([1935278]);\n\tX0 = 0xAD94AC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00A1;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00A1:\n\tX0 = X19;\n\tX1 = 0;\n\tUnityEngine.Debug::LogError(X0, X1);\n\tX20 = *([19352A8]);\n\tgoto L_0038;\nL_00A7:\n\tX0 = 8;\n\tX0 = 0x1854E90(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X19]);\n\t*([X0]) = X8;\n\tX1 = X1 + 0xF88;\n\tX2 = 0;\n\tX0 = 0x1854EA0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_00F8;\n\tX19 = X0;\n\tX0 = 0x1854E80(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_00FA;\nL_00B3:\n\tX19 = X0;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_00FA;\n\tX0 = X19;\n\tX0 = 0x1854E70(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = X0;\n\tX0 = *([19352D8]);\n\tX0 = 0xAD94AC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X19]);\n\tX1 = *([X8]);\n\tX0 = 0xAD9AE8(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_00F0;\n\tX20 = *([X19]);\n\tX0 = 0x1854E80(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([19352E8]);\n\tX0 = 0xAD94AC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = X0;\n\tif (TEMP) goto L_00DA;\n\tX8 = *([X20]);\n\tX0 = X20;\n\tX9 = *([X8+168]);\n\tX1 = *([X8+170]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = X0;\n\tgoto L_00DB;\nL_00DA:\n\tX1 = 0;\nL_00DB:\n\tX0 = X19;\n\tX2 = 0;\n\tX0 = System.String::Concat(X0, X1, X2);\n\tX19 = X0;\n\tX0 = *([1935278]);\n\tX0 = 0xAD94AC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00E7;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00E7:\n\tX0 = X19;\n\tX1 = 0;\n\tUnityEngine.Debug::LogError(X0, X1);\nL_00EF:\n\treturn returnVal1;\nL_00F0:\n\tX0 = 8;\n\tX0 = 0x1854E90(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X19]);\n\t*([X0]) = X8;\n\tX1 = X1 + 0xF88;\n\tX2 = 0;\n\tX0 = 0x1854EA0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00F8:\n\tX19 = X0;\n\tX0 = 0x1854E80(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00FA:\n\tX0 = X19;\n\tX0 = 0xBD3CD0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = 0x9DACB4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn X0;\n// 91 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static long TryReadTicksFromAndroidRoutine()
		{
			//IL_00b9: Expected I8, but got I4
			if (!androidTimeReadAttemptWasMade)
			{
				androidTimeReadAttemptWasMade = true;
				AndroidJavaClass androidJavaClass = new AndroidJavaClass("net.codestage.actk.androidnative.ACTkAndroidRoutines");
				routinesClass = androidJavaClass;
			}
			if (routinesClass != null)
			{
				long num = routinesClass.CallStatic<long>("GetSystemNanoTime", Array.Empty<object>());
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction SMULH not yet implemented.\"");
				long num2 = -6640827866535438581L + num;
				long num3 = num2 >> 6;
				long num4 = num2 >> 63;
				return num3 + num4;
			}
			return 0L;
		}

		[Token(Token = "0x6000028")]
		[Address(RVA = "0xBD5484", Offset = "0xBD5484", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = CodeStage.AntiCheat.Utils.TimeUtils;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A353E9]) = v37;\nL_0016:\n\tv41 = v39.routinesClass == 0;\n\tif (v41) goto L_0021;\n\tUnityEngine.AndroidJavaObject::Dispose(v39.routinesClass);\nL_0021:\n\tSystem.Object::Finalize(this);\n\treturn;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX21 = X0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_003F;\n\tX0 = X21;\n\tX0 = 0x1854E70(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = *([X0]);\n\tX0 = 0x1854E80(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = X19;\n\tX1 = 0;\n\tSystem.Object::Finalize(X0, X1);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0041;\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tX30 = stack[0];\n\tX21 = stack[8];\n\t// 61 ShiftStack 32\n\treturn;\nL_003F:\n\tX20 = 0;\n\tgoto L_0044;\nL_0041:\n\tX0 = X20;\n\tX0 = OutOfMemoryException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = X0;\nL_0044:\n\tX0 = X19;\n\tX1 = 0;\n\tSystem.Object::Finalize(X0, X1);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_004C;\n\tX0 = X21;\n\tX0 = 0xBD3CD0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_004C:\n\tX0 = X20;\n\tX0 = OutOfMemoryException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = 0x9DACB4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		~TimeUtils()
		{
			if (routinesClass != null)
			{
				routinesClass.Dispose();
			}
			base.Finalize();
		}

		[Token(Token = "0x6000029")]
		[Address(RVA = "0xBD5554", Offset = "0xBD5554", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TimeUtils()
		{
		}
	}
}
