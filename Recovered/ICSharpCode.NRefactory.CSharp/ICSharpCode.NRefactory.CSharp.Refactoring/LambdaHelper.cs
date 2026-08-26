using ICSharpCode.NRefactory.CSharp.Resolver;
using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.CSharp.Refactoring
{
	public class LambdaHelper
	{
		public static IType GetLambdaReturnType(RefactoringContext context, LambdaExpression lambda)
		{
			LambdaResolveResult lambdaResolveResult = context.Resolve(lambda) as LambdaResolveResult;
			if (lambdaResolveResult == null)
			{
				return SpecialType.UnknownType;
			}
			if (lambdaResolveResult.IsAsync)
			{
				if (lambdaResolveResult.ReturnType.IsKnownType(KnownTypeCode.Task))
				{
					return context.Compilation.FindType(KnownTypeCode.Void);
				}
				if (lambdaResolveResult.ReturnType.IsKnownType(KnownTypeCode.TaskOfT) && lambdaResolveResult.ReturnType.IsParameterized)
				{
					return lambdaResolveResult.ReturnType.TypeArguments[0];
				}
			}
			return lambdaResolveResult.ReturnType;
		}
	}
}
