using System;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75E584", Offset = "0x75E584")]
	[AttributeAttribute(Type = typeof(ActionTarget), RVA = "0x75E584", Offset = "0x75E584")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75E584", Offset = "0x75E584")]
	[Token(Token = "0x2000365")]
	public class GetFsmVector2 : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x4001B9E")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CAABC", Offset = "0x7CAABC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CAABC", Offset = "0x7CAABC")]
		[Token(Token = "0x4001B9F")]
		[FieldOffset(Offset = "0x58")]
		public FsmString fsmName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CAB0C", Offset = "0x7CAB0C")]
		[Token(Token = "0x4001BA0")]
		[FieldOffset(Offset = "0x60")]
		public FsmString variableName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CAB48", Offset = "0x7CAB48")]
		[Token(Token = "0x4001BA1")]
		[FieldOffset(Offset = "0x68")]
		public FsmVector2 storeValue;

		[Token(Token = "0x4001BA2")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x4001BA3")]
		[FieldOffset(Offset = "0x78")]
		private GameObject goLastFrame;

		[Token(Token = "0x4001BA4")]
		[FieldOffset(Offset = "0x80")]
		private string fsmNameLastFrame;

		[Token(Token = "0x4001BA5")]
		[FieldOffset(Offset = "0x88")]
		private PlayMakerFSM fsm;

		[Token(Token = "0x60010E8")]
		[Address(RVA = "0xA2E90C", Offset = "0xA2E90C", Length = "0x60")]
		public override void Reset()
		{
			gameObject = null;
			FsmString fsmString = "";
			fsmName = fsmString;
			storeValue = null;
		}

		[Token(Token = "0x60010E9")]
		[Address(RVA = "0xA2E96C", Offset = "0xA2E96C", Length = "0x3C")]
		public override void OnEnter()
		{
			DoGetFsmVector2();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60010EA")]
		[Address(RVA = "0xA2EB74", Offset = "0xA2EB74", Length = "0x4")]
		public override void OnUpdate()
		{
			DoGetFsmVector2();
		}

		[Token(Token = "0x60010EB")]
		[Address(RVA = "0xA2E9A8", Offset = "0xA2E9A8", Length = "0x1CC")]
		private void DoGetFsmVector2()
		{
			//IL_0137: Expected O, but got I
			//IL_015a: Expected O, but got I
			if (storeValue == null)
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
			if (!(playMakerFSM == null))
			{
				FsmVariables fsmVariables = ((PlayMakerFSM)obj).FsmVariables;
				string value4 = variableName.Value;
				FsmVector2 fsmVector = fsmVariables.GetFsmVector2(value4);
				if (fsmVector != null)
				{
					FsmVector2 fsmVector2 = storeValue;
					fsmVector2.value = fsmVector.value;
					fsmVector2.value.y = fsmVector.value.y;
				}
			}
		}

		[Token(Token = "0x60010EC")]
		[Address(RVA = "0xA2EB78", Offset = "0xA2EB78", Length = "0x8")]
		public GetFsmVector2()
		{
		}
	}
}
