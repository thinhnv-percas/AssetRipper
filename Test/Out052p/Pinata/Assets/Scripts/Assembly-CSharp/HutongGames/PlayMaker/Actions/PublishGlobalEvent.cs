using AssetRipperInjected;
using Cpp2ILInjected;
using Morpeh.Globals;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x759B20", Offset = "0x759B20")]
	[Token(Token = "0x2000297")]
	public class PublishGlobalEvent : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x4001702")]
		[FieldOffset(Offset = "0x50")]
		public GlobalEvent evnt;

		[Token(Token = "0x6000CD8")]
		[Address(RVA = "0xB1B7C4", Offset = "0xB1B7C4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.evnt = 0;\n\treturn;\n")]
		public override void Reset()
		{
			evnt = null;
		}

		[Token(Token = "0x6000CD9")]
		[Address(RVA = "0xB1B7CC", Offset = "0xB1B7CC", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tMorpeh.Globals.GlobalEvent::Publish(this.evnt);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			evnt.Publish();
			Finish();
		}

		[Token(Token = "0x6000CDA")]
		[Address(RVA = "0xB1B804", Offset = "0xB1B804", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PublishGlobalEvent()
		{
		}
	}
}
