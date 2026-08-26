using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Microsoft.VisualStudio.Composition.Reflection;

[StructLayout(LayoutKind.Auto)]
[DebuggerDisplay("{DebuggerDisplay,nq}")]
public struct ConstructorRef : IEquatable<ConstructorRef>
{
	private readonly int? metadataToken;

	private ConstructorInfo constructorInfo;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal string DebuggerDisplay
	{
		get
		{
			if (!IsEmpty)
			{
				return string.Format("{0}.{1}({2})", DeclaringType.FullName, ConstructorInfo.ConstructorName, string.Join(", ", ParameterTypes.Select((TypeRef p) => p.FullName)));
			}
			return "(empty)";
		}
	}

	public TypeRef DeclaringType { get; private set; }

	public int MetadataToken => metadataToken ?? constructorInfo.MetadataToken;

	public ConstructorInfo ConstructorInfo => constructorInfo ?? (constructorInfo = this.Resolve());

	public ImmutableArray<TypeRef> ParameterTypes { get; private set; }

	public bool IsEmpty => DeclaringType == null;

	internal Resolver Resolver => DeclaringType?.Resolver;

	internal ConstructorInfo ConstructorInfoNoResolve => constructorInfo;

	public ConstructorRef(TypeRef declaringType, int metadataToken, ImmutableArray<TypeRef> parameterTypes)
	{
		this = default(ConstructorRef);
		Requires.NotNull(declaringType, "declaringType");
		if (parameterTypes.IsDefault)
		{
			throw new ArgumentNullException("parameterTypes");
		}
		DeclaringType = declaringType;
		this.metadataToken = metadataToken;
		ParameterTypes = parameterTypes;
	}

	[Obsolete]
	public ConstructorRef(TypeRef declaringType, int metadataToken)
		: this(declaringType, metadataToken, declaringType.Resolve().Assembly.ManifestModule.ResolveMethod(metadataToken).GetParameterTypes(declaringType.Resolver))
	{
	}

	public ConstructorRef(ConstructorInfo constructor, Resolver resolver)
		: this(TypeRef.Get(constructor.DeclaringType, resolver), constructor.MetadataToken, constructor.GetParameterTypes(resolver))
	{
	}

	public static ConstructorRef Get(ConstructorInfo constructor, Resolver resolver)
	{
		if (!(constructor != null))
		{
			return default(ConstructorRef);
		}
		return new ConstructorRef(constructor, resolver);
	}

	public bool Equals(ConstructorRef other)
	{
		if (IsEmpty ^ other.IsEmpty)
		{
			return false;
		}
		if (IsEmpty)
		{
			return true;
		}
		if (constructorInfo != null && other.constructorInfo != null && constructorInfo == other.constructorInfo)
		{
			return true;
		}
		if (metadataToken.HasValue && other.metadataToken.HasValue)
		{
			if (metadataToken.Value != other.metadataToken.Value)
			{
				return false;
			}
		}
		else if (!ParameterTypes.EqualsByValue(other.ParameterTypes))
		{
			return false;
		}
		return EqualityComparer<TypeRef>.Default.Equals(DeclaringType, other.DeclaringType);
	}

	public override int GetHashCode()
	{
		return DeclaringType.GetHashCode() + ParameterTypes.Length;
	}

	public override bool Equals(object obj)
	{
		bool num = obj is ConstructorRef;
		ConstructorRef other = (num ? ((ConstructorRef)obj) : default(ConstructorRef));
		if (num)
		{
			return Equals(other);
		}
		return false;
	}
}
