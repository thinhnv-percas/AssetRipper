using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x751D54", Offset = "0x751D54")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x751D54", Offset = "0x751D54")]
	[Token(Token = "0x2000114")]
	public class CurveFloat : CurveFsmAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A19E0", Offset = "0x7A19E0")]
		[Token(Token = "0x4001052")]
		[FieldOffset(Offset = "0xE0")]
		public FsmFloat floatVariable;

		[RequiredField]
		[Token(Token = "0x4001053")]
		[FieldOffset(Offset = "0xE8")]
		public FsmFloat fromValue;

		[RequiredField]
		[Token(Token = "0x4001054")]
		[FieldOffset(Offset = "0xF0")]
		public FsmFloat toValue;

		[RequiredField]
		[Token(Token = "0x4001055")]
		[FieldOffset(Offset = "0xF8")]
		public FsmAnimationCurve animCurve;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A1A4C", Offset = "0x7A1A4C")]
		[Token(Token = "0x4001056")]
		[FieldOffset(Offset = "0x100")]
		public Calculation calculation;

		[Token(Token = "0x4001057")]
		[FieldOffset(Offset = "0x104")]
		private bool finishInNextStep;

		[Token(Token = "0x600063A")]
		[Address(RVA = "0xA956F4", Offset = "0xA956F4", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EB3A78]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202220B]) = v42;\nL_0016:\n\tHutongGames.PlayMaker.Actions.CurveFsmAction::Reset(this);\n\tv47 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v47);\n\tv47.useVariable = 1;\n\tthis.floatVariable = v47;\n\tv53 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v53);\n\tv53.useVariable = 1;\n\tthis.toValue = v53;\n\tv59 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v59);\n\tv59.useVariable = 1;\n\tthis.fromValue = v59;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			base.Reset();
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = true;
			floatVariable = fsmFloat;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.useVariable = true;
			toValue = fsmFloat2;
			FsmFloat fsmFloat3 = new FsmFloat();
			fsmFloat3.useVariable = true;
			fromValue = fsmFloat3;
		}

		[Token(Token = "0x600063B")]
		[Address(RVA = "0xA957BC", Offset = "0xA957BC", Length = "0x1AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1ED3BA8]);\n\tv21 = *([v20 @ X8_v23]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202220C]) = v40;\nL_0015:\n\tHutongGames.PlayMaker.Actions.CurveFsmAction::OnEnter(this);\n\tthis.finishInNextStep = 0;\n\t// 27 NewArr v46 @ X0_v4 (System.Single[]), typeof(System.Single[]), 1\n\tthis.resultFloats = v46;\n\t// 31 NewArr v49 @ X0_v6 (System.Single[]), typeof(System.Single[]), 1\n\tthis.fromFloats = v49;\n\tv55 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.fromValue);\n\tv84 = v55 == 0;\n\tv85 = ~v84;\n\tif (v85) goto L_0037;\n\tv57 = HutongGames.PlayMaker.FsmFloat::get_Value(this.fromValue);\nL_0037:\n\tv49[0] = v57;\n\t// 58 NewArr v66 @ X0_v21 (System.Single[]), typeof(System.Single[]), 1\n\tthis.toFloats = v66;\n\tv151 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.toValue);\n\tv153 = v151 == 0;\n\tv154 = ~v153;\n\tif (v154) goto L_0052;\n\tv58 = HutongGames.PlayMaker.FsmFloat::get_Value(this.toValue);\nL_0052:\n\tv66[0] = v58;\n\t// 87 NewArr v94 @ X0_v26 (Calculation[]), typeof(Calculation[]), 1\n\tthis.calculations = v94;\n\t*([v94 @ X0_v26 (Calculation[])+20]) = this.calculation;\n\t// 100 NewArr v68 @ X0_v28 (UnityEngine.AnimationCurve[]), typeof(UnityEngine.AnimationCurve[]), 1\n\tv77 = this.animCurve;\n\tthis.curves = v68;\n\tv164 = v77.curve == 0;\n\tif (v164) goto L_0078;\n\t// 114 IsInst v147 @ X0_v32, typeof(UnityEngine.AnimationCurve), v77.curve (UnityEngine.AnimationCurve)\n\tv148 = v147 == 0;\n\tif (v148) goto L_0088;\nL_0078:\n\tv68[0] = v77.curve;\n\tHutongGames.PlayMaker.Actions.CurveFsmAction::Init(this);\n\treturn;\n\tv102 = new System.NullReferenceException();\n\tv124 = new System.IndexOutOfRangeException();\nL_0087:\n\tv143 = new System.TypeLoadException();\nL_0088:\n\tv134 = new System.ArrayTypeMismatchException();\n\tgoto L_0087;\n\treturn;\n// 93 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			base.OnEnter();
			finishInNextStep = false;
			float[] array = new float[1];
			resultFloats = array;
			float[] array2 = (fromFloats = new float[1]);
			bool isNone = fromValue.IsNone;
			bool flag = !isNone;
			bool flag2 = !flag;
			float num = 0f;
			if (!flag2)
			{
				num = fromValue.Value;
			}
			array2[0] = num;
			float[] array3 = (toFloats = new float[1]);
			bool isNone2 = toValue.IsNone;
			bool flag3 = !isNone2;
			bool flag4 = !flag3;
			float num2 = 0f;
			if (!flag4)
			{
				num2 = toValue.Value;
			}
			array3[0] = num2;
			Calculation[] array4 = new Calculation[1];
			calculations = array4;
			_ = calculation;
			AnimationCurve[] array5 = new AnimationCurve[1];
			FsmAnimationCurve fsmAnimationCurve = animCurve;
			curves = array5;
			if (fsmAnimationCurve.curve != null)
			{
				object obj = fsmAnimationCurve.curve as AnimationCurve;
				if (obj == null)
				{
					while (true)
					{
						ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
						TypeLoadException ex2 = new TypeLoadException();
					}
				}
			}
			array5[0] = fsmAnimationCurve.curve;
			Init();
		}

		[Token(Token = "0x600063C")]
		[Address(RVA = "0xA95968", Offset = "0xA95968", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void OnExit()
		{
		}

		[Token(Token = "0x600063D")]
		[Address(RVA = "0xA9596C", Offset = "0xA9596C", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.CurveFsmAction::OnUpdate(this);\n\tv14 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.floatVariable);\n\tv49 = v14 == 0;\n\tv50 = ~v49;\n\tif (v50) goto L_001F;\n\tv70 = ~this.isRunning;\n\tif (v70) goto L_001F;\n\tv56 = this.resultFloats;\n\tv83 = v56.Length == 0;\n\tif (v83) goto L_0055;\n\tv53 = this.floatVariable;\n\tv53.value = v56[0];\nL_001F:\n\tv75 = ~this.finishInNextStep;\n\tif (v75) goto L_0031;\n\tv87 = ~this.looping;\n\tv88 = ~v87;\n\tif (v88) goto L_0031;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\tv92 = this.finishEvent == 0;\n\tif (v92) goto L_0031;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.finishEvent);\nL_0031:\n\tv96 = ~this.finishAction;\n\tif (v96) goto L_0051;\n\tv101 = ~this.finishInNextStep;\n\tv102 = ~v101;\n\tif (v102) goto L_0051;\n\tv66 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.floatVariable);\n\tv124 = v66 == 0;\n\tv125 = ~v124;\n\tif (v125) goto L_004C;\n\tv57 = this.resultFloats;\n\tv84 = v57.Length == 0;\n\tif (v84) goto L_0055;\n\tv54 = this.floatVariable;\n\tv54.value = v57[0];\nL_004C:\n\tthis.finishInNextStep = 1;\nL_0051:\n\treturn;\n\tthrow System.NullReferenceException;\n\tv68 = new System.NullReferenceException();\nL_0055:\n\tv86 = new System.IndexOutOfRangeException();\n\tthrow v86;\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			base.OnUpdate();
			if (!floatVariable.IsNone && isRunning)
			{
				float[] array = resultFloats;
				if (array.Length == 0)
				{
					goto IL_01e8;
				}
				FsmFloat fsmFloat = floatVariable;
				fsmFloat.Value = array[0];
			}
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
			if (!floatVariable.IsNone)
			{
				float[] array2 = resultFloats;
				if (array2.Length == 0)
				{
					goto IL_01e8;
				}
				FsmFloat fsmFloat2 = floatVariable;
				fsmFloat2.Value = array2[0];
			}
			finishInNextStep = true;
			return;
			IL_01e8:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x600063E")]
		[Address(RVA = "0xA95A64", Offset = "0xA95A64", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CurveFloat()
		{
		}
	}
}
