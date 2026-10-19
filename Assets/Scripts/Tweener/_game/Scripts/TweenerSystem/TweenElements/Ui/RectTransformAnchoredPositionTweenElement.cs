using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using UnityEngine;

namespace _game.Scripts.TweenerSystem.TweenElements.Ui
{
	[Token(Token = "0x2000014")]
	public class RectTransformAnchoredPositionTweenElement : TweenElement<Vector2>
	{
		[SerializeField]
		[Token(Token = "0x4000029")]
		[FieldOffset(Offset = "0x68")]
		private RectTransform m_target;

		[SerializeField]
		[Token(Token = "0x400002A")]
		[FieldOffset(Offset = "0x70")]
		private bool m_hasStartValue;

		[Token(Token = "0x1700000C")]
		protected internal override Object Target
		{
			[Token(Token = "0x6000039")]
			[Address(RVA = "0x81A080C", Offset = "0x81A080C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_target;\n")]
			get
			{
				return m_target;
			}
		}

		[Token(Token = "0x600003A")]
		[Address(RVA = "0x81A0814", Offset = "0x81A0814", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv47 = UnityEngine.RectTransform::get_anchoredPosition(this.m_target);\n\t*([this @ X0 (_game.Scripts.TweenerSystem.TweenElements.Ui.RectTransformAnchoredPositionTweenElement)+24]) = v47;\n\t*([this @ X0 (_game.Scripts.TweenerSystem.TweenElements.Ui.RectTransformAnchoredPositionTweenElement)+28]) = v47.y;\nL_0014:\n\tv40 = this.m_hasStartValue == 0;\n\tv41 = ~v40;\n\tif (v41) goto L_0028;\nL_0028:\n\tv61 = *([this @ X0 (_game.Scripts.TweenerSystem.TweenElements.Ui.RectTransformAnchoredPositionTweenElement)+20]);\n\treturnVal1 = PrimeTween.Tween::UIAnchoredPosition(this.m_target, &v61 @ stack_-70_v1);\n\treturn returnVal1;\n")]
		protected internal unsafe override Tween GetTween()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RectTransformAnchoredPositionTweenElement::GetTween");
			return default;
		}

		[Token(Token = "0x600003B")]
		[Address(RVA = "0x81A089C", Offset = "0x81A089C", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_hasStartValue = 1;\n\tv16 = UnityEngine.RectTransform::get_anchoredPosition(this.m_target);\n\t*([this @ X0 (_game.Scripts.TweenerSystem.TweenElements.Ui.RectTransformAnchoredPositionTweenElement)+24]) = v16;\n\t*([this @ X0 (_game.Scripts.TweenerSystem.TweenElements.Ui.RectTransformAnchoredPositionTweenElement)+28]) = v16.y;\n\treturn;\n")]
		private void Editor_SaveStartValue()
		{
			m_hasStartValue = true;
			_ = m_target.anchoredPosition.y;
		}

		[Token(Token = "0x600003C")]
		[Address(RVA = "0x81A08D8", Offset = "0x81A08D8", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = UnityEngine.RectTransform::get_anchoredPosition(this.m_target);\n\t*([this @ X0 (_game.Scripts.TweenerSystem.TweenElements.Ui.RectTransformAnchoredPositionTweenElement)+2C]) = v15;\n\t*([this @ X0 (_game.Scripts.TweenerSystem.TweenElements.Ui.RectTransformAnchoredPositionTweenElement)+30]) = v15.y;\n\treturn;\n")]
		private void Editor_SaveEndValue()
		{
			_ = m_target.anchoredPosition.y;
		}

		[Token(Token = "0x600003D")]
		[Address(RVA = "0x81A090C", Offset = "0x81A090C", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_0020:\n\t_game.Scripts.TweenerSystem.TweenElement`1<UnityEngine.Vector2>::.ctor(this);\n\treturn;\n")]
		public RectTransformAnchoredPositionTweenElement()
		{
		}
	}
}
