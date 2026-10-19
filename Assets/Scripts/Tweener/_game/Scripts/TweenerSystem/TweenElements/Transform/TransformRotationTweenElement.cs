using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using UnityEngine;

namespace _game.Scripts.TweenerSystem.TweenElements.Transform
{
	[Token(Token = "0x200001C")]
	public class TransformRotationTweenElement : TweenElement<Quaternion>
	{
		[SerializeField]
		[Token(Token = "0x4000036")]
		[FieldOffset(Offset = "0x78")]
		private UnityEngine.Transform m_target;

		[Token(Token = "0x17000013")]
		protected internal override Object Target
		{
			[Token(Token = "0x6000050")]
			[Address(RVA = "0x81A0E94", Offset = "0x81A0E94", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_target;\n")]
			get
			{
				return m_target;
			}
		}

		[Token(Token = "0x6000051")]
		[Address(RVA = "0x81A0E9C", Offset = "0x81A0E9C", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\nL_001D:\n\tv49 = *([this @ X0 (_game.Scripts.TweenerSystem.TweenElements.Transform.TransformRotationTweenElement)+20]);\n\treturnVal1 = PrimeTween.Tween::Rotation(this.m_target, &v49 @ stack_-80_v1);\n\treturn returnVal1;\n")]
		protected internal unsafe override Tween GetTween()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TransformRotationTweenElement::GetTween");
			return default;
		}

		[Token(Token = "0x6000052")]
		[Address(RVA = "0x81A0F0C", Offset = "0x81A0F0C", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_0020:\n\t_game.Scripts.TweenerSystem.TweenElement`1<UnityEngine.Quaternion>::.ctor(this);\n\treturn;\n")]
		public TransformRotationTweenElement()
		{
		}
	}
}
