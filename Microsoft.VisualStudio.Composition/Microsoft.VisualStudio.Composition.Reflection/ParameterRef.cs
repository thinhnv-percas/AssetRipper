using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Microsoft.VisualStudio.Composition.Reflection;

[StructLayout(LayoutKind.Auto)]
[DebuggerDisplay("{DebuggerDisplay,nq}")]
public struct ParameterRef : IEquatable<ParameterRef>
{
	private readonly int parameterIndex;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal string DebuggerDisplay
	{
		get
		{
			if (!IsEmpty)
			{
				return $"{DeclaringType.FullName}.{(Method.IsEmpty ? Constructor.DebuggerDisplay : Method.DebuggerDisplay)}(p-index: {ParameterIndex})";
			}
			return "(empty)";
		}
	}

	public MethodRef Method { get; private set; }

	public ConstructorRef Constructor { get; private set; }

	public TypeRef DeclaringType => Constructor.DeclaringType ?? Method.DeclaringType;

	public int MethodMetadataToken
	{
		get
		{
			if (!Constructor.IsEmpty)
			{
				return Constructor.MetadataToken;
			}
			return Method.MetadataToken;
		}
	}

	public int ParameterIndex => parameterIndex;

	public AssemblyName AssemblyName => DeclaringType.AssemblyName;

	public bool IsEmpty
	{
		get
		{
			if (Method.IsEmpty)
			{
				return Constructor.IsEmpty;
			}
			return false;
		}
	}

	internal Resolver Resolver => DeclaringType?.Resolver;

	public ParameterRef(MethodRef method, int parameterIndex)
	{
		this = default(ParameterRef);
		Method = method;
		this.parameterIndex = parameterIndex;
	}

	[Obsolete]
	public ParameterRef(TypeRef declaringType, int methodMetadataToken, int parameterIndex)
	{
		MethodBase methodBase = declaringType.Resolve().Assembly.ManifestModule.ResolveMethod(methodMetadataToken);
		if (methodBase is ConstructorInfo constructor)
		{
			Constructor = new ConstructorRef(constructor, declaringType.Resolver);
			Method = default(MethodRef);
		}
		else
		{
			Method = new MethodRef((MethodInfo)methodBase, declaringType.Resolver);
			Constructor = default(ConstructorRef);
		}
		this.parameterIndex = parameterIndex;
	}

	[Obsolete]
	public ParameterRef(ParameterInfo parameter, Resolver resolver)
	{
		MemberInfo member = parameter.Member;
		_ = member.DeclaringType;
		if (member is ConstructorInfo constructor)
		{
			Constructor = new ConstructorRef(constructor, resolver);
			Method = default(MethodRef);
		}
		else
		{
			Method = new MethodRef((MethodInfo)member, resolver);
			Constructor = default(ConstructorRef);
		}
		parameterIndex = parameter.Position;
	}

	public ParameterRef(ConstructorRef ctor, int parameterIndex)
	{
		this = default(ParameterRef);
		Constructor = ctor;
		this.parameterIndex = parameterIndex;
	}

	public static ParameterRef Get(ParameterInfo parameter, Resolver resolver)
	{
		if (parameter != null)
		{
			if (parameter.Member is ConstructorInfo constructor)
			{
				return new ParameterRef(new ConstructorRef(constructor, resolver), parameter.Position);
			}
			if (parameter.Member is MethodInfo method)
			{
				return new ParameterRef(new MethodRef(method, resolver), parameter.Position);
			}
			throw new NotSupportedException("Unsupported member type: " + parameter.Member.GetType().Name);
		}
		return default(ParameterRef);
	}

	public bool Equals(ParameterRef other)
	{
		if (Constructor.Equals(other.Constructor) && Method.Equals(other.Method))
		{
			return ParameterIndex == other.ParameterIndex;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return Method.MetadataToken + Constructor.MetadataToken + parameterIndex;
	}

	public override bool Equals(object obj)
	{
		bool num = obj is ParameterRef;
		ParameterRef other = (num ? ((ParameterRef)obj) : default(ParameterRef));
		if (num)
		{
			return Equals(other);
		}
		return false;
	}
}
