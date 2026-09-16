using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75F9BC", Offset = "0x75F9BC")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75F9BC", Offset = "0x75F9BC")]
	[Token(Token = "0x200038C")]
	public class SetStringValue : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7CCCC4", Offset = "0x7CCCC4")]
		[Token(Token = "0x4001C79")]
		[FieldOffset(Offset = "0x50")]
		public FsmString stringVariable;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7CCD00", Offset = "0x7CCD00")]
		[Token(Token = "0x4001C7A")]
		[FieldOffset(Offset = "0x58")]
		public FsmString stringValue;

		[Token(Token = "0x4001C7B")]
		[FieldOffset(Offset = "0x60")]
		public bool everyFrame;

		[Token(Token = "0x60011AA")]
		[Address(RVA = "0x999B34", Offset = "0x999B34", Length = "0xC")]
		public override void Reset()
		{
			everyFrame = false;
			stringVariable = null;
			stringValue = null;
		}

		[Token(Token = "0x60011AB")]
		[Address(RVA = "0x999B40", Offset = "0x999B40", Length = "0x54")]
		public override void OnEnter()
		{
			FsmString fsmString = stringVariable;
			if (stringVariable != null && stringValue != null)
			{
				string value = stringValue.Value;
				fsmString.Value = value;
			}
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60011AC")]
		[Address(RVA = "0x999BC8", Offset = "0x999BC8", Length = "0x34")]
		public override void OnUpdate()
		{
			FsmString fsmString = stringVariable;
			if (stringVariable != null && stringValue != null)
			{
				string value = stringValue.Value;
				fsmString.Value = value;
			}
		}

		[Token(Token = "0x60011AD")]
		[Address(RVA = "0x999B94", Offset = "0x999B94", Length = "0x34")]
		private void DoSetStringValue()
		{
			FsmString fsmString = stringVariable;
			if (stringVariable != null && stringValue != null)
			{
				string value = stringValue.Value;
				fsmString.Value = value;
			}
		}

		[Token(Token = "0x60011AE")]
		[Address(RVA = "0x999BFC", Offset = "0x999BFC", Length = "0x8")]
		public SetStringValue()
		{
		}
	}
}
