using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75F8CC", Offset = "0x75F8CC")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75F8CC", Offset = "0x75F8CC")]
	[Token(Token = "0x2000389")]
	public class GetStringRight : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7CCA88", Offset = "0x7CCA88")]
		[Token(Token = "0x4001C6D")]
		[FieldOffset(Offset = "0x50")]
		public FsmString stringVariable;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CCAC4", Offset = "0x7CCAC4")]
		[Token(Token = "0x4001C6E")]
		[FieldOffset(Offset = "0x58")]
		public FsmInt charCount;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7CCAFC", Offset = "0x7CCAFC")]
		[Token(Token = "0x4001C6F")]
		[FieldOffset(Offset = "0x60")]
		public FsmString storeResult;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CCB38", Offset = "0x7CCB38")]
		[Token(Token = "0x4001C70")]
		[FieldOffset(Offset = "0x68")]
		public bool everyFrame;

		[Token(Token = "0x600119C")]
		[Address(RVA = "0xA36068", Offset = "0xA36068", Length = "0x34")]
		public override void Reset()
		{
			stringVariable = null;
			FsmInt fsmInt = 0;
			charCount = fsmInt;
			storeResult = null;
			everyFrame = false;
		}

		[Token(Token = "0x600119D")]
		[Address(RVA = "0xA3609C", Offset = "0xA3609C", Length = "0x3C")]
		public override void OnEnter()
		{
			DoGetStringRight();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x600119E")]
		[Address(RVA = "0xA361E4", Offset = "0xA361E4", Length = "0x4")]
		public override void OnUpdate()
		{
			DoGetStringRight();
		}

		[Token(Token = "0x600119F")]
		[Address(RVA = "0xA360D8", Offset = "0xA360D8", Length = "0x10C")]
		private void DoGetStringRight()
		{
			if (!stringVariable.IsNone && !storeResult.IsNone)
			{
				string value = stringVariable.Value;
				int value2 = charCount.Value;
				int num = Mathf.Clamp(value2, 0, value.Length);
				FsmString fsmString = storeResult;
				int startIndex = value.Length - num;
				string value3 = value.Substring(startIndex, num);
				fsmString.Value = value3;
			}
		}

		[Token(Token = "0x60011A0")]
		[Address(RVA = "0xA361E8", Offset = "0xA361E8", Length = "0x8")]
		public GetStringRight()
		{
		}
	}
}
