using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ICSharpCode.TextEditor.Document;

namespace ICSharpCode.TextEditor;

public class FoldMargin : AbstractMargin
{
	private int selectedFoldLine = -1;

	public override Size Size => new Size(textArea.TextView.FontHeight, -1);

	public override bool IsVisible => textArea.TextEditorProperties.EnableFolding;

	public FoldMargin(TextArea textArea)
		: base(textArea)
	{
	}

	public override void Paint(Graphics g, Rectangle rect)
	{
		if (rect.Width <= 0 || rect.Height <= 0)
		{
			return;
		}
		HighlightColor colorFor = textArea.Document.HighlightingStrategy.GetColorFor("LineNumbers");
		textArea.Document.HighlightingStrategy.GetColorFor("FoldLine");
		for (int i = 0; i < (base.DrawingPosition.Height + textArea.TextView.VisibleLineDrawingRemainder) / textArea.TextView.FontHeight + 1; i++)
		{
			Rectangle rectangle = new Rectangle(base.DrawingPosition.X, base.DrawingPosition.Top + i * textArea.TextView.FontHeight - textArea.TextView.VisibleLineDrawingRemainder, base.DrawingPosition.Width, textArea.TextView.FontHeight);
			if (rect.IntersectsWith(rectangle))
			{
				if (textArea.Document.TextEditorProperties.ShowLineNumbers)
				{
					g.FillRectangle(BrushRegistry.GetBrush(textArea.Enabled ? colorFor.BackgroundColor : SystemColors.InactiveBorder), new Rectangle(rectangle.X + 1, rectangle.Y, rectangle.Width - 1, rectangle.Height));
					g.DrawLine(BrushRegistry.GetDotPen(colorFor.Color, colorFor.BackgroundColor), drawingPosition.X, rectangle.Y, drawingPosition.X, rectangle.Bottom);
				}
				else
				{
					g.FillRectangle(BrushRegistry.GetBrush(textArea.Enabled ? colorFor.BackgroundColor : SystemColors.InactiveBorder), rectangle);
				}
				int firstLogicalLine = textArea.Document.GetFirstLogicalLine(textArea.TextView.FirstPhysicalLine + i);
				if (firstLogicalLine < textArea.Document.TotalNumberOfLines)
				{
					PaintFoldMarker(g, firstLogicalLine, rectangle);
				}
			}
		}
	}

	private bool SelectedFoldingFrom(List<FoldMarker> list)
	{
		if (list != null)
		{
			for (int i = 0; i < list.Count; i++)
			{
				if (selectedFoldLine == list[i].StartLine)
				{
					return true;
				}
			}
		}
		return false;
	}

	private void PaintFoldMarker(Graphics g, int lineNumber, Rectangle drawingRectangle)
	{
		HighlightColor colorFor = textArea.Document.HighlightingStrategy.GetColorFor("FoldLine");
		HighlightColor colorFor2 = textArea.Document.HighlightingStrategy.GetColorFor("SelectedFoldLine");
		List<FoldMarker> foldingsWithStart = textArea.Document.FoldingManager.GetFoldingsWithStart(lineNumber);
		List<FoldMarker> foldingsContainsLineNumber = textArea.Document.FoldingManager.GetFoldingsContainsLineNumber(lineNumber);
		List<FoldMarker> foldingsWithEnd = textArea.Document.FoldingManager.GetFoldingsWithEnd(lineNumber);
		bool num = foldingsWithStart.Count > 0;
		bool flag = foldingsContainsLineNumber.Count > 0;
		bool flag2 = foldingsWithEnd.Count > 0;
		bool flag3 = SelectedFoldingFrom(foldingsWithStart);
		bool flag4 = SelectedFoldingFrom(foldingsContainsLineNumber);
		bool flag5 = SelectedFoldingFrom(foldingsWithEnd);
		int num2 = (int)Math.Round((float)textArea.TextView.FontHeight * 0.57f);
		num2 -= num2 % 2;
		int num3 = drawingRectangle.Y + (drawingRectangle.Height - num2) / 2;
		int num4 = drawingRectangle.X + (drawingRectangle.Width - num2) / 2 + num2 / 2;
		if (num)
		{
			bool flag6 = true;
			bool flag7 = false;
			foreach (FoldMarker item in foldingsWithStart)
			{
				if (item.IsFolded)
				{
					flag6 = false;
				}
				else
				{
					flag7 = item.EndLine > item.StartLine;
				}
			}
			bool flag8 = false;
			foreach (FoldMarker item2 in foldingsWithEnd)
			{
				if (item2.EndLine > item2.StartLine && !item2.IsFolded)
				{
					flag8 = true;
				}
			}
			DrawFoldMarker(g, new RectangleF(drawingRectangle.X + (drawingRectangle.Width - num2) / 2, num3, num2, num2), flag6, flag3);
			if (flag | flag8)
			{
				g.DrawLine(BrushRegistry.GetPen(flag4 ? colorFor2.Color : colorFor.Color), num4, drawingRectangle.Top, num4, num3 - 1);
			}
			if (flag | flag7)
			{
				g.DrawLine(BrushRegistry.GetPen(((flag5 || (flag3 & flag6)) | flag4) ? colorFor2.Color : colorFor.Color), num4, num3 + num2 + 1, num4, drawingRectangle.Bottom);
			}
		}
		else if (flag2)
		{
			int num5 = drawingRectangle.Top + drawingRectangle.Height / 2;
			g.DrawLine(BrushRegistry.GetPen(flag5 ? colorFor2.Color : colorFor.Color), num4, num5, num4 + num2 / 2, num5);
			g.DrawLine(BrushRegistry.GetPen((flag4 | flag5) ? colorFor2.Color : colorFor.Color), num4, drawingRectangle.Top, num4, num5);
			if (flag)
			{
				g.DrawLine(BrushRegistry.GetPen(flag4 ? colorFor2.Color : colorFor.Color), num4, num5 + 1, num4, drawingRectangle.Bottom);
			}
		}
		else if (flag)
		{
			g.DrawLine(BrushRegistry.GetPen(flag4 ? colorFor2.Color : colorFor.Color), num4, drawingRectangle.Top, num4, drawingRectangle.Bottom);
		}
	}

