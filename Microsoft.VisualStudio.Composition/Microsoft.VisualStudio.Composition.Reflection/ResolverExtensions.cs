using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;

namespace Microsoft.VisualStudio.Composition.Reflection;

public static class ResolverExtensions
{
	private const BindingFlags AllInstanceMembers = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

	public static Type Resolve(this TypeRef typeRef)
	{
		return typeRef?.ResolvedType;
	}

	public static ConstructorInfo Resolve(this ConstructorRef constructorRef)
	{
		if (constructorRef.IsEmpty)
		{
			return null;
		}
		return (ConstructorInfo)constructorRef.Resolver.GetManifest(constructorRef.DeclaringType.AssemblyName).ResolveMethod(constructorRef.MetadataToken);
	}

	[Obsolete("Use Resolve2 instead.", true)]
	public static MethodInfo Resolve(this MethodRef methodRef)
	{
		return (MethodInfo)methodRef.Resolve2();
	}

	public static MethodBase Resolve2(this MethodRef methodRef)
	{
		if (methodRef.IsEmpty)
		{
			return null;
		}
		MethodBase methodBase = methodRef.Resolver.GetManifest(methodRef.DeclaringType.AssemblyName).ResolveMethod(methodRef.MetadataToken);
		if (methodRef.GenericMethodArguments.Length > 0)
		{
			return ((MethodInfo)methodBase).MakeGenericMethod(methodRef.GenericMethodArguments.Select(Resolve).ToArray());
		}
		return methodBase;
	}

	public static PropertyInfo Resolve(this PropertyRef propertyRef)
	{
		if (propertyRef.IsEmpty)
		{
			return null;
		}
		return propertyRef.DeclaringType.Resolve().GetRuntimeProperties().First((PropertyInfo p) => p.MetadataToken == propertyRef.MetadataToken);
	}

	public static MethodInfo ResolveGetter(this PropertyRef propertyRef)
	{
		if (propertyRef.GetMethodMetadataToken.HasValue)
		{
			return (MethodInfo)propertyRef.Resolver.GetManifest(propertyRef.DeclaringType.AssemblyName).ResolveMethod(propertyRef.GetMethodMetadataToken.Value);
		}
		return null;
	}

	public static MethodInfo ResolveSetter(this PropertyRef propertyRef)
	{
		if (propertyRef.SetMethodMetadataToken.HasValue)
		{
			return (MethodInfo)propertyRef.Resolver.GetManifest(propertyRef.DeclaringType.AssemblyName).ResolveMethod(propertyRef.SetMethodMetadataToken.Value);
		}
		return null;
	}

	public static FieldInfo Resolve(this FieldRef fieldRef)
	{
		if (fieldRef.IsEmpty)
		{
			return null;
		}
		return fieldRef.Resolver.GetManifest(fieldRef.AssemblyName).ResolveField(fieldRef.MetadataToken);
	}

	public static ParameterInfo Resolve(this ParameterRef parameterRef)
	{
		if (parameterRef.IsEmpty)
		{
			return null;
		}
		return parameterRef.Resolver.GetManifest(parameterRef.AssemblyName).ResolveMethod(parameterRef.Constructor.IsEmpty ? parameterRef.Method.MetadataToken : parameterRef.Constructor.MetadataToken).GetParameters()[parameterRef.ParameterIndex];
	}

	public static MemberInfo Resolve(this MemberRef memberRef)
	{
		if (memberRef.IsEmpty)
		{
			return null;
		}
		if (memberRef.IsField)
		{
			return memberRef.Field.FieldInfo;
		}
		if (memberRef.IsProperty)
		{
			return memberRef.Property.PropertyInfo;
		}
		if (memberRef.IsMethod)
		{
			return memberRef.Method.MethodBase;
		}
		if (memberRef.IsConstructor)
		{
			return memberRef.Constructor.ConstructorInfo;
		}
		if (memberRef.IsType)
		{
			return memberRef.Type.Resolve().GetTypeInfo();
		}
		throw new NotSupportedException();
	}

