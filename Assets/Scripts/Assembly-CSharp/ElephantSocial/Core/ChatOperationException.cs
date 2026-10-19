using System;
using Cpp2ILInjected;

namespace ElephantSocial.Core
{
	[Token(Token = "0x20008FB")]
	public class ChatOperationException : ElephantSocialException
	{
		[Token(Token = "0x60025C2")]
		[Address(RVA = "0x3E09320", Offset = "0x3E09320", Length = "0x6C")]
		public ChatOperationException(string message)
			: base(message)
		{
		}

		[Token(Token = "0x60025C3")]
		[Address(RVA = "0x3E0938C", Offset = "0x3E0938C", Length = "0x7C")]
		public ChatOperationException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}
