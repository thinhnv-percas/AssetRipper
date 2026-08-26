#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public static class MeshGeometryHelper
{
	public static Vector3DCollection CalculateNormals(this MeshGeometry3D mesh)
	{
		return CalculateNormals(mesh.Positions, mesh.TriangleIndices);
	}

	public static Vector3DCollection CalculateNormals(IList<Point3D> positions, IList<int> triangleIndices)
	{
		Vector3DCollection vector3DCollection = new Vector3DCollection(positions.Count);
		for (int i = 0; i < positions.Count; i++)
		{
			vector3DCollection.Add(default(Vector3D));
		}
		for (int j = 0; j < triangleIndices.Count; j += 3)
		{
			int index = triangleIndices[j];
			int index2 = triangleIndices[j + 1];
			int index3 = triangleIndices[j + 2];
			Point3D point3D = positions[index];
			Point3D point3D2 = positions[index2];
			Point3D point3D3 = positions[index3];
			Vector3D first = point3D2 - point3D;
			Vector3D second = point3D3 - point3D;
			Vector3D vector3D = SharedFunctions.CrossProduct(ref first, ref second);
			vector3D.Normalize();
			vector3DCollection[index] += vector3D;
			vector3DCollection[index2] += vector3D;
			vector3DCollection[index3] += vector3D;
		}
		for (int k = 0; k < vector3DCollection.Count; k++)
		{
			vector3DCollection[k].Normalize();
		}
		return vector3DCollection;
	}

	public static Int32Collection FindBorderEdges(this MeshGeometry3D mesh)
	{
		Dictionary<ulong, int> dictionary = new Dictionary<ulong, int>();
		for (int i = 0; i < mesh.TriangleIndices.Count / 3; i++)
		{
			int num = i * 3;
			for (int j = 0; j < 3; j++)
			{
				int num2 = mesh.TriangleIndices[num + j];
				int num3 = mesh.TriangleIndices[num + (j + 1) % 3];
				int i2 = Math.Min(num2, num3);
				int i3 = Math.Max(num3, num2);
				ulong key = CreateKey((uint)i2, (uint)i3);
				if (dictionary.ContainsKey(key))
				{
					dictionary[key]++;
				}
				else
				{
					dictionary.Add(key, 1);
				}
			}
		}
		Int32Collection int32Collection = new Int32Collection();
		foreach (KeyValuePair<ulong, int> item in dictionary)
		{
			if (item.Value == 1)
			{
				ReverseKey(item.Key, out var i4, out var i5);
				int32Collection.Add((int)i4);
				int32Collection.Add((int)i5);
			}
		}
		return int32Collection;
	}

	public static Int32Collection FindEdges(this MeshGeometry3D mesh)
	{
		Int32Collection int32Collection = new Int32Collection();
		HashSet<ulong> hashSet = new HashSet<ulong>();
		for (int i = 0; i < mesh.TriangleIndices.Count / 3; i++)
		{
			int num = i * 3;
			for (int j = 0; j < 3; j++)
			{
				int num2 = mesh.TriangleIndices[num + j];
				int num3 = mesh.TriangleIndices[num + (j + 1) % 3];
				int num4 = Math.Min(num2, num3);
				int num5 = Math.Max(num3, num2);
				ulong item = CreateKey((uint)num4, (uint)num5);
				if (!hashSet.Contains(item))
				{
					int32Collection.Add(num4);
					int32Collection.Add(num5);
					hashSet.Add(item);
				}
			}
		}
		return int32Collection;
	}

	public static Int32Collection FindSharpEdges(this MeshGeometry3D mesh, double minimumAngle)
	{
		Int32Collection int32Collection = new Int32Collection();
		Dictionary<ulong, Vector3D> dictionary = new Dictionary<ulong, Vector3D>();
		for (int i = 0; i < mesh.TriangleIndices.Count / 3; i++)
		{
			int num = i * 3;
			Point3D point3D = mesh.Positions[mesh.TriangleIndices[num]];
			Point3D point3D2 = mesh.Positions[mesh.TriangleIndices[num + 1]];
			Point3D point3D3 = mesh.Positions[mesh.TriangleIndices[num + 2]];
			Vector3D first = point3D2 - point3D;
			Vector3D second = point3D3 - point3D;
			Vector3D first2 = SharedFunctions.CrossProduct(ref first, ref second);
			first2.Normalize();
			for (int j = 0; j < 3; j++)
			{
				int val = mesh.TriangleIndices[num + j];
				int val2 = mesh.TriangleIndices[num + (j + 1) % 3];
				int num2 = Math.Min(val, val2);
				int num3 = Math.Max(val, val2);
				ulong key = CreateKey((uint)num2, (uint)num3);
				if (dictionary.TryGetValue(key, out var value))
				{
					Vector3D second2 = value;
					second2.Normalize();
					double num4 = 180.0 / Math.PI * Math.Acos(SharedFunctions.DotProduct(ref first2, ref second2));
					if (num4 > minimumAngle)
					{
						int32Collection.Add(num2);
						int32Collection.Add(num3);
					}
				}
				else
				{
					dictionary.Add(key, first2);
				}
			}
		}
		return int32Collection;
	}

	public static MeshGeometry3D NoSharedVertices(this MeshGeometry3D input)
	{
		Point3DCollection point3DCollection = new Point3DCollection();
		Int32Collection int32Collection = new Int32Collection();
		Vector3DCollection vector3DCollection = null;
		if (input.Normals != null)
		{
			vector3DCollection = new Vector3DCollection();
		}
		PointCollection pointCollection = null;
		if (input.TextureCoordinates != null)
		{
			pointCollection = new PointCollection();
		}
		for (int i = 0; i < input.TriangleIndices.Count; i += 3)
		{
			int num = i;
			int num2 = i + 1;
			int num3 = i + 2;
			int index = input.TriangleIndices[num];
			int index2 = input.TriangleIndices[num2];
			int index3 = input.TriangleIndices[num3];
			Point3D value = input.Positions[index];
			Point3D value2 = input.Positions[index2];
			Point3D value3 = input.Positions[index3];
			point3DCollection.Add(value);
			point3DCollection.Add(value2);
			point3DCollection.Add(value3);
			int32Collection.Add(num);
			int32Collection.Add(num2);
			int32Collection.Add(num3);
			if (vector3DCollection != null)
			{
				vector3DCollection.Add(input.Normals[index]);
				vector3DCollection.Add(input.Normals[index2]);
				vector3DCollection.Add(input.Normals[index3]);
			}
			if (pointCollection != null)
			{
				pointCollection.Add(input.TextureCoordinates[index]);
				pointCollection.Add(input.TextureCoordinates[index2]);
				pointCollection.Add(input.TextureCoordinates[index3]);
			}
		}
		return new MeshGeometry3D
		{
			Positions = point3DCollection,
			TriangleIndices = int32Collection,
			Normals = vector3DCollection,
			TextureCoordinates = pointCollection
		};
	}

	public static MeshGeometry3D Simplify(this MeshGeometry3D mesh, double eps)
	{
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		for (int i = 0; i < mesh.Positions.Count; i++)
		{
			for (int j = i + 1; j < mesh.Positions.Count; j++)
			{
				if (!dictionary.ContainsKey(j))
				{
					Vector3D vector = mesh.Positions[i] - mesh.Positions[j];
					double num = SharedFunctions.LengthSquared(ref vector);
					if (num < eps)
					{
						dictionary.Add(j, i);
					}
				}
			}
		}
		Point3DCollection point3DCollection = new Point3DCollection();
		Int32Collection int32Collection = new Int32Collection();
		Dictionary<int, int> dictionary2 = new Dictionary<int, int>();
		for (int k = 0; k < mesh.Positions.Count; k++)
		{
			if (!dictionary.ContainsKey(k))
			{
				dictionary2.Add(k, point3DCollection.Count);
				point3DCollection.Add(mesh.Positions[k]);
			}
		}
		foreach (int triangleIndex in mesh.TriangleIndices)
		{
			int32Collection.Add(dictionary.TryGetValue(triangleIndex, out var value) ? dictionary2[value] : dictionary2[triangleIndex]);
		}
		return new MeshGeometry3D
		{
			Positions = point3DCollection,
			TriangleIndices = int32Collection
		};
	}

	public static string Validate(this MeshGeometry3D mesh)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (mesh.Normals != null && mesh.Normals.Count != 0 && mesh.Normals.Count != mesh.Positions.Count)
		{
			stringBuilder.AppendLine("Wrong number of normal vectors");
		}
		if (mesh.TextureCoordinates != null && mesh.TextureCoordinates.Count != 0 && mesh.TextureCoordinates.Count != mesh.Positions.Count)
		{
			stringBuilder.AppendLine("Wrong number of TextureCoordinates");
		}
		if (mesh.TriangleIndices.Count % 3 != 0)
		{
			stringBuilder.AppendLine("TriangleIndices not complete");
		}
		for (int i = 0; i < mesh.TriangleIndices.Count; i++)
		{
			int num = mesh.TriangleIndices[i];
			if (num < 0 || num >= mesh.Positions.Count)
			{
				stringBuilder.AppendFormat("Wrong index {0} in triangle {1} vertex {2}", num, i / 3, i % 3);
				stringBuilder.AppendLine();
			}
		}
		return (stringBuilder.Length > 0) ? stringBuilder.ToString() : null;
	}

	public static MeshGeometry3D Cut(this MeshGeometry3D mesh, Point3D plane, Vector3D normal)
	{
		bool flag = mesh.TextureCoordinates != null && mesh.TextureCoordinates.Count > 0;
		bool flag2 = mesh.Normals != null && mesh.Normals.Count > 0;
		MeshBuilder meshBuilder = new MeshBuilder(flag2, flag);
		ContourHelper contourHelper = new ContourHelper(plane, normal, mesh);
		foreach (Point3D position in mesh.Positions)
		{
			meshBuilder.Positions.Add(position);
		}
		if (flag)
		{
			foreach (Point textureCoordinate in mesh.TextureCoordinates)
			{
				meshBuilder.TextureCoordinates.Add(textureCoordinate);
			}
		}
		if (flag2)
		{
			foreach (Vector3D normal2 in mesh.Normals)
			{
				meshBuilder.Normals.Add(normal2);
			}
		}
		for (int i = 0; i < mesh.TriangleIndices.Count; i += 3)
		{
			int index = mesh.TriangleIndices[i];
			int index2 = mesh.TriangleIndices[i + 1];
			int index3 = mesh.TriangleIndices[i + 2];
			contourHelper.ContourFacet(index, index2, index3, out var newPositions, out var newNormals, out var newTextureCoordinates, out var triangleIndices);
			Point3D[] array = newPositions;
			foreach (Point3D value in array)
			{
				meshBuilder.Positions.Add(value);
			}
			Point[] array2 = newTextureCoordinates;
			foreach (Point value2 in array2)
			{
				meshBuilder.TextureCoordinates.Add(value2);
			}
			Vector3D[] array3 = newNormals;
			foreach (Vector3D value3 in array3)
			{
				meshBuilder.Normals.Add(value3);
			}
			int[] array4 = triangleIndices;
			foreach (int value4 in array4)
			{
				meshBuilder.TriangleIndices.Add(value4);
			}
		}
		return meshBuilder.ToMesh();
	}

	public static IList<Point3D> GetContourSegments(this MeshGeometry3D mesh, Point3D plane, Vector3D normal)
	{
		List<Point3D> list = new List<Point3D>();
		ContourHelper contourHelper = new ContourHelper(plane, normal, mesh);
		for (int i = 0; i < mesh.TriangleIndices.Count; i += 3)
		{
			contourHelper.ContourFacet(mesh.TriangleIndices[i], mesh.TriangleIndices[i + 1], mesh.TriangleIndices[i + 2], out var newPositions, out var _, out var _, out var _);
			list.AddRange(newPositions);
		}
		return list;
	}

	public static IEnumerable<IList<Point3D>> CombineSegments(IList<Point3D> segments, double eps)
	{
		List<Point3D> curve = new List<Point3D>();
		int curveCount = 0;
		int segmentCount = segments.Count;
		int segment1 = -1;
		int segment2 = -1;
		while (segmentCount > 0)
		{
			if (curveCount > 0)
			{
				segment1 = FindConnectedSegment(segments, curve[0], eps);
				if (segment1 >= 0)
				{
					if (segment1 % 2 == 1)
					{
						curve.Insert(0, segments[segment1 - 1]);
						segments.RemoveAt(segment1 - 1);
						segments.RemoveAt(segment1 - 1);
					}
					else
					{
						curve.Insert(0, segments[segment1 + 1]);
						segments.RemoveAt(segment1);
						segments.RemoveAt(segment1);
					}
					curveCount++;
					segmentCount -= 2;
				}
				segment2 = FindConnectedSegment(segments, curve[curveCount - 1], eps);
				if (segment2 >= 0)
				{
					if (segment2 % 2 == 1)
					{
						curve.Add(segments[segment2 - 1]);
						segments.RemoveAt(segment2 - 1);
						segments.RemoveAt(segment2 - 1);
					}
					else
					{
						curve.Add(segments[segment2 + 1]);
						segments.RemoveAt(segment2);
						segments.RemoveAt(segment2);
					}
					curveCount++;
					segmentCount -= 2;
				}
			}
			if ((segment1 < 0 && segment2 < 0) || segmentCount == 0)
			{
				if (curveCount > 0)
				{
					yield return curve;
					curve = new List<Point3D>();
					curveCount = 0;
				}
				if (segmentCount > 0)
				{
					curve.Add(segments[0]);
					curve.Add(segments[1]);
					curveCount += 2;
					segments.RemoveAt(0);
					segments.RemoveAt(0);
					segmentCount -= 2;
				}
			}
		}
	}

	private static ulong CreateKey(uint i0, uint i1)
	{
		return ((ulong)i0 << 32) + i1;
	}

	private static void ReverseKey(ulong key, out uint i0, out uint i1)
	{
		i0 = (uint)(key >> 32);
		i1 = (uint)(key << 32 >> 32);
	}

	private static int FindConnectedSegment(IList<Point3D> segments, Point3D point, double eps)
	{
		double num = eps;
		int result = -1;
		for (int i = 0; i < segments.Count; i++)
		{
			Vector3D vector = point - segments[i];
			double num2 = SharedFunctions.LengthSquared(ref vector);
			if (num2 < num)
			{
				result = i;
				num = num2;
			}
		}
		return result;
	}

	public static MeshGeometry3D RemoveIsolatedVertices(this MeshGeometry3D mesh)
	{
		RemoveIsolatedVertices(mesh.Positions, mesh.TriangleIndices, mesh.TextureCoordinates, mesh.Normals, out var verticesOut, out var trianglesOut, out var textureOut, out var normalOut);
		return new MeshGeometry3D
		{
			Positions = verticesOut,
			TriangleIndices = trianglesOut,
			TextureCoordinates = textureOut,
			Normals = normalOut
		};
	}

	public static void RemoveIsolatedVertices(IList<Point3D> vertices, IList<int> triangles, IList<Point> texture, IList<Vector3D> normals, out Point3DCollection verticesOut, out Int32Collection trianglesOut, out PointCollection textureOut, out Vector3DCollection normalOut)
	{
		verticesOut = null;
		trianglesOut = null;
		textureOut = null;
		normalOut = null;
		List<List<int>> list = new List<List<int>>(vertices.Count);
		Debug.WriteLine($"NumVert:{vertices.Count}; NumTriangle:{triangles.Count};");
		for (int i = 0; i < vertices.Count; i++)
		{
			list.Add(new List<int>());
		}
		for (int j = 0; j < triangles.Count; j++)
		{
			list[triangles[j]].Add(j);
		}
		List<int> list2 = new List<int>(vertices.Count);
		for (int k = 0; k < vertices.Count; k++)
		{
			if (list[k].Count == 0)
			{
				list2.Add(k);
			}
		}
		verticesOut = new Point3DCollection(vertices.Count - list2.Count);
		trianglesOut = new Int32Collection(triangles);
		if (texture != null)
		{
			textureOut = new PointCollection(vertices.Count - list2.Count);
		}
		if (normals != null)
		{
			normalOut = new Vector3DCollection(vertices.Count - list2.Count);
		}
		if (vertices.Count == list2.Count)
		{
			return;
		}
		int num = 0;
		for (int l = 0; l < vertices.Count; l++)
		{
			if (num == list2.Count || l < list2[num])
			{
				verticesOut.Add(vertices[l]);
				if (texture != null)
				{
					textureOut.Add(texture[l]);
				}
				if (normals != null)
				{
					normalOut.Add(normals[l]);
				}
				foreach (int item in list[l])
				{
					trianglesOut[item] -= num;
				}
			}
			else
			{
				num++;
			}
		}
		Debug.WriteLine($"Remesh finished. Output NumVert:{verticesOut.Count};");
	}
}
