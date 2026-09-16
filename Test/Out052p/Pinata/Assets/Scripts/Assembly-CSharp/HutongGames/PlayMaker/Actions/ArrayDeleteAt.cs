using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x753AA4", Offset = "0x753AA4")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x753AA4", Offset = "0x753AA4")]
	[Token(Token = "0x2000174")]
	public class ArrayDeleteAt : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7A969C", Offset = "0x7A969C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A969C", Offset = "0x7A969C")]
		[Token(Token = "0x400124C")]
		[FieldOffset(Offset = "0x50")]
		public FsmArray array;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A96FC", Offset = "0x7A96FC")]
		[Token(Token = "0x400124D")]
		[FieldOffset(Offset = "0x58")]
		public FsmInt index;

		[Attribute(Type = typeof(ActionSection), RVA = "0x7A9734", Offset = "0x7A9734")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A9734", Offset = "0x7A9734")]
		[Token(Token = "0x400124E")]
		[FieldOffset(Offset = "0x60")]
		public FsmEvent indexOutOfRangeEvent;

		[Token(Token = "0x6000818")]
		[Address(RVA = "0xA88F9C", Offset = "0xA88F9C", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.index = 0;\n\tthis.indexOutOfRangeEvent = 0;\n\tthis.array = 0;\n\treturn;\n")]
		public override void Reset()
		{
			index = null;
			indexOutOfRangeEvent = null;
			array = null;
		}

		[Token(Token = "0x6000819")]
		[Address(RVA = "0xA88FA8", Offset = "0xA88FA8", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ArrayDeleteAt::DoDeleteAt(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoDeleteAt();
			Finish();
		}

		[Token(Token = "0x600081A")]
		[Address(RVA = "0xA88FD0", Offset = "0xA88FD0", Length = "0x14C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1F0B0B0]);\n\tv21 = *([v20 @ X8_v18]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20221B2]) = v40;\nL_0018:\n\tv44 = HutongGames.PlayMaker.FsmInt::get_Value(this.index);\n\tv108 = v44 & 0x80000000;\n\tv109 = v108 == 0;\n\tv110 = ~v109;\n\tif (v110) goto L_0070;\n\tv128 = HutongGames.PlayMaker.FsmInt::get_Value(this.index);\n\tv143 = HutongGames.PlayMaker.FsmArray::get_Length(this.array);\n\tv51 = v128 >= v143;\n\tif (v51) goto L_0070;\n\tv181 = HutongGames.PlayMaker.FsmArray::get_Values(this.array);\n\tv186 = new System.Collections.Generic.List`1<System.Object>();\n\tSystem.Collections.Generic.List`1<System.Object>::.ctor(v186, v181);\n\tv129 = HutongGames.PlayMaker.FsmInt::get_Value(this.index);\n\tSystem.Collections.Generic.List`1<System.Object>::RemoveAt(v186, v129);\n\tv130 = System.Collections.Generic.List`1<System.Object>::ToArray(v186);\n\tHutongGames.PlayMaker.FsmArray::set_Values(this.array, v130);\n\treturn;\nL_0070:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.indexOutOfRangeEvent);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 90 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoDeleteAt()
		{
			//IL_0026: Expected I4, but got I8
			//IL_00a8: Expected I4, but got O
			int value = index.Value;
			if ((int)(value & 0x80000000L) == 0)
			{
				int value2 = index.Value;
				int length = array.Length;
				if (value2 < length)
				{
					object[] values = array.Values;
					object obj = new List<object>((int)values);
					int value3 = index.Value;
					((List<object>)obj).RemoveAt(value3);
					object[] values2 = ((List<object>)obj).ToArray();
					array.Values = values2;
					return;
				}
			}
			Fsm.Event(indexOutOfRangeEvent);
		}

		[Token(Token = "0x600081B")]
		[Address(RVA = "0xA8911C", Offset = "0xA8911C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ArrayDeleteAt()
		{
		}
	}
}
