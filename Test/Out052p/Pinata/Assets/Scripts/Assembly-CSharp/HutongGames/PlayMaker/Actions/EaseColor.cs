using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x751E8C", Offset = "0x751E8C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x751E8C", Offset = "0x751E8C")]
	[Token(Token = "0x2000118")]
	public class EaseColor : EaseFsmAction
	{
		[RequiredField]
		[Token(Token = "0x4001088")]
		[FieldOffset(Offset = "0xC8")]
		public FsmColor fromValue;

		[RequiredField]
		[Token(Token = "0x4001089")]
		[FieldOffset(Offset = "0xD0")]
		public FsmColor toValue;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A1EA4", Offset = "0x7A1EA4")]
		[Token(Token = "0x400108A")]
		[FieldOffset(Offset = "0xD8")]
		public FsmColor colorVariable;

		[Token(Token = "0x400108B")]
		[FieldOffset(Offset = "0xE0")]
		private bool finishInNextStep;

		[Token(Token = "0x600064E")]
		[Address(RVA = "0xB71128", Offset = "0xB71128", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.EaseFsmAction::Reset(this);\n\tthis.finishInNextStep = 0;\n\tthis.toValue = 0;\n\tthis.colorVariable = 0;\n\tthis.fromValue = 0;\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			base.Reset();
			finishInNextStep = false;
			toValue = null;
			colorVariable = null;
			fromValue = null;
		}

		[Token(Token = "0x600064F")]
		[Address(RVA = "0xB7128C", Offset = "0xB7128C", Length = "0x1D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EE4CE8]);\n\tv19 = *([v18 @ X8_v26]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20228FE]) = v38;\nL_0014:\n\tHutongGames.PlayMaker.Actions.EaseFsmAction::OnEnter(this);\n\t// 25 NewArr v44 @ X0_v4 (System.Single[]), typeof(System.Single[]), 4\n\tv45 = this.fromValue;\n\tthis.fromFloats = v44;\n\tv171 = v44.Length == 0;\n\tif (v171) goto L_00CA;\n\tv44[0] = v45.value;\n\tv162 = this.fromValue;\n\tv131 = this.fromFloats;\n\tv210 = v131.Length < 1;\n\tv114 = ~v210;\n\tv106 = v131.Length - 1;\n\tv90 = v106 == 0;\n\tv211 = ~v114;\n\tv50 = v211 | v90;\n\tif (v50) goto L_00CA;\n\tv131[1] = v162.value.g;\n\tv163 = this.fromValue;\n\tv132 = this.fromFloats;\n\tv242 = v132.Length < 2;\n\tv115 = ~v242;\n\tv107 = v132.Length - 2;\n\tv91 = v107 == 0;\n\tv243 = ~v115;\n\tv51 = v243 | v91;\n\tif (v51) goto L_00CA;\n\tv132[2] = v163.value.b;\n\tv164 = this.fromValue;\n\tv133 = this.fromFloats;\n\tv245 = v133.Length < 3;\n\tv116 = ~v245;\n\tv108 = v133.Length - 3;\n\tv92 = v108 == 0;\n\tv246 = ~v116;\n\tv52 = v246 | v92;\n\tif (v52) goto L_00CA;\n\tv133[3] = v164.value.a;\n\t// 102 NewArr v143 @ X0_v13 (System.Single[]), typeof(System.Single[]), 4\n\tv165 = this.toValue;\n\tthis.toFloats = v143;\n\tv204 = v143.Length == 0;\n\tif (v204) goto L_00CA;\n\tv143[0] = v165.value;\n\tv166 = this.toValue;\n\tv135 = this.toFloats;\n\tv250 = v135.Length < 1;\n\tv117 = ~v250;\n\tv109 = v135.Length - 1;\n\tv93 = v109 == 0;\n\tv251 = ~v117;\n\tv53 = v251 | v93;\n\tif (v53) goto L_00CA;\n\tv135[1] = v166.value.g;\n\tv167 = this.toValue;\n\tv136 = this.toFloats;\n\tv253 = v136.Length < 2;\n\tv118 = ~v253;\n\tv110 = v136.Length - 2;\n\tv94 = v110 == 0;\n\tv254 = ~v118;\n\tv54 = v254 | v94;\n\tif (v54) goto L_00CA;\n\tv136[2] = v167.value.b;\n\tv168 = this.toValue;\n\tv137 = this.toFloats;\n\tv256 = v137.Length < 3;\n\tv119 = ~v256;\n\tv111 = v137.Length - 3;\n\tv95 = v111 == 0;\n\tv257 = ~v119;\n\tv55 = v257 | v95;\n\tif (v55) goto L_00CA;\n\tv137[3] = v168.value.a;\n\t// 179 NewArr v144 @ X0_v15 (System.Single[]), typeof(System.Single[]), 4\n\tv169 = this.fromValue;\n\tthis.resultFloats = v144;\n\tthis.finishInNextStep = 0;\n\tv138 = this.colorVariable;\n\tv138.value.r = v169.value;\n\tv138.value.g = v169.value.g;\n\tv138.value.a = v169.value.a;\n\treturn;\n\tv188 = new System.NullReferenceException();\nL_00CA:\n\tv206 = new System.IndexOutOfRangeException();\n\tthrow v206;\n\treturn;\n// 115 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			//IL_008a: Expected O, but got I4
			//IL_0125: Expected O, but got I4
			//IL_01c0: Expected O, but got I4
			//IL_02bd: Expected O, but got I4
			//IL_0358: Expected O, but got I4
			//IL_03f3: Expected O, but got I4
			base.OnEnter();
			float[] array = new float[4];
			FsmColor fsmColor = fromValue;
			fromFloats = array;
			if (array.Length != 0)
			{
				array[0] = fsmColor.value.r;
				FsmColor fsmColor2 = fromValue;
				float[] array2 = fromFloats;
				bool flag = array2.Length < 1;
				bool flag2 = !flag;
				object obj = array2.Length - 1;
				bool flag3 = obj == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array2[1] = fsmColor2.value.g;
					FsmColor fsmColor3 = fromValue;
					float[] array3 = fromFloats;
					bool flag5 = array3.Length < 2;
					bool flag6 = !flag5;
					object obj2 = array3.Length - 2;
					bool flag7 = obj2 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array3[2] = fsmColor3.value.b;
						FsmColor fsmColor4 = fromValue;
						float[] array4 = fromFloats;
						bool flag9 = array4.Length < 3;
						bool flag10 = !flag9;
						object obj3 = array4.Length - 3;
						bool flag11 = obj3 == null;
						bool flag12 = !flag10;
						if (!(flag12 || flag11))
						{
							array4[3] = fsmColor4.value.a;
							float[] array5 = new float[4];
							FsmColor fsmColor5 = toValue;
							toFloats = array5;
							if (array5.Length != 0)
							{
								array5[0] = fsmColor5.value.r;
								FsmColor fsmColor6 = toValue;
								float[] array6 = toFloats;
								bool flag13 = array6.Length < 1;
								bool flag14 = !flag13;
								object obj4 = array6.Length - 1;
								bool flag15 = obj4 == null;
								bool flag16 = !flag14;
								if (!(flag16 || flag15))
								{
									array6[1] = fsmColor6.value.g;
									FsmColor fsmColor7 = toValue;
									float[] array7 = toFloats;
									bool flag17 = array7.Length < 2;
									bool flag18 = !flag17;
									object obj5 = array7.Length - 2;
									bool flag19 = obj5 == null;
									bool flag20 = !flag18;
									if (!(flag20 || flag19))
									{
										array7[2] = fsmColor7.value.b;
										FsmColor fsmColor8 = toValue;
										float[] array8 = toFloats;
										bool flag21 = array8.Length < 3;
										bool flag22 = !flag21;
										object obj6 = array8.Length - 3;
										bool flag23 = obj6 == null;
										bool flag24 = !flag22;
										if (!(flag24 || flag23))
										{
											array8[3] = fsmColor8.value.a;
											float[] array9 = new float[4];
											FsmColor fsmColor9 = fromValue;
											resultFloats = array9;
											finishInNextStep = false;
											FsmColor fsmColor10 = colorVariable;
											fsmColor10.value.r = fsmColor9.value.r;
											fsmColor10.value.g = fsmColor9.value.g;
											fsmColor10.value.a = fsmColor9.value.a;
											return;
										}
									}
								}
							}
						}
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000650")]
		[Address(RVA = "0xB71528", Offset = "0xB71528", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void OnExit()
		{
		}

		[Token(Token = "0x6000651")]
		[Address(RVA = "0xB71530", Offset = "0xB71530", Length = "0x264")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.EaseFsmAction::OnUpdate(this);\n\tv22 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.colorVariable);\n\tv137 = v22 == 0;\n\tv138 = ~v137;\n\tif (v138) goto L_0050;\n\tv195 = ~this.isRunning;\n\tif (v195) goto L_0050;\n\tv188 = this.resultFloats;\n\tv191 = v188.Length == 0;\n\tif (v191) goto L_00F2;\n\tv170 = v188.Length == 1;\n\tif (v170) goto L_00F2;\n\tv367 = v188.Length < 2;\n\tv183 = ~v367;\n\tv179 = v188.Length - 2;\n\tv171 = v179 == 0;\n\tv368 = ~v183;\n\tv152 = v368 | v171;\n\tif (v152) goto L_00F2;\n\tv172 = v188.Length == 3;\n\tif (v172) goto L_00F2;\n\tv199 = this.colorVariable;\n\tv198 = 0;\n\tv212 = 0x101059C(&v198 @ stack_-50_v8 (System.Single), 0, v31, v127, v128, v129, v130, v131, v188[0], v188[1], v188[2], v188[3], v132, v133, v134, v135);\n\tv199.value.r = 0f;\n\tv199.value.g = v380;\n\tv199.value.a = v381;\nL_0050:\n\tv213 = ~this.finishInNextStep;\n\tif (v213) goto L_005E;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\tv222 = this.finishEvent == 0;\n\tif (v222) goto L_005E;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.finishEvent);\nL_005E:\n\tv225 = ~this.finishAction;\n\tif (v225) goto L_00F0;\n\tv296 = ~this.finishInNextStep;\n\tv297 = ~v296;\n\tif (v297) goto L_00F0;\n\tv369 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.colorVariable);\n\tv372 = v369 == 0;\n\tv373 = ~v372;\n\tif (v373) goto L_00E7;\n\tv43 = this.colorVariable;\n\tv379 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.reverse);\n\tv383 = v379 == 0;\n\tv384 = ~v383;\n\tif (v384) goto L_0084;\n\tv285 = HutongGames.PlayMaker.FsmBool::get_Value(this.reverse);\n\tv386 = v285 == 0;\n\tif (v386) goto L_0084;\n\tv90 = this.fromValue;\n\tv391 = this.fromValue == 0;\n\tv275 = ~v391;\n\tif (v275) goto L_008C;\n\tgoto L_00F7;\nL_0084:\n\tv90 = this.toValue;\nL_008C:\n\tv390 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.reverse);\n\tv393 = v390 == 0;\n\tv394 = ~v393;\n\tif (v394) goto L_009E;\n\tv287 = HutongGames.PlayMaker.FsmBool::get_Value(this.reverse);\n\tv396 = v287 == 0;\n\tif (v396) goto L_009E;\n\tv91 = this.fromValue;\n\tv401 = this.fromValue == 0;\n\tv277 = ~v401;\n\tif (v277) goto L_00A6;\n\tgoto L_00F7;\nL_009E:\n\tv91 = this.toValue;\nL_00A6:\n\tv400 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.reverse);\n\tv403 = v400 == 0;\n\tv404 = ~v403;\n\tif (v404) goto L_00B8;\n\tv289 = HutongGames.PlayMaker.FsmBool::get_Value(this.reverse);\n\tv406 = v289 == 0;\n\tif (v406) goto L_00B8;\n\tv92 = this.fromValue;\n\tv411 = this.fromValue == 0;\n\tv279 = ~v411;\n\tif (v279) goto L_00C0;\n\tgoto L_00F7;\nL_00B8:\n\tv92 = this.toValue;\nL_00C0:\n\tv410 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.reverse);\n\tv413 = v410 == 0;\n\tv414 = ~v413;\n\tif (v414) goto L_00D2;\n\tv291 = HutongGames.PlayMaker.FsmBool::get_Value(this.reverse);\n\tv416 = v291 == 0;\n\tif (v416) goto L_00D2;\n\tv263 = this.fromValue;\n\tv422 = this.fromValue == 0;\n\tv281 = ~v422;\n\tif (v281) goto L_00DB;\n\tgoto L_00F7;\nL_00D2:\n\tv263 = this.toValue;\nL_00DB:\n\tv198 = 0;\n\tv293 = 0x101059C(&v198 @ stack_-50_v8 (System.Single), 0, 0, v127, v128, v129, v130, v131, v90.value, v91.value.g, v92.value.b, v263.value.a, v132, v133, v134, v135);\n\tv43.value.r = 0f;\n\tv43.value.g = v380;\n\tv43.value.a = v381;\nL_00E7:\n\tthis.finishInNextStep = 1;\nL_00F0:\n\treturn;\n\tv126 = new System.NullReferenceException();\nL_00F2:\n\tv193 = new System.IndexOutOfRangeException();\n\tthrow v193;\nL_00F7:\n\tthrow System.NullReferenceException;\n// 143 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			//IL_00d6: Expected O, but got I4
			//IL_0171: Expected F4, but got O
			//IL_052e: Expected F4, but got O
			base.OnUpdate();
			object obj2 = default(object);
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
						FsmColor fsmColor = colorVariable;
						float num = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @101059C (inside UnityEngine.ClassLibraryInitializer::Init +0x8)");
						fsmColor.value.r = 0f;
						fsmColor.value.g = (float)obj2;
						fsmColor.value.a = a;
						goto IL_0559;
					}
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			goto IL_0559;
			IL_0559:
			if (finishInNextStep)
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
				FsmColor fsmColor2 = colorVariable;
				if (!reverse.IsNone && reverse.Value)
				{
					FsmColor fsmColor3 = fromValue;
					if (fromValue == null)
					{
						goto IL_0553;
					}
				}
				else
				{
					FsmColor fsmColor3 = toValue;
				}
				if (!reverse.IsNone && reverse.Value)
				{
					FsmColor fsmColor4 = fromValue;
					if (fromValue == null)
					{
						goto IL_0553;
					}
				}
				else
				{
					FsmColor fsmColor4 = toValue;
				}
				if (!reverse.IsNone && reverse.Value)
				{
					FsmColor fsmColor5 = fromValue;
					if (fromValue == null)
					{
						goto IL_0553;
					}
				}
				else
				{
					FsmColor fsmColor5 = toValue;
				}
				if (!reverse.IsNone && reverse.Value)
				{
					FsmColor fsmColor6 = fromValue;
					if (fromValue == null)
					{
						goto IL_0553;
					}
				}
				else
				{
					FsmColor fsmColor6 = toValue;
				}
				float num = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @101059C (inside UnityEngine.ClassLibraryInitializer::Init +0x8)");
				fsmColor2.value.r = 0f;
				fsmColor2.value.g = (float)obj2;
				fsmColor2.value.a = a;
			}
			finishInNextStep = true;
			return;
			IL_0553:
			throw new NullReferenceException();
		}

		[Token(Token = "0x6000652")]
		[Address(RVA = "0xB719F4", Offset = "0xB719F4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.EaseFsmAction::.ctor(this);\n\treturn;\n")]
		public EaseColor()
		{
		}
	}
}
