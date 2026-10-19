using System;
using Cpp2ILInjected;

namespace ElephantSocial.Chat.Model
{
	[Token(Token = "0x2000919")]
	public class MessageCreatedEventArgs : EventArgs
	{
		[Token(Token = "0x1700040E")]
		[field: Token(Token = "0x4001E80")]
		[field: FieldOffset(Offset = "0x10")]
		public string ChannelId
		{
			[Token(Token = "0x6002670")]
			[Address(RVA = "0x3E18004", Offset = "0x3E18004", Length = "0x8")]
			get;
			[Token(Token = "0x6002671")]
			[Address(RVA = "0x3E1800C", Offset = "0x3E1800C", Length = "0x8")]
			set;
		}

		[Token(Token = "0x1700040F")]
		[field: Token(Token = "0x4001E81")]
		[field: FieldOffset(Offset = "0x18")]
		public MessageContentPayload Message
		{
			[Token(Token = "0x6002672")]
			[Address(RVA = "0x3E18014", Offset = "0x3E18014", Length = "0x8")]
			get;
			[Token(Token = "0x6002673")]
			[Address(RVA = "0x3E1801C", Offset = "0x3E1801C", Length = "0x8")]
			set;
		}

		[Token(Token = "0x6002674")]
		[Address(RVA = "0x3E18024", Offset = "0x3E18024", Length = "0x88")]
		public MessageCreatedEventArgs()
		{
		}
	}
}
