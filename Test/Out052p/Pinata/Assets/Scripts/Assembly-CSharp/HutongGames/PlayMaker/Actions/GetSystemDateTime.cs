using System;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75FB4C", Offset = "0x75FB4C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75FB4C", Offset = "0x75FB4C")]
	[Token(Token = "0x2000391")]
	public class GetSystemDateTime : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CD0AC", Offset = "0x7CD0AC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CD0AC", Offset = "0x7CD0AC")]
		[Token(Token = "0x4001C8B")]
		[FieldOffset(Offset = "0x50")]
		public FsmString storeString;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CD0FC", Offset = "0x7CD0FC")]
		[Token(Token = "0x4001C8C")]
		[FieldOffset(Offset = "0x58")]
		public FsmString format;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CD134", Offset = "0x7CD134")]
		[Token(Token = "0x4001C8D")]
		[FieldOffset(Offset = "0x60")]
		public bool everyFrame;

		[Token(Token = "0x60011BC")]
		[Address(RVA = "0xA3630C", Offset = "0xA3630C", Length = "0x5C")]
		public override void Reset()
		{
			storeString = null;
			FsmString fsmString = "MM/dd/yyyy HH:mm";
			format = fsmString;
		}

		[Token(Token = "0x60011BD")]
		[Address(RVA = "0xA36368", Offset = "0xA36368", Length = "0xC4")]
		public override void OnEnter()
		{
			FsmString fsmString = storeString;
			DateTime now = DateTime.Now;
			string value = format.Value;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @E96214 (inside System.DateTimeFormat::Format +0x128)");
			string value2 = default(string);
			fsmString.Value = value2;
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60011BE")]
		[Address(RVA = "0xA3642C", Offset = "0xA3642C", Length = "0xB0")]
		public override void OnUpdate()
		{
			FsmString fsmString = storeString;
			DateTime now = DateTime.Now;
			string value = format.Value;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @E96214 (inside System.DateTimeFormat::Format +0x128)");
			string value2 = default(string);
			fsmString.Value = value2;
		}

		[Token(Token = "0x60011BF")]
		[Address(RVA = "0xA364DC", Offset = "0xA364DC", Length = "0x8")]
		public GetSystemDateTime()
		{
		}
	}
}
