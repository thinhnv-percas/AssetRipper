using System;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75F324", Offset = "0x75F324")]
	[AttributeAttribute(Type = typeof(ActionTarget), RVA = "0x75F324", Offset = "0x75F324")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75F324", Offset = "0x75F324")]
	[Token(Token = "0x200037F")]
	public class SetFsmRect : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CBE44", Offset = "0x7CBE44")]
		[Token(Token = "0x4001C29")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CBE90", Offset = "0x7CBE90")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CBE90", Offset = "0x7CBE90")]
		[Token(Token = "0x4001C2A")]
		[FieldOffset(Offset = "0x58")]
		public FsmString fsmName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CBEE0", Offset = "0x7CBEE0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CBEE0", Offset = "0x7CBEE0")]
		[Token(Token = "0x4001C2B")]
		[FieldOffset(Offset = "0x60")]
		public FsmString variableName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CBF40", Offset = "0x7CBF40")]
		[Token(Token = "0x4001C2C")]
		[FieldOffset(Offset = "0x68")]
		public FsmRect setValue;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CBF8C", Offset = "0x7CBF8C")]
		[Token(Token = "0x4001C2D")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x4001C2E")]
		[FieldOffset(Offset = "0x78")]
		private GameObject goLastFrame;

		[Token(Token = "0x4001C2F")]
		[FieldOffset(Offset = "0x80")]
		private string fsmNameLastFrame;

		[Token(Token = "0x4001C30")]
		[FieldOffset(Offset = "0x88")]
		private PlayMakerFSM fsm;

		[Token(Token = "0x600116A")]
		[Address(RVA = "0x992B34", Offset = "0x992B34", Length = "0x70")]
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

		[Token(Token = "0x600116B")]
		[Address(RVA = "0x992BA4", Offset = "0x992BA4", Length = "0x3C")]
		public override void OnEnter()
		{
			DoSetFsmBool();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x600116C")]
		[Address(RVA = "0x992BE0", Offset = "0x992BE0", Length = "0x240")]
		private void DoSetFsmBool()
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
				FsmRect fsmRect = fsmVariables.GetFsmRect(value5);
				if (fsmRect != null)
				{
					FsmRect fsmRect2 = setValue;
					fsmRect.value.x = fsmRect2.value.x;
					fsmRect.value.y = fsmRect2.value.y;
					fsmRect.value.height = fsmRect2.value.height;
					return;
				}
				value4 = variableName.Value;
				text = "Could not find variable: ";
			}
			string text2 = text + value4;
			LogWarning(text2);
		}

		[Token(Token = "0x600116D")]
		[Address(RVA = "0x992E20", Offset = "0x992E20", Length = "0x4")]
		public override void OnUpdate()
		{
			DoSetFsmBool();
		}

		[Token(Token = "0x600116E")]
		[Address(RVA = "0x992E24", Offset = "0x992E24", Length = "0x8")]
		public SetFsmRect()
		{
		}
	}
}
