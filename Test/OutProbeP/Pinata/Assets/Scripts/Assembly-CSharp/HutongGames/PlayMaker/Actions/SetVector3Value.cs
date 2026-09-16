using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x763288", Offset = "0x763288")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x763288", Offset = "0x763288")]
	[Token(Token = "0x200043E")]
	public class SetVector3Value : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7DAADC", Offset = "0x7DAADC")]
		[Token(Token = "0x4001FF8")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector3 vector3Variable;

		[RequiredField]
		[Token(Token = "0x4001FF9")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector3 vector3Value;

		[Token(Token = "0x4001FFA")]
		[FieldOffset(Offset = "0x60")]
		public bool everyFrame;

		[Token(Token = "0x6001503")]
		[Address(RVA = "0x99ADAC", Offset = "0x99ADAC", Length = "0xC")]
		public override void Reset()
		{
			everyFrame = false;
			vector3Variable = null;
			vector3Value = null;
		}

		[Token(Token = "0x6001504")]
		[Address(RVA = "0x99ADB8", Offset = "0x99ADB8", Length = "0x64")]
		public override void OnEnter()
		{
			FsmVector3 fsmVector = vector3Variable;
			Vector3 vector = (fsmVector.value = vector3Value.Value);
			fsmVector.value.y = vector.y;
			fsmVector.value.z = vector.z;
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001505")]
		[Address(RVA = "0x99AE1C", Offset = "0x99AE1C", Length = "0x48")]
		public override void OnUpdate()
		{
			FsmVector3 fsmVector = vector3Variable;
			Vector3 vector = (fsmVector.value = vector3Value.Value);
			fsmVector.value.y = vector.y;
			fsmVector.value.z = vector.z;
		}

		[Token(Token = "0x6001506")]
		[Address(RVA = "0x99AE64", Offset = "0x99AE64", Length = "0x8")]
		public SetVector3Value()
		{
		}
	}
}
