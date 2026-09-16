using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x753C84", Offset = "0x753C84")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x753C84", Offset = "0x753C84")]
	[Token(Token = "0x200017A")]
	public class ArrayResize : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7A9F30", Offset = "0x7A9F30")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A9F30", Offset = "0x7A9F30")]
		[Token(Token = "0x400126C")]
		[FieldOffset(Offset = "0x50")]
		public FsmArray array;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A9F90", Offset = "0x7A9F90")]
		[Token(Token = "0x400126D")]
		[FieldOffset(Offset = "0x58")]
		public FsmInt newSize;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A9FC8", Offset = "0x7A9FC8")]
		[Token(Token = "0x400126E")]
		[FieldOffset(Offset = "0x60")]
		public FsmEvent sizeOutOfRangeEvent;

		[Token(Token = "0x6000839")]
		[Address(RVA = "0xA89B14", Offset = "0xA89B14", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1ED71F8]);\n\tv19 = *([v18 @ X8_v14]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20221B6]) = v38;\nL_0017:\n\tv42 = HutongGames.PlayMaker.FsmInt::get_Value(this.newSize);\n\tv61 = v42 & 0x80000000;\n\tv62 = v61 == 0;\n\tv63 = ~v62;\n\tif (v63) goto L_002D;\n\tv69 = HutongGames.PlayMaker.FsmInt::get_Value(this.newSize);\n\tHutongGames.PlayMaker.FsmArray::Resize(this.array, v69);\n\tgoto L_0048;\nL_002D:\n\tv79 = HutongGames.PlayMaker.FsmInt::get_Value(this.newSize);\n\t// 52 Box v105 @ X0_v14 (System.Object), typeof(System.Int32), &v79 @ X0_v12 (System.Int32)\n\tv113 = System.String::Concat(\"Size out of range: \", v105);\n\tHutongGames.PlayMaker.FsmStateAction::LogError(this, v113);\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.sizeOutOfRangeEvent);\nL_0048:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			//IL_0026: Expected I4, but got I8
			int value = newSize.Value;
			if ((int)(value & 0x80000000L) == 0)
			{
				int value2 = newSize.Value;
				array.Resize(value2);
			}
			else
			{
				int value3 = newSize.Value;
				object obj = value3;
				string text = "Size out of range: " + obj;
				LogError(text);
				Fsm.Event(sizeOutOfRangeEvent);
			}
			Finish();
		}

		[Token(Token = "0x600083A")]
		[Address(RVA = "0xA89C20", Offset = "0xA89C20", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ArrayResize()
		{
		}
	}
}
