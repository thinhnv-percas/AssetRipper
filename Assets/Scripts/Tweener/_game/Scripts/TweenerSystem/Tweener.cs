using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using UnityEngine;

namespace _game.Scripts.TweenerSystem
{
	[Token(Token = "0x2000008")]
	public class Tweener : MonoBehaviour
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000009")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000011")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000012")]
			public static Action<Tweener> _003C_003E9__11_0;

			[Token(Token = "0x600001C")]
			[Address(RVA = "0x819F8AC", Offset = "0x819F8AC", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.Scripts.TweenerSystem.Tweener+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x600001D")]
			[Address(RVA = "0x819F910", Offset = "0x819F910", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal void _003CPlay_003Eb__11_0(Tweener t)
			{
				if (t._onComplete != null)
				{
					t._onComplete();
				}
				t._onComplete = null;
			}
		}

		[SerializeField]
		[Token(Token = "0x400000C")]
		[FieldOffset(Offset = "0x20")]
		private TweenRootElement m_tweenElement;

		[SerializeField]
		[Token(Token = "0x400000D")]
		[FieldOffset(Offset = "0x28")]
		private bool m_playOnStart;

		[SerializeField]
		[Token(Token = "0x400000E")]
		[FieldOffset(Offset = "0x29")]
		private bool m_useUnscaledTime;

		[Token(Token = "0x400000F")]
		[FieldOffset(Offset = "0x30")]
		private Sequence _activeSequence;

		[Token(Token = "0x4000010")]
		[FieldOffset(Offset = "0x40")]
		private Action _onComplete;

		[Token(Token = "0x17000006")]
		public bool IsAlive
		{
			[Token(Token = "0x6000010")]
			[Address(RVA = "0x819F4C0", Offset = "0x819F4C0", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = PrimeTween.Sequence::get_isAlive(&this._activeSequence (PrimeTween.Sequence));\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return _activeSequence.isAlive;
			}
		}

		[Token(Token = "0x17000007")]
		public bool IsPaused
		{
			[Token(Token = "0x6000011")]
			[Address(RVA = "0x819F4CC", Offset = "0x819F4CC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = PrimeTween.Sequence::get_isPaused(&this._activeSequence (PrimeTween.Sequence));\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return _activeSequence.isPaused;
			}
		}

		[Token(Token = "0x6000012")]
		[Address(RVA = "0x819F4D8", Offset = "0x819F4D8", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.m_playOnStart != 1;\n\tif (v11) goto L_000E;\n\tv12 = _game.Scripts.TweenerSystem.Tweener::Play(this);\n\treturn;\nL_000E:\n\treturn;\n")]
		private void Start()
		{
			if (m_playOnStart)
			{
				Sequence sequence = Play();
			}
		}

		[Token(Token = "0x6000013")]
		[Address(RVA = "0x819F770", Offset = "0x819F770", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = _game.Scripts.TweenerSystem.Tweener::Play(this);\n\treturn;\n")]
		public void PlayNoReturn()
		{
			Sequence sequence = Play();
		}

		[Token(Token = "0x6000014")]
		[Address(RVA = "0x819F4EC", Offset = "0x819F4EC", Length = "0x284")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv55 = UnityEngine.Object::op_Equality(this.m_tweenElement, 0);\n\tv64 = ~v55;\n\tif (v64) goto L_0065;\n\tv81 = UnityEngine.Component::get_gameObject(this);\n\tv101 = UnityEngine.Object::get_name(v81);\n\tv194 = System.String::Concat(\"[Tweener] TweenElement is not assigned on \", v101);\n\tgoto L_0035;\nL_0065:\n\t;\n\tv90 = PrimeTween.Sequence::get_isAlive(&this._activeSequence (PrimeTween.Sequence));\n\tv96 = ~v90;\n\tif (v96) goto L_0073;\n\tPrimeTween.Sequence::Stop(&this._activeSequence (PrimeTween.Sequence));\nL_0073:\n\tv126 = PrimeTween.Sequence::Create(1, 0, 1, this.m_useUnscaledTime, 0);\n\tthis._activeSequence.root.tween = 0;\n\tthis._activeSequence.root.id = v126;\n\tv204 = _game.Scripts.TweenerSystem.TweenRootElement::Prepare(this.m_tweenElement, this._activeSequence, 0, 0f);\n\tgoto L_008D;\nL_008D:\n\tv232 = v210.<>9__11_0;\n\tv212 = v210.<>9__11_0 == 0;\n\tv213 = ~v212;\n\tif (v213) goto L_00B5;\n\tgoto L_009C;\nL_009C:\n\tgoto L_00A4;\nL_00B5:\n\t;\n\tv238 = PrimeTween.Sequence::ChainCallback(&this._activeSequence (PrimeTween.Sequence), this, v232, 1);\n\treturn this._activeSequence;\nL_0035:\n\tUnityEngine.Debug::LogError(v194, this);\n\treturn 0;\nL_00A4:\n\tv252 = new System.Action`1<_game.Scripts.TweenerSystem.Tweener>();\n\tSystem.Action`1<_game.Scripts.TweenerSystem.Tweener>::.ctor(v252, v247.<>9, Il2CppMethodInfo);\n\tv257.<>9__11_0 = v252;\n\tv232 = v252;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Sequence Play()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Tweener::Play");
			return default;
		}

		[Token(Token = "0x6000015")]
		[Address(RVA = "0x819F774", Offset = "0x819F774", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv65 = *([v49 @ X0_v3 (System.Delegate)]) != System.Action;\n\tif (v65) goto L_0051;\n\tthis._onComplete = v49;\n\tv85 = *([v49 @ X0_v3 (System.Delegate)]) != System.Action;\n\tif (v85) goto L_0051;\n\treturn;\nL_0044:\n\tthis._onComplete = 0;\n\treturn;\nL_0051:\n\tthrow System.InvalidCastException;\nL_0019:\n\tv49 = System.Delegate::Combine(this._onComplete, onComplete);\n\tv51 = v49 == 0;\n\tif (v51) goto L_0044;\n")]
		public void OnComplete(Action onComplete)
		{
			Delegate obj = Delegate.Combine(_onComplete, onComplete);
			if ((object)obj != null)
			{
				if ((object)obj.GetType() == typeof(Action))
				{
					_onComplete = (Action)obj;
					if ((object)obj.GetType() == typeof(Action))
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			_onComplete = null;
		}

		[Token(Token = "0x6000016")]
		[Address(RVA = "0x819F828", Offset = "0x819F828", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tPrimeTween.Sequence::set_isPaused(&this._activeSequence (PrimeTween.Sequence), 1);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Pause()
		{
			_activeSequence.isPaused = true;
		}

		[Token(Token = "0x6000017")]
		[Address(RVA = "0x819F838", Offset = "0x819F838", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tPrimeTween.Sequence::set_isPaused(&this._activeSequence (PrimeTween.Sequence), 0);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Resume()
		{
			_activeSequence.isPaused = false;
		}

		[Token(Token = "0x6000018")]
		[Address(RVA = "0x819F848", Offset = "0x819F848", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tPrimeTween.Sequence::Complete(&this._activeSequence (PrimeTween.Sequence));\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Complete()
		{
			_activeSequence.Complete();
		}

		[Token(Token = "0x6000019")]
		[Address(RVA = "0x819F854", Offset = "0x819F854", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tPrimeTween.Sequence::Stop(&this._activeSequence (PrimeTween.Sequence));\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Stop()
		{
			_activeSequence.Stop();
		}

		[Token(Token = "0x600001A")]
		[Address(RVA = "0x819F860", Offset = "0x819F860", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv57 = this + 0x40;\n\tv3 = this._onComplete == 0;\n\tif (v3) goto L_0016;\n\tSystem.Action::Invoke(this._onComplete);\nL_0016:\n\t*([v57 @ X0_v2]) = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnComplete()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Tweener::OnComplete");
		}

		[Token(Token = "0x600001B")]
		[Address(RVA = "0x819F8A4", Offset = "0x819F8A4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public Tweener()
		{
		}
	}
}
