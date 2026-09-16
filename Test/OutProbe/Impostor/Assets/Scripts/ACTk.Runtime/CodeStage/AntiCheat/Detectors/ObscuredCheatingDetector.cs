using System;
using AssetRipperInjected;
using CodeStage.AntiCheat.Common;
using Cpp2ILInjected;
using UnityEngine;

namespace CodeStage.AntiCheat.Detectors
{
	[HelpURL("http://codestage.net/uas_files/actk/api/class_code_stage_1_1_anti_cheat_1_1_detectors_1_1_obscured_cheating_detector.html")]
	[DisallowMultipleComponent]
	[AddComponentMenu("Code Stage/Anti-Cheat Toolkit/Obscured Cheating Detector")]
	[Token(Token = "0x200003A")]
	public class ObscuredCheatingDetector : ACTkDetectorBase<ObscuredCheatingDetector>
	{
		[Token(Token = "0x40000F4")]
		public const string ComponentName = "Obscured Cheating Detector";

		[Token(Token = "0x40000F5")]
		internal const string FinalLogPrefix = "[ACTk] Obscured Cheating Detector: ";

		[Tooltip("Max allowed difference between encrypted and fake values in ObscuredDouble. Increase in case of false positives.")]
		[Token(Token = "0x40000F6")]
		[FieldOffset(Offset = "0x50")]
		public double doubleEpsilon;

		[Tooltip("Max allowed difference between encrypted and fake values in ObscuredFloat. Increase in case of false positives.")]
		[Token(Token = "0x40000F7")]
		[FieldOffset(Offset = "0x58")]
		public float floatEpsilon;

		[Tooltip("Max allowed difference between encrypted and fake values in ObscuredVector2. Increase in case of false positives.")]
		[Token(Token = "0x40000F8")]
		[FieldOffset(Offset = "0x5C")]
		public float vector2Epsilon;

		[Tooltip("Max allowed difference between encrypted and fake values in ObscuredVector3. Increase in case of false positives.")]
		[Token(Token = "0x40000F9")]
		[FieldOffset(Offset = "0x60")]
		public float vector3Epsilon;

		[Tooltip("Max allowed difference between encrypted and fake values in ObscuredQuaternion. Increase in case of false positives.")]
		[Token(Token = "0x40000FA")]
		[FieldOffset(Offset = "0x64")]
		public float quaternionEpsilon;

