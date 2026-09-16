using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75E79C", Offset = "0x75E79C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75E79C", Offset = "0x75E79C")]
	[Token(Token = "0x2000369")]
	public class GotoPreviousState : FsmStateAction
	{
		[Token(Token = "0x60010F8")]
		[Address(RVA = "0xA37C7C", Offset = "0xA37C7C", Length = "0x4")]
		public override void Reset()
		{
		}

		[Token(Token = "0x60010F9")]
		[Address(RVA = "0xA37C80", Offset = "0xA37C80", Length = "0x98")]
		public override void OnEnter()
		{
			Fsm fsm = Fsm;
			FsmState previousActiveState = fsm.PreviousActiveState;
			if (fsm.PreviousActiveState != null)
			{
				string text = "Goto Previous State: " + previousActiveState.Name;
				Log(text);
				Fsm.GotoPreviousState();
			}
			Finish();
		}

		[Token(Token = "0x60010FA")]
		[Address(RVA = "0xA37D18", Offset = "0xA37D18", Length = "0x8")]
		public GotoPreviousState()
		{
		}
	}
}
