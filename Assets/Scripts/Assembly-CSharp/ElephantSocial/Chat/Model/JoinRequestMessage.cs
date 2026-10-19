using Cpp2ILInjected;

namespace ElephantSocial.Chat.Model
{
	[Token(Token = "0x2000921")]
	public class JoinRequestMessage : ChatMessage
	{
		[Token(Token = "0x1700042B")]
		[field: Token(Token = "0x4001E9D")]
		[field: FieldOffset(Offset = "0x38")]
		public string RequestingSocialId
		{
			[Token(Token = "0x60026B3")]
			[Address(RVA = "0x3E183FC", Offset = "0x3E183FC", Length = "0x8")]
			get;
			[Token(Token = "0x60026B4")]
			[Address(RVA = "0x3E18404", Offset = "0x3E18404", Length = "0x8")]
			set;
		}

		[Token(Token = "0x1700042C")]
		[field: Token(Token = "0x4001E9E")]
		[field: FieldOffset(Offset = "0x40")]
		public string RequestingPlayerName
		{
			[Token(Token = "0x60026B5")]
			[Address(RVA = "0x3E1840C", Offset = "0x3E1840C", Length = "0x8")]
			get;
			[Token(Token = "0x60026B6")]
			[Address(RVA = "0x3E18414", Offset = "0x3E18414", Length = "0x8")]
			set;
		}

		[Token(Token = "0x1700042D")]
		[field: Token(Token = "0x4001E9F")]
		[field: FieldOffset(Offset = "0x48")]
		public string RequestingProfilePicture
		{
			[Token(Token = "0x60026B7")]
			[Address(RVA = "0x3E1841C", Offset = "0x3E1841C", Length = "0x8")]
			get;
			[Token(Token = "0x60026B8")]
			[Address(RVA = "0x3E18424", Offset = "0x3E18424", Length = "0x8")]
			set;
		}

		[Token(Token = "0x60026B9")]
		[Address(RVA = "0x3E0F268", Offset = "0x3E0F268", Length = "0x2C")]
		public JoinRequestMessage()
		{
			Type = ChatMessageType.JOIN_REQUEST;
		}
	}
}
