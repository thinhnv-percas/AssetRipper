using System.Collections;
using System.Collections.Generic;

namespace DevXForms
{
	public class NodesSelection : IEnumerable<TreeNode>, IEnumerable
	{
		internal List<TreeNode> _0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A_000A_000A = new List<TreeNode>();

		internal Dictionary<TreeNode, int> _0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020 = new Dictionary<TreeNode, int>();

		public TreeNode this[int index] => _0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A_000A_000A[index];

		public int Count => _0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A_000A_000A.Count;

		public void Clear()
		{
			_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A_000A_000A.Clear();
			_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020.Clear();
		}

		public IEnumerator<TreeNode> GetEnumerator()
		{
			return _0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A_000A_000A.GetEnumerator();
		}

		public void Add(TreeNode node)
		{
			_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A_000A_000A.Add(node);
			_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020.Add(node, 0);
		}

		public void Remove(TreeNode node)
		{
			_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A_000A_000A.Remove(node);
			_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020.Remove(node);
		}

		public bool Contains(TreeNode node)
		{
			return _0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020.ContainsKey(node);
		}

		public IList<TreeNode> GetSortedNodes()
		{
			SortedList<string, TreeNode> sortedList = new SortedList<string, TreeNode>();
			foreach (TreeNode item in _0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A_000A_000A)
			{
				sortedList.Add(item.GetId(), item);
			}
			return sortedList.Values;
		}

		public TreeNode[] ToArray()
		{
			return _0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A_000A_000A?.ToArray();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return _0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A_000A_000A.GetEnumerator();
		}
	}
}
