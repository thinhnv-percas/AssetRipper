using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Microsoft.VisualStudio.Composition.Reflection;

[StructLayout(LayoutKind.Auto)]
[DebuggerDisplay("{DebuggerDisplay,nq}")]
public struct MemberRef : IEquatable<MemberRef>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal string DebuggerDisplay
	{
		get
		{
			if (!IsEmpty)
			{
				if (!IsConstructor)
				{
					if (!IsField)
					{
						if (!IsProperty)
						{
							if (!IsMethod)
							{
								if (!IsType)
								{
									return "(unknown)";
								}
								return Type.DebuggerDisplay;
							}
							return Method.DebuggerDisplay;
						}
						return Property.DebuggerDisplay;
					}
					return Field.DebuggerDisplay;
				}
				return Constructor.DebuggerDisplay;
			}
			return "(empty)";
		}
	}

	public ConstructorRef Constructor { get; private set; }

	public FieldRef Field { get; private set; }

	public PropertyRef Property { get; private set; }

	public MethodRef Method { get; private set; }

	public TypeRef Type { get; private set; }

	public TypeRef DeclaringType
	{
		get
		{
			if (IsProperty)
			{
				return Property.DeclaringType;
			}
			if (IsField)
			{
				return Field.DeclaringType;
			}
			if (IsConstructor)
			{
				return Constructor.DeclaringType;
			}
			if (IsMethod)
			{
				return Method.DeclaringType;
			}
			if (IsType)
			{
				throw new NotSupportedException();
			}
			return null;
		}
	}

	public MemberInfo MemberInfo => this.Resolve();

	public bool IsEmpty
	{
		get
		{
			if (Constructor.IsEmpty && Field.IsEmpty && Property.IsEmpty && Method.IsEmpty)
			{
				return Type == null;
			}
			return false;
		}
	}

	public bool IsConstructor => !Constructor.IsEmpty;

	public bool IsField => !Field.IsEmpty;

	public bool IsProperty => !Property.IsEmpty;

	public bool IsMethod => !Method.IsEmpty;

	public bool IsType => Type != null;

	internal Resolver Resolver => DeclaringType?.Resolver;

	public MemberRef(ConstructorRef constructor)
	{
		this = default(MemberRef);
		Constructor = constructor;
	}

	public MemberRef(FieldRef field)
	{
		this = default(MemberRef);
		Field = field;
	}

	public MemberRef(PropertyRef property)
	{
		this = default(MemberRef);
		Property = property;
	}

	public MemberRef(MethodRef method)
	{
		this = default(MemberRef);
		Method = method;
	}

	public MemberRef(TypeRef type)
	{
		this = default(MemberRef);
		Type = type;
	}

	public MemberRef(MemberInfo member, Resolver resolver)
	{
		this = default(MemberRef);
		Requires.NotNull(member, "member");
		switch (member.MemberType)
		{
		case MemberTypes.Constructor:
			Constructor = new ConstructorRef((ConstructorInfo)member, resolver);
			return;
		case MemberTypes.Field:
			Field = new FieldRef((FieldInfo)member, resolver);
			return;
		case MemberTypes.Method:
			Method = new MethodRef((MethodInfo)member, resolver);
			return;
		case MemberTypes.Property:
			Property = new PropertyRef((PropertyInfo)member, resolver);
			return;
		}
		if (member is TypeInfo typeInfo)
		{
			Type = TypeRef.Get(typeInfo.AsType(), resolver);
			return;
		}
		throw new NotSupportedException();
	}

	public static MemberRef Get(MemberInfo member, Resolver resolver)
	{
		if (!(member != null))
		{
			return default(MemberRef);
		}
		return new MemberRef(member, resolver);
	}

	public bool Equals(MemberRef other)
	{
		if (Constructor.Equals(other.Constructor) && Field.Equals(other.Field) && Property.Equals(other.Property) && Method.Equals(other.Method))
		{
			return EqualityComparer<TypeRef>.Default.Equals(Type, other.Type);
		}
		return false;
	}

	public override int GetHashCode()
	{
		if (!IsField)
		{
			if (!IsProperty)
			{
				if (!IsMethod)
				{
					if (!IsConstructor)
					{
						if (!IsType)
						{
							return 0;
						}
						return Type.GetHashCode();
					}
					return Constructor.GetHashCode();
				}
				return Method.GetHashCode();
			}
			return Property.GetHashCode();
		}
		return Field.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is MemberRef)
		{
			return Equals((MemberRef)obj);
		}
		return false;
	}
}
