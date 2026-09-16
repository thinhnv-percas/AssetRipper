using System;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75F3E0", Offset = "0x75F3E0")]
	[AttributeAttribute(Type = typeof(ActionTarget), RVA = "0x75F3E0", Offset = "0x75F3E0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75F3E0", Offset = "0x75F3E0")]
	[Token(Token = "0x2000380")]
	public class SetFsmString : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CBFC4", Offset = "0x7CBFC4")]
		[Token(Token = "0x4001C31")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CC010", Offset = "0x7CC010")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CC010", Offset = "0x7CC010")]
		[Token(Token = "0x4001C32")]
		[FieldOffset(Offset = "0x58")]
		public FsmString fsmName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CC060", Offset = "0x7CC060")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CC060", Offset = "0x7CC060")]
		[Token(Token = "0x4001C33")]
		[FieldOffset(Offset = "0x60")]
		public FsmString variableName;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CC0C0", Offset = "0x7CC0C0")]
		[Token(Token = "0x4001C34")]
		[FieldOffset(Offset = "0x68")]
		public FsmString setValue;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CC0F8", Offset = "0x7CC0F8")]
		[Token(Token = "0x4001C35")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x4001C36")]
		[FieldOffset(Offset = "0x78")]
		private GameObject goLastFrame;

		[Token(Token = "0x4001C37")]
		[FieldOffset(Offset = "0x80")]
		private string fsmNameLastFrame;

		[Token(Token = "0x4001C38")]
		[FieldOffset(Offset = "0x88")]
		private PlayMakerFSM fsm;

		[Token(Token = "0x600116F")]
		[Address(RVA = "0x992E2C", Offset = "0x992E2C", Length = "0x60")]
		public override void Reset()
		{
			gameObject = null;
			FsmString fsmString = "";
			fsmName = fsmString;
			setValue = null;
		}

		[Token(Token = "0x6001170")]
		[Address(RVA = "0x992E8C", Offset = "0x992E8C", Length = "0x3C")]
		public override void OnEnter()
		{
			DoSetFsmString();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001171")]
		[Address(RVA = "0x992EC8", Offset = "0x992EC8", Length = "0x238")]
		private void DoSetFsmString()
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
				FsmString fsmString = fsmVariables.GetFsmString(value5);
				if (fsmString != null)
				{
					string value6 = setValue.Value;
					fsmString.Value = value6;
					return;
				}
				value4 = variableName.Value;
				text = "Could not find variable: ";
			}
			string text2 = text + value4;
			LogWarning(text2);
		}

		[Token(Token = "0x6001172")]
		[Address(RVA = "0x993100", Offset = "0x993100", Length = "0x4")]
		public override void OnUpdate()
		{
			DoSetFsmString();
		}

		[Token(Token = "0x6001173")]
		[Address(RVA = "0x993104", Offset = "0x993104", Length = "0x8")]
		public SetFsmString()
		{
		}
	}
}
