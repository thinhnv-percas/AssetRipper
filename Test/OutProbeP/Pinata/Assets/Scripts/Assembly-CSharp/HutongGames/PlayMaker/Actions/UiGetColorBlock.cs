using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x761100", Offset = "0x761100")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x761100", Offset = "0x761100")]
	[Token(Token = "0x20003D7")]
	public class UiGetColorBlock : ComponentAction<Selectable>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D1C6C", Offset = "0x7D1C6C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D1C6C", Offset = "0x7D1C6C")]
		[Token(Token = "0x4001DF4")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D1D04", Offset = "0x7D1D04")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7D1D04", Offset = "0x7D1D04")]
		[Token(Token = "0x4001DF5")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat fadeDuration;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D1D54", Offset = "0x7D1D54")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7D1D54", Offset = "0x7D1D54")]
		[Token(Token = "0x4001DF6")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat colorMultiplier;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D1DA4", Offset = "0x7D1DA4")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7D1DA4", Offset = "0x7D1DA4")]
		[Token(Token = "0x4001DF7")]
		[FieldOffset(Offset = "0x78")]
		public FsmColor normalColor;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D1DF4", Offset = "0x7D1DF4")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7D1DF4", Offset = "0x7D1DF4")]
		[Token(Token = "0x4001DF8")]
		[FieldOffset(Offset = "0x80")]
		public FsmColor pressedColor;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D1E44", Offset = "0x7D1E44")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7D1E44", Offset = "0x7D1E44")]
		[Token(Token = "0x4001DF9")]
		[FieldOffset(Offset = "0x88")]
		public FsmColor highlightedColor;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D1E94", Offset = "0x7D1E94")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7D1E94", Offset = "0x7D1E94")]
		[Token(Token = "0x4001DFA")]
		[FieldOffset(Offset = "0x90")]
		public FsmColor disabledColor;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D1EE4", Offset = "0x7D1EE4")]
		[Token(Token = "0x4001DFB")]
		[FieldOffset(Offset = "0x98")]
		public bool everyFrame;

		[Token(Token = "0x4001DFC")]
		[FieldOffset(Offset = "0xA0")]
		private Selectable selectable;

		[Token(Token = "0x6001313")]
		[Address(RVA = "0x9A5CE0", Offset = "0x9A5CE0", Length = "0x18")]
		public override void Reset()
		{
			everyFrame = false;
			disabledColor = null;
			colorMultiplier = null;
			pressedColor = null;
			gameObject = null;
		}

		[Token(Token = "0x6001314")]
		[Address(RVA = "0x9A5CF8", Offset = "0x9A5CF8", Length = "0xA0")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiGetColorBlock)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				selectable = cachedComponent;
			}
			DoGetValue();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001315")]
		[Address(RVA = "0x9A5F64", Offset = "0x9A5F64", Length = "0x4")]
		public override void OnUpdate()
		{
			DoGetValue();
		}

		[Token(Token = "0x6001316")]
		[Address(RVA = "0x9A5D98", Offset = "0x9A5D98", Length = "0x1CC")]
		private void DoGetValue()
		{
			//IL_018b: Expected F4, but got O
			if (!(this.selectable == null))
			{
				if (!colorMultiplier.IsNone)
				{
					Selectable selectable = this.selectable;
					FsmFloat fsmFloat = colorMultiplier;
					fsmFloat.Value = selectable.m_Colors.colorMultiplier;
				}
				if (!fadeDuration.IsNone)
				{
					Selectable selectable2 = this.selectable;
					FsmFloat fsmFloat2 = fadeDuration;
					fsmFloat2.Value = selectable2.m_Colors.fadeDuration;
				}
				if (!normalColor.IsNone)
				{
					Selectable selectable3 = this.selectable;
					FsmColor fsmColor = normalColor;
					fsmColor.value.r = (float)selectable3.m_Colors;
					fsmColor.value.g = selectable3.m_Colors.m_NormalColor.g;
					fsmColor.value.a = selectable3.m_Colors.m_NormalColor.a;
				}
				if (!pressedColor.IsNone)
				{
					Selectable selectable4 = this.selectable;
					FsmColor fsmColor2 = pressedColor;
					fsmColor2.value.r = selectable4.m_Colors.m_PressedColor.r;
					fsmColor2.value.g = selectable4.m_Colors.m_PressedColor.g;
					fsmColor2.value.a = selectable4.m_Colors.m_PressedColor.a;
				}
				if (!highlightedColor.IsNone)
				{
					Selectable selectable5 = this.selectable;
					FsmColor fsmColor3 = highlightedColor;
					fsmColor3.value.r = selectable5.m_Colors.m_HighlightedColor.r;
					fsmColor3.value.g = selectable5.m_Colors.m_HighlightedColor.g;
					fsmColor3.value.a = selectable5.m_Colors.m_HighlightedColor.a;
				}
				if (!disabledColor.IsNone)
				{
					Selectable selectable6 = this.selectable;
					FsmColor fsmColor4 = disabledColor;
					fsmColor4.value.r = selectable6.m_Colors.m_DisabledColor.r;
					fsmColor4.value.g = selectable6.m_Colors.m_DisabledColor.g;
					fsmColor4.value.a = selectable6.m_Colors.m_DisabledColor.a;
				}
			}
		}

		[Token(Token = "0x6001317")]
		[Address(RVA = "0x9A5F68", Offset = "0x9A5F68", Length = "0x50")]
		public UiGetColorBlock()
		{
		}
	}
}
