namespace ICSharpCode.NRefactory.MonoCSharp
{
	public interface ILiteralConstant
	{
		char[] ParsedValue
		{
			get;
			set;
		}
	}
}
