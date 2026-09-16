using System;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75EF78", Offset = "0x75EF78")]
	[AttributeAttribute(Type = typeof(ActionTarget), RVA = "0x75EF78", Offset = "0x75EF78")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75EF78", Offset = "0x75EF78")]
	[Token(Token = "0x200037A")]
	public class SetFsmGameObject : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CB6EC", Offset = "0x7CB6EC")]
		[Token(Token = "0x4001C01")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CB738", Offset = "0x7CB738")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CB738", Offset = "0x7CB738")]
		[Token(Token = "0x4001C02")]
		[FieldOffset(Offset = "0x58")]
		public FsmString fsmName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CB788", Offset = "0x7CB788")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CB788", Offset = "0x7CB788")]
		[Token(Token = "0x4001C03")]
		[FieldOffset(Offset = "0x60")]
		public FsmString variableName;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CB7E8", Offset = "0x7CB7E8")]
		[Token(Token = "0x4001C04")]
		[FieldOffset(Offset = "0x68")]
		public FsmGameObject setValue;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CB820", Offset = "0x7CB820")]
		[Token(Token = "0x4001C05")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x4001C06")]
		[FieldOffset(Offset = "0x78")]
		private GameObject goLastFrame;

		[Token(Token = "0x4001C07")]
		[FieldOffset(Offset = "0x80")]
		private string fsmNameLastFrame;

		[Token(Token = "0x4001C08")]
		[FieldOffset(Offset = "0x88")]
		private PlayMakerFSM fsm;

		[Token(Token = "0x6001151")]
		[Address(RVA = "0x991C84", Offset = "0x991C84", Length = "0x64")]
		public override void Reset()
		{
			gameObject = null;
			FsmString fsmString = "";
			fsmName = fsmString;
			setValue = null;
			everyFrame = false;
		}

		[Token(Token = "0x6001152")]
		[Address(RVA = "0x991CE8", Offset = "0x991CE8", Length = "0x3C")]
		public override void OnEnter()
		{
			DoSetFsmGameObject();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001153")]
		[Address(RVA = "0x991D24", Offset = "0x991D24", Length = "0x234")]
		private void DoSetFsmGameObject()
		{
			//IL_0137: Expected O, but got I
			//IL_015a: Expected O, but got I
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
			if (playMakerFSM == null)
			{
				return;
			}
			FsmVariables fsmVariables = ((PlayMakerFSM)obj).FsmVariables;
			string value4 = variableName.Value;
			FsmGameObject fsmGameObject = fsmVariables.FindFsmGameObject(value4);
			if (fsmGameObject != null)
			{
				GameObject value6;
				if (setValue != null)
				{
					GameObject value5 = setValue.Value;
					value6 = value5;
				}
				else
				{
					value6 = null;
				}
				fsmGameObject.Value = value6;
			}
			else
			{
				string value7 = variableName.Value;
				string text = "Could not find variable: " + value7;
				LogWarning(text);
			}
		}

		[Token(Token = "0x6001154")]
		[Address(RVA = "0x991F58", Offset = "0x991F58", Length = "0x4")]
		public override void OnUpdate()
		{
			DoSetFsmGameObject();
		}

		[Token(Token = "0x6001155")]
		[Address(RVA = "0x991F5C", Offset = "0x991F5C", Length = "0x8")]
		public SetFsmGameObject()
		{
		}
	}
}
