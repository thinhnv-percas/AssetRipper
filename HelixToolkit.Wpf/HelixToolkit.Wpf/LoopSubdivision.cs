using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class LoopSubdivision
{
	private IList<Vector3D> vertices;

	private IList<int> triangleIndices;

	private IList<Vector3D> newVertices;

	private IList<int> newTriangleIndices;

	private Dictionary<int, int[]>[] edgeVertice;

	public SubdivisionScheme Scheme { get; set; }

	public IList<Point3D> Positions => new List<Point3D>(vertices.Select((Vector3D v) => v.ToPoint3D()));

	public LoopSubdivision(IList<Point3D> vertices, IList<int> triangleIndices)
	{
		Scheme = SubdivisionScheme.Loop;
		this.vertices = new List<Vector3D>(vertices.Select((Point3D v) => v.ToVector3D()));
		this.triangleIndices = triangleIndices;
	}

	public LoopSubdivision(MeshGeometry3D meshGeometry)
		: this(meshGeometry.Positions, meshGeometry.TriangleIndices)
	{
	}

	public MeshGeometry3D ToMeshGeometry3D()
	{
		return new MeshGeometry3D
		{
			Positions = new Point3DCollection(Positions),
			TriangleIndices = new Int32Collection(triangleIndices)
		};
	}

	public Mesh3D ToMesh3D()
	{
		return new Mesh3D(Positions, triangleIndices);
	}

	public void Add(int v0, int v1, int v2)
	{
		newTriangleIndices.Add(v0);
		newTriangleIndices.Add(v1);
		newTriangleIndices.Add(v2);
	}

	private int GetEdgeVertice(int v0, int v1, int i)
	{
		if (edgeVertice[v0].ContainsKey(v1))
		{
			return edgeVertice[v0][v1][i];
		}
		return 0;
	}

	private void SetEdgeVertice(int v0, int v1, int i, int value)
	{
		if (!edgeVertice[v0].ContainsKey(v1))
		{
			edgeVertice[v0][v1] = new int[3];
		}
		edgeVertice[v0][v1][i] = value;
	}

	private Vector3D Sum(IEnumerable<int> indices)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		foreach (int index in indices)
		{
			num += vertices[index].X;
			num2 += vertices[index].Y;
			num3 += vertices[index].Z;
		}
		return new Vector3D(num, num2, num3);
	}

	public double Sqr(double d)
	{
		return d * d;
	}

	public void Subdivide(int n)
	{
		for (int i = 0; i < n; i++)
		{
			Subdivide();
		}
	}

	public void Subdivide()
	{
		newVertices = new List<Vector3D>(vertices);
		newTriangleIndices = new List<int>();
		int count = vertices.Count;
		int num = triangleIndices.Count / 3;
		edgeVertice = new Dictionary<int, int[]>[count];
		for (int i = 0; i < count; i++)
		{
			edgeVertice[i] = new Dictionary<int, int[]>();
		}
		for (int j = 0; j < num; j++)
		{
			int num2 = triangleIndices[j * 3];
			int num3 = triangleIndices[j * 3 + 1];
			int num4 = triangleIndices[j * 3 + 2];
			int num5 = AddEdgeVertice(num2, num3, num4);
			int num6 = AddEdgeVertice(num3, num4, num2);
			int num7 = AddEdgeVertice(num2, num4, num3);
			Add(num2, num5, num7);
			Add(num5, num3, num6);
			Add(num7, num6, num4);
			Add(num7, num5, num6);
		}
		for (int k = 0; k < count - 1; k++)
		{
			for (int l = k; l < count; l++)
			{
				int num8 = GetEdgeVertice(k, l, 0);
				if (num8 != 0)
				{
					int index = GetEdgeVertice(k, l, 1);
					int num9 = GetEdgeVertice(k, l, 2);
					if (num9 == 0)
					{
						newVertices[num8] = 0.5 * (vertices[k] + vertices[l]);
					}
					else
					{
						newVertices[num8] = 0.375 * (vertices[k] + vertices[l]) + 0.125 * (vertices[index] + vertices[num9]);
					}
				}
			}
		}
		List<int>[] array = new List<int>[count];
		for (int m = 0; m < count; m++)
		{
			array[m] = new List<int>();
			for (int n = 0; n < count; n++)
			{
				if ((m < n && GetEdgeVertice(m, n, 0) != 0) || (m > n && GetEdgeVertice(n, m, 0) != 0))
				{
					array[m].Add(n);
				}
			}
		}
		for (int num10 = 0; num10 < count; num10++)
		{
			int count2 = array[num10].Count;
			List<int> list = new List<int>();
			for (int num11 = 0; num11 < count2; num11++)
			{
				int num12 = array[num10][num11];
				if ((num12 > num10 && GetEdgeVertice(num10, num12, 2) == 0) || (num12 < num10 && GetEdgeVertice(num12, num10, 2) == 0))
				{
					list.Add(num12);
				}
			}
			if (list.Count == 2)
			{
				newVertices[num10] = 0.75 * vertices[num10] + 0.125 * Sum(list);
				continue;
			}
			SubdivisionScheme scheme = Scheme;
			double num13 = ((scheme != SubdivisionScheme.Warren) ? (1.0 / (double)count2 * (0.625 - Sqr(0.375 + 0.0 * Math.Cos(Math.PI * 2.0 / (double)count2)))) : ((count2 > 3) ? (0.375 / (double)count2) : 0.1875));
			newVertices[num10] = (1.0 - (double)count2 * num13) * vertices[num10] + num13 * Sum(array[num10]);
		}
		vertices = newVertices;
		triangleIndices = newTriangleIndices;
	}

	private int AddEdgeVertice(int v1Index, int v2Index, int v3Index)
	{
		if (v1Index > v2Index)
		{
			int num = v1Index;
			v1Index = v2Index;
			v2Index = num;
		}
		if (GetEdgeVertice(v1Index, v2Index, 0) == 0)
		{
			SetEdgeVertice(v1Index, v2Index, 0, newVertices.Count);
			SetEdgeVertice(v1Index, v2Index, 1, v3Index);
			newVertices.Add(default(Vector3D));
		}
		else
		{
			SetEdgeVertice(v1Index, v2Index, 2, v3Index);
		}
		return GetEdgeVertice(v1Index, v2Index, 0);
	}
}
