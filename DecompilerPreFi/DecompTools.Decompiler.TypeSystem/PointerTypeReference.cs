using System;

namespace DecompTools.Decompiler.TypeSystem;

[Serializable]
public sealed class PointerTypeReference : ITypeReference, ISupportsInterning
{
	private readonly ITypeReference elementType;

	public ITypeReference ElementType => elementType;

	public PointerTypeReference(ITypeReference elementType)
	{
		if (elementType == null)
		{
			throw new ArgumentNullException("elementType");
		}
		this.elementType = elementType;
	}

	public IType Resolve(ITypeResolveContext context)
	{
		return new PointerType(elementType.Resolve(context));
	}

	public override string ToString()
	{
		return elementType.ToString() + "*";
	}

	int ISupportsInterning.GetHashCodeForInterning()
	{
		return elementType.GetHashCode() ^ 0x5779FF4;
	}

	bool ISupportsInterning.EqualsForInterning(ISupportsInterning other)
	{
		return other is PointerTypeReference pointerTypeReference && elementType == pointerTypeReference.elementType;
	}
}
