using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x763378", Offset = "0x763378")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x763378", Offset = "0x763378")]
	[Token(Token = "0x2000441")]
	public class Vector3AddXYZ : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7DABC4", Offset = "0x7DABC4")]
		[Token(Token = "0x4002005")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector3 vector3Variable;

		[Token(Token = "0x4002006")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat addX;

		[Token(Token = "0x4002007")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat addY;

		[Token(Token = "0x4002008")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat addZ;

		[Token(Token = "0x4002009")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x400200A")]
		[FieldOffset(Offset = "0x71")]
		public bool perSecond;

		[Token(Token = "0x6001511")]
		[Address(RVA = "0x9884D8", Offset = "0x9884D8", Length = "0x54")]
		public override void Reset()
		{
			vector3Variable = null;
			FsmFloat fsmFloat = 0f;
			addX = fsmFloat;
			FsmFloat fsmFloat2 = 0f;
			addY = fsmFloat2;
			FsmFloat fsmFloat3 = 0f;
			addZ = fsmFloat3;
			everyFrame = false;
			perSecond = false;
		}

		[Token(Token = "0x6001512")]
		[Address(RVA = "0x98852C", Offset = "0x98852C", Length = "0x3C")]
		public override void OnEnter()
		{
			DoVector3AddXYZ();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001513")]
		[Address(RVA = "0x988700", Offset = "0x988700", Length = "0x4")]
		public override void OnUpdate()
		{
			DoVector3AddXYZ();
		}

		[Token(Token = "0x6001514")]
		[Address(RVA = "0x988568", Offset = "0x988568", Length = "0x198")]
		private void DoVector3AddXYZ()
		{
			float value = addX.Value;
			float value2 = addY.Value;
			float value3 = addZ.Value;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			FsmVector3 fsmVector = vector3Variable;
			Vector3 value4 = vector3Variable.Value;
			Vector3 vector2 = default(Vector3);
			float num = default(float);
			float z;
			float y;
			Vector3 vector4;
			if (perSecond)
			{
				float deltaTime = Time.deltaTime;
				Vector3 vector = default(Vector3);
				vector.x = vector2.x;
				vector.y = num;
				vector.z = 0f;
				Vector3 vector3 = vector * deltaTime;
				z = vector3.z;
				y = vector3.y;
				vector4 = vector3;
			}
			else
			{
				z = 0f;
				y = num;
				vector4 = vector2;
			}
			Vector3 vector5 = default(Vector3);
			vector5.x = vector4.x;
			vector5.y = y;
			vector5.z = z;
			Vector3 vector6 = (fsmVector.value = value4 + vector5);
			fsmVector.value.y = vector6.y;
			fsmVector.value.z = vector6.z;
		}

		[Token(Token = "0x6001515")]
		[Address(RVA = "0x988704", Offset = "0x988704", Length = "0x8")]
		public Vector3AddXYZ()
		{
		}
	}
}
