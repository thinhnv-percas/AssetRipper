using System;
using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.Semantics;

public class TypeOfResolveResult : ResolveResult
{
	private readonly IType referencedType;

	public IType ReferencedType => referencedType;

	public TypeOfResolveResult(IType systemType, IType referencedType)
		: base(systemType)
	{
		if (referencedType == null)
		{
			throw new ArgumentNullException("referencedType");
		}
		this.referencedType = referencedType;
	}
}
