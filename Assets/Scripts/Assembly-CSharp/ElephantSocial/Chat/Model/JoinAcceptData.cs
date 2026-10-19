using Cpp2ILInjected;
using Newtonsoft.Json;

namespace ElephantSocial.Chat.Model
{
	[Token(Token = "0x200090F")]
	public class JoinAcceptData
	{
		[JsonProperty("social_id")]
		[Token(Token = "0x170003EE")]
		[field: Token(Token = "0x4001E57")]
		[field: FieldOffset(Offset = "0x10")]
		public string SocialId
		{
			[Token(Token = "0x6002627")]
			[Address(RVA = "0x3E17BBC", Offset = "0x3E17BBC", Length = "0x8")]
			get;
			[Token(Token = "0x6002628")]
			[Address(RVA = "0x3E17BC4", Offset = "0x3E17BC4", Length = "0x8")]
			set;
		}

		[JsonProperty("player_name")]
		[Token(Token = "0x170003EF")]
		[field: Token(Token = "0x4001E58")]
		[field: FieldOffset(Offset = "0x18")]
		public string PlayerName
		{
			[Token(Token = "0x6002629")]
			[Address(RVA = "0x3E17BCC", Offset = "0x3E17BCC", Length = "0x8")]
			get;
			[Token(Token = "0x600262A")]
			[Address(RVA = "0x3E17BD4", Offset = "0x3E17BD4", Length = "0x8")]
			set;
		}

		[JsonProperty("profile_picture")]
		[Token(Token = "0x170003F0")]
		[field: Token(Token = "0x4001E59")]
		[field: FieldOffset(Offset = "0x20")]
		public string ProfilePicture
		{
			[Token(Token = "0x600262B")]
			[Address(RVA = "0x3E17BDC", Offset = "0x3E17BDC", Length = "0x8")]
			get;
			[Token(Token = "0x600262C")]
			[Address(RVA = "0x3E17BE4", Offset = "0x3E17BE4", Length = "0x8")]
			set;
		}

		[JsonProperty("target_social_id")]
		[Token(Token = "0x170003F1")]
		[field: Token(Token = "0x4001E5A")]
		[field: FieldOffset(Offset = "0x28")]
		public string TargetSocialId
		{
			[Token(Token = "0x600262D")]
			[Address(RVA = "0x3E17BEC", Offset = "0x3E17BEC", Length = "0x8")]
			get;
			[Token(Token = "0x600262E")]
			[Address(RVA = "0x3E17BF4", Offset = "0x3E17BF4", Length = "0x8")]
			set;
		}

		[JsonProperty("target_player_name")]
		[Token(Token = "0x170003F2")]
		[field: Token(Token = "0x4001E5B")]
		[field: FieldOffset(Offset = "0x30")]
		public string TargetPlayerName
		{
			[Token(Token = "0x600262F")]
			[Address(RVA = "0x3E17BFC", Offset = "0x3E17BFC", Length = "0x8")]
			get;
			[Token(Token = "0x6002630")]
			[Address(RVA = "0x3E17C04", Offset = "0x3E17C04", Length = "0x8")]
			set;
		}

		[JsonProperty("target_profile_picture")]
		[Token(Token = "0x170003F3")]
		[field: Token(Token = "0x4001E5C")]
		[field: FieldOffset(Offset = "0x38")]
		public string TargetProfilePicture
		{
			[Token(Token = "0x6002631")]
			[Address(RVA = "0x3E17C0C", Offset = "0x3E17C0C", Length = "0x8")]
			get;
			[Token(Token = "0x6002632")]
			[Address(RVA = "0x3E17C14", Offset = "0x3E17C14", Length = "0x8")]
			set;
		}

		[Token(Token = "0x6002633")]
		[Address(RVA = "0x3E17C1C", Offset = "0x3E17C1C", Length = "0x8")]
		public JoinAcceptData()
		{
		}
	}
}
