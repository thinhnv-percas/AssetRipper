using ICSharpCode.NRefactory.Semantics;
using System;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation
{
	[Serializable]
	public sealed class SimpleConstantValue : IConstantValue, ISupportsInterning
	{
		private readonly ITypeReference type;

		private readonly object value;

		public SimpleConstantValue(ITypeReference type, object value)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			this.type = type;
			this.value = value;
		}

		public ResolveResult Resolve(ITypeResolveContext context)
		{
			return new ConstantResolveResult(type.Resolve(context), value);
		}

		public override string ToString()
		{
			if (value == null)
			{
				return "null";
			}
			if (value is bool)
			{
				return value.ToString().ToLowerInvariant();
			}
			return value.ToString();
		}

		int ISupportsInterning.GetHashCodeForInterning()
		{
			return type.GetHashCode() ^ ((value != null) ? value.GetHashCode() : 0);
		}

		bool ISupportsInterning.EqualsForInterning(ISupportsInterning other)
		{
			SimpleConstantValue simpleConstantValue = other as SimpleConstantValue;
			if (simpleConstantValue != null && type == simpleConstantValue.type)
			{
				return value == simpleConstantValue.value;
			}
			return false;
		}
	}
}
