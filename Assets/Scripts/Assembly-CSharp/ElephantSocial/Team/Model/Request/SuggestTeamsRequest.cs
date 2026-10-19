using Cpp2ILInjected;
using ElephantSocial.Model;
using Newtonsoft.Json;

namespace ElephantSocial.Team.Model.Request
{
	[Token(Token = "0x20008BF")]
	public class SuggestTeamsRequest : SocialBaseData
	{
		[JsonProperty("level")]
		[Token(Token = "0x4001D59")]
		[FieldOffset(Offset = "0x118")]
		public long Level;

		[Token(Token = "0x6002521")]
		[Address(RVA = "0x3DFE2C0", Offset = "0x3DFE2C0", Length = "0x4")]
		public SuggestTeamsRequest()
		{
		}
	}
}
