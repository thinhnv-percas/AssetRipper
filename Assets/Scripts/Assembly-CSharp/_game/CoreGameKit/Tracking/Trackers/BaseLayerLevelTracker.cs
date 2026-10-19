using System;
using Cpp2ILInjected;
using ElephantSDK;
using Reflex.Attributes;
using Unco.EventBusSystem.Runtime;
using Unco.ResourceSystem;
using _game.CoreGameKit.BaseLayer.Controller.Runtime.States;
using _game.CoreGameKit.BaseLayer.LevelSystem;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;
using _game.CoreSystem.HealthSystem;

namespace _game.CoreGameKit.Tracking.Trackers
{
	[Serializable]
	[Token(Token = "0x2000586")]
	public class BaseLayerLevelTracker : ITracker
	{
		[Token(Token = "0x4001317")]
		[FieldOffset(Offset = "0x10")]
		private TrackingRouter _router;

		[Inject(false)]
		[Token(Token = "0x4001318")]
		[FieldOffset(Offset = "0x18")]
		private EventBus _eventBus;

		[Inject(false)]
		[Token(Token = "0x4001319")]
		[FieldOffset(Offset = "0x20")]
		private HealthController _healthController;

		[Inject(false)]
		[Token(Token = "0x400131A")]
		[FieldOffset(Offset = "0x28")]
		private ILevel _currentLevel;

		[Inject(false)]
		[Token(Token = "0x400131B")]
		[FieldOffset(Offset = "0x30")]
		private LevelContext _levelContext;

		[Inject(false)]
		[Token(Token = "0x400131C")]
		[FieldOffset(Offset = "0x38")]
		private IResourceService _resourceService;

		[Token(Token = "0x6001748")]
		[Address(RVA = "0x3D2A2AC", Offset = "0x3D2A2AC", Length = "0x58")]
		public ITracker GetInstance()
		{
			return new BaseLayerLevelTracker();
		}

		[Token(Token = "0x6001749")]
		[Address(RVA = "0x3D2A30C", Offset = "0x3D2A30C", Length = "0x8")]
		public void SetRouter(TrackingRouter router)
		{
			_router = router;
		}

		[Token(Token = "0x600174A")]
		[Address(RVA = "0x3D2A314", Offset = "0x3D2A314", Length = "0x430")]
		public void BeginTracking()
		{
			Action<UventLevelCompleted> observer = OnLevelCompleted;
			_eventBus.ListenEvent(observer);
			Action<UventLevelFailed> observer2 = OnLevelFailed;
			_eventBus.ListenEvent(observer2);
			Action<UventLevelRefreshed> observer3 = OnLevelRefreshed;
			_eventBus.ListenEvent(observer3);
			Action<UventLevelLeave> observer4 = OnLevelLeave;
			_eventBus.ListenEvent(observer4);
			Action<UventKeepPlayingClicked> observer5 = OnKeepPlayingClicked;
			_eventBus.ListenEvent(observer5);
			Action<UventKeepPlayingPurchased> observer6 = OnKeepPlayingPurchased;
			_eventBus.ListenEvent(observer6);
			Action<UventKeepPlayingCantAfford> observer7 = OnKeepPlayingCantAfford;
			_eventBus.ListenEvent(observer7);
			Action<UventKeepPlayingGiveUp> observer8 = OnKeepPlayingGiveUp;
			_eventBus.ListenEvent(observer8);
			Action<UventLevelStarted> observer9 = OnChapterStarted;
			_eventBus.ListenEvent(observer9);
		}

		[Token(Token = "0x600174B")]
		[Address(RVA = "0x3D2A744", Offset = "0x3D2A744", Length = "0x430")]
		public void EndTracking()
		{
			Action<UventLevelCompleted> observer = OnLevelCompleted;
			_eventBus.RemoveListener(observer);
			Action<UventLevelFailed> observer2 = OnLevelFailed;
			_eventBus.RemoveListener(observer2);
			Action<UventLevelRefreshed> observer3 = OnLevelRefreshed;
			_eventBus.RemoveListener(observer3);
			Action<UventLevelLeave> observer4 = OnLevelLeave;
			_eventBus.RemoveListener(observer4);
			Action<UventKeepPlayingClicked> observer5 = OnKeepPlayingClicked;
			_eventBus.RemoveListener(observer5);
			Action<UventKeepPlayingPurchased> observer6 = OnKeepPlayingPurchased;
			_eventBus.RemoveListener(observer6);
			Action<UventKeepPlayingCantAfford> observer7 = OnKeepPlayingCantAfford;
			_eventBus.RemoveListener(observer7);
			Action<UventKeepPlayingGiveUp> observer8 = OnKeepPlayingGiveUp;
			_eventBus.RemoveListener(observer8);
			Action<UventLevelStarted> observer9 = OnChapterStarted;
			_eventBus.RemoveListener(observer9);
		}

