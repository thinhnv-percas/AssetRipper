using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x751CB4", Offset = "0x751CB4")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x751CB4", Offset = "0x751CB4")]
	[Token(Token = "0x2000112")]
	public class AnimateVector3 : AnimateFsmAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A1750", Offset = "0x7A1750")]
		[Token(Token = "0x400103D")]
		[FieldOffset(Offset = "0xD8")]
		public FsmVector3 vectorVariable;

		[RequiredField]
		[Token(Token = "0x400103E")]
		[FieldOffset(Offset = "0xE0")]
		public FsmAnimationCurve curveX;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A179C", Offset = "0x7A179C")]
		[Token(Token = "0x400103F")]
		[FieldOffset(Offset = "0xE8")]
		public Calculation calculationX;

		[RequiredField]
		[Token(Token = "0x4001040")]
		[FieldOffset(Offset = "0xF0")]
		public FsmAnimationCurve curveY;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A17E4", Offset = "0x7A17E4")]
		[Token(Token = "0x4001041")]
		[FieldOffset(Offset = "0xF8")]
		public Calculation calculationY;

		[RequiredField]
		[Token(Token = "0x4001042")]
		[FieldOffset(Offset = "0x100")]
		public FsmAnimationCurve curveZ;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A182C", Offset = "0x7A182C")]
		[Token(Token = "0x4001043")]
		[FieldOffset(Offset = "0x108")]
		public Calculation calculationZ;

		[Token(Token = "0x4001044")]
		[FieldOffset(Offset = "0x10C")]
		private bool finishInNextStep;

		[Token(Token = "0x6000630")]
		[Address(RVA = "0xA86DA4", Offset = "0xA86DA4", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EEFA88]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202219E]) = v38;\nL_0015:\n\tHutongGames.PlayMaker.Actions.AnimateFsmAction::Reset(this);\n\tv44 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v44);\n\tv44.useVariable = 1;\n\tthis.vectorVariable = v44;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			base.Reset();
			FsmVector3 fsmVector = new FsmVector3();
			fsmVector.useVariable = true;
			vectorVariable = fsmVector;
		}

		[Token(Token = "0x6000631")]
		[Address(RVA = "0xA86E24", Offset = "0xA86E24", Length = "0x300")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1ECC540]);\n\tv23 = *([v22 @ X8_v39]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202219F]) = v42;\nL_0017:\n\tHutongGames.PlayMaker.Actions.AnimateFsmAction::OnEnter(this);\n\tthis.finishInNextStep = 0;\n\t// 29 NewArr v49 @ X0_v4 (System.Single[]), typeof(System.Single[]), 3\n\tthis.resultFloats = v49;\n\t// 33 NewArr v52 @ X0_v6 (System.Single[]), typeof(System.Single[]), 3\n\tthis.fromFloats = v52;\n\tv58 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.vectorVariable);\n\tv186 = v58 == 0;\n\tv187 = ~v186;\n\tif (v187) goto L_003B;\n\tv138 = HutongGames.PlayMaker.FsmVector3::get_Value(this.vectorVariable);\nL_003B:\n\tv52[0] = v138;\n\tv181 = this.fromFloats;\n\tv332 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.vectorVariable);\n\tv334 = v332 == 0;\n\tv335 = ~v334;\n\tif (v335) goto L_005D;\n\tv138 = HutongGames.PlayMaker.FsmVector3::get_Value(this.vectorVariable);\n\tv134 = v138.y;\nL_005D:\n\tv181[1] = v134;\n\tv182 = this.fromFloats;\n\tv343 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.vectorVariable);\n\tv345 = v343 == 0;\n\tv346 = ~v345;\n\tif (v346) goto L_007F;\n\tv138 = HutongGames.PlayMaker.FsmVector3::get_Value(this.vectorVariable);\n\tv134 = v138.y;\n\tv130 = v138.z;\nL_007F:\n\tv182[2] = v130;\n\t// 132 NewArr v150 @ X0_v27 (UnityEngine.AnimationCurve[]), typeof(UnityEngine.AnimationCurve[]), 3\n\tv170 = this.curveX;\n\tthis.curves = v150;\n\tv357 = v170.curve == 0;\n\tif (v357) goto L_0098;\n\t// 146 IsInst v323 @ X0_v45, typeof(UnityEngine.AnimationCurve), v170.curve (UnityEngine.AnimationCurve)\n\tv326 = v323 == 0;\n\tif (v326) goto L_013F;\nL_0098:\n\tv150[0] = v170.curve;\n\tv171 = this.curveY;\n\tv64 = this.curves;\n\tv361 = v171.curve == 0;\n\tif (v361) goto L_00B5;\n\t// 165 IsInst v324 @ X0_v43, typeof(UnityEngine.AnimationCurve), v171.curve (UnityEngine.AnimationCurve)\n\tv327 = v324 == 0;\n\tif (v327) goto L_013F;\nL_00B5:\n\tv64[1] = v171.curve;\n\tv172 = this.curveZ;\n\tv65 = this.curves;\n\tv366 = v172.curve == 0;\n\tif (v366) goto L_00D2;\n\t// 194 IsInst v325 @ X0_v41, typeof(UnityEngine.AnimationCurve), v172.curve (UnityEngine.AnimationCurve)\n\tv328 = v325 == 0;\n\tif (v328) goto L_013F;\nL_00D2:\n\tv65[2] = v172.curve;\n\t// 215 NewArr v153 @ X0_v32 (Calculation[]), typeof(Calculation[]), 3\n\tthis.calculations = v153;\n\t*([v153 @ X0_v32 (Calculation[])+20]) = this.calculationX;\n\tv173 = this.calculations;\n\t*([v173 @ X8_v27 (Calculation[])+24]) = this.calculationY;\n\tv174 = this.calculations;\n\t*([v174 @ X8_v28 (Calculation[])+28]) = this.calculationZ;\n\tHutongGames.PlayMaker.Actions.AnimateFsmAction::Init(this);\n\tv380 = HutongGames.PlayMaker.FsmFloat::get_Value(this.delay);\n\tgoto L_011B;\n\tv388 = *([v384 @ X0_v35+E0]);\n\tv389 = v388 == 0;\n\tv390 = ~v389;\n\tif (v390) goto L_011B;\n\tv392 = \"il2cpp_codegen_runtime_class_init\"(v384, v379, v26, v27, v28, v29, v30, v31, v380, v134, v130, v35, v36, v37, v38, v39);\nL_011B:\n\tv397 = UnityEngine.Mathf::Abs(v380);\n\tv407 = v397 >= 0.01f;\n\tif (v407) goto L_0138;\n\tHutongGames.PlayMaker.Actions.AnimateVector3::UpdateVariableValue(this);\n\treturn;\nL_0138:\n\treturn;\n\tv236 = new System.NullReferenceException();\n\tv275 = new System.IndexOutOfRangeException();\nL_013E:\n\tv318 = new System.TypeLoadException();\nL_013F:\n\tv309 = new System.ArrayTypeMismatchException();\n\tgoto L_013E;\n\treturn;\n// 235 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			base.OnEnter();
			finishInNextStep = false;
			float[] array = new float[3];
			resultFloats = array;
			float[] array2 = (fromFloats = new float[3]);
			bool isNone = vectorVariable.IsNone;
			bool flag = !isNone;
			bool flag2 = !flag;
			Vector3 vector = default(Vector3);
			if (!flag2)
			{
				vector = vectorVariable.Value;
			}
			array2[0] = vector.x;
			float[] array3 = fromFloats;
			bool isNone2 = vectorVariable.IsNone;
			bool flag3 = !isNone2;
			bool flag4 = !flag3;
			float num = 0f;
			if (!flag4)
			{
				num = vectorVariable.Value.y;
			}
			array3[1] = num;
			float[] array4 = fromFloats;
			bool isNone3 = vectorVariable.IsNone;
			bool flag5 = !isNone3;
			bool flag6 = !flag5;
			float num2 = 0f;
			if (!flag6)
			{
				vector = vectorVariable.Value;
				num = vector.y;
				num2 = vector.z;
			}
			array4[2] = num2;
			AnimationCurve[] array5 = new AnimationCurve[3];
			FsmAnimationCurve fsmAnimationCurve = curveX;
			curves = array5;
			if (fsmAnimationCurve.curve != null)
			{
				object obj = fsmAnimationCurve.curve as AnimationCurve;
				if (obj == null)
				{
					goto IL_03e0;
				}
			}
			array5[0] = fsmAnimationCurve.curve;
			FsmAnimationCurve fsmAnimationCurve2 = curveY;
			AnimationCurve[] array6 = curves;
			if (fsmAnimationCurve2.curve != null)
			{
				object obj2 = fsmAnimationCurve2.curve as AnimationCurve;
				if (obj2 == null)
				{
					goto IL_03e0;
				}
			}
			array6[1] = fsmAnimationCurve2.curve;
			FsmAnimationCurve fsmAnimationCurve3 = curveZ;
			AnimationCurve[] array7 = curves;
			if (fsmAnimationCurve3.curve != null)
			{
				object obj3 = fsmAnimationCurve3.curve as AnimationCurve;
				if (obj3 == null)
				{
					goto IL_03e0;
				}
			}
			array7[2] = fsmAnimationCurve3.curve;
			Calculation[] array8 = new Calculation[3];
			calculations = array8;
			_ = calculationX;
			Calculation[] array9 = calculations;
			_ = calculationY;
			Calculation[] array10 = calculations;
			_ = calculationZ;
			Init();
			float value = delay.Value;
			float num3 = Mathf.Abs(value);
			if (num3 < 0.01f)
			{
				UpdateVariableValue();
			}
			return;
			IL_03e0:
			while (true)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				TypeLoadException ex2 = new TypeLoadException();
			}
		}

		[Token(Token = "0x6000632")]
		[Address(RVA = "0xA87124", Offset = "0xA87124", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.vectorVariable);\n\tv72 = v13 == 0;\n\tv73 = ~v72;\n\tif (v73) goto L_003E;\n\tv48 = this.resultFloats;\n\tv54 = v48.Length == 0;\n\tif (v54) goto L_003F;\n\tv170 = v48.Length == 1;\n\tif (v170) goto L_003F;\n\tv176 = v48.Length < 2;\n\tv104 = ~v176;\n\tv102 = v48.Length - 2;\n\tv98 = v102 == 0;\n\tv177 = ~v104;\n\tv88 = v177 | v98;\n\tif (v88) goto L_003F;\n\tv115 = this.vectorVariable;\n\tv77 = 0;\n\tv113 = 0x1586898(&v77 @ stack_-30_v3 (UnityEngine.Vector3), 0, v16, v58, v59, v60, v61, v62, v48[0], v48[1], v48[2], v66, v67, v68, v69, v70);\n\tv115.value = 0;\n\tv115.value.z = 0f;\nL_003E:\n\treturn;\nL_003F:\n\tv175 = new System.IndexOutOfRangeException();\n\tthrow v175;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void UpdateVariableValue()
		{
			//IL_00b0: Expected O, but got I4
			if (vectorVariable.IsNone)
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
				if (!(flag4 || flag3))
				{
					FsmVector3 fsmVector = vectorVariable;
					Vector3 vector = default(Vector3);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
					fsmVector.value = default(Vector3);
					fsmVector.value.z = 0f;
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000633")]
		[Address(RVA = "0xA871CC", Offset = "0xA871CC", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.AnimateFsmAction::OnUpdate(this);\n\tv12 = ~this.isRunning;\n\tif (v12) goto L_000E;\n\tHutongGames.PlayMaker.Actions.AnimateVector3::UpdateVariableValue(this);\nL_000E:\n\tv16 = ~this.finishInNextStep;\n\tif (v16) goto L_001E;\n\tv18 = ~this.looping;\n\tv19 = ~v18;\n\tif (v19) goto L_001E;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.finishEvent);\nL_001E:\n\tv31 = ~this.finishAction;\n\tif (v31) goto L_002C;\n\tv35 = ~this.finishInNextStep;\n\tv36 = ~v35;\n\tif (v36) goto L_002C;\n\tHutongGames.PlayMaker.Actions.AnimateVector3::UpdateVariableValue(this);\n\tthis.finishInNextStep = 1;\nL_002C:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x6000634")]
		[Address(RVA = "0xA87254", Offset = "0xA87254", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.AnimateFsmAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AnimateVector3()
		{
		}
	}
}
