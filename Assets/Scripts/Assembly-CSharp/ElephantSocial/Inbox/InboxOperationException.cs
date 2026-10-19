using System;
using Cpp2ILInjected;

namespace ElephantSocial.Inbox
{
	[Token(Token = "0x20008E9")]
	public class InboxOperationException : Exception
	{
		[Token(Token = "0x600258D")]
		[Address(RVA = "0x3E07F94", Offset = "0x3E07F94", Length = "0x6C")]
		public InboxOperationException(string message)
			: base(message)
		{
		}

		[Token(Token = "0x600258E")]
		[Address(RVA = "0x3E0790C", Offset = "0x3E0790C", Length = "0x7C")]
		public InboxOperationException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
