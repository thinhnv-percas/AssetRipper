using ICSharpCode.NRefactory.CSharp;
using System;

namespace ICSharpCode.Decompiler.Ast.Transforms
{
	public static class TransformationPipeline
	{
		public static IAstTransform[] CreatePipeline(DecompilerContext context)
		{
			return new IAstTransform[14]
			{
				new PushNegation(),
				new DelegateConstruction(context),
				new PatternStatementTransform(context),
				new ReplaceMethodCallsWithOperators(context),
				new IntroduceUnsafeModifier(),
				new AddCheckedBlocks(),
				new DeclareVariables(context),
				new ConvertConstructorCallIntoInitializer(),
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
			IAstTransform[] array = CreatePipeline(context);
			foreach (IAstTransform astTransform in array)
			{
				context.CancellationToken.ThrowIfCancellationRequested();
				if (abortCondition != null && abortCondition(astTransform))
				{
					break;
				}
				astTransform.Run(node);
			}
		}
	}
}
