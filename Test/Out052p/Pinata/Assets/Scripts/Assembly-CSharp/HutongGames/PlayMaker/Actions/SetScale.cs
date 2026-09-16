using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x760160", Offset = "0x760160")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x760160", Offset = "0x760160")]
	[Token(Token = "0x20003A4")]
	public class SetScale : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CE11C", Offset = "0x7CE11C")]
		[Token(Token = "0x4001D03")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7CE168", Offset = "0x7CE168")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CE168", Offset = "0x7CE168")]
		[Token(Token = "0x4001D04")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector3 vector;

		[Token(Token = "0x4001D05")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat x;

		[Token(Token = "0x4001D06")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat y;

		[Token(Token = "0x4001D07")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat z;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CE1B8", Offset = "0x7CE1B8")]
		[Token(Token = "0x4001D08")]
		[FieldOffset(Offset = "0x78")]
		public bool everyFrame;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CE1F0", Offset = "0x7CE1F0")]
		[Token(Token = "0x4001D09")]
		[FieldOffset(Offset = "0x79")]
		public bool lateUpdate;

		[Token(Token = "0x6001223")]
		[Address(RVA = "0x9995E4", Offset = "0x9995E4", Length = "0xC8")]
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
			everyFrame = false;
			lateUpdate = false;
		}

		[Token(Token = "0x6001224")]
		[Address(RVA = "0x9996AC", Offset = "0x9996AC", Length = "0x2C")]
		public override void OnPreprocess()
		{
			if (lateUpdate)
			{
				Fsm.HandleLateUpdate = true;
			}
		}

		[Token(Token = "0x6001225")]
		[Address(RVA = "0x9996D8", Offset = "0x9996D8", Length = "0x3C")]
		public override void OnEnter()
		{
			DoSetScale();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001226")]
		[Address(RVA = "0x9998C0", Offset = "0x9998C0", Length = "0x10")]
		public override void OnUpdate()
		{
			if (!lateUpdate)
			{
				DoSetScale();
			}
		}

		[Token(Token = "0x6001227")]
		[Address(RVA = "0x9998D0", Offset = "0x9998D0", Length = "0x48")]
		public override void OnLateUpdate()
		{
			if (lateUpdate)
			{
				DoSetScale();
			}
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001228")]
		[Address(RVA = "0x999714", Offset = "0x999714", Length = "0x1AC")]
		private void DoSetScale()
		{
			//IL_0139: Expected O, but got F4
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null))
			{
				Vector3 vector;
				float num;
				float num2;
				if (this.vector.IsNone)
				{
					Transform transform = ownerDefaultTarget.transform;
					vector = transform.localScale;
					num = vector.y;
					num2 = vector.z;
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
				Vector3 localScale = default(Vector3);
				localScale.x = vector2.x;
				localScale.y = num3;
				localScale.z = num4;
				transform2.localScale = localScale;
			}
		}

		[Token(Token = "0x6001229")]
		[Address(RVA = "0x999918", Offset = "0x999918", Length = "0x8")]
		public SetScale()
		{
		}
	}
}
