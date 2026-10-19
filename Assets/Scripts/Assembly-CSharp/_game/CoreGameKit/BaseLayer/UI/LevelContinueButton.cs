using System;
using Cpp2ILInjected;
using PrimeTween;
using Reflex.Attributes;
using Unco.ResourceSystem;
using Unco.RewardSystem;
using Unco.UncoButtonSystem;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.LevelSystem;
using _game.CoreGameKit.BaseLayer.Services.Interface;
using _game.CoreGameKit.Ui.Animations;
using _game.Systems.MonetizationCore;

namespace _game.CoreGameKit.BaseLayer.UI
{
	[Token(Token = "0x200063C")]
	public class LevelContinueButton : ServiceButtonComponent
	{
		[SerializeField]
		[Token(Token = "0x400157C")]
		[FieldOffset(Offset = "0x20")]
		private UncoButton m_continueButton;

		[Inject(false)]
		[Token(Token = "0x400157D")]
		[FieldOffset(Offset = "0x28")]
		private InterstitialAdService _interstitialAdService;

		[Inject(false)]
		[Token(Token = "0x400157E")]
		[FieldOffset(Offset = "0x30")]
		private IBaseLayerCompleteService _completeService;

		[Inject(false)]
		[Token(Token = "0x400157F")]
		[FieldOffset(Offset = "0x38")]
		private CurrencyAnimationController _currencyAnimationController;

		[Inject(false)]
		[Token(Token = "0x4001580")]
		[FieldOffset(Offset = "0x40")]
		private IResourceService _resourceService;

		[Token(Token = "0x4001581")]
		[FieldOffset(Offset = "0x48")]
		private LootDrop _reward;

		[Inject(false)]
		[Token(Token = "0x6001A9E")]
		[Address(RVA = "0x3D55858", Offset = "0x3D55858", Length = "0x120")]
		private void Construct(LevelContext levelContext)
		{
			_reward.Amount = levelContext.Reward.Amount;
			_reward = levelContext.Reward;
			if (m_continueButton != null)
			{
				Action clickAction = base.InvokeClick;
				m_continueButton.AddListener(clickAction);
			}
		}

		[Token(Token = "0x6001A9F")]
		[Address(RVA = "0x3D55978", Offset = "0x3D55978", Length = "0x184")]
		protected override void OnInvoke()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelContinueButton::OnInvoke");
		}

		[Token(Token = "0x6001AA0")]
		[Address(RVA = "0x3D55B04", Offset = "0x3D55B04", Length = "0x8")]
		public LevelContinueButton()
		{
		}
	}
}
