using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x763008", Offset = "0x763008")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x763008", Offset = "0x763008")]
	[Token(Token = "0x2000436")]
	public class Vector2Normalize : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7DA4CC", Offset = "0x7DA4CC")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7DA4CC", Offset = "0x7DA4CC")]
		[Token(Token = "0x4001FDC")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector2 vector2Variable;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7DA52C", Offset = "0x7DA52C")]
		[Token(Token = "0x4001FDD")]
		[FieldOffset(Offset = "0x58")]
		public bool everyFrame;

		[Token(Token = "0x60014E1")]
		[Address(RVA = "0x9878A8", Offset = "0x9878A8", Length = "0xC")]
		public override void Reset()
		{
			vector2Variable = null;
			everyFrame = false;
		}

		[Token(Token = "0x60014E2")]
		[Address(RVA = "0x9878B4", Offset = "0x9878B4", Length = "0x64")]
		public override void OnEnter()
		{
			FsmVector2 fsmVector = vector2Variable;
			Vector2 value = fsmVector.value;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1588F3C (inside UnityEngine.Vector2::get_zero +0x68)");
			Vector2 value2 = default(Vector2);
			fsmVector.value = value2;
			float y = default(float);
			fsmVector.value.y = y;
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60014E3")]
		[Address(RVA = "0x987918", Offset = "0x987918", Length = "0x44")]
		public override void OnUpdate()
		{
			FsmVector2 fsmVector = vector2Variable;
			Vector2 value = fsmVector.value;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1588F3C (inside UnityEngine.Vector2::get_zero +0x68)");
			Vector2 value2 = default(Vector2);
			fsmVector.value = value2;
			float y = default(float);
			fsmVector.value.y = y;
		}

		[Token(Token = "0x60014E4")]
		[Address(RVA = "0x98795C", Offset = "0x98795C", Length = "0x8")]
		public Vector2Normalize()
		{
		}
	}
}
