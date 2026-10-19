using System;
using Cpp2ILInjected;

namespace ElephantSocial.Chat.Model
{
	[Token(Token = "0x2000918")]
	public class MessageAcknowledgedEventArgs : EventArgs
	{
		[Token(Token = "0x1700040C")]
		[field: Token(Token = "0x4001E7E")]
		[field: FieldOffset(Offset = "0x10")]
		public string ChannelId
		{
			[Token(Token = "0x600266B")]
			[Address(RVA = "0x3E17F5C", Offset = "0x3E17F5C", Length = "0x8")]
			get;
			[Token(Token = "0x600266C")]
			[Address(RVA = "0x3E17F64", Offset = "0x3E17F64", Length = "0x8")]
			set;
		}

		[Token(Token = "0x1700040D")]
		[field: Token(Token = "0x4001E7F")]
		[field: FieldOffset(Offset = "0x18")]
		public AckPayloadWrapper AckInfo
		{
			[Token(Token = "0x600266D")]
			[Address(RVA = "0x3E17F6C", Offset = "0x3E17F6C", Length = "0x8")]
			get;
			[Token(Token = "0x600266E")]
			[Address(RVA = "0x3E17F74", Offset = "0x3E17F74", Length = "0x8")]
			set;
		}

		[Token(Token = "0x600266F")]
		[Address(RVA = "0x3E17F7C", Offset = "0x3E17F7C", Length = "0x88")]
		public MessageAcknowledgedEventArgs()
		{
		}
	}
}
