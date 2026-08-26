using System;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.NRefactory.TypeSystem
{
	public static class InheritanceHelper
	{
		public static IMember GetBaseMember(IMember member)
		{
			return GetBaseMembers(member, includeImplementedInterfaces: false).FirstOrDefault();
		}

		public static IEnumerable<IMember> GetBaseMembers(IMember member, bool includeImplementedInterfaces)
		{
			if (member == null)
			{
				throw new ArgumentNullException("member");
			}
			if (member.IsExplicitInterfaceImplementation && member.ImplementedInterfaceMembers.Count == 1)
			{
				member = member.ImplementedInterfaceMembers[0];
				yield return member;
			}
			TypeParameterSubstitution substitution = member.Substitution;
			member = member.MemberDefinition;
			if (member.DeclaringTypeDefinition != null)
			{
				IEnumerable<IType> source = (!includeImplementedInterfaces) ? member.DeclaringTypeDefinition.GetNonInterfaceBaseTypes() : member.DeclaringTypeDefinition.GetAllBaseTypes();
				foreach (IType item in source.Reverse())
				{
					if (item != member.DeclaringTypeDefinition)
					{
						IEnumerable<IMember> enumerable = (member.SymbolKind != SymbolKind.Accessor) ? item.GetMembers((IUnresolvedMember m) => m.Name == member.Name && !m.IsExplicitInterfaceImplementation, GetMemberOptions.IgnoreInheritedMembers) : item.GetAccessors((IUnresolvedMethod m) => m.Name == member.Name && !m.IsExplicitInterfaceImplementation, GetMemberOptions.IgnoreInheritedMembers);
						foreach (IMember item2 in enumerable)
						{
							if (!item2.IsPrivate && SignatureComparer.Ordinal.Equals(member, item2))
							{
								yield return item2.Specialize(substitution);
							}
						}
					}
				}
			}
		}

		public static IMember GetDerivedMember(IMember baseMember, ITypeDefinition derivedType)
		{
			if (baseMember == null)
			{
				throw new ArgumentNullException("baseMember");
			}
			if (derivedType == null)
			{
				throw new ArgumentNullException("derivedType");
			}
			if (baseMember.Compilation != derivedType.Compilation)
			{
				throw new ArgumentException("baseMember and derivedType must be from the same compilation");
			}
			baseMember = baseMember.MemberDefinition;
			bool includeImplementedInterfaces = baseMember.DeclaringTypeDefinition.Kind == TypeKind.Interface;
			IMethod method = baseMember as IMethod;
			if (method != null)
			{
				foreach (IMethod method2 in derivedType.Methods)
				{
					if (method2.Name == method.Name && method2.Parameters.Count == method.Parameters.Count && method2.TypeParameters.Count == method.TypeParameters.Count && GetBaseMembers(method2, includeImplementedInterfaces).Any((IMember m) => m.MemberDefinition == baseMember))
					{
						return method2;
					}
				}
			}
			IProperty property = baseMember as IProperty;
			if (property != null)
			{
				foreach (IProperty property2 in derivedType.Properties)
				{
					if (property2.Name == property.Name && property2.Parameters.Count == property.Parameters.Count && GetBaseMembers(property2, includeImplementedInterfaces).Any((IMember m) => m.MemberDefinition == baseMember))
					{
						return property2;
					}
				}
			}
			if (baseMember is IEvent)
			{
				foreach (IEvent @event in derivedType.Events)
				{
					if (@event.Name == baseMember.Name)
					{
						return @event;
					}
				}
			}
			if (baseMember is IField)
			{
				foreach (IField field in derivedType.Fields)
				{
					if (field.Name == baseMember.Name)
					{
						return field;
					}
				}
			}
			return null;
		}
	}
}
