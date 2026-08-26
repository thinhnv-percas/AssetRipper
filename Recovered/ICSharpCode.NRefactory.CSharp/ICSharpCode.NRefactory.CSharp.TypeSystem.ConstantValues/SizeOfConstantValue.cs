using ICSharpCode.NRefactory.CSharp.Resolver;
using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;
using System;

namespace ICSharpCode.NRefactory.CSharp.TypeSystem.ConstantValues
{
	[Serializable]
	public sealed class SizeOfConstantValue : ConstantExpression
	{
		private readonly ITypeReference type;

		public SizeOfConstantValue(ITypeReference type)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			this.type = type;
		}

		public override ResolveResult Resolve(CSharpResolver resolver)
		{
			return resolver.ResolveSizeOf(type.Resolve(resolver.CurrentTypeResolveContext));
		}
	}
}
