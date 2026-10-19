using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Cpp2ILInjected;
using PrimeTween;
using Reflex.Attributes;
using Unco.Objects;
using UnityEngine;
using UnityEngine.UI;
using _game.CoreGameKit.BaseLayer.Installers;
using _game.CoreGameKit.UiControllers;

namespace _game.CoreGameKit.Ui.UiControllers
{
	[Token(Token = "0x200055B")]
	public class ZoomTutorialUiController : UIController
	{
		[CompilerGenerated]
		[Token(Token = "0x200055C")]
		private sealed class _003CAnimateSprites_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x400125A")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x400125B")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x400125C")]
			[FieldOffset(Offset = "0x20")]
			public ZoomTutorialUiController _003C_003E4__this;

			[Token(Token = "0x400125D")]
			[FieldOffset(Offset = "0x28")]
			private int _003Cindex_003E5__2;

			[Token(Token = "0x17000203")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600167A")]
				[Address(RVA = "0x3D1E088", Offset = "0x3D1E088", Length = "0x8")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000204")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600167C")]
				[Address(RVA = "0x3D1E0D0", Offset = "0x3D1E0D0", Length = "0x8")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6001677")]
			[Address(RVA = "0x3D1DAA8", Offset = "0x3D1DAA8", Length = "0x2C")]
			public _003CAnimateSprites_003Ed__20(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x6001678")]
			[Address(RVA = "0x3D1DF5C", Offset = "0x3D1DF5C", Length = "0x4")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6001679")]
			[Address(RVA = "0x3D1DF60", Offset = "0x3D1DF60", Length = "0x128")]
			private bool MoveNext()
			{
				//IL_012b: Expected O, but got I4
				ZoomTutorialUiController zoomTutorialUiController = _003C_003E4__this;
				Sprite[] fingerSprites;
				if (_003C_003E1__state != 1)
				{
					if (_003C_003E1__state == 0)
					{
						_003C_003E1__state = -1;
						fingerSprites = zoomTutorialUiController.m_fingerSprites;
						if (zoomTutorialUiController.m_fingerSprites != null && fingerSprites.Length != 0)
						{
							_003Cindex_003E5__2 = 0;
							goto IL_00c1;
						}
					}
					return false;
				}
				_003C_003E1__state = -1;
				fingerSprites = zoomTutorialUiController.m_fingerSprites;
				goto IL_00c1;
				IL_00c1:
				int num = _003Cindex_003E5__2;
				zoomTutorialUiController.m_fingerImage.sprite = fingerSprites[num];
				Sprite[] fingerSprites2 = zoomTutorialUiController.m_fingerSprites;
				int num2 = _003Cindex_003E5__2 + 1;
				int num3 = num2 / fingerSprites2.Length;
				object obj = num3 * fingerSprites2.Length;
				int num4 = (int)(num2 - (nint)obj);
				_003Cindex_003E5__2 = num4;
				WaitForSeconds waitForSeconds = new WaitForSeconds(0.3f);
				_003C_003E2__current = waitForSeconds;
				_003C_003E1__state = 1;
				return true;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600167B")]
			[Address(RVA = "0x3D1E090", Offset = "0x3D1E090", Length = "0x40")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[SerializeField]
		[Token(Token = "0x4001248")]
		[FieldOffset(Offset = "0x48")]
		private Image m_bg;

		[SerializeField]
		[Token(Token = "0x4001249")]
		[FieldOffset(Offset = "0x50")]
		private Image m_fingerImage;

		[SerializeField]
		[Token(Token = "0x400124A")]
		[FieldOffset(Offset = "0x58")]
		private Sprite[] m_fingerSprites;

		[SerializeField]
		[Token(Token = "0x400124B")]
		[FieldOffset(Offset = "0x60")]
		private UncoTMP m_text;

		[Header("Alpha Animation Settings")]
		[SerializeField]
		[Token(Token = "0x400124C")]
		[FieldOffset(Offset = "0x68")]
		private float fadeInDuration;

		[SerializeField]
		[Token(Token = "0x400124D")]
		[FieldOffset(Offset = "0x6C")]
		private float fadeOutDuration;

		[SerializeField]
		[Token(Token = "0x400124E")]
		[FieldOffset(Offset = "0x70")]
		private Ease fadeEase;

		[Token(Token = "0x400124F")]
		[FieldOffset(Offset = "0x78")]
		private Coroutine _spriteAnimationCoroutine;

		[Token(Token = "0x4001250")]
		[FieldOffset(Offset = "0x80")]
		private Tween _textScaleTween;

		[Token(Token = "0x4001251")]
		[FieldOffset(Offset = "0x90")]
		private Tween _alphaTween;

		[Token(Token = "0x4001252")]
		[FieldOffset(Offset = "0xA0")]
		private Action _onZoomComplete;

		[Token(Token = "0x4001253")]
		[FieldOffset(Offset = "0xA8")]
		private ZoomTutorialConfig _currentConfig;

		[Token(Token = "0x4001254")]
		[FieldOffset(Offset = "0xB8")]
		private bool _isCheckingZoom;

		[Token(Token = "0x4001255")]
		[FieldOffset(Offset = "0xBC")]
		private float _initialPinchDistance;

		[Token(Token = "0x4001256")]
		[FieldOffset(Offset = "0xC0")]
		private float _currentZoomLevel;

		[Token(Token = "0x4001257")]
		[FieldOffset(Offset = "0xC4")]
		private float _initialAlpha;

		[Token(Token = "0x4001258")]
		[FieldOffset(Offset = "0xC8")]
		private bool _hasFadedOut;

		[Inject(false)]
		[Token(Token = "0x4001259")]
		[FieldOffset(Offset = "0xD0")]
		private IInputProvider _inputProvider;

		[Inject(false)]
		[Token(Token = "0x600166F")]
		[Address(RVA = "0x3D1D6C4", Offset = "0x3D1D6C4", Length = "0x3C")]
		private void Initialize()
		{
			Color color = m_bg.color;
			float initialAlpha = default(float);
			_initialAlpha = initialAlpha;
		}

		[Token(Token = "0x6001670")]
		[Address(RVA = "0x3D1D700", Offset = "0x3D1D700", Length = "0x330")]
		public void StartAnimations(ZoomTutorialConfig t, Action onZoomComplete)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ZoomTutorialUiController::StartAnimations");
		}

		[IteratorStateMachine(typeof(_003CAnimateSprites_003Ed__20))]
		[Token(Token = "0x6001671")]
		[Address(RVA = "0x3D1DA30", Offset = "0x3D1DA30", Length = "0x78")]
		private IEnumerator AnimateSprites()
		{
			_003CAnimateSprites_003Ed__20 _003CAnimateSprites_003Ed__21 = (_003CAnimateSprites_003Ed__20)FormatterServices.GetUninitializedObject(typeof(_003CAnimateSprites_003Ed__20));
			_003CAnimateSprites_003Ed__21._003C_003E1__state = 0;
			_003CAnimateSprites_003Ed__21._003C_003E4__this = this;
			return _003CAnimateSprites_003Ed__21;
		}

		[Token(Token = "0x6001672")]
		[Address(RVA = "0x3D1DAD4", Offset = "0x3D1DAD4", Length = "0x14")]
		private void Update()
		{
			if (_isCheckingZoom)
			{
				CheckZoomInput();
			}
		}

		[Token(Token = "0x6001673")]
		[Address(RVA = "0x3D1DAE8", Offset = "0x3D1DAE8", Length = "0x350")]
		private void CheckZoomInput()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ZoomTutorialUiController::CheckZoomInput");
		}

		[Token(Token = "0x6001674")]
		[Address(RVA = "0x3D1DE38", Offset = "0x3D1DE38", Length = "0x70")]
		private void OnZoomDetected()
		{
			_isCheckingZoom = false;
			if (_spriteAnimationCoroutine != null)
			{
				StopCoroutine(_spriteAnimationCoroutine);
			}
			if (_textScaleTween.isAlive)
			{
				_textScaleTween.Stop();
			}
			if (_onZoomComplete != null)
			{
				_onZoomComplete();
			}
		}

		[Token(Token = "0x6001675")]
		[Address(RVA = "0x3D1DEA8", Offset = "0x3D1DEA8", Length = "0x98")]
		public override void Hide()
		{
			_isCheckingZoom = false;
			if (_spriteAnimationCoroutine != null)
			{
				StopCoroutine(_spriteAnimationCoroutine);
			}
			if (!_textScaleTween.isAlive)
			{
				if (!_alphaTween.isAlive)
				{
					goto IL_009f;
				}
			}
			else
			{
				_textScaleTween.Stop();
				if (!_alphaTween.isAlive)
				{
					goto IL_009f;
				}
			}
			_alphaTween.Stop();
			base.Hide();
			return;
			IL_009f:
			base.Hide();
		}

		[Token(Token = "0x6001676")]
		[Address(RVA = "0x3D1DF40", Offset = "0x3D1DF40", Length = "0x1C")]
		public ZoomTutorialUiController()
		{
			fadeInDuration = 0.5f;
			fadeOutDuration = 0.3f;
			fadeEase = Ease.InOutSine;
		}
	}
}
