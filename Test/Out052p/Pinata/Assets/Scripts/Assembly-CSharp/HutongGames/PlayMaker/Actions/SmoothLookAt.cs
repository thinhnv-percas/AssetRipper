using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x760200", Offset = "0x760200")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x760200", Offset = "0x760200")]
	[Token(Token = "0x20003A6")]
	public class SmoothLookAt : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CE3DC", Offset = "0x7CE3DC")]
		[Token(Token = "0x4001D14")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CE428", Offset = "0x7CE428")]
		[Token(Token = "0x4001D15")]
		[FieldOffset(Offset = "0x58")]
		public FsmGameObject targetObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CE460", Offset = "0x7CE460")]
		[Token(Token = "0x4001D16")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector3 targetPosition;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CE498", Offset = "0x7CE498")]
		[Token(Token = "0x4001D17")]
		[FieldOffset(Offset = "0x68")]
		public FsmVector3 upVector;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CE4D0", Offset = "0x7CE4D0")]
		[Token(Token = "0x4001D18")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool keepVertical;

		[Attribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7CE508", Offset = "0x7CE508")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CE508", Offset = "0x7CE508")]
		[Token(Token = "0x4001D19")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat speed;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CE55C", Offset = "0x7CE55C")]
		[Token(Token = "0x4001D1A")]
		[FieldOffset(Offset = "0x80")]
		public FsmBool debug;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CE594", Offset = "0x7CE594")]
		[Token(Token = "0x4001D1B")]
		[FieldOffset(Offset = "0x88")]
		public FsmFloat finishTolerance;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CE5CC", Offset = "0x7CE5CC")]
		[Token(Token = "0x4001D1C")]
		[FieldOffset(Offset = "0x90")]
		public FsmEvent finishEvent;

		[Token(Token = "0x4001D1D")]
		[FieldOffset(Offset = "0x98")]
		private GameObject previousGo;

		[Token(Token = "0x4001D1E")]
		[FieldOffset(Offset = "0xA0")]
		private Quaternion lastRotation;

		[Token(Token = "0x4001D1F")]
		[FieldOffset(Offset = "0xB0")]
		private Quaternion desiredRotation;

		[Token(Token = "0x600122E")]
		[Address(RVA = "0x99C60C", Offset = "0x99C60C", Length = "0xE0")]
		public override void Reset()
		{
			gameObject = null;
			targetObject = null;
			FsmVector3 fsmVector = new FsmVector3();
			fsmVector.useVariable = true;
			targetPosition = fsmVector;
			FsmVector3 fsmVector2 = new FsmVector3();
			fsmVector2.useVariable = true;
			upVector = fsmVector2;
			FsmBool fsmBool = true;
			keepVertical = fsmBool;
			FsmBool fsmBool2 = false;
			debug = fsmBool2;
			FsmFloat fsmFloat = 5f;
			speed = fsmFloat;
			FsmFloat fsmFloat2 = 1f;
			finishTolerance = fsmFloat2;
			finishEvent = null;
		}

		[Token(Token = "0x600122F")]
		[Address(RVA = "0x99C6EC", Offset = "0x99C6EC", Length = "0x20")]
		public override void OnPreprocess()
		{
			Fsm.HandleLateUpdate = true;
		}

		[Token(Token = "0x6001230")]
		[Address(RVA = "0x99C70C", Offset = "0x99C70C", Length = "0x8")]
		public override void OnEnter()
		{
			previousGo = null;
		}

		[Token(Token = "0x6001231")]
		[Address(RVA = "0x99C714", Offset = "0x99C714", Length = "0x4")]
		public override void OnLateUpdate()
		{
			DoSmoothLookAt();
		}

		[Token(Token = "0x6001232")]
		[Address(RVA = "0x99C718", Offset = "0x99C718", Length = "0x640")]
		private void DoSmoothLookAt()
		{
			//IL_0726: Expected O, but got I
			//IL_04bf: Expected F4, but got O
			//IL_084d: Expected F4, but got O
			//IL_0862: Expected F4, but got I
			//IL_0799: Expected O, but got I
			//IL_07c0: Expected F4, but got I
			//IL_07d5: Expected F4, but got I
			object obj2 = default(object);
			object obj = obj2;
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (ownerDefaultTarget == null)
			{
				return;
			}
			GameObject value = targetObject.Value;
			if (value == null && targetPosition.IsNone)
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
			Vector3 vector;
			float y;
			float z;
			if (value != null)
			{
				bool isNone = targetPosition.IsNone;
				Transform transform2 = value.transform;
				if (isNone)
				{
					vector = transform2.position;
					y = vector.y;
					z = vector.z;
				}
				else
				{
					Vector3 value2 = targetPosition.Value;
					vector = transform2.TransformPoint(value2);
					y = vector.y;
					z = vector.z;
				}
			}
			else
			{
				vector = targetPosition.Value;
				y = vector.y;
				z = vector.z;
			}
			float y2;
			if (keepVertical.Value)
			{
				Transform transform3 = ownerDefaultTarget.transform;
				y2 = transform3.position.y;
			}
			else
			{
				y2 = y;
			}
			Transform transform4 = ownerDefaultTarget.transform;
			Vector3 position = transform4.position;
			Vector3 vector2 = default(Vector3);
			vector2.x = vector.x;
			vector2.y = y2;
			vector2.z = z;
			Vector3 vector3 = vector2 - position;
			Vector3 zero = Vector3.zero;
			bool flag = vector3 != zero;
			bool flag2 = !flag;
			float num = z;
			Vector3 vector4 = vector;
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158AB88 (inside UnityEngine.Vector3::Angle +0x184)");
				bool flag3 = !(vector3.x > 0f);
				num = z;
				vector4 = vector;
				if (!flag3)
				{
					Vector3 vector5;
					float y3;
					float z2;
					if (upVector.IsNone)
					{
						vector5 = Vector3.up;
						y3 = vector5.y;
						z2 = vector5.z;
					}
					else
					{
						vector5 = upVector.Value;
						y3 = vector5.y;
						z2 = vector5.z;
					}
					Vector3 forward = default(Vector3);
					object obj3 = default(object);
					forward.x = (float)obj3;
					forward.y = vector3.y;
					forward.z = vector3.z;
					Vector3 upwards = default(Vector3);
					upwards.x = vector5.x;
					upwards.y = y3;
					upwards.z = z2;
					Quaternion quaternion2 = (desiredRotation = Quaternion.LookRotation(forward, upwards));
					desiredRotation.y = quaternion2.y;
					desiredRotation.z = quaternion2.z;
					desiredRotation.w = quaternion2.w;
					num = z;
					vector4 = vector;
				}
			}
			float value3 = speed.Value;
			float deltaTime = Time.deltaTime;
			float t = value3 * deltaTime;
			Quaternion a = default(Quaternion);
			a.x = lastRotation.x;
			a.y = lastRotation.y;
			a.z = lastRotation.z;
			a.w = lastRotation.w;
			Quaternion b = default(Quaternion);
			b.x = desiredRotation.x;
			b.y = desiredRotation.y;
			b.z = desiredRotation.z;
			b.w = desiredRotation.w;
			Quaternion quaternion3 = (lastRotation = Quaternion.Slerp(a, b, t));
			lastRotation.y = quaternion3.y;
			lastRotation.z = quaternion3.z;
			lastRotation.w = quaternion3.w;
			Transform transform5 = ownerDefaultTarget.transform;
			Quaternion rotation = default(Quaternion);
			rotation.x = lastRotation.x;
			rotation.y = lastRotation.y;
			rotation.z = lastRotation.z;
			rotation.w = lastRotation.w;
			transform5.rotation = rotation;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X29_v1-24]");
			object obj4 = 0;
			if (debug.Value)
			{
				Transform transform6 = ownerDefaultTarget.transform;
				Vector3 position2 = transform6.position;
				Color grey = Color.grey;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X29_v1-24]");
				obj4 = 0;
				Vector3 end = default(Vector3);
				end.x = vector4.x;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X29_v1-24]");
				end.y = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X29_v1-28]");
				end.z = 0f;
				Debug.DrawLine(position2, end, grey);
			}
			if (finishEvent != null)
			{
				Transform transform7 = ownerDefaultTarget.transform;
				Vector3 position3 = transform7.position;
				Vector3 vector6 = default(Vector3);
				vector6.x = vector4.x;
				vector6.y = (float)obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X29_v1-28]");
				vector6.z = 0f;
				Vector3 vector7 = vector6 - position3;
				Transform transform8 = ownerDefaultTarget.transform;
				Vector3 forward2 = transform8.forward;
				float f = Vector3.Angle(vector7, forward2);
				float num2 = Mathf.Abs(f);
				float value4 = finishTolerance.Value;
				bool flag4 = num2 < value4;
				bool flag5 = !flag4;
				float num3 = num2 - value4;
				bool flag6 = num3 == 0f;
				bool flag7 = !flag6;
				if (!(flag5 && flag7))
				{
					Fsm.Event(finishEvent);
				}
			}
		}

		[Token(Token = "0x6001233")]
		[Address(RVA = "0x99CD58", Offset = "0x99CD58", Length = "0x8")]
		public SmoothLookAt()
		{
		}
	}
}
