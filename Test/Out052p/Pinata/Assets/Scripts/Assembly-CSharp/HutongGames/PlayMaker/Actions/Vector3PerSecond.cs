using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x763698", Offset = "0x763698")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x763698", Offset = "0x763698")]
	[Token(Token = "0x200044B")]
	public class Vector3PerSecond : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7DB0A8", Offset = "0x7DB0A8")]
		[Token(Token = "0x400202F")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector3 vector3Variable;

		[Token(Token = "0x4002030")]
		[FieldOffset(Offset = "0x58")]
		public bool everyFrame;

		[Token(Token = "0x600153D")]
		[Address(RVA = "0x989AFC", Offset = "0x989AFC", Length = "0xC")]
		public override void Reset()
		{
			vector3Variable = null;
			everyFrame = false;
		}

		[Token(Token = "0x600153E")]
		[Address(RVA = "0x989B08", Offset = "0x989B08", Length = "0xE8")]
		public override void OnEnter()
		{
			FsmVector3 fsmVector = vector3Variable;
			Vector3 value = vector3Variable.Value;
			float deltaTime = Time.deltaTime;
			Vector3 vector = (fsmVector.value = value * deltaTime);
			fsmVector.value.y = vector.y;
			fsmVector.value.z = vector.z;
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x600153F")]
		[Address(RVA = "0x989BF0", Offset = "0x989BF0", Length = "0xC4")]
		public override void OnUpdate()
		{
			FsmVector3 fsmVector = vector3Variable;
			Vector3 value = vector3Variable.Value;
			float deltaTime = Time.deltaTime;
			Vector3 vector = (fsmVector.value = value * deltaTime);
			fsmVector.value.y = vector.y;
			fsmVector.value.z = vector.z;
		}

		[Token(Token = "0x6001540")]
		[Address(RVA = "0x989CB4", Offset = "0x989CB4", Length = "0x8")]
		public Vector3PerSecond()
		{
		}
	}
}
