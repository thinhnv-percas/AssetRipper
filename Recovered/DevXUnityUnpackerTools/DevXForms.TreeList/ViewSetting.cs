using System.ComponentModel;
using System.Windows.Forms;

namespace DevXForms.TreeList
{
	public class ViewSetting
	{
		internal MultiSelectTreeView2 _0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020;

		internal BorderStyle _0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020;

		internal int _0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A = 16;

		internal bool _0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_0020 = true;

		internal bool _0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_000A_000A = true;

		internal bool _0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020 = true;

		[DefaultValue(typeof(int), "16")]
		[Category("Behavior")]
		public int Indent
		{
			get
			{
				return _0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A;
			}
			set
			{
				_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A = value;
				_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020.Invalidate();
			}
		}

		[Category("Behavior")]
		[DefaultValue(typeof(bool), "True")]
		public bool ShowLine
		{
			get
			{
				return _0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_0020;
			}
			set
			{
				_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_0020 = value;
				_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020.Invalidate();
			}
		}

		[DefaultValue(typeof(bool), "True")]
		[Category("Behavior")]
		public bool ShowPlusMinus
		{
			get
			{
				return _0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_000A_000A;
			}
			set
			{
				_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_000A_000A = value;
				_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020.Invalidate();
			}
		}

		[DefaultValue(typeof(bool), "True")]
		[Category("Behavior")]
		public bool ShowGridLines
		{
			get
			{
				return _0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020;
			}
			set
			{
				_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020 = value;
				_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020.Invalidate();
			}
		}

		[DefaultValue(typeof(BorderStyle), "None")]
		[Category("Appearance")]
		public BorderStyle BorderStyle
		{
			get
			{
				return _0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020;
			}
			set
			{
				if (_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020 != value)
				{
					_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020 = value;
					_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020._0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_000A_0020_000A();
					_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020.Invalidate();
				}
			}
		}

		public ViewSetting(MultiSelectTreeView2 owner)
		{
			_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020 = owner;
		}
	}
}
