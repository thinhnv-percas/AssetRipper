using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Media3D;

namespace WFTools3D
{
	public class MeshUtils
	{
		internal static int _0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A = 4;

		public static void AddTriangleIndices(MeshGeometry3D mesh, int i, int j, int k)
		{
			mesh.TriangleIndices.Add(i);
			mesh.TriangleIndices.Add(j);
			mesh.TriangleIndices.Add(k);
		}

		public static void FlipTexture(MeshGeometry3D mesh)
		{
			for (int i = 0; i < mesh.TextureCoordinates.Count; i++)
			{
				Point value = mesh.TextureCoordinates[i];
				value.Y = 1.0 - value.Y;
				mesh.TextureCoordinates[i] = value;
			}
		}

		public static MeshGeometry3D CreateTriangle(Point3D p0, Point3D p1, Point3D p2, int divisions = 1)
		{
			Vector3D u = p1 - p0;
			Vector3D v = p2 - p0;
			if (divisions < 1 || divisions > 999 || u.Length < 1E-12 || v.Length < 1E-12)
			{
				return null;
			}
			MeshGeometry3D meshGeometry3D = new MeshGeometry3D();
			AddTriangles(meshGeometry3D, divisions, p0, u, v, 0.0, 1.0, doQuad: false);
			return meshGeometry3D;
		}

		public static MeshGeometry3D CreateSquare(int divisions = 1)
		{
			if (divisions < 1 || divisions > 999)
			{
				return null;
			}
			MeshGeometry3D meshGeometry3D = new MeshGeometry3D();
			AddTriangles(meshGeometry3D, divisions, new Point3D(-1.0, -1.0, 0.0), 2.0 * Math3D.UnitX, 2.0 * Math3D.UnitY, 0.0, 1.0);
			return meshGeometry3D;
		}

		public static MeshGeometry3D CreateCube(int divisions, bool isClosed)
		{
			if (divisions < 1 || divisions > 999)
			{
				return null;
			}
			MeshGeometry3D meshGeometry3D = new MeshGeometry3D();
			AddTriangles(meshGeometry3D, divisions, new Point3D(1.0, -1.0, -1.0), 2.0 * Math3D.UnitY, 2.0 * Math3D.UnitZ, 0.0, 0.25);
			AddTriangles(meshGeometry3D, divisions, new Point3D(1.0, 1.0, -1.0), -2.0 * Math3D.UnitX, 2.0 * Math3D.UnitZ, 0.25, 0.5);
			AddTriangles(meshGeometry3D, divisions, new Point3D(-1.0, 1.0, -1.0), -2.0 * Math3D.UnitY, 2.0 * Math3D.UnitZ, 0.5, 0.75);
			AddTriangles(meshGeometry3D, divisions, new Point3D(-1.0, -1.0, -1.0), 2.0 * Math3D.UnitX, 2.0 * Math3D.UnitZ, 0.75, 1.0);
			AddTriangles(meshGeometry3D, divisions, new Point3D(-1.0, -1.0, 1.0), 2.0 * Math3D.UnitX, 2.0 * Math3D.UnitY, 0.0, 1.0);
			AddTriangles(meshGeometry3D, divisions, new Point3D(-1.0, 1.0, -1.0), 2.0 * Math3D.UnitX, -2.0 * Math3D.UnitY, 0.0, 1.0);
			return meshGeometry3D;
		}

