using Cpp2ILInjected;

namespace ElephantSocial.Chat.Model
{
	[Token(Token = "0x2000920")]
	public class JoinRejectMessage : ChatMessage
	{
		[Token(Token = "0x17000425")]
		[field: Token(Token = "0x4001E97")]
		[field: FieldOffset(Offset = "0x38")]
		public string SocialId
		{
			[Token(Token = "0x60026A6")]
			[Address(RVA = "0x3E1839C", Offset = "0x3E1839C", Length = "0x8")]
			get;
			[Token(Token = "0x60026A7")]
			[Address(RVA = "0x3E183A4", Offset = "0x3E183A4", Length = "0x8")]
			set;
		}

		[Token(Token = "0x17000426")]
		[field: Token(Token = "0x4001E98")]
		[field: FieldOffset(Offset = "0x40")]
		public string PlayerName
		{
			[Token(Token = "0x60026A8")]
			[Address(RVA = "0x3E183AC", Offset = "0x3E183AC", Length = "0x8")]
			get;
			[Token(Token = "0x60026A9")]
			[Address(RVA = "0x3E183B4", Offset = "0x3E183B4", Length = "0x8")]
			set;
		}

		[Token(Token = "0x17000427")]
		[field: Token(Token = "0x4001E99")]
		[field: FieldOffset(Offset = "0x48")]
		public string ProfilePicture
		{
			[Token(Token = "0x60026AA")]
			[Address(RVA = "0x3E183BC", Offset = "0x3E183BC", Length = "0x8")]
			get;
			[Token(Token = "0x60026AB")]
			[Address(RVA = "0x3E183C4", Offset = "0x3E183C4", Length = "0x8")]
			set;
		}

		[Token(Token = "0x17000428")]
		[field: Token(Token = "0x4001E9A")]
		[field: FieldOffset(Offset = "0x50")]
		public string TargetSocialId
		{
			[Token(Token = "0x60026AC")]
			[Address(RVA = "0x3E183CC", Offset = "0x3E183CC", Length = "0x8")]
			get;
			[Token(Token = "0x60026AD")]
			[Address(RVA = "0x3E183D4", Offset = "0x3E183D4", Length = "0x8")]
			set;
		}

		[Token(Token = "0x17000429")]
		[field: Token(Token = "0x4001E9B")]
		[field: FieldOffset(Offset = "0x58")]
		public string TargetPlayerName
		{
			[Token(Token = "0x60026AE")]
			[Address(RVA = "0x3E183DC", Offset = "0x3E183DC", Length = "0x8")]
			get;
			[Token(Token = "0x60026AF")]
			[Address(RVA = "0x3E183E4", Offset = "0x3E183E4", Length = "0x8")]
			set;
		}

		[Token(Token = "0x1700042A")]
		[field: Token(Token = "0x4001E9C")]
		[field: FieldOffset(Offset = "0x60")]
		public string TargetProfilePicture
		{
			[Token(Token = "0x60026B0")]
			[Address(RVA = "0x3E183EC", Offset = "0x3E183EC", Length = "0x8")]
			get;
			[Token(Token = "0x60026B1")]
			[Address(RVA = "0x3E183F4", Offset = "0x3E183F4", Length = "0x8")]
			set;
		}

		[Token(Token = "0x60026B2")]
		[Address(RVA = "0x3E0F2C0", Offset = "0x3E0F2C0", Length = "0x2C")]
		public JoinRejectMessage()
		{
			Type = ChatMessageType.JOIN_REJECT;
		}
	}
}
