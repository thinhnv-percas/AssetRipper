#define DEBUG
using System;
using System.Diagnostics;

namespace DecompTools.Decompiler.TypeSystem.Implementation;

public class NullabilityAnnotatedType : DecoratedType, IType, INamedElement, IEquatable<IType>
{
	private readonly Nullability nullability;

	public Nullability Nullability => nullability;

	public IType TypeWithoutAnnotation => baseType;

	internal NullabilityAnnotatedType(IType type, Nullability nullability)
		: base(type)
	{
		Debug.Assert(nullability != type.Nullability);
		Debug.Assert(type is ITypeDefinition || (type is ITypeParameter && this is ITypeParameter));
		this.nullability = nullability;
	}

	public override IType AcceptVisitor(TypeVisitor visitor)
	{
		return visitor.VisitNullabilityAnnotatedType(this);
	}

	public override bool Equals(IType other)
	{
		return other is NullabilityAnnotatedType nullabilityAnnotatedType && nullabilityAnnotatedType.nullability == nullability && nullabilityAnnotatedType.baseType.Equals(baseType);
	}

	public override IType ChangeNullability(Nullability nullability)
	{
		if (nullability == this.nullability)
		{
			return this;
		}
		return baseType.ChangeNullability(nullability);
	}

	public override IType VisitChildren(TypeVisitor visitor)
	{
		IType type = baseType.AcceptVisitor(visitor);
		if (type != baseType)
		{
			return type.ChangeNullability(nullability);
		}
		return this;
	}

	public override string ToString()
	{
		switch (nullability)
		{
		case Nullability.Nullable:
			return baseType.ToString() + "?";
		case Nullability.NotNullable:
			return baseType.ToString() + "!";
		default:
			Debug.Assert(nullability == Nullability.Oblivious);
			return baseType.ToString() + "~";
		}
	}
}
