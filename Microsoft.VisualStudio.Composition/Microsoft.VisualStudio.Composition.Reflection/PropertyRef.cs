using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Microsoft.VisualStudio.Composition.Reflection;

[StructLayout(LayoutKind.Auto)]
[DebuggerDisplay("{DebuggerDisplay,nq}")]
public struct PropertyRef : IEquatable<PropertyRef>
{
	private readonly int? metadataToken;

	private readonly int? getMethodMetadataToken;

	private readonly int? setMethodMetadataToken;

	private PropertyInfo propertyInfo;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal string DebuggerDisplay
	{
		get
		{
			if (!IsEmpty)
			{
				return $"{DeclaringType.FullName}.{Name}";
			}
			return "(empty)";
		}
	}

	public TypeRef DeclaringType { get; private set; }

	public int MetadataToken => metadataToken ?? propertyInfo.MetadataToken;

	public PropertyInfo PropertyInfo => propertyInfo ?? (propertyInfo = this.Resolve());

	public int? GetMethodMetadataToken => getMethodMetadataToken ?? propertyInfo?.GetMethod?.MetadataToken;

	public int? SetMethodMetadataToken => setMethodMetadataToken ?? propertyInfo?.SetMethod?.MetadataToken;

	public string Name { get; private set; }

	public bool IsEmpty => DeclaringType == null;

	internal Resolver Resolver => DeclaringType?.Resolver;

	public PropertyRef(TypeRef declaringType, int metadataToken, int? getMethodMetadataToken, int? setMethodMetadataToken, string name)
	{
		this = default(PropertyRef);
		DeclaringType = declaringType;
		this.metadataToken = metadataToken;
		this.getMethodMetadataToken = getMethodMetadataToken;
		this.setMethodMetadataToken = setMethodMetadataToken;
		Name = name;
	}

	[Obsolete]
	public PropertyRef(TypeRef declaringType, int metadataToken, int? getMethodMetadataToken, int? setMethodMetadataToken)
		: this(declaringType, metadataToken, getMethodMetadataToken, setMethodMetadataToken, declaringType.Resolve().Assembly.ManifestModule.ResolveMember(metadataToken).Name)
	{
	}

	public PropertyRef(PropertyInfo propertyInfo, Resolver resolver)
	{
		this = default(PropertyRef);
		DeclaringType = TypeRef.Get(propertyInfo.DeclaringType, resolver);
		metadataToken = propertyInfo.MetadataToken;
		this.propertyInfo = propertyInfo;
		Name = propertyInfo.Name;
	}

	public bool Equals(PropertyRef other)
	{
		if (IsEmpty ^ other.IsEmpty)
		{
			return false;
		}
		if (IsEmpty)
		{
			return true;
		}
		if (propertyInfo != null && other.propertyInfo != null && propertyInfo == other.propertyInfo)
		{
			return true;
		}
		if (Name != other.Name)
		{
			return false;
		}
		return EqualityComparer<TypeRef>.Default.Equals(DeclaringType, other.DeclaringType);
	}

	public override int GetHashCode()
	{
		return DeclaringType.GetHashCode() + Name.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		bool num = obj is PropertyRef;
		PropertyRef other = (num ? ((PropertyRef)obj) : default(PropertyRef));
		if (num)
		{
			return Equals(other);
		}
		return false;
	}
}
