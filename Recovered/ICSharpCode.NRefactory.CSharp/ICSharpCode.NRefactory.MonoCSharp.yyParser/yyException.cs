using System;

namespace ICSharpCode.NRefactory.MonoCSharp.yyParser
{
	internal class yyException : Exception
	{
		public yyException(string message)
			: base(message)
		{
		}
	}
}
