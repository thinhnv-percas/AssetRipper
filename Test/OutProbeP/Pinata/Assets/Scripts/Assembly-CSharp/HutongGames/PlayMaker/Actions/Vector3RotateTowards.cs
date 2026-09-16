using System;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7636E8", Offset = "0x7636E8")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7636E8", Offset = "0x7636E8")]
	[Token(Token = "0x200044C")]
	public class Vector3RotateTowards : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x4002031")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector3 currentDirection;

		[RequiredField]
		[Token(Token = "0x4002032")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector3 targetDirection;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7DB104", Offset = "0x7DB104")]
		[Token(Token = "0x4002033")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat rotateSpeed;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7DB150", Offset = "0x7DB150")]
		[Token(Token = "0x4002034")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat maxMagnitude;

		[Token(Token = "0x6001541")]
		[Address(RVA = "0x989CBC", Offset = "0x989CBC", Length = "0xC0")]
		public override void Reset()
		{
			FsmVector3 fsmVector = new FsmVector3();
			fsmVector.useVariable = true;
			currentDirection = fsmVector;
			FsmVector3 fsmVector2 = new FsmVector3();
			fsmVector2.useVariable = true;
			targetDirection = fsmVector2;
			FsmFloat fsmFloat = 360f;
			rotateSpeed = fsmFloat;
			FsmFloat fsmFloat2 = 1f;
			maxMagnitude = fsmFloat2;
		}

		[Token(Token = "0x6001542")]
		[Address(RVA = "0x989D7C", Offset = "0x989D7C", Length = "0x13C")]
		public override void OnUpdate()
		{
			FsmVector3 fsmVector = currentDirection;
			Vector3 value = currentDirection.Value;
			Vector3 value2 = targetDirection.Value;
			float value3 = rotateSpeed.Value;
			float deltaTime = Time.deltaTime;
			float value4 = maxMagnitude.Value;
			float num = value3 * ((float)Math.PI / 180f);
			float maxRadiansDelta = num * deltaTime;
			Vector3 vector = (fsmVector.value = Vector3.RotateTowards(value, value2, maxRadiansDelta, value4));
			fsmVector.value.y = vector.y;
			fsmVector.value.z = vector.z;
		}

		[Token(Token = "0x6001543")]
		[Address(RVA = "0x989EB8", Offset = "0x989EB8", Length = "0x8")]
		public Vector3RotateTowards()
		{
		}
	}
}
