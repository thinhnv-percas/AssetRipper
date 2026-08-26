using System;
using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Utils;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation;

internal static class GetMembersHelper
{
	private const GetMemberOptions declaredMembers = GetMemberOptions.ReturnMemberDefinitions | GetMemberOptions.IgnoreInheritedMembers;

	public static IEnumerable<IType> GetNestedTypes(IType type, Predicate<ITypeDefinition> filter, GetMemberOptions options)
	{
		return GetNestedTypes(type, null, filter, options);
	}

	public static IEnumerable<IType> GetNestedTypes(IType type, IList<IType> nestedTypeArguments, Predicate<ITypeDefinition> filter, GetMemberOptions options)
	{
		if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
		{
			return GetNestedTypesImpl(type, nestedTypeArguments, filter, options);
		}
		return type.GetNonInterfaceBaseTypes().SelectMany((IType t) => GetNestedTypesImpl(t, nestedTypeArguments, filter, options));
	}

	private static IEnumerable<IType> GetNestedTypesImpl(IType outerType, IList<IType> nestedTypeArguments, Predicate<ITypeDefinition> filter, GetMemberOptions options)
	{
		ITypeDefinition outerTypeDef = outerType.GetDefinition();
		if (outerTypeDef == null)
		{
			yield break;
		}
		int outerTypeParameterCount = outerTypeDef.TypeParameterCount;
		ParameterizedType pt = outerType as ParameterizedType;
		foreach (ITypeDefinition nestedType in outerTypeDef.NestedTypes)
		{
			int typeParameterCount = nestedType.TypeParameterCount;
			if ((nestedTypeArguments != null && typeParameterCount - outerTypeParameterCount != nestedTypeArguments.Count) || (filter != null && !filter(nestedType)))
			{
				continue;
			}
			if (typeParameterCount == 0 || (options & GetMemberOptions.ReturnMemberDefinitions) == GetMemberOptions.ReturnMemberDefinitions)
			{
				yield return nestedType;
				continue;
			}
			IType[] array = new IType[typeParameterCount];
			for (int i = 0; i < outerTypeParameterCount; i++)
			{
				int num = i;
				IType type2;
				if (pt == null)
				{
					IType type = outerTypeDef.TypeParameters[i];
					type2 = type;
				}
				else
				{
					type2 = pt.GetTypeArgument(i);
				}
				array[num] = type2;
			}
			for (int j = outerTypeParameterCount; j < typeParameterCount; j++)
			{
				if (nestedTypeArguments != null)
				{
					array[j] = nestedTypeArguments[j - outerTypeParameterCount];
				}
				else
				{
					array[j] = SpecialType.UnboundTypeArgument;
				}
			}
			yield return new ParameterizedType(nestedType, array);
		}
	}

	public static IEnumerable<IMethod> GetMethods(IType type, Predicate<IUnresolvedMethod> filter, GetMemberOptions options)
	{
		return GetMethods(type, null, filter, options);
	}

	public static IEnumerable<IMethod> GetMethods(IType type, IList<IType> typeArguments, Predicate<IUnresolvedMethod> filter, GetMemberOptions options)
	{
		if (typeArguments != null && typeArguments.Count > 0)
		{
			filter = FilterTypeParameterCount(typeArguments.Count).And(filter);
		}
		if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
		{
			return GetMethodsImpl(type, typeArguments, filter, options);
		}
		return type.GetNonInterfaceBaseTypes().SelectMany((IType t) => GetMethodsImpl(t, typeArguments, filter, options));
	}

	private static Predicate<IUnresolvedMethod> FilterTypeParameterCount(int expectedTypeParameterCount)
	{
		return (IUnresolvedMethod m) => m.TypeParameters.Count == expectedTypeParameterCount;
	}

