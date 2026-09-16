using System;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75ED44", Offset = "0x75ED44")]
	[AttributeAttribute(Type = typeof(ActionTarget), RVA = "0x75ED44", Offset = "0x75ED44")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75ED44", Offset = "0x75ED44")]
	[Token(Token = "0x2000377")]
	public class SetFsmColor : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CB2A8", Offset = "0x7CB2A8")]
		[Token(Token = "0x4001BE9")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CB2F4", Offset = "0x7CB2F4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CB2F4", Offset = "0x7CB2F4")]
		[Token(Token = "0x4001BEA")]
		[FieldOffset(Offset = "0x58")]
		public FsmString fsmName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CB344", Offset = "0x7CB344")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CB344", Offset = "0x7CB344")]
		[Token(Token = "0x4001BEB")]
		[FieldOffset(Offset = "0x60")]
		public FsmString variableName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CB3A4", Offset = "0x7CB3A4")]
		[Token(Token = "0x4001BEC")]
		[FieldOffset(Offset = "0x68")]
		public FsmColor setValue;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CB3F0", Offset = "0x7CB3F0")]
		[Token(Token = "0x4001BED")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x4001BEE")]
		[FieldOffset(Offset = "0x78")]
		private GameObject goLastFrame;

		[Token(Token = "0x4001BEF")]
		[FieldOffset(Offset = "0x80")]
		private string fsmNameLastFrame;

		[Token(Token = "0x4001BF0")]
		[FieldOffset(Offset = "0x88")]
		private PlayMakerFSM fsm;

		[Token(Token = "0x6001142")]
		[Address(RVA = "0x9913C4", Offset = "0x9913C4", Length = "0x60")]
		public override void Reset()
		{
			gameObject = null;
			FsmString fsmString = "";
			fsmName = fsmString;
			setValue = null;
		}

		[Token(Token = "0x6001143")]
		[Address(RVA = "0x991424", Offset = "0x991424", Length = "0x3C")]
		public override void OnEnter()
		{
			DoSetFsmColor();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001144")]
		[Address(RVA = "0x991460", Offset = "0x991460", Length = "0x240")]
		private void DoSetFsmColor()
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
				FsmColor fsmColor = fsmVariables.GetFsmColor(value5);
				if (fsmColor != null)
				{
					FsmColor fsmColor2 = setValue;
					fsmColor.value.r = fsmColor2.value.r;
					fsmColor.value.g = fsmColor2.value.g;
					fsmColor.value.a = fsmColor2.value.a;
					return;
				}
				value4 = variableName.Value;
				text = "Could not find variable: ";
			}
			string text2 = text + value4;
			LogWarning(text2);
		}

		[Token(Token = "0x6001145")]
		[Address(RVA = "0x9916A0", Offset = "0x9916A0", Length = "0x4")]
		public override void OnUpdate()
		{
			DoSetFsmColor();
		}

		[Token(Token = "0x6001146")]
		[Address(RVA = "0x9916A4", Offset = "0x9916A4", Length = "0x8")]
		public SetFsmColor()
		{
		}
	}
}
