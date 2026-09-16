using System;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75E640", Offset = "0x75E640")]
	[AttributeAttribute(Type = typeof(ActionTarget), RVA = "0x75E640", Offset = "0x75E640")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75E640", Offset = "0x75E640")]
	[Token(Token = "0x2000366")]
	public class GetFsmVector3 : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x4001BA6")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CAB94", Offset = "0x7CAB94")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CAB94", Offset = "0x7CAB94")]
		[Token(Token = "0x4001BA7")]
		[FieldOffset(Offset = "0x58")]
		public FsmString fsmName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CABE4", Offset = "0x7CABE4")]
		[Token(Token = "0x4001BA8")]
		[FieldOffset(Offset = "0x60")]
		public FsmString variableName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CAC20", Offset = "0x7CAC20")]
		[Token(Token = "0x4001BA9")]
		[FieldOffset(Offset = "0x68")]
		public FsmVector3 storeValue;

		[Token(Token = "0x4001BAA")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x4001BAB")]
		[FieldOffset(Offset = "0x78")]
		private GameObject goLastFrame;

		[Token(Token = "0x4001BAC")]
		[FieldOffset(Offset = "0x80")]
		private string fsmNameLastFrame;

		[Token(Token = "0x4001BAD")]
		[FieldOffset(Offset = "0x88")]
		private PlayMakerFSM fsm;

		[Token(Token = "0x60010ED")]
		[Address(RVA = "0xA2EB80", Offset = "0xA2EB80", Length = "0x60")]
		public override void Reset()
		{
			gameObject = null;
			FsmString fsmString = "";
			fsmName = fsmString;
			storeValue = null;
		}

		[Token(Token = "0x60010EE")]
		[Address(RVA = "0xA2EBE0", Offset = "0xA2EBE0", Length = "0x3C")]
		public override void OnEnter()
		{
			DoGetFsmVector3();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60010EF")]
		[Address(RVA = "0xA2EDF0", Offset = "0xA2EDF0", Length = "0x4")]
		public override void OnUpdate()
		{
			DoGetFsmVector3();
		}

		[Token(Token = "0x60010F0")]
		[Address(RVA = "0xA2EC1C", Offset = "0xA2EC1C", Length = "0x1D4")]
		private void DoGetFsmVector3()
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
				FsmVector3 fsmVector = fsmVariables.GetFsmVector3(value4);
				if (fsmVector != null)
				{
					FsmVector3 fsmVector2 = storeValue;
					Vector3 vector = (fsmVector2.value = fsmVector.Value);
					fsmVector2.value.y = vector.y;
					fsmVector2.value.z = vector.z;
				}
			}
		}

		[Token(Token = "0x60010F1")]
		[Address(RVA = "0xA2EDF4", Offset = "0xA2EDF4", Length = "0x8")]
		public GetFsmVector3()
		{
		}
	}
}
