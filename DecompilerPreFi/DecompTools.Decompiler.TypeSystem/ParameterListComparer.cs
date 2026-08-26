using System.Collections.Generic;

namespace DecompTools.Decompiler.TypeSystem;

public sealed class ParameterListComparer : IEqualityComparer<IReadOnlyList<IParameter>>
{
	public static readonly ParameterListComparer Instance = new ParameterListComparer();

	private static readonly NormalizeTypeVisitor normalizationVisitor = new NormalizeTypeVisitor
	{
		ReplaceClassTypeParametersWithDummy = false,
		ReplaceMethodTypeParametersWithDummy = true,
		DynamicAndObject = true,
		TupleToUnderlyingType = true
	};

	private bool includeModifiers;

	public static ParameterListComparer WithOptions(bool includeModifiers = false)
	{
		return new ParameterListComparer
		{
			includeModifiers = includeModifiers
		};
	}

	public bool Equals(IReadOnlyList<IParameter> x, IReadOnlyList<IParameter> y)
	{
		if (x == y)
		{
			return true;
		}
		if (x == null || y == null || x.Count != y.Count)
		{
			return false;
		}
		for (int i = 0; i < x.Count; i = checked(i + 1))
		{
			IParameter parameter = x[i];
			IParameter parameter2 = y[i];
			if (parameter == null && parameter2 == null)
			{
				continue;
			}
			if (parameter == null || parameter2 == null)
			{
				return false;
			}
			if (includeModifiers)
			{
				if (parameter.IsIn != parameter2.IsIn)
				{
					return false;
				}
				if (parameter.IsOut != parameter2.IsOut)
				{
					return false;
				}
				if (parameter.IsRef != parameter2.IsRef)
				{
					return false;
				}
				if (parameter.IsParams != parameter2.IsParams)
				{
					return false;
				}
			}
			IType type = parameter.Type.AcceptVisitor(normalizationVisitor);
			IType other = parameter2.Type.AcceptVisitor(normalizationVisitor);
			if (!type.Equals(other))
			{
				return false;
			}
		}
		return true;
	}

	public int GetHashCode(IReadOnlyList<IParameter> obj)
	{
		int num = obj.Count;
		foreach (IParameter item in obj)
		{
			num *= 27;
			IType type = item.Type.AcceptVisitor(normalizationVisitor);
			num += type.GetHashCode();
		}
		return num;
	}
}
