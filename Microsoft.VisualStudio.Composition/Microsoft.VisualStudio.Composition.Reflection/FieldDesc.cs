using System;

namespace Microsoft.VisualStudio.Composition.Reflection;

[Obsolete("Use FieldRef instead.", true)]
public class FieldDesc : MemberDesc
{
	public FieldRef Field { get; private set; }

	public TypeDesc FieldType { get; private set; }

	public FieldDesc(FieldRef fieldRef, TypeDesc fieldType, string name, bool isStatic)
		: base(name, isStatic)
	{
		Field = fieldRef;
		FieldType = fieldType;
	}
}
