using System;
using Cpp2ILInjected;
using ElephantSocial.CachingSystem;

namespace ElephantSocial.Leaderboard
{
	[Token(Token = "0x20008D4")]
	public class LeaderboardContainerCache : GenericCachingSystem<LeaderboardContainer>
	{
		[Token(Token = "0x600255F")]
		[Address(RVA = "0x3E04A0C", Offset = "0x3E04A0C", Length = "0x70")]
		private LeaderboardContainerCache(Action<Action<LeaderboardContainer>, Action<string>> dataRequestAction, int cachingIntervalSeconds)
			: base(dataRequestAction, cachingIntervalSeconds)
		{
			Action<Action<LeaderboardContainer>, Action<string>> action = default(Action<Action<LeaderboardContainer>, Action<string>>);
			int num = default(int);
		}

		[Token(Token = "0x6002560")]
		[Address(RVA = "0x3E04A7C", Offset = "0x3E04A7C", Length = "0xA4")]
		public static LeaderboardContainerCache CreateInstance(Action<Action<LeaderboardContainer>, Action<string>> dataRequestAction, int cachingIntervalSeconds)
		{
			return new LeaderboardContainerCache(dataRequestAction, cachingIntervalSeconds);
		}
	}
}
