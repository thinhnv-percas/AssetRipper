using ICSharpCode.NRefactory.TypeSystem.Implementation;

namespace ICSharpCode.NRefactory.TypeSystem
{
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
			PointerType pointerType = other as PointerType;
			if (pointerType != null)
			{
				return elementType.Equals(pointerType.elementType);
			}
			return false;
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

		public override ITypeReference ToTypeReference()
		{
			return new PointerTypeReference(elementType.ToTypeReference());
		}
	}
}
