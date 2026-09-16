using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75FDCC", Offset = "0x75FDCC")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75FDCC", Offset = "0x75FDCC")]
	[Token(Token = "0x2000399")]
	public class GetRotation : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x4001CB0")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7CD5DC", Offset = "0x7CD5DC")]
		[Token(Token = "0x4001CB1")]
		[FieldOffset(Offset = "0x58")]
		public FsmQuaternion quaternion;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7CD5F0", Offset = "0x7CD5F0")]
		[Attribute(Type = typeof(TitleAttribute), RVA = "0x7CD5F0", Offset = "0x7CD5F0")]
		[Token(Token = "0x4001CB2")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector3 vector;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7CD640", Offset = "0x7CD640")]
		[Token(Token = "0x4001CB3")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat xAngle;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7CD654", Offset = "0x7CD654")]
		[Token(Token = "0x4001CB4")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat yAngle;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7CD668", Offset = "0x7CD668")]
		[Token(Token = "0x4001CB5")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat zAngle;

		[Token(Token = "0x4001CB6")]
		[FieldOffset(Offset = "0x80")]
		public Space space;

		[Token(Token = "0x4001CB7")]
		[FieldOffset(Offset = "0x84")]
		public bool everyFrame;

		[Token(Token = "0x60011E1")]
		[Address(RVA = "0xA33D8C", Offset = "0xA33D8C", Length = "0x14")]
		public override void Reset()
		{
			_ = 0;
			vector = null;
			yAngle = null;
			gameObject = null;
		}

		[Token(Token = "0x60011E2")]
		[Address(RVA = "0xA33DA0", Offset = "0xA33DA0", Length = "0x3C")]
		public override void OnEnter()
		{
			DoGetRotation();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60011E3")]
		[Address(RVA = "0xA33FAC", Offset = "0xA33FAC", Length = "0x4")]
		public override void OnUpdate()
		{
			DoGetRotation();
		}

		[Token(Token = "0x60011E4")]
		[Address(RVA = "0xA33DDC", Offset = "0xA33DDC", Length = "0x1D0")]
		private void DoGetRotation()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null))
			{
				float z;
				if (space != Space.World)
				{
					Transform transform = ownerDefaultTarget.transform;
					Vector3 localEulerAngles = transform.localEulerAngles;
					FsmQuaternion fsmQuaternion = this.quaternion;
					Quaternion quaternion = (fsmQuaternion.value = Quaternion.Euler(localEulerAngles));
					fsmQuaternion.value.y = quaternion.y;
					fsmQuaternion.value.z = quaternion.z;
					fsmQuaternion.value.w = quaternion.w;
					FsmVector3 fsmVector = vector;
					fsmVector.value = localEulerAngles;
					fsmVector.value.y = localEulerAngles.y;
					fsmVector.value.z = localEulerAngles.z;
					FsmFloat fsmFloat = xAngle;
					fsmFloat.Value = localEulerAngles.x;
					FsmFloat fsmFloat2 = yAngle;
					fsmFloat2.Value = localEulerAngles.y;
					z = localEulerAngles.z;
				}
				else
				{
					FsmQuaternion fsmQuaternion2 = this.quaternion;
					Transform transform2 = ownerDefaultTarget.transform;
					Quaternion quaternion2 = (fsmQuaternion2.value = transform2.rotation);
					fsmQuaternion2.value.y = quaternion2.y;
					fsmQuaternion2.value.z = quaternion2.z;
					fsmQuaternion2.value.w = quaternion2.w;
					Transform transform3 = ownerDefaultTarget.transform;
					Vector3 eulerAngles = transform3.eulerAngles;
					FsmVector3 fsmVector2 = vector;
					fsmVector2.value = eulerAngles;
					fsmVector2.value.y = eulerAngles.y;
					fsmVector2.value.z = eulerAngles.z;
					FsmFloat fsmFloat3 = xAngle;
					fsmFloat3.Value = eulerAngles.x;
					FsmFloat fsmFloat4 = yAngle;
					fsmFloat4.Value = eulerAngles.y;
					z = eulerAngles.z;
				}
				FsmFloat fsmFloat5 = zAngle;
				fsmFloat5.Value = z;
			}
		}

		[Token(Token = "0x60011E5")]
		[Address(RVA = "0xA33FB0", Offset = "0xA33FB0", Length = "0x8")]
		public GetRotation()
		{
		}
	}
}
