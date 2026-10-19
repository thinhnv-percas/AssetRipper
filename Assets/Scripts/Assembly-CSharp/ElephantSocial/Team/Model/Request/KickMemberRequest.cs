using Cpp2ILInjected;
using ElephantSocial.Model;
using Newtonsoft.Json;

namespace ElephantSocial.Team.Model.Request
{
	[Token(Token = "0x20008B9")]
	public class KickMemberRequest : SocialBaseData
	{
		[JsonProperty("target_social_id")]
		[Token(Token = "0x4001D55")]
		[FieldOffset(Offset = "0x118")]
		public string TargetSocialId;

		[Token(Token = "0x600251B")]
		[Address(RVA = "0x3DEF81C", Offset = "0x3DEF81C", Length = "0x4")]
		public KickMemberRequest()
		{
		}
	}
}
