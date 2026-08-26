using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Media.Media3D;
using System.Windows.Threading;

namespace HelixToolkit.Wpf;

public class OffReader : ModelReader
{
	public IList<int[]> Faces { get; private set; }

	public IList<Point3D> Vertices { get; private set; }

	public OffReader(Dispatcher dispatcher = null)
		: base(dispatcher)
	{
		Vertices = new List<Point3D>();
		Faces = new List<int[]>();
	}

	public Mesh3D CreateMesh()
	{
		Mesh3D mesh3D = new Mesh3D();
		foreach (Point3D vertex in Vertices)
		{
			mesh3D.Vertices.Add(vertex);
		}
		foreach (int[] face in Faces)
		{
			mesh3D.Faces.Add((int[])face.Clone());
		}
		return mesh3D;
	}

	public MeshGeometry3D CreateMeshGeometry3D()
	{
		MeshBuilder meshBuilder = new MeshBuilder(generateNormals: false, generateTexCoords: false);
		foreach (Point3D vertex in Vertices)
		{
			meshBuilder.Positions.Add(vertex);
		}
		foreach (int[] face in Faces)
		{
			meshBuilder.AddTriangleFan(face);
		}
		return meshBuilder.ToMesh();
	}

	public Model3DGroup CreateModel3D()
	{
		Model3DGroup modelGroup = null;
		Dispatch(delegate
		{
			modelGroup = new Model3DGroup();
			MeshGeometry3D geometry = CreateMeshGeometry3D();
			GeometryModel3D geometryModel3D = new GeometryModel3D
			{
				Geometry = geometry,
				Material = base.DefaultMaterial
			};
			geometryModel3D.BackMaterial = geometryModel3D.Material;
			if (base.Freeze)
			{
				geometryModel3D.Freeze();
			}
			modelGroup.Children.Add(geometryModel3D);
			if (base.Freeze)
			{
				modelGroup.Freeze();
			}
		});
		return modelGroup;
	}

	public void Load(Stream s)
	{
		using StreamReader streamReader = new StreamReader(s);
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		int num = 3;
		bool flag5 = false;
		bool flag6 = false;
		int num2 = 0;
		int num3 = 0;
		while (!streamReader.EndOfStream)
		{
			string text = streamReader.ReadLine();
			if (text == null)
			{
				break;
			}
			text = text.Trim();
			if (text.StartsWith("#") || text.Length == 0)
			{
				continue;
			}
			if (flag5)
			{
				int[] intValues = GetIntValues(text);
				num = intValues[0];
				flag5 = false;
			}
			else if (text.Contains("OFF"))
			{
				flag = text.Contains("N");
				flag3 = text.Contains("C");
				flag2 = text.Contains("ST");
				if (text.Contains("4"))
				{
					flag4 = true;
				}
				if (text.Contains("n"))
				{
					flag5 = true;
				}
				flag6 = true;
			}
			else if (flag6)
			{
				int[] intValues2 = GetIntValues(text);
				num2 = intValues2[0];
				num3 = intValues2[1];
				flag6 = false;
			}
			else if (Vertices.Count < num2)
			{
				double[] array = new double[num];
				double[] values = GetValues(text);
				int num4 = 0;
				for (int i = 0; i < num; i++)
				{
					array[i] = values[num4++];
				}
				double[] array2 = new double[num];
				double[] array3 = new double[2];
				double num5 = 0.0;
				if (flag4)
				{
					num5 = values[num4++];
				}
				if (flag)
				{
					for (int j = 0; j < num; j++)
					{
						array2[j] = values[num4++];
					}
				}
				if (flag3)
				{
				}
				if (flag2)
				{
					for (int k = 0; k < 2; k++)
					{
						array3[k] = values[num4++];
					}
				}
				Vertices.Add(new Point3D(array[0], array[1], array[2]));
			}
			else if (Faces.Count < num3)
			{
				int[] intValues3 = GetIntValues(text);
				int num6 = intValues3[0];
				int[] array4 = new int[num6];
				for (int l = 0; l < num6; l++)
				{
					array4[l] = intValues3[l + 1];
				}
				if (flag3)
				{
				}
				Faces.Add(array4);
			}
		}
	}

	public override Model3DGroup Read(Stream s)
	{
		Load(s);
		return CreateModel3D();
	}

	private static int[] GetIntValues(string input)
	{
		string[] array = RemoveComments(input).SplitOnWhitespace();
		int[] array2 = new int[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = (int)double.Parse(array[i], CultureInfo.InvariantCulture);
		}
		return array2;
	}

	private static double[] GetValues(string input)
	{
		string[] array = RemoveComments(input).SplitOnWhitespace();
		double[] array2 = new double[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = double.Parse(array[i], CultureInfo.InvariantCulture);
		}
		return array2;
	}

	private static string RemoveComments(string input)
	{
		int num = input.IndexOf('#');
		if (num >= 0)
		{
			return input.Substring(0, num);
		}
		return input;
	}
}
