using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x762730", Offset = "0x762730")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x762730", Offset = "0x762730")]
	[Token(Token = "0x200041E")]
	public class UiTextSetText : ComponentAction<Text>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D8D90", Offset = "0x7D8D90")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D8D90", Offset = "0x7D8D90")]
		[Token(Token = "0x4001F7E")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D8E28", Offset = "0x7D8E28")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D8E28", Offset = "0x7D8E28")]
		[Token(Token = "0x4001F7F")]
		[FieldOffset(Offset = "0x68")]
		public FsmString text;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D8E78", Offset = "0x7D8E78")]
		[Token(Token = "0x4001F80")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool resetOnExit;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D8EB0", Offset = "0x7D8EB0")]
		[Token(Token = "0x4001F81")]
		[FieldOffset(Offset = "0x78")]
		public bool everyFrame;

		[Token(Token = "0x4001F82")]
		[FieldOffset(Offset = "0x80")]
		private Text uiText;

		[Token(Token = "0x4001F83")]
		[FieldOffset(Offset = "0x88")]
		private string originalString;

		[Token(Token = "0x6001475")]
		[Address(RVA = "0x984DE4", Offset = "0x984DE4", Length = "0x10")]
		public override void Reset()
		{
			everyFrame = false;
			text = null;
			resetOnExit = null;
			gameObject = null;
		}

		[Token(Token = "0x6001476")]
		[Address(RVA = "0x984DF4", Offset = "0x984DF4", Length = "0xC4")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiTextSetText)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			Text text;
			if (UpdateCache(ownerDefaultTarget))
			{
				text = cachedComponent;
				uiText = cachedComponent;
				if ((object)cachedComponent == null)
				{
					throw new NullReferenceException();
				}
			}
			else
			{
				text = uiText;
			}
			string text2 = text.text;
			originalString = text2;
			DoSetTextValue();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001477")]
		[Address(RVA = "0x984F74", Offset = "0x984F74", Length = "0x4")]
		public override void OnUpdate()
		{
			DoSetTextValue();
		}

		[Token(Token = "0x6001478")]
		[Address(RVA = "0x984EB8", Offset = "0x984EB8", Length = "0xBC")]
		private void DoSetTextValue()
		{
			//IL_0059: Expected I, but got O
			//IL_0069: Expected O, but got I
			//IL_0079: Expected O, but got I
			while (!(uiText == null))
			{
				Text text = uiText;
				string value = this.text.Value;
				IntPtr intPtr = (IntPtr)text;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ X8_v7 (Il2CppClass<UnityEngine.UI.Text>)+5C0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ X8_v7 (Il2CppClass<UnityEngine.UI.Text>)+5C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v66 @ X3_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x6001479")]
		[Address(RVA = "0x984F78", Offset = "0x984F78", Length = "0xB4")]
		public override void OnExit()
		{
			//IL_0080: Expected I, but got O
			//IL_009a: Expected O, but got I
			//IL_00aa: Expected O, but got I
			if (!(uiText == null) && resetOnExit.Value)
			{
				Text text = uiText;
				IntPtr intPtr = (IntPtr)text;
				string text2 = originalString;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ X8_v7 (Il2CppClass<UnityEngine.UI.Text>)+5C0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ X8_v7 (Il2CppClass<UnityEngine.UI.Text>)+5C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v79 @ X3_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x600147A")]
		[Address(RVA = "0x98502C", Offset = "0x98502C", Length = "0x50")]
		public UiTextSetText()
		{
		}
	}
}
