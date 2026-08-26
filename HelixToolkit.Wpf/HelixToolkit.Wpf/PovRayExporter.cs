using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class PovRayExporter : Exporter<StreamWriter>
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
		if (!(model.Geometry is MeshGeometry3D meshGeometry3D))
		{
			return;
		}
		writer.WriteLine("mesh2 {");
		writer.WriteLine("  vertex_vectors");
		writer.WriteLine("  {");
		writer.WriteLine("    " + meshGeometry3D.Positions.Count + ",");
		foreach (Point3D position in meshGeometry3D.Positions)
		{
			writer.WriteLine(string.Format(CultureInfo.InvariantCulture, "    {0} {1} {2},", new object[3] { position.X, position.Y, position.Z }));
		}
		writer.WriteLine("  }");
		writer.WriteLine("  face_indices");
		writer.WriteLine("  {");
		writer.WriteLine("    " + meshGeometry3D.TriangleIndices.Count / 3 + ",");
		for (int i = 0; i < meshGeometry3D.TriangleIndices.Count; i += 3)
		{
			writer.WriteLine(string.Format(CultureInfo.InvariantCulture, "    {0} {1} {2},", new object[3]
			{
				meshGeometry3D.TriangleIndices[i],
				meshGeometry3D.TriangleIndices[i + 1],
				meshGeometry3D.TriangleIndices[i + 2]
			}));
		}
		writer.WriteLine("  }");
		writer.WriteLine("}");
	}
}
