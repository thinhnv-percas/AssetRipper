using System;
using Cpp2ILInjected;

namespace ElephantSocial.Chat.Model
{
	[Token(Token = "0x200091C")]
	public class RequestDeniedEventArgs : EventArgs
	{
		[Token(Token = "0x17000414")]
		[field: Token(Token = "0x4001E86")]
		[field: FieldOffset(Offset = "0x10")]
		public string ChannelId
		{
			[Token(Token = "0x600267F")]
			[Address(RVA = "0x3E181FC", Offset = "0x3E181FC", Length = "0x8")]
			get;
			[Token(Token = "0x6002680")]
			[Address(RVA = "0x3E18204", Offset = "0x3E18204", Length = "0x8")]
			set;
		}

		[Token(Token = "0x17000415")]
		[field: Token(Token = "0x4001E87")]
		[field: FieldOffset(Offset = "0x18")]
		public DeniedPayload DenialInfo
		{
			[Token(Token = "0x6002681")]
			[Address(RVA = "0x3E1820C", Offset = "0x3E1820C", Length = "0x8")]
			get;
			[Token(Token = "0x6002682")]
			[Address(RVA = "0x3E18214", Offset = "0x3E18214", Length = "0x8")]
			set;
		}

		[Token(Token = "0x6002683")]
		[Address(RVA = "0x3E1821C", Offset = "0x3E1821C", Length = "0x88")]
		public RequestDeniedEventArgs()
		{
		}
	}
}
