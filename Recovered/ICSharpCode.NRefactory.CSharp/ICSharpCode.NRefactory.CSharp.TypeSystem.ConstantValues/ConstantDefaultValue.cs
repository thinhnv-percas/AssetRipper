using ICSharpCode.NRefactory.CSharp.Resolver;
using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;
using System;

namespace ICSharpCode.NRefactory.CSharp.TypeSystem.ConstantValues
{
	[Serializable]
	public sealed class ConstantDefaultValue : ConstantExpression, ISupportsInterning
	{
		private readonly ITypeReference type;

		public ConstantDefaultValue(ITypeReference type)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			this.type = type;
		}

		public override ResolveResult Resolve(CSharpResolver resolver)
		{
			return resolver.ResolveDefaultValue(type.Resolve(resolver.CurrentTypeResolveContext));
		}

		int ISupportsInterning.GetHashCodeForInterning()
		{
			return type.GetHashCode();
		}

		bool ISupportsInterning.EqualsForInterning(ISupportsInterning other)
		{
			ConstantDefaultValue constantDefaultValue = other as ConstantDefaultValue;
			if (constantDefaultValue != null)
			{
				return type == constantDefaultValue.type;
			}
			return false;
		}
	}
}
