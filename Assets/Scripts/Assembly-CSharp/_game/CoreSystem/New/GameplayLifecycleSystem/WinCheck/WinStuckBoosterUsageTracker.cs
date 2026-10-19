using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.EventBusSystem.Runtime;
using _game.CoreGameKit.CoreSerivces.BoosterSystem.Core;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.WinCheck
{
	[Token(Token = "0x20003F0")]
	public class WinStuckBoosterUsageTracker : IDisposable
	{
		[Inject(false)]
		[Token(Token = "0x4000C7E")]
		[FieldOffset(Offset = "0x10")]
		private EventBus _eventBus;

		[Token(Token = "0x4000C7F")]
		[FieldOffset(Offset = "0x18")]
		internal readonly Dictionary<string, int> _usage;

		[Inject(false)]
		[Token(Token = "0x6001091")]
		[Address(RVA = "0x3CB5034", Offset = "0x3CB5034", Length = "0xA8")]
		private void Initialize()
		{
			Action<UventBoosterUsed> observer = OnBoosterUsed;
			_eventBus.ListenEvent(observer);
		}

		[Token(Token = "0x6001092")]
		[Address(RVA = "0x3CB50DC", Offset = "0x3CB50DC", Length = "0xA8")]
		private void OnBoosterUsed(UventBoosterUsed e)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("WinStuckBoosterUsageTracker::OnBoosterUsed");
		}

		[Token(Token = "0x6001093")]
		[Address(RVA = "0x3CB5184", Offset = "0x3CB5184", Length = "0x8")]
		public IReadOnlyDictionary<string, int> GetUsage()
		{
			return _usage;
		}

		[Token(Token = "0x6001094")]
		[Address(RVA = "0x3CB518C", Offset = "0x3CB518C", Length = "0xC0")]
		public void Dispose()
		{
			if (_eventBus != null)
			{
				Action<UventBoosterUsed> observer = OnBoosterUsed;
				_eventBus.RemoveListener(observer);
			}
		}

		[Token(Token = "0x6001095")]
		[Address(RVA = "0x3CB524C", Offset = "0x3CB524C", Length = "0x8C")]
		public WinStuckBoosterUsageTracker()
		{
			Dictionary<string, int> usage = new Dictionary<string, int>();
			_usage = usage;
		}
	}
}
