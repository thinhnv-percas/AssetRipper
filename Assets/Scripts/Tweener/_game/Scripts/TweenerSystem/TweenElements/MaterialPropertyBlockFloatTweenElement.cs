using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using UnityEngine;

namespace _game.Scripts.TweenerSystem.TweenElements
{
	[Token(Token = "0x2000012")]
	public class MaterialPropertyBlockFloatTweenElement : TweenElement<float>
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000013")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000027")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000028")]
			public static Action<MaterialPropertyBlockFloatTweenElement, float> _003C_003E9__5_0;

			[Token(Token = "0x6000036")]
			[Address(RVA = "0x81A06F4", Offset = "0x81A06F4", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.Scripts.TweenerSystem.TweenElements.MaterialPropertyBlockFloatTweenElement+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000037")]
			[Address(RVA = "0x81A0758", Offset = "0x81A0758", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal void _003CGetTween_003Eb__5_0(MaterialPropertyBlockFloatTweenElement t, float v)
			{
				t.m_renderer.GetPropertyBlock(s_propertyBlock);
				s_propertyBlock.SetFloat(t.m_propertyID, v);
				t.m_renderer.SetPropertyBlock(s_propertyBlock);
			}
		}

		[Token(Token = "0x4000024")]
		private static MaterialPropertyBlock s_propertyBlock;

		[SerializeField]
		[Token(Token = "0x4000025")]
		[FieldOffset(Offset = "0x60")]
		private Renderer m_renderer;

		[SerializeField]
		[Token(Token = "0x4000026")]
		[FieldOffset(Offset = "0x68")]
		private string m_propertyID;

		[Token(Token = "0x1700000B")]
		protected internal override UnityEngine.Object Target
		{
			[Token(Token = "0x6000033")]
			[Address(RVA = "0x81A0424", Offset = "0x81A0424", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_renderer;\n")]
			get
			{
				return m_renderer;
			}
		}

		[Token(Token = "0x6000034")]
		[Address(RVA = "0x81A042C", Offset = "0x81A042C", Length = "0x270")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0036;\n\tv71 = new UnityEngine.MaterialPropertyBlock();\n\tUnityEngine.MaterialPropertyBlock::.ctor(v71);\n\tv107.s_propertyBlock = v71;\nL_004C:\n\tUnityEngine.Renderer::GetPropertyBlock(this.m_renderer, v87.s_propertyBlock);\n\tv112 = UnityEngine.MaterialPropertyBlock::HasFloat(v101.s_propertyBlock, this.m_propertyID);\n\tv177 = v112 == 0;\n\tif (v177) goto L_0062;\n\tv184 = UnityEngine.MaterialPropertyBlock::GetFloat(v102.s_propertyBlock, this.m_propertyID);\n\tv185 = v184;\n\tgoto L_006F;\nL_0062:\n\tv185 = *([this @ X0 (_game.Scripts.TweenerSystem.TweenElements.MaterialPropertyBlockFloatTweenElement)+24]);\nL_0071:\n\tv248 = 0xB2D6000 + 0xF38;\n\tv156 = v207.<>9__5_0;\n\tv209 = v207.<>9__5_0 == 0;\n\tif (v209) goto L_008E;\n\tv146 = *([this @ X0 (_game.Scripts.TweenerSystem.TweenElements.MaterialPropertyBlockFloatTweenElement)+30]);\n\tgoto L_00AD;\nL_008E:\n\tgoto L_0096;\n\tv146 = *([this @ X0 (_game.Scripts.TweenerSystem.TweenElements.MaterialPropertyBlockFloatTweenElement)+30]);\n\tv248 = v248;\n\tv156 = v272;\nL_0036:\n\tv63 = v61.s_propertyBlock == 0;\n\tv64 = ~v63;\n\tif (v64) goto L_004C;\nL_006F:\n\tgoto L_0071;\nL_00AD:\n\tv120 = v146;\n\treturnVal2 = PrimeTween.Tween::Custom /* +1 sharing this address */(this, v185, *([this @ X0 (_game.Scripts.TweenerSystem.TweenElements.MaterialPropertyBlockFloatTweenElement)+28]), &v120 @ stack_-80_v2, v156, *([v248 @ X22_v1 (System.Int32)]));\n\treturn returnVal2;\nL_0096:\n\tv272 = new System.Action`2<_game.Scripts.TweenerSystem.TweenElements.MaterialPropertyBlockFloatTweenElement, System.Single>();\n\tSystem.Action`2<_game.Scripts.TweenerSystem.TweenElements.MaterialPropertyBlockFloatTweenElement, System.Single>::.ctor(v272, v267.<>9, Il2CppMethodInfo);\n\tv278.<>9__5_0 = v272;\n")]
		protected internal override Tween GetTween()
		{
			//IL_0099: Expected F4, but got I
			//IL_00e0: Expected O, but got I
			//IL_00fa: Expected O, but got I
			if (s_propertyBlock == null)
			{
				MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
				s_propertyBlock = materialPropertyBlock;
			}
			m_renderer.GetPropertyBlock(s_propertyBlock);
			if (s_propertyBlock.HasFloat(m_propertyID))
			{
				float num = s_propertyBlock.GetFloat(m_propertyID);
				float num2 = num;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (_game.Scripts.TweenerSystem.TweenElements.MaterialPropertyBlockFloatTweenElement)+24]");
				float num2 = 0f;
			}
			int num3 = 187523072 + 3896;
			Action<MaterialPropertyBlockFloatTweenElement, float> _003C_003E9__5_ = _003C_003Ec._003C_003E9__5_0;
			object obj;
			if (_003C_003Ec._003C_003E9__5_0 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (_game.Scripts.TweenerSystem.TweenElements.MaterialPropertyBlockFloatTweenElement)+30]");
				obj = 0;
			}
			else
			{
				Action<MaterialPropertyBlockFloatTweenElement, float> action = (_003C_003Ec._003C_003E9__5_0 = delegate(MaterialPropertyBlockFloatTweenElement t, float v)
				{
					t.m_renderer.GetPropertyBlock(s_propertyBlock);
					s_propertyBlock.SetFloat(t.m_propertyID, v);
					t.m_renderer.SetPropertyBlock(s_propertyBlock);
				});
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (_game.Scripts.TweenerSystem.TweenElements.MaterialPropertyBlockFloatTweenElement)+30]");
				obj = 0;
				num3 = num3;
				_003C_003E9__5_ = action;
			}
			object obj2 = obj;
			Il2CppRuntime.Boundary("MANAGED", "Method not found @4D15FC4 (PrimeTween.Tween::Custom, and 1 more at this address)");
			Tween result = default(Tween);
			return result;
		}

		[Token(Token = "0x6000035")]
		[Address(RVA = "0x81A069C", Offset = "0x81A069C", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_0020:\n\t_game.Scripts.TweenerSystem.TweenElement`1<System.Single>::.ctor(this);\n\treturn;\n")]
		public MaterialPropertyBlockFloatTweenElement()
		{
		}
	}
}
