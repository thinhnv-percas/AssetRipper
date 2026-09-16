using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x762C98", Offset = "0x762C98")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x762C98", Offset = "0x762C98")]
	[Token(Token = "0x200042B")]
	public class SetVector2XY : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7D98BC", Offset = "0x7D98BC")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D98BC", Offset = "0x7D98BC")]
		[Token(Token = "0x4001FAD")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector2 vector2Variable;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7D991C", Offset = "0x7D991C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D991C", Offset = "0x7D991C")]
		[Token(Token = "0x4001FAE")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector2 vector2Value;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D996C", Offset = "0x7D996C")]
		[Token(Token = "0x4001FAF")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat x;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D99A4", Offset = "0x7D99A4")]
		[Token(Token = "0x4001FB0")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat y;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D99DC", Offset = "0x7D99DC")]
		[Token(Token = "0x4001FB1")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x60014B0")]
		[Address(RVA = "0x99AC08", Offset = "0x99AC08", Length = "0xA4")]
		public override void Reset()
		{
			vector2Variable = null;
			vector2Value = null;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = true;
			x = fsmFloat;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.useVariable = true;
			y = fsmFloat2;
			everyFrame = false;
		}

		[Token(Token = "0x60014B1")]
		[Address(RVA = "0x99ACAC", Offset = "0x99ACAC", Length = "0x3C")]
		public override void OnEnter()
		{
			DoSetVector2XYZ();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60014B2")]
		[Address(RVA = "0x99ADA0", Offset = "0x99ADA0", Length = "0x4")]
		public override void OnUpdate()
		{
			DoSetVector2XYZ();
		}

		[Token(Token = "0x60014B3")]
		[Address(RVA = "0x99ACE8", Offset = "0x99ACE8", Length = "0xB8")]
		private void DoSetVector2XYZ()
		{
			//IL_0172: Expected O, but got F4
			FsmVector2 fsmVector = vector2Variable;
			if (vector2Variable != null)
			{
				Vector2 value = fsmVector.value;
				float num = fsmVector.value.y;
				if (!vector2Value.IsNone)
				{
					FsmVector2 fsmVector2 = vector2Value;
					value = fsmVector2.value;
					num = fsmVector2.value.y;
				}
				bool isNone = x.IsNone;
				bool flag = !isNone;
				bool flag2 = !flag;
				float num2 = value.x;
				if (!flag2)
				{
					float value2 = x.Value;
					num2 = value2;
				}
				if (!y.IsNone)
				{
					float value3 = y.Value;
					num = value3;
				}
				FsmVector2 fsmVector3 = vector2Variable;
				fsmVector3.value = (Vector2)num2;
				fsmVector3.value.y = num;
			}
		}

		[Token(Token = "0x60014B4")]
		[Address(RVA = "0x99ADA4", Offset = "0x99ADA4", Length = "0x8")]
		public SetVector2XY()
		{
		}
	}
}
