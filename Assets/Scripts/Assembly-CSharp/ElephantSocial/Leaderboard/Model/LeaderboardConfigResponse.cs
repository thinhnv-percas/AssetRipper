using System;
using Cpp2ILInjected;
using Newtonsoft.Json;

namespace ElephantSocial.Leaderboard.Model
{
	[Serializable]
	[Token(Token = "0x20008D8")]
	public class LeaderboardConfigResponse
	{
		[JsonProperty("global_leaderboard_id")]
		[Token(Token = "0x4001DAB")]
		[FieldOffset(Offset = "0x10")]
		public int globalLeaderboardId;

		[Token(Token = "0x6002567")]
		[Address(RVA = "0x3E0527C", Offset = "0x3E0527C", Length = "0x8")]
		public LeaderboardConfigResponse()
		{
		}
	}
}
