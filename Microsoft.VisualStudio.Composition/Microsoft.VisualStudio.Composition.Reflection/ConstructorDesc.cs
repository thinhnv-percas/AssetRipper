using System;

namespace Microsoft.VisualStudio.Composition.Reflection;

[Obsolete("Use ConstructorRef instead.", true)]
public class ConstructorDesc : MemberDesc
{
	public ConstructorRef Constructor { get; private set; }

	public ConstructorDesc(ConstructorRef constructor, string name, bool isStatic)
		: base(name, isStatic)
	{
		Constructor = constructor;
	}
}
