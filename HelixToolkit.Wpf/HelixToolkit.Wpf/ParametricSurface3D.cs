using System.Windows;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public abstract class ParametricSurface3D : MeshElement3D
{
	public static readonly DependencyProperty MeshSizeUProperty = DependencyProperty.Register("MeshSizeU", typeof(int), typeof(ParametricSurface3D), new UIPropertyMetadata(120, MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty MeshSizeVProperty = DependencyProperty.Register("MeshSizeV", typeof(int), typeof(ParametricSurface3D), new UIPropertyMetadata(120, MeshElement3D.GeometryChanged));

	public int MeshSizeU
	{
		get
		{
			return (int)GetValue(MeshSizeUProperty);
		}
		set
		{
			SetValue(MeshSizeUProperty, value);
		}
	}

	public int MeshSizeV
	{
		get
		{
			return (int)GetValue(MeshSizeVProperty);
		}
		set
		{
			SetValue(MeshSizeVProperty, value);
		}
	}

	protected abstract Point3D Evaluate(double u, double v, out Point textureCoord);

	protected override MeshGeometry3D Tessellate()
	{
		MeshGeometry3D meshGeometry3D = new MeshGeometry3D();
		int meshSizeU = MeshSizeU;
		int meshSizeV = MeshSizeV;
		Point3D[] array = new Point3D[meshSizeV * meshSizeU];
		Point[] array2 = new Point[meshSizeV * meshSizeU];
		for (int i = 0; i < meshSizeU; i++)
		{
			double u = 1.0 * (double)i / (double)(meshSizeU - 1);
			for (int j = 0; j < meshSizeV; j++)
			{
				double v = 1.0 * (double)j / (double)(meshSizeV - 1);
				int num = i * meshSizeV + j;
				array[num] = Evaluate(u, v, out array2[num]);
			}
		}
		int num2 = 0;
		for (int k = 0; k < meshSizeU; k++)
		{
			for (int l = 0; l < meshSizeV; l++)
			{
				meshGeometry3D.Positions.Add(array[num2]);
				meshGeometry3D.TextureCoordinates.Add(array2[num2]);
				num2++;
			}
		}
		for (int m = 0; m + 1 < meshSizeU; m++)
		{
			for (int n = 0; n + 1 < meshSizeV; n++)
			{
				int num3 = m * meshSizeV;
				int num4 = (m + 1) * meshSizeV;
				int num5 = n;
				int num6 = n + 1;
				AddTriangle(meshGeometry3D, num3 + num5, num3 + num6, num4 + num5);
				AddTriangle(meshGeometry3D, num4 + num5, num3 + num6, num4 + num6);
			}
		}
		return meshGeometry3D;
	}

	private static void AddTriangle(MeshGeometry3D mesh, int i1, int i2, int i3)
	{
		Point3D point = mesh.Positions[i1];
		if (!IsDefined(point))
		{
			return;
		}
		Point3D point2 = mesh.Positions[i2];
		if (IsDefined(point2))
		{
			Point3D point3 = mesh.Positions[i3];
			if (IsDefined(point3))
			{
				mesh.TriangleIndices.Add(i1);
				mesh.TriangleIndices.Add(i2);
				mesh.TriangleIndices.Add(i3);
			}
		}
	}

	private static bool IsDefined(Point3D point)
	{
		return !double.IsNaN(point.X) && !double.IsNaN(point.Y) && !double.IsNaN(point.Z);
	}
}
