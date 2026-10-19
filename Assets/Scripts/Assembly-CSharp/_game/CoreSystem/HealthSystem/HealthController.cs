using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.EventBusSystem.Runtime;
using Unco.RealTimeSystem.Runtime;
using Unco.RemoteManagementSystem;
using Unco.RewardSystem;
using Unco.TimeTaskSystem.Runtime;
using _game.CoreGameKit.CoreSerivces.LevelProgresService.Interface;
using _game.Systems.ElephantStorage;
using _game.Systems.PaymentSystem.PurchaseHandlers;

namespace _game.CoreSystem.HealthSystem
{
	[Token(Token = "0x20004C7")]
	public class HealthController : IDisposable
	{
		[Token(Token = "0x4001001")]
		private const string REGEN_TIMER_KEY = "health-regeneration";

		[Token(Token = "0x4001002")]
		private const string INFINITE_TIMER_KEY = "health-infinite";

		[Inject(false)]
		[Token(Token = "0x4001003")]
		[FieldOffset(Offset = "0x10")]
		internal RealTimeTaskController _realTimeTaskController;

		[Inject(false)]
		[Token(Token = "0x4001004")]
		[FieldOffset(Offset = "0x18")]
		private ILevelProgressService _levelProgressService;

		[Inject(false)]
		[Token(Token = "0x4001005")]
		[FieldOffset(Offset = "0x20")]
		private EventBus _eventBus;

		[Inject(false)]
		[Token(Token = "0x4001006")]
		[FieldOffset(Offset = "0x28")]
		private HealthPurchaseHandler _healthPurchaseHandler;

		[Inject(false)]
		[Token(Token = "0x4001007")]
		[FieldOffset(Offset = "0x30")]
		internal HealthStorageData _healthData;

		[Inject(false)]
		[Token(Token = "0x4001008")]
		[FieldOffset(Offset = "0x38")]
		private IPlayerDataHandler _dataHandler;

		[Token(Token = "0x4001009")]
		[FieldOffset(Offset = "0x40")]
		internal HealthConfig _config;

		[Token(Token = "0x400100A")]
		[FieldOffset(Offset = "0x48")]
		private RealTimerHandle _regenHandle;

		[Token(Token = "0x400100B")]
		[FieldOffset(Offset = "0x58")]
		private RealTimerHandle _infiniteHandle;

		[Token(Token = "0x400100C")]
		[FieldOffset(Offset = "0x68")]
		private HealthState _currentState;

		[CompilerGenerated]
		[Token(Token = "0x400100D")]
		[FieldOffset(Offset = "0x70")]
		internal Action<int> OnHealthChanged;

		[CompilerGenerated]
		[Token(Token = "0x400100E")]
		[FieldOffset(Offset = "0x78")]
		internal Action<HealthState> OnHealthStateChanged;

		[Token(Token = "0x170001BB")]
		public int CurrentHealth
		{
			[Token(Token = "0x600141C")]
			[Address(RVA = "0x3CF2784", Offset = "0x3CF2784", Length = "0x1C")]
			get
			{
				HealthStorageData healthData = _healthData;
				return healthData.CurrentHealth;
			}
		}

		[Token(Token = "0x170001BC")]
		public int MaxHealth
		{
			[Token(Token = "0x600141D")]
			[Address(RVA = "0x3CF27A0", Offset = "0x3CF27A0", Length = "0x1C")]
			get
			{
				HealthConfig config = _config;
				return config.MaxHealth;
			}
		}

		[Token(Token = "0x170001BD")]
		public bool IsFull
		{
			[Token(Token = "0x600141E")]
			[Address(RVA = "0x3CF27BC", Offset = "0x3CF27BC", Length = "0x34")]
			get
			{
				HealthStorageData healthData = _healthData;
				HealthConfig config = _config;
				int num = healthData.CurrentHealth - config.MaxHealth;
				bool flag = num < 0;
				int num2 = healthData.CurrentHealth ^ config.MaxHealth;
				int num3 = healthData.CurrentHealth ^ num;
				int num4 = num2 & num3;
				bool flag2 = num4 < 0;
				return flag == flag2;
			}
		}

		[Token(Token = "0x170001BE")]
		public bool IsInfinite
		{
			[Token(Token = "0x600141F")]
			[Address(RVA = "0x3CF27F0", Offset = "0x3CF27F0", Length = "0x24")]
			get
			{
				HealthStorageData healthData = _healthData;
				bool flag = healthData.InfiniteDuration < 0f;
				bool flag2 = healthData.InfiniteDuration == 0f;
				bool flag3 = healthData.InfiniteDuration == healthData.InfiniteDuration;
				bool flag4 = !flag3;
				bool flag5 = flag == flag4;
				bool flag6 = !flag2;
				return flag5 && flag6;
			}
		}

