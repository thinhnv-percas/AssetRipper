using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class Mesh3D : ICloneable
{
	public IList<int[]> Edges { get; private set; }

	public IList<int[]> Faces { get; private set; }

	public IList<Point> TextureCoordinates { get; private set; }

	public IList<Point3D> Vertices { get; private set; }

	public Mesh3D()
	{
		Vertices = new List<Point3D>();
		Faces = new List<int[]>();
		Edges = new List<int[]>();
	}

	public Mesh3D(IEnumerable<Point3D> positions, IEnumerable<int> triangleIndices)
		: this(positions, null, triangleIndices)
	{
	}

	public Mesh3D(IEnumerable<Point3D> positions, IEnumerable<Point> textureCoordinates, IEnumerable<int> triangleIndices)
	{
		Vertices = new List<Point3D>(positions);
		if (textureCoordinates != null)
		{
			TextureCoordinates = new List<Point>(textureCoordinates);
		}
		Faces = new List<int[]>();
		Edges = new List<int[]>();
		int[] array = new int[3];
		int num = 0;
		foreach (int triangleIndex in triangleIndices)
		{
			array[num++] = triangleIndex;
			if (num == 3)
			{
				AddFace(array);
				num = 0;
				array = new int[3];
			}
		}
		UpdateEdges();
	}

	public void AddFace(params int[] vertexIndices)
	{
		Faces.Add(vertexIndices);
	}

	public object Clone()
	{
		return new Mesh3D
		{
			Vertices = new List<Point3D>(Vertices),
			Faces = new List<int[]>(Faces),
			Edges = new List<int[]>(Edges)
		};
	}

	public Point3D FindCentroid(int faceIndex)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		int num4 = Faces[faceIndex].Length;
		for (int i = 0; i < num4; i++)
		{
			num += Vertices[Faces[faceIndex][i]].X;
			num2 += Vertices[Faces[faceIndex][i]].Y;
			num3 += Vertices[Faces[faceIndex][i]].Z;
		}
		if (num4 > 0)
		{
			num /= (double)num4;
			num2 /= (double)num4;
			num3 /= (double)num4;
		}
		return new Point3D(num, num2, num3);
	}

	public int FindFaceFromEdge(int v0, int v1)
	{
		for (int i = 0; i < Faces.Count; i++)
		{
			int num = Faces[i].Length;
			for (int j = 0; j < num; j++)
			{
				if (Faces[i][j] == v0 && Faces[i][(j + 1) % num] == v1)
				{
					return i;
				}
			}
		}
		return -1;
	}

	public Rect3D GetBounds()
	{
		Rect3D empty = Rect3D.Empty;
		foreach (Point3D vertex in Vertices)
		{
			empty.Union(vertex);
		}
		return empty;
	}

	public Vector3D GetFaceNormal(int faceIndex)
	{
		int num = Faces[faceIndex].Length;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		for (int i = 0; i + 2 < num; i++)
		{
			Point3D point3D = Vertices[Faces[faceIndex][i]];
			Point3D point3D2 = Vertices[Faces[faceIndex][(i + 1) % num]];
			Point3D point3D3 = Vertices[Faces[faceIndex][(i + 2) % num]];
			Vector3D vector3D = Vector3D.CrossProduct(point3D2 - point3D, point3D3 - point3D);
			num2 += vector3D.X;
			num3 += vector3D.Y;
			num4 += vector3D.Z;
		}
		return new Vector3D(num2, num3, num4);
	}

	public int[] GetNeighbourVertices(int vertexIndex)
	{
		return Edges[vertexIndex];
	}

	public bool IsQuadrilateralMesh()
	{
		foreach (int[] face in Faces)
		{
			if (face.Length != 4)
			{
				return false;
			}
		}
		return true;
	}

	public bool IsTriangularMesh()
	{
		foreach (int[] face in Faces)
		{
			if (face.Length != 3)
			{
				return false;
			}
		}
		return true;
	}

	public void Quadrangulate()
	{
		int count = Faces.Count;
		for (int i = 0; i < count; i++)
		{
			if (Faces[i].Length == 4)
			{
				continue;
			}
			Point3D item = FindCentroid(i);
			int count2 = Vertices.Count;
			Vertices.Add(item);
			int num = Faces[i].Length;
			for (int j = 0; j < num; j++)
			{
				Point3D item2 = FindMidpoint(Faces[i][j], Faces[i][(j + 1) % num]);
				Vertices.Add(item2);
			}
			for (int k = 0; k < num; k++)
			{
				int[] array = new int[4]
				{
					count2 + 1 + k,
					Faces[i][(k + 1) % num],
					count2 + 1 + (k + 1) % num,
					count2
				};
				if (k == num - 1)
				{
					Faces[i] = array;
				}
				else
				{
					Faces.Add(array);
				}
			}
		}
	}

	public MeshGeometry3D ToMeshGeometry3D(bool sharedVertices = true, double shrinkFactor = 0.0, List<int> faceIndices = null)
	{
		bool flag = Math.Abs(shrinkFactor) > double.Epsilon;
		if (!sharedVertices | flag)
		{
			MeshBuilder meshBuilder = new MeshBuilder(generateNormals: false, TextureCoordinates != null);
			int num = 0;
			foreach (int[] face in Faces)
			{
				int[] array = new int[face.Length];
				int num2 = 0;
				Point3D point3D = FindCentroid(num);
				int[] array2 = face;
				foreach (int index in array2)
				{
					array[num2++] = meshBuilder.Positions.Count;
					Point3D point3D2 = Vertices[index];
					if (flag)
					{
						point3D2 += shrinkFactor * (point3D - point3D2);
					}
					meshBuilder.Positions.Add(point3D2);
					if (meshBuilder.CreateTextureCoordinates)
					{
						meshBuilder.TextureCoordinates.Add(TextureCoordinates[index]);
					}
				}
				meshBuilder.AddTriangleFan(array);
				if (faceIndices != null)
				{
					int num3 = array.Length - 2;
					for (int j = 0; j < num3; j++)
					{
						faceIndices.Add(num);
					}
				}
				num++;
			}
			return meshBuilder.ToMesh();
		}
		MeshBuilder meshBuilder2 = new MeshBuilder(generateNormals: false, TextureCoordinates != null);
		foreach (Point3D vertex in Vertices)
		{
			meshBuilder2.Positions.Add(vertex);
		}
		if (TextureCoordinates != null)
		{
			foreach (Point textureCoordinate in TextureCoordinates)
			{
				meshBuilder2.TextureCoordinates.Add(textureCoordinate);
			}
		}
		int num4 = 0;
		foreach (int[] face2 in Faces)
		{
			meshBuilder2.AddTriangleFan(face2);
			if (faceIndices != null)
			{
				int num5 = face2.Length - 2;
				for (int k = 0; k < num5; k++)
				{
					faceIndices.Add(num4);
				}
			}
			num4++;
		}
		return meshBuilder2.ToMesh();
	}

	public void Triangulate(bool barycentric)
	{
		int count = Faces.Count;
		for (int i = 0; i < count; i++)
		{
			if (Faces[i].Length == 3)
			{
				continue;
			}
			if (barycentric)
			{
				Point3D item = FindCentroid(i);
				int count2 = Vertices.Count;
				Vertices.Add(item);
				int num = Faces[i].Length;
				for (int j = 0; j < num; j++)
				{
					int[] array = new int[3]
					{
						Faces[i][j],
						Faces[i][(j + 1) % num],
						count2
					};
					if (j == num - 1)
					{
						Faces[i] = array;
					}
					else
					{
						Faces.Add(array);
					}
				}
				continue;
			}
			int num2 = Faces[i].Length;
			for (int k = 1; k + 1 < num2; k++)
			{
				int[] array2 = new int[3]
				{
					Faces[i][0],
					Faces[i][k % num2],
					Faces[i][(k + 1) % num2]
				};
				if (k + 1 == num2 - 1)
				{
					Faces[i] = array2;
				}
				else
				{
					Faces.Add(array2);
				}
			}
		}
	}

	public void UpdateEdges()
	{
		List<List<int>> list = new List<List<int>>(Vertices.Count);
		foreach (Point3D vertex in Vertices)
		{
			list.Add(new List<int>(5));
		}
		foreach (int[] face in Faces)
		{
			for (int i = 0; i < face.Length; i++)
			{
				int num = face[i];
				int num2 = face[(i + 1) % face.Length];
				list[num].Add(num2);
				list[num2].Add(num);
			}
		}
		Edges.Clear();
		foreach (List<int> item in list)
		{
			Edges.Add(item.ToArray());
		}
	}

	private Point3D FindMidpoint(int v0, int v1)
	{
		return new Point3D((Vertices[v0].X + Vertices[v1].X) * 0.5, (Vertices[v0].Y + Vertices[v1].Y) * 0.5, (Vertices[v0].Z + Vertices[v1].Z) * 0.5);
	}
}
