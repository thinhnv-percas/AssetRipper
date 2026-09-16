using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x762EC8", Offset = "0x762EC8")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x762EC8", Offset = "0x762EC8")]
	[Token(Token = "0x2000432")]
	public class Vector2Lerp : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7DA070", Offset = "0x7DA070")]
		[Token(Token = "0x4001FCC")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector2 fromVector;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7DA0BC", Offset = "0x7DA0BC")]
		[Token(Token = "0x4001FCD")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector2 toVector;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7DA108", Offset = "0x7DA108")]
		[Token(Token = "0x4001FCE")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat amount;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7DA154", Offset = "0x7DA154")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7DA154", Offset = "0x7DA154")]
		[Token(Token = "0x4001FCF")]
		[FieldOffset(Offset = "0x68")]
		public FsmVector2 storeResult;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7DA1B4", Offset = "0x7DA1B4")]
		[Token(Token = "0x4001FD0")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x60014D0")]
		[Address(RVA = "0x987214", Offset = "0x987214", Length = "0xA4")]
		public override void Reset()
		{
			FsmVector2 fsmVector = new FsmVector2();
			fsmVector.useVariable = true;
			fromVector = fsmVector;
			FsmVector2 fsmVector2 = new FsmVector2();
			fsmVector2.useVariable = true;
			toVector = fsmVector2;
			storeResult = null;
			everyFrame = true;
		}

		[Token(Token = "0x60014D1")]
		[Address(RVA = "0x9872B8", Offset = "0x9872B8", Length = "0x3C")]
		public override void OnEnter()
		{
			DoVector2Lerp();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60014D2")]
		[Address(RVA = "0x9873C8", Offset = "0x9873C8", Length = "0x4")]
		public override void OnUpdate()
		{
			DoVector2Lerp();
		}

		[Token(Token = "0x60014D3")]
		[Address(RVA = "0x9872F4", Offset = "0x9872F4", Length = "0xD4")]
		private void DoVector2Lerp()
		{
			FsmVector2 fsmVector = fromVector;
			FsmVector2 fsmVector2 = toVector;
			FsmVector2 fsmVector3 = storeResult;
			float value = amount.Value;
			Vector2 a = default(Vector2);
			a.x = fsmVector.value.x;
			a.y = fsmVector.value.y;
			Vector2 b = default(Vector2);
			b.x = fsmVector2.value.x;
			b.y = fsmVector2.value.y;
			Vector2 vector = (fsmVector3.value = Vector2.Lerp(a, b, value));
			fsmVector3.value.y = vector.y;
		}

		[Token(Token = "0x60014D4")]
		[Address(RVA = "0x9873CC", Offset = "0x9873CC", Length = "0x8")]
		public Vector2Lerp()
		{
		}
	}
}
