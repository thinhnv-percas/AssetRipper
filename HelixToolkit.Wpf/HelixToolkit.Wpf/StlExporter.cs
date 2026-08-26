using System.IO;
using System.Windows.Controls;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class StlExporter : Exporter<BinaryWriter>
{
	protected override BinaryWriter Create(Stream stream)
	{
		return new BinaryWriter(stream);
	}

	protected override void Close(BinaryWriter writer)
	{
	}

	public override void Export(Viewport3D viewport, Stream stream)
	{
		BinaryWriter writer = Create(stream);
		int triangleIndicesCount = 0;
		viewport.Children.Traverse(delegate(GeometryModel3D m, Transform3D t)
		{
			triangleIndicesCount += ((MeshGeometry3D)m.Geometry).TriangleIndices.Count;
		});
		ExportHeader(writer, triangleIndicesCount / 3);
		viewport.Children.Traverse(delegate(GeometryModel3D m, Transform3D t)
		{
			ExportModel(writer, m, t);
		});
		Close(writer);
	}

	public override void Export(Visual3D visual, Stream stream)
	{
		BinaryWriter writer = Create(stream);
		int triangleIndicesCount = 0;
		visual.Traverse(delegate(GeometryModel3D m, Transform3D t)
		{
			triangleIndicesCount += ((MeshGeometry3D)m.Geometry).TriangleIndices.Count;
		});
		ExportHeader(writer, triangleIndicesCount / 3);
		visual.Traverse(delegate(GeometryModel3D m, Transform3D t)
		{
			ExportModel(writer, m, t);
		});
		Close(writer);
	}

	public override void Export(Model3D model, Stream stream)
	{
		BinaryWriter writer = Create(stream);
		int triangleIndicesCount = 0;
		model.Traverse(delegate(GeometryModel3D m, Transform3D t)
		{
			triangleIndicesCount += ((MeshGeometry3D)m.Geometry).TriangleIndices.Count;
		});
		ExportHeader(writer, triangleIndicesCount / 3);
		model.Traverse(delegate(GeometryModel3D m, Transform3D t)
		{
			ExportModel(writer, m, t);
		});
		Close(writer);
	}

	private void ExportHeader(BinaryWriter writer, int triangleCount)
	{
		ExportHeader(writer);
		writer.Write(triangleCount);
	}

	protected override void ExportHeader(BinaryWriter writer)
	{
		writer.Write(new byte[80]);
	}

	protected override void ExportModel(BinaryWriter writer, GeometryModel3D model, Transform3D t)
	{
		MeshGeometry3D meshGeometry3D = (MeshGeometry3D)model.Geometry;
		Vector3DCollection vector3DCollection = meshGeometry3D.Normals;
		if (vector3DCollection == null || vector3DCollection.Count != meshGeometry3D.Positions.Count)
		{
			vector3DCollection = meshGeometry3D.CalculateNormals();
		}
		Matrix3D value = t.Clone().Value;
		value.OffsetX = 0.0;
		value.OffsetY = 0.0;
		value.OffsetZ = 0.0;
		MatrixTransform3D matrixTransform3D = new MatrixTransform3D(value);
		for (int i = 0; i < meshGeometry3D.TriangleIndices.Count; i += 3)
		{
			int index = meshGeometry3D.TriangleIndices[i];
			int index2 = meshGeometry3D.TriangleIndices[i + 1];
			int index3 = meshGeometry3D.TriangleIndices[i + 2];
			Vector3D normal = matrixTransform3D.Transform(vector3DCollection[index] + vector3DCollection[index2] + vector3DCollection[index3]);
			normal.Normalize();
			WriteVector(writer, normal);
			WriteVertex(writer, t.Transform(meshGeometry3D.Positions[index]));
			WriteVertex(writer, t.Transform(meshGeometry3D.Positions[index2]));
			WriteVertex(writer, t.Transform(meshGeometry3D.Positions[index3]));
			writer.Write((ushort)0);
		}
	}

	private static void WriteVector(BinaryWriter writer, Vector3D normal)
	{
		writer.Write((float)normal.X);
		writer.Write((float)normal.Y);
		writer.Write((float)normal.Z);
	}

	private static void WriteVertex(BinaryWriter writer, Point3D p)
	{
		writer.Write((float)p.X);
		writer.Write((float)p.Y);
		writer.Write((float)p.Z);
	}
}
