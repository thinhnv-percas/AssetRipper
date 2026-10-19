using System;
using Systems.ShopSystem.Scripts.Ui.ShopGroups;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.AdSystem;
using Unco.EventBusSystem.Runtime;
using Unco.UncoButtonSystem;
using UnityEngine;
using _game.CoreGameKit.Tracking.Events;
using _game.CoreGameKit.UiControllers;

namespace _game.Systems.Offers
{
	[Token(Token = "0x2000761")]
	public class NoAdsOfferUiController : UIController
	{
		[SerializeField]
		[Token(Token = "0x40018A8")]
		[FieldOffset(Offset = "0x48")]
		private UncoButton m_noThxButton;

		[Token(Token = "0x40018A9")]
		[FieldOffset(Offset = "0x50")]
		private Action _onPurchase;

		[Token(Token = "0x40018AA")]
		[FieldOffset(Offset = "0x58")]
		private Action _onClose;

		[Token(Token = "0x40018AB")]
		[FieldOffset(Offset = "0x60")]
		private bool _isOffer;

		[Inject(false)]
		[Token(Token = "0x40018AC")]
		[FieldOffset(Offset = "0x68")]
		private EventBus _eventBus;

		[Inject(false)]
		[Token(Token = "0x40018AD")]
		[FieldOffset(Offset = "0x70")]
		private IAdManager _adManager;

		[Token(Token = "0x40018AE")]
		[FieldOffset(Offset = "0x78")]
		private string _offerType;

		[Token(Token = "0x40018AF")]
		[FieldOffset(Offset = "0x80")]
		private ShopGroupView[] _shopViews;

		[Token(Token = "0x6001F20")]
		[Address(RVA = "0x3D8BE20", Offset = "0x3D8BE20", Length = "0x358")]
		public void Initialize(bool isOffer, Action onPurchase = null, Action onClose = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("NoAdsOfferUiController::Initialize");
		}

		[Token(Token = "0x6001F21")]
		[Address(RVA = "0x3D8CC1C", Offset = "0x3D8CC1C", Length = "0x78")]
		private void OnTapped()
		{
			UventOfferAccepted args = default(UventOfferAccepted);
			_eventBus.InvokeEvent(args);
		}

		[Token(Token = "0x6001F22")]
		[Address(RVA = "0x3D8CC94", Offset = "0x3D8CC94", Length = "0x14")]
		private void OnNoAdsStatusUpdated(bool obj)
		{
			if (obj)
			{
				Hide();
			}
		}

		[Token(Token = "0x6001F23")]
		[Address(RVA = "0x3D8CCA8", Offset = "0x3D8CCA8", Length = "0x1CC")]
		public override void Hide()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("NoAdsOfferUiController::Hide");
		}

		[Token(Token = "0x6001F24")]
		[Address(RVA = "0x3D8CE74", Offset = "0x3D8CE74", Length = "0x8")]
		public NoAdsOfferUiController()
		{
		}
	}
}
