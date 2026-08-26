namespace ICSharpCode.NRefactory.MonoCSharp.yyParser
{
	internal interface yyInput
	{
		bool advance();

		int token();

		object value();
	}
}
