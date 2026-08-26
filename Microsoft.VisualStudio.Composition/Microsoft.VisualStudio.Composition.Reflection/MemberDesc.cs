using System;

namespace Microsoft.VisualStudio.Composition.Reflection;

[Obsolete("Use MemberRef instead.", true)]
public abstract class MemberDesc
{
	public string Name { get; }

	public bool IsStatic { get; }

	protected MemberDesc(string name, bool isStatic)
	{
		Name = name;
		IsStatic = isStatic;
	}
}
