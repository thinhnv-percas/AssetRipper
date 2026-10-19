using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using UnityEngine;

namespace _game.Scripts.TweenerSystem.TweenElements.Transform
{
	[Token(Token = "0x200001A")]
	public class TransformLocalRotationTweenElement : TweenElement<Quaternion>
	{
		[SerializeField]
		[Token(Token = "0x4000034")]
		[FieldOffset(Offset = "0x78")]
		private UnityEngine.Transform m_target;

		[Token(Token = "0x17000011")]
		protected internal override Object Target
		{
			[Token(Token = "0x600004A")]
			[Address(RVA = "0x81A0CF8", Offset = "0x81A0CF8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_target;\n")]
			get
			{
				return m_target;
			}
		}

		[Token(Token = "0x600004B")]
		[Address(RVA = "0x81A0D00", Offset = "0x81A0D00", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\nL_001D:\n\tv49 = *([this @ X0 (_game.Scripts.TweenerSystem.TweenElements.Transform.TransformLocalRotationTweenElement)+20]);\n\treturnVal1 = PrimeTween.Tween::LocalRotation(this.m_target, &v49 @ stack_-80_v1);\n\treturn returnVal1;\n")]
		protected internal unsafe override Tween GetTween()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TransformLocalRotationTweenElement::GetTween");
			return default;
		}

		[Token(Token = "0x600004C")]
		[Address(RVA = "0x81A0D70", Offset = "0x81A0D70", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_0020:\n\t_game.Scripts.TweenerSystem.TweenElement`1<UnityEngine.Quaternion>::.ctor(this);\n\treturn;\n")]
		public TransformLocalRotationTweenElement()
		{
		}
	}
}