		public static void AddTriangles(MeshGeometry3D mesh, int divisions, Point3D p0, Vector3D u, Vector3D v, double tu0, double tu1, bool doQuad = true)
		{
			TextureTransform textureTransform = new TextureTransform(0.0, divisions, tu0, tu1, 1.0, 0.0);
			Vector3D vector = u / divisions;
			Vector3D vector2 = v / divisions;
			Vector3D value = u.Cross(v);
			value.Normalize();
			for (int i = 0; i < divisions; i++)
			{
				int num = doQuad ? divisions : (divisions - i);
				for (int j = 0; j < num; j++)
				{
					Point3D point3D = p0 + j * vector + i * vector2;
					Point3D point3D2 = point3D + vector;
					Point3D value2 = point3D + vector2;
					Point3D value3 = point3D2 + vector2;
					mesh.Positions.Add(point3D);
					mesh.Normals.Add(value);
					mesh.TextureCoordinates.Add(textureTransform.Transform(j, i));
					mesh.Positions.Add(point3D2);
					mesh.Normals.Add(value);
					mesh.TextureCoordinates.Add(textureTransform.Transform(j + 1, i));
					mesh.Positions.Add(value2);
					mesh.Normals.Add(value);
					mesh.TextureCoordinates.Add(textureTransform.Transform(j, i + 1));
					int num2 = mesh.Positions.Count - 3;
					AddTriangleIndices(mesh, num2, num2 + 1, num2 + 2);
					if (doQuad || j < num - 1)
					{
						mesh.Positions.Add(value3);
						mesh.Normals.Add(value);
						mesh.TextureCoordinates.Add(textureTransform.Transform(j + 1, i + 1));
						AddTriangleIndices(mesh, num2 + 1, num2 + 3, num2 + 2);
					}
				}
			}
		}

		internal static void _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020(MeshGeometry3D _0020, int _0020_000A, double _0020_0020, double _0020_000A_000A, double _0020_000A_0020, double _0020_0020_000A, double _0020_0020_0020)
		{
			double num = MathUtils.ToRadians(_0020_0020_000A);
			double num2 = (MathUtils.ToRadians(_0020_0020_0020) - num) / (double)_0020_000A;
			double num3 = num;
			if (_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A(_0020_000A, _0020_0020_000A, _0020_0020_0020))
			{
				num3 = num2 * 0.5;
			}
			Vector3D value = new Vector3D(0.0, 0.0, Math.Sign(num2));
			TextureTransform textureTransform = new TextureTransform(0.0 - _0020_0020, _0020_0020, 0.0, 1.0, 1.0, 0.0);
			int count = _0020.Positions.Count;
			if (_0020_000A_000A == 0.0)
			{
				_0020.Positions.Add(new Point3D(0.0, 0.0, _0020_000A_0020));
				_0020.Normals.Add(value);
				_0020.TextureCoordinates.Add(new Point(0.5, 0.5));
			}
			for (int i = 0; i <= _0020_000A; i++)
			{
				double num4 = num3 + (double)i * num2;
				double num5 = Math.Cos(num4);
				double num6 = Math.Sin(num4);
				double x = _0020_0020 * num5;
				double y = _0020_0020 * num6;
				_0020.Positions.Add(new Point3D(x, y, _0020_000A_0020));
				_0020.Normals.Add(value);
				_0020.TextureCoordinates.Add(textureTransform.Transform(x, y));
				if (_0020_000A_000A == 0.0)
				{
					if (i > 0)
					{
						int num7 = _0020.Positions.Count - 2;
						AddTriangleIndices(_0020, count, num7, num7 + 1);
					}
					continue;
				}
				x = _0020_000A_000A * num5;
				y = _0020_000A_000A * num6;
				_0020.Positions.Add(new Point3D(x, y, _0020_000A_0020));
				_0020.Normals.Add(value);
				_0020.TextureCoordinates.Add(textureTransform.Transform(x, y));
				if (i > 0)
				{
					int num8 = _0020.Positions.Count - 2;
					AddTriangleIndices(_0020, num8, num8 - 1, num8 - 2);
					AddTriangleIndices(_0020, num8, num8 + 1, num8 - 1);
				}
			}
		}

		internal static bool _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A(int _0020, double _0020_000A, double _0020_0020)
		{
			if ((_0020 == 4 || _0020 == 6 || _0020 == 8) && _0020_000A % 360.0 == 0.0 && _0020_0020 % 360.0 == 0.0)
			{
				return true;
			}
			return false;
		}

		public static MeshGeometry3D CreateDiskSegment(int divisions, double innerRadius = 0.0, double startDegrees = 0.0, double stopDegrees = 360.0)
		{
			if (divisions < 3 || divisions > 999 || innerRadius < 0.0 || innerRadius >= 1.0)
			{
				return null;
			}
			MeshGeometry3D meshGeometry3D = new MeshGeometry3D();
			_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020(meshGeometry3D, divisions, 1.0, innerRadius, 0.0, startDegrees, stopDegrees);
			return meshGeometry3D;
		}

