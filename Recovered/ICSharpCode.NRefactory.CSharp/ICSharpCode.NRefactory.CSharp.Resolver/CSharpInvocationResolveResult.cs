using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.NRefactory.CSharp.Resolver
{
	public class CSharpInvocationResolveResult : InvocationResolveResult
	{
		public readonly OverloadResolutionErrors OverloadResolutionErrors;

		public readonly bool IsExtensionMethodInvocation;

		public readonly bool IsDelegateInvocation;

		public readonly bool IsExpandedForm;

		private readonly IList<int> argumentToParameterMap;

		private IMethod reducedMethod;

		public IMethod ReducedMethod
		{
			get
			{
				if (!IsExtensionMethodInvocation)
				{
					return null;
				}
				if (reducedMethod == null && base.Member is IMethod)
				{
					reducedMethod = new ReducedExtensionMethod((IMethod)base.Member);
				}
				return reducedMethod;
			}
		}

		public override bool IsError => OverloadResolutionErrors != OverloadResolutionErrors.None;

		public CSharpInvocationResolveResult(ResolveResult targetResult, IParameterizedMember member, IList<ResolveResult> arguments, OverloadResolutionErrors overloadResolutionErrors = OverloadResolutionErrors.None, bool isExtensionMethodInvocation = false, bool isExpandedForm = false, bool isDelegateInvocation = false, IList<int> argumentToParameterMap = null, IList<ResolveResult> initializerStatements = null, IType returnTypeOverride = null)
			: base(targetResult, member, arguments, initializerStatements, returnTypeOverride)
		{
			OverloadResolutionErrors = overloadResolutionErrors;
			IsExtensionMethodInvocation = isExtensionMethodInvocation;
			IsExpandedForm = isExpandedForm;
			IsDelegateInvocation = isDelegateInvocation;
			this.argumentToParameterMap = argumentToParameterMap;
		}

		public IList<int> GetArgumentToParameterMap()
		{
			return argumentToParameterMap;
		}

		public override IList<ResolveResult> GetArgumentsForCall()
		{
			ResolveResult[] array = new ResolveResult[base.Member.Parameters.Count];
			List<ResolveResult> list = IsExpandedForm ? new List<ResolveResult>() : null;
			for (int i = 0; i < Arguments.Count; i++)
			{
				int num = (argumentToParameterMap == null) ? (IsExpandedForm ? Math.Min(i, array.Length - 1) : i) : argumentToParameterMap[i];
				if (num < 0 || num >= array.Length)
				{
					continue;
				}
				if (IsExpandedForm && num == array.Length - 1)
				{
					list.Add(Arguments[i]);
					continue;
				}
				NamedArgumentResolveResult namedArgumentResolveResult = Arguments[i] as NamedArgumentResolveResult;
				if (namedArgumentResolveResult != null)
				{
					array[num] = namedArgumentResolveResult.Argument;
				}
				else
				{
					array[num] = Arguments[i];
				}
			}
			if (IsExpandedForm)
			{
				IType type = base.Member.Parameters.Last().Type;
				IType type2 = base.Member.Compilation.FindType(KnownTypeCode.Int32);
				ResolveResult[] sizeArguments = new ResolveResult[1]
				{
					new ConstantResolveResult(type2, list.Count)
				};
				array[array.Length - 1] = new ArrayCreateResolveResult(type, sizeArguments, list);
			}
			for (int j = 0; j < array.Length; j++)
			{
				if (array[j] == null)
				{
					if (base.Member.Parameters[j].IsOptional)
					{
						array[j] = new ConstantResolveResult(base.Member.Parameters[j].Type, base.Member.Parameters[j].ConstantValue);
					}
					else
					{
						array[j] = ErrorResolveResult.UnknownError;
					}
				}
			}
			return array;
		}
	}
}
