using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;

namespace DevXForms
{
	public class TreeNode
	{
		internal TreeNodeCollection _0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020;

		internal TreeNode _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_0020_000A_0020;

		internal TreeNode _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A;

		internal TreeNodeCollection _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020;

		internal bool _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A_000A_000A;

		internal bool _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020;

		internal int _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A_0020_000A = -1;

		internal object _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A_0020_0020;

		internal Rectangle _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_000A;

		[CompilerGenerated]
		internal int _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020 = -1;

		[CompilerGenerated]
		internal string _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A = "";

		[CompilerGenerated]
		internal string _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020;

		[CompilerGenerated]
		internal string _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_0020;

		internal bool _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_000A;

		internal object[] _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020;

		internal int _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_0020_000A;

		public TreeNode Parent
		{
			get
			{
				if (_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020 != null)
				{
					return _0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020.Owner;
				}
				return null;
			}
		}

		public TreeNode PrevSibling => _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_0020_000A_0020;

		public TreeNode NextSibling => _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A;

		public bool HasChildren
		{
			get
			{
				if (_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020 != null && !_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020.IsEmpty())
				{
					return true;
				}
				return _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A_000A_000A;
			}
			set
			{
				_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A_000A_000A = value;
			}
		}

		public int ImageId
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

		public string Key
		{
			get;
			set;
		}

		public virtual TreeNodeCollection Owner => _0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020;

		public virtual TreeNodeCollection Nodes
		{
			get
			{
				if (_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020 == null)
				{
					_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020 = new TreeNodeCollection(this);
				}
				return _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020;
			}
		}

		public bool Expanded
		{
			get
			{
				if (_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020)
				{
					return HasChildren;
				}
				return false;
			}
			set
			{
				if (_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020 == value)
				{
					return;
				}
				TreeNodeCollection treeNodeCollection = null;
				if (!_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_000A)
				{
					treeNodeCollection = GetRootCollection();
					if (treeNodeCollection != null)
					{
						treeNodeCollection.NodetifyBeforeExpand(this, value, out bool cancel);
						if (cancel)
						{
							return;
						}
					}
				}
				int visibleNodeCount = VisibleNodeCount;
				_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020 = value;
				if (_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020)
				{
					_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_000A(1, VisibleNodeCount);
				}
				else
				{
					_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_000A(visibleNodeCount, 1);
				}
				if (!_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_000A)
				{
					treeNodeCollection?.NodetifyAfterExpand(this, value);
				}
			}
		}

		public object Tag
		{
			get
			{
				return _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A_0020_0020;
			}
			set
			{
				_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A_0020_0020 = value;
			}
		}

		public string Text
		{
			get
			{
				if (_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020 == null || _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020.Length == 0)
				{
					return null;
				}
				return _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020[0]?.ToString();
			}
			set
			{
				if (_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020 == null || _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020.Length == 0)
				{
					_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020 = new object[1];
				}
				_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020[0] = value;
			}
		}

		public object this[string fieldname]
		{
			get
			{
				return this[Owner.FieldIndex(fieldname)];
			}
			set
			{
				this[Owner.FieldIndex(fieldname)] = value;
			}
		}

		public object this[int index]
		{
			get
			{
				if (index < 0 || index >= _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020.Length)
				{
					return null;
				}
				return _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020[index];
			}
			set
			{
				if (index >= 0 && index < 100 && (_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020 == null || index >= _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020.Length))
				{
					object[] array = new object[index + 1];
					if (_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020 != null)
					{
						_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020.CopyTo(array, 0);
					}
					_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020 = array;
				}
				_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020(index);
				_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020[index] = value;
			}
		}

		public int VisibleNodeCount
		{
			get
			{
				if (_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020)
				{
					return _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_0020_000A + 1;
				}
				return 1;
			}
		}

		public int NodeIndex => _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020;

		internal int _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020
		{
			get
			{
				if (_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020 == null)
				{
					return -1;
				}
				_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020._0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020(_0020: false);
				return _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A_0020_000A;
			}
			set
			{
				_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A_0020_000A = value;
			}
		}

		public void Collapse()
		{
			Expanded = false;
		}

		public void Expand()
		{
			Expanded = true;
		}

