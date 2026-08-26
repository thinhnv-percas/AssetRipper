using System;
using System.Collections.Immutable;

namespace Microsoft.VisualStudio.Composition.Reflection;

[Obsolete("Use MethodRef instead.", true)]
public class MethodDesc : MemberDesc
{
	public MethodRef Method { get; private set; }

	public TypeRef ReturnType { get; private set; }

	public ImmutableArray<TypeRef> Parameters { get; private set; }

	public MethodDesc(MethodRef method, string name, bool isStatic, TypeRef returnType, ImmutableArray<TypeRef> parameters)
		: base(name, isStatic)
	{
		Method = method;
		ReturnType = returnType;
		Parameters = parameters;
	}
}
