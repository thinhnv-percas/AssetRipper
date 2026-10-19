using Cpp2ILInjected;

namespace ElephantSocial.Chat.Model
{
	[Token(Token = "0x200091F")]
	public class JoinAcceptMessage : ChatMessage
	{
		[Token(Token = "0x1700041F")]
		[field: Token(Token = "0x4001E91")]
		[field: FieldOffset(Offset = "0x38")]
		public string SocialId
		{
			[Token(Token = "0x6002699")]
			[Address(RVA = "0x3E1833C", Offset = "0x3E1833C", Length = "0x8")]
			get;
			[Token(Token = "0x600269A")]
			[Address(RVA = "0x3E18344", Offset = "0x3E18344", Length = "0x8")]
			set;
		}

		[Token(Token = "0x17000420")]
		[field: Token(Token = "0x4001E92")]
		[field: FieldOffset(Offset = "0x40")]
		public string PlayerName
		{
			[Token(Token = "0x600269B")]
			[Address(RVA = "0x3E1834C", Offset = "0x3E1834C", Length = "0x8")]
			get;
			[Token(Token = "0x600269C")]
			[Address(RVA = "0x3E18354", Offset = "0x3E18354", Length = "0x8")]
			set;
		}

		[Token(Token = "0x17000421")]
		[field: Token(Token = "0x4001E93")]
		[field: FieldOffset(Offset = "0x48")]
		public string ProfilePicture
		{
			[Token(Token = "0x600269D")]
			[Address(RVA = "0x3E1835C", Offset = "0x3E1835C", Length = "0x8")]
			get;
			[Token(Token = "0x600269E")]
			[Address(RVA = "0x3E18364", Offset = "0x3E18364", Length = "0x8")]
			set;
		}

		[Token(Token = "0x17000422")]
		[field: Token(Token = "0x4001E94")]
		[field: FieldOffset(Offset = "0x50")]
		public string TargetSocialId
		{
			[Token(Token = "0x600269F")]
			[Address(RVA = "0x3E1836C", Offset = "0x3E1836C", Length = "0x8")]
			get;
			[Token(Token = "0x60026A0")]
			[Address(RVA = "0x3E18374", Offset = "0x3E18374", Length = "0x8")]
			set;
		}

		[Token(Token = "0x17000423")]
		[field: Token(Token = "0x4001E95")]
		[field: FieldOffset(Offset = "0x58")]
		public string TargetPlayerName
		{
			[Token(Token = "0x60026A1")]
			[Address(RVA = "0x3E1837C", Offset = "0x3E1837C", Length = "0x8")]
			get;
			[Token(Token = "0x60026A2")]
			[Address(RVA = "0x3E18384", Offset = "0x3E18384", Length = "0x8")]
			set;
		}

		[Token(Token = "0x17000424")]
		[field: Token(Token = "0x4001E96")]
		[field: FieldOffset(Offset = "0x60")]
		public string TargetProfilePicture
		{
			[Token(Token = "0x60026A3")]
			[Address(RVA = "0x3E1838C", Offset = "0x3E1838C", Length = "0x8")]
			get;
			[Token(Token = "0x60026A4")]
			[Address(RVA = "0x3E18394", Offset = "0x3E18394", Length = "0x8")]
			set;
		}

		[Token(Token = "0x60026A5")]
		[Address(RVA = "0x3E0F294", Offset = "0x3E0F294", Length = "0x2C")]
		public JoinAcceptMessage()
		{
			Type = ChatMessageType.JOIN_ACCEPT;
		}
	}
}
