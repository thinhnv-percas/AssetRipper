using System;
using System.Collections.Generic;
using Cpp2ILInjected;

namespace ElephantSocial.CachingSystem
{
	[Token(Token = "0x2000941")]
	public class GenericCachingSystem<T>
	{
		[Token(Token = "0x4001F4A")]
		[FieldOffset(Offset = "0x0")]
		private T cachedData;

		[Token(Token = "0x4001F4B")]
		[FieldOffset(Offset = "0x0")]
		private readonly int cachingIntervalSeconds;

		[Token(Token = "0x4001F4C")]
		[FieldOffset(Offset = "0x0")]
		private DateTime lastCachingDateTime;

		[Token(Token = "0x4001F4D")]
		[FieldOffset(Offset = "0x0")]
		private readonly Action<Action<T>, Action<string>> dataRequestAction;

		[Token(Token = "0x4001F4E")]
		[FieldOffset(Offset = "0x0")]
		private readonly List<Action<T>> waitingResponses;

		[Token(Token = "0x4001F4F")]
		[FieldOffset(Offset = "0x0")]
		private bool requestInProgress;

		[Token(Token = "0x6002781")]
		[Address(RVA = "0x532F98C", Offset = "0x532F98C", Length = "0x98")]
		protected internal GenericCachingSystem(Action<Action<T>, Action<string>> dataRequestAction, int cachingIntervalSeconds)
		{
			List<Action<T>> list = new List<Action<T>>();
			waitingResponses = list;
			this.dataRequestAction = dataRequestAction;
			this.cachingIntervalSeconds = cachingIntervalSeconds;
		}

		[Token(Token = "0x6002782")]
		[Address(RVA = "0x532FA24", Offset = "0x532FA24", Length = "0xFC")]
		protected GenericCachingSystem(Action<Action<T>, Action<string>> dataRequestAction, int cachingIntervalSeconds, T initValues)
		{
			List<Action<T>> list = new List<Action<T>>();
			waitingResponses = list;
			this.cachingIntervalSeconds = cachingIntervalSeconds;
			this.dataRequestAction = dataRequestAction;
			cachedData = initValues;
			DateTime now = DateTime.Now;
			lastCachingDateTime = now;
		}

		[Token(Token = "0x6002783")]
		[Address(RVA = "0x532FB20", Offset = "0x532FB20", Length = "0x280")]
		public unsafe void GetData(Action<T> response, Action<string> onError)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GenericCachingSystem::GetData");
		}

		[Token(Token = "0x6002784")]
		[Address(RVA = "0x532FDA0", Offset = "0x532FDA0", Length = "0xD8")]
		public void ClearCache()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GenericCachingSystem::ClearCache");
		}
	}
}
