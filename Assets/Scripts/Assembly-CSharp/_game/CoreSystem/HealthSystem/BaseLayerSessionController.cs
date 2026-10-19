using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.EventBusSystem.Runtime;
using Unco.RemoteManagementSystem;
using Unco.ResourceSystem;
using _game.CoreGameKit.BaseLayer.Controller.Runtime.States;
using _game.CoreGameKit.BaseLayer.Installers.Unco.ContainerSystem.Runtime;
using _game.CoreGameKit.CoreSerivces.LevelProgresService.Interface;
using _game.CoreGameKit.Tracking;
using _game.CoreSystem.Events;

namespace _game.CoreSystem.HealthSystem
{
	[Token(Token = "0x20004C4")]
	public class BaseLayerSessionController : IDisposable, IRequireAppFocusCall
	{
		[CompilerGenerated]
		[Token(Token = "0x4000FF7")]
		[FieldOffset(Offset = "0x18")]
		private Action OnSessionStart;

		[Inject(true)]
		[Token(Token = "0x4000FF8")]
		[FieldOffset(Offset = "0x20")]
		private HealthController _healthController;

		[Inject(false)]
		[Token(Token = "0x4000FF9")]
		[FieldOffset(Offset = "0x28")]
		private EventBus _eventBus;

		[Inject(false)]
		[Token(Token = "0x4000FFA")]
		[FieldOffset(Offset = "0x30")]
		private TransactionContextFactory _contextFactory;

		[Inject(false)]
		[Token(Token = "0x4000FFB")]
		[FieldOffset(Offset = "0x38")]
		private TrackingManager _trackingManager;

		[Token(Token = "0x170001B5")]
		[field: Token(Token = "0x4000FF2")]
		[field: FieldOffset(Offset = "0x10")]
		public bool HasStarted
		{
			[Token(Token = "0x6001404")]
			[Address(RVA = "0x3CF1AE4", Offset = "0x3CF1AE4", Length = "0x8")]
			get;
			[Token(Token = "0x6001405")]
			[Address(RVA = "0x3CF1AEC", Offset = "0x3CF1AEC", Length = "0x8")]
			private set;
		}

		[Token(Token = "0x170001B6")]
		[field: Token(Token = "0x4000FF3")]
		[field: FieldOffset(Offset = "0x11")]
		public bool HomeBlocked
		{
			[Token(Token = "0x6001406")]
			[Address(RVA = "0x3CF1AF4", Offset = "0x3CF1AF4", Length = "0x8")]
			get;
			[Token(Token = "0x6001407")]
			[Address(RVA = "0x3CF1AFC", Offset = "0x3CF1AFC", Length = "0x8")]
			private set;
		}

		[Token(Token = "0x170001B7")]
		[field: Token(Token = "0x4000FF4")]
		[field: FieldOffset(Offset = "0x12")]
		public bool WinRewardedBlocked
		{
			[Token(Token = "0x6001408")]
			[Address(RVA = "0x3CF1B04", Offset = "0x3CF1B04", Length = "0x8")]
			get;
			[Token(Token = "0x6001409")]
			[Address(RVA = "0x3CF1B0C", Offset = "0x3CF1B0C", Length = "0x8")]
			private set;
		}

		[Token(Token = "0x170001B8")]
		[field: Token(Token = "0x4000FF5")]
		[field: FieldOffset(Offset = "0x13")]
		public bool RemoveHealthBlocked
		{
			[Token(Token = "0x600140A")]
			[Address(RVA = "0x3CF1B14", Offset = "0x3CF1B14", Length = "0x8")]
			get;
			[Token(Token = "0x600140B")]
			[Address(RVA = "0x3CF1B1C", Offset = "0x3CF1B1C", Length = "0x8")]
			private set;
		}

		[Token(Token = "0x170001B9")]
		[field: Token(Token = "0x4000FF6")]
		[field: FieldOffset(Offset = "0x14")]
		public bool IsWin
		{
			[Token(Token = "0x600140C")]
			[Address(RVA = "0x3CF1B24", Offset = "0x3CF1B24", Length = "0x8")]
			get;
			[Token(Token = "0x600140D")]
			[Address(RVA = "0x3CF1B2C", Offset = "0x3CF1B2C", Length = "0x8")]
			private set;
		}

