using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using UnityEngine;

namespace _game.Scripts.TweenerSystem.TweenElements.Transform
{
	[Token(Token = "0x2000017")]
	public class TransformLocalPositionSingleAxisTweenElement : TweenElement<float>
	{
		[Token(Token = "0x2000018")]
		private enum Axis
		{
			[Token(Token = "0x4000030")]
			X = 0,
			[Token(Token = "0x4000031")]
			Y = 1,
			[Token(Token = "0x4000032")]
			Z = 2
		}

		[SerializeField]
		[Token(Token = "0x400002D")]
		[FieldOffset(Offset = "0x60")]
		private UnityEngine.Transform m_target;

		[SerializeField]
		[Token(Token = "0x400002E")]
		[FieldOffset(Offset = "0x68")]
		private Axis m_axis;

		[Token(Token = "0x1700000F")]
		protected internal override Object Target
		{
			[Token(Token = "0x6000044")]
			[Address(RVA = "0x81A0AFC", Offset = "0x81A0AFC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_target;\n")]
			get
			{
				return m_target;
			}
		}

		[Token(Token = "0x6000045")]
		[Address(RVA = "0x81A0B04", Offset = "0x81A0B04", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv58 = this.m_axis != 1;\n\tif (v58) goto L_004D;\n\tv61 = *([this @ X0 (_game.Scripts.TweenerSystem.TweenElements.Transform.TransformLocalPositionSingleAxisTweenElement)+20]);\n\treturnVal2 = PrimeTween.Tween::LocalPositionY(this.m_target, &v61 @ stack_-60_v1);\n\treturn returnVal2;\nL_003C:\n\tv61 = *([this @ X0 (_game.Scripts.TweenerSystem.TweenElements.Transform.TransformLocalPositionSingleAxisTweenElement)+20]);\n\treturnVal1 = PrimeTween.Tween::LocalPositionZ(this.m_target, &v61 @ stack_-60_v1);\n\treturn returnVal1;\nL_004D:\n\tv61 = *([this @ X0 (_game.Scripts.TweenerSystem.TweenElements.Transform.TransformLocalPositionSingleAxisTweenElement)+20]);\n\treturnVal3 = PrimeTween.Tween::LocalPositionX(this.m_target, &v61 @ stack_-60_v1);\n\treturn returnVal3;\nL_0018:\n\tv44 = this.m_axis == 2;\n\tif (v44) goto L_003C;\n")]
		protected internal unsafe override Tween GetTween()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TransformLocalPositionSingleAxisTweenElement::GetTween");
			return default;
		}

		[Token(Token = "0x6000046")]
		[Address(RVA = "0x81A0BD4", Offset = "0x81A0BD4", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_0020:\n\t_game.Scripts.TweenerSystem.TweenElement`1<System.Single>::.ctor(this);\n\treturn;\n")]
		public TransformLocalPositionSingleAxisTweenElement()
		{
		}
	}
}
