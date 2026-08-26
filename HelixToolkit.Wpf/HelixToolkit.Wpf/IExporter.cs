using System.IO;
using System.Windows.Controls;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public interface IExporter
{
	void Export(Viewport3D viewport, Stream stream);

	void Export(Visual3D visual, Stream stream);

	void Export(Model3D model, Stream stream);
}
