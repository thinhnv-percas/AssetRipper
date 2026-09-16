using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75E74C", Offset = "0x75E74C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75E74C", Offset = "0x75E74C")]
	[Token(Token = "0x2000368")]
	public class GetPreviousStateName : FsmStateAction
	{
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7CAC70", Offset = "0x7CAC70")]
		[Token(Token = "0x4001BAF")]
		[FieldOffset(Offset = "0x50")]
		public FsmString storeName;

		[Token(Token = "0x60010F5")]
		[Address(RVA = "0xA328BC", Offset = "0xA328BC", Length = "0x8")]
		public override void Reset()
		{
			storeName = null;
		}

		[Token(Token = "0x60010F6")]
		[Address(RVA = "0xA328C4", Offset = "0xA328C4", Length = "0x3C")]
		public override void OnEnter()
		{
			Fsm fsm = Fsm;
			FsmState previousActiveState = fsm.PreviousActiveState;
			FsmString fsmString = storeName;
			if (fsm.PreviousActiveState != null)
			{
				previousActiveState = (FsmState)(object)previousActiveState.Name;
			}
			fsmString.Value = (string)(object)previousActiveState;
			Finish();
		}

		[Token(Token = "0x60010F7")]
		[Address(RVA = "0xA32900", Offset = "0xA32900", Length = "0x8")]
		public GetPreviousStateName()
		{
		}
	}
}
