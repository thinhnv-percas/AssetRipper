using System;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.TypeSystem;

[Serializable]
public sealed class TopLevelTypeNameComparer : IEqualityComparer<TopLevelTypeName>
{
	public static readonly TopLevelTypeNameComparer Ordinal = new TopLevelTypeNameComparer(StringComparer.Ordinal);

	public static readonly TopLevelTypeNameComparer OrdinalIgnoreCase = new TopLevelTypeNameComparer(StringComparer.OrdinalIgnoreCase);

	public readonly StringComparer NameComparer;

	public TopLevelTypeNameComparer(StringComparer nameComparer)
	{
		NameComparer = nameComparer;
	}

	public bool Equals(TopLevelTypeName x, TopLevelTypeName y)
	{
		if (x.TypeParameterCount == y.TypeParameterCount && NameComparer.Equals(x.Name, y.Name))
		{
			return NameComparer.Equals(x.Namespace, y.Namespace);
		}
		return false;
	}

	public int GetHashCode(TopLevelTypeName obj)
	{
		return NameComparer.GetHashCode(obj.Name) ^ NameComparer.GetHashCode(obj.Namespace) ^ obj.TypeParameterCount;
	}
}
