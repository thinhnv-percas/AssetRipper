using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using UnityEngine;
using UnityEngine.Events;

namespace _game.Scripts.TweenerSystem.TweenElements
{
	[Token(Token = "0x200000B")]
	public class CallbackTweenElement : TweenRootElement
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200000C")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000019")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400001A")]
			public static Action<CallbackTweenElement> _003C_003E9__2_0;

			[Token(Token = "0x400001B")]
			public static Action<CallbackTweenElement> _003C_003E9__2_1;

			[Token(Token = "0x6000021")]
			[Address(RVA = "0x819FC50", Offset = "0x819FC50", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.Scripts.TweenerSystem.TweenElements.CallbackTweenElement+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000022")]
			[Address(RVA = "0x819FCB4", Offset = "0x819FCB4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal void _003CPrepare_003Eb__2_0(CallbackTweenElement t)
			{
				t.m_callback.Invoke();
			}

			internal void _003CPrepare_003Eb__2_1(CallbackTweenElement t)
			{
				t.m_callback.Invoke();
			}
		}

		[SerializeField]
		[Token(Token = "0x4000017")]
		[FieldOffset(Offset = "0x20")]
		private UnityEvent m_callback;

		[SerializeField]
		[Token(Token = "0x4000018")]
		[FieldOffset(Offset = "0x28")]
		private bool m_warnIfDestroyed;

		[Token(Token = "0x600001F")]
		[Address(RVA = "0x819F960", Offset = "0x819F960", Length = "0x2E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = sequence;\n\tgoto L_0036;\n\tv72 = operation != 1;\n\tif (v72) goto L_0060;\n\tgoto L_004E;\nL_004E:\n\tv167 = v101.<>9__2_0;\n\tv103 = v101.<>9__2_0 == 0;\n\tv104 = ~v103;\n\tif (v104) goto L_00B1;\n\tgoto L_0094;\nL_0058:\n\tgoto L_005A;\nL_005A:\n\tv132 = v93.<>9__2_1;\n\tv95 = v93.<>9__2_1 == 0;\n\tv96 = ~v95;\n\tif (v96) goto L_00E4;\n\tgoto L_00C6;\nL_0060:\n\tv87 = 1;\n\t// 101 Box v92 @ X0_v17 (System.Object), typeof(_game.Scripts.TweenerSystem.SequenceOperation), &v87 @ stack_-54_v1 (System.Int32)\n\tv108 = 2;\n\t// 107 Box v111 @ X0_v19 (System.Object), typeof(_game.Scripts.TweenerSystem.SequenceOperation), &v108 @ stack_-58_v1 (System.Int32)\n\tv257 = System.String::Format(\"Callback Tween Element: Callbacks only support {0} or {1} operations!\", v92, v111);\n\tgoto L_007F;\nL_0094:\n\tgoto L_009C;\nL_00B1:\n\tv177 = PrimeTween.Sequence::ChainCallback(&v24 @ stack_-50_v1 (PrimeTween.Sequence), this, v167, this.m_warnIfDestroyed);\n\treturn;\nL_00C6:\n\tgoto L_00CE;\nL_00E4:\n\tv143 = PrimeTween.Sequence::InsertCallback(&v24 @ stack_-50_v1 (PrimeTween.Sequence), insertTime, this, v132, this.m_warnIfDestroyed);\n\treturn;\nL_0036:\n\tv55 = operation == 2;\n\tif (v55) goto L_0058;\nL_007F:\n\tUnityEngine.Debug::LogError(v257);\n\treturn;\nL_009C:\n\tv280 = new System.Action`1<_game.Scripts.TweenerSystem.TweenElements.CallbackTweenElement>();\n\tSystem.Action`1<_game.Scripts.TweenerSystem.TweenElements.CallbackTweenElement>::.ctor(v280, v275.<>9, Il2CppMethodInfo);\n\tv301.<>9__2_0 = v280;\n\tv167 = v280;\nL_00CE:\n\tv228 = new System.Action`1<_game.Scripts.TweenerSystem.TweenElements.CallbackTweenElement>();\n\tSystem.Action`1<_game.Scripts.TweenerSystem.TweenElements.CallbackTweenElement>::.ctor(v228, v223.<>9, Il2CppMethodInfo);\n\tv297.<>9__2_1 = v228;\n\tv132 = v228;\n")]
		internal override void Prepare(Sequence sequence, SequenceOperation operation, float insertTime)
		{
			Sequence sequence2 = sequence;
			switch (operation)
			{
			case SequenceOperation.Chain:
			{
				Action<CallbackTweenElement> callback2 = _003C_003Ec._003C_003E9__2_0;
				if (_003C_003Ec._003C_003E9__2_0 == null)
				{
					callback2 = (_003C_003Ec._003C_003E9__2_0 = delegate(CallbackTweenElement t)
					{
						t.m_callback.Invoke();
					});
				}
				Sequence sequence4 = sequence2.ChainCallback(this, callback2, m_warnIfDestroyed);
				break;
			}
			case SequenceOperation.Insert:
			{
				Action<CallbackTweenElement> callback = _003C_003Ec._003C_003E9__2_1;
				if (_003C_003Ec._003C_003E9__2_1 == null)
				{
					callback = (_003C_003Ec._003C_003E9__2_1 = delegate(CallbackTweenElement t)
					{
						t.m_callback.Invoke();
					});
				}
				Sequence sequence3 = sequence2.InsertCallback(insertTime, this, callback, m_warnIfDestroyed);
				break;
			}
			default:
			{
				int num = 1;
				object arg = (SequenceOperation)num;
				int num2 = 2;
				object arg2 = (SequenceOperation)num2;
				string message = $"Callback Tween Element: Callbacks only support {arg} or {arg2} operations!";
				Debug.LogError(message);
				break;
			}
			}
		}

		[Token(Token = "0x6000020")]
		[Address(RVA = "0x819FC40", Offset = "0x819FC40", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_warnIfDestroyed = 1;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public CallbackTweenElement()
		{
			m_warnIfDestroyed = true;
		}
	}
}