	private static IEnumerable<IMethod> GetMethodsImpl(IType baseType, IList<IType> methodTypeArguments, Predicate<IUnresolvedMethod> filter, GetMemberOptions options)
	{
		IEnumerable<IMethod> methods = baseType.GetMethods(filter, options | (GetMemberOptions.ReturnMemberDefinitions | GetMemberOptions.IgnoreInheritedMembers));
		ParameterizedType pt = baseType as ParameterizedType;
		if ((options & GetMemberOptions.ReturnMemberDefinitions) == 0 && (pt != null || (methodTypeArguments != null && methodTypeArguments.Count > 0)))
		{
			TypeParameterSubstitution substitution = null;
			foreach (IMethod item in methods)
			{
				if (methodTypeArguments == null || methodTypeArguments.Count <= 0 || item.TypeParameters.Count == methodTypeArguments.Count)
				{
					if (substitution == null)
					{
						substitution = ((pt == null) ? new TypeParameterSubstitution(null, methodTypeArguments) : pt.GetSubstitution(methodTypeArguments));
					}
					yield return new SpecializedMethod(item, substitution);
				}
			}
			yield break;
		}
		foreach (IMethod item2 in methods)
		{
			yield return item2;
		}
	}

	public static IEnumerable<IMethod> GetAccessors(IType type, Predicate<IUnresolvedMethod> filter, GetMemberOptions options)
	{
		if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
		{
			return GetAccessorsImpl(type, filter, options);
		}
		return type.GetNonInterfaceBaseTypes().SelectMany((IType t) => GetAccessorsImpl(t, filter, options));
	}

	private static IEnumerable<IMethod> GetAccessorsImpl(IType baseType, Predicate<IUnresolvedMethod> filter, GetMemberOptions options)
	{
		return GetConstructorsOrAccessorsImpl(baseType, baseType.GetAccessors(filter, options | (GetMemberOptions.ReturnMemberDefinitions | GetMemberOptions.IgnoreInheritedMembers)), filter, options);
	}

	public static IEnumerable<IMethod> GetConstructors(IType type, Predicate<IUnresolvedMethod> filter, GetMemberOptions options)
	{
		if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
		{
			return GetConstructorsImpl(type, filter, options);
		}
		return type.GetNonInterfaceBaseTypes().SelectMany((IType t) => GetConstructorsImpl(t, filter, options));
	}

	private static IEnumerable<IMethod> GetConstructorsImpl(IType baseType, Predicate<IUnresolvedMethod> filter, GetMemberOptions options)
	{
		return GetConstructorsOrAccessorsImpl(baseType, baseType.GetConstructors(filter, options | (GetMemberOptions.ReturnMemberDefinitions | GetMemberOptions.IgnoreInheritedMembers)), filter, options);
	}

	private static IEnumerable<IMethod> GetConstructorsOrAccessorsImpl(IType baseType, IEnumerable<IMethod> declaredMembers, Predicate<IUnresolvedMethod> filter, GetMemberOptions options)
	{
		if ((options & GetMemberOptions.ReturnMemberDefinitions) == GetMemberOptions.ReturnMemberDefinitions)
		{
			return declaredMembers;
		}
		ParameterizedType pt = baseType as ParameterizedType;
		if (pt != null)
		{
			TypeParameterSubstitution substitution = pt.GetSubstitution();
			return declaredMembers.Select((IMethod m) => new SpecializedMethod(m, substitution)
			{
				DeclaringType = pt
			});
		}
		return declaredMembers;
	}

	public static IEnumerable<IProperty> GetProperties(IType type, Predicate<IUnresolvedProperty> filter, GetMemberOptions options)
	{
		if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
		{
			return GetPropertiesImpl(type, filter, options);
		}
		return type.GetNonInterfaceBaseTypes().SelectMany((IType t) => GetPropertiesImpl(t, filter, options));
	}