		[Token(Token = "0x1700002F")]
		internal static bool ExistsAndIsRunning
		{
			[Token(Token = "0x60003A4")]
			[Address(RVA = "0xBEC178", Offset = "0xBEC178", Length = "0xC8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv43 = Il2CppMethodInfo;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A35534]) = v35;\nL_001A:\n\tgoto L_0022;\n\tv44 = 0xB348B0(v37, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0022:\n\tgoto L_0026;\n\tv52 = 0xB348B0(v47, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0026:\n\tv56 = v54.<Instance>k__BackingField == 0;\n\tif (v56) goto L_FFFFFFFF;\n\tgoto L_0036;\n\tv64 = 0xB348B0(v58, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0036:\n\tgoto L_0039;\n\tv108 = 0xB348B0(v67, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0039:\n\tv111 = v110.<Instance>k__BackingField;\n\tv89 = v111.isRunning == 0;\n\tv74 = ~v89;\n\tgoto L_004E;\nL_004E:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if ((object)KeepAliveBehaviour<ObscuredCheatingDetector>.Instance != null)
				{
					ObscuredCheatingDetector obscuredCheatingDetector = KeepAliveBehaviour<ObscuredCheatingDetector>.Instance;
					bool flag = !obscuredCheatingDetector.IsRunning;
					return !flag;
				}
				return false;
			}
		}

		[Token(Token = "0x600039F")]
		[Address(RVA = "0xBEBC44", Offset = "0xBEBC44", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A3552F]) = v34;\nL_0016:\n\treturnVal1 = CodeStage.AntiCheat.Common.KeepAliveBehaviour`1<CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector>::get_GetOrCreateInstance();\n\treturn returnVal1;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ObscuredCheatingDetector AddToSceneOrGetExisting()
		{
			return KeepAliveBehaviour<ObscuredCheatingDetector>.GetOrCreateInstance;
		}

		[Token(Token = "0x60003A0")]
		[Address(RVA = "0xBEBC84", Offset = "0xBEBC84", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv43 = Il2CppMethodInfo;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv56 = UnityEngine.Object;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv67 = \"[ACTk] Obscured Cheating Detector: can't be started since it doesn't exists in scene or not yet initialized!\";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v67, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A35530]) = v35;\nL_0020:\n\tgoto L_002A;\n\tv45 = 0xB348B0(v37, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_002A:\n\tgoto L_0032;\n\tv58 = 0xB348B0(v49, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0032:\n\tgoto L_0038;\n\tv68 = v60;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v68, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0038:\n\tv74 = UnityEngine.Object::op_Inequality(v61.<Instance>k__BackingField, 0);\n\tv76 = v74 == 0;\n\tif (v76) goto L_0059;\n\tgoto L_004A;\n\tv89 = 0xB348B0(v78, v72, v73, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_004A:\n\tgoto L_0051;\n\tv103 = 0xB348B0(v92, v72, v73, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0051:\n\treturnVal1 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::StartDetectionInternal(v105.<Instance>k__BackingField, 0);\n\tgoto L_0065;\nL_0059:\n\tgoto L_005F;\n\tv97 = \"il2cpp_codegen_runtime_class_init\"(v85, v72, v73, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_005F:\n\tUnityEngine.Debug::LogError(\"[ACTk] Obscured Cheating Detector: can't be started since it doesn't exists in scene or not yet initialized!\");\nL_0065:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 71 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ObscuredCheatingDetector StartDetection()
		{
			if (KeepAliveBehaviour<ObscuredCheatingDetector>.Instance != null)
			{
				return KeepAliveBehaviour<ObscuredCheatingDetector>.Instance.StartDetectionInternal(null);
			}
			Debug.LogError("[ACTk] Obscured Cheating Detector: can't be started since it doesn't exists in scene or not yet initialized!");
			return null;
		}

		[Token(Token = "0x60003A1")]
		[Address(RVA = "0xBEBF38", Offset = "0xBEBF38", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35531]) = v37;\nL_0014:\n\tv39 = CodeStage.AntiCheat.Common.KeepAliveBehaviour`1<CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector>::get_GetOrCreateInstance();\n\treturnVal1 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::StartDetectionInternal(v39, callback);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ObscuredCheatingDetector StartDetection(Action callback)
		{
			ObscuredCheatingDetector getOrCreateInstance = KeepAliveBehaviour<ObscuredCheatingDetector>.GetOrCreateInstance;
			return getOrCreateInstance.StartDetectionInternal(callback);
		}

		[Token(Token = "0x60003A2")]
		[Address(RVA = "0xBEBF8C", Offset = "0xBEBF8C", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv43 = UnityEngine.Object;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A35532]) = v35;\nL_001A:\n\tgoto L_0024;\n\tv44 = 0xB348B0(v37, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0024:\n\tgoto L_002C;\n\tv54 = 0xB348B0(v48, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_002C:\n\tgoto L_0032;\n\tv62 = v56;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v62, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0032:\n\tv68 = UnityEngine.Object::op_Inequality(v57.<Instance>k__BackingField, 0);\n\tv70 = v68 == 0;\n\tif (v70) goto L_0056;\n\tgoto L_0044;\n\tv80 = 0xB348B0(v72, v66, v67, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0044:\n\tgoto L_0047;\n\tv106 = 0xB348B0(v83, v66, v67, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0047:\n\tv95 = v101.<Instance>k__BackingField;\n\tv100 = *([v95 @ X0_v13 (CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector)]);\n\tv91 = *([v100 @ X8_v13 (Il2CppClass<CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector>)+208]);\n\tv93 = *([v100 @ X8_v13 (Il2CppClass<CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector>)+210]);\n\t// 81 IndirectJump v91 @ X2_v2, v95 @ X0_v13 (CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector), v95 @ X0_v13 (CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector), v93 @ X1_v2, v91 @ X2_v2, v18 @ X3, v19 @ X4, v20 @ X5, v21 @ X6, v22 @ X7, v23 @ V0, v24 @ V1, v25 @ V2, v26 @ V3, v27 @ V4, v28 @ V5, v29 @ V6, v30 @ V7\nL_0056:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void StopDetection()
		{
			//IL_005b: Expected I, but got O
			//IL_006b: Expected O, but got I
			//IL_007b: Expected O, but got I
			if (KeepAliveBehaviour<ObscuredCheatingDetector>.Instance != null)
			{
				ObscuredCheatingDetector obscuredCheatingDetector = KeepAliveBehaviour<ObscuredCheatingDetector>.Instance;
				nint num = (nint)obscuredCheatingDetector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X8_v13 (Il2CppClass<CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector>)+208]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X8_v13 (Il2CppClass<CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector>)+210]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v91 @ X2_v2 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x60003A3")]
		[Address(RVA = "0xBEC084", Offset = "0xBEC084", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv43 = UnityEngine.Object;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A35533]) = v35;\nL_001A:\n\tgoto L_0024;\n\tv44 = 0xB348B0(v37, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0024:\n\tgoto L_002C;\n\tv54 = 0xB348B0(v48, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_002C:\n\tgoto L_0032;\n\tv62 = v56;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v62, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0032:\n\tv68 = UnityEngine.Object::op_Inequality(v57.<Instance>k__BackingField, 0);\n\tv70 = v68 == 0;\n\tif (v70) goto L_0056;\n\tgoto L_0044;\n\tv80 = 0xB348B0(v72, v66, v67, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0044:\n\tgoto L_0047;\n\tv106 = 0xB348B0(v83, v66, v67, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0047:\n\tv95 = v101.<Instance>k__BackingField;\n\tv100 = *([v95 @ X0_v13 (CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector)]);\n\tv91 = *([v100 @ X8_v13 (Il2CppClass<CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector>)+1C8]);\n\tv93 = *([v100 @ X8_v13 (Il2CppClass<CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector>)+1D0]);\n\t// 81 IndirectJump v91 @ X2_v2, v95 @ X0_v13 (CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector), v95 @ X0_v13 (CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector), v93 @ X1_v2, v91 @ X2_v2, v18 @ X3, v19 @ X4, v20 @ X5, v21 @ X6, v22 @ X7, v23 @ V0, v24 @ V1, v25 @ V2, v26 @ V3, v27 @ V4, v28 @ V5, v29 @ V6, v30 @ V7\nL_0056:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Dispose()
		{
			//IL_005b: Expected I, but got O
			//IL_006b: Expected O, but got I
			//IL_007b: Expected O, but got I
			if (KeepAliveBehaviour<ObscuredCheatingDetector>.Instance != null)
			{
				ObscuredCheatingDetector obscuredCheatingDetector = KeepAliveBehaviour<ObscuredCheatingDetector>.Instance;
				nint num = (nint)obscuredCheatingDetector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X8_v13 (Il2CppClass<CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector>)+1C8]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X8_v13 (Il2CppClass<CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector>)+1D0]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v91 @ X2_v2 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x60003A5")]
		[Address(RVA = "0xBEC240", Offset = "0xBEC240", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35535]) = v37;\nL_0019:\n\tthis.doubleEpsilon = 0.0001d;\n\tthis.floatEpsilon = *([407B00]);\n\tCodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector>::.ctor(this);\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private ObscuredCheatingDetector()
		{
			//IL_002c: Expected F4, but got I
			base._002Ector();
			doubleEpsilon = 0.0001;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [407B00]");
			floatEpsilon = 0f;
		}

		[Token(Token = "0x60003A6")]
		[Address(RVA = "0xBEBDB8", Offset = "0xBEBDB8", Length = "0x180")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, callback, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv43 = UnityEngine.Debug;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, callback, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv55 = \"[ACTk] Obscured Cheating Detector: has properly configured Detection Event in the inspector, but still get started with Action callback. Both Action and Detection Event will be called on detection. Are you sure you wish to do this?\";\n\tv56 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, callback, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv63 = \"[ACTk] Obscured Cheating Detector: disabled but StartDetection still called from somewhere (see stack trace for this message)!\";\n\tv64 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, callback, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv81 = \"[ACTk] Obscured Cheating Detector: was started without any callbacks. Please configure Detection Event in the inspector, or pass the callback Action to the StartDetection method.\";\n\tv82 = \"il2cpp_codegen_initialize_runtime_metadata\"(v81, callback, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv110 = \"[ACTk] Obscured Cheating Detector: already running!\";\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v110, callback, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A35536]) = v37;\nL_0024:\n\tv41 = ~this.isRunning;\n\tif (v41) goto L_0032;\n\tgoto L_FFFFFFFF;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v45, callback, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tgoto L_0053;\nL_0032:\n\tv53 = UnityEngine.Behaviour::get_enabled(this);\n\tv61 = v53 == 0;\n\tif (v61) goto L_004C;\n\tv76 = callback == 0;\n\tif (v76) goto L_005B;\n\tv104 = ~this.detectionEventHasListener;\n\tif (v104) goto L_0062;\n\tgoto L_0046;\n\tv128 = \"il2cpp_codegen_runtime_class_init\"(v111, v52, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0046:\n\tUnityEngine.Debug::LogWarning(\"[ACTk] Obscured Cheating Detector: has properly configured Detection Event in the inspector, but still get started with Action callback. Both Action and Detection Event will be called on detection. Are you sure you wish to do this?\", this);\n\tgoto L_0062;\nL_004C:\n\tgoto L_FFFFFFFF;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v77, v52, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0053:\n\tUnityEngine.Debug::LogWarning(v66, this);\nL_005A:\n\treturn this;\nL_005B:\n\tv105 = ~this.detectionEventHasListener;\n\tif (v105) goto L_006A;\nL_0062:\n\tCodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector>::add_CheatDetected(this, callback);\n\tthis.started = 0x101;\n\tgoto L_005A;\nL_006A:\n\tgoto L_0071;\n\tv131 = \"il2cpp_codegen_runtime_class_init\"(v125, v52, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0071:\n\tUnityEngine.Debug::LogWarning(\"[ACTk] Obscured Cheating Detector: was started without any callbacks. Please configure Detection Event in the inspector, or pass the callback Action to the StartDetection method.\", this);\n\tUnityEngine.Behaviour::set_enabled(this, 0);\n\tgoto L_005A;\n\treturn X0;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private ObscuredCheatingDetector StartDetectionInternal(Action callback)
		{
			string message;
			if (IsRunning)
			{
				message = "[ACTk] Obscured Cheating Detector: already running!";
			}
			else
			{
				if (base.enabled)
				{
					if (callback != null)
					{
						if (detectionEventHasListener)
						{
							Debug.LogWarning("[ACTk] Obscured Cheating Detector: has properly configured Detection Event in the inspector, but still get started with Action callback. Both Action and Detection Event will be called on detection. Are you sure you wish to do this?", this);
						}
					}
					else if (!detectionEventHasListener)
					{
						Debug.LogWarning("[ACTk] Obscured Cheating Detector: was started without any callbacks. Please configure Detection Event in the inspector, or pass the callback Action to the StartDetection method.", this);
						base.enabled = false;
						goto IL_009f;
					}
					base.CheatDetected += callback;
					started = true;
					goto IL_009f;
				}
				message = "[ACTk] Obscured Cheating Detector: disabled but StartDetection still called from somewhere (see stack trace for this message)!";
			}
			Debug.LogWarning(message, this);
			goto IL_009f;
			IL_009f:
			return this;
		}

		[Token(Token = "0x60003A7")]
		[Address(RVA = "0xBEC2A8", Offset = "0xBEC2A8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv1 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::StartDetectionInternal(this, 0);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void StartDetectionAutomatically()
		{
			ObscuredCheatingDetector obscuredCheatingDetector = StartDetectionInternal(null);
		}

		[Token(Token = "0x60003A8")]
		[Address(RVA = "0xBEC2B0", Offset = "0xBEC2B0", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = \"Obscured Cheating Detector\";\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A35537]) = v34;\nL_0016:\n\treturn \"Obscured Cheating Detector\";\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override string GetComponentName()
		{
			return "Obscured Cheating Detector";
		}
	}
}
