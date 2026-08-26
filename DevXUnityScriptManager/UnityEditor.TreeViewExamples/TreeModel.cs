using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace UnityEditor.TreeViewExamples;

public class TreeModel<T> where T : TreeElement
{
	[CompilerGenerated]
	private sealed class _0020_0020_000A_0020_0020_000A_0020_000A_000A_0020_0020
	{
		public int _0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A;

		internal bool _0020_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A(T P_0)
		{
			return P_0.id == _0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A;
		}
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class _0020_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020
	{
		public static readonly _0020_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020 _0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A = new _0020_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020();

		public static Func<T, int> _0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020;

		internal int _0020_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A(T P_0)
		{
			return P_0.id;
		}
	}

	[CompilerGenerated]
	private sealed class _0020_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020
	{
		public IList<int> _0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A;

		internal bool _0020_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A(T P_0)
		{
			return _0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A.Contains(P_0.id);
		}
	}

	private IList<T> _0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020;

	private T _0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A;

	private int _0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_0020;

	[CompilerGenerated]
	private Action _0020_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A;

	public T root
	{
		get
		{
			return _0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A;
		}
		set
		{
			_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A = value;
		}
	}

	public int numberOfDataElements => _0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020.Count;

	public event Action modelChanged
	{
		[CompilerGenerated]
		add
		{
			Action action = _0020_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref _0020_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action action = _0020_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref _0020_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public TreeModel(IList<T> data)
	{
		SetData(data);
	}

	public T Find(int id)
	{
		return _0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020.FirstOrDefault((T P_0) => P_0.id == id);
	}

	public void SetData(IList<T> data)
	{
		_0020_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A(data);
	}

	private void _0020_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A(IList<T> P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_0020, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A);
		}
		_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020 = P_0;
		if (_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020.Count > 0)
		{
			_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A = TreeElementUtility.ListToTree(P_0);
		}
		_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_0020 = _0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020.Max((T val) => val.id);
	}

	public int GenerateUniqueID()
	{
		return ++_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_0020;
	}

	public IList<int> GetAncestors(int id)
	{
		List<int> list = new List<int>();
		TreeElement treeElement = Find(id);
		if (treeElement != null)
		{
			while (treeElement.parent != null)
			{
				list.Add(treeElement.parent.id);
				treeElement = treeElement.parent;
			}
		}
		return list;
	}

	public IList<int> GetDescendantsThatHaveChildren(int id)
	{
		T val = Find(id);
		if (val != null)
		{
			return _0020_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020(val);
		}
		return new List<int>();
	}

	private IList<int> _0020_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020(TreeElement P_0)
	{
		Stack<TreeElement> stack = new Stack<TreeElement>();
		stack.Push(P_0);
		List<int> list = new List<int>();
		while (stack.Count > 0)
		{
			TreeElement treeElement = stack.Pop();
			if (!treeElement.hasChildren)
			{
				continue;
			}
			list.Add(treeElement.id);
			foreach (TreeElement child in treeElement.children)
			{
				stack.Push(child);
			}
		}
		return list;
	}

	public void RemoveElements(IList<int> elementIDs)
	{
		IList<T> elements = _0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020.Where((T P_0) => elementIDs.Contains(P_0.id)).ToArray();
		RemoveElements(elements);
	}

	public void RemoveElements(IList<T> elements)
	{
		foreach (T element in elements)
		{
			if (element == _0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A)
			{
				throw new ArgumentException(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020);
			}
		}
		foreach (T item in TreeElementUtility.FindCommonAncestorsWithinList(elements))
		{
			item.parent.children.Remove(item);
			item.parent = null;
		}
		TreeElementUtility.TreeToList(_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A, _0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020);
		_0020_0020_000A_0020_0020_000A_0020_0020_000A_0020_000A();
	}

	public void AddElements(IList<T> elements, TreeElement parent, int insertPosition)
	{
		if (elements == null)
		{
			throw new ArgumentNullException(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_0020);
		}
		if (elements.Count == 0)
		{
			throw new ArgumentNullException(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A);
		}
		if (parent == null)
		{
			throw new ArgumentNullException(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_000A);
		}
		if (parent.children == null)
		{
			parent.children = new List<TreeElement>();
		}
		parent.children.InsertRange(insertPosition, elements.Cast<TreeElement>());
		foreach (T element in elements)
		{
			element.parent = parent;
			element.depth = parent.depth + 1;
			TreeElementUtility.UpdateDepthValues(element);
		}
		TreeElementUtility.TreeToList(_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A, _0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020);
		_0020_0020_000A_0020_0020_000A_0020_0020_000A_0020_000A();
	}

	public void AddRoot(T root)
	{
		if (root == null)
		{
			throw new ArgumentNullException(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_0020, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_0020);
		}
		if (_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020 == null)
		{
			throw new InvalidOperationException(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A);
		}
		if (_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020.Count != 0)
		{
			throw new InvalidOperationException(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020);
		}
		root.id = GenerateUniqueID();
		root.depth = -1;
		_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020.Add(root);
	}

	public void AddElement(T element, TreeElement parent, int insertPosition)
	{
		if (element == null)
		{
			throw new ArgumentNullException(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020);
		}
		if (parent == null)
		{
			throw new ArgumentNullException(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_000A);
		}
		if (parent.children == null)
		{
			parent.children = new List<TreeElement>();
		}
		parent.children.Insert(insertPosition, element);
		element.parent = parent;
		TreeElementUtility.UpdateDepthValues(parent);
		TreeElementUtility.TreeToList(_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A, _0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020);
		_0020_0020_000A_0020_0020_000A_0020_0020_000A_0020_000A();
	}

	public void MoveElements(TreeElement parentElement, int insertionIndex, List<TreeElement> elements)
	{
		if (insertionIndex < 0)
		{
			throw new ArgumentException(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A);
		}
		if (parentElement == null)
		{
			return;
		}
		if (insertionIndex > 0)
		{
			insertionIndex -= parentElement.children.GetRange(0, insertionIndex).Count(elements.Contains);
		}
		foreach (TreeElement element in elements)
		{
			element.parent.children.Remove(element);
			element.parent = parentElement;
		}
		if (parentElement.children == null)
		{
			parentElement.children = new List<TreeElement>();
		}
		parentElement.children.InsertRange(insertionIndex, elements);
		TreeElementUtility.UpdateDepthValues(root);
		TreeElementUtility.TreeToList(_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A, _0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020);
		_0020_0020_000A_0020_0020_000A_0020_0020_000A_0020_000A();
	}

	private void _0020_0020_000A_0020_0020_000A_0020_0020_000A_0020_000A()
	{
		if (_0020_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A != null)
		{
			_0020_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A();
		}
	}
}
