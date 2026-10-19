using Cpp2ILInjected;
using ElephantSocial.Model;
using Newtonsoft.Json;

namespace ElephantSocial.Team.Model.Request
{
	[Token(Token = "0x20008B2")]
	public class AcceptJoinRequest : SocialBaseData
	{
		[JsonProperty("target_social_id")]
		[Token(Token = "0x4001D49")]
		[FieldOffset(Offset = "0x118")]
		public string TargetSocialId;

		[Token(Token = "0x6002510")]
		[Address(RVA = "0x3DF004C", Offset = "0x3DF004C", Length = "0x4")]
		public AcceptJoinRequest()
		{
		}
	}
}
