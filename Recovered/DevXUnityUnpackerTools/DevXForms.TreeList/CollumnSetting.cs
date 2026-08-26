using System.ComponentModel;

namespace DevXForms.TreeList
{
	[TypeConverter(typeof(OptionsSettingTypeConverter))]
	public class CollumnSetting
	{
		private int _0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020 = 5;

		private int _0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A = 20;

		private MultiSelectTreeView2 _0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020;

		[DefaultValue(5)]
		public int LeftMargin
		{
			get
			{
				return _0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020;
			}
			set
			{
				_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020 = value;
				_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020.Columns.RecalcVisibleColumsRect();
				_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020.Invalidate();
			}
		}

		[DefaultValue(20)]
		public int HeaderHeight
		{
			get
			{
				return _0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A;
			}
			set
			{
				_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A = value;
				_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020.Columns.RecalcVisibleColumsRect();
				_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020.Invalidate();
			}
		}

		public CollumnSetting(MultiSelectTreeView2 owner)
		{
			_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020 = owner;
		}
	}
}
