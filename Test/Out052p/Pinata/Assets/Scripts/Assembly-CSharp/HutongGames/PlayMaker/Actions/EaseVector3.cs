using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x751FC4", Offset = "0x751FC4")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x751FC4", Offset = "0x751FC4")]
	[Token(Token = "0x200011C")]
	public class EaseVector3 : EaseFsmAction
	{
		[RequiredField]
		[Token(Token = "0x40010A9")]
		[FieldOffset(Offset = "0xC8")]
		public FsmVector3 fromValue;

		[RequiredField]
		[Token(Token = "0x40010AA")]
		[FieldOffset(Offset = "0xD0")]
		public FsmVector3 toValue;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A1FC0", Offset = "0x7A1FC0")]
		[Token(Token = "0x40010AB")]
		[FieldOffset(Offset = "0xD8")]
		public FsmVector3 vector3Variable;

		[Token(Token = "0x40010AC")]
		[FieldOffset(Offset = "0xE0")]
		private bool finishInNextStep;

		[Token(Token = "0x6000682")]
		[Address(RVA = "0xB73758", Offset = "0xB73758", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.EaseFsmAction::Reset(this);\n\tthis.finishInNextStep = 0;\n\tthis.toValue = 0;\n\tthis.vector3Variable = 0;\n\tthis.fromValue = 0;\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			base.Reset();
			finishInNextStep = false;
			toValue = null;
			vector3Variable = null;
			fromValue = null;
		}

		[Token(Token = "0x6000683")]
		[Address(RVA = "0xB73784", Offset = "0xB73784", Length = "0x1BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1F0F3C0]);\n\tv21 = *([v20 @ X8_v17]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022913]) = v40;\nL_0015:\n\tHutongGames.PlayMaker.Actions.EaseFsmAction::OnEnter(this);\n\t// 26 NewArr v46 @ X0_v4 (System.Single[]), typeof(System.Single[]), 3\n\tthis.fromFloats = v46;\n\tv52 = HutongGames.PlayMaker.FsmVector3::get_Value(this.fromValue);\n\tv187 = v46.Length == 0;\n\tif (v187) goto L_00BA;\n\tv46[0] = v52;\n\tv165 = this.fromFloats;\n\tv124 = HutongGames.PlayMaker.FsmVector3::get_Value(this.fromValue);\n\tv251 = v165.Length < 1;\n\tv103 = ~v251;\n\tv97 = v165.Length - 1;\n\tv85 = v97 == 0;\n\tv252 = ~v103;\n\tv55 = v252 | v85;\n\tif (v55) goto L_00BA;\n\tv165[1] = v124.y;\n\tv166 = this.fromFloats;\n\tv125 = HutongGames.PlayMaker.FsmVector3::get_Value(this.fromValue);\n\tv253 = v166.Length < 2;\n\tv104 = ~v253;\n\tv98 = v166.Length - 2;\n\tv86 = v98 == 0;\n\tv254 = ~v104;\n\tv56 = v254 | v86;\n\tif (v56) goto L_00BA;\n\tv166[2] = v125.z;\n\t// 93 NewArr v141 @ X0_v17 (System.Single[]), typeof(System.Single[]), 3\n\tthis.toFloats = v141;\n\tv126 = HutongGames.PlayMaker.FsmVector3::get_Value(this.toValue);\n\tv188 = v141.Length == 0;\n\tif (v188) goto L_00BA;\n\tv141[0] = v126;\n\tv168 = this.toFloats;\n\tv127 = HutongGames.PlayMaker.FsmVector3::get_Value(this.toValue);\n\tv256 = v168.Length < 1;\n\tv105 = ~v256;\n\tv99 = v168.Length - 1;\n\tv87 = v99 == 0;\n\tv257 = ~v105;\n\tv57 = v257 | v87;\n\tif (v57) goto L_00BA;\n\tv168[1] = v127.y;\n\tv169 = this.toFloats;\n\tv128 = HutongGames.PlayMaker.FsmVector3::get_Value(this.toValue);\n\tv258 = v169.Length < 2;\n\tv106 = ~v258;\n\tv100 = v169.Length - 2;\n\tv88 = v100 == 0;\n\tv259 = ~v106;\n\tv58 = v259 | v88;\n\tif (v58) goto L_00BA;\n\tv169[2] = v128.z;\n\t// 160 NewArr v261 @ X0_v22 (System.Single[]), typeof(System.Single[]), 3\n\tthis.resultFloats = v261;\n\tthis.finishInNextStep = 0;\n\tv156 = this.vector3Variable;\n\tv129 = HutongGames.PlayMaker.FsmVector3::get_Value(this.fromValue);\n\tv156.value = v129;\n\tv156.value.y = v129.y;\n\tv156.value.z = v129.z;\n\treturn;\n\tv171 = new System.NullReferenceException();\nL_00BA:\n\tv194 = new System.IndexOutOfRangeException();\n\tthrow v194;\n\tthrow System.NullReferenceException;\n// 120 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			//IL_009e: Expected O, but got I4
			//IL_0139: Expected O, but got I4
			//IL_023b: Expected O, but got I4
			//IL_02d6: Expected O, but got I4
			base.OnEnter();
			float[] array = (fromFloats = new float[3]);
			Vector3 value = fromValue.Value;
			if (array.Length != 0)
			{
				array[0] = value.x;
				float[] array2 = fromFloats;
				Vector3 value2 = fromValue.Value;
				bool flag = array2.Length < 1;
				bool flag2 = !flag;
				object obj = array2.Length - 1;
				bool flag3 = obj == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array2[1] = value2.y;
					float[] array3 = fromFloats;
					Vector3 value3 = fromValue.Value;
					bool flag5 = array3.Length < 2;
					bool flag6 = !flag5;
					object obj2 = array3.Length - 2;
					bool flag7 = obj2 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array3[2] = value3.z;
						float[] array4 = (toFloats = new float[3]);
						Vector3 value4 = toValue.Value;
						if (array4.Length != 0)
						{
							array4[0] = value4.x;
							float[] array5 = toFloats;
							Vector3 value5 = toValue.Value;
							bool flag9 = array5.Length < 1;
							bool flag10 = !flag9;
							object obj3 = array5.Length - 1;
							bool flag11 = obj3 == null;
							bool flag12 = !flag10;
							if (!(flag12 || flag11))
							{
								array5[1] = value5.y;
								float[] array6 = toFloats;
								Vector3 value6 = toValue.Value;
								bool flag13 = array6.Length < 2;
								bool flag14 = !flag13;
								object obj4 = array6.Length - 2;
								bool flag15 = obj4 == null;
								bool flag16 = !flag14;
								if (!(flag16 || flag15))
								{
									array6[2] = value6.z;
									float[] array7 = new float[3];
									resultFloats = array7;
									finishInNextStep = false;
									FsmVector3 fsmVector = vector3Variable;
									Vector3 vector = (fsmVector.value = fromValue.Value);
									fsmVector.value.y = vector.y;
									fsmVector.value.z = vector.z;
									return;
								}
							}
						}
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000684")]
		[Address(RVA = "0xB73940", Offset = "0xB73940", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void OnExit()
		{
		}

		[Token(Token = "0x6000685")]
		[Address(RVA = "0xB73944", Offset = "0xB73944", Length = "0x218")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.EaseFsmAction::OnUpdate(this);\n\tv20 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.vector3Variable);\n\tv163 = v20 == 0;\n\tv164 = ~v163;\n\tif (v164) goto L_0042;\n\tv172 = ~this.isRunning;\n\tif (v172) goto L_0042;\n\tv223 = this.resultFloats;\n\tv243 = v223.Length == 0;\n\tif (v243) goto L_00D0;\n\tv340 = v223.Length == 1;\n\tif (v340) goto L_00D0;\n\tv374 = v223.Length < 2;\n\tv187 = ~v374;\n\tv186 = v223.Length - 2;\n\tv184 = v186 == 0;\n\tv375 = ~v187;\n\tv179 = v375 | v184;\n\tif (v179) goto L_00D0;\n\tv41 = this.vector3Variable;\n\tv173 = 0;\n\tv196 = 0x1586898(&v173 @ stack_-40_v9 (UnityEngine.Vector3), 0, v30, v152, v153, v154, v155, v156, v223[0], v223[1], v223[2], v157, v158, v159, v160, v161);\n\tv41.value = 0;\n\tv41.value.z = 0f;\nL_0042:\n\tv197 = ~this.finishInNextStep;\n\tif (v197) goto L_0050;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\tv229 = this.finishEvent == 0;\n\tif (v229) goto L_0050;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.finishEvent);\nL_0050:\n\tv232 = ~this.finishAction;\n\tif (v232) goto L_00CF;\n\tv282 = ~this.finishInNextStep;\n\tv283 = ~v282;\n\tif (v283) goto L_00CF;\n\tv376 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.vector3Variable);\n\tv381 = v376 == 0;\n\tv378 = ~v381;\n\tif (v378) goto L_00C7;\n\tv203 = this.vector3Variable;\n\tv382 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.reverse);\n\tv384 = v382 == 0;\n\tv385 = ~v384;\n\tif (v385) goto L_0076;\n\tv389 = HutongGames.PlayMaker.FsmBool::get_Value(this.reverse);\n\tv387 = v389 == 0;\n\tif (v387) goto L_0076;\n\tv392 = this.fromValue;\n\tv394 = this.fromValue == 0;\n\tv127 = ~v394;\n\tif (v127) goto L_007A;\n\tgoto L_00B1;\nL_0076:\n\tv392 = this.toValue;\nL_007A:\n\tv59 = HutongGames.PlayMaker.FsmVector3::get_Value(v392);\n\tv395 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.reverse);\n\tv397 = v395 == 0;\n\tv398 = ~v397;\n\tif (v398) goto L_0094;\n\tv402 = HutongGames.PlayMaker.FsmBool::get_Value(this.reverse);\n\tv400 = v402 == 0;\n\tif (v400) goto L_0094;\n\tv405 = this.fromValue;\n\tv407 = this.fromValue == 0;\n\tv131 = ~v407;\n\tif (v131) goto L_0098;\n\tgoto L_00B1;\nL_0094:\n\tv405 = this.toValue;\nL_0098:\n\tv56 = HutongGames.PlayMaker.FsmVector3::get_Value(v405);\n\tv169 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.reverse);\n\tv409 = v169 == 0;\n\tv166 = ~v409;\n\tif (v166) goto L_00B2;\n\tv170 = HutongGames.PlayMaker.FsmBool::get_Value(this.reverse);\n\tv167 = v170 == 0;\n\tif (v167) goto L_00B2;\n\tv220 = this.fromValue;\n\tv411 = this.fromValue == 0;\n\tv122 = ~v411;\n\tif (v122) goto L_00B6;\nL_00B1:\n\tthrow System.NullReferenceException;\nL_00B2:\n\tv220 = this.toValue;\nL_00B6:\n\tv222 = HutongGames.PlayMaker.FsmVector3::get_Value(v220);\n\tv173 = 0;\n\tv241 = 0x1586898(&v173 @ stack_-40_v9 (UnityEngine.Vector3), 0, v200, v152, v153, v154, v155, v156, v199, v198, v222.z, v157, v158, v159, v160, v161);\n\tv203.value = 0;\n\tv203.value.z = 0f;\nL_00C7:\n\tthis.finishInNextStep = 1;\nL_00CF:\n\treturn;\nL_00D0:\n\tv345 = new System.IndexOutOfRangeException();\n\tthrow v345;\n\tthrow System.NullReferenceException;\n// 124 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			//IL_01b4: Expected O, but got I4
			//IL_00e6: Expected O, but got I4
			base.OnUpdate();
			bool isNone = vector3Variable.IsNone;
			bool flag = !isNone;
			bool flag2 = !flag;
			FsmVector3 fsmVector2 = default(FsmVector3);
			FsmVector3 fsmVector = fsmVector2;
			Vector3 vector;
			if (!flag2)
			{
				bool flag3 = !isRunning;
				fsmVector = fsmVector2;
				if (!flag3)
				{
					float[] array = resultFloats;
					if (array.Length != 0 && array.Length != 1)
					{
						bool flag4 = array.Length < 2;
						bool flag5 = !flag4;
						object obj = array.Length - 2;
						bool flag6 = obj == null;
						bool flag7 = !flag5;
						if (!(flag7 || flag6))
						{
							fsmVector = vector3Variable;
							vector = default(Vector3);
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
							fsmVector.value = default(Vector3);
							fsmVector.value.z = 0f;
							goto IL_0543;
						}
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
			}
			goto IL_0543;
			IL_0543:
			bool flag8 = !finishInNextStep;
			object obj3 = default(object);
			object obj2 = obj3;
			if (!flag8)
			{
				Finish();
				bool flag9 = finishEvent == null;
				obj2 = obj3;
				if (!flag9)
				{
					Fsm.Event(finishEvent);
					obj2 = 0;
				}
			}
			if (!finishAction || finishInNextStep)
			{
				return;
			}
			FsmVector3 fsmVector3;
			FsmVector3 fsmVector6;
			if (!vector3Variable.IsNone)
			{
				fsmVector3 = vector3Variable;
				FsmVector3 fsmVector4;
				if (!reverse.IsNone && reverse.Value)
				{
					fsmVector4 = fromValue;
					if (fromValue == null)
					{
						goto IL_04ab;
					}
				}
				else
				{
					fsmVector4 = toValue;
				}
				Vector3 value = fsmVector4.Value;
				FsmVector3 fsmVector5;
				if (!reverse.IsNone && reverse.Value)
				{
					fsmVector5 = fromValue;
					if (fromValue == null)
					{
						goto IL_04ab;
					}
				}
				else
				{
					fsmVector5 = toValue;
				}
				Vector3 value2 = fsmVector5.Value;
				bool isNone2 = reverse.IsNone;
				bool flag10 = !isNone2;
				bool flag11 = !flag10;
				float y = value2.y;
				Vector3 vector2 = value;
				obj3 = obj2;
				fsmVector2 = fsmVector3;
				float y2;
				Vector3 vector3;
				if (!flag11)
				{
					bool value3 = reverse.Value;
					bool flag12 = !value3;
					y = value2.y;
					vector2 = value;
					obj3 = obj2;
					fsmVector2 = fsmVector3;
					if (!flag12)
					{
						fsmVector6 = fromValue;
						bool flag13 = fromValue == null;
						bool flag14 = !flag13;
						y2 = value2.y;
						vector3 = value;
						if (!flag14)
						{
							goto IL_04ab;
						}
						goto IL_04e0;
					}
				}
				fsmVector6 = toValue;
				y2 = y;
				vector3 = vector2;
				obj2 = obj3;
				fsmVector3 = fsmVector2;
				goto IL_04e0;
			}
			goto IL_0567;
			IL_0567:
			finishInNextStep = true;
			return;
			IL_04e0:
			Vector3 value4 = fsmVector6.Value;
			vector = default(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			fsmVector3.value = default(Vector3);
			fsmVector3.value.z = 0f;
			goto IL_0567;
			IL_04ab:
			throw new NullReferenceException();
		}

		[Token(Token = "0x6000686")]
		[Address(RVA = "0xB73B5C", Offset = "0xB73B5C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.EaseFsmAction::.ctor(this);\n\treturn;\n")]
		public EaseVector3()
		{
		}
	}
}
