#define DEBUG
#define TRACE
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class MeshBuilder
{
	private const string AllCurvesShouldHaveTheSameNumberOfPoints = "All curves should have the same number of points";

	private const string SourceMeshNormalsShouldNotBeNull = "Source mesh normals should not be null.";

	private const string SourceMeshTextureCoordinatesShouldNotBeNull = "Source mesh texture coordinates should not be null.";

	private const string WrongNumberOfDiameters = "Wrong number of diameters.";

	private const string WrongNumberOfPositions = "Wrong number of positions.";

	private const string WrongNumberOfNormals = "Wrong number of normals.";

	private const string WrongNumberOfTextureCoordinates = "Wrong number of texture coordinates.";

	private const string WrongNumberOfAngles = "Wrong number of angles.";

	private static readonly ThreadLocal<Dictionary<int, IList<Point>>> CircleCache = new ThreadLocal<Dictionary<int, IList<Point>>>(() => new Dictionary<int, IList<Point>>());

	private static readonly ThreadLocal<Dictionary<int, IList<Point>>> ClosedCircleCache = new ThreadLocal<Dictionary<int, IList<Point>>>(() => new Dictionary<int, IList<Point>>());

	private static readonly ThreadLocal<Dictionary<int, MeshGeometry3D>> UnitSphereCache = new ThreadLocal<Dictionary<int, MeshGeometry3D>>(() => new Dictionary<int, MeshGeometry3D>());

	private Point3DCollection positions;

	private Int32Collection triangleIndices;

	private Vector3DCollection normals;

	private PointCollection textureCoordinates;

	private Vector3DCollection tangents;

	private Vector3DCollection bitangents;

	public Point3DCollection Positions => positions;

	public Int32Collection TriangleIndices => triangleIndices;

	public Vector3DCollection Normals
	{
		get
		{
			return normals;
		}
		set
		{
			normals = value;
		}
	}

	public PointCollection TextureCoordinates
	{
		get
		{
			return textureCoordinates;
		}
		set
		{
			textureCoordinates = value;
		}
	}

	public Vector3DCollection Tangents
	{
		get
		{
			return tangents;
		}
		set
		{
			tangents = value;
		}
	}

	public Vector3DCollection BiTangents
	{
		get
		{
			return bitangents;
		}
		set
		{
			bitangents = value;
		}
	}

	public bool HasNormals => normals != null;

	public bool HasTexCoords => textureCoordinates != null;

	public bool HasTangents => tangents != null;

	public bool CreateNormals
	{
		get
		{
			return normals != null;
		}
		set
		{
			if (value && normals == null)
			{
				normals = new Vector3DCollection();
			}
			if (!value)
			{
				normals = null;
			}
		}
	}

	public bool CreateTextureCoordinates
	{
		get
		{
			return textureCoordinates != null;
		}
		set
		{
			if (value && textureCoordinates == null)
			{
				textureCoordinates = new PointCollection();
			}
			if (!value)
			{
				textureCoordinates = null;
			}
		}
	}

	public MeshBuilder()
		: this(true, true, false)
	{
	}

	public MeshBuilder(bool generateNormals = true, bool generateTexCoords = true, bool tangentSpace = false)
	{
		positions = new Point3DCollection();
		triangleIndices = new Int32Collection();
		if (generateNormals)
		{
			normals = new Vector3DCollection();
		}
		if (generateTexCoords)
		{
			textureCoordinates = new PointCollection();
		}
		if (tangentSpace)
		{
			tangents = new Vector3DCollection();
			bitangents = new Vector3DCollection();
		}
	}

	public static IList<Point> GetCircle(int thetaDiv, bool closed = false)
	{
		IList<Point> value = null;
		if ((!closed && !CircleCache.Value.TryGetValue(thetaDiv, out value)) || (closed && !ClosedCircleCache.Value.TryGetValue(thetaDiv, out value)))
		{
			value = new PointCollection();
			if (!closed)
			{
				CircleCache.Value.Add(thetaDiv, value);
			}
			else
			{
				ClosedCircleCache.Value.Add(thetaDiv, value);
			}
			int num = (closed ? thetaDiv : (thetaDiv - 1));
			for (int i = 0; i < thetaDiv; i++)
			{
				double num2 = Math.PI * 2.0 * ((double)i / (double)num);
				value.Add(new Point(Math.Cos(num2), 0.0 - Math.Sin(num2)));
			}
		}
		IList<Point> list = new List<Point>();
		foreach (Point item in value)
		{
			list.Add(new Point(item.X, item.Y));
		}
		return list;
	}

	public static IList<Point> GetCircleSegment(int thetaDiv, double totalAngle = Math.PI * 2.0, double angleOffset = 0.0)
	{
		IList<Point> list = new PointCollection();
		for (int i = 0; i < thetaDiv; i++)
		{
			double num = totalAngle * ((double)i / (double)(thetaDiv - 1)) + angleOffset;
			list.Add(new Point(Math.Cos(num), Math.Sin(num)));
		}
		return list;
	}

	private static MeshGeometry3D GetUnitSphere(int subdivisions)
	{
		if (UnitSphereCache.Value.ContainsKey(subdivisions))
		{
			return UnitSphereCache.Value[subdivisions];
		}
		MeshBuilder meshBuilder = new MeshBuilder(generateNormals: false, generateTexCoords: false);
		meshBuilder.AddRegularIcosahedron(default(Point3D), 1.0, shareVertices: false);
		for (int i = 0; i < subdivisions; i++)
		{
			meshBuilder.SubdivideLinear();
		}
		for (int j = 0; j < meshBuilder.positions.Count; j++)
		{
			Vector3D vector = meshBuilder.Positions[j].ToVector3D();
			vector.Normalize();
			meshBuilder.Positions[j] = SharedFunctions.ToPoint3D(ref vector);
		}
		MeshGeometry3D meshGeometry3D = meshBuilder.ToMesh();
		UnitSphereCache.Value[subdivisions] = meshGeometry3D;
		return meshGeometry3D;
	}

	private static void ComputeNormals(Point3DCollection positions, Int32Collection triangleIndices, out Vector3DCollection normals)
	{
		normals = new Vector3DCollection(positions.Count);
		for (int i = 0; i < positions.Count; i++)
		{
			normals.Add(new Vector3D(0.0, 0.0, 0.0));
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
			first.Normalize();
			second.Normalize();
			float num = (float)Math.Acos(SharedFunctions.DotProduct(ref first, ref second));
			vector3D.Normalize();
			normals[index] += num * vector3D;
			normals[index2] += num * vector3D;
			normals[index3] += num * vector3D;
		}
		for (int k = 0; k < normals.Count; k++)
		{
			Vector3D value = normals[k];
			value.Normalize();
			normals[k] = value;
		}
	}

	public void ComputeTangents(MeshFaces meshFaces)
	{
		switch (meshFaces)
		{
		case MeshFaces.Default:
			if ((positions != null) & (triangleIndices != null) & (normals != null) & (textureCoordinates != null))
			{
				ComputeTangents(positions, normals, textureCoordinates, triangleIndices, out var vector3DCollection3, out var vector3DCollection4);
				tangents = vector3DCollection3;
				bitangents = vector3DCollection4;
			}
			break;
		case MeshFaces.QuadPatches:
			if ((positions != null) & (triangleIndices != null) & (normals != null) & (textureCoordinates != null))
			{
				ComputeTangentsQuads(positions, normals, textureCoordinates, triangleIndices, out var vector3DCollection, out var vector3DCollection2);
				tangents = vector3DCollection;
				bitangents = vector3DCollection2;
			}
			break;
		}
	}

	public static void ComputeTangents(Point3DCollection positions, Vector3DCollection normals, PointCollection textureCoordinates, Int32Collection triangleIndices, out Vector3DCollection tangents, out Vector3DCollection bitangents)
	{
		Vector3D[] array = new Vector3D[positions.Count];
		for (int i = 0; i < triangleIndices.Count; i += 3)
		{
			int num = triangleIndices[i];
			int num2 = triangleIndices[i + 1];
			int num3 = triangleIndices[i + 2];
			Point3D point3D = positions[num];
			Point3D point3D2 = positions[num2];
			Point3D point3D3 = positions[num3];
			Point point = textureCoordinates[num];
			Point point2 = textureCoordinates[num2];
			Point point3 = textureCoordinates[num3];
			double num4 = point3D2.X - point3D.X;
			double num5 = point3D3.X - point3D.X;
			double num6 = point3D2.Y - point3D.Y;
			double num7 = point3D3.Y - point3D.Y;
			double num8 = point3D2.Z - point3D.Z;
			double num9 = point3D3.Z - point3D.Z;
			double num10 = point2.X - point.X;
			double num11 = point3.X - point.X;
			double num12 = point2.Y - point.Y;
			double num13 = point3.Y - point.Y;
			double num14 = 1.0 / (num10 * num13 - num11 * num12);
			Vector3D vector3D = new Vector3D((num13 * num4 - num12 * num5) * num14, (num13 * num6 - num12 * num7) * num14, (num13 * num8 - num12 * num9) * num14);
			array[num] += vector3D;
			array[num2] += vector3D;
			array[num3] += vector3D;
		}
		tangents = new Vector3DCollection(positions.Count);
		bitangents = new Vector3DCollection(positions.Count);
		for (int j = 0; j < positions.Count; j++)
		{
			Vector3D first = normals[j];
			Vector3D second = array[j];
			second -= first * SharedFunctions.DotProduct(ref first, ref second);
			second.Normalize();
			Vector3D value = SharedFunctions.CrossProduct(ref first, ref second);
			tangents.Add(second);
			bitangents.Add(value);
		}
	}

	public static void ComputeTangentsQuads(Point3DCollection positions, Vector3DCollection normals, PointCollection textureCoordinates, Int32Collection indices, out Vector3DCollection tangents, out Vector3DCollection bitangents)
	{
		Vector3D[] array = new Vector3D[positions.Count];
		for (int i = 0; i < indices.Count; i += 4)
		{
			int num = indices[i];
			int num2 = indices[i + 1];
			int num3 = indices[i + 2];
			int num4 = indices[i + 3];
			Point3D point3D = positions[num];
			Point3D point3D2 = positions[num2];
			Point3D point3D3 = positions[num3];
			Point3D point3D4 = positions[num4];
			Point point = textureCoordinates[num];
			Point point2 = textureCoordinates[num2];
			Point point3 = textureCoordinates[num3];
			Point point4 = textureCoordinates[num4];
			double num5 = point3D2.X - point3D.X;
			double num6 = point3D4.X - point3D.X;
			double num7 = point3D2.Y - point3D.Y;
			double num8 = point3D4.Y - point3D.Y;
			double num9 = point3D2.Z - point3D.Z;
			double num10 = point3D4.Z - point3D.Z;
			double num11 = point2.X - point.X;
			double num12 = point4.X - point.X;
			double num13 = point2.Y - point.Y;
			double num14 = point4.Y - point.Y;
			double num15 = 1.0 / (num11 * num14 - num12 * num13);
			Vector3D vector3D = new Vector3D((num14 * num5 - num13 * num6) * num15, (num14 * num7 - num13 * num8) * num15, (num14 * num9 - num13 * num10) * num15);
			array[num] += vector3D;
			array[num2] += vector3D;
			array[num3] += vector3D;
			array[num4] += vector3D;
		}
		tangents = new Vector3DCollection(positions.Count);
		bitangents = new Vector3DCollection(positions.Count);
		for (int j = 0; j < positions.Count; j++)
		{
			Vector3D first = normals[j];
			Vector3D second = array[j];
			second -= first * SharedFunctions.DotProduct(ref first, ref second);
			second.Normalize();
			Vector3D value = SharedFunctions.CrossProduct(ref first, ref second);
			tangents.Add(second);
			bitangents.Add(value);
		}
	}

	public static void ComputeTangents(MeshGeometry3D meshGeometry)
	{
		ComputeTangents(meshGeometry.Positions, meshGeometry.Normals, meshGeometry.TextureCoordinates, meshGeometry.TriangleIndices, out var _, out var _);
	}

	public void ComputeNormalsAndTangents(MeshFaces meshFaces, bool tangents = false)
	{
		if (!HasNormals & (positions != null) & (triangleIndices != null))
		{
			ComputeNormals(positions, triangleIndices, out normals);
		}
		switch (meshFaces)
		{
		case MeshFaces.Default:
			if (tangents & HasNormals & (textureCoordinates != null))
			{
				ComputeTangents(positions, normals, textureCoordinates, triangleIndices, out var vector3DCollection3, out var vector3DCollection4);
				this.tangents = vector3DCollection3;
				bitangents = vector3DCollection4;
			}
			break;
		case MeshFaces.QuadPatches:
			if (tangents & HasNormals & (textureCoordinates != null))
			{
				ComputeTangentsQuads(positions, normals, textureCoordinates, triangleIndices, out var vector3DCollection, out var vector3DCollection2);
				this.tangents = vector3DCollection;
				bitangents = vector3DCollection2;
			}
			break;
		}
	}

	public void AddArrow(Point3D point1, Point3D point2, double diameter, double headLength = 3.0, int thetaDiv = 18)
	{
		Vector3D vector = point2 - point1;
		double num = SharedFunctions.Length(ref vector);
		double num2 = diameter / 2.0;
		PointCollection points = new PointCollection
		{
			new Point(0.0, 0.0),
			new Point(0.0, num2),
			new Point(num - diameter * headLength, num2),
			new Point(num - diameter * headLength, num2 * 2.0),
			new Point(num, 0.0)
		};
		AddRevolvedGeometry(points, null, point1, vector, thetaDiv);
	}

	public void AddBoundingBox(Rect3D boundingBox, double diameter)
	{
		Point3D point3D = new Point3D(boundingBox.X, boundingBox.Y, boundingBox.Z);
		Point3D point3D2 = new Point3D(boundingBox.X, boundingBox.Y + boundingBox.SizeY, boundingBox.Z);
		Point3D point3D3 = new Point3D(boundingBox.X + boundingBox.SizeX, boundingBox.Y + boundingBox.SizeY, boundingBox.Z);
		Point3D point3D4 = new Point3D(boundingBox.X + boundingBox.SizeX, boundingBox.Y, boundingBox.Z);
		Point3D point3D5 = new Point3D(boundingBox.X, boundingBox.Y, boundingBox.Z + boundingBox.SizeZ);
		Point3D point3D6 = new Point3D(boundingBox.X, boundingBox.Y + boundingBox.SizeY, boundingBox.Z + boundingBox.SizeZ);
		Point3D point3D7 = new Point3D(boundingBox.X + boundingBox.SizeX, boundingBox.Y + boundingBox.SizeY, boundingBox.Z + boundingBox.SizeZ);
		Point3D point3D8 = new Point3D(boundingBox.X + boundingBox.SizeX, boundingBox.Y, boundingBox.Z + boundingBox.SizeZ);
		Action<Point3D, Point3D> action = delegate(Point3D c1, Point3D c2)
		{
			AddCylinder(c1, c2, diameter, 10);
		};
		action(point3D, point3D2);
		action(point3D2, point3D3);
		action(point3D3, point3D4);
		action(point3D4, point3D);
		action(point3D5, point3D6);
		action(point3D6, point3D7);
		action(point3D7, point3D8);
		action(point3D8, point3D5);
		action(point3D, point3D5);
		action(point3D2, point3D6);
		action(point3D3, point3D7);
		action(point3D4, point3D8);
	}

	public void AddBox(Point3D center, double xlength, double ylength, double zlength)
	{
		AddBox(center, xlength, ylength, zlength, BoxFaces.All);
	}

	public void AddBox(Rect3D rectangle, BoxFaces faces = BoxFaces.All)
	{
		AddBox(new Point3D(rectangle.X + rectangle.SizeX * 0.5, rectangle.Y + rectangle.SizeY * 0.5, rectangle.Z + rectangle.SizeZ * 0.5), rectangle.SizeX, rectangle.SizeY, rectangle.SizeZ, faces);
	}

	public void AddBox(Point3D center, double xlength, double ylength, double zlength, BoxFaces faces)
	{
		AddBox(center, new Vector3D(1.0, 0.0, 0.0), new Vector3D(0.0, 1.0, 0.0), xlength, ylength, zlength, faces);
	}

	public void AddBox(Point3D center, Vector3D x, Vector3D y, double xlength, double ylength, double zlength, BoxFaces faces = BoxFaces.All)
	{
		Vector3D vector3D = SharedFunctions.CrossProduct(ref x, ref y);
		if ((faces & BoxFaces.PositiveX) == BoxFaces.PositiveX)
		{
			AddCubeFace(center, x, vector3D, xlength, ylength, zlength);
		}
		if ((faces & BoxFaces.NegativeX) == BoxFaces.NegativeX)
		{
			AddCubeFace(center, -x, vector3D, xlength, ylength, zlength);
		}
		if ((faces & BoxFaces.NegativeY) == BoxFaces.NegativeY)
		{
			AddCubeFace(center, -y, vector3D, ylength, xlength, zlength);
		}
		if ((faces & BoxFaces.PositiveY) == BoxFaces.PositiveY)
		{
			AddCubeFace(center, y, vector3D, ylength, xlength, zlength);
		}
		if ((faces & BoxFaces.PositiveZ) == BoxFaces.PositiveZ)
		{
			AddCubeFace(center, vector3D, y, zlength, xlength, ylength);
		}
		if ((faces & BoxFaces.NegativeZ) == BoxFaces.NegativeZ)
		{
			AddCubeFace(center, -vector3D, y, zlength, xlength, ylength);
		}
	}

	public void AddCone(Point3D origin, Vector3D direction, double baseRadius, double topRadius, double height, bool baseCap, bool topCap, int thetaDiv)
	{
		PointCollection pointCollection = new PointCollection();
		List<double> list = new List<double>();
		if (baseCap)
		{
			pointCollection.Add(new Point(0.0, 0.0));
			list.Add(0.0);
		}
		pointCollection.Add(new Point(0.0, baseRadius));
		list.Add(1.0);
		pointCollection.Add(new Point(height, topRadius));
		list.Add(0.0);
		if (topCap)
		{
			pointCollection.Add(new Point(height, 0.0));
			list.Add(1.0);
		}
		AddRevolvedGeometry(pointCollection, list, origin, direction, thetaDiv);
	}

	public void AddCone(Point3D origin, Point3D apex, double baseRadius, bool baseCap, int thetaDiv)
	{
		Vector3D vector = apex - origin;
		AddCone(origin, vector, baseRadius, 0.0, SharedFunctions.Length(ref vector), baseCap, topCap: false, thetaDiv);
	}

	public void AddCubeFace(Point3D center, Vector3D normal, Vector3D up, double dist, double width, double height)
	{
		Vector3D vector3D = SharedFunctions.CrossProduct(ref normal, ref up);
		Vector3D vector3D2 = normal * dist / 2.0;
		up *= height / 2.0;
		vector3D *= width / 2.0;
		Point3D value = center + vector3D2 - up - vector3D;
		Point3D value2 = center + vector3D2 - up + vector3D;
		Point3D value3 = center + vector3D2 + up + vector3D;
		Point3D value4 = center + vector3D2 + up - vector3D;
		int count = positions.Count;
		positions.Add(value);
		positions.Add(value2);
		positions.Add(value3);
		positions.Add(value4);
		if (normals != null)
		{
			normals.Add(normal);
			normals.Add(normal);
			normals.Add(normal);
			normals.Add(normal);
		}
		if (textureCoordinates != null)
		{
			textureCoordinates.Add(new Point(1.0, 1.0));
			textureCoordinates.Add(new Point(0.0, 1.0));
			textureCoordinates.Add(new Point(0.0, 0.0));
			textureCoordinates.Add(new Point(1.0, 0.0));
		}
		triangleIndices.Add(count + 2);
		triangleIndices.Add(count + 1);
		triangleIndices.Add(count);
		triangleIndices.Add(count);
		triangleIndices.Add(count + 3);
		triangleIndices.Add(count + 2);
	}

	public void AddCube(BoxFaces faces = BoxFaces.All)
	{
		if ((faces & BoxFaces.PositiveX) == BoxFaces.PositiveX)
		{
			AddFacePX();
		}
		if ((faces & BoxFaces.NegativeX) == BoxFaces.NegativeX)
		{
			AddFaceNX();
		}
		if ((faces & BoxFaces.NegativeY) == BoxFaces.NegativeY)
		{
			AddFaceNY();
		}
		if ((faces & BoxFaces.PositiveY) == BoxFaces.PositiveY)
		{
			AddFacePY();
		}
		if ((faces & BoxFaces.PositiveZ) == BoxFaces.PositiveZ)
		{
			AddFacePZ();
		}
		if ((faces & BoxFaces.NegativeZ) == BoxFaces.NegativeZ)
		{
			AddFaceNZ();
		}
	}

	public void AddCylinder(Point3D p1, Point3D p2, double diameter, int thetaDiv)
	{
		Vector3D vector = p2 - p1;
		double height = SharedFunctions.Length(ref vector);
		vector.Normalize();
		AddCone(p1, vector, diameter / 2.0, diameter / 2.0, height, baseCap: false, topCap: false, thetaDiv);
	}

	public void AddCylinder(Point3D p1, Point3D p2, double radius = 1.0, int thetaDiv = 32, bool cap1 = true, bool cap2 = true)
	{
		Vector3D vector = p2 - p1;
		double height = SharedFunctions.Length(ref vector);
		vector.Normalize();
		AddCone(p1, vector, radius, radius, height, cap1, cap2, thetaDiv);
	}

	public void AddDodecahedron(Point3D center, Vector3D forward, Vector3D up, double sideLength)
	{
		int count = positions.Count;
		Vector3D second = SharedFunctions.CrossProduct(ref up, ref forward);
		double num = 0.25 * Math.Sqrt(3.0) * (1.0 + Math.Sqrt(5.0)) * sideLength;
		double num2 = 0.10000000149011612 * Math.Sqrt(50.0 + 10.0 * Math.Sqrt(5.0)) * sideLength;
		double num3 = Math.Sqrt(num * num - num2 * num2);
		Point3D point3D = center - up * num3;
		IList<Point> circle = GetCircle(5, closed: true);
		List<Point3D> list = new List<Point3D>();
		foreach (Point item2 in circle)
		{
			Point3D point3D2 = point3D + forward * item2.X * num2 + second * item2.Y * num2;
			list.Add(point3D2);
			positions.Add(point3D2);
		}
		double num4 = Math.Acos(1.0 - sideLength * sideLength / (2.0 * num * num));
		foreach (Point3D item3 in list)
		{
			Vector3D second2 = item3 - point3D;
			second2.Normalize();
			Vector3D first = item3 - center;
			first.Normalize();
			Vector3D second3 = SharedFunctions.CrossProduct(ref up, ref second2);
			Point3D point3D3 = new Point3D(num * Math.Cos(num4), 0.0, num * Math.Sin(num4));
			Vector3D vector3D = SharedFunctions.CrossProduct(ref first, ref second3);
			positions.Add(center + first * point3D3.X + vector3D * point3D3.Z);
		}
		Point3D point3D4 = center + up * num3;
		List<Point3D> list2 = new List<Point3D>();
		foreach (Point item4 in circle)
		{
			Point3D item = point3D4 - forward * item4.X * num2 + second * item4.Y * num2;
			list2.Add(item);
		}
		foreach (Point3D item5 in list2)
		{
			Vector3D second4 = item5 - point3D4;
			second4.Normalize();
			Vector3D second5 = item5 - center;
			second5.Normalize();
			Vector3D first2 = SharedFunctions.CrossProduct(ref up, ref second4);
			Point3D point3D5 = new Point3D(num * Math.Cos(num4), 0.0, num * Math.Sin(num4));
			Vector3D vector3D2 = SharedFunctions.CrossProduct(ref first2, ref second5);
			positions.Add(center + second5 * point3D5.X + vector3D2 * point3D5.Z);
		}
		foreach (Point3D item6 in list2)
		{
			positions.Add(item6);
		}
		if (normals != null)
		{
			for (int i = count; i < positions.Count; i++)
			{
				Vector3D value = positions[i] - center;
				value.Normalize();
				normals.Add(value);
			}
		}
		if (textureCoordinates != null)
		{
			for (int j = count; j < positions.Count; j++)
			{
				Vector3D first3 = positions[j] - center;
				first3.Normalize();
				double num5 = SharedFunctions.DotProduct(ref first3, ref up);
				Vector3D first4 = first3 - up * num5;
				first4.Normalize();
				double x = Math.Atan2(SharedFunctions.DotProduct(ref first4, ref forward), SharedFunctions.DotProduct(ref first4, ref second));
				double y = num5 * 0.5 + 0.5;
				textureCoordinates.Add(new Point(x, y));
			}
		}
		AddPolygonByTriangulation(positions.Skip(count).Take(5).Select((Point3D p, int result) => result)
			.ToList());
		AddPolygonByTriangulation(positions.Skip(count + 15).Select((Point3D p, int num7) => 15 + num7).ToList());
		for (int num6 = 0; num6 < 5; num6++)
		{
			List<int> vertexIndices = new List<int>
			{
				(num6 + 1) % 5 + count,
				num6,
				num6 + 5 + count,
				(5 - num6 + 2) % 5 + 10 + count,
				(num6 + 1) % 5 + 5 + count
			};
			AddPolygonByTriangulation(vertexIndices);
			vertexIndices = new List<int>
			{
				num6 + 15 + count,
				num6 + 10 + count,
				(5 - num6 + 2) % 5 + 5 + count,
				(num6 + 1) % 5 + 10 + count,
				(num6 + 1) % 5 + 15 + count
			};
			AddPolygonByTriangulation(vertexIndices);
		}
	}

	public void AddEdges(IList<Point3D> points, IList<int> edges, double diameter, int thetaDiv)
	{
		for (int i = 0; i < edges.Count - 1; i += 2)
		{
			AddCylinder(points[edges[i]], points[edges[i + 1]], diameter, thetaDiv);
		}
	}

	public void AddEllipsoid(Point3D center, double radiusx, double radiusy, double radiusz, int thetaDiv = 20, int phiDiv = 10)
	{
		int count = Positions.Count;
		double num = Math.PI * 2.0 / (double)thetaDiv;
		double num2 = Math.PI / (double)phiDiv;
		for (int i = 0; i <= phiDiv; i++)
		{
			double num3 = (double)i * num2;
			for (int j = 0; j <= thetaDiv; j++)
			{
				double num4 = (double)j * num;
				double num5 = Math.Cos(num4) * Math.Sin(num3);
				double num6 = Math.Sin(num4) * Math.Sin(num3);
				double num7 = Math.Cos(num3);
				Point3D value = new Point3D(center.X + radiusx * num5, center.Y + radiusy * num6, center.Z + radiusz * num7);
				positions.Add(value);
				if (normals != null)
				{
					Vector3D value2 = new Vector3D(num5, num6, num7);
					normals.Add(value2);
				}
				if (textureCoordinates != null)
				{
					Point value3 = new Point(num4 / (Math.PI * 2.0), num3 / Math.PI);
					textureCoordinates.Add(value3);
				}
			}
		}
		AddRectangularMeshTriangleIndices(count, phiDiv + 1, thetaDiv + 1, isSpherical: true);
	}

	public void AddExtrudedGeometry(IList<Point> points, Vector3D xaxis, Point3D p0, Point3D p1)
	{
		Vector3D second = p1 - p0;
		Vector3D vector3D = SharedFunctions.CrossProduct(ref xaxis, ref second);
		vector3D.Normalize();
		xaxis.Normalize();
		int count = positions.Count;
		int num = 2 * points.Count;
		foreach (Point point in points)
		{
			Vector3D vector3D2 = xaxis * point.X + vector3D * point.Y;
			positions.Add(p0 + vector3D2);
			positions.Add(p1 + vector3D2);
			vector3D2.Normalize();
			if (normals != null)
			{
				normals.Add(vector3D2);
				normals.Add(vector3D2);
			}
			if (textureCoordinates != null)
			{
				textureCoordinates.Add(new Point(0.0, 0.0));
				textureCoordinates.Add(new Point(1.0, 0.0));
			}
			int value = count + 1;
			int value2 = (count + 2) % num;
			int value3 = (count + 2) % num + 1;
			triangleIndices.Add(value);
			triangleIndices.Add(value2);
			triangleIndices.Add(count);
			triangleIndices.Add(value);
			triangleIndices.Add(value3);
			triangleIndices.Add(value2);
		}
		ComputeNormals(positions, triangleIndices, out normals);
	}

	public void AddFacePZ()
	{
		Point3D[] array = new Point3D[4]
		{
			new Point3D(0.0, 0.0, 1.0),
			new Point3D(0.0, 1.0, 1.0),
			new Point3D(1.0, 1.0, 1.0),
			new Point3D(1.0, 0.0, 1.0)
		};
		Vector3D[] array2 = new Vector3D[4]
		{
			new Vector3D(0.0, 0.0, 1.0),
			new Vector3D(0.0, 0.0, 1.0),
			new Vector3D(0.0, 0.0, 1.0),
			new Vector3D(0.0, 0.0, 1.0)
		};
		int count = positions.Count;
		int[] array3 = new int[6]
		{
			count,
			count + 3,
			count + 2,
			count,
			count + 2,
			count + 1
		};
		Point[] array4 = new Point[4]
		{
			new Point(0.0, 1.0),
			new Point(1.0, 1.0),
			new Point(1.0, 0.0),
			new Point(0.0, 0.0)
		};
		Point3D[] array5 = array;
		foreach (Point3D value in array5)
		{
			positions.Add(value);
		}
		Vector3D[] array6 = array2;
		foreach (Vector3D value2 in array6)
		{
			normals.Add(value2);
		}
		int[] array7 = array3;
		foreach (int value3 in array7)
		{
			triangleIndices.Add(value3);
		}
		Point[] array8 = array4;
		foreach (Point value4 in array8)
		{
			textureCoordinates.Add(value4);
		}
	}

	public void AddFaceNZ()
	{
		Point3D[] array = new Point3D[4]
		{
			new Point3D(0.0, 1.0, 0.0),
			new Point3D(0.0, 0.0, 0.0),
			new Point3D(1.0, 0.0, 0.0),
			new Point3D(1.0, 1.0, 0.0)
		};
		Vector3D[] array2 = new Vector3D[4]
		{
			-new Vector3D(0.0, 0.0, 1.0),
			-new Vector3D(0.0, 0.0, 1.0),
			-new Vector3D(0.0, 0.0, 1.0),
			-new Vector3D(0.0, 0.0, 1.0)
		};
		int count = positions.Count;
		int[] array3 = new int[6]
		{
			count,
			count + 3,
			count + 2,
			count,
			count + 2,
			count + 1
		};
		Point[] array4 = new Point[4]
		{
			new Point(0.0, 1.0),
			new Point(1.0, 1.0),
			new Point(1.0, 0.0),
			new Point(0.0, 0.0)
		};
		Point3D[] array5 = array;
		foreach (Point3D value in array5)
		{
			positions.Add(value);
		}
		Vector3D[] array6 = array2;
		foreach (Vector3D value2 in array6)
		{
			normals.Add(value2);
		}
		int[] array7 = array3;
		foreach (int value3 in array7)
		{
			triangleIndices.Add(value3);
		}
		Point[] array8 = array4;
		foreach (Point value4 in array8)
		{
			textureCoordinates.Add(value4);
		}
	}

	public void AddFacePX()
	{
		Point3D[] array = new Point3D[4]
		{
			new Point3D(1.0, 0.0, 0.0),
			new Point3D(1.0, 0.0, 1.0),
			new Point3D(1.0, 1.0, 1.0),
			new Point3D(1.0, 1.0, 0.0)
		};
		Vector3D[] array2 = new Vector3D[4]
		{
			new Vector3D(1.0, 0.0, 0.0),
			new Vector3D(1.0, 0.0, 0.0),
			new Vector3D(1.0, 0.0, 0.0),
			new Vector3D(1.0, 0.0, 0.0)
		};
		int count = positions.Count;
		int[] array3 = new int[6]
		{
			count,
			count + 3,
			count + 2,
			count,
			count + 2,
			count + 1
		};
		Point[] array4 = new Point[4]
		{
			new Point(0.0, 1.0),
			new Point(1.0, 1.0),
			new Point(1.0, 0.0),
			new Point(0.0, 0.0)
		};
		Point3D[] array5 = array;
		foreach (Point3D value in array5)
		{
			positions.Add(value);
		}
		Vector3D[] array6 = array2;
		foreach (Vector3D value2 in array6)
		{
			normals.Add(value2);
		}
		int[] array7 = array3;
		foreach (int value3 in array7)
		{
			triangleIndices.Add(value3);
		}
		Point[] array8 = array4;
		foreach (Point value4 in array8)
		{
			textureCoordinates.Add(value4);
		}
	}

	public void AddFaceNX()
	{
		Point3D[] array = new Point3D[4]
		{
			new Point3D(0.0, 0.0, 1.0),
			new Point3D(0.0, 0.0, 0.0),
			new Point3D(0.0, 1.0, 0.0),
			new Point3D(0.0, 1.0, 1.0)
		};
		Vector3D[] array2 = new Vector3D[4]
		{
			-new Vector3D(1.0, 0.0, 0.0),
			-new Vector3D(1.0, 0.0, 0.0),
			-new Vector3D(1.0, 0.0, 0.0),
			-new Vector3D(1.0, 0.0, 0.0)
		};
		int count = positions.Count;
		int[] array3 = new int[6]
		{
			count,
			count + 3,
			count + 2,
			count,
			count + 2,
			count + 1
		};
		Point[] array4 = new Point[4]
		{
			new Point(0.0, 1.0),
			new Point(1.0, 1.0),
			new Point(1.0, 0.0),
			new Point(0.0, 0.0)
		};
		Point3D[] array5 = array;
		foreach (Point3D value in array5)
		{
			positions.Add(value);
		}
		Vector3D[] array6 = array2;
		foreach (Vector3D value2 in array6)
		{
			normals.Add(value2);
		}
		int[] array7 = array3;
		foreach (int value3 in array7)
		{
			triangleIndices.Add(value3);
		}
		Point[] array8 = array4;
		foreach (Point value4 in array8)
		{
			textureCoordinates.Add(value4);
		}
	}

	public void AddFacePY()
	{
		Point3D[] array = new Point3D[4]
		{
			new Point3D(1.0, 1.0, 0.0),
			new Point3D(1.0, 1.0, 1.0),
			new Point3D(0.0, 1.0, 1.0),
			new Point3D(0.0, 1.0, 0.0)
		};
		Vector3D[] array2 = new Vector3D[4]
		{
			new Vector3D(0.0, 1.0, 0.0),
			new Vector3D(0.0, 1.0, 0.0),
			new Vector3D(0.0, 1.0, 0.0),
			new Vector3D(0.0, 1.0, 0.0)
		};
		int count = positions.Count;
		int[] array3 = new int[6]
		{
			count,
			count + 3,
			count + 2,
			count,
			count + 2,
			count + 1
		};
		Point[] array4 = new Point[4]
		{
			new Point(0.0, 1.0),
			new Point(1.0, 1.0),
			new Point(1.0, 0.0),
			new Point(0.0, 0.0)
		};
		Point3D[] array5 = array;
		foreach (Point3D value in array5)
		{
			positions.Add(value);
		}
		Vector3D[] array6 = array2;
		foreach (Vector3D value2 in array6)
		{
			normals.Add(value2);
		}
		int[] array7 = array3;
		foreach (int value3 in array7)
		{
			triangleIndices.Add(value3);
		}
		Point[] array8 = array4;
		foreach (Point value4 in array8)
		{
			textureCoordinates.Add(value4);
		}
	}

	public void AddFaceNY()
	{
		Point3D[] array = new Point3D[4]
		{
			new Point3D(0.0, 0.0, 0.0),
			new Point3D(0.0, 0.0, 1.0),
			new Point3D(1.0, 0.0, 1.0),
			new Point3D(1.0, 0.0, 0.0)
		};
		Vector3D[] array2 = new Vector3D[4]
		{
			-new Vector3D(0.0, 1.0, 0.0),
			-new Vector3D(0.0, 1.0, 0.0),
			-new Vector3D(0.0, 1.0, 0.0),
			-new Vector3D(0.0, 1.0, 0.0)
		};
		int count = positions.Count;
		int[] array3 = new int[6]
		{
			count,
			count + 3,
			count + 2,
			count,
			count + 2,
			count + 1
		};
		Point[] array4 = new Point[4]
		{
			new Point(0.0, 1.0),
			new Point(1.0, 1.0),
			new Point(1.0, 0.0),
			new Point(0.0, 0.0)
		};
		Point3D[] array5 = array;
		foreach (Point3D value in array5)
		{
			positions.Add(value);
		}
		Vector3D[] array6 = array2;
		foreach (Vector3D value2 in array6)
		{
			normals.Add(value2);
		}
		int[] array7 = array3;
		foreach (int value3 in array7)
		{
			triangleIndices.Add(value3);
		}
		Point[] array8 = array4;
		foreach (Point value4 in array8)
		{
			textureCoordinates.Add(value4);
		}
	}

	public void AddExtrudedSegments(IList<Point> points, Vector3D axisX, Point3D p0, Point3D p1)
	{
		if (points.Count % 2 != 0)
		{
			throw new InvalidOperationException("The number of points should be even.");
		}
		Vector3D second = p1 - p0;
		Vector3D vector3D = SharedFunctions.CrossProduct(ref axisX, ref second);
		vector3D.Normalize();
		axisX.Normalize();
		int count = positions.Count;
		for (int i = 0; i < points.Count; i++)
		{
			Point point = points[i];
			Vector3D vector3D2 = axisX * point.X + vector3D * point.Y;
			positions.Add(p0 + vector3D2);
			positions.Add(p1 + vector3D2);
			if (normals != null)
			{
				vector3D2.Normalize();
				normals.Add(vector3D2);
				normals.Add(vector3D2);
			}
			if (textureCoordinates != null)
			{
				double y = (double)i / (double)(points.Count - 1);
				textureCoordinates.Add(new Point(0.0, y));
				textureCoordinates.Add(new Point(1.0, y));
			}
		}
		int num = points.Count - 1;
		for (int j = 0; j < num; j++)
		{
			int num2 = count + j * 2;
			int value = num2 + 1;
			int value2 = num2 + 3;
			int value3 = num2 + 2;
			triangleIndices.Add(num2);
			triangleIndices.Add(value);
			triangleIndices.Add(value2);
			triangleIndices.Add(value2);
			triangleIndices.Add(value3);
			triangleIndices.Add(num2);
		}
	}

	public void AddLoftedGeometry(IList<IList<Point3D>> positionsList, IList<IList<Vector3D>> normalList, IList<IList<Point>> textureCoordinateList)
	{
		int count = positions.Count;
		int num = -1;
		for (int i = 0; i < positionsList.Count; i++)
		{
			IList<Point3D> list = positionsList[i];
			if (num == -1)
			{
				num = list.Count;
			}
			if (list.Count != num)
			{
				throw new InvalidOperationException("All curves should have the same number of points");
			}
			foreach (Point3D item in list)
			{
				positions.Add(item);
			}
			if (normals != null && normalList != null)
			{
				IList<Vector3D> list2 = normalList[i];
				foreach (Vector3D item2 in list2)
				{
					normals.Add(item2);
				}
			}
			if (textureCoordinates == null || textureCoordinateList == null)
			{
				continue;
			}
			IList<Point> list3 = textureCoordinateList[i];
			foreach (Point item3 in list3)
			{
				textureCoordinates.Add(item3);
			}
		}
		for (int j = 0; j + 1 < positionsList.Count; j++)
		{
			for (int k = 0; k + 1 < num; k++)
			{
				int num2 = count + j * num + k;
				int num3 = num2 + num;
				int value = num3 + 1;
				int value2 = num2 + 1;
				triangleIndices.Add(num2);
				triangleIndices.Add(num3);
				triangleIndices.Add(value);
				triangleIndices.Add(value);
				triangleIndices.Add(value2);
				triangleIndices.Add(num2);
			}
		}
	}

	public void AddNode(Point3D position, Vector3D normal, Point textureCoordinate)
	{
		positions.Add(position);
		if (normals != null)
		{
			normals.Add(normal);
		}
		if (textureCoordinates != null)
		{
			textureCoordinates.Add(textureCoordinate);
		}
	}

	public void AddOctahedron(Point3D center, Vector3D forward, Vector3D up, double sideLength, double height)
	{
		Vector3D vector3D = SharedFunctions.CrossProduct(ref forward, ref up);
		Vector3D vector3D2 = forward * sideLength / 2.0;
		up *= height / 2.0;
		vector3D *= sideLength / 2.0;
		Point3D point3D = center - vector3D2 - up - vector3D;
		Point3D point3D2 = center - vector3D2 - up + vector3D;
		Point3D point3D3 = center + vector3D2 - up + vector3D;
		Point3D point3D4 = center + vector3D2 - up - vector3D;
		Point3D p = center + up;
		Point3D p2 = center - up;
		AddTriangle(point3D, point3D2, p);
		AddTriangle(point3D2, point3D3, p);
		AddTriangle(point3D3, point3D4, p);
		AddTriangle(point3D4, point3D, p);
		AddTriangle(point3D2, point3D, p2);
		AddTriangle(point3D3, point3D2, p2);
		AddTriangle(point3D4, point3D3, p2);
		AddTriangle(point3D, point3D4, p2);
	}

	public void AddPipe(Point3D point1, Point3D point2, double innerDiameter, double diameter, int thetaDiv)
	{
		Vector3D vector = point2 - point1;
		double x = SharedFunctions.Length(ref vector);
		vector.Normalize();
		PointCollection pointCollection = new PointCollection
		{
			new Point(0.0, innerDiameter / 2.0),
			new Point(0.0, diameter / 2.0),
			new Point(x, diameter / 2.0),
			new Point(x, innerDiameter / 2.0)
		};
		List<double> list = new List<double> { 1.0, 0.0, 1.0, 0.0 };
		if (innerDiameter > 0.0)
		{
			pointCollection.Add(new Point(0.0, innerDiameter / 2.0));
			list.Add(1.0);
		}
		AddRevolvedGeometry(pointCollection, list, point1, vector, thetaDiv);
	}

	public void AddPipes(IList<Vector3D> points, IList<int> edges, double diameter = 1.0, int thetaDiv = 32)
	{
		for (int i = 0; i < edges.Count - 1; i += 2)
		{
			AddCylinder((Point3D)points[edges[i]], (Point3D)points[edges[i + 1]], diameter, thetaDiv);
		}
	}

	public void AddPolygon(IList<Point> points, Vector3D axisX, Vector3D axisY, Point3D origin)
	{
		Int32Collection int32Collection = SweepLinePolygonTriangulator.Triangulate(points);
		int count = positions.Count;
		foreach (Point point in points)
		{
			positions.Add(origin + axisX * point.X + axisY * point.Y);
		}
		foreach (int item in int32Collection)
		{
			triangleIndices.Add(count + item);
		}
	}

	public void AddPolygon(IList<Point3D> points)
	{
		switch (points.Count)
		{
		case 3:
			AddTriangle(points[0], points[1], points[2]);
			break;
		case 4:
			AddQuad(points[0], points[1], points[2], points[3]);
			break;
		default:
			AddTriangleFan(points);
			break;
		}
	}

	public void AddPolygon(IList<int> vertexIndices)
	{
		int count = vertexIndices.Count;
		for (int i = 0; i + 2 < count; i++)
		{
			triangleIndices.Add(vertexIndices[0]);
			triangleIndices.Add(vertexIndices[i + 1]);
			triangleIndices.Add(vertexIndices[i + 2]);
		}
	}

	[Obsolete("Please use the faster version AddPolygon instead")]
	public void AddPolygonByCuttingEars(IList<int> vertexIndices)
	{
		List<Point3D> pts = vertexIndices.Select((int vi) => positions[vi]).ToList();
		Polygon3D polygon3D = new Polygon3D(pts);
		Polygon polygon = polygon3D.Flatten();
		Int32Collection int32Collection = CuttingEarsTriangulator.Triangulate(polygon.Points);
		if (int32Collection == null)
		{
			return;
		}
		foreach (int item in int32Collection)
		{
			triangleIndices.Add(vertexIndices[item]);
		}
	}

	public void AddPolygonByTriangulation(IList<int> vertexIndices)
	{
		List<Point3D> pts = vertexIndices.Select((int vi) => positions[vi]).ToList();
		Polygon3D polygon3D = new Polygon3D(pts);
		Polygon polygon = polygon3D.Flatten();
		Int32Collection int32Collection = polygon.Triangulate();
		if (int32Collection == null)
		{
			return;
		}
		foreach (int item in int32Collection)
		{
			triangleIndices.Add(vertexIndices[item]);
		}
	}

	public void AddPyramid(Point3D center, double sideLength, double height, bool closeBase = false)
	{
		AddPyramid(center, new Vector3D(1.0, 0.0, 0.0), new Vector3D(0.0, 0.0, 1.0), sideLength, height, closeBase);
	}

	public void AddPyramid(Point3D center, Vector3D forward, Vector3D up, double sideLength, double height, bool closeBase = false)
	{
		Vector3D vector3D = SharedFunctions.CrossProduct(ref forward, ref up);
		Vector3D vector3D2 = forward * sideLength / 2.0;
		up *= height;
		vector3D *= sideLength / 2.0;
		Vector3D vector3D3 = -up * 1.0 / 3.0;
		Vector3D vector3D4 = up * 2.0 / 3.0;
		Point3D point3D = center - vector3D2 - vector3D + vector3D3;
		Point3D point3D2 = center - vector3D2 + vector3D + vector3D3;
		Point3D point3D3 = center + vector3D2 + vector3D + vector3D3;
		Point3D point3D4 = center + vector3D2 - vector3D + vector3D3;
		Point3D p = center + vector3D4;
		AddTriangle(point3D, point3D2, p);
		AddTriangle(point3D2, point3D3, p);
		AddTriangle(point3D3, point3D4, p);
		AddTriangle(point3D4, point3D, p);
		if (closeBase)
		{
			AddTriangle(point3D, point3D3, point3D2);
			AddTriangle(point3D3, point3D, point3D4);
		}
	}

	public void AddQuad(IList<int> vertexIndices)
	{
		for (int i = 0; i < 4; i++)
		{
			triangleIndices.Add(vertexIndices[i]);
		}
	}

	public void AddQuad(Point3D p0, Point3D p1, Point3D p2, Point3D p3)
	{
		Point uv = new Point(0.0, 0.0);
		Point uv2 = new Point(1.0, 0.0);
		Point uv3 = new Point(1.0, 1.0);
		Point uv4 = new Point(0.0, 1.0);
		AddQuad(p0, p1, p2, p3, uv, uv2, uv3, uv4);
	}

	public void AddQuad(Point3D p0, Point3D p1, Point3D p2, Point3D p3, Point uv0, Point uv1, Point uv2, Point uv3)
	{
		int count = positions.Count;
		positions.Add(p0);
		positions.Add(p1);
		positions.Add(p2);
		positions.Add(p3);
		if (textureCoordinates != null)
		{
			textureCoordinates.Add(uv0);
			textureCoordinates.Add(uv1);
			textureCoordinates.Add(uv2);
			textureCoordinates.Add(uv3);
		}
		if (normals != null)
		{
			Vector3D first = p1 - p0;
			Vector3D second = p3 - p0;
			Vector3D value = SharedFunctions.CrossProduct(ref first, ref second);
			value.Normalize();
			normals.Add(value);
			normals.Add(value);
			normals.Add(value);
			normals.Add(value);
		}
		triangleIndices.Add(count);
		triangleIndices.Add(count + 1);
		triangleIndices.Add(count + 2);
		triangleIndices.Add(count + 2);
		triangleIndices.Add(count + 3);
		triangleIndices.Add(count);
	}

	public void AddQuads(IList<Point3D> quadPositions, IList<Vector3D> quadNormals, IList<Point> quadTextureCoordinates)
	{
		if (quadPositions == null)
		{
			throw new ArgumentNullException("quadPositions");
		}
		if (normals != null && quadNormals == null)
		{
			throw new ArgumentNullException("quadNormals");
		}
		if (textureCoordinates != null && quadTextureCoordinates == null)
		{
			throw new ArgumentNullException("quadTextureCoordinates");
		}
		if (quadNormals != null && quadNormals.Count != quadPositions.Count)
		{
			throw new InvalidOperationException("Wrong number of normals.");
		}
		if (quadTextureCoordinates != null && quadTextureCoordinates.Count != quadPositions.Count)
		{
			throw new InvalidOperationException("Wrong number of texture coordinates.");
		}
		Debug.Assert(quadPositions.Count > 0 && quadPositions.Count % 4 == 0, "Wrong number of positions.");
		int count = positions.Count;
		foreach (Point3D quadPosition in quadPositions)
		{
			positions.Add(quadPosition);
		}
		if (textureCoordinates != null && quadTextureCoordinates != null)
		{
			foreach (Point quadTextureCoordinate in quadTextureCoordinates)
			{
				textureCoordinates.Add(quadTextureCoordinate);
			}
		}
		if (normals != null && quadNormals != null)
		{
			foreach (Vector3D quadNormal in quadNormals)
			{
				normals.Add(quadNormal);
			}
		}
		int count2 = positions.Count;
		for (int i = count; i + 3 < count2; i++)
		{
			triangleIndices.Add(i);
			triangleIndices.Add(i + 1);
			triangleIndices.Add(i + 2);
			triangleIndices.Add(i + 2);
			triangleIndices.Add(i + 3);
			triangleIndices.Add(i);
		}
	}

	public void AddRectangularMesh(IList<Point3D> points, int columns)
	{
		if (points == null)
		{
			throw new ArgumentNullException("points");
		}
		int count = Positions.Count;
		foreach (Point3D point in points)
		{
			positions.Add(point);
		}
		int rows = points.Count / columns;
		AddRectangularMeshTriangleIndices(count, rows, columns);
		if (normals != null)
		{
			AddRectangularMeshNormals(count, rows, columns);
		}
		if (textureCoordinates != null)
		{
			AddRectangularMeshTextureCoordinates(rows, columns);
		}
	}

	public void AddRectangularMesh(Point3D[,] points, Point[,] texCoords = null, bool closed0 = false, bool closed1 = false)
	{
		if (points == null)
		{
			throw new ArgumentNullException("points");
		}
		int num = points.GetUpperBound(0) + 1;
		int num2 = points.GetUpperBound(1) + 1;
		int count = positions.Count;
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < num2; j++)
			{
				positions.Add(points[i, j]);
			}
		}
		AddRectangularMeshTriangleIndices(count, num, num2, closed0, closed1);
		if (normals != null)
		{
			AddRectangularMeshNormals(count, num, num2);
		}
		if (textureCoordinates == null)
		{
			return;
		}
		if (texCoords != null)
		{
			for (int k = 0; k < num; k++)
			{
				for (int l = 0; l < num2; l++)
				{
					textureCoordinates.Add(texCoords[k, l]);
				}
			}
		}
		else
		{
			AddRectangularMeshTextureCoordinates(num, num2);
		}
	}

	public void AddRectangularMesh(IList<Point3D> points, int columns, bool flipTriangles = false)
	{
		if (points == null)
		{
			throw new ArgumentNullException("points");
		}
		int count = positions.Count;
		foreach (Point3D point in points)
		{
			positions.Add(point);
		}
		int rows = points.Count / columns;
		if (flipTriangles)
		{
			AddRectangularMeshTriangleIndicesFlipped(count, rows, columns);
		}
		else
		{
			AddRectangularMeshTriangleIndices(count, rows, columns);
		}
		if (normals != null)
		{
			AddRectangularMeshNormals(count, rows, columns);
		}
		if (textureCoordinates != null)
		{
			AddRectangularMeshTextureCoordinates(rows, columns);
		}
	}

	public void AddRectangularMesh(BoxFaces plane, int columns, int rows, double width, double height, bool flipTriangles = false, bool flipTexCoordsUAxis = false, bool flipTexCoordsVAxis = false)
	{
		if (columns < 2 || rows < 2)
		{
			throw new ArgumentNullException("columns or rows too small");
		}
		if (width <= 0.0 || height <= 0.0)
		{
			throw new ArgumentNullException("width or height too small");
		}
		int count = positions.Count;
		double num = height / (double)(rows - 1);
		double num2 = width / (double)(columns - 1);
		for (int i = 0; i < rows; i++)
		{
			for (int j = 0; j < columns; j++)
			{
				positions.Add(new Point3D((double)j * num2, (double)i * num, 0.0));
			}
		}
		if (flipTriangles)
		{
			AddRectangularMeshTriangleIndicesFlipped(count, rows, columns);
		}
		else
		{
			AddRectangularMeshTriangleIndices(count, rows, columns);
		}
		if (normals != null)
		{
			AddRectangularMeshNormals(count, rows, columns);
		}
		if (textureCoordinates != null)
		{
			AddRectangularMeshTextureCoordinates(rows, columns, flipTexCoordsVAxis, flipTexCoordsUAxis);
		}
	}

	private void AddRectangularMeshNormals(int index0, int rows, int columns)
	{
		for (int i = 0; i < rows; i++)
		{
			int num = i + 1;
			if (num == rows)
			{
				num--;
			}
			int num2 = num - 1;
			for (int j = 0; j < columns; j++)
			{
				int num3 = j + 1;
				if (num3 == columns)
				{
					num3--;
				}
				int num4 = num3 - 1;
				Vector3D first = Point3D.Subtract(positions[index0 + num * columns + num4], positions[index0 + num2 * columns + num4]);
				Vector3D second = Point3D.Subtract(positions[index0 + num2 * columns + num3], positions[index0 + num2 * columns + num4]);
				Vector3D value = SharedFunctions.CrossProduct(ref first, ref second);
				value.Normalize();
				normals.Add(value);
			}
		}
	}

	private void AddRectangularMeshTextureCoordinates(int rows, int columns, bool flipRowsAxis = false, bool flipColumnsAxis = false)
	{
		for (int i = 0; i < rows; i++)
		{
			double y = (flipRowsAxis ? (1.0 - (double)i / (double)(rows - 1)) : ((double)i / (double)(rows - 1)));
			for (int j = 0; j < columns; j++)
			{
				double x = (flipColumnsAxis ? (1.0 - (double)j / (double)(columns - 1)) : ((double)j / (double)(columns - 1)));
				textureCoordinates.Add(new Point(x, y));
			}
		}
	}

	public void AddRectangularMeshTriangleIndices(int index0, int rows, int columns, bool isSpherical = false)
	{
		for (int i = 0; i < rows - 1; i++)
		{
			for (int j = 0; j < columns - 1; j++)
			{
				int num = i * columns + j;
				if (!isSpherical || i > 0)
				{
					triangleIndices.Add(index0 + num);
					triangleIndices.Add(index0 + num + 1 + columns);
					triangleIndices.Add(index0 + num + 1);
				}
				if (!isSpherical || i < rows - 2)
				{
					triangleIndices.Add(index0 + num + 1 + columns);
					triangleIndices.Add(index0 + num);
					triangleIndices.Add(index0 + num + columns);
				}
			}
		}
	}

	public void AddRectangularMeshTriangleIndices(int index0, int rows, int columns, bool rowsClosed, bool columnsClosed)
	{
		int num = rows - 1;
		int num2 = columns - 1;
		if (columnsClosed)
		{
			num++;
		}
		if (rowsClosed)
		{
			num2++;
		}
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < num2; j++)
			{
				int value = index0 + i * columns + j;
				int value2 = index0 + i * columns + (j + 1) % columns;
				int value3 = index0 + (i + 1) % rows * columns + j;
				int value4 = index0 + (i + 1) % rows * columns + (j + 1) % columns;
				triangleIndices.Add(value);
				triangleIndices.Add(value4);
				triangleIndices.Add(value2);
				triangleIndices.Add(value4);
				triangleIndices.Add(value);
				triangleIndices.Add(value3);
			}
		}
	}

	private void AddRectangularMeshTriangleIndicesFlipped(int index0, int rows, int columns, bool isSpherical = false)
	{
		for (int i = 0; i < rows - 1; i++)
		{
			for (int j = 0; j < columns - 1; j++)
			{
				int num = i * columns + j;
				if (!isSpherical || i > 0)
				{
					triangleIndices.Add(index0 + num);
					triangleIndices.Add(index0 + num + 1);
					triangleIndices.Add(index0 + num + 1 + columns);
				}
				if (!isSpherical || i < rows - 2)
				{
					triangleIndices.Add(index0 + num + 1 + columns);
					triangleIndices.Add(index0 + num + columns);
					triangleIndices.Add(index0 + num);
				}
			}
		}
	}

	public void AddRegularIcosahedron(Point3D center, double radius, bool shareVertices)
	{
		double num = Math.Sqrt(2.0 / (5.0 + Math.Sqrt(5.0)));
		double num2 = Math.Sqrt(2.0 / (5.0 - Math.Sqrt(5.0)));
		int[] array = new int[60]
		{
			1, 4, 0, 4, 9, 0, 4, 5, 9, 8,
			5, 4, 1, 8, 4, 1, 10, 8, 10, 3,
			8, 8, 3, 5, 3, 2, 5, 3, 7, 2,
			3, 10, 7, 10, 6, 7, 6, 11, 7, 6,
			0, 11, 6, 1, 0, 10, 1, 6, 11, 0,
			9, 2, 11, 9, 5, 2, 9, 11, 2, 7
		};
		Vector3D[] array2 = new Vector3D[12]
		{
			new Vector3D(0.0 - num, 0.0, num2),
			new Vector3D(num, 0.0, num2),
			new Vector3D(0.0 - num, 0.0, 0.0 - num2),
			new Vector3D(num, 0.0, 0.0 - num2),
			new Vector3D(0.0, num2, num),
			new Vector3D(0.0, num2, 0.0 - num),
			new Vector3D(0.0, 0.0 - num2, num),
			new Vector3D(0.0, 0.0 - num2, 0.0 - num),
			new Vector3D(num2, num, 0.0),
			new Vector3D(0.0 - num2, num, 0.0),
			new Vector3D(num2, 0.0 - num, 0.0),
			new Vector3D(0.0 - num2, 0.0 - num, 0.0)
		};
		if (shareVertices)
		{
			int count = positions.Count;
			Vector3D[] array3 = array2;
			foreach (Vector3D vector3D in array3)
			{
				positions.Add(center + vector3D * radius);
			}
			int[] array4 = array;
			foreach (int num3 in array4)
			{
				triangleIndices.Add(count + num3);
			}
		}
		else
		{
			for (int k = 0; k + 2 < array.Length; k += 3)
			{
				AddTriangle(center + array2[array[k]] * radius, center + array2[array[k + 1]] * radius, center + array2[array[k + 2]] * radius);
			}
		}
	}

	public void AddRevolvedGeometry(IList<Point> points, IList<double> textureValues, Point3D origin, Vector3D direction, int thetaDiv)
	{
		direction.Normalize();
		Vector3D second = direction.FindAnyPerpendicular();
		Vector3D vector3D = SharedFunctions.CrossProduct(ref direction, ref second);
		second.Normalize();
		vector3D.Normalize();
		IList<Point> circle = GetCircle(thetaDiv);
		int count = positions.Count;
		int count2 = points.Count;
		int num = (points.Count - 1) * 2 * thetaDiv;
		int num2 = (points.Count - 1) * 2;
		for (int i = 0; i < thetaDiv; i++)
		{
			Vector3D vector3D2 = vector3D * circle[i].X + second * circle[i].Y;
			for (int j = 0; j + 1 < count2; j++)
			{
				Point3D value = origin + direction * points[j].X + vector3D2 * points[j].Y;
				Point3D value2 = origin + direction * points[j + 1].X + vector3D2 * points[j + 1].Y;
				positions.Add(value);
				positions.Add(value2);
				if (normals != null)
				{
					double num3 = points[j + 1].X - points[j].X;
					double num4 = points[j + 1].Y - points[j].Y;
					Vector3D value3 = -direction * num4 + vector3D2 * num3;
					value3.Normalize();
					normals.Add(value3);
					normals.Add(value3);
				}
				if (textureCoordinates != null)
				{
					textureCoordinates.Add(new Point((double)i / (double)(thetaDiv - 1), (textureValues == null) ? ((double)j / (double)(count2 - 1)) : textureValues[j]));
					textureCoordinates.Add(new Point((double)i / (double)(thetaDiv - 1), (textureValues == null) ? ((double)(j + 1) / (double)(count2 - 1)) : textureValues[j + 1]));
				}
				int num5 = count + i * num2 + j * 2;
				int value4 = num5 + 1;
				int num6 = count + ((i + 1) * num2 + j * 2) % num;
				int value5 = num6 + 1;
				triangleIndices.Add(value4);
				triangleIndices.Add(num5);
				triangleIndices.Add(num6);
				triangleIndices.Add(value4);
				triangleIndices.Add(num6);
				triangleIndices.Add(value5);
			}
		}
	}

	public void AddSphere(Point3D center, double radius = 1.0, int thetaDiv = 32, int phiDiv = 32)
	{
		AddEllipsoid(center, radius, radius, radius, thetaDiv, phiDiv);
	}

	public void AddSubdivisionSphere(Point3D center, double radius, int subdivisions)
	{
		int count = positions.Count;
		Append(GetUnitSphere(subdivisions));
		int count2 = positions.Count;
		for (int i = count; i < count2; i++)
		{
			Vector3D vector3D = (Vector3D)positions[i];
			positions[i] = center + radius * vector3D;
		}
	}

	public void AddSurfaceOfRevolution(Point3D origin, Vector3D axis, IList<Point> section, IList<int> sectionIndices, int thetaDiv = 37, IList<double> textureValues = null)
	{
		if (textureCoordinates != null && textureValues == null)
		{
			throw new ArgumentNullException("textureValues");
		}
		if (textureValues != null && textureValues.Count != section.Count)
		{
			throw new InvalidOperationException("Wrong number of texture coordinates.");
		}
		axis.Normalize();
		Vector3D second = axis.FindAnyPerpendicular();
		Vector3D vector3D = SharedFunctions.CrossProduct(ref axis, ref second);
		IList<Point> circle = GetCircle(thetaDiv);
		int count = section.Count;
		int count2 = positions.Count;
		for (int i = 0; i < thetaDiv; i++)
		{
			Vector3D vector3D2 = vector3D * circle[i].X + second * circle[i].Y;
			for (int j = 0; j < count; j++)
			{
				Point3D value = origin + axis * section[j].Y + vector3D2 * section[j].X;
				positions.Add(value);
				if (normals != null)
				{
					double num = section[j + 1].X - section[j].X;
					double num2 = section[j + 1].Y - section[j].Y;
					Vector3D value2 = -axis * num2 + vector3D2 * num;
					value2.Normalize();
					normals.Add(value2);
				}
				if (textureCoordinates != null)
				{
					textureCoordinates.Add(new Point((double)i / (double)(thetaDiv - 1), (textureValues == null) ? ((double)j / (double)(count - 1)) : textureValues[j]));
				}
			}
		}
		for (int k = 0; k < thetaDiv; k++)
		{
			int num3 = (k + 1) % thetaDiv;
			for (int l = 0; l + 1 < sectionIndices.Count; l += 2)
			{
				int num4 = sectionIndices[l];
				int num5 = sectionIndices[l + 1];
				int value3 = count2 + k * count + num4;
				int value4 = count2 + num3 * count + num4;
				int value5 = count2 + k * count + num5;
				int value6 = count2 + num3 * count + num5;
				triangleIndices.Add(value3);
				triangleIndices.Add(value4);
				triangleIndices.Add(value6);
				triangleIndices.Add(value6);
				triangleIndices.Add(value5);
				triangleIndices.Add(value3);
			}
		}
	}

	public void AddTetrahedron(Point3D center, Vector3D forward, Vector3D up, double sideLength)
	{
		Vector3D vector3D = SharedFunctions.CrossProduct(ref up, ref forward);
		double num = Math.Sqrt(6.0) / 3.0 * sideLength;
		double num2 = Math.Sqrt(6.0) / 4.0 * sideLength;
		double num3 = Math.Sqrt(3.0) / 2.0 * sideLength;
		double num4 = Math.Sqrt(3.0) / 3.0 * sideLength;
		double num5 = num - num2;
		double num6 = num3 - num4;
		double num7 = sideLength * 0.5;
		Point3D point3D = center + forward * num4 - up * num5;
		Point3D point3D2 = center - forward * num6 - vector3D * num7 - up * num5;
		Point3D point3D3 = center - forward * num6 + vector3D * num7 - up * num5;
		Point3D p = center + up * num2;
		AddTriangle(point3D, point3D2, point3D3);
		AddTriangle(point3D, p, point3D2);
		AddTriangle(point3D2, p, point3D3);
		AddTriangle(point3D3, p, point3D);
	}

	public void AddTorus(double torusDiameter, double tubeDiameter, int thetaDiv = 36, int phiDiv = 24)
	{
		int count = positions.Count;
		if (torusDiameter == 0.0)
		{
			AddSphere(default(Point3D), tubeDiameter, thetaDiv, phiDiv);
			return;
		}
		if (tubeDiameter == 0.0)
		{
			throw new HelixToolkitException("Torus must have a Diameter bigger than 0");
		}
		bool flag = tubeDiameter > torusDiameter;
		IList<Point> source;
		if (flag)
		{
			double num = Math.Acos(1.0 - torusDiameter * torusDiameter / (2.0 * (tubeDiameter * tubeDiameter * 0.25)));
			double num2 = Math.PI + num;
			double angleOffset = (0.0 - num2) / 2.0;
			source = GetCircleSegment(phiDiv, num2, angleOffset);
		}
		else
		{
			source = GetCircle(phiDiv, closed: true);
		}
		source = source.Select((Point p) => new Point(p.X * tubeDiameter * 0.5, p.Y * tubeDiameter * 0.5)).ToList();
		List<Point3D> source2 = source.Select((Point p) => new Point3D(p.X, 0.0, p.Y)).ToList();
		for (int num3 = 0; num3 < thetaDiv; num3++)
		{
			double angle = Math.PI * 2.0 * ((double)num3 / (double)thetaDiv);
			List<Point3D> list = source2.Select((Point3D p3D) => new Point3D(Math.Cos(angle) * (p3D.X + torusDiameter * 0.5), Math.Sin(angle) * (p3D.X + torusDiameter * 0.5), p3D.Z)).ToList();
			for (int num4 = 0; num4 < phiDiv; num4++)
			{
				if (!flag || num3 <= 0 || (num4 != 0 && num4 != phiDiv - 1))
				{
					positions.Add(list[num4]);
				}
			}
		}
		if (normals != null)
		{
			for (int num5 = 0; num5 < thetaDiv; num5++)
			{
				double angle2 = Math.PI * 2.0 * ((double)num5 / (double)thetaDiv);
				List<Point3D> list2 = source2.Select((Point3D p3D) => new Point3D(Math.Cos(angle2) * (p3D.X + torusDiameter * 0.5), Math.Sin(angle2) * (p3D.X + torusDiameter * 0.5), p3D.Z)).ToList();
				if (flag && num5 > 0)
				{
					list2.RemoveAt(0);
					list2.RemoveAt(list2.Count - 1);
				}
				Point3D point3D = new Point3D(Math.Cos(angle2) * torusDiameter * 0.5, Math.Sin(angle2) * torusDiameter * 0.5, 0.0);
				for (int num6 = 0; num6 < list2.Count; num6++)
				{
					Vector3D value = list2[num6] - point3D;
					value.Normalize();
					if (flag && num5 == 0 && num6 == 0)
					{
						value = new Vector3D(0.0, 0.0, -1.0);
					}
					else if (flag && num5 == 0 && num6 == phiDiv - 1)
					{
						value = new Vector3D(0.0, 0.0, 1.0);
					}
					normals.Add(value);
				}
			}
		}
		if (textureCoordinates != null)
		{
			for (int num7 = 0; num7 < thetaDiv; num7++)
			{
				int num8 = ((flag && num7 > 0) ? (phiDiv - 2) : phiDiv);
				for (int num9 = 0; num9 < num8; num9++)
				{
					double x = (double)num7 / (double)thetaDiv;
					double num10 = 0.0;
					num10 = ((!((num7 > 0) & flag)) ? ((double)num9 / (double)phiDiv) : ((double)(num9 + 1) / (double)phiDiv));
					textureCoordinates.Add(new Point(x, num10));
				}
			}
		}
		for (int num11 = 0; num11 < thetaDiv; num11++)
		{
			if (!flag)
			{
				int num12 = num11 * phiDiv;
				int num13 = (num11 + 1) % thetaDiv * phiDiv;
				for (int num14 = 0; num14 < phiDiv; num14++)
				{
					int num15 = (num14 + 1) % phiDiv;
					triangleIndices.Add(num12 + num14 + count);
					triangleIndices.Add(num12 + num15 + count);
					triangleIndices.Add(num13 + num14 + count);
					triangleIndices.Add(num13 + num14 + count);
					triangleIndices.Add(num12 + num15 + count);
					triangleIndices.Add(num13 + num15 + count);
				}
				continue;
			}
			int num16 = num11 * (phiDiv - 2) + 1;
			num16 += ((num11 > 0) ? 1 : 0);
			int num17 = phiDiv + num16 - 1;
			num17 -= ((num11 > 0) ? 1 : 0);
			if (num17 >= positions.Count)
			{
				num17 %= positions.Count;
				num17++;
			}
			for (int num18 = 1; num18 < phiDiv - 2; num18++)
			{
				triangleIndices.Add(num16 + num18 - 1 + count);
				triangleIndices.Add(num17 + num18 - 1 + count);
				triangleIndices.Add(num16 + num18 + count);
				triangleIndices.Add(num17 + num18 - 1 + count);
				triangleIndices.Add(num17 + num18 + count);
				triangleIndices.Add(num16 + num18 + count);
			}
		}
		if (!flag)
		{
			return;
		}
		List<int> list3 = new List<int>();
		list3.Add(0);
		for (int num19 = 0; num19 < thetaDiv; num19++)
		{
			if (num19 == 0)
			{
				list3.Add(1 + count);
			}
			else
			{
				list3.Add(phiDiv + (num19 - 1) * (phiDiv - 2) + count);
			}
		}
		list3.Add(1 + count);
		list3.Reverse();
		AddTriangleFan(list3);
		list3 = new List<int>();
		list3.Add(phiDiv - 1 + count);
		for (int num20 = 0; num20 < thetaDiv; num20++)
		{
			if (num20 == 0)
			{
				list3.Add(phiDiv - 2 + count);
			}
			else
			{
				list3.Add(phiDiv + num20 * (phiDiv - 2) - 1 + count);
			}
		}
		list3.Add(phiDiv - 2 + count);
		AddTriangleFan(list3);
	}

	public void AddTriangle(IList<int> vertexIndices)
	{
		for (int i = 0; i < 3; i++)
		{
			triangleIndices.Add(vertexIndices[i]);
		}
	}

	public void AddTriangle(Point3D p0, Point3D p1, Point3D p2)
	{
		Point uv = new Point(0.0, 0.0);
		Point uv2 = new Point(1.0, 0.0);
		Point uv3 = new Point(0.0, 1.0);
		AddTriangle(p0, p1, p2, uv, uv2, uv3);
	}

	public void AddTriangle(Point3D p0, Point3D p1, Point3D p2, Point uv0, Point uv1, Point uv2)
	{
		int count = positions.Count;
		positions.Add(p0);
		positions.Add(p1);
		positions.Add(p2);
		if (textureCoordinates != null)
		{
			textureCoordinates.Add(uv0);
			textureCoordinates.Add(uv1);
			textureCoordinates.Add(uv2);
		}
		if (normals != null)
		{
			Vector3D first = p1 - p0;
			Vector3D second = p2 - p0;
			Vector3D value = SharedFunctions.CrossProduct(ref first, ref second);
			value.Normalize();
			normals.Add(value);
			normals.Add(value);
			normals.Add(value);
		}
		triangleIndices.Add(count);
		triangleIndices.Add(count + 1);
		triangleIndices.Add(count + 2);
	}

	public void AddTriangleFan(IList<int> vertices)
	{
		for (int i = 0; i + 2 < vertices.Count; i++)
		{
			triangleIndices.Add(vertices[0]);
			triangleIndices.Add(vertices[i + 1]);
			triangleIndices.Add(vertices[i + 2]);
		}
	}

	public void AddTriangleFan(IList<Point3D> fanPositions, IList<Vector3D> fanNormals = null, IList<Point> fanTextureCoordinates = null)
	{
		if (positions == null)
		{
			throw new ArgumentNullException("fanPositions");
		}
		if (normals != null && fanNormals == null)
		{
			throw new ArgumentNullException("fanNormals");
		}
		if (textureCoordinates != null && fanTextureCoordinates == null)
		{
			throw new ArgumentNullException("fanTextureCoordinates");
		}
		int count = positions.Count;
		foreach (Point3D fanPosition in fanPositions)
		{
			positions.Add(fanPosition);
		}
		if (textureCoordinates != null && fanTextureCoordinates != null)
		{
			foreach (Point fanTextureCoordinate in fanTextureCoordinates)
			{
				textureCoordinates.Add(fanTextureCoordinate);
			}
		}
		if (normals != null && fanNormals != null)
		{
			foreach (Vector3D fanNormal in fanNormals)
			{
				normals.Add(fanNormal);
			}
		}
		int count2 = positions.Count;
		for (int i = count; i + 2 < count2; i++)
		{
			triangleIndices.Add(count);
			triangleIndices.Add(i + 1);
			triangleIndices.Add(i + 2);
		}
	}

	public void AddTriangles(IList<Point3D> trianglePositions, IList<Vector3D> triangleNormals = null, IList<Point> triangleTextureCoordinates = null)
	{
		if (trianglePositions == null)
		{
			throw new ArgumentNullException("trianglePositions");
		}
		if (normals != null && triangleNormals == null)
		{
			throw new ArgumentNullException("triangleNormals");
		}
		if (textureCoordinates != null && triangleTextureCoordinates == null)
		{
			throw new ArgumentNullException("triangleTextureCoordinates");
		}
		if (trianglePositions.Count % 3 != 0)
		{
			throw new InvalidOperationException("Wrong number of positions.");
		}
		if (triangleNormals != null && triangleNormals.Count != trianglePositions.Count)
		{
			throw new InvalidOperationException("Wrong number of normals.");
		}
		if (triangleTextureCoordinates != null && triangleTextureCoordinates.Count != trianglePositions.Count)
		{
			throw new InvalidOperationException("Wrong number of texture coordinates.");
		}
		int count = positions.Count;
		foreach (Point3D trianglePosition in trianglePositions)
		{
			positions.Add(trianglePosition);
		}
		if (textureCoordinates != null && triangleTextureCoordinates != null)
		{
			foreach (Point triangleTextureCoordinate in triangleTextureCoordinates)
			{
				textureCoordinates.Add(triangleTextureCoordinate);
			}
		}
		if (normals != null && triangleNormals != null)
		{
			foreach (Vector3D triangleNormal in triangleNormals)
			{
				normals.Add(triangleNormal);
			}
		}
		int count2 = positions.Count;
		for (int i = count; i < count2; i++)
		{
			triangleIndices.Add(i);
		}
	}

	public void AddTriangleStrip(IList<Point3D> stripPositions, IList<Vector3D> stripNormals = null, IList<Point> stripTextureCoordinates = null)
	{
		if (stripPositions == null)
		{
			throw new ArgumentNullException("stripPositions");
		}
		if (normals != null && stripNormals == null)
		{
			throw new ArgumentNullException("stripNormals");
		}
		if (textureCoordinates != null && stripTextureCoordinates == null)
		{
			throw new ArgumentNullException("stripTextureCoordinates");
		}
		if (stripNormals != null && stripNormals.Count != stripPositions.Count)
		{
			throw new InvalidOperationException("Wrong number of normals.");
		}
		if (stripTextureCoordinates != null && stripTextureCoordinates.Count != stripPositions.Count)
		{
			throw new InvalidOperationException("Wrong number of texture coordinates.");
		}
		int count = positions.Count;
		for (int i = 0; i < stripPositions.Count; i++)
		{
			positions.Add(stripPositions[i]);
			if (normals != null && stripNormals != null)
			{
				normals.Add(stripNormals[i]);
			}
			if (textureCoordinates != null && stripTextureCoordinates != null)
			{
				textureCoordinates.Add(stripTextureCoordinates[i]);
			}
		}
		int count2 = positions.Count;
		for (int j = count; j + 2 < count2; j += 2)
		{
			triangleIndices.Add(j);
			triangleIndices.Add(j + 1);
			triangleIndices.Add(j + 2);
			if (j + 3 < count2)
			{
				triangleIndices.Add(j + 1);
				triangleIndices.Add(j + 3);
				triangleIndices.Add(j + 2);
			}
		}
	}

	public void AddTube(IList<Point3D> path, double[] values, double[] diameters, int thetaDiv, bool isTubeClosed, bool frontCap = false, bool backCap = false)
	{
		IList<Point> circle = GetCircle(thetaDiv);
		AddTube(path, values, diameters, circle, isTubeClosed, isSectionClosed: true, frontCap, backCap);
	}

	public void AddTube(IList<Point3D> path, double diameter, int thetaDiv, bool isTubeClosed, bool frontCap = false, bool backCap = false)
	{
		AddTube(path, null, new double[1] { diameter }, thetaDiv, isTubeClosed, frontCap, backCap);
	}

	public void AddTube(IList<Point3D> path, IList<double> values, IList<double> diameters, IList<Point> section, bool isTubeClosed, bool isSectionClosed, bool frontCap = false, bool backCap = false)
	{
		if (values != null && values.Count == 0)
		{
			throw new InvalidOperationException("Wrong number of texture coordinates.");
		}
		if (diameters != null && diameters.Count == 0)
		{
			throw new InvalidOperationException("Wrong number of diameters.");
		}
		int count = positions.Count;
		int count2 = path.Count;
		int count3 = section.Count;
		if (count2 < 2 || count3 < 2)
		{
			return;
		}
		Vector3D first = (path[1] - path[0]).FindAnyPerpendicular();
		int num = diameters?.Count ?? 0;
		int num2 = values?.Count ?? 0;
		Vector3D vector3D = default(Vector3D);
		Vector3D vector3D2 = default(Vector3D);
		for (int i = 0; i < count2; i++)
		{
			double num3 = ((diameters != null) ? (diameters[i % num] / 2.0) : 1.0);
			int index = ((i > 0) ? (i - 1) : i);
			int index2 = ((i + 1 < count2) ? (i + 1) : i);
			Vector3D second = path[index2] - path[index];
			Vector3D second2 = SharedFunctions.CrossProduct(ref first, ref second);
			first = SharedFunctions.CrossProduct(ref second, ref second2);
			first.Normalize();
			second2.Normalize();
			Vector3D vector3D3 = second2;
			Vector3D vector3D4 = first;
			if (vector3D3.IsUndefined() || vector3D4.IsUndefined())
			{
				second = vector3D2;
				second *= -1.0;
				first = vector3D;
				first *= -1.0;
				second2 = SharedFunctions.CrossProduct(ref first, ref second);
				first.Normalize();
				second2.Normalize();
				vector3D3 = second2;
				vector3D4 = first;
			}
			vector3D2 = second;
			vector3D = first;
			for (int j = 0; j < count3; j++)
			{
				Vector3D vector3D5 = section[j].X * vector3D3 * num3 + section[j].Y * vector3D4 * num3;
				Point3D value = path[i] + vector3D5;
				positions.Add(value);
				if (normals != null)
				{
					vector3D5.Normalize();
					normals.Add(vector3D5);
				}
				if (textureCoordinates != null)
				{
					textureCoordinates.Add((values != null) ? new Point(values[i % num2], (double)j / (double)(count3 - 1)) : default(Point));
				}
			}
		}
		AddRectangularMeshTriangleIndices(count, count2, count3, isSectionClosed, isTubeClosed);
		if (!frontCap && (!backCap || path.Count <= 1))
		{
			return;
		}
		Vector3D[] array = new Vector3D[section.Count];
		Point[] fanTextureCoordinates = new Point[section.Count];
		int count4 = path.Count;
		if (backCap)
		{
			Point3D[] fanPositions = Positions.Skip(Positions.Count - section.Count).Take(section.Count).Reverse()
				.ToArray();
			Vector3D vector3D6 = path[count4 - 1] - path[count4 - 2];
			vector3D6.Normalize();
			for (int k = 0; k < array.Length; k++)
			{
				array[k] = vector3D6;
			}
			AddTriangleFan(fanPositions, array, fanTextureCoordinates);
		}
		if (frontCap)
		{
			Point3D[] fanPositions2 = Positions.Take(section.Count).ToArray();
			Vector3D vector3D7 = path[0] - path[1];
			vector3D7.Normalize();
			for (int l = 0; l < array.Length; l++)
			{
				array[l] = vector3D7;
			}
			AddTriangleFan(fanPositions2, array, fanTextureCoordinates);
		}
	}

	public void AddTube(IList<Point3D> path, IList<double> angles, IList<double> values, IList<double> diameters, IList<Point> section, Vector3D sectionXAxis, bool isTubeClosed, bool isSectionClosed, bool frontCap = false, bool backCap = false)
	{
		if (values != null && values.Count == 0)
		{
			throw new InvalidOperationException("Wrong number of texture coordinates.");
		}
		if (diameters != null && diameters.Count == 0)
		{
			throw new InvalidOperationException("Wrong number of diameters.");
		}
		if (angles != null && angles.Count == 0)
		{
			throw new InvalidOperationException("Wrong number of angles.");
		}
		int count = positions.Count;
		int count2 = path.Count;
		int count3 = section.Count;
		if (count2 < 2 || count3 < 2)
		{
			return;
		}
		Vector3D first = path[1] - path[0];
		Vector3D second = sectionXAxis;
		Vector3D first2 = SharedFunctions.CrossProduct(ref first, ref second);
		first2.Normalize();
		second.Normalize();
		int num = diameters?.Count ?? 0;
		int num2 = values?.Count ?? 0;
		int num3 = angles?.Count ?? 0;
		for (int i = 0; i < count2; i++)
		{
			double num4 = ((diameters != null) ? (diameters[i % num] / 2.0) : 1.0);
			double num5 = ((angles != null) ? angles[i % num3] : 0.0);
			double num6 = Math.Cos(num5);
			double num7 = Math.Sin(num5);
			int index = ((i > 0) ? (i - 1) : i);
			int index2 = ((i + 1 < count2) ? (i + 1) : i);
			first = path[index2] - path[index];
			second = SharedFunctions.CrossProduct(ref first2, ref first);
			if (SharedFunctions.LengthSquared(ref second) > 9.999999974752427E-07)
			{
				first2 = SharedFunctions.CrossProduct(ref first, ref second);
			}
			first2.Normalize();
			second.Normalize();
			for (int j = 0; j < count3; j++)
			{
				double num8 = section[j].X * num6 - section[j].Y * num7;
				double num9 = section[j].X * num7 + section[j].Y * num6;
				Vector3D vector3D = num8 * second * num4 + num9 * first2 * num4;
				Point3D value = path[i] + vector3D;
				positions.Add(value);
				if (normals != null)
				{
					vector3D.Normalize();
					normals.Add(vector3D);
				}
				if (textureCoordinates != null)
				{
					textureCoordinates.Add((values != null) ? new Point(values[i % num2], (double)j / (double)(count3 - 1)) : default(Point));
				}
			}
		}
		AddRectangularMeshTriangleIndices(count, count2, count3, isSectionClosed, isTubeClosed);
		if (!frontCap && (!backCap || path.Count <= 1))
		{
			return;
		}
		Vector3D[] array = new Vector3D[section.Count];
		Point[] fanTextureCoordinates = new Point[section.Count];
		int count4 = path.Count;
		if (backCap)
		{
			Point3D[] fanPositions = Positions.Skip(Positions.Count - section.Count).Take(section.Count).Reverse()
				.ToArray();
			Vector3D vector3D2 = path[count4 - 1] - path[count4 - 2];
			vector3D2.Normalize();
			for (int k = 0; k < array.Length; k++)
			{
				array[k] = vector3D2;
			}
			AddTriangleFan(fanPositions, array, fanTextureCoordinates);
		}
		if (frontCap)
		{
			Point3D[] fanPositions2 = Positions.Take(section.Count).ToArray();
			Vector3D vector3D3 = path[0] - path[1];
			vector3D3.Normalize();
			for (int l = 0; l < array.Length; l++)
			{
				array[l] = vector3D3;
			}
			AddTriangleFan(fanPositions2, array, fanTextureCoordinates);
		}
	}

	public void Append(MeshBuilder mesh)
	{
		if (mesh == null)
		{
			throw new ArgumentNullException("mesh");
		}
		Append(mesh.positions, mesh.triangleIndices, mesh.normals, mesh.textureCoordinates);
	}

	public void Append(MeshGeometry3D mesh)
	{
		if (mesh == null)
		{
			throw new ArgumentNullException("mesh");
		}
		Append(mesh.Positions, mesh.TriangleIndices, (normals != null) ? mesh.Normals : null, (textureCoordinates != null) ? mesh.TextureCoordinates : null);
	}

	public void Append(IList<Point3D> positionsToAppend, IList<int> triangleIndicesToAppend, IList<Vector3D> normalsToAppend = null, IList<Point> textureCoordinatesToAppend = null)
	{
		if (positionsToAppend == null)
		{
			throw new ArgumentNullException("positionsToAppend");
		}
		if (normals != null && normalsToAppend == null)
		{
			throw new InvalidOperationException("Source mesh normals should not be null.");
		}
		if (textureCoordinates != null && textureCoordinatesToAppend == null)
		{
			throw new InvalidOperationException("Source mesh texture coordinates should not be null.");
		}
		if (normalsToAppend != null && normalsToAppend.Count != positionsToAppend.Count)
		{
			throw new InvalidOperationException("Wrong number of normals.");
		}
		if (textureCoordinatesToAppend != null && textureCoordinatesToAppend.Count != positionsToAppend.Count)
		{
			throw new InvalidOperationException("Wrong number of texture coordinates.");
		}
		int count = positions.Count;
		foreach (Point3D item in positionsToAppend)
		{
			positions.Add(item);
		}
		if (normals != null && normalsToAppend != null)
		{
			foreach (Vector3D item2 in normalsToAppend)
			{
				normals.Add(item2);
			}
		}
		if (textureCoordinates != null && textureCoordinatesToAppend != null)
		{
			foreach (Point item3 in textureCoordinatesToAppend)
			{
				textureCoordinates.Add(item3);
			}
		}
		foreach (int item4 in triangleIndicesToAppend)
		{
			triangleIndices.Add(count + item4);
		}
	}

	public void ChamferCorner(Point3D p, double d, double eps = 9.999999974752427E-07, IList<Point3D> chamferPoints = null)
	{
		NoSharedVertices();
		normals = null;
		textureCoordinates = null;
		Vector3D vector3D = FindCornerNormal(p, eps);
		Point3D point3D = p - vector3D * d;
		int count = positions.Count;
		positions.Add(point3D);
		Plane3D plane3D = new Plane3D(point3D, vector3D);
		int count2 = triangleIndices.Count;
		for (int i = 0; i < count2; i += 3)
		{
			int num = i;
			int index = i + 1;
			int num2 = i + 2;
			Point3D point3D2 = positions[triangleIndices[num]];
			Point3D point3D3 = positions[triangleIndices[index]];
			Point3D point3D4 = positions[triangleIndices[num2]];
			Vector3D vector = p - point3D2;
			Vector3D vector2 = p - point3D3;
			Vector3D vector3 = p - point3D4;
			double val = SharedFunctions.LengthSquared(ref vector);
			double num3 = SharedFunctions.LengthSquared(ref vector2);
			double num4 = SharedFunctions.LengthSquared(ref vector3);
			double num5 = Math.Min(val, Math.Min(num3, num4));
			if (num5 > eps)
			{
				continue;
			}
			if (num3 < eps)
			{
				num = i + 1;
				index = i + 2;
				num2 = i;
			}
			if (num4 < eps)
			{
				num = i + 2;
				index = i;
				num2 = i + 1;
			}
			point3D2 = positions[triangleIndices[num]];
			point3D3 = positions[triangleIndices[index]];
			point3D4 = positions[triangleIndices[num2]];
			Point3D? point3D5 = plane3D.LineIntersection(point3D2, point3D3);
			Point3D? point3D6 = plane3D.LineIntersection(point3D2, point3D4);
			if (!point3D5.HasValue || !point3D6.HasValue)
			{
				continue;
			}
			if (chamferPoints != null)
			{
				if (!chamferPoints.Contains(point3D5.Value))
				{
					chamferPoints.Add(point3D5.Value);
				}
				if (!chamferPoints.Contains(point3D6.Value))
				{
					chamferPoints.Add(point3D6.Value);
				}
			}
			int num6 = num;
			positions[triangleIndices[num6]] = point3D5.Value;
			int count3 = positions.Count;
			positions.Add(point3D6.Value);
			triangleIndices.Add(num6);
			triangleIndices.Add(num2);
			triangleIndices.Add(count3);
			triangleIndices.Add(count);
			triangleIndices.Add(num6);
			triangleIndices.Add(count3);
		}
		NoSharedVertices();
	}

	public void CheckPerformanceLimits()
	{
		if (positions.Count > 20000)
		{
			Trace.WriteLine($"Too many positions ({positions.Count}).");
		}
		if (triangleIndices.Count > 60002)
		{
			Trace.WriteLine($"Too many triangle indices ({triangleIndices.Count}).");
		}
	}

	private Vector3D FindCornerNormal(Point3D p, double eps)
	{
		Vector3D vector3D = default(Vector3D);
		int num = 0;
		HashSet<Vector3D> hashSet = new HashSet<Vector3D>();
		for (int i = 0; i < triangleIndices.Count; i += 3)
		{
			int index = i;
			int index2 = i + 1;
			int index3 = i + 2;
			Point3D point3D = positions[triangleIndices[index]];
			Point3D point3D2 = positions[triangleIndices[index2]];
			Point3D point3D3 = positions[triangleIndices[index3]];
			Vector3D vector = p - point3D;
			Vector3D vector2 = p - point3D2;
			Vector3D vector3 = p - point3D3;
			double val = SharedFunctions.LengthSquared(ref vector);
			double val2 = SharedFunctions.LengthSquared(ref vector2);
			double val3 = SharedFunctions.LengthSquared(ref vector3);
			double num2 = Math.Min(val, Math.Min(val2, val3));
			if (!(num2 > eps))
			{
				Vector3D first = point3D2 - point3D;
				Vector3D second = point3D3 - point3D;
				Vector3D vector3D2 = SharedFunctions.CrossProduct(ref first, ref second);
				vector3D2.Normalize();
				if (!hashSet.Contains(vector3D2))
				{
					num++;
					vector3D += vector3D2;
					hashSet.Add(vector3D2);
				}
			}
		}
		if (num == 0)
		{
			return default(Vector3D);
		}
		return vector3D * (1f / (float)num);
	}

	private void NoSharedVertices()
	{
		Point3DCollection point3DCollection = new Point3DCollection();
		Int32Collection int32Collection = new Int32Collection();
		Vector3DCollection vector3DCollection = null;
		if (normals != null)
		{
			vector3DCollection = new Vector3DCollection();
		}
		PointCollection pointCollection = null;
		if (textureCoordinates != null)
		{
			pointCollection = new PointCollection();
		}
		for (int i = 0; i < triangleIndices.Count; i += 3)
		{
			int num = i;
			int num2 = i + 1;
			int num3 = i + 2;
			int index = triangleIndices[num];
			int index2 = triangleIndices[num2];
			int index3 = triangleIndices[num3];
			Point3D value = positions[index];
			Point3D value2 = positions[index2];
			Point3D value3 = positions[index3];
			point3DCollection.Add(value);
			point3DCollection.Add(value2);
			point3DCollection.Add(value3);
			int32Collection.Add(num);
			int32Collection.Add(num2);
			int32Collection.Add(num3);
			if (vector3DCollection != null)
			{
				vector3DCollection.Add(normals[index]);
				vector3DCollection.Add(normals[index2]);
				vector3DCollection.Add(normals[index3]);
			}
			if (pointCollection != null)
			{
				pointCollection.Add(textureCoordinates[index]);
				pointCollection.Add(textureCoordinates[index2]);
				pointCollection.Add(textureCoordinates[index3]);
			}
		}
		positions = point3DCollection;
		triangleIndices = int32Collection;
		normals = vector3DCollection;
		textureCoordinates = pointCollection;
	}

	public void Scale(double scaleX, double scaleY, double scaleZ)
	{
		for (int i = 0; i < Positions.Count; i++)
		{
			Positions[i] = new Point3D(Positions[i].X * scaleX, Positions[i].Y * scaleY, Positions[i].Z * scaleZ);
		}
		if (Normals != null)
		{
			for (int j = 0; j < Normals.Count; j++)
			{
				Normals[j] = new Vector3D(Normals[j].X * scaleX, Normals[j].Y * scaleY, Normals[j].Z * scaleZ);
				Normals[j].Normalize();
			}
		}
	}

	private void Subdivide4()
	{
		int count = Positions.Count;
		int count2 = TriangleIndices.Count;
		for (int i = 0; i < count2; i += 3)
		{
			int num = TriangleIndices[i];
			int num2 = TriangleIndices[i + 1];
			int num3 = TriangleIndices[i + 2];
			Point3D point3D = Positions[num];
			Point3D point3D2 = Positions[num2];
			Point3D point3D3 = Positions[num3];
			Vector3D vector3D = point3D2 - point3D;
			Vector3D vector3D2 = point3D3 - point3D2;
			Vector3D vector3D3 = point3D - point3D3;
			Point3D value = point3D + vector3D * 0.5;
			Point3D value2 = point3D2 + vector3D2 * 0.5;
			Point3D value3 = point3D3 + vector3D3 * 0.5;
			int value4 = count++;
			int value5 = count++;
			int value6 = count++;
			Positions.Add(value);
			Positions.Add(value2);
			Positions.Add(value3);
			if (normals != null)
			{
				Vector3D value7 = Normals[num];
				Normals.Add(value7);
				Normals.Add(value7);
				Normals.Add(value7);
			}
			if (textureCoordinates != null)
			{
				Point point = TextureCoordinates[num];
				Point point2 = TextureCoordinates[num + 1];
				Point point3 = TextureCoordinates[num + 2];
				Vector vector = point2 - point;
				Vector vector2 = point3 - point2;
				Vector vector3 = point - point3;
				Point value8 = point + vector * 0.5;
				Point value9 = point2 + vector2 * 0.5;
				Point value10 = point3 + vector3 * 0.5;
				TextureCoordinates.Add(value8);
				TextureCoordinates.Add(value9);
				TextureCoordinates.Add(value10);
			}
			TriangleIndices[i + 1] = value4;
			TriangleIndices[i + 2] = value6;
			TriangleIndices.Add(value4);
			TriangleIndices.Add(num2);
			TriangleIndices.Add(value5);
			TriangleIndices.Add(value5);
			TriangleIndices.Add(num3);
			TriangleIndices.Add(value6);
			TriangleIndices.Add(value4);
			TriangleIndices.Add(value5);
			TriangleIndices.Add(value6);
		}
	}

	private void SubdivideBarycentric()
	{
		int num = Positions.Count;
		int count = TriangleIndices.Count;
		for (int i = 0; i < count; i += 3)
		{
			int num2 = TriangleIndices[i];
			int num3 = TriangleIndices[i + 1];
			int num4 = TriangleIndices[i + 2];
			Point3D point3D = Positions[num2];
			Point3D point3D2 = Positions[num3];
			Point3D point3D3 = Positions[num4];
			Vector3D vector3D = point3D2 - point3D;
			Vector3D vector3D2 = point3D3 - point3D2;
			Vector3D vector3D3 = point3D - point3D3;
			Point3D value = point3D + vector3D * 0.5;
			Point3D value2 = point3D2 + vector3D2 * 0.5;
			Point3D value3 = point3D3 + vector3D3 * 0.5;
			Point3D value4 = new Point3D((point3D.X + point3D2.X + point3D3.X) / 3.0, (point3D.Y + point3D2.Y + point3D3.Y) / 3.0, (point3D.Z + point3D2.Z + point3D3.Z) / 3.0);
			int value5 = num + 1;
			int value6 = num + 2;
			int value7 = num + 3;
			Positions.Add(value4);
			Positions.Add(value);
			Positions.Add(value2);
			Positions.Add(value3);
			if (normals != null)
			{
				Vector3D value8 = Normals[num2];
				Normals.Add(value8);
				Normals.Add(value8);
				Normals.Add(value8);
				Normals.Add(value8);
			}
			if (textureCoordinates != null)
			{
				Point point = TextureCoordinates[num2];
				Point point2 = TextureCoordinates[num2 + 1];
				Point point3 = TextureCoordinates[num2 + 2];
				Vector vector = point2 - point;
				Vector vector2 = point3 - point2;
				Vector vector3 = point - point3;
				Point value9 = point + vector * 0.5;
				Point value10 = point2 + vector2 * 0.5;
				Point value11 = point3 + vector3 * 0.5;
				Point value12 = new Point((point.X + point2.X) * 0.5, (point.Y + point2.Y) * 0.5);
				TextureCoordinates.Add(value12);
				TextureCoordinates.Add(value9);
				TextureCoordinates.Add(value10);
				TextureCoordinates.Add(value11);
			}
			TriangleIndices[i + 1] = value5;
			TriangleIndices[i + 2] = num;
			TriangleIndices.Add(value5);
			TriangleIndices.Add(num3);
			TriangleIndices.Add(num);
			TriangleIndices.Add(num3);
			TriangleIndices.Add(value6);
			TriangleIndices.Add(num);
			TriangleIndices.Add(value6);
			TriangleIndices.Add(num4);
			TriangleIndices.Add(num);
			TriangleIndices.Add(num4);
			TriangleIndices.Add(value7);
			TriangleIndices.Add(num);
			TriangleIndices.Add(value7);
			TriangleIndices.Add(num2);
			TriangleIndices.Add(num);
			num += 4;
		}
	}

	public void SubdivideLinear(bool barycentric = false)
	{
		if (barycentric)
		{
			SubdivideBarycentric();
		}
		else
		{
			Subdivide4();
		}
	}

	public MeshGeometry3D ToMesh(bool freeze = false)
	{
		if (triangleIndices.Count == 0)
		{
			MeshGeometry3D meshGeometry3D = new MeshGeometry3D();
			if (freeze)
			{
				meshGeometry3D.Freeze();
			}
			return meshGeometry3D;
		}
		if (normals != null && positions.Count != normals.Count)
		{
			throw new InvalidOperationException("Wrong number of normals.");
		}
		if (textureCoordinates != null && positions.Count != textureCoordinates.Count)
		{
			throw new InvalidOperationException("Wrong number of texture coordinates.");
		}
		MeshGeometry3D meshGeometry3D2 = new MeshGeometry3D
		{
			Positions = new Point3DCollection(positions),
			TriangleIndices = new Int32Collection(triangleIndices)
		};
		if (normals != null)
		{
			meshGeometry3D2.Normals = new Vector3DCollection(normals);
		}
		if (textureCoordinates != null)
		{
			meshGeometry3D2.TextureCoordinates = new PointCollection(textureCoordinates);
		}
		if (freeze)
		{
			meshGeometry3D2.Freeze();
		}
		return meshGeometry3D2;
	}
}
