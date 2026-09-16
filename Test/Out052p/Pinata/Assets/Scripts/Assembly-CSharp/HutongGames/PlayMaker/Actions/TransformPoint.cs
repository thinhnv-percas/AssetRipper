using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7602F0", Offset = "0x7602F0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7602F0", Offset = "0x7602F0")]
	[Token(Token = "0x20003A9")]
	public class TransformPoint : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x4001D30")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Token(Token = "0x4001D31")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector3 localPosition;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7CE8E0", Offset = "0x7CE8E0")]
		[Token(Token = "0x4001D32")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector3 storeResult;

		[Token(Token = "0x4001D33")]
		[FieldOffset(Offset = "0x68")]
		public bool everyFrame;

		[Token(Token = "0x6001240")]
		[Address(RVA = "0x9A0EA8", Offset = "0x9A0EA8", Length = "0x10")]
		public override void Reset()
		{
			everyFrame = false;
			localPosition = null;
			storeResult = null;
			gameObject = null;
		}

		[Token(Token = "0x6001241")]
		[Address(RVA = "0x9A0EB8", Offset = "0x9A0EB8", Length = "0x3C")]
		public override void OnEnter()
		{
			DoTransformPoint();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001242")]
		[Address(RVA = "0x9A0FE0", Offset = "0x9A0FE0", Length = "0x4")]
		public override void OnUpdate()
		{
			DoTransformPoint();
		}

		[Token(Token = "0x6001243")]
		[Address(RVA = "0x9A0EF4", Offset = "0x9A0EF4", Length = "0xEC")]
		private void DoTransformPoint()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null))
			{
				FsmVector3 fsmVector = storeResult;
				Transform transform = ownerDefaultTarget.transform;
				Vector3 value = localPosition.Value;
				Vector3 vector = (fsmVector.value = transform.TransformPoint(value));
				fsmVector.value.y = vector.y;
				fsmVector.value.z = vector.z;
			}
		}

		[Token(Token = "0x6001244")]
		[Address(RVA = "0x9A0FE4", Offset = "0x9A0FE4", Length = "0x8")]
		public TransformPoint()
		{
		}
	}
}
