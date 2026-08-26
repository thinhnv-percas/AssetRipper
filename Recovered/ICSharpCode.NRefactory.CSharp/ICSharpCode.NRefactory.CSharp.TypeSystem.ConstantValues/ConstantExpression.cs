using ICSharpCode.NRefactory.CSharp.Resolver;
using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;
using System;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.CSharp.TypeSystem.ConstantValues
{
	[Serializable]
	public abstract class ConstantExpression : IConstantValue
	{
		public abstract ResolveResult Resolve(CSharpResolver resolver);

		public ResolveResult Resolve(ITypeResolveContext context)
		{
			CSharpTypeResolveContext context2 = (CSharpTypeResolveContext)context;
			if (context.CurrentAssembly != context.Compilation.MainAssembly)
			{
				IProjectContent projectContent = context.CurrentAssembly as IProjectContent;
				if (projectContent != null)
				{
					ICompilation compilation = context.Compilation.SolutionSnapshot.GetCompilation(projectContent);
					if (compilation != null)
					{
						CSharpTypeResolveContext context3 = MapToNestedCompilation(context2, compilation);
						return MapToNewContext(Resolve(new CSharpResolver(context3)), context);
					}
				}
			}
			return Resolve(new CSharpResolver(context2));
		}

		private CSharpTypeResolveContext MapToNestedCompilation(CSharpTypeResolveContext context, ICompilation nestedCompilation)
		{
			CSharpTypeResolveContext cSharpTypeResolveContext = new CSharpTypeResolveContext(nestedCompilation.MainAssembly);
			if (context.CurrentUsingScope != null)
			{
				cSharpTypeResolveContext = cSharpTypeResolveContext.WithUsingScope(context.CurrentUsingScope.UnresolvedUsingScope.Resolve(nestedCompilation));
			}
			if (context.CurrentTypeDefinition != null)
			{
				cSharpTypeResolveContext = cSharpTypeResolveContext.WithCurrentTypeDefinition(nestedCompilation.Import(context.CurrentTypeDefinition));
			}
			return cSharpTypeResolveContext;
		}

		private static ResolveResult MapToNewContext(ResolveResult rr, ITypeResolveContext newContext)
		{
			if (rr is TypeOfResolveResult)
			{
				return new TypeOfResolveResult(rr.Type.ToTypeReference().Resolve(newContext), ((TypeOfResolveResult)rr).ReferencedType.ToTypeReference().Resolve(newContext));
			}
			if (rr is ArrayCreateResolveResult)
			{
				ArrayCreateResolveResult arrayCreateResolveResult = (ArrayCreateResolveResult)rr;
				return new ArrayCreateResolveResult(arrayCreateResolveResult.Type.ToTypeReference().Resolve(newContext), MapToNewContext(arrayCreateResolveResult.SizeArguments, newContext), MapToNewContext(arrayCreateResolveResult.InitializerElements, newContext));
			}
			if (rr.IsCompileTimeConstant)
			{
				return new ConstantResolveResult(rr.Type.ToTypeReference().Resolve(newContext), rr.ConstantValue);
			}
			return new ErrorResolveResult(rr.Type.ToTypeReference().Resolve(newContext));
		}

		private static ResolveResult[] MapToNewContext(IList<ResolveResult> input, ITypeResolveContext newContext)
		{
			if (input == null)
			{
				return null;
			}
			ResolveResult[] array = new ResolveResult[input.Count];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = MapToNewContext(input[i], newContext);
			}
			return array;
		}
	}
}
