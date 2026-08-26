#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class MeshSimplification
{
	private struct SymmetricMatrix
	{
		private const int Size = 10;

		public double M11;

		public double M12;

		public double M13;

		public double M14;

		public double M22;

		public double M23;

		public double M24;

		public double M33;

		public double M34;

		public double M44;

		public double this[int c] => c switch
		{
			0 => M11, 
			1 => M12, 
			2 => M13, 
			3 => M14, 
			4 => M22, 
			5 => M23, 
			6 => M24, 
			7 => M33, 
			8 => M34, 
			9 => M44, 
			_ => throw new ArgumentOutOfRangeException(), 
		};

		public SymmetricMatrix(double c = 0.0)
		{
			M11 = (M12 = (M13 = (M14 = (M22 = (M23 = (M24 = (M33 = (M34 = (M44 = c)))))))));
		}

		public SymmetricMatrix(double a, double b, double c, double d)
		{
			M11 = a * a;
			M12 = a * b;
			M13 = a * c;
			M14 = a * d;
			M22 = b * b;
			M23 = b * c;
			M24 = b * d;
			M33 = c * c;
			M34 = c * d;
			M44 = d * d;
		}

		public SymmetricMatrix(double m11, double m12, double m13, double m14, double m22, double m23, double m24, double m33, double m34, double m44)
		{
			M11 = m11;
			M12 = m12;
			M13 = m13;
			M14 = m14;
			M22 = m22;
			M23 = m23;
			M24 = m24;
			M33 = m33;
			M34 = m34;
			M44 = m44;
		}

		public double det(int a11, int a12, int a13, int a21, int a22, int a23, int a31, int a32, int a33)
		{
			return this[a11] * this[a22] * this[a33] + this[a13] * this[a21] * this[a32] + this[a12] * this[a23] * this[a31] - this[a13] * this[a22] * this[a31] - this[a11] * this[a23] * this[a32] - this[a12] * this[a21] * this[a33];
		}

		public static SymmetricMatrix operator +(SymmetricMatrix n1, SymmetricMatrix n2)
		{
			return new SymmetricMatrix(n1[0] + n2[0], n1[1] + n2[1], n1[2] + n2[2], n1[3] + n2[3], n1[4] + n2[4], n1[5] + n2[5], n1[6] + n2[6], n1[7] + n2[7], n1[8] + n2[8], n1[9] + n2[9]);
		}

		public void SetAll(double c)
		{
			M11 = (M12 = (M13 = (M14 = (M22 = (M23 = (M24 = (M33 = (M34 = (M44 = c)))))))));
		}
	}

	private sealed class Triangle
	{
		public readonly int[] v = new int[3];

		public readonly double[] err = new double[4];

		public bool deleted = false;

		public bool dirty = false;

		public Vector3D normal = default(Vector3D);

		public Triangle Clone()
		{
			Triangle triangle = new Triangle
			{
				deleted = deleted,
				dirty = dirty,
				normal = normal
			};
			triangle.v[0] = v[0];
			triangle.v[1] = v[1];
			triangle.v[2] = v[2];
			triangle.err[0] = err[0];
			triangle.err[1] = err[1];
			triangle.err[2] = err[2];
			triangle.err[3] = err[3];
			return triangle;
		}
	}

	private sealed class Vertex
	{
		public Vector3D p;

		public int tStart = 0;

		public int tCount = 0;

		public SymmetricMatrix q = default(SymmetricMatrix);

		public bool border = false;

		public Vertex()
		{
			p = default(Vector3D);
		}

		public Vertex(Point3D v)
		{
			p = new Vector3D(v.X, v.Y, v.Z);
		}

		public Vertex(ref Vector3D v)
		{
			p = v;
		}

		public Vertex Clone()
		{
			return new Vertex
			{
				p = p,
				border = border,
				q = q,
				tCount = tCount,
				tStart = tStart
			};
		}
	}

	private struct Ref
	{
		public int tid;

		public int tvertex;

		public Ref(int id = 0, int tvert = 0)
		{
			tid = id;
			tvertex = tvert;
		}

		public void Reset()
		{
			tid = 0;
			tvertex = 0;
		}
	}

	private readonly List<Triangle> triangles;

	private readonly List<Vertex> vertices;

	private readonly List<Ref> refs;

	public MeshSimplification(MeshGeometry3D model)
	{
		triangles = new List<Triangle>(from x in Enumerable.Range(0, model.TriangleIndices.Count / 3)
			select new Triangle());
		int num = 0;
		foreach (Triangle triangle in triangles)
		{
			triangle.v[0] = model.TriangleIndices[num++];
			triangle.v[1] = model.TriangleIndices[num++];
			triangle.v[2] = model.TriangleIndices[num++];
		}
		vertices = model.Positions.Select((Point3D x) => new Vertex(x)).ToList();
		refs = new List<Ref>(from x in Enumerable.Range(0, model.TriangleIndices.Count)
			select default(Ref));
	}

	public MeshGeometry3D Simplify(bool verbose = false)
	{
		return Simplify(int.MaxValue, 7.0, verbose, lossless: true);
	}

	public MeshGeometry3D Simplify(int targetCount, double aggressive = 7.0, bool verbose = false, bool lossless = false)
	{
		foreach (Triangle triangle in triangles)
		{
			triangle.deleted = false;
		}
		int deletedTriangles = 0;
		List<bool> list = new List<bool>();
		List<bool> list2 = new List<bool>();
		int count = triangles.Count;
		int num = 9999;
		if (!lossless)
		{
			num = 100;
		}
		for (int i = 0; i < num; i++)
		{
			if (!lossless && count - deletedTriangles <= targetCount)
			{
				break;
			}
			if (lossless || i % 5 == 0)
			{
				UpdateMesh(i);
			}
			foreach (Triangle triangle2 in triangles)
			{
				triangle2.dirty = false;
			}
			double num2 = 0.001;
			if (!lossless)
			{
				num2 = 1E-09 * Math.Pow((double)i + 3.0, aggressive);
			}
			if (verbose)
			{
				Debug.WriteLine($"Iteration: {i}; Triangles: {count - deletedTriangles}; Threshold: {num2};");
			}
			foreach (Triangle triangle3 in triangles)
			{
				if (triangle3.err[3] > num2 || triangle3.deleted || triangle3.dirty)
				{
					continue;
				}
				for (int j = 0; j < 3; j++)
				{
					if (!(triangle3.err[j] < num2))
					{
						continue;
					}
					int num3 = triangle3.v[j];
					Vertex v = vertices[num3];
					int num4 = triangle3.v[(j + 1) % 3];
					Vertex v2 = vertices[num4];
					if (v.border != v2.border)
					{
						continue;
					}
					CalculateError(num3, num4, out var p_result);
					list.Clear();
					list2.Clear();
					list.AddRange(Enumerable.Repeat(element: false, v.tCount));
					list2.AddRange(Enumerable.Repeat(element: false, v2.tCount));
					if (Flipped(ref p_result, num3, num4, ref v, ref v2, list) || Flipped(ref p_result, num4, num3, ref v2, ref v, list2))
					{
						continue;
					}
					v.p = p_result;
					v.q = v2.q + v.q;
					int count2 = refs.Count;
					UpdateTriangles(num3, ref v, list, ref deletedTriangles);
					UpdateTriangles(num3, ref v2, list2, ref deletedTriangles);
					int num5 = refs.Count - count2;
					if (num5 <= v.tCount)
					{
						if (num5 > 0)
						{
							for (int k = 0; k < num5; k++)
							{
								refs[v.tStart + k] = refs[count2 + k];
							}
						}
					}
					else
					{
						v.tStart = count2;
					}
					v.tCount = num5;
					break;
				}
				if (lossless || count - deletedTriangles > targetCount)
				{
					continue;
				}
				break;
			}
			if (lossless)
			{
				if (deletedTriangles <= 0)
				{
					break;
				}
				deletedTriangles = 0;
			}
		}
		CompactMesh();
		return GetMesh();
	}

	public MeshGeometry3D GetMesh()
	{
		Point3DCollection positions = new Point3DCollection(vertices.Select((Vertex x) => new Point3D(x.p.X, x.p.Y, x.p.Z)));
		Int32Collection int32Collection = new Int32Collection(triangles.Count * 3);
		foreach (Triangle triangle in triangles)
		{
			int32Collection.Add(triangle.v[0]);
			int32Collection.Add(triangle.v[1]);
			int32Collection.Add(triangle.v[2]);
		}
		return new MeshGeometry3D
		{
			Positions = positions,
			TriangleIndices = int32Collection
		};
	}

	private bool Flipped(ref Vector3D p, int i0, int i1, ref Vertex v0, ref Vertex v1, IList<bool> deleted)
	{
		for (int j = 0; j < v0.tCount; j++)
		{
			Triangle triangle = triangles[refs[v0.tStart + j].tid];
			if (triangle.deleted)
			{
				continue;
			}
			int tvertex = refs[v0.tStart + j].tvertex;
			int num = triangle.v[(tvertex + 1) % 3];
			int num2 = triangle.v[(tvertex + 2) % 3];
			if (num == i1 || num2 == i1)
			{
				deleted[j] = true;
				continue;
			}
			Vector3D first = vertices[num].p - p;
			first.Normalize();
			Vector3D second = vertices[num2].p - p;
			second.Normalize();
			if (SharedFunctions.DotProduct(ref first, ref second) > 0.999)
			{
				return true;
			}
			Vector3D first2 = SharedFunctions.CrossProduct(ref first, ref second);
			first2.Normalize();
			deleted[j] = false;
			if (SharedFunctions.DotProduct(ref first2, ref triangle.normal) < 0.2)
			{
				return true;
			}
		}
		return false;
	}

	private void UpdateTriangles(int i0, ref Vertex v, IList<bool> deleted, ref int deletedTriangles)
	{
		for (int j = 0; j < v.tCount; j++)
		{
			Ref item = refs[v.tStart + j];
			Triangle triangle = triangles[item.tid];
			if (!triangle.deleted)
			{
				if (deleted[j])
				{
					triangle.deleted = true;
					deletedTriangles++;
					continue;
				}
				triangle.v[item.tvertex] = i0;
				triangle.dirty = true;
				triangle.err[0] = CalculateError(triangle.v[0], triangle.v[1], out var p_result);
				triangle.err[1] = CalculateError(triangle.v[1], triangle.v[2], out p_result);
				triangle.err[2] = CalculateError(triangle.v[2], triangle.v[0], out p_result);
				triangle.err[3] = Math.Min(triangle.err[0], Math.Min(triangle.err[1], triangle.err[2]));
				refs.Add(item);
			}
		}
	}

	private double CalculateError(int id_v1, int id_v2, out Vector3D p_result)
	{
		p_result = default(Vector3D);
		SymmetricMatrix q = vertices[id_v1].q + vertices[id_v2].q;
		bool flag = vertices[id_v1].border & vertices[id_v2].border;
		double num = 0.0;
		double num2 = q.det(0, 1, 2, 1, 4, 5, 2, 5, 7);
		if (num2 != 0.0 && !flag)
		{
			p_result.X = (float)(-1.0 / num2 * q.det(1, 2, 3, 4, 5, 6, 5, 7, 8));
			p_result.Y = (float)(1.0 / num2 * q.det(0, 2, 3, 1, 5, 6, 2, 7, 8));
			p_result.Z = (float)(-1.0 / num2 * q.det(0, 1, 3, 1, 4, 6, 2, 5, 8));
			num = VertexError(ref q, p_result.X, p_result.Y, p_result.Z);
		}
		else
		{
			Vector3D p = vertices[id_v1].p;
			Vector3D p2 = vertices[id_v2].p;
			Vector3D vector3D = (p + p2) / 2.0;
			double num3 = VertexError(ref q, p.X, p.Y, p.Z);
			double num4 = VertexError(ref q, p2.X, p2.Y, p2.Z);
			double num5 = VertexError(ref q, vector3D.X, vector3D.Y, vector3D.Z);
			num = Math.Min(num3, Math.Min(num4, num5));
			if (num3 == num)
			{
				p_result = p;
			}
			if (num4 == num)
			{
				p_result = p2;
			}
			if (num5 == num)
			{
				p_result = vector3D;
			}
		}
		return num;
	}

	private double VertexError(ref SymmetricMatrix q, double x, double y, double z)
	{
		return q.M11 * x * x + 2.0 * q.M12 * x * y + 2.0 * q.M13 * x * z + 2.0 * q.M14 * x + q.M22 * y * y + 2.0 * q.M23 * y * z + 2.0 * q.M24 * y + q.M33 * z * z + 2.0 * q.M34 * z + q.M44;
	}

	private void UpdateMesh(int iteration)
	{
		if (iteration > 0)
		{
			int num = 0;
			for (int i = 0; i < triangles.Count; i++)
			{
				if (!triangles[i].deleted)
				{
					triangles[num++] = triangles[i];
				}
			}
			triangles.RemoveRange(num, triangles.Count - num);
		}
		if (iteration == 0)
		{
			foreach (Vertex vertex2 in vertices)
			{
				vertex2.q.SetAll(0.0);
			}
			foreach (Triangle triangle2 in triangles)
			{
				Vector3D second = vertices[triangle2.v[0]].p;
				Vector3D p = vertices[triangle2.v[1]].p;
				Vector3D p2 = vertices[triangle2.v[2]].p;
				Vector3D first = SharedFunctions.CrossProduct(p - second, p2 - second);
				first.Normalize();
				triangle2.normal = first;
				for (int j = 0; j < 3; j++)
				{
					vertices[triangle2.v[j]].q += new SymmetricMatrix(first.X, first.Y, first.Z, 0.0 - SharedFunctions.DotProduct(ref first, ref second));
				}
			}
			foreach (Triangle triangle3 in triangles)
			{
				for (int k = 0; k < 3; k++)
				{
					triangle3.err[k] = CalculateError(triangle3.v[k], triangle3.v[(k + 1) % 3], out var _);
				}
				triangle3.err[3] = Math.Min(triangle3.err[0], Math.Min(triangle3.err[1], triangle3.err[2]));
			}
		}
		foreach (Vertex vertex3 in vertices)
		{
			vertex3.tStart = 0;
			vertex3.tCount = 0;
		}
		foreach (Triangle triangle4 in triangles)
		{
			vertices[triangle4.v[0]].tCount++;
			vertices[triangle4.v[1]].tCount++;
			vertices[triangle4.v[2]].tCount++;
		}
		int num2 = 0;
		foreach (Vertex vertex4 in vertices)
		{
			vertex4.tStart = num2;
			num2 += vertex4.tCount;
			vertex4.tCount = 0;
		}
		int num3 = triangles.Count * 3;
		if (refs.Count < num3)
		{
			refs.Clear();
			refs.AddRange(from x in Enumerable.Range(0, num3)
				select default(Ref));
		}
		else
		{
			refs.RemoveRange(num3, refs.Count - num3);
			refs.ForEach(delegate(Ref x)
			{
				x.Reset();
			});
		}
		int num4 = 0;
		foreach (Triangle triangle5 in triangles)
		{
			for (int num5 = 0; num5 < 3; num5++)
			{
				Vertex vertex = vertices[triangle5.v[num5]];
				Ref value = refs[vertex.tStart + vertex.tCount];
				value.tid = num4;
				value.tvertex = num5;
				refs[vertex.tStart + vertex.tCount] = value;
				vertex.tCount++;
			}
			num4++;
		}
		if (iteration != 0)
		{
			return;
		}
		List<int> list = new List<int>();
		List<int> list2 = new List<int>();
		foreach (Vertex vertex5 in vertices)
		{
			vertex5.border = false;
		}
		foreach (Vertex vertex6 in vertices)
		{
			list.Clear();
			list2.Clear();
			for (int num6 = 0; num6 < vertex6.tCount; num6++)
			{
				Triangle triangle = triangles[refs[vertex6.tStart + num6].tid];
				for (int num7 = 0; num7 < 3; num7++)
				{
					int num8 = 0;
					int num9;
					for (num9 = triangle.v[num7]; num8 < list.Count && list2[num8] != num9; num8++)
					{
					}
					if (num8 == list.Count)
					{
						list.Add(1);
						list2.Add(num9);
					}
					else
					{
						list[num8]++;
					}
				}
			}
			for (int num10 = 0; num10 < list.Count; num10++)
			{
				if (list[num10] == 1)
				{
					vertices[list2[num10]].border = true;
				}
			}
		}
	}

	private void CompactMesh()
	{
		int num = 0;
		foreach (Vertex vertex in vertices)
		{
			vertex.tCount = 0;
		}
		for (int i = 0; i < triangles.Count; i++)
		{
			if (!triangles[i].deleted)
			{
				triangles[num++] = triangles[i];
				vertices[triangles[i].v[0]].tCount = 1;
				vertices[triangles[i].v[1]].tCount = 1;
				vertices[triangles[i].v[2]].tCount = 1;
			}
		}
		triangles.RemoveRange(num, triangles.Count - num);
		num = 0;
		foreach (Vertex vertex2 in vertices)
		{
			if (vertex2.tCount > 0)
			{
				vertex2.tStart = num;
				vertices[num++].p = vertex2.p;
			}
		}
		foreach (Triangle triangle in triangles)
		{
			triangle.v[0] = vertices[triangle.v[0]].tStart;
			triangle.v[1] = vertices[triangle.v[1]].tStart;
			triangle.v[2] = vertices[triangle.v[2]].tStart;
		}
		vertices.RemoveRange(num, vertices.Count - num);
	}
}
