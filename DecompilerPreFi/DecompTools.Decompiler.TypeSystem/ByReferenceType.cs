using DecompTools.Decompiler.TypeSystem.Implementation;

namespace DecompTools.Decompiler.TypeSystem;

public sealed class ByReferenceType : TypeWithElementType
{
	public override TypeKind Kind => TypeKind.ByReference;

	public override string NameSuffix => "&";

	public override bool? IsReferenceType => null;

	public override bool IsByRefLike => true;

	public ByReferenceType(IType elementType)
		: base(elementType)
	{
	}

	public override int GetHashCode()
	{
		return elementType.GetHashCode() ^ 0x5779FF5;
	}

	public override bool Equals(IType other)
	{
		return other is ByReferenceType byReferenceType && elementType.Equals(byReferenceType.elementType);
	}

	public override IType AcceptVisitor(TypeVisitor visitor)
	{
		return visitor.VisitByReferenceType(this);
	}

	public override IType VisitChildren(TypeVisitor visitor)
	{
		IType type = elementType.AcceptVisitor(visitor);
		if (type == elementType)
		{
			return this;
		}
		return new ByReferenceType(type);
	}
}
