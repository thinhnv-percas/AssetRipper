using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x762DD8", Offset = "0x762DD8")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x762DD8", Offset = "0x762DD8")]
	[Token(Token = "0x200042F")]
	public class Vector2HighPassFilter : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7D9D54", Offset = "0x7D9D54")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D9D54", Offset = "0x7D9D54")]
		[Token(Token = "0x4001FBE")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector2 vector2Variable;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D9DB4", Offset = "0x7D9DB4")]
		[Token(Token = "0x4001FBF")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat filteringFactor;

		[Token(Token = "0x4001FC0")]
		[FieldOffset(Offset = "0x60")]
		private Vector2 filteredVector;

		[Token(Token = "0x60014C4")]
		[Address(RVA = "0x986C88", Offset = "0x986C88", Length = "0x34")]
		public override void Reset()
		{
			vector2Variable = null;
			FsmFloat fsmFloat = 0.1f;
			filteringFactor = fsmFloat;
		}

		[Token(Token = "0x60014C5")]
		[Address(RVA = "0x986CBC", Offset = "0x986CBC", Length = "0x48")]
		public override void OnEnter()
		{
			FsmVector2 fsmVector = vector2Variable;
			Vector2 vector = default(Vector2);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
			filteredVector = default(Vector2);
			float y = default(float);
			filteredVector.y = y;
		}

		[Token(Token = "0x60014C6")]
		[Address(RVA = "0x986D04", Offset = "0x986D04", Length = "0xFC")]
		public override void OnUpdate()
		{
			FsmVector2 fsmVector = vector2Variable;
			float value = filteringFactor.Value;
			float value2 = filteringFactor.Value;
			float num = 1f - value2;
			FsmVector2 fsmVector2 = vector2Variable;
			float num2 = fsmVector.value.x * value;
			float num3 = filteredVector.x * num;
			float num4 = num2 + num3;
			float x = fsmVector.value.x - num4;
			filteredVector.x = x;
			float value3 = filteringFactor.Value;
			float value4 = filteringFactor.Value;
			float num5 = 1f - value4;
			float num6 = fsmVector2.value.y * value3;
			FsmVector2 fsmVector3 = vector2Variable;
			float num7 = filteredVector.y * num5;
			float num8 = num6 + num7;
			float y = fsmVector2.value.y - num8;
			filteredVector.y = y;
			Vector2 vector = default(Vector2);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
			fsmVector3.value = default(Vector2);
			float y2 = default(float);
			fsmVector3.value.y = y2;
		}

		[Token(Token = "0x60014C7")]
		[Address(RVA = "0x986E00", Offset = "0x986E00", Length = "0x8")]
		public Vector2HighPassFilter()
		{
		}
	}
}
