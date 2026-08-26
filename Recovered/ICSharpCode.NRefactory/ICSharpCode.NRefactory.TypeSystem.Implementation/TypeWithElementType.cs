using System;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation
{
	public abstract class TypeWithElementType : AbstractType
	{
		[CLSCompliant(false)]
		protected IType elementType;

		public override string Name => elementType.Name + NameSuffix;

		public override string Namespace => elementType.Namespace;

		public override string FullName => elementType.FullName + NameSuffix;

		public override string ReflectionName => elementType.ReflectionName + NameSuffix;

		public abstract string NameSuffix
		{
			get;
		}

		public IType ElementType => elementType;

		protected TypeWithElementType(IType elementType)
		{
			if (elementType == null)
			{
				throw new ArgumentNullException("elementType");
			}
			this.elementType = elementType;
		}

		public abstract override IType VisitChildren(TypeVisitor visitor);
	}
}
