using System;
using Cpp2ILInjected;

namespace ElephantSocial.Core
{
	[Token(Token = "0x20008FA")]
	public class TeamOperationException : ElephantSocialException
	{
		[Token(Token = "0x60025C0")]
		[Address(RVA = "0x3E09238", Offset = "0x3E09238", Length = "0x6C")]
		public TeamOperationException(string message)
			: base(message)
		{
		}

		[Token(Token = "0x60025C1")]
		[Address(RVA = "0x3E092A4", Offset = "0x3E092A4", Length = "0x7C")]
		public TeamOperationException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}
