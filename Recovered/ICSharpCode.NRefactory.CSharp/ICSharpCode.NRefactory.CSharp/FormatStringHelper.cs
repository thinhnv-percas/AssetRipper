using ICSharpCode.NRefactory.CSharp.Resolver;
using ICSharpCode.NRefactory.TypeSystem;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.NRefactory.CSharp
{
	internal static class FormatStringHelper
	{
		private static readonly string[] parameterNames = new string[3]
		{
			"format",
			"frmt",
			"fmt"
		};

		public static bool TryGetFormattingParameters(CSharpInvocationResolveResult invocationResolveResult, InvocationExpression invocationExpression, out Expression formatArgument, out IList<Expression> arguments, Func<IParameter, Expression, bool> argumentFilter)
		{
			if (argumentFilter == null)
			{
				argumentFilter = ((IParameter p, Expression e) => true);
			}
			formatArgument = null;
			arguments = new List<Expression>();
			if (invocationResolveResult.Member.SymbolKind == SymbolKind.Method && invocationResolveResult.Member.DeclaringType != null && !invocationResolveResult.Member.DeclaringType.GetMethods((IUnresolvedMethod m) => m.Name == invocationResolveResult.Member.Name).ToList().Any((IMethod m) => m.Parameters.Count == 2 && m.Parameters[0].Type.IsKnownType(KnownTypeCode.String) && parameterNames.Contains(m.Parameters[0].Name) && m.Parameters[1].IsParams))
			{
				return false;
			}
			IList<int> argumentToParameterMap = invocationResolveResult.GetArgumentToParameterMap();
			IList<IParameter> parameters = invocationResolveResult.Member.Parameters;
			Expression[] array = invocationExpression.Arguments.ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				int num = argumentToParameterMap[i];
				if (num < 0 || num >= parameters.Count)
				{
					continue;
				}
				IParameter parameter = parameters[num];
				Expression expression = array[i];
				if (i == 0 && parameter.Type.IsKnownType(KnownTypeCode.String) && parameterNames.Contains(parameter.Name))
				{
					formatArgument = expression;
				}
				else if (formatArgument != null && parameter.IsParams && !invocationResolveResult.IsExpandedForm)
				{
					ArrayCreateExpression arrayCreateExpression = expression as ArrayCreateExpression;
					if (arrayCreateExpression == null || arrayCreateExpression.Initializer.IsNull)
					{
						return false;
					}
					foreach (Expression element in arrayCreateExpression.Initializer.Elements)
					{
						if (argumentFilter(parameter, element))
						{
							arguments.Add(expression);
						}
					}
				}
				else if (formatArgument != null && argumentFilter(parameter, expression))
				{
					arguments.Add(expression);
				}
			}
			return formatArgument != null;
		}
	}
}
