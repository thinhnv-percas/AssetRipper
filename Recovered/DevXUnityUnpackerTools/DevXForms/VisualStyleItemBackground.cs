using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DevXForms
{
	public class VisualStyleItemBackground
	{
		public enum Style
		{
			Normal,
			Inactive
		}

		private Style _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020;

		private Pen _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A;

		public VisualStyleItemBackground(Style style)
		{
			_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020 = style;
		}

		public void DrawBackground(Control owner, Graphics dc, Rectangle r)
		{
			Color color = Color.FromArgb(130, 170, 250);
			if (_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020 == Style.Inactive)
			{
				color = Color.FromArgb(150, 200, 250);
			}
			if (_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A == null)
			{
				_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A = new Pen(color);
			}
			using (GraphicsPath graphicsPath = new GraphicsPath())
			{
				graphicsPath.AddLine(r.Left + 2, r.Top, r.Right - 2, r.Top);
				graphicsPath.AddLine(r.Right, r.Top + 2, r.Right, r.Bottom - 2);
				graphicsPath.AddLine(r.Right - 2, r.Bottom, r.Left + 2, r.Bottom);
				graphicsPath.AddLine(r.Left, r.Bottom - 2, r.Left, r.Top + 2);
				graphicsPath.CloseFigure();
				dc.DrawPath(_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A, graphicsPath);
				r.Inflate(-1, -1);
				using (LinearGradientBrush brush = new LinearGradientBrush(r, Color.White, Color.FromArgb(90, color), 90f))
				{
					dc.FillRectangle(brush, r);
					dc.DrawLine(Pens.White, r.Left + 1, r.Top, r.Right - 1, r.Top);
				}
			}
		}
	}
}
