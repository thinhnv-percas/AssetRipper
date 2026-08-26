namespace ICSharpCode.NRefactory.CSharp;

public static class SyntaxExtensions
{
	public static bool IsComparisonOperator(this OperatorType operatorType)
	{
		if ((uint)(operatorType - 18) <= 5u)
		{
			return true;
		}
		return false;
	}
}
