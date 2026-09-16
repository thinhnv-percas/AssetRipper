using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75FFD0", Offset = "0x75FFD0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75FFD0", Offset = "0x75FFD0")]
	[Token(Token = "0x200039F")]
	public class MoveTowards : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CD9B0", Offset = "0x7CD9B0")]
		[Token(Token = "0x4001CD9")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CD9FC", Offset = "0x7CD9FC")]
		[Token(Token = "0x4001CDA")]
		[FieldOffset(Offset = "0x58")]
		public FsmGameObject targetObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CDA34", Offset = "0x7CDA34")]
		[Token(Token = "0x4001CDB")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector3 targetPosition;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CDA6C", Offset = "0x7CDA6C")]
		[Token(Token = "0x4001CDC")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool ignoreVertical;

		[Attribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7CDAA4", Offset = "0x7CDAA4")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CDAA4", Offset = "0x7CDAA4")]
		[Token(Token = "0x4001CDD")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat maxSpeed;

		[Attribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7CDAF8", Offset = "0x7CDAF8")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CDAF8", Offset = "0x7CDAF8")]
		[Token(Token = "0x4001CDE")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat finishDistance;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CDB4C", Offset = "0x7CDB4C")]
		[Token(Token = "0x4001CDF")]
		[FieldOffset(Offset = "0x80")]
		public FsmEvent finishEvent;

		[Token(Token = "0x4001CE0")]
		[FieldOffset(Offset = "0x88")]
		private GameObject go;

		[Token(Token = "0x4001CE1")]
		[FieldOffset(Offset = "0x90")]
		private GameObject goTarget;

		[Token(Token = "0x4001CE2")]
		[FieldOffset(Offset = "0x98")]
		private Vector3 targetPos;

		[Token(Token = "0x4001CE3")]
		[FieldOffset(Offset = "0xA4")]
		private Vector3 targetPosWithVertical;

		[Token(Token = "0x6001202")]
		[Address(RVA = "0xB188BC", Offset = "0xB188BC", Length = "0x40")]
		public override void Reset()
		{
			gameObject = null;
			targetObject = null;
			FsmFloat fsmFloat = 10f;
			maxSpeed = fsmFloat;
			FsmFloat fsmFloat2 = 1f;
			finishDistance = fsmFloat2;
			finishEvent = null;
		}

		[Token(Token = "0x6001203")]
		[Address(RVA = "0xB188FC", Offset = "0xB188FC", Length = "0x4")]
		public override void OnUpdate()
		{
			DoMoveTowards();
		}

		[Token(Token = "0x6001204")]
		[Address(RVA = "0xB18900", Offset = "0xB18900", Length = "0x1C0")]
		private void DoMoveTowards()
		{
			if (UpdateTargetPos())
			{
				Transform transform = go.transform;
				Transform transform2 = go.transform;
				Vector3 position = transform2.position;
				float value = maxSpeed.Value;
				float deltaTime = Time.deltaTime;
				float maxDistanceDelta = value * deltaTime;
				Vector3 target = default(Vector3);
				target.x = targetPos.x;
				target.y = targetPos.y;
				target.z = targetPos.z;
				position = Vector3.MoveTowards(position, target, maxDistanceDelta);
				transform.position = position;
				Transform transform3 = go.transform;
				position = transform3.position;
				Vector3 vector = default(Vector3);
				vector.x = targetPos.x;
				vector.y = targetPos.y;
				vector.z = targetPos.z;
				position -= vector;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158AD58 (inside UnityEngine.Vector3::ClampMagnitude +0xDC)");
				float value2 = finishDistance.Value;
				if (position.x < value2)
				{
					Fsm.Event(finishEvent);
					Finish();
				}
			}
		}

		[Token(Token = "0x6001205")]
		[Address(RVA = "0xB18AC0", Offset = "0xB18AC0", Length = "0x1F0")]
		public bool UpdateTargetPos()
		{
			if ((go = Fsm.GetOwnerDefaultTarget(gameObject)) == null || ((goTarget = targetObject.Value) == null && targetPosition.IsNone))
			{
				return false;
			}
			Vector3 vector;
			float y;
			float z;
			if (goTarget != null)
			{
				bool isNone = targetPosition.IsNone;
				Transform transform = goTarget.transform;
				if (isNone)
				{
					vector = transform.position;
					y = vector.y;
					z = vector.z;
				}
				else
				{
					Vector3 value = targetPosition.Value;
					vector = transform.TransformPoint(value);
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
			targetPos = vector;
			targetPos.y = y;
			targetPos.z = z;
			targetPosWithVertical = vector;
			targetPosWithVertical.y = y;
			targetPosWithVertical.z = z;
			if (ignoreVertical.Value)
			{
				Transform transform2 = go.transform;
				Vector3 position = transform2.position;
				targetPos.y = position.y;
			}
			return true;
		}

		[Token(Token = "0x6001206")]
		[Address(RVA = "0xB18CB0", Offset = "0xB18CB0", Length = "0xC")]
		public Vector3 GetTargetPos()
		{
			return targetPos;
		}

		[Token(Token = "0x6001207")]
		[Address(RVA = "0xB18CBC", Offset = "0xB18CBC", Length = "0xC")]
		public Vector3 GetTargetPosWithVertical()
		{
			return targetPosWithVertical;
		}

		[Token(Token = "0x6001208")]
		[Address(RVA = "0xB18CC8", Offset = "0xB18CC8", Length = "0x8")]
		public MoveTowards()
		{
		}
	}
}
