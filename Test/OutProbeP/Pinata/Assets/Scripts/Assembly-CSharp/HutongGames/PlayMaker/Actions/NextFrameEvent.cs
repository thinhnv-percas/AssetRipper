using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75E860", Offset = "0x75E860")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75E860", Offset = "0x75E860")]
	[Token(Token = "0x200036B")]
	public class NextFrameEvent : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x4001BB0")]
		[FieldOffset(Offset = "0x50")]
		public FsmEvent sendEvent;

		[Token(Token = "0x60010FD")]
		[Address(RVA = "0xB18F20", Offset = "0xB18F20", Length = "0x8")]
		public override void Reset()
		{
			sendEvent = null;
		}

		[Token(Token = "0x60010FE")]
		[Address(RVA = "0xB18F28", Offset = "0xB18F28", Length = "0x4")]
		public override void OnEnter()
		{
		}

		[Token(Token = "0x60010FF")]
		[Address(RVA = "0xB18F2C", Offset = "0xB18F2C", Length = "0x38")]
		public override void OnUpdate()
		{
			Finish();
			Fsm.Event(sendEvent);
		}

		[Token(Token = "0x6001100")]
		[Address(RVA = "0xB18F64", Offset = "0xB18F64", Length = "0x8")]
		public NextFrameEvent()
		{
		}
	}
}
