using System;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation;

[Serializable]
internal sealed class AccessorOwnerMemberReference : IMemberReference, ISymbolReference
{
	private readonly IMemberReference accessorReference;

	public ITypeReference DeclaringTypeReference => accessorReference.DeclaringTypeReference;

	public AccessorOwnerMemberReference(IMemberReference accessorReference)
	{
		if (accessorReference == null)
		{
			throw new ArgumentNullException("accessorReference");
		}
		this.accessorReference = accessorReference;
	}

	public IMember Resolve(ITypeResolveContext context)
	{
		if (accessorReference.Resolve(context) is IMethod method)
		{
			return method.AccessorOwner;
		}
		return null;
	}

	ISymbol ISymbolReference.Resolve(ITypeResolveContext context)
	{
		return ((IMemberReference)this).Resolve(context);
	}
}
