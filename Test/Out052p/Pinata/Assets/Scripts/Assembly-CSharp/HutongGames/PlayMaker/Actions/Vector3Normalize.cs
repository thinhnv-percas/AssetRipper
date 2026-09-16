using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7635F8", Offset = "0x7635F8")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7635F8", Offset = "0x7635F8")]
	[Token(Token = "0x2000449")]
	public class Vector3Normalize : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7DB024", Offset = "0x7DB024")]
		[Token(Token = "0x4002027")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector3 vector3Variable;

		[Token(Token = "0x4002028")]
		[FieldOffset(Offset = "0x58")]
		public bool everyFrame;

		[Token(Token = "0x6001534")]
		[Address(RVA = "0x989568", Offset = "0x989568", Length = "0xC")]
		public override void Reset()
		{
			vector3Variable = null;
			everyFrame = false;
		}

		[Token(Token = "0x6001535")]
		[Address(RVA = "0x989574", Offset = "0x989574", Length = "0x78")]
		public override void OnEnter()
		{
			FsmVector3 fsmVector = vector3Variable;
			Vector3 value = vector3Variable.Value;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158A710 (inside UnityEngine.Vector3::get_zero +0x15C)");
			fsmVector.value = value;
			fsmVector.value.y = value.y;
			fsmVector.value.z = value.z;
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001536")]
		[Address(RVA = "0x9895EC", Offset = "0x9895EC", Length = "0x60")]
		public override void OnUpdate()
		{
			FsmVector3 fsmVector = vector3Variable;
			Vector3 value = vector3Variable.Value;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158A710 (inside UnityEngine.Vector3::get_zero +0x15C)");
			fsmVector.value = value;
			fsmVector.value.y = value.y;
			fsmVector.value.z = value.z;
		}

		[Token(Token = "0x6001537")]
		[Address(RVA = "0x98964C", Offset = "0x98964C", Length = "0x8")]
		public Vector3Normalize()
		{
		}
	}
}
