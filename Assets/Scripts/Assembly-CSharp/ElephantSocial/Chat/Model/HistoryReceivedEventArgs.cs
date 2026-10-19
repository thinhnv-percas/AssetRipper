using System;
using Cpp2ILInjected;

namespace ElephantSocial.Chat.Model
{
	[Token(Token = "0x2000917")]
	public class HistoryReceivedEventArgs : EventArgs
	{
		[Token(Token = "0x1700040A")]
		[field: Token(Token = "0x4001E7C")]
		[field: FieldOffset(Offset = "0x10")]
		public string ChannelId
		{
			[Token(Token = "0x6002666")]
			[Address(RVA = "0x3E17EB4", Offset = "0x3E17EB4", Length = "0x8")]
			get;
			[Token(Token = "0x6002667")]
			[Address(RVA = "0x3E17EBC", Offset = "0x3E17EBC", Length = "0x8")]
			set;
		}

		[Token(Token = "0x1700040B")]
		[field: Token(Token = "0x4001E7D")]
		[field: FieldOffset(Offset = "0x18")]
		public HistoryDeliveredPayload History
		{
			[Token(Token = "0x6002668")]
			[Address(RVA = "0x3E17EC4", Offset = "0x3E17EC4", Length = "0x8")]
			get;
			[Token(Token = "0x6002669")]
			[Address(RVA = "0x3E17ECC", Offset = "0x3E17ECC", Length = "0x8")]
			set;
		}

		[Token(Token = "0x600266A")]
		[Address(RVA = "0x3E17ED4", Offset = "0x3E17ED4", Length = "0x88")]
		public HistoryReceivedEventArgs()
		{
		}
	}
}
