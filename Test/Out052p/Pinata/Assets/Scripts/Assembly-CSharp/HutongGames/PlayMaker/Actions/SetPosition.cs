using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x760070", Offset = "0x760070")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x760070", Offset = "0x760070")]
	[Token(Token = "0x20003A1")]
	public class SetPosition : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CDDE0", Offset = "0x7CDDE0")]
		[Token(Token = "0x4001CEE")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7CDE2C", Offset = "0x7CDE2C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CDE2C", Offset = "0x7CDE2C")]
		[Token(Token = "0x4001CEF")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector3 vector;

		[Token(Token = "0x4001CF0")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat x;

		[Token(Token = "0x4001CF1")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat y;

		[Token(Token = "0x4001CF2")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat z;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CDE7C", Offset = "0x7CDE7C")]
		[Token(Token = "0x4001CF3")]
		[FieldOffset(Offset = "0x78")]
		public Space space;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CDEB4", Offset = "0x7CDEB4")]
		[Token(Token = "0x4001CF4")]
		[FieldOffset(Offset = "0x7C")]
		public bool everyFrame;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CDEEC", Offset = "0x7CDEEC")]
		[Token(Token = "0x4001CF5")]
		[FieldOffset(Offset = "0x7D")]
		public bool lateUpdate;

		[Token(Token = "0x6001211")]
		[Address(RVA = "0x9982C4", Offset = "0x9982C4", Length = "0xCC")]
		public override void Reset()
		{
			gameObject = null;
			vector = null;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = true;
			x = fsmFloat;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.useVariable = true;
			y = fsmFloat2;
			FsmFloat fsmFloat3 = new FsmFloat();
			fsmFloat3.useVariable = true;
			z = fsmFloat3;
			space = Space.Self;
			everyFrame = false;
			lateUpdate = false;
		}

		[Token(Token = "0x6001212")]
		[Address(RVA = "0x998390", Offset = "0x998390", Length = "0x2C")]
		public override void OnPreprocess()
		{
			if (lateUpdate)
			{
				Fsm.HandleLateUpdate = true;
			}
		}

		[Token(Token = "0x6001213")]
		[Address(RVA = "0x9983BC", Offset = "0x9983BC", Length = "0x48")]
		public override void OnEnter()
		{
			if (!everyFrame && !lateUpdate)
			{
				DoSetPosition();
				Finish();
			}
		}

		[Token(Token = "0x6001214")]
		[Address(RVA = "0x9985F0", Offset = "0x9985F0", Length = "0x10")]
		public override void OnUpdate()
		{
			if (!lateUpdate)
			{
				DoSetPosition();
			}
		}

		[Token(Token = "0x6001215")]
		[Address(RVA = "0x998600", Offset = "0x998600", Length = "0x48")]
		public override void OnLateUpdate()
		{
			if (lateUpdate)
			{
				DoSetPosition();
			}
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001216")]
		[Address(RVA = "0x998404", Offset = "0x998404", Length = "0x1EC")]
		private void DoSetPosition()
		{
			//IL_0184: Expected O, but got F4
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (ownerDefaultTarget == null)
			{
				return;
			}
			Vector3 vector;
			float num;
			float num2;
			if (this.vector.IsNone)
			{
				Transform transform = ownerDefaultTarget.transform;
				if (space != Space.World)
				{
					vector = transform.localPosition;
					num = vector.y;
					num2 = vector.z;
				}
				else
				{
					vector = transform.position;
					num = vector.y;
					num2 = vector.z;
				}
			}
			else
			{
				vector = this.vector.Value;
				num = vector.y;
				num2 = vector.z;
			}
			bool isNone = x.IsNone;
			bool flag = !isNone;
			bool flag2 = !flag;
			Vector3 vector2 = vector;
			if (!flag2)
			{
				float value = x.Value;
				vector2 = (Vector3)value;
			}
			bool isNone2 = y.IsNone;
			bool flag3 = !isNone2;
			bool flag4 = !flag3;
			float num3 = num;
			if (!flag4)
			{
				float value2 = y.Value;
				num3 = value2;
			}
			bool isNone3 = z.IsNone;
			bool flag5 = !isNone3;
			bool flag6 = !flag5;
			float num4 = num2;
			if (!flag6)
			{
				float value3 = z.Value;
				num4 = value3;
			}
			Transform transform2 = ownerDefaultTarget.transform;
			if (space != Space.World)
			{
				Vector3 localPosition = default(Vector3);
				localPosition.x = vector2.x;
				localPosition.y = num3;
				localPosition.z = num4;
				transform2.localPosition = localPosition;
			}
			else
			{
				Vector3 position = default(Vector3);
				position.x = vector2.x;
				position.y = num3;
				position.z = num4;
				transform2.position = position;
			}
		}

		[Token(Token = "0x6001217")]
		[Address(RVA = "0x998648", Offset = "0x998648", Length = "0x8")]
		public SetPosition()
		{
		}
	}
}
