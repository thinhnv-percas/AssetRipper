using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp
{
	internal static class NRefactoryExtensions
	{
		public static T Detach<T>(this T node) where T : AstNode
		{
			node.Remove();
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

		public static Expression WithName(this Expression node, string patternGroupName)
		{
			return new NamedNode(patternGroupName, node);
		}
	}
}
