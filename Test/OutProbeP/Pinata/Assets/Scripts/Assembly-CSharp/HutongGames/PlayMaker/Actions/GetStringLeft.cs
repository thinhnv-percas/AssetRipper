using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75F82C", Offset = "0x75F82C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75F82C", Offset = "0x75F82C")]
	[Token(Token = "0x2000387")]
	public class GetStringLeft : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7CC928", Offset = "0x7CC928")]
		[Token(Token = "0x4001C66")]
		[FieldOffset(Offset = "0x50")]
		public FsmString stringVariable;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CC964", Offset = "0x7CC964")]
		[Token(Token = "0x4001C67")]
		[FieldOffset(Offset = "0x58")]
		public FsmInt charCount;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7CC99C", Offset = "0x7CC99C")]
		[Token(Token = "0x4001C68")]
		[FieldOffset(Offset = "0x60")]
		public FsmString storeResult;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CC9D8", Offset = "0x7CC9D8")]
		[Token(Token = "0x4001C69")]
		[FieldOffset(Offset = "0x68")]
		public bool everyFrame;

		[Token(Token = "0x6001192")]
		[Address(RVA = "0xA35E34", Offset = "0xA35E34", Length = "0x34")]
		public override void Reset()
		{
			stringVariable = null;
			FsmInt fsmInt = 0;
			charCount = fsmInt;
			storeResult = null;
			everyFrame = false;
		}

		[Token(Token = "0x6001193")]
		[Address(RVA = "0xA35E68", Offset = "0xA35E68", Length = "0x3C")]
		public override void OnEnter()
		{
			DoGetStringLeft();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001194")]
		[Address(RVA = "0xA35FC4", Offset = "0xA35FC4", Length = "0x4")]
		public override void OnUpdate()
		{
			DoGetStringLeft();
		}

		[Token(Token = "0x6001195")]
		[Address(RVA = "0xA35EA4", Offset = "0xA35EA4", Length = "0x120")]
		private void DoGetStringLeft()
		{
			if (!stringVariable.IsNone && !storeResult.IsNone)
			{
				FsmString fsmString = storeResult;
				string value = stringVariable.Value;
				int value2 = charCount.Value;
				string value3 = stringVariable.Value;
				int length = Mathf.Clamp(value2, 0, value3.Length);
				string value4 = value.Substring(0, length);
				fsmString.Value = value4;
			}
		}

		[Token(Token = "0x6001196")]
		[Address(RVA = "0xA35FC8", Offset = "0xA35FC8", Length = "0x8")]
		public GetStringLeft()
		{
		}
	}
}
