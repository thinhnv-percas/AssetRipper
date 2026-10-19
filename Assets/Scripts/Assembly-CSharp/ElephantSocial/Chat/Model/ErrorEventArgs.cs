using System;
using Cpp2ILInjected;

namespace ElephantSocial.Chat.Model
{
	[Token(Token = "0x2000916")]
	public class ErrorEventArgs : EventArgs
	{
		[Token(Token = "0x17000408")]
		[field: Token(Token = "0x4001E7A")]
		[field: FieldOffset(Offset = "0x10")]
		public string Title
		{
			[Token(Token = "0x6002661")]
			[Address(RVA = "0x3E17E0C", Offset = "0x3E17E0C", Length = "0x8")]
			get;
			[Token(Token = "0x6002662")]
			[Address(RVA = "0x3E17E14", Offset = "0x3E17E14", Length = "0x8")]
			set;
		}

		[Token(Token = "0x17000409")]
		[field: Token(Token = "0x4001E7B")]
		[field: FieldOffset(Offset = "0x18")]
		public string Message
		{
			[Token(Token = "0x6002663")]
			[Address(RVA = "0x3E17E1C", Offset = "0x3E17E1C", Length = "0x8")]
			get;
			[Token(Token = "0x6002664")]
			[Address(RVA = "0x3E17E24", Offset = "0x3E17E24", Length = "0x8")]
			set;
		}

		[Token(Token = "0x6002665")]
		[Address(RVA = "0x3E17E2C", Offset = "0x3E17E2C", Length = "0x88")]
		public ErrorEventArgs()
		{
		}
	}
}
