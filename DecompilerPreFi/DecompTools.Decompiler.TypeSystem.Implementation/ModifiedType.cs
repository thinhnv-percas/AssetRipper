using System;
using System.Collections.Generic;

namespace DecompTools.Decompiler.TypeSystem.Implementation;

public class ModifiedType : TypeWithElementType, IType, INamedElement, IEquatable<IType>
{
	private readonly TypeKind kind;

	private readonly IType modifier;

	public IType Modifier => modifier;

	public override TypeKind Kind => kind;

	public override string NameSuffix => ((kind == TypeKind.ModReq) ? " modreq" : " modopt") + "(" + modifier.FullName + ")";

	public override bool? IsReferenceType => elementType.IsReferenceType;

	public override bool IsByRefLike => elementType.IsByRefLike;

	public override Nullability Nullability => elementType.Nullability;

	public ModifiedType(IType modifier, IType unmodifiedType, bool isRequired)
		: base(unmodifiedType)
	{
		kind = (isRequired ? TypeKind.ModReq : TypeKind.ModOpt);
		this.modifier = modifier ?? throw new ArgumentNullException("modifier");
	}

	public override IType ChangeNullability(Nullability nullability)
	{
		IType type = elementType.ChangeNullability(nullability);
		if (type == elementType)
		{
			return this;
		}
		return new ModifiedType(modifier, type, kind == TypeKind.ModReq);
	}

	public override ITypeDefinition GetDefinition()
	{
		return elementType.GetDefinition();
	}

	public override IEnumerable<IMethod> GetAccessors(Predicate<IMethod> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		return elementType.GetAccessors(filter, options);
	}

	public override IEnumerable<IMethod> GetConstructors(Predicate<IMethod> filter = null, GetMemberOptions options = GetMemberOptions.IgnoreInheritedMembers)
	{
		return elementType.GetConstructors(filter, options);
	}

	public override IEnumerable<IEvent> GetEvents(Predicate<IEvent> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		return elementType.GetEvents(filter, options);
	}

	public override IEnumerable<IField> GetFields(Predicate<IField> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		return elementType.GetFields(filter, options);
	}

	public override IEnumerable<IMember> GetMembers(Predicate<IMember> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		return elementType.GetMembers(filter, options);
	}

	public override IEnumerable<IMethod> GetMethods(IReadOnlyList<IType> typeArguments, Predicate<IMethod> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		return elementType.GetMethods(typeArguments, filter, options);
	}

	public override IEnumerable<IMethod> GetMethods(Predicate<IMethod> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		return elementType.GetMethods(filter, options);
	}

	public override IEnumerable<IType> GetNestedTypes(IReadOnlyList<IType> typeArguments, Predicate<ITypeDefinition> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		return elementType.GetNestedTypes(typeArguments, filter, options);
	}

	public override IEnumerable<IType> GetNestedTypes(Predicate<ITypeDefinition> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		return elementType.GetNestedTypes(filter, options);
	}

	public override IEnumerable<IProperty> GetProperties(Predicate<IProperty> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		return elementType.GetProperties(filter, options);
	}

	public override IType VisitChildren(TypeVisitor visitor)
	{
		IType type = elementType.AcceptVisitor(visitor);
		IType type2 = modifier.AcceptVisitor(visitor);
		if (type2 != modifier || type != elementType)
		{
			return new ModifiedType(type2, type, kind == TypeKind.ModReq);
		}
		return this;
	}

	public override IType AcceptVisitor(TypeVisitor visitor)
	{
		if (kind == TypeKind.ModReq)
		{
			return visitor.VisitModReq(this);
		}
		return visitor.VisitModOpt(this);
	}

	public override bool Equals(IType other)
	{
		return other is ModifiedType modifiedType && kind == modifiedType.kind && modifier.Equals(modifiedType.modifier) && elementType.Equals(modifiedType.elementType);
	}

	public override int GetHashCode()
	{
		return (int)((uint)kind ^ (uint)(elementType.GetHashCode() * 1344795899)) ^ (modifier.GetHashCode() * 901375117);
	}
}
