using System;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation;

public sealed class OwnedTypeParameterReference : ISymbolReference
{
	private ISymbolReference owner;

	private int index;

	public OwnedTypeParameterReference(ISymbolReference owner, int index)
	{
		if (owner == null)
		{
			throw new ArgumentNullException("owner");
		}
		this.owner = owner;
		this.index = index;
	}

	public ISymbol Resolve(ITypeResolveContext context)
	{
		IEntity entity = owner.Resolve(context) as IEntity;
		if (entity is ITypeDefinition)
		{
			return ((ITypeDefinition)entity).TypeParameters[index];
		}
		if (entity is IMethod)
		{
			return ((IMethod)entity).TypeParameters[index];
		}
		return null;
	}
}
