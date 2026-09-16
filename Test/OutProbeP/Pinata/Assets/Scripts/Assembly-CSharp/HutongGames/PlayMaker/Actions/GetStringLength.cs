using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75F87C", Offset = "0x75F87C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75F87C", Offset = "0x75F87C")]
	[Token(Token = "0x2000388")]
	public class GetStringLength : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7CCA10", Offset = "0x7CCA10")]
		[Token(Token = "0x4001C6A")]
		[FieldOffset(Offset = "0x50")]
		public FsmString stringVariable;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7CCA4C", Offset = "0x7CCA4C")]
		[Token(Token = "0x4001C6B")]
		[FieldOffset(Offset = "0x58")]
		public FsmInt storeResult;

		[Token(Token = "0x4001C6C")]
		[FieldOffset(Offset = "0x60")]
		public bool everyFrame;

		[Token(Token = "0x6001197")]
		[Address(RVA = "0xA35FD0", Offset = "0xA35FD0", Length = "0xC")]
		public override void Reset()
		{
			everyFrame = false;
			stringVariable = null;
			storeResult = null;
		}

		[Token(Token = "0x6001198")]
		[Address(RVA = "0xA35FDC", Offset = "0xA35FDC", Length = "0x3C")]
		public override void OnEnter()
		{
			DoGetStringLength();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001199")]
		[Address(RVA = "0xA3605C", Offset = "0xA3605C", Length = "0x4")]
		public override void OnUpdate()
		{
			DoGetStringLength();
		}

		[Token(Token = "0x600119A")]
		[Address(RVA = "0xA36018", Offset = "0xA36018", Length = "0x44")]
		private void DoGetStringLength()
		{
			if (stringVariable != null)
			{
				FsmInt fsmInt = storeResult;
				if (storeResult != null)
				{
					string value = stringVariable.Value;
					fsmInt.Value = value.Length;
				}
			}
		}

		[Token(Token = "0x600119B")]
		[Address(RVA = "0xA36060", Offset = "0xA36060", Length = "0x8")]
		public GetStringLength()
		{
		}
	}
}
