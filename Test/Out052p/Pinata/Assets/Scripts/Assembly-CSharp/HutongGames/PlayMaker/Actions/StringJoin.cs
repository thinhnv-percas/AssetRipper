using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75FA5C", Offset = "0x75FA5C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75FA5C", Offset = "0x75FA5C")]
	[Token(Token = "0x200038E")]
	public class StringJoin : FsmStateAction
	{
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7CCDAC", Offset = "0x7CCDAC")]
		[Attribute(Type = typeof(ArrayEditorAttribute), RVA = "0x7CCDAC", Offset = "0x7CCDAC")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CCDAC", Offset = "0x7CCDAC")]
		[Token(Token = "0x4001C7E")]
		[FieldOffset(Offset = "0x50")]
		public FsmArray stringArray;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CCE30", Offset = "0x7CCE30")]
		[Token(Token = "0x4001C7F")]
		[FieldOffset(Offset = "0x58")]
		public FsmString separator;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7CCE68", Offset = "0x7CCE68")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CCE68", Offset = "0x7CCE68")]
		[Token(Token = "0x4001C80")]
		[FieldOffset(Offset = "0x60")]
		public FsmString storeResult;

		[Token(Token = "0x60011B2")]
		[Address(RVA = "0x99E950", Offset = "0x99E950", Length = "0x88")]
		public override void OnEnter()
		{
			if (!stringArray.IsNone && !storeResult.IsNone)
			{
				FsmString fsmString = storeResult;
				string value = separator.Value;
				FsmArray fsmArray = stringArray;
				string value2 = string.Join(value, fsmArray.stringValues);
				fsmString.Value = value2;
			}
			Finish();
		}

		[Token(Token = "0x60011B3")]
		[Address(RVA = "0x99E9D8", Offset = "0x99E9D8", Length = "0x8")]
		public StringJoin()
		{
		}
	}
}
