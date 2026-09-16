using System;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75F49C", Offset = "0x75F49C")]
	[AttributeAttribute(Type = typeof(ActionTarget), RVA = "0x75F49C", Offset = "0x75F49C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75F49C", Offset = "0x75F49C")]
	[Token(Token = "0x2000381")]
	public class SetFsmTexture : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CC130", Offset = "0x7CC130")]
		[Token(Token = "0x4001C39")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CC17C", Offset = "0x7CC17C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CC17C", Offset = "0x7CC17C")]
		[Token(Token = "0x4001C3A")]
		[FieldOffset(Offset = "0x58")]
		public FsmString fsmName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CC1CC", Offset = "0x7CC1CC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CC1CC", Offset = "0x7CC1CC")]
		[Token(Token = "0x4001C3B")]
		[FieldOffset(Offset = "0x60")]
		public FsmString variableName;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CC22C", Offset = "0x7CC22C")]
		[Token(Token = "0x4001C3C")]
		[FieldOffset(Offset = "0x68")]
		public FsmTexture setValue;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CC264", Offset = "0x7CC264")]
		[Token(Token = "0x4001C3D")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x4001C3E")]
		[FieldOffset(Offset = "0x78")]
		private GameObject goLastFrame;

		[Token(Token = "0x4001C3F")]
		[FieldOffset(Offset = "0x80")]
		private string fsmNameLastFrame;

		[Token(Token = "0x4001C40")]
		[FieldOffset(Offset = "0x88")]
		private PlayMakerFSM fsm;

		[Token(Token = "0x6001174")]
		[Address(RVA = "0x99310C", Offset = "0x99310C", Length = "0x70")]
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

		[Token(Token = "0x6001175")]
		[Address(RVA = "0x99317C", Offset = "0x99317C", Length = "0x3C")]
		public override void OnEnter()
		{
			DoSetFsmTexture();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001176")]
		[Address(RVA = "0x9931B8", Offset = "0x9931B8", Length = "0x250")]
		private void DoSetFsmTexture()
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
				FsmTexture fsmTexture = fsmVariables.FindFsmTexture(value5);
				if (fsmTexture != null)
				{
					Texture value6 = setValue.Value;
					fsmTexture.Value = value6;
					return;
				}
				value4 = variableName.Value;
				text = "Could not find variable: ";
			}
			string text2 = text + value4;
			LogWarning(text2);
		}

		[Token(Token = "0x6001177")]
		[Address(RVA = "0x993408", Offset = "0x993408", Length = "0x4")]
		public override void OnUpdate()
		{
			DoSetFsmTexture();
		}

		[Token(Token = "0x6001178")]
		[Address(RVA = "0x99340C", Offset = "0x99340C", Length = "0x8")]
		public SetFsmTexture()
		{
		}
	}
}
