using System.Windows;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public abstract class TextItem
{
	public HorizontalAlignment HorizontalAlignment { get; set; }

	public Point3D Position { get; set; }

	public string Text { get; set; }

	public VerticalAlignment VerticalAlignment { get; set; }
}
