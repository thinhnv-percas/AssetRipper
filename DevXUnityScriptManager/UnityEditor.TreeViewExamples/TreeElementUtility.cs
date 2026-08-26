using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace UnityEditor.TreeViewExamples;

public static class TreeElementUtility
{
	[CompilerGenerated]
	private sealed class _0020_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A<_00210> where _00210 : TreeElement
	{
		public IList<_00210> _0020_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020;

		internal bool _0020_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020(_00210 P_0)
		{
			return _0020_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020_00601(P_0, _0020_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020);
		}
	}

	public static void TreeToList<T>(T root, IList<T> result) where T : TreeElement
	{
		if (result == null)
		{
			throw new NullReferenceException(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020);
		}
		result.Clear();
		Stack<T> stack = new Stack<T>();
		stack.Push(root);
		while (stack.Count > 0)
		{
			T val = stack.Pop();
			result.Add(val);
			if (val.children != null && val.children.Count > 0)
			{
				for (int num = val.children.Count - 1; num >= 0; num--)
				{
					stack.Push((T)val.children[num]);
				}
			}
		}
	}

	public static T ListToTree<T>(IList<T> list) where T : TreeElement
	{
		ValidateDepthValues(list);
		foreach (T item in list)
		{
			item.parent = null;
			item.children = null;
		}
		for (int i = 0; i < list.Count; i++)
		{
			T val = list[i];
			if (val.children != null)
			{
				continue;
			}
			int depth = val.depth;
			int num = 0;
			for (int j = i + 1; j < list.Count; j++)
			{
				if (list[j].depth == depth + 1)
				{
					num++;
				}
				if (list[j].depth <= depth)
				{
					break;
				}
			}
			List<TreeElement> list2 = null;
			if (num != 0)
			{
				list2 = new List<TreeElement>(num);
				num = 0;
				for (int k = i + 1; k < list.Count; k++)
				{
					if (list[k].depth == depth + 1)
					{
						list[k].parent = val;
						list2.Add(list[k]);
						num++;
					}
					if (list[k].depth <= depth)
					{
						break;
					}
				}
			}
			val.children = list2;
		}
		return list[0];
	}

	public static void ValidateDepthValues<T>(IList<T> list) where T : TreeElement
	{
		if (list.Count == 0)
		{
			throw new ArgumentException(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020);
		}
		if (list[0].depth != -1)
		{
			throw new ArgumentException(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_000A + list[0].depth, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020);
		}
		for (int i = 0; i < list.Count - 1; i++)
		{
			int depth = list[i].depth;
			int depth2 = list[i + 1].depth;
			if (depth2 > depth && depth2 - depth > 1)
			{
				throw new ArgumentException(string.Format(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_0020, i, depth, i + 1, depth2));
			}
		}
		for (int j = 1; j < list.Count; j++)
		{
			if (list[j].depth < 0)
			{
				throw new ArgumentException(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A + j + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_0020);
			}
		}
		if (list.Count > 1 && list[1].depth != 0)
		{
			throw new ArgumentException(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_0020_0020_000A_0020_0020_000A, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020);
		}
	}

	public static void UpdateDepthValues<T>(T root) where T : TreeElement
	{
		if (root == null)
		{
			throw new ArgumentNullException(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_0020, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_0020_0020_000A_0020_0020_0020);
		}
		if (!root.hasChildren)
		{
			return;
		}
		Stack<TreeElement> stack = new Stack<TreeElement>();
		stack.Push(root);
		while (stack.Count > 0)
		{
			TreeElement treeElement = stack.Pop();
			if (treeElement.children == null)
			{
				continue;
			}
			foreach (TreeElement child in treeElement.children)
			{
				child.depth = treeElement.depth + 1;
				stack.Push(child);
			}
		}
	}

	private static bool _0020_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020_00601<_0020_0020>(_0020_0020 P_0, IList<_0020_0020> P_1) where _0020_0020 : TreeElement
	{
		while (P_0 != null)
		{
			P_0 = (_0020_0020)P_0.parent;
			if (P_1.Contains(P_0))
			{
				return true;
			}
		}
		return false;
	}

	public static IList<T> FindCommonAncestorsWithinList<T>(IList<T> elements) where T : TreeElement
	{
		if (elements.Count == 1)
		{
			return new List<T>(elements);
		}
		List<T> list = new List<T>(elements);
		list.RemoveAll((T P_0) => _0020_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020_00601(P_0, elements));
		return list;
	}
}
