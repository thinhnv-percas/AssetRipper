using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Spine;
using UnityEngine;

[Token(Token = "0x2000028")]
public class GraphicController : MonoBehaviour
{
	[Token(Token = "0x4000095")]
	[FieldOffset(Offset = "0x20")]
	public List<Box> Boxes;

	[Token(Token = "0x4000096")]
	[FieldOffset(Offset = "0x28")]
	public SpriteRenderer background;

	[Token(Token = "0x4000097")]
	[FieldOffset(Offset = "0x30")]
	public Sprite[] backgroundList;

	[Token(Token = "0x4000098")]
	[FieldOffset(Offset = "0x38")]
	public Transform posRow1;

	[Token(Token = "0x4000099")]
	[FieldOffset(Offset = "0x40")]
	public Transform posRow1_2;

	[Token(Token = "0x400009A")]
	[FieldOffset(Offset = "0x48")]
	public Transform posRow2_2;

	[Token(Token = "0x400009B")]
	[FieldOffset(Offset = "0x50")]
	private float timeResetAnimation;

	[Token(Token = "0x60000FF")]
	[Address(RVA = "0xC01080", Offset = "0xC01080", Length = "0xA4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv16 = UnityEngine.Debug;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv49 = \"oke\";\n\tv34 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv36 = 1;\n\t*([1A35615]) = v36;\nL_001E:\n\tv47 = this.timeResetAnimation >= 0;\n\tif (v47) goto L_0032;\n\tgoto L_002C;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v53, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_002C:\n\tUnityEngine.Debug::Log(\"oke\");\n\tGraphicController::RandomAnimation(this);\n\tgoto L_0034;\nL_0032:\n\tv59 = UnityEngine.Time::get_deltaTime();\n\tv66 = this.timeResetAnimation - v59;\nL_0034:\n\tthis.timeResetAnimation = v66;\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Update()
	{
		float num;
		if (timeResetAnimation < 0f)
		{
			Debug.Log("oke");
			RandomAnimation();
			num = 5f;
		}
		else
		{
			float deltaTime = Time.deltaTime;
			num = timeResetAnimation - deltaTime;
		}
		timeResetAnimation = num;
	}

	[Token(Token = "0x6000100")]
	[Address(RVA = "0xBFD2D0", Offset = "0xBFD2D0", Length = "0x34")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.backgroundList;\n\tUnityEngine.SpriteRenderer::set_sprite(this.background, v2[0]);\n\treturn;\n\tv13 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void Set1RowBackground()
	{
		Sprite[] array = backgroundList;
		background.sprite = array[0];
	}

	[Token(Token = "0x6000101")]
	[Address(RVA = "0xBFD304", Offset = "0xBFD304", Length = "0x38")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.backgroundList;\n\tUnityEngine.SpriteRenderer::set_sprite(this.background, v2[1]);\n\treturn;\n\tv41 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void Set2RowBackground()
	{
		Sprite[] array = backgroundList;
		background.sprite = array[1];
	}

	[Token(Token = "0x6000102")]
	[Address(RVA = "0xBFEA18", Offset = "0xBFEA18", Length = "0xA4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, box, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A35616]) = v36;\nL_0012:\n\tv37 = this.Boxes;\n\tv42 = v37._items;\n\tv44 = v37._version + 1;\n\tv37._version = v44;\n\tv53 = v37._size;\n\tv55 = v37._size < v42.Length;\n\tv56 = ~v55;\n\tif (v56) goto L_003E;\n\tv64 = v37._size + 1;\n\tv37._size = v64;\n\tv42[v53 @ X10_v4 (System.Int32)] = box;\n\treturn;\nL_003E:\n\tSystem.Collections.Generic.List`1<Box>::AddWithResize(v37, box);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void AddBox(Box box)
	{
		List<Box> boxes = Boxes;
		Box[] items = boxes._items;
		int version = boxes._version + 1;
		boxes._version = version;
		int count = boxes.Count;
		if (boxes.Count < items.Length)
		{
			int size = boxes.Count + 1;
			boxes._size = size;
			items[count] = box;
		}
		else
		{
			boxes.Add(box);
		}
	}

	[Token(Token = "0x6000103")]
	[Address(RVA = "0xBFEABC", Offset = "0xBFEABC", Length = "0xD4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv24 = Il2CppMethodInfo;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, list, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv46 = Il2CppMethodInfo;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, list, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv112 = Il2CppMethodInfo;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v112, list, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 1;\n\t*([1A35617]) = v43;\nL_0028:\n\tv59 = list._size < 1;\n\tif (v59) goto L_0055;\nL_0034:\n\tv179 = System.Collections.Generic.List`1<Box>::get_Item(this.Boxes, v109);\n\tv102 = System.Collections.Generic.List`1<System.Collections.Generic.Stack`1<System.Int32>>::get_Item(list, v109);\n\tBox::SetUp(v179, v102);\n\tv109 = v109 + 1;\n\tv123 = v109 < list._size;\n\tif (v123) goto L_0034;\nL_0055:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void SetUp(List<Stack<int>> list)
	{
		if (list.Count >= 1)
		{
			int num = 0;
			do
			{
				Box box = Boxes[num];
				Stack<int> up = list[num];
				box.SetUp(up);
				num++;
			}
			while (num < list.Count);
		}
	}

	[Token(Token = "0x6000104")]
	[Address(RVA = "0xC01124", Offset = "0xC01124", Length = "0x2FC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0049;\n\tv26 = Il2CppMethodInfo;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv56 = Il2CppMethodInfo;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv159 = Il2CppMethodInfo;\n\tv160 = \"il2cpp_codegen_initialize_runtime_metadata\"(v159, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv243 = Il2CppMethodInfo;\n\tv244 = \"il2cpp_codegen_initialize_runtime_metadata\"(v243, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv295 = Il2CppMethodInfo;\n\tv296 = \"il2cpp_codegen_initialize_runtime_metadata\"(v295, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv302 = Il2CppMethodInfo;\n\tv303 = \"il2cpp_codegen_initialize_runtime_metadata\"(v302, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv314 = Il2CppMethodInfo;\n\tv315 = \"il2cpp_codegen_initialize_runtime_metadata\"(v314, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv401 = Il2CppMethodInfo;\n\tv402 = \"il2cpp_codegen_initialize_runtime_metadata\"(v401, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv441 = \"Idle\";\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v441, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 1;\n\t*([1A35618]) = v46;\nL_0049:\n\tv77 = System.Collections.Generic.List`1<Box>::GetEnumerator(this.Boxes);\nL_0050:\n\tv284 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v76 @ stack_-A8_v7 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv298 = v284 == 0;\n\tif (v298) goto L_00AE;\n\tv405 = System.Collections.Generic.Stack`1<System.Object>::GetEnumerator(*([v163 @ stack_-98+40]));\nL_0063:\n\tv460 = System.Collections.Generic.Stack`1<System.Object>+Enumerator<System.Object>::MoveNext(&v214 @ stack_-A8_v9 (System.Collections.Generic.Stack`1<System.Object>+Enumerator<System.Object>));\n\tv456 = v460 == 0;\n\tif (v456) goto L_008D;\n\tv467 = System.Collections.Generic.Stack`1<System.Object>+Enumerator<System.Object>::get_Current(&v214 @ stack_-A8_v9 (System.Collections.Generic.Stack`1<System.Object>+Enumerator<System.Object>));\n\tv453 = UnityEngine.Random::Range(0, 0x64);\n\tv177 = v453 > 9;\n\tif (v177) goto L_0063;\n\tv231 = v467 == 0;\n\tif (v231) goto L_0093;\n\tv238 = *([v467 @ X0_v43+20]);\n\tv232 = *([v467 @ X0_v43+20]) == 0;\n\tif (v232) goto L_0095;\n\tv230 = *([v238 @ X8_v18+E8]) == 0;\n\tif (v230) goto L_0091;\n\tv454 = Spine.AnimationState::SetAnimation(*([v238 @ X8_v18+E8]), 0, \"Idle\", 0);\n\tgoto L_0063;\nL_008D:\n\tSystem.Collections.Generic.Stack`1<System.Object>+Enumerator<System.Object>::Dispose(&v214 @ stack_-A8_v9 (System.Collections.Generic.Stack`1<System.Object>+Enumerator<System.Object>));\n\tgoto L_0050;\n\tgoto L_00DD;\nL_0091:\n\tv224 = new System.NullReferenceException();\n\tgoto L_FFFFFFFF;\nL_0093:\n\tv224 = new System.NullReferenceException();\n\tgoto L_FFFFFFFF;\nL_0095:\n\tv224 = new System.NullReferenceException();\n\tgoto L_FFFFFFFF;\n\tgoto L_009D;\n\tgoto L_009D;\n\tgoto L_009D;\n\tgoto L_009D;\n\tgoto L_009D;\n\tgoto L_009D;\nL_009D:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_00BA;\n\tX0 = 0x1854E70(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = *([X0]);\n\tX0 = 0x1854E80(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_008D;\nL_00AE:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v76 @ stack_-A8_v7 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\nL_00B9:\n\treturn;\nL_00BA:\n\tstack[0] = X1;\n\tstack[68] = X0;\n\tX19 = 0;\nL_00BF:\n\tSystem.Collections.Generic.Stack`1<System.Object>+Enumerator<System.Object>::Dispose(&v123 @ stack_-90_v4 (System.Collections.Generic.Stack`1<System.Object>+Enumerator<System.Object>));\n\tgoto L_00E3;\nL_00CE:\n\tv178 = *([v438 @ X20_v5 (Il2CppMethodInfo)]) != 1;\n\tif (v178) goto L_FFFFFFFF;\n\tv468 = 0x1854E70(v224, *([v438 @ X20_v5 (Il2CppMethodInfo)]), v420, 0, 0, v32, v33, v34, v211, v36, v37, v38, v39, v40, v41, v42);\n\tv470 = 0x1854E80(v468, *([v438 @ X20_v5 (Il2CppMethodInfo)]), v420, 0, 0, v32, v33, v34, v211, v36, v37, v38, v39, v40, v41, v42);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v127 @ stack_-70_v4 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv350 = *([v468 @ X0_v14]) == 0;\n\tif (v350) goto L_00B9;\n\tv348 = new System.OutOfMemoryException();\n\tv355 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_00DD:\n\tv148 = new System.OutOfMemoryException();\n\tv224 = new System.NullReferenceException();\n\tgoto L_00E7;\nL_00E3:\n\tv290 = new System.OutOfMemoryException();\nL_00E7:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v127 @ stack_-70_v4 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tgoto L_00EE;\n\tv309 = 0xBD3CD0(v286, *([v438 @ X20_v5 (Il2CppMethodInfo)]), v420, 0, 0, v32, v33, v34, v211, v36, v37, v38, v39, v40, v41, v42);\nL_00EE:\n\tv312 = new System.OutOfMemoryException();\n\tv224 = 0x9DACB4(v312, *([v438 @ X20_v5 (Il2CppMethodInfo)]), v420, 0, 0, v32, v33, v34, v211, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_00BF;\n\tgoto L_00CE;\n\tgoto L_00CE;\n\tgoto L_00CE;\n\tgoto L_00CE;\n\tgoto L_00CE;\n\tgoto L_00CE;\n\treturn;\n// 145 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void RandomAnimation()
	{
		//IL_002a: Expected O, but got I
		//IL_00a7: Expected O, but got I
		//IL_0111: Expected O, but got I
		List<Box>.Enumerator enumerator = Boxes.GetEnumerator();
		List<object>.Enumerator enumerator2 = default(List<object>.Enumerator);
		Stack<object>.Enumerator enumerator4 = default(Stack<object>.Enumerator);
		while (enumerator2.MoveNext())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ stack_-98+40]");
			object enumerator3 = ((Stack<object>)0).GetEnumerator();
			while (enumerator4.MoveNext())
			{
				object current = enumerator4.Current;
				int num = UnityEngine.Random.Range(0, 100);
				bool flag = num > 9;
				string text = null;
				if (flag)
				{
					continue;
				}
				NullReferenceException ex;
				Stack<object>.Enumerator enumerator5;
				List<object>.Enumerator enumerator6;
				if (current != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v467 @ X0_v43+20]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v467 @ X0_v43+20]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ X8_v18+E8]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ X8_v18+E8]");
							TrackEntry trackEntry = ((Spine.AnimationState)0).SetAnimation(0, "Idle", loop: false);
							text = "Idle";
							continue;
						}
						ex = new NullReferenceException();
						text = null;
						enumerator5 = enumerator4;
						enumerator6 = enumerator2;
						Stack<object>.Enumerator enumerator7 = enumerator4;
						nint num2 = 0;
					}
					else
					{
						ex = new NullReferenceException();
						text = null;
						enumerator5 = enumerator4;
						enumerator6 = enumerator2;
						Stack<object>.Enumerator enumerator7 = enumerator4;
						nint num2 = 0;
					}
				}
				else
				{
					ex = new NullReferenceException();
					text = null;
					enumerator5 = enumerator4;
					enumerator6 = enumerator2;
					Stack<object>.Enumerator enumerator7 = enumerator4;
					nint num2 = 0;
				}
				NullReferenceException ex2 = ex;
				while (true)
				{
					enumerator6.Dispose();
					OutOfMemoryException ex3 = new OutOfMemoryException();
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @9DACB4");
					enumerator5.Dispose();
					OutOfMemoryException ex4 = new OutOfMemoryException();
					ex2 = (NullReferenceException)(object)ex4;
				}
			}
			enumerator4.Dispose();
		}
		enumerator2.Dispose();
	}

	[Token(Token = "0x6000105")]
	[Address(RVA = "0xBFFE9C", Offset = "0xBFFE9C", Length = "0x348")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0051;\n\tv32 = Il2CppMethodInfo;\n\tv33 = \"il2cpp_codegen_initialize_runtime_metadata\"(v32, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv62 = Il2CppMethodInfo;\n\tv63 = \"il2cpp_codegen_initialize_runtime_metadata\"(v62, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv137 = Il2CppMethodInfo;\n\tv138 = \"il2cpp_codegen_initialize_runtime_metadata\"(v137, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv189 = Il2CppMethodInfo;\n\tv190 = \"il2cpp_codegen_initialize_runtime_metadata\"(v189, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv213 = Il2CppMethodInfo;\n\tv214 = \"il2cpp_codegen_initialize_runtime_metadata\"(v213, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv219 = Il2CppMethodInfo;\n\tv220 = \"il2cpp_codegen_initialize_runtime_metadata\"(v219, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv237 = Il2CppMethodInfo;\n\tv238 = \"il2cpp_codegen_initialize_runtime_metadata\"(v237, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv386 = Il2CppMethodInfo;\n\tv387 = \"il2cpp_codegen_initialize_runtime_metadata\"(v386, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv481 = Il2CppMethodInfo;\n\tv482 = \"il2cpp_codegen_initialize_runtime_metadata\"(v481, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv491 = \"Fall\";\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v491, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv52 = 1;\n\t*([1A35619]) = v52;\nL_0051:\n\tv85 = System.Collections.Generic.List`1<Box>::GetEnumerator(this.Boxes);\nL_0058:\n\tv209 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v84 @ stack_-B8_v10 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv216 = v209 == 0;\n\tif (v216) goto L_00B5;\n\tUnityEngine.GameObject::SetActive(*([v141 @ stack_-A8+58]), 0);\n\tv487 = UnityEngine.Component::GetComponent(*([v141 @ stack_-A8+60]));\n\tUnityEngine.Animation::Stop(v487);\n\tv500 = System.Collections.Generic.Stack`1<System.Object>::GetEnumerator(*([v141 @ stack_-A8+40]));\nL_007A:\n\tv512 = System.Collections.Generic.Stack`1<System.Object>+Enumerator<System.Object>::MoveNext(&v161 @ stack_-B8_v12 (System.Collections.Generic.Stack`1<System.Object>+Enumerator<System.Object>));\n\tv514 = v512 == 0;\n\tif (v514) goto L_0092;\n\tv516 = System.Collections.Generic.Stack`1<System.Object>+Enumerator<System.Object>::get_Current(&v161 @ stack_-B8_v12 (System.Collections.Generic.Stack`1<System.Object>+Enumerator<System.Object>));\n\tv178 = v516 == 0;\n\tif (v178) goto L_0098;\n\tv183 = *([v516 @ X0_v52+20]);\n\tv179 = *([v516 @ X0_v52+20]) == 0;\n\tif (v179) goto L_009A;\n\tv177 = *([v183 @ X8_v20+E8]) == 0;\n\tif (v177) goto L_0096;\n\tv508 = Spine.AnimationState::SetAnimation(*([v183 @ X8_v20+E8]), 0, \"Fall\", 0);\n\tgoto L_007A;\nL_0092:\n\tSystem.Collections.Generic.Stack`1<System.Object>+Enumerator<System.Object>::Dispose(&v161 @ stack_-B8_v12 (System.Collections.Generic.Stack`1<System.Object>+Enumerator<System.Object>));\n\tgoto L_0058;\n\tgoto L_00D2;\nL_0096:\n\tv172 = new System.NullReferenceException();\n\tgoto L_00D6;\nL_0098:\n\tv172 = new System.NullReferenceException();\n\tgoto L_00D6;\nL_009A:\n\tv172 = new System.NullReferenceException();\n\tgoto L_00D6;\n\tgoto L_00A1;\n\tgoto L_00A1;\n\tgoto L_00A1;\n\tgoto L_00A1;\n\tgoto L_00A1;\nL_00A1:\n\tX20 = X1;\n\tX19 = X0;\n\tC = X20 < 1;\n\tC = ~C;\n\tTEMP1 = X20 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X20 ^ 1;\n\tTEMP3 = X20 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_00C4;\n\tX0 = X19;\n\tX0 = 0x1854E70(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = *([X0]);\n\tX0 = 0x1854E80(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_0092;\nL_00B5:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v84 @ stack_-B8_v10 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\nL_00C3:\n\treturn;\nL_00C4:\n\tX21 = 0;\nL_00C7:\n\tSystem.Collections.Generic.Stack`1<System.Object>+Enumerator<System.Object>::Dispose(&v152 @ stack_-A0_v2 (System.Collections.Generic.Stack`1<System.Object>+Enumerator<System.Object>));\n\tv217 = v389 == 0;\n\tif (v217) goto L_00EC;\n\tv225 = new System.OutOfMemoryException();\n\tv376 = new System.NullReferenceException();\n\tv477 = new System.NullReferenceException();\n\tv280 = new System.NullReferenceException();\n\tv289 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_00D2:\n\tv126 = new System.OutOfMemoryException();\n\tv172 = new System.NullReferenceException();\nL_00D6:\n\tgoto L_00C7;\n\tgoto L_00E1;\n\tgoto L_00E1;\n\tgoto L_00E1;\n\tgoto L_00E1;\n\tgoto L_00E1;\n\tgoto L_00E1;\n\tgoto L_00E1;\n\tgoto L_00E1;\n\tgoto L_00E1;\n\tgoto L_00E1;\nL_00E1:\n\tX20 = X1;\n\tX19 = X0;\nL_00EC:\n\tv235 = v165 != 1;\n\tif (v235) goto L_00FA;\n\tv378 = 0x1854E70(v172, *([v400 @ X23_v4 (Il2CppMethodInfo)]), v394, 0, 0, v38, v39, v40, v158, v42, v43, v44, v45, v46, v47, v48);\n\tv478 = 0x1854E80(v378, *([v400 @ X23_v4 (Il2CppMethodInfo)]), v394, 0, 0, v38, v39, v40, v158, v42, v43, v44, v45, v46, v47, v48);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v157 @ stack_-80_v2 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv331 = *([v378 @ X0_v14]) == 0;\n\tif (v331) goto L_00C3;\n\tthrow System.OutOfMemoryException;\nL_00FA:\n\tgoto L_00FE;\n\tX19 = X0;\nL_00FE:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v157 @ stack_-80_v2 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tgoto L_0105;\n\tv493 = 0xBD3CD0(v172, *([v399 @ X22_v4 (Il2CppMethodInfo)]), v394, 0, 0, v38, v39, v40, v158, v42, v43, v44, v45, v46, v47, v48);\nL_0105:\n\tv496 = new System.OutOfMemoryException();\n\tv445 = 0x9DACB4(v496, *([v399 @ X22_v4 (Il2CppMethodInfo)]), v394, 0, 0, v38, v39, v40, v158, v42, v43, v44, v45, v46, v47, v48);\n\treturn;\n// 146 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void SetDefaultAnimation()
	{
		//IL_002f: Expected O, but got I
		//IL_0045: Expected O, but got I
		//IL_006d: Expected O, but got I
		//IL_00b5: Expected O, but got I
		//IL_011f: Expected O, but got I
		List<Box>.Enumerator enumerator = Boxes.GetEnumerator();
		List<object>.Enumerator enumerator2 = default(List<object>.Enumerator);
		Stack<object>.Enumerator enumerator4 = default(Stack<object>.Enumerator);
		int num4 = default(int);
		object obj2 = default(object);
		while (true)
		{
			if (enumerator2.MoveNext())
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ stack_-A8+58]");
				((GameObject)0).SetActive(value: false);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ stack_-A8+60]");
				UnityEngine.Animation component = ((Component)0).GetComponent<UnityEngine.Animation>();
				component.Stop();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ stack_-A8+40]");
				object enumerator3 = ((Stack<object>)0).GetEnumerator();
				string text = null;
				while (enumerator4.MoveNext())
				{
					object current = enumerator4.Current;
					Stack<object>.Enumerator enumerator5;
					List<object>.Enumerator enumerator6;
					nint num3;
					if (current != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v516 @ X0_v52+20]");
						object obj = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v516 @ X0_v52+20]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ X8_v20+E8]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ X8_v20+E8]");
								TrackEntry trackEntry = ((Spine.AnimationState)0).SetAnimation(0, "Fall", loop: false);
								text = "Fall";
								continue;
							}
							NullReferenceException ex = new NullReferenceException();
							enumerator5 = enumerator4;
							enumerator6 = enumerator2;
							Stack<object>.Enumerator enumerator7 = enumerator4;
							nint num = 0;
							nint num2 = 0;
							num3 = 0;
						}
						else
						{
							NullReferenceException ex = new NullReferenceException();
							enumerator5 = enumerator4;
							enumerator6 = enumerator2;
							Stack<object>.Enumerator enumerator7 = enumerator4;
							nint num = 0;
							nint num2 = 0;
							num3 = 0;
						}
					}
					else
					{
						NullReferenceException ex = new NullReferenceException();
						enumerator5 = enumerator4;
						enumerator6 = enumerator2;
						Stack<object>.Enumerator enumerator7 = enumerator4;
						nint num = 0;
						nint num2 = 0;
						num3 = 0;
					}
					enumerator5.Dispose();
					if (num4 != 0)
					{
						OutOfMemoryException ex2 = new OutOfMemoryException();
						NullReferenceException ex3 = new NullReferenceException();
						NullReferenceException ex4 = new NullReferenceException();
						NullReferenceException ex5 = new NullReferenceException();
						NullReferenceException ex6 = new NullReferenceException();
						throw new NullReferenceException();
					}
					if (num3 == 1)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E70 (native __cxa_begin_catch)");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E80 (native __cxa_end_catch)");
						enumerator6.Dispose();
						if (obj2 != null)
						{
							throw new OutOfMemoryException();
						}
					}
					else
					{
						enumerator6.Dispose();
						OutOfMemoryException ex7 = new OutOfMemoryException();
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @9DACB4");
					}
					return;
				}
				enumerator4.Dispose();
				num4 = 0;
				continue;
			}
			enumerator2.Dispose();
			break;
		}
	}

	[Token(Token = "0x6000106")]
	[Address(RVA = "0xC01420", Offset = "0xC01420", Length = "0x10")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.timeResetAnimation = 5f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public GraphicController()
	{
		timeResetAnimation = 5f;
	}
}
