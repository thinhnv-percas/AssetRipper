using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x761B00", Offset = "0x761B00")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x761B00", Offset = "0x761B00")]
	[Token(Token = "0x20003F7")]
	public class UiInputFieldGetTextAsFloat : ComponentAction<InputField>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D59BC", Offset = "0x7D59BC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D59BC", Offset = "0x7D59BC")]
		[Token(Token = "0x4001EAA")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D5A54", Offset = "0x7D5A54")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D5A54", Offset = "0x7D5A54")]
		[Token(Token = "0x4001EAB")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat value;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D5AB4", Offset = "0x7D5AB4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D5AB4", Offset = "0x7D5AB4")]
		[Token(Token = "0x4001EAC")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool isFloat;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D5B04", Offset = "0x7D5B04")]
		[Token(Token = "0x4001EAD")]
		[FieldOffset(Offset = "0x78")]
		public FsmEvent isFloatEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D5B3C", Offset = "0x7D5B3C")]
		[Token(Token = "0x4001EAE")]
		[FieldOffset(Offset = "0x80")]
		public FsmEvent isNotFloatEvent;

		[Token(Token = "0x4001EAF")]
		[FieldOffset(Offset = "0x88")]
		public bool everyFrame;

		[Token(Token = "0x4001EB0")]
		[FieldOffset(Offset = "0x90")]
		private InputField inputField;

		[Token(Token = "0x4001EB1")]
		[FieldOffset(Offset = "0x98")]
		private float _value;

		[Token(Token = "0x4001EB2")]
		[FieldOffset(Offset = "0x9C")]
		private bool _success;

		[Token(Token = "0x60013A9")]
		[Address(RVA = "0x97AD88", Offset = "0x97AD88", Length = "0x14")]
		public override void Reset()
		{
			everyFrame = false;
			isFloatEvent = null;
			value = null;
		}

		[Token(Token = "0x60013AA")]
		[Address(RVA = "0x97AD9C", Offset = "0x97AD9C", Length = "0xA0")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiInputFieldGetTextAsFloat)+30]");
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

		[Token(Token = "0x60013AB")]
		[Address(RVA = "0x97AF2C", Offset = "0x97AF2C", Length = "0x4")]
		public override void OnUpdate()
		{
			DoGetTextValue();
		}

		[Token(Token = "0x60013AC")]
		[Address(RVA = "0x97AE3C", Offset = "0x97AE3C", Length = "0xF0")]
		private unsafe void DoGetTextValue()
		{
			//IL_00bb: Expected O, but got I
			//IL_00c7: Expected O, but got I
			//IL_0130: Expected O, but got I
			if (!(this.inputField == null))
			{
				InputField inputField = this.inputField;
				bool success = float.TryParse(inputField.text, out *(float*)((long)(IntPtr)this + 152L));
				FsmFloat fsmFloat = value;
				_success = success;
				fsmFloat.Value = _value;
				FsmBool fsmBool = isFloat;
				fsmBool.value = _success;
				object obj = (long)(IntPtr)this + 120L;
				object obj2 = (long)(IntPtr)this + 128L;
				object fsmEvent = ((!_success) ? obj2 : obj);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiInputFieldGetTextAsFloat)+30]");
				((Fsm)0).Event((FsmEvent)fsmEvent);
			}
		}

		[Token(Token = "0x60013AD")]
		[Address(RVA = "0x97AF30", Offset = "0x97AF30", Length = "0x50")]
		public UiInputFieldGetTextAsFloat()
		{
		}
	}
}
