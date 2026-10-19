using System;
using Cpp2ILInjected;

namespace ElephantSocial.Core
{
	[Token(Token = "0x20008F8")]
	public class ElephantSocialException : Exception
	{
		[Token(Token = "0x60025BC")]
		[Address(RVA = "0x3E09068", Offset = "0x3E09068", Length = "0x6C")]
		public ElephantSocialException(string message)
			: base(message)
		{
		}

		[Token(Token = "0x60025BD")]
		[Address(RVA = "0x3E090D4", Offset = "0x3E090D4", Length = "0x7C")]
		public ElephantSocialException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}
