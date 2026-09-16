using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Facebook.MiniJSON;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Facebook.Unity
{
	[Token(Token = "0x2000048")]
	public class CodelessUIInteractEvent : MonoBehaviour
	{
		[Token(Token = "0x17000057")]
		[field: Token(Token = "0x400007B")]
		[field: FieldOffset(Offset = "0x18")]
		private FBSDKEventBindingManager eventBindingManager
		{
			[Token(Token = "0x6000188")]
			[Address(RVA = "0xD247A0", Offset = "0xD247A0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<eventBindingManager>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x6000189")]
			[Address(RVA = "0xD247A8", Offset = "0xD247A8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<eventBindingManager>k__BackingField = value;\n\treturn;\n")]
			set;
		}

		[Token(Token = "0x600018A")]
		[Address(RVA = "0xD247B0", Offset = "0xD247B0", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1F043B8]);\n\tv17 = *([v16 @ X8_v22]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2023BA0]) = v37;\nL_0018:\n\tgoto L_0021;\n\tv44 = *([v40 @ X0_v2+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_0021;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v40, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0021:\n\tv54 = UnityEngine.Object::FindObjectOfType();\n\tv57 = UnityEngine.Object::op_Equality(v54, 0);\n\tv59 = v57 == 0;\n\tif (v59) goto L_004B;\n\tv63 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v63, \"EventSystem\");\n\tv103 = UnityEngine.GameObject::AddComponent(v63);\n\tv137 = UnityEngine.GameObject::AddComponent(v63);\n\tgoto L_004A;\n\tv142 = *([v138 @ X0_v17+E0]);\n\tv143 = v142 == 0;\n\tv144 = ~v143;\n\tif (v144) goto L_004A;\n\tv146 = \"il2cpp_codegen_runtime_class_init\"(v138, v136, v65, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_004A:\n\tUnityEngine.Object::DontDestroyOnLoad(v63);\nL_004B:\n\tv76 = Facebook.Unity.Constants::get_CurrentPlatform();\n\tv89 = v76 != 1;\n\tif (v89) goto L_0063;\n\tFacebook.Unity.CodelessUIInteractEvent::SetLoggerInitAndroid();\n\treturn;\nL_0063:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Awake()
		{
			//IL_0087: Expected I4, but got O
			EventSystem eventSystem = UnityEngine.Object.FindObjectOfType<EventSystem>();
			if (eventSystem == null)
			{
				GameObject gameObject = new GameObject("EventSystem");
				EventSystem eventSystem2 = gameObject.AddComponent<EventSystem>();
				StandaloneInputModule standaloneInputModule = gameObject.AddComponent<StandaloneInputModule>();
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
				bool flag = (byte)(int)gameObject != 0;
			}
			FacebookUnityPlatform currentPlatform = Constants.CurrentPlatform;
			if (currentPlatform == FacebookUnityPlatform.Android)
			{
				SetLoggerInitAndroid();
			}
		}

		[Token(Token = "0x600018B")]
		[Address(RVA = "0xD248C4", Offset = "0xD248C4", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EEA6F8]);\n\tv19 = *([v18 @ X8_v21]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([2023BA1]) = v39;\nL_0016:\n\tv43 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v43, \"com.facebook.internal.FetchedAppSettingsManager\");\n\tv52 = 1;\n\t// 34 NewArr v54 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\t// 41 Box v61 @ X0_v7, typeof(System.Boolean), &v52 @ X21_v1 (System.Int32)\n\tv64 = v61 == 0;\n\tif (v64) goto L_0036;\n\t// 50 IsInst v78 @ X0_v18, typeof(System.Object), v61 @ X0_v7\nL_0036:\n\tv82 = v54.Length == 0;\n\tif (v82) goto L_004B;\n\tv54[0] = v61;\n\tUnityEngine.AndroidJavaObject::CallStatic(v43, \"setIsUnityInit\", v54);\n\treturn;\n\tv74 = new System.NullReferenceException();\nL_004B:\n\tv87 = new System.IndexOutOfRangeException();\n\tgoto L_0050;\n\tv88 = new System.ArrayTypeMismatchException();\nL_0050:\n\tthrow v96;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void SetLoggerInitAndroid()
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.facebook.internal.FetchedAppSettingsManager");
			int num = 1;
			object[] array = new object[1];
			object obj = (byte)num != 0;
			if (obj != null)
			{
				object obj2 = obj as object;
			}
			if (array.Length != 0)
			{
				array[0] = obj;
				androidJavaClass.CallStatic("setIsUnityInit", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x600018C")]
		[Address(RVA = "0xD249D0", Offset = "0xD249D0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private static void SetLoggerInitIos()
		{
		}

		[Token(Token = "0x600018D")]
		[Address(RVA = "0xD249D4", Offset = "0xD249D4", Length = "0x478")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = &v11 @ X29;\n\tgoto L_0017;\n\tv23 = *([1EA3860]);\n\tv24 = *([v23 @ X8_v59]);\n\tv25 = \"il2cpp_codegen_initialize_method\"(v24, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2023BA2]) = v43;\nL_0017:\n\tv44 = &v11 @ X29 - 0x78;\n\tv47 = 0x6D26F0(v44, 0, 0x44, v28, v29, v30, v31, v32, v118, v34, v35, v36, v37, v38, v39, v40);\n\tv48 = &v49 @ stack_-100;\n\t*([v11 @ X29-88]) = 0;\n\t*([v11 @ X29-80]) = 0;\n\t*([v11 @ X29-90]) = 0;\n\tv53 = UnityEngine.Input::GetMouseButtonDown(0);\n\tv55 = v53 == 0;\n\tif (v55) goto L_00E3;\nL_002C:\n\tgoto L_0033;\n\tv101 = *([v95 @ X0_v16+E0]);\n\tv102 = v101 == 0;\n\tv103 = ~v102;\n\tif (v103) goto L_0033;\n\tv105 = \"il2cpp_codegen_runtime_class_init\"(v95, v85, v56, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0033:\n\tv109 = UnityEngine.EventSystems.EventSystem::get_current();\n\tv242 = UnityEngine.EventSystems.EventSystem::IsPointerOverGameObject(v109);\n\tv278 = v242 == 0;\n\tv200 = ~v278;\n\tif (v200) goto L_006E;\n\tv191 = UnityEngine.Input::get_touchCount();\n\tv135 = v191 < 1;\n\tif (v135) goto L_0106;\n\tgoto L_0055;\n\tv400 = *([v373 @ X0_v107+E0]);\n\tv401 = v400 == 0;\n\tv402 = ~v401;\n\tif (v402) goto L_0055;\n\tv404 = \"il2cpp_codegen_runtime_class_init\"(v373, v183, v56, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0055:\n\tv408 = UnityEngine.EventSystems.EventSystem::get_current();\n\tv438 = UnityEngine.Input::get_touches();\n\tv492 = v438.Length == 0;\n\tif (v492) goto L_0118;\n\tv518 = v438 + 0x20;\n\tv520 = 0x167179C(v518, 0, v253, v28, v29, v30, v31, v32, v118, v34, v35, v36, v37, v38, v39, v40);\n\tv531 = v408 == 0;\n\tif (v531) goto L_011D;\n\tv192 = UnityEngine.EventSystems.EventSystem::IsPointerOverGameObject(v408, v520);\n\tv201 = v192 == 0;\n\tif (v201) goto L_0106;\nL_006E:\n\tgoto L_0075;\n\tv341 = *([v307 @ X0_v59+E0]);\n\tv342 = v341 == 0;\n\tv343 = ~v342;\n\tif (v343) goto L_0075;\n\tv345 = \"il2cpp_codegen_runtime_class_init\"(v307, v291, v280, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0075:\n\tv293 = UnityEngine.EventSystems.EventSystem::get_current();\n\tgoto L_0089;\n\tv439 = *([v410 @ X0_v63+E0]);\n\tv440 = v439 == 0;\n\tv441 = ~v440;\n\tif (v441) goto L_0089;\n\tv443 = \"il2cpp_codegen_runtime_class_init\"(v410, v291, v280, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0089:\n\tv193 = UnityEngine.Object::op_Inequality(0, v293.m_CurrentSelected);\n\tv202 = v193 == 0;\n\tif (v202) goto L_0106;\n\tgoto L_0098;\n\tv521 = *([v493 @ X0_v67+E0]);\n\tv522 = v521 == 0;\n\tv523 = ~v522;\n\tif (v523) goto L_0098;\n\tv525 = \"il2cpp_codegen_runtime_class_init\"(v493, v185, v129, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0098:\n\tv365 = UnityEngine.EventSystems.EventSystem::get_current();\n\tv551 = UnityEngine.Object::get_name(v365.m_CurrentSelected);\n\tv430 = UnityEngine.EventSystems.EventSystem::get_current();\n\tv572 = UnityEngine.GameObject::GetComponent(v430.m_CurrentSelected);\n\tgoto L_00BA;\n\tv580 = *([v574 @ X0_v77+E0]);\n\tv581 = v580 == 0;\n\tv582 = ~v581;\n\tif (v582) goto L_00BA;\n\tv584 = \"il2cpp_codegen_runtime_class_init\"(v574, v570, v129, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_00BA:\n\tv194 = UnityEngine.Object::op_Inequality(0, v572);\n\tv203 = v194 == 0;\n\tif (v203) goto L_0106;\n\tv217 = this.<eventBindingManager>k__BackingField;\n\tv204 = this.<eventBindingManager>k__BackingField == 0;\n\tif (v204) goto L_0106;\n\tv205 = v217.<eventBindings>k__BackingField == 0;\n\tif (v205) goto L_0106;\n\tv594 = System.Collections.Generic.List`1<Facebook.Unity.FBSDKEventBinding>::GetEnumerator(v217.<eventBindings>k__BackingField);\n\t*([v11 @ X29-80]) = *([v11 @ X29-C8]);\n\t*([v11 @ X29-90]) = *([v11 @ X29-D8]);\nL_00D0:\n\tv604 = &v11 @ X29 - 0x90;\n\tv329 = System.Collections.Generic.List`1<Facebook.Unity.FBSDKEventBinding>+Enumerator<Facebook.Unity.FBSDKEventBinding>::MoveNext(v604);\n\tv606 = v329 == 0;\n\tif (v606) goto L_FFFFFFFF;\n\tv180 = *([v11 @ X29-80]);\n\tv610 = Facebook.Unity.FBSDKViewHiearchy::GetPath(v430.m_CurrentSelected, 0x23);\n\tv600 = Facebook.Unity.FBSDKViewHiearchy::CheckPathMatchPath(v610, *([v180 @ X21_v15 (System.Int32)+30]));\n\tv602 = v600 == 0;\n\tif (v602) goto L_00D0;\n\tgoto L_0109;\nL_00E3:\n\tv100 = UnityEngine.Input::get_touchCount();\n\tv60 = v100 < 1;\n\tif (v60) goto L_0106;\n\tv115 = UnityEngine.Input::GetTouch(0);\n\tv244 = &v11 @ X29 - 0x78;\n\tv245 = &v11 @ X29 - 0xD8;\n\tv246 = 0x6D2410(v244, v245, 0x44, v28, v29, v30, v31, v32, v118, v34, v35, v36, v37, v38, v39, v40);\n\tv302 = &v11 @ X29 - 0x78;\n\tv88 = 0x16717C4(v302, 0, 0x44, v28, v29, v30, v31, v32, v118, v34, v35, v36, v37, v38, v39, v40);\n\tv90 = v88 == 0;\n\tif (v90) goto L_002C;\nL_0106:\n\treturn;\nL_0109:\n\tv225 = 0;\n\t*([v48 @ X22_v1]) = 0xF4;\n\tgoto L_0141;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tv338 = new System.NullReferenceException();\n\tv372 = new System.NullReferenceException();\n\tv399 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\tv468 = new System.NullReferenceException();\n\tv491 = new System.NullReferenceException();\nL_0118:\n\tv517 = new System.IndexOutOfRangeException();\n\tthrow v517;\nL_011D:\n\tv548 = new System.NullReferenceException();\n\tgoto L_017D;\n\t// 287 Jump @b113\n\tgoto L_012C;\n\t// 289 Jump @b113\n\t// 290 Jump @b113\n\t// 291 Jump @b113\n\t// 292 Jump @b113\n\t// 293 Jump @b113\n\t// 294 Jump @b113\n\t// 295 Jump @b113\n\t// 296 Jump @b113\n\t// 297 Jump @b113\n\t// 298 Jump @b113\n\tgoto L_012C;\nL_012C:\n\tX19 = X0;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_017D;\n\tX0 = X19;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = 0;\n\tX20 = 0xFFFFFFFF;\nL_0141:\n\tv619 = &v11 @ X29 - 0x90;\n\tv620 = System.Collections.Generic.List`1<Facebook.Unity.FBSDKEventBinding>+Enumerator<Facebook.Unity.FBSDKEventBinding>::Dispose(v619);\n\tgoto L_014A;\nL_014A:\n\tgoto L_015D;\n\tv661 = *([v48 @ X22_v1+v225 @ X20_v16 (System.Int32)*4]) == 0xF4;\n\tif (v661) goto L_015D;\nL_0159:\n\tthrow System.TypeLoadException;\n\tgoto L_0159;\nL_015D:\n\tv206 = v180 == 0;\n\tif (v206) goto L_0106;\n\tgoto L_016F;\n\tv677 = *([v673 @ X0_v90+E0]);\n\tv678 = v677 == 0;\n\tv679 = ~v678;\n\tif (v679) goto L_016F;\n\tv681 = \"il2cpp_codegen_runtime_class_init\"(v673, v187, v131, v28, v29, v30, v31, v32, v117, v34, v35, v36, v37, v38, v39, v40);\nL_016F:\n\tFacebook.Unity.FB::LogAppEvent(*([v180 @ X21_v15 (System.Int32)+10]), 0, 0);\n\tgoto L_0106;\n\t// 369 Jump @b113\n\t// 370 Jump @b113\nL_017D:\n\tv137 = v520 != 1;\n\tif (v137) goto L_0198;\n\tv556 = 0x6D2BC0(v548, v520, v253, v28, v29, v30, v31, v32, v118, v34, v35, v36, v37, v38, v39, v40);\n\tv220 = *([v556 @ X0_v28]);\n\tv567 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v220 @ X8_v10]), v253, v28, v29, v30, v31, v32, v118, v34, v35, v36, v37, v38, v39, v40);\n\tv573 = v567 & 1;\n\tv208 = v573 == 0;\n\tif (v208) goto L_018E;\n\tv198 = 0x6D2490(v567, *([v220 @ X8_v10]), v253, v28, v29, v30, v31, v32, v118, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_0106;\nL_018E:\n\tv579 = 0x6D1E60(8, *([v220 @ X8_v10]), v253, v28, v29, v30, v31, v32, v118, v34, v35, v36, v37, v38, v39, v40);\n\t*([v579 @ X0_v32]) = *([v556 @ X0_v28]);\n\tv265 = 0x1E8A000 + 0x870;\n\tv588 = 0x6D2A00(v579, v265, 0, v28, v29, v30, v31, v32, v118, v34, v35, v36, v37, v38, v39, v40);\n\tv560 = 0x6D2490(v588, v265, 0, v28, v29, v30, v31, v32, v118, v34, v35, v36, v37, v38, v39, v40);\nL_0198:\n\tv564 = 0x6D2380(v272, v265, v253, v28, v29, v30, v31, v32, v118, v34, v35, v36, v37, v38, v39, v40);\n\tv268 = 0x846AA4(v564, v265, v253, v28, v29, v30, v31, v32, v118, v34, v35, v36, v37, v38, v39, v40);\n\treturn;\n// 216 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void Update()
		{
			//IL_04f5: Expected O, but got I
			//IL_030a: Expected O, but got I
			//IL_0319: Expected O, but got I
			//IL_0337: Expected O, but got I
			//IL_00c5: Expected O, but got I
			//IL_055c: Expected O, but got I
			//IL_0598: Expected O, but got I4
			//IL_05d4: Expected O, but got I
			//IL_029c: Expected O, but got I
			//IL_041b: Expected O, but got I
			object obj = obj;
			object obj2 = (long)(IntPtr)obj - 120L;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D26F0 (native memset)");
			object obj4 = default(object);
			object obj3 = obj4;
			_ = 0;
			_ = 0;
			_ = 0;
			bool mouseButtonDown = Input.GetMouseButtonDown(0);
			bool flag = !mouseButtonDown;
			int num = 68;
			if (flag)
			{
				int touchCount = Input.touchCount;
				if (touchCount < 1)
				{
					return;
				}
				Touch touch = Input.GetTouch(0);
				object obj5 = (long)(IntPtr)obj - 120L;
				object obj6 = (long)(IntPtr)obj - 216L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
				object obj7 = (long)(IntPtr)obj - 120L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @16717C4 (inside UnityEngine.SendMouseEvents::.cctor +0x1A4)");
				object obj8 = default(object);
				bool flag2 = obj8 == null;
				num = 68;
				if (!flag2)
				{
					return;
				}
			}
			EventSystem current = EventSystem.current;
			if (!current.IsPointerOverGameObject())
			{
				int touchCount2 = Input.touchCount;
				if (touchCount2 < 1)
				{
					return;
				}
				EventSystem current2 = EventSystem.current;
				Touch[] touches = Input.touches;
				int num2;
				if (touches.Length == 0)
				{
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					num = 0;
					num2 = 0;
					throw ex;
				}
				object obj9 = (long)(IntPtr)touches + 32L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @167179C (inside UnityEngine.SendMouseEvents::.cctor +0x17C)");
				bool flag3 = (object)current2 == null;
				int num3 = default(int);
				num2 = num3;
				if (flag3)
				{
					NullReferenceException ex2 = new NullReferenceException();
					bool flag4 = num3 != 1;
					NullReferenceException ex3 = ex2;
					if (!flag4)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
						object obj11 = default(object);
						object obj10 = obj11;
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
						object obj12 = default(object);
						if ((uint)((ulong)(long)(IntPtr)obj12 & 1uL) != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
							return;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1E60 (native __cxa_allocate_exception)");
						object obj13 = obj11;
						num2 = 32022528 + 2160;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2A00 (native __cxa_throw)");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
						num = 0;
						NullReferenceException ex4 = default(NullReferenceException);
						ex3 = ex4;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
					return;
				}
				if (!current2.IsPointerOverGameObject(num3))
				{
					return;
				}
			}
			EventSystem current3 = EventSystem.current;
			if (!(null != current3.currentSelectedGameObject))
			{
				return;
			}
			EventSystem current4 = EventSystem.current;
			string text = current4.currentSelectedGameObject.name;
			EventSystem current5 = EventSystem.current;
			Button component = current5.currentSelectedGameObject.GetComponent<Button>();
			if (!(null != component))
			{
				return;
			}
			FBSDKEventBindingManager fBSDKEventBindingManager = eventBindingManager;
			if (eventBindingManager == null || fBSDKEventBindingManager.eventBindings == null)
			{
				return;
			}
			List<FBSDKEventBinding>.Enumerator enumerator = fBSDKEventBindingManager.eventBindings.GetEnumerator();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ X29-C8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ X29-D8]");
			_ = 0;
			int num4;
			List<FBSDKCodelessPathComponent> path;
			do
			{
				List<FBSDKEventBinding>.Enumerator enumerator2 = (List<FBSDKEventBinding>.Enumerator)((long)(IntPtr)obj - 144L);
				if (((List<FBSDKEventBinding>.Enumerator*)enumerator2)->MoveNext())
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ X29-80]");
					num4 = 0;
					path = FBSDKViewHiearchy.GetPath(current5.currentSelectedGameObject, 35);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ X21_v15 (System.Int32)+30]");
					continue;
				}
				num4 = 0;
				break;
			}
			while (!FBSDKViewHiearchy.CheckPathMatchPath(path, (List<FBSDKCodelessPathComponent>)0));
			int num5 = 0;
			obj3 = 244;
			List<FBSDKEventBinding>.Enumerator enumerator3 = (List<FBSDKEventBinding>.Enumerator)((long)(IntPtr)obj - 144L);
			((List<FBSDKEventBinding>.Enumerator*)enumerator3)->Dispose();
			if (num4 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ X21_v15 (System.Int32)+10]");
				FB.LogAppEvent((string)0);
			}
		}

		[Token(Token = "0x600018E")]
		[Address(RVA = "0xD24E74", Offset = "0xD24E74", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1F04600]);\n\tv23 = *([v22 @ X8_v17]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, message, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023BA3]) = v41;\nL_0017:\n\tv44 = Facebook.MiniJSON.Json;\n\tv46 = *([v44 @ X0_v2 (Il2CppClass<Facebook.MiniJSON.Json>)+12F]) & 2;\n\tv47 = v46 == 0;\n\tif (v47) goto L_001F;\n\tv49 = *([v44 @ X0_v2 (Il2CppClass<Facebook.MiniJSON.Json>)+E0]) == 0;\n\tif (v49) goto L_0038;\nL_001F:\n\tv52 = message == 0;\n\tif (v52) goto L_0052;\nL_0022:\n\tv59 = Facebook.MiniJSON.Json+Parser::Parse(message);\n\tv112 = v59 == 0;\n\tif (v112) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0052;\nL_0038:\n\tv124 = message == 0;\n\tv56 = ~v124;\n\tif (v56) goto L_0022;\n\tgoto L_0052;\n\tv62 = v62_asT == 0;\n\tif (v62) goto L_FFFFFFFF;\n\tgoto L_0052;\nL_0052:\n\tv123 = new Facebook.Unity.FBSDKEventBindingManager();\n\tFacebook.Unity.FBSDKEventBindingManager::.ctor(v123, v113);\n\tthis.<eventBindingManager>k__BackingField = v123;\n\treturn;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnReceiveMapping(string message)
		{
			//IL_010c: Expected I, but got O
			IntPtr intPtr = (IntPtr)typeof(Json);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X0_v2 (Il2CppClass<Facebook.MiniJSON.Json>)+12F]");
			string listDict;
			if (0u != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X0_v2 (Il2CppClass<Facebook.MiniJSON.Json>)+E0]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					if (message != null)
					{
						goto IL_004f;
					}
					listDict = message;
					goto IL_013f;
				}
			}
			bool flag = message == null;
			listDict = message;
			if (!flag)
			{
				goto IL_004f;
			}
			goto IL_013f;
			IL_013f:
			FBSDKEventBindingManager fBSDKEventBindingManager = new FBSDKEventBindingManager((List<object>)(object)listDict);
			eventBindingManager = fBSDKEventBindingManager;
			return;
			IL_004f:
			object obj = Json.Parser.Parse(message);
			if (obj == null)
			{
				listDict = null;
			}
			else
			{
				List<object> list = obj as List<object>;
				listDict = (string)((list == null) ? null : obj);
			}
			goto IL_013f;
		}

		[Token(Token = "0x600018F")]
		[Address(RVA = "0xD25138", Offset = "0xD25138", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CodelessUIInteractEvent()
		{
		}
	}
}
