using DevXForms.TreeList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace DevXForms
{
	public class MultiSelectTreeView2 : Control, ISupportInitialize
	{
		public delegate void NotifyBeforeExpandHandler(TreeNode node, bool isExpanding);

		public delegate void NotifyAfterHandler(TreeNode node, bool isExpanding);

		[CompilerGenerated]
		internal TreeViewEventHandler _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020;

		[CompilerGenerated]
		internal NotifyAfterHandler _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A;

		[CompilerGenerated]
		internal TreeViewCancelEventHandler _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020;

		[CompilerGenerated]
		internal bool _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A;

		[CompilerGenerated]
		internal bool _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020;

		[CompilerGenerated]
		internal bool _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A;

		[CompilerGenerated]
		internal string _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A;

		[CompilerGenerated]
		internal string _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020;

		internal TreeListViewNodes _0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A_000A_000A;

		internal TreeViewColumnCollection _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_000A;

		internal RowSetting _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_000A_0020_0020;

		internal ViewSetting _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A;

		internal bool _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020;

		internal VScrollBar _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A;

		internal HScrollBar _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020;

		internal Panel _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A;

		internal Panel _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A_0020;

		internal bool _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A = true;

		internal TreeNode _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020;

		internal ImageList _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A = new ImageList();

		internal RowPainter _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020;

		internal CellPainter _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_000A;

		internal TreeListColumn _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020;

		internal int _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_000A_000A_000A;

		internal NodesSelection _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_000A_000A_0020 = new NodesSelection();

		internal TreeNode _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_000A_0020_000A;

		internal int _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_000A_0020_0020 = -1;

		[CompilerGenerated]
		internal MouseEventHandler _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A;

		internal bool _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020;

		internal TreeListColumn _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A;

		internal Image _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020;

		internal Graphics _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A;

		internal Graphics _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_0020;

		internal Rectangle _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A_0020_000A;

		internal bool _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A_0020_0020;

		internal int _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_000A;

		internal int _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020;

		internal bool _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A;

		internal bool _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020;

		internal Rectangle _0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A;

		public bool FullRowSelect
		{
			get;
			set;
		}

		public bool HideSelection
		{
			get;
			set;
		}

		public bool LabelEdit
		{
			get;
			set;
		}

		public string ImageKey
		{
			get;
			set;
		}

		public string SelectedImageKey
		{
			get;
			set;
		}

		public bool ShowColumns
		{
			get
			{
				return _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020;
			}
			set
			{
				_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020 = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Category("Columns")]
		[Browsable(true)]
		public TreeViewColumnCollection Columns => _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_000A;

		[Browsable(true)]
		[Category("Options")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public CollumnSetting ColumnsOptions => _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_000A.Options;

		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Category("Options")]
		public RowSetting RowOptions => _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_000A_0020_0020;

		[Category("Options")]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public ViewSetting ViewOptions => _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A;

		[Category("Behavior")]
		[DefaultValue(typeof(bool), "True")]
		public bool MultiSelect
		{
			get
			{
				return _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A;
			}
			set
			{
				_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A = value;
			}
		}

		[DefaultValue(typeof(Color), "Window")]
		public new Color BackColor
		{
			get
			{
				return base.BackColor;
			}
			set
			{
				base.BackColor = value;
			}
		}

		public ImageList ImageList
		{
			get
			{
				return _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A;
			}
			set
			{
				_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A = value;
			}
		}

		public TreeListViewNodes Nodes => _0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A_000A_000A;

		[Browsable(false)]
		public CellPainter CellPainter
		{
			get
			{
				return _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_000A;
			}
			set
			{
				_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_000A = value;
			}
		}

		[Browsable(false)]
		public NodesSelection NodesSelection => _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_000A_000A_0020;

		internal TreeNode _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A
		{
			get
			{
				if (NodesSelection.Count == 0)
				{
					return null;
				}
				return NodesSelection[NodesSelection.Count - 1];
			}
			set
			{
				NodesSelection.Clear();
				NodesSelection.Add(value);
				EnsureVisible(value);
				FocusedNode = value;
			}
		}

		internal NodesSelection _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020 => _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_000A_000A_0020;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public TreeNode FocusedNode
		{
			get
			{
				return _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_000A_0020_000A;
			}
			set
			{
				TreeNode focusedNode = FocusedNode;
				if (focusedNode != value)
				{
					if (!MultiSelect)
					{
						NodesSelection.Clear();
					}
					int visibleNodeIndex = TreeNodeCollection.GetVisibleNodeIndex(focusedNode);
					int visibleNodeIndex2 = TreeNodeCollection.GetVisibleNodeIndex(value);
					_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_000A_0020_000A = value;
					OnAfterSelect(value);
					InvalidateRow(visibleNodeIndex);
					InvalidateRow(visibleNodeIndex2);
					EnsureVisible(_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_000A_0020_000A);
				}
			}
		}

		internal int _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A
		{
			get
			{
				if (!ShowColumns)
				{
					return 0;
				}
				return Columns.Options.HeaderHeight;
			}
		}

		internal bool _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A => base.DesignMode;

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				createParams.Style &= -8388609;
				createParams.ExStyle &= -513;
				switch (ViewOptions.BorderStyle)
				{
				case BorderStyle.Fixed3D:
					createParams.ExStyle |= 512;
					break;
				case BorderStyle.FixedSingle:
					createParams.Style |= 8388608;
					break;
				}
				return createParams;
			}
		}

		public new Rectangle ClientRectangle
		{
			get
			{
				Rectangle clientRectangle = base.ClientRectangle;
				if (_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A.Visible)
				{
					clientRectangle.Width -= _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A.Width + 1;
				}
				if (_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020.Visible)
				{
					clientRectangle.Height -= _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020.Height + 1;
				}
				return clientRectangle;
			}
		}

		public event TreeViewEventHandler AfterSelect
		{
			[CompilerGenerated]
			add
			{
				TreeViewEventHandler treeViewEventHandler = _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020;
				TreeViewEventHandler treeViewEventHandler2;
				do
				{
					treeViewEventHandler2 = treeViewEventHandler;
					TreeViewEventHandler value2 = (TreeViewEventHandler)Delegate.Combine(treeViewEventHandler2, value);
					treeViewEventHandler = Interlocked.CompareExchange(ref _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020, value2, treeViewEventHandler2);
				}
				while ((object)treeViewEventHandler != treeViewEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				TreeViewEventHandler treeViewEventHandler = _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020;
				TreeViewEventHandler treeViewEventHandler2;
				do
				{
					treeViewEventHandler2 = treeViewEventHandler;
					TreeViewEventHandler value2 = (TreeViewEventHandler)Delegate.Remove(treeViewEventHandler2, value);
					treeViewEventHandler = Interlocked.CompareExchange(ref _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020, value2, treeViewEventHandler2);
				}
				while ((object)treeViewEventHandler != treeViewEventHandler2);
			}
		}

		public event NotifyAfterHandler AfterExpand
		{
			[CompilerGenerated]
			add
			{
				NotifyAfterHandler notifyAfterHandler = _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A;
				NotifyAfterHandler notifyAfterHandler2;
				do
				{
					notifyAfterHandler2 = notifyAfterHandler;
					NotifyAfterHandler value2 = (NotifyAfterHandler)Delegate.Combine(notifyAfterHandler2, value);
					notifyAfterHandler = Interlocked.CompareExchange(ref _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A, value2, notifyAfterHandler2);
				}
				while ((object)notifyAfterHandler != notifyAfterHandler2);
			}
			[CompilerGenerated]
			remove
			{
				NotifyAfterHandler notifyAfterHandler = _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A;
				NotifyAfterHandler notifyAfterHandler2;
				do
				{
					notifyAfterHandler2 = notifyAfterHandler;
					NotifyAfterHandler value2 = (NotifyAfterHandler)Delegate.Remove(notifyAfterHandler2, value);
					notifyAfterHandler = Interlocked.CompareExchange(ref _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A, value2, notifyAfterHandler2);
				}
				while ((object)notifyAfterHandler != notifyAfterHandler2);
			}
		}

		public event TreeViewCancelEventHandler BeforeExpand
		{
			[CompilerGenerated]
			add
			{
				TreeViewCancelEventHandler treeViewCancelEventHandler = _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020;
				TreeViewCancelEventHandler treeViewCancelEventHandler2;
				do
				{
					treeViewCancelEventHandler2 = treeViewCancelEventHandler;
					TreeViewCancelEventHandler value2 = (TreeViewCancelEventHandler)Delegate.Combine(treeViewCancelEventHandler2, value);
					treeViewCancelEventHandler = Interlocked.CompareExchange(ref _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020, value2, treeViewCancelEventHandler2);
				}
				while ((object)treeViewCancelEventHandler != treeViewCancelEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				TreeViewCancelEventHandler treeViewCancelEventHandler = _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020;
				TreeViewCancelEventHandler treeViewCancelEventHandler2;
				do
				{
					treeViewCancelEventHandler2 = treeViewCancelEventHandler;
					TreeViewCancelEventHandler value2 = (TreeViewCancelEventHandler)Delegate.Remove(treeViewCancelEventHandler2, value);
					treeViewCancelEventHandler = Interlocked.CompareExchange(ref _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020, value2, treeViewCancelEventHandler2);
				}
				while ((object)treeViewCancelEventHandler != treeViewCancelEventHandler2);
			}
		}

		internal event MouseEventHandler _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020
		{
			[CompilerGenerated]
			add
			{
				MouseEventHandler mouseEventHandler = _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A;
				MouseEventHandler mouseEventHandler2;
				do
				{
					mouseEventHandler2 = mouseEventHandler;
					MouseEventHandler value2 = (MouseEventHandler)Delegate.Combine(mouseEventHandler2, value);
					mouseEventHandler = Interlocked.CompareExchange(ref _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A, value2, mouseEventHandler2);
				}
				while ((object)mouseEventHandler != mouseEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				MouseEventHandler mouseEventHandler = _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A;
				MouseEventHandler mouseEventHandler2;
				do
				{
					mouseEventHandler2 = mouseEventHandler;
					MouseEventHandler value2 = (MouseEventHandler)Delegate.Remove(mouseEventHandler2, value);
					mouseEventHandler = Interlocked.CompareExchange(ref _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A, value2, mouseEventHandler2);
				}
				while ((object)mouseEventHandler != mouseEventHandler2);
			}
		}

		internal virtual void OnAfterSelect(TreeNode node)
		{
			raiseAfterSelect(node);
		}

		internal virtual void raiseAfterSelect(TreeNode node)
		{
			if (_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020 != null)
			{
				_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020(this, new TreeViewEventArgs(node));
			}
		}

		public virtual void OnNotifyBeforeExpand(TreeNode node, bool isExpanding, out bool cancel)
		{
			raiseNotifyBeforeExpand(node, isExpanding, out cancel);
		}

		internal virtual void raiseNotifyBeforeExpand(TreeNode node, bool isExpanding, out bool cancel)
		{
			cancel = false;
			if (_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020 != null)
			{
				TreeViewCancelEventArgs treeViewCancelEventArgs = new TreeViewCancelEventArgs();
				treeViewCancelEventArgs.Node = node;
				_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020?.Invoke(this, treeViewCancelEventArgs);
				cancel = treeViewCancelEventArgs.Cancel;
			}
		}

		public virtual void OnNotifyAfterExpand(TreeNode node, bool isExpanded)
		{
			raiseNotifyAfterExpand(node, isExpanded);
		}

		internal virtual void raiseNotifyAfterExpand(TreeNode node, bool isExpanded)
		{
			if (_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A != null)
			{
				_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A(node, isExpanded);
			}
		}

		public MultiSelectTreeView2()
		{
			DoubleBuffered = true;
			BackColor = SystemColors.Window;
			base.TabStop = true;
			_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020 = new RowPainter();
			_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_000A = new CellPainter(this);
			_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A_000A_000A = new TreeListViewNodes(this);
			_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_000A = new TreeViewColumnCollection(this);
			_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_000A_0020_0020 = new RowSetting(this);
			_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A = new ViewSetting(this);
			_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020();
			ShowColumns = false;
		}

		public void RecalcLayout()
		{
			if (_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020 == null)
			{
				_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020 = Nodes.FirstNode;
			}
			if (Nodes.Count == 0)
			{
				_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020 = null;
			}
			_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A();
			int num = _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A();
			if (num == 0)
			{
				_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020 = Nodes.FirstNode;
			}
			else
			{
				_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020 = TreeNodeCollection.GetNextNode(Nodes.FirstNode, num);
			}
			Invalidate();
		}

		internal void _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020()
		{
			_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020 = new HScrollBar();
			_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020.Scroll += _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020_0020_000A;
			_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020.Dock = DockStyle.Fill;
			_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A = new VScrollBar();
			_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A.Scroll += _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_0020;
			_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A.Dock = DockStyle.Right;
			_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A = new Panel();
			_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A.BackColor = Color.Transparent;
			_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A.Size = new Size(_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A.Width - 1, _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020.Height);
			_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A.Dock = DockStyle.Right;
			base.Controls.Add(_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A);
			_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A_0020 = new Panel();
			_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A_0020.Height = _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020.Height;
			_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A_0020.Dock = DockStyle.Bottom;
			_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A_0020.Controls.Add(_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020);
			_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A_0020.Controls.Add(_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A);
			base.Controls.Add(_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A_0020);
		}

		public void EnsureVisible(TreeNode node)
		{
			if (node != null)
			{
				int num = 0;
				List<TreeNode> list = new List<TreeNode>();
				TreeNode parent = node.Parent;
				while (parent != null && num++ < 100)
				{
					list.Insert(0, parent);
					parent = parent.Parent;
				}
				for (num = 0; num < list.Count; num++)
				{
					list[num].Expand();
				}
				int num3 = _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A() - 1;
				int visibleNodeIndex = TreeNodeCollection.GetVisibleNodeIndex(node);
				if (visibleNodeIndex < _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A())
				{
					_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020_0020_0020(visibleNodeIndex);
				}
				if (visibleNodeIndex > _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A() + num3)
				{
					_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020_0020_0020(visibleNodeIndex - num3);
				}
			}
		}

		public TreeNode CalcHitNode(Point mousepoint)
		{
			int num = _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020_000A_000A(mousepoint);
			if (num < 0)
			{
				return null;
			}
			return TreeNodeCollection.GetNextNode(_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020, num);
		}

		public TreeNode GetHitNode()
		{
			return CalcHitNode(PointToClient(Control.MousePosition));
		}

		public HitInfo CalcColumnHit(Point mousepoint)
		{
			return Columns.CalcHitInfo(mousepoint, _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020());
		}

		public bool HitTestScrollbar(Point mousepoint)
		{
			if (_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020.Visible && mousepoint.Y >= ClientRectangle.Height - _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020.Height)
			{
				return true;
			}
			return false;
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			if (ClientRectangle.Width > 0 && ClientRectangle.Height > 0)
			{
				Columns.RecalcVisibleColumsRect();
				_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A();
			}
		}

		internal virtual void BeforeShowContextMenu()
		{
		}

		internal void InvalidateRow(int absoluteRowIndex)
		{
			int _0020 = absoluteRowIndex - _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A();
			Rectangle rectangle = _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020_0020_000A(_0020);
			if (rectangle != Rectangle.Empty)
			{
				rectangle.Inflate(1, 1);
				Invalidate(rectangle);
			}
		}

		internal void _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_0020(object _0020, ScrollEventArgs _0020_000A)
		{
			int num = _0020_000A.NewValue - _0020_000A.OldValue;
			if (num != 0)
			{
				if (_0020_000A.NewValue == 0)
				{
					_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020 = Nodes.FirstNode;
					num = 0;
				}
				_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020 = TreeNodeCollection.GetNextNode(_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020, num);
				Invalidate();
			}
		}

		internal void _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020_0020_000A(object _0020, ScrollEventArgs _0020_000A)
		{
			Invalidate();
		}

		internal void _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020_0020_0020(int _0020)
		{
			if (_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A != null)
			{
				if (_0020 < 0)
				{
					_0020 = 0;
				}
				int num = _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A.Maximum - _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A.LargeChange + 1;
				if (_0020 > num)
				{
					_0020 = num;
				}
				if (_0020 < _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A.Minimum)
				{
					_0020 = _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A.Minimum;
				}
				if (_0020 > _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A.Maximum)
				{
					_0020 = _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A.Maximum;
				}
				if (_0020 >= 0 && _0020 <= num && _0020 != _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A.Value)
				{
					ScrollEventArgs _0020_000A = new ScrollEventArgs(ScrollEventType.ThumbPosition, _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A.Value, _0020, ScrollOrientation.VerticalScroll);
					try
					{
						_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A.Value = _0020;
					}
					catch (Exception arg)
					{
						ConsoleManager._0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A(string.Concat(arg));
					}
					_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_0020(_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A, _0020_000A);
				}
			}
		}

		internal int _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A()
		{
			if (_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A == null)
			{
				return 0;
			}
			if (!_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A.Visible)
			{
				return 0;
			}
			return _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A.Value;
		}

		internal int _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020()
		{
			if (_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A == null)
			{
				return 0;
			}
			if (!_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020.Visible)
			{
				return 0;
			}
			return _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020.Value;
		}

		internal void _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A()
		{
			if (_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A == null || ClientRectangle.Width < 0)
			{
				return;
			}
			int num = _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A();
			int visibleNodeCount = Nodes.VisibleNodeCount;
			if (num > visibleNodeCount)
			{
				_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A.Visible = false;
				_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020_0020_0020(0);
			}
			else
			{
				_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A.Visible = true;
				_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A.SmallChange = 1;
				_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A.LargeChange = num;
				_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A.Minimum = 0;
				_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A.Maximum = visibleNodeCount - 1;
				int num2 = _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A.Maximum - _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A.LargeChange;
				if (num2 < _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A.Value)
				{
					_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020_0020_0020(num2);
				}
			}
			if (ClientRectangle.Width > _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020())
			{
				_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A_0020.Visible = false;
				_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020.Value = 0;
				return;
			}
			_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020.Minimum = 0;
			_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020.Maximum = _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020();
			_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020.SmallChange = 5;
			_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020.LargeChange = ClientRectangle.Width;
			_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A.Visible = _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A.Visible;
			_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A_0020.Visible = true;
		}

		internal int _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020_000A_000A(Point _0020)
		{
			if (_0020.Y <= _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A)
			{
				return -1;
			}
			return (_0020.Y - _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A) / RowOptions.ItemHeight;
		}

		internal int _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020_000A_0020(int _0020)
		{
			return _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A + _0020 * RowOptions.ItemHeight;
		}

		internal Rectangle _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020_0020_000A(int _0020)
		{
			Rectangle clientRectangle = ClientRectangle;
			clientRectangle.Y = _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020_000A_0020(_0020);
			if (clientRectangle.Top < _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A || clientRectangle.Top > ClientRectangle.Height)
			{
				return Rectangle.Empty;
			}
			clientRectangle.Height = RowOptions.ItemHeight;
			return clientRectangle;
		}

		internal void _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020_0020_0020(TreeNode _0020, Keys _0020_000A)
		{
			if (Control.ModifierKeys == Keys.None)
			{
				foreach (TreeNode item in NodesSelection)
				{
					int visibleNodeIndex = TreeNodeCollection.GetVisibleNodeIndex(item);
					InvalidateRow(visibleNodeIndex);
				}
				NodesSelection.Clear();
				NodesSelection.Add(_0020);
			}
			if (Control.ModifierKeys == Keys.Shift)
			{
				if (NodesSelection.Count == 0)
				{
					NodesSelection.Add(_0020);
				}
				else
				{
					int visibleNodeIndex2 = TreeNodeCollection.GetVisibleNodeIndex(NodesSelection[0]);
					int visibleNodeIndex3 = TreeNodeCollection.GetVisibleNodeIndex(_0020);
					if (visibleNodeIndex3 > visibleNodeIndex2)
					{
						TreeNode firstNode = NodesSelection[0];
						NodesSelection.Clear();
						foreach (TreeNode item2 in TreeNodeCollection.ForwardNodeIterator(firstNode, _0020, mustBeVisible: true))
						{
							NodesSelection.Add(item2);
						}
						Invalidate();
					}
					if (visibleNodeIndex3 < visibleNodeIndex2)
					{
						TreeNode firstNode2 = NodesSelection[0];
						NodesSelection.Clear();
						foreach (TreeNode item3 in TreeNodeCollection.ReverseNodeIterator(firstNode2, _0020, mustBeVisible: true))
						{
							NodesSelection.Add(item3);
						}
						Invalidate();
					}
				}
			}
			if (Control.ModifierKeys == Keys.Control)
			{
				if (NodesSelection.Contains(_0020))
				{
					NodesSelection.Remove(_0020);
				}
				else
				{
					NodesSelection.Add(_0020);
				}
			}
			InvalidateRow(TreeNodeCollection.GetVisibleNodeIndex(_0020));
			FocusedNode = _0020;
		}

		protected override void OnMouseClick(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				Point point = new Point(e.X, e.Y);
				TreeNode treeNode = CalcHitNode(point);
				if (treeNode != null && Columns.Count > 0)
				{
					int visibleRowIndex = _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020_000A_000A(point);
					Rectangle plusMinusRectangle = GetPlusMinusRectangle(treeNode, Columns.VisibleColumns[0], visibleRowIndex);
					if (treeNode.HasChildren && plusMinusRectangle != Rectangle.Empty && plusMinusRectangle.Contains(point))
					{
						treeNode.Expanded = !treeNode.Expanded;
					}
					else if (MultiSelect)
					{
						_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020_0020_0020(treeNode, Control.ModifierKeys);
					}
					else
					{
						FocusedNode = treeNode;
					}
				}
				else
				{
					_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020.Clear();
					FocusedNode = null;
				}
			}
			base.OnMouseClick(e);
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			if (_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020 != null)
			{
				int num = _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020.CalculatedRect.Left - _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_000A_000A_000A;
				int num2 = e.X - num;
				if (num2 < 10)
				{
					num2 = 10;
				}
				_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020.Width = num2;
				Columns.RecalcVisibleColumsRect(isDoingColumnResizing: true);
				Invalidate();
				return;
			}
			TreeListColumn treeListColumn = null;
			if (ShowColumns)
			{
				HitInfo hitInfo = Columns.CalcHitInfo(new Point(e.X, e.Y), _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020());
				if ((hitInfo.HitType & HitInfo.eHitType.kColumnHeader) > (HitInfo.eHitType)0)
				{
					treeListColumn = hitInfo.Column;
				}
				if ((hitInfo.HitType & HitInfo.eHitType.kColumnHeaderResize) > (HitInfo.eHitType)0)
				{
					Cursor = Cursors.VSplit;
				}
				else
				{
					Cursor = Cursors.Arrow;
				}
				_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_000A_0020_0020(treeListColumn, _0020_000A: true);
				int num3 = _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A();
				int num4 = -1;
				if (treeListColumn == null)
				{
					num4 = (e.Y - _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A) / RowOptions.ItemHeight + num3;
				}
				if (num4 != _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_000A_0020_0020)
				{
					InvalidateRow(_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_000A_0020_0020);
					_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_000A_0020_0020 = num4;
					InvalidateRow(_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_000A_0020_0020);
				}
			}
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			if (ShowColumns)
			{
				_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_000A_0020_0020(null, _0020_000A: false);
			}
		}

		protected override void OnMouseWheel(MouseEventArgs e)
		{
			int _0020 = _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A.Value - e.Delta * SystemInformation.MouseWheelScrollLines / 120;
			if (_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A.Visible)
			{
				_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020_0020_0020(_0020);
			}
			base.OnMouseWheel(e);
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			Focus();
			if (e.Button == MouseButtons.Right)
			{
				Point mousepoint = new Point(e.X, e.Y);
				TreeNode treeNode = CalcHitNode(mousepoint);
				if (treeNode != null)
				{
					if (MultiSelect && !NodesSelection.Contains(treeNode))
					{
						_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020_0020_0020(treeNode, Control.ModifierKeys);
					}
					FocusedNode = treeNode;
					Invalidate();
				}
				BeforeShowContextMenu();
			}
			if (e.Button == MouseButtons.Left)
			{
				HitInfo hitInfo = Columns.CalcHitInfo(new Point(e.X, e.Y), _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020());
				if ((hitInfo.HitType & HitInfo.eHitType.kColumnHeaderResize) > (HitInfo.eHitType)0)
				{
					_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020 = hitInfo.Column;
					_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_000A_000A_000A = _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020();
					return;
				}
			}
			base.OnMouseDown(e);
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			if (_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020 != null)
			{
				_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020 = null;
				Columns.RecalcVisibleColumsRect();
				_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A();
				Invalidate();
				if (_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A != null)
				{
					_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A(this, e);
				}
			}
			base.OnMouseUp(e);
		}

		protected override void OnMouseDoubleClick(MouseEventArgs e)
		{
			base.OnMouseDoubleClick(e);
			Point mousepoint = new Point(e.X, e.Y);
			TreeNode treeNode = CalcHitNode(mousepoint);
			if (treeNode != null && treeNode.HasChildren)
			{
				treeNode.Expanded = !treeNode.Expanded;
			}
		}

		internal void _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_000A_0020_000A()
		{
			UpdateStyles();
		}

		public void BeginInit()
		{
			Columns._0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_0020();
		}

		public void EndInit()
		{
			Columns._0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A();
		}

		protected override void OnEnter(EventArgs e)
		{
			base.OnEnter(e);
			Invalidate();
		}

		protected override void OnLeave(EventArgs e)
		{
			base.OnLeave(e);
			Invalidate();
		}

		internal void _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_000A_0020_0020(TreeListColumn _0020, bool _0020_000A)
		{
			int num = _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020();
			if (_0020 != _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A)
			{
				if (_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A != null)
				{
					_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A.ishot = false;
					Rectangle calculatedRect = _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A.CalculatedRect;
					calculatedRect.X -= num;
					Invalidate(calculatedRect);
				}
				_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A = _0020;
				if (_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A != null)
				{
					_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A.ishot = _0020_000A;
					Rectangle calculatedRect2 = _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A.CalculatedRect;
					calculatedRect2.X -= num;
					Invalidate(calculatedRect2);
				}
			}
		}

		internal int _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020_000A_000A()
		{
			if (RowOptions.ShowHeader)
			{
				return RowOptions.HeaderWidth;
			}
			return 0;
		}

		internal int _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020()
		{
			if (!ShowColumns)
			{
				int num = 0;
				foreach (TreeNode item in TreeNodeCollection.ForwardNodeIterator(_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020, mustBeVisible: true))
				{
					num = Math.Max(num, item._0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_000A.Right);
				}
				return _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020_000A_000A() + num;
			}
			return _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020_000A_000A() + Columns.ColumnsWidth;
		}

		internal int _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A(out int _0020)
		{
			_0020 = 0;
			if (ClientRectangle.Height < 0)
			{
				return 0;
			}
			int height = ClientRectangle.Height;
			int num = _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A;
			_0020 = (ClientRectangle.Height - _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A) % RowOptions.ItemHeight;
			return (ClientRectangle.Height - _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A) / RowOptions.ItemHeight;
		}

		internal int _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A()
		{
			int num;
			return _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A(out num);
		}

		public void BeginUpdate()
		{
			_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020 = true;
			_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A_000A_000A.BeginUpdate();
		}

		public void EndUpdate()
		{
			_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A_000A_000A.EndUpdate();
			_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020 = false;
			RecalcLayout();
			Invalidate();
		}

		public new void Update()
		{
			base.Update();
			Invalidate();
		}

		internal object _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020(TreeNode _0020, TreeListColumn _0020_000A)
		{
			string text = string.Empty;
			while (_0020 != null)
			{
				text = _0020.Owner.GetNodeIndex(_0020).ToString() + ":" + text;
				_0020 = _0020.Parent;
			}
			return "<temp>" + text;
		}

		internal virtual object GetData(TreeNode node, TreeListColumn column)
		{
			if (node[column.Index] != null)
			{
				return node[column.Index];
			}
			return null;
		}

		internal virtual TextFormatting GetFormatting(TreeNode node, TreeListColumn column)
		{
			return column.CellFormat;
		}

		internal virtual void PaintCell(Graphics dc, Rectangle cellRect, TreeNode node, TreeListColumn column)
		{
			if (_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A)
			{
				CellPainter.PaintCell(dc, cellRect, node, column, GetFormatting(node, column), _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020(node, column));
			}
			else
			{
				CellPainter.PaintCell(dc, cellRect, node, column, GetFormatting(node, column), GetData(node, column));
			}
		}

		internal virtual void PaintImage(Graphics dc, Rectangle imageRect, TreeNode node, Image image)
		{
			if (image != null)
			{
				dc.DrawImageUnscaled(image, imageRect);
			}
		}

		internal virtual void PaintNode(Graphics dc, Rectangle rowRect, TreeNode node, TreeListColumn[] visibleColumns, int visibleRowIndex)
		{
			if (ShowColumns)
			{
				CellPainter.DrawSelectionBackground(dc, rowRect, node);
			}
			int num = 0;
			TreeListColumn treeListColumn;
			Rectangle rectangle;
			while (true)
			{
				if (num >= visibleColumns.Length)
				{
					return;
				}
				treeListColumn = visibleColumns[num];
				if (!ShowColumns || treeListColumn.CalculatedRect.Right - _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020() >= _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020_000A_000A())
				{
					rectangle = rowRect;
					rectangle.X = treeListColumn.CalculatedRect.X - _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020();
					rectangle.Width = treeListColumn.CalculatedRect.Width;
					if (!ShowColumns)
					{
						break;
					}
					if (treeListColumn.VisibleIndex == 0)
					{
						int num2 = 10;
						rectangle.X += Columns.Options.LeftMargin;
						rectangle.Width -= Columns.Options.LeftMargin;
						int num3 = GetIndentSize(node) + 5;
						rectangle.X += num3;
						rectangle.Width -= num3;
						if (ViewOptions.ShowLine)
						{
							PaintLines(dc, rectangle, node);
						}
						rectangle.X += num2;
						rectangle.Width -= num2;
						Rectangle plusMinusRectangle = GetPlusMinusRectangle(node, treeListColumn, visibleRowIndex);
						if (plusMinusRectangle != Rectangle.Empty && ViewOptions.ShowPlusMinus)
						{
							CellPainter.PaintCellPlusMinus(dc, plusMinusRectangle, node);
						}
						if (!ViewOptions.ShowLine && !ViewOptions.ShowPlusMinus)
						{
							rectangle.X -= num2 + 5;
							rectangle.Width += num2 + 5;
						}
						Image nodeBitmap = GetNodeBitmap(node);
						if (nodeBitmap != null)
						{
							plusMinusRectangle.Y = rectangle.Y + rectangle.Height / 2 - nodeBitmap.Height / 2;
							plusMinusRectangle.X = rectangle.X;
							plusMinusRectangle.Width = nodeBitmap.Width;
							plusMinusRectangle.Height = nodeBitmap.Height;
							PaintImage(dc, plusMinusRectangle, node, nodeBitmap);
							rectangle.X += plusMinusRectangle.Width + 2;
							rectangle.Width -= plusMinusRectangle.Width + 2;
						}
						PaintCell(dc, rectangle, node, treeListColumn);
					}
					else
					{
						PaintCell(dc, rectangle, node, treeListColumn);
					}
				}
				num++;
			}
			rectangle.Width = rowRect.Width;
			int num4 = 10;
			rectangle.X += Columns.Options.LeftMargin;
			int num5 = GetIndentSize(node) + 5;
			rectangle.X += num5;
			if (ViewOptions.ShowLine)
			{
				PaintLines(dc, rectangle, node);
			}
			rectangle.X += num4;
			Rectangle plusMinusRectangle2 = GetPlusMinusRectangle(node, treeListColumn, visibleRowIndex);
			if (plusMinusRectangle2 != Rectangle.Empty && ViewOptions.ShowPlusMinus)
			{
				CellPainter.PaintCellPlusMinus(dc, plusMinusRectangle2, node);
			}
			if (!ViewOptions.ShowLine && !ViewOptions.ShowPlusMinus)
			{
				rectangle.X -= num4 + 5;
			}
			Rectangle nodeRect = rectangle;
			nodeRect.X -= 4;
			nodeRect.Width += 8;
			CellPainter.DrawSelectionBackground(dc, nodeRect, node);
			Image nodeBitmap2 = GetNodeBitmap(node);
			if (nodeBitmap2 != null)
			{
				plusMinusRectangle2.Y = rectangle.Y + rectangle.Height / 2 - nodeBitmap2.Height / 2;
				plusMinusRectangle2.X = rectangle.X;
				plusMinusRectangle2.Width = nodeBitmap2.Width;
				plusMinusRectangle2.Height = nodeBitmap2.Height;
				PaintImage(dc, plusMinusRectangle2, node, nodeBitmap2);
				rectangle.X += plusMinusRectangle2.Width + 2;
				rectangle.Width -= plusMinusRectangle2.Width + 2;
			}
			node._0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_000A = rectangle;
			PaintCell(dc, rectangle, node, treeListColumn);
		}

		internal virtual void PaintLines(Graphics dc, Rectangle cellRect, TreeNode node)
		{
			Pen pen = new Pen(Color.Gray);
			pen.DashStyle = DashStyle.Dot;
			int num = cellRect.Top + cellRect.Height / 2;
			if (node.Parent == null && node.PrevSibling == null)
			{
				cellRect.Y += cellRect.Height / 2;
				cellRect.Height -= cellRect.Height / 2;
			}
			if (node.NextSibling != null)
			{
				dc.DrawLine(pen, cellRect.X, cellRect.Top, cellRect.X, cellRect.Bottom);
			}
			else
			{
				dc.DrawLine(pen, cellRect.X, cellRect.Top, cellRect.X, num);
			}
			dc.DrawLine(pen, cellRect.X, num, cellRect.X + 8, num);
			for (TreeNode parent = node.Parent; parent != null; parent = parent.Parent)
			{
				cellRect.X -= ViewOptions.Indent;
				if (parent.NextSibling != null)
				{
					dc.DrawLine(pen, cellRect.X, cellRect.Top, cellRect.X, cellRect.Bottom);
				}
			}
			pen.Dispose();
		}

		internal virtual int GetIndentSize(TreeNode node)
		{
			int num = 0;
			for (TreeNode parent = node.Parent; parent != null; parent = parent.Parent)
			{
				num += ViewOptions.Indent;
			}
			return num;
		}

		internal virtual Rectangle GetPlusMinusRectangle(TreeNode node, TreeListColumn firstColumn, int visibleRowIndex)
		{
			if (!node.HasChildren)
			{
				return Rectangle.Empty;
			}
			int num = _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020();
			if (firstColumn.CalculatedRect.Right - num < _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020_000A_000A())
			{
				return Rectangle.Empty;
			}
			Rectangle calculatedRect = firstColumn.CalculatedRect;
			calculatedRect.X -= num;
			calculatedRect.X += GetIndentSize(node);
			calculatedRect.X += Columns.Options.LeftMargin;
			calculatedRect.Width = 10;
			calculatedRect.Y = _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020_000A_0020(visibleRowIndex);
			calculatedRect.Height = RowOptions.ItemHeight;
			return calculatedRect;
		}

		internal virtual Image GetNodeBitmap(TreeNode node)
		{
			if (ImageList != null && node.ImageId >= 0 && node.ImageId < ImageList.Images.Count)
			{
				return ImageList.Images[node.ImageId];
			}
			if (ImageList != null && !string.IsNullOrEmpty(node.ImageKey) && ImageList.Images.ContainsKey(node.ImageKey))
			{
				return ImageList.Images[node.ImageKey];
			}
			if (ImageList != null && !string.IsNullOrEmpty(ImageKey) && ImageList.Images.ContainsKey(ImageKey))
			{
				return ImageList.Images[ImageKey];
			}
			return null;
		}

		internal void _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A(int _0020, int _0020_000A)
		{
		}

		internal void Start()
		{
		}

		public void DoWork()
		{
			Thread.Sleep(1000);
			while (true)
			{
				Thread.Sleep(1);
				if (_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A_0020_0020 && !_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020 && base.Visible && MainForm.instance.Visible)
				{
					_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A_0020_0020 = false;
					try
					{
						DrawContent();
					}
					catch
					{
					}
				}
			}
		}

		public void DrawContent()
		{
			try
			{
				_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020 = true;
				if (_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020 == null || _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020.Size != base.Size)
				{
					_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_0020?.Dispose();
					_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020?.Dispose();
					_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020 = new Bitmap(base.Size.Width, base.Size.Height);
					_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_0020 = Graphics.FromImage(_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020);
					_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_0020.CompositingMode = CompositingMode.SourceOver;
					_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_0020.CompositingQuality = CompositingQuality.HighSpeed;
					_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_0020.InterpolationMode = InterpolationMode.Low;
					_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_0020.PixelOffsetMode = PixelOffsetMode.Half;
					_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A?.Dispose();
					_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A = CreateGraphics();
				}
				if (_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A == null)
				{
					_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A = CreateGraphics();
					_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A.CompositingMode = CompositingMode.SourceCopy;
					_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A.CompositingQuality = CompositingQuality.AssumeLinear;
					_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A.SmoothingMode = SmoothingMode.None;
					_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A.InterpolationMode = InterpolationMode.NearestNeighbor;
					_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A.TextRenderingHint = TextRenderingHint.SystemDefault;
					_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A.PixelOffsetMode = PixelOffsetMode.HighSpeed;
				}
				_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_0020.Clear(BackColor);
				OnPaintOwn(new PaintEventArgs(_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_0020, new Rectangle(0, 0, base.Width, base.Height)));
				_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A.DrawImageUnscaled(_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020, 0, 0);
			}
			catch (Exception _0020)
			{
				ConsoleManager.WriteEx45(_0020);
			}
			finally
			{
				_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020 = false;
			}
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			Invalidate();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			OnPaintOwn(e);
		}

		internal void OnPaintOwn(PaintEventArgs e)
		{
			int num = _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020();
			int num2 = 0;
			int num3 = _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A(out num2);
			if (num2 > 0)
			{
				num3++;
			}
			bool flag = true;
			if (ShowColumns)
			{
				if (flag)
				{
					Rectangle clipRectangle = e.ClipRectangle;
					Columns.Draw(e.Graphics, clipRectangle, num);
				}
				if (ViewOptions.ShowGridLines)
				{
					int num4 = Nodes.VisibleNodeCount - _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A.Value;
					if (num3 > num4)
					{
						num3 = num4;
					}
					Rectangle clientRectangle = ClientRectangle;
					if (flag)
					{
						clientRectangle.Y += _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A;
					}
					clientRectangle.Height = num3 * RowOptions.ItemHeight;
					Columns.Painter.DrawVerticalGridLines(Columns, e.Graphics, clientRectangle, num);
				}
			}
			int num5 = 0;
			TreeListColumn[] visibleColumns = Columns.VisibleColumns;
			int columnsWidth = Columns.ColumnsWidth;
			foreach (TreeNode item in TreeNodeCollection.ForwardNodeIterator(_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020, mustBeVisible: true))
			{
				Rectangle rectangle = _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020_0020_000A(num5);
				if (rectangle == Rectangle.Empty || rectangle.Bottom <= e.ClipRectangle.Top || rectangle.Top >= e.ClipRectangle.Bottom)
				{
					if (num5 > num3)
					{
						break;
					}
					num5++;
				}
				else
				{
					rectangle.X = _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020_000A_000A() - num;
					if (!ShowColumns)
					{
						string empty = string.Empty;
						empty = item?.Text.ToString();
						rectangle.Width = (int)e.Graphics.MeasureString(empty ?? string.Empty, Font).Width + 10;
						Image nodeBitmap = GetNodeBitmap(item);
						if (nodeBitmap != null)
						{
							rectangle.Width += nodeBitmap.Width;
						}
						if (ViewOptions.ShowGridLines)
						{
							Rectangle r = rectangle;
							r.X = _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020_000A_000A();
							r.Width = rectangle.Width + 10 - num;
							_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020.DrawHorizontalGridLine(e.Graphics, r);
						}
					}
					else
					{
						rectangle.Width = columnsWidth;
						if (ViewOptions.ShowGridLines)
						{
							Rectangle r2 = rectangle;
							r2.X = _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020_000A_000A();
							r2.Width = columnsWidth - num;
							_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020.DrawHorizontalGridLine(e.Graphics, r2);
						}
					}
					PaintNode(e.Graphics, rectangle, item, visibleColumns, num5);
					Rectangle r3 = rectangle;
					r3.X = 0;
					r3.Width = _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020_000A_000A();
					int num6 = num5 + _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A();
					r3.Width = _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020_000A_000A();
					if (r3.Width > 0)
					{
						_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020.DrawHeader(e.Graphics, r3, num6 == _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_000A_0020_0020);
					}
					num5++;
				}
			}
		}

		protected override bool IsInputKey(Keys keyData)
		{
			if ((keyData & Keys.Shift) > Keys.None)
			{
				return true;
			}
			if ((uint)(keyData - 33) <= 7u)
			{
				return true;
			}
			return false;
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			TreeNode treeNode = null;
			if (e.KeyCode == Keys.Prior)
			{
				int num = 0;
				int num2 = _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A(out num) - 1;
				treeNode = TreeNodeCollection.GetNextNode(FocusedNode, -num2);
				if (treeNode == null)
				{
					treeNode = Nodes.FirstVisibleNode();
				}
			}
			if (e.KeyCode == Keys.Next)
			{
				int num3 = 0;
				int searchOffset = _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A(out num3) - 1;
				treeNode = TreeNodeCollection.GetNextNode(FocusedNode, searchOffset);
				if (treeNode == null)
				{
					treeNode = Nodes.LastVisibleNode(recursive: true);
				}
			}
			if (e.KeyCode == Keys.Down)
			{
				treeNode = TreeNodeCollection.GetNextNode(FocusedNode, 1);
			}
			if (e.KeyCode == Keys.Up)
			{
				treeNode = TreeNodeCollection.GetNextNode(FocusedNode, -1);
			}
			if (e.KeyCode == Keys.Home)
			{
				treeNode = Nodes.FirstNode;
			}
			if (e.KeyCode == Keys.End)
			{
				treeNode = Nodes.LastVisibleNode(recursive: true);
			}
			if (e.KeyCode == Keys.Left && FocusedNode != null)
			{
				if (FocusedNode.Expanded)
				{
					FocusedNode.Collapse();
					EnsureVisible(FocusedNode);
					return;
				}
				if (FocusedNode.Parent != null)
				{
					FocusedNode = FocusedNode.Parent;
					EnsureVisible(FocusedNode);
				}
			}
			if (e.KeyCode == Keys.Right && FocusedNode != null)
			{
				if (!FocusedNode.Expanded && FocusedNode.HasChildren)
				{
					FocusedNode.Expand();
					EnsureVisible(FocusedNode);
					return;
				}
				if (FocusedNode.Expanded && FocusedNode.HasChildren)
				{
					FocusedNode = FocusedNode.Nodes.FirstNode;
					EnsureVisible(FocusedNode);
				}
			}
			if (treeNode != null)
			{
				if (MultiSelect)
				{
					if (Control.ModifierKeys == Keys.Control)
					{
						FocusedNode = treeNode;
					}
					else
					{
						_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020_0020_0020(treeNode, Control.ModifierKeys);
					}
				}
				else
				{
					FocusedNode = treeNode;
				}
				EnsureVisible(FocusedNode);
			}
			base.OnKeyDown(e);
		}
	}
}
