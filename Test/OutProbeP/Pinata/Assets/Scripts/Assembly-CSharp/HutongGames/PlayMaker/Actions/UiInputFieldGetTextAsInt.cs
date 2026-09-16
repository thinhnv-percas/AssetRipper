using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x761B50", Offset = "0x761B50")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x761B50", Offset = "0x761B50")]
	[Token(Token = "0x20003F8")]
	public class UiInputFieldGetTextAsInt : ComponentAction<InputField>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D5B74", Offset = "0x7D5B74")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D5B74", Offset = "0x7D5B74")]
		[Token(Token = "0x4001EB3")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D5C0C", Offset = "0x7D5C0C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D5C0C", Offset = "0x7D5C0C")]
		[Token(Token = "0x4001EB4")]
		[FieldOffset(Offset = "0x68")]
		public FsmInt value;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D5C6C", Offset = "0x7D5C6C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D5C6C", Offset = "0x7D5C6C")]
		[Token(Token = "0x4001EB5")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool isInt;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D5CBC", Offset = "0x7D5CBC")]
		[Token(Token = "0x4001EB6")]
		[FieldOffset(Offset = "0x78")]
		public FsmEvent isIntEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D5CF4", Offset = "0x7D5CF4")]
		[Token(Token = "0x4001EB7")]
		[FieldOffset(Offset = "0x80")]
		public FsmEvent isNotIntEvent;

		[Token(Token = "0x4001EB8")]
		[FieldOffset(Offset = "0x88")]
		public bool everyFrame;

		[Token(Token = "0x4001EB9")]
		[FieldOffset(Offset = "0x90")]
		private InputField inputField;

		[Token(Token = "0x4001EBA")]
		[FieldOffset(Offset = "0x98")]
		private int _value;

		[Token(Token = "0x4001EBB")]
		[FieldOffset(Offset = "0x9C")]
		private bool _success;

		[Token(Token = "0x60013AE")]
		[Address(RVA = "0x97AF80", Offset = "0x97AF80", Length = "0x14")]
		public override void Reset()
		{
			everyFrame = false;
			isIntEvent = null;
			value = null;
		}

		[Token(Token = "0x60013AF")]
		[Address(RVA = "0x97AF94", Offset = "0x97AF94", Length = "0xA0")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiInputFieldGetTextAsInt)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				inputField = cachedComponent;
			}
			DoGetTextValue();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60013B0")]
		[Address(RVA = "0x97B124", Offset = "0x97B124", Length = "0x4")]
		public override void OnUpdate()
		{
			DoGetTextValue();
		}

		[Token(Token = "0x60013B1")]
		[Address(RVA = "0x97B034", Offset = "0x97B034", Length = "0xF0")]
		private unsafe void DoGetTextValue()
		{
			//IL_00bb: Expected O, but got I
			//IL_00c7: Expected O, but got I
			//IL_0130: Expected O, but got I
			if (!(this.inputField == null))
			{
				InputField inputField = this.inputField;
				bool success = int.TryParse(inputField.text, out *(int*)((long)(IntPtr)this + 152L));
				FsmInt fsmInt = value;
				_success = success;
				fsmInt.Value = _value;
				FsmBool fsmBool = isInt;
				fsmBool.value = _success;
				object obj = (long)(IntPtr)this + 120L;
				object obj2 = (long)(IntPtr)this + 128L;
				object fsmEvent = ((!_success) ? obj2 : obj);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiInputFieldGetTextAsInt)+30]");
				((Fsm)0).Event((FsmEvent)fsmEvent);
			}
		}

		[Token(Token = "0x60013B2")]
		[Address(RVA = "0x97B128", Offset = "0x97B128", Length = "0x50")]
		public UiInputFieldGetTextAsInt()
		{
		}
	}
}
