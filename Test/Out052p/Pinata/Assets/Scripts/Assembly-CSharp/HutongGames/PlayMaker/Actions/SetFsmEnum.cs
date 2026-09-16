using System;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75EE00", Offset = "0x75EE00")]
	[AttributeAttribute(Type = typeof(ActionTarget), RVA = "0x75EE00", Offset = "0x75EE00")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75EE00", Offset = "0x75EE00")]
	[Token(Token = "0x2000378")]
	public class SetFsmEnum : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CB428", Offset = "0x7CB428")]
		[Token(Token = "0x4001BF1")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CB474", Offset = "0x7CB474")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CB474", Offset = "0x7CB474")]
		[Token(Token = "0x4001BF2")]
		[FieldOffset(Offset = "0x58")]
		public FsmString fsmName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CB4C4", Offset = "0x7CB4C4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CB4C4", Offset = "0x7CB4C4")]
		[Token(Token = "0x4001BF3")]
		[FieldOffset(Offset = "0x60")]
		public FsmString variableName;

		[RequiredField]
		[Token(Token = "0x4001BF4")]
		[FieldOffset(Offset = "0x68")]
		public FsmEnum setValue;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CB534", Offset = "0x7CB534")]
		[Token(Token = "0x4001BF5")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x4001BF6")]
		[FieldOffset(Offset = "0x78")]
		private GameObject goLastFrame;

		[Token(Token = "0x4001BF7")]
		[FieldOffset(Offset = "0x80")]
		private string fsmNameLastFrame;

		[Token(Token = "0x4001BF8")]
		[FieldOffset(Offset = "0x88")]
		private PlayMakerFSM fsm;

		[Token(Token = "0x6001147")]
		[Address(RVA = "0x9916AC", Offset = "0x9916AC", Length = "0x60")]
		public override void Reset()
		{
			gameObject = null;
			FsmString fsmString = "";
			fsmName = fsmString;
			setValue = null;
		}

		[Token(Token = "0x6001148")]
		[Address(RVA = "0x99170C", Offset = "0x99170C", Length = "0x3C")]
		public override void OnEnter()
		{
			DoSetFsmEnum();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001149")]
		[Address(RVA = "0x991748", Offset = "0x991748", Length = "0x250")]
		private void DoSetFsmEnum()
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
				FsmEnum fsmEnum = fsmVariables.GetFsmEnum(value5);
				if (fsmEnum != null)
				{
					Enum value6 = setValue.Value;
					fsmEnum.Value = value6;
					return;
				}
				value4 = variableName.Value;
				text = "Could not find variable: ";
			}
			string text2 = text + value4;
			LogWarning(text2);
		}

		[Token(Token = "0x600114A")]
		[Address(RVA = "0x991998", Offset = "0x991998", Length = "0x4")]
		public override void OnUpdate()
		{
			DoSetFsmEnum();
		}

		[Token(Token = "0x600114B")]
		[Address(RVA = "0x99199C", Offset = "0x99199C", Length = "0x8")]
		public SetFsmEnum()
		{
		}
	}
}
