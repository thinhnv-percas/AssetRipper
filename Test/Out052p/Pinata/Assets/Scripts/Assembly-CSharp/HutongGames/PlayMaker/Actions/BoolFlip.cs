using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x759398", Offset = "0x759398")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x759398", Offset = "0x759398")]
	[Token(Token = "0x200027F")]
	public class BoolFlip : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B7EB4", Offset = "0x7B7EB4")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B7EB4", Offset = "0x7B7EB4")]
		[Token(Token = "0x40016AA")]
		[FieldOffset(Offset = "0x50")]
		public FsmBool boolVariable;

		[Token(Token = "0x6000C70")]
		[Address(RVA = "0xA8C2A4", Offset = "0xA8C2A4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.boolVariable = 0;\n\treturn;\n")]
		public override void Reset()
		{
			boolVariable = null;
		}

		[Token(Token = "0x6000C71")]
		[Address(RVA = "0xA8C2AC", Offset = "0xA8C2AC", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this.boolVariable;\n\tv16 = HutongGames.PlayMaker.FsmBool::get_Value(this.boolVariable);\n\tv34 = ~v16;\n\tv12.value = v34;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			FsmBool fsmBool = boolVariable;
			bool value = boolVariable.Value;
			bool value2 = !value;
			fsmBool.value = value2;
			Finish();
		}

		[Token(Token = "0x6000C72")]
		[Address(RVA = "0xA8C2F8", Offset = "0xA8C2F8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public BoolFlip()
		{
		}
	}
}
