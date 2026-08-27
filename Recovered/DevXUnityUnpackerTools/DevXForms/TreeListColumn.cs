using DevXForms.TreeList;
using System;
using System.ComponentModel;
using System.Drawing;

namespace DevXForms
{
	[DesignTimeVisible(false)]
	public class TreeListColumn
	{
		internal TextFormatting _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A = new TextFormatting();

		internal TextFormatting _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020_0020 = new TextFormatting();

		internal TreeViewColumnCollection _0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020;

		internal Rectangle _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_0020_000A_000A;

		internal int _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_0020_000A_0020 = -1;

		internal int _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A = -1;

		internal int _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_0020 = 50;

		internal string _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A = string.Empty;

		internal string _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020 = string.Empty;

		public bool ishot;

		internal bool _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A;

		internal float _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_000A_0020_0020 = 100f;

		internal int _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_000A;

		internal int _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public TextFormatting HeaderFormat => _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public TextFormatting CellFormat => _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020_0020;

		internal TreeViewColumnCollection _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020
		{
			get
			{
				return _0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020;
			}
			set
			{
				_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020 = value;
			}
		}

		internal Rectangle _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A
		{
			get
			{
				return _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_0020_000A_000A;
			}
			set
			{
				_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_0020_000A_000A = value;
			}
		}

		internal int _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_0020
		{
			get
			{
				return _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_0020_000A_0020;
			}
			set
			{
				_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_0020_000A_0020 = value;
			}
		}

		internal int _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_000A
		{
			get
			{
				return _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A;
			}
			set
			{
				_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A = value;
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Rectangle CalculatedRect => _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public MultiSelectTreeView2 TreeList
		{
			get
			{
				if (_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020 == null)
				{
					return null;
				}
				return _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020.Owner;
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Font Font => _0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020.Font;

		public int Width
		{
			get
			{
				return _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_0020;
			}
			set
			{
				if (_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_0020 != value)
				{
					_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_0020 = value;
					if (_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020 != null && _0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020._0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A)
					{
						_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020.RecalcVisibleColumsRect();
					}
				}
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string Caption
		{
			get
			{
				return _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020;
			}
			set
			{
				_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020 = value;
				if (_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020 != null)
				{
					_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020._0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_000A();
				}
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string Fieldname
		{
			get
			{
				return _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A;
			}
			set
			{
				if (_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020 == null || !_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020._0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A)
				{
					throw new Exception("Fieldname can only be set at design time, Use Constructor to set programatically");
				}
				if (value.Length == 0)
				{
					throw new Exception("empty Fieldname not value");
				}
				if (_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020[value] != null)
				{
					throw new Exception("fieldname already exist in collection");
				}
				_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public int VisibleIndex
		{
			get
			{
				return _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_0020;
			}
			set
			{
				if (_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020 != null)
				{
					_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020.SetVisibleIndex(this, value);
				}
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public int Index => _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_000A;

		[DefaultValue(false)]
		public bool AutoSize
		{
			get
			{
				return _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A;
			}
			set
			{
				_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A = value;
			}
		}

		[DefaultValue(100f)]
		public float AutoSizeRatio
		{
			get
			{
				return _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_000A_0020_0020;
			}
			set
			{
				_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_000A_0020_0020 = value;
			}
		}

		public int AutoSizeMinSize
		{
			get
			{
				return _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_000A;
			}
			set
			{
				_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_000A = value;
			}
		}

		internal int _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_0020
		{
			get
			{
				return _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020;
			}
			set
			{
				_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020 = value;
			}
		}

		public TreeListColumn(string fieldName)
		{
			_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A = fieldName;
		}

		public TreeListColumn(string fieldName, string caption)
		{
			_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A = fieldName;
			_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020 = caption;
		}

		public TreeListColumn(string fieldName, string caption, int width)
		{
			_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A = fieldName;
			_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020 = caption;
			_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_0020 = width;
		}

		public virtual void Draw(Graphics dc, ColumnHeaderPainter painter, Rectangle r)
		{
			painter.DrawHeader(dc, r, this, HeaderFormat, ishot);
		}
	}
}
