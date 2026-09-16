using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionTarget), RVA = "0x7540A4", Offset = "0x7540A4")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7540A4", Offset = "0x7540A4")]
	[Token(Token = "0x2000183")]
	public class SetFsmArray : BaseFsmVariableAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AAA54", Offset = "0x7AAA54")]
		[Token(Token = "0x4001291")]
		[FieldOffset(Offset = "0x78")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AAAA0", Offset = "0x7AAAA0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AAAA0", Offset = "0x7AAAA0")]
		[Token(Token = "0x4001292")]
		[FieldOffset(Offset = "0x80")]
		public FsmString fsmName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AAAF0", Offset = "0x7AAAF0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AAAF0", Offset = "0x7AAAF0")]
		[Token(Token = "0x4001293")]
		[FieldOffset(Offset = "0x88")]
		public FsmString variableName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AAB50", Offset = "0x7AAB50")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AAB50", Offset = "0x7AAB50")]
		[Token(Token = "0x4001294")]
		[FieldOffset(Offset = "0x90")]
		public FsmArray setValue;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AABB0", Offset = "0x7AABB0")]
		[Token(Token = "0x4001295")]
		[FieldOffset(Offset = "0x98")]
		public bool copyValues;

		[Token(Token = "0x600085B")]
		[Address(RVA = "0x990A38", Offset = "0x990A38", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EAE478]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021721]) = v38;\nL_0013:\n\tthis.gameObject = 0;\n\tv43 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.variableName = 0;\n\tthis.setValue = 0;\n\tthis.fsmName = v43;\n\tthis.copyValues = 1;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmString fsmString = "";
			variableName = null;
			setValue = null;
			fsmName = fsmString;
			copyValues = true;
		}

		[Token(Token = "0x600085C")]
		[Address(RVA = "0x990AA0", Offset = "0x990AA0", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetFsmArray::DoSetFsmArrayCopy(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoSetFsmArrayCopy();
			Finish();
		}

		[Token(Token = "0x600085D")]
		[Address(RVA = "0x990AC8", Offset = "0x990AC8", Length = "0x328")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EBB230]);\n\tv23 = *([v22 @ X8_v42]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021722]) = v42;\nL_001A:\n\tv47 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv126 = this.fsmName;\n\tv227 = HutongGames.PlayMaker.FsmString::get_Value(this.fsmName);\n\tv246 = HutongGames.PlayMaker.Actions.BaseFsmVariableAction::UpdateCache(this, v47, v227);\n\tv290 = v246 == 0;\n\tif (v290) goto L_010D;\n\tv231 = PlayMakerFSM::get_FsmVariables(this.fsm);\n\tv126 = this.variableName;\n\tv232 = HutongGames.PlayMaker.FsmString::get_Value(this.variableName);\n\tv398 = HutongGames.PlayMaker.FsmVariables::GetFsmArray(v231, v232);\n\tv368 = v398 == 0;\n\tif (v368) goto L_006C;\n\tv241 = this.setValue;\n\tv56 = v398.type != v241.type;\n\tif (v56) goto L_007D;\n\tHutongGames.PlayMaker.FsmArray::Resize(v398, 0);\n\tv234 = HutongGames.PlayMaker.FsmArray::get_Values(this.setValue);\n\tv378 = ~this.copyValues;\n\tif (v378) goto L_FFFFFFFF;\n\tv395 = System.Array::Clone(v234);\n\t// 100 IsInst v421 @ X0_v61 (System.Object[]), typeof(System.Object[]), v395 @ X0_v60 (System.Object)\n\tgoto L_0111;\nL_006C:\n\tv371 = HutongGames.PlayMaker.FsmString::get_Value(this.variableName);\n\tHutongGames.PlayMaker.Actions.BaseFsmVariableAction::DoVariableNotFound(this, v371);\n\treturn;\nL_007D:\n\t// 125 NewArr v115 @ X0_v28 (System.Object[]), typeof(System.Object[]), 5\n\tv377 = \"Can only copy arrays with the same elements type. Found <\" == 0;\n\tif (v377) goto L_008B;\n\t// 136 IsInst v381 @ X0_v52, typeof(System.Object), \"Can only copy arrays with the same elements type. Found <\"\nL_008B:\n\tv126 = v115.Length;\n\tv211 = v115.Length == 0;\n\tif (v211) goto L_0120;\n\tv115[0] = \"Can only copy arrays with the same elements type. Found <\";\n\tv390 = v398.type;\n\t// 150 Box v392 @ X0_v34, typeof(HutongGames.PlayMaker.VariableType), &v390 @ X8_v18 (HutongGames.PlayMaker.VariableType)\n\tv418 = v392 == 0;\n\tif (v418) goto L_00A0;\n\t// 157 IsInst v406 @ X0_v51, typeof(System.Object), v392 @ X0_v34\nL_00A0:\n\tv126 = v115.Length;\n\tv424 = v115.Length < 1;\n\tv186 = ~v424;\n\tv181 = v115.Length - 1;\n\tv171 = v181 == 0;\n\tv425 = ~v186;\n\tv146 = v425 | v171;\n\tif (v146) goto L_0120;\n\tv115[1] = v392;\n\tv428 = \"> and <\" == 0;\n\tif (v428) goto L_00B9;\n\t// 181 IsInst v407 @ X0_v49, typeof(System.Object), \"> and <\"\n\tv126 = v115.Length;\nL_00B9:\n\tv430 = v126 < 2;\n\tv188 = ~v430;\n\tv183 = v126 - 2;\n\tv173 = v183 == 0;\n\tv431 = ~v188;\n\tv148 = v431 | v173;\n\tif (v148) goto L_0120;\n\tv115[2] = \"> and <\";\n\tv243 = this.setValue;\n\tv433 = v243.type;\n\t// 206 Box v436 @ X0_v39, typeof(HutongGames.PlayMaker.VariableType), &v433 @ X8_v24 (HutongGames.PlayMaker.VariableType)\n\tv437 = v436 == 0;\n\tif (v437) goto L_00D8;\n\t// 213 IsInst v408 @ X0_v48, typeof(System.Object), v436 @ X0_v39\nL_00D8:\n\tv126 = v115.Length;\n\tv440 = v115.Length < 3;\n\tv187 = ~v440;\n\tv182 = v115.Length - 3;\n\tv172 = v182 == 0;\n\tv441 = ~v187;\n\tv147 = v441 | v172;\n\tif (v147) goto L_0120;\n\tv115[3] = v436;\n\tv444 = \">\" == 0;\n\tif (v444) goto L_00F1;\n\t// 237 IsInst v409 @ X0_v46, typeof(System.Object), \">\"\n\tv126 = v115.Length;\nL_00F1:\n\tv446 = v126 < 4;\n\tv189 = ~v446;\n\tv184 = v126 - 4;\n\tv174 = v184 == 0;\n\tv447 = ~v189;\n\tv149 = v447 | v174;\n\tif (v149) goto L_0120;\n\tv115[4] = \">\";\n\tv450 = System.String::Concat(v115);\n\tHutongGames.PlayMaker.FsmStateAction::LogError(this, v450);\nL_010D:\n\treturn;\nL_0111:\n\tHutongGames.PlayMaker.FsmArray::set_Values(v398, v396);\n\tHutongGames.PlayMaker.FsmArray::SaveChanges(v398);\n\treturn;\n\tv111 = new System.NullReferenceException();\n\tv135 = new System.NullReferenceException();\nL_0120:\n\tv224 = new System.IndexOutOfRangeException();\n\tgoto L_0125;\n\tv279 = new System.ArrayTypeMismatchException();\nL_0125:\n\tthrow v278;\n// 191 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetFsmArrayCopy()
		{
			//IL_01da: Expected O, but got I4
			//IL_025f: Expected O, but got I4
			//IL_028b: Expected O, but got I4
			//IL_04ca: Expected O, but got I
			//IL_030d: Expected O, but got I4
			//IL_0387: Expected O, but got I4
			//IL_03b3: Expected O, but got I4
			//IL_0528: Expected O, but got I
			//IL_0435: Expected O, but got I4
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			FsmString fsmString = fsmName;
			string value = fsmName.Value;
			if (!UpdateCache(ownerDefaultTarget, value))
			{
				return;
			}
			FsmVariables fsmVariables = fsm.FsmVariables;
			fsmString = variableName;
			string value2 = variableName.Value;
			FsmArray fsmArray = fsmVariables.GetFsmArray(value2);
			if (fsmArray != null)
			{
				FsmArray fsmArray2 = setValue;
				if (fsmArray.TypeConstraint != fsmArray2.TypeConstraint)
				{
					object[] array = new object[5];
					if ("Can only copy arrays with the same elements type. Found <" != null)
					{
						object obj = "Can only copy arrays with the same elements type. Found <" as object;
					}
					fsmString = (FsmString)array.Length;
					if (array.Length != 0)
					{
						array[0] = "Can only copy arrays with the same elements type. Found <";
						VariableType typeConstraint = fsmArray.TypeConstraint;
						object obj2 = typeConstraint;
						if (obj2 != null)
						{
							object obj3 = obj2 as object;
						}
						fsmString = (FsmString)array.Length;
						bool flag = array.Length < 1;
						bool flag2 = !flag;
						object obj4 = array.Length - 1;
						bool flag3 = obj4 == null;
						bool flag4 = !flag2;
						if (!(flag4 || flag3))
						{
							array[1] = obj2;
							if ("> and <" != null)
							{
								object obj5 = "> and <" as object;
								fsmString = (FsmString)array.Length;
							}
							bool flag5 = (long)(IntPtr)fsmString < 2L;
							bool flag6 = !flag5;
							object obj6 = (long)(IntPtr)fsmString - 2L;
							bool flag7 = obj6 == null;
							bool flag8 = !flag6;
							if (!(flag8 || flag7))
							{
								array[2] = "> and <";
								FsmArray fsmArray3 = setValue;
								VariableType typeConstraint2 = fsmArray3.TypeConstraint;
								object obj7 = typeConstraint2;
								if (obj7 != null)
								{
									object obj8 = obj7 as object;
								}
								fsmString = (FsmString)array.Length;
								bool flag9 = array.Length < 3;
								bool flag10 = !flag9;
								object obj9 = array.Length - 3;
								bool flag11 = obj9 == null;
								bool flag12 = !flag10;
								if (!(flag12 || flag11))
								{
									array[3] = obj7;
									if (">" != null)
									{
										object obj10 = ">" as object;
										fsmString = (FsmString)array.Length;
									}
									bool flag13 = (long)(IntPtr)fsmString < 4L;
									bool flag14 = !flag13;
									object obj11 = (long)(IntPtr)fsmString - 4L;
									bool flag15 = obj11 == null;
									bool flag16 = !flag14;
									if (!(flag16 || flag15))
									{
										array[4] = ">";
										string text = string.Concat(array);
										LogError(text);
										return;
									}
								}
							}
						}
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
					throw ex2;
				}
				fsmArray.Resize(0);
				object[] values = setValue.Values;
				object[] values2;
				if (copyValues)
				{
					object obj12 = values.Clone();
					object[] array2 = obj12 as object[];
					values2 = array2;
				}
				else
				{
					values2 = values;
				}
				fsmArray.Values = values2;
				fsmArray.SaveChanges();
			}
			else
			{
				string value3 = variableName.Value;
				DoVariableNotFound(value3);
			}
		}

		[Token(Token = "0x600085E")]
		[Address(RVA = "0x990DF0", Offset = "0x990DF0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.BaseFsmVariableAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetFsmArray()
		{
		}
	}
}
