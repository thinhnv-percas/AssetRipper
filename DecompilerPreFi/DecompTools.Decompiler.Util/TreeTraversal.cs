using System;
using System.Collections.Generic;

namespace DecompTools.Decompiler.Util;

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
					IEnumerable<T> children = recursion(element);
					if (children != null)
					{
						stack.Push(children.GetEnumerator());
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
					T element = stack.Peek().Current;
					IEnumerable<T> children = recursion(element);
					if (children != null)
					{
						stack.Push(children.GetEnumerator());
					}
					else
					{
						yield return element;
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
