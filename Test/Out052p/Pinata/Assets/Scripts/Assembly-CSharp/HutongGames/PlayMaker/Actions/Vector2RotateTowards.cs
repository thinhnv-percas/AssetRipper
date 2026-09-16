using System;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7630F8", Offset = "0x7630F8")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7630F8", Offset = "0x7630F8")]
	[Token(Token = "0x2000439")]
	public class Vector2RotateTowards : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7DA7A4", Offset = "0x7DA7A4")]
		[Token(Token = "0x4001FE6")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector2 currentDirection;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7DA7F0", Offset = "0x7DA7F0")]
		[Token(Token = "0x4001FE7")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector2 targetDirection;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7DA83C", Offset = "0x7DA83C")]
		[Token(Token = "0x4001FE8")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat rotateSpeed;

		[Token(Token = "0x4001FE9")]
		[FieldOffset(Offset = "0x68")]
		private Vector3 current;

		[Token(Token = "0x4001FEA")]
		[FieldOffset(Offset = "0x74")]
		private Vector3 target;

		[Token(Token = "0x60014EE")]
		[Address(RVA = "0x987E40", Offset = "0x987E40", Length = "0xB0")]
		public override void Reset()
		{
			FsmVector2 fsmVector = new FsmVector2();
			fsmVector.useVariable = true;
			currentDirection = fsmVector;
			FsmVector2 fsmVector2 = new FsmVector2();
			fsmVector2.useVariable = true;
			targetDirection = fsmVector2;
			FsmFloat fsmFloat = 360f;
			rotateSpeed = fsmFloat;
		}

		[Token(Token = "0x60014EF")]
		[Address(RVA = "0x987EF0", Offset = "0x987EF0", Length = "0x94")]
		public override void OnEnter()
		{
			FsmVector2 fsmVector = currentDirection;
			Vector3 vector = default(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			FsmVector2 fsmVector2 = targetDirection;
			current = default(Vector3);
			current.z = 0f;
			Vector3 vector2 = default(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			target = default(Vector3);
			target.z = 0f;
		}

		[Token(Token = "0x60014F0")]
		[Address(RVA = "0x987F84", Offset = "0x987F84", Length = "0x138")]
		public override void OnUpdate()
		{
			FsmVector2 fsmVector = currentDirection;
			current.x = fsmVector.value.x;
			current.y = fsmVector.value.y;
			float value = rotateSpeed.Value;
			float deltaTime = Time.deltaTime;
			float num = value * ((float)Math.PI / 180f);
			float maxRadiansDelta = num * deltaTime;
			Vector3 vector = default(Vector3);
			vector.x = fsmVector.value.x;
			vector.y = fsmVector.value.y;
			vector.z = current.z;
			Vector3 vector2 = default(Vector3);
			vector2.x = target.x;
			vector2.y = target.y;
			vector2.z = target.z;
			Vector3 vector3 = Vector3.RotateTowards(vector, vector2, maxRadiansDelta, 1000f);
			FsmVector2 fsmVector2 = currentDirection;
			current = vector3;
			current.y = vector3.y;
			current.z = vector3.z;
			Vector2 vector4 = default(Vector2);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
			fsmVector2.value = default(Vector2);
			float y = default(float);
			fsmVector2.value.y = y;
		}

		[Token(Token = "0x60014F1")]
		[Address(RVA = "0x9880BC", Offset = "0x9880BC", Length = "0x8")]
		public Vector2RotateTowards()
		{
		}
	}
}
