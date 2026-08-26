using System.Collections.Generic;
using System.Linq;
using System.Text;
using dnlib.DotNet;
using dnSpy.Contracts.Decompiler;
using ICSharpCode.NRefactory.CSharp;

namespace ICSharpCode.Decompiler.Ast.Transforms;

public class IntroduceExtensionMethods : IAstTransformPoolObject, IAstTransform
{
	private readonly StringBuilder stringBuilder;

	private static readonly UTF8String systemRuntimeCompilerServicesString = new UTF8String("System.Runtime.CompilerServices");

	private static readonly UTF8String extensionAttributeString = new UTF8String("ExtensionAttribute");

	public IntroduceExtensionMethods(DecompilerContext context)
	{
		stringBuilder = new StringBuilder();
		Reset(context);
	}

	public void Reset(DecompilerContext context)
	{
	}

	public void Run(AstNode compilationUnit)
	{
		foreach (InvocationExpression item in compilationUnit.Descendants.OfType<InvocationExpression>())
		{
			MemberReferenceExpression memberReferenceExpression = item.Target as MemberReferenceExpression;
			IMethod method = item.Annotation<IMethod>();
			if (memberReferenceExpression == null || !(memberReferenceExpression.Target is TypeReferenceExpression) || method == null || !item.Arguments.Any())
			{
				continue;
			}
			MethodDef d = method.Resolve();
			if (d == null || !d.IsDefined(systemRuntimeCompilerServicesString, extensionAttributeString))
			{
				continue;
			}
			Expression expression = item.Arguments.First();
			if (expression is NullReferenceExpression)
			{
				expression = expression.ReplaceWith((Expression expr) => expr.CastTo(AstBuilder.ConvertType(d.Parameters.SkipNonNormal().First().Type, stringBuilder)));
			}
			else
			{
				List<ILSpan> allRecursiveILSpans = memberReferenceExpression.Target.GetAllRecursiveILSpans();
				memberReferenceExpression.Target = expression.Detach();
				if (allRecursiveILSpans.Count > 0)
				{
					memberReferenceExpression.Target.AddAnnotation(allRecursiveILSpans);
				}
			}
			if (item.Arguments.Any())
			{
				List<ILSpan> allRecursiveILSpans2 = memberReferenceExpression.TypeArguments.GetAllRecursiveILSpans();
				memberReferenceExpression.TypeArguments.Clear();
				if (allRecursiveILSpans2.Count > 0)
				{
					memberReferenceExpression.AddAnnotation(allRecursiveILSpans2);
				}
			}
		}
	}
}
