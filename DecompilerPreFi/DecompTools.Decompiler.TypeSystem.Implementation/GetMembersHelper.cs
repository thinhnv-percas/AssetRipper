using System;
using System.Collections.Generic;
using System.Linq;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.TypeSystem.Implementation;

internal static class GetMembersHelper
{
	private const GetMemberOptions declaredMembers = GetMemberOptions.ReturnMemberDefinitions | GetMemberOptions.IgnoreInheritedMembers;

	public static IEnumerable<IType> GetNestedTypes(IType type, Predicate<ITypeDefinition> filter, GetMemberOptions options)
	{
		return GetNestedTypes(type, null, filter, options);
	}

	public static IEnumerable<IType> GetNestedTypes(IType type, IReadOnlyList<IType> nestedTypeArguments, Predicate<ITypeDefinition> filter, GetMemberOptions options)
	{
		if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
		{
			return GetNestedTypesImpl(type, nestedTypeArguments, filter, options);
		}
		return Enumerable.SelectMany<IType, IType>(type.GetNonInterfaceBaseTypes(), (Func<IType, IEnumerable<IType>>)((IType t) => GetNestedTypesImpl(t, nestedTypeArguments, filter, options)));
	}

	private static IEnumerable<IType> GetNestedTypesImpl(IType outerType, IReadOnlyList<IType> nestedTypeArguments, Predicate<ITypeDefinition> filter, GetMemberOptions options)
	{
		ITypeDefinition outerTypeDef = outerType.GetDefinition();
		if (outerTypeDef == null)
		{
			yield break;
		}
		int outerTypeParameterCount = outerTypeDef.TypeParameterCount;
		ParameterizedType pt = outerType as ParameterizedType;
		checked
		{
			foreach (ITypeDefinition nestedType in outerTypeDef.NestedTypes)
			{
				int totalTypeParameterCount = nestedType.TypeParameterCount;
				if ((nestedTypeArguments != null && totalTypeParameterCount - outerTypeParameterCount != nestedTypeArguments.Count) || (filter != null && !filter(nestedType)))
				{
					continue;
				}
				if (totalTypeParameterCount == 0 || (options & GetMemberOptions.ReturnMemberDefinitions) == GetMemberOptions.ReturnMemberDefinitions)
				{
					yield return nestedType;
					continue;
				}
				IType[] newTypeArguments = new IType[totalTypeParameterCount];
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
					newTypeArguments[num] = type2;
				}
				for (int j = outerTypeParameterCount; j < totalTypeParameterCount; j++)
				{
					if (nestedTypeArguments != null)
					{
						newTypeArguments[j] = nestedTypeArguments[j - outerTypeParameterCount];
					}
					else
					{
						newTypeArguments[j] = SpecialType.UnboundTypeArgument;
					}
				}
				yield return new ParameterizedType(nestedType, newTypeArguments);
			}
		}
	}

	public static IEnumerable<IMethod> GetMethods(IType type, Predicate<IMethod> filter, GetMemberOptions options)
	{
		return GetMethods(type, null, filter, options);
	}

	public static IEnumerable<IMethod> GetMethods(IType type, IReadOnlyList<IType> typeArguments, Predicate<IMethod> filter, GetMemberOptions options)
	{
		if (typeArguments != null && typeArguments.Count > 0)
		{
			filter = FilterTypeParameterCount(typeArguments.Count).And(filter);
		}
		if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
		{
			return GetMethodsImpl(type, typeArguments, filter, options);
		}
		return Enumerable.SelectMany<IType, IMethod>(type.GetNonInterfaceBaseTypes(), (Func<IType, IEnumerable<IMethod>>)((IType t) => GetMethodsImpl(t, typeArguments, filter, options)));
	}

	private static Predicate<IMethod> FilterTypeParameterCount(int expectedTypeParameterCount)
	{
		return (IMethod m) => m.TypeParameters.Count == expectedTypeParameterCount;
	}

	private static IEnumerable<IMethod> GetMethodsImpl(IType baseType, IReadOnlyList<IType> methodTypeArguments, Predicate<IMethod> filter, GetMemberOptions options)
	{
		IEnumerable<IMethod> declaredMethods = baseType.GetMethods(filter, options | (GetMemberOptions.ReturnMemberDefinitions | GetMemberOptions.IgnoreInheritedMembers));
		ParameterizedType pt = baseType as ParameterizedType;
		if ((options & GetMemberOptions.ReturnMemberDefinitions) == 0 && (pt != null || (methodTypeArguments != null && methodTypeArguments.Count > 0)))
		{
			TypeParameterSubstitution substitution = null;
			foreach (IMethod m in declaredMethods)
			{
				if (methodTypeArguments == null || methodTypeArguments.Count <= 0 || m.TypeParameters.Count == methodTypeArguments.Count)
				{
					if (substitution == null)
					{
						substitution = ((pt == null) ? new TypeParameterSubstitution(null, methodTypeArguments) : pt.GetSubstitution(methodTypeArguments));
					}
					yield return new SpecializedMethod(m, substitution);
				}
			}
			yield break;
		}
		foreach (IMethod item in declaredMethods)
		{
			yield return item;
		}
	}

	public static IEnumerable<IMethod> GetAccessors(IType type, Predicate<IMethod> filter, GetMemberOptions options)
	{
		if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
		{
			return GetAccessorsImpl(type, filter, options);
		}
		return Enumerable.SelectMany<IType, IMethod>(type.GetNonInterfaceBaseTypes(), (Func<IType, IEnumerable<IMethod>>)((IType t) => GetAccessorsImpl(t, filter, options)));
	}

	private static IEnumerable<IMethod> GetAccessorsImpl(IType baseType, Predicate<IMethod> filter, GetMemberOptions options)
	{
		return GetConstructorsOrAccessorsImpl(baseType, baseType.GetAccessors(filter, options | (GetMemberOptions.ReturnMemberDefinitions | GetMemberOptions.IgnoreInheritedMembers)), options);
	}

	public static IEnumerable<IMethod> GetConstructors(IType type, Predicate<IMethod> filter, GetMemberOptions options)
	{
		if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
		{
			return GetConstructorsImpl(type, filter, options);
		}
		return Enumerable.SelectMany<IType, IMethod>(type.GetNonInterfaceBaseTypes(), (Func<IType, IEnumerable<IMethod>>)((IType t) => GetConstructorsImpl(t, filter, options)));
	}

	private static IEnumerable<IMethod> GetConstructorsImpl(IType baseType, Predicate<IMethod> filter, GetMemberOptions options)
	{
		return GetConstructorsOrAccessorsImpl(baseType, baseType.GetConstructors(filter, options | (GetMemberOptions.ReturnMemberDefinitions | GetMemberOptions.IgnoreInheritedMembers)), options);
	}

	private static IEnumerable<IMethod> GetConstructorsOrAccessorsImpl(IType baseType, IEnumerable<IMethod> declaredMembers, GetMemberOptions options)
	{
		if ((options & GetMemberOptions.ReturnMemberDefinitions) == GetMemberOptions.ReturnMemberDefinitions)
		{
			return declaredMembers;
		}
		ParameterizedType pt = baseType as ParameterizedType;
		if (pt != null)
		{
			TypeParameterSubstitution substitution = pt.GetSubstitution();
			return Enumerable.Select<IMethod, SpecializedMethod>(declaredMembers, (Func<IMethod, SpecializedMethod>)((IMethod m) => new SpecializedMethod(m, substitution)
			{
				DeclaringType = pt
			}));
		}
		return declaredMembers;
	}

	public static IEnumerable<IProperty> GetProperties(IType type, Predicate<IProperty> filter, GetMemberOptions options)
	{
		if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
		{
			return GetPropertiesImpl(type, filter, options);
		}
		return Enumerable.SelectMany<IType, IProperty>(type.GetNonInterfaceBaseTypes(), (Func<IType, IEnumerable<IProperty>>)((IType t) => GetPropertiesImpl(t, filter, options)));
	}

	private static IEnumerable<IProperty> GetPropertiesImpl(IType baseType, Predicate<IProperty> filter, GetMemberOptions options)
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
			return Enumerable.Select<IProperty, SpecializedProperty>(properties, (Func<IProperty, SpecializedProperty>)((IProperty m) => new SpecializedProperty(m, substitution)
			{
				DeclaringType = pt
			}));
		}
		return properties;
	}

	public static IEnumerable<IField> GetFields(IType type, Predicate<IField> filter, GetMemberOptions options)
	{
		if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
		{
			return GetFieldsImpl(type, filter, options);
		}
		return Enumerable.SelectMany<IType, IField>(type.GetNonInterfaceBaseTypes(), (Func<IType, IEnumerable<IField>>)((IType t) => GetFieldsImpl(t, filter, options)));
	}

	private static IEnumerable<IField> GetFieldsImpl(IType baseType, Predicate<IField> filter, GetMemberOptions options)
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
			return Enumerable.Select<IField, SpecializedField>(fields, (Func<IField, SpecializedField>)((IField m) => new SpecializedField(m, substitution)
			{
				DeclaringType = pt
			}));
		}
		return fields;
	}

	public static IEnumerable<IEvent> GetEvents(IType type, Predicate<IEvent> filter, GetMemberOptions options)
	{
		if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
		{
			return GetEventsImpl(type, filter, options);
		}
		return Enumerable.SelectMany<IType, IEvent>(type.GetNonInterfaceBaseTypes(), (Func<IType, IEnumerable<IEvent>>)((IType t) => GetEventsImpl(t, filter, options)));
	}

	private static IEnumerable<IEvent> GetEventsImpl(IType baseType, Predicate<IEvent> filter, GetMemberOptions options)
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
			return Enumerable.Select<IEvent, SpecializedEvent>(events, (Func<IEvent, SpecializedEvent>)((IEvent m) => new SpecializedEvent(m, substitution)
			{
				DeclaringType = pt
			}));
		}
		return events;
	}

	public static IEnumerable<IMember> GetMembers(IType type, Predicate<IMember> filter, GetMemberOptions options)
	{
		if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
		{
			return GetMembersImpl(type, filter, options);
		}
		return Enumerable.SelectMany<IType, IMember>(type.GetNonInterfaceBaseTypes(), (Func<IType, IEnumerable<IMember>>)((IType t) => GetMembersImpl(t, filter, options)));
	}

	private static IEnumerable<IMember> GetMembersImpl(IType baseType, Predicate<IMember> filter, GetMemberOptions options)
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
