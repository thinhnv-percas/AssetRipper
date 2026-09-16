using System;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75F0F0", Offset = "0x75F0F0")]
	[AttributeAttribute(Type = typeof(ActionTarget), RVA = "0x75F0F0", Offset = "0x75F0F0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75F0F0", Offset = "0x75F0F0")]
	[Token(Token = "0x200037C")]
	public class SetFsmMaterial : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CB9D8", Offset = "0x7CB9D8")]
		[Token(Token = "0x4001C11")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CBA24", Offset = "0x7CBA24")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CBA24", Offset = "0x7CBA24")]
		[Token(Token = "0x4001C12")]
		[FieldOffset(Offset = "0x58")]
		public FsmString fsmName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CBA74", Offset = "0x7CBA74")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CBA74", Offset = "0x7CBA74")]
		[Token(Token = "0x4001C13")]
		[FieldOffset(Offset = "0x60")]
		public FsmString variableName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CBAD4", Offset = "0x7CBAD4")]
		[Token(Token = "0x4001C14")]
		[FieldOffset(Offset = "0x68")]
		public FsmMaterial setValue;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CBB20", Offset = "0x7CBB20")]
		[Token(Token = "0x4001C15")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x4001C16")]
		[FieldOffset(Offset = "0x78")]
		private GameObject goLastFrame;

		[Token(Token = "0x4001C17")]
		[FieldOffset(Offset = "0x80")]
		private string fsmNameLastFrame;

		[Token(Token = "0x4001C18")]
		[FieldOffset(Offset = "0x88")]
		private PlayMakerFSM fsm;

		[Token(Token = "0x600115B")]
		[Address(RVA = "0x992244", Offset = "0x992244", Length = "0x70")]
		public override void Reset()
		{
			gameObject = null;
			FsmString fsmString = "";
			fsmName = fsmString;
			FsmString fsmString2 = "";
			variableName = fsmString2;
			setValue = null;
			everyFrame = false;
		}

		[Token(Token = "0x600115C")]
		[Address(RVA = "0x9922B4", Offset = "0x9922B4", Length = "0x3C")]
		public override void OnEnter()
		{
			DoSetFsmBool();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x600115D")]
		[Address(RVA = "0x9922F0", Offset = "0x9922F0", Length = "0x250")]
		private void DoSetFsmBool()
		{
			//IL_012d: Expected O, but got I
			//IL_0150: Expected O, but got I
			if (setValue == null)
			{
				return;
			}
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (ownerDefaultTarget == null)
			{
				return;
			}
			object obj;
			PlayMakerFSM playMakerFSM;
			if (!(ownerDefaultTarget != goLastFrame))
			{
				string value = fsmName.Value;
				if (!(value != fsmNameLastFrame))
				{
					obj = (long)(IntPtr)this + 136L;
					playMakerFSM = fsm;
					goto IL_015f;
				}
			}
			goLastFrame = ownerDefaultTarget;
			string value2 = fsmName.Value;
			fsmNameLastFrame = value2;
			string value3 = fsmName.Value;
			PlayMakerFSM gameObjectFsm = ActionHelpers.GetGameObjectFsm(ownerDefaultTarget, value3);
			obj = (long)(IntPtr)this + 136L;
			fsm = gameObjectFsm;
			playMakerFSM = gameObjectFsm;
			goto IL_015f;
			IL_015f:
			string value4;
			string text;
			if (playMakerFSM == null)
			{
				value4 = fsmName.Value;
				text = "Could not find FSM: ";
			}
			else
			{
				FsmVariables fsmVariables = ((PlayMakerFSM)obj).FsmVariables;
				string value5 = variableName.Value;
				FsmMaterial fsmMaterial = fsmVariables.GetFsmMaterial(value5);
				if (fsmMaterial != null)
				{
					Material value6 = setValue.Value;
					fsmMaterial.Value = value6;
					return;
				}
				value4 = variableName.Value;
				text = "Could not find variable: ";
			}
			string text2 = text + value4;
			LogWarning(text2);
		}

		[Token(Token = "0x600115E")]
		[Address(RVA = "0x992540", Offset = "0x992540", Length = "0x4")]
		public override void OnUpdate()
		{
			DoSetFsmBool();
		}

		[Token(Token = "0x600115F")]
		[Address(RVA = "0x992544", Offset = "0x992544", Length = "0x8")]
		public SetFsmMaterial()
		{
		}
	}
}