		[Token(Token = "0x600174C")]
		[Address(RVA = "0x3D2AB74", Offset = "0x3D2AB74", Length = "0xE4")]
		private void OnLevelCompleted(UventLevelCompleted evt)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerLevelTracker::OnLevelCompleted");
		}

		[Token(Token = "0x600174D")]
		[Address(RVA = "0x3D2AC58", Offset = "0x3D2AC58", Length = "0x114")]
		private void OnLevelFailed(UventLevelFailed evt)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerLevelTracker::OnLevelFailed");
		}

		[Token(Token = "0x600174E")]
		[Address(RVA = "0x3D2AD6C", Offset = "0x3D2AD6C", Length = "0x38")]
		private void OnLevelRefreshed(UventLevelRefreshed obj)
		{
			Params parameters = Params.New();
			_router.Event(TrackingKey.level_refresh, parameters);
		}

		[Token(Token = "0x600174F")]
		[Address(RVA = "0x3D2ADA4", Offset = "0x3D2ADA4", Length = "0x38")]
		private void OnLevelLeave(UventLevelLeave obj)
		{
			Params parameters = Params.New();
			_router.Event(TrackingKey.level_leave, parameters);
		}

		[Token(Token = "0x6001750")]
		[Address(RVA = "0x3D2ADDC", Offset = "0x3D2ADDC", Length = "0x38")]
		private void OnKeepPlayingClicked(UventKeepPlayingClicked obj)
		{
			Params parameters = Params.New();
			_router.Event(TrackingKey.keep_playing_clicked, parameters);
		}

		[Token(Token = "0x6001751")]
		[Address(RVA = "0x3D2AE14", Offset = "0x3D2AE14", Length = "0xE4")]
		private void OnKeepPlayingPurchased(UventKeepPlayingPurchased obj)
		{
			Params obj2 = Params.New();
			Params obj3 = obj2.Set("attempt_number", obj.AttemptNumber);
			Params obj4 = obj2.Set("from_ego_offer", obj.IsEgoOffer ? 1 : 0);
			if (!obj.IsEgoOffer)
			{
				Params obj5 = obj2.Set("cost_paid", obj.CostPaid);
			}
			_router.Event(TrackingKey.keep_playing_purchased, obj2);
		}

		[Token(Token = "0x6001752")]
		[Address(RVA = "0x3D2AEF8", Offset = "0x3D2AEF8", Length = "0x38")]
		private void OnKeepPlayingCantAfford(UventKeepPlayingCantAfford obj)
		{
			Params parameters = Params.New();
			_router.Event(TrackingKey.keep_playing_cantafford, parameters);
		}

		[Token(Token = "0x6001753")]
		[Address(RVA = "0x3D2AF30", Offset = "0x3D2AF30", Length = "0x90")]
		private void OnKeepPlayingGiveUp(UventKeepPlayingGiveUp obj)
		{
			Params parameters = Params.New();
			_router.Event(TrackingKey.keep_playing_giveup, parameters);
			Params obj2 = Params.New();
			Params obj3 = obj2.Set("type", "keep_playing");
		}

		[Token(Token = "0x6001754")]
		[Address(RVA = "0x3D2AFC0", Offset = "0x3D2AFC0", Length = "0x1B8")]
		private void OnChapterStarted(UventLevelStarted evt)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerLevelTracker::OnChapterStarted");
		}

		[Token(Token = "0x6001755")]
		[Address(RVA = "0x3D2A304", Offset = "0x3D2A304", Length = "0x8")]
		public BaseLayerLevelTracker()
		{
		}
	}
}