	private static IEnumerable<IProperty> GetPropertiesImpl(IType baseType, Predicate<IUnresolvedProperty> filter, GetMemberOptions options)
	{
		IEnumerable<IProperty> properties = baseType.GetProperties(filter, options | (GetMemberOptions.ReturnMemberDefinitions | GetMemberOptions.IgnoreInheritedMembers));
		if ((options & GetMemberOptions.ReturnMemberDefinitions) == GetMemberOptions.ReturnMemberDefinitions)
		{
			return properties;
		}
		ParameterizedType pt = baseType as ParameterizedType;
		if (pt != null)
		{
			TypeParameterSubstitution substitution = pt.GetSubstitution();
			return properties.Select((IProperty m) => new SpecializedProperty(m, substitution)
			{
				DeclaringType = pt
			});
		}
		return properties;
	}

	public static IEnumerable<IField> GetFields(IType type, Predicate<IUnresolvedField> filter, GetMemberOptions options)
	{
		if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
		{
			return GetFieldsImpl(type, filter, options);
		}
		return type.GetNonInterfaceBaseTypes().SelectMany((IType t) => GetFieldsImpl(t, filter, options));
	}

	private static IEnumerable<IField> GetFieldsImpl(IType baseType, Predicate<IUnresolvedField> filter, GetMemberOptions options)
	{
		IEnumerable<IField> fields = baseType.GetFields(filter, options | (GetMemberOptions.ReturnMemberDefinitions | GetMemberOptions.IgnoreInheritedMembers));
		if ((options & GetMemberOptions.ReturnMemberDefinitions) == GetMemberOptions.ReturnMemberDefinitions)
		{
			return fields;
		}
		ParameterizedType pt = baseType as ParameterizedType;
		if (pt != null)
		{
			TypeParameterSubstitution substitution = pt.GetSubstitution();
			return fields.Select((IField m) => new SpecializedField(m, substitution)
			{
				DeclaringType = pt
			});
		}
		return fields;
	}

	public static IEnumerable<IEvent> GetEvents(IType type, Predicate<IUnresolvedEvent> filter, GetMemberOptions options)
	{
		if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
		{
			return GetEventsImpl(type, filter, options);
		}
		return type.GetNonInterfaceBaseTypes().SelectMany((IType t) => GetEventsImpl(t, filter, options));
	}

	private static IEnumerable<IEvent> GetEventsImpl(IType baseType, Predicate<IUnresolvedEvent> filter, GetMemberOptions options)
	{
		IEnumerable<IEvent> events = baseType.GetEvents(filter, options | (GetMemberOptions.ReturnMemberDefinitions | GetMemberOptions.IgnoreInheritedMembers));
		if ((options & GetMemberOptions.ReturnMemberDefinitions) == GetMemberOptions.ReturnMemberDefinitions)
		{
			return events;
		}
		ParameterizedType pt = baseType as ParameterizedType;
		if (pt != null)
		{
			TypeParameterSubstitution substitution = pt.GetSubstitution();
			return events.Select((IEvent m) => new SpecializedEvent(m, substitution)
			{
				DeclaringType = pt
			});
		}
		return events;
	}

	public static IEnumerable<IMember> GetMembers(IType type, Predicate<IUnresolvedMember> filter, GetMemberOptions options)
	{
		if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
		{
			return GetMembersImpl(type, filter, options);
		}
		return type.GetNonInterfaceBaseTypes().SelectMany((IType t) => GetMembersImpl(t, filter, options));
	}

	private static IEnumerable<IMember> GetMembersImpl(IType baseType, Predicate<IUnresolvedMember> filter, GetMemberOptions options)
	{
		foreach (IMethod item in GetMethodsImpl(baseType, null, filter, options))
		{
			yield return item;
		}
		foreach (IProperty item2 in GetPropertiesImpl(baseType, filter, options))
		{
			yield return item2;
		}
		foreach (IField item3 in GetFieldsImpl(baseType, filter, options))
		{
			yield return item3;
		}
		foreach (IEvent item4 in GetEventsImpl(baseType, filter, options))
		{
			yield return item4;
		}
	}
}
