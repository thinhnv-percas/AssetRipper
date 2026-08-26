using ICSharpCode.NRefactory.TypeSystem.Implementation;

namespace ICSharpCode.NRefactory.TypeSystem
{
	public sealed class ByReferenceType : TypeWithElementType
	{
		public override TypeKind Kind => TypeKind.ByReference;

		public override string NameSuffix => "&";

		public override bool? IsReferenceType => null;

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
			ByReferenceType byReferenceType = other as ByReferenceType;
			if (byReferenceType != null)
			{
				return elementType.Equals(byReferenceType.elementType);
			}
			return false;
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

		public override ITypeReference ToTypeReference()
		{
			return new ByReferenceTypeReference(elementType.ToTypeReference());
		}
	}
}
