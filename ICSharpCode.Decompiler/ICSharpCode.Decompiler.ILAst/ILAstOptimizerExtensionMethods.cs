using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnSpy.Contracts.Decompiler;

namespace ICSharpCode.Decompiler.ILAst;

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

	public static bool RunOptimization(this ILBlock block, Func<ILBlockBase, List<ILNode>, ILExpression, int, bool> optimization)
	{
		bool result = false;
		foreach (ILBasicBlock item in block.Body)
		{
			for (int num = item.Body.Count - 1; num >= 0; num--)
			{
				if (item.Body.ElementAtOrDefault(num) is ILExpression arg && optimization(item, item.Body, arg, num))
				{
					result = true;
				}
			}
		}
		return result;
	}

	public static bool IsConditionalControlFlow(this ILNode node)
	{
		if (node is ILExpression iLExpression)
		{
			return iLExpression.Code.IsConditionalControlFlow();
		}
		return false;
	}

	public static bool IsUnconditionalControlFlow(this ILNode node)
	{
		if (node is ILExpression iLExpression)
		{
			return iLExpression.Code.IsUnconditionalControlFlow();
		}
		return false;
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
		if ((uint)(code - 152) <= 7u || code == ILCode.Stelem)
		{
			return true;
		}
		return false;
	}

	public static bool IsLoadFromArray(this ILCode code)
	{
		if ((uint)(code - 141) <= 10u || code == ILCode.Ldelem)
		{
			return true;
		}
		return false;
	}

	public static bool CanBeExpressionStatement(this ILExpression expr)
	{
		switch (expr.Code)
		{
		case ILCode.Call:
		case ILCode.Callvirt:
		{
			IMethod method = (IMethod)expr.Operand;
			return !method.Name.StartsWith("get_", StringComparison.Ordinal);
		}
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
		case ILCode.Stelem:
		case ILCode.Stloc:
		case ILCode.CallSetter:
		case ILCode.CallvirtSetter:
		case ILCode.CallReadOnlySetter:
			return true;
		default:
			return false;
		}
	}

	public static ILExpression WithILSpansFrom(this ILExpression expr, bool calculateILSpans, ILNode node)
	{
		if (!calculateILSpans)
		{
			return expr;
		}
		long index = 0L;
		bool done = false;
		while (true)
		{
			ILSpan allILSpans = node.GetAllILSpans(ref index, ref done);
			if (done)
			{
				break;
			}
			expr.ILSpans.Add(allILSpans);
		}
		return expr;
	}

	public static ILNode[] RemoveTail(this List<ILNode> body, params ILCode[] codes)
	{
		for (int i = 0; i < codes.Length; i++)
		{
			if (((ILExpression)body[body.Count - codes.Length + i]).Code != codes[i])
			{
				throw new Exception("Tailing code does not match expected.");
			}
		}
		ILNode[] array = new ILNode[codes.Length];
		for (int j = 0; j < codes.Length; j++)
		{
			array[j] = body[body.Count - codes.Length + j];
		}
		body.RemoveRange(body.Count - codes.Length, codes.Length);
		return array;
	}

	public static V GetOrDefault<K, V>(this Dictionary<K, V> dict, K key)
	{
		dict.TryGetValue(key, out var value);
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
