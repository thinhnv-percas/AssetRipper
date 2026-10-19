using System;
using Cpp2ILInjected;

namespace ElephantSocial.Leaderboard
{
	[Serializable]
	[Token(Token = "0x20008D2")]
	public class LeaderboardContainer
	{
		[Token(Token = "0x4001DA5")]
		[FieldOffset(Offset = "0x10")]
		public string country;

		[Token(Token = "0x4001DA6")]
		[FieldOffset(Offset = "0x18")]
		public LeaderboardRecords global;

		[Token(Token = "0x4001DA7")]
		[FieldOffset(Offset = "0x20")]
		public LeaderboardRecords local;

		[Token(Token = "0x600255C")]
		[Address(RVA = "0x3E04970", Offset = "0x3E04970", Length = "0x8")]
		public LeaderboardContainer()
		{
		}
	}
}
