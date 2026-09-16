using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x761920", Offset = "0x761920")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x761920", Offset = "0x761920")]
	[Token(Token = "0x20003F1")]
	public class UiInputFieldGetCharacterLimit : ComponentAction<InputField>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D51B4", Offset = "0x7D51B4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D51B4", Offset = "0x7D51B4")]
		[Token(Token = "0x4001E8C")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D524C", Offset = "0x7D524C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D524C", Offset = "0x7D524C")]
		[Token(Token = "0x4001E8D")]
		[FieldOffset(Offset = "0x68")]
		public FsmInt characterLimit;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D52AC", Offset = "0x7D52AC")]
		[Token(Token = "0x4001E8E")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent hasNoLimitEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D52E4", Offset = "0x7D52E4")]
		[Token(Token = "0x4001E8F")]
		[FieldOffset(Offset = "0x78")]
		public FsmEvent isLimitedEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D531C", Offset = "0x7D531C")]
		[Token(Token = "0x4001E90")]
		[FieldOffset(Offset = "0x80")]
		public bool everyFrame;

		[Token(Token = "0x4001E91")]
		[FieldOffset(Offset = "0x88")]
		private InputField inputField;

		[Token(Token = "0x600138E")]
		[Address(RVA = "0x97A2D0", Offset = "0x97A2D0", Length = "0xC")]
		public override void Reset()
		{
			characterLimit = null;
			everyFrame = false;
		}

		[Token(Token = "0x600138F")]
		[Address(RVA = "0x97A2DC", Offset = "0x97A2DC", Length = "0xA0")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiInputFieldGetCharacterLimit)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				inputField = cachedComponent;
			}
			DoGetValue();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001390")]
		[Address(RVA = "0x97A44C", Offset = "0x97A44C", Length = "0x4")]
		public override void OnUpdate()
		{
			DoGetValue();
		}

		[Token(Token = "0x6001391")]
		[Address(RVA = "0x97A37C", Offset = "0x97A37C", Length = "0xD0")]
		private void DoGetValue()
		{
			//IL_007e: Expected O, but got I
			//IL_008a: Expected O, but got I
			//IL_015d: Expected O, but got I
			if (!(this.inputField == null))
			{
				InputField inputField = this.inputField;
				FsmInt fsmInt = characterLimit;
				fsmInt.Value = inputField.characterLimit;
				InputField inputField2 = this.inputField;
				object obj = (long)(IntPtr)this + 120L;
				object obj2 = (long)(IntPtr)this + 112L;
				bool flag = inputField2.characterLimit < 0;
				bool flag2 = inputField2.characterLimit == 0;
				int num = inputField2.characterLimit ^ inputField2.characterLimit;
				int num2 = inputField2.characterLimit & num;
				bool flag3 = num2 < 0;
				bool flag4 = flag == flag3;
				bool flag5 = !flag2;
				object fsmEvent = ((!(flag4 && flag5)) ? obj2 : obj);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiInputFieldGetCharacterLimit)+30]");
				((Fsm)0).Event((FsmEvent)fsmEvent);
			}
		}

		[Token(Token = "0x6001392")]
		[Address(RVA = "0x97A450", Offset = "0x97A450", Length = "0x50")]
		public UiInputFieldGetCharacterLimit()
		{
		}
	}
}
