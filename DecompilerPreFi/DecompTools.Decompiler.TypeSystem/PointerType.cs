using DecompTools.Decompiler.TypeSystem.Implementation;

namespace DecompTools.Decompiler.TypeSystem;

public sealed class PointerType : TypeWithElementType
{
	public override TypeKind Kind => TypeKind.Pointer;

	public override string NameSuffix => "*";

	public override bool? IsReferenceType => null;

	public PointerType(IType elementType)
		: base(elementType)
	{
	}

	public override int GetHashCode()
	{
		return elementType.GetHashCode() ^ 0x5779FF3;
	}

	public override bool Equals(IType other)
	{
		return other is PointerType pointerType && elementType.Equals(pointerType.elementType);
	}

	public override IType AcceptVisitor(TypeVisitor visitor)
	{
		return visitor.VisitPointerType(this);
	}

	public override IType VisitChildren(TypeVisitor visitor)
	{
		IType type = elementType.AcceptVisitor(visitor);
		if (type == elementType)
		{
			return this;
		}
		return new PointerType(type);
	}
}
