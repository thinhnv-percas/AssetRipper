using System.Collections.Generic;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation
{
	public class DefaultTypeParameter : AbstractTypeParameter
	{
		private readonly bool hasValueTypeConstraint;

		private readonly bool hasReferenceTypeConstraint;

		private readonly bool hasDefaultConstructorConstraint;

		private readonly IList<IType> constraints;

		public override bool HasValueTypeConstraint => hasValueTypeConstraint;

		public override bool HasReferenceTypeConstraint => hasReferenceTypeConstraint;

		public override bool HasDefaultConstructorConstraint => hasDefaultConstructorConstraint;

		public override IEnumerable<IType> DirectBaseTypes
		{
			get
			{
				bool hasNonInterfaceConstraint = false;
				foreach (IType c in constraints)
				{
					yield return c;
					if (c.Kind != TypeKind.Interface)
					{
						hasNonInterfaceConstraint = true;
					}
				}
				if (HasValueTypeConstraint || !hasNonInterfaceConstraint)
				{
					yield return Compilation.FindType((!HasValueTypeConstraint) ? KnownTypeCode.Object : KnownTypeCode.ValueType);
				}
			}
		}

		public DefaultTypeParameter(IEntity owner, int index, string name = null, VarianceModifier variance = VarianceModifier.Invariant, IList<IAttribute> attributes = null, DomRegion region = default(DomRegion), bool hasValueTypeConstraint = false, bool hasReferenceTypeConstraint = false, bool hasDefaultConstructorConstraint = false, IList<IType> constraints = null)
			: base(owner, index, name, variance, attributes, region)
		{
			this.hasValueTypeConstraint = hasValueTypeConstraint;
			this.hasReferenceTypeConstraint = hasReferenceTypeConstraint;
			this.hasDefaultConstructorConstraint = hasDefaultConstructorConstraint;
			this.constraints = (constraints ?? EmptyList<IType>.Instance);
		}

		public DefaultTypeParameter(ICompilation compilation, SymbolKind ownerType, int index, string name = null, VarianceModifier variance = VarianceModifier.Invariant, IList<IAttribute> attributes = null, DomRegion region = default(DomRegion), bool hasValueTypeConstraint = false, bool hasReferenceTypeConstraint = false, bool hasDefaultConstructorConstraint = false, IList<IType> constraints = null)
			: base(compilation, ownerType, index, name, variance, attributes, region)
		{
			this.hasValueTypeConstraint = hasValueTypeConstraint;
			this.hasReferenceTypeConstraint = hasReferenceTypeConstraint;
			this.hasDefaultConstructorConstraint = hasDefaultConstructorConstraint;
			this.constraints = (constraints ?? EmptyList<IType>.Instance);
		}
	}
}
