using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x762F18", Offset = "0x762F18")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x762F18", Offset = "0x762F18")]
	[Token(Token = "0x2000433")]
	public class Vector2LowPassFilter : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7DA1EC", Offset = "0x7DA1EC")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7DA1EC", Offset = "0x7DA1EC")]
		[Token(Token = "0x4001FD1")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector2 vector2Variable;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7DA24C", Offset = "0x7DA24C")]
		[Token(Token = "0x4001FD2")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat filteringFactor;

		[Token(Token = "0x4001FD3")]
		[FieldOffset(Offset = "0x60")]
		private Vector2 filteredVector;

		[Token(Token = "0x60014D5")]
		[Address(RVA = "0x9873D4", Offset = "0x9873D4", Length = "0x34")]
		public override void Reset()
		{
			vector2Variable = null;
			FsmFloat fsmFloat = 0.1f;
			filteringFactor = fsmFloat;
		}

		[Token(Token = "0x60014D6")]
		[Address(RVA = "0x987408", Offset = "0x987408", Length = "0x48")]
		public override void OnEnter()
		{
			FsmVector2 fsmVector = vector2Variable;
			Vector2 vector = default(Vector2);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
			filteredVector = default(Vector2);
			float y = default(float);
			filteredVector.y = y;
		}

		[Token(Token = "0x60014D7")]
		[Address(RVA = "0x987450", Offset = "0x987450", Length = "0xF4")]
		public override void OnUpdate()
		{
			FsmVector2 fsmVector = vector2Variable;
			float value = filteringFactor.Value;
			float value2 = filteringFactor.Value;
			float num = fsmVector.value.x * value;
			FsmVector2 fsmVector2 = vector2Variable;
			float num2 = 1f - value2;
			float num3 = filteredVector.x * num2;
			float x = num + num3;
			filteredVector.x = x;
			float value3 = filteringFactor.Value;
			float value4 = filteringFactor.Value;
			float num4 = 1f - value4;
			FsmVector2 fsmVector3 = vector2Variable;
			float num5 = fsmVector2.value.y * value3;
			float num6 = filteredVector.y * num4;
			float y = num5 + num6;
			filteredVector.y = y;
			Vector2 vector = default(Vector2);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
			fsmVector3.value = default(Vector2);
			float y2 = default(float);
			fsmVector3.value.y = y2;
		}

		[Token(Token = "0x60014D8")]
		[Address(RVA = "0x987544", Offset = "0x987544", Length = "0x8")]
		public Vector2LowPassFilter()
		{
		}
	}
}
