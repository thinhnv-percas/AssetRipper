namespace DecompTools.Decompiler.TypeSystem.Implementation;

public sealed class PinnedType : TypeWithElementType
{
	public override string NameSuffix => " pinned";

	public override bool? IsReferenceType => elementType.IsReferenceType;

	public override bool IsByRefLike => elementType.IsByRefLike;

	public override TypeKind Kind => TypeKind.Other;

	public PinnedType(IType elementType)
		: base(elementType)
	{
	}

	public override IType VisitChildren(TypeVisitor visitor)
	{
		IType type = elementType.AcceptVisitor(visitor);
		if (type == elementType)
		{
			return this;
		}
		return new PinnedType(type);
	}
}
