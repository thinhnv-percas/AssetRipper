using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DevXForms.TreeList
{
	[TypeConverter(typeof(OptionsSettingTypeConverter))]
	public class TextFormatting
	{
		private ContentAlignment _0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A = ContentAlignment.MiddleLeft;

		private Color _0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_0020 = SystemColors.ControlText;

		private Color _0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_000A = Color.Transparent;

		private Padding _0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020 = new Padding(0, 0, 0, 0);

		[DefaultValue(typeof(Padding), "0,0,0,0")]
		public Padding Padding
		{
			get
			{
				return _0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020;
			}
			set
			{
				_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020 = value;
			}
		}

		[DefaultValue(typeof(ContentAlignment), "MiddleLeft")]
		public ContentAlignment TextAlignment
		{
			get
			{
				return _0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A;
			}
			set
			{
				_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A = value;
			}
		}

		[DefaultValue(typeof(Color), "ControlText")]
		public Color ForeColor
		{
			get
			{
				return _0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_0020;
			}
			set
			{
				_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_0020 = value;
			}
		}

		[DefaultValue(typeof(Color), "Transparent")]
		public Color BackColor
		{
			get
			{
				return _0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_000A;
			}
			set
			{
				_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_000A = value;
			}
		}

		public TextFormatFlags GetFormattingFlags()
		{
			TextFormatFlags result = TextFormatFlags.Default;
			switch (TextAlignment)
			{
			case ContentAlignment.TopLeft:
				result = TextFormatFlags.Default;
				break;
			case ContentAlignment.TopCenter:
				result = TextFormatFlags.HorizontalCenter;
				break;
			case ContentAlignment.TopRight:
				result = TextFormatFlags.Right;
				break;
			case ContentAlignment.MiddleLeft:
				result = TextFormatFlags.VerticalCenter;
				break;
			case ContentAlignment.MiddleCenter:
				result = (TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
				break;
			case ContentAlignment.MiddleRight:
				result = (TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
				break;
			case ContentAlignment.BottomLeft:
				result = TextFormatFlags.Bottom;
				break;
			case ContentAlignment.BottomCenter:
				result = (TextFormatFlags.Bottom | TextFormatFlags.HorizontalCenter);
				break;
			case ContentAlignment.BottomRight:
				result = (TextFormatFlags.Bottom | TextFormatFlags.Right);
				break;
			}
			return result;
		}

		public TextFormatting()
		{
		}

		public TextFormatting(TextFormatting aCopy)
		{
			_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A = aCopy._0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A;
			_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_0020 = aCopy._0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_0020;
			_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_000A = aCopy._0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_000A;
			_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020 = aCopy._0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020;
		}
	}
}