		public static MeshGeometry3D CreateCylinderSegment(int divisions, bool isClosed, double upperRadius = 1.0, double startDegrees = 0.0, double stopDegrees = 360.0)
		{
			if (divisions < 3 || divisions > 999 || upperRadius <= 0.0)
			{
				return null;
			}
			MeshGeometry3D meshGeometry3D = new MeshGeometry3D();
			double num = MathUtils.ToRadians(startDegrees);
			double num2 = (MathUtils.ToRadians(stopDegrees) - num) / (double)divisions;
			double num3 = num;
			if (_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A(divisions, startDegrees, stopDegrees))
			{
				num3 = num2 * 0.5;
			}
			for (int i = 0; i <= divisions; i++)
			{
				double num4 = num3 + (double)i * num2;
				double x = num4 / MathUtils.PIx2;
				double num5 = Math.Cos(num4);
				double num6 = Math.Sin(num4);
				double x2 = upperRadius * num5;
				double y = upperRadius * num6;
				Vector3D value = new Vector3D(num5, num6, 0.0);
				meshGeometry3D.Positions.Add(new Point3D(num5, num6, 0.0));
				meshGeometry3D.Normals.Add(value);
				meshGeometry3D.TextureCoordinates.Add(new Point(x, 1.0));
				meshGeometry3D.Positions.Add(new Point3D(x2, y, 1.0));
				meshGeometry3D.Normals.Add(value);
				meshGeometry3D.TextureCoordinates.Add(new Point(x, 0.0));
				if (i > 0)
				{
					int num7 = 2 * i;
					AddTriangleIndices(meshGeometry3D, num7, num7 - 1, num7 - 2);
					AddTriangleIndices(meshGeometry3D, num7, num7 + 1, num7 - 1);
				}
			}
			if (isClosed)
			{
				_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020(meshGeometry3D, divisions, upperRadius, 0.0, 1.0, startDegrees, stopDegrees);
				_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020(meshGeometry3D, divisions, 1.0, 0.0, 0.0, stopDegrees, startDegrees);
				if (startDegrees != 0.0 || stopDegrees != 360.0)
				{
					_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020(meshGeometry3D, startDegrees, upperRadius, _0020_000A_000A: true);
					_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020(meshGeometry3D, stopDegrees, upperRadius, _0020_000A_000A: false);
				}
			}
			return meshGeometry3D;
		}

		internal static void _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020(MeshGeometry3D _0020, double _0020_000A, double _0020_0020, bool _0020_000A_000A)
		{
			double num = MathUtils.ToRadians(_0020_000A);
			double num2 = Math.Cos(num);
			double num3 = Math.Sin(num);
			double x = _0020_0020 * num2;
			double y = _0020_0020 * num3;
			int count = _0020.Positions.Count;
			Vector3D value = Math3D.UnitY.Rotate(Math3D.UnitZ, _0020_000A);
			double x2 = (!_0020_000A_000A) ? 1 : 0;
			double x3 = num / MathUtils.PIx2;
			_0020.Positions.Add(new Point3D(0.0, 0.0, 0.0));
			_0020.Normals.Add(value);
			_0020.TextureCoordinates.Add(new Point(x2, 1.0));
			_0020.Positions.Add(new Point3D(num2, num3, 0.0));
			_0020.Normals.Add(value);
			_0020.TextureCoordinates.Add(new Point(x3, 1.0));
			_0020.Positions.Add(new Point3D(x, y, 1.0));
			_0020.Normals.Add(value);
			_0020.TextureCoordinates.Add(new Point(x3, 0.0));
			_0020.Positions.Add(new Point3D(0.0, 0.0, 1.0));
			_0020.Normals.Add(value);
			_0020.TextureCoordinates.Add(new Point(x2, 0.0));
			if (_0020_000A_000A)
			{
				AddTriangleIndices(_0020, count, count + 1, count + 2);
				AddTriangleIndices(_0020, count, count + 2, count + 3);
			}
			else
			{
				AddTriangleIndices(_0020, count, count + 2, count + 1);
				AddTriangleIndices(_0020, count, count + 3, count + 2);
			}
		}

