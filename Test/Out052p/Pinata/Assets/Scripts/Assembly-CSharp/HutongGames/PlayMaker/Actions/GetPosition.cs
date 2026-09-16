using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75FD7C", Offset = "0x75FD7C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75FD7C", Offset = "0x75FD7C")]
	[Token(Token = "0x2000398")]
	public class GetPosition : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x4001CA9")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7CD57C", Offset = "0x7CD57C")]
		[Token(Token = "0x4001CAA")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector3 vector;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7CD590", Offset = "0x7CD590")]
		[Token(Token = "0x4001CAB")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat x;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7CD5A4", Offset = "0x7CD5A4")]
		[Token(Token = "0x4001CAC")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat y;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7CD5B8", Offset = "0x7CD5B8")]
		[Token(Token = "0x4001CAD")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat z;

		[Token(Token = "0x4001CAE")]
		[FieldOffset(Offset = "0x78")]
		public Space space;

		[Token(Token = "0x4001CAF")]
		[FieldOffset(Offset = "0x7C")]
		public bool everyFrame;

		[Token(Token = "0x60011DC")]
		[Address(RVA = "0xA32758", Offset = "0xA32758", Length = "0x14")]
		public override void Reset()
		{
			_ = 0;
			z = null;
			gameObject = null;
			x = null;
		}

		[Token(Token = "0x60011DD")]
		[Address(RVA = "0xA3276C", Offset = "0xA3276C", Length = "0x3C")]
		public override void OnEnter()
		{
			DoGetPosition();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60011DE")]
		[Address(RVA = "0xA328B0", Offset = "0xA328B0", Length = "0x4")]
		public override void OnUpdate()
		{
			DoGetPosition();
		}

		[Token(Token = "0x60011DF")]
		[Address(RVA = "0xA327A8", Offset = "0xA327A8", Length = "0x108")]
		private void DoGetPosition()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null))
			{
				Transform transform = ownerDefaultTarget.transform;
				Vector3 value;
				float value2;
				float value3;
				if (space != Space.World)
				{
					value = transform.localPosition;
					value2 = value.y;
					value3 = value.z;
				}
				else
				{
					value = transform.position;
					value2 = value.y;
					value3 = value.z;
				}
				FsmVector3 fsmVector = vector;
				fsmVector.value = value;
				fsmVector.value.y = value2;
				fsmVector.value.z = value3;
				FsmFloat fsmFloat = x;
				fsmFloat.Value = value.x;
				FsmFloat fsmFloat2 = y;
				fsmFloat2.Value = value2;
				FsmFloat fsmFloat3 = z;
				fsmFloat3.Value = value3;
			}
		}

		[Token(Token = "0x60011E0")]
		[Address(RVA = "0xA328B4", Offset = "0xA328B4", Length = "0x8")]
		public GetPosition()
		{
		}
	}
}
