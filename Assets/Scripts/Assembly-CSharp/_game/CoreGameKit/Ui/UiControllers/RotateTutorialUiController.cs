using System;
using Cpp2ILInjected;
using PrimeTween;
using Reflex.Attributes;
using UnityEngine;
using UnityEngine.UI;
using _game.CoreGameKit.BaseLayer.Installers;
using _game.CoreGameKit.UiControllers;

namespace _game.CoreGameKit.Ui.UiControllers
{
	[Token(Token = "0x2000553")]
	public class RotateTutorialUiController : UIController
	{
		[SerializeField]
		[Token(Token = "0x40011F5")]
		[FieldOffset(Offset = "0x48")]
		private Image m_fingerImage;

		[SerializeField]
		[Token(Token = "0x40011F6")]
		[FieldOffset(Offset = "0x50")]
		private Image m_bg;

		[Header("Tap Animation Settings")]
		[SerializeField]
		[Token(Token = "0x40011F7")]
		[FieldOffset(Offset = "0x58")]
		private float tapScaleAmount;

		[SerializeField]
		[Token(Token = "0x40011F8")]
		[FieldOffset(Offset = "0x5C")]
		private float tapDuration;

		[SerializeField]
		[Token(Token = "0x40011F9")]
		[FieldOffset(Offset = "0x60")]
		private Ease tapEase;

		[Header("Swipe Animation Settings")]
		[SerializeField]
		[Token(Token = "0x40011FA")]
		[FieldOffset(Offset = "0x64")]
		private float swipeDistance;

		[SerializeField]
		[Token(Token = "0x40011FB")]
		[FieldOffset(Offset = "0x68")]
		private float swipeDuration;

		[SerializeField]
		[Token(Token = "0x40011FC")]
		[FieldOffset(Offset = "0x6C")]
		private Ease swipeEase;

		[SerializeField]
		[Token(Token = "0x40011FD")]
		[FieldOffset(Offset = "0x70")]
		private bool swipeToRight;

		[Header("Animation Loop Settings")]
		[SerializeField]
		[Token(Token = "0x40011FE")]
		[FieldOffset(Offset = "0x71")]
		private bool loopAnimation;

		[SerializeField]
		[Token(Token = "0x40011FF")]
		[FieldOffset(Offset = "0x74")]
		private float delayBetweenLoops;

		[Header("Alpha Animation Settings")]
		[SerializeField]
		[Token(Token = "0x4001200")]
		[FieldOffset(Offset = "0x78")]
		private float fadeInDuration;

		[SerializeField]
		[Token(Token = "0x4001201")]
		[FieldOffset(Offset = "0x7C")]
		private float fadeOutDuration;

		[SerializeField]
		[Token(Token = "0x4001202")]
		[FieldOffset(Offset = "0x80")]
		private Ease fadeEase;

		[Token(Token = "0x4001203")]
		[FieldOffset(Offset = "0x88")]
		private Sequence currentSequence;

		[Token(Token = "0x4001204")]
		[FieldOffset(Offset = "0x98")]
		private Tween delayTween;

		[Token(Token = "0x4001205")]
		[FieldOffset(Offset = "0xA8")]
		private Tween alphaTween;

		[Token(Token = "0x4001206")]
		[FieldOffset(Offset = "0xB8")]
		private RectTransform fingerRectTransform;

		[Token(Token = "0x4001207")]
		[FieldOffset(Offset = "0xC0")]
		private Vector2 fingerStartPosition;

		[Token(Token = "0x4001208")]
		[FieldOffset(Offset = "0xC8")]
		private Action _completeAction;

		[Token(Token = "0x4001209")]
		[FieldOffset(Offset = "0xD0")]
		private float _requiredInputRotation;

		[Token(Token = "0x400120A")]
		[FieldOffset(Offset = "0xD4")]
		private float _initialAlpha;

		[Token(Token = "0x400120B")]
		[FieldOffset(Offset = "0xD8")]
		private IInputProvider _inputProvider;

		[Token(Token = "0x400120C")]
		[FieldOffset(Offset = "0xE0")]
		private bool _hasFadedOut;

