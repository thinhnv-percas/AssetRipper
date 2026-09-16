using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75F91C", Offset = "0x75F91C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75F91C", Offset = "0x75F91C")]
	[Token(Token = "0x200038A")]
	public class GetSubstring : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7CCB70", Offset = "0x7CCB70")]
		[Token(Token = "0x4001C71")]
		[FieldOffset(Offset = "0x50")]
		public FsmString stringVariable;

		[RequiredField]
		[Token(Token = "0x4001C72")]
		[FieldOffset(Offset = "0x58")]
		public FsmInt startIndex;

		[RequiredField]
		[Token(Token = "0x4001C73")]
		[FieldOffset(Offset = "0x60")]
		public FsmInt length;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7CCBCC", Offset = "0x7CCBCC")]
		[Token(Token = "0x4001C74")]
		[FieldOffset(Offset = "0x68")]
		public FsmString storeResult;

		[Token(Token = "0x4001C75")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x60011A1")]
		[Address(RVA = "0xA361F0", Offset = "0xA361F0", Length = "0x44")]
		public override void Reset()
		{
			stringVariable = null;
			FsmInt fsmInt = 0;
			startIndex = fsmInt;
			FsmInt fsmInt2 = 1;
			length = fsmInt2;
			storeResult = null;
			everyFrame = false;
		}

		[Token(Token = "0x60011A2")]
		[Address(RVA = "0xA36234", Offset = "0xA36234", Length = "0x3C")]
		public override void OnEnter()
		{
			DoGetSubstring();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60011A3")]
		[Address(RVA = "0xA36300", Offset = "0xA36300", Length = "0x4")]
		public override void OnUpdate()
		{
			DoGetSubstring();
		}

		[Token(Token = "0x60011A4")]
		[Address(RVA = "0xA36270", Offset = "0xA36270", Length = "0x90")]
		private void DoGetSubstring()
		{
			if (stringVariable != null)
			{
				FsmString fsmString = storeResult;
				if (storeResult != null)
				{
					string value = stringVariable.Value;
					int value2 = startIndex.Value;
					int value3 = length.Value;
					string value4 = value.Substring(value2, value3);
					fsmString.Value = value4;
				}
			}
		}

		[Token(Token = "0x60011A5")]
		[Address(RVA = "0xA36304", Offset = "0xA36304", Length = "0x8")]
		public GetSubstring()
		{
		}
	}
}
