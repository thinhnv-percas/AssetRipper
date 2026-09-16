using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x751DDC", Offset = "0x751DDC")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x751DDC", Offset = "0x751DDC")]
	[Token(Token = "0x2000116")]
	public class CurveRect : CurveFsmAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A1BD4", Offset = "0x7A1BD4")]
		[Token(Token = "0x4001070")]
		[FieldOffset(Offset = "0xE0")]
		public FsmRect rectVariable;

		[RequiredField]
		[Token(Token = "0x4001071")]
		[FieldOffset(Offset = "0xE8")]
		public FsmRect fromValue;

		[RequiredField]
		[Token(Token = "0x4001072")]
		[FieldOffset(Offset = "0xF0")]
		public FsmRect toValue;

		[RequiredField]
		[Token(Token = "0x4001073")]
		[FieldOffset(Offset = "0xF8")]
		public FsmAnimationCurve curveX;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A1C40", Offset = "0x7A1C40")]
		[Token(Token = "0x4001074")]
		[FieldOffset(Offset = "0x100")]
		public Calculation calculationX;

		[RequiredField]
		[Token(Token = "0x4001075")]
		[FieldOffset(Offset = "0x108")]
		public FsmAnimationCurve curveY;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A1C88", Offset = "0x7A1C88")]
		[Token(Token = "0x4001076")]
		[FieldOffset(Offset = "0x110")]
		public Calculation calculationY;

		[RequiredField]
		[Token(Token = "0x4001077")]
		[FieldOffset(Offset = "0x118")]
		public FsmAnimationCurve curveW;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A1CD0", Offset = "0x7A1CD0")]
		[Token(Token = "0x4001078")]
		[FieldOffset(Offset = "0x120")]
		public Calculation calculationW;

		[RequiredField]
		[Token(Token = "0x4001079")]
		[FieldOffset(Offset = "0x128")]
		public FsmAnimationCurve curveH;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A1D18", Offset = "0x7A1D18")]
		[Token(Token = "0x400107A")]
		[FieldOffset(Offset = "0x130")]
		public Calculation calculationH;

		[Token(Token = "0x400107B")]
		[FieldOffset(Offset = "0x134")]
		private Rect rct;

		[Token(Token = "0x400107C")]
		[FieldOffset(Offset = "0x144")]
		private bool finishInNextStep;

		[Token(Token = "0x6000644")]
		[Address(RVA = "0xA95A6C", Offset = "0xA95A6C", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EF20F0]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202220F]) = v42;\nL_0016:\n\tHutongGames.PlayMaker.Actions.CurveFsmAction::Reset(this);\n\tv47 = new HutongGames.PlayMaker.FsmRect();\n\tHutongGames.PlayMaker.FsmRect::.ctor(v47);\n\tv47.useVariable = 1;\n\tthis.rectVariable = v47;\n\tv53 = new HutongGames.PlayMaker.FsmRect();\n\tHutongGames.PlayMaker.FsmRect::.ctor(v53);\n\tv53.useVariable = 1;\n\tthis.toValue = v53;\n\tv59 = new HutongGames.PlayMaker.FsmRect();\n\tHutongGames.PlayMaker.FsmRect::.ctor(v59);\n\tv59.useVariable = 1;\n\tthis.fromValue = v59;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			base.Reset();
			FsmRect fsmRect = new FsmRect();
			fsmRect.useVariable = true;
			rectVariable = fsmRect;
			FsmRect fsmRect2 = new FsmRect();
			fsmRect2.useVariable = true;
			toValue = fsmRect2;
			FsmRect fsmRect3 = new FsmRect();
			fsmRect3.useVariable = true;
			fromValue = fsmRect3;
		}

		[Token(Token = "0x6000645")]
		[Address(RVA = "0xA95B34", Offset = "0xA95B34", Length = "0x4A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1F0B118]);\n\tv21 = *([v20 @ X8_v60]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022210]) = v40;\nL_0017:\n\tHutongGames.PlayMaker.Actions.CurveFsmAction::OnEnter(this);\n\tthis.finishInNextStep = 0;\n\t// 29 NewArr v48 @ X0_v4 (System.Single[]), typeof(System.Single[]), 4\n\tthis.resultFloats = v48;\n\t// 33 NewArr v51 @ X0_v6 (System.Single[]), typeof(System.Single[]), 4\n\tthis.fromFloats = v51;\n\tv57 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.fromValue);\n\tv322 = v57 == 0;\n\tv323 = ~v322;\n\tif (v323) goto L_003C;\n\tv284 = this.fromValue;\n\tv190 = v284.value;\n\tv366 = 0x10CCFB4(&v190 @ V0_v7 (UnityEngine.Rect), 0, v24, v25, v26, v27, v28, v29, v284.value, v31, v32, v33, v34, v35, v36, v37);\nL_003C:\n\tv51[0] = v190;\n\tv309 = this.fromFloats;\n\tv234 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.fromValue);\n\tv475 = v234 == 0;\n\tv476 = ~v475;\n\tif (v476) goto L_005F;\n\tv286 = this.fromValue;\n\tv190 = v286.value;\n\tv480 = 0x10CCFC4(&v190 @ V0_v7 (UnityEngine.Rect), 0, v24, v25, v26, v27, v28, v29, v286.value, v31, v32, v33, v34, v35, v36, v37);\nL_005F:\n\tv309[1] = v190;\n\tv310 = this.fromFloats;\n\tv236 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.fromValue);\n\tv486 = v236 == 0;\n\tv487 = ~v486;\n\tif (v487) goto L_0082;\n\tv288 = this.fromValue;\n\tv190 = v288.value;\n\tv491 = 0x10CD178(&v190 @ V0_v7 (UnityEngine.Rect), 0, v24, v25, v26, v27, v28, v29, v288.value, v31, v32, v33, v34, v35, v36, v37);\nL_0082:\n\tv310[2] = v190;\n\tv311 = this.fromFloats;\n\tv238 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.fromValue);\n\tv497 = v238 == 0;\n\tv498 = ~v497;\n\tif (v498) goto L_00A5;\n\tv290 = this.fromValue;\n\tv190 = v290.value;\n\tv502 = 0x10CD188(&v190 @ V0_v7 (UnityEngine.Rect), 0, v24, v25, v26, v27, v28, v29, v290.value, v31, v32, v33, v34, v35, v36, v37);\nL_00A5:\n\tv311[3] = v190;\n\t// 168 NewArr v240 @ X0_v30 (System.Single[]), typeof(System.Single[]), 4\n\tthis.toFloats = v240;\n\tv241 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.toValue);\n\tv510 = v241 == 0;\n\tv511 = ~v510;\n\tif (v511) goto L_00C3;\n\tv293 = this.toValue;\n\tv190 = v293.value;\n\tv515 = 0x10CCFB4(&v190 @ V0_v7 (UnityEngine.Rect), 0, v24, v25, v26, v27, v28, v29, v293.value, v31, v32, v33, v34, v35, v36, v37);\nL_00C3:\n\tv240[0] = v190;\n\tv313 = this.toFloats;\n\tv243 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.toValue);\n\tv519 = v243 == 0;\n\tv520 = ~v519;\n\tif (v520) goto L_00E6;\n\tv295 = this.toValue;\n\tv190 = v295.value;\n\tv524 = 0x10CCFC4(&v190 @ V0_v7 (UnityEngine.Rect), 0, v24, v25, v26, v27, v28, v29, v295.value, v31, v32, v33, v34, v35, v36, v37);\nL_00E6:\n\tv313[1] = v190;\n\tv314 = this.toFloats;\n\tv245 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.toValue);\n\tv530 = v245 == 0;\n\tv531 = ~v530;\n\tif (v531) goto L_0109;\n\tv297 = this.toValue;\n\tv190 = v297.value;\n\tv535 = 0x10CD178(&v190 @ V0_v7 (UnityEngine.Rect), 0, v24, v25, v26, v27, v28, v29, v297.value, v31, v32, v33, v34, v35, v36, v37);\nL_0109:\n\tv314[2] = v190;\n\tv315 = this.toFloats;\n\tv247 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.toValue);\n\tv541 = v247 == 0;\n\tv542 = ~v541;\n\tif (v542) goto L_012C;\n\tv299 = this.toValue;\n\tv190 = v299.value;\n\tv546 = 0x10CD188(&v190 @ V0_v7 (UnityEngine.Rect), 0, v24, v25, v26, v27, v28, v29, v299.value, v31, v32, v33, v34, v35, v36, v37);\nL_012C:\n\tv315[3] = v190;\n\t// 305 NewArr v249 @ X0_v44 (UnityEngine.AnimationCurve[]), typeof(UnityEngine.AnimationCurve[]), 4\n\tv301 = this.curveX;\n\tthis.curves = v249;\n\tv554 = v301.curve == 0;\n\tif (v554) goto L_0145;\n\t// 319 IsInst v462 @ X0_v59, typeof(UnityEngine.AnimationCurve), v301.curve (UnityEngine.AnimationCurve)\n\tv466 = v462 == 0;\n\tif (v466) goto L_01EF;\nL_0145:\n\tv249[0] = v301.curve;\n\tv302 = this.curveY;\n\tv229 = this.curves;\n\tv558 = v302.curve == 0;\n\tif (v558) goto L_0162;\n\t// 338 IsInst v463 @ X0_v57, typeof(UnityEngine.AnimationCurve), v302.curve (UnityEngine.AnimationCurve)\n\tv467 = v463 == 0;\n\tif (v467) goto L_01EF;\nL_0162:\n\tv229[1] = v302.curve;\n\tv303 = this.curveW;\n\tv230 = this.curves;\n\tv563 = v303.curve == 0;\n\tif (v563) goto L_017F;\n\t// 367 IsInst v464 @ X0_v55, typeof(UnityEngine.AnimationCurve), v303.curve (UnityEngine.AnimationCurve)\n\tv468 = v464 == 0;\n\tif (v468) goto L_01EF;\nL_017F:\n\tv230[2] = v303.curve;\n\tv304 = this.curveH;\n\tv231 = this.curves;\n\tv568 = v304.curve == 0;\n\tif (v568) goto L_019C;\n\t// 396 IsInst v465 @ X0_v53, typeof(UnityEngine.AnimationCurve), v304.curve (UnityEngine.AnimationCurve)\n\tv469 = v465 == 0;\n\tif (v469) goto L_01EF;\nL_019C:\n\tv231[3] = v304.curve;\n\t// 417 NewArr v253 @ X0_v50 (Calculation[]), typeof(Calculation[]), 4\n\tthis.calculations = v253;\n\t*([v253 @ X0_v50 (Calculation[])+20]) = this.calculationX;\n\tv305 = this.calculations;\n\t*([v305 @ X8_v44 (Calculation[])+24]) = this.calculationY;\n\tv306 = this.calculations;\n\t*([v306 @ X8_v45 (Calculation[])+28]) = this.calculationW;\n\tv307 = this.calculations;\n\t*([v307 @ X8_v46 (Calculation[])+28]) = this.calculationH;\n\tHutongGames.PlayMaker.Actions.CurveFsmAction::Init(this);\n\treturn;\n\tv362 = new System.NullReferenceException();\n\tv414 = new System.IndexOutOfRangeException();\nL_01EE:\n\tv456 = new System.TypeLoadException();\nL_01EF:\n\tv447 = new System.ArrayTypeMismatchException();\n\tgoto L_01EE;\n\treturn;\n// 364 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			base.OnEnter();
			finishInNextStep = false;
			float[] array = new float[4];
			resultFloats = array;
			float[] array2 = (fromFloats = new float[4]);
			bool isNone = fromValue.IsNone;
			bool flag = !isNone;
			bool flag2 = !flag;
			Rect rect = default(Rect);
			if (!flag2)
			{
				FsmRect fsmRect = fromValue;
				rect = fsmRect.value;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFB4 (inside UnityEngine.Rect::MinMaxRect +0x18)");
			}
			array2[0] = rect.x;
			float[] array3 = fromFloats;
			bool isNone2 = fromValue.IsNone;
			bool flag3 = !isNone2;
			bool flag4 = !flag3;
			rect = default(Rect);
			if (!flag4)
			{
				FsmRect fsmRect2 = fromValue;
				rect = fsmRect2.value;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFC4 (inside UnityEngine.Rect::MinMaxRect +0x28)");
			}
			array3[1] = rect.x;
			float[] array4 = fromFloats;
			bool isNone3 = fromValue.IsNone;
			bool flag5 = !isNone3;
			bool flag6 = !flag5;
			rect = default(Rect);
			if (!flag6)
			{
				FsmRect fsmRect3 = fromValue;
				rect = fsmRect3.value;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD178 (inside UnityEngine.Rect::MinMaxRect +0x1DC)");
			}
			array4[2] = rect.x;
			float[] array5 = fromFloats;
			bool isNone4 = fromValue.IsNone;
			bool flag7 = !isNone4;
			bool flag8 = !flag7;
			rect = default(Rect);
			if (!flag8)
			{
				FsmRect fsmRect4 = fromValue;
				rect = fsmRect4.value;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD188 (inside UnityEngine.Rect::MinMaxRect +0x1EC)");
			}
			array5[3] = rect.x;
			float[] array6 = (toFloats = new float[4]);
			bool isNone5 = toValue.IsNone;
			bool flag9 = !isNone5;
			bool flag10 = !flag9;
			rect = default(Rect);
			if (!flag10)
			{
				FsmRect fsmRect5 = toValue;
				rect = fsmRect5.value;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFB4 (inside UnityEngine.Rect::MinMaxRect +0x18)");
			}
			array6[0] = rect.x;
			float[] array7 = toFloats;
			bool isNone6 = toValue.IsNone;
			bool flag11 = !isNone6;
			bool flag12 = !flag11;
			rect = default(Rect);
			if (!flag12)
			{
				FsmRect fsmRect6 = toValue;
				rect = fsmRect6.value;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFC4 (inside UnityEngine.Rect::MinMaxRect +0x28)");
			}
			array7[1] = rect.x;
			float[] array8 = toFloats;
			bool isNone7 = toValue.IsNone;
			bool flag13 = !isNone7;
			bool flag14 = !flag13;
			rect = default(Rect);
			if (!flag14)
			{
				FsmRect fsmRect7 = toValue;
				rect = fsmRect7.value;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD178 (inside UnityEngine.Rect::MinMaxRect +0x1DC)");
			}
			array8[2] = rect.x;
			float[] array9 = toFloats;
			bool isNone8 = toValue.IsNone;
			bool flag15 = !isNone8;
			bool flag16 = !flag15;
			rect = default(Rect);
			if (!flag16)
			{
				FsmRect fsmRect8 = toValue;
				rect = fsmRect8.value;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD188 (inside UnityEngine.Rect::MinMaxRect +0x1EC)");
			}
			array9[3] = rect.x;
			AnimationCurve[] array10 = new AnimationCurve[4];
			FsmAnimationCurve fsmAnimationCurve = curveX;
			curves = array10;
			if (fsmAnimationCurve.curve != null)
			{
				object obj = fsmAnimationCurve.curve as AnimationCurve;
				if (obj == null)
				{
					goto IL_073f;
				}
			}
			array10[0] = fsmAnimationCurve.curve;
			FsmAnimationCurve fsmAnimationCurve2 = curveY;
			AnimationCurve[] array11 = curves;
			if (fsmAnimationCurve2.curve != null)
			{
				object obj2 = fsmAnimationCurve2.curve as AnimationCurve;
				if (obj2 == null)
				{
					goto IL_073f;
				}
			}
			array11[1] = fsmAnimationCurve2.curve;
			FsmAnimationCurve fsmAnimationCurve3 = curveW;
			AnimationCurve[] array12 = curves;
			if (fsmAnimationCurve3.curve != null)
			{
				object obj3 = fsmAnimationCurve3.curve as AnimationCurve;
				if (obj3 == null)
				{
					goto IL_073f;
				}
			}
			array12[2] = fsmAnimationCurve3.curve;
			FsmAnimationCurve fsmAnimationCurve4 = curveH;
			AnimationCurve[] array13 = curves;
			if (fsmAnimationCurve4.curve != null)
			{
				object obj4 = fsmAnimationCurve4.curve as AnimationCurve;
				if (obj4 == null)
				{
					goto IL_073f;
				}
			}
			array13[3] = fsmAnimationCurve4.curve;
			Calculation[] array14 = new Calculation[4];
			calculations = array14;
			_ = calculationX;
			Calculation[] array15 = calculations;
			_ = calculationY;
			Calculation[] array16 = calculations;
			_ = calculationW;
			Calculation[] array17 = calculations;
			_ = calculationH;
			Init();
			return;
			IL_073f:
			while (true)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				TypeLoadException ex2 = new TypeLoadException();
			}
		}

		[Token(Token = "0x6000646")]
		[Address(RVA = "0xA95FD8", Offset = "0xA95FD8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void OnExit()
		{
		}

		[Token(Token = "0x6000647")]
		[Address(RVA = "0xA95FDC", Offset = "0xA95FDC", Length = "0x190")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.CurveFsmAction::OnUpdate(this);\n\tv14 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.rectVariable);\n\tv123 = v14 == 0;\n\tv124 = ~v123;\n\tif (v124) goto L_0052;\n\tv204 = ~this.isRunning;\n\tif (v204) goto L_0052;\n\tv184 = this.resultFloats;\n\tv275 = v184.Length == 0;\n\tif (v275) goto L_00B8;\n\tv306 = v184.Length == 1;\n\tif (v306) goto L_00B8;\n\tv341 = v184.Length < 2;\n\tv333 = ~v341;\n\tv330 = v184.Length - 2;\n\tv324 = v330 == 0;\n\tv342 = ~v333;\n\tv154 = v342 | v324;\n\tif (v154) goto L_00B8;\n\tv169 = v184.Length == 3;\n\tif (v169) goto L_00B8;\n\tv139 = 0;\n\tv198 = 0x10CCF64(&v139 @ stack_-30_v8 (System.Single), 0, v18, v113, v114, v115, v116, v117, v184[0], v184[1], v184[2], v184[3], v118, v119, v120, v121);\n\tv127 = this.rectVariable;\n\tthis.rct.m_XMin = 0f;\n\tthis.rct.m_YMin = v349;\n\tthis.rct.m_Width = 0f;\n\tthis.rct.m_Height = v350;\n\tv127.value = 0;\n\tv127.value.m_YMin = v349;\n\tv127.value.m_Width = 0f;\n\tv127.value.m_Height = v350;\nL_0052:\n\tv210 = ~this.finishInNextStep;\n\tif (v210) goto L_0064;\n\tv211 = ~this.looping;\n\tv212 = ~v211;\n\tif (v212) goto L_0064;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\tv216 = this.finishEvent == 0;\n\tif (v216) goto L_0064;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.finishEvent);\nL_0064:\n\tv220 = ~this.finishAction;\n\tif (v220) goto L_00B7;\n\tv277 = ~this.finishInNextStep;\n\tv278 = ~v277;\n\tif (v278) goto L_00B7;\n\tv199 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.rectVariable);\n\tv345 = v199 == 0;\n\tv346 = ~v345;\n\tif (v346) goto L_00B2;\n\tv186 = this.resultFloats;\n\tv338 = v186.Length == 0;\n\tif (v338) goto L_00B8;\n\tv325 = v186.Length == 1;\n\tif (v325) goto L_00B8;\n\tv352 = v186.Length < 2;\n\tv335 = ~v352;\n\tv332 = v186.Length - 2;\n\tv326 = v332 == 0;\n\tv353 = ~v335;\n\tv155 = v353 | v326;\n\tif (v155) goto L_00B8;\n\tv170 = v186.Length == 3;\n\tif (v170) goto L_00B8;\n\tv139 = 0;\n\tv200 = 0x10CCF64(&v139 @ stack_-30_v8 (System.Single), 0, 0, v113, v114, v115, v116, v117, v186[0], v186[1], v186[2], v186[3], v118, v119, v120, v121);\n\tv128 = this.rectVariable;\n\tthis.rct.m_XMin = 0f;\n\tthis.rct.m_YMin = v349;\n\tthis.rct.m_Width = 0f;\n\tthis.rct.m_Height = v350;\n\tv128.value = 0;\n\tv128.value.m_YMin = v349;\n\tv128.value.m_Width = 0f;\n\tv128.value.m_Height = v350;\nL_00B2:\n\tthis.finishInNextStep = 1;\nL_00B7:\n\treturn;\nL_00B8:\n\tv340 = new System.IndexOutOfRangeException();\n\tthrow v340;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n// 111 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			//IL_00d6: Expected O, but got I4
			//IL_032f: Expected O, but got I4
			base.OnUpdate();
			float y = default(float);
			float height = default(float);
			if (!rectVariable.IsNone && isRunning)
			{
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
						float num = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCF64 (inside UnityEngine.RangeAttribute::.ctor +0x290)");
						FsmRect fsmRect = rectVariable;
						rct.x = 0f;
						rct.y = y;
						rct.width = 0f;
						rct.height = height;
						fsmRect.value = default(Rect);
						fsmRect.value.y = y;
						fsmRect.value.width = 0f;
						fsmRect.value.height = height;
						goto IL_0444;
					}
				}
				goto IL_0436;
			}
			goto IL_0444;
			IL_0444:
			if (finishInNextStep && !looping)
			{
				Finish();
				if (finishEvent != null)
				{
					Fsm.Event(finishEvent);
				}
			}
			if (!finishAction || finishInNextStep)
			{
				return;
			}
			if (!rectVariable.IsNone)
			{
				float[] array2 = resultFloats;
				if (array2.Length != 0 && array2.Length != 1)
				{
					bool flag5 = array2.Length < 2;
					bool flag6 = !flag5;
					object obj2 = array2.Length - 2;
					bool flag7 = obj2 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7) && array2.Length != 3)
					{
						float num = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCF64 (inside UnityEngine.RangeAttribute::.ctor +0x290)");
						FsmRect fsmRect2 = rectVariable;
						rct.x = 0f;
						rct.y = y;
						rct.width = 0f;
						rct.height = height;
						fsmRect2.value = default(Rect);
						fsmRect2.value.y = y;
						fsmRect2.value.width = 0f;
						fsmRect2.value.height = height;
						goto IL_0460;
					}
				}
				goto IL_0436;
			}
			goto IL_0460;
			IL_0460:
			finishInNextStep = true;
			return;
			IL_0436:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000648")]
		[Address(RVA = "0xA9616C", Offset = "0xA9616C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CurveRect()
		{
		}
	}
}
