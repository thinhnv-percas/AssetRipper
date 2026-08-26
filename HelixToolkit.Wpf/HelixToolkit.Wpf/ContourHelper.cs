using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class ContourHelper
{
	private enum ContourFacetResult
	{
		None,
		ZeroOnly,
		OneAndTwo,
		OneOnly,
		ZeroAndTwo,
		TwoOnly,
		ZeroAndOne,
		All
	}

	private static readonly IDictionary<ContourFacetResult, int[,]> ResultIndices = new Dictionary<ContourFacetResult, int[,]>
	{
		{
			ContourFacetResult.ZeroOnly,
			new int[2, 2]
			{
				{ 0, 1 },
				{ 0, 2 }
			}
		},
		{
			ContourFacetResult.OneAndTwo,
			new int[2, 2]
			{
				{ 0, 2 },
				{ 0, 1 }
			}
		},
		{
			ContourFacetResult.OneOnly,
			new int[2, 2]
			{
				{ 1, 2 },
				{ 1, 0 }
			}
		},
		{
			ContourFacetResult.ZeroAndTwo,
			new int[2, 2]
			{
				{ 1, 0 },
				{ 1, 2 }
			}
		},
		{
			ContourFacetResult.TwoOnly,
			new int[2, 2]
			{
				{ 2, 0 },
				{ 2, 1 }
			}
		},
		{
			ContourFacetResult.ZeroAndOne,
			new int[2, 2]
			{
				{ 2, 1 },
				{ 2, 0 }
			}
		}
	};

	private readonly double a;

	private readonly double b;

	private readonly double c;

	private readonly double d;

	private readonly double[] sides = new double[3];

	private readonly int[] indices = new int[3];

	private readonly Point3D[] meshPositions;

	private readonly Vector3D[] meshNormals;

	private readonly Point[] meshTextureCoordinates;

	private readonly Point3D[] points = new Point3D[3];

	private readonly Vector3D[] normals;

	private readonly Point[] textures;

	private int positionCount;

	public ContourHelper(Point3D planeOrigin, Vector3D planeNormal, MeshGeometry3D originalMesh)
	{
		bool flag = originalMesh.Normals != null && originalMesh.Normals.Count > 0;
		bool flag2 = originalMesh.TextureCoordinates != null && originalMesh.TextureCoordinates.Count > 0;
		normals = (flag ? new Vector3D[3] : null);
		textures = (flag2 ? new Point[3] : null);
		positionCount = originalMesh.Positions.Count;
		meshPositions = originalMesh.Positions.ToArray();
		meshNormals = (flag ? originalMesh.Normals.ToArray() : null);
		meshTextureCoordinates = (flag2 ? originalMesh.TextureCoordinates.ToArray() : null);
		float num = (float)Math.Sqrt(planeNormal.X * planeNormal.X + planeNormal.Y * planeNormal.Y + planeNormal.Z * planeNormal.Z);
		a = planeNormal.X / (double)num;
		b = planeNormal.Y / (double)num;
		c = planeNormal.Z / (double)num;
		d = 0f - (float)(planeNormal.X * planeOrigin.X + planeNormal.Y * planeOrigin.Y + planeNormal.Z * planeOrigin.Z);
	}

	public void ContourFacet(int index0, int index1, int index2, out Point3D[] newPositions, out Vector3D[] newNormals, out Point[] newTextureCoordinates, out int[] triangleIndices)
	{
		SetData(index0, index1, index2);
		ContourFacetResult contourFacet = GetContourFacet();
		switch (contourFacet)
		{
		case ContourFacetResult.ZeroOnly:
			triangleIndices = new int[3]
			{
				index0,
				positionCount++,
				positionCount++
			};
			break;
		case ContourFacetResult.OneAndTwo:
			triangleIndices = new int[6]
			{
				index1,
				index2,
				positionCount,
				positionCount++,
				positionCount++,
				index1
			};
			break;
		case ContourFacetResult.OneOnly:
			triangleIndices = new int[3]
			{
				index1,
				positionCount++,
				positionCount++
			};
			break;
		case ContourFacetResult.ZeroAndTwo:
			triangleIndices = new int[6]
			{
				index2,
				index0,
				positionCount,
				positionCount++,
				positionCount++,
				index2
			};
			break;
		case ContourFacetResult.TwoOnly:
			triangleIndices = new int[3]
			{
				index2,
				positionCount++,
				positionCount++
			};
			break;
		case ContourFacetResult.ZeroAndOne:
			triangleIndices = new int[6]
			{
				index0,
				index1,
				positionCount,
				positionCount++,
				positionCount++,
				index0
			};
			break;
		case ContourFacetResult.All:
			newPositions = new Point3D[0];
			newNormals = new Vector3D[0];
			newTextureCoordinates = new Point[0];
			triangleIndices = new int[3] { index0, index1, index2 };
			return;
		default:
			newPositions = new Point3D[0];
			newNormals = new Vector3D[0];
			newTextureCoordinates = new Point[0];
			triangleIndices = new int[0];
			return;
		}
		int[,] array = ResultIndices[contourFacet];
		newPositions = new Point3D[2]
		{
			CreateNewPosition(array[0, 0], array[0, 1]),
			CreateNewPosition(array[1, 0], array[1, 1])
		};
		if (normals != null)
		{
			newNormals = new Vector3D[2]
			{
				CreateNewNormal(array[0, 0], array[0, 1]),
				CreateNewNormal(array[1, 0], array[1, 1])
			};
		}
		else
		{
			newNormals = new Vector3D[0];
		}
		if (textures != null)
		{
			newTextureCoordinates = new Point[2]
			{
				CreateNewTexture(array[0, 0], array[0, 1]),
				CreateNewTexture(array[1, 0], array[1, 1])
			};
		}
		else
		{
			newTextureCoordinates = new Point[0];
		}
	}

	private static double CalculatePoint(double firstPoint, double secondPoint, double firstSide, double secondSide)
	{
		return firstPoint - firstSide * (secondPoint - firstPoint) / (secondSide - firstSide);
	}

	private ContourFacetResult GetContourFacet()
	{
		if (IsSideAlone(0))
		{
			return (sides[0] > 0.0) ? ContourFacetResult.ZeroOnly : ContourFacetResult.OneAndTwo;
		}
		if (IsSideAlone(1))
		{
			return (sides[1] > 0.0) ? ContourFacetResult.OneOnly : ContourFacetResult.ZeroAndTwo;
		}
		if (IsSideAlone(2))
		{
			return (sides[2] > 0.0) ? ContourFacetResult.TwoOnly : ContourFacetResult.ZeroAndOne;
		}
		if (AllSidesBelowContour())
		{
			return ContourFacetResult.All;
		}
		return ContourFacetResult.None;
	}

	private void SetData(int index0, int index1, int index2)
	{
		indices[0] = index0;
		indices[1] = index1;
		indices[2] = index2;
		points[0] = meshPositions[index0];
		points[1] = meshPositions[index1];
		points[2] = meshPositions[index2];
		if (normals != null)
		{
			normals[0] = meshNormals[index0];
			normals[1] = meshNormals[index1];
			normals[2] = meshNormals[index2];
		}
		if (textures != null)
		{
			textures[0] = meshTextureCoordinates[index0];
			textures[1] = meshTextureCoordinates[index1];
			textures[2] = meshTextureCoordinates[index2];
		}
		sides[0] = a * points[0].X + b * points[0].Y + c * points[0].Z + d;
		sides[1] = a * points[1].X + b * points[1].Y + c * points[1].Z + d;
		sides[2] = a * points[2].X + b * points[2].Y + c * points[2].Z + d;
	}

	private Point3D CreateNewPosition(int index0, int index1)
	{
		Point3D point3D = points[index0];
		Point3D point3D2 = points[index1];
		double firstSide = sides[index0];
		double secondSide = sides[index1];
		return new Point3D(CalculatePoint(point3D.X, point3D2.X, firstSide, secondSide), CalculatePoint(point3D.Y, point3D2.Y, firstSide, secondSide), CalculatePoint(point3D.Z, point3D2.Z, firstSide, secondSide));
	}

	private Vector3D CreateNewNormal(int index0, int index1)
	{
		Vector3D vector3D = normals[index0];
		Vector3D vector3D2 = normals[index1];
		double firstSide = sides[index0];
		double secondSide = sides[index1];
		return new Vector3D(CalculatePoint(vector3D.X, vector3D2.X, firstSide, secondSide), CalculatePoint(vector3D.Y, vector3D2.Y, firstSide, secondSide), CalculatePoint(vector3D.Z, vector3D2.Z, firstSide, secondSide));
	}

	private Point CreateNewTexture(int index0, int index1)
	{
		Point point = textures[index0];
		Point point2 = textures[index1];
		double firstSide = sides[index0];
		double secondSide = sides[index1];
		return new Point(CalculatePoint(point.X, point2.X, firstSide, secondSide), CalculatePoint(point.Y, point2.Y, firstSide, secondSide));
	}

	private bool IsSideAlone(int index)
	{
		Func<int, int> func = (int i) => (i + 1 <= 2) ? (i + 1) : 0;
		int num = func(index);
		int num2 = func(num);
		return sides[index] * sides[num] < 0.0 && sides[index] * sides[num2] < 0.0;
	}

	private bool AllSidesBelowContour()
	{
		return sides[0] >= 0.0 && sides[1] >= 0.0 && sides[2] >= 0.0;
	}
}
