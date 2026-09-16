using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x762CE8", Offset = "0x762CE8")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x762CE8", Offset = "0x762CE8")]
	[Token(Token = "0x200042C")]
	public class Vector2Add : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7D9A14", Offset = "0x7D9A14")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D9A14", Offset = "0x7D9A14")]
		[Token(Token = "0x4001FB2")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector2 vector2Variable;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D9A74", Offset = "0x7D9A74")]
		[Token(Token = "0x4001FB3")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector2 addVector;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D9AC0", Offset = "0x7D9AC0")]
		[Token(Token = "0x4001FB4")]
		[FieldOffset(Offset = "0x60")]
		public bool everyFrame;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D9AF8", Offset = "0x7D9AF8")]
		[Token(Token = "0x4001FB5")]
		[FieldOffset(Offset = "0x61")]
		public bool perSecond;

		[Token(Token = "0x60014B5")]
		[Address(RVA = "0x9867EC", Offset = "0x9867EC", Length = "0x7C")]
		public override void Reset()
		{
			vector2Variable = null;
			FsmVector2 fsmVector = new FsmVector2();
			fsmVector.useVariable = true;
			addVector = fsmVector;
			everyFrame = false;
			perSecond = false;
		}

		[Token(Token = "0x60014B6")]
		[Address(RVA = "0x986868", Offset = "0x986868", Length = "0x3C")]
		public override void OnEnter()
		{
			DoVector2Add();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60014B7")]
		[Address(RVA = "0x9869AC", Offset = "0x9869AC", Length = "0x4")]
		public override void OnUpdate()
		{
			DoVector2Add();
		}

		[Token(Token = "0x60014B8")]
		[Address(RVA = "0x9868A4", Offset = "0x9868A4", Length = "0x108")]
		private void DoVector2Add()
		{
			FsmVector2 fsmVector = vector2Variable;
			FsmVector2 fsmVector2 = addVector;
			Vector2 vector = fsmVector2.value;
			float y = fsmVector2.value.y;
			if (perSecond)
			{
				float deltaTime = Time.deltaTime;
				Vector2 vector2 = default(Vector2);
				vector2.x = fsmVector2.value.x;
				vector2.y = fsmVector2.value.y;
				Vector2 vector3 = vector2 * deltaTime;
				y = vector3.y;
				vector = vector3;
			}
			Vector2 vector4 = default(Vector2);
			vector4.x = fsmVector.value.x;
			vector4.y = fsmVector.value.y;
			Vector2 vector5 = default(Vector2);
			vector5.x = vector.x;
			vector5.y = y;
			Vector2 vector6 = (fsmVector.value = vector4 + vector5);
			fsmVector.value.y = vector6.y;
		}

		[Token(Token = "0x60014B9")]
		[Address(RVA = "0x9869B0", Offset = "0x9869B0", Length = "0x8")]
		public Vector2Add()
		{
		}
	}
}
