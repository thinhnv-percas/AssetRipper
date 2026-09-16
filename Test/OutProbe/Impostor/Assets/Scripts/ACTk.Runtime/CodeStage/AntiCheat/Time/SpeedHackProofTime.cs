using System;
using AssetRipperInjected;
using CodeStage.AntiCheat.Common;
using CodeStage.AntiCheat.Detectors;
using CodeStage.AntiCheat.Utils;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeStage.AntiCheat.Time
{
	[DisallowMultipleComponent]
	[AddComponentMenu(null)]
	[Token(Token = "0x200000A")]
	public class SpeedHackProofTime : KeepAliveBehaviour<SpeedHackProofTime>
	{
		[Token(Token = "0x4000012")]
		private static bool inited;

		[Token(Token = "0x4000013")]
		private static bool speedHackDetected;

		[Token(Token = "0x4000014")]
		private static float reliableTime;

		[Token(Token = "0x4000015")]
		private static float reliableDeltaTime;

		[Token(Token = "0x4000016")]
		private static float reliableUnscaledTime;

		[Token(Token = "0x4000017")]
		private static float reliableUnscaledDeltaTime;

		[Token(Token = "0x4000018")]
		private static float reliableRealtimeSinceStartup;

		[Token(Token = "0x4000019")]
		private static float reliableTimeSinceLevelLoad;

		[Token(Token = "0x400001A")]
		private static bool warningShot;

		[Token(Token = "0x400001B")]
		[FieldOffset(Offset = "0x28")]
		private long currentReliableTicks;

		[Token(Token = "0x400001C")]
		[FieldOffset(Offset = "0x30")]
		private long lastFrameReliableTicks;

		[Token(Token = "0x400001D")]
		[FieldOffset(Offset = "0x38")]
		private long reliableTicksDelta;

		[Token(Token = "0x17000001")]
		public static float time
		{
			[Token(Token = "0x6000030")]
			[Address(RVA = "0xBD5FD8", Offset = "0xBD5FD8", Length = "0x74")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = CodeStage.AntiCheat.Time.SpeedHackProofTime;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A353EE]) = v34;\nL_0014:\n\tv38 = ~v36.inited;\n\tv39 = ~v38;\n\tif (v39) goto L_001B;\n\tCodeStage.AntiCheat.Time.SpeedHackProofTime::Init();\nL_001B:\n\tv43 = ~v40.speedHackDetected;\n\tif (v43) goto L_0028;\n\treturn v40.reliableTime;\nL_0028:\n\treturnVal2 = UnityEngine.Time::get_time();\n\treturn returnVal2;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (!inited)
				{
					Init();
				}
				if (speedHackDetected)
				{
					return reliableTime;
				}
				return UnityEngine.Time.time;
			}
		}

		[Token(Token = "0x17000002")]
		public static float unscaledTime
		{
			[Token(Token = "0x6000031")]
			[Address(RVA = "0xBD604C", Offset = "0xBD604C", Length = "0x74")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = CodeStage.AntiCheat.Time.SpeedHackProofTime;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A353EF]) = v34;\nL_0014:\n\tv38 = ~v36.inited;\n\tv39 = ~v38;\n\tif (v39) goto L_001B;\n\tCodeStage.AntiCheat.Time.SpeedHackProofTime::Init();\nL_001B:\n\tv43 = ~v40.speedHackDetected;\n\tif (v43) goto L_0028;\n\treturn v40.reliableUnscaledTime;\nL_0028:\n\treturnVal2 = UnityEngine.Time::get_unscaledTime();\n\treturn returnVal2;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (!inited)
				{
					Init();
				}
				if (speedHackDetected)
				{
					return reliableUnscaledTime;
				}
				return UnityEngine.Time.unscaledTime;
			}
		}

		[Token(Token = "0x17000003")]
		public static float deltaTime
		{
			[Token(Token = "0x6000032")]
			[Address(RVA = "0xBD60C0", Offset = "0xBD60C0", Length = "0x74")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = CodeStage.AntiCheat.Time.SpeedHackProofTime;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A353F0]) = v34;\nL_0014:\n\tv38 = ~v36.inited;\n\tv39 = ~v38;\n\tif (v39) goto L_001B;\n\tCodeStage.AntiCheat.Time.SpeedHackProofTime::Init();\nL_001B:\n\tv43 = ~v40.speedHackDetected;\n\tif (v43) goto L_0028;\n\treturn v40.reliableDeltaTime;\nL_0028:\n\treturnVal2 = UnityEngine.Time::get_deltaTime();\n\treturn returnVal2;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (!inited)
				{
					Init();
				}
				if (speedHackDetected)
				{
					return reliableDeltaTime;
				}
				return UnityEngine.Time.deltaTime;
			}
		}

		[Token(Token = "0x17000004")]
		public static float unscaledDeltaTime
		{
			[Token(Token = "0x6000033")]
			[Address(RVA = "0xBD6134", Offset = "0xBD6134", Length = "0x74")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = CodeStage.AntiCheat.Time.SpeedHackProofTime;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A353F1]) = v34;\nL_0014:\n\tv38 = ~v36.inited;\n\tv39 = ~v38;\n\tif (v39) goto L_001B;\n\tCodeStage.AntiCheat.Time.SpeedHackProofTime::Init();\nL_001B:\n\tv43 = ~v40.speedHackDetected;\n\tif (v43) goto L_0028;\n\treturn v40.reliableUnscaledDeltaTime;\nL_0028:\n\treturnVal2 = UnityEngine.Time::get_unscaledDeltaTime();\n\treturn returnVal2;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (!inited)
				{
					Init();
				}
				if (speedHackDetected)
				{
					return reliableUnscaledDeltaTime;
				}
				return UnityEngine.Time.unscaledDeltaTime;
			}
		}

		[Token(Token = "0x17000005")]
		public static float realtimeSinceStartup
		{
			[Token(Token = "0x6000034")]
			[Address(RVA = "0xBD61A8", Offset = "0xBD61A8", Length = "0x74")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = CodeStage.AntiCheat.Time.SpeedHackProofTime;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A353F2]) = v34;\nL_0014:\n\tv38 = ~v36.inited;\n\tv39 = ~v38;\n\tif (v39) goto L_001B;\n\tCodeStage.AntiCheat.Time.SpeedHackProofTime::Init();\nL_001B:\n\tv43 = ~v40.speedHackDetected;\n\tif (v43) goto L_0028;\n\treturn v40.reliableRealtimeSinceStartup;\nL_0028:\n\treturnVal2 = UnityEngine.Time::get_realtimeSinceStartup();\n\treturn returnVal2;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (!inited)
				{
					Init();
				}
				if (speedHackDetected)
				{
					return reliableRealtimeSinceStartup;
				}
				return UnityEngine.Time.realtimeSinceStartup;
			}
		}

		[Token(Token = "0x17000006")]
		public static float timeSinceLevelLoad
		{
			[Token(Token = "0x6000035")]
			[Address(RVA = "0xBD621C", Offset = "0xBD621C", Length = "0x74")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = CodeStage.AntiCheat.Time.SpeedHackProofTime;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A353F3]) = v34;\nL_0014:\n\tv38 = ~v36.inited;\n\tv39 = ~v38;\n\tif (v39) goto L_001B;\n\tCodeStage.AntiCheat.Time.SpeedHackProofTime::Init();\nL_001B:\n\tv43 = ~v40.speedHackDetected;\n\tif (v43) goto L_0028;\n\treturn v40.reliableTimeSinceLevelLoad;\nL_0028:\n\treturnVal2 = UnityEngine.Time::get_timeSinceLevelLoad();\n\treturn returnVal2;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (!inited)
				{
					Init();
				}
				if (speedHackDetected)
				{
					return reliableTimeSinceLevelLoad;
				}
				return UnityEngine.Time.timeSinceLevelLoad;
			}
		}

		[Token(Token = "0x600002C")]
		[Address(RVA = "0xBD5904", Offset = "0xBD5904", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = \"SpeedHackProofTime\";\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A353EA]) = v34;\nL_0016:\n\treturn \"SpeedHackProofTime\";\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override string GetComponentName()
		{
			return "SpeedHackProofTime";
		}

		[Token(Token = "0x600002D")]
		[Address(RVA = "0xBD5944", Offset = "0xBD5944", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = CodeStage.AntiCheat.Time.SpeedHackProofTime;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A353EB]) = v37;\nL_0016:\n\tv41 = ~v39.speedHackDetected;\n\tif (v41) goto L_002A;\n\tv42 = CodeStage.AntiCheat.Utils.TimeUtils::GetReliableTicks();\n\tv35.currentReliableTicks = v42;\n\tv48 = v42 - v35.lastFrameReliableTicks;\n\tv35.reliableTicksDelta = v48;\n\tCodeStage.AntiCheat.Time.SpeedHackProofTime::UpdateReliableTimeValues(v35);\n\treturn;\nL_002A:\n\tCodeStage.AntiCheat.Time.SpeedHackProofTime::UpdateTimeValuesFromUnityTime(v35);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Update()
		{
			if (speedHackDetected)
			{
				long num = (currentReliableTicks = TimeUtils.GetReliableTicks()) - lastFrameReliableTicks;
				reliableTicksDelta = num;
				UpdateReliableTimeValues();
			}
			else
			{
				UpdateTimeValuesFromUnityTime();
			}
		}

		[Token(Token = "0x600002E")]
		[Address(RVA = "0xBD5B18", Offset = "0xBD5B18", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv39 = CodeStage.AntiCheat.Time.SpeedHackProofTime;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v39, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A353EC]) = v35;\nL_0015:\n\tv37 = CodeStage.AntiCheat.Common.KeepAliveBehaviour`1<CodeStage.AntiCheat.Time.SpeedHackProofTime>::get_GetOrCreateInstance();\n\tv43 = CodeStage.AntiCheat.Time.SpeedHackProofTime::InitInternal(v37);\n\tv49.inited = v43;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Init()
		{
			SpeedHackProofTime getOrCreateInstance = KeepAliveBehaviour<SpeedHackProofTime>.GetOrCreateInstance;
			bool flag = getOrCreateInstance.InitInternal();
			inited = flag;
		}

		[Token(Token = "0x600002F")]
		[Address(RVA = "0xBD5D90", Offset = "0xBD5D90", Length = "0x248")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv53 = System.Action;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv66 = Il2CppMethodInfo;\n\tv67 = \"il2cpp_codegen_initialize_runtime_metadata\"(v66, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv77 = Il2CppMethodInfo;\n\tv78 = \"il2cpp_codegen_initialize_runtime_metadata\"(v77, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv87 = UnityEngine.Object;\n\tv88 = \"il2cpp_codegen_initialize_runtime_metadata\"(v87, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv92 = Il2CppMethodInfo;\n\tv93 = \"il2cpp_codegen_initialize_runtime_metadata\"(v92, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv109 = CodeStage.AntiCheat.Time.SpeedHackProofTime;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v109, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv43 = 1;\n\t*([1A353ED]) = v43;\nL_002A:\n\tv45.inited = 0;\n\tgoto L_003B;\n\tv55 = 0xB348B0(v47, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_003B:\n\tgoto L_0043;\n\tv68 = 0xB348B0(v59, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0043:\n\tgoto L_0049;\n\tv79 = v70;\n\tv80 = \"il2cpp_codegen_runtime_class_init\"(v79, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0049:\n\tv85 = UnityEngine.Object::op_Equality(v71.<Instance>k__BackingField, 0);\n\tv90 = v85 == 0;\n\tif (v90) goto L_005D;\n\treturn;\nL_005D:\n\tgoto L_0065;\n\tv148 = 0xB348B0(v103, v83, v84, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0065:\n\tgoto L_006D;\n\tv156 = 0xB348B0(v151, v83, v84, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_006D:\n\tgoto L_0073;\n\tv162 = v158;\n\tv163 = \"il2cpp_codegen_runtime_class_init\"(v162, v83, v84, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0073:\n\tv168 = UnityEngine.Object::op_Inequality(v159.<Instance>k__BackingField, 0);\n\tv170 = v168 == 0;\n\tif (v170) goto L_00A2;\n\tgoto L_0085;\n\tv199 = CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<CodeStage.AntiCheat.Detectors.SpeedHackDetector>::remove_CheatDetected(v172, v166, v167);\nL_0085:\n\tgoto L_008C;\n\tv215 = CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<CodeStage.AntiCheat.Detectors.SpeedHackDetector>::remove_CheatDetected(v202, v166, v167);\nL_008C:\n\tv220 = new System.Action();\n\tSystem.Action::.ctor(v220, v218.<Instance>k__BackingField, Il2CppMethodInfo);\n\tCodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<CodeStage.AntiCheat.Detectors.SpeedHackDetector>::remove_CheatDetected(v159.<Instance>k__BackingField, v220);\nL_00A2:\n\tgoto L_00AA;\n\tv207 = CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<CodeStage.AntiCheat.Detectors.SpeedHackDetector>::remove_CheatDetected(v194, v181, v119);\nL_00AA:\n\tgoto L_00B1;\n\tv221 = CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<CodeStage.AntiCheat.Detectors.SpeedHackDetector>::remove_CheatDetected(v210, v181, v119);\nL_00B1:\n\tv231 = UnityEngine.Component::get_gameObject(v223.<Instance>k__BackingField);\n\tgoto L_00C3;\n\tv236 = v138;\n\tv237 = \"il2cpp_codegen_runtime_class_init\"(v236, v230, v119, v111, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_00C3:\n\tUnityEngine.Object::Destroy(v231);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 141 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Dispose()
		{
			inited = false;
			if (!(KeepAliveBehaviour<SpeedHackProofTime>.Instance == null))
			{
				if (KeepAliveBehaviour<SpeedHackDetector>.Instance != null)
				{
					Action value = KeepAliveBehaviour<SpeedHackProofTime>.Instance.OnSpeedHackDetected;
					KeepAliveBehaviour<SpeedHackDetector>.Instance.CheatDetected -= value;
				}
				GameObject obj = KeepAliveBehaviour<SpeedHackProofTime>.Instance.gameObject;
				UnityEngine.Object.Destroy(obj);
			}
		}

		[Token(Token = "0x6000036")]
		[Address(RVA = "0xBD5B8C", Offset = "0xBD5B8C", Length = "0x204")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0034;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv46 = Il2CppMethodInfo;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv59 = System.Action;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv70 = UnityEngine.Debug;\n\tv71 = \"il2cpp_codegen_initialize_runtime_metadata\"(v70, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv80 = Il2CppMethodInfo;\n\tv81 = \"il2cpp_codegen_initialize_runtime_metadata\"(v80, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv85 = UnityEngine.Object;\n\tv86 = \"il2cpp_codegen_initialize_runtime_metadata\"(v85, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv96 = Il2CppMethodInfo;\n\tv97 = \"il2cpp_codegen_initialize_runtime_metadata\"(v96, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv115 = CodeStage.AntiCheat.Time.SpeedHackProofTime;\n\tv116 = \"il2cpp_codegen_initialize_runtime_metadata\"(v115, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv154 = \"[ACTk] Can't initialize SpeedHackProofTime class since it requires running SpeedHackDetector instance which was not found. Did you started SpeedHackDetector before using SpeedHackProofTime?\\nSpeedHackProofTime will use unreliable vanilla Time.* APIs until you start SpeedHackDetector.\";\n\tv155 = \"il2cpp_codegen_initialize_runtime_metadata\"(v154, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv183 = \"[ACTk] Can't initialize SpeedHackProofTime class since it requires running SpeedHackDetector instance but only idle instance was found. Did you started SpeedHackDetector before using SpeedHackProofTime?\\nSpeedHackProofTime will use unreliable vanilla Time.* APIs until you start SpeedHackDetector.\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v183, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A353F4]) = v38;\nL_0034:\n\tgoto L_003E;\n\tv48 = 0xB348B0(v40, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_003E:\n\tgoto L_0043;\n\tv61 = 0xB348B0(v52, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0043:\n\tv66 = v64.<Instance>k__BackingField;\n\tgoto L_004C;\n\tv72 = v63;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v72, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_004C:\n\tv78 = UnityEngine.Object::op_Equality(v64.<Instance>k__BackingField, 0);\n\tv83 = v78 == 0;\n\tif (v83) goto L_0066;\n\tv92 = ~v90.warningShot;\n\tv93 = ~v92;\n\tif (v93) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tv117 = \"il2cpp_codegen_runtime_class_init\"(v100, v76, v77, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tgoto L_0090;\nL_0066:\n\tv112 = *([v66 @ X20_v4 (UnityEngine.Object)+4A]) == 0;\n\tif (v112) goto L_0080;\n\tv149 = new System.Action();\n\tSystem.Action::.ctor(v149, this, Il2CppMethodInfo);\n\tCodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<CodeStage.AntiCheat.Detectors.SpeedHackDetector>::add_CheatDetected(v64.<Instance>k__BackingField, v149);\n\tgoto L_009B;\nL_0080:\n\tv105 = ~v152.warningShot;\n\tif (v105) goto L_008A;\n\tgoto L_009B;\nL_008A:\n\tgoto L_FFFFFFFF;\n\tv187 = \"il2cpp_codegen_runtime_class_init\"(v179, v76, v77, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0090:\n\tUnityEngine.Debug::LogWarning(*([v159 @ X8_v9 (System.String)]));\n\tv138.warningShot = 1;\nL_009B:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 102 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private bool InitInternal()
		{
			UnityEngine.Object obj = KeepAliveBehaviour<SpeedHackDetector>.Instance;
			string message;
			if (KeepAliveBehaviour<SpeedHackDetector>.Instance == null)
			{
				if (warningShot)
				{
					goto IL_00ed;
				}
				message = "[ACTk] Can't initialize SpeedHackProofTime class since it requires running SpeedHackDetector instance which was not found. Did you started SpeedHackDetector before using SpeedHackProofTime?\nSpeedHackProofTime will use unreliable vanilla Time.* APIs until you start SpeedHackDetector.";
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ X20_v4 (UnityEngine.Object)+4A]");
				if ((nint)0 != 0)
				{
					Action value = OnSpeedHackDetected;
					KeepAliveBehaviour<SpeedHackDetector>.Instance.CheatDetected += value;
					return true;
				}
				if (warningShot)
				{
					goto IL_00ed;
				}
				message = "[ACTk] Can't initialize SpeedHackProofTime class since it requires running SpeedHackDetector instance but only idle instance was found. Did you started SpeedHackDetector before using SpeedHackProofTime?\nSpeedHackProofTime will use unreliable vanilla Time.* APIs until you start SpeedHackDetector.";
			}
			Debug.LogWarning(message);
			warningShot = true;
			return false;
			IL_00ed:
			return false;
		}

		[Token(Token = "0x6000037")]
		[Address(RVA = "0xBD59B8", Offset = "0xBD59B8", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv14 = CodeStage.AntiCheat.Time.SpeedHackProofTime;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A353F5]) = v34;\nL_0012:\n\tv36 = UnityEngine.Time::get_time();\n\tv39.reliableTime = v36;\n\tv40 = UnityEngine.Time::get_deltaTime();\n\tv43.reliableDeltaTime = v40;\n\tv44 = UnityEngine.Time::get_unscaledTime();\n\tv47.reliableUnscaledTime = v44;\n\tv48 = UnityEngine.Time::get_unscaledDeltaTime();\n\tv51.reliableUnscaledDeltaTime = v48;\n\tv52 = UnityEngine.Time::get_timeSinceLevelLoad();\n\tv55.reliableTimeSinceLevelLoad = v52;\n\tv56 = UnityEngine.Time::get_realtimeSinceStartup();\n\tv60.reliableRealtimeSinceStartup = v56;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void UpdateTimeValuesFromUnityTime()
		{
			float num = UnityEngine.Time.time;
			reliableTime = num;
			float num2 = UnityEngine.Time.deltaTime;
			reliableDeltaTime = num2;
			float num3 = UnityEngine.Time.unscaledTime;
			reliableUnscaledTime = num3;
			float num4 = UnityEngine.Time.unscaledDeltaTime;
			reliableUnscaledDeltaTime = num4;
			float num5 = UnityEngine.Time.timeSinceLevelLoad;
			reliableTimeSinceLevelLoad = num5;
			float num6 = UnityEngine.Time.realtimeSinceStartup;
			reliableRealtimeSinceStartup = num6;
		}

		[Token(Token = "0x6000038")]
		[Address(RVA = "0xBD5A6C", Offset = "0xBD5A6C", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = CodeStage.AntiCheat.Time.SpeedHackProofTime;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 1;\n\t*([1A353F6]) = v39;\nL_0018:\n\tthis.lastFrameReliableTicks = this.currentReliableTicks;\n\tv46 = this.reliableTicksDelta / 10000000f;\n\tv48.reliableUnscaledDeltaTime = v46;\n\tv49 = UnityEngine.Time::get_timeScale();\n\tv51 = v46 * v49;\n\tv61 = v51 + v56.reliableTime;\n\tv62 = v56.reliableUnscaledTime + v56.reliableUnscaledDeltaTime;\n\tv56.reliableTime = v61;\n\tv56.reliableDeltaTime = v51;\n\tv65 = v56.reliableUnscaledDeltaTime + v56.reliableRealtimeSinceStartup;\n\tv56.reliableUnscaledTime = v62;\n\tv56.reliableRealtimeSinceStartup = v65;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void UpdateReliableTimeValues()
		{
			lastFrameReliableTicks = currentReliableTicks;
			float num = (reliableUnscaledDeltaTime = (float)reliableTicksDelta / 10000000f);
			float timeScale = UnityEngine.Time.timeScale;
			float num2 = num * timeScale;
			float num3 = num2 + reliableTime;
			float num4 = reliableUnscaledTime + reliableUnscaledDeltaTime;
			reliableTime = num3;
			reliableDeltaTime = num2;
			float num5 = reliableUnscaledDeltaTime + reliableRealtimeSinceStartup;
			reliableUnscaledTime = num4;
			reliableRealtimeSinceStartup = num5;
		}

		[Token(Token = "0x6000039")]
		[Address(RVA = "0xBD6290", Offset = "0xBD6290", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = CodeStage.AntiCheat.Time.SpeedHackProofTime;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A353F7]) = v37;\nL_0016:\n\tv40.speedHackDetected = 1;\n\tv41 = CodeStage.AntiCheat.Utils.TimeUtils::GetReliableTicks();\n\tv35.lastFrameReliableTicks = v41;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnSpeedHackDetected()
		{
			speedHackDetected = true;
			long reliableTicks = TimeUtils.GetReliableTicks();
			lastFrameReliableTicks = reliableTicks;
		}

		[Token(Token = "0x600003A")]
		[Address(RVA = "0xBD62E8", Offset = "0xBD62E8", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv30 = Il2CppMethodInfo;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, scene, mode, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv54 = CodeStage.AntiCheat.Time.SpeedHackProofTime;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, scene, mode, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv48 = 1;\n\t*([1A353F8]) = v48;\nL_001E:\n\tv50 = scene & 0xFFFFFFFF;\n\tCodeStage.AntiCheat.Common.KeepAliveBehaviour`1<CodeStage.AntiCheat.Time.SpeedHackProofTime>::OnSceneLoaded(this, v50, mode);\n\tv62.reliableTimeSinceLevelLoad = 0f;\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void OnSceneLoaded(Scene scene, LoadSceneMode mode)
		{
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_0017: Expected O, but got Unknown
			Scene scene2 = (Scene)(scene & 0xFFFFFFFFL);
			base.OnSceneLoaded(scene2, mode);
			reliableTimeSinceLevelLoad = 0f;
		}

		[Token(Token = "0x600003B")]
		[Address(RVA = "0xBD6374", Offset = "0xBD6374", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A353F9]) = v37;\nL_001A:\n\tCodeStage.AntiCheat.Common.KeepAliveBehaviour`1<CodeStage.AntiCheat.Time.SpeedHackProofTime>::.ctor(this);\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SpeedHackProofTime()
		{
		}
	}
}
