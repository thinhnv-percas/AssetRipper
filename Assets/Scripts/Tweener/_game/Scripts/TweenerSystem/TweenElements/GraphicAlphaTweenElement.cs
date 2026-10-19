using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using UnityEngine;
using UnityEngine.UI;

namespace _game.Scripts.TweenerSystem.TweenElements
{
	[Token(Token = "0x200000F")]
	public class GraphicAlphaTweenElement : TweenElement<float>
	{
		[SerializeField]
		[Token(Token = "0x400001E")]
		[FieldOffset(Offset = "0x60")]
		private Graphic m_graphic;

		[Token(Token = "0x17000009")]
		protected internal override Object Target
		{
			[Token(Token = "0x600002A")]
			[Address(RVA = "0x819FF10", Offset = "0x819FF10", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_graphic;\n")]
			get
			{
				return m_graphic;
			}
		}

		[Token(Token = "0x600002B")]
		[Address(RVA = "0x819FF18", Offset = "0x819FF18", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\nL_0015:\n\tv41 = *([this @ X0 (_game.Scripts.TweenerSystem.TweenElements.GraphicAlphaTweenElement)+20]);\n\treturnVal1 = PrimeTween.Tween::Alpha(this.m_graphic, &v41 @ stack_-60_v1);\n\treturn returnVal1;\n")]
		protected internal unsafe override Tween GetTween()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GraphicAlphaTweenElement::GetTween");
			return default;
		}

		[Token(Token = "0x600002C")]
		[Address(RVA = "0x819FF7C", Offset = "0x819FF7C", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_0020:\n\t_game.Scripts.TweenerSystem.TweenElement`1<System.Single>::.ctor(this);\n\treturn;\n")]
		public GraphicAlphaTweenElement()
		{
		}
	}
}
