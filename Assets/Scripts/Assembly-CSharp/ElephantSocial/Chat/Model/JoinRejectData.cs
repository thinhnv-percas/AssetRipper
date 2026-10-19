using Cpp2ILInjected;
using Newtonsoft.Json;

namespace ElephantSocial.Chat.Model
{
	[Token(Token = "0x2000910")]
	public class JoinRejectData
	{
		[JsonProperty("social_id")]
		[Token(Token = "0x170003F4")]
		[field: Token(Token = "0x4001E5D")]
		[field: FieldOffset(Offset = "0x10")]
		public string SocialId
		{
			[Token(Token = "0x6002634")]
			[Address(RVA = "0x3E17C24", Offset = "0x3E17C24", Length = "0x8")]
			get;
			[Token(Token = "0x6002635")]
			[Address(RVA = "0x3E17C2C", Offset = "0x3E17C2C", Length = "0x8")]
			set;
		}

		[JsonProperty("player_name")]
		[Token(Token = "0x170003F5")]
		[field: Token(Token = "0x4001E5E")]
		[field: FieldOffset(Offset = "0x18")]
		public string PlayerName
		{
			[Token(Token = "0x6002636")]
			[Address(RVA = "0x3E17C34", Offset = "0x3E17C34", Length = "0x8")]
			get;
			[Token(Token = "0x6002637")]
			[Address(RVA = "0x3E17C3C", Offset = "0x3E17C3C", Length = "0x8")]
			set;
		}

		[JsonProperty("profile_picture")]
		[Token(Token = "0x170003F6")]
		[field: Token(Token = "0x4001E5F")]
		[field: FieldOffset(Offset = "0x20")]
		public string ProfilePicture
		{
			[Token(Token = "0x6002638")]
			[Address(RVA = "0x3E17C44", Offset = "0x3E17C44", Length = "0x8")]
			get;
			[Token(Token = "0x6002639")]
			[Address(RVA = "0x3E17C4C", Offset = "0x3E17C4C", Length = "0x8")]
			set;
		}

		[JsonProperty("target_social_id")]
		[Token(Token = "0x170003F7")]
		[field: Token(Token = "0x4001E60")]
		[field: FieldOffset(Offset = "0x28")]
		public string TargetSocialId
		{
			[Token(Token = "0x600263A")]
			[Address(RVA = "0x3E17C54", Offset = "0x3E17C54", Length = "0x8")]
			get;
			[Token(Token = "0x600263B")]
			[Address(RVA = "0x3E17C5C", Offset = "0x3E17C5C", Length = "0x8")]
			set;
		}

		[JsonProperty("target_player_name")]
		[Token(Token = "0x170003F8")]
		[field: Token(Token = "0x4001E61")]
		[field: FieldOffset(Offset = "0x30")]
		public string TargetPlayerName
		{
			[Token(Token = "0x600263C")]
			[Address(RVA = "0x3E17C64", Offset = "0x3E17C64", Length = "0x8")]
			get;
			[Token(Token = "0x600263D")]
			[Address(RVA = "0x3E17C6C", Offset = "0x3E17C6C", Length = "0x8")]
			set;
		}

		[JsonProperty("target_profile_picture")]
		[Token(Token = "0x170003F9")]
		[field: Token(Token = "0x4001E62")]
		[field: FieldOffset(Offset = "0x38")]
		public string TargetProfilePicture
		{
			[Token(Token = "0x600263E")]
			[Address(RVA = "0x3E17C74", Offset = "0x3E17C74", Length = "0x8")]
			get;
			[Token(Token = "0x600263F")]
			[Address(RVA = "0x3E17C7C", Offset = "0x3E17C7C", Length = "0x8")]
			set;
		}

		[Token(Token = "0x6002640")]
		[Address(RVA = "0x3E17C84", Offset = "0x3E17C84", Length = "0x8")]
		public JoinRejectData()
		{
		}
	}
}
