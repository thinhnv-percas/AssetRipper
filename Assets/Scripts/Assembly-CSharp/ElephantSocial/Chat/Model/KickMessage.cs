using Cpp2ILInjected;

namespace ElephantSocial.Chat.Model
{
	[Token(Token = "0x2000922")]
	public class KickMessage : ChatMessage
	{
		[Token(Token = "0x1700042E")]
		[field: Token(Token = "0x4001EA0")]
		[field: FieldOffset(Offset = "0x38")]
		public string SocialId
		{
			[Token(Token = "0x60026BA")]
			[Address(RVA = "0x3E1842C", Offset = "0x3E1842C", Length = "0x8")]
			get;
			[Token(Token = "0x60026BB")]
			[Address(RVA = "0x3E18434", Offset = "0x3E18434", Length = "0x8")]
			set;
		}

		[Token(Token = "0x1700042F")]
		[field: Token(Token = "0x4001EA1")]
		[field: FieldOffset(Offset = "0x40")]
		public string PlayerName
		{
			[Token(Token = "0x60026BC")]
			[Address(RVA = "0x3E1843C", Offset = "0x3E1843C", Length = "0x8")]
			get;
			[Token(Token = "0x60026BD")]
			[Address(RVA = "0x3E18444", Offset = "0x3E18444", Length = "0x8")]
			set;
		}

		[Token(Token = "0x17000430")]
		[field: Token(Token = "0x4001EA2")]
		[field: FieldOffset(Offset = "0x48")]
		public string ProfilePicture
		{
			[Token(Token = "0x60026BE")]
			[Address(RVA = "0x3E1844C", Offset = "0x3E1844C", Length = "0x8")]
			get;
			[Token(Token = "0x60026BF")]
			[Address(RVA = "0x3E18454", Offset = "0x3E18454", Length = "0x8")]
			set;
		}

		[Token(Token = "0x17000431")]
		[field: Token(Token = "0x4001EA3")]
		[field: FieldOffset(Offset = "0x50")]
		public string TargetSocialId
		{
			[Token(Token = "0x60026C0")]
			[Address(RVA = "0x3E1845C", Offset = "0x3E1845C", Length = "0x8")]
			get;
			[Token(Token = "0x60026C1")]
			[Address(RVA = "0x3E18464", Offset = "0x3E18464", Length = "0x8")]
			set;
		}

		[Token(Token = "0x17000432")]
		[field: Token(Token = "0x4001EA4")]
		[field: FieldOffset(Offset = "0x58")]
		public string TargetPlayerName
		{
			[Token(Token = "0x60026C2")]
			[Address(RVA = "0x3E1846C", Offset = "0x3E1846C", Length = "0x8")]
			get;
			[Token(Token = "0x60026C3")]
			[Address(RVA = "0x3E18474", Offset = "0x3E18474", Length = "0x8")]
			set;
		}

		[Token(Token = "0x17000433")]
		[field: Token(Token = "0x4001EA5")]
		[field: FieldOffset(Offset = "0x60")]
		public string TargetProfilePicture
		{
			[Token(Token = "0x60026C4")]
			[Address(RVA = "0x3E1847C", Offset = "0x3E1847C", Length = "0x8")]
			get;
			[Token(Token = "0x60026C5")]
			[Address(RVA = "0x3E18484", Offset = "0x3E18484", Length = "0x8")]
			set;
		}

		[Token(Token = "0x60026C6")]
		[Address(RVA = "0x3E0F2EC", Offset = "0x3E0F2EC", Length = "0x2C")]
		public KickMessage()
		{
			Type = ChatMessageType.KICK;
		}
	}
}
