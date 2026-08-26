using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;

namespace Microsoft.VisualStudio.Composition.Reflection;

[StructLayout(LayoutKind.Auto)]
[DebuggerDisplay("{DebuggerDisplay,nq}")]
public struct MethodRef : IEquatable<MethodRef>
{
	private readonly int? metadataToken;

	private MethodBase methodBase;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal string DebuggerDisplay
	{
		get
		{
			if (!IsEmpty)
			{
				return string.Format("{0}.{1}({2})", DeclaringType.FullName, Name, string.Join(", ", ParameterTypes.Select((TypeRef p) => p.FullName)));
			}
			return "(empty)";
		}
	}

	public TypeRef DeclaringType { get; private set; }

	public int MetadataToken
	{
		get
		{
			if (metadataToken.HasValue)
			{
				return metadataToken.Value;
			}
			if (methodBase is MethodBuilder methodBuilder)
			{
				return methodBuilder.GetToken().Token;
			}
			return methodBase.MetadataToken;
		}
	}

	public MethodBase MethodBase => methodBase ?? (methodBase = this.Resolve2());

	public string Name { get; private set; }

	public ImmutableArray<TypeRef> ParameterTypes { get; private set; }

	public ImmutableArray<TypeRef> GenericMethodArguments { get; private set; }

	public bool IsEmpty => DeclaringType == null;

	internal Resolver Resolver => DeclaringType?.Resolver;

	public MethodRef(TypeRef declaringType, int metadataToken, string name, ImmutableArray<TypeRef> parameterTypes, ImmutableArray<TypeRef> genericMethodArguments)
	{
		this = default(MethodRef);
		Requires.NotNullOrEmpty(name, "name");
		DeclaringType = declaringType;
		this.metadataToken = metadataToken;
		ParameterTypes = parameterTypes;
		Name = name;
		GenericMethodArguments = genericMethodArguments;
	}

	[Obsolete]
	public MethodRef(TypeRef declaringType, int metadataToken, ImmutableArray<TypeRef> genericMethodArguments)
		: this(declaringType, metadataToken, declaringType.Resolve().Assembly.ManifestModule.ResolveMethod(metadataToken).Name, declaringType.Resolve().Assembly.ManifestModule.ResolveMethod(metadataToken).GetParameterTypes(declaringType.Resolver), genericMethodArguments)
	{
	}

	public MethodRef(MethodInfo method, Resolver resolver)
		: this((MethodBase)method, resolver)
	{
	}

	public MethodRef(MethodBase method, Resolver resolver)
		: this(method, resolver, Requires.NotNull(method, "method").GetParameterTypes(resolver))
	{
	}

	public MethodRef(MethodBase method, Resolver resolver, ImmutableArray<TypeRef> parameterTypes)
	{
		this = default(MethodRef);
		Requires.NotNull(method, "method");
		Requires.NotNull(resolver, "resolver");
		DeclaringType = TypeRef.Get(method.DeclaringType, resolver);
		ParameterTypes = parameterTypes;
		Name = method.Name;
		GenericMethodArguments = method.GetGenericTypeArguments(resolver);
		methodBase = method;
	}

	public MethodRef(ConstructorRef constructor)
		: this(constructor.DeclaringType, constructor.MetadataToken, ConstructorInfo.ConstructorName, constructor.ParameterTypes, ImmutableArray<TypeRef>.Empty)
	{
		methodBase = constructor.ConstructorInfoNoResolve;
	}

	public static MethodRef Get(MethodInfo method, Resolver resolver)
	{
		return Get((MethodBase)method, resolver);
	}

	public static MethodRef Get(MethodBase method, Resolver resolver)
	{
		if (!(method != null))
		{
			return default(MethodRef);
		}
		return new MethodRef(method, resolver);
	}

	public bool Equals(MethodRef other)
	{
		if (IsEmpty ^ other.IsEmpty)
		{
			return false;
		}
		if (IsEmpty)
		{
			return true;
		}
		if (methodBase != null && other.methodBase != null && methodBase == other.methodBase)
		{
			return true;
		}
		if (!EqualityComparer<TypeRef>.Default.Equals(DeclaringType, other.DeclaringType))
		{
			return false;
		}
		if (metadataToken.HasValue && other.metadataToken.HasValue)
		{
			if (metadataToken.Value != other.metadataToken.Value)
			{
				return false;
			}
		}
		else if (Name != other.Name || !ParameterTypes.EqualsByValue(other.ParameterTypes))
		{
			return false;
		}
		return GenericMethodArguments.EqualsByValue(other.GenericMethodArguments);
	}

	public override int GetHashCode()
	{
		return DeclaringType.GetHashCode() + Name.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		bool num = obj is MethodRef;
		MethodRef other = (num ? ((MethodRef)obj) : default(MethodRef));
		if (num)
		{
			return Equals(other);
		}
		return false;
	}
}
