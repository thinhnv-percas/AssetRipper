using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x751B64", Offset = "0x751B64")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x751B64", Offset = "0x751B64")]
	[Token(Token = "0x200010D")]
	public class AnimateColor : AnimateFsmAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A11A8", Offset = "0x7A11A8")]
		[Token(Token = "0x4001006")]
		[FieldOffset(Offset = "0xD8")]
		public FsmColor colorVariable;

		[RequiredField]
		[Token(Token = "0x4001007")]
		[FieldOffset(Offset = "0xE0")]
		public FsmAnimationCurve curveR;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A11F4", Offset = "0x7A11F4")]
		[Token(Token = "0x4001008")]
		[FieldOffset(Offset = "0xE8")]
		public Calculation calculationR;

		[RequiredField]
		[Token(Token = "0x4001009")]
		[FieldOffset(Offset = "0xF0")]
		public FsmAnimationCurve curveG;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A123C", Offset = "0x7A123C")]
		[Token(Token = "0x400100A")]
		[FieldOffset(Offset = "0xF8")]
		public Calculation calculationG;

		[RequiredField]
		[Token(Token = "0x400100B")]
		[FieldOffset(Offset = "0x100")]
		public FsmAnimationCurve curveB;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A1284", Offset = "0x7A1284")]
		[Token(Token = "0x400100C")]
		[FieldOffset(Offset = "0x108")]
		public Calculation calculationB;

		[RequiredField]
		[Token(Token = "0x400100D")]
		[FieldOffset(Offset = "0x110")]
		public FsmAnimationCurve curveA;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A12CC", Offset = "0x7A12CC")]
		[Token(Token = "0x400100E")]
		[FieldOffset(Offset = "0x118")]
		public Calculation calculationA;

		[Token(Token = "0x400100F")]
		[FieldOffset(Offset = "0x11C")]
		private bool finishInNextStep;

		[Token(Token = "0x6000614")]
		[Address(RVA = "0xA14074", Offset = "0xA14074", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1F01EB8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021D2B]) = v38;\nL_0014:\n\tHutongGames.PlayMaker.Actions.AnimateFsmAction::Reset(this);\n\tv43 = new HutongGames.PlayMaker.FsmColor();\n\tHutongGames.PlayMaker.FsmColor::.ctor(v43);\n\tv43.useVariable = 1;\n\tthis.colorVariable = v43;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			base.Reset();
			FsmColor fsmColor = new FsmColor();
			fsmColor.useVariable = true;
			colorVariable = fsmColor;
		}

		[Token(Token = "0x6000615")]
		[Address(RVA = "0xA14258", Offset = "0xA14258", Length = "0x380")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EC0CB8]);\n\tv23 = *([v22 @ X8_v53]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021D2C]) = v42;\nL_0016:\n\tHutongGames.PlayMaker.Actions.AnimateFsmAction::OnEnter(this);\n\tthis.finishInNextStep = 0;\n\t// 28 NewArr v48 @ X0_v4 (System.Single[]), typeof(System.Single[]), 4\n\tthis.resultFloats = v48;\n\t// 32 NewArr v51 @ X0_v6 (System.Single[]), typeof(System.Single[]), 4\n\tthis.fromFloats = v51;\n\tv57 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.colorVariable);\n\tv230 = v57 == 0;\n\tv231 = ~v230;\n\tif (v231) goto L_0037;\n\tv205 = this.colorVariable;\n\tv163 = v205.value;\nL_0037:\n\tv51[0] = v163;\n\tv221 = this.fromFloats;\n\tv176 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.colorVariable);\n\tv367 = v176 == 0;\n\tv368 = ~v367;\n\tif (v368) goto L_0056;\n\tv206 = this.colorVariable;\n\tv164 = v206.value.g;\nL_0056:\n\tv221[1] = v164;\n\tv222 = this.fromFloats;\n\tv177 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.colorVariable);\n\tv374 = v177 == 0;\n\tv375 = ~v374;\n\tif (v375) goto L_0075;\n\tv207 = this.colorVariable;\n\tv165 = v207.value.b;\nL_0075:\n\tv222[2] = v165;\n\tv223 = this.fromFloats;\n\tv178 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.colorVariable);\n\tv381 = v178 == 0;\n\tv382 = ~v381;\n\tif (v382) goto L_0094;\n\tv208 = this.colorVariable;\n\tv162 = v208.value.a;\nL_0094:\n\tv223[3] = v162;\n\t// 153 NewArr v179 @ X0_v26 (UnityEngine.AnimationCurve[]), typeof(UnityEngine.AnimationCurve[]), 4\n\tv209 = this.curveR;\n\tthis.curves = v179;\n\tv390 = v209.curve == 0;\n\tif (v390) goto L_00AD;\n\t// 167 IsInst v354 @ X0_v47, typeof(UnityEngine.AnimationCurve), v209.curve (UnityEngine.AnimationCurve)\n\tv358 = v354 == 0;\n\tif (v358) goto L_0182;\nL_00AD:\n\tv179[0] = v209.curve;\n\tv210 = this.curveG;\n\tv64 = this.curves;\n\tv394 = v210.curve == 0;\n\tif (v394) goto L_00CA;\n\t// 186 IsInst v355 @ X0_v45, typeof(UnityEngine.AnimationCurve), v210.curve (UnityEngine.AnimationCurve)\n\tv359 = v355 == 0;\n\tif (v359) goto L_0182;\nL_00CA:\n\tv64[1] = v210.curve;\n\tv211 = this.curveB;\n\tv65 = this.curves;\n\tv399 = v211.curve == 0;\n\tif (v399) goto L_00E7;\n\t// 215 IsInst v356 @ X0_v43, typeof(UnityEngine.AnimationCurve), v211.curve (UnityEngine.AnimationCurve)\n\tv360 = v356 == 0;\n\tif (v360) goto L_0182;\nL_00E7:\n\tv65[2] = v211.curve;\n\tv212 = this.curveA;\n\tv66 = this.curves;\n\tv404 = v212.curve == 0;\n\tif (v404) goto L_0104;\n\t// 244 IsInst v357 @ X0_v41, typeof(UnityEngine.AnimationCurve), v212.curve (UnityEngine.AnimationCurve)\n\tv361 = v357 == 0;\n\tif (v361) goto L_0182;\nL_0104:\n\tv66[3] = v212.curve;\n\t// 265 NewArr v183 @ X0_v32 (Calculation[]), typeof(Calculation[]), 4\n\tthis.calculations = v183;\n\t*([v183 @ X0_v32 (Calculation[])+20]) = this.calculationR;\n\tv213 = this.calculations;\n\t*([v213 @ X8_v35 (Calculation[])+24]) = this.calculationG;\n\tv214 = this.calculations;\n\t*([v214 @ X8_v36 (Calculation[])+28]) = this.calculationB;\n\tv215 = this.calculations;\n\t*([v215 @ X8_v37 (Calculation[])+2C]) = this.calculationA;\n\tHutongGames.PlayMaker.Actions.AnimateFsmAction::Init(this);\n\tv420 = HutongGames.PlayMaker.FsmFloat::get_Value(this.delay);\n\tgoto L_015E;\n\tv428 = *([v424 @ X0_v35+E0]);\n\tv429 = v428 == 0;\n\tv430 = ~v429;\n\tif (v430) goto L_015E;\n\tv432 = \"il2cpp_codegen_runtime_class_init\"(v424, v419, v26, v27, v28, v29, v30, v31, v420, v33, v34, v35, v36, v37, v38, v39);\nL_015E:\n\tv437 = UnityEngine.Mathf::Abs(v420);\n\tv447 = v437 >= 0.01f;\n\tif (v447) goto L_017B;\n\tHutongGames.PlayMaker.Actions.AnimateColor::UpdateVariableValue(this);\n\treturn;\nL_017B:\n\treturn;\n\tv272 = new System.NullReferenceException();\n\tv309 = new System.IndexOutOfRangeException();\nL_0181:\n\tv348 = new System.TypeLoadException();\nL_0182:\n\tv339 = new System.ArrayTypeMismatchException();\n\tgoto L_0181;\n\treturn;\n// 284 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			base.OnEnter();
			finishInNextStep = false;
			float[] array = new float[4];
			resultFloats = array;
			float[] array2 = (fromFloats = new float[4]);
			bool isNone = colorVariable.IsNone;
			bool flag = !isNone;
			bool flag2 = !flag;
			Color color = default(Color);
			if (!flag2)
			{
				FsmColor fsmColor = colorVariable;
				color = fsmColor.value;
			}
			array2[0] = color.r;
			float[] array3 = fromFloats;
			bool isNone2 = colorVariable.IsNone;
			bool flag3 = !isNone2;
			bool flag4 = !flag3;
			float num = 0f;
			if (!flag4)
			{
				FsmColor fsmColor2 = colorVariable;
				num = fsmColor2.value.g;
			}
			array3[1] = num;
			float[] array4 = fromFloats;
			bool isNone3 = colorVariable.IsNone;
			bool flag5 = !isNone3;
			bool flag6 = !flag5;
			float num2 = 0f;
			if (!flag6)
			{
				FsmColor fsmColor3 = colorVariable;
				num2 = fsmColor3.value.b;
			}
			array4[2] = num2;
			float[] array5 = fromFloats;
			bool isNone4 = colorVariable.IsNone;
			bool flag7 = !isNone4;
			bool flag8 = !flag7;
			float num3 = 0f;
			if (!flag8)
			{
				FsmColor fsmColor4 = colorVariable;
				num3 = fsmColor4.value.a;
			}
			array5[3] = num3;
			AnimationCurve[] array6 = new AnimationCurve[4];
			FsmAnimationCurve fsmAnimationCurve = curveR;
			curves = array6;
			if (fsmAnimationCurve.curve != null)
			{
				object obj = fsmAnimationCurve.curve as AnimationCurve;
				if (obj == null)
				{
					goto IL_050d;
				}
			}
			array6[0] = fsmAnimationCurve.curve;
			FsmAnimationCurve fsmAnimationCurve2 = curveG;
			AnimationCurve[] array7 = curves;
			if (fsmAnimationCurve2.curve != null)
			{
				object obj2 = fsmAnimationCurve2.curve as AnimationCurve;
				if (obj2 == null)
				{
					goto IL_050d;
				}
			}
			array7[1] = fsmAnimationCurve2.curve;
			FsmAnimationCurve fsmAnimationCurve3 = curveB;
			AnimationCurve[] array8 = curves;
			if (fsmAnimationCurve3.curve != null)
			{
				object obj3 = fsmAnimationCurve3.curve as AnimationCurve;
				if (obj3 == null)
				{
					goto IL_050d;
				}
			}
			array8[2] = fsmAnimationCurve3.curve;
			FsmAnimationCurve fsmAnimationCurve4 = curveA;
			AnimationCurve[] array9 = curves;
			if (fsmAnimationCurve4.curve != null)
			{
				object obj4 = fsmAnimationCurve4.curve as AnimationCurve;
				if (obj4 == null)
				{
					goto IL_050d;
				}
			}
			array9[3] = fsmAnimationCurve4.curve;
			Calculation[] array10 = new Calculation[4];
			calculations = array10;
			_ = calculationR;
			Calculation[] array11 = calculations;
			_ = calculationG;
			Calculation[] array12 = calculations;
			_ = calculationB;
			Calculation[] array13 = calculations;
			_ = calculationA;
			Init();
			float value = delay.Value;
			float num4 = Mathf.Abs(value);
			if (num4 < 0.01f)
			{
				UpdateVariableValue();
			}
			return;
			IL_050d:
			while (true)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				TypeLoadException ex2 = new TypeLoadException();
			}
		}

		[Token(Token = "0x6000616")]
		[Address(RVA = "0xA14B94", Offset = "0xA14B94", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.colorVariable);\n\tv72 = v13 == 0;\n\tv73 = ~v72;\n\tif (v73) goto L_004B;\n\tv48 = this.resultFloats;\n\tv54 = v48.Length == 0;\n\tif (v54) goto L_004C;\n\tv178 = v48.Length == 1;\n\tif (v178) goto L_004C;\n\tv192 = v48.Length < 2;\n\tv190 = ~v192;\n\tv189 = v48.Length - 2;\n\tv187 = v189 == 0;\n\tv193 = ~v190;\n\tv90 = v193 | v187;\n\tif (v90) goto L_004C;\n\tv100 = v48.Length == 3;\n\tif (v100) goto L_004C;\n\tv117 = this.colorVariable;\n\tv80 = 0;\n\tv115 = 0x101059C(&v80 @ stack_-30_v3 (System.Single), 0, v16, v58, v59, v60, v61, v62, v48[0], v48[1], v48[2], v48[3], v67, v68, v69, v70);\n\tv117.value.r = 0f;\n\tv117.value.g = v196;\n\tv117.value.a = v197;\nL_004B:\n\treturn;\nL_004C:\n\tv191 = new System.IndexOutOfRangeException();\n\tthrow v191;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void UpdateVariableValue()
		{
			//IL_00b0: Expected O, but got I4
			//IL_014b: Expected F4, but got O
			if (colorVariable.IsNone)
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
					FsmColor fsmColor = colorVariable;
					float num = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @101059C (inside UnityEngine.ClassLibraryInitializer::Init +0x8)");
					fsmColor.value.r = 0f;
					object obj2 = default(object);
					fsmColor.value.g = (float)obj2;
					float a = default(float);
					fsmColor.value.a = a;
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000617")]
		[Address(RVA = "0xA14C48", Offset = "0xA14C48", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.AnimateFsmAction::OnUpdate(this);\n\tv12 = ~this.isRunning;\n\tif (v12) goto L_000D;\n\tHutongGames.PlayMaker.Actions.AnimateColor::UpdateVariableValue(this);\nL_000D:\n\tv16 = ~this.finishInNextStep;\n\tif (v16) goto L_001D;\n\tv18 = ~this.looping;\n\tv19 = ~v18;\n\tif (v19) goto L_001D;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.finishEvent);\nL_001D:\n\tv31 = ~this.finishAction;\n\tif (v31) goto L_002B;\n\tv35 = ~this.finishInNextStep;\n\tv36 = ~v35;\n\tif (v36) goto L_002B;\n\tHutongGames.PlayMaker.Actions.AnimateColor::UpdateVariableValue(this);\n\tthis.finishInNextStep = 1;\nL_002B:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x6000618")]
		[Address(RVA = "0xA14D14", Offset = "0xA14D14", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AnimateColor()
		{
		}
	}
}
