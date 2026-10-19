using System;
using Cpp2ILInjected;
using ElephantSDK;
using Reflex.Attributes;
using Unco.EventBusSystem.Runtime;
using Unco.ResourceSystem;
using _game.CoreGameKit.CoreSerivces.BoosterSystem.Core;

namespace _game.CoreGameKit.Tracking.Trackers
{
	[Serializable]
	[Token(Token = "0x2000587")]
	public class BoosterTrackers : ITracker
	{
		[Inject(false)]
		[Token(Token = "0x400131D")]
		[FieldOffset(Offset = "0x10")]
		private EventBus _eventBus;

		[Inject(false)]
		[Token(Token = "0x400131E")]
		[FieldOffset(Offset = "0x18")]
		private TransactionContextFactory _contextFactory;

		[Token(Token = "0x400131F")]
		[FieldOffset(Offset = "0x20")]
		private TrackingRouter _router;

		[Token(Token = "0x6001756")]
		[Address(RVA = "0x3D2B178", Offset = "0x3D2B178", Length = "0x58")]
		public ITracker GetInstance()
		{
			return new BoosterTrackers();
		}

		[Token(Token = "0x6001757")]
		[Address(RVA = "0x3D2B1D8", Offset = "0x3D2B1D8", Length = "0x8")]
		public void SetRouter(TrackingRouter router)
		{
			_router = router;
		}

		[Token(Token = "0x6001758")]
		[Address(RVA = "0x3D2B1E0", Offset = "0x3D2B1E0", Length = "0x120")]
		public void BeginTracking()
		{
			Action<UventBoosterUsed> observer = OnBoosterUsed;
			_eventBus.ListenEvent(observer);
			Action<UventBoosterPurchased> observer2 = OnBoosterPurchased;
			_eventBus.ListenEvent(observer2);
		}

		[Token(Token = "0x6001759")]
		[Address(RVA = "0x3D2B300", Offset = "0x3D2B300", Length = "0x120")]
		public void EndTracking()
		{
			Action<UventBoosterUsed> observer = OnBoosterUsed;
			_eventBus.RemoveListener(observer);
			Action<UventBoosterPurchased> observer2 = OnBoosterPurchased;
			_eventBus.RemoveListener(observer2);
		}

		[Token(Token = "0x600175A")]
		[Address(RVA = "0x3D2B420", Offset = "0x3D2B420", Length = "0x138")]
		private unsafe void OnBoosterUsed(UventBoosterUsed evt)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BoosterTrackers::OnBoosterUsed");
		}

		[Token(Token = "0x600175B")]
		[Address(RVA = "0x3D2B558", Offset = "0x3D2B558", Length = "0x178")]
		private unsafe void OnBoosterPurchased(UventBoosterPurchased evt)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BoosterTrackers::OnBoosterPurchased");
		}

		[Token(Token = "0x600175C")]
		[Address(RVA = "0x3D2B1D0", Offset = "0x3D2B1D0", Length = "0x8")]
		public BoosterTrackers()
		{
		}
	}
}
