using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7632D8", Offset = "0x7632D8")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7632D8", Offset = "0x7632D8")]
	[Token(Token = "0x200043F")]
	public class SetVector3XYZ : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7DAB28", Offset = "0x7DAB28")]
		[Token(Token = "0x4001FFB")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector3 vector3Variable;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7DAB64", Offset = "0x7DAB64")]
		[Token(Token = "0x4001FFC")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector3 vector3Value;

		[Token(Token = "0x4001FFD")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat x;

		[Token(Token = "0x4001FFE")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat y;

		[Token(Token = "0x4001FFF")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat z;

		[Token(Token = "0x4002000")]
		[FieldOffset(Offset = "0x78")]
		public bool everyFrame;

		[Token(Token = "0x6001507")]
		[Address(RVA = "0x99AE6C", Offset = "0x99AE6C", Length = "0xC8")]
		public override void Reset()
		{
			vector3Variable = null;
			vector3Value = null;
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
		}

		[Token(Token = "0x6001508")]
		[Address(RVA = "0x99AF34", Offset = "0x99AF34", Length = "0x3C")]
		public override void OnEnter()
		{
			DoSetVector3XYZ();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001509")]
		[Address(RVA = "0x99B07C", Offset = "0x99B07C", Length = "0x4")]
		public override void OnUpdate()
		{
			DoSetVector3XYZ();
		}

		[Token(Token = "0x600150A")]
		[Address(RVA = "0x99AF70", Offset = "0x99AF70", Length = "0x10C")]
		private void DoSetVector3XYZ()
		{
			//IL_0110: Expected O, but got F4
			if (vector3Variable != null)
			{
				Vector3 value = vector3Variable.Value;
				bool isNone = vector3Value.IsNone;
				bool flag = !isNone;
				bool flag2 = !flag;
				float num = value.z;
				float num2 = value.y;
				Vector3 value2 = value;
				if (!flag2)
				{
					Vector3 value3 = vector3Value.Value;
					num = value3.z;
					num2 = value3.y;
					value2 = value3;
				}
				if (!x.IsNone)
				{
					float value4 = x.Value;
					value2 = (Vector3)value4;
				}
				if (!y.IsNone)
				{
					float value5 = y.Value;
					num2 = value5;
				}
				if (!z.IsNone)
				{
					float value6 = z.Value;
					num = value6;
				}
				FsmVector3 fsmVector = vector3Variable;
				fsmVector.value = value2;
				fsmVector.value.y = num2;
				fsmVector.value.z = num;
			}
		}

		[Token(Token = "0x600150B")]
		[Address(RVA = "0x99B080", Offset = "0x99B080", Length = "0x8")]
		public SetVector3XYZ()
		{
		}
	}
}
