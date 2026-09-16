using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75FE1C", Offset = "0x75FE1C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75FE1C", Offset = "0x75FE1C")]
	[Token(Token = "0x200039A")]
	public class GetScale : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x4001CB8")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7CD68C", Offset = "0x7CD68C")]
		[Token(Token = "0x4001CB9")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector3 vector;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7CD6A0", Offset = "0x7CD6A0")]
		[Token(Token = "0x4001CBA")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat xScale;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7CD6B4", Offset = "0x7CD6B4")]
		[Token(Token = "0x4001CBB")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat yScale;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7CD6C8", Offset = "0x7CD6C8")]
		[Token(Token = "0x4001CBC")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat zScale;

		[Token(Token = "0x4001CBD")]
		[FieldOffset(Offset = "0x78")]
		public Space space;

		[Token(Token = "0x4001CBE")]
		[FieldOffset(Offset = "0x7C")]
		public bool everyFrame;

		[Token(Token = "0x60011E6")]
		[Address(RVA = "0xA33FB8", Offset = "0xA33FB8", Length = "0x14")]
		public override void Reset()
		{
			_ = 0;
			zScale = null;
			gameObject = null;
			xScale = null;
		}

		[Token(Token = "0x60011E7")]
		[Address(RVA = "0xA33FCC", Offset = "0xA33FCC", Length = "0x3C")]
		public override void OnEnter()
		{
			DoGetScale();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60011E8")]
		[Address(RVA = "0xA34110", Offset = "0xA34110", Length = "0x4")]
		public override void OnUpdate()
		{
			DoGetScale();
		}

		[Token(Token = "0x60011E9")]
		[Address(RVA = "0xA34008", Offset = "0xA34008", Length = "0x108")]
		private void DoGetScale()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null))
			{
				Transform transform = ownerDefaultTarget.transform;
				Vector3 value;
				float y;
				float z;
				if (space != Space.World)
				{
					value = transform.localScale;
					y = value.y;
					z = value.z;
				}
				else
				{
					value = transform.lossyScale;
					y = value.y;
					z = value.z;
				}
				FsmVector3 fsmVector = vector;
				fsmVector.value = value;
				fsmVector.value.y = y;
				fsmVector.value.z = z;
				FsmFloat fsmFloat = xScale;
				fsmFloat.Value = value.x;
				FsmFloat fsmFloat2 = yScale;
				fsmFloat2.Value = y;
				FsmFloat fsmFloat3 = zScale;
				fsmFloat3.Value = z;
			}
		}

		[Token(Token = "0x60011EA")]
		[Address(RVA = "0xA34114", Offset = "0xA34114", Length = "0x8")]
		public GetScale()
		{
		}
	}
}
