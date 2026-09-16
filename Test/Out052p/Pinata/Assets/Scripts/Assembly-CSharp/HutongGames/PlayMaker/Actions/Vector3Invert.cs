using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7634B8", Offset = "0x7634B8")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7634B8", Offset = "0x7634B8")]
	[Token(Token = "0x2000445")]
	public class Vector3Invert : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7DAD88", Offset = "0x7DAD88")]
		[Token(Token = "0x400201A")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector3 vector3Variable;

		[Token(Token = "0x400201B")]
		[FieldOffset(Offset = "0x58")]
		public bool everyFrame;

		[Token(Token = "0x6001523")]
		[Address(RVA = "0x988D9C", Offset = "0x988D9C", Length = "0xC")]
		public override void Reset()
		{
			vector3Variable = null;
			everyFrame = false;
		}

		[Token(Token = "0x6001524")]
		[Address(RVA = "0x988DA8", Offset = "0x988DA8", Length = "0xDC")]
		public override void OnEnter()
		{
			FsmVector3 fsmVector = vector3Variable;
			Vector3 value = vector3Variable.Value;
			Vector3 vector = (fsmVector.value = value * -1f);
			fsmVector.value.y = vector.y;
			fsmVector.value.z = vector.z;
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001525")]
		[Address(RVA = "0x988E84", Offset = "0x988E84", Length = "0xB8")]
		public override void OnUpdate()
		{
			FsmVector3 fsmVector = vector3Variable;
			Vector3 value = vector3Variable.Value;
			Vector3 vector = (fsmVector.value = value * -1f);
			fsmVector.value.y = vector.y;
			fsmVector.value.z = vector.z;
		}

		[Token(Token = "0x6001526")]
		[Address(RVA = "0x988F3C", Offset = "0x988F3C", Length = "0x8")]
		public Vector3Invert()
		{
		}
	}
}
