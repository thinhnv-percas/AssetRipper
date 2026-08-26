using DevXForms.TreeList;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace DevXForms
{
	public class ColumnHeaderPainter
	{
		internal bool _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020;

		internal SolidBrush _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020;

		public virtual void DrawHeaderFiller(Graphics dc, Rectangle r)
		{
			if (!Application.RenderWithVisualStyles)
			{
				ControlPaint.DrawButton(dc, r, ButtonState.Flat);
				return;
			}
			VisualStyleElement normal = VisualStyleElement.Header.Item.Normal;
			if (VisualStyleRenderer.IsElementDefined(normal))
			{
				new VisualStyleRenderer(normal).DrawBackground(dc, r);
			}
		}

		public virtual void DrawHeader(Graphics dc, Rectangle cellRect, TreeListColumn column, TextFormatting format, bool isHot)
		{
			if (!_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020)
			{
				try
				{
					if (!Application.RenderWithVisualStyles)
					{
						ControlPaint.DrawButton(dc, cellRect, ButtonState.Flat);
						return;
					}
				}
				catch
				{
					_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020 = true;
				}
			}
			try
			{
				if (Application.RenderWithVisualStyles)
				{
					VisualStyleElement element = VisualStyleElement.Header.Item.Normal;
					if (isHot)
					{
						element = VisualStyleElement.Header.Item.Hot;
					}
					if (VisualStyleRenderer.IsElementDefined(element))
					{
						new VisualStyleRenderer(element).DrawBackground(dc, cellRect);
						if (format.BackColor != Color.Transparent)
						{
							if (_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020 == null)
							{
								_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020 = new SolidBrush(format.BackColor);
							}
							dc.FillRectangle(_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020, cellRect);
						}
						cellRect = _0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A.AdjustRectangle(cellRect, format.Padding);
						Color foreColor = format.ForeColor;
						format.GetFormattingFlags();
						Point location = cellRect.Location;
						location.Y += 3;
						dc.DrawString(column.Caption, column.Font, Brushes.Black, location);
						return;
					}
				}
			}
			catch
			{
			}
			dc.DrawRectangle(_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_000A.GridLinePen, cellRect);
		}

		public virtual void DrawVerticalGridLines(TreeViewColumnCollection columns, Graphics dc, Rectangle r, int hScrollOffset)
		{
			TreeListColumn[] visibleColumns = columns.VisibleColumns;
			for (int i = 0; i < visibleColumns.Length; i++)
			{
				int num = visibleColumns[i].CalculatedRect.Right - hScrollOffset;
				if (num >= 0)
				{
					dc.DrawLine(_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_000A.GridLinePen, num, r.Top, num, r.Bottom);
				}
			}
		}
	}
}
