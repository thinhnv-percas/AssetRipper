using System;

namespace Microsoft.VisualStudio.Composition.Reflection;

[Obsolete("Use TypeRef instead.", true)]
public class TypeDesc
{
	public TypeRef Type { get; private set; }

	public string FullName { get; private set; }

	public TypeDesc(TypeRef type, string fullName)
	{
		Type = type;
		FullName = fullName;
	}

	public static TypeDesc Get(Type type, Resolver resolver)
	{
		Requires.NotNull(type, "type");
		Requires.NotNull(resolver, "resolver");
		return new TypeDesc(TypeRef.Get(type, resolver), type.FullName);
	}
}
