using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace DevXForms
{
	public class RowPainter
	{
		private bool _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020;

		private bool _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A;

		public void DrawHeader(Graphics dc, Rectangle r, bool isHot)
		{
			if (!_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020)
			{
				try
				{
					if (!Application.RenderWithVisualStyles)
					{
						ControlPaint.DrawButton(dc, r, ButtonState.Flat);
						return;
					}
				}
				catch (Exception _0020)
				{
					ConsoleManager.WriteEx45(_0020);
					_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020 = true;
				}
			}
			if (Application.RenderWithVisualStyles && _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A)
			{
				try
				{
					VisualStyleElement element = VisualStyleElement.Header.Item.Normal;
					if (isHot)
					{
						element = VisualStyleElement.Header.Item.Hot;
					}
					if (VisualStyleRenderer.IsElementDefined(element))
					{
						new VisualStyleRenderer(element).DrawBackground(dc, r);
						return;
					}
				}
				catch
				{
					_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A = true;
				}
			}
			dc.DrawRectangle(_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_000A.GridLinePen, r);
		}

		public void DrawHorizontalGridLine(Graphics dc, Rectangle r)
		{
			dc.DrawLine(_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_000A.GridLinePen, r.Left, r.Bottom, r.Right, r.Bottom);
		}
	}
}
