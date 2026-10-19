using System;
using Cpp2ILInjected;
using ElephantSocial.Model;

namespace ElephantSocial.Leaderboard.Model
{
	[Serializable]
	[Token(Token = "0x20008D7")]
	public class LeaderboardConfigRequest : SocialBaseData
	{
		[Token(Token = "0x6002566")]
		[Address(RVA = "0x3E05274", Offset = "0x3E05274", Length = "0x8")]
		public LeaderboardConfigRequest()
		{
		}
	}
}
