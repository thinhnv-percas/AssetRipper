using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class ModelsSelectedByPointEventArgs : ModelsSelectedEventArgs
{
	public Point Position { get; private set; }

	public ModelsSelectedByPointEventArgs(IList<Model3D> selectedModels, Point position)
		: base(selectedModels, areSortedByDistanceAscending: true)
	{
		Position = position;
	}
}