		public static MeshGeometry3D CreateCone(int divisions, bool isClosed)
		{
			if (divisions < 3 || divisions > 999)
			{
				return null;
			}
			TextureTransform textureTransform = new TextureTransform(-1.0, 1.0, 0.0, 1.0, 1.0, 0.0);
			MeshGeometry3D meshGeometry3D = new MeshGeometry3D();
			meshGeometry3D.Positions.Add(new Point3D(0.0, 0.0, 1.0));
			meshGeometry3D.Normals.Add(new Vector3D(0.0, 0.0, 1.0));
			meshGeometry3D.TextureCoordinates.Add(textureTransform.Transform(0.0, 0.0));
			double num = MathUtils.PIx2 / (double)divisions;
			double num2 = num * 0.5;
			for (int i = 0; i <= divisions; i++)
			{
				double num3 = num2 + (double)i * num;
				double num4 = num3 / MathUtils.PIx2;
				double x = Math.Cos(num3);
				double y = Math.Sin(num3);
				meshGeometry3D.Positions.Add(new Point3D(x, y, 0.0));
				meshGeometry3D.Normals.Add(new Vector3D(x, y, 0.0));
				meshGeometry3D.TextureCoordinates.Add(textureTransform.Transform(x, y));
				if (i > 0)
				{
					AddTriangleIndices(meshGeometry3D, i, i + 1, 0);
				}
			}
			if (isClosed)
			{
				_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020(meshGeometry3D, divisions, 1.0, 0.0, 0.0, 360.0, 0.0);
			}
			return meshGeometry3D;
		}

		public static MeshGeometry3D CreateSphere(int divisions)
		{
			if (divisions < 1 || divisions > 999)
			{
				return null;
			}
			MeshGeometry3D meshGeometry3D = new MeshGeometry3D();
			int num = 2 * divisions;
			double num2 = Math.PI / (double)num;
			for (int i = 0; i <= num; i++)
			{
				double num3 = (double)i * num2;
				double num4 = Math.Sin(num3);
				double num5 = Math.Cos(num3);
				int num6 = _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A(i, divisions);
				double num7 = (num6 == 1) ? 0.0 : (MathUtils.PIx2 / (double)(num6 - 1));
				for (int j = 0; j < num6; j++)
				{
					double num8 = (double)j * num7;
					double x = num8 / MathUtils.PIx2;
					double x2 = Math.Cos(num8) * num4;
					double y = Math.Sin(num8) * num4;
					double z = num5;
					meshGeometry3D.Positions.Add(new Point3D(x2, y, z));
					meshGeometry3D.Normals.Add(new Vector3D(x2, y, z));
					meshGeometry3D.TextureCoordinates.Add(new Point(x, (0.0 - num5) * 0.5 + 0.5));
				}
			}
			int num9 = 0;
			int num10 = 0;
			while (num10 < divisions)
			{
				int num11 = _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A(num10, divisions);
				_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A(num10 + 1, divisions);
				int num12 = num9 + num11;
				for (int k = 0; k < _0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A; k++)
				{
					AddTriangleIndices(meshGeometry3D, num9, num12, num12 + 1);
					num12++;
					int num13 = num11 / _0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A;
					int num14 = 0;
					while (num14 < num13)
					{
						AddTriangleIndices(meshGeometry3D, num9, num12, num9 + 1);
						AddTriangleIndices(meshGeometry3D, num9 + 1, num12, num12 + 1);
						num14++;
						num9++;
						num12++;
					}
				}
				num10++;
				num9++;
			}
			num = 2 * divisions - 1;
			int num15 = divisions;
			while (num15 <= num)
			{
				int num16 = _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A(num15, divisions);
				int num17 = _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A(num15 + 1, divisions);
				int num18 = num9 + num16;
				for (int l = 0; l < _0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A; l++)
				{
					AddTriangleIndices(meshGeometry3D, num9, num18, num9 + 1);
					num9++;
					int num19 = num17 / _0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A;
					int num20 = 0;
					while (num20 < num19)
					{
						AddTriangleIndices(meshGeometry3D, num18, num18 + 1, num9);
						AddTriangleIndices(meshGeometry3D, num18 + 1, num9 + 1, num9);
						num20++;
						num9++;
						num18++;
					}
				}
				num15++;
				num9++;
			}
			return meshGeometry3D;
		}

