using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7635A8", Offset = "0x7635A8")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7635A8", Offset = "0x7635A8")]
	[Token(Token = "0x2000448")]
	public class Vector3Multiply : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7DAFD8", Offset = "0x7DAFD8")]
		[Token(Token = "0x4002024")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector3 vector3Variable;

		[RequiredField]
		[Token(Token = "0x4002025")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat multiplyBy;

		[Token(Token = "0x4002026")]
		[FieldOffset(Offset = "0x60")]
		public bool everyFrame;

		[Token(Token = "0x6001530")]
		[Address(RVA = "0x989370", Offset = "0x989370", Length = "0x34")]
		public override void Reset()
		{
			vector3Variable = null;
			FsmFloat fsmFloat = 1f;
			multiplyBy = fsmFloat;
			everyFrame = false;
		}

		[Token(Token = "0x6001531")]
		[Address(RVA = "0x9893A4", Offset = "0x9893A4", Length = "0xF0")]
		public override void OnEnter()
		{
			FsmVector3 fsmVector = vector3Variable;
			Vector3 value = vector3Variable.Value;
			float value2 = multiplyBy.Value;
			Vector3 vector = (fsmVector.value = value * value2);
			fsmVector.value.y = vector.y;
			fsmVector.value.z = vector.z;
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001532")]
		[Address(RVA = "0x989494", Offset = "0x989494", Length = "0xCC")]
		public override void OnUpdate()
		{
			FsmVector3 fsmVector = vector3Variable;
			Vector3 value = vector3Variable.Value;
			float value2 = multiplyBy.Value;
			Vector3 vector = (fsmVector.value = value * value2);
			fsmVector.value.y = vector.y;
			fsmVector.value.z = vector.z;
		}

		[Token(Token = "0x6001533")]
		[Address(RVA = "0x989560", Offset = "0x989560", Length = "0x8")]
		public Vector3Multiply()
		{
		}
	}
}