		[Token(Token = "0x170001BF")]
		public HealthState State
		{
			[Token(Token = "0x6001420")]
			[Address(RVA = "0x3CF2814", Offset = "0x3CF2814", Length = "0x8")]
			get
			{
				return _currentState;
			}
		}

		[Token(Token = "0x170001C0")]
		public int DisableHealthUntilLevel
		{
			[Token(Token = "0x6001421")]
			[Address(RVA = "0x3CF20A8", Offset = "0x3CF20A8", Length = "0x1C")]
			get
			{
				HealthConfig config = _config;
				return config.DisableHealthUntilLevel;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x6001422")]
		[Address(RVA = "0x3CF281C", Offset = "0x3CF281C", Length = "0xB4")]
		public void add_OnHealthChanged(Action<int> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HealthController::add_OnHealthChanged");
		}

		[CompilerGenerated]
		[Token(Token = "0x6001423")]
		[Address(RVA = "0x3CF28D0", Offset = "0x3CF28D0", Length = "0xB4")]
		public void remove_OnHealthChanged(Action<int> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HealthController::remove_OnHealthChanged");
		}

		[CompilerGenerated]
		[Token(Token = "0x6001424")]
		[Address(RVA = "0x3CF2984", Offset = "0x3CF2984", Length = "0xB4")]
		public void add_OnHealthStateChanged(Action<HealthState> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HealthController::add_OnHealthStateChanged");
		}

		[CompilerGenerated]
		[Token(Token = "0x6001425")]
		[Address(RVA = "0x3CF2A38", Offset = "0x3CF2A38", Length = "0xB4")]
		public void remove_OnHealthStateChanged(Action<HealthState> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HealthController::remove_OnHealthStateChanged");
		}

		[Inject(false)]
		[Token(Token = "0x6001426")]
		[Address(RVA = "0x3CF2AEC", Offset = "0x3CF2AEC", Length = "0x1CC")]
		private void Construct(RemoteConfigManager remoteConfigManager)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HealthController::Construct");
		}

		[Token(Token = "0x6001427")]
		[Address(RVA = "0x3CF2E30", Offset = "0x3CF2E30", Length = "0x148")]
		private void ResolveOfflineTimers()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HealthController::ResolveOfflineTimers");
		}

		[Token(Token = "0x6001428")]
		[Address(RVA = "0x3CF2CB8", Offset = "0x3CF2CB8", Length = "0x178")]
		private void ResolvePendingHealth()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HealthController::ResolvePendingHealth");
		}

		[Token(Token = "0x6001429")]
		[Address(RVA = "0x3CF3428", Offset = "0x3CF3428", Length = "0xAC")]
		public void Dispose()
		{
			if (_realTimeTaskController.IsActive("health-regeneration"))
			{
				_regenHandle.Detach();
			}
			if (_realTimeTaskController.IsActive("health-infinite"))
			{
				_infiniteHandle.Detach();
			}
		}

		[Token(Token = "0x600142A")]
		[Address(RVA = "0x3CF34D4", Offset = "0x3CF34D4", Length = "0x60")]
		public void AddHealth(int amount)
		{
			if (amount >= 1)
			{
				HealthStorageData healthData = _healthData;
				HealthConfig config = _config;
				int num = healthData.CurrentHealth + amount;
				int num2 = num - config.MaxHealth;
				bool flag = num2 < 0;
				int num3 = num ^ config.MaxHealth;
				int num4 = num ^ num2;
				int num5 = num3 & num4;
				bool flag2 = num5 < 0;
				int health = ((flag == flag2) ? config.MaxHealth : num);
				SetHealth(health);
				EvaluateState();
			}
		}

