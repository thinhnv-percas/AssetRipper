using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using ElephantSDK;
using Reflex.Attributes;
using Unco.TimeTaskSystem.Runtime;
using Unco.TimeTaskSystem.Runtime.UnityBindings;
using UnityEngine;
using _game.Systems.ElephantStorage;

namespace Unco.RealTimeSystem.Runtime
{
	[Token(Token = "0x20007F0")]
	public class RealTimeTaskController : IDisposable
	{
		[Token(Token = "0x20007F1")]
		internal struct RealTimerEntry
		{
			[Token(Token = "0x4001A7C")]
			[FieldOffset(Offset = "0x0")]
			public float Duration;

			[Token(Token = "0x4001A7D")]
			[FieldOffset(Offset = "0x8")]
			public OnRealTimerComplete OnComplete;

			[Token(Token = "0x4001A7E")]
			[FieldOffset(Offset = "0x10")]
			public TimerHandle TimerHandle;
		}

		[Token(Token = "0x4001A79")]
		[FieldOffset(Offset = "0x10")]
		private UnscaledTimeTaskController _unscaledTimeTaskController;

		[Token(Token = "0x4001A7A")]
		[FieldOffset(Offset = "0x18")]
		private RealTimeStorageData _storageData;

		[Token(Token = "0x4001A7B")]
		[FieldOffset(Offset = "0x20")]
		internal readonly Dictionary<string, RealTimerEntry> _activeTimers;

		[Inject(false)]
		[Token(Token = "0x600218B")]
		[Address(RVA = "0x3DC6F04", Offset = "0x3DC6F04", Length = "0x34")]
		private void Construct(UnscaledTimeTaskController unscaledTimeTaskController, RealTimeStorageData storageData)
		{
			_unscaledTimeTaskController = unscaledTimeTaskController;
			_storageData = storageData;
		}

		[Token(Token = "0x600218C")]
		[Address(RVA = "0x3DC6F38", Offset = "0x3DC6F38", Length = "0x4")]
		public void Dispose()
		{
			DetachAll();
		}

		[Token(Token = "0x600218D")]
		[Address(RVA = "0x3DC70C4", Offset = "0x3DC70C4", Length = "0x61C")]
		public unsafe void CreateRealTimer(string key, ref RealTimerHandle handle, float duration, OnRealTimerComplete onComplete, float updateInterval = 0f)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RealTimeTaskController::CreateRealTimer");
		}

		[Token(Token = "0x600218E")]
		[Address(RVA = "0x3DC786C", Offset = "0x3DC786C", Length = "0xA4")]
		public void AddTime(string key, float duration)
		{
			RealTimerEntry value = default(RealTimerEntry);
			string key2 = default(string);
			if (!_activeTimers.TryGetValue(key2, out value))
			{
			}
		}

		[Token(Token = "0x600218F")]
		[Address(RVA = "0x3DC7910", Offset = "0x3DC7910", Length = "0xC8")]
		public void Cancel(string key)
		{
			RealTimerEntry value = default(RealTimerEntry);
			if (_activeTimers.TryGetValue(key, out value))
			{
				bool flag = _activeTimers.Remove(key);
			}
			RemovePersistedData(key);
		}

		[Token(Token = "0x6002190")]
		[Address(RVA = "0x3DC7AA4", Offset = "0x3DC7AA4", Length = "0xBC")]
		public void Detach(string key)
		{
			RealTimerEntry value = default(RealTimerEntry);
			if (_activeTimers.TryGetValue(key, out value))
			{
				bool flag = _activeTimers.Remove(key);
			}
		}

		[Token(Token = "0x6002191")]
		[Address(RVA = "0x3DC7B60", Offset = "0x3DC7B60", Length = "0xAC")]
		public bool TryGetRemainingTime(string key, out float remaining)
		{
			remaining = default(float);
			RealTimerEntry value = default(RealTimerEntry);
			string key2 = default(string);
			bool flag = _activeTimers.TryGetValue(key2, out value);
			bool flag2 = !flag;
			float num = 0f;
			if (!flag2)
			{
				num = 0f;
			}
			remaining = num;
			return flag;
		}

		[Token(Token = "0x6002192")]
		[Address(RVA = "0x3DC7C0C", Offset = "0x3DC7C0C", Length = "0xAC")]
		public bool TryGetProgress(string key, out float progress)
		{
			progress = default(float);
			RealTimerEntry value = default(RealTimerEntry);
			string key2 = default(string);
			bool flag = _activeTimers.TryGetValue(key2, out value);
			bool flag2 = !flag;
			float num = 0f;
			if (!flag2)
			{
				num = 0f;
			}
			progress = num;
			return flag;
		}

