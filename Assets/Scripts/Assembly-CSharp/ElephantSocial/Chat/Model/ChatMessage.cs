using Cpp2ILInjected;
using ElephantSocial.Team;

namespace ElephantSocial.Chat.Model
{
	[Token(Token = "0x200091D")]
	public abstract class ChatMessage
	{
		[Token(Token = "0x17000416")]
		[field: Token(Token = "0x4001E88")]
		[field: FieldOffset(Offset = "0x10")]
		public string ID
		{
			[Token(Token = "0x6002684")]
			[Address(RVA = "0x3E182A4", Offset = "0x3E182A4", Length = "0x8")]
			get;
			[Token(Token = "0x6002685")]
			[Address(RVA = "0x3E182AC", Offset = "0x3E182AC", Length = "0x8")]
			set;
		}

		[Token(Token = "0x17000417")]
		[field: Token(Token = "0x4001E89")]
		[field: FieldOffset(Offset = "0x18")]
		public TeamMember Sender
		{
			[Token(Token = "0x6002686")]
			[Address(RVA = "0x3E182B4", Offset = "0x3E182B4", Length = "0x8")]
			get;
			[Token(Token = "0x6002687")]
			[Address(RVA = "0x3E182BC", Offset = "0x3E182BC", Length = "0x8")]
			set;
		}

		[Token(Token = "0x17000418")]
		[field: Token(Token = "0x4001E8A")]
		[field: FieldOffset(Offset = "0x20")]
		public ChatMessageType Type
		{
			[Token(Token = "0x6002688")]
			[Address(RVA = "0x3E182C4", Offset = "0x3E182C4", Length = "0x8")]
			get;
			[Token(Token = "0x6002689")]
			[Address(RVA = "0x3E182CC", Offset = "0x3E182CC", Length = "0x8")]
			set;
		}

		[Token(Token = "0x17000419")]
		[field: Token(Token = "0x4001E8B")]
		[field: FieldOffset(Offset = "0x28")]
		public long CreatedAt
		{
			[Token(Token = "0x600268A")]
			[Address(RVA = "0x3E182D4", Offset = "0x3E182D4", Length = "0x8")]
			get;
			[Token(Token = "0x600268B")]
			[Address(RVA = "0x3E182DC", Offset = "0x3E182DC", Length = "0x8")]
			set;
		}

		[Token(Token = "0x1700041A")]
		[field: Token(Token = "0x4001E8C")]
		[field: FieldOffset(Offset = "0x30")]
		public long UpdatedAt
		{
			[Token(Token = "0x600268C")]
			[Address(RVA = "0x3E182E4", Offset = "0x3E182E4", Length = "0x8")]
			get;
			[Token(Token = "0x600268D")]
			[Address(RVA = "0x3E182EC", Offset = "0x3E182EC", Length = "0x8")]
			set;
		}

		[Token(Token = "0x600268E")]
		[Address(RVA = "0x3E182F4", Offset = "0x3E182F4", Length = "0x8")]
		protected internal ChatMessage()
		{
		}
	}
}