		[CompilerGenerated]
		[Token(Token = "0x600140E")]
		[Address(RVA = "0x3CF1B34", Offset = "0x3CF1B34", Length = "0xA4")]
		public void add_OnSessionStart(Action value)
		{
			Action action = OnSessionStart;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref OnSessionStart, value2, action2);
			}
			while ((object)action != action2);
		}

		[CompilerGenerated]
		[Token(Token = "0x600140F")]
		[Address(RVA = "0x3CF1BD8", Offset = "0x3CF1BD8", Length = "0xA4")]
		public void remove_OnSessionStart(Action value)
		{
			Action action = OnSessionStart;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref OnSessionStart, value2, action2);
			}
			while ((object)action != action2);
		}

		[Inject(false)]
		[Token(Token = "0x6001410")]
		[Address(RVA = "0x3CF1C7C", Offset = "0x3CF1C7C", Length = "0x42C")]
		private void Construct(RemoteConfigManager remoteConfigManager, ILevelProgressService levelProgressService)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerSessionController::Construct");
		}

		[Token(Token = "0x6001411")]
		[Address(RVA = "0x3CF20C4", Offset = "0x3CF20C4", Length = "0xC")]
		private void OnLevelCompleted(UventLevelCompleted obj)
		{
			IsWin = true;
		}

		[Token(Token = "0x6001412")]
		[Address(RVA = "0x3CF20D0", Offset = "0x3CF20D0", Length = "0x270")]
		public void Dispose()
		{
			Action<USandCubeClicked> observer = OnSandCubeClicked;
			_eventBus.RemoveListener(observer);
			Action<UventLevelRefreshed> observer2 = OnLevelRefreshed;
			_eventBus.RemoveListener(observer2);
			Action<UventLevelLeave> observer3 = OnLevelLeave;
			_eventBus.RemoveListener(observer3);
			Action<UventKeepPlayingGiveUp> observer4 = OnLevelGiveUp;
			_eventBus.RemoveListener(observer4);
			Action<UventLevelCompleted> observer5 = OnLevelCompleted;
			_eventBus.RemoveListener(observer5);
		}

		[Token(Token = "0x6001413")]
		[Address(RVA = "0x3CF2340", Offset = "0x3CF2340", Length = "0x34")]
		private void OnSandCubeClicked(USandCubeClicked obj)
		{
			if (obj.isPourable && !HasStarted)
			{
				HasStarted = true;
				if (OnSessionStart != null)
				{
					OnSessionStart();
				}
			}
		}

		[Token(Token = "0x6001414")]
		[Address(RVA = "0x3CF2374", Offset = "0x3CF2374", Length = "0x68")]
		private void OnLevelLeave(UventLevelLeave obj)
		{
			if (HasStarted && !RemoveHealthBlocked && _healthController != null)
			{
				_healthController.RemoveHealth();
			}
		}

		[Token(Token = "0x6001415")]
		[Address(RVA = "0x3CF2404", Offset = "0x3CF2404", Length = "0x68")]
		private void OnLevelRefreshed(UventLevelRefreshed obj)
		{
			if (HasStarted && !RemoveHealthBlocked && _healthController != null)
			{
				_healthController.RemoveHealth();
			}
		}

		[Token(Token = "0x6001416")]
		[Address(RVA = "0x3CF246C", Offset = "0x3CF246C", Length = "0x68")]
		private void OnLevelGiveUp(UventKeepPlayingGiveUp obj)
		{
			if (HasStarted && !RemoveHealthBlocked && _healthController != null)
			{
				_healthController.RemoveHealth();
			}
		}

		[Token(Token = "0x6001417")]
		[Address(RVA = "0x3CF24D4", Offset = "0x3CF24D4", Length = "0x3C")]
		public void OnFocusChanged(bool focus)
		{
			if (focus || !HasStarted || RemoveHealthBlocked || IsWin)
			{
				if (_healthController != null)
				{
					_healthController.RemovePendingHealth();
				}
			}
			else if (_healthController != null)
			{
				_healthController.AddPendingHealth();
			}
		}

		[Token(Token = "0x6001418")]
		[Address(RVA = "0x3CF23DC", Offset = "0x3CF23DC", Length = "0x28")]
		private void TryRemoveHealth(string sourceType)
		{
			if (HasStarted && !RemoveHealthBlocked && _healthController != null)
			{
				_healthController.RemoveHealth();
			}
		}

		[Token(Token = "0x6001419")]
		[Address(RVA = "0x3CF276C", Offset = "0x3CF276C", Length = "0x8")]
		public BaseLayerSessionController()
		{
		}
	}
}