		[Token(Token = "0x600142B")]
		[Address(RVA = "0x3CF26C0", Offset = "0x3CF26C0", Length = "0xAC")]
		public void RemoveHealth(int amount = 1)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HealthController::RemoveHealth");
		}

		[Token(Token = "0x600142C")]
		[Address(RVA = "0x3CF2510", Offset = "0x3CF2510", Length = "0xEC")]
		public void AddPendingHealth()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HealthController::AddPendingHealth");
		}

		[Token(Token = "0x600142D")]
		[Address(RVA = "0x3CF25FC", Offset = "0x3CF25FC", Length = "0xC4")]
		public void RemovePendingHealth()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HealthController::RemovePendingHealth");
		}

		[Token(Token = "0x600142E")]
		[Address(RVA = "0x3CF3180", Offset = "0x3CF3180", Length = "0x1B0")]
		public void GrantInfiniteHealth(float duration)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HealthController::GrantInfiniteHealth");
		}

		[Token(Token = "0x600142F")]
		[Address(RVA = "0x3CF37A0", Offset = "0x3CF37A0", Length = "0xC")]
		public float GetRegenRemainingTime()
		{
			return _regenHandle.GetRemainingTime();
		}

		[Token(Token = "0x6001430")]
		[Address(RVA = "0x3CF37AC", Offset = "0x3CF37AC", Length = "0xC")]
		public float GetRegenProgress()
		{
			return _regenHandle.GetProgress();
		}

		[Token(Token = "0x6001431")]
		[Address(RVA = "0x3CF37B8", Offset = "0x3CF37B8", Length = "0xC")]
		public float GetRegenDuration()
		{
			return _regenHandle.GetDuration();
		}

		[Token(Token = "0x6001432")]
		[Address(RVA = "0x3CF37C4", Offset = "0x3CF37C4", Length = "0xC")]
		public float GetInfiniteRemainingTime()
		{
			return _infiniteHandle.GetRemainingTime();
		}

		[Token(Token = "0x6001433")]
		[Address(RVA = "0x3CF37D0", Offset = "0x3CF37D0", Length = "0x68")]
		public void UnsubscribeInfiniteUpdate(OnTimerUpdate callback)
		{
			_realTimeTaskController.UnsubscribeUpdate("health-infinite", callback);
		}

		[Token(Token = "0x6001434")]
		[Address(RVA = "0x3CF3838", Offset = "0x3CF3838", Length = "0x68")]
		public void SubscribeInfiniteUpdate(OnTimerUpdate callback)
		{
			_realTimeTaskController.SubscribeUpdate("health-infinite", callback);
		}

		[Token(Token = "0x6001435")]
		[Address(RVA = "0x3CF3534", Offset = "0x3CF3534", Length = "0x15C")]
		internal void SetHealth(int value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HealthController::SetHealth");
		}

		[Token(Token = "0x6001436")]
		[Address(RVA = "0x3CF38A0", Offset = "0x3CF38A0", Length = "0x68")]
		public void SubscribeRegenUpdate(OnTimerUpdate callback)
		{
			_realTimeTaskController.SubscribeUpdate("health-regeneration", callback);
		}

		[Token(Token = "0x6001437")]
		[Address(RVA = "0x3CF3908", Offset = "0x3CF3908", Length = "0x68")]
		public void UnsubscribeRegenUpdate(OnTimerUpdate callback)
		{
			_realTimeTaskController.UnsubscribeUpdate("health-regeneration", callback);
		}

		[Token(Token = "0x6001438")]
		[Address(RVA = "0x3CF2F78", Offset = "0x3CF2F78", Length = "0x4C")]
		private HealthState DetermineState()
		{
			HealthStorageData healthData = _healthData;
			bool flag = healthData.InfiniteDuration < 0f;
			bool flag2 = healthData.InfiniteDuration == 0f;
			bool flag3 = healthData.InfiniteDuration == healthData.InfiniteDuration;
			bool flag4 = !flag3;
			bool flag5 = flag == flag4;
			bool flag6 = !flag5;
			if (!(flag6 || flag2))
			{
				return HealthState.Infinite;
			}
			HealthConfig config = _config;
			int num = healthData.CurrentHealth - config.MaxHealth;
			bool flag7 = num < 0;
			int num2 = healthData.CurrentHealth ^ config.MaxHealth;
			int num3 = healthData.CurrentHealth ^ num;
			int num4 = num2 & num3;
			bool flag8 = num4 < 0;
			bool flag9 = flag7 == flag8;
			return (!flag9) ? HealthState.Regenerating : HealthState.Full;
		}

		[Token(Token = "0x6001439")]
		[Address(RVA = "0x3CF2FC4", Offset = "0x3CF2FC4", Length = "0x1BC")]
		internal void EvaluateState()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HealthController::EvaluateState");
		}

		[Token(Token = "0x600143A")]
		[Address(RVA = "0x3CF3970", Offset = "0x3CF3970", Length = "0xCC")]
		private void StartInfinite()
		{
			HealthStorageData healthData = _healthData;
			OnRealTimerComplete onComplete = OnInfiniteComplete;
			_realTimeTaskController.CreateRealTimer("health-infinite", ref _infiniteHandle, healthData.InfiniteDuration, onComplete, 1f);
		}

		[Token(Token = "0x600143B")]
		[Address(RVA = "0x3CF3A3C", Offset = "0x3CF3A3C", Length = "0xCC")]
		private void StartRegeneration()
		{
			HealthConfig config = _config;
			OnRealTimerComplete onComplete = OnRegenerationComplete;
			_realTimeTaskController.CreateRealTimer("health-regeneration", ref _regenHandle, config.RegenDuration, onComplete, 1f);
		}

		[Token(Token = "0x600143C")]
		[Address(RVA = "0x3CF3B10", Offset = "0x3CF3B10", Length = "0xC8")]
		private unsafe void OnRegenerationComplete(int completeCount)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HealthController::OnRegenerationComplete");
		}

		[Token(Token = "0x600143D")]
		[Address(RVA = "0x3CF3BD8", Offset = "0x3CF3BD8", Length = "0x98")]
		private void OnInfiniteComplete(int completeCount)
		{
			if (completeCount >= 1)
			{
				HealthStorageData healthData = _healthData;
				healthData.InfiniteDuration = 0f;
				RemovePendingHealth();
				EvaluateState();
				_eventBus.InvokeEvent(default(UventHealthInfiniteEnded));
			}
		}

		[Token(Token = "0x600143E")]
		[Address(RVA = "0x3CF3338", Offset = "0x3CF3338", Length = "0xE8")]
		private DateTime GetPendingHealthTime()
		{
			HealthStorageData healthData = _healthData;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			if (DateTime.TryParse(healthData.PendingHealthTime, invariantCulture, default(DateTimeStyles), out var result))
			{
				return result;
			}
			return default(DateTime);
		}

		[Token(Token = "0x600143F")]
		[Address(RVA = "0x3CF3420", Offset = "0x3CF3420", Length = "0x8")]
		private void ResetPendingHealthTime()
		{
			SetPendingHealthTime(default(DateTime));
		}

		[Token(Token = "0x6001440")]
		[Address(RVA = "0x3CF3690", Offset = "0x3CF3690", Length = "0x108")]
		private void SetPendingHealthTime(DateTime time)
		{
			//IL_003c: Expected O, but got I4
			DateTime dateTime = time;
			int num = 187224064 + 864;
			HealthStorageData healthStorageData = _healthData;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			object obj = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ X0_v28+E4]");
			string _003CPendingHealthTime_003Ek__BackingField;
			if ((nint)0 != 0)
			{
				_003CPendingHealthTime_003Ek__BackingField = dateTime.ToString(invariantCulture);
			}
			else
			{
				_003CPendingHealthTime_003Ek__BackingField = dateTime.ToString(invariantCulture);
				bool flag = _healthData == null;
				bool flag2 = !flag;
				healthStorageData = healthStorageData;
				if (!flag2)
				{
					throw new NullReferenceException();
				}
			}
			healthStorageData.PendingHealthTime = _003CPendingHealthTime_003Ek__BackingField;
		}

		[Token(Token = "0x6001441")]
		[Address(RVA = "0x3CF3C70", Offset = "0x3CF3C70", Length = "0x4C")]
		public bool CanPlay()
		{
			HealthStorageData healthData = _healthData;
			bool flag = healthData.InfiniteDuration < 0f;
			bool flag2 = healthData.InfiniteDuration == 0f;
			bool flag3 = healthData.InfiniteDuration == healthData.InfiniteDuration;
			bool flag4 = !flag3;
			bool flag5 = flag == flag4;
			bool flag6 = !flag5;
			if (!(flag6 || flag2))
			{
				return true;
			}
			HealthConfig config = _config;
			int num = healthData.CurrentHealth - config.HeartRequiredToPlay;
			bool flag7 = num < 0;
			int num2 = healthData.CurrentHealth ^ config.HeartRequiredToPlay;
			int num3 = healthData.CurrentHealth ^ num;
			int num4 = num2 & num3;
			bool flag8 = num4 < 0;
			return flag7 == flag8;
		}

		[Token(Token = "0x6001442")]
		[Address(RVA = "0x3CF3CBC", Offset = "0x3CF3CBC", Length = "0x8")]
		public HealthController()
		{
		}
	}
}
