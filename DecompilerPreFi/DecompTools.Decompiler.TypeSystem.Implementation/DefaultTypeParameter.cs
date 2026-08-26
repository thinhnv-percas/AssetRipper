using System.Collections.Generic;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.TypeSystem.Implementation;

public class DefaultTypeParameter : AbstractTypeParameter
{
	private readonly bool hasValueTypeConstraint;

	private readonly bool hasReferenceTypeConstraint;

	private readonly bool hasDefaultConstructorConstraint;

	private readonly Nullability nullabilityConstraint;

	private readonly IReadOnlyList<IType> constraints;

	private readonly IReadOnlyList<IAttribute> attributes;

	public override bool HasValueTypeConstraint => hasValueTypeConstraint;

	public override bool HasReferenceTypeConstraint => hasReferenceTypeConstraint;

	public override bool HasDefaultConstructorConstraint => hasDefaultConstructorConstraint;

	public override bool HasUnmanagedConstraint => false;

	public override Nullability NullabilityConstraint => nullabilityConstraint;

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
				yield return base.Compilation.FindType((!HasValueTypeConstraint) ? KnownTypeCode.Object : KnownTypeCode.ValueType);
			}
		}
	}

	public DefaultTypeParameter(IEntity owner, int index, string name = null, VarianceModifier variance = VarianceModifier.Invariant, IReadOnlyList<IAttribute> attributes = null, bool hasValueTypeConstraint = false, bool hasReferenceTypeConstraint = false, bool hasDefaultConstructorConstraint = false, IReadOnlyList<IType> constraints = null, Nullability nullabilityConstraint = Nullability.Oblivious)
		: base(owner, index, name, variance)
	{
		this.hasValueTypeConstraint = hasValueTypeConstraint;
		this.hasReferenceTypeConstraint = hasReferenceTypeConstraint;
		this.hasDefaultConstructorConstraint = hasDefaultConstructorConstraint;
		this.nullabilityConstraint = nullabilityConstraint;
		this.constraints = constraints ?? EmptyList<IType>.Instance;
		this.attributes = attributes ?? EmptyList<IAttribute>.Instance;
	}

	public DefaultTypeParameter(ICompilation compilation, SymbolKind ownerType, int index, string name = null, VarianceModifier variance = VarianceModifier.Invariant, IReadOnlyList<IAttribute> attributes = null, bool hasValueTypeConstraint = false, bool hasReferenceTypeConstraint = false, bool hasDefaultConstructorConstraint = false, IReadOnlyList<IType> constraints = null, Nullability nullabilityConstraint = Nullability.Oblivious)
		: base(compilation, ownerType, index, name, variance)
	{
		this.hasValueTypeConstraint = hasValueTypeConstraint;
		this.hasReferenceTypeConstraint = hasReferenceTypeConstraint;
		this.hasDefaultConstructorConstraint = hasDefaultConstructorConstraint;
		this.nullabilityConstraint = nullabilityConstraint;
		this.constraints = constraints ?? EmptyList<IType>.Instance;
		this.attributes = attributes ?? EmptyList<IAttribute>.Instance;
	}

	public override IEnumerable<IAttribute> GetAttributes()
	{
		return attributes;
	}
}
