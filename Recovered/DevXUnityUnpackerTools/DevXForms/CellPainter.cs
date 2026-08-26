using DevXForms.TreeList;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace DevXForms
{
	public class CellPainter
	{
		private SolidBrush _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A;

		private SolidBrush _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020;

		protected MultiSelectTreeView2 m_owner;

		private SolidBrush _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020;

		public CellPainter(MultiSelectTreeView2 owner)
		{
			m_owner = owner;
		}

		public virtual void DrawSelectionBackground(Graphics dc, Rectangle nodeRect, TreeNode node)
		{
			if (m_owner.NodesSelection.Contains(node) || m_owner.FocusedNode == node)
			{
				VisualStyleItemBackground.Style style = VisualStyleItemBackground.Style.Normal;
				if (!m_owner.Focused)
				{
					style = VisualStyleItemBackground.Style.Inactive;
				}
				new VisualStyleItemBackground(style).DrawBackground(m_owner, dc, nodeRect);
			}
		}

		public virtual void PaintCell(Graphics dc, Rectangle cellRect, TreeNode node, TreeListColumn column, TextFormatting format, object data)
		{
			if (format.BackColor != Color.Transparent)
			{
				Rectangle rect = cellRect;
				rect.X = column.CalculatedRect.X;
				rect.Width = column.CalculatedRect.Width;
				if (_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020 == null)
				{
					_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020 = new SolidBrush(format.BackColor);
				}
				dc.FillRectangle(_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020, rect);
			}
			if (data != null)
			{
				cellRect = _0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A.AdjustRectangle(cellRect, format.Padding);
				Color foreColor = format.ForeColor;
				if (m_owner.FocusedNode == node && !Application.RenderWithVisualStyles)
				{
					Color highlightText = SystemColors.HighlightText;
				}
				format.GetFormattingFlags();
				Point location = cellRect.Location;
				location.Y += 3;
				dc.DrawString(data.ToString(), m_owner.Font, Brushes.Black, location);
			}
		}

		public virtual void PaintCellPlusMinus(Graphics dc, Rectangle glyphRect, TreeNode node)
		{
			if (Application.RenderWithVisualStyles)
			{
				VisualStyleElement element = VisualStyleElement.TreeView.Glyph.Closed;
				if (node.Expanded)
				{
					element = VisualStyleElement.TreeView.Glyph.Opened;
				}
				if (VisualStyleRenderer.IsElementDefined(element))
				{
					new VisualStyleRenderer(element).DrawBackground(dc, glyphRect);
				}
			}
		}
	}
}
