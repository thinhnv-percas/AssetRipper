using System;

namespace Microsoft.VisualStudio.Composition.Reflection;

[Obsolete("Use PropertyRef instead.", true)]
public class PropertyDesc : MemberDesc
{
	public PropertyDesc Property { get; private set; }

	public TypeDesc PropertyType { get; private set; }

	public PropertyDesc(PropertyDesc property, TypeDesc propertyType, string name, bool isStatic)
		: base(name, isStatic)
	{
		Property = property;
		PropertyType = propertyType;
	}
}
