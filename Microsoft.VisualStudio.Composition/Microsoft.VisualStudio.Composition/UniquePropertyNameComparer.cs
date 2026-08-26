using System.Collections.Generic;
using System.Reflection;

namespace Microsoft.VisualStudio.Composition;

internal class UniquePropertyNameComparer : IEqualityComparer<PropertyInfo>
{
	internal static readonly IEqualityComparer<PropertyInfo> Default = new UniquePropertyNameComparer();

	private UniquePropertyNameComparer()
	{
	}

	public bool Equals(PropertyInfo x, PropertyInfo y)
	{
		return x.Name == y.Name;
	}

	public int GetHashCode(PropertyInfo obj)
	{
		return obj.Name.GetHashCode();
	}
}
