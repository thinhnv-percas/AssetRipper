using System;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75F6D0", Offset = "0x75F6D0")]
	[AttributeAttribute(Type = typeof(ActionTarget), RVA = "0x75F6D0", Offset = "0x75F6D0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75F6D0", Offset = "0x75F6D0")]
	[Token(Token = "0x2000384")]
	public class SetFsmVector3 : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CC538", Offset = "0x7CC538")]
		[Token(Token = "0x4001C53")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CC584", Offset = "0x7CC584")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CC584", Offset = "0x7CC584")]
		[Token(Token = "0x4001C54")]
		[FieldOffset(Offset = "0x58")]
		public FsmString fsmName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CC5D4", Offset = "0x7CC5D4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CC5D4", Offset = "0x7CC5D4")]
		[Token(Token = "0x4001C55")]
		[FieldOffset(Offset = "0x60")]
		public FsmString variableName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CC634", Offset = "0x7CC634")]
		[Token(Token = "0x4001C56")]
		[FieldOffset(Offset = "0x68")]
		public FsmVector3 setValue;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CC680", Offset = "0x7CC680")]
		[Token(Token = "0x4001C57")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x4001C58")]
		[FieldOffset(Offset = "0x78")]
		private GameObject goLastFrame;

		[Token(Token = "0x4001C59")]
		[FieldOffset(Offset = "0x80")]
		private string fsmNameLastFrame;

		[Token(Token = "0x4001C5A")]
		[FieldOffset(Offset = "0x88")]
		private PlayMakerFSM fsm;

		[Token(Token = "0x6001183")]
		[Address(RVA = "0x993A4C", Offset = "0x993A4C", Length = "0x60")]
		public override void Reset()
		{
			gameObject = null;
			FsmString fsmString = "";
			fsmName = fsmString;
			setValue = null;
		}

		[Token(Token = "0x6001184")]
		[Address(RVA = "0x993AAC", Offset = "0x993AAC", Length = "0x3C")]
		public override void OnEnter()
		{
			DoSetFsmVector3();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001185")]
		[Address(RVA = "0x993AE8", Offset = "0x993AE8", Length = "0x23C")]
		private void DoSetFsmVector3()
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
				FsmVector3 fsmVector = fsmVariables.GetFsmVector3(value5);
				if (fsmVector != null)
				{
					Vector3 vector = (fsmVector.value = setValue.Value);
					fsmVector.value.y = vector.y;
					fsmVector.value.z = vector.z;
					return;
				}
				value4 = variableName.Value;
				text = "Could not find variable: ";
			}
			string text2 = text + value4;
			LogWarning(text2);
		}

		[Token(Token = "0x6001186")]
		[Address(RVA = "0x993D24", Offset = "0x993D24", Length = "0x4")]
		public override void OnUpdate()
		{
			DoSetFsmVector3();
		}

		[Token(Token = "0x6001187")]
		[Address(RVA = "0x993D28", Offset = "0x993D28", Length = "0x8")]
		public SetFsmVector3()
		{
		}
	}
}
