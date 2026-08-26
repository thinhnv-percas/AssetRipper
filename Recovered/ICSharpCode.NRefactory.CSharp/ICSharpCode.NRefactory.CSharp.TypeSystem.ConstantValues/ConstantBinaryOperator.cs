using ICSharpCode.NRefactory.CSharp.Resolver;
using ICSharpCode.NRefactory.Semantics;
using System;

namespace ICSharpCode.NRefactory.CSharp.TypeSystem.ConstantValues
{
	[Serializable]
	public sealed class ConstantBinaryOperator : ConstantExpression
	{
		private readonly ConstantExpression left;

		private readonly BinaryOperatorType operatorType;

		private readonly ConstantExpression right;

		public ConstantBinaryOperator(ConstantExpression left, BinaryOperatorType operatorType, ConstantExpression right)
		{
			if (left == null)
			{
				throw new ArgumentNullException("left");
			}
			if (right == null)
			{
				throw new ArgumentNullException("right");
			}
			this.left = left;
			this.operatorType = operatorType;
			this.right = right;
		}

		public override ResolveResult Resolve(CSharpResolver resolver)
		{
			ResolveResult lhs = left.Resolve(resolver);
			ResolveResult rhs = right.Resolve(resolver);
			return resolver.ResolveBinaryOperator(operatorType, lhs, rhs);
		}
	}
}
