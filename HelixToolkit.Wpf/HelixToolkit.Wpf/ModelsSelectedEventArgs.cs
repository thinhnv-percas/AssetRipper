using System;
using System.Collections.Generic;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class ModelsSelectedEventArgs : EventArgs
{
	public IList<Model3D> SelectedModels { get; private set; }

	public bool AreSortedByDistanceAscending { get; private set; }

	public ModelsSelectedEventArgs(IList<Model3D> selected, bool areSortedByDistanceAscending)
	{
		SelectedModels = selected;
		AreSortedByDistanceAscending = areSortedByDistanceAscending;
	}
}
