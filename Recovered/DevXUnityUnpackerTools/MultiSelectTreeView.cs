using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

public class MultiSelectTreeView : TreeView
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020<_00210>
	{
		public static readonly _0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020<_00210> _0020_000A_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A = new _0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020<_00210>();

		public static Func<TreeNode, _00210> _0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A;

		internal _00210 _0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A(TreeNode _0020)
		{
			return (_00210)_0020.Tag;
		}
	}

	internal readonly Dictionary<int, TreeNode> _0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_000A_0020 = new Dictionary<int, TreeNode>();

	internal List<TreeNode> _0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A = new List<TreeNode>();

	internal TreeNode _0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020;

	public List<TreeNode> SelectedNodes
	{
		get
		{
			return _0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A;
		}
		set
		{
			_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_0020();
			if (value != null)
			{
				foreach (TreeNode item in value)
				{
					_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020(item, _0020_000A: true);
				}
			}
		}
	}

	public new TreeNode SelectedNode
	{
		get
		{
			return _0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020;
		}
		set
		{
			_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_0020();
			if (value != null)
			{
				_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A(value);
			}
		}
	}

	public void LoadItems<T>(IEnumerable<T> items, Func<T, int> getId, Func<T, int?> getParentId, Func<T, string> getDisplayName)
	{
		base.Nodes.Clear();
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_000A_0020.Clear();
		foreach (T item in items)
		{
			int num = getId(item);
			string text = getDisplayName(item);
			TreeNode value = new TreeNode
			{
				Name = num.ToString(),
				Text = text,
				Tag = item
			};
			_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_000A_0020.Add(getId(item), value);
		}
		foreach (int key in _0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_000A_0020.Keys)
		{
			TreeNode node = GetNode(key);
			T arg = (T)node.Tag;
			int? num2 = getParentId(arg);
			if (num2.HasValue)
			{
				GetNode(num2.Value).Nodes.Add(node);
			}
			else
			{
				base.Nodes.Add(node);
			}
		}
	}

	public IQueryable<T> GetItems<T>()
	{
		return _0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_000A_0020.Values.Select(_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020<T>._0020_000A_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A._0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A).AsQueryable();
	}

	public TreeNode GetNode(int id)
	{
		return _0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_000A_0020[id];
	}

	public T GetItem<T>(int id)
	{
		return (T)GetNode(id).Tag;
	}

	public T GetParent<T>(int id) where T : class
	{
		if (GetNode(id).Parent != null)
		{
			return (T)base.Parent.Tag;
		}
		return null;
	}

	public List<T> GetDescendants<T>(int id, int? deepLimit = default(int?))
	{
		IEnumerator enumerator = GetNode(id).Nodes.GetEnumerator();
		List<T> list = new List<T>();
		if (deepLimit.HasValue && deepLimit.Value <= 0)
		{
			return list;
		}
		while (enumerator.MoveNext())
		{
			TreeNode treeNode = (TreeNode)enumerator.Current;
			T item = (T)treeNode.Tag;
			list.Add(item);
			int? num = deepLimit.HasValue ? new int?(deepLimit.Value - 1) : null;
			if (!deepLimit.HasValue || num > 0)
			{
				int id2 = int.Parse(treeNode.Name);
				List<T> descendants = GetDescendants<T>(id2, num);
				list.AddRange(descendants);
			}
		}
		return list;
	}

	public MultiSelectTreeView()
	{
		base.SelectedNode = null;
	}

	protected override void OnGotFocus(EventArgs e)
	{
		try
		{
			if (_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020 == null && base.TopNode != null)
			{
				_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020(base.TopNode, _0020_000A: true);
			}
			base.OnGotFocus(e);
		}
		catch (Exception _0020)
		{
			_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A(_0020);
		}
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		try
		{
			base.SelectedNode = null;
			TreeNode nodeAt = GetNodeAt(e.Location);
			if (nodeAt != null)
			{
				int x = nodeAt.Bounds.X;
				int num = nodeAt.Bounds.Right + 10;
				if (e.Location.X > x && e.Location.X < num && (Control.ModifierKeys != 0 || !_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A.Contains(nodeAt)))
				{
					_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A(nodeAt);
				}
			}
			base.OnMouseDown(e);
		}
		catch (Exception _0020)
		{
			_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A(_0020);
		}
	}

	protected override void OnMouseUp(MouseEventArgs e)
	{
		try
		{
			TreeNode nodeAt = GetNodeAt(e.Location);
			if (nodeAt != null && Control.ModifierKeys == Keys.None && _0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A.Contains(nodeAt))
			{
				int x = nodeAt.Bounds.X;
				int num = nodeAt.Bounds.Right + 10;
				if (e.Location.X > x)
				{
					int x2 = e.Location.X;
				}
			}
			base.OnMouseUp(e);
		}
		catch (Exception _0020)
		{
			_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A(_0020);
		}
	}

	protected override void OnItemDrag(ItemDragEventArgs e)
	{
		try
		{
			TreeNode treeNode = e.Item as TreeNode;
			if (treeNode != null && !_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A.Contains(treeNode))
			{
				_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A(treeNode);
				_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020(treeNode, _0020_000A: true);
			}
			base.OnItemDrag(e);
		}
		catch (Exception _0020)
		{
			_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A(_0020);
		}
	}

	protected override void OnBeforeSelect(TreeViewCancelEventArgs e)
	{
		try
		{
			base.SelectedNode = null;
			e.Cancel = true;
			base.OnBeforeSelect(e);
		}
		catch (Exception _0020)
		{
			_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A(_0020);
		}
	}

	protected override void OnAfterSelect(TreeViewEventArgs e)
	{
		try
		{
			base.OnAfterSelect(e);
			base.SelectedNode = null;
		}
		catch (Exception _0020)
		{
			_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A(_0020);
		}
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		base.OnKeyDown(e);
		if (e.KeyCode != Keys.ShiftKey)
		{
			bool flag = Control.ModifierKeys == Keys.Shift;
			try
			{
				if (_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020 == null && base.TopNode != null)
				{
					_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020(base.TopNode, _0020_000A: true);
				}
				if (_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020 != null)
				{
					if (e.KeyCode == Keys.Left)
					{
						if (_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020.IsExpanded && _0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020.Nodes.Count > 0)
						{
							_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020.Collapse();
						}
						else if (_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020.Parent != null)
						{
							_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A(_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020.Parent);
						}
					}
					else if (e.KeyCode == Keys.Right)
					{
						if (!_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020.IsExpanded)
						{
							_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020.Expand();
						}
						else
						{
							_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A(_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020.FirstNode);
						}
					}
					else if (e.KeyCode == Keys.Up)
					{
						if (_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020.PrevVisibleNode != null)
						{
							_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A(_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020.PrevVisibleNode);
						}
					}
					else if (e.KeyCode == Keys.Down)
					{
						if (_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020.NextVisibleNode != null)
						{
							_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A(_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020.NextVisibleNode);
						}
					}
					else if (e.KeyCode == Keys.Home)
					{
						if (flag)
						{
							if (_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020.Parent == null)
							{
								if (base.Nodes.Count > 0)
								{
									_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A(base.Nodes[0]);
								}
							}
							else
							{
								_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A(_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020.Parent.FirstNode);
							}
						}
						else if (base.Nodes.Count > 0)
						{
							_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A(base.Nodes[0]);
						}
					}
					else if (e.KeyCode == Keys.End)
					{
						if (flag)
						{
							if (_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020.Parent == null)
							{
								if (base.Nodes.Count > 0)
								{
									_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A(base.Nodes[base.Nodes.Count - 1]);
								}
							}
							else
							{
								_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A(_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020.Parent.LastNode);
							}
						}
						else if (base.Nodes.Count > 0)
						{
							TreeNode lastNode = base.Nodes[0].LastNode;
							while (lastNode.IsExpanded && lastNode.LastNode != null)
							{
								lastNode = lastNode.LastNode;
							}
							_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A(lastNode);
						}
					}
					else if (e.KeyCode == Keys.Prior)
					{
						int num = base.VisibleCount;
						TreeNode prevVisibleNode = _0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020;
						while (num > 0 && prevVisibleNode.PrevVisibleNode != null)
						{
							prevVisibleNode = prevVisibleNode.PrevVisibleNode;
							num--;
						}
						_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A(prevVisibleNode);
					}
					else if (e.KeyCode == Keys.Next)
					{
						int num2 = base.VisibleCount;
						TreeNode nextVisibleNode = _0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020;
						while (num2 > 0 && nextVisibleNode.NextVisibleNode != null)
						{
							nextVisibleNode = nextVisibleNode.NextVisibleNode;
							num2--;
						}
						_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A(nextVisibleNode);
					}
					else
					{
						string value = ((char)(ushort)e.KeyValue).ToString();
						TreeNode nextVisibleNode2 = _0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020;
						do
						{
							if (nextVisibleNode2.NextVisibleNode == null)
							{
								return;
							}
							nextVisibleNode2 = nextVisibleNode2.NextVisibleNode;
						}
						while (!nextVisibleNode2.Text.StartsWith(value));
						_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A(nextVisibleNode2);
					}
				}
			}
			catch (Exception _0020)
			{
				_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A(_0020);
			}
			finally
			{
				EndUpdate();
			}
		}
	}

	internal void _0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A(TreeNode _0020)
	{
		try
		{
			BeginUpdate();
			if (_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020 == null || Control.ModifierKeys == Keys.Control)
			{
				bool flag = _0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A.Contains(_0020);
				_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020(_0020, !flag);
			}
			else if (Control.ModifierKeys == Keys.Shift)
			{
				TreeNode treeNode = _0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020;
				if (treeNode.Parent == _0020.Parent)
				{
					if (treeNode.Index < _0020.Index)
					{
						while (treeNode != _0020)
						{
							treeNode = treeNode.NextVisibleNode;
							if (treeNode == null)
							{
								break;
							}
							_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020(treeNode, _0020_000A: true);
						}
					}
					else if (treeNode.Index != _0020.Index)
					{
						while (treeNode != _0020)
						{
							treeNode = treeNode.PrevVisibleNode;
							if (treeNode == null)
							{
								break;
							}
							_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020(treeNode, _0020_000A: true);
						}
					}
				}
				else
				{
					TreeNode treeNode2 = treeNode;
					TreeNode treeNode3 = _0020;
					int num = Math.Min(treeNode2.Level, treeNode3.Level);
					while (treeNode2.Level > num)
					{
						treeNode2 = treeNode2.Parent;
					}
					while (treeNode3.Level > num)
					{
						treeNode3 = treeNode3.Parent;
					}
					while (treeNode2.Parent != treeNode3.Parent)
					{
						treeNode2 = treeNode2.Parent;
						treeNode3 = treeNode3.Parent;
					}
					if (treeNode2.Index < treeNode3.Index)
					{
						while (treeNode != _0020)
						{
							treeNode = treeNode.NextVisibleNode;
							if (treeNode == null)
							{
								break;
							}
							_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020(treeNode, _0020_000A: true);
						}
					}
					else if (treeNode2.Index == treeNode3.Index)
					{
						if (treeNode.Level < _0020.Level)
						{
							while (treeNode != _0020)
							{
								treeNode = treeNode.NextVisibleNode;
								if (treeNode == null)
								{
									break;
								}
								_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020(treeNode, _0020_000A: true);
							}
						}
						else
						{
							while (treeNode != _0020)
							{
								treeNode = treeNode.PrevVisibleNode;
								if (treeNode == null)
								{
									break;
								}
								_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020(treeNode, _0020_000A: true);
							}
						}
					}
					else
					{
						while (treeNode != _0020)
						{
							treeNode = treeNode.PrevVisibleNode;
							if (treeNode == null)
							{
								break;
							}
							_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020(treeNode, _0020_000A: true);
						}
					}
				}
			}
			else
			{
				_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A(_0020);
			}
			OnAfterSelect(new TreeViewEventArgs(_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020));
		}
		finally
		{
			EndUpdate();
		}
	}

	internal void _0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_0020()
	{
		try
		{
			foreach (TreeNode item in _0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A)
			{
				item.BackColor = BackColor;
				item.ForeColor = ForeColor;
			}
		}
		finally
		{
			_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A.Clear();
			_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020 = null;
		}
	}

	internal void _0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A(TreeNode _0020)
	{
		if (_0020 != null)
		{
			_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_0020();
			_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020(_0020, _0020_000A: true);
			_0020.EnsureVisible();
		}
	}

	internal void _0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020(TreeNode _0020, bool _0020_000A)
	{
		if (_0020_000A)
		{
			_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020 = _0020;
			if (!_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A.Contains(_0020))
			{
				_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A.Add(_0020);
			}
			_0020.BackColor = SystemColors.Highlight;
			_0020.ForeColor = SystemColors.HighlightText;
			for (TreeNode parent = _0020.Parent; parent != null; parent = parent.Parent)
			{
				parent.Expand();
			}
		}
		else
		{
			_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A.Remove(_0020);
			_0020.BackColor = BackColor;
			_0020.ForeColor = ForeColor;
		}
	}

	internal void _0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A(Exception _0020)
	{
		MessageBox.Show(_0020.Message);
	}
}
