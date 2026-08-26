using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.Decompiler.Ast
{
	internal static class NRefactoryExtensions
	{
		public static T WithAnnotation<T>(this T node, object annotation) where T : AstNode
		{
			if (annotation != null)
			{
				node.AddAnnotation(annotation);
			}
			return node;
		}

		public static T CopyAnnotationsFrom<T>(this T node, AstNode other) where T : AstNode
		{
			foreach (object annotation in other.Annotations)
			{
				node.AddAnnotation(annotation);
			}
			return node;
		}

		public static T Detach<T>(this T node) where T : AstNode
		{
			node.Remove();
			return node;
		}

		public static Expression WithName(this Expression node, string patternGroupName)
		{
			return new NamedNode(patternGroupName, node);
		}

		public static Statement WithName(this Statement node, string patternGroupName)
		{
			return new NamedNode(patternGroupName, node);
		}

		public static void AddNamedArgument(this Attribute attribute, string name, Expression argument)
		{
			attribute.Arguments.Add(new AssignmentExpression(new IdentifierExpression(name), argument));
		}

		public static AstType ToType(this Pattern pattern)
		{
			return pattern;
		}

		public static Expression ToExpression(this Pattern pattern)
		{
			return pattern;
		}

		public static Statement ToStatement(this Pattern pattern)
		{
			return pattern;
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
	}
}
