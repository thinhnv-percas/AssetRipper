using ICSharpCode.NRefactory.CSharp.Resolver;
using ICSharpCode.NRefactory.Semantics;
using System;

namespace ICSharpCode.NRefactory.CSharp.TypeSystem.ConstantValues
{
	[Serializable]
	public sealed class ConstantCheckedExpression : ConstantExpression
	{
		private readonly bool checkForOverflow;

		private readonly ConstantExpression expression;

		public ConstantCheckedExpression(bool checkForOverflow, ConstantExpression expression)
		{
			if (expression == null)
			{
				throw new ArgumentNullException("expression");
			}
			this.checkForOverflow = checkForOverflow;
			this.expression = expression;
		}

		public override ResolveResult Resolve(CSharpResolver resolver)
		{
			return expression.Resolve(resolver.WithCheckForOverflow(checkForOverflow));
		}
	}
}
