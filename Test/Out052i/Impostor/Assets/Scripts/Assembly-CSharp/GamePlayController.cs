using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using CodeStage.AntiCheat.Storage;
using Cpp2ILInjected;
using Lean.Pool;
using Spine;
using Spine.Unity;
using UnityEngine;

[Token(Token = "0x2000026")]
public class GamePlayController : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	[Token(Token = "0x2000027")]
	private sealed class _003C_003Ec
	{
		[Token(Token = "0x4000090")]
		public static readonly _003C_003Ec _003C_003E9;

		[Token(Token = "0x4000091")]
		public static Action _003C_003E9__24_0;

		[Token(Token = "0x4000092")]
		public static Action _003C_003E9__24_1;

		[Token(Token = "0x4000093")]
		public static Action _003C_003E9__24_2;

		[Token(Token = "0x4000094")]
		public static Action _003C_003E9__26_0;

		[Token(Token = "0x60000F9")]
		[Address(RVA = "0xC00E5C", Offset = "0xC00E5C", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv14 = GamePlayController+<>c;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A35610]) = v34;\nL_0012:\n\tv36 = new GamePlayController+<>c();\n\tSystem.Object::.ctor(v36);\n\tv40.<>9 = v36;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static _003C_003Ec()
		{
			_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
			_003C_003E9 = _003C_003Ec2;
		}

		[Token(Token = "0x60000FA")]
		[Address(RVA = "0xC00EB8", Offset = "0xC00EB8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public _003C_003Ec()
		{
		}

		internal void _003CWinning_003Eb__24_0()
		{
			LeanPool.DespawnAll();
		}

		internal void _003CWinning_003Eb__24_1()
		{
			RatingReviewManager instance = SingletonMonoDontDestroy<RatingReviewManager>.Instance;
			instance.EnableRatingReviewPanel();
		}

		internal void _003CWinning_003Eb__24_2()
		{
			GUIManager instance = SingletonMonoDontDestroy<GUIManager>.Instance;
			instance.ActivatingWinningCanvas();
		}

		internal void _003CReplay_003Eb__26_0()
		{
			LeanPool.DespawnAll();
		}
	}

	[Token(Token = "0x4000083")]
	[FieldOffset(Offset = "0x20")]
	public DataController DataController;

	[Token(Token = "0x4000084")]
	[FieldOffset(Offset = "0x28")]
	public GraphicController GraphicController;

	[Token(Token = "0x4000085")]
	[FieldOffset(Offset = "0x30")]
	public int numberRows;

	[Token(Token = "0x4000086")]
	[FieldOffset(Offset = "0x34")]
	public int maxBoxPerRow;

	[Token(Token = "0x4000087")]
	[FieldOffset(Offset = "0x38")]
	public int maxValueCols;

	[Token(Token = "0x4000088")]
	[FieldOffset(Offset = "0x3C")]
	public int numberCols;

	[Token(Token = "0x4000089")]
	[FieldOffset(Offset = "0x40")]
	public int maxCols;

	[Token(Token = "0x400008A")]
	[FieldOffset(Offset = "0x44")]
	public int numberColors;

	[Token(Token = "0x400008B")]
	[FieldOffset(Offset = "0x48")]
	public Stack<Movement> movementSaveStack;

	[Token(Token = "0x400008C")]
	[FieldOffset(Offset = "0x50")]
	internal bool isPeeking;

	[Token(Token = "0x400008D")]
	[FieldOffset(Offset = "0x58")]
	public Box currentBox;

	[Token(Token = "0x400008E")]
	[FieldOffset(Offset = "0x60")]
	public Box selectedBox;

	[Token(Token = "0x400008F")]
	[FieldOffset(Offset = "0x68")]
	public Imposter selectedImposter;

	[Token(Token = "0x17000019")]
	public bool IsPeeking
	{
		[Token(Token = "0x60000E9")]
		[Address(RVA = "0xBFFE28", Offset = "0xBFFE28", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.isPeeking;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return IsPeeking;
		}
		[Token(Token = "0x60000EA")]
		[Address(RVA = "0xBFFE30", Offset = "0xBFFE30", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.isPeeking = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		set
		{
			isPeeking = value;
		}
	}

	[Token(Token = "0x60000EB")]
	[Address(RVA = "0xBFFE3C", Offset = "0xBFFE3C", Length = "0x60")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A35604]) = v33;\nL_0011:\n\tthis.isPeeking = 0;\n\tGraphicController::SetDefaultAnimation(this.GraphicController);\n\tSystem.Collections.Generic.Stack`1<Movement>::Clear(this.movementSaveStack);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void SetDefault()
	{
		isPeeking = false;
		GraphicController.SetDefaultAnimation();
		movementSaveStack.Clear();
	}

	[Token(Token = "0x60000EC")]
	[Address(RVA = "0xBFCBD4", Offset = "0xBFCBD4", Length = "0x10C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv16 = UnityEngine.Object;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv40 = Il2CppMethodInfo;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v40, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv104 = Il2CppMethodInfo;\n\tv34 = \"il2cpp_codegen_initialize_runtime_metadata\"(v104, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv36 = 1;\n\t*([1A35605]) = v36;\nL_0017:\n\tv37 = this.selectedBox;\n\tv42 = *([v37 @ X20_v2 (UnityEngine.Object)+40]);\n\tv106 = *([v42 @ X8_v4+18]) == 0;\n\tif (v106) goto L_FFFFFFFF;\n\tv54 = *([v42 @ X8_v4+18]) >= this.maxValueCols;\n\tif (v54) goto L_FFFFFFFF;\n\tgoto L_0038;\n\tv175 = \"il2cpp_codegen_runtime_class_init\"(v149, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_0038:\n\tv83 = UnityEngine.Object::op_Equality(this.currentBox, v37);\n\tv158 = v83 == 0;\n\tif (v158) goto L_0040;\n\tgoto L_0069;\n\tgoto L_0069;\nL_0040:\n\tv97 = this.currentBox;\n\tv85 = System.Collections.Generic.Stack`1<Imposter>::Peek(v97.imposterStack);\n\tv98 = this.selectedBox;\n\tv86 = System.Collections.Generic.Stack`1<Imposter>::Peek(v98.imposterStack);\n\tv169 = v85.id - v86.id;\n\tv167 = v169 == 0;\n\tv162 = ~v167;\nL_0069:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public bool isCancelHandle()
	{
		//IL_0015: Expected O, but got I
		UnityEngine.Object obj = selectedBox;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ X20_v2 (UnityEngine.Object)+40]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v4+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v4+18]");
			if ((nint)0 >= (nint)maxValueCols || currentBox == obj)
			{
				return true;
			}
			Box box = currentBox;
			Imposter imposter = box.Imposters.Peek();
			Box box2 = selectedBox;
			Imposter imposter2 = box2.Imposters.Peek();
			int num = imposter.id - imposter2.id;
			bool flag = num == 0;
			return !flag;
		}
		return false;
	}

	[Token(Token = "0x60000ED")]
	[Address(RVA = "0xBFCE18", Offset = "0xBFCE18", Length = "0x100")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = Movement;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv42 = Il2CppMethodInfo;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A35606]) = v38;\nL_0019:\n\tv44 = UnityEngine.Component::get_transform(this.selectedImposter);\n\tgoto L_0033;\n\tv81 = UnityEngine.Vector3;\n\tv82 = \"il2cpp_codegen_initialize_runtime_metadata\"(v81, v43, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv83 = 1;\n\t*([1A35519]) = v83;\nL_0033:\n\tUnityEngine.Transform::set_position(v44, v71.zeroVector);\n\tv116 = new Movement();\n\tSystem.Object::.ctor(v116);\n\tv116.imposter = this.selectedImposter;\n\tv116.currentBox = this.currentBox;\n\tSystem.Collections.Generic.Stack`1<Movement>::Push(this.movementSaveStack, v116);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void SaveLastMove()
	{
		Transform transform = selectedImposter.transform;
		transform.position = Vector3.zero;
		Movement item = new Movement(currentBox, null, selectedImposter);
		movementSaveStack.Push(item);
	}

	[Token(Token = "0x60000EE")]
	[Address(RVA = "0xBFCE08", Offset = "0xBFCE08", Length = "0x10")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.isPeeking = 0;\n\tthis.selectedBox = 0;\n\tthis.selectedImposter = 0;\n\tthis.currentBox = 0;\n\treturn;\n")]
	public void ResetPeeking()
	{
		isPeeking = false;
		selectedBox = null;
		selectedImposter = null;
		currentBox = null;
	}

	[Token(Token = "0x60000EF")]
	[Address(RVA = "0xC001E4", Offset = "0xC001E4", Length = "0x258")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\n\tv18 = UnityEngine.Object;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv42 = Il2CppMethodInfo;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv120 = Il2CppMethodInfo;\n\tv121 = \"il2cpp_codegen_initialize_runtime_metadata\"(v120, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv135 = SingletonMonoDontDestroy`1<GUIManager>;\n\tv136 = \"il2cpp_codegen_initialize_runtime_metadata\"(v135, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv161 = SingletonMonoDontDestroy`1<GameManager>;\n\tv162 = \"il2cpp_codegen_initialize_runtime_metadata\"(v161, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv166 = Il2CppMethodInfo;\n\tv167 = \"il2cpp_codegen_initialize_runtime_metadata\"(v166, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv177 = Il2CppMethodInfo;\n\tv178 = \"il2cpp_codegen_initialize_runtime_metadata\"(v177, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv182 = Il2CppMethodInfo;\n\tv183 = \"il2cpp_codegen_initialize_runtime_metadata\"(v182, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv185 = Il2CppMethodInfo;\n\tv186 = \"il2cpp_codegen_initialize_runtime_metadata\"(v185, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv190 = \"Fall\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v190, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A35607]) = v38;\nL_002D:\n\tv39 = this.movementSaveStack;\n\tv45 = v39._size == 0;\n\tif (v45) goto L_00BB;\n\tgoto L_0041;\n\tv137 = \"il2cpp_codegen_runtime_class_init\"(v125, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0041:\n\tv75 = UnityEngine.Object::op_Inequality(this.currentBox, 0);\n\tv164 = v75 == 0;\n\tif (v164) goto L_0064;\n\tv104 = this.currentBox;\n\tUnityEngine.GameObject::SetActive(v104.effect, 0);\n\tv105 = this.selectedImposter;\n\tv106 = v105._animation;\n\tv173 = Spine.AnimationState::SetAnimation(v106.state, 0, \"Fall\", 0);\nL_0064:\n\tv79 = System.Collections.Generic.Stack`1<Movement>::Peek(this.movementSaveStack);\n\tv80 = System.Collections.Generic.Stack`1<Movement>::Pop(this.movementSaveStack);\n\tv109 = v79.targetBox;\n\tv194 = System.Collections.Generic.Stack`1<Imposter>::Peek(v109.imposterStack);\n\tthis.selectedImposter = v194;\n\tthis.isPeeking = 1;\n\t// 126 NotImplemented \"Instruction EXT not yet implemented.\"\n\tthis.currentBox = v79.currentBox;\n\tImposter::MoveToTop(v79.imposter, v79.currentBox, 0.25f);\n\tBox::moveItem(this.currentBox, Il2CppMethodInfo, this.selectedBox, 0);\n\tthis.isPeeking = 0;\n\tthis.currentBox = 0;\n\tthis.selectedBox = 0;\n\tthis.selectedImposter = 0;\n\tgoto L_0099;\n\tv200 = \"il2cpp_codegen_runtime_class_init\"(v197, v70, v63, v58, v56, v24, v25, v26, v51, v49, v29, v30, v31, v32, v33, v34);\nL_0099:\n\tv84 = SingletonMonoDontDestroy`1<GameManager>::get_Instance();\n\tv205 = GameManager::get_numberRewinds(v84);\n\tv71 = v205 - 1;\n\tGameManager::set_numberRewinds(v205, v71);\n\tgoto L_00AA;\n\tv209 = \"il2cpp_codegen_runtime_class_init\"(v206, v71, v63, v58, v56, v24, v25, v26, v51, v49, v29, v30, v31, v32, v33, v34);\nL_00AA:\n\tv85 = SingletonMonoDontDestroy`1<GUIManager>::get_Instance();\n\tGUIManager::SetDefaultGUI(v85);\n\treturn;\nL_00BB:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 126 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void RewindPlay()
	{
		//IL_015d: Expected F4, but got O
		//IL_0176: Expected O, but got I
		//IL_01d1: Expected O, but got I4
		Stack<Movement> stack = movementSaveStack;
		if (stack.Count != 0)
		{
			if (currentBox != null)
			{
				Box box = currentBox;
				box.effect.SetActive(value: false);
				Imposter imposter = selectedImposter;
				SkeletonAnimation animation = imposter._animation;
				TrackEntry trackEntry = animation.state.SetAnimation(0, "Fall", loop: false);
			}
			Movement movement = movementSaveStack.Peek();
			Movement movement2 = movementSaveStack.Pop();
			Box targetBox = movement.targetBox;
			Imposter imposter2 = targetBox.Imposters.Peek();
			selectedImposter = imposter2;
			isPeeking = true;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction EXT not yet implemented.\"");
			currentBox = movement.currentBox;
			movement.imposter.MoveToTop((float)movement.currentBox);
			currentBox.moveItem((Box)0, selectedBox, null);
			isPeeking = false;
			currentBox = null;
			selectedBox = null;
			selectedImposter = null;
			GameManager instance = SingletonMonoDontDestroy<GameManager>.Instance;
			int numberRewinds = instance.numberRewinds;
			int numberRewinds2 = numberRewinds - 1;
			((GameManager)numberRewinds).numberRewinds = numberRewinds2;
			GUIManager instance2 = SingletonMonoDontDestroy<GUIManager>.Instance;
			instance2.SetDefaultGUI();
		}
	}

	[Token(Token = "0x60000F0")]
	[Address(RVA = "0xC005D0", Offset = "0xC005D0", Length = "0x170")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = Il2CppMethodInfo;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv65 = Il2CppMethodInfo;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv75 = Il2CppMethodInfo;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v75, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A35608]) = v38;\nL_001B:\n\tv39 = 0;\n\tv42 = this.GraphicController;\n\tv43 = this.GraphicController == 0;\n\tif (v43) goto L_0051;\n\tv48 = v42.Boxes == 0;\n\tif (v48) goto L_0051;\n\tv73 = System.Collections.Generic.List`1<Box>::GetEnumerator(v42.Boxes);\nL_0030:\n\tv95 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v39 @ stack_-48_v1 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv110 = v95 == 0;\n\tif (v110) goto L_003D;\n\tv91 = Box::isDoneBox(0);\n\tv141 = v141 + v91;\n\tgoto L_0030;\nL_003D:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v39 @ stack_-48_v1 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\nL_0044:\n\tv154 = v141 - this.maxCols;\n\tv156 = v154 == 0;\n\treturn v156;\n\tv56 = new System.NullReferenceException();\nL_0051:\n\tv63 = new System.NullReferenceException();\n\tgoto L_005E;\n\tgoto L_005E;\nL_005E:\n\tv87 = Il2CppMethodInfo != 1;\n\tif (v87) goto L_006E;\n\tv97 = System.Collections.Generic.List`1<Box>+Enumerator<Box>::MoveNext(v63);\n\tv111 = System.Collections.Generic.List`1<Box>+Enumerator<Box>::MoveNext(v97);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v39 @ stack_-48_v1 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv105 = ~v97.m_value;\n\tif (v105) goto L_0044;\n\tthrow System.OutOfMemoryException;\nL_006E:\n\tgoto L_0074;\n\tX20 = X0;\nL_0074:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v39 @ stack_-48_v1 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tgoto L_007B;\n\tv165 = System.Collections.Generic.List`1<Box>+Enumerator<Box>::Dispose(v63);\nL_007B:\n\tv168 = new System.OutOfMemoryException();\n\treturnVal2 = System.Collections.Generic.List`1<Box>+Enumerator<Box>::Dispose(v168);\n\treturn returnVal2;\n// 78 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public unsafe bool isWinning()
	{
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		GraphicController graphicController = GraphicController;
		int num = default(int);
		if ((object)GraphicController != null && graphicController.Boxes != null)
		{
			List<Box>.Enumerator enumerator2 = graphicController.Boxes.GetEnumerator();
			num = 0;
			while (enumerator.MoveNext())
			{
				bool flag = ((Box)null).isDoneBox();
				num += (flag ? 1 : 0);
			}
			enumerator.Dispose();
		}
		else
		{
			NullReferenceException ex = new NullReferenceException();
			if ((nint)0 != 1)
			{
				enumerator.Dispose();
				OutOfMemoryException ex2 = new OutOfMemoryException();
				((List<Box>.Enumerator*)ex2)->Dispose();
				bool result = default(bool);
				return result;
			}
			bool flag2 = ((List<Box>.Enumerator*)ex)->MoveNext();
			bool flag3 = (flag2 ? ((List<Box>.Enumerator*)1) : ((List<Box>.Enumerator*)null))->MoveNext();
			enumerator.Dispose();
			bool flag4 = !((bool*)(flag2 ? 1 : 0))->m_value;
			num = num;
			if (!flag4)
			{
				throw new OutOfMemoryException();
			}
		}
		int num2 = num - maxCols;
		return num2 == 0;
	}

	[Token(Token = "0x60000F1")]
	[Address(RVA = "0xC00740", Offset = "0xC00740", Length = "0x174")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tv18 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv46 = Il2CppMethodInfo;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv53 = Il2CppMethodInfo;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv57 = SingletonMonoDontDestroy`1<GUIManager>;\n\tv58 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv95 = SingletonMonoDontDestroy`1<GameManager>;\n\tv96 = \"il2cpp_codegen_initialize_runtime_metadata\"(v95, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv98 = Il2CppMethodInfo;\n\tv99 = \"il2cpp_codegen_initialize_runtime_metadata\"(v98, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv123 = \"Level\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v123, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A35609]) = v38;\nL_002B:\n\tgoto L_002E;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_002E:\n\tv51 = SingletonMonoDontDestroy`1<GameManager>::get_Instance();\n\tv60 = v51.currentLevel + 1;\n\tv51.currentLevel = v60;\n\tv62 = SingletonMonoDontDestroy`1<GameManager>::get_Instance();\n\tv62.isAddBox = 0;\n\tgoto L_0044;\n\tv124 = \"il2cpp_codegen_runtime_class_init\"(v103, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0044:\n\tv73 = SingletonMonoDontDestroy`1<GUIManager>::get_Instance();\n\tGUIManager::PlayWinningSound(v73);\n\tv74 = SingletonMonoDontDestroy`1<GUIManager>::get_Instance();\n\tUnityEngine.GameObject::SetActive(v74.videoGO, 0);\n\tv76 = SingletonMonoDontDestroy`1<GameManager>::get_Instance();\n\tgoto L_0065;\n\tv134 = v87;\n\tv135 = \"il2cpp_codegen_runtime_class_init\"(v134, v70, v67, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0065:\n\tCodeStage.AntiCheat.Storage.ObscuredPrefs::SetInt(\"Level\", v76.currentLevel);\n\tSystem.Collections.Generic.Stack`1<Movement>::Clear(this.movementSaveStack);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 78 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void ResetAndUpdateGameManager()
	{
		GameManager instance = SingletonMonoDontDestroy<GameManager>.Instance;
		int currentLevel = instance.currentLevel + 1;
		instance.currentLevel = currentLevel;
		GameManager instance2 = SingletonMonoDontDestroy<GameManager>.Instance;
		instance2.isAddBox = false;
		GUIManager instance3 = SingletonMonoDontDestroy<GUIManager>.Instance;
		instance3.PlayWinningSound();
		GUIManager instance4 = SingletonMonoDontDestroy<GUIManager>.Instance;
		instance4.videoGO.SetActive(value: false);
		GameManager instance5 = SingletonMonoDontDestroy<GameManager>.Instance;
		ObscuredPrefs.SetInt("Level", instance5.currentLevel);
		movementSaveStack.Clear();
	}

	[Token(Token = "0x60000F2")]
	[Address(RVA = "0xC008EC", Offset = "0xC008EC", Length = "0xC4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv43 = SingletonMonoDontDestroy`1<GameManager>;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A3560A]) = v35;\nL_001A:\n\tgoto L_001D;\n\tv44 = \"il2cpp_codegen_runtime_class_init\"(v36, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001D:\n\tv47 = SingletonMonoDontDestroy`1<GameManager>::get_Instance();\n\tv59 = v47.currentLevel != 5;\n\tif (v59) goto L_0032;\n\tgoto L_004F;\nL_0032:\n\tgoto L_0035;\n\tv122 = \"il2cpp_codegen_runtime_class_init\"(v86, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0035:\n\tv79 = SingletonMonoDontDestroy`1<GameManager>::get_Instance();\n\tv116 = v79.currentLevel * 0xEEEEEEEF;\n\tv118 = 0x8888888 + v116;\n\tv146 = v118 < 0x11111111;\n\tv112 = ~v146;\n\tv96 = ~v112;\nL_004F:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private bool isGetToDestinationLevel()
	{
		//IL_0070: Expected I4, but got I8
		GameManager instance = SingletonMonoDontDestroy<GameManager>.Instance;
		if (instance.currentLevel == 5)
		{
			return true;
		}
		GameManager instance2 = SingletonMonoDontDestroy<GameManager>.Instance;
		int num = (int)(instance2.currentLevel * 4008636143L);
		int num2 = 143165576 + num;
		bool flag = num2 < 286331153;
		bool flag2 = !flag;
		return !flag2;
	}

	[Token(Token = "0x60000F3")]
	[Address(RVA = "0xBFD044", Offset = "0xBFD044", Length = "0x20C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv18 = System.Action;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv42 = Il2CppMethodInfo;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv47 = Il2CppMethodInfo;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv56 = Il2CppMethodInfo;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv92 = GamePlayController+<>c;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v92, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A3560B]) = v38;\nL_001F:\n\tv40 = GamePlayController::isWinning(this);\n\tv45 = v40 == 0;\n\tif (v45) goto L_007D;\n\tGamePlayController::ResetAndUpdateGameManager(this);\n\tgoto L_002F;\n\tv93 = \"il2cpp_codegen_runtime_class_init\"(v60, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv95 = GamePlayController+<>c;\nL_002F:\n\tv118 = v96.<>9__24_0;\n\tv98 = v96.<>9__24_0 == 0;\n\tv99 = ~v98;\n\tif (v99) goto L_004C;\n\tgoto L_003E;\n\tv123 = \"il2cpp_codegen_runtime_class_init\"(v94, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv125 = GamePlayController+<>c;\nL_003E:\n\tv114 = new System.Action();\n\tSystem.Action::.ctor(v114, v127.<>9, Il2CppMethodInfo);\n\tv117.<>9__24_0 = v114;\nL_004C:\n\tExtensions::StartDelayMethod(this, 2f, v118);\n\tv129 = GamePlayController::isGetToDestinationLevel(this);\n\tgoto L_0059;\n\tv138 = v132;\n\tv139 = \"il2cpp_codegen_runtime_class_init\"(v138, v122, v107, v109, v23, v24, v25, v26, v120, v28, v29, v30, v31, v32, v33, v34);\n\tv142 = GamePlayController+<>c;\nL_0059:\n\tv145 = v129 == 0;\n\tif (v145) goto L_007E;\n\tv173 = v143.<>9__24_1;\n\tv147 = v143.<>9__24_1 == 0;\n\tv148 = ~v147;\n\tif (v148) goto L_00A2;\n\tgoto L_006B;\n\tv178 = v141;\n\tv179 = \"il2cpp_codegen_runtime_class_init\"(v178, v122, v107, v109, v23, v24, v25, v26, v120, v28, v29, v30, v31, v32, v33, v34);\n\tv182 = GamePlayController+<>c;\nL_006B:\n\tv169 = new System.Action();\n\tSystem.Action::.ctor(v169, v184.<>9, Il2CppMethodInfo);\n\tv172.<>9__24_1 = v169;\n\tgoto L_00A2;\nL_007D:\n\treturn;\nL_007E:\n\tv173 = v143.<>9__24_2;\n\tv150 = v143.<>9__24_2 == 0;\n\tv151 = ~v150;\n\tif (v151) goto L_00A2;\n\tgoto L_008E;\n\tv186 = v141;\n\tv187 = \"il2cpp_codegen_runtime_class_init\"(v186, v122, v107, v109, v23, v24, v25, v26, v120, v28, v29, v30, v31, v32, v33, v34);\n\tv190 = GamePlayController+<>c;\nL_008E:\n\tv168 = new System.Action();\n\tSystem.Action::.ctor(v168, v192.<>9, Il2CppMethodInfo);\n\tv171.<>9__24_2 = v168;\nL_00A2:\n\tExtensions::StartDelayMethod(this, 2f, v173);\n\treturn;\n// 100 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void Winning()
	{
		if (!isWinning())
		{
			return;
		}
		ResetAndUpdateGameManager();
		Action callback = _003C_003Ec._003C_003E9__24_0;
		if (_003C_003Ec._003C_003E9__24_0 == null)
		{
			callback = (_003C_003Ec._003C_003E9__24_0 = delegate
			{
				LeanPool.DespawnAll();
			});
		}
		this.StartDelayMethod(2f, callback);
		Action callback2;
		if (isGetToDestinationLevel())
		{
			callback2 = _003C_003Ec._003C_003E9__24_1;
			if (_003C_003Ec._003C_003E9__24_1 == null)
			{
				callback2 = (_003C_003Ec._003C_003E9__24_1 = delegate
				{
					RatingReviewManager instance = SingletonMonoDontDestroy<RatingReviewManager>.Instance;
					instance.EnableRatingReviewPanel();
				});
			}
		}
		else
		{
			callback2 = _003C_003Ec._003C_003E9__24_2;
			if (_003C_003Ec._003C_003E9__24_2 == null)
			{
				callback2 = (_003C_003Ec._003C_003E9__24_2 = delegate
				{
					GUIManager instance = SingletonMonoDontDestroy<GUIManager>.Instance;
					instance.ActivatingWinningCanvas();
				});
			}
		}
		this.StartDelayMethod(2f, callback2);
	}

	[Token(Token = "0x60000F4")]
	[Address(RVA = "0xC009B0", Offset = "0xC009B0", Length = "0xD0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv46 = Il2CppMethodInfo;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv53 = SingletonMonoDontDestroy`1<GUIManager>;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv57 = SingletonMonoDontDestroy`1<GameManager>;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A3560C]) = v38;\nL_0022:\n\tgoto L_0025;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0025:\n\tv51 = SingletonMonoDontDestroy`1<GameManager>::get_Instance();\n\tv63 = v51.currentLevel == 1;\n\tif (v63) goto L_004A;\n\tgoto L_003E;\n\tv102 = \"il2cpp_codegen_runtime_class_init\"(v96, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_003E:\n\tv85 = SingletonMonoDontDestroy`1<GUIManager>::get_Instance();\n\tGUIManager::WatchVideo1(v85);\nL_004A:\n\tDataController::LoadMap(this.DataController);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void NextLevel()
	{
		GameManager instance = SingletonMonoDontDestroy<GameManager>.Instance;
		if (instance.currentLevel != 1)
		{
			GUIManager instance2 = SingletonMonoDontDestroy<GUIManager>.Instance;
			instance2.WatchVideo1();
		}
		DataController.LoadMap();
	}

	[Token(Token = "0x60000F5")]
	[Address(RVA = "0xC00B28", Offset = "0xC00B28", Length = "0x1C0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002E;\n\tv24 = System.Action;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv49 = Il2CppMethodInfo;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv56 = Il2CppMethodInfo;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv63 = Il2CppMethodInfo;\n\tv64 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv67 = SingletonMonoDontDestroy`1<GUIManager>;\n\tv68 = \"il2cpp_codegen_initialize_runtime_metadata\"(v67, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv85 = SingletonMonoDontDestroy`1<GameManager>;\n\tv86 = \"il2cpp_codegen_initialize_runtime_metadata\"(v85, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv91 = Il2CppMethodInfo;\n\tv92 = \"il2cpp_codegen_initialize_runtime_metadata\"(v91, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv122 = GamePlayController+<>c;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v122, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 1;\n\t*([1A3560D]) = v44;\nL_002E:\n\tGamePlayController::SetDefault(this);\n\tgoto L_0036;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v51, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0036:\n\tv61 = SingletonMonoDontDestroy`1<GameManager>::get_Instance();\n\tv61.isAddBox = 0;\n\tgoto L_0045;\n\tv87 = \"il2cpp_codegen_runtime_class_init\"(v72, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0045:\n\tv78 = SingletonMonoDontDestroy`1<GUIManager>::get_Instance();\n\tGUIManager::SetDefaultGUI(v78);\n\tgoto L_0055;\n\tv129 = \"il2cpp_codegen_runtime_class_init\"(v125, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv131 = GamePlayController+<>c;\nL_0055:\n\tv152 = v132.<>9__26_0;\n\tv138 = v132.<>9__26_0 == 0;\n\tv139 = ~v138;\n\tif (v139) goto L_0072;\n\tgoto L_0064;\n\tv159 = \"il2cpp_codegen_runtime_class_init\"(v130, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv161 = GamePlayController+<>c;\nL_0064:\n\tv150 = new System.Action();\n\tSystem.Action::.ctor(v150, v162.<>9, Il2CppMethodInfo);\n\tv151.<>9__26_0 = v150;\nL_0072:\n\tExtensions::StartDelayMethod(this, 0f, v152);\n\tv165 = new System.Action();\n\tSystem.Action::.ctor(v165, this, Il2CppMethodInfo);\n\tExtensions::StartDelayMethod(this, 0f, v165);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 89 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void Replay()
	{
		SetDefault();
		GameManager instance = SingletonMonoDontDestroy<GameManager>.Instance;
		instance.isAddBox = false;
		GUIManager instance2 = SingletonMonoDontDestroy<GUIManager>.Instance;
		instance2.SetDefaultGUI();
		Action callback = _003C_003Ec._003C_003E9__26_0;
		if (_003C_003Ec._003C_003E9__26_0 == null)
		{
			callback = (_003C_003Ec._003C_003E9__26_0 = delegate
			{
				LeanPool.DespawnAll();
			});
		}
		this.StartDelayMethod(0f, callback);
		Action callback2 = delegate
		{
			DataController.LoadMap();
		};
		this.StartDelayMethod(0f, callback2);
	}

	[Token(Token = "0x60000F6")]
	[Address(RVA = "0xC00CE8", Offset = "0xC00CE8", Length = "0xD8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv46 = SingletonMonoDontDestroy`1<GameManager>;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A3560E]) = v38;\nL_001C:\n\tgoto L_001F;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001F:\n\tv50 = SingletonMonoDontDestroy`1<GameManager>::get_Instance();\n\tv53 = v50.currentLevel == 0;\n\tif (v53) goto L_0037;\n\tgoto L_002C;\n\tv79 = \"il2cpp_codegen_runtime_class_init\"(v67, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_002C:\n\tv55 = SingletonMonoDontDestroy`1<GameManager>::get_Instance();\n\tv72 = ~v55.isAddBox;\n\tif (v72) goto L_003C;\nL_0037:\n\treturn;\nL_003C:\n\tgoto L_003F;\n\tv96 = \"il2cpp_codegen_runtime_class_init\"(v93, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_003F:\n\tv56 = SingletonMonoDontDestroy`1<GameManager>::get_Instance();\n\tv56.isAddBox = 1;\n\tDataController::AddOneBox(this.DataController);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void AddOneBox()
	{
		GameManager instance = SingletonMonoDontDestroy<GameManager>.Instance;
		if (instance.currentLevel != 0)
		{
			GameManager instance2 = SingletonMonoDontDestroy<GameManager>.Instance;
			if (!instance2.isAddBox)
			{
				GameManager instance3 = SingletonMonoDontDestroy<GameManager>.Instance;
				instance3.isAddBox = true;
				DataController.AddOneBox();
			}
		}
	}

	[Token(Token = "0x60000F7")]
	[Address(RVA = "0xC00DC0", Offset = "0xC00DC0", Length = "0x84")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv47 = System.Collections.Generic.Stack`1<Movement>;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A3560F]) = v42;\nL_001A:\n\tthis.numberColors = 4;\n\tv45 = new System.Collections.Generic.Stack`1<Movement>();\n\tSystem.Collections.Generic.Stack`1<Movement>::.ctor(v45);\n\tthis.movementSaveStack = v45;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public GamePlayController()
	{
		numberColors = 4;
		Stack<Movement> stack = new Stack<Movement>();
		movementSaveStack = stack;
	}
}