		[Token(Token = "0x6002193")]
		[Address(RVA = "0x3DC7CB8", Offset = "0x3DC7CB8", Length = "0x94")]
		public bool TryGetDuration(string key, out float duration)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RealTimeTaskController::TryGetDuration");
			duration = default;
			return default;
		}

		[Token(Token = "0x6002194")]
		[Address(RVA = "0x3DC7D4C", Offset = "0x3DC7D4C", Length = "0xAC")]
		public bool TryGetElapsedTime(string key, out float elapsed)
		{
			elapsed = default(float);
			RealTimerEntry value = default(RealTimerEntry);
			string key2 = default(string);
			bool flag = _activeTimers.TryGetValue(key2, out value);
			bool flag2 = !flag;
			float num = 0f;
			if (!flag2)
			{
				num = 0f;
			}
			elapsed = num;
			return flag;
		}

		[Token(Token = "0x6002195")]
		[Address(RVA = "0x3DC7DF8", Offset = "0x3DC7DF8", Length = "0x90")]
		public bool IsActive(string key)
		{
			RealTimerEntry value = default(RealTimerEntry);
			string key2 = default(string);
			bool flag = _activeTimers.TryGetValue(key2, out value);
			if (flag)
			{
				flag = value.TimerHandle.IsValid;
			}
			return flag;
		}

		[Token(Token = "0x6002196")]
		[Address(RVA = "0x3DC7E88", Offset = "0x3DC7E88", Length = "0x1C")]
		public bool HasPersistedTimer(string key)
		{
			int num = FindPersistedIndex(key);
			int num2 = ~num;
			return (byte)(num2 >> 31) != 0;
		}

		[Token(Token = "0x6002197")]
		[Address(RVA = "0x3DC7EA4", Offset = "0x3DC7EA4", Length = "0x32C")]
		public unsafe int ResolveOfflineCompletions(string key, float duration)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RealTimeTaskController::ResolveOfflineCompletions");
			return default;
		}

		[Token(Token = "0x6002198")]
		[Address(RVA = "0x3DC81D0", Offset = "0x3DC81D0", Length = "0x180")]
		public void SeedPersistedTimer(string key, DateTime triggerTime)
		{
			//IL_0083: Expected I4, but got I8
			int num = FindPersistedIndex(key);
			RealTimeStorageData storageData = _storageData;
			RealTimerPref realTimerPref = default(RealTimerPref);
			if ((int)(num & 0x80000000L) == 0)
			{
				storageData.Timers[num] = realTimerPref;
			}
			else
			{
				List<RealTimerPref> timers = storageData.Timers;
				timers.Add(realTimerPref);
			}
			Elephant.SaveStorage();
		}

		[Token(Token = "0x6002199")]
		[Address(RVA = "0x3DC8350", Offset = "0x3DC8350", Length = "0x9C")]
		public void SubscribeUpdate(string key, OnTimerUpdate callback)
		{
			RealTimerEntry value = default(RealTimerEntry);
			string key2 = default(string);
			if (!_activeTimers.TryGetValue(key2, out value))
			{
			}
		}

		[Token(Token = "0x600219A")]
		[Address(RVA = "0x3DC83EC", Offset = "0x3DC83EC", Length = "0x9C")]
		public void UnsubscribeUpdate(string key, OnTimerUpdate callback)
		{
			RealTimerEntry value = default(RealTimerEntry);
			string key2 = default(string);
			if (!_activeTimers.TryGetValue(key2, out value))
			{
			}
		}

		[Token(Token = "0x600219B")]
		[Address(RVA = "0x3DC6F3C", Offset = "0x3DC6F3C", Length = "0x188")]
		public unsafe void DetachAll()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RealTimeTaskController::DetachAll");
		}

		[Token(Token = "0x600219C")]
		[Address(RVA = "0x3DC8488", Offset = "0x3DC8488", Length = "0x1B4")]
		private void OnTimerComplete(string key)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RealTimeTaskController::OnTimerComplete");
		}

		[Token(Token = "0x600219D")]
		[Address(RVA = "0x3DC7788", Offset = "0x3DC7788", Length = "0xB0")]
		private int FindPersistedIndex(string key)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RealTimeTaskController::FindPersistedIndex");
			return default;
		}

		[Token(Token = "0x600219E")]
		[Address(RVA = "0x3DC79D8", Offset = "0x3DC79D8", Length = "0xCC")]
		private void RemovePersistedData(string key)
		{
			//IL_0052: Expected I4, but got I8
			string key2 = default(string);
			int num = FindPersistedIndex(key2);
			if ((int)(num & 0x80000000L) == 0)
			{
				RealTimeStorageData storageData = _storageData;
				storageData.Timers.RemoveAt(num);
				Elephant.SaveStorage();
			}
		}

		[Token(Token = "0x600219F")]
		[Address(RVA = "0x3DC863C", Offset = "0x3DC863C", Length = "0x8C")]
		public RealTimeTaskController()
		{
			Dictionary<string, RealTimerEntry> activeTimers = new Dictionary<string, RealTimerEntry>();
			_activeTimers = activeTimers;
		}
	}
}
