using System;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75EEBC", Offset = "0x75EEBC")]
	[AttributeAttribute(Type = typeof(ActionTarget), RVA = "0x75EEBC", Offset = "0x75EEBC")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75EEBC", Offset = "0x75EEBC")]
	[Token(Token = "0x2000379")]
	public class SetFsmFloat : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CB56C", Offset = "0x7CB56C")]
		[Token(Token = "0x4001BF9")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CB5B8", Offset = "0x7CB5B8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CB5B8", Offset = "0x7CB5B8")]
		[Token(Token = "0x4001BFA")]
		[FieldOffset(Offset = "0x58")]
		public FsmString fsmName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CB608", Offset = "0x7CB608")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CB608", Offset = "0x7CB608")]
		[Token(Token = "0x4001BFB")]
		[FieldOffset(Offset = "0x60")]
		public FsmString variableName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CB668", Offset = "0x7CB668")]
		[Token(Token = "0x4001BFC")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat setValue;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CB6B4", Offset = "0x7CB6B4")]
		[Token(Token = "0x4001BFD")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x4001BFE")]
		[FieldOffset(Offset = "0x78")]
		private GameObject goLastFrame;

		[Token(Token = "0x4001BFF")]
		[FieldOffset(Offset = "0x80")]
		private string fsmNameLastFrame;

		[Token(Token = "0x4001C00")]
		[FieldOffset(Offset = "0x88")]
		private PlayMakerFSM fsm;

		[Token(Token = "0x600114C")]
		[Address(RVA = "0x9919A4", Offset = "0x9919A4", Length = "0x60")]
		public override void Reset()
		{
			gameObject = null;
			FsmString fsmString = "";
			fsmName = fsmString;
			setValue = null;
		}

		[Token(Token = "0x600114D")]
		[Address(RVA = "0x991A04", Offset = "0x991A04", Length = "0x3C")]
		public override void OnEnter()
		{
			DoSetFsmFloat();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x600114E")]
		[Address(RVA = "0x991A40", Offset = "0x991A40", Length = "0x238")]
		private void DoSetFsmFloat()
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
				FsmFloat fsmFloat = fsmVariables.GetFsmFloat(value5);
				if (fsmFloat != null)
				{
					float value6 = setValue.Value;
					fsmFloat.Value = value6;
					return;
				}
				value4 = variableName.Value;
				text = "Could not find variable: ";
			}
			string text2 = text + value4;
			LogWarning(text2);
		}

		[Token(Token = "0x600114F")]
		[Address(RVA = "0x991C78", Offset = "0x991C78", Length = "0x4")]
		public override void OnUpdate()
		{
			DoSetFsmFloat();
		}

		[Token(Token = "0x6001150")]
		[Address(RVA = "0x991C7C", Offset = "0x991C7C", Length = "0x8")]
		public SetFsmFloat()
		{
		}
	}
}
