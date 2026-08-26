namespace ICSharpCode.NRefactory.MonoCSharp.yyParser
{
	internal class yyUnexpectedEof : yyException
	{
		public yyUnexpectedEof(string message)
			: base(message)
		{
		}

		public yyUnexpectedEof()
			: base("")
		{
		}
	}
}
