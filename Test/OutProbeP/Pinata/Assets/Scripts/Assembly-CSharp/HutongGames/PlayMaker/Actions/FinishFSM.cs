using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75D6E4", Offset = "0x75D6E4")]
	[Attribute(Type = typeof(NoteAttribute), RVA = "0x75D6E4", Offset = "0x75D6E4")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75D6E4", Offset = "0x75D6E4")]
	[Token(Token = "0x200034B")]
	public class FinishFSM : FsmStateAction
	{
		[Token(Token = "0x600107B")]
		[Address(RVA = "0xB7597C", Offset = "0xB7597C", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Fsm::Stop(this.fsm);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			Fsm.Stop();
		}

		[Token(Token = "0x600107C")]
		[Address(RVA = "0xB75998", Offset = "0xB75998", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FinishFSM()
		{
		}
	}
}
