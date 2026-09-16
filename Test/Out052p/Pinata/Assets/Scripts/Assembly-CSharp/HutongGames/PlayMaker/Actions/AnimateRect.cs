using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x751C54", Offset = "0x751C54")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x751C54", Offset = "0x751C54")]
	[Token(Token = "0x2000111")]
	public class AnimateRect : AnimateFsmAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A15F4", Offset = "0x7A15F4")]
		[Token(Token = "0x4001033")]
		[FieldOffset(Offset = "0xD8")]
		public FsmRect rectVariable;

		[RequiredField]
		[Token(Token = "0x4001034")]
		[FieldOffset(Offset = "0xE0")]
		public FsmAnimationCurve curveX;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A1640", Offset = "0x7A1640")]
		[Token(Token = "0x4001035")]
		[FieldOffset(Offset = "0xE8")]
		public Calculation calculationX;

		[RequiredField]
		[Token(Token = "0x4001036")]
		[FieldOffset(Offset = "0xF0")]
		public FsmAnimationCurve curveY;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A1688", Offset = "0x7A1688")]
		[Token(Token = "0x4001037")]
		[FieldOffset(Offset = "0xF8")]
		public Calculation calculationY;

		[RequiredField]
		[Token(Token = "0x4001038")]
		[FieldOffset(Offset = "0x100")]
		public FsmAnimationCurve curveW;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A16D0", Offset = "0x7A16D0")]
		[Token(Token = "0x4001039")]
		[FieldOffset(Offset = "0x108")]
		public Calculation calculationW;

		[RequiredField]
		[Token(Token = "0x400103A")]
		[FieldOffset(Offset = "0x110")]
		public FsmAnimationCurve curveH;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A1718", Offset = "0x7A1718")]
		[Token(Token = "0x400103B")]
		[FieldOffset(Offset = "0x118")]
		public Calculation calculationH;

		[Token(Token = "0x400103C")]
		[FieldOffset(Offset = "0x11C")]
		private bool finishInNextStep;

		[Token(Token = "0x600062B")]
		[Address(RVA = "0xA8681C", Offset = "0xA8681C", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1ED8480]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202219C]) = v38;\nL_0015:\n\tHutongGames.PlayMaker.Actions.AnimateFsmAction::Reset(this);\n\tv44 = new HutongGames.PlayMaker.FsmRect();\n\tHutongGames.PlayMaker.FsmRect::.ctor(v44);\n\tv44.useVariable = 1;\n\tthis.rectVariable = v44;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			base.Reset();
			FsmRect fsmRect = new FsmRect();
			fsmRect.useVariable = true;
			rectVariable = fsmRect;
		}

		[Token(Token = "0x600062C")]
		[Address(RVA = "0xA8689C", Offset = "0xA8689C", Length = "0x3C4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EC0730]);\n\tv23 = *([v22 @ X8_v53]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202219D]) = v42;\nL_0019:\n\tHutongGames.PlayMaker.Actions.AnimateFsmAction::OnEnter(this);\n\tthis.finishInNextStep = 0;\n\t// 31 NewArr v51 @ X0_v4 (System.Single[]), typeof(System.Single[]), 4\n\tthis.resultFloats = v51;\n\t// 35 NewArr v54 @ X0_v6 (System.Single[]), typeof(System.Single[]), 4\n\tthis.fromFloats = v54;\n\tv60 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.rectVariable);\n\tv246 = v60 == 0;\n\tv247 = ~v246;\n\tif (v247) goto L_003E;\n\tv221 = this.rectVariable;\n\tv167 = v221.value;\n\tv294 = 0x10CCFB4(&v167 @ V0_v7 (UnityEngine.Rect), 0, v26, v27, v28, v29, v30, v31, v221.value, v33, v34, v35, v36, v37, v38, v39);\nL_003E:\n\tv54[0] = v167;\n\tv237 = this.fromFloats;\n\tv189 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.rectVariable);\n\tv392 = v189 == 0;\n\tv393 = ~v392;\n\tif (v393) goto L_0061;\n\tv223 = this.rectVariable;\n\tv167 = v223.value;\n\tv397 = 0x10CCFC4(&v167 @ V0_v7 (UnityEngine.Rect), 0, v26, v27, v28, v29, v30, v31, v223.value, v33, v34, v35, v36, v37, v38, v39);\nL_0061:\n\tv237[1] = v167;\n\tv238 = this.fromFloats;\n\tv191 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.rectVariable);\n\tv403 = v191 == 0;\n\tv404 = ~v403;\n\tif (v404) goto L_0084;\n\tv225 = this.rectVariable;\n\tv167 = v225.value;\n\tv408 = 0x10CD178(&v167 @ V0_v7 (UnityEngine.Rect), 0, v26, v27, v28, v29, v30, v31, v225.value, v33, v34, v35, v36, v37, v38, v39);\nL_0084:\n\tv238[2] = v167;\n\tv239 = this.fromFloats;\n\tv193 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.rectVariable);\n\tv414 = v193 == 0;\n\tv415 = ~v414;\n\tif (v415) goto L_00A7;\n\tv227 = this.rectVariable;\n\tv167 = v227.value;\n\tv419 = 0x10CD188(&v167 @ V0_v7 (UnityEngine.Rect), 0, v26, v27, v28, v29, v30, v31, v227.value, v33, v34, v35, v36, v37, v38, v39);\nL_00A7:\n\tv239[3] = v167;\n\t// 172 NewArr v195 @ X0_v30 (UnityEngine.AnimationCurve[]), typeof(UnityEngine.AnimationCurve[]), 4\n\tv229 = this.curveX;\n\tthis.curves = v195;\n\tv427 = v229.curve == 0;\n\tif (v427) goto L_00C0;\n\t// 186 IsInst v379 @ X0_v51, typeof(UnityEngine.AnimationCurve), v229.curve (UnityEngine.AnimationCurve)\n\tv383 = v379 == 0;\n\tif (v383) goto L_018E;\nL_00C0:\n\tv195[0] = v229.curve;\n\tv230 = this.curveY;\n\tv67 = this.curves;\n\tv431 = v230.curve == 0;\n\tif (v431) goto L_00DD;\n\t// 205 IsInst v380 @ X0_v49, typeof(UnityEngine.AnimationCurve), v230.curve (UnityEngine.AnimationCurve)\n\tv384 = v380 == 0;\n\tif (v384) goto L_018E;\nL_00DD:\n\tv67[1] = v230.curve;\n\tv231 = this.curveW;\n\tv68 = this.curves;\n\tv436 = v231.curve == 0;\n\tif (v436) goto L_00FA;\n\t// 234 IsInst v381 @ X0_v47, typeof(UnityEngine.AnimationCurve), v231.curve (UnityEngine.AnimationCurve)\n\tv385 = v381 == 0;\n\tif (v385) goto L_018E;\nL_00FA:\n\tv68[2] = v231.curve;\n\tv232 = this.curveH;\n\tv69 = this.curves;\n\tv441 = v232.curve == 0;\n\tif (v441) goto L_0117;\n\t// 263 IsInst v382 @ X0_v45, typeof(UnityEngine.AnimationCurve), v232.curve (UnityEngine.AnimationCurve)\n\tv386 = v382 == 0;\n\tif (v386) goto L_018E;\nL_0117:\n\tv69[3] = v232.curve;\n\t// 284 NewArr v199 @ X0_v36 (Calculation[]), typeof(Calculation[]), 4\n\tthis.calculations = v199;\n\t*([v199 @ X0_v36 (Calculation[])+20]) = this.calculationX;\n\tv233 = this.calculations;\n\t*([v233 @ X8_v35 (Calculation[])+24]) = this.calculationY;\n\tv234 = this.calculations;\n\t*([v234 @ X8_v36 (Calculation[])+28]) = this.calculationW;\n\tv235 = this.calculations;\n\t*([v235 @ X8_v37 (Calculation[])+2C]) = this.calculationH;\n\tHutongGames.PlayMaker.Actions.AnimateFsmAction::Init(this);\n\tv457 = HutongGames.PlayMaker.FsmFloat::get_Value(this.delay);\n\tgoto L_0172;\n\tv465 = *([v461 @ X0_v39+E0]);\n\tv466 = v465 == 0;\n\tv467 = ~v466;\n\tif (v467) goto L_0172;\n\tv469 = \"il2cpp_codegen_runtime_class_init\"(v461, v456, v26, v27, v28, v29, v30, v31, v457, v33, v34, v35, v36, v37, v38, v39);\nL_0172:\n\tv474 = UnityEngine.Mathf::Abs(v457);\n\tv484 = v474 >= 0.01f;\n\tif (v484) goto L_0187;\n\tHutongGames.PlayMaker.Actions.AnimateRect::UpdateVariableValue(this);\nL_0187:\n\treturn;\n\tv290 = new System.NullReferenceException();\n\tv331 = new System.IndexOutOfRangeException();\nL_018D:\n\tv373 = new System.TypeLoadException();\nL_018E:\n\tv364 = new System.ArrayTypeMismatchException();\n\tgoto L_018D;\n\treturn;\n// 293 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			base.OnEnter();
			finishInNextStep = false;
			float[] array = new float[4];
			resultFloats = array;
			float[] array2 = (fromFloats = new float[4]);
			bool isNone = rectVariable.IsNone;
			bool flag = !isNone;
			bool flag2 = !flag;
			Rect rect = default(Rect);
			if (!flag2)
			{
				FsmRect fsmRect = rectVariable;
				rect = fsmRect.value;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFB4 (inside UnityEngine.Rect::MinMaxRect +0x18)");
			}
			array2[0] = rect.x;
			float[] array3 = fromFloats;
			bool isNone2 = rectVariable.IsNone;
			bool flag3 = !isNone2;
			bool flag4 = !flag3;
			rect = default(Rect);
			if (!flag4)
			{
				FsmRect fsmRect2 = rectVariable;
				rect = fsmRect2.value;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFC4 (inside UnityEngine.Rect::MinMaxRect +0x28)");
			}
			array3[1] = rect.x;
			float[] array4 = fromFloats;
			bool isNone3 = rectVariable.IsNone;
			bool flag5 = !isNone3;
			bool flag6 = !flag5;
			rect = default(Rect);
			if (!flag6)
			{
				FsmRect fsmRect3 = rectVariable;
				rect = fsmRect3.value;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD178 (inside UnityEngine.Rect::MinMaxRect +0x1DC)");
			}
			array4[2] = rect.x;
			float[] array5 = fromFloats;
			bool isNone4 = rectVariable.IsNone;
			bool flag7 = !isNone4;
			bool flag8 = !flag7;
			rect = default(Rect);
			if (!flag8)
			{
				FsmRect fsmRect4 = rectVariable;
				rect = fsmRect4.value;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD188 (inside UnityEngine.Rect::MinMaxRect +0x1EC)");
			}
			array5[3] = rect.x;
			AnimationCurve[] array6 = new AnimationCurve[4];
			FsmAnimationCurve fsmAnimationCurve = curveX;
			curves = array6;
			if (fsmAnimationCurve.curve != null)
			{
				object obj = fsmAnimationCurve.curve as AnimationCurve;
				if (obj == null)
				{
					goto IL_053c;
				}
			}
			array6[0] = fsmAnimationCurve.curve;
			FsmAnimationCurve fsmAnimationCurve2 = curveY;
			AnimationCurve[] array7 = curves;
			if (fsmAnimationCurve2.curve != null)
			{
				object obj2 = fsmAnimationCurve2.curve as AnimationCurve;
				if (obj2 == null)
				{
					goto IL_053c;
				}
			}
			array7[1] = fsmAnimationCurve2.curve;
			FsmAnimationCurve fsmAnimationCurve3 = curveW;
			AnimationCurve[] array8 = curves;
			if (fsmAnimationCurve3.curve != null)
			{
				object obj3 = fsmAnimationCurve3.curve as AnimationCurve;
				if (obj3 == null)
				{
					goto IL_053c;
				}
			}
			array8[2] = fsmAnimationCurve3.curve;
			FsmAnimationCurve fsmAnimationCurve4 = curveH;
			AnimationCurve[] array9 = curves;
			if (fsmAnimationCurve4.curve != null)
			{
				object obj4 = fsmAnimationCurve4.curve as AnimationCurve;
				if (obj4 == null)
				{
					goto IL_053c;
				}
			}
			array9[3] = fsmAnimationCurve4.curve;
			Calculation[] array10 = new Calculation[4];
			calculations = array10;
			_ = calculationX;
			Calculation[] array11 = calculations;
			_ = calculationY;
			Calculation[] array12 = calculations;
			_ = calculationW;
			Calculation[] array13 = calculations;
			_ = calculationH;
			Init();
			float value = delay.Value;
			float num = Mathf.Abs(value);
			if (num < 0.01f)
			{
				UpdateVariableValue();
			}
			return;
			IL_053c:
			while (true)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				TypeLoadException ex2 = new TypeLoadException();
			}
		}

		[Token(Token = "0x600062D")]
		[Address(RVA = "0xA86C60", Offset = "0xA86C60", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.rectVariable);\n\tv72 = v13 == 0;\n\tv73 = ~v72;\n\tif (v73) goto L_004B;\n\tv48 = this.resultFloats;\n\tv54 = v48.Length == 0;\n\tif (v54) goto L_004C;\n\tv178 = v48.Length == 1;\n\tif (v178) goto L_004C;\n\tv192 = v48.Length < 2;\n\tv190 = ~v192;\n\tv189 = v48.Length - 2;\n\tv187 = v189 == 0;\n\tv193 = ~v190;\n\tv90 = v193 | v187;\n\tif (v90) goto L_004C;\n\tv100 = v48.Length == 3;\n\tif (v100) goto L_004C;\n\tv117 = this.rectVariable;\n\tv80 = 0;\n\tv115 = 0x10CCF64(&v80 @ stack_-30_v3 (System.Single), 0, v16, v58, v59, v60, v61, v62, v48[0], v48[1], v48[2], v48[3], v67, v68, v69, v70);\n\tv117.value.m_XMin = 0f;\n\tv117.value.m_YMin = v196;\n\tv117.value.m_Height = v197;\nL_004B:\n\treturn;\nL_004C:\n\tv191 = new System.IndexOutOfRangeException();\n\tthrow v191;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void UpdateVariableValue()
		{
			//IL_00b0: Expected O, but got I4
			//IL_014b: Expected F4, but got O
			if (rectVariable.IsNone)
			{
				return;
			}
			float[] array = resultFloats;
			if (array.Length != 0 && array.Length != 1)
			{
				bool flag = array.Length < 2;
				bool flag2 = !flag;
				object obj = array.Length - 2;
				bool flag3 = obj == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3) && array.Length != 3)
				{
					FsmRect fsmRect = rectVariable;
					float num = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCF64 (inside UnityEngine.RangeAttribute::.ctor +0x290)");
					fsmRect.value.x = 0f;
					object obj2 = default(object);
					fsmRect.value.y = (float)obj2;
					float height = default(float);
					fsmRect.value.height = height;
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x600062E")]
		[Address(RVA = "0xA86D14", Offset = "0xA86D14", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.AnimateFsmAction::OnUpdate(this);\n\tv12 = ~this.isRunning;\n\tif (v12) goto L_000E;\n\tHutongGames.PlayMaker.Actions.AnimateRect::UpdateVariableValue(this);\nL_000E:\n\tv16 = ~this.finishInNextStep;\n\tif (v16) goto L_001E;\n\tv18 = ~this.looping;\n\tv19 = ~v18;\n\tif (v19) goto L_001E;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.finishEvent);\nL_001E:\n\tv31 = ~this.finishAction;\n\tif (v31) goto L_002C;\n\tv35 = ~this.finishInNextStep;\n\tv36 = ~v35;\n\tif (v36) goto L_002C;\n\tHutongGames.PlayMaker.Actions.AnimateRect::UpdateVariableValue(this);\n\tthis.finishInNextStep = 1;\nL_002C:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			base.OnUpdate();
			if (isRunning)
			{
				UpdateVariableValue();
			}
			if (finishInNextStep && !looping)
			{
				Finish();
				Fsm.Event(finishEvent);
			}
			if (finishAction && !finishInNextStep)
			{
				UpdateVariableValue();
				finishInNextStep = true;
			}
		}

		[Token(Token = "0x600062F")]
		[Address(RVA = "0xA86D9C", Offset = "0xA86D9C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.AnimateFsmAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AnimateRect()
		{
		}
	}
}
