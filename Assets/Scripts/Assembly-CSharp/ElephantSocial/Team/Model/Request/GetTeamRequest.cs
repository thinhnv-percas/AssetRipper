using Cpp2ILInjected;
using ElephantSocial.Model;
using Newtonsoft.Json;

namespace ElephantSocial.Team.Model.Request
{
	[Token(Token = "0x20008B5")]
	public class GetTeamRequest : SocialBaseData
	{
		[JsonProperty("team_id")]
		[Token(Token = "0x4001D51")]
		[FieldOffset(Offset = "0x118")]
		public string TeamId;

		[Token(Token = "0x6002513")]
		[Address(RVA = "0x3DFE2C8", Offset = "0x3DFE2C8", Length = "0x4")]
		public GetTeamRequest()
		{
		}
	}
}
