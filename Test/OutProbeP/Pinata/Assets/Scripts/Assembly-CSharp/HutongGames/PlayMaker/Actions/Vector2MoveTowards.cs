using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x762F68", Offset = "0x762F68")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x762F68", Offset = "0x762F68")]
	[Token(Token = "0x2000434")]
	public class Vector2MoveTowards : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7DA284", Offset = "0x7DA284")]
		[Token(Token = "0x4001FD4")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector2 source;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7DA2D0", Offset = "0x7DA2D0")]
		[Token(Token = "0x4001FD5")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector2 target;

		[Attribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7DA308", Offset = "0x7DA308")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7DA308", Offset = "0x7DA308")]
		[Token(Token = "0x4001FD6")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat maxSpeed;

		[Attribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7DA35C", Offset = "0x7DA35C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7DA35C", Offset = "0x7DA35C")]
		[Token(Token = "0x4001FD7")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat finishDistance;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7DA3B0", Offset = "0x7DA3B0")]
		[Token(Token = "0x4001FD8")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent finishEvent;

		[Token(Token = "0x60014D9")]
		[Address(RVA = "0x98754C", Offset = "0x98754C", Length = "0x40")]
		public override void Reset()
		{
			source = null;
			target = null;
			FsmFloat fsmFloat = 10f;
			maxSpeed = fsmFloat;
			FsmFloat fsmFloat2 = 1f;
			finishDistance = fsmFloat2;
			finishEvent = null;
		}

		[Token(Token = "0x60014DA")]
		[Address(RVA = "0x98758C", Offset = "0x98758C", Length = "0x4")]
		public override void OnUpdate()
		{
			DoMoveTowards();
		}

		[Token(Token = "0x60014DB")]
		[Address(RVA = "0x987590", Offset = "0x987590", Length = "0x150")]
		private void DoMoveTowards()
		{
			FsmVector2 fsmVector = source;
			FsmVector2 fsmVector2 = target;
			float value = maxSpeed.Value;
			value = Time.deltaTime;
			float maxDistanceDelta = value * value;
			Vector2 current = default(Vector2);
			current.x = fsmVector.value.x;
			current.y = fsmVector.value.y;
			Vector2 vector = default(Vector2);
			vector.x = fsmVector2.value.x;
			vector.y = fsmVector2.value.y;
			Vector2 vector2 = (fsmVector.value = Vector2.MoveTowards(current, vector, maxDistanceDelta));
			fsmVector.value.y = vector2.y;
			FsmVector2 fsmVector3 = source;
			FsmVector2 fsmVector4 = target;
			Vector2 vector3 = default(Vector2);
			vector3.x = fsmVector3.value.x;
			vector3.y = fsmVector3.value.y;
			Vector2 vector4 = default(Vector2);
			vector4.x = fsmVector4.value.x;
			vector4.y = fsmVector4.value.y;
			Vector2 vector5 = vector3 - vector4;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1588E30 (inside UnityEngine.Vector2::Scale +0xC8)");
			value = finishDistance.Value;
			if (vector5.x < value)
			{
				Fsm.Event(finishEvent);
				Finish();
			}
		}

		[Token(Token = "0x60014DC")]
		[Address(RVA = "0x9876E0", Offset = "0x9876E0", Length = "0x8")]
		public Vector2MoveTowards()
		{
		}
	}
}
