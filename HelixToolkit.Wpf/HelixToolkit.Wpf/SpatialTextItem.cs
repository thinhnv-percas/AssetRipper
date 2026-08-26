using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class SpatialTextItem : TextItem
{
	public Vector3D TextDirection { get; set; }

	public Vector3D UpDirection { get; set; }
}
