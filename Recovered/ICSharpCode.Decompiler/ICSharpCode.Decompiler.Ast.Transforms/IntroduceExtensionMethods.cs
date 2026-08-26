using ICSharpCode.NRefactory.CSharp;
using Mono.Cecil;
using System.Linq;

namespace ICSharpCode.Decompiler.Ast.Transforms
{
	public class IntroduceExtensionMethods : IAstTransform
	{
		private readonly DecompilerContext context;

		public IntroduceExtensionMethods(DecompilerContext context)
		{
			this.context = context;
		}

		public void Run(AstNode compilationUnit)
		{
			foreach (InvocationExpression item in compilationUnit.Descendants.OfType<InvocationExpression>())
			{
				MemberReferenceExpression memberReferenceExpression = item.Target as MemberReferenceExpression;
				MethodReference methodReference = item.Annotation<MethodReference>();
				if (memberReferenceExpression != null && memberReferenceExpression.Target is TypeReferenceExpression && methodReference != null && item.Arguments.Any())
				{
					MethodDefinition d = methodReference.Resolve();
					if (d != null)
					{
						foreach (CustomAttribute customAttribute in d.CustomAttributes)
						{
							if (customAttribute.AttributeType.Name == "ExtensionAttribute" && customAttribute.AttributeType.Namespace == "System.Runtime.CompilerServices")
							{
								Expression expression = item.Arguments.First();
								if (expression is NullReferenceExpression)
								{
									expression = expression.ReplaceWith((Expression expr) => expr.CastTo(AstBuilder.ConvertType(d.Parameters.First().ParameterType)));
								}
								else
								{
									memberReferenceExpression.Target = expression.Detach();
								}
								if (item.Arguments.Any())
								{
									memberReferenceExpression.TypeArguments.Clear();
								}
								break;
							}
						}
					}
				}
			}
		}
	}
}
