using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x762D88", Offset = "0x762D88")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x762D88", Offset = "0x762D88")]
	[Token(Token = "0x200042E")]
	public class Vector2ClampMagnitude : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7D9C70", Offset = "0x7D9C70")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D9C70", Offset = "0x7D9C70")]
		[Token(Token = "0x4001FBB")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector2 vector2Variable;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D9CD0", Offset = "0x7D9CD0")]
		[Token(Token = "0x4001FBC")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat maxLength;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D9D1C", Offset = "0x7D9D1C")]
		[Token(Token = "0x4001FBD")]
		[FieldOffset(Offset = "0x60")]
		public bool everyFrame;

		[Token(Token = "0x60014BF")]
		[Address(RVA = "0x986B84", Offset = "0x986B84", Length = "0xC")]
		public override void Reset()
		{
			everyFrame = false;
			vector2Variable = null;
			maxLength = null;
		}

		[Token(Token = "0x60014C0")]
		[Address(RVA = "0x986B90", Offset = "0x986B90", Length = "0x3C")]
		public override void OnEnter()
		{
			DoVector2ClampMagnitude();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60014C1")]
		[Address(RVA = "0x986C7C", Offset = "0x986C7C", Length = "0x4")]
		public override void OnUpdate()
		{
			DoVector2ClampMagnitude();
		}

		[Token(Token = "0x60014C2")]
		[Address(RVA = "0x986BCC", Offset = "0x986BCC", Length = "0xB0")]
		private void DoVector2ClampMagnitude()
		{
			FsmVector2 fsmVector = vector2Variable;
			float value = maxLength.Value;
			Vector2 vector = default(Vector2);
			vector.x = fsmVector.value.x;
			vector.y = fsmVector.value.y;
			Vector2 vector2 = (fsmVector.value = Vector2.ClampMagnitude(vector, value));
			fsmVector.value.y = vector2.y;
		}

		[Token(Token = "0x60014C3")]
		[Address(RVA = "0x986C80", Offset = "0x986C80", Length = "0x8")]
		public Vector2ClampMagnitude()
		{
		}
	}
}
