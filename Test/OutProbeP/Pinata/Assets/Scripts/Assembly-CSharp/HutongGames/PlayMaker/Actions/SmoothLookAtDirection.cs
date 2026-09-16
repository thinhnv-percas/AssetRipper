using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x760250", Offset = "0x760250")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x760250", Offset = "0x760250")]
	[Token(Token = "0x20003A7")]
	public class SmoothLookAtDirection : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CE604", Offset = "0x7CE604")]
		[Token(Token = "0x4001D20")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CE650", Offset = "0x7CE650")]
		[Token(Token = "0x4001D21")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector3 targetDirection;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CE69C", Offset = "0x7CE69C")]
		[Token(Token = "0x4001D22")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat minMagnitude;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CE6D4", Offset = "0x7CE6D4")]
		[Token(Token = "0x4001D23")]
		[FieldOffset(Offset = "0x68")]
		public FsmVector3 upVector;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CE70C", Offset = "0x7CE70C")]
		[Token(Token = "0x4001D24")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool keepVertical;

		[RequiredField]
		[Attribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7CE758", Offset = "0x7CE758")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CE758", Offset = "0x7CE758")]
		[Token(Token = "0x4001D25")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat speed;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CE7BC", Offset = "0x7CE7BC")]
		[Token(Token = "0x4001D26")]
		[FieldOffset(Offset = "0x80")]
		public bool lateUpdate;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CE7F4", Offset = "0x7CE7F4")]
		[Token(Token = "0x4001D27")]
		[FieldOffset(Offset = "0x88")]
		public FsmEvent finishEvent;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CE82C", Offset = "0x7CE82C")]
		[Token(Token = "0x4001D28")]
		[FieldOffset(Offset = "0x90")]
		public FsmBool finish;

		[Token(Token = "0x4001D29")]
		[FieldOffset(Offset = "0x98")]
		private GameObject previousGo;

		[Token(Token = "0x4001D2A")]
		[FieldOffset(Offset = "0xA0")]
		private Quaternion lastRotation;

		[Token(Token = "0x4001D2B")]
		[FieldOffset(Offset = "0xB0")]
		private Quaternion desiredRotation;

		[Token(Token = "0x6001234")]
		[Address(RVA = "0x99D568", Offset = "0x99D568", Length = "0xDC")]
		public override void Reset()
		{
			gameObject = null;
			FsmVector3 fsmVector = new FsmVector3();
			fsmVector.useVariable = true;
			targetDirection = fsmVector;
			FsmFloat fsmFloat = 0.1f;
			minMagnitude = fsmFloat;
			FsmVector3 fsmVector2 = new FsmVector3();
			fsmVector2.useVariable = true;
			upVector = fsmVector2;
			FsmBool fsmBool = true;
			keepVertical = fsmBool;
			FsmFloat fsmFloat2 = 5f;
			speed = fsmFloat2;
			lateUpdate = true;
			finishEvent = null;
		}

		[Token(Token = "0x6001235")]
		[Address(RVA = "0x99D644", Offset = "0x99D644", Length = "0x20")]
		public override void OnPreprocess()
		{
			Fsm.HandleLateUpdate = true;
		}

		[Token(Token = "0x6001236")]
		[Address(RVA = "0x99D664", Offset = "0x99D664", Length = "0x8")]
		public override void OnEnter()
		{
			previousGo = null;
		}

		[Token(Token = "0x6001237")]
		[Address(RVA = "0x99D66C", Offset = "0x99D66C", Length = "0x10")]
		public override void OnUpdate()
		{
			if (!lateUpdate)
			{
				DoSmoothLookAtDirection();
			}
		}

		[Token(Token = "0x6001238")]
		[Address(RVA = "0x99D9D4", Offset = "0x99D9D4", Length = "0x10")]
		public override void OnLateUpdate()
		{
			if (lateUpdate)
			{
				DoSmoothLookAtDirection();
			}
		}

		[Token(Token = "0x6001239")]
		[Address(RVA = "0x99D67C", Offset = "0x99D67C", Length = "0x358")]
		private void DoSmoothLookAtDirection()
		{
			//IL_045f: Expected F4, but got I
			//IL_0474: Expected F4, but got I
			//IL_02e6: Expected F4, but got O
			object obj2 = default(object);
			object obj = obj2;
			if (targetDirection.IsNone)
			{
				return;
			}
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (ownerDefaultTarget == null)
			{
				return;
			}
			if (previousGo != ownerDefaultTarget)
			{
				Transform transform = ownerDefaultTarget.transform;
				Quaternion quaternion = (lastRotation = transform.rotation);
				lastRotation.y = quaternion.y;
				lastRotation.z = quaternion.z;
				lastRotation.w = quaternion.w;
				desiredRotation = quaternion;
				desiredRotation.y = quaternion.y;
				desiredRotation.z = quaternion.z;
				desiredRotation.w = quaternion.w;
				previousGo = ownerDefaultTarget;
			}
			Vector3 value = targetDirection.Value;
			bool value2 = keepVertical.Value;
			bool flag = !value2;
			float y = value.y;
			if (!flag)
			{
				y = 0f;
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158AB88 (inside UnityEngine.Vector3::Angle +0x184)");
			float value3 = minMagnitude.Value;
			float w;
			float z2;
			int num;
			if (value.x > value3)
			{
				Vector3 vector;
				float y2;
				float z;
				if (upVector.IsNone)
				{
					vector = Vector3.up;
					y2 = vector.y;
					z = vector.z;
				}
				else
				{
					vector = upVector.Value;
					y2 = vector.y;
					z = vector.z;
				}
				Vector3 forward = default(Vector3);
				object obj3 = default(object);
				forward.x = (float)obj3;
				forward.y = y;
				forward.z = value.z;
				Vector3 upwards = default(Vector3);
				upwards.x = vector.x;
				upwards.y = y2;
				upwards.z = z;
				Quaternion quaternion2 = Quaternion.LookRotation(forward, upwards);
				desiredRotation.x = quaternion2.x;
				_ = quaternion2.y;
				desiredRotation.y = quaternion2.y;
				desiredRotation.z = quaternion2.z;
				desiredRotation.w = quaternion2.w;
				w = quaternion2.w;
				z2 = quaternion2.z;
				num = 0;
			}
			else
			{
				_ = desiredRotation;
				_ = desiredRotation.y;
				z2 = desiredRotation.z;
				w = desiredRotation.w;
				num = 1;
			}
			float value4 = speed.Value;
			float deltaTime = Time.deltaTime;
			float t = value4 * deltaTime;
			Quaternion a = default(Quaternion);
			a.x = lastRotation.x;
			a.y = lastRotation.y;
			a.z = lastRotation.z;
			a.w = lastRotation.w;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v26 @ X29_v1-14]");
			Quaternion b = default(Quaternion);
			b.x = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v26 @ X29_v1-18]");
			b.y = 0f;
			b.z = z2;
			b.w = w;
			Quaternion quaternion3 = (lastRotation = Quaternion.Slerp(a, b, t));
			lastRotation.y = quaternion3.y;
			lastRotation.z = quaternion3.z;
			lastRotation.w = quaternion3.w;
			Transform transform2 = ownerDefaultTarget.transform;
			Quaternion rotation = default(Quaternion);
			rotation.x = lastRotation.x;
			rotation.y = lastRotation.y;
			rotation.z = lastRotation.z;
			rotation.w = lastRotation.w;
			transform2.rotation = rotation;
			if (num != 0)
			{
				Fsm.Event(finishEvent);
				if (finish.Value)
				{
					Finish();
				}
			}
		}

		[Token(Token = "0x600123A")]
		[Address(RVA = "0x99D9E4", Offset = "0x99D9E4", Length = "0x8")]
		public SmoothLookAtDirection()
		{
		}
	}
}
