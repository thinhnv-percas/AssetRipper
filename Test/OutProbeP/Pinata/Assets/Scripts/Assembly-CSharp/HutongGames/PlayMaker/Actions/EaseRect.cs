using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x751F64", Offset = "0x751F64")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x751F64", Offset = "0x751F64")]
	[Token(Token = "0x200011B")]
	public class EaseRect : EaseFsmAction
	{
		[RequiredField]
		[Token(Token = "0x40010A5")]
		[FieldOffset(Offset = "0xC8")]
		public FsmRect fromValue;

		[RequiredField]
		[Token(Token = "0x40010A6")]
		[FieldOffset(Offset = "0xD0")]
		public FsmRect toValue;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A1F8C", Offset = "0x7A1F8C")]
		[Token(Token = "0x40010A7")]
		[FieldOffset(Offset = "0xD8")]
		public FsmRect rectVariable;

		[Token(Token = "0x40010A8")]
		[FieldOffset(Offset = "0xE0")]
		private bool finishInNextStep;

		[Token(Token = "0x600067D")]
		[Address(RVA = "0xB731FC", Offset = "0xB731FC", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.EaseFsmAction::Reset(this);\n\tthis.finishInNextStep = 0;\n\tthis.toValue = 0;\n\tthis.rectVariable = 0;\n\tthis.fromValue = 0;\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			base.Reset();
			finishInNextStep = false;
			toValue = null;
			rectVariable = null;
			fromValue = null;
		}

		[Token(Token = "0x600067E")]
		[Address(RVA = "0xB73228", Offset = "0xB73228", Length = "0x270")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1EAA1F8]);\n\tv21 = *([v20 @ X8_v25]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022912]) = v40;\nL_0017:\n\tHutongGames.PlayMaker.Actions.EaseFsmAction::OnEnter(this);\n\t// 28 NewArr v48 @ X0_v4 (System.Single[]), typeof(System.Single[]), 4\n\tv49 = this.fromValue;\n\tthis.fromFloats = v48;\n\tv52 = v49.value;\n\tv56 = 0x10CCFB4(&v52 @ V0_v3 (UnityEngine.Rect), 0, v24, v25, v26, v27, v28, v29, v49.value, v31, v32, v33, v34, v35, v36, v37);\n\tv220 = v48.Length == 0;\n\tif (v220) goto L_00F0;\n\tv48[0] = v49.value;\n\tv187 = this.fromValue;\n\tv52 = v187.value;\n\tv196 = this.fromFloats;\n\tv159 = 0x10CCFC4(&v52 @ V0_v3 (UnityEngine.Rect), 0, v24, v25, v26, v27, v28, v29, v187.value, v31, v32, v33, v34, v35, v36, v37);\n\tv271 = v196.Length < 1;\n\tv126 = ~v271;\n\tv118 = v196.Length - 1;\n\tv102 = v118 == 0;\n\tv272 = ~v126;\n\tv62 = v272 | v102;\n\tif (v62) goto L_00F0;\n\tv196[1] = v187.value;\n\tv188 = this.fromValue;\n\tv52 = v188.value;\n\tv197 = this.fromFloats;\n\tv160 = 0x10CD178(&v52 @ V0_v3 (UnityEngine.Rect), 0, v24, v25, v26, v27, v28, v29, v188.value, v31, v32, v33, v34, v35, v36, v37);\n\tv274 = v197.Length < 2;\n\tv127 = ~v274;\n\tv119 = v197.Length - 2;\n\tv103 = v119 == 0;\n\tv275 = ~v127;\n\tv63 = v275 | v103;\n\tif (v63) goto L_00F0;\n\tv197[2] = v188.value;\n\tv189 = this.fromValue;\n\tv52 = v189.value;\n\tv198 = this.fromFloats;\n\tv161 = 0x10CD188(&v52 @ V0_v3 (UnityEngine.Rect), 0, v24, v25, v26, v27, v28, v29, v189.value, v31, v32, v33, v34, v35, v36, v37);\n\tv277 = v198.Length < 3;\n\tv128 = ~v277;\n\tv120 = v198.Length - 3;\n\tv104 = v120 == 0;\n\tv278 = ~v128;\n\tv64 = v278 | v104;\n\tif (v64) goto L_00F0;\n\tv198[3] = v189.value;\n\t// 122 NewArr v162 @ X0_v20 (System.Single[]), typeof(System.Single[]), 4\n\tv190 = this.toValue;\n\tthis.toFloats = v162;\n\tv52 = v190.value;\n\tv163 = 0x10CCFB4(&v52 @ V0_v3 (UnityEngine.Rect), 0, v24, v25, v26, v27, v28, v29, v190.value, v31, v32, v33, v34, v35, v36, v37);\n\tv221 = v162.Length == 0;\n\tif (v221) goto L_00F0;\n\tv162[0] = v190.value;\n\tv191 = this.toValue;\n\tv52 = v191.value;\n\tv200 = this.toFloats;\n\tv164 = 0x10CCFC4(&v52 @ V0_v3 (UnityEngine.Rect), 0, v24, v25, v26, v27, v28, v29, v191.value, v31, v32, v33, v34, v35, v36, v37);\n\tv282 = v200.Length < 1;\n\tv129 = ~v282;\n\tv121 = v200.Length - 1;\n\tv105 = v121 == 0;\n\tv283 = ~v129;\n\tv65 = v283 | v105;\n\tif (v65) goto L_00F0;\n\tv200[1] = v191.value;\n\tv192 = this.toValue;\n\tv52 = v192.value;\n\tv201 = this.toFloats;\n\tv165 = 0x10CD178(&v52 @ V0_v3 (UnityEngine.Rect), 0, v24, v25, v26, v27, v28, v29, v192.value, v31, v32, v33, v34, v35, v36, v37);\n\tv285 = v201.Length < 2;\n\tv130 = ~v285;\n\tv122 = v201.Length - 2;\n\tv106 = v122 == 0;\n\tv286 = ~v130;\n\tv66 = v286 | v106;\n\tif (v66) goto L_00F0;\n\tv201[2] = v192.value;\n\tv193 = this.toValue;\n\tv52 = v193.value;\n\tv202 = this.toFloats;\n\tv166 = 0x10CD188(&v52 @ V0_v3 (UnityEngine.Rect), 0, v24, v25, v26, v27, v28, v29, v193.value, v31, v32, v33, v34, v35, v36, v37);\n\tv288 = v202.Length < 3;\n\tv131 = ~v288;\n\tv123 = v202.Length - 3;\n\tv107 = v123 == 0;\n\tv289 = ~v131;\n\tv67 = v289 | v107;\n\tif (v67) goto L_00F0;\n\tv202[3] = v193.value;\n\t// 216 NewArr v167 @ X0_v30 (System.Single[]), typeof(System.Single[]), 4\n\tv194 = this.fromValue;\n\tthis.resultFloats = v167;\n\tthis.finishInNextStep = 0;\n\tv59 = this.rectVariable;\n\tv59.value.m_XMin = v194.value;\n\tv59.value.m_YMin = v194.value.m_YMin;\n\tv59.value.m_Height = v194.value.m_Height;\n\treturn;\n\tv204 = new System.NullReferenceException();\nL_00F0:\n\tv232 = new System.IndexOutOfRangeException();\n\tthrow v232;\n\treturn;\n// 137 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			//IL_00c7: Expected O, but got I4
			//IL_017e: Expected O, but got I4
			//IL_0235: Expected O, but got I4
			//IL_036f: Expected O, but got I4
			//IL_0426: Expected O, but got I4
			//IL_04dd: Expected O, but got I4
			base.OnEnter();
			float[] array = new float[4];
			FsmRect fsmRect = fromValue;
			fromFloats = array;
			Rect value = fsmRect.value;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCFB4 (inside UnityEngine.Rect::MinMaxRect +0x18)");
			if (array.Length != 0)
			{
				array[0] = fsmRect.value.x;
				FsmRect fsmRect2 = fromValue;
				value = fsmRect2.value;
				float[] array2 = fromFloats;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCFC4 (inside UnityEngine.Rect::MinMaxRect +0x28)");
				bool flag = array2.Length < 1;
				bool flag2 = !flag;
				object obj = array2.Length - 1;
				bool flag3 = obj == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array2[1] = fsmRect2.value.x;
					FsmRect fsmRect3 = fromValue;
					value = fsmRect3.value;
					float[] array3 = fromFloats;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD178 (inside UnityEngine.Rect::MinMaxRect +0x1DC)");
					bool flag5 = array3.Length < 2;
					bool flag6 = !flag5;
					object obj2 = array3.Length - 2;
					bool flag7 = obj2 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array3[2] = fsmRect3.value.x;
						FsmRect fsmRect4 = fromValue;
						value = fsmRect4.value;
						float[] array4 = fromFloats;
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD188 (inside UnityEngine.Rect::MinMaxRect +0x1EC)");
						bool flag9 = array4.Length < 3;
						bool flag10 = !flag9;
						object obj3 = array4.Length - 3;
						bool flag11 = obj3 == null;
						bool flag12 = !flag10;
						if (!(flag12 || flag11))
						{
							array4[3] = fsmRect4.value.x;
							float[] array5 = new float[4];
							FsmRect fsmRect5 = toValue;
							toFloats = array5;
							value = fsmRect5.value;
							Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCFB4 (inside UnityEngine.Rect::MinMaxRect +0x18)");
							if (array5.Length != 0)
							{
								array5[0] = fsmRect5.value.x;
								FsmRect fsmRect6 = toValue;
								value = fsmRect6.value;
								float[] array6 = toFloats;
								Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCFC4 (inside UnityEngine.Rect::MinMaxRect +0x28)");
								bool flag13 = array6.Length < 1;
								bool flag14 = !flag13;
								object obj4 = array6.Length - 1;
								bool flag15 = obj4 == null;
								bool flag16 = !flag14;
								if (!(flag16 || flag15))
								{
									array6[1] = fsmRect6.value.x;
									FsmRect fsmRect7 = toValue;
									value = fsmRect7.value;
									float[] array7 = toFloats;
									Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD178 (inside UnityEngine.Rect::MinMaxRect +0x1DC)");
									bool flag17 = array7.Length < 2;
									bool flag18 = !flag17;
									object obj5 = array7.Length - 2;
									bool flag19 = obj5 == null;
									bool flag20 = !flag18;
									if (!(flag20 || flag19))
									{
										array7[2] = fsmRect7.value.x;
										FsmRect fsmRect8 = toValue;
										value = fsmRect8.value;
										float[] array8 = toFloats;
										Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD188 (inside UnityEngine.Rect::MinMaxRect +0x1EC)");
										bool flag21 = array8.Length < 3;
										bool flag22 = !flag21;
										object obj6 = array8.Length - 3;
										bool flag23 = obj6 == null;
										bool flag24 = !flag22;
										if (!(flag24 || flag23))
										{
											array8[3] = fsmRect8.value.x;
											float[] array9 = new float[4];
											FsmRect fsmRect9 = fromValue;
											resultFloats = array9;
											finishInNextStep = false;
											FsmRect fsmRect10 = rectVariable;
											fsmRect10.value.x = fsmRect9.value.x;
											fsmRect10.value.y = fsmRect9.value.y;
											fsmRect10.value.height = fsmRect9.value.height;
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

		[Token(Token = "0x600067F")]
		[Address(RVA = "0xB73498", Offset = "0xB73498", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void OnExit()
		{
		}

		[Token(Token = "0x6000680")]
		[Address(RVA = "0xB7349C", Offset = "0xB7349C", Length = "0x2B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.EaseFsmAction::OnUpdate(this);\n\tv24 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.rectVariable);\n\tv146 = v24 == 0;\n\tv147 = ~v146;\n\tif (v147) goto L_0052;\n\tv205 = ~this.isRunning;\n\tif (v205) goto L_0052;\n\tv197 = this.resultFloats;\n\tv200 = v197.Length == 0;\n\tif (v200) goto L_0108;\n\tv179 = v197.Length == 1;\n\tif (v179) goto L_0108;\n\tv382 = v197.Length < 2;\n\tv192 = ~v382;\n\tv188 = v197.Length - 2;\n\tv180 = v188 == 0;\n\tv383 = ~v192;\n\tv161 = v383 | v180;\n\tif (v161) goto L_0108;\n\tv181 = v197.Length == 3;\n\tif (v181) goto L_0108;\n\tv209 = this.rectVariable;\n\tv208 = 0;\n\tv222 = 0x10CCF64(&v208 @ stack_-60_v8 (System.Single), 0, v33, v136, v137, v138, v139, v140, v197[0], v197[1], v197[2], v197[3], v141, v142, v143, v144);\n\tv209.value.m_XMin = 0f;\n\tv209.value.m_YMin = v395;\n\tv209.value.m_Height = v396;\nL_0052:\n\tv223 = ~this.finishInNextStep;\n\tif (v223) goto L_0060;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\tv232 = this.finishEvent == 0;\n\tif (v232) goto L_0060;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.finishEvent);\nL_0060:\n\tv235 = ~this.finishAction;\n\tif (v235) goto L_0106;\n\tv308 = ~this.finishInNextStep;\n\tv309 = ~v308;\n\tif (v309) goto L_0106;\n\tv384 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.rectVariable);\n\tv387 = v384 == 0;\n\tv388 = ~v387;\n\tif (v388) goto L_00FD;\n\tv45 = this.rectVariable;\n\tv394 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.reverse);\n\tv398 = v394 == 0;\n\tv399 = ~v398;\n\tif (v399) goto L_0086;\n\tv295 = HutongGames.PlayMaker.FsmBool::get_Value(this.reverse);\n\tv401 = v295 == 0;\n\tif (v401) goto L_0086;\n\tv95 = this.fromValue;\n\tv408 = this.fromValue == 0;\n\tv285 = ~v408;\n\tif (v285) goto L_0089;\n\tgoto L_010D;\nL_0086:\n\tv95 = this.toValue;\nL_0089:\n\tv58 = v95.value;\n\tv406 = 0x10CCFB4(&v58 @ V0_v7 (UnityEngine.Rect), 0, 0, v136, v137, v138, v139, v140, v95.value, v197[1], v197[2], v197[3], v141, v142, v143, v144);\n\tv409 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.reverse);\n\tv411 = v409 == 0;\n\tv412 = ~v411;\n\tif (v412) goto L_00A5;\n\tv297 = HutongGames.PlayMaker.FsmBool::get_Value(this.reverse);\n\tv414 = v297 == 0;\n\tif (v414) goto L_00A5;\n\tv96 = this.fromValue;\n\tv421 = this.fromValue == 0;\n\tv287 = ~v421;\n\tif (v287) goto L_00A8;\n\tgoto L_010D;\nL_00A5:\n\tv96 = this.toValue;\nL_00A8:\n\tv59 = v96.value;\n\tv419 = 0x10CCFC4(&v59 @ V0_v8 (UnityEngine.Rect), 0, 0, v136, v137, v138, v139, v140, v96.value, v197[1], v197[2], v197[3], v141, v142, v143, v144);\n\tv422 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.reverse);\n\tv424 = v422 == 0;\n\tv425 = ~v424;\n\tif (v425) goto L_00C4;\n\tv299 = HutongGames.PlayMaker.FsmBool::get_Value(this.reverse);\n\tv427 = v299 == 0;\n\tif (v427) goto L_00C4;\n\tv97 = this.fromValue;\n\tv434 = this.fromValue == 0;\n\tv289 = ~v434;\n\tif (v289) goto L_00C7;\n\tgoto L_010D;\nL_00C4:\n\tv97 = this.toValue;\nL_00C7:\n\tv60 = v97.value;\n\tv432 = 0x10CD178(&v60 @ V0_v9 (UnityEngine.Rect), 0, 0, v136, v137, v138, v139, v140, v97.value, v197[1], v197[2], v197[3], v141, v142, v143, v144);\n\tv435 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.reverse);\n\tv437 = v435 == 0;\n\tv438 = ~v437;\n\tif (v438) goto L_00E3;\n\tv301 = HutongGames.PlayMaker.FsmBool::get_Value(this.reverse);\n\tv440 = v301 == 0;\n\tif (v440) goto L_00E3;\n\tv273 = this.fromValue;\n\tv450 = this.fromValue == 0;\n\tv291 = ~v450;\n\tif (v291) goto L_00E6;\n\tgoto L_010D;\nL_00E3:\n\tv273 = this.toValue;\nL_00E6:\n\tv444 = v273.value;\n\tv447 = 0x10CD188(&v444 @ V0_v10 (UnityEngine.Rect), 0, 0, v136, v137, v138, v139, v140, v273.value, v197[1], v197[2], v197[3], v141, v142, v143, v144);\n\tv208 = 0;\n\tv303 = 0x10CCF64(&v208 @ stack_-60_v8 (System.Single), 0, 0, v136, v137, v138, v139, v140, v95.value, v96.value, v97.value, v273.value, v141, v142, v143, v144);\n\tv45.value.m_XMin = 0f;\n\tv45.value.m_YMin = v395;\n\tv45.value.m_Height = v396;\nL_00FD:\n\tthis.finishInNextStep = 1;\nL_0106:\n\treturn;\n\tv135 = new System.NullReferenceException();\nL_0108:\n\tv203 = new System.IndexOutOfRangeException();\n\tthrow v203;\nL_010D:\n\tthrow System.NullReferenceException;\n// 157 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			//IL_00d6: Expected O, but got I4
			//IL_0176: Expected F4, but got O
			//IL_05b7: Expected F4, but got O
			base.OnUpdate();
			object obj2 = default(object);
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
						FsmRect fsmRect = rectVariable;
						float num = 0f;
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCF64 (inside UnityEngine.RangeAttribute::.ctor +0x290)");
						fsmRect.value.x = 0f;
						fsmRect.value.y = (float)obj2;
						fsmRect.value.height = height;
						goto IL_05e2;
					}
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			goto IL_05e2;
			IL_05e2:
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
			if (!rectVariable.IsNone)
			{
				FsmRect fsmRect2 = rectVariable;
				FsmRect fsmRect3;
				if (!reverse.IsNone && reverse.Value)
				{
					fsmRect3 = fromValue;
					if (fromValue == null)
					{
						goto IL_05dc;
					}
				}
				else
				{
					fsmRect3 = toValue;
				}
				Rect value = fsmRect3.value;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCFB4 (inside UnityEngine.Rect::MinMaxRect +0x18)");
				FsmRect fsmRect4;
				if (!reverse.IsNone && reverse.Value)
				{
					fsmRect4 = fromValue;
					if (fromValue == null)
					{
						goto IL_05dc;
					}
				}
				else
				{
					fsmRect4 = toValue;
				}
				Rect value2 = fsmRect4.value;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCFC4 (inside UnityEngine.Rect::MinMaxRect +0x28)");
				FsmRect fsmRect5;
				if (!reverse.IsNone && reverse.Value)
				{
					fsmRect5 = fromValue;
					if (fromValue == null)
					{
						goto IL_05dc;
					}
				}
				else
				{
					fsmRect5 = toValue;
				}
				Rect value3 = fsmRect5.value;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD178 (inside UnityEngine.Rect::MinMaxRect +0x1DC)");
				FsmRect fsmRect6;
				if (!reverse.IsNone && reverse.Value)
				{
					fsmRect6 = fromValue;
					if (fromValue == null)
					{
						goto IL_05dc;
					}
				}
				else
				{
					fsmRect6 = toValue;
				}
				Rect value4 = fsmRect6.value;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD188 (inside UnityEngine.Rect::MinMaxRect +0x1EC)");
				float num = 0f;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCF64 (inside UnityEngine.RangeAttribute::.ctor +0x290)");
				fsmRect2.value.x = 0f;
				fsmRect2.value.y = (float)obj2;
				fsmRect2.value.height = height;
			}
			finishInNextStep = true;
			return;
			IL_05dc:
			throw new NullReferenceException();
		}

		[Token(Token = "0x6000681")]
		[Address(RVA = "0xB73754", Offset = "0xB73754", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.EaseFsmAction::.ctor(this);\n\treturn;\n")]
		public EaseRect()
		{
		}
	}
}
