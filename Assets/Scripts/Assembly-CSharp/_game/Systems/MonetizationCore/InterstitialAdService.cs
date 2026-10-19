using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Cpp2ILInjected;
using ElephantSDK;
using Reflex.Attributes;
using RollicGames.Advertisements;
using Unco.AdSystem;
using UnityEngine;
using _game.CoreGameKit.CoreSerivces.LevelProgresService.Interface;
using _game.CoreGameKit.UiControllers;
using _game.Systems.ElephantStorage;

namespace _game.Systems.MonetizationCore
{
	[Token(Token = "0x200076D")]
	public class InterstitialAdService
	{
		[Inject(false)]
		[Token(Token = "0x40018C5")]
		[FieldOffset(Offset = "0x10")]
		private IAdManager _adManager;

		[Inject(false)]
		[Token(Token = "0x40018C6")]
		[FieldOffset(Offset = "0x18")]
		private UiManager _uiManager;

		[Inject(false)]
		[Token(Token = "0x40018C7")]
		[FieldOffset(Offset = "0x20")]
		private ILevelProgressService _levelProgressService;

		[Inject(false)]
		[Token(Token = "0x40018C8")]
		[FieldOffset(Offset = "0x28")]
		private MonetizationStorageData _monetizationData;

		[Inject(false)]
		[Token(Token = "0x40018C9")]
		[FieldOffset(Offset = "0x30")]
		private IPlayerDataHandler _dataHandler;

		[Token(Token = "0x40018CA")]
		[FieldOffset(Offset = "0x38")]
		private readonly InterstitialConfig _config;

		[Token(Token = "0x40018CB")]
		[FieldOffset(Offset = "0x40")]
		private readonly float _sessionStartTime;

		[Token(Token = "0x40018CC")]
		[FieldOffset(Offset = "0x44")]
		private float _rewardedInterstitialBufferSeconds;

		[Token(Token = "0x40018CD")]
		[FieldOffset(Offset = "0x48")]
		private float _lastInterstitialTime;

		[Token(Token = "0x40018CE")]
		[FieldOffset(Offset = "0x4C")]
		private int _tryShowCount;

		[CompilerGenerated]
		[Token(Token = "0x40018CF")]
		[FieldOffset(Offset = "0x50")]
		internal Action OnInterstitialShown;

