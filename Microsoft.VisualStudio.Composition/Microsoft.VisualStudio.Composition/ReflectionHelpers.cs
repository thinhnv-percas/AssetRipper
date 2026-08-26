using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Composition.Reflection;

namespace Microsoft.VisualStudio.Composition;

public static class ReflectionHelpers
{
	internal enum Assignability
	{
		Definitely,
		Maybe,
		DefinitelyNot
	}

	private static readonly Assembly Mscorlib = typeof(int).GetTypeInfo().Assembly;

	public static Func<object> CreateFuncOfType(Type typeArg, Func<object> func)
	{
		return func.As(typeArg);
	}

	internal static bool IsEquivalentTo(this Type type1, Type type2)
	{
		Requires.NotNull(type1, "type1");
		Requires.NotNull(type2, "type2");
		if (type1 == type2)
		{
			return true;
		}
		TypeInfo typeInfo = type1.GetTypeInfo();
		TypeInfo typeInfo2 = type2.GetTypeInfo();
		if (typeInfo.IsAssignableFrom(typeInfo2))
		{
			return typeInfo2.IsAssignableFrom(typeInfo);
		}
		return false;
	}

	internal static Assignability IsAssignableTo(ImportDefinitionBinding import, ExportDefinitionBinding export)
	{
		Requires.NotNull(import, "import");
		Requires.NotNull(export, "export");
		Type importingSiteElementType = import.ImportingSiteElementType;
		Type type = export.ExportedValueType;
		if (type.GetTypeInfo().IsGenericTypeDefinition && importingSiteElementType.GetTypeInfo().IsGenericType)
		{
			type = type.MakeGenericType(importingSiteElementType.GenericTypeArguments);
		}
		if (typeof(Delegate).GetTypeInfo().IsAssignableFrom(importingSiteElementType.GetTypeInfo()) && typeof(Delegate).GetTypeInfo().IsAssignableFrom(type.GetTypeInfo()))
		{
			try
			{
				((MethodInfo)export.ExportingMember).CreateDelegate(importingSiteElementType, null);
				return Assignability.Definitely;
			}
			catch (ArgumentException)
			{
				return Assignability.DefinitelyNot;
			}
		}
		if (importingSiteElementType.GetTypeInfo().IsAssignableFrom(type.GetTypeInfo()))
		{
			return Assignability.Definitely;
		}
		if (export.ExportingMemberRef.IsEmpty || type.GetTypeInfo().IsSealed)
		{
			return Assignability.DefinitelyNot;
		}
		if (importingSiteElementType.GetTypeInfo().IsInterface || type.GetTypeInfo().IsAssignableFrom(importingSiteElementType))
		{
			return Assignability.Maybe;
		}
		return Assignability.DefinitelyNot;
	}

	internal static ImmutableArray<TypeRef> GetParameterTypes(this MethodBase method, Resolver resolver)
	{
		Requires.NotNull(method, "method");
		return (from pi in method.GetParameters()
			select TypeRef.Get(pi.ParameterType, resolver)).ToImmutableArray();
	}

	internal static ImmutableArray<TypeRef> GetGenericTypeArguments(this MethodBase methodBase, Resolver resolver)
	{
		Requires.NotNull(methodBase, "methodBase");
		return (methodBase as MethodInfo)?.GetGenericArguments()?.Select((Type t) => TypeRef.Get(t, resolver)).ToImmutableArray() ?? ImmutableArray<TypeRef>.Empty;
	}

	internal static IEnumerable<PropertyInfo> EnumProperties(this Type type)
	{
		Requires.NotNull(type, "type");
		List<Type> list = new List<Type> { type };
		if (type.GetTypeInfo().IsInterface)
		{
			list.AddRange(type.GetTypeInfo().ImplementedInterfaces);
		}
		else
		{
			while (type != null)
			{
				type = type.GetTypeInfo().BaseType;
				if (type != null)
				{
					list.Add(type);
				}
			}
		}
		return list.SelectMany((Type t) => t.GetTypeInfo().DeclaredProperties);
	}

