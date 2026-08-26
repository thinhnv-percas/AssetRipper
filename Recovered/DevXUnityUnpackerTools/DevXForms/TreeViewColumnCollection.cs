using DevXForms.TreeList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;

namespace DevXForms
{
	[Description("This is the columns collection")]
	[Editor(typeof(ColumnCollectionEditor), typeof(UITypeEditor))]
	public class TreeViewColumnCollection : IList<TreeListColumn>, ICollection<TreeListColumn>, IEnumerable<TreeListColumn>, IEnumerable, IList, ICollection
	{
		private ColumnHeaderPainter _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A = new ColumnHeaderPainter();

		private CollumnSetting _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020;

		private MultiSelectTreeView2 _0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020;

		private List<TreeListColumn> _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_000A = new List<TreeListColumn>();

		private List<TreeListColumn> _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020 = new List<TreeListColumn>();

		private Dictionary<string, TreeListColumn> _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A = new Dictionary<string, TreeListColumn>();

		private bool _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020;

		[Browsable(false)]
		public CollumnSetting Options => _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020;

		[Browsable(false)]
		public ColumnHeaderPainter Painter
		{
			get
			{
				return _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A;
			}
			set
			{
				_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A = value;
			}
		}

		[Browsable(false)]
		public MultiSelectTreeView2 Owner => _0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020;

		[Browsable(false)]
		public Font Font => _0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020.Font;

		[Browsable(false)]
		public TreeListColumn[] VisibleColumns => _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020.ToArray();

		[Browsable(false)]
		public int ColumnsWidth
		{
			get
			{
				int num = 0;
				foreach (TreeListColumn item in _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020)
				{
					num = ((!item.AutoSize) ? (num + item.Width) : (num + item._0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_0020));
				}
				return num;
			}
		}

		public TreeListColumn this[int index]
		{
			get
			{
				return _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_000A[index];
			}
			set
			{
				_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_000A[index] = value;
			}
		}

		public TreeListColumn this[string fieldname]
		{
			get
			{
				_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A.TryGetValue(fieldname, out TreeListColumn value);
				return value;
			}
		}

		[Browsable(false)]
		public int Count => _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_000A.Count;

		[Browsable(false)]
		public bool IsReadOnly => false;

		bool IList.IsFixedSize => false;

		object IList.this[int index]
		{
			get
			{
				throw new Exception("The method or operation is not implemented.");
			}
			set
			{
				throw new Exception("The method or operation is not implemented.");
			}
		}

		public bool IsSynchronized
		{
			get
			{
				throw new Exception("The method or operation is not implemented.");
			}
		}

		public object SyncRoot
		{
			get
			{
				throw new Exception("The method or operation is not implemented.");
			}
		}

		internal bool _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A
		{
			get
			{
				if (_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020 != null)
				{
					return _0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020._0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A;
				}
				return false;
			}
		}

		public TreeViewColumnCollection(MultiSelectTreeView2 owner)
		{
			_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020 = owner;
			_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020 = new CollumnSetting(owner);
		}

		public void SetVisibleIndex(TreeListColumn col, int index)
		{
			_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020.Remove(col);
			if (index >= 0)
			{
				if (index < _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020.Count)
				{
					_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020.Insert(index, col);
				}
				else
				{
					_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020.Add(col);
				}
			}
			RecalcVisibleColumsRect();
		}

		public HitInfo CalcHitInfo(Point point, int horzOffset)
		{
			HitInfo hitInfo = new HitInfo();
			hitInfo.Column = CalcHitColumn(point, horzOffset);
			if (hitInfo.Column != null && point.Y < Options.HeaderHeight)
			{
				hitInfo.HitType |= HitInfo.eHitType.kColumnHeader;
				int num = hitInfo.Column.CalculatedRect.Right - horzOffset;
				if (!hitInfo.Column.AutoSize && point.X >= num - 4 && point.X <= num)
				{
					hitInfo.HitType |= HitInfo.eHitType.kColumnHeaderResize;
				}
			}
			return hitInfo;
		}

		public TreeListColumn CalcHitColumn(Point point, int horzOffset)
		{
			if (point.X < Options.LeftMargin)
			{
				return null;
			}
			foreach (TreeListColumn item in _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020)
			{
				int num = item.CalculatedRect.Left - horzOffset;
				int num2 = item.CalculatedRect.Right - horzOffset;
				if (point.X >= num && point.X <= num2)
				{
					return item;
				}
			}
			return null;
		}

		public void RecalcVisibleColumsRect()
		{
			RecalcVisibleColumsRect(isDoingColumnResizing: false);
		}

