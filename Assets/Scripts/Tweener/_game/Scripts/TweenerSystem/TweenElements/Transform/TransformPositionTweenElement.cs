using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using UnityEngine;

namespace _game.Scripts.TweenerSystem.TweenElements.Transform
{
	[Token(Token = "0x200001B")]
	public class TransformPositionTweenElement : TweenElement<Vector3>
	{
		[SerializeField]
		[Token(Token = "0x4000035")]
		[FieldOffset(Offset = "0x70")]
		private UnityEngine.Transform m_target;

		[Token(Token = "0x17000012")]
		protected internal override Object Target
		{
			[Token(Token = "0x600004D")]
			[Address(RVA = "0x81A0DC8", Offset = "0x81A0DC8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_target;\n")]
			get
			{
				return m_target;
			}
		}

		[Token(Token = "0x600004E")]
		[Address(RVA = "0x81A0DD0", Offset = "0x81A0DD0", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_001B:\n\tv47 = *([this @ X0 (_game.Scripts.TweenerSystem.TweenElements.Transform.TransformPositionTweenElement)+20]);\n\treturnVal1 = PrimeTween.Tween::Position(this.m_target, &v47 @ stack_-70_v1);\n\treturn returnVal1;\n")]
		protected internal unsafe override Tween GetTween()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TransformPositionTweenElement::GetTween");
			return default;
		}

		[Token(Token = "0x600004F")]
		[Address(RVA = "0x81A0E3C", Offset = "0x81A0E3C", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_0020:\n\t_game.Scripts.TweenerSystem.TweenElement`1<UnityEngine.Vector3>::.ctor(this);\n\treturn;\n")]
		public TransformPositionTweenElement()
		{
		}
	}
}