	internal static IEnumerable<Type> EnumTypeAndBaseTypes(this Type type)
	{
		Requires.NotNull(type, "type");
		while (type != null)
		{
			yield return type;
			type = type.GetTypeInfo().BaseType;
		}
	}

	internal static IEnumerable<PropertyInfo> WherePublicInstance(this IEnumerable<PropertyInfo> infos)
	{
		return infos.Where((PropertyInfo p) => p.GetMethod.IsPublicInstance() || p.SetMethod.IsPublicInstance());
	}

	internal static bool IsStatic(this MemberInfo exportingMember)
	{
		if (exportingMember == null)
		{
			return false;
		}
		FieldInfo fieldInfo = exportingMember as FieldInfo;
		if (fieldInfo != null)
		{
			return fieldInfo.IsStatic;
		}
		MethodInfo methodInfo = exportingMember as MethodInfo;
		if (methodInfo != null)
		{
			return methodInfo.IsStatic;
		}
		PropertyInfo propertyInfo = exportingMember as PropertyInfo;
		if (propertyInfo != null)
		{
			return (propertyInfo.GetMethod ?? propertyInfo.SetMethod).IsStatic;
		}
		throw new NotSupportedException();
	}

	internal static Type GetMemberType(MemberInfo fieldOrPropertyOrType)
	{
		Requires.NotNull(fieldOrPropertyOrType, "fieldOrPropertyOrType");
		if ((object)fieldOrPropertyOrType != null)
		{
			if (fieldOrPropertyOrType is TypeInfo typeInfo)
			{
				return typeInfo.AsType();
			}
			if (fieldOrPropertyOrType is PropertyInfo propertyInfo)
			{
				return propertyInfo.PropertyType;
			}
			if (fieldOrPropertyOrType is FieldInfo fieldInfo)
			{
				return fieldInfo.FieldType;
			}
		}
		throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Strings.UnexpectedMemberType, new object[1] { fieldOrPropertyOrType.MemberType }));
	}

	internal static bool IsPublicInstance(this MethodInfo methodInfo)
	{
		if (methodInfo.IsPublic)
		{
			return !methodInfo.IsStatic;
		}
		return false;
	}

	internal static string GetTypeName(Type type, bool genericTypeDefinition, bool evenNonPublic, HashSet<Assembly> relevantAssemblies, HashSet<Type> relevantEmbeddedTypes)
	{
		Requires.NotNull(type, "type");
		if (type.IsArray)
		{
			return GetTypeName(type.GetElementType(), genericTypeDefinition, evenNonPublic, relevantAssemblies, relevantEmbeddedTypes) + "[]";
		}
		if (relevantAssemblies != null)
		{
			relevantAssemblies.Add(type.GetTypeInfo().Assembly);
			relevantAssemblies.UnionWith(from t in GetAllBaseTypesAndInterfaces(type)
				select t.GetTypeInfo().Assembly);
		}
		if (relevantEmbeddedTypes != null)
		{
			AddEmbeddedInterfaces(type, relevantEmbeddedTypes);
		}
		if (type.IsGenericParameter)
		{
			return type.Name;
		}
		if (!IsPublic(type, checkGenericTypeArgs: true) && !evenNonPublic)
		{
			return GetTypeName(type.GetTypeInfo().BaseType ?? typeof(object), genericTypeDefinition, evenNonPublic, relevantAssemblies, relevantEmbeddedTypes);
		}
		if (type.IsEquivalentTo(typeof(ValueType)))
		{
			return "object";
		}
		string text = string.Empty;
		if (type.DeclaringType != null)
		{
			TypeInfo typeInfo = type.DeclaringType.GetTypeInfo();
			text = GetTypeName((typeInfo.ContainsGenericParameters && type.GenericTypeArguments.Length > typeInfo.GenericTypeArguments.Length) ? type.DeclaringType.MakeGenericType(type.GenericTypeArguments.Take(typeInfo.GenericTypeParameters.Length).ToArray()) : type.DeclaringType, genericTypeDefinition, evenNonPublic, relevantAssemblies, relevantEmbeddedTypes) + ".";
		}
		if (genericTypeDefinition)
		{
			return text + FilterTypeNameForGenericTypeDefinition(type, type.DeclaringType == null);
		}
		string[] typeArguments = type.GetTypeInfo().GenericTypeArguments.Select((Type t) => GetTypeName(t, genericTypeDefinition: false, evenNonPublic, relevantAssemblies, relevantEmbeddedTypes)).ToArray();
		return text + ReplaceBackTickWithTypeArgs((type.DeclaringType == null) ? type.FullName : type.Name, typeArguments);
	}

	private static void AddEmbeddedInterfaces(Type type, HashSet<Type> relevantEmbeddedTypes, ImmutableStack<Type> observedTypes = null)
	{
		Requires.NotNull(type, "type");
		Requires.NotNull(relevantEmbeddedTypes, "relevantEmbeddedTypes");
		observedTypes = observedTypes ?? ImmutableStack<Type>.Empty;
		if (observedTypes.Contains(type))
		{
			return;
		}
		observedTypes = observedTypes.Push(type);
		if (type.GetTypeInfo().Assembly != Mscorlib)
		{
			if (type.IsEmbeddedType())
			{
				relevantEmbeddedTypes.Add(type);
			}
			if (type.GetTypeInfo().BaseType != null)
			{
				AddEmbeddedInterfaces(type.GetTypeInfo().BaseType, relevantEmbeddedTypes, observedTypes);
			}
			foreach (Type implementedInterface in type.GetTypeInfo().ImplementedInterfaces)
			{
				AddEmbeddedInterfaces(implementedInterface, relevantEmbeddedTypes, observedTypes);
			}
		}
		if (type.GetTypeInfo().IsGenericType)
		{
			Type[] genericTypeArguments = type.GenericTypeArguments;
			for (int i = 0; i < genericTypeArguments.Length; i++)
			{
				AddEmbeddedInterfaces(genericTypeArguments[i], relevantEmbeddedTypes, observedTypes);
			}
		}
	}

	internal static string ReplaceBackTickWithTypeArgs(string originalName, params string[] typeArguments)
	{
		Requires.NotNullOrEmpty(originalName, "originalName");
		string text = originalName;
		int num = originalName.IndexOf('`');
		if (num >= 0)
		{
			int length = originalName.ToCharArray().Skip(num + 1).TakeWhile((char ch) => char.IsDigit(ch))
				.Count();
			text = originalName.Substring(0, text.IndexOf('`'));
			text += "<";
			int num2 = originalName.IndexOf('[', num + 1);
			string text2 = originalName.Substring(num + 1, length);
			if (num2 >= 0)
			{
				text2 = text2.Substring(0, num2 - num - 1);
			}
			int num3 = int.Parse(text2, CultureInfo.InvariantCulture);
			if (typeArguments == null || typeArguments.Length == 0)
			{
				if (num3 == 1)
				{
					text += "T";
				}
				else
				{
					for (int num4 = 1; num4 <= num3; num4++)
					{
						text = text + "T" + num4;
						if (num4 < num3)
						{
							text += ",";
						}
					}
				}
			}
			else
			{
				Requires.Argument(typeArguments.Length == num3, "typeArguments", Strings.WrongLength);
				text += string.Join(",", typeArguments);
			}
			text += ">";
		}
		return text;
	}

	internal static bool IsPublic(Type type, bool checkGenericTypeArgs = false)
	{
		Requires.NotNull(type, "type");
		TypeInfo typeInfo = type.GetTypeInfo();
		if (typeInfo.IsNotPublic)
		{
			return false;
		}
		if (typeInfo.IsArray)
		{
			return IsPublic(typeInfo.GetElementType(), checkGenericTypeArgs);
		}
		if (checkGenericTypeArgs && typeInfo.IsGenericType && !typeInfo.IsGenericTypeDefinition && typeInfo.GenericTypeArguments.Any((Type t) => !IsPublic(t, checkGenericTypeArgs: true) || t.IsEmbeddedType()))
		{
			return false;
		}
		if (typeInfo.IsPublic || typeInfo.IsNestedPublic)
		{
			return true;
		}
		return false;
	}

	internal static bool HasBaseclassOf(this Type type, Type baseClass)
	{
		if (type == baseClass)
		{
			return false;
		}
		while (type != null)
		{
			if (type == baseClass)
			{
				return true;
			}
			type = type.GetTypeInfo().BaseType;
		}
		return false;
	}

	internal static bool IsEmbeddedType(this Type type)
	{
		Requires.NotNull(type, "type");
		TypeInfo typeInfo = type.GetTypeInfo();
		if (typeInfo.IsInterface && typeInfo.IsAttributeDefined<TypeIdentifierAttribute>() && typeInfo.IsAttributeDefined<GuidAttribute>())
		{
			return true;
		}
		return false;
	}

	internal static bool IsEmbeddableAssembly(this Assembly assembly)
	{
		Requires.NotNull(assembly, "assembly");
		return assembly.GetCustomAttributes().Any((Attribute a) => a.GetType().FullName == "System.Runtime.InteropServices.PrimaryInteropAssemblyAttribute" || a.GetType().FullName == "System.Runtime.InteropServices.ImportedFromTypeLibAttribute");
	}

	internal static Type CloseGenericType(Type genericTypeDefinition, Type constructedType)
	{
		using Rental<Type[]> rental = ExtractGenericTypeArguments(genericTypeDefinition, constructedType);
		return genericTypeDefinition.MakeGenericType(rental.Value);
	}

	internal static Rental<Type[]> ExtractGenericTypeArguments(Type genericTypeDefinition, Type constructedType)
	{
		Requires.NotNull(genericTypeDefinition, "genericTypeDefinition");
		Requires.NotNull(constructedType, "constructedType");
		TypeInfo typeInfo = genericTypeDefinition.GetTypeInfo();
		Type type = constructedType;
		while (type != null && (!type.GetTypeInfo().IsGenericType || !typeInfo.IsAssignableFrom(type.GetGenericTypeDefinition().GetTypeInfo())))
		{
			type = type.GetTypeInfo().BaseType;
		}
		Requires.Argument(type != null, "constructedType", Strings.NotClosedFormOfOther);
		Rental<Type[]> result = ArrayRental<Type>.Get(typeInfo.GenericTypeParameters.Length);
		for (int i = 0; i < result.Value.Length; i++)
		{
			result.Value[i] = type.GenericTypeArguments[i];
		}
		return result;
	}

	internal static Type GetExportedValueType(Type declaringType, MemberInfo exportingMember)
	{
		if (exportingMember == null)
		{
			return declaringType;
		}
		if (exportingMember is FieldInfo || exportingMember is PropertyInfo)
		{
			return GetMemberType(exportingMember);
		}
		MethodInfo methodInfo = exportingMember as MethodInfo;
		if (methodInfo != null)
		{
			return GetContractTypeForDelegate(methodInfo);
		}
		throw new NotSupportedException();
	}

	internal static Type GetContractTypeForDelegate(MethodInfo method)
	{
		Requires.NotNull(method, "method");
		ParameterInfo[] parameters = method.GetParameters();
		Type[] array = new Type[parameters.Length + 1];
		array[parameters.Length] = method.ReturnType;
		for (int i = 0; i < parameters.Length; i++)
		{
			array[i] = parameters[i].ParameterType;
		}
		return Expression.GetDelegateType(array);
	}

	internal static Attribute Instantiate(this CustomAttributeData attributeData)
	{
		Requires.NotNull(attributeData, "attributeData");
		Attribute attribute = (Attribute)attributeData.Constructor.Invoke(attributeData.ConstructorArguments.Select((CustomAttributeTypedArgument ca) => ca.Value).ToArray());
		foreach (CustomAttributeNamedArgument namedArgument in attributeData.NamedArguments)
		{
			if (namedArgument.IsField)
			{
				FieldInfo field = attributeData.AttributeType.GetField(namedArgument.MemberName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				Assumes.NotNull(field);
				field.SetValue(attribute, namedArgument.TypedValue.Value);
			}
			else
			{
				PropertyInfo property = attributeData.AttributeType.GetProperty(namedArgument.MemberName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				Assumes.NotNull(property);
				property.SetValue(attribute, namedArgument.TypedValue.Value);
			}
		}
		return attribute;
	}

	internal static void GetInputAssembliesFromMetadata(ISet<AssemblyName> assemblies, IReadOnlyDictionary<string, object> metadata)
	{
		Requires.NotNull(assemblies, "assemblies");
		Requires.NotNull(metadata, "metadata");
		metadata = LazyMetadataWrapper.TryUnwrap(metadata);
		foreach (object item in metadata.Values.Where((object v) => v != null))
		{
			Type type = item as Type;
			Type type2 = item.GetType();
			if (typeof(LazyMetadataWrapper.Enum32Substitution) == type2)
			{
				((LazyMetadataWrapper.Enum32Substitution)item).EnumType.GetInputAssemblies(assemblies);
			}
			else if (typeof(LazyMetadataWrapper.TypeSubstitution) == type2)
			{
				((LazyMetadataWrapper.TypeSubstitution)item).TypeRef.GetInputAssemblies(assemblies);
			}
			else if (typeof(LazyMetadataWrapper.TypeArraySubstitution) == type2)
			{
				foreach (TypeRef item2 in ((LazyMetadataWrapper.TypeArraySubstitution)item).TypeRefArray)
				{
					item2.GetInputAssemblies(assemblies);
				}
			}
			else if (type != null)
			{
				GetTypeAndBaseTypeAssemblies(assemblies, type);
			}
			else if (item.GetType().IsArray)
			{
				if (item is object[] source)
				{
					foreach (object item3 in source.Where((object o) => o != null))
					{
						Type type3 = item3 as Type;
						if (type3 != null)
						{
							GetTypeAndBaseTypeAssemblies(assemblies, type3);
						}
						else
						{
							GetTypeAndBaseTypeAssemblies(assemblies, item3.GetType());
						}
					}
				}
				else
				{
					GetTypeAndBaseTypeAssemblies(assemblies, item.GetType());
				}
			}
			else
			{
				GetTypeAndBaseTypeAssemblies(assemblies, item.GetType());
			}
		}
	}

	private static string FilterTypeNameForGenericTypeDefinition(Type type, bool fullName)
	{
		Requires.NotNull(type, "type");
		string text = (fullName ? type.FullName : type.Name);
		if (type.GetTypeInfo().IsGenericType && text.IndexOf('`') >= 0)
		{
			text = text.Substring(0, text.IndexOf('`'));
			text += "<";
			int num = Math.Max(type.GenericTypeArguments.Length, type.GetTypeInfo().GenericTypeParameters.Length);
			text += new string(',', num - 1);
			text += ">";
		}
		return text;
	}

	private static void GetTypeAndBaseTypeAssemblies(ISet<AssemblyName> assemblies, Type type)
	{
		Requires.NotNull(assemblies, "assemblies");
		Requires.NotNull(type, "type");
		foreach (Type item in type.EnumTypeAndBaseTypes())
		{
			assemblies.Add(item.GetTypeInfo().Assembly.GetName());
		}
		Type[] interfaces = type.GetTypeInfo().GetInterfaces();
		foreach (Type type2 in interfaces)
		{
			assemblies.Add(type2.GetTypeInfo().Assembly.GetName());
		}
	}

	private static IEnumerable<Type> GetAllBaseTypesAndInterfaces(Type type)
	{
		Requires.NotNull(type, "type");
		Type baseType = type.GetTypeInfo().BaseType;
		while (baseType != null)
		{
			yield return baseType;
			baseType = baseType.GetTypeInfo().BaseType;
		}
		foreach (Type implementedInterface in type.GetTypeInfo().ImplementedInterfaces)
		{
			yield return implementedInterface;
		}
	}
}
