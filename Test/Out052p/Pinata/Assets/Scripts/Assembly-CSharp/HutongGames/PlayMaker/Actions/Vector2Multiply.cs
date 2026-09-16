using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x762FB8", Offset = "0x762FB8")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x762FB8", Offset = "0x762FB8")]
	[Token(Token = "0x2000435")]
	public class Vector2Multiply : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7DA3E8", Offset = "0x7DA3E8")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7DA3E8", Offset = "0x7DA3E8")]
		[Token(Token = "0x4001FD9")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector2 vector2Variable;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7DA448", Offset = "0x7DA448")]
		[Token(Token = "0x4001FDA")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat multiplyBy;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7DA494", Offset = "0x7DA494")]
		[Token(Token = "0x4001FDB")]
		[FieldOffset(Offset = "0x60")]
		public bool everyFrame;

		[Token(Token = "0x60014DD")]
		[Address(RVA = "0x9876E8", Offset = "0x9876E8", Length = "0x34")]
		public override void Reset()
		{
			vector2Variable = null;
			FsmFloat fsmFloat = 1f;
			multiplyBy = fsmFloat;
			everyFrame = false;
		}

		[Token(Token = "0x60014DE")]
		[Address(RVA = "0x98771C", Offset = "0x98771C", Length = "0xD4")]
		public override void OnEnter()
		{
			FsmVector2 fsmVector = vector2Variable;
			float value = multiplyBy.Value;
			Vector2 vector = default(Vector2);
			vector.x = fsmVector.value.x;
			vector.y = fsmVector.value.y;
			Vector2 vector2 = (fsmVector.value = vector * value);
			fsmVector.value.y = vector2.y;
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60014DF")]
		[Address(RVA = "0x9877F0", Offset = "0x9877F0", Length = "0xB0")]
		public override void OnUpdate()
		{
			FsmVector2 fsmVector = vector2Variable;
			float value = multiplyBy.Value;
			Vector2 vector = default(Vector2);
			vector.x = fsmVector.value.x;
			vector.y = fsmVector.value.y;
			Vector2 vector2 = (fsmVector.value = vector * value);
			fsmVector.value.y = vector2.y;
		}

		[Token(Token = "0x60014E0")]
		[Address(RVA = "0x9878A0", Offset = "0x9878A0", Length = "0x8")]
		public Vector2Multiply()
		{
		}
	}
}