		[CompilerGenerated]
		[Token(Token = "0x6001F4D")]
		[Address(RVA = "0x3D8C2EC", Offset = "0x3D8C2EC", Length = "0xA4")]
		public void add_OnInterstitialShown(Action value)
		{
			Action action = OnInterstitialShown;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref OnInterstitialShown, value2, action2);
			}
			while ((object)action != action2);
		}

		[CompilerGenerated]
		[Token(Token = "0x6001F4E")]
		[Address(RVA = "0x3D8CB68", Offset = "0x3D8CB68", Length = "0xA4")]
		public void remove_OnInterstitialShown(Action value)
		{
			Action action = OnInterstitialShown;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref OnInterstitialShown, value2, action2);
			}
			while ((object)action != action2);
		}

		[Token(Token = "0x6001F4F")]
		[Address(RVA = "0x3D8E0AC", Offset = "0x3D8E0AC", Length = "0x17C")]
		public InterstitialAdService(InterstitialConfig config)
		{
			_lastInterstitialTime = -1f;
			_config = config;
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			_sessionStartTime = realtimeSinceStartup;
			_rewardedInterstitialBufferSeconds = config.rewardedInterstitialBufferSeconds;
			Action<RollicRewardedAd.RewardedAdCategory, RLRewardedAdResult> b = OnRewardedFinished;
			Delegate obj = Delegate.Combine(AdManager.OnRewardedFinished, b);
			if ((object)obj != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				Action<RollicRewardedAd.RewardedAdCategory, RLRewardedAdResult> action = default(Action<RollicRewardedAd.RewardedAdCategory, RLRewardedAdResult>);
				if (action == null)
				{
					throw new InvalidCastException();
				}
				AdManager.OnRewardedFinished = action;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj2 = default(object);
				if (obj2 == null)
				{
					throw new InvalidCastException();
				}
			}
			else
			{
				AdManager.OnRewardedFinished = null;
			}
		}

		[Inject(false)]
		[Token(Token = "0x6001F50")]
		[Address(RVA = "0x3D8E228", Offset = "0x3D8E228", Length = "0xE0")]
		private void Inject()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("InterstitialAdService::Inject");
		}

		[Token(Token = "0x6001F51")]
		[Address(RVA = "0x3D8E308", Offset = "0x3D8E308", Length = "0x17C")]
		private long ResolveInstallTimestamp()
		{
			MonetizationStorageData monetizationData = _monetizationData;
			DateTimeOffset dateTimeOffset2;
			if (monetizationData.InterstitialFirstInstallDay >= 1)
			{
				int num = monetizationData.InterstitialFirstInstallDay * 274877907;
				int num2 = num >> 38;
				int num3 = num2 * 1000;
				int num4 = monetizationData.InterstitialFirstInstallDay - num3;
				DateTime dateTime = new DateTime(num2, 1, 1, 0, 0, 0, DateTimeKind.Utc);
				DateTime dateTime2 = dateTime;
				double value = (double)num4 - 5E-324;
				DateTime dateTime3 = dateTime2.AddDays(value);
				DateTimeOffset dateTimeOffset = new DateTimeOffset(dateTime3, TimeSpan.Zero);
				dateTimeOffset2 = dateTimeOffset;
			}
			else
			{
				DateTimeOffset utcNow = DateTimeOffset.UtcNow;
				dateTimeOffset2 = utcNow;
			}
			return dateTimeOffset2.ToUnixTimeSeconds();
		}

		[Token(Token = "0x6001F52")]
		[Address(RVA = "0x3D8E484", Offset = "0x3D8E484", Length = "0x54")]
		private void OnRewardedFinished(RollicRewardedAd.RewardedAdCategory category, RLRewardedAdResult result)
		{
			if (result == RLRewardedAdResult.Finished)
			{
				float realtimeSinceStartup = Time.realtimeSinceStartup;
				InterstitialConfig config = _config;
				float num = realtimeSinceStartup + _rewardedInterstitialBufferSeconds;
				float num2 = num - config.interDisplayIntervalInSeconds;
				bool flag = num2 < _lastInterstitialTime;
				bool flag2 = num2 == _lastInterstitialTime;
				bool flag3 = num2 == num2;
				bool flag4 = _lastInterstitialTime == _lastInterstitialTime;
				bool flag5 = flag3 && flag4;
				bool flag6 = !flag5;
				bool flag7 = flag == flag6;
				bool flag8 = !flag7;
				if (!(flag8 || flag2))
				{
					_lastInterstitialTime = num2;
				}
			}
		}

		[Token(Token = "0x6001F53")]
		[Address(RVA = "0x3D8E4D8", Offset = "0x3D8E4D8", Length = "0x8")]
		public void DEV_ShowInterstitial()
		{
			ShowInterstitial(null);
		}

		[Token(Token = "0x6001F54")]
		[Address(RVA = "0x3D8E6A0", Offset = "0x3D8E6A0", Length = "0x10C")]
		public void TryShow(Action onComplete)
		{
			int tryShowCount = _tryShowCount + 1;
			_tryShowCount = tryShowCount;
			if (IsEligible(out var skipReason))
			{
				ShowInterstitial(onComplete);
				return;
			}
			InterstitialConfig config = _config;
			if (config.logEligibilityReasons)
			{
				string message = "[Inter] skipped: " + skipReason;
				Debug.Log(message);
			}
			onComplete?.Invoke();
		}

		[Token(Token = "0x6001F55")]
		[Address(RVA = "0x3D8E4E0", Offset = "0x3D8E4E0", Length = "0x1C0")]
		private void ShowInterstitial(Action onComplete)
		{
			Action onShown = delegate
			{
				InterstitialAdService interstitialAdService = this;
				float realtimeSinceStartup = Time.realtimeSinceStartup;
				interstitialAdService._lastInterstitialTime = realtimeSinceStartup;
				InterstitialAdService interstitialAdService2 = this;
				if (interstitialAdService2.OnInterstitialShown != null)
				{
					interstitialAdService2.OnInterstitialShown();
				}
			};
			Action onDismissed = delegate
			{
				if (onComplete != null)
				{
					onComplete();
				}
			};
			Action onFailed = delegate
			{
				if (onComplete != null)
				{
					onComplete();
				}
			};
			_adManager.ShowInterstitial(onShown, onDismissed, onFailed);
		}

		[Token(Token = "0x6001F56")]
		[Address(RVA = "0x3D8E7AC", Offset = "0x3D8E7AC", Length = "0x60C")]
		private bool IsEligible(out string skipReason)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("InterstitialAdService::IsEligible");
			skipReason = default;
			return default;
		}

		[Token(Token = "0x6001F57")]
		[Address(RVA = "0x3D8EDB8", Offset = "0x3D8EDB8", Length = "0xD0")]
		private void LogSkip(string reason)
		{
			InterstitialConfig config = _config;
			if (config.logEligibilityReasons)
			{
				string text = default(string);
				string message = "[Inter] skipped: " + text;
				Debug.Log(message);
			}
		}

		[Token(Token = "0x6001F58")]
		[Address(RVA = "0x3D8EE90", Offset = "0x3D8EE90", Length = "0x1A0")]
		private bool IsAdFreeDay()
		{
			MonetizationStorageData monetizationData = _monetizationData;
			InterstitialConfig config = _config;
			DateTimeOffset dateTimeOffset2;
			if (config.useCalendarDayCheck)
			{
				DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(monetizationData.InterstitialFirstInstallTimestamp);
				dateTimeOffset2 = dateTimeOffset;
				DateTime utcDateTime = dateTimeOffset2.UtcDateTime;
				DateTime dateTime = utcDateTime;
				DateTime date = dateTime.Date;
				DateTime utcNow = DateTime.UtcNow;
				dateTime = utcNow;
				DateTime date2 = dateTime.Date;
				TimeSpan timeSpan = date2 - date;
				TimeSpan timeSpan2 = timeSpan;
				double totalDays = timeSpan2.TotalDays;
				InterstitialConfig config2 = _config;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
				return totalDays < (double)config2.firstDayToDisplayInter;
			}
			DateTimeOffset utcNow2 = DateTimeOffset.UtcNow;
			dateTimeOffset2 = utcNow2;
			long num = dateTimeOffset2.ToUnixTimeSeconds();
			InterstitialConfig config3 = _config;
			long num2 = num - monetizationData.InterstitialFirstInstallTimestamp;
			int num3 = config3.firstDayToDisplayInter * 86400;
			long num4 = num2 - num3;
			bool flag = num4 < 0;
			long num5 = num2 ^ num3;
			long num6 = num2 ^ num4;
			long num7 = num5 & num6;
			bool flag2 = num7 < 0;
			bool flag3 = flag == flag2;
			return !flag3;
		}
	}
}
