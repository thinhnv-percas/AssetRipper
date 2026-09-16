using System;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75F268", Offset = "0x75F268")]
	[AttributeAttribute(Type = typeof(ActionTarget), RVA = "0x75F268", Offset = "0x75F268")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75F268", Offset = "0x75F268")]
	[Token(Token = "0x200037E")]
	public class SetFsmQuaternion : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CBCC4", Offset = "0x7CBCC4")]
		[Token(Token = "0x4001C21")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CBD10", Offset = "0x7CBD10")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CBD10", Offset = "0x7CBD10")]
		[Token(Token = "0x4001C22")]
		[FieldOffset(Offset = "0x58")]
		public FsmString fsmName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CBD60", Offset = "0x7CBD60")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CBD60", Offset = "0x7CBD60")]
		[Token(Token = "0x4001C23")]
		[FieldOffset(Offset = "0x60")]
		public FsmString variableName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CBDC0", Offset = "0x7CBDC0")]
		[Token(Token = "0x4001C24")]
		[FieldOffset(Offset = "0x68")]
		public FsmQuaternion setValue;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CBE0C", Offset = "0x7CBE0C")]
		[Token(Token = "0x4001C25")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x4001C26")]
		[FieldOffset(Offset = "0x78")]
		private GameObject goLastFrame;

		[Token(Token = "0x4001C27")]
		[FieldOffset(Offset = "0x80")]
		private string fsmNameLastFrame;

		[Token(Token = "0x4001C28")]
		[FieldOffset(Offset = "0x88")]
		private PlayMakerFSM fsm;

		[Token(Token = "0x6001165")]
		[Address(RVA = "0x99283C", Offset = "0x99283C", Length = "0x70")]
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

		[Token(Token = "0x6001166")]
		[Address(RVA = "0x9928AC", Offset = "0x9928AC", Length = "0x3C")]
		public override void OnEnter()
		{
			DoSetFsmQuaternion();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001167")]
		[Address(RVA = "0x9928E8", Offset = "0x9928E8", Length = "0x240")]
		private void DoSetFsmQuaternion()
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
				FsmQuaternion fsmQuaternion = fsmVariables.GetFsmQuaternion(value5);
				if (fsmQuaternion != null)
				{
					FsmQuaternion fsmQuaternion2 = setValue;
					fsmQuaternion.value.x = fsmQuaternion2.value.x;
					fsmQuaternion.value.y = fsmQuaternion2.value.y;
					fsmQuaternion.value.w = fsmQuaternion2.value.w;
					return;
				}
				value4 = variableName.Value;
				text = "Could not find variable: ";
			}
			string text2 = text + value4;
			LogWarning(text2);
		}

		[Token(Token = "0x6001168")]
		[Address(RVA = "0x992B28", Offset = "0x992B28", Length = "0x4")]
		public override void OnUpdate()
		{
			DoSetFsmQuaternion();
		}

		[Token(Token = "0x6001169")]
		[Address(RVA = "0x992B2C", Offset = "0x992B2C", Length = "0x8")]
		public SetFsmQuaternion()
		{
		}
	}
}