		internal static int _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A(int _0020, int _0020_000A)
		{
			if (_0020 > _0020_000A)
			{
				_0020 = 2 * _0020_000A - _0020;
			}
			return _0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A * _0020 + 1;
		}

		public static MeshGeometry3D CreateTube(IList<Point3D> path, IList<Point> section, bool isPathClosed)
		{
			int count = path.Count;
			int count2 = section.Count;
			if (count < 2 || count2 < 2)
			{
				return null;
			}
			MeshGeometry3D meshGeometry3D = new MeshGeometry3D();
			int index = isPathClosed ? (count - 1) : 0;
			Vector3D v = path[1] - path[index];
			v.Normalize();
			Vector3D unitX = Math3D.UnitX;
			Vector3D vector3D = v.Cross(unitX);
			if (vector3D.LengthSquared < 0.001)
			{
				unitX = Math3D.UnitY;
				vector3D = v.Cross(unitX);
			}
			for (int i = 0; i < count; i++)
			{
				index = ((i > 0) ? (i - 1) : (isPathClosed ? (count - 1) : i));
				int index2 = (i + 1 < count) ? (i + 1) : ((!isPathClosed) ? i : 0);
				v = path[index2] - path[index];
				unitX = vector3D.Cross(v);
				unitX.Normalize();
				vector3D = v.Cross(unitX);
				vector3D.Normalize();
				for (int j = 0; j < count2; j++)
				{
					Vector3D vector3D2 = section[j].X * unitX + section[j].Y * vector3D;
					Point3D value = path[i] + vector3D2;
					meshGeometry3D.Positions.Add(value);
					vector3D2.Normalize();
					meshGeometry3D.Normals.Add(vector3D2);
					double x = (double)i / ((double)count - 1.0);
					double y = (double)j / ((double)count2 - 1.0);
					meshGeometry3D.TextureCoordinates.Add(new Point(x, y));
				}
			}
			int num = isPathClosed ? count : (count - 1);
			int num2 = count2 - 1;
			for (int k = 0; k < num; k++)
			{
				for (int l = 0; l < num2; l++)
				{
					int num3 = k * count2 + l;
					int j2 = num3 + 1;
					int num4 = (k + 1) % count * count2 + l;
					int num5 = num4 + 1;
					AddTriangleIndices(meshGeometry3D, num3, j2, num5);
					AddTriangleIndices(meshGeometry3D, num5, num4, num3);
				}
			}
			if (!isPathClosed)
			{
				int _0020_000A = meshGeometry3D.Positions.Count - count2;
				_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020(meshGeometry3D, 0, path, section, _0020_000A_0020: true);
				_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020(meshGeometry3D, _0020_000A, path, section, _0020_000A_0020: false);
			}
			return meshGeometry3D;
		}

		internal static void _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020(MeshGeometry3D _0020, int _0020_000A, IList<Point3D> _0020_0020, IList<Point> _0020_000A_000A, bool _0020_000A_0020)
		{
			int index = _0020_000A_0020 ? 1 : (_0020_0020.Count - 2);
			int index2 = (!_0020_000A_0020) ? (_0020_0020.Count - 1) : 0;
			int num = (!_0020_000A_0020) ? 1 : 0;
			Vector3D value = _0020_0020[index2] - _0020_0020[index];
			value.Normalize();
			int count = _0020.Positions.Count;
			_0020.Positions.Add(_0020_0020[index2]);
			_0020.Normals.Add(value);
			_0020.TextureCoordinates.Add(new Point(num, num));
			for (int i = 0; i < _0020_000A_000A.Count; i++)
			{
				_0020.Positions.Add(_0020.Positions[_0020_000A + i]);
				_0020.Normals.Add(value);
				_0020.TextureCoordinates.Add(new Point(num, num));
				if (i > 0)
				{
					int count2 = _0020.Positions.Count;
					if (_0020_000A_0020)
					{
						AddTriangleIndices(_0020, count, count2 - 1, count2 - 2);
					}
					else
					{
						AddTriangleIndices(_0020, count, count2 - 2, count2 - 1);
					}
				}
			}
		}
	}
}
