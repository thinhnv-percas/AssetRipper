using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x762C48", Offset = "0x762C48")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x762C48", Offset = "0x762C48")]
	[Token(Token = "0x200042A")]
	public class SetVector2Value : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7D97D8", Offset = "0x7D97D8")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D97D8", Offset = "0x7D97D8")]
		[Token(Token = "0x4001FAA")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector2 vector2Variable;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D9838", Offset = "0x7D9838")]
		[Token(Token = "0x4001FAB")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector2 vector2Value;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D9884", Offset = "0x7D9884")]
		[Token(Token = "0x4001FAC")]
		[FieldOffset(Offset = "0x60")]
		public bool everyFrame;

		[Token(Token = "0x60014AC")]
		[Address(RVA = "0x99AB80", Offset = "0x99AB80", Length = "0xC")]
		public override void Reset()
		{
			everyFrame = false;
			vector2Variable = null;
			vector2Value = null;
		}

		[Token(Token = "0x60014AD")]
		[Address(RVA = "0x99AB8C", Offset = "0x99AB8C", Length = "0x44")]
		public override void OnEnter()
		{
			FsmVector2 fsmVector = vector2Value;
			FsmVector2 fsmVector2 = vector2Variable;
			fsmVector2.value = fsmVector.value;
			fsmVector2.value.y = fsmVector.value.y;
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60014AE")]
		[Address(RVA = "0x99ABD0", Offset = "0x99ABD0", Length = "0x30")]
		public override void OnUpdate()
		{
			FsmVector2 fsmVector = vector2Value;
			FsmVector2 fsmVector2 = vector2Variable;
			fsmVector2.value = fsmVector.value;
			fsmVector2.value.y = fsmVector.value.y;
		}

		[Token(Token = "0x60014AF")]
		[Address(RVA = "0x99AC00", Offset = "0x99AC00", Length = "0x8")]
		public SetVector2Value()
		{
		}
	}
}
