using System;
using System.Collections.Generic;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;

namespace GoogleMobileAds.Common
{
	[Token(Token = "0x200002E")]
	public class MobileAdsEventExecutor : MonoBehaviour
	{
		[Token(Token = "0x400009C")]
		public static MobileAdsEventExecutor instance = null;

		[Token(Token = "0x400009D")]
		private static List<Action> adEventsQueue;

		[Token(Token = "0x400009E")]
		private static bool adEventsQueueEmpty;

		[Token(Token = "0x600022E")]
		[Address(RVA = "0x1352440", Offset = "0x1352440", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = UnityEngine.GameObject;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv47 = GoogleMobileAds.Common.MobileAdsEventExecutor;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv53 = UnityEngine.Object;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv78 = \"MobileAdsMainThreadExecuter\";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v78, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A3688A]) = v35;\nL_0021:\n\tgoto L_0023;\n\tv43 = \"il2cpp_codegen_runtime_class_init\"(v36, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0023:\n\tv45 = GoogleMobileAds.Common.MobileAdsEventExecutor::IsActive();\n\tv50 = v45 == 0;\n\tv51 = ~v50;\n\tif (v51) goto L_0057;\n\tv58 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v58, \"MobileAdsMainThreadExecuter\");\n\tv91 = v58 == 0;\n\tif (v91) goto L_0058;\n\tUnityEngine.Object::set_hideFlags(v58, 0x3D);\n\tgoto L_0042;\n\tv103 = \"il2cpp_codegen_runtime_class_init\"(v99, v95, v65, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0042:\n\tUnityEngine.Object::DontDestroyOnLoad(v58);\n\tv110 = UnityEngine.GameObject::AddComponent(v58);\n\tgoto L_0052;\n\tv113 = v111;\n\tv114 = \"il2cpp_codegen_runtime_class_init\"(v113, v63, v65, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv116 = GoogleMobileAds.Common.MobileAdsEventExecutor;\nL_0052:\n\tv71.instance = v110;\nL_0057:\n\treturn;\nL_0058:\n\tthrow v58;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Initialize()
		{
			if (!IsActive())
			{
				GameObject gameObject = new GameObject("MobileAdsMainThreadExecuter");
				if ((object)gameObject == null)
				{
					throw gameObject;
				}
				gameObject.hideFlags = HideFlags.HideAndDontSave;
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
				MobileAdsEventExecutor mobileAdsEventExecutor = gameObject.AddComponent<MobileAdsEventExecutor>();
				instance = mobileAdsEventExecutor;
			}
		}

		[Token(Token = "0x600022F")]
		[Address(RVA = "0x1352560", Offset = "0x1352560", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = GoogleMobileAds.Common.MobileAdsEventExecutor;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv43 = UnityEngine.Object;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A3688B]) = v35;\nL_001A:\n\tgoto L_0023;\n\tv44 = \"il2cpp_codegen_runtime_class_init\"(v36, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv46 = GoogleMobileAds.Common.MobileAdsEventExecutor;\nL_0023:\n\tgoto L_002D;\n\tv53 = v47;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v53, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_002D:\n\treturnVal1 = UnityEngine.Object::op_Inequality(v48.instance, 0);\n\treturn returnVal1;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsActive()
		{
			return instance != null;
		}

		[Token(Token = "0x6000230")]
		[Address(RVA = "0x13525EC", Offset = "0x13525EC", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = UnityEngine.Object;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A3688C]) = v37;\nL_0015:\n\tv40 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_0025;\n\tv46 = v41;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v46, v39, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0025:\n\tUnityEngine.Object::DontDestroyOnLoad(v40);\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Awake()
		{
			GameObject target = base.gameObject;
			UnityEngine.Object.DontDestroyOnLoad(target);
		}

		[Token(Token = "0x6000231")]
		[Address(RVA = "0x1352658", Offset = "0x1352658", Length = "0x194")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv44 = GoogleMobileAds.Common.MobileAdsEventExecutor;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A3688D]) = v38;\nL_001A:\n\tgoto L_0023;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv47 = GoogleMobileAds.Common.MobileAdsEventExecutor;\nL_0023:\n\tSystem.Threading.Monitor::Enter(v48.adEventsQueue, &v52 @ stack_-24_v2 (System.Boolean));\n\tgoto L_002C;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v55, v51, v54, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv61 = GoogleMobileAds.Common.MobileAdsEventExecutor;\nL_002C:\n\tv63 = v62.adEventsQueue;\n\tv68 = v63._items;\n\tv70 = v63._version + 1;\n\tv63._version = v70;\n\tv71 = v63._items == 0;\n\tif (v71) goto L_0066;\n\tv126 = v63._size;\n\tv128 = v63._size < v68.Length;\n\tv129 = ~v128;\n\tif (v129) goto L_004E;\n\tv158 = v63._size + 1;\n\tv63._size = v158;\n\tv68[v126 @ X10_v6 (System.Int32)] = action;\n\tgoto L_004F;\nL_004E:\n\tSystem.Collections.Generic.List`1<System.Action>::AddWithResize(v63, action);\nL_004F:\n\tv170 = System.Collections.Generic.List`1<System.Action>::AddWithResize(v63, v75);\n\tv184.adEventsQueueEmpty = 0;\nL_0055:\n\tv194 = ~v52;\n\tif (v194) goto L_005A;\n\tSystem.Threading.Monitor::Exit(v48.adEventsQueue);\nL_005A:\n\tv200 = v120 == 0;\n\tv118 = ~v200;\n\tif (v118) goto L_0064;\n\treturn;\nL_0064:\n\tv116 = new System.OutOfMemoryException();\n\tv125 = new System.NullReferenceException();\nL_0066:\n\tv157 = new System.NullReferenceException();\n\tgoto L_0072;\nL_0072:\n\tv181 = v75 != 1;\n\tif (v181) goto L_007A;\n\tv186 = System.Collections.Generic.List`1<System.Action>::AddWithResize(v157, v75);\n\tv120 = *([v186 @ X0_v24 (System.Collections.Generic.List`1<System.Action>)]);\n\tv190 = System.Collections.Generic.List`1<System.Action>::AddWithResize(v186, v75);\n\tgoto L_0055;\nL_007A:\n\tgoto L_007D;\n\tX21 = X0;\nL_007D:\n\tv196 = ~v52;\n\tif (v196) goto L_0084;\n\tSystem.Threading.Monitor::Exit(v48.adEventsQueue);\nL_0084:\n\tgoto L_0088;\n\tv213 = System.Collections.Generic.List`1<System.Action>::AddWithResize(v157, v75);\nL_0088:\n\tv216 = new System.OutOfMemoryException();\n\tv234 = System.Collections.Generic.List`1<System.Action>::AddWithResize(v216, v75);\n\treturn;\n// 81 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ExecuteInUpdate(Action action)
		{
			//IL_004e: Expected O, but got I4
			//IL_01af: Expected I, but got O
			//IL_010e: Expected I, but got O
			//IL_00d1: Expected O, but got I4
			bool lockTaken = default(bool);
			Monitor.Enter(adEventsQueue, ref lockTaken);
			List<Action> list = adEventsQueue;
			Action[] items = list._items;
			int version = list._version + 1;
			list._version = version;
			bool flag = list._items == null;
			Action action2 = (Action)lockTaken;
			if (flag)
			{
				goto IL_016c;
			}
			int count = list.Count;
			if (list.Count < items.Length)
			{
				int size = list.Count + 1;
				list._size = size;
				items[count] = action;
				action2 = (Action)lockTaken;
			}
			else
			{
				list.Add(action);
				action2 = action;
			}
			list.Add(action2);
			adEventsQueueEmpty = false;
			nint num = unchecked((nint)null);
			goto IL_0225;
			IL_0225:
			if (lockTaken)
			{
				Monitor.Exit(adEventsQueue);
				action2 = null;
			}
			if (num == 0)
			{
				return;
			}
			OutOfMemoryException ex = new OutOfMemoryException();
			NullReferenceException ex2 = new NullReferenceException();
			goto IL_016c;
			IL_016c:
			NullReferenceException ex3 = new NullReferenceException();
			if ((nint)action2 == 1)
			{
				((List<Action>)(object)ex3).Add(action2);
				List<Action> list2 = default(List<Action>);
				num = (nint)list2;
				list2.Add(action2);
				goto IL_0225;
			}
			if (lockTaken)
			{
				Monitor.Exit(adEventsQueue);
				action2 = null;
			}
			OutOfMemoryException ex4 = new OutOfMemoryException();
			((List<Action>)(object)ex4).Add(action2);
		}

		[Token(Token = "0x6000232")]
		[Address(RVA = "0x13527EC", Offset = "0x13527EC", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = System.Action;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv42 = GoogleMobileAds.Common.MobileAdsEventExecutor;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv47 = Il2CppMethodInfo;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv51 = GoogleMobileAds.Common.MobileAdsEventExecutor+<>c__DisplayClass7_0;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A3688E]) = v38;\nL_001D:\n\tv40 = new GoogleMobileAds.Common.MobileAdsEventExecutor+<>c__DisplayClass7_0();\n\tSystem.Object::.ctor(v40);\n\tv40.eventParam = eventParam;\n\tv59 = new System.Action();\n\tSystem.Action::.ctor(v59, v40, Il2CppMethodInfo);\n\tgoto L_003D;\n\tv84 = \"il2cpp_codegen_runtime_class_init\"(v65, v62, v61, v63, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_003D:\n\tGoogleMobileAds.Common.MobileAdsEventExecutor::ExecuteInUpdate(v59);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void InvokeInUpdate(UnityEvent eventParam)
		{
			Action action = delegate
			{
				eventParam.Invoke();
			};
			ExecuteInUpdate(action);
		}

		[Token(Token = "0x6000233")]
		[Address(RVA = "0x13528C0", Offset = "0x13528C0", Length = "0x33C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv48 = Il2CppMethodInfo;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv57 = Il2CppMethodInfo;\n\tv58 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv62 = Il2CppMethodInfo;\n\tv63 = \"il2cpp_codegen_initialize_runtime_metadata\"(v62, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv156 = Il2CppMethodInfo;\n\tv157 = \"il2cpp_codegen_initialize_runtime_metadata\"(v156, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv201 = Il2CppMethodInfo;\n\tv202 = \"il2cpp_codegen_initialize_runtime_metadata\"(v201, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv208 = Il2CppMethodInfo;\n\tv209 = \"il2cpp_codegen_initialize_runtime_metadata\"(v208, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv219 = System.Collections.Generic.List`1<System.Action>;\n\tv220 = \"il2cpp_codegen_initialize_runtime_metadata\"(v219, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv226 = GoogleMobileAds.Common.MobileAdsEventExecutor;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v226, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv39 = 1;\n\t*([1A3688F]) = v39;\nL_002C:\n\tv41 = 0;\n\tgoto L_0037;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v40, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv52 = GoogleMobileAds.Common.MobileAdsEventExecutor;\nL_0037:\n\tv55 = 0xAD94E8(GoogleMobileAds.Common.MobileAdsEventExecutor, methodInfo, v21, v239, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv59 = ~v53.adEventsQueueEmpty;\n\tv60 = ~v59;\n\tif (v60) goto L_00BF;\n\tv67 = new System.Collections.Generic.List`1<System.Action>();\n\tSystem.Collections.Generic.List`1<System.Action>::.ctor(v67);\n\tgoto L_0051;\n\tv210 = \"il2cpp_codegen_runtime_class_init\"(v203, v161, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv212 = GoogleMobileAds.Common.MobileAdsEventExecutor;\nL_0051:\n\tSystem.Threading.Monitor::Enter(v213.adEventsQueue, &v69 @ stack_-24_v3 (System.Boolean));\n\tgoto L_005E;\n\tv227 = \"il2cpp_codegen_runtime_class_init\"(v221, v215, v217, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_005E:\n\tv387 = v232.adEventsQueue;\n\tSystem.Collections.Generic.List`1<System.Action>::AddRange(v67, v232.adEventsQueue);\n\tv274 = v273.adEventsQueue;\n\tv275 = v273.adEventsQueue == 0;\n\tif (v275) goto L_00C4;\n\tv299 = v274._version + 1;\n\tv274._size = 0;\n\tv274._version = v299;\n\tv310 = v274._size < 1;\n\tif (v310) goto L_007C;\n\tv329 = v274._items;\n\tSystem.Array::Clear(v274._items, 0, v274._size);\nL_007C:\n\tv335 = 0xAD94E8(v329, v387, v274._size, 0, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv340.adEventsQueueEmpty = 1;\nL_0084:\n\tv369 = ~v69;\n\tif (v369) goto L_0089;\n\tSystem.Threading.Monitor::Exit(v213.adEventsQueue);\nL_0089:\n\tv374 = v78 == 0;\n\tv375 = ~v374;\n\tif (v375) goto L_00C2;\n\tv104 = v144 == 3;\n\tif (v104) goto L_0099;\n\tv391 = v144 == 0;\n\tv137 = ~v391;\n\tif (v137) goto L_00BF;\nL_0099:\n\tv325 = v327 == 0;\n\tif (v325) goto L_00C5;\n\tv422 = System.Collections.Generic.List`1<System.Action>::GetEnumerator(v327);\nL_00A5:\n\tv433 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v41 @ stack_-48_v1 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv136 = v433 == 0;\n\tif (v136) goto L_00B8;\n\tv383 = 0;\n\tv436 = *([v383 @ X8_v22 (System.Int32)+20]) == 0;\n\tif (v436) goto L_00A5;\n\t*([v383 @ X8_v22 (System.Int32)+18])(v434, *([v383 @ X8_v22 (System.Int32)+40]), *([v383 @ X8_v22 (System.Int32)+28]), v121, 0, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tgoto L_00A5;\nL_00B8:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v41 @ stack_-48_v1 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\nL_00BF:\n\treturn;\n\tthrow System.NullReferenceException;\nL_00C2:\n\tv263 = new System.OutOfMemoryException();\n\tv271 = new System.NullReferenceException();\nL_00C4:\n\tthrow v67;\nL_00C5:\n\tv328 = new System.NullReferenceException();\n\tgoto L_00D3;\n\tgoto L_00D3;\n\tgoto L_00D3;\nL_00D3:\n\tv351 = v387 != 1;\n\tif (v351) goto L_00DE;\n\tv371 = System.Collections.Generic.List`1<System.Action>::AddRange(v328, v387);\n\tv364 = System.Collections.Generic.List`1<System.Action>::AddRange(v371, v387);\n\tgoto L_0084;\nL_00DE:\n\tgoto L_00E1;\n\tX21 = X0;\nL_00E1:\n\tv377 = ~v69;\n\tif (v377) goto L_FFFFFFFF;\n\tSystem.Threading.Monitor::Exit(v213.adEventsQueue);\n\tgoto L_0112;\n\tv394 = new System.OutOfMemoryException();\n\tgoto L_00F7;\n\tgoto L_00F7;\nL_00F7:\n\tv86 = v387 != 1;\n\tif (v86) goto L_0107;\n\tv440 = System.Collections.Generic.List`1<System.Action>::AddRange(v394, v387);\n\tv448 = System.Collections.Generic.List`1<System.Action>::AddRange(v440, v387);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v41 @ stack_-48_v1 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv138 = *([v440 @ X0_v43 (System.Collections.Generic.List`1<System.Action>)]) == 0;\n\tif (v138) goto L_00BF;\n\tthrow System.OutOfMemoryException;\nL_0107:\n\tgoto L_010D;\n\tX21 = X0;\nL_010D:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v41 @ stack_-48_v1 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tgoto L_0114;\nL_0112:\n\tv416 = System.Collections.Generic.List`1<System.Action>::AddRange(v395, v405);\nL_0114:\n\tv425 = new System.OutOfMemoryException();\n\tv192 = System.Collections.Generic.List`1<System.Action>::AddRange(v425, v190);\n\treturn;\n// 166 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Update()
		{
			//IL_0109: Expected I, but got O
			//IL_02a5: Expected I, but got O
			//IL_0374: Expected I, but got O
			//IL_038f: Expected O, but got I
			List<object>.Enumerator enumerator = default(List<object>.Enumerator);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD94E8");
			if (adEventsQueueEmpty)
			{
				return;
			}
			List<Action> list = new List<Action>();
			bool lockTaken = default(bool);
			Monitor.Enter(adEventsQueue, ref lockTaken);
			IEnumerable<object> enumerable = adEventsQueue;
			list.AddRange(adEventsQueue);
			List<Action> list2 = adEventsQueue;
			bool flag = adEventsQueue == null;
			nint num = 0;
			List<Action> list3 = list;
			if (!flag)
			{
				int version = list2._version + 1;
				list2._size = 0;
				list2._version = version;
				bool flag2 = list2.Count < 1;
				Array array = (Array)(object)list;
				if (!flag2)
				{
					array = list2._items;
					Array.Clear(list2._items, 0, list2.Count);
					enumerable = null;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD94E8");
				adEventsQueueEmpty = true;
				nint num2 = unchecked((nint)null);
				num = list2.Count;
				int num3 = 3;
				list3 = list;
				List<Action> list4 = default(List<Action>);
				while (true)
				{
					if (lockTaken)
					{
						Monitor.Exit(adEventsQueue);
						enumerable = null;
					}
					if (num2 != 0)
					{
						break;
					}
					if (num3 != 3 && num3 != 0)
					{
						return;
					}
					if (list3 != null)
					{
						List<Action>.Enumerator enumerator2 = list3.GetEnumerator();
						while (enumerator.MoveNext())
						{
							int num4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v383 @ X8_v22 (System.Int32)+20]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v383 @ X8_v22 (System.Int32)+18] (should have been resolved before IL gen)");
							}
						}
						enumerator.Dispose();
						return;
					}
					NullReferenceException ex = new NullReferenceException();
					if ((nint)enumerable == 1)
					{
						((List<Action>)(object)ex).AddRange((IEnumerable<Action>)enumerable);
						list4.AddRange((IEnumerable<Action>)enumerable);
						num2 = (nint)list4;
						num3 = 0;
						continue;
					}
					if (lockTaken)
					{
						Monitor.Exit(adEventsQueue);
						enumerable = null;
					}
					NullReferenceException ex2 = ex;
					IEnumerable<Action> enumerable2 = (IEnumerable<Action>)enumerable;
					((List<Action>)(object)ex2).AddRange(enumerable2);
					nint num5 = (nint)enumerable2;
					OutOfMemoryException ex3 = new OutOfMemoryException();
					((List<Action>)(object)ex3).AddRange((IEnumerable<Action>)num5);
					return;
				}
				OutOfMemoryException ex4 = new OutOfMemoryException();
				NullReferenceException ex5 = new NullReferenceException();
			}
			throw list;
		}

		[Token(Token = "0x6000234")]
		[Address(RVA = "0x1352BFC", Offset = "0x1352BFC", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = GoogleMobileAds.Common.MobileAdsEventExecutor;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A36890]) = v34;\nL_0015:\n\tgoto L_001B;\n\tv39 = \"il2cpp_codegen_runtime_class_init\"(v35, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = GoogleMobileAds.Common.MobileAdsEventExecutor;\nL_001B:\n\tv42.instance = 0;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnDisable()
		{
			instance = null;
		}

		[Token(Token = "0x6000235")]
		[Address(RVA = "0x1352C54", Offset = "0x1352C54", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MobileAdsEventExecutor()
		{
		}

		[Token(Token = "0x6000236")]
		[Address(RVA = "0x1352C5C", Offset = "0x1352C5C", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv49 = System.Collections.Generic.List`1<System.Action>;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv54 = GoogleMobileAds.Common.MobileAdsEventExecutor;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv43 = 1;\n\t*([1A36891]) = v43;\nL_001F:\n\tv45.instance = 0;\n\tv47 = new System.Collections.Generic.List`1<System.Action>();\n\tSystem.Collections.Generic.List`1<System.Action>::.ctor(v47);\n\tv56.adEventsQueue = v47;\n\tv57 = System.Collections.Generic.List`1<System.Action>::.ctor(v47);\n\tv64.adEventsQueueEmpty = 1;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static MobileAdsEventExecutor()
		{
			List<Action> list = new List<Action>();
			adEventsQueue = list;
			adEventsQueueEmpty = true;
		}
	}
}
