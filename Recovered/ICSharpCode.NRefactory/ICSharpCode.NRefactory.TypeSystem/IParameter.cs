using System.Collections.Generic;

namespace ICSharpCode.NRefactory.TypeSystem
{
	public interface IParameter : IVariable, ISymbol
	{
		IList<IAttribute> Attributes
		{
			get;
		}

		bool IsRef
		{
			get;
		}

		bool IsOut
		{
			get;
		}

		bool IsParams
		{
			get;
		}

		bool IsOptional
		{
			get;
		}

		IParameterizedMember Owner
		{
			get;
		}
	}
}
