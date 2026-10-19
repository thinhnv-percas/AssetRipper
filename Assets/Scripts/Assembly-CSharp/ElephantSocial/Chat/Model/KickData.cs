using Cpp2ILInjected;
using Newtonsoft.Json;

namespace ElephantSocial.Chat.Model
{
	[Token(Token = "0x2000912")]
	public class KickData
	{
		[JsonProperty("social_id")]
		[Token(Token = "0x170003FD")]
		[field: Token(Token = "0x4001E66")]
		[field: FieldOffset(Offset = "0x10")]
		public string SocialId
		{
			[Token(Token = "0x6002648")]
			[Address(RVA = "0x3E17CC4", Offset = "0x3E17CC4", Length = "0x8")]
			get;
			[Token(Token = "0x6002649")]
			[Address(RVA = "0x3E17CCC", Offset = "0x3E17CCC", Length = "0x8")]
			set;
		}

		[JsonProperty("player_name")]
		[Token(Token = "0x170003FE")]
		[field: Token(Token = "0x4001E67")]
		[field: FieldOffset(Offset = "0x18")]
		public string PlayerName
		{
			[Token(Token = "0x600264A")]
			[Address(RVA = "0x3E17CD4", Offset = "0x3E17CD4", Length = "0x8")]
			get;
			[Token(Token = "0x600264B")]
			[Address(RVA = "0x3E17CDC", Offset = "0x3E17CDC", Length = "0x8")]
			set;
		}

		[JsonProperty("profile_picture")]
		[Token(Token = "0x170003FF")]
		[field: Token(Token = "0x4001E68")]
		[field: FieldOffset(Offset = "0x20")]
		public string ProfilePicture
		{
			[Token(Token = "0x600264C")]
			[Address(RVA = "0x3E17CE4", Offset = "0x3E17CE4", Length = "0x8")]
			get;
			[Token(Token = "0x600264D")]
			[Address(RVA = "0x3E17CEC", Offset = "0x3E17CEC", Length = "0x8")]
			set;
		}

		[JsonProperty("target_social_id")]
		[Token(Token = "0x17000400")]
		[field: Token(Token = "0x4001E69")]
		[field: FieldOffset(Offset = "0x28")]
		public string TargetSocialId
		{
			[Token(Token = "0x600264E")]
			[Address(RVA = "0x3E17CF4", Offset = "0x3E17CF4", Length = "0x8")]
			get;
			[Token(Token = "0x600264F")]
			[Address(RVA = "0x3E17CFC", Offset = "0x3E17CFC", Length = "0x8")]
			set;
		}

		[JsonProperty("target_player_name")]
		[Token(Token = "0x17000401")]
		[field: Token(Token = "0x4001E6A")]
		[field: FieldOffset(Offset = "0x30")]
		public string TargetPlayerName
		{
			[Token(Token = "0x6002650")]
			[Address(RVA = "0x3E17D04", Offset = "0x3E17D04", Length = "0x8")]
			get;
			[Token(Token = "0x6002651")]
			[Address(RVA = "0x3E17D0C", Offset = "0x3E17D0C", Length = "0x8")]
			set;
		}

		[JsonProperty("target_profile_picture")]
		[Token(Token = "0x17000402")]
		[field: Token(Token = "0x4001E6B")]
		[field: FieldOffset(Offset = "0x38")]
		public string TargetProfilePicture
		{
			[Token(Token = "0x6002652")]
			[Address(RVA = "0x3E17D14", Offset = "0x3E17D14", Length = "0x8")]
			get;
			[Token(Token = "0x6002653")]
			[Address(RVA = "0x3E17D1C", Offset = "0x3E17D1C", Length = "0x8")]
			set;
		}

		[Token(Token = "0x6002654")]
		[Address(RVA = "0x3E17D24", Offset = "0x3E17D24", Length = "0x8")]
		public KickData()
		{
		}
	}
}
