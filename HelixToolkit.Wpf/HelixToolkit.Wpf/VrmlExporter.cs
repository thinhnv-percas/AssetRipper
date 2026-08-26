using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class VrmlExporter : Exporter<StreamWriter>
{
	public string Title { get; set; }

	protected override StreamWriter Create(Stream stream)
	{
		StreamWriter streamWriter = new StreamWriter(stream, Encoding.UTF8);
		streamWriter.WriteLine("# VRML V2.0 utf8");
		if (Title != null)
		{
			streamWriter.WriteLine("# " + Title);
		}
		return streamWriter;
	}

	protected override void Close(StreamWriter writer)
	{
		writer.Close();
	}

	protected override void ExportModel(StreamWriter writer, GeometryModel3D model, Transform3D inheritedTransform)
	{
		if (!(model.Geometry is MeshGeometry3D meshGeometry3D))
		{
			return;
		}
		writer.WriteLine("Shape {");
		writer.WriteLine("  appearance Appearance {");
		writer.WriteLine("    material Material {");
		writer.WriteLine("      diffuseColor 0.8 0.8 0.2");
		writer.WriteLine("      specularColor 0.5 0.5 0.5");
		writer.WriteLine("    }");
		writer.WriteLine("  }");
		writer.WriteLine("  geometry IndexedFaceSet {");
		writer.WriteLine("    coord Coordinate {");
		writer.WriteLine("      point [");
		foreach (Point3D position in meshGeometry3D.Positions)
		{
			writer.WriteLine(string.Format(CultureInfo.InvariantCulture, "{0} {1} {2},", new object[3] { position.X, position.Y, position.Z }));
		}
		writer.WriteLine("      ]");
		writer.WriteLine("    }");
		writer.WriteLine("    coordIndex [");
		for (int i = 0; i < meshGeometry3D.TriangleIndices.Count; i += 3)
		{
			writer.WriteLine(string.Format(CultureInfo.InvariantCulture, "{0} {1} {2},", new object[3]
			{
				meshGeometry3D.TriangleIndices[i],
				meshGeometry3D.TriangleIndices[i + 1],
				meshGeometry3D.TriangleIndices[i + 2]
			}));
		}
		writer.WriteLine("    ]");
		writer.WriteLine("  }");
		writer.WriteLine("}");
	}
}
