using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75FBEC", Offset = "0x75FBEC")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75FBEC", Offset = "0x75FBEC")]
	[Token(Token = "0x2000393")]
	public class PerSecond : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x4001C91")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat floatValue;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7CD1B8", Offset = "0x7CD1B8")]
		[Token(Token = "0x4001C92")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat storeResult;

		[Token(Token = "0x4001C93")]
		[FieldOffset(Offset = "0x60")]
		public bool everyFrame;

		[Token(Token = "0x60011C5")]
		[Address(RVA = "0xB190B0", Offset = "0xB190B0", Length = "0xC")]
		public override void Reset()
		{
			everyFrame = false;
			floatValue = null;
			storeResult = null;
		}

		[Token(Token = "0x60011C6")]
		[Address(RVA = "0xB190BC", Offset = "0xB190BC", Length = "0x3C")]
		public override void OnEnter()
		{
			DoPerSecond();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60011C7")]
		[Address(RVA = "0xB19148", Offset = "0xB19148", Length = "0x4")]
		public override void OnUpdate()
		{
			DoPerSecond();
		}

		[Token(Token = "0x60011C8")]
		[Address(RVA = "0xB190F8", Offset = "0xB190F8", Length = "0x50")]
		private void DoPerSecond()
		{
			FsmFloat fsmFloat = storeResult;
			if (storeResult != null)
			{
				float value = floatValue.Value;
				float deltaTime = Time.deltaTime;
				float value2 = value * deltaTime;
				fsmFloat.Value = value2;
			}
		}

		[Token(Token = "0x60011C9")]
		[Address(RVA = "0xB1914C", Offset = "0xB1914C", Length = "0x8")]
		public PerSecond()
		{
		}
	}
}
