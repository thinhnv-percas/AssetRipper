using System;
using Cpp2ILInjected;

namespace ElephantSocial.Chat.Model
{
	[Token(Token = "0x200091A")]
	public class MessageDeletedEventArgs : EventArgs
	{
		[Token(Token = "0x17000410")]
		[field: Token(Token = "0x4001E82")]
		[field: FieldOffset(Offset = "0x10")]
		public string ChannelId
		{
			[Token(Token = "0x6002675")]
			[Address(RVA = "0x3E180AC", Offset = "0x3E180AC", Length = "0x8")]
			get;
			[Token(Token = "0x6002676")]
			[Address(RVA = "0x3E180B4", Offset = "0x3E180B4", Length = "0x8")]
			set;
		}

		[Token(Token = "0x17000411")]
		[field: Token(Token = "0x4001E83")]
		[field: FieldOffset(Offset = "0x18")]
		public DeletedMessagePayload DeletionInfo
		{
			[Token(Token = "0x6002677")]
			[Address(RVA = "0x3E180BC", Offset = "0x3E180BC", Length = "0x8")]
			get;
			[Token(Token = "0x6002678")]
			[Address(RVA = "0x3E180C4", Offset = "0x3E180C4", Length = "0x8")]
			set;
		}

		[Token(Token = "0x6002679")]
		[Address(RVA = "0x3E180CC", Offset = "0x3E180CC", Length = "0x88")]
		public MessageDeletedEventArgs()
		{
		}
	}
}
