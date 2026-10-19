using Cpp2ILInjected;

namespace ElephantSocial.Chat.Model
{
	[Token(Token = "0x2000924")]
	public class TextMessage : ChatMessage
	{
		[Token(Token = "0x17000437")]
		[field: Token(Token = "0x4001EA9")]
		[field: FieldOffset(Offset = "0x38")]
		public string Text
		{
			[Token(Token = "0x60026CE")]
			[Address(RVA = "0x3E184BC", Offset = "0x3E184BC", Length = "0x8")]
			get;
			[Token(Token = "0x60026CF")]
			[Address(RVA = "0x3E184C4", Offset = "0x3E184C4", Length = "0x8")]
			set;
		}

		[Token(Token = "0x60026D0")]
		[Address(RVA = "0x3E0F0F4", Offset = "0x3E0F0F4", Length = "0x28")]
		public TextMessage()
		{
			Type = default(ChatMessageType);
		}
	}
}
