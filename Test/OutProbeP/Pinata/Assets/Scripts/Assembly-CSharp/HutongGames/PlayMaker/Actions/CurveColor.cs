using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x751D04", Offset = "0x751D04")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x751D04", Offset = "0x751D04")]
	[Token(Token = "0x2000113")]
	public class CurveColor : CurveFsmAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A1864", Offset = "0x7A1864")]
		[Token(Token = "0x4001045")]
		[FieldOffset(Offset = "0xE0")]
		public FsmColor colorVariable;

		[RequiredField]
		[Token(Token = "0x4001046")]
		[FieldOffset(Offset = "0xE8")]
		public FsmColor fromValue;

		[RequiredField]
		[Token(Token = "0x4001047")]
		[FieldOffset(Offset = "0xF0")]
		public FsmColor toValue;

		[RequiredField]
		[Token(Token = "0x4001048")]
		[FieldOffset(Offset = "0xF8")]
		public FsmAnimationCurve curveR;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A18D0", Offset = "0x7A18D0")]
		[Token(Token = "0x4001049")]
		[FieldOffset(Offset = "0x100")]
		public Calculation calculationR;

		[RequiredField]
		[Token(Token = "0x400104A")]
		[FieldOffset(Offset = "0x108")]
		public FsmAnimationCurve curveG;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A1918", Offset = "0x7A1918")]
		[Token(Token = "0x400104B")]
		[FieldOffset(Offset = "0x110")]
		public Calculation calculationG;

		[RequiredField]
		[Token(Token = "0x400104C")]
		[FieldOffset(Offset = "0x118")]
		public FsmAnimationCurve curveB;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A1960", Offset = "0x7A1960")]
		[Token(Token = "0x400104D")]
		[FieldOffset(Offset = "0x120")]
		public Calculation calculationB;

		[RequiredField]
		[Token(Token = "0x400104E")]
		[FieldOffset(Offset = "0x128")]
		public FsmAnimationCurve curveA;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A19A8", Offset = "0x7A19A8")]
		[Token(Token = "0x400104F")]
		[FieldOffset(Offset = "0x130")]
		public Calculation calculationA;

		[Token(Token = "0x4001050")]
		[FieldOffset(Offset = "0x134")]
		private Color clr;

		[Token(Token = "0x4001051")]
		[FieldOffset(Offset = "0x144")]
		private bool finishInNextStep;

		[Token(Token = "0x6000635")]
		[Address(RVA = "0xA93850", Offset = "0xA93850", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1ECEEA8]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2022209]) = v42;\nL_0016:\n\tHutongGames.PlayMaker.Actions.CurveFsmAction::Reset(this);\n\tv47 = new HutongGames.PlayMaker.FsmColor();\n\tHutongGames.PlayMaker.FsmColor::.ctor(v47);\n\tv47.useVariable = 1;\n\tthis.colorVariable = v47;\n\tv53 = new HutongGames.PlayMaker.FsmColor();\n\tHutongGames.PlayMaker.FsmColor::.ctor(v53);\n\tv53.useVariable = 1;\n\tthis.toValue = v53;\n\tv59 = new HutongGames.PlayMaker.FsmColor();\n\tHutongGames.PlayMaker.FsmColor::.ctor(v59);\n\tv59.useVariable = 1;\n\tthis.fromValue = v59;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			base.Reset();
			FsmColor fsmColor = new FsmColor();
			fsmColor.useVariable = true;
			colorVariable = fsmColor;
			FsmColor fsmColor2 = new FsmColor();
			fsmColor2.useVariable = true;
			toValue = fsmColor2;
			FsmColor fsmColor3 = new FsmColor();
			fsmColor3.useVariable = true;
			fromValue = fsmColor3;
		}

		[Token(Token = "0x6000636")]
		[Address(RVA = "0xA93A90", Offset = "0xA93A90", Length = "0x414")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1EA4F70]);\n\tv21 = *([v20 @ X8_v60]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202220A]) = v40;\nL_0015:\n\tHutongGames.PlayMaker.Actions.CurveFsmAction::OnEnter(this);\n\tthis.finishInNextStep = 0;\n\t// 27 NewArr v46 @ X0_v4 (System.Single[]), typeof(System.Single[]), 4\n\tthis.resultFloats = v46;\n\t// 31 NewArr v49 @ X0_v6 (System.Single[]), typeof(System.Single[]), 4\n\tthis.fromFloats = v49;\n\tv55 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.fromValue);\n\tv295 = v55 == 0;\n\tv296 = ~v295;\n\tif (v296) goto L_0036;\n\tv257 = this.fromValue;\n\tv188 = v257.value;\nL_0036:\n\tv49[0] = v188;\n\tv282 = this.fromFloats;\n\tv214 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.fromValue);\n\tv440 = v214 == 0;\n\tv441 = ~v440;\n\tif (v441) goto L_0055;\n\tv258 = this.fromValue;\n\tv189 = v258.value.g;\nL_0055:\n\tv282[1] = v189;\n\tv283 = this.fromFloats;\n\tv215 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.fromValue);\n\tv447 = v215 == 0;\n\tv448 = ~v447;\n\tif (v448) goto L_0074;\n\tv259 = this.fromValue;\n\tv190 = v259.value.b;\nL_0074:\n\tv283[2] = v190;\n\tv284 = this.fromFloats;\n\tv216 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.fromValue);\n\tv454 = v216 == 0;\n\tv455 = ~v454;\n\tif (v455) goto L_0093;\n\tv260 = this.fromValue;\n\tv182 = v260.value.a;\nL_0093:\n\tv284[3] = v182;\n\t// 150 NewArr v217 @ X0_v26 (System.Single[]), typeof(System.Single[]), 4\n\tthis.toFloats = v217;\n\tv218 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.toValue);\n\tv463 = v218 == 0;\n\tv464 = ~v463;\n\tif (v464) goto L_00AD;\n\tv262 = this.toValue;\n\tv191 = v262.value;\nL_00AD:\n\tv217[0] = v191;\n\tv286 = this.toFloats;\n\tv219 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.toValue);\n\tv468 = v219 == 0;\n\tv469 = ~v468;\n\tif (v469) goto L_00CC;\n\tv263 = this.toValue;\n\tv192 = v263.value.g;\nL_00CC:\n\tv286[1] = v192;\n\tv287 = this.toFloats;\n\tv220 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.toValue);\n\tv475 = v220 == 0;\n\tv476 = ~v475;\n\tif (v476) goto L_00EB;\n\tv264 = this.toValue;\n\tv193 = v264.value.b;\nL_00EB:\n\tv287[2] = v193;\n\tv288 = this.toFloats;\n\tv221 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.toValue);\n\tv482 = v221 == 0;\n\tv483 = ~v482;\n\tif (v483) goto L_010A;\n\tv265 = this.toValue;\n\tv187 = v265.value.a;\nL_010A:\n\tv288[3] = v187;\n\t// 271 NewArr v222 @ X0_v36 (UnityEngine.AnimationCurve[]), typeof(UnityEngine.AnimationCurve[]), 4\n\tv266 = this.curveR;\n\tthis.curves = v222;\n\tv491 = v266.curve == 0;\n\tif (v491) goto L_0123;\n\t// 285 IsInst v427 @ X0_v51, typeof(UnityEngine.AnimationCurve), v266.curve (UnityEngine.AnimationCurve)\n\tv431 = v427 == 0;\n\tif (v431) goto L_01CD;\nL_0123:\n\tv222[0] = v266.curve;\n\tv267 = this.curveG;\n\tv210 = this.curves;\n\tv495 = v267.curve == 0;\n\tif (v495) goto L_0140;\n\t// 304 IsInst v428 @ X0_v49, typeof(UnityEngine.AnimationCurve), v267.curve (UnityEngine.AnimationCurve)\n\tv432 = v428 == 0;\n\tif (v432) goto L_01CD;\nL_0140:\n\tv210[1] = v267.curve;\n\tv268 = this.curveB;\n\tv211 = this.curves;\n\tv500 = v268.curve == 0;\n\tif (v500) goto L_015D;\n\t// 333 IsInst v429 @ X0_v47, typeof(UnityEngine.AnimationCurve), v268.curve (UnityEngine.AnimationCurve)\n\tv433 = v429 == 0;\n\tif (v433) goto L_01CD;\nL_015D:\n\tv211[2] = v268.curve;\n\tv269 = this.curveA;\n\tv212 = this.curves;\n\tv505 = v269.curve == 0;\n\tif (v505) goto L_017A;\n\t// 362 IsInst v430 @ X0_v45, typeof(UnityEngine.AnimationCurve), v269.curve (UnityEngine.AnimationCurve)\n\tv434 = v430 == 0;\n\tif (v434) goto L_01CD;\nL_017A:\n\tv212[3] = v269.curve;\n\t// 383 NewArr v226 @ X0_v42 (Calculation[]), typeof(Calculation[]), 4\n\tthis.calculations = v226;\n\t*([v226 @ X0_v42 (Calculation[])+20]) = this.calculationR;\n\tv270 = this.calculations;\n\t*([v270 @ X8_v44 (Calculation[])+24]) = this.calculationG;\n\tv271 = this.calculations;\n\t*([v271 @ X8_v45 (Calculation[])+28]) = this.calculationB;\n\tv272 = this.calculations;\n\t*([v272 @ X8_v46 (Calculation[])+2C]) = this.calculationA;\n\tHutongGames.PlayMaker.Actions.CurveFsmAction::Init(this);\n\treturn;\n\tv334 = new System.NullReferenceException();\n\tv382 = new System.IndexOutOfRangeException();\nL_01CC:\n\tv421 = new System.TypeLoadException();\nL_01CD:\n\tv412 = new System.ArrayTypeMismatchException();\n\tgoto L_01CC;\n\treturn;\n// 338 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			Color color = default(Color);
			if (!flag2)
			{
				FsmColor fsmColor = fromValue;
				color = fsmColor.value;
			}
			array2[0] = color.r;
			float[] array3 = fromFloats;
			bool isNone2 = fromValue.IsNone;
			bool flag3 = !isNone2;
			bool flag4 = !flag3;
			float num = 0f;
			if (!flag4)
			{
				FsmColor fsmColor2 = fromValue;
				num = fsmColor2.value.g;
			}
			array3[1] = num;
			float[] array4 = fromFloats;
			bool isNone3 = fromValue.IsNone;
			bool flag5 = !isNone3;
			bool flag6 = !flag5;
			float num2 = 0f;
			if (!flag6)
			{
				FsmColor fsmColor3 = fromValue;
				num2 = fsmColor3.value.b;
			}
			array4[2] = num2;
			float[] array5 = fromFloats;
			bool isNone4 = fromValue.IsNone;
			bool flag7 = !isNone4;
			bool flag8 = !flag7;
			float num3 = 0f;
			if (!flag8)
			{
				FsmColor fsmColor4 = fromValue;
				num3 = fsmColor4.value.a;
			}
			array5[3] = num3;
			float[] array6 = (toFloats = new float[4]);
			bool isNone5 = toValue.IsNone;
			bool flag9 = !isNone5;
			bool flag10 = !flag9;
			Color color2 = default(Color);
			if (!flag10)
			{
				FsmColor fsmColor5 = toValue;
				color2 = fsmColor5.value;
			}
			array6[0] = color2.r;
			float[] array7 = toFloats;
			bool isNone6 = toValue.IsNone;
			bool flag11 = !isNone6;
			bool flag12 = !flag11;
			float num4 = 0f;
			if (!flag12)
			{
				FsmColor fsmColor6 = toValue;
				num4 = fsmColor6.value.g;
			}
			array7[1] = num4;
			float[] array8 = toFloats;
			bool isNone7 = toValue.IsNone;
			bool flag13 = !isNone7;
			bool flag14 = !flag13;
			float num5 = 0f;
			if (!flag14)
			{
				FsmColor fsmColor7 = toValue;
				num5 = fsmColor7.value.b;
			}
			array8[2] = num5;
			float[] array9 = toFloats;
			bool isNone8 = toValue.IsNone;
			bool flag15 = !isNone8;
			bool flag16 = !flag15;
			float num6 = 0f;
			if (!flag16)
			{
				FsmColor fsmColor8 = toValue;
				num6 = fsmColor8.value.a;
			}
			array9[3] = num6;
			AnimationCurve[] array10 = new AnimationCurve[4];
			FsmAnimationCurve fsmAnimationCurve = curveR;
			curves = array10;
			if (fsmAnimationCurve.curve != null)
			{
				object obj = fsmAnimationCurve.curve as AnimationCurve;
				if (obj == null)
				{
					goto IL_06e9;
				}
			}
			array10[0] = fsmAnimationCurve.curve;
			FsmAnimationCurve fsmAnimationCurve2 = curveG;
			AnimationCurve[] array11 = curves;
			if (fsmAnimationCurve2.curve != null)
			{
				object obj2 = fsmAnimationCurve2.curve as AnimationCurve;
				if (obj2 == null)
				{
					goto IL_06e9;
				}
			}
			array11[1] = fsmAnimationCurve2.curve;
			FsmAnimationCurve fsmAnimationCurve3 = curveB;
			AnimationCurve[] array12 = curves;
			if (fsmAnimationCurve3.curve != null)
			{
				object obj3 = fsmAnimationCurve3.curve as AnimationCurve;
				if (obj3 == null)
				{
					goto IL_06e9;
				}
			}
			array12[2] = fsmAnimationCurve3.curve;
			FsmAnimationCurve fsmAnimationCurve4 = curveA;
			AnimationCurve[] array13 = curves;
			if (fsmAnimationCurve4.curve != null)
			{
				object obj4 = fsmAnimationCurve4.curve as AnimationCurve;
				if (obj4 == null)
				{
					goto IL_06e9;
				}
			}
			array13[3] = fsmAnimationCurve4.curve;
			Calculation[] array14 = new Calculation[4];
			calculations = array14;
			_ = calculationR;
			Calculation[] array15 = calculations;
			_ = calculationG;
			Calculation[] array16 = calculations;
			_ = calculationB;
			Calculation[] array17 = calculations;
			_ = calculationA;
			Init();
			return;
			IL_06e9:
			while (true)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				TypeLoadException ex2 = new TypeLoadException();
			}
		}

		[Token(Token = "0x6000637")]
		[Address(RVA = "0xA944E0", Offset = "0xA944E0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void OnExit()
		{
		}

		[Token(Token = "0x6000638")]
		[Address(RVA = "0xA944E4", Offset = "0xA944E4", Length = "0x190")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.CurveFsmAction::OnUpdate(this);\n\tv14 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.colorVariable);\n\tv123 = v14 == 0;\n\tv124 = ~v123;\n\tif (v124) goto L_0052;\n\tv204 = ~this.isRunning;\n\tif (v204) goto L_0052;\n\tv184 = this.resultFloats;\n\tv275 = v184.Length == 0;\n\tif (v275) goto L_00B8;\n\tv306 = v184.Length == 1;\n\tif (v306) goto L_00B8;\n\tv341 = v184.Length < 2;\n\tv333 = ~v341;\n\tv330 = v184.Length - 2;\n\tv324 = v330 == 0;\n\tv342 = ~v333;\n\tv154 = v342 | v324;\n\tif (v154) goto L_00B8;\n\tv169 = v184.Length == 3;\n\tif (v169) goto L_00B8;\n\tv139 = 0;\n\tv198 = 0x101059C(&v139 @ stack_-30_v8 (System.Single), 0, v18, v113, v114, v115, v116, v117, v184[0], v184[1], v184[2], v184[3], v118, v119, v120, v121);\n\tv127 = this.colorVariable;\n\tthis.clr.r = 0f;\n\tthis.clr.g = v349;\n\tthis.clr.b = 0f;\n\tthis.clr.a = v350;\n\tv127.value = 0;\n\tv127.value.g = v349;\n\tv127.value.b = 0f;\n\tv127.value.a = v350;\nL_0052:\n\tv210 = ~this.finishInNextStep;\n\tif (v210) goto L_0064;\n\tv211 = ~this.looping;\n\tv212 = ~v211;\n\tif (v212) goto L_0064;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\tv216 = this.finishEvent == 0;\n\tif (v216) goto L_0064;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.finishEvent);\nL_0064:\n\tv220 = ~this.finishAction;\n\tif (v220) goto L_00B7;\n\tv277 = ~this.finishInNextStep;\n\tv278 = ~v277;\n\tif (v278) goto L_00B7;\n\tv199 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.colorVariable);\n\tv345 = v199 == 0;\n\tv346 = ~v345;\n\tif (v346) goto L_00B2;\n\tv186 = this.resultFloats;\n\tv338 = v186.Length == 0;\n\tif (v338) goto L_00B8;\n\tv325 = v186.Length == 1;\n\tif (v325) goto L_00B8;\n\tv352 = v186.Length < 2;\n\tv335 = ~v352;\n\tv332 = v186.Length - 2;\n\tv326 = v332 == 0;\n\tv353 = ~v335;\n\tv155 = v353 | v326;\n\tif (v155) goto L_00B8;\n\tv170 = v186.Length == 3;\n\tif (v170) goto L_00B8;\n\tv139 = 0;\n\tv200 = 0x101059C(&v139 @ stack_-30_v8 (System.Single), 0, 0, v113, v114, v115, v116, v117, v186[0], v186[1], v186[2], v186[3], v118, v119, v120, v121);\n\tv128 = this.colorVariable;\n\tthis.clr.r = 0f;\n\tthis.clr.g = v349;\n\tthis.clr.b = 0f;\n\tthis.clr.a = v350;\n\tv128.value = 0;\n\tv128.value.g = v349;\n\tv128.value.b = 0f;\n\tv128.value.a = v350;\nL_00B2:\n\tthis.finishInNextStep = 1;\nL_00B7:\n\treturn;\nL_00B8:\n\tv340 = new System.IndexOutOfRangeException();\n\tthrow v340;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n// 111 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			//IL_00d6: Expected O, but got I4
			//IL_0334: Expected O, but got I4
			base.OnUpdate();
			float g = default(float);
			float a = default(float);
			if (!colorVariable.IsNone && isRunning)
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
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @101059C (inside UnityEngine.ClassLibraryInitializer::Init +0x8)");
						FsmColor fsmColor = colorVariable;
						clr.r = 0f;
						clr.g = g;
						clr.b = 0f;
						clr.a = a;
						fsmColor.value = default(Color);
						fsmColor.value.g = g;
						fsmColor.value.b = 0f;
						fsmColor.value.a = a;
						goto IL_044e;
					}
				}
				goto IL_0440;
			}
			goto IL_044e;
			IL_044e:
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
			if (!colorVariable.IsNone)
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
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @101059C (inside UnityEngine.ClassLibraryInitializer::Init +0x8)");
						FsmColor fsmColor2 = colorVariable;
						clr.r = 0f;
						clr.g = g;
						clr.b = 0f;
						clr.a = a;
						fsmColor2.value = default(Color);
						fsmColor2.value.g = g;
						fsmColor2.value.b = 0f;
						fsmColor2.value.a = a;
						goto IL_046a;
					}
				}
				goto IL_0440;
			}
			goto IL_046a;
			IL_046a:
			finishInNextStep = true;
			return;
			IL_0440:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000639")]
		[Address(RVA = "0xA956E4", Offset = "0xA956E4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CurveColor()
		{
		}
	}
}
