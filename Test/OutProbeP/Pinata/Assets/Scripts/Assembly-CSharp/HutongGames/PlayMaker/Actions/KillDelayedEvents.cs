using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75E7EC", Offset = "0x75E7EC")]
	[Attribute(Type = typeof(NoteAttribute), RVA = "0x75E7EC", Offset = "0x75E7EC")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75E7EC", Offset = "0x75E7EC")]
	[Token(Token = "0x200036A")]
	public class KillDelayedEvents : FsmStateAction
	{
		[Token(Token = "0x60010FB")]
		[Address(RVA = "0xA3978C", Offset = "0xA3978C", Length = "0x38")]
		public override void OnEnter()
		{
			Fsm.KillDelayedEvents();
			Finish();
		}

		[Token(Token = "0x60010FC")]
		[Address(RVA = "0xA397C4", Offset = "0xA397C4", Length = "0x8")]
		public KillDelayedEvents()
		{
		}
	}
}
