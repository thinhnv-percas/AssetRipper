using System;
using Cpp2ILInjected;
using ElephantSocial.Model;

namespace ElephantSocial.Leaderboard.Model
{
	[Serializable]
	[Token(Token = "0x20008D9")]
	public class LeaderboardPlayerRequest : BaseLeaderboardRequest
	{
		[Token(Token = "0x4001DAC")]
		[FieldOffset(Offset = "0x11C")]
		public int score;

		[Token(Token = "0x4001DAD")]
		[FieldOffset(Offset = "0x120")]
		public string operation;

		[Token(Token = "0x6002568")]
		[Address(RVA = "0x3E04D9C", Offset = "0x3E04D9C", Length = "0x58")]
		public LeaderboardPlayerRequest(int leaderboardId, BoardPlayer player, string operation)
			: base(leaderboardId)
		{
			base.leaderboardId = leaderboardId;
			score = player.score;
			this.operation = operation;
		}
	}
}
