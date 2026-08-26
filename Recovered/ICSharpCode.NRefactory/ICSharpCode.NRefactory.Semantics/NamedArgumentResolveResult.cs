using ICSharpCode.NRefactory.TypeSystem;
using System;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.Semantics
{
	public class NamedArgumentResolveResult : ResolveResult
	{
		public readonly IParameterizedMember Member;

		public readonly IParameter Parameter;

		public readonly string ParameterName;

		public readonly ResolveResult Argument;

		public NamedArgumentResolveResult(IParameter parameter, ResolveResult argument, IParameterizedMember member = null)
			: base(argument.Type)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException("parameter");
			}
			if (argument == null)
			{
				throw new ArgumentNullException("argument");
			}
			Member = member;
			Parameter = parameter;
			ParameterName = parameter.Name;
			Argument = argument;
		}

		public NamedArgumentResolveResult(string parameterName, ResolveResult argument)
			: base(argument.Type)
		{
			if (parameterName == null)
			{
				throw new ArgumentNullException("parameterName");
			}
			if (argument == null)
			{
				throw new ArgumentNullException("argument");
			}
			ParameterName = parameterName;
			Argument = argument;
		}

		public override IEnumerable<ResolveResult> GetChildResults()
		{
			return new ResolveResult[1]
			{
				Argument
			};
		}
	}
}
