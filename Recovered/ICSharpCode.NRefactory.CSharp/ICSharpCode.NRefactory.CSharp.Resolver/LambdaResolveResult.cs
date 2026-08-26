using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.CSharp.Resolver
{
	public abstract class LambdaResolveResult : ResolveResult
	{
		public abstract bool HasParameterList
		{
			get;
		}

		public abstract bool IsAnonymousMethod
		{
			get;
		}

		public abstract bool IsImplicitlyTyped
		{
			get;
		}

		public abstract bool IsAsync
		{
			get;
		}

		public abstract IList<IParameter> Parameters
		{
			get;
		}

		public abstract IType ReturnType
		{
			get;
		}

		public abstract ResolveResult Body
		{
			get;
		}

		protected LambdaResolveResult()
			: base(SpecialType.UnknownType)
		{
		}

		public abstract IType GetInferredReturnType(IType[] parameterTypes);

		public abstract Conversion IsValid(IType[] parameterTypes, IType returnType, CSharpConversions conversions);

		public override IEnumerable<ResolveResult> GetChildResults()
		{
			return new ResolveResult[1]
			{
				Body
			};
		}
	}
}
