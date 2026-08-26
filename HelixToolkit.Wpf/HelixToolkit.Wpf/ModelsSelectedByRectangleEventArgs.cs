using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class ModelsSelectedByRectangleEventArgs : ModelsSelectedEventArgs
{
	public Rect Rectangle { get; private set; }

	public ModelsSelectedByRectangleEventArgs(IList<Model3D> selectedModels, Rect rectangle)
		: base(selectedModels, areSortedByDistanceAscending: false)
	{
		Rectangle = rectangle;
	}
}
