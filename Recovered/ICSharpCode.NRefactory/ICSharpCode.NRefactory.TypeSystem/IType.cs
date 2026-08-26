using System;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.TypeSystem
{
	public interface IType : INamedElement, IEquatable<IType>
	{
		TypeKind Kind
		{
			get;
		}

		bool? IsReferenceType
		{
			get;
		}

		IType DeclaringType
		{
			get;
		}

		int TypeParameterCount
		{
			get;
		}

		IList<IType> TypeArguments
		{
			get;
		}

		bool IsParameterized
		{
			get;
		}

		IEnumerable<IType> DirectBaseTypes
		{
			get;
		}

		ITypeDefinition GetDefinition();

		IType AcceptVisitor(TypeVisitor visitor);

		IType VisitChildren(TypeVisitor visitor);

		ITypeReference ToTypeReference();

		TypeParameterSubstitution GetSubstitution();

		TypeParameterSubstitution GetSubstitution(IList<IType> methodTypeArguments);

		IEnumerable<IType> GetNestedTypes(Predicate<ITypeDefinition> filter = null, GetMemberOptions options = GetMemberOptions.None);

		IEnumerable<IType> GetNestedTypes(IList<IType> typeArguments, Predicate<ITypeDefinition> filter = null, GetMemberOptions options = GetMemberOptions.None);

		IEnumerable<IMethod> GetConstructors(Predicate<IUnresolvedMethod> filter = null, GetMemberOptions options = GetMemberOptions.IgnoreInheritedMembers);

		IEnumerable<IMethod> GetMethods(Predicate<IUnresolvedMethod> filter = null, GetMemberOptions options = GetMemberOptions.None);

		IEnumerable<IMethod> GetMethods(IList<IType> typeArguments, Predicate<IUnresolvedMethod> filter = null, GetMemberOptions options = GetMemberOptions.None);

		IEnumerable<IProperty> GetProperties(Predicate<IUnresolvedProperty> filter = null, GetMemberOptions options = GetMemberOptions.None);

		IEnumerable<IField> GetFields(Predicate<IUnresolvedField> filter = null, GetMemberOptions options = GetMemberOptions.None);

		IEnumerable<IEvent> GetEvents(Predicate<IUnresolvedEvent> filter = null, GetMemberOptions options = GetMemberOptions.None);

		IEnumerable<IMember> GetMembers(Predicate<IUnresolvedMember> filter = null, GetMemberOptions options = GetMemberOptions.None);

		IEnumerable<IMethod> GetAccessors(Predicate<IUnresolvedMethod> filter = null, GetMemberOptions options = GetMemberOptions.None);
	}
}
