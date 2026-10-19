using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using UnityEngine;

namespace _game.Scripts.TweenerSystem.TweenElements.Transform
{
	[Token(Token = "0x200001D")]
	public class TransformScaleTweenElement : TweenElement<Vector3>
	{
		[SerializeField]
		[Token(Token = "0x4000037")]
		[FieldOffset(Offset = "0x70")]
		private UnityEngine.Transform m_target;

		[Token(Token = "0x17000014")]
		protected internal override Object Target
		{
			[Token(Token = "0x6000053")]
			[Address(RVA = "0x81A0F64", Offset = "0x81A0F64", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_target;\n")]
			get
			{
				return m_target;
			}
		}

		[Token(Token = "0x6000054")]
		[Address(RVA = "0x81A0F6C", Offset = "0x81A0F6C", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_001B:\n\tv47 = *([this @ X0 (_game.Scripts.TweenerSystem.TweenElements.Transform.TransformScaleTweenElement)+20]);\n\treturnVal1 = PrimeTween.Tween::Scale(this.m_target, &v47 @ stack_-70_v1);\n\treturn returnVal1;\n")]
		protected internal unsafe override Tween GetTween()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TransformScaleTweenElement::GetTween");
			return default;
		}

		[Token(Token = "0x6000055")]
		[Address(RVA = "0x81A0FD8", Offset = "0x81A0FD8", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_0020:\n\t_game.Scripts.TweenerSystem.TweenElement`1<UnityEngine.Vector3>::.ctor(this);\n\treturn;\n")]
		public TransformScaleTweenElement()
		{
		}
	}
}
