using System;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75E350", Offset = "0x75E350")]
	[AttributeAttribute(Type = typeof(ActionTarget), RVA = "0x75E350", Offset = "0x75E350")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75E350", Offset = "0x75E350")]
	[Token(Token = "0x2000362")]
	public class GetFsmTexture : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CA6D8", Offset = "0x7CA6D8")]
		[Token(Token = "0x4001B84")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CA724", Offset = "0x7CA724")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CA724", Offset = "0x7CA724")]
		[Token(Token = "0x4001B85")]
		[FieldOffset(Offset = "0x58")]
		public FsmString fsmName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CA774", Offset = "0x7CA774")]
		[Token(Token = "0x4001B86")]
		[FieldOffset(Offset = "0x60")]
		public FsmString variableName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CA7B0", Offset = "0x7CA7B0")]
		[Token(Token = "0x4001B87")]
		[FieldOffset(Offset = "0x68")]
		public FsmTexture storeValue;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CA7EC", Offset = "0x7CA7EC")]
		[Token(Token = "0x4001B88")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x4001B89")]
		[FieldOffset(Offset = "0x78")]
		private GameObject goLastFrame;

		[Token(Token = "0x4001B8A")]
		[FieldOffset(Offset = "0x80")]
		private string fsmNameLastFrame;

		[Token(Token = "0x4001B8B")]
		[FieldOffset(Offset = "0x88")]
		protected PlayMakerFSM fsm;

		[Token(Token = "0x60010D7")]
		[Address(RVA = "0xA2DE60", Offset = "0xA2DE60", Length = "0x70")]
		public override void Reset()
		{
			gameObject = null;
			FsmString fsmString = "";
			fsmName = fsmString;
			FsmString fsmString2 = "";
			variableName = fsmString2;
			storeValue = null;
			everyFrame = false;
		}

		[Token(Token = "0x60010D8")]
		[Address(RVA = "0xA2DED0", Offset = "0xA2DED0", Length = "0x3C")]
		public override void OnEnter()
		{
			DoGetFsmVariable();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60010D9")]
		[Address(RVA = "0xA2E0F4", Offset = "0xA2E0F4", Length = "0x4")]
		public override void OnUpdate()
		{
			DoGetFsmVariable();
		}

		[Token(Token = "0x60010DA")]
		[Address(RVA = "0xA2DF0C", Offset = "0xA2DF0C", Length = "0x1E8")]
		private void DoGetFsmVariable()
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
			if (!(playMakerFSM == null) && storeValue != null)
			{
				FsmVariables fsmVariables = ((PlayMakerFSM)obj).FsmVariables;
				string value4 = variableName.Value;
				FsmTexture fsmTexture = fsmVariables.GetFsmTexture(value4);
				if (fsmTexture != null)
				{
					Texture value5 = fsmTexture.Value;
					storeValue.Value = value5;
				}
			}
		}

		[Token(Token = "0x60010DB")]
		[Address(RVA = "0xA2E0F8", Offset = "0xA2E0F8", Length = "0x8")]
		public GetFsmTexture()
		{
		}
	}
}
