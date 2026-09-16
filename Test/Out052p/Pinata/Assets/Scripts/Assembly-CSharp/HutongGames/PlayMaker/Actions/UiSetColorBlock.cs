using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x761290", Offset = "0x761290")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x761290", Offset = "0x761290")]
	[Token(Token = "0x20003DC")]
	public class UiSetColorBlock : ComponentAction<Selectable>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D2514", Offset = "0x7D2514")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D2514", Offset = "0x7D2514")]
		[Token(Token = "0x4001E1B")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D25AC", Offset = "0x7D25AC")]
		[Token(Token = "0x4001E1C")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat fadeDuration;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D25E4", Offset = "0x7D25E4")]
		[Token(Token = "0x4001E1D")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat colorMultiplier;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D261C", Offset = "0x7D261C")]
		[Token(Token = "0x4001E1E")]
		[FieldOffset(Offset = "0x78")]
		public FsmColor normalColor;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D2654", Offset = "0x7D2654")]
		[Token(Token = "0x4001E1F")]
		[FieldOffset(Offset = "0x80")]
		public FsmColor pressedColor;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D268C", Offset = "0x7D268C")]
		[Token(Token = "0x4001E20")]
		[FieldOffset(Offset = "0x88")]
		public FsmColor highlightedColor;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D26C4", Offset = "0x7D26C4")]
		[Token(Token = "0x4001E21")]
		[FieldOffset(Offset = "0x90")]
		public FsmColor disabledColor;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D26FC", Offset = "0x7D26FC")]
		[Token(Token = "0x4001E22")]
		[FieldOffset(Offset = "0x98")]
		public FsmBool resetOnExit;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D2734", Offset = "0x7D2734")]
		[Token(Token = "0x4001E23")]
		[FieldOffset(Offset = "0xA0")]
		public bool everyFrame;

		[Token(Token = "0x4001E24")]
		[FieldOffset(Offset = "0xA8")]
		private Selectable selectable;

		[Token(Token = "0x4001E25")]
		[FieldOffset(Offset = "0xB0")]
		private ColorBlock _colorBlock;

		[Token(Token = "0x4001E26")]
		[FieldOffset(Offset = "0x108")]
		private ColorBlock originalColorBlock;

		[Token(Token = "0x600132A")]
		[Address(RVA = "0x982840", Offset = "0x982840", Length = "0x134")]
		public override void Reset()
		{
			gameObject = null;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = true;
			fadeDuration = fsmFloat;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.useVariable = true;
			colorMultiplier = fsmFloat2;
			FsmColor fsmColor = new FsmColor();
			fsmColor.useVariable = true;
			normalColor = fsmColor;
			FsmColor fsmColor2 = new FsmColor();
			fsmColor2.useVariable = true;
			highlightedColor = fsmColor2;
			FsmColor fsmColor3 = new FsmColor();
			fsmColor3.useVariable = true;
			pressedColor = fsmColor3;
			FsmColor fsmColor4 = new FsmColor();
			fsmColor4.useVariable = true;
			disabledColor = fsmColor4;
			resetOnExit = null;
			everyFrame = false;
		}

		[Token(Token = "0x600132B")]
		[Address(RVA = "0x982974", Offset = "0x982974", Length = "0x124")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			//IL_0083: Expected O, but got I
			//IL_005c: Expected O, but got I
			//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0101: Expected O, but got Unknown
			//IL_010d: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiSetColorBlock)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			object obj;
			UnityEngine.Object obj2;
			if (UpdateCache(ownerDefaultTarget))
			{
				obj = (long)(IntPtr)this + 168L;
				selectable = cachedComponent;
				obj2 = cachedComponent;
			}
			else
			{
				obj = (long)(IntPtr)this + 168L;
				obj2 = selectable;
			}
			bool flag = obj2 != null;
			bool flag2 = !flag;
			UnityEngine.Object obj3 = null;
			if (!flag2)
			{
				bool value = resetOnExit.Value;
				bool flag3 = !value;
				obj3 = null;
				if (!flag3)
				{
					obj3 = (UnityEngine.Object)(obj + 68);
					object obj4 = (long)(IntPtr)this + 264L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1DA0 (native memmove)");
				}
			}
			DoSetValue();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x600132C")]
		[Address(RVA = "0x982C94", Offset = "0x982C94", Length = "0x4")]
		public override void OnUpdate()
		{
			DoSetValue();
		}

		[Token(Token = "0x600132D")]
		[Address(RVA = "0x982A98", Offset = "0x982A98", Length = "0x1FC")]
		private unsafe void DoSetValue()
		{
			//IL_0049: Expected O, but got I
			//IL_005a: Expected O, but got I
			//IL_03ca: Expected O, but got Ref
			if (!(selectable == null))
			{
				object obj = (long)(IntPtr)this + 176L;
				object obj2 = (long)(IntPtr)selectable + 68L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1DA0 (native memmove)");
				if (!colorMultiplier.IsNone)
				{
					float value = colorMultiplier.Value;
					_colorBlock.colorMultiplier = value;
				}
				if (!fadeDuration.IsNone)
				{
					float value = fadeDuration.Value;
					_colorBlock.fadeDuration = value;
				}
				if (!normalColor.IsNone)
				{
					FsmColor fsmColor = normalColor;
					_colorBlock.m_NormalColor.r = fsmColor.value.r;
					_colorBlock.m_NormalColor.g = fsmColor.value.g;
					_colorBlock.m_NormalColor.a = fsmColor.value.a;
				}
				if (!pressedColor.IsNone)
				{
					FsmColor fsmColor2 = pressedColor;
					_colorBlock.m_PressedColor.r = fsmColor2.value.r;
					_colorBlock.m_PressedColor.g = fsmColor2.value.g;
					_colorBlock.m_PressedColor.a = fsmColor2.value.a;
				}
				if (!highlightedColor.IsNone)
				{
					FsmColor fsmColor3 = highlightedColor;
					_colorBlock.m_HighlightedColor.r = fsmColor3.value.r;
					_colorBlock.m_HighlightedColor.g = fsmColor3.value.g;
					_colorBlock.m_HighlightedColor.a = fsmColor3.value.a;
				}
				if (!disabledColor.IsNone)
				{
					FsmColor fsmColor4 = disabledColor;
					_colorBlock.m_DisabledColor.r = fsmColor4.value.r;
					_colorBlock.m_DisabledColor.g = fsmColor4.value.g;
					_colorBlock.m_DisabledColor.a = fsmColor4.value.a;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
				object obj3 = default(object);
				selectable.colors = (ColorBlock)(&obj3);
			}
		}

		[Token(Token = "0x600132E")]
		[Address(RVA = "0x982C98", Offset = "0x982C98", Length = "0xD8")]
		public unsafe override void OnExit()
		{
			//IL_0075: Expected O, but got I
			//IL_009d: Expected O, but got Ref
			if (!(selectable == null) && resetOnExit.Value)
			{
				object obj = (long)(IntPtr)this + 264L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
				object obj2 = default(object);
				selectable.colors = (ColorBlock)(&obj2);
			}
		}

		[Token(Token = "0x600132F")]
		[Address(RVA = "0x982D70", Offset = "0x982D70", Length = "0x50")]
		public UiSetColorBlock()
		{
		}
	}
}
