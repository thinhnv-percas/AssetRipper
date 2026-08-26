using System.IO;
using System.Text;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class RenderManExporter : Exporter<StreamWriter>
{
	protected override StreamWriter Create(Stream stream)
	{
		return new StreamWriter(stream, Encoding.UTF8);
	}

	protected override void Close(StreamWriter writer)
	{
		writer.Close();
	}

	protected override void ExportCamera(StreamWriter writer, Camera camera)
	{
		base.ExportCamera(writer, camera);
	}

	protected override void ExportLight(StreamWriter writer, Light light, Transform3D inheritedTransform)
	{
		base.ExportLight(writer, light, inheritedTransform);
	}

	protected override void ExportModel(StreamWriter writer, GeometryModel3D model, Transform3D inheritedTransform)
	{
		MeshGeometry3D meshGeometry3D = model.Geometry as MeshGeometry3D;
		if (meshGeometry3D != null)
		{
		}
	}
}
