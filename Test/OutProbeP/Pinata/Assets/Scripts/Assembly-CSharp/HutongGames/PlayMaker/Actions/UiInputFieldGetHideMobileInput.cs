using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x761970", Offset = "0x761970")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x761970", Offset = "0x761970")]
	[Token(Token = "0x20003F2")]
	public class UiInputFieldGetHideMobileInput : ComponentAction<InputField>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D5354", Offset = "0x7D5354")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D5354", Offset = "0x7D5354")]
		[Token(Token = "0x4001E92")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D53EC", Offset = "0x7D53EC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D53EC", Offset = "0x7D53EC")]
		[Token(Token = "0x4001E93")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool hideMobileInput;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D543C", Offset = "0x7D543C")]
		[Token(Token = "0x4001E94")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent mobileInputHiddenEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D5474", Offset = "0x7D5474")]
		[Token(Token = "0x4001E95")]
		[FieldOffset(Offset = "0x78")]
		public FsmEvent mobileInputShownEvent;

		[Token(Token = "0x4001E96")]
		[FieldOffset(Offset = "0x80")]
		private InputField inputField;

		[Token(Token = "0x6001393")]
		[Address(RVA = "0x97A4A0", Offset = "0x97A4A0", Length = "0xC")]
		public override void Reset()
		{
			mobileInputHiddenEvent = null;
			mobileInputShownEvent = null;
			hideMobileInput = null;
		}

		[Token(Token = "0x6001394")]
		[Address(RVA = "0x97A4AC", Offset = "0x97A4AC", Length = "0x8C")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiInputFieldGetHideMobileInput)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				inputField = cachedComponent;
			}
			DoGetValue();
			Finish();
		}

		[Token(Token = "0x6001395")]
		[Address(RVA = "0x97A538", Offset = "0x97A538", Length = "0xE4")]
		private void DoGetValue()
		{
			//IL_0083: Expected O, but got I
			//IL_008f: Expected O, but got I
			//IL_00ee: Expected O, but got I
			if (!(inputField == null))
			{
				FsmBool fsmBool = hideMobileInput;
				bool shouldHideMobileInput = inputField.shouldHideMobileInput;
				fsmBool.value = shouldHideMobileInput;
				bool shouldHideMobileInput2 = inputField.shouldHideMobileInput;
				object fsmEvent = (long)(IntPtr)this + 112L;
				object obj = (long)(IntPtr)this + 120L;
				if (!shouldHideMobileInput2)
				{
					fsmEvent = obj;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiInputFieldGetHideMobileInput)+30]");
				((Fsm)0).Event((FsmEvent)fsmEvent);
			}
		}

		[Token(Token = "0x6001396")]
		[Address(RVA = "0x97A61C", Offset = "0x97A61C", Length = "0x50")]
		public UiInputFieldGetHideMobileInput()
		{
		}
	}
}
