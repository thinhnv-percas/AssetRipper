using System.Collections.Generic;

namespace DecompTools.Decompiler.Util;

public class UnionFind<T>
{
	private class Node
	{
		public int rank;

		public Node parent;

		public T value;
	}

	private Dictionary<T, Node> mapping;

	public UnionFind()
	{
		mapping = new Dictionary<T, Node>();
	}

	private Node GetNode(T element)
	{
		if (!mapping.TryGetValue(element, out var value))
		{
			value = new Node
			{
				value = element,
				rank = 0
			};
			value.parent = value;
			mapping.Add(element, value);
		}
		return value;
	}

	public T Find(T element)
	{
		return FindRoot(GetNode(element)).value;
	}

	private Node FindRoot(Node node)
	{
		if (node.parent != node)
		{
			node.parent = FindRoot(node.parent);
		}
		return node.parent;
	}

	public void Merge(T a, T b)
	{
		Node node = FindRoot(GetNode(a));
		Node node2 = FindRoot(GetNode(b));
		checked
		{
			if (node != node2)
			{
				if (node.rank < node2.rank)
				{
					node.parent = node2;
					return;
				}
				if (node.rank > node2.rank)
				{
					node2.parent = node;
					return;
				}
				node2.parent = node;
				node.rank++;
			}
		}
	}
}
