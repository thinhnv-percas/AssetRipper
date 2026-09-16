using System;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7601B0", Offset = "0x7601B0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7601B0", Offset = "0x7601B0")]
	[Token(Token = "0x20003A5")]
	public class SmoothFollowAction : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CE228", Offset = "0x7CE228")]
		[Token(Token = "0x4001D0A")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CE274", Offset = "0x7CE274")]
		[Token(Token = "0x4001D0B")]
		[FieldOffset(Offset = "0x58")]
		public FsmGameObject targetObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CE2AC", Offset = "0x7CE2AC")]
		[Token(Token = "0x4001D0C")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat distance;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CE2F8", Offset = "0x7CE2F8")]
		[Token(Token = "0x4001D0D")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat height;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CE344", Offset = "0x7CE344")]
		[Token(Token = "0x4001D0E")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat heightDamping;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CE390", Offset = "0x7CE390")]
		[Token(Token = "0x4001D0F")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat rotationDamping;

		[Token(Token = "0x4001D10")]
		[FieldOffset(Offset = "0x80")]
		private GameObject cachedObject;

		[Token(Token = "0x4001D11")]
		[FieldOffset(Offset = "0x88")]
		private Transform myTransform;

		[Token(Token = "0x4001D12")]
		[FieldOffset(Offset = "0x90")]
		private GameObject cachedTarget;

		[Token(Token = "0x4001D13")]
		[FieldOffset(Offset = "0x98")]
		private Transform targetTransform;

		[Token(Token = "0x600122A")]
		[Address(RVA = "0x99C11C", Offset = "0x99C11C", Length = "0x60")]
		public override void Reset()
		{
			gameObject = null;
			targetObject = null;
			FsmFloat fsmFloat = 10f;
			distance = fsmFloat;
			FsmFloat fsmFloat2 = 5f;
			height = fsmFloat2;
			FsmFloat fsmFloat3 = 2f;
			heightDamping = fsmFloat3;
			FsmFloat fsmFloat4 = 3f;
			rotationDamping = fsmFloat4;
		}

		[Token(Token = "0x600122B")]
		[Address(RVA = "0x99C17C", Offset = "0x99C17C", Length = "0x20")]
		public override void OnPreprocess()
		{
			Fsm.HandleLateUpdate = true;
		}

		[Token(Token = "0x600122C")]
		[Address(RVA = "0x99C19C", Offset = "0x99C19C", Length = "0x468")]
		public override void OnLateUpdate()
		{
			//IL_01bd: Expected O, but got I
			//IL_017a: Expected O, but got I
			//IL_03cd: Expected O, but got I4
			//IL_03f7: Expected F4, but got O
			GameObject value = targetObject.Value;
			if (value == null)
			{
				return;
			}
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (ownerDefaultTarget == null)
			{
				return;
			}
			if (cachedObject != ownerDefaultTarget)
			{
				cachedObject = ownerDefaultTarget;
				Transform transform = ownerDefaultTarget.transform;
				myTransform = transform;
			}
			GameObject value2 = targetObject.Value;
			Transform transform2;
			object obj;
			if (cachedTarget != value2)
			{
				transform2 = (cachedTarget = targetObject.Value).transform;
				obj = (long)(IntPtr)this + 152L;
				targetTransform = transform2;
				if ((object)transform2 == null)
				{
					throw new NullReferenceException();
				}
			}
			else
			{
				obj = (long)(IntPtr)this + 152L;
				transform2 = targetTransform;
			}
			Vector3 eulerAngles = transform2.eulerAngles;
			Vector3 position = ((Transform)obj).position;
			float value3 = height.Value;
			Vector3 eulerAngles2 = myTransform.eulerAngles;
			Vector3 position2 = myTransform.position;
			float value4 = rotationDamping.Value;
			float deltaTime = Time.deltaTime;
			float t = value4 * deltaTime;
			float y = Mathf.LerpAngle(eulerAngles2.y, eulerAngles.y, t);
			float b = position.y + value3;
			float value5 = heightDamping.Value;
			float deltaTime2 = Time.deltaTime;
			float t2 = value5 * deltaTime2;
			float num = Mathf.Lerp(position2.y, b, t2);
			Quaternion quaternion = Quaternion.Euler(0f, y, 0f);
			Vector3 position3 = targetTransform.position;
			myTransform.position = position3;
			Vector3 position4 = myTransform.position;
			Vector3 forward = Vector3.forward;
			Vector3 vector = quaternion * forward;
			float value6 = distance.Value;
			Vector3 vector2 = vector * value6;
			Vector3 position5 = position4 - vector2;
			myTransform.position = position5;
			Vector3 position6 = myTransform.position;
			Vector3 position7 = myTransform.position;
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			Vector3 position8 = default(Vector3);
			position8.x = 0f;
			object obj3 = default(object);
			position8.y = (float)obj3;
			position8.z = 0f;
			myTransform.position = position8;
			myTransform.LookAt((Transform)obj);
		}

		[Token(Token = "0x600122D")]
		[Address(RVA = "0x99C604", Offset = "0x99C604", Length = "0x8")]
		public SmoothFollowAction()
		{
		}
	}
}
