using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.Decompiler.ILAst
{
	public static class PatternMatching
	{
		public static bool Match(this ILNode node, ILCode code)
		{
			ILExpression iLExpression = node as ILExpression;
			if (iLExpression != null && iLExpression.Prefixes == null)
			{
				return iLExpression.Code == code;
			}
			return false;
		}

		public static bool Match<T>(this ILNode node, ILCode code, out T operand)
		{
			ILExpression iLExpression = node as ILExpression;
			if (iLExpression != null && iLExpression.Prefixes == null && iLExpression.Code == code && iLExpression.Arguments.Count == 0)
			{
				operand = (T)iLExpression.Operand;
				return true;
			}
			operand = default(T);
			return false;
		}

		public static bool Match(this ILNode node, ILCode code, out List<ILExpression> args)
		{
			ILExpression iLExpression = node as ILExpression;
			if (iLExpression != null && iLExpression.Prefixes == null && iLExpression.Code == code)
			{
				args = iLExpression.Arguments;
				return true;
			}
			args = null;
			return false;
		}

		public static bool Match(this ILNode node, ILCode code, out ILExpression arg)
		{
			if (node.Match(code, out List<ILExpression> args) && args.Count == 1)
			{
				arg = args[0];
				return true;
			}
			arg = null;
			return false;
		}

		public static bool Match<T>(this ILNode node, ILCode code, out T operand, out List<ILExpression> args)
		{
			ILExpression iLExpression = node as ILExpression;
			if (iLExpression != null && iLExpression.Prefixes == null && iLExpression.Code == code)
			{
				operand = (T)iLExpression.Operand;
				args = iLExpression.Arguments;
				return true;
			}
			operand = default(T);
			args = null;
			return false;
		}

		public static bool Match<T>(this ILNode node, ILCode code, out T operand, out ILExpression arg)
		{
			if (node.Match(code, out operand, out List<ILExpression> args) && args.Count == 1)
			{
				arg = args[0];
				return true;
			}
			arg = null;
			return false;
		}

		public static bool Match<T>(this ILNode node, ILCode code, out T operand, out ILExpression arg1, out ILExpression arg2)
		{
			if (node.Match(code, out operand, out List<ILExpression> args) && args.Count == 2)
			{
				arg1 = args[0];
				arg2 = args[1];
				return true;
			}
			arg1 = null;
			arg2 = null;
			return false;
		}

		public static bool MatchSingle<T>(this ILBasicBlock bb, ILCode code, out T operand, out ILExpression arg)
		{
			if (bb.Body.Count == 2 && bb.Body[0] is ILLabel && bb.Body[1].Match(code, out operand, out arg))
			{
				return true;
			}
			operand = default(T);
			arg = null;
			return false;
		}

		public static bool MatchSingleAndBr<T>(this ILBasicBlock bb, ILCode code, out T operand, out ILExpression arg, out ILLabel brLabel)
		{
			if (bb.Body.Count == 3 && bb.Body[0] is ILLabel && bb.Body[1].Match(code, out operand, out arg) && bb.Body[2].Match(ILCode.Br, out brLabel))
			{
				return true;
			}
			operand = default(T);
			arg = null;
			brLabel = null;
			return false;
		}

		public static bool MatchLastAndBr<T>(this ILBasicBlock bb, ILCode code, out T operand, out ILExpression arg, out ILLabel brLabel)
		{
			if (bb.Body.ElementAtOrDefault(bb.Body.Count - 2).Match(code, out operand, out arg) && bb.Body.LastOrDefault().Match(ILCode.Br, out brLabel))
			{
				return true;
			}
			operand = default(T);
			arg = null;
			brLabel = null;
			return false;
		}

		public static bool MatchThis(this ILNode node)
		{
			if (node.Match(ILCode.Ldloc, out ILVariable operand) && operand.IsParameter)
			{
				return operand.OriginalParameter.Index == -1;
			}
			return false;
		}

		public static bool MatchLdloc(this ILNode node, ILVariable expectedVar)
		{
			if (node.Match(ILCode.Ldloc, out ILVariable operand))
			{
				return operand == expectedVar;
			}
			return false;
		}

		public static bool MatchLdloca(this ILNode node, ILVariable expectedVar)
		{
			if (node.Match(ILCode.Ldloca, out ILVariable operand))
			{
				return operand == expectedVar;
			}
			return false;
		}

		public static bool MatchStloc(this ILNode node, ILVariable expectedVar, out ILExpression expr)
		{
			if (node.Match(ILCode.Stloc, out ILVariable operand, out expr))
			{
				return operand == expectedVar;
			}
			return false;
		}

		public static bool MatchLdcI4(this ILNode node, int expectedValue)
		{
			if (node.Match(ILCode.Ldc_I4, out int operand))
			{
				return operand == expectedValue;
			}
			return false;
		}
	}
}
