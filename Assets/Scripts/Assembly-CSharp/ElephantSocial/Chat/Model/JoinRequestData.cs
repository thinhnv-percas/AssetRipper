using Cpp2ILInjected;
using Newtonsoft.Json;

namespace ElephantSocial.Chat.Model
{
	[Token(Token = "0x2000911")]
	public class JoinRequestData
	{
		[JsonProperty("social_id")]
		[Token(Token = "0x170003FA")]
		[field: Token(Token = "0x4001E63")]
		[field: FieldOffset(Offset = "0x10")]
		public string SocialId
		{
			[Token(Token = "0x6002641")]
			[Address(RVA = "0x3E17C8C", Offset = "0x3E17C8C", Length = "0x8")]
			get;
			[Token(Token = "0x6002642")]
			[Address(RVA = "0x3E17C94", Offset = "0x3E17C94", Length = "0x8")]
			set;
		}

		[JsonProperty("player_name")]
		[Token(Token = "0x170003FB")]
		[field: Token(Token = "0x4001E64")]
		[field: FieldOffset(Offset = "0x18")]
		public string PlayerName
		{
			[Token(Token = "0x6002643")]
			[Address(RVA = "0x3E17C9C", Offset = "0x3E17C9C", Length = "0x8")]
			get;
			[Token(Token = "0x6002644")]
			[Address(RVA = "0x3E17CA4", Offset = "0x3E17CA4", Length = "0x8")]
			set;
		}

		[JsonProperty("profile_picture")]
		[Token(Token = "0x170003FC")]
		[field: Token(Token = "0x4001E65")]
		[field: FieldOffset(Offset = "0x20")]
		public string ProfilePicture
		{
			[Token(Token = "0x6002645")]
			[Address(RVA = "0x3E17CAC", Offset = "0x3E17CAC", Length = "0x8")]
			get;
			[Token(Token = "0x6002646")]
			[Address(RVA = "0x3E17CB4", Offset = "0x3E17CB4", Length = "0x8")]
			set;
		}

		[Token(Token = "0x6002647")]
		[Address(RVA = "0x3E17CBC", Offset = "0x3E17CBC", Length = "0x8")]
		public JoinRequestData()
		{
		}
	}
}