		[Token(Token = "0x400120D")]
		[FieldOffset(Offset = "0xE1")]
		private bool _isTrackingInput;

		[Token(Token = "0x400120E")]
		[FieldOffset(Offset = "0xE4")]
		private float _accumulatedSwipeDistance;

		[Token(Token = "0x400120F")]
		[FieldOffset(Offset = "0xE8")]
		private bool _isInputActive;

		[Token(Token = "0x4001210")]
		[FieldOffset(Offset = "0xEC")]
		private Vector2 _lastInputPosition;

		[Inject(false)]
		[Token(Token = "0x600163C")]
		[Address(RVA = "0x3D1A1AC", Offset = "0x3D1A1AC", Length = "0xBC")]
		private void Initialize(IInputProvider inputProvider)
		{
			IInputProvider inputProvider2 = default(IInputProvider);
			_inputProvider = inputProvider2;
			RectTransform component = m_fingerImage.GetComponent<RectTransform>();
			fingerRectTransform = component;
			Vector2 anchoredPosition = fingerRectTransform.anchoredPosition;
			fingerStartPosition.x = anchoredPosition.x;
			fingerStartPosition.y = anchoredPosition.y;
			Color color = m_bg.color;
			float initialAlpha = default(float);
			_initialAlpha = initialAlpha;
		}

		[Token(Token = "0x600163D")]
		[Address(RVA = "0x3D1A268", Offset = "0x3D1A268", Length = "0x1EC")]
		public unsafe void PlayTapAndSwipeAnimation(float requiredInputRotation, Action onRequiredInputCompleted)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RotateTutorialUiController::PlayTapAndSwipeAnimation");
		}

		[Token(Token = "0x600163E")]
		[Address(RVA = "0x3D1A454", Offset = "0x3D1A454", Length = "0x3C")]
		public void StopAnimation()
		{
			currentSequence.Stop();
			delayTween.Stop();
			alphaTween.Stop();
		}

		[Token(Token = "0x600163F")]
		[Address(RVA = "0x3D1A490", Offset = "0x3D1A490", Length = "0x2DC")]
		private unsafe void PlayAnimationSequence()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RotateTutorialUiController::PlayAnimationSequence");
		}

		[Token(Token = "0x6001640")]
		[Address(RVA = "0x3D1A76C", Offset = "0x3D1A76C", Length = "0x14")]
		private void Update()
		{
			if (_isTrackingInput)
			{
				TrackUserInput();
			}
		}

		[Token(Token = "0x6001641")]
		[Address(RVA = "0x3D1A780", Offset = "0x3D1A780", Length = "0x36C")]
		private void TrackUserInput()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RotateTutorialUiController::TrackUserInput");
		}

		[Token(Token = "0x6001642")]
		[Address(RVA = "0x3D1AAEC", Offset = "0x3D1AAEC", Length = "0x6C")]
		private void OnRequiredInputCompleted()
		{
			_isTrackingInput = false;
			_isInputActive = false;
			currentSequence.Stop();
			delayTween.Stop();
			alphaTween.Stop();
			if (_completeAction != null)
			{
				_completeAction();
			}
			_completeAction = null;
		}

		[Token(Token = "0x6001643")]
		[Address(RVA = "0x3D1AB58", Offset = "0x3D1AB58", Length = "0x4C")]
		public override void OnDisable()
		{
			base.OnDisable();
			currentSequence.Stop();
			delayTween.Stop();
			alphaTween.Stop();
			_isTrackingInput = false;
		}

		[Token(Token = "0x6001644")]
		[Address(RVA = "0x3D1ABA4", Offset = "0x3D1ABA4", Length = "0x54")]
		public RotateTutorialUiController()
		{
			tapScaleAmount = 1.3f;
			tapDuration = 0.4f;
			tapEase = Ease.OutQuad;
			swipeDistance = 100f;
			swipeDuration = 0.8f;
			swipeEase = Ease.InOutSine;
			swipeToRight = true;
			loopAnimation = true;
			delayBetweenLoops = 1f;
			fadeInDuration = 0.5f;
			fadeOutDuration = 0.3f;
		}
	}
}
