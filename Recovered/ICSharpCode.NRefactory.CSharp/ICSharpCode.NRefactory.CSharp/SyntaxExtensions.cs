namespace ICSharpCode.NRefactory.CSharp
{
	public static class SyntaxExtensions
	{
		public static bool IsComparisonOperator(this OperatorType operatorType)
		{
			switch (operatorType)
			{
			case OperatorType.Equality:
			case OperatorType.Inequality:
			case OperatorType.GreaterThan:
			case OperatorType.LessThan:
			case OperatorType.GreaterThanOrEqual:
			case OperatorType.LessThanOrEqual:
				return true;
			default:
				return false;
			}
		}
	}
}
