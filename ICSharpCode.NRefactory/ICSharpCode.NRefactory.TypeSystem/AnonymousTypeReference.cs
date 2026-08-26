using System;

namespace ICSharpCode.NRefactory.TypeSystem;

[Serializable]
public class AnonymousTypeReference : ITypeReference
{
	private readonly IUnresolvedProperty[] unresolvedProperties;

	public AnonymousTypeReference(IUnresolvedProperty[] properties)
	{
		if (properties == null)
		{
			throw new ArgumentNullException("properties");
		}
		unresolvedProperties = properties;
	}

	public IType Resolve(ITypeResolveContext context)
	{
		return new AnonymousType(context.Compilation, unresolvedProperties);
	}
}
