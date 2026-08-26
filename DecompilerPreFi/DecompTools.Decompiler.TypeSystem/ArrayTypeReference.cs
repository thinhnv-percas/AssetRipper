using System;

namespace DecompTools.Decompiler.TypeSystem;

[Serializable]
public sealed class ArrayTypeReference : ITypeReference, ISupportsInterning
{
	private readonly ITypeReference elementType;

	private readonly int dimensions;

	public ITypeReference ElementType => elementType;

	public int Dimensions => dimensions;

	public ArrayTypeReference(ITypeReference elementType, int dimensions = 1)
	{
		if (elementType == null)
		{
			throw new ArgumentNullException("elementType");
		}
		if (dimensions <= 0)
		{
			throw new ArgumentOutOfRangeException("dimensions", dimensions, "dimensions must be positive");
		}
		this.elementType = elementType;
		this.dimensions = dimensions;
	}

	public IType Resolve(ITypeResolveContext context)
	{
		return new ArrayType(context.Compilation, elementType.Resolve(context), dimensions);
	}

	public override string ToString()
	{
		return elementType.ToString() + "[" + new string(',', checked(dimensions - 1)) + "]";
	}

	int ISupportsInterning.GetHashCodeForInterning()
	{
		return elementType.GetHashCode() ^ dimensions;
	}

	bool ISupportsInterning.EqualsForInterning(ISupportsInterning other)
	{
		return other is ArrayTypeReference arrayTypeReference && elementType == arrayTypeReference.elementType && dimensions == arrayTypeReference.dimensions;
	}
}
