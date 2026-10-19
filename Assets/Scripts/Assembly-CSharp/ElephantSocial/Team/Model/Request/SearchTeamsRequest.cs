using Cpp2ILInjected;
using ElephantSocial.Model;
using Newtonsoft.Json;

namespace ElephantSocial.Team.Model.Request
{
	[Token(Token = "0x20008BE")]
	public class SearchTeamsRequest : SocialBaseData
	{
		[JsonProperty("search")]
		[Token(Token = "0x4001D58")]
		[FieldOffset(Offset = "0x118")]
		public string SearchTerm;

		[Token(Token = "0x6002520")]
		[Address(RVA = "0x3DFE2C4", Offset = "0x3DFE2C4", Length = "0x4")]
		public SearchTeamsRequest()
		{
		}
	}
}
