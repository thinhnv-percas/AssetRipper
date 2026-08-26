using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEditor.TreeViewExamples;
using UnityEngine;

internal class _0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A<_00210> : TreeViewItem where _00210 : TreeElement
{
	[CompilerGenerated]
	private _00210 _0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A;

	public _00210 data
	{
		[CompilerGenerated]
		get
		{
			return _0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A;
		}
		[CompilerGenerated]
		set
		{
			_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A = value;
		}
	}

	public _0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A(int id, int depth, string displayName, _00210 data)
		: base(id, depth, displayName)
	{
		this.data = data;
	}
}
internal class _0020_0020_000A_0020_0020_0020_000A_0020_000A_000A_0020<_00210> : TreeView where _00210 : TreeElement
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _0020_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A
	{
		public static readonly _0020_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A _0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A = new _0020_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A();

		public static Comparison<TreeViewItem> _0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A;

		public static Func<TreeElement, int> _0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020;

		internal int _0020_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A(TreeViewItem P_0, TreeViewItem P_1)
		{
			return EditorUtility.NaturalCompare(P_0.displayName, P_1.displayName);
		}

		internal int _0020_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020(TreeElement P_0)
		{
			return P_0.id;
		}
	}

	[CompilerGenerated]
	private sealed class _0020_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A
	{
		public SetupDragAndDropArgs _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A;

		internal bool _0020_0020_000A_0020_0020_0020_000A_000A_000A_0020_0020(TreeViewItem P_0)
		{
			return _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A.draggedItemIDs.Contains(P_0.id);
		}
	}

	private TreeModel<_00210> _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020;

	private readonly List<TreeViewItem> _0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A = new List<TreeViewItem>(100);

	[CompilerGenerated]
	private Action _0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020;

	[CompilerGenerated]
	private Action<IList<TreeViewItem>> _0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A;

	private const string _0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020 = "GenericDragColumnDragging";

	public TreeModel<_00210> treeModel => _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020;

	public event Action treeChanged
	{
		[CompilerGenerated]
		add
		{
			Action action = _0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref _0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action action = _0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref _0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public event Action<IList<TreeViewItem>> beforeDroppingDraggedItems
	{
		[CompilerGenerated]
		add
		{
			Action<IList<TreeViewItem>> action = _0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A;
			Action<IList<TreeViewItem>> action2;
			do
			{
				action2 = action;
				Action<IList<TreeViewItem>> value2 = (Action<IList<TreeViewItem>>)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref _0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action<IList<TreeViewItem>> action = _0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A;
			Action<IList<TreeViewItem>> action2;
			do
			{
				action2 = action;
				Action<IList<TreeViewItem>> value2 = (Action<IList<TreeViewItem>>)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref _0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public _0020_0020_000A_0020_0020_0020_000A_0020_000A_000A_0020(TreeViewState state, TreeModel<_00210> model)
		: base(state)
	{
		_0020_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A(model);
	}

	public _0020_0020_000A_0020_0020_0020_000A_0020_000A_000A_0020(TreeViewState state, MultiColumnHeader multiColumnHeader, TreeModel<_00210> model)
		: base(state, multiColumnHeader)
	{
		_0020_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A(model);
	}

	private void _0020_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A(TreeModel<_00210> P_0)
	{
		_0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020 = P_0;
		_0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020.modelChanged += _0020_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020;
	}

	private void _0020_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020()
	{
		if (_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020 != null)
		{
			_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020();
		}
		((TreeView)this).Reload();
	}

	protected override TreeViewItem BuildRoot()
	{
		int depth = -1;
		return (TreeViewItem)(object)new _0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A<_00210>(_0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020.root.id, depth, _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020.root.name, _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020.root);
	}

	protected override IList<TreeViewItem> BuildRows(TreeViewItem root)
	{
		if (_0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020.root == null)
		{
			Debug.LogError((object)_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A);
		}
		_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A.Clear();
		if (!string.IsNullOrEmpty(((TreeView)this).searchString))
		{
			_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020(_0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020.root, ((TreeView)this).searchString, _0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A);
		}
		else if (_0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020.root.hasChildren)
		{
			_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A(_0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020.root, 0, _0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A);
		}
		TreeView.SetupParentsAndChildrenFromDepths(root, (IList<TreeViewItem>)_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A);
		return _0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A;
	}

	private void _0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A(_00210 P_0, int P_1, IList<TreeViewItem> P_2)
	{
		foreach (_00210 child in P_0.children)
		{
			_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A<_00210> obj = new _0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A<_00210>(child.id, P_1, child.name, child);
			P_2.Add((TreeViewItem)(object)obj);
			if (child.hasChildren)
			{
				if (((TreeView)this).IsExpanded(child.id))
				{
					_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A(child, P_1 + 1, P_2);
				}
				else
				{
					((TreeViewItem)obj).children = TreeView.CreateChildListForCollapsedParent();
				}
			}
		}
	}

	private void _0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020(_00210 P_0, string P_1, List<TreeViewItem> P_2)
	{
		if (string.IsNullOrEmpty(P_1))
		{
			throw new ArgumentException(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A);
		}
		Stack<_00210> stack = new Stack<_00210>();
		foreach (TreeElement child in P_0.children)
		{
			stack.Push((_00210)child);
		}
		while (stack.Count > 0)
		{
			_00210 val = stack.Pop();
			if (val.name.IndexOf(P_1, StringComparison.OrdinalIgnoreCase) >= 0)
			{
				P_2.Add((TreeViewItem)(object)new _0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A<_00210>(val.id, 0, val.name, val));
			}
			if (val.children == null || val.children.Count <= 0)
			{
				continue;
			}
			foreach (TreeElement child2 in val.children)
			{
				stack.Push((_00210)child2);
			}
		}
		SortSearchResult(P_2);
	}

	protected virtual void SortSearchResult(List<TreeViewItem> rows)
	{
		rows.Sort((TreeViewItem P_0, TreeViewItem P_1) => EditorUtility.NaturalCompare(P_0.displayName, P_1.displayName));
	}

	protected override IList<int> GetAncestors(int id)
	{
		return _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020.GetAncestors(id);
	}

	protected override IList<int> GetDescendantsThatHaveChildren(int id)
	{
		return _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020.GetDescendantsThatHaveChildren(id);
	}

	protected override bool CanStartDrag(CanStartDragArgs args)
	{
		return true;
	}

	protected override void SetupDragAndDrop(SetupDragAndDropArgs args)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		if (!((TreeView)this).hasSearch)
		{
			DragAndDrop.PrepareStartDrag();
			List<TreeViewItem> list = (from P_0 in ((TreeView)this).GetRows()
				where args.draggedItemIDs.Contains(P_0.id)
				select P_0).ToList();
			DragAndDrop.SetGenericData(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020, (object)list);
			DragAndDrop.objectReferences = (Object[])(object)new Object[0];
			DragAndDrop.StartDrag((list.Count == 1) ? list[0].displayName : _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_0020_0020_0020_0020_000A_000A);
		}
	}

	protected override DragAndDropVisualMode HandleDragAndDrop(DragAndDropArgs args)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Invalid comparison between Unknown and I4
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Invalid comparison between Unknown and I4
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		if (DragAndDrop.GetGenericData(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020) is List<TreeViewItem> list)
		{
			DragAndDropPosition dragAndDropPosition = args.dragAndDropPosition;
			if ((int)dragAndDropPosition > 1)
			{
				if ((int)dragAndDropPosition == 2)
				{
					if (args.performDrop)
					{
						OnDropDraggedElementsAtIndex(list, _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020.root, _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020.root.children.Count);
					}
					return (DragAndDropVisualMode)16;
				}
				Debug.LogError((object)(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_0020_0020_0020_0020_000A_0020 + args.dragAndDropPosition));
				return (DragAndDropVisualMode)0;
			}
			bool flag = _0020_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A(args.parentItem, list);
			if (args.performDrop & flag)
			{
				_00210 data = ((_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A<_00210>)(object)args.parentItem).data;
				OnDropDraggedElementsAtIndex(list, data, (args.insertAtIndex != -1) ? args.insertAtIndex : 0);
			}
			if (flag)
			{
				return (DragAndDropVisualMode)16;
			}
			return (DragAndDropVisualMode)0;
		}
		return (DragAndDropVisualMode)0;
	}

	public virtual void OnDropDraggedElementsAtIndex(List<TreeViewItem> draggedRows, _00210 parent, int insertIndex)
	{
		if (_0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A != null)
		{
			_0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A(draggedRows);
		}
		List<TreeElement> list = new List<TreeElement>();
		foreach (TreeViewItem draggedRow in draggedRows)
		{
			list.Add(((_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A<_00210>)(object)draggedRow).data);
		}
		int[] array = list.Select((TreeElement P_0) => P_0.id).ToArray();
		_0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020.MoveElements(parent, insertIndex, list);
		((TreeView)this).SetSelection((IList<int>)array, (TreeViewSelectionOptions)2);
	}

	private bool _0020_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A(TreeViewItem P_0, List<TreeViewItem> P_1)
	{
		for (TreeViewItem val = P_0; val != null; val = val.parent)
		{
			if (P_1.Contains(val))
			{
				return false;
			}
		}
		return true;
	}
}
