using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x753A04", Offset = "0x753A04")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x753A04", Offset = "0x753A04")]
	[Token(Token = "0x2000172")]
	public class ArrayCompare : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A92E0", Offset = "0x7A92E0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A92E0", Offset = "0x7A92E0")]
		[Token(Token = "0x4001240")]
		[FieldOffset(Offset = "0x50")]
		public FsmArray array1;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A9340", Offset = "0x7A9340")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A9340", Offset = "0x7A9340")]
		[Token(Token = "0x4001241")]
		[FieldOffset(Offset = "0x58")]
		public FsmArray array2;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A93A0", Offset = "0x7A93A0")]
		[Token(Token = "0x4001242")]
		[FieldOffset(Offset = "0x60")]
		public FsmEvent SequenceEqual;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A93D8", Offset = "0x7A93D8")]
		[Token(Token = "0x4001243")]
		[FieldOffset(Offset = "0x68")]
		public FsmEvent SequenceNotEqual;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A9410", Offset = "0x7A9410")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A9410", Offset = "0x7A9410")]
		[Token(Token = "0x4001244")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool storeResult;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A9460", Offset = "0x7A9460")]
		[Token(Token = "0x4001245")]
		[FieldOffset(Offset = "0x78")]
		public bool everyFrame;

		[Token(Token = "0x600080F")]
		[Address(RVA = "0xA88AD0", Offset = "0xA88AD0", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.array1 = 0;\n\tthis.SequenceEqual = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			array1 = null;
			SequenceEqual = null;
		}

		[Token(Token = "0x6000810")]
		[Address(RVA = "0xA88ADC", Offset = "0xA88ADC", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ArrayCompare::DoSequenceEqual(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoSequenceEqual();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000811")]
		[Address(RVA = "0xA88B18", Offset = "0xA88B18", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = HutongGames.PlayMaker.FsmArray::get_Values(this.array1);\n\tv54 = v17 == 0;\n\tif (v54) goto L_0052;\n\tv78 = HutongGames.PlayMaker.FsmArray::get_Values(this.array2);\n\tv76 = v78 == 0;\n\tif (v76) goto L_0052;\n\tv27 = this.storeResult;\n\tv69 = HutongGames.PlayMaker.FsmArray::get_Values(this.array1);\n\tv127 = HutongGames.PlayMaker.FsmArray::get_Values(this.array2);\n\tv70 = HutongGames.PlayMaker.Actions.ArrayCompare::TestSequenceEqual(this, v69, v127);\n\tv27.value = v70;\n\tv71 = HutongGames.PlayMaker.FsmBool::get_Value(this.storeResult);\n\tv112 = this + 0x60;\n\tv105 = this + 0x68;\n\tv99 = v71 == 0;\n\tv90 = ~v99;\n\tv87 = ~v90;\n\tif (v87) goto L_FFFFFFFF;\n\tgoto L_004A;\nL_004A:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, *([v112 @ X8_v6]));\n\treturn;\nL_0052:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSequenceEqual()
		{
			//IL_00ce: Expected O, but got I
			//IL_00da: Expected O, but got I
			object[] values = array1.Values;
			if (values == null)
			{
				return;
			}
			object[] values2 = array2.Values;
			if (values2 != null)
			{
				FsmBool fsmBool = storeResult;
				object[] values3 = array1.Values;
				object[] values4 = array2.Values;
				bool value = TestSequenceEqual(values3, values4);
				fsmBool.value = value;
				bool value2 = storeResult.Value;
				object fsmEvent = (long)(IntPtr)this + 96L;
				object obj = (long)(IntPtr)this + 104L;
				if (!value2)
				{
					fsmEvent = obj;
				}
				Fsm.Event((FsmEvent)fsmEvent);
			}
		}

		[Token(Token = "0x6000812")]
		[Address(RVA = "0xA88BFC", Offset = "0xA88BFC", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv37 = _array1.Length != _array2.Length;\n\tif (v37) goto L_FFFFFFFF;\n\tv195 = this.array1;\nL_0021:\n\tv205 = HutongGames.PlayMaker.FsmArray::get_Length(v195);\n\tv35 = v101 >= v205;\n\tif (v35) goto L_FFFFFFFF;\n\tv208 = v101 < _array1.Length;\n\tv209 = ~v208;\n\tif (v209) goto L_0065;\n\tv218 = v101 < _array2.Length;\n\tv67 = ~v218;\n\tif (v67) goto L_0065;\n\tv103 = System.Object::Equals(_array1[v101 @ X22_v6 (System.Int32)], _array2[v101 @ X22_v6 (System.Int32)]);\n\tv116 = v103 == 0;\n\tif (v116) goto L_FFFFFFFF;\n\tv195 = this.array1;\n\tv101 = v101 + 1;\n\tv240 = this.array1 == 0;\n\tv79 = ~v240;\n\tif (v79) goto L_0021;\n\tthrow System.NullReferenceException;\n\tgoto L_0064;\nL_0064:\n\treturn returnVal1;\nL_0065:\n\tv228 = new System.IndexOutOfRangeException();\n\tthrow v228;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 80 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private bool TestSequenceEqual(object[] _array1, object[] _array2)
		{
			if (_array1.Length == _array2.Length)
			{
				FsmArray fsmArray = array1;
				int num = 0;
				while (true)
				{
					int length = fsmArray.Length;
					if (num < length)
					{
						if (num < _array1.Length && num < _array2.Length)
						{
							if (!_array1[num].Equals(_array2[num]))
							{
								break;
							}
							fsmArray = array1;
							num++;
							if (array1 == null)
							{
								throw new NullReferenceException();
							}
							continue;
						}
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
						throw ex;
					}
					return true;
				}
			}
			return false;
		}

		[Token(Token = "0x6000813")]
		[Address(RVA = "0xA88CD0", Offset = "0xA88CD0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ArrayCompare()
		{
		}
	}
}