	[Obsolete("Use MemberRef instead.", true)]
	public static MemberInfo Resolve(this MemberDesc memberDesc)
	{
		throw new NotSupportedException();
	}

	internal static void GetInputAssemblies(this TypeRef typeRef, ISet<AssemblyName> assemblies)
	{
		Requires.NotNull(assemblies, "assemblies");
		if (typeRef == null)
		{
			return;
		}
		assemblies.Add(typeRef.AssemblyName);
		foreach (TypeRef genericTypeArgument in typeRef.GenericTypeArguments)
		{
			genericTypeArgument.GetInputAssemblies(assemblies);
		}
		Type type = typeRef.Resolve();
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

	internal static void GetInputAssemblies(this MemberRef memberRef, ISet<AssemblyName> assemblies)
	{
		Requires.NotNull(assemblies, "assemblies");
		if (memberRef.IsConstructor)
		{
			memberRef.Constructor.GetInputAssemblies(assemblies);
		}
		else if (memberRef.IsField)
		{
			memberRef.Field.GetInputAssemblies(assemblies);
		}
		else if (memberRef.IsMethod)
		{
			memberRef.Method.GetInputAssemblies(assemblies);
		}
		else if (memberRef.IsProperty)
		{
			memberRef.Property.GetInputAssemblies(assemblies);
		}
	}

	internal static void GetInputAssemblies(this MethodRef methodRef, ISet<AssemblyName> assemblies)
	{
		Requires.NotNull(assemblies, "assemblies");
		if (!methodRef.IsEmpty)
		{
			assemblies.Add(methodRef.DeclaringType.AssemblyName);
			foreach (TypeRef genericMethodArgument in methodRef.GenericMethodArguments)
			{
				genericMethodArgument.GetInputAssemblies(assemblies);
			}
		}
	}

	internal static void GetInputAssemblies(this PropertyRef propertyRef, ISet<AssemblyName> assemblies)
	{
		Requires.NotNull(assemblies, "assemblies");
		if (!propertyRef.IsEmpty)
		{
			propertyRef.DeclaringType.GetInputAssemblies(assemblies);
		}
	}

	internal static void GetInputAssemblies(this FieldRef fieldRef, ISet<AssemblyName> assemblies)
	{
		Requires.NotNull(assemblies, "assemblies");
		if (!fieldRef.IsEmpty)
		{
			fieldRef.DeclaringType.GetInputAssemblies(assemblies);
		}
	}

	internal static void GetInputAssemblies(this ConstructorRef constructorRef, ISet<AssemblyName> assemblies)
	{
		Requires.NotNull(assemblies, "assemblies");
		if (!constructorRef.IsEmpty)
		{
			constructorRef.DeclaringType.GetInputAssemblies(assemblies);
		}
	}

	internal static void GetInputAssemblies(this ParameterRef parameterRef, ISet<AssemblyName> assemblies)
	{
		Requires.NotNull(assemblies, "assemblies");
		if (!parameterRef.IsEmpty)
		{
			parameterRef.DeclaringType.GetInputAssemblies(assemblies);
		}
	}

	internal static Module GetManifest(this Resolver resolver, AssemblyName assemblyName)
	{
		return resolver.AssemblyLoader.LoadAssembly(assemblyName).ManifestModule;
	}

	private static T FindMethodByParameters<T>(IEnumerable<T> members, string memberName, ImmutableArray<TypeRef> parameterTypes) where T : MethodBase
	{
		Requires.NotNull(members, "members");
		foreach (T member in members)
		{
			if (member.Name != memberName)
			{
				continue;
			}
			ParameterInfo[] parameters = member.GetParameters();
			if (parameters.Length == parameterTypes.Length)
			{
				for (int i = 0; i < parameters.Length; i++)
				{
					parameterTypes[i].Equals(parameters[i].ParameterType);
				}
				return member;
			}
		}
		return null;
	}
}
