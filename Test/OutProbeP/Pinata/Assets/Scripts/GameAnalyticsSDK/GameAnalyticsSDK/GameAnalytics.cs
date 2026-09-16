using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using AssetRipperInjected;
using Cpp2ILInjected;
using GameAnalyticsSDK.Events;
using GameAnalyticsSDK.Setup;
using GameAnalyticsSDK.State;
using GameAnalyticsSDK.Wrapper;
using UnityEngine;

namespace GameAnalyticsSDK
{
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x73C308", Offset = "0x73C308")]
	[ExecuteInEditMode]
	[Token(Token = "0x2000009")]
	public class GameAnalytics : MonoBehaviour
	{
		[Token(Token = "0x400002D")]
		private static Settings _settings;

		[Token(Token = "0x400002E")]
		private static GameAnalytics _instance;

		[Token(Token = "0x400002F")]
		private static bool _hasInitializeBeenCalled;

		[CompilerGenerated]
		[Token(Token = "0x4000030")]
		private static Action m_OnRemoteConfigsUpdatedEvent;

		[Token(Token = "0x17000001")]
		public static Settings SettingsGA
		{
			[Token(Token = "0x6000001")]
			[Address(RVA = "0x15A046C", Offset = "0x15A046C", Length = "0x94")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv16 = *([1EDA870]);\n\tv17 = *([v16 @ X8_v10]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([20297E9]) = v37;\nL_001D:\n\tgoto L_0026;\n\tv49 = *([v44 @ X0_v2+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0026;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v44, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0026:\n\tv59 = UnityEngine.Object::op_Equality(v43._settings, 0);\n\tv61 = v59 == 0;\n\tif (v61) goto L_0033;\n\tGameAnalyticsSDK.GameAnalytics::InitAPI();\nL_0033:\n\treturn v65._settings;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (_settings == null)
				{
					InitAPI();
				}
				return _settings;
			}
			[Token(Token = "0x6000002")]
			[Address(RVA = "0x15A2958", Offset = "0x15A2958", Length = "0x54")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1F07B30]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20297EA]) = v38;\nL_0017:\n\tv42._settings = value;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set
			{
				_settings = value;
			}
		}

		[Token(Token = "0x14000001")]
		public static event Action OnRemoteConfigsUpdatedEvent
		{
			[CompilerGenerated]
			[Token(Token = "0x6000025")]
			[Address(RVA = "0x15A4890", Offset = "0x15A4890", Length = "0xB8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EA9410]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029806]) = v42;\nL_001F:\n\tv95 = System.Delegate::Combine(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._settings + 0x18;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_003f: Expected O, but got I
				Delegate obj = GameAnalytics.m_OnRemoteConfigsUpdatedEvent;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Combine(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(Action))
					{
						break;
					}
					object obj3 = (long)(IntPtr)_settings + 24L;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
					bool flag = obj != obj4;
					obj = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x6000026")]
			[Address(RVA = "0x15A4948", Offset = "0x15A4948", Length = "0xB8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EE7118]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029807]) = v42;\nL_001F:\n\tv95 = System.Delegate::Remove(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._settings + 0x18;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_003f: Expected O, but got I
				Delegate obj = GameAnalytics.m_OnRemoteConfigsUpdatedEvent;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Remove(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(Action))
					{
						break;
					}
					object obj3 = (long)(IntPtr)_settings + 24L;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
					bool flag = obj != obj4;
					obj = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x6000003")]
		[Address(RVA = "0x15A29AC", Offset = "0x15A29AC", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1EE96B0]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20297EB]) = v35;\nL_0014:\n\tv39 = new UnityEngine.Application+LogCallback();\n\tUnityEngine.Application+LogCallback::.ctor(v39, 0, Il2CppMethodInfo);\n\tUnityEngine.Application::add_logMessageReceived(v39);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnEnable()
		{
			Application.LogCallback value = GA_Debug.HandleLog;
			Application.logMessageReceived += value;
		}

		[Token(Token = "0x6000004")]
		[Address(RVA = "0x15A2A1C", Offset = "0x15A2A1C", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1F041A0]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20297EC]) = v35;\nL_0014:\n\tv39 = new UnityEngine.Application+LogCallback();\n\tUnityEngine.Application+LogCallback::.ctor(v39, 0, Il2CppMethodInfo);\n\tUnityEngine.Application::remove_logMessageReceived(v39);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDisable()
		{
			Application.LogCallback value = GA_Debug.HandleLog;
			Application.logMessageReceived -= value;
		}

		[Token(Token = "0x6000005")]
		[Address(RVA = "0x15A2A8C", Offset = "0x15A2A8C", Length = "0x164")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EFADC0]);\n\tv23 = *([v22 @ X8_v20]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20297ED]) = v42;\nL_0016:\n\tv44 = UnityEngine.Application::get_isPlaying();\n\tv46 = v44 == 0;\n\tif (v46) goto L_0064;\n\tgoto L_002E;\n\tv64 = *([v53 @ X0_v4+E0]);\n\tv65 = v64 == 0;\n\tv66 = ~v65;\n\tif (v66) goto L_002E;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v53, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_002E:\n\tv74 = UnityEngine.Object::op_Inequality(v52._instance, 0);\n\tv111 = v74 == 0;\n\tif (v111) goto L_0069;\n\tgoto L_0042;\n\tv123 = *([v114 @ X0_v14+E0]);\n\tv124 = v123 == 0;\n\tv125 = ~v124;\n\tif (v125) goto L_0042;\n\tv127 = \"il2cpp_codegen_runtime_class_init\"(v114, v72, v73, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0042:\n\tUnityEngine.Debug::LogWarning(\"Destroying duplicate GameAnalytics object - only one is allowed per scene!\");\n\tv140 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_005B;\n\tv151 = *([v102 @ X8_v15+E0]);\n\tv152 = v151 == 0;\n\tv153 = ~v152;\n\tif (v153) goto L_005B;\n\tv156 = v102;\n\tv155 = \"il2cpp_codegen_runtime_class_init\"(v156, v139, v73, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_005B:\n\tUnityEngine.Object::Destroy(v140);\n\treturn;\nL_0064:\n\treturn;\nL_0069:\n\tv121._instance = this;\n\tv122 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_0080;\n\tv141 = *([v103 @ X8_v8+E0]);\n\tv142 = v141 == 0;\n\tv143 = ~v142;\n\tif (v143) goto L_0080;\n\tv150 = v103;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v150, v120, v73, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0080:\n\tUnityEngine.Object::DontDestroyOnLoad(v122);\n\treturn;\n// 83 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Awake()
		{
			if (Application.isPlaying)
			{
				if (_instance != null)
				{
					Debug.LogWarning("Destroying duplicate GameAnalytics object - only one is allowed per scene!");
					GameObject obj = base.gameObject;
					UnityEngine.Object.Destroy(obj);
				}
				else
				{
					_instance = this;
					GameObject target = base.gameObject;
					UnityEngine.Object.DontDestroyOnLoad(target);
				}
			}
		}

		[Token(Token = "0x6000006")]
		[Address(RVA = "0x15A2BF0", Offset = "0x15A2BF0", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1EBE718]);\n\tv21 = *([v20 @ X8_v11]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20297EE]) = v40;\nL_0015:\n\tv42 = UnityEngine.Application::get_isPlaying();\n\tv44 = v42 == 0;\n\tif (v44) goto L_003A;\n\tgoto L_002D;\n\tv76 = *([v51 @ X0_v5+E0]);\n\tv77 = v76 == 0;\n\tv78 = ~v77;\n\tif (v78) goto L_002D;\n\tv80 = \"il2cpp_codegen_runtime_class_init\"(v51, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002D:\n\tv64 = UnityEngine.Object::op_Equality(v50._instance, this);\n\tv66 = v64 == 0;\n\tif (v66) goto L_003A;\n\tv68._instance = 0;\nL_003A:\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDestroy()
		{
			if (Application.isPlaying && _instance == this)
			{
				_instance = null;
			}
		}

		[Token(Token = "0x6000007")]
		[Address(RVA = "0x15A2C98", Offset = "0x15A2C98", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private void OnApplicationQuit()
		{
		}

		[Token(Token = "0x6000008")]
		[Address(RVA = "0x15A2790", Offset = "0x15A2790", Length = "0x1C8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv16 = *([1EFC9E8]);\n\tv17 = *([v16 @ X8_v29]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([20297EF]) = v37;\nL_001B:\n\tgoto L_0023;\n\tv47 = *([v40 @ X0_v2+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0023;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0023:\n\tv56 = System.Type::GetTypeFromHandle(GameAnalyticsSDK.Setup.Settings);\n\tv62 = UnityEngine.Resources::Load(\"GameAnalytics/Settings\", v56);\n\tv67 = v62 == 0;\n\tif (v67) goto L_0050;\n\tgoto L_FFFFFFFF;\n\tv88 = v88_asT == 0;\n\tif (v88) goto L_0058;\nL_0050:\n\tv66._settings = v62;\n\tGameAnalyticsSDK.State.GAState::Init();\n\treturn;\nL_0058:\n\tv135 = new System.InvalidCastException();\n\tgoto L_0065;\n\tgoto L_0065;\nL_0065:\n\tv147 = GameAnalyticsSDK.Setup.Settings != 1;\n\tif (v147) goto L_00A6;\n\tv191 = 0x6D2BC0(v135, GameAnalyticsSDK.Setup.Settings, 0, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv203 = *([v191 @ X0_v14]);\n\tv173 = *([v203 @ X19_v6]);\n\tv207 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v203 @ X19_v6]), 0, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv208 = v207 & 1;\n\tv209 = v208 == 0;\n\tif (v209) goto L_009A;\n\tv210 = 0x6D2490(v207, v173, 0, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv213 = v203 == 0;\n\tif (v213) goto L_00A2;\n\tv219 = *([v203 @ X19_v6]);\n\t*([v219 @ X8_v19+180])(v223, v203, *([v219 @ X8_v19+188]), 0, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv229 = System.String::Concat(\"Error getting Settings in InitAPI: \", v223);\n\tgoto L_0097;\n\tv239 = *([v181 @ X8_v25+E0]);\n\tv240 = v239 == 0;\n\tv241 = ~v240;\n\tif (v241) goto L_0097;\n\tv244 = v181;\n\tv243 = \"il2cpp_codegen_runtime_class_init\"(v244, v226, v169, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0097:\n\tUnityEngine.Debug::Log(v229);\n\treturn;\nL_009A:\n\tv212 = 0x6D1E60(8, *([v203 @ X19_v6]), 0, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\t*([v212 @ X0_v22]) = *([v191 @ X0_v14]);\n\tv173 = 0x1E8A000 + 0x870;\n\tv218 = 0x6D2A00(v212, v173, 0, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_00A2:\n\tv232 = new System.NullReferenceException();\n\tv196 = 0x6D2490(v232, v173, v170, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_00A6:\n\tv201 = 0x6D2380(v185, v173, v170, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv176 = 0x846AA4(v201, v173, v170, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\treturn;\n// 111 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void InitAPI()
		{
			//IL_00b4: Expected O, but got I4
			//IL_00c2: Expected I, but got O
			//IL_00f7: Expected I, but got O
			//IL_01dd: Expected O, but got I4
			//IL_015e: Expected O, but got I4
			Type typeFromHandle = typeof(Settings);
			UnityEngine.Object obj = Resources.Load("GameAnalytics/Settings", typeFromHandle);
			if ((object)obj != null)
			{
				Settings settings = obj as Settings;
				if ((object)settings == null)
				{
					InvalidCastException ex = new InvalidCastException();
					bool flag = (IntPtr)typeof(Settings) != (IntPtr)1;
					object obj2 = 0;
					IntPtr intPtr = (IntPtr)typeof(Settings);
					InvalidCastException ex2 = ex;
					if (!flag)
					{
						Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
						object obj4 = default(object);
						object obj3 = obj4;
						intPtr = (IntPtr)obj3;
						Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
						object obj5 = default(object);
						if ((uint)((ulong)(long)(IntPtr)obj5 & 1uL) != 0)
						{
							Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
							bool flag2 = obj3 == null;
							obj2 = 0;
							if (!flag2)
							{
								object obj6 = obj3;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v219 @ X8_v19+180] (should have been resolved before IL gen)");
								string text = default(string);
								string message = "Error getting Settings in InitAPI: " + text;
								Debug.Log(message);
								return;
							}
						}
						else
						{
							Il2CppRuntime.Boundary("SYSTEM_API:__cxa_allocate_exception", "Method not found @6D1E60 (native __cxa_allocate_exception)");
							object obj7 = obj4;
							intPtr = (IntPtr)(32022528 + 2160);
							Il2CppRuntime.Boundary("SYSTEM_API:__cxa_throw", "Method not found @6D2A00 (native __cxa_throw)");
							obj2 = 0;
						}
						NullReferenceException ex3 = new NullReferenceException();
						Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
						ex2 = (InvalidCastException)(object)ex3;
					}
					Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
					return;
				}
			}
			_settings = (Settings)obj;
			GAState.Init();
		}

		[Token(Token = "0x6000009")]
		[Address(RVA = "0x15A2E60", Offset = "0x15A2E60", Length = "0x36C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EC2DF0]);\n\tv25 = *([v24 @ X8_v48]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv45 = 0 | 1;\n\t*([20297F0]) = v45;\nL_0017:\n\tv47 = UnityEngine.Application::get_isPlaying();\n\tv49 = v47 == 0;\n\tif (v49) goto L_018B;\n\tv50 = GameAnalyticsSDK.GameAnalytics::get_SettingsGA();\n\tv175 = ~v50.InfoLogBuild;\n\tif (v175) goto L_0023;\n\tGameAnalyticsSDK.Events.GA_Setup::SetInfoLog(1);\nL_0023:\n\tv303 = GameAnalyticsSDK.GameAnalytics::get_SettingsGA();\n\tv354 = ~v303.VerboseLogBuild;\n\tif (v354) goto L_002B;\n\tGameAnalyticsSDK.Events.GA_Setup::SetVerboseLog(1);\nL_002B:\n\tv357 = GameAnalyticsSDK.GameAnalytics::GetPlatformIndex();\n\tgoto L_0041;\n\tv364 = *([v360 @ X8_v7 (Il2CppClass<GameAnalyticsSDK.Setup.Settings>)+E0]);\n\tv365 = v364 == 0;\n\tv366 = ~v365;\n\tif (v366) goto L_0041;\n\tv379 = v360;\n\tv369 = \"il2cpp_codegen_runtime_class_init\"(v379, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv372 = GameAnalyticsSDK.Setup.Settings;\nL_0041:\n\tv378 = System.String::Concat(\"unity \", v374.VERSION);\n\tgoto L_0051;\n\tv385 = *([v381 @ X8_v10+E0]);\n\tv386 = v385 == 0;\n\tv387 = ~v386;\n\tgoto L_0051;\n\tv392 = v381;\n\tv389 = \"il2cpp_codegen_runtime_class_init\"(v392, v376, v375, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0051:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::SetUnitySdkVersion(v378);\n\tv393 = GameAnalyticsSDK.GameAnalytics::GetUnityVersion();\n\tv411 = System.String::Concat(\"unity \", v393);\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::SetUnityEngineVersion(v411);\n\tv396 = v357 & 0x80000000;\n\tv397 = v396 == 0;\n\tv398 = ~v397;\n\tif (v398) goto L_00F8;\n\tv422 = GameAnalyticsSDK.GameAnalytics::get_SettingsGA();\n\tv418 = ~v422.UsePlayerSettingsBuildNumber;\n\tif (v418) goto L_00D3;\n\tv422 = GameAnalyticsSDK.GameAnalytics::get_SettingsGA();\nL_0069:\n\tv469 = v422.Platforms;\n\tv195 = v299 >= v469._size;\n\tif (v195) goto L_00D3;\n\tv536 = GameAnalyticsSDK.GameAnalytics::get_SettingsGA();\n\tv191 = v536.Platforms;\n\tv505 = v191._size < v299;\n\tv506 = ~v505;\n\tv507 = v191._size - v299;\n\tv509 = v507 == 0;\n\tv514 = ~v509;\n\tv196 = v506 & v514;\n\tif (v196) goto L_008E;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_008E:\n\tv185 = v299 << 2;\n\tv520 = v191._items + v185;\n\tv246 = *([v520 @ X8_v37+20]) == 0xB;\n\tif (v246) goto L_00C0;\n\tv536 = GameAnalyticsSDK.GameAnalytics::get_SettingsGA();\n\tv431 = v536.Platforms;\n\tv544 = v431._size < v299;\n\tv545 = ~v544;\n\tv546 = v431._size - v299;\n\tv548 = v546 == 0;\n\tv553 = ~v548;\n\tv554 = v545 & v553;\n\tif (v554) goto L_00B2;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_00B2:\n\tv526 = v299 << 2;\n\tv560 = v431._items + v526;\n\tv527 = *([v560 @ X8_v43+20]) != 8;\n\tif (v527) goto L_00CD;\nL_00C0:\n\tv307 = GameAnalyticsSDK.GameAnalytics::get_SettingsGA();\n\tv457 = UnityEngine.Application::get_version();\n\tSystem.Collections.Generic.List`1<System.String>::set_Item(v307.Build, v299, v457);\nL_00CD:\n\tv299 = v299 + 1;\n\tv422 = GameAnalyticsSDK.GameAnalytics::get_SettingsGA();\n\tv567 = v422 == 0;\n\tv463 = ~v567;\n\tif (v463) goto L_0069;\n\tgoto L_018D;\nL_00D3:\n\tv308 = GameAnalyticsSDK.GameAnalytics::get_SettingsGA();\n\tv410 = v308.Build;\n\tv484 = v410._size < v357;\n\tv408 = ~v484;\n\tv407 = v410._size - v357;\n\tv405 = v407 == 0;\n\tv485 = ~v405;\n\tv400 = v408 & v485;\n\tif (v400) goto L_00E8;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_00E8:\n\tv489 = v410._items;\n\tgoto L_00F7;\n\tv496 = *([v490 @ X0_v50+E0]);\n\tv497 = v496 == 0;\n\tv498 = ~v497;\n\tif (v498) goto L_00F7;\n\tv500 = \"il2cpp_codegen_runtime_class_init\"(v490, v294, v290, v178, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_00F7:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::SetBuild(v489[v357 @ X0_v11 (System.Int32)]);\nL_00F8:\n\tv309 = GameAnalyticsSDK.GameAnalytics::get_SettingsGA();\n\tv419 = v309.CustomDimensions01;\n\tv200 = v419._size < 1;\n\tif (v200) goto L_0110;\n\tv310 = GameAnalyticsSDK.GameAnalytics::get_SettingsGA();\n\tGameAnalyticsSDK.Events.GA_Setup::SetAvailableCustomDimensions01(v310.CustomDimensions01);\nL_0110:\n\tv311 = GameAnalyticsSDK.GameAnalytics::get_SettingsGA();\n\tv471 = v311.CustomDimensions02;\n\tv201 = v471._size < 1;\n\tif (v201) goto L_0128;\n\tv312 = GameAnalyticsSDK.GameAnalytics::get_SettingsGA();\n\tGameAnalyticsSDK.Events.GA_Setup::SetAvailableCustomDimensions02(v312.CustomDimensions02);\nL_0128:\n\tv313 = GameAnalyticsSDK.GameAnalytics::get_SettingsGA();\n\tv472 = v313.CustomDimensions03;\n\tv202 = v472._size < 1;\n\tif (v202) goto L_0140;\n\tv314 = GameAnalyticsSDK.GameAnalytics::get_SettingsGA();\n\tGameAnalyticsSDK.Events.GA_Setup::SetAvailableCustomDimensions03(v314.CustomDimensions03);\nL_0140:\n\tv315 = GameAnalyticsSDK.GameAnalytics::get_SettingsGA();\n\tv473 = v315.ResourceItemTypes;\n\tv203 = v473._size < 1;\n\tif (v203) goto L_0158;\n\tv316 = GameAnalyticsSDK.GameAnalytics::get_SettingsGA();\n\tGameAnalyticsSDK.Events.GA_Setup::SetAvailableResourceItemTypes(v316.ResourceItemTypes);\nL_0158:\n\tv317 = GameAnalyticsSDK.GameAnalytics::get_SettingsGA();\n\tv474 = v317.ResourceCurrencies;\n\tv62 = v474._size < 1;\n\tif (v62) goto L_0170;\n\tv318 = GameAnalyticsSDK.GameAnalytics::get_SettingsGA();\n\tGameAnalyticsSDK.Events.GA_Setup::SetAvailableResourceCurrencies(v318.ResourceCurrencies);\nL_0170:\n\tv101 = GameAnalyticsSDK.GameAnalytics::get_SettingsGA();\n\tv103 = ~v101.UseManualSessionHandling;\n\tif (v103) goto L_018B;\n\tGameAnalyticsSDK.GameAnalytics::SetEnabledManualSessionHandling(1);\n\treturn;\nL_018B:\n\treturn;\nL_018D:\n\tv302 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n// 258 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void InternalInitialize()
		{
			//IL_0044: Expected O, but got I4
			//IL_0088: Expected O, but got I4
			//IL_00e4: Expected I4, but got I8
			//IL_0231: Expected O, but got I
			//IL_030c: Expected O, but got I
			if (!Application.isPlaying)
			{
				return;
			}
			Settings settingsGA = SettingsGA;
			if (settingsGA.InfoLogBuild)
			{
				GA_Setup.SetInfoLog(enabled: true);
				settingsGA = (Settings)1;
			}
			Settings settingsGA2 = SettingsGA;
			if (settingsGA2.VerboseLogBuild)
			{
				GA_Setup.SetVerboseLog(enabled: true);
				settingsGA2 = (Settings)1;
			}
			int platformIndex = GetPlatformIndex();
			string unitySdkVersion = "unity " + Settings.VERSION;
			GA_Wrapper.SetUnitySdkVersion(unitySdkVersion);
			string unityVersion = GetUnityVersion();
			string unityEngineVersion = "unity " + unityVersion;
			GA_Wrapper.SetUnityEngineVersion(unityEngineVersion);
			if ((int)(platformIndex & 0x80000000L) == 0)
			{
				Settings settingsGA3 = SettingsGA;
				if (settingsGA3.UsePlayerSettingsBuildNumber)
				{
					settingsGA3 = SettingsGA;
					int num = 0;
					while (true)
					{
						List<RuntimePlatform> platforms = settingsGA3.Platforms;
						if (num >= platforms.Count)
						{
							break;
						}
						Settings settingsGA4 = SettingsGA;
						List<RuntimePlatform> platforms2 = settingsGA4.Platforms;
						bool flag = platforms2.Count < num;
						bool flag2 = !flag;
						int num2 = platforms2.Count - num;
						bool flag3 = num2 == 0;
						bool flag4 = !flag3;
						if (!(flag2 && flag4))
						{
							throw new ArgumentOutOfRangeException();
						}
						int num3 = num << 2;
						object obj = (long)(IntPtr)platforms2._items + (long)num3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v520 @ X8_v37+20]");
						if ((IntPtr)0 != (IntPtr)11)
						{
							settingsGA4 = SettingsGA;
							List<RuntimePlatform> platforms3 = settingsGA4.Platforms;
							bool flag5 = platforms3.Count < num;
							bool flag6 = !flag5;
							int num4 = platforms3.Count - num;
							bool flag7 = num4 == 0;
							bool flag8 = !flag7;
							if (!(flag6 && flag8))
							{
								throw new ArgumentOutOfRangeException();
							}
							int num5 = num << 2;
							object obj2 = (long)(IntPtr)platforms3._items + (long)num5;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v560 @ X8_v43+20]");
							if ((IntPtr)0 != (IntPtr)8)
							{
								goto IL_036e;
							}
						}
						Settings settingsGA5 = SettingsGA;
						string version = Application.version;
						settingsGA5.Build.set_Item(num, version);
						goto IL_036e;
						IL_036e:
						num++;
						settingsGA3 = SettingsGA;
						if ((object)settingsGA3 == null)
						{
							NullReferenceException ex = new NullReferenceException();
							throw new NullReferenceException();
						}
					}
				}
				Settings settingsGA6 = SettingsGA;
				List<string> build = settingsGA6.Build;
				bool flag9 = build.Count < platformIndex;
				bool flag10 = !flag9;
				int num6 = build.Count - platformIndex;
				bool flag11 = num6 == 0;
				bool flag12 = !flag11;
				if (!(flag10 && flag12))
				{
					throw new ArgumentOutOfRangeException();
				}
				string[] items = build._items;
				GA_Wrapper.SetBuild(items[platformIndex]);
				unityEngineVersion = items[platformIndex];
			}
			Settings settingsGA7 = SettingsGA;
			List<string> customDimensions = settingsGA7.CustomDimensions01;
			if (customDimensions.Count >= 1)
			{
				Settings settingsGA8 = SettingsGA;
				GA_Setup.SetAvailableCustomDimensions01(settingsGA8.CustomDimensions01);
				settingsGA7 = (Settings)(object)settingsGA8.CustomDimensions01;
			}
			Settings settingsGA9 = SettingsGA;
			List<string> customDimensions2 = settingsGA9.CustomDimensions02;
			if (customDimensions2.Count >= 1)
			{
				Settings settingsGA10 = SettingsGA;
				GA_Setup.SetAvailableCustomDimensions02(settingsGA10.CustomDimensions02);
				settingsGA9 = (Settings)(object)settingsGA10.CustomDimensions02;
			}
			Settings settingsGA11 = SettingsGA;
			List<string> customDimensions3 = settingsGA11.CustomDimensions03;
			if (customDimensions3.Count >= 1)
			{
				Settings settingsGA12 = SettingsGA;
				GA_Setup.SetAvailableCustomDimensions03(settingsGA12.CustomDimensions03);
				settingsGA11 = (Settings)(object)settingsGA12.CustomDimensions03;
			}
			Settings settingsGA13 = SettingsGA;
			List<string> resourceItemTypes = settingsGA13.ResourceItemTypes;
			if (resourceItemTypes.Count >= 1)
			{
				Settings settingsGA14 = SettingsGA;
				GA_Setup.SetAvailableResourceItemTypes(settingsGA14.ResourceItemTypes);
				settingsGA13 = (Settings)(object)settingsGA14.ResourceItemTypes;
			}
			Settings settingsGA15 = SettingsGA;
			List<string> resourceCurrencies = settingsGA15.ResourceCurrencies;
			if (resourceCurrencies.Count >= 1)
			{
				Settings settingsGA16 = SettingsGA;
				GA_Setup.SetAvailableResourceCurrencies(settingsGA16.ResourceCurrencies);
				settingsGA15 = (Settings)(object)settingsGA16.ResourceCurrencies;
			}
			Settings settingsGA17 = SettingsGA;
			if (settingsGA17.UseManualSessionHandling)
			{
				SetEnabledManualSessionHandling(enabled: true);
			}
		}

		[Token(Token = "0x600000A")]
		[Address(RVA = "0x15A366C", Offset = "0x15A366C", Length = "0x158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv16 = *([1EBF5A8]);\n\tv17 = *([v16 @ X8_v26]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([20297F1]) = v37;\nL_0012:\n\tGameAnalyticsSDK.GameAnalytics::InternalInitialize();\n\tv38 = GameAnalyticsSDK.GameAnalytics::GetPlatformIndex();\n\tv40 = v38 & 0x80000000;\n\tv41 = v40 == 0;\n\tv42 = ~v41;\n\tif (v42) goto L_0042;\n\tv43 = GameAnalyticsSDK.GameAnalytics::get_SettingsGA();\n\tv60 = GameAnalyticsSDK.Setup.Settings::GetGameKey(v43, v38);\n\tv63 = GameAnalyticsSDK.GameAnalytics::get_SettingsGA();\n\tv117 = GameAnalyticsSDK.Setup.Settings::GetSecretKey(v63, v38);\n\tgoto L_0034;\n\tv133 = *([v129 @ X8_v19+E0]);\n\tv134 = v133 == 0;\n\tv135 = ~v134;\n\tif (v135) goto L_0034;\n\tv139 = v129;\n\tv138 = \"il2cpp_codegen_runtime_class_init\"(v139, v116, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0034:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::Initialize(v60, v117);\n\tv125._hasInitializeBeenCalled = 1;\n\tgoto L_0068;\nL_0042:\n\tv49._hasInitializeBeenCalled = 1;\n\tv50 = UnityEngine.Application::get_platform();\n\t// 74 Box v58 @ X0_v7 (System.Object), typeof(UnityEngine.RuntimePlatform), &v50 @ X0_v5 (UnityEngine.RuntimePlatform)\n\tv75 = System.String::Concat(\"GameAnalytics: Unsupported platform (events will not be sent in editor; or missing platform in settings): \", v58);\n\tgoto L_0062;\n\tv107 = *([v79 @ X8_v16+E0]);\n\tv108 = v107 == 0;\n\tv109 = ~v108;\n\tif (v109) goto L_0062;\n\tv118 = v79;\n\tv112 = \"il2cpp_codegen_runtime_class_init\"(v118, v71, v72, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0062:\n\tUnityEngine.Debug::LogWarning(v75);\nL_0068:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Initialize()
		{
			//IL_00cf: Expected I4, but got I8
			InternalInitialize();
			int platformIndex = GetPlatformIndex();
			if ((int)(platformIndex & 0x80000000L) == 0)
			{
				Settings settingsGA = SettingsGA;
				string gameKey = settingsGA.GetGameKey(platformIndex);
				Settings settingsGA2 = SettingsGA;
				string secretKey = settingsGA2.GetSecretKey(platformIndex);
				GA_Wrapper.Initialize(gameKey, secretKey);
				_hasInitializeBeenCalled = true;
			}
			else
			{
				_hasInitializeBeenCalled = true;
				RuntimePlatform platform = Application.platform;
				object obj = platform;
				string message = "GameAnalytics: Unsupported platform (events will not be sent in editor; or missing platform in settings): " + obj;
				Debug.LogWarning(message);
			}
		}

		[Token(Token = "0x600000B")]
		[Address(RVA = "0x15A3930", Offset = "0x15A3930", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv34 = *([1EFE920]);\n\tv35 = *([v34 @ X8_v17]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, amount, itemType, itemId, cartType, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([20297F2]) = v50;\nL_0020:\n\tv56 = ~v54._hasInitializeBeenCalled;\n\tif (v56) goto L_0039;\n\tGameAnalyticsSDK.Events.GA_Business::NewEvent(currency, amount, itemType, itemId, cartType, 0);\n\treturn;\nL_0039:\n\tgoto L_004C;\n\tv77 = *([v73 @ X0_v2+E0]);\n\tv78 = v77 == 0;\n\tv79 = ~v78;\n\tif (v79) goto L_004C;\n\tv81 = \"il2cpp_codegen_runtime_class_init\"(v73, amount, itemType, itemId, cartType, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_004C:\n\tUnityEngine.Debug::LogError(\"GameAnalytics: REMEMBER THE SDK NEEDS TO BE MANUALLY INITIALIZED NOW\");\n\treturn;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void NewBusinessEvent(string currency, int amount, string itemType, string itemId, string cartType)
		{
			if (_hasInitializeBeenCalled)
			{
				GA_Business.NewEvent(currency, amount, itemType, itemId, cartType, null);
			}
			else
			{
				Debug.LogError("GameAnalytics: REMEMBER THE SDK NEEDS TO BE MANUALLY INITIALIZED NOW");
			}
		}

		[Token(Token = "0x600000C")]
		[Address(RVA = "0x15A3A04", Offset = "0x15A3A04", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv42 = *([1F0F538]);\n\tv43 = *([v42 @ X8_v17]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, amount, itemType, itemId, cartType, receipt, signature, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([20297F3]) = v56;\nL_0024:\n\tv62 = ~v60._hasInitializeBeenCalled;\n\tif (v62) goto L_0041;\n\tGameAnalyticsSDK.Events.GA_Business::NewEventGooglePlay(currency, amount, itemType, itemId, cartType, receipt, signature, 0);\n\treturn;\nL_0041:\n\tgoto L_0056;\n\tv88 = *([v74 @ X0_v2+E0]);\n\tv89 = v88 == 0;\n\tv90 = ~v89;\n\tif (v90) goto L_0056;\n\tv92 = \"il2cpp_codegen_runtime_class_init\"(v74, amount, itemType, itemId, cartType, receipt, signature, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53);\nL_0056:\n\tUnityEngine.Debug::LogError(\"GameAnalytics: REMEMBER THE SDK NEEDS TO BE MANUALLY INITIALIZED NOW\");\n\treturn;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void NewBusinessEventGooglePlay(string currency, int amount, string itemType, string itemId, string cartType, string receipt, string signature)
		{
			if (_hasInitializeBeenCalled)
			{
				GA_Business.NewEventGooglePlay(currency, amount, itemType, itemId, cartType, receipt, signature, null);
			}
			else
			{
				Debug.LogError("GameAnalytics: REMEMBER THE SDK NEEDS TO BE MANUALLY INITIALIZED NOW");
			}
		}

		[Token(Token = "0x600000D")]
		[Address(RVA = "0x15A3B04", Offset = "0x15A3B04", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EAEF80]);\n\tv19 = *([v18 @ X8_v17]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20297F4]) = v38;\nL_0018:\n\tv44 = ~v42._hasInitializeBeenCalled;\n\tif (v44) goto L_002A;\n\tGameAnalyticsSDK.Events.GA_Design::CreateNewEvent(eventName, 0, 0);\n\treturn;\nL_002A:\n\tgoto L_0039;\n\tv58 = *([v54 @ X0_v2+E0]);\n\tv59 = v58 == 0;\n\tv60 = ~v59;\n\tif (v60) goto L_0039;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v54, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0039:\n\tUnityEngine.Debug::LogError(\"GameAnalytics: REMEMBER THE SDK NEEDS TO BE MANUALLY INITIALIZED NOW\");\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void NewDesignEvent(string eventName)
		{
			if (_hasInitializeBeenCalled)
			{
				GA_Design.CreateNewEvent(eventName, null, null);
			}
			else
			{
				Debug.LogError("GameAnalytics: REMEMBER THE SDK NEEDS TO BE MANUALLY INITIALIZED NOW");
			}
		}

		[Token(Token = "0x600000E")]
		[Address(RVA = "0x15A228C", Offset = "0x15A228C", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1F060C0]);\n\tv23 = *([v22 @ X8_v17]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, eventValue, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20297F5]) = v41;\nL_001A:\n\tv47 = ~v45._hasInitializeBeenCalled;\n\tif (v47) goto L_002D;\n\tGameAnalyticsSDK.Events.GA_Design::NewEvent(eventName, eventValue, 0);\n\treturn;\nL_002D:\n\tgoto L_003D;\n\tv62 = *([v58 @ X0_v2+E0]);\n\tv63 = v62 == 0;\n\tv64 = ~v63;\n\tif (v64) goto L_003D;\n\tv66 = \"il2cpp_codegen_runtime_class_init\"(v58, methodInfo, v26, v27, v28, v29, v30, v31, eventValue, v32, v33, v34, v35, v36, v37, v38);\nL_003D:\n\tUnityEngine.Debug::LogError(\"GameAnalytics: REMEMBER THE SDK NEEDS TO BE MANUALLY INITIALIZED NOW\");\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void NewDesignEvent(string eventName, float eventValue)
		{
			if (_hasInitializeBeenCalled)
			{
				GA_Design.NewEvent(eventName, eventValue, null);
			}
			else
			{
				Debug.LogError("GameAnalytics: REMEMBER THE SDK NEEDS TO BE MANUALLY INITIALIZED NOW");
			}
		}

		[Token(Token = "0x600000F")]
		[Address(RVA = "0x15A3BA4", Offset = "0x15A3BA4", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EF2D80]);\n\tv23 = *([v22 @ X8_v17]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, progression01, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20297F6]) = v41;\nL_001A:\n\tv47 = ~v45._hasInitializeBeenCalled;\n\tif (v47) goto L_0030;\n\tGameAnalyticsSDK.Events.GA_Progression::CreateEvent(progressionStatus, progression01, 0, 0, 0, 0);\n\treturn;\nL_0030:\n\tgoto L_0040;\n\tv65 = *([v61 @ X0_v2+E0]);\n\tv66 = v65 == 0;\n\tv67 = ~v66;\n\tif (v67) goto L_0040;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v61, progression01, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0040:\n\tUnityEngine.Debug::LogError(\"GameAnalytics: REMEMBER THE SDK NEEDS TO BE MANUALLY INITIALIZED NOW\");\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void NewProgressionEvent(GAProgressionStatus progressionStatus, string progression01)
		{
			if (_hasInitializeBeenCalled)
			{
				GA_Progression.CreateEvent(progressionStatus, progression01, null, null, null, null);
			}
			else
			{
				Debug.LogError("GameAnalytics: REMEMBER THE SDK NEEDS TO BE MANUALLY INITIALIZED NOW");
			}
		}

		[Token(Token = "0x6000010")]
		[Address(RVA = "0x15A3C60", Offset = "0x15A3C60", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = *([1EFA478]);\n\tv27 = *([v26 @ X8_v17]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, progression01, progression02, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20297F7]) = v44;\nL_001C:\n\tv50 = ~v48._hasInitializeBeenCalled;\n\tif (v50) goto L_0033;\n\tGameAnalyticsSDK.Events.GA_Progression::CreateEvent(progressionStatus, progression01, progression02, 0, 0, 0);\n\treturn;\nL_0033:\n\tgoto L_0044;\n\tv69 = *([v65 @ X0_v2+E0]);\n\tv70 = v69 == 0;\n\tv71 = ~v70;\n\tif (v71) goto L_0044;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v65, progression01, progression02, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0044:\n\tUnityEngine.Debug::LogError(\"GameAnalytics: REMEMBER THE SDK NEEDS TO BE MANUALLY INITIALIZED NOW\");\n\treturn;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void NewProgressionEvent(GAProgressionStatus progressionStatus, string progression01, string progression02)
		{
			if (_hasInitializeBeenCalled)
			{
				GA_Progression.CreateEvent(progressionStatus, progression01, progression02, null, null, null);
			}
			else
			{
				Debug.LogError("GameAnalytics: REMEMBER THE SDK NEEDS TO BE MANUALLY INITIALIZED NOW");
			}
		}

		[Token(Token = "0x6000011")]
		[Address(RVA = "0x15A3D20", Offset = "0x15A3D20", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv30 = *([1EBD538]);\n\tv31 = *([v30 @ X8_v17]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, progression01, progression02, progression03, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20297F8]) = v47;\nL_001E:\n\tv53 = ~v51._hasInitializeBeenCalled;\n\tif (v53) goto L_0036;\n\tGameAnalyticsSDK.Events.GA_Progression::CreateEvent(progressionStatus, progression01, progression02, progression03, 0, 0);\n\treturn;\nL_0036:\n\tgoto L_0048;\n\tv73 = *([v69 @ X0_v2+E0]);\n\tv74 = v73 == 0;\n\tv75 = ~v74;\n\tif (v75) goto L_0048;\n\tv77 = \"il2cpp_codegen_runtime_class_init\"(v69, progression01, progression02, progression03, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0048:\n\tUnityEngine.Debug::LogError(\"GameAnalytics: REMEMBER THE SDK NEEDS TO BE MANUALLY INITIALIZED NOW\");\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void NewProgressionEvent(GAProgressionStatus progressionStatus, string progression01, string progression02, string progression03)
		{
			if (_hasInitializeBeenCalled)
			{
				GA_Progression.CreateEvent(progressionStatus, progression01, progression02, progression03, null, null);
			}
			else
			{
				Debug.LogError("GameAnalytics: REMEMBER THE SDK NEEDS TO BE MANUALLY INITIALIZED NOW");
			}
		}

		[Token(Token = "0x6000012")]
		[Address(RVA = "0x15A3DF0", Offset = "0x15A3DF0", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = *([1EAF440]);\n\tv27 = *([v26 @ X8_v17]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, progression01, score, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20297F9]) = v44;\nL_001C:\n\tv50 = ~v48._hasInitializeBeenCalled;\n\tif (v50) goto L_0031;\n\tGameAnalyticsSDK.Events.GA_Progression::NewEvent(progressionStatus, progression01, score, 0);\n\treturn;\nL_0031:\n\tgoto L_0042;\n\tv67 = *([v63 @ X0_v2+E0]);\n\tv68 = v67 == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_0042;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v63, progression01, score, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0042:\n\tUnityEngine.Debug::LogError(\"GameAnalytics: REMEMBER THE SDK NEEDS TO BE MANUALLY INITIALIZED NOW\");\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void NewProgressionEvent(GAProgressionStatus progressionStatus, string progression01, int score)
		{
			if (_hasInitializeBeenCalled)
			{
				GA_Progression.NewEvent(progressionStatus, progression01, score, null);
			}
			else
			{
				Debug.LogError("GameAnalytics: REMEMBER THE SDK NEEDS TO BE MANUALLY INITIALIZED NOW");
			}
		}

		[Token(Token = "0x6000013")]
		[Address(RVA = "0x15A3EA8", Offset = "0x15A3EA8", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv30 = *([1EBE668]);\n\tv31 = *([v30 @ X8_v17]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, progression01, progression02, score, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20297FA]) = v47;\nL_001E:\n\tv53 = ~v51._hasInitializeBeenCalled;\n\tif (v53) goto L_0035;\n\tGameAnalyticsSDK.Events.GA_Progression::NewEvent(progressionStatus, progression01, progression02, score, 0);\n\treturn;\nL_0035:\n\tgoto L_0047;\n\tv72 = *([v68 @ X0_v2+E0]);\n\tv73 = v72 == 0;\n\tv74 = ~v73;\n\tif (v74) goto L_0047;\n\tv76 = \"il2cpp_codegen_runtime_class_init\"(v68, progression01, progression02, score, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0047:\n\tUnityEngine.Debug::LogError(\"GameAnalytics: REMEMBER THE SDK NEEDS TO BE MANUALLY INITIALIZED NOW\");\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void NewProgressionEvent(GAProgressionStatus progressionStatus, string progression01, string progression02, int score)
		{
			if (_hasInitializeBeenCalled)
			{
				GA_Progression.NewEvent(progressionStatus, progression01, progression02, score, null);
			}
			else
			{
				Debug.LogError("GameAnalytics: REMEMBER THE SDK NEEDS TO BE MANUALLY INITIALIZED NOW");
			}
		}

		[Token(Token = "0x6000014")]
		[Address(RVA = "0x15A3F74", Offset = "0x15A3F74", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv34 = *([1F0E4E0]);\n\tv35 = *([v34 @ X8_v17]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, progression01, progression02, progression03, score, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([20297FB]) = v50;\nL_0020:\n\tv56 = ~v54._hasInitializeBeenCalled;\n\tif (v56) goto L_0039;\n\tGameAnalyticsSDK.Events.GA_Progression::NewEvent(progressionStatus, progression01, progression02, progression03, score, 0);\n\treturn;\nL_0039:\n\tgoto L_004C;\n\tv77 = *([v73 @ X0_v2+E0]);\n\tv78 = v77 == 0;\n\tv79 = ~v78;\n\tif (v79) goto L_004C;\n\tv81 = \"il2cpp_codegen_runtime_class_init\"(v73, progression01, progression02, progression03, score, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_004C:\n\tUnityEngine.Debug::LogError(\"GameAnalytics: REMEMBER THE SDK NEEDS TO BE MANUALLY INITIALIZED NOW\");\n\treturn;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void NewProgressionEvent(GAProgressionStatus progressionStatus, string progression01, string progression02, string progression03, int score)
		{
			if (_hasInitializeBeenCalled)
			{
				GA_Progression.NewEvent(progressionStatus, progression01, progression02, progression03, score, null);
			}
			else
			{
				Debug.LogError("GameAnalytics: REMEMBER THE SDK NEEDS TO BE MANUALLY INITIALIZED NOW");
			}
		}

		[Token(Token = "0x6000015")]
		[Address(RVA = "0x15A4048", Offset = "0x15A4048", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv34 = *([1EC67B8]);\n\tv35 = *([v34 @ X8_v17]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, currency, itemType, itemId, methodInfo, v38, v39, v40, amount, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([20297FC]) = v50;\nL_0020:\n\tv56 = ~v54._hasInitializeBeenCalled;\n\tif (v56) goto L_0039;\n\tGameAnalyticsSDK.Events.GA_Resource::NewEvent(flowType, currency, amount, itemType, itemId, 0);\n\treturn;\nL_0039:\n\tgoto L_004C;\n\tv77 = *([v73 @ X0_v2+E0]);\n\tv78 = v77 == 0;\n\tv79 = ~v78;\n\tif (v79) goto L_004C;\n\tv81 = \"il2cpp_codegen_runtime_class_init\"(v73, currency, itemType, itemId, methodInfo, v38, v39, v40, amount, v41, v42, v43, v44, v45, v46, v47);\nL_004C:\n\tUnityEngine.Debug::LogError(\"GameAnalytics: REMEMBER THE SDK NEEDS TO BE MANUALLY INITIALIZED NOW\");\n\treturn;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void NewResourceEvent(GAResourceFlowType flowType, string currency, float amount, string itemType, string itemId)
		{
			if (_hasInitializeBeenCalled)
			{
				GA_Resource.NewEvent(flowType, currency, amount, itemType, itemId, null);
			}
			else
			{
				Debug.LogError("GameAnalytics: REMEMBER THE SDK NEEDS TO BE MANUALLY INITIALIZED NOW");
			}
		}

		[Token(Token = "0x6000016")]
		[Address(RVA = "0x15A4128", Offset = "0x15A4128", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EEA188]);\n\tv23 = *([v22 @ X8_v17]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, message, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20297FD]) = v41;\nL_001A:\n\tv47 = ~v45._hasInitializeBeenCalled;\n\tif (v47) goto L_002D;\n\tGameAnalyticsSDK.Events.GA_Error::CreateNewEvent(severity, message, 0);\n\treturn;\nL_002D:\n\tgoto L_003D;\n\tv62 = *([v58 @ X0_v2+E0]);\n\tv63 = v62 == 0;\n\tv64 = ~v63;\n\tif (v64) goto L_003D;\n\tv66 = \"il2cpp_codegen_runtime_class_init\"(v58, message, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_003D:\n\tUnityEngine.Debug::LogError(\"GameAnalytics: REMEMBER THE SDK NEEDS TO BE MANUALLY INITIALIZED NOW\");\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void NewErrorEvent(GAErrorSeverity severity, string message)
		{
			if (_hasInitializeBeenCalled)
			{
				GA_Error.CreateNewEvent(severity, message, null);
			}
			else
			{
				Debug.LogError("GameAnalytics: REMEMBER THE SDK NEEDS TO BE MANUALLY INITIALIZED NOW");
			}
		}

		[Token(Token = "0x6000017")]
		[Address(RVA = "0x15A41D8", Offset = "0x15A41D8", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv34 = *([1EA8FB8]);\n\tv35 = *([v34 @ X8_v17]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, adType, adSdkName, adPlacement, duration, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([20297FE]) = v50;\nL_0020:\n\tv56 = ~v54._hasInitializeBeenCalled;\n\tif (v56) goto L_0038;\n\tGameAnalyticsSDK.Events.GA_Ads::NewEvent(adAction, adType, adSdkName, adPlacement, duration);\n\treturn;\nL_0038:\n\tgoto L_004B;\n\tv76 = *([v72 @ X0_v2+E0]);\n\tv77 = v76 == 0;\n\tv78 = ~v77;\n\tif (v78) goto L_004B;\n\tv80 = \"il2cpp_codegen_runtime_class_init\"(v72, adType, adSdkName, adPlacement, duration, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_004B:\n\tUnityEngine.Debug::LogError(\"GameAnalytics: REMEMBER THE SDK NEEDS TO BE MANUALLY INITIALIZED NOW\");\n\treturn;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void NewAdEvent(GAAdAction adAction, GAAdType adType, string adSdkName, string adPlacement, long duration)
		{
			if (_hasInitializeBeenCalled)
			{
				GA_Ads.NewEvent(adAction, adType, adSdkName, adPlacement, duration);
			}
			else
			{
				Debug.LogError("GameAnalytics: REMEMBER THE SDK NEEDS TO BE MANUALLY INITIALIZED NOW");
			}
		}

		[Token(Token = "0x6000018")]
		[Address(RVA = "0x15A42A8", Offset = "0x15A42A8", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv34 = *([1ED0D50]);\n\tv35 = *([v34 @ X8_v17]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, adType, adSdkName, adPlacement, noAdReason, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([20297FF]) = v50;\nL_0020:\n\tv56 = ~v54._hasInitializeBeenCalled;\n\tif (v56) goto L_0038;\n\tGameAnalyticsSDK.Events.GA_Ads::NewEvent(adAction, adType, adSdkName, adPlacement, noAdReason);\n\treturn;\nL_0038:\n\tgoto L_004B;\n\tv76 = *([v72 @ X0_v2+E0]);\n\tv77 = v76 == 0;\n\tv78 = ~v77;\n\tif (v78) goto L_004B;\n\tv80 = \"il2cpp_codegen_runtime_class_init\"(v72, adType, adSdkName, adPlacement, noAdReason, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_004B:\n\tUnityEngine.Debug::LogError(\"GameAnalytics: REMEMBER THE SDK NEEDS TO BE MANUALLY INITIALIZED NOW\");\n\treturn;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void NewAdEvent(GAAdAction adAction, GAAdType adType, string adSdkName, string adPlacement, GAAdError noAdReason)
		{
			if (_hasInitializeBeenCalled)
			{
				GA_Ads.NewEvent(adAction, adType, adSdkName, adPlacement, noAdReason);
			}
			else
			{
				Debug.LogError("GameAnalytics: REMEMBER THE SDK NEEDS TO BE MANUALLY INITIALIZED NOW");
			}
		}

		[Token(Token = "0x6000019")]
		[Address(RVA = "0x15A4378", Offset = "0x15A4378", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv30 = *([1F0D9E0]);\n\tv31 = *([v30 @ X8_v17]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, adType, adSdkName, adPlacement, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2029800]) = v47;\nL_001E:\n\tv53 = ~v51._hasInitializeBeenCalled;\n\tif (v53) goto L_0034;\n\tGameAnalyticsSDK.Events.GA_Ads::NewEvent(adAction, adType, adSdkName, adPlacement);\n\treturn;\nL_0034:\n\tgoto L_0046;\n\tv71 = *([v67 @ X0_v2+E0]);\n\tv72 = v71 == 0;\n\tv73 = ~v72;\n\tif (v73) goto L_0046;\n\tv75 = \"il2cpp_codegen_runtime_class_init\"(v67, adType, adSdkName, adPlacement, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0046:\n\tUnityEngine.Debug::LogError(\"GameAnalytics: REMEMBER THE SDK NEEDS TO BE MANUALLY INITIALIZED NOW\");\n\treturn;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void NewAdEvent(GAAdAction adAction, GAAdType adType, string adSdkName, string adPlacement)
		{
			if (_hasInitializeBeenCalled)
			{
				GA_Ads.NewEvent(adAction, adType, adSdkName, adPlacement);
			}
			else
			{
				Debug.LogError("GameAnalytics: REMEMBER THE SDK NEEDS TO BE MANUALLY INITIALIZED NOW");
			}
		}

		[Token(Token = "0x600001A")]
		[Address(RVA = "0x15A4440", Offset = "0x15A4440", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tGameAnalyticsSDK.Events.GA_Setup::SetFacebookId(facebookId);\n\treturn;\n")]
		public static void SetFacebookId(string facebookId)
		{
			GA_Setup.SetFacebookId(facebookId);
		}

		[Token(Token = "0x600001B")]
		[Address(RVA = "0x15A4444", Offset = "0x15A4444", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tGameAnalyticsSDK.Events.GA_Setup::SetGender(gender);\n\treturn;\n")]
		public static void SetGender(GAGender gender)
		{
			GA_Setup.SetGender(gender);
		}

		[Token(Token = "0x600001C")]
		[Address(RVA = "0x15A4448", Offset = "0x15A4448", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tGameAnalyticsSDK.Events.GA_Setup::SetBirthYear(birthYear);\n\treturn;\n")]
		public static void SetBirthYear(int birthYear)
		{
			GA_Setup.SetBirthYear(birthYear);
		}

		[Token(Token = "0x600001D")]
		[Address(RVA = "0x15A444C", Offset = "0x15A444C", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1ECD828]);\n\tv19 = *([v18 @ X8_v14]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029801]) = v38;\nL_0018:\n\tv44 = System.String::Concat(\"Initializing with custom id: \", userId);\n\tgoto L_0029;\n\tv52 = *([v48 @ X8_v7+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_0029;\n\tv61 = v48;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v61, v41, v42, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0029:\n\tUnityEngine.Debug::Log(v44);\n\tgoto L_003C;\n\tv68 = *([v64 @ X0_v6+E0]);\n\tv69 = v68 == 0;\n\tv70 = ~v69;\n\tif (v70) goto L_003C;\n\tv72 = \"il2cpp_codegen_runtime_class_init\"(v64, v60, v42, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_003C:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::SetCustomUserId(userId);\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetCustomId(string userId)
		{
			string message = "Initializing with custom id: " + userId;
			Debug.Log(message);
			GA_Wrapper.SetCustomUserId(userId);
		}

		[Token(Token = "0x600001E")]
		[Address(RVA = "0x15A3608", Offset = "0x15A3608", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EF1C10]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029802]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::SetEnabledManualSessionHandling(enabled);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetEnabledManualSessionHandling(bool enabled)
		{
			GA_Wrapper.SetEnabledManualSessionHandling(enabled);
		}

		[Token(Token = "0x600001F")]
		[Address(RVA = "0x15A45C4", Offset = "0x15A45C4", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F098C8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029803]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::SetEnabledEventSubmission(enabled);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetEnabledEventSubmission(bool enabled)
		{
			GA_Wrapper.SetEnabledEventSubmission(enabled);
		}

		[Token(Token = "0x6000020")]
		[Address(RVA = "0x15A468C", Offset = "0x15A468C", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EE3558]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029804]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<GameAnalyticsSDK.Wrapper.GA_Wrapper>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0021:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::StartSession();\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void StartSession()
		{
			GA_Wrapper.StartSession();
		}

		[Token(Token = "0x6000021")]
		[Address(RVA = "0x15A4788", Offset = "0x15A4788", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EB7EB8]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029805]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<GameAnalyticsSDK.Wrapper.GA_Wrapper>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0021:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::EndSession();\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void EndSession()
		{
			GA_Wrapper.EndSession();
		}

		[Token(Token = "0x6000022")]
		[Address(RVA = "0x15A4884", Offset = "0x15A4884", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tGameAnalyticsSDK.Events.GA_Setup::SetCustomDimension01(customDimension);\n\treturn;\n")]
		public static void SetCustomDimension01(string customDimension)
		{
			GA_Setup.SetCustomDimension01(customDimension);
		}

		[Token(Token = "0x6000023")]
		[Address(RVA = "0x15A4888", Offset = "0x15A4888", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tGameAnalyticsSDK.Events.GA_Setup::SetCustomDimension02(customDimension);\n\treturn;\n")]
		public static void SetCustomDimension02(string customDimension)
		{
			GA_Setup.SetCustomDimension02(customDimension);
		}

		[Token(Token = "0x6000024")]
		[Address(RVA = "0x15A488C", Offset = "0x15A488C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tGameAnalyticsSDK.Events.GA_Setup::SetCustomDimension03(customDimension);\n\treturn;\n")]
		public static void SetCustomDimension03(string customDimension)
		{
			GA_Setup.SetCustomDimension03(customDimension);
		}

		[Token(Token = "0x6000027")]
		[Address(RVA = "0x15A4A00", Offset = "0x15A4A00", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = *([1EC49F0]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029808]) = v35;\nL_0016:\n\tv41 = v39.OnRemoteConfigsUpdatedEvent == 0;\n\tif (v41) goto L_0023;\n\tSystem.Action::Invoke(v39.OnRemoteConfigsUpdatedEvent);\n\treturn;\nL_0023:\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnRemoteConfigsUpdated()
		{
			if (GameAnalytics.OnRemoteConfigsUpdatedEvent != null)
			{
				GameAnalytics.OnRemoteConfigsUpdatedEvent();
			}
		}

		[Token(Token = "0x6000028")]
		[Address(RVA = "0x15A4A64", Offset = "0x15A4A64", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = *([1EA9F88]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029809]) = v35;\nL_0016:\n\tv41 = v39.OnRemoteConfigsUpdatedEvent == 0;\n\tif (v41) goto L_0023;\n\tSystem.Action::Invoke(v39.OnRemoteConfigsUpdatedEvent);\n\treturn;\nL_0023:\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void RemoteConfigsUpdated()
		{
			if (GameAnalytics.OnRemoteConfigsUpdatedEvent != null)
			{
				GameAnalytics.OnRemoteConfigsUpdatedEvent();
			}
		}

		[Token(Token = "0x6000029")]
		[Address(RVA = "0x15A4AC8", Offset = "0x15A4AC8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = GameAnalyticsSDK.GameAnalytics::GetRemoteConfigsValueAsString(key, 0);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string GetRemoteConfigsValueAsString(string key)
		{
			return GetRemoteConfigsValueAsString(key, null);
		}

		[Token(Token = "0x600002A")]
		[Address(RVA = "0x15A4AD0", Offset = "0x15A4AD0", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1ED3EA8]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, defaultValue, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202980A]) = v41;\nL_001B:\n\tgoto L_0029;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0029;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, defaultValue, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0029:\n\treturnVal1 = GameAnalyticsSDK.Wrapper.GA_Wrapper::GetRemoteConfigsValueAsString(key, defaultValue);\n\treturn returnVal1;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string GetRemoteConfigsValueAsString(string key, string defaultValue)
		{
			return GA_Wrapper.GetRemoteConfigsValueAsString(key, defaultValue);
		}

		[Token(Token = "0x600002B")]
		[Address(RVA = "0x15A4BB8", Offset = "0x15A4BB8", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EF3048]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202980B]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<GameAnalyticsSDK.Wrapper.GA_Wrapper>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0021:\n\treturnVal1 = GameAnalyticsSDK.Wrapper.GA_Wrapper::IsRemoteConfigsReady();\n\treturn returnVal1;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsRemoteConfigsReady()
		{
			return GA_Wrapper.IsRemoteConfigsReady();
		}

		[Token(Token = "0x600002C")]
		[Address(RVA = "0x15A4C70", Offset = "0x15A4C70", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EF49B0]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202980C]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<GameAnalyticsSDK.Wrapper.GA_Wrapper>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0021:\n\treturnVal1 = GameAnalyticsSDK.Wrapper.GA_Wrapper::GetRemoteConfigsContentAsString();\n\treturn returnVal1;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string GetRemoteConfigsContentAsString()
		{
			return GA_Wrapper.GetRemoteConfigsContentAsString();
		}

		[Token(Token = "0x600002D")]
		[Address(RVA = "0x15A4D28", Offset = "0x15A4D28", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EDC748]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202980D]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::StartTimer(key);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void StartTimer(string key)
		{
			GA_Wrapper.StartTimer(key);
		}

		[Token(Token = "0x600002E")]
		[Address(RVA = "0x15A4DF0", Offset = "0x15A4DF0", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EE6580]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202980E]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::PauseTimer(key);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void PauseTimer(string key)
		{
			GA_Wrapper.PauseTimer(key);
		}

		[Token(Token = "0x600002F")]
		[Address(RVA = "0x15A4EB8", Offset = "0x15A4EB8", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F01D30]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202980F]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::ResumeTimer(key);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ResumeTimer(string key)
		{
			GA_Wrapper.ResumeTimer(key);
		}

		[Token(Token = "0x6000030")]
		[Address(RVA = "0x15A4F80", Offset = "0x15A4F80", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EB5430]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029810]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\treturnVal1 = GameAnalyticsSDK.Wrapper.GA_Wrapper::StopTimer(key);\n\treturn returnVal1;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static long StopTimer(string key)
		{
			return GA_Wrapper.StopTimer(key);
		}

		[Token(Token = "0x6000031")]
		[Address(RVA = "0x15A3378", Offset = "0x15A3378", Length = "0x1C8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1F02B90]);\n\tv27 = *([v26 @ X8_v26]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv47 = 0 | 1;\n\t*([2029811]) = v47;\nL_001A:\n\tv51 = 0;\n\tv53 = UnityEngine.Application::get_unityVersion();\n\t// 35 NewArr v60 @ X0_v5 (System.Char[]), typeof(System.Char[]), 1\n\tv64 = v60.Length == 0;\n\tif (v64) goto L_00B0;\n\tv60[0] = 0x2E;\n\tv140 = System.String::Split(v53, v60);\n\tv181 = v140.Length;\n\tv275 = v140.Length < 1;\n\tif (v275) goto L_00AF;\nL_0049:\n\tv313 = v77 < v181;\n\tv164 = ~v313;\n\tif (v164) goto L_00B0;\n\tv74 = v77 << 3;\n\tv314 = v140 + v74;\n\tv155 = v314 + 0x20;\n\tv175 = System.Int32::TryParse(*([v155 @ X21_v8]), &v51 @ stack_-44_v1 (System.Int32));\n\tv316 = v77 < v140.Length;\n\tv122 = ~v316;\n\tv178 = v175 == 0;\n\tif (v178) goto L_006E;\n\tif (v122) goto L_00B0;\n\tv328 = *([v155 @ X21_v8]);\n\tv319 = v77 == 0;\n\tv320 = ~v319;\n\tif (v320) goto L_0094;\n\tgoto L_0096;\nL_006E:\n\tif (v122) goto L_00B0;\n\tgoto L_007D;\n\tv338 = *([v321 @ X0_v25+E0]);\n\tv339 = v338 == 0;\n\tv340 = ~v339;\n\tif (v340) goto L_007D;\n\tv342 = \"il2cpp_codegen_runtime_class_init\"(v321, v171, v167, v67, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_007D:\n\tv141 = System.Text.RegularExpressions.Regex::Split(*([v155 @ X21_v8]), \"[^\\\\d]+\");\n\tv345 = v141.Length == 0;\n\tif (v345) goto L_0096;\n\tv179 = v141.Length == 0;\n\tif (v179) goto L_00B0;\n\tv176 = System.Int32::TryParse(v141[0], &v51 @ stack_-44_v1 (System.Int32));\n\tv346 = v176 == 0;\n\tif (v346) goto L_0096;\n\tv180 = v141.Length == 0;\n\tif (v180) goto L_00B0;\n\tv328 = v141[0];\nL_0094:\n\tv337 = System.String::Concat(v151, \".\", v328);\nL_0096:\n\tv181 = v140.Length;\n\tv77 = v77 + 1;\n\tv288 = v77 < v140.Length;\n\tif (v288) goto L_0049;\nL_00AF:\n\treturn v303;\nL_00B0:\n\tv185 = new System.IndexOutOfRangeException();\n\tthrow v185;\n\tthrow System.NullReferenceException;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 122 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static string GetUnityVersion()
		{
			//IL_00b7: Expected O, but got I
			//IL_00c6: Expected O, but got I
			int result = 0;
			string unityVersion = Application.unityVersion;
			char[] array = new char[1];
			string text;
			if (array.Length != 0)
			{
				array[0] = '.';
				string[] array2 = unityVersion.Split(array);
				int num = array2.Length;
				bool flag = array2.Length < 1;
				text = "";
				if (flag)
				{
					goto IL_0242;
				}
				int num2 = 0;
				string text2 = "";
				while (num2 < num)
				{
					int num3 = num2 << 3;
					object obj = (long)(IntPtr)array2 + (long)num3;
					object obj2 = (long)(IntPtr)obj + 32L;
					bool flag2 = int.TryParse((string)obj2, out result);
					bool flag3 = num2 < array2.Length;
					bool flag4 = !flag3;
					string text3;
					if (flag2)
					{
						if (flag4)
						{
							break;
						}
						text3 = (string)obj2;
						if (num2 != 0)
						{
							goto IL_027a;
						}
						text = (string)obj2;
					}
					else
					{
						if (flag4)
						{
							break;
						}
						string[] array3 = Regex.Split((string)obj2, "[^\\d]+");
						bool flag5 = array3.Length == 0;
						text = text2;
						if (!flag5)
						{
							if (array3.Length == 0)
							{
								break;
							}
							bool flag6 = int.TryParse(array3[0], out result);
							bool flag7 = !flag6;
							text = text2;
							if (!flag7)
							{
								if (array3.Length == 0)
								{
									break;
								}
								text3 = array3[0];
								goto IL_027a;
							}
						}
					}
					goto IL_029d;
					IL_029d:
					num = array2.Length;
					num2++;
					bool flag8 = num2 < array2.Length;
					text2 = text;
					if (flag8)
					{
						continue;
					}
					goto IL_0242;
					IL_027a:
					string text4 = text2 + "." + text3;
					text = text4;
					goto IL_029d;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
			IL_0242:
			return text;
		}

		[Token(Token = "0x6000032")]
		[Address(RVA = "0x15A31CC", Offset = "0x15A31CC", Length = "0x148")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv14 = *([1EC05E8]);\n\tv15 = *([v14 @ X8_v23]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029812]) = v35;\nL_0012:\n\tv37 = UnityEngine.Application::get_platform();\n\tv39 = v37 - 0x12;\n\tv40 = v39 < 3;\n\tv41 = ~v40;\n\tif (v41) goto L_002D;\n\tv49 = GameAnalyticsSDK.GameAnalytics::get_SettingsGA();\n\tv194 = v49.Platforms;\n\tgoto L_007B;\nL_002D:\n\tv54 = v37 == 0x1F;\n\tif (v54) goto L_0058;\n\tv69 = v37 != 8;\n\tif (v69) goto L_0072;\n\tv90 = GameAnalyticsSDK.GameAnalytics::get_SettingsGA();\n\tv205 = System.Collections.Generic.List`1<UnityEngine.RuntimePlatform>::Contains(v90.Platforms, 8);\n\tv92 = GameAnalyticsSDK.GameAnalytics::get_SettingsGA();\n\tv195 = v92.Platforms;\n\tv216 = v205 == 0;\n\tif (v216) goto L_FFFFFFFF;\n\tgoto L_0080;\nL_0058:\n\tv70 = GameAnalyticsSDK.GameAnalytics::get_SettingsGA();\n\tv171 = System.Collections.Generic.List`1<UnityEngine.RuntimePlatform>::Contains(v70.Platforms, 0x1F);\n\tv95 = GameAnalyticsSDK.GameAnalytics::get_SettingsGA();\n\tv195 = v95.Platforms;\n\tv211 = v171 == 0;\n\tif (v211) goto L_FFFFFFFF;\n\tgoto L_0080;\nL_0072:\n\tv97 = GameAnalyticsSDK.GameAnalytics::get_SettingsGA();\n\tv194 = v97.Platforms;\nL_007B:\n\t;\nL_0080:\n\treturnVal2 = System.Collections.Generic.List`1<UnityEngine.RuntimePlatform>::IndexOf(v194, v143);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 93 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static int GetPlatformIndex()
		{
			RuntimePlatform platform = Application.platform;
			int num = (int)(platform - 18);
			List<RuntimePlatform> list;
			RuntimePlatform item;
			List<RuntimePlatform> platforms;
			if (num < 3)
			{
				Settings settingsGA = SettingsGA;
				list = settingsGA.Platforms;
				item = RuntimePlatform.MetroPlayerARM;
			}
			else
			{
				if (platform != RuntimePlatform.tvOS)
				{
					if (platform != RuntimePlatform.IPhonePlayer)
					{
						Settings settingsGA2 = SettingsGA;
						list = settingsGA2.Platforms;
						item = platform;
						goto IL_01eb;
					}
					Settings settingsGA3 = SettingsGA;
					bool flag = settingsGA3.Platforms.Contains(RuntimePlatform.IPhonePlayer);
					Settings settingsGA4 = SettingsGA;
					platforms = settingsGA4.Platforms;
					bool flag2 = !flag;
					list = settingsGA4.Platforms;
					if (!flag2)
					{
						goto IL_00e2;
					}
				}
				else
				{
					Settings settingsGA5 = SettingsGA;
					bool flag3 = settingsGA5.Platforms.Contains(RuntimePlatform.tvOS);
					Settings settingsGA6 = SettingsGA;
					platforms = settingsGA6.Platforms;
					bool flag4 = !flag3;
					list = settingsGA6.Platforms;
					if (flag4)
					{
						goto IL_00e2;
					}
				}
				item = RuntimePlatform.tvOS;
			}
			goto IL_01eb;
			IL_01eb:
			return list.IndexOf(item);
			IL_00e2:
			item = RuntimePlatform.IPhonePlayer;
			list = platforms;
			goto IL_01eb;
		}

		[Token(Token = "0x6000033")]
		[Address(RVA = "0x15A5048", Offset = "0x15A5048", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1F0CC08]);\n\tv21 = *([v20 @ X8_v10]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2029813]) = v40;\nL_0014:\n\tv94 = GameAnalyticsSDK.GameAnalytics::get_SettingsGA();\nL_001A:\n\tv100 = v94.Build;\n\tv56 = v103 >= v100._size;\n\tif (v56) goto L_0040;\n\tv153 = GameAnalyticsSDK.GameAnalytics::get_SettingsGA();\n\tSystem.Collections.Generic.List`1<System.String>::set_Item(v153.Build, v103, v38);\n\tv103 = v103 + 1;\n\tv94 = GameAnalyticsSDK.GameAnalytics::get_SettingsGA();\n\tv158 = v94 == 0;\n\tv96 = ~v158;\n\tif (v96) goto L_001A;\n\tthrow System.NullReferenceException;\nL_0040:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetBuildAllPlatforms(string build)
		{
			Settings settingsGA = SettingsGA;
			int num = 0;
			string value = default(string);
			while (true)
			{
				List<string> build2 = settingsGA.Build;
				if (num < build2.Count)
				{
					Settings settingsGA2 = SettingsGA;
					settingsGA2.Build.set_Item(num, value);
					num++;
					settingsGA = SettingsGA;
					if ((object)settingsGA == null)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				break;
			}
		}

		[Token(Token = "0x6000034")]
		[Address(RVA = "0x15A50F0", Offset = "0x15A50F0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GameAnalytics()
		{
		}
	}
}
