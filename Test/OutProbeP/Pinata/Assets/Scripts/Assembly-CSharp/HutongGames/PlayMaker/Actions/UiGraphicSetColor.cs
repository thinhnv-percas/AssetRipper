using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7616A0", Offset = "0x7616A0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7616A0", Offset = "0x7616A0")]
	[Token(Token = "0x20003E9")]
	public class UiGraphicSetColor : ComponentAction<Graphic>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D37B4", Offset = "0x7D37B4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D37B4", Offset = "0x7D37B4")]
		[Token(Token = "0x4001E68")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D384C", Offset = "0x7D384C")]
		[Token(Token = "0x4001E69")]
		[FieldOffset(Offset = "0x68")]
		public FsmColor color;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D3884", Offset = "0x7D3884")]
		[Token(Token = "0x4001E6A")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat red;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D38BC", Offset = "0x7D38BC")]
		[Token(Token = "0x4001E6B")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat green;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D38F4", Offset = "0x7D38F4")]
		[Token(Token = "0x4001E6C")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat blue;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D392C", Offset = "0x7D392C")]
		[Token(Token = "0x4001E6D")]
		[FieldOffset(Offset = "0x88")]
		public FsmFloat alpha;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D3964", Offset = "0x7D3964")]
		[Token(Token = "0x4001E6E")]
		[FieldOffset(Offset = "0x90")]
		public FsmBool resetOnExit;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D399C", Offset = "0x7D399C")]
		[Token(Token = "0x4001E6F")]
		[FieldOffset(Offset = "0x98")]
		public bool everyFrame;

		[Token(Token = "0x4001E70")]
		[FieldOffset(Offset = "0xA0")]
		private Graphic uiComponent;

		[Token(Token = "0x4001E71")]
		[FieldOffset(Offset = "0xA8")]
		private Color originalColor;

		[Token(Token = "0x6001366")]
		[Address(RVA = "0x9790EC", Offset = "0x9790EC", Length = "0xE8")]
		public override void Reset()
		{
			gameObject = null;
			color = null;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = true;
			red = fsmFloat;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.useVariable = true;
			green = fsmFloat2;
			FsmFloat fsmFloat3 = new FsmFloat();
			fsmFloat3.useVariable = true;
			blue = fsmFloat3;
			FsmFloat fsmFloat4 = new FsmFloat();
			fsmFloat4.useVariable = true;
			alpha = fsmFloat4;
			resetOnExit = null;
			everyFrame = false;
		}

		[Token(Token = "0x6001367")]
		[Address(RVA = "0x9791D4", Offset = "0x9791D4", Length = "0xC8")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiGraphicSetColor)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			Graphic graphic;
			if (UpdateCache(ownerDefaultTarget))
			{
				graphic = cachedComponent;
				uiComponent = cachedComponent;
				if ((object)cachedComponent == null)
				{
					throw new NullReferenceException();
				}
			}
			else
			{
				graphic = uiComponent;
			}
			Color color = graphic.color;
			Color color2 = default(Color);
			originalColor = color2;
			float g = default(float);
			originalColor.g = g;
			float b = default(float);
			originalColor.b = b;
			float a = default(float);
			originalColor.a = a;
			DoSetColorValue();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001368")]
		[Address(RVA = "0x979454", Offset = "0x979454", Length = "0x4")]
		public override void OnUpdate()
		{
			DoSetColorValue();
		}

		[Token(Token = "0x6001369")]
		[Address(RVA = "0x97929C", Offset = "0x97929C", Length = "0x1B8")]
		private void DoSetColorValue()
		{
			//IL_01fd: Expected I, but got O
			//IL_020d: Expected O, but got I
			//IL_021d: Expected O, but got I
			while (!(uiComponent == null))
			{
				Color color = uiComponent.color;
				if (!this.color.IsNone)
				{
					FsmColor fsmColor = this.color;
					float g = fsmColor.value.g;
					float b = fsmColor.value.b;
					float a = fsmColor.value.a;
				}
				if (!red.IsNone)
				{
					float value = red.Value;
				}
				if (!green.IsNone)
				{
					float value2 = green.Value;
				}
				if (!blue.IsNone)
				{
					float value3 = blue.Value;
				}
				if (!alpha.IsNone)
				{
					float value4 = alpha.Value;
				}
				Graphic graphic = uiComponent;
				IntPtr intPtr = (IntPtr)graphic;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ X8_v11 (Il2CppClass<UnityEngine.UI.Graphic>)+2A0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ X8_v11 (Il2CppClass<UnityEngine.UI.Graphic>)+2A8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v105 @ X2_v2 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x600136A")]
		[Address(RVA = "0x979458", Offset = "0x979458", Length = "0xB8")]
		public override void OnExit()
		{
			//IL_0080: Expected I, but got O
			//IL_00c7: Expected O, but got I
			//IL_00d7: Expected O, but got I
			if (!(uiComponent == null) && resetOnExit.Value)
			{
				Graphic graphic = uiComponent;
				IntPtr intPtr = (IntPtr)graphic;
				Color color = originalColor;
				float g = originalColor.g;
				float b = originalColor.b;
				float a = originalColor.a;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ X8_v7 (Il2CppClass<UnityEngine.UI.Graphic>)+2A0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ X8_v7 (Il2CppClass<UnityEngine.UI.Graphic>)+2A8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v89 @ X2_v2 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x600136B")]
		[Address(RVA = "0x979510", Offset = "0x979510", Length = "0x50")]
		public UiGraphicSetColor()
		{
		}
	}
}
