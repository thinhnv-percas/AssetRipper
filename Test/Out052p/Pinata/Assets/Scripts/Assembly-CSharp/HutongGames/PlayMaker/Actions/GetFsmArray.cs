using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionTarget), RVA = "0x753F54", Offset = "0x753F54")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x753F54", Offset = "0x753F54")]
	[Token(Token = "0x2000181")]
	public class GetFsmArray : BaseFsmVariableAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AA6F4", Offset = "0x7AA6F4")]
		[Token(Token = "0x4001286")]
		[FieldOffset(Offset = "0x78")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AA740", Offset = "0x7AA740")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AA740", Offset = "0x7AA740")]
		[Token(Token = "0x4001287")]
		[FieldOffset(Offset = "0x80")]
		public FsmString fsmName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AA790", Offset = "0x7AA790")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AA790", Offset = "0x7AA790")]
		[Token(Token = "0x4001288")]
		[FieldOffset(Offset = "0x88")]
		public FsmString variableName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AA7F0", Offset = "0x7AA7F0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AA7F0", Offset = "0x7AA7F0")]
		[Token(Token = "0x4001289")]
		[FieldOffset(Offset = "0x90")]
		public FsmArray storeValue;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AA850", Offset = "0x7AA850")]
		[Token(Token = "0x400128A")]
		[FieldOffset(Offset = "0x98")]
		public bool copyValues;

		[Token(Token = "0x6000852")]
		[Address(RVA = "0xA2B99C", Offset = "0xA2B99C", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EEA260]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021DB8]) = v38;\nL_0013:\n\tthis.gameObject = 0;\n\tv43 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.variableName = 0;\n\tthis.storeValue = 0;\n\tthis.fsmName = v43;\n\tthis.copyValues = 1;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmString fsmString = "";
			variableName = null;
			storeValue = null;
			fsmName = fsmString;
			copyValues = true;
		}

		[Token(Token = "0x6000853")]
		[Address(RVA = "0xA2BA04", Offset = "0xA2BA04", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetFsmArray::DoSetFsmArrayCopy(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoSetFsmArrayCopy();
			Finish();
		}

		[Token(Token = "0x6000854")]
		[Address(RVA = "0xA2BA2C", Offset = "0xA2BA2C", Length = "0x330")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EFB3D8]);\n\tv23 = *([v22 @ X8_v41]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021DB9]) = v42;\nL_001A:\n\tv47 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv127 = this.fsmName;\n\tv228 = HutongGames.PlayMaker.FsmString::get_Value(this.fsmName);\n\tv248 = HutongGames.PlayMaker.Actions.BaseFsmVariableAction::UpdateCache(this, v47, v228);\n\tv291 = v248 == 0;\n\tif (v291) goto L_010D;\n\tv234 = PlayMakerFSM::get_FsmVariables(this.fsm);\n\tv127 = this.variableName;\n\tv235 = HutongGames.PlayMaker.FsmString::get_Value(this.variableName);\n\tv365 = HutongGames.PlayMaker.FsmVariables::GetFsmArray(v234, v235);\n\tv366 = v365 == 0;\n\tif (v366) goto L_006C;\n\tv114 = this.storeValue;\n\tv57 = v365.type != v114.type;\n\tif (v57) goto L_007D;\n\tHutongGames.PlayMaker.FsmArray::Resize(v114, 0);\n\tv236 = HutongGames.PlayMaker.FsmArray::get_Values(v365);\n\tv375 = ~this.copyValues;\n\tif (v375) goto L_FFFFFFFF;\n\tv237 = System.Array::Clone(v236);\n\t// 100 IsInst v419 @ X0_v61 (System.Object[]), typeof(System.Object[]), v237 @ X0_v60 (System.Object)\n\tgoto L_0113;\nL_006C:\n\tv370 = HutongGames.PlayMaker.FsmString::get_Value(this.variableName);\n\tHutongGames.PlayMaker.Actions.BaseFsmVariableAction::DoVariableNotFound(this, v370);\n\treturn;\nL_007D:\n\t// 125 NewArr v116 @ X0_v29 (System.Object[]), typeof(System.Object[]), 5\n\tv378 = \"Can only copy arrays with the same elements type. Found <\" == 0;\n\tif (v378) goto L_008B;\n\t// 136 IsInst v381 @ X0_v53, typeof(System.Object), \"Can only copy arrays with the same elements type. Found <\"\nL_008B:\n\tv127 = v116.Length;\n\tv213 = v116.Length == 0;\n\tif (v213) goto L_0124;\n\tv116[0] = \"Can only copy arrays with the same elements type. Found <\";\n\tv391 = v365.type;\n\t// 150 Box v393 @ X0_v35, typeof(HutongGames.PlayMaker.VariableType), &v391 @ X8_v17 (HutongGames.PlayMaker.VariableType)\n\tv416 = v393 == 0;\n\tif (v416) goto L_00A0;\n\t// 157 IsInst v404 @ X0_v52, typeof(System.Object), v393 @ X0_v35\nL_00A0:\n\tv127 = v116.Length;\n\tv422 = v116.Length < 1;\n\tv188 = ~v422;\n\tv183 = v116.Length - 1;\n\tv173 = v183 == 0;\n\tv423 = ~v188;\n\tv148 = v423 | v173;\n\tif (v148) goto L_0124;\n\tv116[1] = v393;\n\tv426 = \"> and <\" == 0;\n\tif (v426) goto L_00B9;\n\t// 181 IsInst v405 @ X0_v50, typeof(System.Object), \"> and <\"\n\tv127 = v116.Length;\nL_00B9:\n\tv428 = v127 < 2;\n\tv190 = ~v428;\n\tv185 = v127 - 2;\n\tv175 = v185 == 0;\n\tv429 = ~v190;\n\tv150 = v429 | v175;\n\tif (v150) goto L_0124;\n\tv116[2] = \"> and <\";\n\tv245 = this.storeValue;\n\tv431 = v245.type;\n\t// 206 Box v434 @ X0_v40, typeof(HutongGames.PlayMaker.VariableType), &v431 @ X8_v23 (HutongGames.PlayMaker.VariableType)\n\tv435 = v434 == 0;\n\tif (v435) goto L_00D8;\n\t// 213 IsInst v406 @ X0_v49, typeof(System.Object), v434 @ X0_v40\nL_00D8:\n\tv127 = v116.Length;\n\tv438 = v116.Length < 3;\n\tv189 = ~v438;\n\tv184 = v116.Length - 3;\n\tv174 = v184 == 0;\n\tv439 = ~v189;\n\tv149 = v439 | v174;\n\tif (v149) goto L_0124;\n\tv116[3] = v434;\n\tv442 = \">\" == 0;\n\tif (v442) goto L_00F1;\n\t// 237 IsInst v407 @ X0_v47, typeof(System.Object), \">\"\n\tv127 = v116.Length;\nL_00F1:\n\tv444 = v127 < 4;\n\tv191 = ~v444;\n\tv186 = v127 - 4;\n\tv176 = v186 == 0;\n\tv445 = ~v191;\n\tv151 = v445 | v176;\n\tif (v151) goto L_0124;\n\tv116[4] = \">\";\n\tv448 = System.String::Concat(v116);\n\tHutongGames.PlayMaker.FsmStateAction::LogError(this, v448);\nL_010D:\n\treturn;\nL_0113:\n\tHutongGames.PlayMaker.FsmArray::set_Values(v395, v110);\n\tHutongGames.PlayMaker.FsmArray::SaveChanges(this.storeValue);\n\treturn;\n\tv112 = new System.NullReferenceException();\n\tv137 = new System.NullReferenceException();\nL_0124:\n\tv225 = new System.IndexOutOfRangeException();\n\tgoto L_0129;\n\tv281 = new System.ArrayTypeMismatchException();\nL_0129:\n\tthrow v280;\n// 195 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetFsmArrayCopy()
		{
			//IL_01e2: Expected O, but got I4
			//IL_0267: Expected O, but got I4
			//IL_0293: Expected O, but got I4
			//IL_04e3: Expected O, but got I
			//IL_0315: Expected O, but got I4
			//IL_038f: Expected O, but got I4
			//IL_03bb: Expected O, but got I4
			//IL_0541: Expected O, but got I
			//IL_043d: Expected O, but got I4
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
				FsmArray fsmArray2 = storeValue;
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
								FsmArray fsmArray3 = storeValue;
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
				fsmArray2.Resize(0);
				object[] values = fsmArray.Values;
				object[] values2;
				FsmArray fsmArray4;
				if (copyValues)
				{
					object obj12 = values.Clone();
					object[] array2 = obj12 as object[];
					values2 = array2;
					fsmArray4 = storeValue;
				}
				else
				{
					values2 = values;
					fsmArray4 = storeValue;
				}
				fsmArray4.Values = values2;
				storeValue.SaveChanges();
			}
			else
			{
				string value3 = variableName.Value;
				DoVariableNotFound(value3);
			}
		}

		[Token(Token = "0x6000855")]
		[Address(RVA = "0xA2BD5C", Offset = "0xA2BD5C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.BaseFsmVariableAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetFsmArray()
		{
		}
	}
}
