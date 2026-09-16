using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75FEBC", Offset = "0x75FEBC")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75FEBC", Offset = "0x75FEBC")]
	[Token(Token = "0x200039C")]
	public class InverseTransformPoint : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x4001CC3")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Token(Token = "0x4001CC4")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector3 worldPosition;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7CD758", Offset = "0x7CD758")]
		[Token(Token = "0x4001CC5")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector3 storeResult;

		[Token(Token = "0x4001CC6")]
		[FieldOffset(Offset = "0x68")]
		public bool everyFrame;

		[Token(Token = "0x60011F0")]
		[Address(RVA = "0xA38ABC", Offset = "0xA38ABC", Length = "0x10")]
		public override void Reset()
		{
			everyFrame = false;
			worldPosition = null;
			storeResult = null;
			gameObject = null;
		}

		[Token(Token = "0x60011F1")]
		[Address(RVA = "0xA38ACC", Offset = "0xA38ACC", Length = "0x3C")]
		public override void OnEnter()
		{
			DoInverseTransformPoint();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60011F2")]
		[Address(RVA = "0xA38BF4", Offset = "0xA38BF4", Length = "0x4")]
		public override void OnUpdate()
		{
			DoInverseTransformPoint();
		}

		[Token(Token = "0x60011F3")]
		[Address(RVA = "0xA38B08", Offset = "0xA38B08", Length = "0xEC")]
		private void DoInverseTransformPoint()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null))
			{
				FsmVector3 fsmVector = storeResult;
				Transform transform = ownerDefaultTarget.transform;
				Vector3 value = worldPosition.Value;
				Vector3 vector = (fsmVector.value = transform.InverseTransformPoint(value));
				fsmVector.value.y = vector.y;
				fsmVector.value.z = vector.z;
			}
		}

		[Token(Token = "0x60011F4")]
		[Address(RVA = "0xA38BF8", Offset = "0xA38BF8", Length = "0x8")]
		public InverseTransformPoint()
		{
		}
	}
}
