using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x763148", Offset = "0x763148")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x763148", Offset = "0x763148")]
	[Token(Token = "0x200043A")]
	public class Vector2Subtract : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7DA888", Offset = "0x7DA888")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7DA888", Offset = "0x7DA888")]
		[Token(Token = "0x4001FEB")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector2 vector2Variable;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7DA8E8", Offset = "0x7DA8E8")]
		[Token(Token = "0x4001FEC")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector2 subtractVector;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7DA934", Offset = "0x7DA934")]
		[Token(Token = "0x4001FED")]
		[FieldOffset(Offset = "0x60")]
		public bool everyFrame;

		[Token(Token = "0x60014F2")]
		[Address(RVA = "0x9880C4", Offset = "0x9880C4", Length = "0x7C")]
		public override void Reset()
		{
			vector2Variable = null;
			FsmVector2 fsmVector = new FsmVector2();
			fsmVector.useVariable = true;
			subtractVector = fsmVector;
			everyFrame = false;
		}

		[Token(Token = "0x60014F3")]
		[Address(RVA = "0x988140", Offset = "0x988140", Length = "0xD0")]
		public override void OnEnter()
		{
			FsmVector2 fsmVector = vector2Variable;
			FsmVector2 fsmVector2 = subtractVector;
			Vector2 vector = default(Vector2);
			vector.x = fsmVector.value.x;
			vector.y = fsmVector.value.y;
			Vector2 vector2 = default(Vector2);
			vector2.x = fsmVector2.value.x;
			vector2.y = fsmVector2.value.y;
			Vector2 vector3 = (fsmVector.value = vector - vector2);
			fsmVector.value.y = vector3.y;
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60014F4")]
		[Address(RVA = "0x988210", Offset = "0x988210", Length = "0xAC")]
		public override void OnUpdate()
		{
			FsmVector2 fsmVector = vector2Variable;
			FsmVector2 fsmVector2 = subtractVector;
			Vector2 vector = default(Vector2);
			vector.x = fsmVector.value.x;
			vector.y = fsmVector.value.y;
			Vector2 vector2 = default(Vector2);
			vector2.x = fsmVector2.value.x;
			vector2.y = fsmVector2.value.y;
			Vector2 vector3 = (fsmVector.value = vector - vector2);
			fsmVector.value.y = vector3.y;
		}

		[Token(Token = "0x60014F5")]
		[Address(RVA = "0x9882BC", Offset = "0x9882BC", Length = "0x8")]
		public Vector2Subtract()
		{
		}
	}
}
