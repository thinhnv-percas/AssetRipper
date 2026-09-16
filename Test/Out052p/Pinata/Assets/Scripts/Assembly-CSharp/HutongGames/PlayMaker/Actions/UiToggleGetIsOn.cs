using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x762780", Offset = "0x762780")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x762780", Offset = "0x762780")]
	[Token(Token = "0x200041F")]
	public class UiToggleGetIsOn : ComponentAction<Toggle>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D8EE8", Offset = "0x7D8EE8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D8EE8", Offset = "0x7D8EE8")]
		[Token(Token = "0x4001F84")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D8F80", Offset = "0x7D8F80")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D8F80", Offset = "0x7D8F80")]
		[Token(Token = "0x4001F85")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool value;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D8FD0", Offset = "0x7D8FD0")]
		[Token(Token = "0x4001F86")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent isOnEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D9008", Offset = "0x7D9008")]
		[Token(Token = "0x4001F87")]
		[FieldOffset(Offset = "0x78")]
		public FsmEvent isOffEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D9040", Offset = "0x7D9040")]
		[Token(Token = "0x4001F88")]
		[FieldOffset(Offset = "0x80")]
		public bool everyFrame;

		[Token(Token = "0x4001F89")]
		[FieldOffset(Offset = "0x88")]
		private Toggle _toggle;

		[Token(Token = "0x600147B")]
		[Address(RVA = "0x98507C", Offset = "0x98507C", Length = "0xC")]
		public override void Reset()
		{
			everyFrame = false;
			gameObject = null;
			value = null;
		}

		[Token(Token = "0x600147C")]
		[Address(RVA = "0x985088", Offset = "0x985088", Length = "0xA0")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiToggleGetIsOn)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				_toggle = cachedComponent;
			}
			DoGetValue();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x600147D")]
		[Address(RVA = "0x9851F8", Offset = "0x9851F8", Length = "0x4")]
		public override void OnUpdate()
		{
			DoGetValue();
		}

		[Token(Token = "0x600147E")]
		[Address(RVA = "0x985128", Offset = "0x985128", Length = "0xD0")]
		private void DoGetValue()
		{
			//IL_007e: Expected O, but got I
			//IL_008a: Expected O, but got I
			//IL_00f6: Expected O, but got I
			if (!(_toggle == null))
			{
				Toggle toggle = _toggle;
				FsmBool fsmBool = value;
				fsmBool.value = toggle.isOn;
				Toggle toggle2 = _toggle;
				object obj = (long)(IntPtr)this + 112L;
				object obj2 = (long)(IntPtr)this + 120L;
				object fsmEvent = ((!toggle2.isOn) ? obj2 : obj);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiToggleGetIsOn)+30]");
				((Fsm)0).Event((FsmEvent)fsmEvent);
			}
		}

		[Token(Token = "0x600147F")]
		[Address(RVA = "0x9851FC", Offset = "0x9851FC", Length = "0x50")]
		public UiToggleGetIsOn()
		{
		}
	}
}
