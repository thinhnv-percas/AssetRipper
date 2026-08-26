using System;

namespace ICSharpCode.NRefactory.TypeSystem;

[Serializable]
public sealed class ByReferenceTypeReference : ITypeReference, ISupportsInterning
{
	private readonly ITypeReference elementType;

	public ITypeReference ElementType => elementType;

	public ByReferenceTypeReference(ITypeReference elementType)
	{
		if (elementType == null)
		{
			throw new ArgumentNullException("elementType");
		}
		this.elementType = elementType;
	}

	public IType Resolve(ITypeResolveContext context)
	{
		return new ByReferenceType(elementType.Resolve(context));
	}

	public override string ToString()
	{
		return elementType.ToString() + "&";
	}

	int ISupportsInterning.GetHashCodeForInterning()
	{
		return elementType.GetHashCode() ^ 0x5779FF6;
	}

	bool ISupportsInterning.EqualsForInterning(ISupportsInterning other)
	{
		if (other is ByReferenceTypeReference byReferenceTypeReference)
		{
			return elementType == byReferenceTypeReference.elementType;
		}
		return false;
	}
}
