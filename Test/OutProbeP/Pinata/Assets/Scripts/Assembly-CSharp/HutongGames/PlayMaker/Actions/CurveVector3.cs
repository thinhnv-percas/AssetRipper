using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x751E3C", Offset = "0x751E3C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x751E3C", Offset = "0x751E3C")]
	[Token(Token = "0x2000117")]
	public class CurveVector3 : CurveFsmAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A1D50", Offset = "0x7A1D50")]
		[Token(Token = "0x400107D")]
		[FieldOffset(Offset = "0xE0")]
		public FsmVector3 vectorVariable;

		[RequiredField]
		[Token(Token = "0x400107E")]
		[FieldOffset(Offset = "0xE8")]
		public FsmVector3 fromValue;

		[RequiredField]
		[Token(Token = "0x400107F")]
		[FieldOffset(Offset = "0xF0")]
		public FsmVector3 toValue;

		[RequiredField]
		[Token(Token = "0x4001080")]
		[FieldOffset(Offset = "0xF8")]
		public FsmAnimationCurve curveX;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A1DBC", Offset = "0x7A1DBC")]
		[Token(Token = "0x4001081")]
		[FieldOffset(Offset = "0x100")]
		public Calculation calculationX;

		[RequiredField]
		[Token(Token = "0x4001082")]
		[FieldOffset(Offset = "0x108")]
		public FsmAnimationCurve curveY;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A1E04", Offset = "0x7A1E04")]
		[Token(Token = "0x4001083")]
		[FieldOffset(Offset = "0x110")]
		public Calculation calculationY;

		[RequiredField]
		[Token(Token = "0x4001084")]
		[FieldOffset(Offset = "0x118")]
		public FsmAnimationCurve curveZ;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A1E4C", Offset = "0x7A1E4C")]
		[Token(Token = "0x4001085")]
		[FieldOffset(Offset = "0x120")]
		public Calculation calculationZ;

		[Token(Token = "0x4001086")]
		[FieldOffset(Offset = "0x124")]
		private Vector3 vct;

		[Token(Token = "0x4001087")]
		[FieldOffset(Offset = "0x130")]
		private bool finishInNextStep;

		[Token(Token = "0x6000649")]
		[Address(RVA = "0xA96174", Offset = "0xA96174", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EEE5E0]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2022211]) = v42;\nL_0016:\n\tHutongGames.PlayMaker.Actions.CurveFsmAction::Reset(this);\n\tv47 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v47);\n\tv47.useVariable = 1;\n\tthis.vectorVariable = v47;\n\tv53 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v53);\n\tv53.useVariable = 1;\n\tthis.toValue = v53;\n\tv59 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v59);\n\tv59.useVariable = 1;\n\tthis.fromValue = v59;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			base.Reset();
			FsmVector3 fsmVector = new FsmVector3();
			fsmVector.useVariable = true;
			vectorVariable = fsmVector;
			FsmVector3 fsmVector2 = new FsmVector3();
			fsmVector2.useVariable = true;
			toValue = fsmVector2;
			FsmVector3 fsmVector3 = new FsmVector3();
			fsmVector3.useVariable = true;
			fromValue = fsmVector3;
		}

		[Token(Token = "0x600064A")]
		[Address(RVA = "0xA9623C", Offset = "0xA9623C", Length = "0x35C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1EEA718]);\n\tv21 = *([v20 @ X8_v37]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022212]) = v40;\nL_0015:\n\tHutongGames.PlayMaker.Actions.CurveFsmAction::OnEnter(this);\n\tthis.finishInNextStep = 0;\n\t// 27 NewArr v46 @ X0_v4 (System.Single[]), typeof(System.Single[]), 3\n\tthis.resultFloats = v46;\n\t// 31 NewArr v49 @ X0_v6 (System.Single[]), typeof(System.Single[]), 3\n\tthis.fromFloats = v49;\n\tv55 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.fromValue);\n\tv228 = v55 == 0;\n\tv229 = ~v228;\n\tif (v229) goto L_0039;\n\tv155 = HutongGames.PlayMaker.FsmVector3::get_Value(this.fromValue);\nL_0039:\n\tv49[0] = v155;\n\tv221 = this.fromFloats;\n\tv388 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.fromValue);\n\tv390 = v388 == 0;\n\tv391 = ~v390;\n\tif (v391) goto L_005B;\n\tv155 = HutongGames.PlayMaker.FsmVector3::get_Value(this.fromValue);\n\tv148 = v155.y;\nL_005B:\n\tv221[1] = v148;\n\tv222 = this.fromFloats;\n\tv399 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.fromValue);\n\tv401 = v399 == 0;\n\tv402 = ~v401;\n\tif (v402) goto L_007D;\n\tv155 = HutongGames.PlayMaker.FsmVector3::get_Value(this.fromValue);\n\tv148 = v155.y;\n\tv141 = v155.z;\nL_007D:\n\tv222[2] = v141;\n\t// 128 NewArr v178 @ X0_v27 (System.Single[]), typeof(System.Single[]), 3\n\tthis.toFloats = v178;\n\tv412 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.toValue);\n\tv414 = v412 == 0;\n\tv415 = ~v414;\n\tif (v415) goto L_009A;\n\tv156 = HutongGames.PlayMaker.FsmVector3::get_Value(this.toValue);\nL_009A:\n\tv178[0] = v156;\n\tv223 = this.toFloats;\n\tv421 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.toValue);\n\tv423 = v421 == 0;\n\tv424 = ~v423;\n\tif (v424) goto L_00BC;\n\tv156 = HutongGames.PlayMaker.FsmVector3::get_Value(this.toValue);\n\tv149 = v156.y;\nL_00BC:\n\tv223[1] = v149;\n\tv224 = this.toFloats;\n\tv432 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.toValue);\n\tv434 = v432 == 0;\n\tv435 = ~v434;\n\tif (v435) goto L_00DE;\n\tv156 = HutongGames.PlayMaker.FsmVector3::get_Value(this.toValue);\n\tv149 = v156.y;\n\tv142 = v156.z;\nL_00DE:\n\tv224[2] = v142;\n\t// 227 NewArr v179 @ X0_v38 (UnityEngine.AnimationCurve[]), typeof(UnityEngine.AnimationCurve[]), 3\n\tv207 = this.curveX;\n\tthis.curves = v179;\n\tv446 = v207.curve == 0;\n\tif (v446) goto L_00F7;\n\t// 241 IsInst v379 @ X0_v50, typeof(UnityEngine.AnimationCurve), v207.curve (UnityEngine.AnimationCurve)\n\tv382 = v379 == 0;\n\tif (v382) goto L_0172;\nL_00F7:\n\tv179[0] = v207.curve;\n\tv208 = this.curveY;\n\tv175 = this.curves;\n\tv450 = v208.curve == 0;\n\tif (v450) goto L_0114;\n\t// 260 IsInst v380 @ X0_v48, typeof(UnityEngine.AnimationCurve), v208.curve (UnityEngine.AnimationCurve)\n\tv383 = v380 == 0;\n\tif (v383) goto L_0172;\nL_0114:\n\tv175[1] = v208.curve;\n\tv209 = this.curveZ;\n\tv176 = this.curves;\n\tv455 = v209.curve == 0;\n\tif (v455) goto L_0131;\n\t// 289 IsInst v381 @ X0_v46, typeof(UnityEngine.AnimationCurve), v209.curve (UnityEngine.AnimationCurve)\n\tv384 = v381 == 0;\n\tif (v384) goto L_0172;\nL_0131:\n\tv176[2] = v209.curve;\n\t// 310 NewArr v182 @ X0_v43 (Calculation[]), typeof(Calculation[]), 3\n\tthis.calculations = v182;\n\t*([v182 @ X0_v43 (Calculation[])+20]) = this.calculationX;\n\tv210 = this.calculations;\n\t*([v210 @ X8_v31 (Calculation[])+24]) = this.calculationY;\n\tv211 = this.calculations;\n\t*([v211 @ X8_v32 (Calculation[])+28]) = this.calculationZ;\n\tHutongGames.PlayMaker.Actions.CurveFsmAction::Init(this);\n\treturn;\n\tv281 = new System.NullReferenceException();\n\tv331 = new System.IndexOutOfRangeException();\nL_0171:\n\tv374 = new System.TypeLoadException();\nL_0172:\n\tv365 = new System.ArrayTypeMismatchException();\n\tgoto L_0171;\n\treturn;\n// 273 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			base.OnEnter();
			finishInNextStep = false;
			float[] array = new float[3];
			resultFloats = array;
			float[] array2 = (fromFloats = new float[3]);
			bool isNone = fromValue.IsNone;
			bool flag = !isNone;
			bool flag2 = !flag;
			Vector3 vector = default(Vector3);
			if (!flag2)
			{
				vector = fromValue.Value;
			}
			array2[0] = vector.x;
			float[] array3 = fromFloats;
			bool isNone2 = fromValue.IsNone;
			bool flag3 = !isNone2;
			bool flag4 = !flag3;
			float num = 0f;
			if (!flag4)
			{
				num = fromValue.Value.y;
			}
			array3[1] = num;
			float[] array4 = fromFloats;
			bool isNone3 = fromValue.IsNone;
			bool flag5 = !isNone3;
			bool flag6 = !flag5;
			float num2 = 0f;
			if (!flag6)
			{
				vector = fromValue.Value;
				num = vector.y;
				num2 = vector.z;
			}
			array4[2] = num2;
			float[] array5 = (toFloats = new float[3]);
			bool isNone4 = toValue.IsNone;
			bool flag7 = !isNone4;
			bool flag8 = !flag7;
			Vector3 vector2 = default(Vector3);
			if (!flag8)
			{
				vector2 = toValue.Value;
			}
			array5[0] = vector2.x;
			float[] array6 = toFloats;
			bool isNone5 = toValue.IsNone;
			bool flag9 = !isNone5;
			bool flag10 = !flag9;
			float num3 = 0f;
			if (!flag10)
			{
				num3 = toValue.Value.y;
			}
			array6[1] = num3;
			float[] array7 = toFloats;
			bool isNone6 = toValue.IsNone;
			bool flag11 = !isNone6;
			bool flag12 = !flag11;
			float num4 = 0f;
			if (!flag12)
			{
				vector2 = toValue.Value;
				num3 = vector2.y;
				num4 = vector2.z;
			}
			array7[2] = num4;
			AnimationCurve[] array8 = new AnimationCurve[3];
			FsmAnimationCurve fsmAnimationCurve = curveX;
			curves = array8;
			if (fsmAnimationCurve.curve != null)
			{
				object obj = fsmAnimationCurve.curve as AnimationCurve;
				if (obj == null)
				{
					goto IL_052b;
				}
			}
			array8[0] = fsmAnimationCurve.curve;
			FsmAnimationCurve fsmAnimationCurve2 = curveY;
			AnimationCurve[] array9 = curves;
			if (fsmAnimationCurve2.curve != null)
			{
				object obj2 = fsmAnimationCurve2.curve as AnimationCurve;
				if (obj2 == null)
				{
					goto IL_052b;
				}
			}
			array9[1] = fsmAnimationCurve2.curve;
			FsmAnimationCurve fsmAnimationCurve3 = curveZ;
			AnimationCurve[] array10 = curves;
			if (fsmAnimationCurve3.curve != null)
			{
				object obj3 = fsmAnimationCurve3.curve as AnimationCurve;
				if (obj3 == null)
				{
					goto IL_052b;
				}
			}
			array10[2] = fsmAnimationCurve3.curve;
			Calculation[] array11 = new Calculation[3];
			calculations = array11;
			_ = calculationX;
			Calculation[] array12 = calculations;
			_ = calculationY;
			Calculation[] array13 = calculations;
			_ = calculationZ;
			Init();
			return;
			IL_052b:
			while (true)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				TypeLoadException ex2 = new TypeLoadException();
			}
		}

		[Token(Token = "0x600064B")]
		[Address(RVA = "0xA96598", Offset = "0xA96598", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void OnExit()
		{
		}

		[Token(Token = "0x600064C")]
		[Address(RVA = "0xA9659C", Offset = "0xA9659C", Length = "0x180")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.CurveFsmAction::OnUpdate(this);\n\tv14 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.vectorVariable);\n\tv94 = v14 == 0;\n\tv95 = ~v94;\n\tif (v95) goto L_0044;\n\tv162 = ~this.isRunning;\n\tif (v162) goto L_0044;\n\tv151 = this.resultFloats;\n\tv156 = v151.Length == 0;\n\tif (v156) goto L_009D;\n\tv128 = v151.Length == 1;\n\tif (v128) goto L_009D;\n\tv306 = v151.Length < 2;\n\tv144 = ~v306;\n\tv139 = v151.Length - 2;\n\tv129 = v139 == 0;\n\tv307 = ~v144;\n\tv105 = v307 | v129;\n\tif (v105) goto L_009D;\n\tv165 = 0;\n\tv178 = 0x1586898(&v165 @ stack_-30_v8 (System.Single), 0, v17, v83, v84, v85, v86, v87, v151[0], v151[1], v151[2], v88, v89, v90, v91, v92);\n\tv163 = this.vectorVariable;\n\tthis.vct.x = 0f;\n\tthis.vct.y = v312;\n\tthis.vct.z = 0f;\n\tv163.value = 0;\n\tv163.value.y = v312;\n\tv163.value.z = 0f;\nL_0044:\n\tv180 = ~this.finishInNextStep;\n\tif (v180) goto L_0056;\n\tv185 = ~this.looping;\n\tv186 = ~v185;\n\tif (v186) goto L_0056;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\tv190 = this.finishEvent == 0;\n\tif (v190) goto L_0056;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.finishEvent);\nL_0056:\n\tv194 = ~this.finishAction;\n\tif (v194) goto L_009B;\n\tv233 = ~this.finishInNextStep;\n\tv234 = ~v233;\n\tif (v234) goto L_009B;\n\tv159 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.vectorVariable);\n\tv310 = v159 == 0;\n\tv311 = ~v310;\n\tif (v311) goto L_0096;\n\tv152 = this.resultFloats;\n\tv157 = v152.Length == 0;\n\tif (v157) goto L_009D;\n\tv130 = v152.Length == 1;\n\tif (v130) goto L_009D;\n\tv315 = v152.Length < 2;\n\tv146 = ~v315;\n\tv141 = v152.Length - 2;\n\tv131 = v141 == 0;\n\tv316 = ~v146;\n\tv106 = v316 | v131;\n\tif (v106) goto L_009D;\n\tv165 = 0;\n\tv229 = 0x1586898(&v165 @ stack_-30_v8 (System.Single), 0, 0, v83, v84, v85, v86, v87, v152[0], v152[1], v152[2], v88, v89, v90, v91, v92);\n\tv197 = this.vectorVariable;\n\tthis.vct.x = 0f;\n\tthis.vct.y = v312;\n\tthis.vct.z = 0f;\n\tv197.value = 0;\n\tv197.value.y = v312;\n\tv197.value.z = 0f;\nL_0096:\n\tthis.finishInNextStep = 1;\nL_009B:\n\treturn;\n\tv82 = new System.NullReferenceException();\nL_009D:\n\tv160 = new System.IndexOutOfRangeException();\n\tthrow v160;\n\tthrow System.NullReferenceException;\n// 91 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			//IL_00d6: Expected O, but got I4
			//IL_02f4: Expected O, but got I4
			base.OnUpdate();
			float y = default(float);
			if (!vectorVariable.IsNone && isRunning)
			{
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
						float num = 0f;
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
						FsmVector3 fsmVector = vectorVariable;
						vct.x = 0f;
						vct.y = y;
						vct.z = 0f;
						fsmVector.value = default(Vector3);
						fsmVector.value.y = y;
						fsmVector.value.z = 0f;
						goto IL_03ce;
					}
				}
				goto IL_03c0;
			}
			goto IL_03ce;
			IL_03c0:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
			IL_03ea:
			finishInNextStep = true;
			return;
			IL_03ce:
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
			if (!vectorVariable.IsNone)
			{
				float[] array2 = resultFloats;
				if (array2.Length != 0 && array2.Length != 1)
				{
					bool flag5 = array2.Length < 2;
					bool flag6 = !flag5;
					object obj2 = array2.Length - 2;
					bool flag7 = obj2 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						float num = 0f;
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
						FsmVector3 fsmVector2 = vectorVariable;
						vct.x = 0f;
						vct.y = y;
						vct.z = 0f;
						fsmVector2.value = default(Vector3);
						fsmVector2.value.y = y;
						fsmVector2.value.z = 0f;
						goto IL_03ea;
					}
				}
				goto IL_03c0;
			}
			goto IL_03ea;
		}

		[Token(Token = "0x600064D")]
		[Address(RVA = "0xA9671C", Offset = "0xA9671C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CurveVector3()
		{
		}
	}
}
