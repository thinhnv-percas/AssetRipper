using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[NoActionTargets]
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x753E14", Offset = "0x753E14")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x753E14", Offset = "0x753E14")]
	[Token(Token = "0x200017F")]
	public class ArrayTransferValue : FsmStateAction
	{
		[Token(Token = "0x2000481")]
		public enum ArrayTransferType
		{
			[Token(Token = "0x400214E")]
			Copy = 0,
			[Token(Token = "0x400214F")]
			Cut = 1,
			[Token(Token = "0x4002150")]
			nullify = 2
		}

		[Token(Token = "0x2000482")]
		public enum ArrayPasteType
		{
			[Token(Token = "0x4002152")]
			AsFirstItem = 0,
			[Token(Token = "0x4002153")]
			AsLastItem = 1,
			[Token(Token = "0x4002154")]
			InsertAtSameIndex = 2,
			[Token(Token = "0x4002155")]
			ReplaceAtSameIndex = 3
		}

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AA330", Offset = "0x7AA330")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AA330", Offset = "0x7AA330")]
		[Token(Token = "0x4001279")]
		[FieldOffset(Offset = "0x50")]
		public FsmArray arraySource;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AA390", Offset = "0x7AA390")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AA390", Offset = "0x7AA390")]
		[Token(Token = "0x400127A")]
		[FieldOffset(Offset = "0x58")]
		public FsmArray arrayTarget;

		[AttributeAttribute(Type = typeof(MatchFieldTypeAttribute), RVA = "0x7AA3F0", Offset = "0x7AA3F0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AA3F0", Offset = "0x7AA3F0")]
		[Token(Token = "0x400127B")]
		[FieldOffset(Offset = "0x60")]
		public FsmInt indexToTransfer;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7AA450", Offset = "0x7AA450")]
		[AttributeAttribute(Type = typeof(ObjectTypeAttribute), RVA = "0x7AA450", Offset = "0x7AA450")]
		[Token(Token = "0x400127C")]
		[FieldOffset(Offset = "0x68")]
		public FsmEnum copyType;

		[AttributeAttribute(Type = typeof(ObjectTypeAttribute), RVA = "0x7AA4D8", Offset = "0x7AA4D8")]
		[Token(Token = "0x400127D")]
		[FieldOffset(Offset = "0x70")]
		public FsmEnum pasteType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7AA53C", Offset = "0x7AA53C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AA53C", Offset = "0x7AA53C")]
		[Token(Token = "0x400127E")]
		[FieldOffset(Offset = "0x78")]
		public FsmEvent indexOutOfRange;

		[Token(Token = "0x6000849")]
		[Address(RVA = "0xA8A258", Offset = "0xA8A258", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EE0610]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20221BB]) = v38;\nL_0013:\n\tthis.arrayTarget = 0;\n\tthis.indexToTransfer = 0;\n\tthis.arraySource = 0;\n\tv42 = 0;\n\t// 27 Box v44 @ X0_v3 (System.Enum), typeof(HutongGames.PlayMaker.Actions.ArrayTransferValue+ArrayTransferType), &v42 @ stack_-24_v1\n\tv46 = HutongGames.PlayMaker.FsmEnum::op_Implicit(v44);\n\tthis.copyType = v46;\n\tv52 = 1;\n\t// 37 Box v53 @ X0_v6 (System.Enum), typeof(HutongGames.PlayMaker.Actions.ArrayTransferValue+ArrayPasteType), &v52 @ X8_v7 (System.Int32)\n\tv55 = HutongGames.PlayMaker.FsmEnum::op_Implicit(v53);\n\tthis.pasteType = v55;\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_003b: Expected O, but got I4
			//IL_0044: Expected I4, but got O
			arrayTarget = null;
			indexToTransfer = null;
			arraySource = null;
			object obj = 0;
			Enum obj2 = (ArrayTransferType)obj;
			FsmEnum fsmEnum = obj2;
			copyType = fsmEnum;
			int num = 1;
			Enum obj3 = (ArrayPasteType)num;
			FsmEnum fsmEnum2 = obj3;
			pasteType = fsmEnum2;
		}

		[Token(Token = "0x600084A")]
		[Address(RVA = "0xA8A2F4", Offset = "0xA8A2F4", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ArrayTransferValue::DoTransferValue(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoTransferValue();
			Finish();
		}

		[Token(Token = "0x600084B")]
		[Address(RVA = "0xA8A31C", Offset = "0xA8A31C", Length = "0x4FC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv24 = *([1F108C0]);\n\tv25 = *([v24 @ X8_v61]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20221BC]) = v44;\nL_001A:\n\tv48 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.arraySource);\n\tv298 = v48 == 0;\n\tv299 = ~v298;\n\tif (v299) goto L_002F;\n\tv398 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.arrayTarget);\n\tv401 = v398 == 0;\n\tif (v401) goto L_0034;\nL_002F:\n\treturn;\nL_0034:\n\tv578 = HutongGames.PlayMaker.FsmInt::get_Value(this.indexToTransfer);\n\tv579 = v578 & 0x80000000;\n\tv580 = v579 == 0;\n\tv581 = ~v580;\n\tif (v581) goto L_0203;\n\tv583 = HutongGames.PlayMaker.FsmArray::get_Length(this.arraySource);\n\tv73 = v578 >= v583;\n\tif (v73) goto L_0203;\n\tv234 = HutongGames.PlayMaker.FsmArray::get_Values(this.arraySource);\n\tv587 = v578 < v234.Length;\n\tv185 = ~v587;\n\tif (v185) goto L_0209;\n\tv235 = HutongGames.PlayMaker.FsmEnum::get_Value(this.copyType);\n\tv416 = v416_asT == 0;\n\tif (v416) goto L_0208;\n\tv592 = \"il2cpp_vm_object_unbox\"(v235, HutongGames.PlayMaker.Actions.ArrayTransferValue+ArrayTransferType, v53, v50, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv74 = *([v592 @ X0_v27]) != 1;\n\tif (v74) goto L_00AF;\n\tv595 = HutongGames.PlayMaker.FsmArray::get_Values(this.arraySource);\n\tv352 = new System.Collections.Generic.List`1<System.Object>();\n\tSystem.Collections.Generic.List`1<System.Object>::.ctor(v352, v595);\n\tSystem.Collections.Generic.List`1<System.Object>::RemoveAt(v352, v578);\n\tv353 = System.Collections.Generic.List`1<System.Object>::ToArray(v352);\n\tHutongGames.PlayMaker.FsmArray::set_Values(this.arraySource, v353);\n\tgoto L_00DD;\nL_00AF:\n\tv238 = HutongGames.PlayMaker.FsmEnum::get_Value(this.copyType);\n\tv417 = v417_asT == 0;\n\tif (v417) goto L_0208;\n\tv603 = \"il2cpp_vm_object_unbox\"(v238, HutongGames.PlayMaker.Actions.ArrayTransferValue+ArrayTransferType, v53, v50, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv75 = *([v603 @ X0_v72]) != 2;\n\tif (v75) goto L_00DD;\n\tv240 = HutongGames.PlayMaker.FsmArray::get_Values(this.arraySource);\n\tSystem.Array::SetValue(v240, 0, v578);\nL_00DD:\n\tv242 = HutongGames.PlayMaker.FsmEnum::get_Value(this.pasteType);\n\tv77 = v77_asT == 0;\n\tif (v77) goto L_0208;\n\tv622 = \"il2cpp_vm_object_unbox\"(v242, HutongGames.PlayMaker.Actions.ArrayTransferValue+ArrayPasteType, v53, 0, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv623 = *([v622 @ X0_v31]) == 0;\n\tif (v623) goto L_013A;\n\tv244 = HutongGames.PlayMaker.FsmEnum::get_Value(this.pasteType);\n\tv418 = v418_asT == 0;\n\tif (v418) goto L_0208;\n\tv354 = \"il2cpp_vm_object_unbox\"(v244, HutongGames.PlayMaker.Actions.ArrayTransferValue+ArrayPasteType, v53, 0, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv78 = *([v354 @ X0_v43]) != 1;\n\tif (v78) goto L_0159;\n\tv646 = HutongGames.PlayMaker.FsmArray::get_Length(this.arrayTarget);\n\tv347 = v646 + 1;\n\tHutongGames.PlayMaker.FsmArray::Resize(this.arrayTarget, v347);\n\tv661 = HutongGames.PlayMaker.FsmArray::get_Length(this.arrayTarget);\n\tv545 = v661 - 1;\nL_0134:\n\tHutongGames.PlayMaker.FsmArray::Set(v549, v545, v234[v578 @ X0_v18 (System.Int32)]);\n\treturn;\nL_013A:\n\tv625 = HutongGames.PlayMaker.FsmArray::get_Values(this.arrayTarget);\n\tv651 = new System.Collections.Generic.List`1<System.Object>();\n\tSystem.Collections.Generic.List`1<System.Object>::.ctor(v651, v625);\n\tSystem.Collections.Generic.List`1<System.Object>::Insert(v651, 0, v234[v578 @ X0_v18 (System.Int32)]);\n\tv370 = this.arrayTarget;\n\tgoto L_01AE;\nL_0159:\n\tv247 = HutongGames.PlayMaker.FsmEnum::get_Value(this.pasteType);\n\tv419 = v419_asT == 0;\n\tif (v419) goto L_0208;\n\tv662 = \"il2cpp_vm_object_unbox\"(v247, HutongGames.PlayMaker.Actions.ArrayTransferValue+ArrayPasteType, v53, 0, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv79 = *([v662 @ X0_v47]) != 2;\n\tif (v79) goto L_01C2;\n\tv670 = HutongGames.PlayMaker.FsmArray::get_Length(this.arrayTarget);\n\tv80 = v578 < v670;\n\tif (v80) goto L_0193;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.indexOutOfRange);\nL_0193:\n\tv680 = HutongGames.PlayMaker.FsmArray::get_Values(this.arrayTarget);\n\tv651 = new System.Collections.Generic.List`1<System.Object>();\n\tSystem.Collections.Generic.List`1<System.Object>::.ctor(v651, v680);\n\tSystem.Collections.Generic.List`1<System.Object>::Insert(v651, v578, v234[v578 @ X0_v18 (System.Int32)]);\n\tv370 = this.arrayTarget;\nL_01AE:\n\tv358 = System.Collections.Generic.List`1::ToArray /* +30 sharing this address */(v651, *([v376 @ X8_v18 (Il2CppMethodInfo)]));\n\tHutongGames.PlayMaker.FsmArray::set_Values(v370, v358);\n\treturn;\nL_01C2:\n\tv252 = HutongGames.PlayMaker.FsmEnum::get_Value(this.pasteType);\n\tv420 = v420_asT == 0;\n\tif (v420) goto L_0208;\n\tv399 = \"il2cpp_vm_object_unbox\"(v252, HutongGames.PlayMaker.Actions.ArrayTransferValue+ArrayPasteType, v53, 0, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv81 = *([v399 @ X0_v50]) != 3;\n\tif (v81) goto L_002F;\n\tv584 = HutongGames.PlayMaker.FsmArray::get_Length(this.arrayTarget);\n\tv82 = v578 >= v584;\n\tif (v82) goto L_0203;\n\tv549 = this.arrayTarget;\n\tgoto L_0134;\nL_0203:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.indexOutOfRange);\n\treturn;\n\tthrow System.NullReferenceException;\n\tv379 = new System.NullReferenceException();\nL_0208:\n\tv484 = new System.InvalidCastException();\nL_0209:\n\tv576 = new System.IndexOutOfRangeException();\n\tthrow v576;\n\treturn;\n// 417 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoTransferValue()
		{
			//IL_008a: Expected I4, but got I8
			//IL_013e: Expected I4, but got O
			//IL_0209: Expected I4, but got O
			//IL_019d: Expected I4, but got O
			//IL_02a0: Expected I4, but got O
			//IL_03c1: Expected I4, but got O
			//IL_0305: Expected I4, but got O
			//IL_0421: Expected I4, but got O
			//IL_052e: Expected I4, but got O
			//IL_04c1: Expected I4, but got O
			if (arraySource.IsNone || arrayTarget.IsNone)
			{
				return;
			}
			int value = indexToTransfer.Value;
			object[] values;
			FsmArray fsmArray;
			int index;
			FsmArray fsmArray2;
			if ((int)(value & 0x80000000L) == 0)
			{
				int length = arraySource.Length;
				if (value < length)
				{
					values = arraySource.Values;
					if (value < values.Length)
					{
						Enum value2 = copyType.Value;
						if ((int)((value2 is ArrayTransferType) ? value2 : null) != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
							object obj = default(object);
							if ((IntPtr)obj == (IntPtr)1)
							{
								object[] values2 = arraySource.Values;
								object obj2 = new List<object>((int)values2);
								((List<object>)obj2).RemoveAt(value);
								object[] values3 = ((List<object>)obj2).ToArray();
								arraySource.Values = values3;
								int num = 0;
							}
							else
							{
								Enum value3 = copyType.Value;
								if ((int)((value3 is ArrayTransferType) ? value3 : null) == 0)
								{
									goto IL_05d1;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
								object obj3 = default(object);
								if ((IntPtr)obj3 == (IntPtr)2)
								{
									object[] values4 = arraySource.Values;
									values4.SetValue(null, value);
									int num = value;
								}
							}
							Enum value4 = pasteType.Value;
							if ((int)((value4 is ArrayPasteType) ? value4 : null) != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
								object obj4 = default(object);
								if (obj4 == null)
								{
									object[] values5 = arrayTarget.Values;
									object obj5 = new List<object>((int)values5);
									((List<object>)obj5).Insert(0, values[value]);
									fsmArray = arrayTarget;
									IntPtr intPtr = (IntPtr)0;
									goto IL_05ed;
								}
								Enum value5 = pasteType.Value;
								if ((int)((value5 is ArrayPasteType) ? value5 : null) != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
									object obj6 = default(object);
									if ((IntPtr)obj6 == (IntPtr)1)
									{
										int length2 = arrayTarget.Length;
										int newLength = length2 + 1;
										arrayTarget.Resize(newLength);
										int length3 = arrayTarget.Length;
										index = length3 - 1;
										fsmArray2 = arrayTarget;
										goto IL_05fc;
									}
									Enum value6 = pasteType.Value;
									if ((int)((value6 is ArrayPasteType) ? value6 : null) != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
										object obj7 = default(object);
										if ((IntPtr)obj7 == (IntPtr)2)
										{
											int length4 = arrayTarget.Length;
											if (value >= length4)
											{
												Fsm.Event(indexOutOfRange);
											}
											object[] values6 = arrayTarget.Values;
											object obj5 = new List<object>((int)values6);
											((List<object>)obj5).Insert(value, values[value]);
											fsmArray = arrayTarget;
											IntPtr intPtr = (IntPtr)0;
											goto IL_05ed;
										}
										Enum value7 = pasteType.Value;
										if ((int)((value7 is ArrayPasteType) ? value7 : null) != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
											object obj8 = default(object);
											if ((IntPtr)obj8 != (IntPtr)3)
											{
												return;
											}
											int length5 = arrayTarget.Length;
											if (value >= length5)
											{
												goto IL_05bf;
											}
											fsmArray2 = arrayTarget;
											index = value;
											goto IL_05fc;
										}
									}
								}
							}
						}
						goto IL_05d1;
					}
					goto IL_05df;
				}
			}
			goto IL_05bf;
			IL_05bf:
			Fsm.Event(indexOutOfRange);
			return;
			IL_05fc:
			fsmArray2.Set(index, values[value]);
			return;
			IL_05df:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
			IL_05ed:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @14532CC (System.Collections.Generic.List`1::ToArray, and 30 more at this address)");
			object[] values7 = default(object[]);
			fsmArray.Values = values7;
			return;
			IL_05d1:
			InvalidCastException ex2 = new InvalidCastException();
			goto IL_05df;
		}

		[Token(Token = "0x600084C")]
		[Address(RVA = "0xA8A818", Offset = "0xA8A818", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ArrayTransferValue()
		{
		}
	}
}
