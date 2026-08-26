using ICSharpCode.NRefactory.CSharp.Resolver;
using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;
using System;

namespace ICSharpCode.NRefactory.CSharp.TypeSystem.ConstantValues
{
	[Serializable]
	public sealed class PrimitiveConstantExpression : ConstantExpression, ISupportsInterning
	{
		private readonly ITypeReference type;

		private readonly object value;

		public ITypeReference Type => type;

		public object Value => value;

		public PrimitiveConstantExpression(ITypeReference type, object value)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			this.type = type;
			this.value = value;
		}

		public override ResolveResult Resolve(CSharpResolver resolver)
		{
			return new ConstantResolveResult(type.Resolve(resolver.CurrentTypeResolveContext), value);
		}

		int ISupportsInterning.GetHashCodeForInterning()
		{
			return type.GetHashCode() ^ ((value != null) ? value.GetHashCode() : 0);
		}

		bool ISupportsInterning.EqualsForInterning(ISupportsInterning other)
		{
			PrimitiveConstantExpression primitiveConstantExpression = other as PrimitiveConstantExpression;
			if (primitiveConstantExpression != null && type == primitiveConstantExpression.type)
			{
				return value == primitiveConstantExpression.value;
			}
			return false;
		}
	}
}
