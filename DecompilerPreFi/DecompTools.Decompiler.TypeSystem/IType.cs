using System;
using System.Collections.Generic;

namespace DecompTools.Decompiler.TypeSystem;

public interface IType : INamedElement, IEquatable<IType>
{
	TypeKind Kind { get; }

	bool? IsReferenceType { get; }

	bool IsByRefLike { get; }

	Nullability Nullability { get; }

	IType DeclaringType { get; }

	int TypeParameterCount { get; }

	IReadOnlyList<ITypeParameter> TypeParameters { get; }

	IReadOnlyList<IType> TypeArguments { get; }

	IEnumerable<IType> DirectBaseTypes { get; }

	IType ChangeNullability(Nullability newNullability);

	ITypeDefinition GetDefinition();

	IType AcceptVisitor(TypeVisitor visitor);

	IType VisitChildren(TypeVisitor visitor);

	TypeParameterSubstitution GetSubstitution();

	IEnumerable<IType> GetNestedTypes(Predicate<ITypeDefinition> filter = null, GetMemberOptions options = GetMemberOptions.None);

	IEnumerable<IType> GetNestedTypes(IReadOnlyList<IType> typeArguments, Predicate<ITypeDefinition> filter = null, GetMemberOptions options = GetMemberOptions.None);

	IEnumerable<IMethod> GetConstructors(Predicate<IMethod> filter = null, GetMemberOptions options = GetMemberOptions.IgnoreInheritedMembers);

	IEnumerable<IMethod> GetMethods(Predicate<IMethod> filter = null, GetMemberOptions options = GetMemberOptions.None);

	IEnumerable<IMethod> GetMethods(IReadOnlyList<IType> typeArguments, Predicate<IMethod> filter = null, GetMemberOptions options = GetMemberOptions.None);

	IEnumerable<IProperty> GetProperties(Predicate<IProperty> filter = null, GetMemberOptions options = GetMemberOptions.None);

	IEnumerable<IField> GetFields(Predicate<IField> filter = null, GetMemberOptions options = GetMemberOptions.None);

	IEnumerable<IEvent> GetEvents(Predicate<IEvent> filter = null, GetMemberOptions options = GetMemberOptions.None);

	IEnumerable<IMember> GetMembers(Predicate<IMember> filter = null, GetMemberOptions options = GetMemberOptions.None);

	IEnumerable<IMethod> GetAccessors(Predicate<IMethod> filter = null, GetMemberOptions options = GetMemberOptions.None);
}
