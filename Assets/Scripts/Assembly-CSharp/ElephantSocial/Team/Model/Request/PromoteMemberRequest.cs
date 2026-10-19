using Cpp2ILInjected;
using ElephantSocial.Model;
using Newtonsoft.Json;

namespace ElephantSocial.Team.Model.Request
{
	[Token(Token = "0x20008BC")]
	public class PromoteMemberRequest : SocialBaseData
	{
		[JsonProperty("target_social_id")]
		[Token(Token = "0x4001D56")]
		[FieldOffset(Offset = "0x118")]
		public string TargetSocialId;

		[Token(Token = "0x600251E")]
		[Address(RVA = "0x3DEF24C", Offset = "0x3DEF24C", Length = "0x4")]
		public PromoteMemberRequest()
		{
		}
	}
}
