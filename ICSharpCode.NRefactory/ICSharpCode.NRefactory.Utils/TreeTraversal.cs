using System;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.Utils;

public static class TreeTraversal
{
	public static IEnumerable<T> PreOrder<T>(T root, Func<T, IEnumerable<T>> recursion)
	{
		return PreOrder(new T[1] { root }, recursion);
	}

	public static IEnumerable<T> PreOrder<T>(IEnumerable<T> input, Func<T, IEnumerable<T>> recursion)
	{
		Stack<IEnumerator<T>> stack = new Stack<IEnumerator<T>>();
		try
		{
			stack.Push(input.GetEnumerator());
			while (stack.Count > 0)
			{
				while (stack.Peek().MoveNext())
				{
					T element = stack.Peek().Current;
					yield return element;
					IEnumerable<T> enumerable = recursion(element);
					if (enumerable != null)
					{
						stack.Push(enumerable.GetEnumerator());
					}
				}
				stack.Pop().Dispose();
			}
		}
		finally
		{
			while (stack.Count > 0)
			{
				stack.Pop().Dispose();
			}
		}
	}

	public static IEnumerable<T> PostOrder<T>(T root, Func<T, IEnumerable<T>> recursion)
	{
		return PostOrder(new T[1] { root }, recursion);
	}

	public static IEnumerable<T> PostOrder<T>(IEnumerable<T> input, Func<T, IEnumerable<T>> recursion)
	{
		Stack<IEnumerator<T>> stack = new Stack<IEnumerator<T>>();
		try
		{
			stack.Push(input.GetEnumerator());
			while (stack.Count > 0)
			{
				while (stack.Peek().MoveNext())
				{
					T current = stack.Peek().Current;
					IEnumerable<T> enumerable = recursion(current);
					if (enumerable != null)
					{
						stack.Push(enumerable.GetEnumerator());
					}
					else
					{
						yield return current;
					}
				}
				stack.Pop().Dispose();
				if (stack.Count > 0)
				{
					yield return stack.Peek().Current;
				}
			}
		}
		finally
		{
			while (stack.Count > 0)
			{
				stack.Pop().Dispose();
			}
		}
	}
}
