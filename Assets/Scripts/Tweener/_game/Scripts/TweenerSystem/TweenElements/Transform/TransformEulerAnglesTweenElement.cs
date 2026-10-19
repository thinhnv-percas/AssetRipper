using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using UnityEngine;

namespace _game.Scripts.TweenerSystem.TweenElements.Transform
{
	[Token(Token = "0x2000015")]
	public class TransformEulerAnglesTweenElement : TweenElement<Vector3>
	{
		[SerializeField]
		[Token(Token = "0x400002B")]
		[FieldOffset(Offset = "0x70")]
		private UnityEngine.Transform m_target;

		[Token(Token = "0x1700000D")]
		protected internal override Object Target
		{
			[Token(Token = "0x600003E")]
			[Address(RVA = "0x81A0964", Offset = "0x81A0964", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_target;\n")]
			get
			{
				return m_target;
			}
		}

		[Token(Token = "0x600003F")]
		[Address(RVA = "0x81A096C", Offset = "0x81A096C", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_001B:\n\tv47 = *([this @ X0 (_game.Scripts.TweenerSystem.TweenElements.Transform.TransformEulerAnglesTweenElement)+20]);\n\treturnVal1 = PrimeTween.Tween::Rotation(this.m_target, &v47 @ stack_-70_v1);\n\treturn returnVal1;\n")]
		protected internal unsafe override Tween GetTween()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TransformEulerAnglesTweenElement::GetTween");
			return default;
		}

		[Token(Token = "0x6000040")]
		[Address(RVA = "0x81A09D8", Offset = "0x81A09D8", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_0020:\n\t_game.Scripts.TweenerSystem.TweenElement`1<UnityEngine.Vector3>::.ctor(this);\n\treturn;\n")]
		public TransformEulerAnglesTweenElement()
		{
		}
	}
}
