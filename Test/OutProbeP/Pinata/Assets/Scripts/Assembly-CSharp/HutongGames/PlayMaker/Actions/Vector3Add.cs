using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x763328", Offset = "0x763328")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x763328", Offset = "0x763328")]
	[Token(Token = "0x2000440")]
	public class Vector3Add : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7DAB78", Offset = "0x7DAB78")]
		[Token(Token = "0x4002001")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector3 vector3Variable;

		[RequiredField]
		[Token(Token = "0x4002002")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector3 addVector;

		[Token(Token = "0x4002003")]
		[FieldOffset(Offset = "0x60")]
		public bool everyFrame;

		[Token(Token = "0x4002004")]
		[FieldOffset(Offset = "0x61")]
		public bool perSecond;

		[Token(Token = "0x600150C")]
		[Address(RVA = "0x9882C4", Offset = "0x9882C4", Length = "0x7C")]
		public override void Reset()
		{
			vector3Variable = null;
			FsmVector3 fsmVector = new FsmVector3();
			fsmVector.useVariable = true;
			addVector = fsmVector;
			everyFrame = false;
			perSecond = false;
		}

		[Token(Token = "0x600150D")]
		[Address(RVA = "0x988340", Offset = "0x988340", Length = "0x3C")]
		public override void OnEnter()
		{
			DoVector3Add();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x600150E")]
		[Address(RVA = "0x9884CC", Offset = "0x9884CC", Length = "0x4")]
		public override void OnUpdate()
		{
			DoVector3Add();
		}

		[Token(Token = "0x600150F")]
		[Address(RVA = "0x98837C", Offset = "0x98837C", Length = "0x150")]
		private void DoVector3Add()
		{
			FsmVector3 fsmVector = vector3Variable;
			Vector3 value = vector3Variable.Value;
			Vector3 value2 = addVector.Value;
			float z;
			float y;
			Vector3 vector2;
			if (perSecond)
			{
				float deltaTime = Time.deltaTime;
				Vector3 vector = value2 * deltaTime;
				z = vector.z;
				y = vector.y;
				vector2 = vector;
			}
			else
			{
				z = value2.z;
				y = value2.y;
				vector2 = value2;
			}
			Vector3 vector3 = default(Vector3);
			vector3.x = vector2.x;
			vector3.y = y;
			vector3.z = z;
			Vector3 vector4 = (fsmVector.value = value + vector3);
			fsmVector.value.y = vector4.y;
			fsmVector.value.z = vector4.z;
		}

		[Token(Token = "0x6001510")]
		[Address(RVA = "0x9884D0", Offset = "0x9884D0", Length = "0x8")]
		public Vector3Add()
		{
		}
	}
}