		public void RecalcVisibleColumsRect(bool isDoingColumnResizing)
		{
			if (_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020)
			{
				return;
			}
			int num = 0;
			if (_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020.RowOptions.ShowHeader)
			{
				num = _0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020.RowOptions.HeaderWidth;
			}
			int y = 0;
			int headerHeight = Options.HeaderHeight;
			int num2 = 0;
			foreach (TreeListColumn item in _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_000A)
			{
				item._0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_0020 = -1;
				item._0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_000A = num2++;
			}
			int num4 = 0;
			int num5 = 0;
			float num6 = 0f;
			foreach (TreeListColumn item2 in _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020)
			{
				if (item2.AutoSize)
				{
					num5 += item2.AutoSizeMinSize;
					num6 += item2.AutoSizeRatio;
				}
				else
				{
					num4 += item2.Width;
				}
			}
			float num7 = _0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020.ClientRectangle.Width - _0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020._0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020_000A_000A() - (num4 + num5);
			float num8 = 0f;
			if (num6 > 0f && num7 > 0f)
			{
				num8 = num7 / num6;
			}
			for (num2 = 0; num2 < _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020.Count; num2++)
			{
				TreeListColumn treeListColumn = _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020[num2];
				int num9 = treeListColumn.Width;
				if (treeListColumn.AutoSize)
				{
					num9 = (treeListColumn._0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_0020 = ((!isDoingColumnResizing) ? (treeListColumn.AutoSizeMinSize + (int)(num8 * treeListColumn.AutoSizeRatio) - 1) : treeListColumn._0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_0020));
				}
				treeListColumn._0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A = new Rectangle(num, y, num9, headerHeight);
				treeListColumn._0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_0020 = num2;
				num += num9;
			}
			_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_000A();
		}

		public void Draw(Graphics dc, Rectangle rect, int horzOffset)
		{
			foreach (TreeListColumn item in _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020)
			{
				Rectangle calculatedRect = item.CalculatedRect;
				calculatedRect.X -= horzOffset;
				if (calculatedRect.Left > rect.Right)
				{
					break;
				}
				item.Draw(dc, _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A, calculatedRect);
			}
			if (_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020.RowOptions.ShowHeader)
			{
				Rectangle r = new Rectangle(0, 0, _0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020.RowOptions.HeaderWidth, Options.HeaderHeight);
				_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A.DrawHeaderFiller(dc, r);
			}
		}

		public void AddRange(IEnumerable<TreeListColumn> columns)
		{
			foreach (TreeListColumn column in columns)
			{
				Add(column);
			}
		}

		public void AddRange(TreeListColumn[] columns)
		{
			foreach (TreeListColumn item in columns)
			{
				Add(item);
			}
		}

		public void Add(TreeListColumn item)
		{
			if (Owner._0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A)
			{
				_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_000A.Remove(item);
				_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020.Remove(item);
			}
			item._0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020 = this;
			_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_000A.Add(item);
			_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020.Add(item);
			_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A[item.Fieldname] = item;
			RecalcVisibleColumsRect();
		}

		public void Clear()
		{
			_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A.Clear();
			_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_000A.Clear();
			_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020.Clear();
		}

		public bool Contains(TreeListColumn item)
		{
			return _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_000A.Contains(item);
		}

		public int IndexOf(TreeListColumn item)
		{
			return _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_000A.IndexOf(item);
		}

		public void Insert(int index, TreeListColumn item)
		{
			_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_000A.Insert(index, item);
		}

		public void RemoveAt(int index)
		{
			_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_000A.RemoveAt(index);
		}

		public void CopyTo(TreeListColumn[] array, int arrayIndex)
		{
			_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_000A.CopyTo(array, arrayIndex);
		}

		public bool Remove(TreeListColumn item)
		{
			return _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_000A.Remove(item);
		}

		public IEnumerator<TreeListColumn> GetEnumerator()
		{
			return _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_000A.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		int IList.Add(object value)
		{
			Add((TreeListColumn)value);
			return Count - 1;
		}

		bool IList.Contains(object value)
		{
			return Contains((TreeListColumn)value);
		}

		int IList.IndexOf(object value)
		{
			return IndexOf((TreeListColumn)value);
		}

		void IList.Insert(int index, object value)
		{
			Insert(index, (TreeListColumn)value);
		}

		void IList.Remove(object value)
		{
			Remove((TreeListColumn)value);
		}

		public void CopyTo(Array array, int index)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		internal void _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_000A()
		{
			if (_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020 != null)
			{
				_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020.Invalidate();
			}
		}

		internal void _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_0020()
		{
			_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020 = true;
		}

		internal void _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A()
		{
			_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020 = false;
			RecalcVisibleColumsRect();
		}
	}
}
