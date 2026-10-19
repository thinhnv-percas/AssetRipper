using System;
using Systems.ResourceSystem.IAPSystem.Scripts.Data;
using Cpp2ILInjected;
using ElephantSDK;
using Reflex.Attributes;
using Sirenix.Utilities;
using Unco.EventBusSystem.Runtime;
using _game.CoreGameKit.Tracking.Events;
using _game.Systems.PaymentSystem.Data;
using _game.Systems.ShopSystem.Scripts.Core;

namespace _game.CoreGameKit.Tracking.Trackers
{
	[Serializable]
	[Token(Token = "0x200058A")]
	public class ShopTracker : ITracker
	{
		[Inject(false)]
		[Token(Token = "0x4001325")]
		[FieldOffset(Offset = "0x10")]
		private EventBus _eventBus;

		[Inject(false)]
		[Token(Token = "0x4001326")]
		[FieldOffset(Offset = "0x18")]
		private IAPStoreService _iapStoreService;

		[Token(Token = "0x4001327")]
		[FieldOffset(Offset = "0x20")]
		private TrackingRouter _router;

		[Token(Token = "0x600176E")]
		[Address(RVA = "0x3D2C1AC", Offset = "0x3D2C1AC", Length = "0x58")]
		public ITracker GetInstance()
		{
			return new ShopTracker();
		}

		[Token(Token = "0x600176F")]
		[Address(RVA = "0x3D2C20C", Offset = "0x3D2C20C", Length = "0x8")]
		public void SetRouter(TrackingRouter router)
		{
			_router = router;
		}

		[Token(Token = "0x6001770")]
		[Address(RVA = "0x3D2C214", Offset = "0x3D2C214", Length = "0x430")]
		public void BeginTracking()
		{
			Action<UventPurchaseSucceed> observer = OnPurchaseSucceed;
			_eventBus.ListenEvent(observer);
			Action<UventPurchaseFailed> observer2 = OnPurchaseFailed;
			_eventBus.ListenEvent(observer2);
			Action<UventPurchaseStarted> observer3 = OnPurchaseStarted;
			_eventBus.ListenEvent(observer3);
			Action<UventIAPStoreIsNotInitiazlied> observer4 = OnStoreNotInitialized;
			_eventBus.ListenEvent(observer4);
			Action<UventIAPStoreProductNotFound> observer5 = OnProductNotFound;
			_eventBus.ListenEvent(observer5);
			Action<UventShopOpened> observer6 = OnShopOpened;
			_eventBus.ListenEvent(observer6);
			Action<UventOfferShown> observer7 = OnOfferShown;
			_eventBus.ListenEvent(observer7);
			Action<UventOfferAccepted> observer8 = OnOfferAccepted;
			_eventBus.ListenEvent(observer8);
			Action<UventOfferRejected> observer9 = OnOfferRejected;
			_eventBus.ListenEvent(observer9);
		}

		[Token(Token = "0x6001771")]
		[Address(RVA = "0x3D2C644", Offset = "0x3D2C644", Length = "0x430")]
		public void EndTracking()
		{
			Action<UventPurchaseSucceed> observer = OnPurchaseSucceed;
			_eventBus.RemoveListener(observer);
			Action<UventPurchaseFailed> observer2 = OnPurchaseFailed;
			_eventBus.RemoveListener(observer2);
			Action<UventPurchaseStarted> observer3 = OnPurchaseStarted;
			_eventBus.RemoveListener(observer3);
			Action<UventIAPStoreIsNotInitiazlied> observer4 = OnStoreNotInitialized;
			_eventBus.RemoveListener(observer4);
			Action<UventIAPStoreProductNotFound> observer5 = OnProductNotFound;
			_eventBus.RemoveListener(observer5);
			Action<UventShopOpened> observer6 = OnShopOpened;
			_eventBus.RemoveListener(observer6);
			Action<UventOfferShown> observer7 = OnOfferShown;
			_eventBus.RemoveListener(observer7);
			Action<UventOfferAccepted> observer8 = OnOfferAccepted;
			_eventBus.RemoveListener(observer8);
			Action<UventOfferRejected> observer9 = OnOfferRejected;
			_eventBus.RemoveListener(observer9);
		}

		[Token(Token = "0x6001772")]
		[Address(RVA = "0x3D2CA74", Offset = "0x3D2CA74", Length = "0x158")]
		private void OnPurchaseSucceed(UventPurchaseSucceed evt)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ShopTracker::OnPurchaseSucceed");
		}

		[Token(Token = "0x6001773")]
		[Address(RVA = "0x3D2CBCC", Offset = "0x3D2CBCC", Length = "0x124")]
		private void OnPurchaseFailed(UventPurchaseFailed evt)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ShopTracker::OnPurchaseFailed");
		}

		[Token(Token = "0x6001774")]
		[Address(RVA = "0x3D2CCF0", Offset = "0x3D2CCF0", Length = "0xEC")]
		private void OnPurchaseStarted(UventPurchaseStarted evt)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ShopTracker::OnPurchaseStarted");
		}

		[Token(Token = "0x6001775")]
		[Address(RVA = "0x3D2CDDC", Offset = "0x3D2CDDC", Length = "0x20")]
		private void OnStoreNotInitialized(UventIAPStoreIsNotInitiazlied evt)
		{
			_router.Event(TrackingKey.iap_store_not_initialized);
		}

		[Token(Token = "0x6001776")]
		[Address(RVA = "0x3D2CDFC", Offset = "0x3D2CDFC", Length = "0xB8")]
		private void OnProductNotFound(UventIAPStoreProductNotFound evt)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ShopTracker::OnProductNotFound");
		}

		[Token(Token = "0x6001777")]
		[Address(RVA = "0x3D2CEB4", Offset = "0x3D2CEB4", Length = "0xB4")]
		private void OnShopOpened(UventShopOpened evt)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ShopTracker::OnShopOpened");
		}

		[Token(Token = "0x6001778")]
		[Address(RVA = "0x3D2CF68", Offset = "0x3D2CF68", Length = "0x84")]
		private void OnOfferShown(UventOfferShown evt)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ShopTracker::OnOfferShown");
		}

		[Token(Token = "0x6001779")]
		[Address(RVA = "0x3D2CFEC", Offset = "0x3D2CFEC", Length = "0x84")]
		private void OnOfferAccepted(UventOfferAccepted evt)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ShopTracker::OnOfferAccepted");
		}

		[Token(Token = "0x600177A")]
		[Address(RVA = "0x3D2D070", Offset = "0x3D2D070", Length = "0x84")]
		private void OnOfferRejected(UventOfferRejected evt)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ShopTracker::OnOfferRejected");
		}

		[Token(Token = "0x600177B")]
		[Address(RVA = "0x3D2C204", Offset = "0x3D2C204", Length = "0x8")]
		public ShopTracker()
		{
		}
	}
}
