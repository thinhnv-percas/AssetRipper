using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x763558", Offset = "0x763558")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x763558", Offset = "0x763558")]
	[Token(Token = "0x2000447")]
	public class Vector3LowPassFilter : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7DAF40", Offset = "0x7DAF40")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7DAF40", Offset = "0x7DAF40")]
		[Token(Token = "0x4002021")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector3 vector3Variable;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7DAFA0", Offset = "0x7DAFA0")]
		[Token(Token = "0x4002022")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat filteringFactor;

		[Token(Token = "0x4002023")]
		[FieldOffset(Offset = "0x60")]
		private Vector3 filteredVector;

		[Token(Token = "0x600152C")]
		[Address(RVA = "0x98913C", Offset = "0x98913C", Length = "0x34")]
		public override void Reset()
		{
			vector3Variable = null;
			FsmFloat fsmFloat = 0.1f;
			filteringFactor = fsmFloat;
		}

		[Token(Token = "0x600152D")]
		[Address(RVA = "0x989170", Offset = "0x989170", Length = "0x94")]
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

		[Token(Token = "0x600152E")]
		[Address(RVA = "0x989204", Offset = "0x989204", Length = "0x164")]
		public override void OnUpdate()
		{
			Vector3 value = vector3Variable.Value;
			float value2 = filteringFactor.Value;
			float value3 = filteringFactor.Value;
			float num = 1f - value3;
			float num2 = value.x * value2;
			float num3 = filteredVector.x * num;
			float x = num2 + num3;
			filteredVector.x = x;
			Vector3 value4 = vector3Variable.Value;
			float value5 = filteringFactor.Value;
			float value6 = filteringFactor.Value;
			float num4 = 1f - value6;
			float num5 = value4.y * value5;
			float num6 = filteredVector.y * num4;
			float y = num5 + num6;
			filteredVector.y = y;
			Vector3 value7 = vector3Variable.Value;
			float value8 = filteringFactor.Value;
			float value9 = filteringFactor.Value;
			float num7 = 1f - value9;
			FsmVector3 fsmVector = vector3Variable;
			float num8 = value7.z * value8;
			float num9 = filteredVector.z * num7;
			float z = num8 + num9;
			filteredVector.z = z;
			Vector3 vector = default(Vector3);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			fsmVector.value = default(Vector3);
			fsmVector.value.z = 0f;
		}

		[Token(Token = "0x600152F")]
		[Address(RVA = "0x989368", Offset = "0x989368", Length = "0x8")]
		public Vector3LowPassFilter()
		{
		}
	}
}
