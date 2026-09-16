using System;
using AssetRipperInjected;
using CodeStage.AntiCheat.Common;
using CodeStage.AntiCheat.Utils;
using Cpp2ILInjected;
using UnityEngine;

namespace CodeStage.AntiCheat.Detectors
{
	[AddComponentMenu("Code Stage/Anti-Cheat Toolkit/Speed Hack Detector")]
	[DisallowMultipleComponent]
	[HelpURL("http://codestage.net/uas_files/actk/api/class_code_stage_1_1_anti_cheat_1_1_detectors_1_1_speed_hack_detector.html")]
	[Token(Token = "0x200003B")]
	public class SpeedHackDetector : ACTkDetectorBase<SpeedHackDetector>
	{
		[Token(Token = "0x40000FB")]
		public const string ComponentName = "Speed Hack Detector";

		[Token(Token = "0x40000FC")]
		internal const string FinalLogPrefix = "[ACTk] Speed Hack Detector: ";

		[Tooltip("Time (in seconds) between detector checks.")]
		[Token(Token = "0x40000FD")]
		[FieldOffset(Offset = "0x4C")]
		public float interval;

		[Tooltip("Allowed speed multiplier threshold. Do not set to too low values (e.g. 0 or 0.00*) since there are timer fluctuations on different hardware.")]
		[Range(0.05f, 5f)]
		[Token(Token = "0x40000FE")]
		[FieldOffset(Offset = "0x50")]
		public float threshold;

		[Tooltip("Maximum false positives count allowed before registering speed hack.")]
		[Token(Token = "0x40000FF")]
		[FieldOffset(Offset = "0x54")]
		public byte maxFalsePositives;

		[Tooltip("Amount of sequential successful checks before clearing internal false positives counter.\nSet 0 to disable Cool Down feature.")]
		[Token(Token = "0x4000100")]
		[FieldOffset(Offset = "0x58")]
		public int coolDown;

		[Token(Token = "0x4000101")]
		[FieldOffset(Offset = "0x5C")]
		private byte currentFalsePositives;

		[Token(Token = "0x4000102")]
		[FieldOffset(Offset = "0x60")]
		private int currentCooldownShots;

		[Token(Token = "0x4000103")]
		[FieldOffset(Offset = "0x68")]
		private long previousReliableTicks;

		[Token(Token = "0x4000104")]
		[FieldOffset(Offset = "0x70")]
		private long previousVulnerableEnvironmentTicks;

		[Token(Token = "0x4000105")]
		[FieldOffset(Offset = "0x78")]
		private long previousVulnerableRealtimeTicks;

