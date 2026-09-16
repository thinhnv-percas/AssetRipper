using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75FA0C", Offset = "0x75FA0C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75FA0C", Offset = "0x75FA0C")]
	[Token(Token = "0x200038D")]
	public class StringAppend : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CCD14", Offset = "0x7CCD14")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7CCD14", Offset = "0x7CCD14")]
		[Token(Token = "0x4001C7C")]
		[FieldOffset(Offset = "0x50")]
		public FsmString stringVariable;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CCD74", Offset = "0x7CCD74")]
		[Token(Token = "0x4001C7D")]
		[FieldOffset(Offset = "0x58")]
		public FsmString appendString;

		[Token(Token = "0x60011AF")]
		[Address(RVA = "0x99E524", Offset = "0x99E524", Length = "0x8")]
		public override void Reset()
		{
			stringVariable = null;
			appendString = null;
		}

		[Token(Token = "0x60011B0")]
		[Address(RVA = "0x99E52C", Offset = "0x99E52C", Length = "0x74")]
		public override void OnEnter()
		{
			FsmString fsmString = stringVariable;
			string value = stringVariable.Value;
			string value2 = appendString.Value;
			string value3 = value + value2;
			fsmString.Value = value3;
			Finish();
		}

		[Token(Token = "0x60011B1")]
		[Address(RVA = "0x99E5A0", Offset = "0x99E5A0", Length = "0x8")]
		public StringAppend()
		{
		}
	}
}
