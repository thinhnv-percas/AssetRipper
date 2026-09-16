using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace CodeStage.AntiCheat.Detectors
{
	[HelpURL("http://codestage.net/uas_files/actk/api/class_code_stage_1_1_anti_cheat_1_1_detectors_1_1_injection_detector.html")]
	[DisallowMultipleComponent]
	[AddComponentMenu("Code Stage/Anti-Cheat Toolkit/Injection Detector")]
	[Token(Token = "0x2000038")]
	public class InjectionDetector : ACTkDetectorBase<InjectionDetector>
	{
		[Token(Token = "0x2000039")]
		public delegate void InjectionDetectedEventHandler(string reason);

		[Token(Token = "0x40000F2")]
		public const string ComponentName = "Injection Detector";

		[Token(Token = "0x40000F3")]
		internal const string FinalLogPrefix = "[ACTk] Injection Detector: ";

		[Token(Token = "0x6000393")]
		[Address(RVA = "0xBEB868", Offset = "0xBEB868", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv43 = \"[ACTk] Injection Detector: is not supported on current platform! This message is harmless.\";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A35527]) = v35;\nL_001A:\n\tgoto L_001E;\n\tv44 = \"il2cpp_codegen_runtime_class_init\"(v36, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001E:\n\tUnityEngine.Debug::Log(\"[ACTk] Injection Detector: is not supported on current platform! This message is harmless.\");\n\treturn 0;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static InjectionDetector AddToSceneOrGetExisting()
		{
			Debug.Log("[ACTk] Injection Detector: is not supported on current platform! This message is harmless.");
			return null;
		}

		[Token(Token = "0x6000394")]
		[Address(RVA = "0xBEB8D8", Offset = "0xBEB8D8", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv43 = \"[ACTk] Injection Detector: is not supported on current platform! This message is harmless.\";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A35528]) = v35;\nL_001A:\n\tgoto L_0022;\n\tv44 = \"il2cpp_codegen_runtime_class_init\"(v36, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0022:\n\tUnityEngine.Debug::Log(\"[ACTk] Injection Detector: is not supported on current platform! This message is harmless.\");\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void StartDetection()
		{
			Debug.Log("[ACTk] Injection Detector: is not supported on current platform! This message is harmless.");
		}

		[Token(Token = "0x6000395")]
		[Address(RVA = "0xBEB940", Offset = "0xBEB940", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv43 = \"[ACTk] Injection Detector: is not supported on current platform! This message is harmless.\";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A35529]) = v35;\nL_001A:\n\tgoto L_0022;\n\tv44 = \"il2cpp_codegen_runtime_class_init\"(v36, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0022:\n\tUnityEngine.Debug::Log(\"[ACTk] Injection Detector: is not supported on current platform! This message is harmless.\");\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void StartDetection(Action<string> callback)
		{
			Debug.Log("[ACTk] Injection Detector: is not supported on current platform! This message is harmless.");
		}

		[Token(Token = "0x6000396")]
		[Address(RVA = "0xBEB9A8", Offset = "0xBEB9A8", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv43 = \"[ACTk] Injection Detector: is not supported on current platform! This message is harmless.\";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A3552A]) = v35;\nL_001A:\n\tgoto L_0022;\n\tv44 = \"il2cpp_codegen_runtime_class_init\"(v36, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0022:\n\tUnityEngine.Debug::Log(\"[ACTk] Injection Detector: is not supported on current platform! This message is harmless.\");\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void StopDetection()
		{
			Debug.Log("[ACTk] Injection Detector: is not supported on current platform! This message is harmless.");
		}

		[Token(Token = "0x6000397")]
		[Address(RVA = "0xBEBA10", Offset = "0xBEBA10", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv43 = \"[ACTk] Injection Detector: is not supported on current platform! This message is harmless.\";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A3552B]) = v35;\nL_001A:\n\tgoto L_0022;\n\tv44 = \"il2cpp_codegen_runtime_class_init\"(v36, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0022:\n\tUnityEngine.Debug::Log(\"[ACTk] Injection Detector: is not supported on current platform! This message is harmless.\");\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Dispose()
		{
			Debug.Log("[ACTk] Injection Detector: is not supported on current platform! This message is harmless.");
		}

		[Token(Token = "0x6000398")]
		[Address(RVA = "0xBEBA78", Offset = "0xBEBA78", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv43 = \"[ACTk] Injection Detector: is not supported on current platform! This message is harmless.\";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A3552C]) = v35;\nL_001A:\n\tgoto L_0022;\n\tv44 = \"il2cpp_codegen_runtime_class_init\"(v36, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0022:\n\tUnityEngine.Debug::Log(\"[ACTk] Injection Detector: is not supported on current platform! This message is harmless.\");\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void StartDetectionAutomatically()
		{
			Debug.Log("[ACTk] Injection Detector: is not supported on current platform! This message is harmless.");
		}

		[Token(Token = "0x6000399")]
		[Address(RVA = "0xBEBAE0", Offset = "0xBEBAE0", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = \"Injection Detector\";\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A3552D]) = v34;\nL_0016:\n\treturn \"Injection Detector\";\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override string GetComponentName()
		{
			return "Injection Detector";
		}

		[Token(Token = "0x600039A")]
		[Address(RVA = "0xBEBB20", Offset = "0xBEBB20", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A3552E]) = v37;\nL_001A:\n\tCodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<CodeStage.AntiCheat.Detectors.InjectionDetector>::.ctor(this);\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public InjectionDetector()
		{
		}
	}
}