		[Token(Token = "0x60003A9")]
		[Address(RVA = "0xBEC2F0", Offset = "0xBEC2F0", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A35538]) = v34;\nL_0016:\n\treturnVal1 = CodeStage.AntiCheat.Common.KeepAliveBehaviour`1<CodeStage.AntiCheat.Detectors.SpeedHackDetector>::get_GetOrCreateInstance();\n\treturn returnVal1;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static SpeedHackDetector AddToSceneOrGetExisting()
		{
			return KeepAliveBehaviour<SpeedHackDetector>.GetOrCreateInstance;
		}

		[Token(Token = "0x60003AA")]
		[Address(RVA = "0xBEC330", Offset = "0xBEC330", Length = "0x1FC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv16 = UnityEngine.Debug;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv45 = Il2CppMethodInfo;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv58 = UnityEngine.Object;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv69 = \"[ACTk] Speed Hack Detector: can't be started since it doesn't exists in scene or not yet initialized!\";\n\tv34 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv37 = 1;\n\t*([1A35539]) = v37;\nL_0021:\n\tgoto L_002B;\n\tv47 = 0xB348B0(v39, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_002B:\n\tgoto L_0033;\n\tv60 = 0xB348B0(v51, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_0033:\n\tgoto L_0039;\n\tv70 = v62;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v70, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_0039:\n\tv76 = UnityEngine.Object::op_Inequality(v63.<Instance>k__BackingField, 0);\n\tv78 = v76 == 0;\n\tif (v78) goto L_00A0;\n\tgoto L_004B;\n\tv93 = 0xB348B0(v80, v74, v75, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_004B:\n\tgoto L_0050;\n\tv105 = 0xB348B0(v96, v74, v75, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_0050:\n\tv148 = v108.<Instance>k__BackingField;\n\tgoto L_005F;\n\tv116 = v109;\n\tv117 = 0xB348B0(v116, v74, v75, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv120 = v117;\nL_005F:\n\tgoto L_0062;\n\tv154 = 0xB348B0(v122, v74, v75, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_0062:\n\tv157 = v156.<Instance>k__BackingField;\n\tgoto L_0074;\n\tv190 = 0xB348B0(v179, v74, v75, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_0074:\n\tgoto L_0077;\n\tv198 = 0xB348B0(v193, v74, v75, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_0077:\n\tv189 = v199.<Instance>k__BackingField;\n\tgoto L_0089;\n\tv205 = 0xB348B0(v201, v74, v75, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_0089:\n\tgoto L_008C;\n\tv213 = 0xB348B0(v208, v74, v75, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_008C:\n\tv145 = v214.<Instance>k__BackingField;\n\tv141 = CodeStage.AntiCheat.Detectors.SpeedHackDetector::StartDetectionInternal(v108.<Instance>k__BackingField, 0, v157.interval, v189.maxFalsePositives, v145.coolDown);\n\tgoto L_00AC;\nL_00A0:\n\tgoto L_00A4;\n\tv101 = \"il2cpp_codegen_runtime_class_init\"(v88, v74, v75, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_00A4:\n\tUnityEngine.Debug::LogError(\"[ACTk] Speed Hack Detector: can't be started since it doesn't exists in scene or not yet initialized!\");\nL_00AC:\n\treturn v148;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 124 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static SpeedHackDetector StartDetection()
		{
			SpeedHackDetector result;
			if (KeepAliveBehaviour<SpeedHackDetector>.Instance != null)
			{
				result = KeepAliveBehaviour<SpeedHackDetector>.Instance;
				SpeedHackDetector speedHackDetector = KeepAliveBehaviour<SpeedHackDetector>.Instance;
				SpeedHackDetector speedHackDetector2 = KeepAliveBehaviour<SpeedHackDetector>.Instance;
				SpeedHackDetector speedHackDetector3 = KeepAliveBehaviour<SpeedHackDetector>.Instance;
				SpeedHackDetector speedHackDetector4 = KeepAliveBehaviour<SpeedHackDetector>.Instance.StartDetectionInternal(null, speedHackDetector.interval, speedHackDetector2.maxFalsePositives, speedHackDetector3.coolDown);
			}
			else
			{
				Debug.LogError("[ACTk] Speed Hack Detector: can't be started since it doesn't exists in scene or not yet initialized!");
				result = null;
			}
			return result;
		}

		[Token(Token = "0x60003AB")]
		[Address(RVA = "0xBEC6E4", Offset = "0xBEC6E4", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A3553A]) = v37;\nL_0014:\n\tv39 = CodeStage.AntiCheat.Common.KeepAliveBehaviour`1<CodeStage.AntiCheat.Detectors.SpeedHackDetector>::get_GetOrCreateInstance();\n\treturnVal1 = CodeStage.AntiCheat.Detectors.SpeedHackDetector::StartDetection(callback, v39.interval);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static SpeedHackDetector StartDetection(Action callback)
		{
			SpeedHackDetector getOrCreateInstance = KeepAliveBehaviour<SpeedHackDetector>.GetOrCreateInstance;
			return StartDetection(callback, getOrCreateInstance.interval);
		}

