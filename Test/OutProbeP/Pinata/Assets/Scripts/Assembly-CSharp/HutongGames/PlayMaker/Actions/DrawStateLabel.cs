using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7555A0", Offset = "0x7555A0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7555A0", Offset = "0x7555A0")]
	[Token(Token = "0x20001C3")]
	public class DrawStateLabel : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AE910", Offset = "0x7AE910")]
		[Token(Token = "0x4001393")]
		[FieldOffset(Offset = "0x50")]
		public FsmBool showLabel;

		[Token(Token = "0x6000971")]
		[Address(RVA = "0xB70CC0", Offset = "0xB70CC0", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = HutongGames.PlayMaker.FsmBool::op_Implicit(1);\n\tthis.showLabel = v12;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmBool fsmBool = true;
			showLabel = fsmBool;
		}

		[Token(Token = "0x6000972")]
		[Address(RVA = "0xB70CEC", Offset = "0xB70CEC", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this.fsm;\n\tv16 = HutongGames.PlayMaker.FsmBool::get_Value(this.showLabel);\n\tv14.showStateLabel = v16;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			Fsm fsm = Fsm;
			bool value = showLabel.Value;
			fsm.showStateLabel = value;
			Finish();
		}

		[Token(Token = "0x6000973")]
		[Address(RVA = "0xB70D3C", Offset = "0xB70D3C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DrawStateLabel()
		{
		}
	}
}
