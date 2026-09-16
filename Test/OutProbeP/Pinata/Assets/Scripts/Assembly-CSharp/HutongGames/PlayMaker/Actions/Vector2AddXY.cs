using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x762D38", Offset = "0x762D38")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x762D38", Offset = "0x762D38")]
	[Token(Token = "0x200042D")]
	public class Vector2AddXY : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7D9B30", Offset = "0x7D9B30")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D9B30", Offset = "0x7D9B30")]
		[Token(Token = "0x4001FB6")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector2 vector2Variable;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D9B90", Offset = "0x7D9B90")]
		[Token(Token = "0x4001FB7")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat addX;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D9BC8", Offset = "0x7D9BC8")]
		[Token(Token = "0x4001FB8")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat addY;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D9C00", Offset = "0x7D9C00")]
		[Token(Token = "0x4001FB9")]
		[FieldOffset(Offset = "0x68")]
		public bool everyFrame;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D9C38", Offset = "0x7D9C38")]
		[Token(Token = "0x4001FBA")]
		[FieldOffset(Offset = "0x69")]
		public bool perSecond;

		[Token(Token = "0x60014BA")]
		[Address(RVA = "0x9869B8", Offset = "0x9869B8", Length = "0x44")]
		public override void Reset()
		{
			vector2Variable = null;
			FsmFloat fsmFloat = 0f;
			addX = fsmFloat;
			FsmFloat fsmFloat2 = 0f;
			addY = fsmFloat2;
			everyFrame = false;
			perSecond = false;
		}

		[Token(Token = "0x60014BB")]
		[Address(RVA = "0x9869FC", Offset = "0x9869FC", Length = "0x3C")]
		public override void OnEnter()
		{
			DoVector2AddXYZ();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60014BC")]
		[Address(RVA = "0x986B78", Offset = "0x986B78", Length = "0x4")]
		public override void OnUpdate()
		{
			DoVector2AddXYZ();
		}

		[Token(Token = "0x60014BD")]
		[Address(RVA = "0x986A38", Offset = "0x986A38", Length = "0x140")]
		private void DoVector2AddXYZ()
		{
			float value = addX.Value;
			float value2 = addY.Value;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
			FsmVector2 fsmVector = vector2Variable;
			Vector2 vector2 = default(Vector2);
			float num = default(float);
			float y;
			Vector2 vector4;
			if (perSecond)
			{
				float deltaTime = Time.deltaTime;
				Vector2 vector = default(Vector2);
				vector.x = vector2.x;
				vector.y = num;
				Vector2 vector3 = vector * deltaTime;
				y = vector3.y;
				vector4 = vector3;
			}
			else
			{
				y = num;
				vector4 = vector2;
			}
			Vector2 vector5 = default(Vector2);
			vector5.x = fsmVector.value.x;
			vector5.y = fsmVector.value.y;
			Vector2 vector6 = default(Vector2);
			vector6.x = vector4.x;
			vector6.y = y;
			Vector2 vector7 = (fsmVector.value = vector5 + vector6);
			fsmVector.value.y = vector7.y;
		}

		[Token(Token = "0x60014BE")]
		[Address(RVA = "0x986B7C", Offset = "0x986B7C", Length = "0x8")]
		public Vector2AddXY()
		{
		}
	}
}
