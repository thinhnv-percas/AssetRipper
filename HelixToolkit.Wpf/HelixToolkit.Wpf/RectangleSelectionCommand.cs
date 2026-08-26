using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class RectangleSelectionCommand : SelectionCommand
{
	private Rect selectionRect;

	private RectangleAdorner rectangleAdorner;

	public RectangleSelectionCommand(Viewport3D viewport, EventHandler<ModelsSelectedEventArgs> eventHandler)
		: base(viewport, eventHandler)
	{
	}

	protected override void Started(ManipulationEventArgs e)
	{
		base.Started(e);
		selectionRect = new Rect(base.MouseDownPoint, base.MouseDownPoint);
		ShowRectangle();
	}

	protected override void Delta(ManipulationEventArgs e)
	{
		base.Delta(e);
		selectionRect = new Rect(base.MouseDownPoint, e.CurrentPosition);
		UpdateRectangle();
	}

	protected override void Completed(ManipulationEventArgs e)
	{
		HideRectangle();
		List<Model3D> list = (from hit in Viewport.FindHits(selectionRect, base.SelectionHitMode)
			select hit.Model).ToList();
		if (!selectionRect.Size.Equals(default(Size)) || !list.Any())
		{
			OnModelsSelected(new ModelsSelectedByRectangleEventArgs(list, selectionRect));
		}
	}

	protected override Cursor GetCursor()
	{
		return Cursors.Arrow;
	}

	private void HideRectangle()
	{
		AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(Viewport);
		if (rectangleAdorner != null)
		{
			adornerLayer.Remove(rectangleAdorner);
		}
		rectangleAdorner = null;
		Viewport.InvalidateVisual();
	}

	private void UpdateRectangle()
	{
		if (rectangleAdorner != null)
		{
			rectangleAdorner.Rectangle = selectionRect;
			rectangleAdorner.InvalidateVisual();
		}
	}

	private void ShowRectangle()
	{
		if (rectangleAdorner == null)
		{
			AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(Viewport);
			rectangleAdorner = new RectangleAdorner(Viewport, selectionRect, Colors.LightGray, Colors.Black, 1.0, 1.0, 0.0, DashStyles.Dash);
			adornerLayer.Add(rectangleAdorner);
		}
	}
}
