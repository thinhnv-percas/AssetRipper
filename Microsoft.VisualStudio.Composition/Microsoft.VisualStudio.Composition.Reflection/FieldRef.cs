using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Microsoft.VisualStudio.Composition.Reflection;

[StructLayout(LayoutKind.Auto)]
[DebuggerDisplay("{DebuggerDisplay,nq}")]
public struct FieldRef : IEquatable<FieldRef>
{
	private readonly int? metadataToken;

	private FieldInfo fieldInfo;

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

	public int MetadataToken => metadataToken ?? fieldInfo.MetadataToken;

	public FieldInfo FieldInfo => fieldInfo ?? (fieldInfo = this.Resolve());

	public string Name { get; private set; }

	public AssemblyName AssemblyName
	{
		get
		{
			if (!IsEmpty)
			{
				return DeclaringType.AssemblyName;
			}
			return null;
		}
	}

	public bool IsEmpty => DeclaringType == null;

	internal Resolver Resolver => DeclaringType?.Resolver;

	public FieldRef(TypeRef declaringType, int metadataToken, string name)
	{
		this = default(FieldRef);
		Requires.NotNull(declaringType, "declaringType");
		Requires.NotNullOrEmpty(name, "name");
		DeclaringType = declaringType;
		this.metadataToken = metadataToken;
		Name = name;
	}

	[Obsolete]
	public FieldRef(TypeRef declaringType, int metadataToken)
		: this(declaringType, metadataToken, declaringType.Resolve().Assembly.ManifestModule.ResolveField(metadataToken).Name)
	{
	}

	public FieldRef(FieldInfo field, Resolver resolver)
		: this(TypeRef.Get(field.DeclaringType, resolver), field.MetadataToken, field.Name)
	{
		fieldInfo = field;
	}

	public bool Equals(FieldRef other)
	{
		if (IsEmpty ^ other.IsEmpty)
		{
			return false;
		}
		if (IsEmpty)
		{
			return true;
		}
		if (fieldInfo != null && other.fieldInfo != null && fieldInfo == other.fieldInfo)
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
		else if (Name != other.Name)
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
		bool num = obj is FieldRef;
		FieldRef other = (num ? ((FieldRef)obj) : default(FieldRef));
		if (num)
		{
			return Equals(other);
		}
		return false;
	}
}
