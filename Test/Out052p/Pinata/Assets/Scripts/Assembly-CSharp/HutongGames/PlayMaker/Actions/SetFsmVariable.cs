using System;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75F558", Offset = "0x75F558")]
	[AttributeAttribute(Type = typeof(ActionTarget), RVA = "0x75F558", Offset = "0x75F558")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75F558", Offset = "0x75F558")]
	[Token(Token = "0x2000382")]
	public class SetFsmVariable : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CC29C", Offset = "0x7CC29C")]
		[Token(Token = "0x4001C41")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CC2E8", Offset = "0x7CC2E8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CC2E8", Offset = "0x7CC2E8")]
		[Token(Token = "0x4001C42")]
		[FieldOffset(Offset = "0x58")]
		public FsmString fsmName;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CC338", Offset = "0x7CC338")]
		[Token(Token = "0x4001C43")]
		[FieldOffset(Offset = "0x60")]
		public FsmString variableName;

		[RequiredField]
		[Token(Token = "0x4001C44")]
		[FieldOffset(Offset = "0x68")]
		public FsmVar setValue;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CC380", Offset = "0x7CC380")]
		[Token(Token = "0x4001C45")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x4001C46")]
		[FieldOffset(Offset = "0x78")]
		private PlayMakerFSM targetFsm;

		[Token(Token = "0x4001C47")]
		[FieldOffset(Offset = "0x80")]
		private NamedVariable targetVariable;

		[Token(Token = "0x4001C48")]
		[FieldOffset(Offset = "0x88")]
		private GameObject cachedGameObject;

		[Token(Token = "0x4001C49")]
		[FieldOffset(Offset = "0x90")]
		private string cachedFsmName;

		[Token(Token = "0x4001C4A")]
		[FieldOffset(Offset = "0x98")]
		private string cachedVariableName;

		[Token(Token = "0x6001179")]
		[Address(RVA = "0x993414", Offset = "0x993414", Length = "0x7C")]
		public override void Reset()
		{
			gameObject = null;
			FsmString fsmString = "";
			fsmName = fsmString;
			FsmVar fsmVar = new FsmVar();
			setValue = fsmVar;
		}

		[Token(Token = "0x600117A")]
		[Address(RVA = "0x993490", Offset = "0x993490", Length = "0x3C")]
		public override void OnEnter()
		{
			DoSetFsmVariable();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x600117B")]
		[Address(RVA = "0x993768", Offset = "0x993768", Length = "0x4")]
		public override void OnUpdate()
		{
			DoSetFsmVariable();
		}

		[Token(Token = "0x600117C")]
		[Address(RVA = "0x9934CC", Offset = "0x9934CC", Length = "0x29C")]
		private void DoSetFsmVariable()
		{
			//IL_02bb: Expected O, but got I
			//IL_0282: Expected O, but got I
			if (setValue.IsNone)
			{
				return;
			}
			string value = variableName.Value;
			if (string.IsNullOrEmpty(value))
			{
				return;
			}
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (ownerDefaultTarget == null)
			{
				return;
			}
			if (!(ownerDefaultTarget != cachedGameObject))
			{
				string value2 = fsmName.Value;
				if (!(value2 != cachedFsmName))
				{
					goto IL_01e6;
				}
			}
			string value3 = fsmName.Value;
			if ((targetFsm = ActionHelpers.GetGameObjectFsm(ownerDefaultTarget, value3)) == null)
			{
				return;
			}
			cachedGameObject = ownerDefaultTarget;
			string value4 = fsmName.Value;
			cachedFsmName = value4;
			goto IL_01e6;
			IL_01e6:
			string value5 = variableName.Value;
			object obj;
			if (value5 != cachedVariableName)
			{
				FsmVariables fsmVariables = targetFsm.FsmVariables;
				FsmVar fsmVar = setValue;
				string value6 = variableName.Value;
				NamedVariable namedVariable = fsmVariables.FindVariable(fsmVar.Type, value6);
				obj = (long)(IntPtr)this + 128L;
				targetVariable = namedVariable;
				string value7 = variableName.Value;
				cachedVariableName = value7;
			}
			else
			{
				obj = (long)(IntPtr)this + 128L;
			}
			if (obj != null)
			{
				setValue.UpdateValue();
				setValue.ApplyValueTo((INamedVariable)obj);
			}
			else
			{
				string value8 = variableName.Value;
				string text = "Missing Variable: " + value8;
				LogWarning(text);
			}
		}

		[Token(Token = "0x600117D")]
		[Address(RVA = "0x99376C", Offset = "0x99376C", Length = "0x8")]
		public SetFsmVariable()
		{
		}
	}
}