		public void ExpandAll()
		{
			Expanded = true;
			if (HasChildren)
			{
				foreach (TreeNode node in Nodes)
				{
					node.ExpandAll();
				}
			}
		}

		public TreeNode()
		{
			_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020 = new object[1];
		}

		public TreeNode(string text)
		{
			_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020 = new object[1]
			{
				text
			};
		}

		public TreeNode(object[] fields)
		{
			SetData(fields);
		}

		public void EnsureVisible()
		{
			(GetRootCollection() as TreeListViewNodes)?.EnsureVisible(this);
		}

		public void SetData(object[] fields)
		{
			_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020 = new object[fields.Length];
			fields.CopyTo(_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020, 0);
		}

		public void MakeVisible()
		{
			for (TreeNode parent = Parent; parent != null; parent = parent.Parent)
			{
				parent.Expanded = true;
			}
		}

		public bool IsVisible()
		{
			for (TreeNode parent = Parent; parent != null; parent = parent.Parent)
			{
				if (!parent.Expanded)
				{
					return false;
				}
				if (parent.Owner == null)
				{
					return false;
				}
			}
			return true;
		}

		public TreeNode GetRoot()
		{
			TreeNode treeNode = this;
			while (treeNode.Parent != null)
			{
				treeNode = treeNode.Parent;
			}
			return treeNode;
		}

		public TreeNodeCollection GetRootCollection()
		{
			return GetRoot().Owner;
		}

		public string GetId()
		{
			StringBuilder stringBuilder = new StringBuilder(32);
			for (TreeNode treeNode = this; treeNode != null; treeNode = treeNode.Parent)
			{
				treeNode.Owner._0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020(_0020: false);
				if (treeNode.Parent != null)
				{
					stringBuilder.Insert(0, "." + treeNode._0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020.ToString());
				}
				else
				{
					stringBuilder.Insert(0, treeNode._0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020.ToString());
				}
			}
			return stringBuilder.ToString();
		}

		internal void _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A(TreeNode _0020, TreeNodeCollection _0020_000A)
		{
			_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020 = _0020_000A;
			TreeNode treeNode = null;
			if (_0020 != null)
			{
				treeNode = _0020.PrevSibling;
				_0020._0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_0020_000A_0020 = this;
			}
			if (treeNode != null)
			{
				treeNode._0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A = this;
			}
			_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A = _0020;
			_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_0020_000A_0020 = treeNode;
			_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_000A(0, VisibleNodeCount);
		}

		internal void _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A_0020_0020(TreeNode _0020, TreeNodeCollection _0020_000A)
		{
			_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020 = _0020_000A;
			TreeNode treeNode = null;
			if (_0020 != null)
			{
				treeNode = _0020.NextSibling;
				_0020._0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A = this;
				_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_0020_000A_0020 = _0020;
			}
			if (treeNode != null)
			{
				treeNode._0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_0020_000A_0020 = this;
			}
			_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A = treeNode;
			_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_000A(0, VisibleNodeCount);
		}

		internal void _0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_000A_0020_0020()
		{
			TreeNode prevSibling = PrevSibling;
			TreeNode nextSibling = NextSibling;
			if (prevSibling != null)
			{
				prevSibling._0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A = nextSibling;
			}
			if (nextSibling != null)
			{
				nextSibling._0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_0020_000A_0020 = prevSibling;
			}
			_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A = null;
			_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_0020_000A_0020 = null;
			_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_000A(VisibleNodeCount, 0);
			_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020 = null;
			_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A_0020_000A = -1;
		}

		internal static void _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A(TreeNode _0020, bool _0020_000A)
		{
			if (_0020 != null)
			{
				_0020._0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A_000A_000A = _0020_000A;
			}
		}

		internal void _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_0020(int _0020, int _0020_000A)
		{
			int visibleNodeCount = VisibleNodeCount;
			_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_0020_000A += _0020_000A - _0020;
			_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_000A(visibleNodeCount, VisibleNodeCount);
		}

		internal void _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_000A(int _0020, int _0020_000A)
		{
			if (Owner != null)
			{
				Owner._0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_000A(_0020, _0020_000A);
			}
			if (Parent != null)
			{
				Parent._0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_0020(_0020, _0020_000A);
			}
		}

		internal void _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020(int _0020)
		{
		}
	}
}
