namespace DecompTools.Decompiler.CSharp.Syntax;

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

	public static bool IsBitwise(this BinaryOperatorType operatorType)
	{
		return operatorType == BinaryOperatorType.BitwiseAnd || operatorType == BinaryOperatorType.BitwiseOr || operatorType == BinaryOperatorType.ExclusiveOr;
	}

	public static Statement GetNextStatement(this Statement statement)
	{
		AstNode nextSibling = statement.NextSibling;
		while (nextSibling != null && !(nextSibling is Statement))
		{
			nextSibling = nextSibling.NextSibling;
		}
		return (Statement)nextSibling;
	}

	public static bool IsArgList(this AstType type)
	{
		return type is SimpleType simpleType && simpleType.Identifier == "__arglist";
	}

	public static void AddNamedArgument(this Attribute attribute, string name, Expression argument)
	{
		attribute.Arguments.Add(new AssignmentExpression(new IdentifierExpression(name), argument));
	}

	public static T Detach<T>(this T node) where T : AstNode
	{
		node.Remove();
		return node;
	}
}
