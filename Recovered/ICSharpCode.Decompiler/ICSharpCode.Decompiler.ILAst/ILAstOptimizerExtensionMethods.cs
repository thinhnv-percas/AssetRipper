using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.Decompiler.ILAst
{
	public static class ILAstOptimizerExtensionMethods
	{
		public static bool RunOptimization(this ILBlock block, Func<List<ILNode>, ILBasicBlock, int, bool> optimization)
		{
			bool result = false;
			List<ILNode> body = block.Body;
			for (int num = body.Count - 1; num >= 0; num--)
			{
				if (num < body.Count && optimization(body, (ILBasicBlock)body[num], num))
				{
					result = true;
				}
			}
			return result;
		}

		public static bool RunOptimization(this ILBlock block, Func<List<ILNode>, ILExpression, int, bool> optimization)
		{
			bool result = false;
			foreach (ILBasicBlock item in block.Body)
			{
				for (int num = item.Body.Count - 1; num >= 0; num--)
				{
					ILExpression iLExpression = item.Body.ElementAtOrDefault(num) as ILExpression;
					if (iLExpression != null && optimization(item.Body, iLExpression, num))
					{
						result = true;
					}
				}
			}
			return result;
		}

		public static bool IsConditionalControlFlow(this ILNode node)
		{
			return (node as ILExpression)?.Code.IsConditionalControlFlow() ?? false;
		}

		public static bool IsUnconditionalControlFlow(this ILNode node)
		{
			return (node as ILExpression)?.Code.IsUnconditionalControlFlow() ?? false;
		}

		public static bool HasNoSideEffects(this ILExpression expr)
		{
			switch (expr.Code)
			{
			case ILCode.Ldnull:
			case ILCode.Ldc_I4:
			case ILCode.Ldc_I8:
			case ILCode.Ldc_R4:
			case ILCode.Ldc_R8:
			case ILCode.Ldstr:
			case ILCode.Ldloc:
			case ILCode.Ldloca:
			case ILCode.Ldc_Decimal:
				return true;
			default:
				return false;
			}
		}

		public static bool IsStoreToArray(this ILCode code)
		{
			switch (code)
			{
			case ILCode.Stelem_I:
			case ILCode.Stelem_I1:
			case ILCode.Stelem_I2:
			case ILCode.Stelem_I4:
			case ILCode.Stelem_I8:
			case ILCode.Stelem_R4:
			case ILCode.Stelem_R8:
			case ILCode.Stelem_Ref:
			case ILCode.Stelem_Any:
				return true;
			default:
				return false;
			}
		}

		public static bool IsLoadFromArray(this ILCode code)
		{
			switch (code)
			{
			case ILCode.Ldelem_I1:
			case ILCode.Ldelem_U1:
			case ILCode.Ldelem_I2:
			case ILCode.Ldelem_U2:
			case ILCode.Ldelem_I4:
			case ILCode.Ldelem_U4:
			case ILCode.Ldelem_I8:
			case ILCode.Ldelem_I:
			case ILCode.Ldelem_R4:
			case ILCode.Ldelem_R8:
			case ILCode.Ldelem_Ref:
			case ILCode.Ldelem_Any:
				return true;
			default:
				return false;
			}
		}

		public static bool CanBeExpressionStatement(this ILExpression expr)
		{
			switch (expr.Code)
			{
			case ILCode.Call:
			case ILCode.Callvirt:
				return !((MethodReference)expr.Operand).Name.StartsWith("get_", StringComparison.Ordinal);
			case ILCode.Stind_Ref:
			case ILCode.Newobj:
			case ILCode.Stfld:
			case ILCode.Stsfld:
			case ILCode.Stobj:
			case ILCode.Newarr:
			case ILCode.Stelem_I:
			case ILCode.Stelem_I1:
			case ILCode.Stelem_I2:
			case ILCode.Stelem_I4:
			case ILCode.Stelem_I8:
			case ILCode.Stelem_R4:
			case ILCode.Stelem_R8:
			case ILCode.Stelem_Ref:
			case ILCode.Stelem_Any:
			case ILCode.Stloc:
			case ILCode.CallSetter:
			case ILCode.CallvirtSetter:
				return true;
			default:
				return false;
			}
		}

		public static ILExpression WithILRanges(this ILExpression expr, IEnumerable<ILRange> ilranges)
		{
			expr.ILRanges.AddRange(ilranges);
			return expr;
		}

		public static void RemoveTail(this List<ILNode> body, params ILCode[] codes)
		{
			for (int i = 0; i < codes.Length; i++)
			{
				if (((ILExpression)body[body.Count - codes.Length + i]).Code != codes[i])
				{
					throw new Exception("Tailing code does not match expected.");
				}
			}
			body.RemoveRange(body.Count - codes.Length, codes.Length);
		}

		public static V GetOrDefault<K, V>(this Dictionary<K, V> dict, K key)
		{
			dict.TryGetValue(key, out V value);
			return value;
		}

		public static void RemoveOrThrow<T>(this ICollection<T> collection, T item)
		{
			if (!collection.Remove(item))
			{
				throw new Exception("The item was not found in the collection");
			}
		}

		public static void RemoveOrThrow<K, V>(this Dictionary<K, V> collection, K key)
		{
			if (!collection.Remove(key))
			{
				throw new Exception("The key was not found in the dictionary");
			}
		}

		public static bool ContainsReferenceTo(this ILExpression expr, ILVariable v)
		{
			if (expr.Operand == v)
			{
				return true;
			}
			foreach (ILExpression argument in expr.Arguments)
			{
				if (argument.ContainsReferenceTo(v))
				{
					return true;
				}
			}
			return false;
		}
	}
}
