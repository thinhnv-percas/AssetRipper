using Cpp2ILInjected;
using ElephantSocial.Model;
using Newtonsoft.Json;

namespace ElephantSocial.Leaderboard.Model
{
	[Token(Token = "0x20008D6")]
	public class BaseLeaderboardRequest : SocialBaseData
	{
		[JsonProperty("leaderboard_id")]
		[Token(Token = "0x4001DAA")]
		[FieldOffset(Offset = "0x118")]
		public int leaderboardId;

		[Token(Token = "0x6002565")]
		[Address(RVA = "0x3E05248", Offset = "0x3E05248", Length = "0x2C")]
		public BaseLeaderboardRequest(int leaderboardId)
		{
			this.leaderboardId = leaderboardId;
		}
	}
}
