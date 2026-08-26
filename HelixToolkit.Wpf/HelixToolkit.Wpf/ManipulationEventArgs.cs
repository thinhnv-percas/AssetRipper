using System.Windows;

namespace HelixToolkit.Wpf;

public class ManipulationEventArgs
{
	public Point CurrentPosition { get; private set; }

	public ManipulationEventArgs(Point currentPosition)
	{
		CurrentPosition = currentPosition;
	}
}
