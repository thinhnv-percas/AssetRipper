using System;
using System.Collections.Generic;

namespace DecompTools.Decompiler.TypeSystem;

[Serializable]
public sealed class FullTypeNameComparer : IEqualityComparer<FullTypeName>
{
	public static readonly FullTypeNameComparer Ordinal = new FullTypeNameComparer(StringComparer.Ordinal);

	public static readonly FullTypeNameComparer OrdinalIgnoreCase = new FullTypeNameComparer(StringComparer.OrdinalIgnoreCase);

	public readonly StringComparer NameComparer;

	public FullTypeNameComparer(StringComparer nameComparer)
	{
		NameComparer = nameComparer;
	}

	public bool Equals(FullTypeName x, FullTypeName y)
	{
		if (x.NestingLevel != y.NestingLevel)
		{
			return false;
		}
		TopLevelTypeName topLevelTypeName = x.TopLevelTypeName;
		TopLevelTypeName topLevelTypeName2 = y.TopLevelTypeName;
		if (topLevelTypeName.TypeParameterCount == topLevelTypeName2.TypeParameterCount && NameComparer.Equals(topLevelTypeName.Name, topLevelTypeName2.Name) && NameComparer.Equals(topLevelTypeName.Namespace, topLevelTypeName2.Namespace))
		{
			for (int i = 0; i < x.NestingLevel; i = checked(i + 1))
			{
				if (x.GetNestedTypeAdditionalTypeParameterCount(i) != y.GetNestedTypeAdditionalTypeParameterCount(i))
				{
					return false;
				}
				if (!NameComparer.Equals(x.GetNestedTypeName(i), y.GetNestedTypeName(i)))
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}

	public int GetHashCode(FullTypeName obj)
	{
		TopLevelTypeName topLevelTypeName = obj.TopLevelTypeName;
		int num = NameComparer.GetHashCode(topLevelTypeName.Name) ^ NameComparer.GetHashCode(topLevelTypeName.Namespace) ^ topLevelTypeName.TypeParameterCount;
		for (int i = 0; i < obj.NestingLevel; i++)
		{
			num *= 31;
			num += NameComparer.GetHashCode(obj.Name) ^ obj.TypeParameterCount;
		}
		return num;
	}
}
