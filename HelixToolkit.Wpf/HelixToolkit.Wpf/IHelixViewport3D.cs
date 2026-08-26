using System.Windows.Controls;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public interface IHelixViewport3D
{
	ProjectionCamera Camera { get; }

	CameraController CameraController { get; }

	Model3DGroup Lights { get; }

	Viewport3D Viewport { get; }

	void Copy();

	void CopyXaml();

	void Export(string fileName);

	void ZoomExtents(double animationTime);
}
