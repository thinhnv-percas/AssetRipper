using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7630A8", Offset = "0x7630A8")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7630A8", Offset = "0x7630A8")]
	[Token(Token = "0x2000438")]
	public class Vector2PerSecond : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7DA70C", Offset = "0x7DA70C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7DA70C", Offset = "0x7DA70C")]
		[Token(Token = "0x4001FE4")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector2 vector2Variable;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7DA76C", Offset = "0x7DA76C")]
		[Token(Token = "0x4001FE5")]
		[FieldOffset(Offset = "0x58")]
		public bool everyFrame;

		[Token(Token = "0x60014EA")]
		[Address(RVA = "0x987CB4", Offset = "0x987CB4", Length = "0x10")]
		public override void Reset()
		{
			vector2Variable = null;
			everyFrame = true;
		}

		[Token(Token = "0x60014EB")]
		[Address(RVA = "0x987CC4", Offset = "0x987CC4", Length = "0xCC")]
		public override void OnEnter()
		{
			FsmVector2 fsmVector = vector2Variable;
			float deltaTime = Time.deltaTime;
			Vector2 vector = default(Vector2);
			vector.x = fsmVector.value.x;
			vector.y = fsmVector.value.y;
			Vector2 vector2 = (fsmVector.value = vector * deltaTime);
			fsmVector.value.y = vector2.y;
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60014EC")]
		[Address(RVA = "0x987D90", Offset = "0x987D90", Length = "0xA8")]
		public override void OnUpdate()
		{
			FsmVector2 fsmVector = vector2Variable;
			float deltaTime = Time.deltaTime;
			Vector2 vector = default(Vector2);
			vector.x = fsmVector.value.x;
			vector.y = fsmVector.value.y;
			Vector2 vector2 = (fsmVector.value = vector * deltaTime);
			fsmVector.value.y = vector2.y;
		}

		[Token(Token = "0x60014ED")]
		[Address(RVA = "0x987E38", Offset = "0x987E38", Length = "0x8")]
		public Vector2PerSecond()
		{
		}
	}
}
