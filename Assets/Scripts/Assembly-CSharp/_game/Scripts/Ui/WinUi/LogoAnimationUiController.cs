using System;
using Cpp2ILInjected;
using PrimeTween;
using Reflex.Attributes;
using Spine;
using Spine.Unity;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.Installers;
using _game.CoreGameKit.UiControllers;

namespace _game.Scripts.Ui.WinUi
{
	[Token(Token = "0x2000706")]
	public class LogoAnimationUiController : UIController, IHasCompletion
	{
		[SerializeField]
		[Token(Token = "0x400178D")]
		[FieldOffset(Offset = "0x48")]
		private SkeletonGraphic m_skeletonAnimation;

		[SerializeField]
		[Token(Token = "0x400178E")]
		[FieldOffset(Offset = "0x50")]
		private float m_delay;

		[Token(Token = "0x170002E2")]
		[field: Token(Token = "0x400178F")]
		[field: FieldOffset(Offset = "0x58")]
		public Action OnCompleted
		{
			[Token(Token = "0x6001DA8")]
			[Address(RVA = "0x3D7BA34", Offset = "0x3D7BA34", Length = "0x8")]
			get;
			[Token(Token = "0x6001DA9")]
			[Address(RVA = "0x3D7BA3C", Offset = "0x3D7BA3C", Length = "0x8")]
			set;
		}

		[Token(Token = "0x170002E3")]
		[field: Token(Token = "0x4001790")]
		[field: FieldOffset(Offset = "0x60")]
		public Action OnFailed
		{
			[Token(Token = "0x6001DAA")]
			[Address(RVA = "0x3D7BA44", Offset = "0x3D7BA44", Length = "0x8")]
			get;
			[Token(Token = "0x6001DAB")]
			[Address(RVA = "0x3D7BA4C", Offset = "0x3D7BA4C", Length = "0x8")]
			set;
		}

		[Inject(false)]
		[Token(Token = "0x6001DA4")]
		[Address(RVA = "0x3D7B83C", Offset = "0x3D7B83C", Length = "0xA4")]
		private void Inject()
		{
			Spine.AnimationState animationState = m_skeletonAnimation.AnimationState;
			Spine.AnimationState.TrackEntryDelegate value = OnComplete;
			animationState.add_Complete(value);
		}

		[Token(Token = "0x6001DA5")]
		[Address(RVA = "0x3D7B8E0", Offset = "0x3D7B8E0", Length = "0x8")]
		public void Initialize(Action onComplete)
		{
			OnCompleted = onComplete;
		}

		[Token(Token = "0x6001DA6")]
		[Address(RVA = "0x3D7B8E8", Offset = "0x3D7B8E8", Length = "0xB0")]
		public override void Hide()
		{
			base.Hide();
			Spine.AnimationState animationState = m_skeletonAnimation.AnimationState;
			Spine.AnimationState.TrackEntryDelegate value = OnComplete;
			animationState.remove_Complete(value);
		}

		[Token(Token = "0x6001DA7")]
		[Address(RVA = "0x3D7B998", Offset = "0x3D7B998", Length = "0x9C")]
		private void OnComplete(TrackEntry trackentry)
		{
			Action onComplete = delegate
			{
				if (OnCompleted != null)
				{
					OnCompleted();
				}
				LogoAnimationUiController logoAnimationUiController = default(LogoAnimationUiController);
				logoAnimationUiController.Hide();
			};
			Tween tween = Tween.Delay(m_delay, onComplete, useUnscaledTime: true);
		}

		[Token(Token = "0x6001DAC")]
		[Address(RVA = "0x3D7BA54", Offset = "0x3D7BA54", Length = "0x8")]
		public LogoAnimationUiController()
		{
		}
	}
}
