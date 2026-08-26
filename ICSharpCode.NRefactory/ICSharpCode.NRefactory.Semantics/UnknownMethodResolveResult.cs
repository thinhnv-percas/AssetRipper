using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.Semantics;

public class UnknownMethodResolveResult : UnknownMemberResolveResult
{
	private readonly ReadOnlyCollection<IParameter> parameters;

	public ReadOnlyCollection<IParameter> Parameters => parameters;

	public UnknownMethodResolveResult(IType targetType, string methodName, IEnumerable<IType> typeArguments, IEnumerable<IParameter> parameters)
		: base(targetType, methodName, typeArguments)
	{
		this.parameters = new ReadOnlyCollection<IParameter>(parameters.ToArray());
	}
}
