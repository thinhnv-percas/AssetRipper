using Cpp2ILInjected;
using ElephantSocial.Model;
using Newtonsoft.Json;

namespace ElephantSocial.Team.Model.Request
{
	[Token(Token = "0x20008BD")]
	public class RejectJoinRequest : SocialBaseData
	{
		[JsonProperty("target_social_id")]
		[Token(Token = "0x4001D57")]
		[FieldOffset(Offset = "0x118")]
		public string TargetSocialId;

		[Token(Token = "0x600251F")]
		[Address(RVA = "0x3DF033C", Offset = "0x3DF033C", Length = "0x4")]
		public RejectJoinRequest()
		{
		}
	}
}
