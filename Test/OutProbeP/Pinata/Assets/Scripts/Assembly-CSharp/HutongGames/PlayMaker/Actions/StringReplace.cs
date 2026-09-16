using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75FAAC", Offset = "0x75FAAC")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75FAAC", Offset = "0x75FAAC")]
	[Token(Token = "0x200038F")]
	public class StringReplace : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7CCEB8", Offset = "0x7CCEB8")]
		[Token(Token = "0x4001C81")]
		[FieldOffset(Offset = "0x50")]
		public FsmString stringVariable;

		[Token(Token = "0x4001C82")]
		[FieldOffset(Offset = "0x58")]
		public FsmString replace;

		[Token(Token = "0x4001C83")]
		[FieldOffset(Offset = "0x60")]
		public FsmString with;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7CCEF4", Offset = "0x7CCEF4")]
		[Token(Token = "0x4001C84")]
		[FieldOffset(Offset = "0x68")]
		public FsmString storeResult;

		[Token(Token = "0x4001C85")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x60011B4")]
		[Address(RVA = "0x99E9E0", Offset = "0x99E9E0", Length = "0x70")]
		public override void Reset()
		{
			stringVariable = null;
			FsmString fsmString = "";
			replace = fsmString;
			FsmString fsmString2 = "";
			with = fsmString2;
			storeResult = null;
			everyFrame = false;
		}

		[Token(Token = "0x60011B5")]
		[Address(RVA = "0x99EA50", Offset = "0x99EA50", Length = "0x3C")]
		public override void OnEnter()
		{
			DoReplace();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60011B6")]
		[Address(RVA = "0x99EB1C", Offset = "0x99EB1C", Length = "0x4")]
		public override void OnUpdate()
		{
			DoReplace();
		}

		[Token(Token = "0x60011B7")]
		[Address(RVA = "0x99EA8C", Offset = "0x99EA8C", Length = "0x90")]
		private void DoReplace()
		{
			if (stringVariable != null)
			{
				FsmString fsmString = storeResult;
				if (storeResult != null)
				{
					string value = stringVariable.Value;
					string value2 = replace.Value;
					string value3 = with.Value;
					string value4 = value.Replace(value2, value3);
					fsmString.Value = value4;
				}
			}
		}

		[Token(Token = "0x60011B8")]
		[Address(RVA = "0x99EB20", Offset = "0x99EB20", Length = "0x8")]
		public StringReplace()
		{
		}
	}
}
