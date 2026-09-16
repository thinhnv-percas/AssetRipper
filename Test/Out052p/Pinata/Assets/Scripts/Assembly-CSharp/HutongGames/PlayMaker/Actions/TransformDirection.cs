using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7602A0", Offset = "0x7602A0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7602A0", Offset = "0x7602A0")]
	[Token(Token = "0x20003A8")]
	public class TransformDirection : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x4001D2C")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Token(Token = "0x4001D2D")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector3 localDirection;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7CE884", Offset = "0x7CE884")]
		[Token(Token = "0x4001D2E")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector3 storeResult;

		[Token(Token = "0x4001D2F")]
		[FieldOffset(Offset = "0x68")]
		public bool everyFrame;

		[Token(Token = "0x600123B")]
		[Address(RVA = "0x9A092C", Offset = "0x9A092C", Length = "0x10")]
		public override void Reset()
		{
			everyFrame = false;
			localDirection = null;
			storeResult = null;
			gameObject = null;
		}

		[Token(Token = "0x600123C")]
		[Address(RVA = "0x9A093C", Offset = "0x9A093C", Length = "0x3C")]
		public override void OnEnter()
		{
			DoTransformDirection();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x600123D")]
		[Address(RVA = "0x9A0A64", Offset = "0x9A0A64", Length = "0x4")]
		public override void OnUpdate()
		{
			DoTransformDirection();
		}

		[Token(Token = "0x600123E")]
		[Address(RVA = "0x9A0978", Offset = "0x9A0978", Length = "0xEC")]
		private void DoTransformDirection()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null))
			{
				FsmVector3 fsmVector = storeResult;
				Transform transform = ownerDefaultTarget.transform;
				Vector3 value = localDirection.Value;
				Vector3 vector = (fsmVector.value = transform.TransformDirection(value));
				fsmVector.value.y = vector.y;
				fsmVector.value.z = vector.z;
			}
		}

		[Token(Token = "0x600123F")]
		[Address(RVA = "0x9A0A68", Offset = "0x9A0A68", Length = "0x8")]
		public TransformDirection()
		{
		}
	}
}
