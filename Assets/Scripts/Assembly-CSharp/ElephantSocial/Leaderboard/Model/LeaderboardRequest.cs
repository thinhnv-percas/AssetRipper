using System;
using Cpp2ILInjected;

namespace ElephantSocial.Leaderboard.Model
{
	[Serializable]
	[Token(Token = "0x20008DA")]
	public class LeaderboardRequest : BaseLeaderboardRequest
	{
		[Token(Token = "0x6002569")]
		[Address(RVA = "0x3E05004", Offset = "0x3E05004", Length = "0x2C")]
		public LeaderboardRequest(int leaderboardId)
			: base(leaderboardId)
		{
			base.leaderboardId = leaderboardId;
		}
	}
}