		[Token(Token = "0x60003AC")]
		[Address(RVA = "0xBEC73C", Offset = "0xBEC73C", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, interval, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A3553B]) = v40;\nL_0016:\n\tv42 = CodeStage.AntiCheat.Common.KeepAliveBehaviour`1<CodeStage.AntiCheat.Detectors.SpeedHackDetector>::get_GetOrCreateInstance();\n\treturnVal1 = CodeStage.AntiCheat.Detectors.SpeedHackDetector::StartDetection(callback, interval, v42.maxFalsePositives);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static SpeedHackDetector StartDetection(Action callback, float interval)
		{
			SpeedHackDetector getOrCreateInstance = KeepAliveBehaviour<SpeedHackDetector>.GetOrCreateInstance;
			return StartDetection(callback, interval, getOrCreateInstance.maxFalsePositives);
		}

		[Token(Token = "0x60003AD")]
		[Address(RVA = "0xBEC7A4", Offset = "0xBEC7A4", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv26 = Il2CppMethodInfo;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, maxFalsePositives, methodInfo, v29, v30, v31, v32, v33, interval, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 1;\n\t*([1A3553C]) = v43;\nL_0018:\n\tv45 = CodeStage.AntiCheat.Common.KeepAliveBehaviour`1<CodeStage.AntiCheat.Detectors.SpeedHackDetector>::get_GetOrCreateInstance();\n\treturnVal1 = CodeStage.AntiCheat.Detectors.SpeedHackDetector::StartDetection(callback, interval, maxFalsePositives, v45.coolDown);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static SpeedHackDetector StartDetection(Action callback, float interval, byte maxFalsePositives)
		{
			SpeedHackDetector getOrCreateInstance = KeepAliveBehaviour<SpeedHackDetector>.GetOrCreateInstance;
			return StartDetection(callback, interval, maxFalsePositives, getOrCreateInstance.coolDown);
		}

