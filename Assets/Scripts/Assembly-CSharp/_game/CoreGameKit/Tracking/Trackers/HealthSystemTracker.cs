using System;
using Cpp2ILInjected;
using ElephantSDK;
using Reflex.Attributes;
using Unco.EventBusSystem.Runtime;
using Unco.ResourceSystem;
using _game.CoreGameKit.Ui.UiControllers;
using _game.CoreSystem.HealthSystem;
using _game.Systems.PaymentSystem.Data;

namespace _game.CoreGameKit.Tracking.Trackers
{
	[Serializable]
	[Token(Token = "0x2000588")]
	public class HealthSystemTracker : ITracker
	{
		[Inject(false)]
		[Token(Token = "0x4001320")]
		[FieldOffset(Offset = "0x10")]
		private EventBus _eventBus;

		[Inject(false)]
		[Token(Token = "0x4001321")]
		[FieldOffset(Offset = "0x18")]
		private TransactionContextFactory _contextFactory;

		[Token(Token = "0x4001322")]
		[FieldOffset(Offset = "0x20")]
		private TrackingRouter _router;

		[Token(Token = "0x600175D")]
		[Address(RVA = "0x3D2B6D0", Offset = "0x3D2B6D0", Length = "0x58")]
		public ITracker GetInstance()
		{
			return new HealthSystemTracker();
		}

		[Token(Token = "0x600175E")]
		[Address(RVA = "0x3D2B730", Offset = "0x3D2B730", Length = "0x8")]
		public void SetRouter(TrackingRouter router)
		{
			_router = router;
		}

		[Token(Token = "0x600175F")]
		[Address(RVA = "0x3D2B738", Offset = "0x3D2B738", Length = "0x270")]
		public void BeginTracking()
		{
			Action<UventHealthInfiniteGranted> observer = OnInfiniteGranted;
			_eventBus.ListenEvent(observer);
			Action<UventHealthInfiniteEnded> observer2 = OnInfiniteEnded;
			_eventBus.ListenEvent(observer2);
			Action<UventHeartRefillClicked> observer3 = OnRefillClicked;
			_eventBus.ListenEvent(observer3);
			Action<UventHeartRefillCantAfford> observer4 = OnRefillCantAfford;
			_eventBus.ListenEvent(observer4);
			Action<UventHeartRefillPurchased> observer5 = OnRefillPurchased;
			_eventBus.ListenEvent(observer5);
		}

		[Token(Token = "0x6001760")]
		[Address(RVA = "0x3D2B9A8", Offset = "0x3D2B9A8", Length = "0x270")]
		public void EndTracking()
		{
			Action<UventHealthInfiniteGranted> observer = OnInfiniteGranted;
			_eventBus.RemoveListener(observer);
			Action<UventHealthInfiniteEnded> observer2 = OnInfiniteEnded;
			_eventBus.RemoveListener(observer2);
			Action<UventHeartRefillClicked> observer3 = OnRefillClicked;
			_eventBus.RemoveListener(observer3);
			Action<UventHeartRefillCantAfford> observer4 = OnRefillCantAfford;
			_eventBus.RemoveListener(observer4);
			Action<UventHeartRefillPurchased> observer5 = OnRefillPurchased;
			_eventBus.RemoveListener(observer5);
		}

		[Token(Token = "0x6001761")]
		[Address(RVA = "0x3D2BC18", Offset = "0x3D2BC18", Length = "0xB8")]
		private void OnHealthChanged(UventHealthChanged obj)
		{
			Params obj2 = Params.New();
			Params obj3 = obj2.Set("previous_health", obj.PreviousHealth);
			Params obj4 = obj2.Set("new_health", obj.NewHealth);
			_router.Event(TrackingKey.health_changed, obj2);
		}

		[Token(Token = "0x6001762")]
		[Address(RVA = "0x3D2BCD0", Offset = "0x3D2BCD0", Length = "0xB8")]
		private void OnInfiniteGranted(UventHealthInfiniteGranted obj)
		{
			Params obj2 = Params.New();
			Params obj3 = obj2.Set("previous_duration", obj.PreviousDuration);
			Params obj4 = obj2.Set("added_duration", obj.AddedDuration);
			_router.Event(TrackingKey.health_infinite_changed, obj2);
		}

		[Token(Token = "0x6001763")]
		[Address(RVA = "0x3D2BD88", Offset = "0x3D2BD88", Length = "0x38")]
		private void OnInfiniteEnded(UventHealthInfiniteEnded obj)
		{
			Params parameters = Params.New();
			_router.Event(TrackingKey.health_infinite_changed, parameters);
		}

		[Token(Token = "0x6001764")]
		[Address(RVA = "0x3D2BDC0", Offset = "0x3D2BDC0", Length = "0x20")]
		private void OnRefillClicked(UventHeartRefillClicked obj)
		{
			_router.Event(TrackingKey.heartrefill_clicked);
		}

		[Token(Token = "0x6001765")]
		[Address(RVA = "0x3D2BDE0", Offset = "0x3D2BDE0", Length = "0x20")]
		private void OnRefillCantAfford(UventHeartRefillCantAfford obj)
		{
			_router.Event(TrackingKey.heartrefill_cantafford);
		}

		[Token(Token = "0x6001766")]
		[Address(RVA = "0x3D2BE00", Offset = "0x3D2BE00", Length = "0x14C")]
		private void OnRefillPurchased(UventHeartRefillPurchased obj)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HealthSystemTracker::OnRefillPurchased");
		}

		[Token(Token = "0x6001767")]
		[Address(RVA = "0x3D2B728", Offset = "0x3D2B728", Length = "0x8")]
		public HealthSystemTracker()
		{
		}
	}
}
