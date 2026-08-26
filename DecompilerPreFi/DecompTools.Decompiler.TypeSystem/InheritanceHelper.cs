#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DecompTools.Decompiler.TypeSystem;

public static class InheritanceHelper
{
	public static IMember GetBaseMember(IMember member)
	{
		return Enumerable.FirstOrDefault<IMember>(GetBaseMembers(member, includeImplementedInterfaces: false));
	}

	public static IEnumerable<IMember> GetBaseMembers(IMember member, bool includeImplementedInterfaces)
	{
		if (member == null)
		{
			throw new ArgumentNullException("member");
		}
		if (includeImplementedInterfaces && member.IsExplicitInterfaceImplementation && Enumerable.Count<IMember>(member.ExplicitlyImplementedInterfaceMembers) == 1)
		{
			member = Enumerable.First<IMember>(member.ExplicitlyImplementedInterfaceMembers);
			yield return member;
		}
		TypeParameterSubstitution substitution = member.Substitution;
		member = member.MemberDefinition;
		if (member.DeclaringTypeDefinition == null)
		{
			yield break;
		}
		IEnumerable<IType> allBaseTypes = ((!includeImplementedInterfaces) ? member.DeclaringTypeDefinition.GetNonInterfaceBaseTypes() : member.DeclaringTypeDefinition.GetAllBaseTypes());
		foreach (IType baseType in Enumerable.Reverse<IType>(allBaseTypes))
		{
			if (baseType == member.DeclaringTypeDefinition)
			{
				continue;
			}
			IEnumerable<IMember> baseMembers = ((member.SymbolKind != SymbolKind.Accessor) ? baseType.GetMembers((IMember m) => m.Name == member.Name && (int)m.Accessibility > 1, GetMemberOptions.IgnoreInheritedMembers) : baseType.GetAccessors((IMethod m) => m.Name == member.Name && (int)m.Accessibility > 1, GetMemberOptions.IgnoreInheritedMembers));
			foreach (IMember baseMember in baseMembers)
			{
				Debug.Assert(baseMember.Accessibility != Accessibility.Private);
				if (SignatureComparer.Ordinal.Equals(member, baseMember))
				{
					yield return baseMember.Specialize(substitution);
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
		if (baseMember is IMethod method)
		{
			foreach (IMethod method2 in derivedType.Methods)
			{
				if (method2.Name == method.Name && method2.Parameters.Count == method.Parameters.Count && method2.TypeParameters.Count == method.TypeParameters.Count && Enumerable.Any<IMember>(GetBaseMembers(method2, includeImplementedInterfaces), (Func<IMember, bool>)((IMember m) => m.MemberDefinition == baseMember)))
				{
					return method2;
				}
			}
		}
		if (baseMember is IProperty property)
		{
			foreach (IProperty property2 in derivedType.Properties)
			{
				if (property2.Name == property.Name && property2.Parameters.Count == property.Parameters.Count && Enumerable.Any<IMember>(GetBaseMembers(property2, includeImplementedInterfaces), (Func<IMember, bool>)((IMember m) => m.MemberDefinition == baseMember)))
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

	internal static IEnumerable<IAttribute> GetAttributes(ITypeDefinition typeDef)
	{
		foreach (IType baseType in Enumerable.Reverse<IType>(typeDef.GetNonInterfaceBaseTypes()))
		{
			ITypeDefinition baseTypeDef = baseType.GetDefinition();
			if (baseTypeDef == null)
			{
				continue;
			}
			foreach (IAttribute attribute in baseTypeDef.GetAttributes())
			{
				yield return attribute;
			}
		}
	}

	internal static IEnumerable<IAttribute> GetAttributes(IMember member)
	{
		HashSet<IMember> visitedMembers = new HashSet<IMember>();
		int num;
		do
		{
			member = member.MemberDefinition;
			if (!visitedMembers.Add(member))
			{
				break;
			}
			foreach (IAttribute attribute in member.GetAttributes())
			{
				yield return attribute;
			}
			if (member.IsOverride)
			{
				IMember baseMember;
				member = (baseMember = GetBaseMember(member));
				num = ((baseMember != null) ? 1 : 0);
			}
			else
			{
				num = 0;
			}
		}
		while (num != 0);
	}
}
