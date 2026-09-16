using System;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75F1AC", Offset = "0x75F1AC")]
	[AttributeAttribute(Type = typeof(ActionTarget), RVA = "0x75F1AC", Offset = "0x75F1AC")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75F1AC", Offset = "0x75F1AC")]
	[Token(Token = "0x200037D")]
	public class SetFsmObject : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CBB58", Offset = "0x7CBB58")]
		[Token(Token = "0x4001C19")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CBBA4", Offset = "0x7CBBA4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CBBA4", Offset = "0x7CBBA4")]
		[Token(Token = "0x4001C1A")]
		[FieldOffset(Offset = "0x58")]
		public FsmString fsmName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CBBF4", Offset = "0x7CBBF4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CBBF4", Offset = "0x7CBBF4")]
		[Token(Token = "0x4001C1B")]
		[FieldOffset(Offset = "0x60")]
		public FsmString variableName;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CBC54", Offset = "0x7CBC54")]
		[Token(Token = "0x4001C1C")]
		[FieldOffset(Offset = "0x68")]
		public FsmObject setValue;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CBC8C", Offset = "0x7CBC8C")]
		[Token(Token = "0x4001C1D")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x4001C1E")]
		[FieldOffset(Offset = "0x78")]
		private GameObject goLastFrame;

		[Token(Token = "0x4001C1F")]
		[FieldOffset(Offset = "0x80")]
		private string fsmNameLastFrame;

		[Token(Token = "0x4001C20")]
		[FieldOffset(Offset = "0x88")]
		private PlayMakerFSM fsm;

		[Token(Token = "0x6001160")]
		[Address(RVA = "0x99254C", Offset = "0x99254C", Length = "0x70")]
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

		[Token(Token = "0x6001161")]
		[Address(RVA = "0x9925BC", Offset = "0x9925BC", Length = "0x3C")]
		public override void OnEnter()
		{
			DoSetFsmBool();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001162")]
		[Address(RVA = "0x9925F8", Offset = "0x9925F8", Length = "0x238")]
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
				FsmObject fsmObject = fsmVariables.GetFsmObject(value5);
				if (fsmObject != null)
				{
					UnityEngine.Object value6 = setValue.Value;
					fsmObject.Value = value6;
					return;
				}
				value4 = variableName.Value;
				text = "Could not find variable: ";
			}
			string text2 = text + value4;
			LogWarning(text2);
		}

		[Token(Token = "0x6001163")]
		[Address(RVA = "0x992830", Offset = "0x992830", Length = "0x4")]
		public override void OnUpdate()
		{
			DoSetFsmBool();
		}

		[Token(Token = "0x6001164")]
		[Address(RVA = "0x992834", Offset = "0x992834", Length = "0x8")]
		public SetFsmObject()
		{
		}
	}
}
