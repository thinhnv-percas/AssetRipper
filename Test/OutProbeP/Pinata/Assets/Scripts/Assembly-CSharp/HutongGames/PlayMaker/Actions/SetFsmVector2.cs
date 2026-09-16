using System;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75F614", Offset = "0x75F614")]
	[AttributeAttribute(Type = typeof(ActionTarget), RVA = "0x75F614", Offset = "0x75F614")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75F614", Offset = "0x75F614")]
	[Token(Token = "0x2000383")]
	public class SetFsmVector2 : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CC3B8", Offset = "0x7CC3B8")]
		[Token(Token = "0x4001C4B")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CC404", Offset = "0x7CC404")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CC404", Offset = "0x7CC404")]
		[Token(Token = "0x4001C4C")]
		[FieldOffset(Offset = "0x58")]
		public FsmString fsmName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CC454", Offset = "0x7CC454")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CC454", Offset = "0x7CC454")]
		[Token(Token = "0x4001C4D")]
		[FieldOffset(Offset = "0x60")]
		public FsmString variableName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CC4B4", Offset = "0x7CC4B4")]
		[Token(Token = "0x4001C4E")]
		[FieldOffset(Offset = "0x68")]
		public FsmVector2 setValue;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CC500", Offset = "0x7CC500")]
		[Token(Token = "0x4001C4F")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x4001C50")]
		[FieldOffset(Offset = "0x78")]
		private GameObject goLastFrame;

		[Token(Token = "0x4001C51")]
		[FieldOffset(Offset = "0x80")]
		private string fsmNameLastFrame;

		[Token(Token = "0x4001C52")]
		[FieldOffset(Offset = "0x88")]
		private PlayMakerFSM fsm;

		[Token(Token = "0x600117E")]
		[Address(RVA = "0x993774", Offset = "0x993774", Length = "0x60")]
		public override void Reset()
		{
			gameObject = null;
			FsmString fsmString = "";
			fsmName = fsmString;
			setValue = null;
		}

		[Token(Token = "0x600117F")]
		[Address(RVA = "0x9937D4", Offset = "0x9937D4", Length = "0x3C")]
		public override void OnEnter()
		{
			DoSetFsmVector2();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001180")]
		[Address(RVA = "0x993810", Offset = "0x993810", Length = "0x230")]
		private void DoSetFsmVector2()
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
				FsmVector2 fsmVector = fsmVariables.GetFsmVector2(value5);
				if (fsmVector != null)
				{
					FsmVector2 fsmVector2 = setValue;
					fsmVector.value = fsmVector2.value;
					fsmVector.value.y = fsmVector2.value.y;
					return;
				}
				value4 = variableName.Value;
				text = "Could not find variable: ";
			}
			string text2 = text + value4;
			LogWarning(text2);
		}

		[Token(Token = "0x6001181")]
		[Address(RVA = "0x993A40", Offset = "0x993A40", Length = "0x4")]
		public override void OnUpdate()
		{
			DoSetFsmVector2();
		}

		[Token(Token = "0x6001182")]
		[Address(RVA = "0x993A44", Offset = "0x993A44", Length = "0x8")]
		public SetFsmVector2()
		{
		}
	}
}
