using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75FD2C", Offset = "0x75FD2C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75FD2C", Offset = "0x75FD2C")]
	[Token(Token = "0x2000397")]
	public class GetAngleToTarget : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CD3E0", Offset = "0x7CD3E0")]
		[Token(Token = "0x4001CA3")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CD42C", Offset = "0x7CD42C")]
		[Token(Token = "0x4001CA4")]
		[FieldOffset(Offset = "0x58")]
		public FsmGameObject targetObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CD464", Offset = "0x7CD464")]
		[Token(Token = "0x4001CA5")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector3 targetPosition;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CD49C", Offset = "0x7CD49C")]
		[Token(Token = "0x4001CA6")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool ignoreHeight;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7CD4D4", Offset = "0x7CD4D4")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CD4D4", Offset = "0x7CD4D4")]
		[Token(Token = "0x4001CA7")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat storeAngle;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CD534", Offset = "0x7CD534")]
		[Token(Token = "0x4001CA8")]
		[FieldOffset(Offset = "0x78")]
		public bool everyFrame;

		[Token(Token = "0x60011D7")]
		[Address(RVA = "0xB7D79C", Offset = "0xB7D79C", Length = "0x8C")]
		public override void Reset()
		{
			gameObject = null;
			targetObject = null;
			FsmVector3 fsmVector = new FsmVector3();
			fsmVector.useVariable = true;
			targetPosition = fsmVector;
			FsmBool fsmBool = true;
			ignoreHeight = fsmBool;
			storeAngle = null;
			everyFrame = false;
		}

		[Token(Token = "0x60011D8")]
		[Address(RVA = "0xB7D828", Offset = "0xB7D828", Length = "0x20")]
		public override void OnPreprocess()
		{
			Fsm.HandleLateUpdate = true;
		}

		[Token(Token = "0x60011D9")]
		[Address(RVA = "0xB7D848", Offset = "0xB7D848", Length = "0x3C")]
		public override void OnLateUpdate()
		{
			DoGetAngleToTarget();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60011DA")]
		[Address(RVA = "0xB7D884", Offset = "0xB7D884", Length = "0x2B0")]
		private void DoGetAngleToTarget()
		{
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
			Vector3 vector;
			float y;
			float z;
			if (value != null)
			{
				bool isNone = targetPosition.IsNone;
				Transform transform = value.transform;
				if (isNone)
				{
					vector = transform.position;
					y = vector.y;
					z = vector.z;
				}
				else
				{
					Vector3 value2 = targetPosition.Value;
					vector = transform.TransformPoint(value2);
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
			if (ignoreHeight.Value)
			{
				Transform transform2 = ownerDefaultTarget.transform;
				y2 = transform2.position.y;
			}
			else
			{
				y2 = y;
			}
			Transform transform3 = ownerDefaultTarget.transform;
			Vector3 position = transform3.position;
			Vector3 vector2 = default(Vector3);
			vector2.x = vector.x;
			vector2.y = y2;
			vector2.z = z;
			Vector3 vector3 = vector2 - position;
			FsmFloat fsmFloat = storeAngle;
			Transform transform4 = ownerDefaultTarget.transform;
			Vector3 forward = transform4.forward;
			float value3 = Vector3.Angle(vector3, forward);
			fsmFloat.Value = value3;
		}

		[Token(Token = "0x60011DB")]
		[Address(RVA = "0xB7DB34", Offset = "0xB7DB34", Length = "0x8")]
		public GetAngleToTarget()
		{
		}
	}
}
