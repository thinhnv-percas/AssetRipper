using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x762E78", Offset = "0x762E78")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x762E78", Offset = "0x762E78")]
	[Token(Token = "0x2000431")]
	public class Vector2Invert : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7D9FD8", Offset = "0x7D9FD8")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D9FD8", Offset = "0x7D9FD8")]
		[Token(Token = "0x4001FCA")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector2 vector2Variable;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7DA038", Offset = "0x7DA038")]
		[Token(Token = "0x4001FCB")]
		[FieldOffset(Offset = "0x58")]
		public bool everyFrame;

		[Token(Token = "0x60014CC")]
		[Address(RVA = "0x9870B8", Offset = "0x9870B8", Length = "0xC")]
		public override void Reset()
		{
			vector2Variable = null;
			everyFrame = false;
		}

		[Token(Token = "0x60014CD")]
		[Address(RVA = "0x9870C4", Offset = "0x9870C4", Length = "0xB4")]
		public override void OnEnter()
		{
			FsmVector2 fsmVector = vector2Variable;
			Vector2 vector = default(Vector2);
			vector.x = fsmVector.value.x;
			vector.y = fsmVector.value.y;
			Vector2 vector2 = (fsmVector.value = vector * -1f);
			fsmVector.value.y = vector2.y;
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60014CE")]
		[Address(RVA = "0x987178", Offset = "0x987178", Length = "0x94")]
		public override void OnUpdate()
		{
			FsmVector2 fsmVector = vector2Variable;
			Vector2 vector = default(Vector2);
			vector.x = fsmVector.value.x;
			vector.y = fsmVector.value.y;
			Vector2 vector2 = (fsmVector.value = vector * -1f);
			fsmVector.value.y = vector2.y;
		}

		[Token(Token = "0x60014CF")]
		[Address(RVA = "0x98720C", Offset = "0x98720C", Length = "0x8")]
		public Vector2Invert()
		{
		}
	}
}
