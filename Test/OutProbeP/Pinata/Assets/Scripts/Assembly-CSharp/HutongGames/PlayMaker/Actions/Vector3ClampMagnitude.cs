using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7633C8", Offset = "0x7633C8")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7633C8", Offset = "0x7633C8")]
	[Token(Token = "0x2000442")]
	public class Vector3ClampMagnitude : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7DAC00", Offset = "0x7DAC00")]
		[Token(Token = "0x400200B")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector3 vector3Variable;

		[RequiredField]
		[Token(Token = "0x400200C")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat maxLength;

		[Token(Token = "0x400200D")]
		[FieldOffset(Offset = "0x60")]
		public bool everyFrame;

		[Token(Token = "0x6001516")]
		[Address(RVA = "0x98870C", Offset = "0x98870C", Length = "0xC")]
		public override void Reset()
		{
			everyFrame = false;
			vector3Variable = null;
			maxLength = null;
		}

		[Token(Token = "0x6001517")]
		[Address(RVA = "0x988718", Offset = "0x988718", Length = "0x3C")]
		public override void OnEnter()
		{
			DoVector3ClampMagnitude();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001518")]
		[Address(RVA = "0x988820", Offset = "0x988820", Length = "0x4")]
		public override void OnUpdate()
		{
			DoVector3ClampMagnitude();
		}

		[Token(Token = "0x6001519")]
		[Address(RVA = "0x988754", Offset = "0x988754", Length = "0xCC")]
		private void DoVector3ClampMagnitude()
		{
			FsmVector3 fsmVector = vector3Variable;
			Vector3 value = vector3Variable.Value;
			float value2 = maxLength.Value;
			Vector3 vector = (fsmVector.value = Vector3.ClampMagnitude(value, value2));
			fsmVector.value.y = vector.y;
			fsmVector.value.z = vector.z;
		}

		[Token(Token = "0x600151A")]
		[Address(RVA = "0x988824", Offset = "0x988824", Length = "0x8")]
		public Vector3ClampMagnitude()
		{
		}
	}
}
