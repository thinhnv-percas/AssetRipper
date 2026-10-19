using Cpp2ILInjected;
using ElephantSocial.Model;
using Newtonsoft.Json;

namespace ElephantSocial.Team.Model.Request
{
	[Token(Token = "0x20008B8")]
	public class JoinTeamRequest : SocialBaseData
	{
		[JsonProperty("team_id")]
		[Token(Token = "0x4001D54")]
		[FieldOffset(Offset = "0x118")]
		public string TeamId;

		[Token(Token = "0x600251A")]
		[Address(RVA = "0x3DEE978", Offset = "0x3DEE978", Length = "0x4")]
		public JoinTeamRequest()
		{
		}
	}
}
