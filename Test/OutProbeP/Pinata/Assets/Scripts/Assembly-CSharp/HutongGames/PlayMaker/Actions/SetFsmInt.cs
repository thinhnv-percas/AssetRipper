using System;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75F034", Offset = "0x75F034")]
	[AttributeAttribute(Type = typeof(ActionTarget), RVA = "0x75F034", Offset = "0x75F034")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75F034", Offset = "0x75F034")]
	[Token(Token = "0x200037B")]
	public class SetFsmInt : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CB858", Offset = "0x7CB858")]
		[Token(Token = "0x4001C09")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CB8A4", Offset = "0x7CB8A4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CB8A4", Offset = "0x7CB8A4")]
		[Token(Token = "0x4001C0A")]
		[FieldOffset(Offset = "0x58")]
		public FsmString fsmName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CB8F4", Offset = "0x7CB8F4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CB8F4", Offset = "0x7CB8F4")]
		[Token(Token = "0x4001C0B")]
		[FieldOffset(Offset = "0x60")]
		public FsmString variableName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CB954", Offset = "0x7CB954")]
		[Token(Token = "0x4001C0C")]
		[FieldOffset(Offset = "0x68")]
		public FsmInt setValue;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CB9A0", Offset = "0x7CB9A0")]
		[Token(Token = "0x4001C0D")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x4001C0E")]
		[FieldOffset(Offset = "0x78")]
		private GameObject goLastFrame;

		[Token(Token = "0x4001C0F")]
		[FieldOffset(Offset = "0x80")]
		private string fsmNameLastFrame;

		[Token(Token = "0x4001C10")]
		[FieldOffset(Offset = "0x88")]
		private PlayMakerFSM fsm;

		[Token(Token = "0x6001156")]
		[Address(RVA = "0x991F64", Offset = "0x991F64", Length = "0x60")]
		public override void Reset()
		{
			gameObject = null;
			FsmString fsmString = "";
			fsmName = fsmString;
			setValue = null;
		}

		[Token(Token = "0x6001157")]
		[Address(RVA = "0x991FC4", Offset = "0x991FC4", Length = "0x3C")]
		public override void OnEnter()
		{
			DoSetFsmInt();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001158")]
		[Address(RVA = "0x992000", Offset = "0x992000", Length = "0x238")]
		private void DoSetFsmInt()
		{
			//IL_0137: Expected O, but got I
			//IL_015a: Expected O, but got I
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
					goto IL_0169;
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
			goto IL_0169;
			IL_0169:
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
				FsmInt fsmInt = fsmVariables.GetFsmInt(value5);
				if (fsmInt != null)
				{
					int value6 = setValue.Value;
					fsmInt.Value = value6;
					return;
				}
				value4 = variableName.Value;
				text = "Could not find variable: ";
			}
			string text2 = text + value4;
			LogWarning(text2);
		}

		[Token(Token = "0x6001159")]
		[Address(RVA = "0x992238", Offset = "0x992238", Length = "0x4")]
		public override void OnUpdate()
		{
			DoSetFsmInt();
		}

		[Token(Token = "0x600115A")]
		[Address(RVA = "0x99223C", Offset = "0x99223C", Length = "0x8")]
		public SetFsmInt()
		{
		}
	}
}
