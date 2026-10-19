using System;
using Cpp2ILInjected;

namespace ElephantSocial.Chat.Model
{
	[Token(Token = "0x2000915")]
	public class ConnectionStatusEventArgs : EventArgs
	{
		[Token(Token = "0x17000406")]
		[field: Token(Token = "0x4001E78")]
		[field: FieldOffset(Offset = "0x10")]
		public bool IsConnected
		{
			[Token(Token = "0x600265C")]
			[Address(RVA = "0x3E17D64", Offset = "0x3E17D64", Length = "0x8")]
			get;
			[Token(Token = "0x600265D")]
			[Address(RVA = "0x3E17D6C", Offset = "0x3E17D6C", Length = "0x8")]
			set;
		}

		[Token(Token = "0x17000407")]
		[field: Token(Token = "0x4001E79")]
		[field: FieldOffset(Offset = "0x18")]
		public string Reason
		{
			[Token(Token = "0x600265E")]
			[Address(RVA = "0x3E17D74", Offset = "0x3E17D74", Length = "0x8")]
			get;
			[Token(Token = "0x600265F")]
			[Address(RVA = "0x3E17D7C", Offset = "0x3E17D7C", Length = "0x8")]
			set;
		}

		[Token(Token = "0x6002660")]
		[Address(RVA = "0x3E17D84", Offset = "0x3E17D84", Length = "0x88")]
		public ConnectionStatusEventArgs()
		{
		}
	}
}
