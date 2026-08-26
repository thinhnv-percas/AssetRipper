using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class VectorFieldVisual3D : ModelVisual3D
{
	private readonly ModelVisual3D model;

	private MeshGeometry3D body;

	private MeshGeometry3D head;

	public double Diameter { get; set; }

	public Vector3DCollection Directions { get; set; }

	public Brush Fill { get; set; }

	public double HeadLength { get; set; }

	public Point3DCollection Positions { get; set; }

	public int ThetaDiv { get; set; }

	public VectorFieldVisual3D()
	{
		Positions = new Point3DCollection();
		Directions = new Vector3DCollection();
		Fill = Brushes.Blue;
		ThetaDiv = 37;
		Diameter = 1.0;
		HeadLength = 2.0;
		model = new ModelVisual3D();
		base.Children.Add(model);
	}

	public void UpdateModel()
	{
		CreateGeometry();
		Model3DGroup model3DGroup = new Model3DGroup();
		Material material = MaterialHelper.CreateMaterial(Fill);
		double num = HeadLength * Diameter;
		for (int i = 0; i < Positions.Count; i++)
		{
			Point3D point3D = Positions[i];
			Vector3D vector3D = Directions[i];
			GeometryModel3D value = new GeometryModel3D
			{
				Geometry = head,
				Material = material,
				Transform = CreateHeadTransform(point3D + vector3D, vector3D)
			};
			model3DGroup.Children.Add(value);
			Vector3D vector3D2 = vector3D;
			vector3D2.Normalize();
			GeometryModel3D value2 = new GeometryModel3D
			{
				Geometry = body,
				Material = material,
				Transform = CreateBodyTransform(point3D, vector3D2 * (1.0 - num / vector3D.Length))
			};
			model3DGroup.Children.Add(value2);
		}
		model.Content = model3DGroup;
	}

	private static Transform3D CreateBodyTransform(Point3D p, Vector3D z)
	{
		double length = z.Length;
		z.Normalize();
		Vector3D vector = z.FindAnyPerpendicular();
		vector.Normalize();
		Vector3D vector3D = Vector3D.CrossProduct(z, vector);
		Matrix3D matrix = new Matrix3D(vector.X, vector.Y, vector.Z, 0.0, vector3D.X, vector3D.Y, vector3D.Z, 0.0, z.X * length, z.Y * length, z.Z * length, 0.0, p.X, p.Y, p.Z, 1.0);
		return new MatrixTransform3D(matrix);
	}

	private static Transform3D CreateHeadTransform(Point3D p, Vector3D z)
	{
		z.Normalize();
		Vector3D vector = z.FindAnyPerpendicular();
		vector.Normalize();
		Vector3D vector3D = Vector3D.CrossProduct(z, vector);
		Matrix3D matrix = new Matrix3D(vector.X, vector.Y, vector.Z, 0.0, vector3D.X, vector3D.Y, vector3D.Z, 0.0, z.X, z.Y, z.Z, 0.0, p.X, p.Y, p.Z, 1.0);
		return new MatrixTransform3D(matrix);
	}

	private void CreateGeometry()
	{
		double num = Diameter / 2.0;
		double num2 = HeadLength * Diameter;
		PointCollection points = new PointCollection
		{
			new Point(0.0 - num2, num),
			new Point(0.0 - num2, num * 2.0),
			new Point(0.0, 0.0)
		};
		MeshBuilder meshBuilder = new MeshBuilder(generateNormals: false, generateTexCoords: false);
		meshBuilder.AddRevolvedGeometry(points, null, new Point3D(0.0, 0.0, 0.0), new Vector3D(0.0, 0.0, 1.0), ThetaDiv);
		head = meshBuilder.ToMesh();
		head.Freeze();
		points = new PointCollection
		{
			new Point(0.0, 0.0),
			new Point(0.0, num),
			new Point(1.0, num)
		};
		MeshBuilder meshBuilder2 = new MeshBuilder(generateNormals: false, generateTexCoords: false);
		meshBuilder2.AddRevolvedGeometry(points, null, new Point3D(0.0, 0.0, 0.0), new Vector3D(0.0, 0.0, 1.0), ThetaDiv);
		body = meshBuilder2.ToMesh();
		body.Freeze();
	}
}