		[Token(Token = "0x60003AE")]
		[Address(RVA = "0xBEC81C", Offset = "0xBEC81C", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv30 = Il2CppMethodInfo;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, maxFalsePositives, coolDown, methodInfo, v33, v34, v35, v36, interval, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 1;\n\t*([1A3553D]) = v46;\nL_001A:\n\tv48 = CodeStage.AntiCheat.Common.KeepAliveBehaviour`1<CodeStage.AntiCheat.Detectors.SpeedHackDetector>::get_GetOrCreateInstance();\n\treturnVal1 = CodeStage.AntiCheat.Detectors.SpeedHackDetector::StartDetectionInternal(v48, callback, interval, maxFalsePositives, coolDown);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static SpeedHackDetector StartDetection(Action callback, float interval, byte maxFalsePositives, int coolDown)
		{
			SpeedHackDetector getOrCreateInstance = KeepAliveBehaviour<SpeedHackDetector>.GetOrCreateInstance;
			return getOrCreateInstance.StartDetectionInternal(callback, interval, maxFalsePositives, coolDown);
		}

		[Token(Token = "0x60003AF")]
		[Address(RVA = "0xBEC898", Offset = "0xBEC898", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv43 = UnityEngine.Object;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A3553E]) = v35;\nL_001A:\n\tgoto L_0024;\n\tv44 = 0xB348B0(v37, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0024:\n\tgoto L_002C;\n\tv54 = 0xB348B0(v48, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_002C:\n\tgoto L_0032;\n\tv62 = v56;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v62, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0032:\n\tv68 = UnityEngine.Object::op_Inequality(v57.<Instance>k__BackingField, 0);\n\tv70 = v68 == 0;\n\tif (v70) goto L_0056;\n\tgoto L_0044;\n\tv80 = 0xB348B0(v72, v66, v67, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0044:\n\tgoto L_0047;\n\tv106 = 0xB348B0(v83, v66, v67, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0047:\n\tv95 = v101.<Instance>k__BackingField;\n\tv100 = *([v95 @ X0_v13 (CodeStage.AntiCheat.Detectors.SpeedHackDetector)]);\n\tv91 = *([v100 @ X8_v13 (Il2CppClass<CodeStage.AntiCheat.Detectors.SpeedHackDetector>)+208]);\n\tv93 = *([v100 @ X8_v13 (Il2CppClass<CodeStage.AntiCheat.Detectors.SpeedHackDetector>)+210]);\n\t// 81 IndirectJump v91 @ X2_v2, v95 @ X0_v13 (CodeStage.AntiCheat.Detectors.SpeedHackDetector), v95 @ X0_v13 (CodeStage.AntiCheat.Detectors.SpeedHackDetector), v93 @ X1_v2, v91 @ X2_v2, v18 @ X3, v19 @ X4, v20 @ X5, v21 @ X6, v22 @ X7, v23 @ V0, v24 @ V1, v25 @ V2, v26 @ V3, v27 @ V4, v28 @ V5, v29 @ V6, v30 @ V7\nL_0056:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void StopDetection()
		{
			//IL_005b: Expected I, but got O
			//IL_006b: Expected O, but got I
			//IL_007b: Expected O, but got I
			if (KeepAliveBehaviour<SpeedHackDetector>.Instance != null)
			{
				SpeedHackDetector speedHackDetector = KeepAliveBehaviour<SpeedHackDetector>.Instance;
				nint num = (nint)speedHackDetector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X8_v13 (Il2CppClass<CodeStage.AntiCheat.Detectors.SpeedHackDetector>)+208]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X8_v13 (Il2CppClass<CodeStage.AntiCheat.Detectors.SpeedHackDetector>)+210]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v91 @ X2_v2 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x60003B0")]
		[Address(RVA = "0xBEC990", Offset = "0xBEC990", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv43 = UnityEngine.Object;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A3553F]) = v35;\nL_001A:\n\tgoto L_0024;\n\tv44 = 0xB348B0(v37, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0024:\n\tgoto L_002C;\n\tv54 = 0xB348B0(v48, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_002C:\n\tgoto L_0032;\n\tv62 = v56;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v62, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0032:\n\tv68 = UnityEngine.Object::op_Inequality(v57.<Instance>k__BackingField, 0);\n\tv70 = v68 == 0;\n\tif (v70) goto L_0056;\n\tgoto L_0044;\n\tv80 = 0xB348B0(v72, v66, v67, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0044:\n\tgoto L_0047;\n\tv106 = 0xB348B0(v83, v66, v67, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0047:\n\tv95 = v101.<Instance>k__BackingField;\n\tv100 = *([v95 @ X0_v13 (CodeStage.AntiCheat.Detectors.SpeedHackDetector)]);\n\tv91 = *([v100 @ X8_v13 (Il2CppClass<CodeStage.AntiCheat.Detectors.SpeedHackDetector>)+1C8]);\n\tv93 = *([v100 @ X8_v13 (Il2CppClass<CodeStage.AntiCheat.Detectors.SpeedHackDetector>)+1D0]);\n\t// 81 IndirectJump v91 @ X2_v2, v95 @ X0_v13 (CodeStage.AntiCheat.Detectors.SpeedHackDetector), v95 @ X0_v13 (CodeStage.AntiCheat.Detectors.SpeedHackDetector), v93 @ X1_v2, v91 @ X2_v2, v18 @ X3, v19 @ X4, v20 @ X5, v21 @ X6, v22 @ X7, v23 @ V0, v24 @ V1, v25 @ V2, v26 @ V3, v27 @ V4, v28 @ V5, v29 @ V6, v30 @ V7\nL_0056:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Dispose()
		{
			//IL_005b: Expected I, but got O
			//IL_006b: Expected O, but got I
			//IL_007b: Expected O, but got I
			if (KeepAliveBehaviour<SpeedHackDetector>.Instance != null)
			{
				SpeedHackDetector speedHackDetector = KeepAliveBehaviour<SpeedHackDetector>.Instance;
				nint num = (nint)speedHackDetector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X8_v13 (Il2CppClass<CodeStage.AntiCheat.Detectors.SpeedHackDetector>)+1C8]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X8_v13 (Il2CppClass<CodeStage.AntiCheat.Detectors.SpeedHackDetector>)+1D0]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v91 @ X2_v2 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x60003B1")]
		[Address(RVA = "0xBECA84", Offset = "0xBECA84", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35540]) = v37;\nL_0017:\n\tthis.maxFalsePositives = 3;\n\tthis.interval = 1.3411048258027414E-08d;\n\tthis.coolDown = 0x1E;\n\tCodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<CodeStage.AntiCheat.Detectors.SpeedHackDetector>::.ctor(this);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private SpeedHackDetector()
		{
			maxFalsePositives = 3;
			interval = 1f;
			threshold = 0.2f;
			coolDown = 30;
		}

		[Token(Token = "0x60003B2")]
		[Address(RVA = "0xBECAE8", Offset = "0xBECAE8", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = pause == 0;\n\tv3 = ~v2;\n\tif (v3) goto L_0009;\n\tv6 = ~this.started;\n\tif (v6) goto L_0009;\n\tCodeStage.AntiCheat.Detectors.SpeedHackDetector::ResetLastTicks(this);\n\treturn;\nL_0009:\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnApplicationPause(bool pause)
		{
			if (!pause && IsStarted)
			{
				ResetLastTicks();
			}
		}

		[Token(Token = "0x60003B3")]
		[Address(RVA = "0xBECB30", Offset = "0xBECB30", Length = "0x17C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = System.Math;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 1;\n\t*([1A35541]) = v41;\nL_0015:\n\tv43 = ~this.isRunning;\n\tif (v43) goto L_00B9;\n\tv45 = CodeStage.AntiCheat.Utils.TimeUtils::GetReliableTicks();\n\tv116 = this.interval * 10000000f;\n\tv66 = v116 != 0x7F800000;\n\tif (v66) goto L_FFFFFFFF;\n\tgoto L_0031;\nL_0031:\n\tv103 = v45 - this.previousReliableTicks;\n\tv54 = v103 < v123;\n\tif (v54) goto L_00B9;\n\tv152 = CodeStage.AntiCheat.Utils.TimeUtils::GetEnvironmentTicks();\n\tv154 = CodeStage.AntiCheat.Utils.TimeUtils::GetRealtimeTicks();\n\tv60 = v45 - this.previousReliableTicks;\n\tv58 = v152 - this.previousVulnerableEnvironmentTicks;\n\tgoto L_0055;\n\tv162 = \"il2cpp_codegen_runtime_class_init\"(v157, methodInfo, v25, v26, v27, v28, v29, v30, v116, v113, v106, v34, v35, v36, v37, v38);\nL_0055:\n\tv168 = v58 / v60;\n\t// 87 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv180 = v168 > this.threshold;\n\tif (v180) goto L_0099;\n\tv182 = v154 - this.previousVulnerableRealtimeTicks;\n\tv184 = v182 / v60;\n\t// 106 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv196 = v184 > this.threshold;\n\tif (v196) goto L_0099;\n\tv221 = this.currentFalsePositives == 0;\n\tif (v221) goto L_00AE;\n\tv239 = this.coolDown < 1;\n\tif (v239) goto L_00AE;\n\tv249 = this.currentCooldownShots + 1;\n\tthis.currentCooldownShots = v249;\n\tv240 = v249 < this.coolDown;\n\tif (v240) goto L_00AE;\n\tthis.currentFalsePositives = 0;\n\tgoto L_00AE;\nL_0099:\n\tv211 = this.currentFalsePositives + 1;\n\tthis.currentFalsePositives = v211;\n\tv212 = this.maxFalsePositives < v211;\n\tv213 = ~v212;\n\tif (v213) goto L_00AC;\n\tv226 = CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<CodeStage.AntiCheat.Detectors.SpeedHackDetector>::OnCheatingDetected(this);\n\tgoto L_00AE;\nL_00AC:\n\tthis.currentCooldownShots = 0;\n\tCodeStage.AntiCheat.Detectors.SpeedHackDetector::ResetLastTicks(this);\nL_00AE:\n\tthis.previousReliableTicks = v45;\n\tthis.previousVulnerableEnvironmentTicks = v152;\n\tthis.previousVulnerableRealtimeTicks = v154;\nL_00B9:\n\treturn;\n// 133 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Update()
		{
			//IL_004f: Expected F4, but got I8
			if (!IsRunning)
			{
				return;
			}
			long reliableTicks = TimeUtils.GetReliableTicks();
			float num = interval * 10000000f;
			float num2 = ((num != float.PositiveInfinity) ? num : (-9.223372E+18f));
			long num3 = reliableTicks - previousReliableTicks;
			if ((float)num3 < num2)
			{
				return;
			}
			long environmentTicks = TimeUtils.GetEnvironmentTicks();
			long realtimeTicks = TimeUtils.GetRealtimeTicks();
			long num4 = reliableTicks - previousReliableTicks;
			long num5 = environmentTicks - previousVulnerableEnvironmentTicks;
			long num6 = num5 / num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
			if (!((float)num6 > threshold))
			{
				long num7 = realtimeTicks - previousVulnerableRealtimeTicks;
				long num8 = num7 / num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
				if (!((float)num8 > threshold))
				{
					if (currentFalsePositives != 0 && coolDown >= 1 && ++currentCooldownShots >= coolDown)
					{
						currentFalsePositives = 0;
					}
					goto IL_0204;
				}
			}
			int num9 = currentFalsePositives + 1;
			currentFalsePositives = (byte)num9;
			if (maxFalsePositives < num9)
			{
				base.OnCheatingDetected();
			}
			else
			{
				currentCooldownShots = 0;
				ResetLastTicks();
			}
			goto IL_0204;
			IL_0204:
			previousReliableTicks = reliableTicks;
			previousVulnerableEnvironmentTicks = environmentTicks;
			previousVulnerableRealtimeTicks = realtimeTicks;
		}

		[Token(Token = "0x60003B4")]
		[Address(RVA = "0xBEC52C", Offset = "0xBEC52C", Length = "0x1B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv30 = Il2CppMethodInfo;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, callback, falsePositives, shotsTillCooldown, methodInfo, v33, v34, v35, checkInterval, v36, v37, v38, v39, v40, v41, v42);\n\tv52 = UnityEngine.Debug;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, callback, falsePositives, shotsTillCooldown, methodInfo, v33, v34, v35, checkInterval, v36, v37, v38, v39, v40, v41, v42);\n\tv64 = \"[ACTk] Speed Hack Detector: disabled but StartDetection still called from somewhere (see stack trace for this message)!\";\n\tv65 = \"il2cpp_codegen_initialize_runtime_metadata\"(v64, callback, falsePositives, shotsTillCooldown, methodInfo, v33, v34, v35, checkInterval, v36, v37, v38, v39, v40, v41, v42);\n\tv72 = \"[ACTk] Speed Hack Detector: already running!\";\n\tv73 = \"il2cpp_codegen_initialize_runtime_metadata\"(v72, callback, falsePositives, shotsTillCooldown, methodInfo, v33, v34, v35, checkInterval, v36, v37, v38, v39, v40, v41, v42);\n\tv90 = \"[ACTk] Speed Hack Detector: has properly configured Detection Event in the inspector, but still get started with Action callback. Both Action and Detection Event will be called on detection. Are you sure you wish to do this?\";\n\tv91 = \"il2cpp_codegen_initialize_runtime_metadata\"(v90, callback, falsePositives, shotsTillCooldown, methodInfo, v33, v34, v35, checkInterval, v36, v37, v38, v39, v40, v41, v42);\n\tv122 = \"[ACTk] Speed Hack Detector: was started without any callbacks. Please configure Detection Event in the inspector, or pass the callback Action to the StartDetection method.\";\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v122, callback, falsePositives, shotsTillCooldown, methodInfo, v33, v34, v35, checkInterval, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 1;\n\t*([1A35542]) = v46;\nL_002A:\n\tv50 = ~this.isRunning;\n\tif (v50) goto L_0038;\n\tgoto L_FFFFFFFF;\n\tv66 = \"il2cpp_codegen_runtime_class_init\"(v54, callback, falsePositives, shotsTillCooldown, methodInfo, v33, v34, v35, checkInterval, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_0059;\nL_0038:\n\tv62 = UnityEngine.Behaviour::get_enabled(this);\n\tv70 = v62 == 0;\n\tif (v70) goto L_0052;\n\tv85 = callback == 0;\n\tif (v85) goto L_0064;\n\tv116 = ~this.detectionEventHasListener;\n\tif (v116) goto L_006B;\n\tgoto L_004C;\n\tv141 = \"il2cpp_codegen_runtime_class_init\"(v123, v61, falsePositives, shotsTillCooldown, methodInfo, v33, v34, v35, checkInterval, v36, v37, v38, v39, v40, v41, v42);\nL_004C:\n\tUnityEngine.Debug::LogWarning(\"[ACTk] Speed Hack Detector: has properly configured Detection Event in the inspector, but still get started with Action callback. Both Action and Detection Event will be called on detection. Are you sure you wish to do this?\", this);\n\tgoto L_006B;\nL_0052:\n\tgoto L_FFFFFFFF;\n\tv118 = \"il2cpp_codegen_runtime_class_init\"(v86, v61, falsePositives, shotsTillCooldown, methodInfo, v33, v34, v35, checkInterval, v36, v37, v38, v39, v40, v41, v42);\nL_0059:\n\tUnityEngine.Debug::LogWarning(v75, this);\nL_0063:\n\treturn this;\nL_0064:\n\tv117 = ~this.detectionEventHasListener;\n\tif (v117) goto L_007A;\nL_006B:\n\tCodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<CodeStage.AntiCheat.Detectors.SpeedHackDetector>::add_CheatDetected(this, callback);\n\tthis.interval = checkInterval;\n\tthis.maxFalsePositives = falsePositives;\n\tthis.coolDown = shotsTillCooldown;\n\tCodeStage.AntiCheat.Detectors.SpeedHackDetector::ResetLastTicks(this);\n\tthis.currentFalsePositives = 0;\n\tthis.currentCooldownShots = 0;\n\tthis.started = 0x101;\n\tgoto L_0063;\nL_007A:\n\tgoto L_0081;\n\tv144 = \"il2cpp_codegen_runtime_class_init\"(v138, v61, falsePositives, shotsTillCooldown, methodInfo, v33, v34, v35, checkInterval, v36, v37, v38, v39, v40, v41, v42);\nL_0081:\n\tUnityEngine.Debug::LogWarning(\"[ACTk] Speed Hack Detector: was started without any callbacks. Please configure Detection Event in the inspector, or pass the callback Action to the StartDetection method.\", this);\n\tUnityEngine.Behaviour::set_enabled(this, 0);\n\tgoto L_0063;\n\treturn X0;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private SpeedHackDetector StartDetectionInternal(Action callback, float checkInterval, byte falsePositives, int shotsTillCooldown)
		{
			string message;
			if (IsRunning)
			{
				message = "[ACTk] Speed Hack Detector: already running!";
			}
			else
			{
				if (base.enabled)
				{
					if (callback != null)
					{
						if (detectionEventHasListener)
						{
							Debug.LogWarning("[ACTk] Speed Hack Detector: has properly configured Detection Event in the inspector, but still get started with Action callback. Both Action and Detection Event will be called on detection. Are you sure you wish to do this?", this);
						}
					}
					else if (!detectionEventHasListener)
					{
						Debug.LogWarning("[ACTk] Speed Hack Detector: was started without any callbacks. Please configure Detection Event in the inspector, or pass the callback Action to the StartDetection method.", this);
						base.enabled = false;
						goto IL_009f;
					}
					base.CheatDetected += callback;
					interval = checkInterval;
					maxFalsePositives = falsePositives;
					coolDown = shotsTillCooldown;
					ResetLastTicks();
					currentFalsePositives = 0;
					currentCooldownShots = 0;
					started = true;
					goto IL_009f;
				}
				message = "[ACTk] Speed Hack Detector: disabled but StartDetection still called from somewhere (see stack trace for this message)!";
			}
			Debug.LogWarning(message, this);
			goto IL_009f;
			IL_009f:
			return this;
		}

		[Token(Token = "0x60003B5")]
		[Address(RVA = "0xBECCAC", Offset = "0xBECCAC", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = CodeStage.AntiCheat.Detectors.SpeedHackDetector::StartDetectionInternal(this, 0, this.interval, this.maxFalsePositives, this.coolDown);\n\treturn;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void StartDetectionAutomatically()
		{
			SpeedHackDetector speedHackDetector = StartDetectionInternal(null, interval, maxFalsePositives, coolDown);
		}

		[Token(Token = "0x60003B6")]
		[Address(RVA = "0xBECCC0", Offset = "0xBECCC0", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = \"Speed Hack Detector\";\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A35543]) = v34;\nL_0016:\n\treturn \"Speed Hack Detector\";\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override string GetComponentName()
		{
			return "Speed Hack Detector";
		}

		[Token(Token = "0x60003B7")]
		[Address(RVA = "0xBECAFC", Offset = "0xBECAFC", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = CodeStage.AntiCheat.Utils.TimeUtils::GetReliableTicks();\n\tthis.previousReliableTicks = v7;\n\tv9 = CodeStage.AntiCheat.Utils.TimeUtils::GetEnvironmentTicks();\n\tthis.previousVulnerableEnvironmentTicks = v9;\n\tv11 = CodeStage.AntiCheat.Utils.TimeUtils::GetRealtimeTicks();\n\tthis.previousVulnerableRealtimeTicks = v11;\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ResetLastTicks()
		{
			long reliableTicks = TimeUtils.GetReliableTicks();
			previousReliableTicks = reliableTicks;
			long environmentTicks = TimeUtils.GetEnvironmentTicks();
			previousVulnerableEnvironmentTicks = environmentTicks;
			long realtimeTicks = TimeUtils.GetRealtimeTicks();
			previousVulnerableRealtimeTicks = realtimeTicks;
		}
	}
}
