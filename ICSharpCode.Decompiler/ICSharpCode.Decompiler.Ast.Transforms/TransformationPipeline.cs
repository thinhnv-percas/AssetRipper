using System;
using ICSharpCode.NRefactory.CSharp;

namespace ICSharpCode.Decompiler.Ast.Transforms;

public static class TransformationPipeline
{
	public static IAstTransformPoolObject[] CreatePipeline(DecompilerContext context)
	{
		return new IAstTransformPoolObject[14]
		{
			new PushNegation(),
			new DelegateConstruction(context),
			new PatternStatementTransform(context),
			new ReplaceMethodCallsWithOperators(context),
			new IntroduceUnsafeModifier(),
			new AddCheckedBlocks(),
			new DeclareVariables(context),
			new ConvertConstructorCallIntoInitializer(context),
			new DecimalConstantTransform(),
			new IntroduceUsingDeclarations(context),
			new IntroduceExtensionMethods(context),
			new IntroduceQueryExpressions(context),
			new CombineQueryExpressions(context),
			new FlattenSwitchBlocks()
		};
	}

	public static void RunTransformationsUntil(AstNode node, Predicate<IAstTransform> abortCondition, DecompilerContext context)
	{
		if (node == null)
		{
			return;
		}
		IAstTransformPoolObject[] pipelinePool = context.Cache.GetPipelinePool();
		try
		{
			IAstTransformPoolObject[] array = pipelinePool;
			foreach (IAstTransformPoolObject astTransformPoolObject in array)
			{
				astTransformPoolObject.Reset(context);
				context.CancellationToken.ThrowIfCancellationRequested();
				if (abortCondition != null && abortCondition(astTransformPoolObject))
				{
					break;
				}
				astTransformPoolObject.Run(node);
			}
		}
		finally
		{
			context.Cache.Return(pipelinePool);
		}
	}
}
