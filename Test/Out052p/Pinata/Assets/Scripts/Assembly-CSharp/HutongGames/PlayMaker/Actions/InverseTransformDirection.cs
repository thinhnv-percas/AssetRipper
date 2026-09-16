using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75FE6C", Offset = "0x75FE6C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75FE6C", Offset = "0x75FE6C")]
	[Token(Token = "0x200039B")]
	public class InverseTransformDirection : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x4001CBF")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Token(Token = "0x4001CC0")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector3 worldDirection;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7CD6FC", Offset = "0x7CD6FC")]
		[Token(Token = "0x4001CC1")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector3 storeResult;

		[Token(Token = "0x4001CC2")]
		[FieldOffset(Offset = "0x68")]
		public bool everyFrame;

		[Token(Token = "0x60011EB")]
		[Address(RVA = "0xA38978", Offset = "0xA38978", Length = "0x10")]
		public override void Reset()
		{
			everyFrame = false;
			worldDirection = null;
			storeResult = null;
			gameObject = null;
		}

		[Token(Token = "0x60011EC")]
		[Address(RVA = "0xA38988", Offset = "0xA38988", Length = "0x3C")]
		public override void OnEnter()
		{
			DoInverseTransformDirection();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60011ED")]
		[Address(RVA = "0xA38AB0", Offset = "0xA38AB0", Length = "0x4")]
		public override void OnUpdate()
		{
			DoInverseTransformDirection();
		}

		[Token(Token = "0x60011EE")]
		[Address(RVA = "0xA389C4", Offset = "0xA389C4", Length = "0xEC")]
		private void DoInverseTransformDirection()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null))
			{
				FsmVector3 fsmVector = storeResult;
				Transform transform = ownerDefaultTarget.transform;
				Vector3 value = worldDirection.Value;
				Vector3 vector = (fsmVector.value = transform.InverseTransformDirection(value));
				fsmVector.value.y = vector.y;
				fsmVector.value.z = vector.z;
			}
		}

		[Token(Token = "0x60011EF")]
		[Address(RVA = "0xA38AB4", Offset = "0xA38AB4", Length = "0x8")]
		public InverseTransformDirection()
		{
		}
	}
}
