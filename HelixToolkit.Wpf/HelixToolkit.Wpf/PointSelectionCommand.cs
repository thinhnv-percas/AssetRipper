using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class PointSelectionCommand : SelectionCommand
{
	private Point position;

	public PointSelectionCommand(Viewport3D viewport, EventHandler<ModelsSelectedEventArgs> eventHandler)
		: base(viewport, eventHandler)
	{
	}

	protected override void Started(ManipulationEventArgs e)
	{
		base.Started(e);
		position = e.CurrentPosition;
		List<Model3D> selectedModels = (from hit in Viewport.FindHits(position)
			select hit.Model).ToList();
		OnModelsSelected(new ModelsSelectedByPointEventArgs(selectedModels, position));
	}

	protected override void Completed(ManipulationEventArgs e)
	{
	}

	protected override Cursor GetCursor()
	{
		return Cursors.Arrow;
	}
}
