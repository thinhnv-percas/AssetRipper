using System.Collections.Generic;

namespace System.Collections.Immutable;

internal static class AllocFreeConcurrentStack<T>
{
	private const int MaxSize = 35;

	private static readonly Type s_typeOfT = typeof(T);

	private static Stack<RefAsValueType<T>> ThreadLocalStack
	{
		get
		{
			Dictionary<Type, object> dictionary = AllocFreeConcurrentStack.t_stacks;
			if (dictionary == null)
			{
				dictionary = (AllocFreeConcurrentStack.t_stacks = new Dictionary<Type, object>());
			}
			if (!dictionary.TryGetValue(s_typeOfT, out var value))
			{
				value = new Stack<RefAsValueType<RefAsValueType<T>>>(35);
				dictionary.Add(s_typeOfT, value);
			}
			return (Stack<RefAsValueType<T>>)value;
		}
	}

	public static void TryAdd(T item)
	{
		Stack<RefAsValueType<T>> threadLocalStack = ThreadLocalStack;
		if (((Stack<RefAsValueType<RefAsValueType<T>>>)(object)threadLocalStack).Count < 35)
		{
			((Stack<RefAsValueType<RefAsValueType<T>>>)(object)threadLocalStack).Push((RefAsValueType<RefAsValueType<T>>)new RefAsValueType<T>(item));
		}
	}

	public static bool TryTake(out T item)
	{
		Stack<RefAsValueType<T>> threadLocalStack = ThreadLocalStack;
		if (threadLocalStack != null && ((Stack<RefAsValueType<RefAsValueType<T>>>)(object)threadLocalStack).Count > 0)
		{
			item = ((Stack<RefAsValueType<RefAsValueType<T>>>)(object)threadLocalStack).Pop().Value;
			return true;
		}
		item = default(T);
		return false;
	}
}
internal static class AllocFreeConcurrentStack
{
	[ThreadStatic]
	internal static Dictionary<Type, object> t_stacks;
}