	public override void HandleMouseMove(Point mousepos, MouseButtons mouseButtons)
	{
		bool enableFolding = textArea.Document.TextEditorProperties.EnableFolding;
		int lineNumber = (mousepos.Y + textArea.VirtualTop.Y) / textArea.TextView.FontHeight;
		int firstLogicalLine = textArea.Document.GetFirstLogicalLine(lineNumber);
		if (enableFolding && firstLogicalLine >= 0 && firstLogicalLine + 1 < textArea.Document.TotalNumberOfLines)
		{
			List<FoldMarker> foldingsWithStart = textArea.Document.FoldingManager.GetFoldingsWithStart(firstLogicalLine);
			int num = selectedFoldLine;
			if (foldingsWithStart.Count > 0)
			{
				selectedFoldLine = firstLogicalLine;
			}
			else
			{
				selectedFoldLine = -1;
			}
			if (num != selectedFoldLine)
			{
				textArea.Refresh(this);
			}
		}
	}

	public override void HandleMouseDown(Point mousepos, MouseButtons mouseButtons)
	{
		bool enableFolding = textArea.Document.TextEditorProperties.EnableFolding;
		int lineNumber = (mousepos.Y + textArea.VirtualTop.Y) / textArea.TextView.FontHeight;
		int firstLogicalLine = textArea.Document.GetFirstLogicalLine(lineNumber);
		textArea.Focus();
		if (!enableFolding || firstLogicalLine < 0 || firstLogicalLine + 1 >= textArea.Document.TotalNumberOfLines)
		{
			return;
		}
		foreach (FoldMarker item in textArea.Document.FoldingManager.GetFoldingsWithStart(firstLogicalLine))
		{
			item.IsFolded = !item.IsFolded;
		}
		textArea.Document.FoldingManager.NotifyFoldingsChanged(EventArgs.Empty);
	}

	public override void HandleMouseLeave(EventArgs e)
	{
		if (selectedFoldLine != -1)
		{
			selectedFoldLine = -1;
			textArea.Refresh(this);
		}
	}

	private void DrawFoldMarker(Graphics g, RectangleF rectangle, bool isOpened, bool isSelected)
	{
		HighlightColor colorFor = textArea.Document.HighlightingStrategy.GetColorFor("FoldMarker");
		HighlightColor colorFor2 = textArea.Document.HighlightingStrategy.GetColorFor("FoldLine");
		HighlightColor colorFor3 = textArea.Document.HighlightingStrategy.GetColorFor("SelectedFoldLine");
		Rectangle rect = new Rectangle((int)rectangle.X, (int)rectangle.Y, (int)rectangle.Width, (int)rectangle.Height);
		g.FillRectangle(BrushRegistry.GetBrush(colorFor.BackgroundColor), rect);
		g.DrawRectangle(BrushRegistry.GetPen(isSelected ? colorFor3.Color : colorFor.Color), rect);
		int num = (int)Math.Round((double)rectangle.Height / 8.0) + 1;
		int num2 = rect.Height / 2 + rect.Height % 2;
		g.DrawLine(BrushRegistry.GetPen(colorFor2.BackgroundColor), rectangle.X + (float)num, rectangle.Y + (float)num2, rectangle.X + rectangle.Width - (float)num, rectangle.Y + (float)num2);
		if (!isOpened)
		{
			g.DrawLine(BrushRegistry.GetPen(colorFor2.BackgroundColor), rectangle.X + (float)num2, rectangle.Y + (float)num, rectangle.X + (float)num2, rectangle.Y + rectangle.Height - (float)num);
		}
	}
}
