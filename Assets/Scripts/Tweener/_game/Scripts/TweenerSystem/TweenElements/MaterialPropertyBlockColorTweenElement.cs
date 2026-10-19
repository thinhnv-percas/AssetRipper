using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using UnityEngine;

namespace _game.Scripts.TweenerSystem.TweenElements
{
	[Token(Token = "0x2000010")]
	public class MaterialPropertyBlockColorTweenElement : TweenElement<Color>
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000011")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000022")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000023")]
			public static Action<MaterialPropertyBlockColorTweenElement, Color> _003C_003E9__5_0;

			[Token(Token = "0x6000030")]
			[Address(RVA = "0x81A02EC", Offset = "0x81A02EC", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.Scripts.TweenerSystem.TweenElements.MaterialPropertyBlockColorTweenElement+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000031")]
			[Address(RVA = "0x81A0350", Offset = "0x81A0350", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal void _003CGetTween_003Eb__5_0(MaterialPropertyBlockColorTweenElement t, Color v)
			{
				t.m_renderer.GetPropertyBlock(s_propertyBlock);
				s_propertyBlock.SetColor(t.m_propertyID, v);
				t.m_renderer.SetPropertyBlock(s_propertyBlock);
			}
		}

		[Token(Token = "0x400001F")]
		private static MaterialPropertyBlock s_propertyBlock;

		[SerializeField]
		[Token(Token = "0x4000020")]
		[FieldOffset(Offset = "0x78")]
		private Renderer m_renderer;

		[SerializeField]
		[Token(Token = "0x4000021")]
		[FieldOffset(Offset = "0x80")]
		private string m_propertyID;

		[Token(Token = "0x1700000A")]
		protected internal override UnityEngine.Object Target
		{
			[Token(Token = "0x600002D")]
			[Address(RVA = "0x819FFD4", Offset = "0x819FFD4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_renderer;\n")]
			get
			{
				return m_renderer;
			}
		}

		[Token(Token = "0x600002E")]
		[Address(RVA = "0x819FFDC", Offset = "0x819FFDC", Length = "0x2B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003C;\n\tv83 = new UnityEngine.MaterialPropertyBlock();\n\tUnityEngine.MaterialPropertyBlock::.ctor(v83);\n\tv119.s_propertyBlock = v83;\nL_0052:\n\tUnityEngine.Renderer::GetPropertyBlock(this.m_renderer, v99.s_propertyBlock);\n\tv124 = UnityEngine.MaterialPropertyBlock::HasFloat(v113.s_propertyBlock, this.m_propertyID);\n\tv219 = v124 == 0;\n\tif (v219) goto L_006E;\n\tv229 = UnityEngine.MaterialPropertyBlock::GetColor(v114.s_propertyBlock, this.m_propertyID);\n\tv230 = v229.a;\n\tv232 = v229.b;\n\tv234 = v229.g;\n\tv236 = v229;\n\tgoto L_0081;\nL_006E:\n\tv236 = *([this @ X0 (_game.Scripts.TweenerSystem.TweenElements.MaterialPropertyBlockColorTweenElement)+24]);\n\tv234 = *([this @ X0 (_game.Scripts.TweenerSystem.TweenElements.MaterialPropertyBlockColorTweenElement)+28]);\n\tv232 = *([this @ X0 (_game.Scripts.TweenerSystem.TweenElements.MaterialPropertyBlockColorTweenElement)+2C]);\n\tv230 = *([this @ X0 (_game.Scripts.TweenerSystem.TweenElements.MaterialPropertyBlockColorTweenElement)+30]);\nL_0083:\n\tv306 = 0xB2D6000 + 0xF30;\n\tv198 = v267.<>9__5_0;\n\tv269 = v267.<>9__5_0 == 0;\n\tif (v269) goto L_00A0;\n\tv178 = *([this @ X0 (_game.Scripts.TweenerSystem.TweenElements.MaterialPropertyBlockColorTweenElement)+48]);\n\tgoto L_00BF;\nL_00A0:\n\tgoto L_00A8;\n\tv178 = *([this @ X0 (_game.Scripts.TweenerSystem.TweenElements.MaterialPropertyBlockColorTweenElement)+48]);\n\tv306 = v306;\n\tv198 = v332;\nL_003C:\n\tv75 = v73.s_propertyBlock == 0;\n\tv76 = ~v75;\n\tif (v76) goto L_0052;\nL_0081:\n\tgoto L_0083;\nL_00BF:\n\tv146 = v178;\n\t// 206 MakeStruct v129 @ AGG81A0264_1_v1 (UnityEngine.Color), typeof(UnityEngine.Color), v236 @ V8_v1 (UnityEngine.Color), v234 @ V9_v1 (System.Single), v232 @ V10_v1 (System.Single), v230 @ V11_v1 (System.Single)\n\t// 207 MakeStruct v126 @ AGG81A0264_2_v1 (UnityEngine.Color), typeof(UnityEngine.Color), [this @ X0 (_game.Scripts.TweenerSystem.TweenElements.MaterialPropertyBlockColorTweenElement)+34], [this @ X0 (_game.Scripts.TweenerSystem.TweenElements.MaterialPropertyBlockColorTweenElement)+38], [this @ X0 (_game.Scripts.TweenerSystem.TweenElements.MaterialPropertyBlockColorTweenElement)+3C], [this @ X0 (_game.Scripts.TweenerSystem.TweenElements.MaterialPropertyBlockColorTweenElement)+40]\n\treturnVal2 = PrimeTween.Tween::Custom /* +1 sharing this address */(this, v129, v126, &v146 @ stack_-B0_v2, v198, *([v306 @ X22_v1 (System.Int32)]));\n\treturn returnVal2;\nL_00A8:\n\tv332 = new System.Action`2<_game.Scripts.TweenerSystem.TweenElements.MaterialPropertyBlockColorTweenElement, UnityEngine.Color>();\n\tSystem.Action`2<_game.Scripts.TweenerSystem.TweenElements.MaterialPropertyBlockColorTweenElement, UnityEngine.Color>::.ctor(v332, v327.<>9, Il2CppMethodInfo);\n\tv338.<>9__5_0 = v332;\n")]
		protected internal override Tween GetTween()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MaterialPropertyBlockColorTweenElement::GetTween");
			return default;
		}

		[Token(Token = "0x600002F")]
		[Address(RVA = "0x81A0294", Offset = "0x81A0294", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_0020:\n\t_game.Scripts.TweenerSystem.TweenElement`1<UnityEngine.Color>::.ctor(this);\n\treturn;\n")]
		public MaterialPropertyBlockColorTweenElement()
		{
		}
	}
}
