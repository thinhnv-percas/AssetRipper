using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using UnityEngine;

namespace _game.Scripts.TweenerSystem.TweenElements
{
	[Token(Token = "0x200000D")]
	public class CanvasGroupAlphaTweenElement : TweenElement<float>
	{
		[SerializeField]
		[Token(Token = "0x400001C")]
		[FieldOffset(Offset = "0x60")]
		private CanvasGroup m_canvasGroup;

		[Token(Token = "0x17000008")]
		protected internal override Object Target
		{
			[Token(Token = "0x6000025")]
			[Address(RVA = "0x819FD04", Offset = "0x819FD04", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_canvasGroup;\n")]
			get
			{
				return m_canvasGroup;
			}
		}

		[Token(Token = "0x6000026")]
		[Address(RVA = "0x819FD0C", Offset = "0x819FD0C", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\nL_0015:\n\tv41 = *([this @ X0 (_game.Scripts.TweenerSystem.TweenElements.CanvasGroupAlphaTweenElement)+20]);\n\treturnVal1 = PrimeTween.Tween::Alpha(this.m_canvasGroup, &v41 @ stack_-60_v1);\n\treturn returnVal1;\n")]
		protected internal unsafe override Tween GetTween()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CanvasGroupAlphaTweenElement::GetTween");
			return default;
		}

		[Token(Token = "0x6000027")]
		[Address(RVA = "0x819FD70", Offset = "0x819FD70", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_0020:\n\t_game.Scripts.TweenerSystem.TweenElement`1<System.Single>::.ctor(this);\n\treturn;\n")]
		public CanvasGroupAlphaTweenElement()
		{
		}
	}
}
