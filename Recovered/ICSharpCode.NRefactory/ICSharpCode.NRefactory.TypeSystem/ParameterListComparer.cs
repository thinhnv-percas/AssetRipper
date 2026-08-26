using ICSharpCode.NRefactory.TypeSystem.Implementation;
using System;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.TypeSystem
{
	public sealed class ParameterListComparer : IEqualityComparer<IList<IParameter>>
	{
		private sealed class NormalizeTypeVisitor : TypeVisitor
		{
			public override IType VisitTypeParameter(ITypeParameter type)
			{
				if (type.OwnerType == SymbolKind.Method)
				{
					return DummyTypeParameter.GetMethodTypeParameter(type.Index);
				}
				return base.VisitTypeParameter(type);
			}

			public override IType VisitTypeDefinition(ITypeDefinition type)
			{
				if (type.KnownTypeCode == KnownTypeCode.Object)
				{
					return SpecialType.Dynamic;
				}
				return base.VisitTypeDefinition(type);
			}
		}

		public static readonly ParameterListComparer Instance = new ParameterListComparer();

		private static readonly NormalizeTypeVisitor normalizationVisitor = new NormalizeTypeVisitor();

		[Obsolete("Use DummyTypeParameter.NormalizeMethodTypeParameters instead if you only need to normalize type parameters. Also, consider if you need to normalize object vs. dynamic as well.")]
		public IType NormalizeMethodTypeParameters(IType type)
		{
			return DummyTypeParameter.NormalizeMethodTypeParameters(type);
		}

		public bool Equals(IList<IParameter> x, IList<IParameter> y)
		{
			if (x == y)
			{
				return true;
			}
			if (x == null || y == null || x.Count != y.Count)
			{
				return false;
			}
			for (int i = 0; i < x.Count; i++)
			{
				IParameter parameter = x[i];
				IParameter parameter2 = y[i];
				if (parameter != null || parameter2 != null)
				{
					if (parameter == null || parameter2 == null)
					{
						return false;
					}
					IType type = parameter.Type.AcceptVisitor(normalizationVisitor);
					IType other = parameter2.Type.AcceptVisitor(normalizationVisitor);
					if (!type.Equals(other))
					{
						return false;
					}
				}
			}
			return true;
		}

		public int GetHashCode(IList<IParameter> obj)
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
}
