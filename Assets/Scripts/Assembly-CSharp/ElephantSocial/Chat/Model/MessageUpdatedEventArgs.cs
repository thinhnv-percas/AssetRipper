using System;
using Cpp2ILInjected;

namespace ElephantSocial.Chat.Model
{
	[Token(Token = "0x200091B")]
	public class MessageUpdatedEventArgs : EventArgs
	{
		[Token(Token = "0x17000412")]
		[field: Token(Token = "0x4001E84")]
		[field: FieldOffset(Offset = "0x10")]
		public string ChannelId
		{
			[Token(Token = "0x600267A")]
			[Address(RVA = "0x3E18154", Offset = "0x3E18154", Length = "0x8")]
			get;
			[Token(Token = "0x600267B")]
			[Address(RVA = "0x3E1815C", Offset = "0x3E1815C", Length = "0x8")]
			set;
		}

		[Token(Token = "0x17000413")]
		[field: Token(Token = "0x4001E85")]
		[field: FieldOffset(Offset = "0x18")]
		public MessageContentPayload Message
		{
			[Token(Token = "0x600267C")]
			[Address(RVA = "0x3E18164", Offset = "0x3E18164", Length = "0x8")]
			get;
			[Token(Token = "0x600267D")]
			[Address(RVA = "0x3E1816C", Offset = "0x3E1816C", Length = "0x8")]
			set;
		}

		[Token(Token = "0x600267E")]
		[Address(RVA = "0x3E18174", Offset = "0x3E18174", Length = "0x88")]
		public MessageUpdatedEventArgs()
		{
		}
	}
}
