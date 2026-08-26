using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Microsoft.VisualStudio.Composition.Reflection;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public class TypeRef : IEquatable<TypeRef>, IEquatable<Type>
{
	private static readonly IEqualityComparer<AssemblyName> AssemblyNameComparer = ByValueEquality.AssemblyNameNoFastCheck;

	private readonly Resolver resolver;

	private Type resolvedType;

	private int? hashCode;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal string DebuggerDisplay => FullName;

	public AssemblyName AssemblyName { get; private set; }

	public int MetadataToken { get; private set; }

	public string FullName { get; private set; }

	public bool IsArray { get; private set; }

	public int GenericTypeParameterCount { get; private set; }

	public ImmutableArray<TypeRef> GenericTypeArguments { get; private set; }

	public MemberRef GenericParameterDeclaringMemberRef { get; private set; }

	public int GenericParameterDeclaringMemberIndex { get; private set; }

	public bool IsGenericTypeDefinition
	{
		get
		{
			if (GenericTypeParameterCount > 0)
			{
				return GenericTypeArguments.Length == 0;
			}
			return false;
		}
	}

	internal Resolver Resolver => resolver;

	internal Type ResolvedType
	{
		get
		{
			if (resolvedType == null)
			{
				Type type2;
				if ((MetadataToken & -16777216) == 33554432)
				{
					Type type = Resolver.GetManifest(AssemblyName).ResolveType(MetadataToken);
					if (GenericTypeArguments.Length > 0)
					{
						using Rental<Type[]> rental = GetResolvedTypeArray(GenericTypeArguments);
						type2 = type.MakeGenericType(rental.Value);
					}
					else
					{
						type2 = type;
					}
				}
				else
				{
					type2 = GetGenericTypeArguments(GenericParameterDeclaringMemberRef.MemberInfo)[GenericParameterDeclaringMemberIndex];
				}
				if (IsArray)
				{
					type2 = type2.MakeArrayType();
				}
				resolvedType = type2;
			}
			return resolvedType;
		}
	}

	private TypeRef(Resolver resolver, AssemblyName assemblyName, int metadataToken, string fullName, bool isArray, int genericTypeParameterCount, ImmutableArray<TypeRef> genericTypeArguments, MemberRef declaringMember, int declaringMethodParameterIndex)
	{
		Requires.NotNull(resolver, "resolver");
		Requires.NotNull(assemblyName, "assemblyName");
		Requires.Argument((metadataToken & -16777216) == 33554432, "metadataToken", Strings.NotATypeSpec);
		Requires.Argument(metadataToken != 33554432, "metadataToken", Strings.UnresolvableMetadataToken);
		Requires.NotNullOrEmpty(fullName, "fullName");
		this.resolver = resolver;
		AssemblyName = GetNormalizedAssemblyName(assemblyName);
		MetadataToken = metadataToken;
		FullName = fullName;
		IsArray = isArray;
		GenericTypeParameterCount = genericTypeParameterCount;
		GenericTypeArguments = genericTypeArguments;
		GenericParameterDeclaringMemberRef = declaringMember;
		GenericParameterDeclaringMemberIndex = declaringMethodParameterIndex;
	}

	private TypeRef(Resolver resolver, Type type)
	{
		Requires.NotNull(resolver, "resolver");
		Requires.NotNull(type, "type");
		this.resolver = resolver;
		AssemblyName = GetNormalizedAssemblyName(type.GetTypeInfo().Assembly.GetName());
		IsArray = type.IsArray;
		Type type2 = (type.IsArray ? type.GetElementType() : type);
		MetadataToken = type2.GetTypeInfo().MetadataToken;
		FullName = (type2.GetTypeInfo().IsGenericType ? type2.GetGenericTypeDefinition() : type2).FullName;
		GenericTypeParameterCount = type2.GetTypeInfo().GenericTypeParameters.Length;
		GenericTypeArguments = ((type2.GenericTypeArguments != null && type2.GenericTypeArguments.Length != 0) ? type2.GenericTypeArguments.Select((Type t) => new TypeRef(resolver, t)).ToImmutableArray() : ImmutableArray<TypeRef>.Empty);
		if (type2.IsGenericParameter)
		{
			MemberInfo member = (MemberInfo)(((object)type2.GetTypeInfo().DeclaringMethod) ?? ((object)type2.DeclaringType.GetTypeInfo()));
			GenericParameterDeclaringMemberRef = MemberRef.Get(member, resolver);
			GenericParameterDeclaringMemberIndex = Array.IndexOf(GetGenericTypeArguments(member), type2);
		}
	}

	public static TypeRef Get(Resolver resolver, AssemblyName assemblyName, int metadataToken, string fullName, bool isArray, int genericTypeParameterCount, ImmutableArray<TypeRef> genericTypeArguments)
	{
		return new TypeRef(resolver, assemblyName, metadataToken, fullName, isArray, genericTypeParameterCount, genericTypeArguments, default(MemberRef), 0);
	}

	public static TypeRef Get(Resolver resolver, AssemblyName assemblyName, int metadataToken, string fullName, bool isArray, int genericTypeParameterCount, ImmutableArray<TypeRef> genericTypeArguments, MemberRef declaringMember, int declaringMethodParameterIndex = 0)
	{
		return new TypeRef(resolver, assemblyName, metadataToken, fullName, isArray, genericTypeParameterCount, genericTypeArguments, declaringMember, declaringMethodParameterIndex);
	}

	public static TypeRef Get(Type type, Resolver resolver)
	{
		Requires.NotNull(resolver, "resolver");
		if (type == null)
		{
			return null;
		}
		TypeRef target;
		lock (resolver.InstanceCache)
		{
			if (!resolver.InstanceCache.TryGetValue(type, out var value))
			{
				target = new TypeRef(resolver, type);
				resolver.InstanceCache.Add(type, new WeakReference<TypeRef>(target));
			}
			else if (!value.TryGetTarget(out target))
			{
				target = new TypeRef(resolver, type);
				value.SetTarget(target);
			}
		}
		return target;
	}

	[Obsolete]
	public static TypeRef Get(Resolver resolver, AssemblyName assemblyName, int metadataToken, bool isArray, int genericTypeParameterCount, ImmutableArray<TypeRef> genericTypeArguments)
	{
		return Get(resolver.AssemblyLoader.LoadAssembly(assemblyName).ManifestModule.ResolveType(metadataToken), resolver);
	}

	[Obsolete]
	public static TypeRef Get(Resolver resolver, AssemblyName assemblyName, int metadataToken, bool isArray, int genericTypeParameterCount, ImmutableArray<TypeRef> genericTypeArguments, MemberRef declaringMember, int declaringMethodParameterIndex = 0)
	{
		return Get(resolver.AssemblyLoader.LoadAssembly(assemblyName).ManifestModule.ResolveType(metadataToken), resolver);
	}

	public TypeRef MakeGenericTypeRef(ImmutableArray<TypeRef> genericTypeArguments)
	{
		Requires.Argument(!genericTypeArguments.IsDefault, "genericTypeArguments", Strings.NotInitialized);
		Verify.Operation(IsGenericTypeDefinition, Strings.NotGenericTypeDefinition);
		return new TypeRef(Resolver, AssemblyName, MetadataToken, FullName, IsArray, GenericTypeParameterCount, genericTypeArguments, default(MemberRef), 0);
	}

	public override int GetHashCode()
	{
		if (!hashCode.HasValue)
		{
			hashCode = AssemblyNameComparer.GetHashCode(AssemblyName) + MetadataToken;
		}
		return hashCode.Value;
	}

	public override bool Equals(object obj)
	{
		if (obj is TypeRef other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(TypeRef other)
	{
		if (MetadataToken == other.MetadataToken && AssemblyNameComparer.Equals(AssemblyName, other.AssemblyName) && IsArray == other.IsArray && GenericTypeParameterCount == other.GenericTypeParameterCount && GenericTypeArguments.EqualsByValue(other.GenericTypeArguments) && GenericParameterDeclaringMemberRef.Equals(other.GenericParameterDeclaringMemberRef))
		{
			return GenericParameterDeclaringMemberIndex == other.GenericParameterDeclaringMemberIndex;
		}
		return false;
	}

	public bool Equals(Type other)
	{
		return Equals(Get(other, Resolver));
	}

	private static Rental<Type[]> GetResolvedTypeArray(ImmutableArray<TypeRef> typeRefs)
	{
		if (typeRefs.IsDefault)
		{
			return default(Rental<Type[]>);
		}
		Rental<Type[]> result = ArrayRental<Type>.Get(typeRefs.Length);
		for (int i = 0; i < typeRefs.Length; i++)
		{
			result.Value[i] = typeRefs[i].ResolvedType;
		}
		return result;
	}

	private static Type[] GetGenericTypeArguments(MemberInfo member)
	{
		if (member is TypeInfo typeInfo)
		{
			return typeInfo.GetGenericArguments();
		}
		if (member is MethodInfo methodInfo)
		{
			return methodInfo.GetGenericArguments();
		}
		throw new ArgumentException();
	}

	private static AssemblyName GetNormalizedAssemblyName(AssemblyName assemblyName)
	{
		Requires.NotNull(assemblyName, "assemblyName");
		AssemblyName assemblyName2 = assemblyName;
		if (assemblyName.CodeBase.IndexOf('~') >= 0)
		{
			string codeBase = new Uri(Path.GetFullPath(new Uri(assemblyName.CodeBase).LocalPath)).ToString();
			assemblyName2 = (AssemblyName)assemblyName.Clone();
			assemblyName2.CodeBase = codeBase;
		}
		return assemblyName2;
	}
}
