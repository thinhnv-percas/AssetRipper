using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x763418", Offset = "0x763418")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x763418", Offset = "0x763418")]
	[Token(Token = "0x2000443")]
	public class Vector3HighPassFilter : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7DAC4C", Offset = "0x7DAC4C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7DAC4C", Offset = "0x7DAC4C")]
		[Token(Token = "0x400200E")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector3 vector3Variable;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7DACAC", Offset = "0x7DACAC")]
		[Token(Token = "0x400200F")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat filteringFactor;

		[Token(Token = "0x4002010")]
		[FieldOffset(Offset = "0x60")]
		private Vector3 filteredVector;

		[Token(Token = "0x600151B")]
		[Address(RVA = "0x98882C", Offset = "0x98882C", Length = "0x34")]
		public override void Reset()
		{
			vector3Variable = null;
			FsmFloat fsmFloat = 0.1f;
			filteringFactor = fsmFloat;
		}

		[Token(Token = "0x600151C")]
		[Address(RVA = "0x988860", Offset = "0x988860", Length = "0x94")]
		public override void OnEnter()
		{
			Vector3 value = vector3Variable.Value;
			Vector3 value2 = vector3Variable.Value;
			Vector3 value3 = vector3Variable.Value;
			Vector3 vector = default(Vector3);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			filteredVector = default(Vector3);
			filteredVector.z = 0f;
		}

		[Token(Token = "0x600151D")]
		[Address(RVA = "0x9888F4", Offset = "0x9888F4", Length = "0x1B4")]
		public override void OnUpdate()
		{
			Vector3 value = vector3Variable.Value;
			Vector3 value2 = vector3Variable.Value;
			float value3 = filteringFactor.Value;
			float value4 = filteringFactor.Value;
			float num = 1f - value4;
			float num2 = value2.x * value3;
			float num3 = filteredVector.x * num;
			float num4 = num2 + num3;
			float x = value.x - num4;
			filteredVector.x = x;
			Vector3 value5 = vector3Variable.Value;
			Vector3 value6 = vector3Variable.Value;
			float value7 = filteringFactor.Value;
			float value8 = filteringFactor.Value;
			float num5 = 1f - value8;
			float num6 = value6.y * value7;
			float num7 = filteredVector.y * num5;
			float num8 = num6 + num7;
			float y = value5.y - num8;
			filteredVector.y = y;
			Vector3 value9 = vector3Variable.Value;
			Vector3 value10 = vector3Variable.Value;
			float value11 = filteringFactor.Value;
			float value12 = filteringFactor.Value;
			float num9 = 1f - value12;
			float num10 = value10.z * value11;
			FsmVector3 fsmVector = vector3Variable;
			float num11 = filteredVector.z * num9;
			float num12 = num10 + num11;
			float z = value9.z - num12;
			filteredVector.z = z;
			Vector3 vector = default(Vector3);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			fsmVector.value = default(Vector3);
			fsmVector.value.z = 0f;
		}

		[Token(Token = "0x600151E")]
		[Address(RVA = "0x988AA8", Offset = "0x988AA8", Length = "0x8")]
		public Vector3HighPassFilter()
		{
		}
	}
}
