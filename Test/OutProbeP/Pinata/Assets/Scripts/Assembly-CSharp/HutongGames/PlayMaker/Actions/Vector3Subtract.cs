using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x763738", Offset = "0x763738")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x763738", Offset = "0x763738")]
	[Token(Token = "0x200044D")]
	public class Vector3Subtract : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7DB19C", Offset = "0x7DB19C")]
		[Token(Token = "0x4002035")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector3 vector3Variable;

		[RequiredField]
		[Token(Token = "0x4002036")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector3 subtractVector;

		[Token(Token = "0x4002037")]
		[FieldOffset(Offset = "0x60")]
		public bool everyFrame;

		[Token(Token = "0x6001544")]
		[Address(RVA = "0x989EC0", Offset = "0x989EC0", Length = "0x7C")]
		public override void Reset()
		{
			vector3Variable = null;
			FsmVector3 fsmVector = new FsmVector3();
			fsmVector.useVariable = true;
			subtractVector = fsmVector;
			everyFrame = false;
		}

		[Token(Token = "0x6001545")]
		[Address(RVA = "0x989F3C", Offset = "0x989F3C", Length = "0x10C")]
		public override void OnEnter()
		{
			FsmVector3 fsmVector = vector3Variable;
			Vector3 value = vector3Variable.Value;
			Vector3 value2 = subtractVector.Value;
			Vector3 vector = (fsmVector.value = value - value2);
			fsmVector.value.y = vector.y;
			fsmVector.value.z = vector.z;
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001546")]
		[Address(RVA = "0x98A048", Offset = "0x98A048", Length = "0xE4")]
		public override void OnUpdate()
		{
			FsmVector3 fsmVector = vector3Variable;
			Vector3 value = vector3Variable.Value;
			Vector3 value2 = subtractVector.Value;
			Vector3 vector = (fsmVector.value = value - value2);
			fsmVector.value.y = vector.y;
			fsmVector.value.z = vector.z;
		}

		[Token(Token = "0x6001547")]
		[Address(RVA = "0x98A12C", Offset = "0x98A12C", Length = "0x8")]
		public Vector3Subtract()
		{
		}
	}
}
