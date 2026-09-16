using System;
using System.Collections.Generic;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.UDP
{
	[HideInInspector]
	[Token(Token = "0x2000004")]
	internal class MainThreadDispatcher : MonoBehaviour
	{
		[Token(Token = "0x400000F")]
		public static readonly string OBJECT_NAME = "UnityChannelMainThreadDispatcher";

		[Token(Token = "0x4000010")]
		private static List<Action> s_Callbacks;

		[Token(Token = "0x4000011")]
		private static Dictionary<float, Action> delayAction;

		[Token(Token = "0x4000012")]
		private static bool s_CallbacksPending;

		[Token(Token = "0x4000013")]
		private static bool _initialized;

		[Token(Token = "0x6000009")]
		[Address(RVA = "0x15C9BEC", Offset = "0x15C9BEC", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F029B0]);\n\tv19 = *([v18 @ X8_v18]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([20299D2]) = v39;\nL_0019:\n\tgoto L_0025;\n\tv46 = *([v42 @ X0_v2 (Il2CppClass<UnityEngine.UDP.MainThreadDispatcher>)+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0025;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v42, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv50 = UnityEngine.UDP.MainThreadDispatcher;\nL_0025:\n\tv58 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v58, v54.OBJECT_NAME);\n\tgoto L_0038;\n\tv69 = *([v65 @ X0_v6+E0]);\n\tv70 = v69 == 0;\n\tv71 = ~v70;\n\tgoto L_0038;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v65, v60, v61, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0038:\n\tUnityEngine.Object::DontDestroyOnLoad(v58);\n\tUnityEngine.Object::set_hideFlags(v58, 3);\n\tv88 = UnityEngine.GameObject::AddComponent(v58);\n\tv91._initialized = 1;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void init()
		{
			GameObject gameObject = new GameObject(OBJECT_NAME);
			Object.DontDestroyOnLoad(gameObject);
			gameObject.hideFlags = HideFlags.HideInHierarchy | HideFlags.HideInInspector;
			MainThreadDispatcher mainThreadDispatcher = gameObject.AddComponent<MainThreadDispatcher>();
			_initialized = true;
		}

		[Token(Token = "0x600000A")]
		[Address(RVA = "0x15C8DD8", Offset = "0x15C8DD8", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EB9B90]);\n\tv21 = *([v20 @ X8_v26]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20299D3]) = v40;\nL_001A:\n\tgoto L_0023;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<UnityEngine.UDP.MainThreadDispatcher>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0023;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = UnityEngine.UDP.MainThreadDispatcher;\nL_0023:\n\tv56 = ~v54._initialized;\n\tv57 = ~v56;\n\tif (v57) goto L_0034;\n\tgoto L_002F;\n\tv71 = *([v50 @ X0_v3 (Il2CppClass<UnityEngine.UDP.MainThreadDispatcher>)+E0]);\n\tv72 = v71 == 0;\n\tv73 = ~v72;\n\tif (v73) goto L_002F;\n\tv75 = \"il2cpp_codegen_runtime_class_init\"(v50, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002F:\n\tUnityEngine.UDP.MainThreadDispatcher::init();\nL_0034:\n\tgoto L_003F;\n\tv76 = *([v62 @ X0_v4 (Il2CppClass<UnityEngine.UDP.MainThreadDispatcher>)+E0]);\n\tv77 = v76 == 0;\n\tv78 = ~v77;\n\tgoto L_003F;\n\tv87 = \"il2cpp_codegen_runtime_class_init\"(v62, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv80 = UnityEngine.UDP.MainThreadDispatcher;\nL_003F:\n\tSystem.Threading.Monitor::Enter(v83.s_Callbacks);\n\tgoto L_004D;\n\tv92 = *([v88 @ X0_v7 (Il2CppClass<UnityEngine.UDP.MainThreadDispatcher>)+E0]);\n\tv93 = v92 == 0;\n\tv94 = ~v93;\n\tgoto L_004D;\n\tv102 = \"il2cpp_codegen_runtime_class_init\"(v88, v84, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv96 = UnityEngine.UDP.MainThreadDispatcher;\nL_004D:\n\tv101 = v99.s_Callbacks == 0;\n\tif (v101) goto L_0063;\n\tSystem.Collections.Generic.List`1<System.Action>::Add(v99.s_Callbacks, runnable);\n\tv108 = System.Collections.Generic.List`1<System.Action>::Add(v99.s_Callbacks, runnable);\n\tv113.s_CallbacksPending = 1;\n\tSystem.Threading.Monitor::Exit(v83.s_Callbacks);\n\treturn;\nL_0063:\n\tv107 = new System.NullReferenceException();\n\tgoto L_006F;\nL_006F:\n\tgoto L_0080;\n\tv129 = 0x6D2BC0(v107, 0, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv175 = 0x6D2490(v129, 0, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tSystem.Threading.Monitor::Exit(v83.s_Callbacks);\n\tv179 = *([v129 @ X0_v15]) == 0;\n\tv164 = ~v179;\n\tif (v164) goto L_0084;\n\treturn;\nL_0080:\n\tv130 = 0x6D2380(v107, 0, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0084:\n\tthrow System.TypeLoadException;\n// 77 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void RunOnMainThread(Action runnable)
		{
			if (!_initialized)
			{
				init();
			}
			Monitor.Enter(s_Callbacks);
			if (s_Callbacks != null)
			{
				s_Callbacks.Add(runnable);
				s_Callbacks.Add(runnable);
				s_CallbacksPending = true;
				Monitor.Exit(s_Callbacks);
				return;
			}
			NullReferenceException ex = new NullReferenceException();
			Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			throw new TypeLoadException();
		}

		[Token(Token = "0x600000B")]
		[Address(RVA = "0x15C9CE8", Offset = "0x15C9CE8", Length = "0x17C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EF1C40]);\n\tv25 = *([v24 @ X8_v26]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, waitTime, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([20299D4]) = v43;\nL_001C:\n\tgoto L_0025;\n\tv50 = *([v46 @ X0_v2 (Il2CppClass<UnityEngine.UDP.MainThreadDispatcher>)+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0025;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v46, methodInfo, v28, v29, v30, v31, v32, v33, waitTime, v34, v35, v36, v37, v38, v39, v40);\n\tv54 = UnityEngine.UDP.MainThreadDispatcher;\nL_0025:\n\tv59 = ~v57._initialized;\n\tv60 = ~v59;\n\tif (v60) goto L_0036;\n\tgoto L_0031;\n\tv74 = *([v53 @ X0_v3 (Il2CppClass<UnityEngine.UDP.MainThreadDispatcher>)+E0]);\n\tv75 = v74 == 0;\n\tv76 = ~v75;\n\tif (v76) goto L_0031;\n\tv78 = \"il2cpp_codegen_runtime_class_init\"(v53, methodInfo, v28, v29, v30, v31, v32, v33, waitTime, v34, v35, v36, v37, v38, v39, v40);\nL_0031:\n\tUnityEngine.UDP.MainThreadDispatcher::init();\nL_0036:\n\tgoto L_0041;\n\tv79 = *([v65 @ X0_v4 (Il2CppClass<UnityEngine.UDP.MainThreadDispatcher>)+E0]);\n\tv80 = v79 == 0;\n\tv81 = ~v80;\n\tgoto L_0041;\n\tv90 = \"il2cpp_codegen_runtime_class_init\"(v65, methodInfo, v28, v29, v30, v31, v32, v33, waitTime, v34, v35, v36, v37, v38, v39, v40);\n\tv83 = UnityEngine.UDP.MainThreadDispatcher;\nL_0041:\n\tSystem.Threading.Monitor::Enter(v86.s_Callbacks);\n\tgoto L_004F;\n\tv95 = *([v91 @ X0_v7 (Il2CppClass<UnityEngine.UDP.MainThreadDispatcher>)+E0]);\n\tv96 = v95 == 0;\n\tv97 = ~v96;\n\tgoto L_004F;\n\tv105 = \"il2cpp_codegen_runtime_class_init\"(v91, v87, v28, v29, v30, v31, v32, v33, waitTime, v34, v35, v36, v37, v38, v39, v40);\n\tv99 = UnityEngine.UDP.MainThreadDispatcher;\nL_004F:\n\tv104 = v102.delayAction == 0;\n\tif (v104) goto L_0067;\n\tSystem.Collections.Generic.Dictionary`2<System.Single, System.Action>::set_Item(v102.delayAction, waitTime, runnable);\n\tv112 = 0x8D8210(v102.delayAction, runnable, Il2CppMethodInfo, v29, v30, v31, v32, v33, waitTime, v34, v35, v36, v37, v38, v39, v40);\n\tv117.s_CallbacksPending = 1;\n\tSystem.Threading.Monitor::Exit(v86.s_Callbacks);\n\treturn;\nL_0067:\n\tv111 = new System.NullReferenceException();\n\tgoto L_0073;\nL_0073:\n\tgoto L_0085;\n\tv134 = 0x6D2BC0(v111, 0, v28, v29, v30, v31, v32, v33, waitTime, v34, v35, v36, v37, v38, v39, v40);\n\tv183 = 0x6D2490(v134, 0, v28, v29, v30, v31, v32, v33, waitTime, v34, v35, v36, v37, v38, v39, v40);\n\tSystem.Threading.Monitor::Exit(v86.s_Callbacks);\n\tv187 = *([v134 @ X0_v15]) == 0;\n\tv170 = ~v187;\n\tif (v170) goto L_0089;\n\treturn;\nL_0085:\n\tv135 = 0x6D2380(v111, 0, v28, v29, v30, v31, v32, v33, waitTime, v34, v35, v36, v37, v38, v39, v40);\nL_0089:\n\tthrow System.TypeLoadException;\n// 82 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void DispatchDelayJob(float waitTime, Action runnable)
		{
			if (!_initialized)
			{
				init();
			}
			Monitor.Enter(s_Callbacks);
			if (delayAction != null)
			{
				delayAction.set_Item(waitTime, runnable);
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8D8210");
				s_CallbacksPending = true;
				Monitor.Exit(s_Callbacks);
				return;
			}
			NullReferenceException ex = new NullReferenceException();
			Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			throw new TypeLoadException();
		}

		[Token(Token = "0x600000C")]
		[Address(RVA = "0x15C9E64", Offset = "0x15C9E64", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1ED5BA0]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, runnable, methodInfo, v26, v27, v28, v29, v30, waitTime, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([20299D5]) = v41;\nL_0018:\n\tv45 = new UnityEngine.UDP.MainThreadDispatcher+<WaitAndDo>d__8();\n\tSystem.Object::.ctor(v45);\n\tv45.<>1__state = 0;\n\tv45.waitTime = waitTime;\n\tv45.runnable = runnable;\n\treturn v45;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IEnumerator<WaitForSeconds> WaitAndDo(float waitTime, Action runnable)
		{
			_003CWaitAndDo_003Ed__8 _003CWaitAndDo_003Ed__9 = null;
			_003CWaitAndDo_003Ed__9._003C_003E1__state = 0;
			_003CWaitAndDo_003Ed__9.waitTime = waitTime;
			_003CWaitAndDo_003Ed__9.runnable = runnable;
			return _003CWaitAndDo_003Ed__9;
		}

		[Token(Token = "0x600000D")]
		[Address(RVA = "0x15C9F14", Offset = "0x15C9F14", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EAEA68]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20299D6]) = v38;\nL_0015:\n\tv41 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_002B;\n\tv49 = *([v45 @ X8_v5+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_002B;\n\tv62 = v45;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v62, v40, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002B:\n\tUnityEngine.Object::DontDestroyOnLoad(v41);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			GameObject target = base.gameObject;
			Object.DontDestroyOnLoad(target);
		}

		[Token(Token = "0x600000E")]
		[Address(RVA = "0x15C9F90", Offset = "0x15C9F90", Length = "0x404")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = &v15 @ X29;\n\tgoto L_001A;\n\tv27 = *([1EBA970]);\n\tv28 = *([v27 @ X8_v73]);\n\tv29 = \"il2cpp_codegen_initialize_method\"(v28, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20299D7]) = v47;\nL_001A:\n\tv49 = &v50 @ stack_-90;\n\t*([v15 @ X29-48]) = 0;\n\t*([v15 @ X29-58]) = 0;\n\t*([v15 @ X29-68]) = 0;\n\tgoto L_002E;\n\tv58 = *([v54 @ X0_v2 (Il2CppClass<UnityEngine.UDP.MainThreadDispatcher>)+E0]);\n\tv59 = v58 == 0;\n\tv60 = ~v59;\n\tgoto L_002E;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v54, methodInfo, v31, v32, v33, v34, v35, v36, v48, v38, v39, v40, v41, v42, v43, v44);\n\tv62 = UnityEngine.UDP.MainThreadDispatcher;\nL_002E:\n\tv67 = System.Collections.Generic.Dictionary`2<System.Single, System.Action>::.ctor(UnityEngine.UDP.MainThreadDispatcher, methodInfo);\n\tv69 = ~v65.s_CallbacksPending;\n\tif (v69) goto L_016E;\n\tgoto L_0040;\n\tv161 = *([v70 @ X0_v6 (Il2CppClass<UnityEngine.UDP.MainThreadDispatcher>)+E0]);\n\tv162 = v161 == 0;\n\tv163 = ~v162;\n\tif (v163) goto L_0040;\n\tv219 = \"il2cpp_codegen_runtime_class_init\"(v70, methodInfo, v31, v32, v33, v34, v35, v36, v48, v38, v39, v40, v41, v42, v43, v44);\n\tv165 = UnityEngine.UDP.MainThreadDispatcher;\nL_0040:\n\tSystem.Threading.Monitor::Enter(v168.s_Callbacks);\n\tgoto L_004D;\n\tv224 = *([v220 @ X0_v9 (Il2CppClass<UnityEngine.UDP.MainThreadDispatcher>)+E0]);\n\tv225 = v224 == 0;\n\tv226 = ~v225;\n\tgoto L_004D;\n\tv234 = \"il2cpp_codegen_runtime_class_init\"(v220, v169, v31, v32, v33, v34, v35, v36, v48, v38, v39, v40, v41, v42, v43, v44);\n\tv228 = UnityEngine.UDP.MainThreadDispatcher;\nL_004D:\n\tv232 = v231.s_Callbacks;\n\tv236 = v232._size == 0;\n\tv237 = ~v236;\n\tif (v237) goto L_006C;\n\tgoto L_0060;\n\tv325 = *([v227 @ X0_v10 (Il2CppClass<UnityEngine.UDP.MainThreadDispatcher>)+E0]);\n\tv326 = v325 == 0;\n\tv327 = ~v326;\n\tif (v327) goto L_0060;\n\tv329 = \"il2cpp_codegen_runtime_class_init\"(v227, v169, v31, v32, v33, v34, v35, v36, v48, v38, v39, v40, v41, v42, v43, v44);\n\tv440 = UnityEngine.UDP.MainThreadDispatcher;\n\tv332 = *([v440 @ X8_v66+B8]);\nL_0060:\n\tv334 = v331.delayAction == 0;\n\tif (v334) goto L_0110;\n\tv371 = System.Collections.Generic.Dictionary`2<System.Single, System.Action>::get_Count(v331.delayAction);\n\tv134 = v371 == 0;\n\tif (v134) goto L_00FF;\nL_006C:\n\tgoto L_0074;\n\tv335 = *([v290 @ X0_v53 (Il2CppClass<UnityEngine.UDP.MainThreadDispatcher>)+E0]);\n\tv336 = v335 == 0;\n\tv337 = ~v336;\n\tgoto L_0074;\n\tv407 = \"il2cpp_codegen_runtime_class_init\"(v290, v287, v31, v32, v33, v34, v35, v36, v48, v38, v39, v40, v41, v42, v43, v44);\n\tv338 = UnityEngine.UDP.MainThreadDispatcher;\nL_0074:\n\tv321 = v341.s_Callbacks;\n\t// 123 NewArr v411 @ X0_v56 (System.Action[]), typeof(System.Action[]), v321._size (System.Int32)\n\tSystem.Collections.Generic.List`1<System.Action>::CopyTo(v367.s_Callbacks, v411);\n\tSystem.Collections.Generic.List`1<System.Action>::Clear(v437.s_Callbacks);\n\tv465 = new System.Collections.Generic.Dictionary`2<System.Single, System.Action>();\n\tSystem.Collections.Generic.Dictionary`2<System.Single, System.Action>::.ctor(v465, v463.delayAction);\n\tSystem.Collections.Generic.Dictionary`2<System.Single, System.Action>::Clear(v450.delayAction);\n\tv596 = System.Collections.Generic.Dictionary`2<System.Single, System.Action>::.ctor(v450.delayAction, Il2CppMethodInfo);\n\tv494.s_CallbacksPending = 0;\n\t*([v49 @ X24_v1]) = 0x7E;\n\tSystem.Threading.Monitor::Exit(v168.s_Callbacks);\nL_00BD:\n\tv562 = v121.Length < 1;\n\tif (v562) goto L_00E6;\nL_00D0:\n\tSystem.Action::Invoke(v121[v547 @ X20_v21 (System.Collections.Generic.List`1<System.Action>)]);\n\tv547 = v547 + 1;\n\tv603 = v547 < v121.Length;\n\tif (v603) goto L_00D0;\nL_00E6:\n\tv632 = System.Collections.Generic.Dictionary`2<System.Single, System.Action>::GetEnumerator(v115);\nL_00EA:\n\tv644 = &v15 @ X29 - 0x68;\n\tv645 = System.Collections.Generic.Dictionary`2<System.Single, System.Action>+Enumerator<System.Single, System.Action>::MoveNext(v644);\n\tv642 = v645 == 0;\n\tif (v642) goto L_00F8;\n\tv650 = UnityEngine.UDP.MainThreadDispatcher::WaitAndDo(v645, *([v15 @ X29-58]), *([v15 @ X29-50]));\n\tv640 = UnityEngine.MonoBehaviour::StartCoroutine(v492, v650);\n\tgoto L_00EA;\nL_00F8:\n\tv143 = 0;\n\t*([v49 @ X24_v1]) = 0xE2;\n\tgoto L_0148;\nL_00FF:\n\t*([v49 @ X24_v1]) = 0xE2;\n\tSystem.Threading.Monitor::Exit(v168.s_Callbacks);\n\tgoto L_016E;\n\tv537 = new System.IndexOutOfRangeException();\nL_0105:\n\tv550 = new System.TypeLoadException();\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tv324 = new System.NullReferenceException();\n\tv369 = new System.NullReferenceException();\n\tv439 = new System.NullReferenceException();\n\tv401 = new System.NullReferenceException();\nL_0110:\n\tv406 = new System.NullReferenceException();\n\tgoto L_011F;\n\tgoto L_011F;\n\tgoto L_011F;\n\tgoto L_011F;\n\tX22 = 0;\n\tgoto L_0129;\n\tX22 = 0;\n\tgoto L_0129;\n\tX22 = 0;\n\tgoto L_0129;\n\tX22 = 0;\n\tgoto L_0129;\nL_011F:\n\tgoto L_0129;\nL_0129:\n\tv179 = 0 != 1;\n\tif (v179) goto L_016F;\n\tv455 = System.Collections.Generic.Dictionary`2<System.Single, System.Action>::.ctor(v406, 0);\n\tv460 = System.Collections.Generic.Dictionary`2<System.Single, System.Action>::.ctor(v455, 0);\n\tSystem.Threading.Monitor::Exit(v168.s_Callbacks);\n\tv471 = *([v455 @ X0_v14 (System.Collections.Generic.Dictionary`2<System.Single, System.Action>)]) == 0;\n\tif (v471) goto L_00BD;\n\tgoto L_0105;\n\tgoto L_0137;\n\tgoto L_0137;\nL_0137:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_016F;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = 0xFFFFFFFF;\nL_0148:\n\tv654 = &v15 @ X29 - 0x68;\n\tv130 = System.Collections.Generic.Dictionary`2<System.Single, System.Action>+Enumerator<System.Single, System.Action>::Dispose(v654);\n\tgoto L_0152;\nL_0152:\n\tgoto L_016E;\n\tv101 = *([v49 @ X24_v1+v143 @ X20_v19 (System.Collections.Generic.List`1<System.Action>)*4]) == 0xE2;\n\tif (v101) goto L_016E;\nL_015F:\n\tgoto L_0105;\n\tgoto L_015F;\nL_016E:\n\treturn;\nL_016F:\n\tv209 = System.Collections.Generic.Dictionary`2<System.Single, System.Action>::.ctor(v406, 0);\n\treturn;\n// 220 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void Update()
		{
			//IL_00ad: Expected I4, but got O
			//IL_01da: Expected O, but got I4
			//IL_00de: Expected O, but got I4
			//IL_033f: Expected O, but got I
			//IL_01cc: Expected O, but got I4
			//IL_014d: Expected O, but got I
			//IL_0378: Expected O, but got I
			//IL_019e: Expected O, but got I
			//IL_019e: Expected F4, but got I
			//IL_019e: Expected O, but got I4
			object obj = obj;
			object obj3 = default(object);
			object obj2 = obj3;
			_ = 0;
			_ = 0;
			_ = 0;
			if (!s_CallbacksPending)
			{
				return;
			}
			Monitor.Enter(s_Callbacks);
			List<Action> list = s_Callbacks;
			MainThreadDispatcher mainThreadDispatcher;
			Dictionary<float, Action> dictionary2;
			Action[] array;
			if (list.Count == 0)
			{
				bool flag = delayAction == null;
				mainThreadDispatcher = this;
				if (flag)
				{
					NullReferenceException ex = (NullReferenceException)(object)new Dictionary<float, Action>((IDictionary<float, Action>)null);
					if (0 == 1)
					{
						Monitor.Exit(s_Callbacks);
						Dictionary<float, Action> dictionary = default(Dictionary<float, Action>);
						bool flag2 = dictionary == null;
						dictionary2 = null;
						array = null;
						if (!flag2)
						{
							TypeLoadException ex2 = new TypeLoadException();
							throw new NullReferenceException();
						}
						goto IL_0103;
					}
					return;
				}
				if (delayAction.Count == 0)
				{
					obj2 = 226;
					Monitor.Exit(s_Callbacks);
					return;
				}
			}
			List<Action> list2 = s_Callbacks;
			Action[] array2 = new Action[list2.Count];
			s_Callbacks.CopyTo(array2);
			s_Callbacks.Clear();
			Dictionary<float, Action> dictionary3 = new Dictionary<float, Action>((int)delayAction);
			delayAction.Clear();
			s_CallbacksPending = false;
			obj2 = 126;
			Monitor.Exit(s_Callbacks);
			dictionary2 = dictionary3;
			array = array2;
			mainThreadDispatcher = this;
			goto IL_0103;
			IL_0103:
			if (array.Length >= 1)
			{
				List<Action> list3 = null;
				do
				{
					array[(object)list3]();
					list3 = (List<Action>)((long)(IntPtr)list3 + 1L);
				}
				while ((long)(IntPtr)list3 < (long)array.Length);
			}
			Dictionary<float, Action>.Enumerator enumerator = dictionary2.GetEnumerator();
			while (true)
			{
				Dictionary<float, Action>.Enumerator enumerator2 = (Dictionary<float, Action>.Enumerator)((long)(IntPtr)obj - 104L);
				bool flag3 = ((Dictionary<float, Action>.Enumerator*)enumerator2)->MoveNext();
				if (!flag3)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ X29-58]");
				IntPtr intPtr = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ X29-50]");
				IEnumerator<WaitForSeconds> routine = ((MainThreadDispatcher)flag3).WaitAndDo((long)intPtr, (Action)0);
				Coroutine coroutine = mainThreadDispatcher.StartCoroutine(routine);
			}
			List<Action> list4 = null;
			obj2 = 226;
			Dictionary<float, Action>.Enumerator enumerator3 = (Dictionary<float, Action>.Enumerator)((long)(IntPtr)obj - 104L);
			((Dictionary<float, Action>.Enumerator*)enumerator3)->Dispose();
		}

		[Token(Token = "0x600000F")]
		[Address(RVA = "0x15CA394", Offset = "0x15CA394", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MainThreadDispatcher()
		{
		}

		[Token(Token = "0x6000010")]
		[Address(RVA = "0x15CA39C", Offset = "0x15CA39C", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv16 = *([1EA6C78]);\n\tv17 = *([v16 @ X8_v18]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([20299D8]) = v37;\nL_0019:\n\tv43.OBJECT_NAME = \"UnityChannelMainThreadDispatcher\";\n\tv48 = new System.Collections.Generic.List`1<System.Action>();\n\tSystem.Collections.Generic.List`1<System.Action>::.ctor(v48);\n\tv54.s_Callbacks = v48;\n\tv58 = new System.Collections.Generic.Dictionary`2<System.Single, System.Action>();\n\tSystem.Collections.Generic.Dictionary`2<System.Single, System.Action>::.ctor(v58);\n\tv64.delayAction = v58;\n\tv65._initialized = 0;\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static MainThreadDispatcher()
		{
			List<Action> list = new List<Action>();
			s_Callbacks = list;
			Dictionary<float, Action> dictionary = new Dictionary<float, Action>();
			delayAction = dictionary;
			_initialized = false;
		}
	}
}
