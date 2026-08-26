using System.IO;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public interface IModelReader
{
	Model3DGroup Read(string path);

	Model3DGroup Read(Stream s);
}
