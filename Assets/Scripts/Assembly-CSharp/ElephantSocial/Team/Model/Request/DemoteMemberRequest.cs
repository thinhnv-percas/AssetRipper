using Cpp2ILInjected;
using ElephantSocial.Model;
using Newtonsoft.Json;

namespace ElephantSocial.Team.Model.Request
{
	[Token(Token = "0x20008B4")]
	public class DemoteMemberRequest : SocialBaseData
	{
		[JsonProperty("target_social_id")]
		[Token(Token = "0x4001D50")]
		[FieldOffset(Offset = "0x118")]
		public string TargetSocialId;

		[Token(Token = "0x6002512")]
		[Address(RVA = "0x3DEF534", Offset = "0x3DEF534", Length = "0x4")]
		public DemoteMemberRequest()
		{
		}
	}
}
