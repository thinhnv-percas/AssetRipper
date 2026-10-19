using System;
using Cpp2ILInjected;

namespace ElephantSocial.Core
{
	[Token(Token = "0x20008F9")]
	public class ConnectionException : ElephantSocialException
	{
		[Token(Token = "0x60025BE")]
		[Address(RVA = "0x3E09150", Offset = "0x3E09150", Length = "0x6C")]
		public ConnectionException(string message)
			: base(message)
		{
		}

		[Token(Token = "0x60025BF")]
		[Address(RVA = "0x3E091BC", Offset = "0x3E091BC", Length = "0x7C")]
		public ConnectionException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}
