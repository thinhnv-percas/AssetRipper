using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class ObjExporter : Exporter<ObjExporter.ObjWriters>
{
	public class ObjWriters
	{
		public StreamWriter ObjWriter { get; set; }

		public StreamWriter MaterialsWriter { get; set; }
	}

	private readonly Dictionary<Material, string> exportedMaterials = new Dictionary<Material, string>();

	private int groupNo = 1;

	private int matNo = 1;

	private int normalIndex = 1;

	private int objectNo = 1;

	private int textureIndex = 1;

	private int vertexIndex = 1;

	public bool ExportNormals { get; set; }

	public Func<string, Stream> FileCreator { get; set; }

	public bool UseDissolveForTransparency { get; set; }

	public string Comment { get; set; }

	public string MaterialsFile { get; set; }

	public bool SwitchYZ { get; set; }

	public string TextureFolder { get; set; }

	public string TextureExtension { get; set; }

	public int TextureSize { get; set; }

	public int TextureQualityLevel { get; set; }

	public ObjExporter()
	{
		TextureExtension = ".png";
		TextureSize = 1024;
		TextureQualityLevel = 90;
		TextureFolder = ".";
		SwitchYZ = true;
		ExportNormals = false;
		FileCreator = File.Create;
	}

	public void ExportMesh(StreamWriter writer, MeshGeometry3D m, Transform3D t)
	{
		if (m == null)
		{
			throw new ArgumentNullException("m");
		}
		if (t == null)
		{
			throw new ArgumentNullException("t");
		}
		Dictionary<int, int> vertexIndexMap = new Dictionary<int, int>();
		Dictionary<int, int> textureIndexMap = new Dictionary<int, int>();
		Dictionary<int, int> normalIndexMap = new Dictionary<int, int>();
		int num = 0;
		if (m.Positions != null)
		{
			foreach (Point3D position in m.Positions)
			{
				vertexIndexMap.Add(num++, vertexIndex++);
				Point3D point3D = t.Transform(position);
				writer.WriteLine(string.Format(CultureInfo.InvariantCulture, "v {0} {1} {2}", new object[3]
				{
					point3D.X,
					SwitchYZ ? point3D.Z : point3D.Y,
					SwitchYZ ? (0.0 - point3D.Y) : point3D.Z
				}));
			}
			writer.WriteLine($"# {num} vertices");
		}
		if (m.TextureCoordinates != null)
		{
			num = 0;
			foreach (Point textureCoordinate in m.TextureCoordinates)
			{
				textureIndexMap.Add(num++, textureIndex++);
				writer.WriteLine(string.Format(CultureInfo.InvariantCulture, "vt {0} {1}", new object[2]
				{
					textureCoordinate.X,
					1.0 - textureCoordinate.Y
				}));
			}
			writer.WriteLine($"# {num} texture coordinates");
		}
		if (m.Normals != null && ExportNormals)
		{
			num = 0;
			foreach (Vector3D normal in m.Normals)
			{
				normalIndexMap.Add(num++, normalIndex++);
				writer.WriteLine(string.Format(CultureInfo.InvariantCulture, "vn {0} {1} {2}", new object[3] { normal.X, normal.Y, normal.Z }));
			}
			writer.WriteLine($"# {num} normals");
		}
		Func<int, string> func = delegate(int i0)
		{
			bool flag = textureIndexMap.ContainsKey(i0);
			bool flag2 = normalIndexMap.ContainsKey(i0);
			if (flag & flag2)
			{
				return $"{vertexIndexMap[i0]}/{textureIndexMap[i0]}/{normalIndexMap[i0]}";
			}
			if (flag)
			{
				return $"{vertexIndexMap[i0]}/{textureIndexMap[i0]}";
			}
			return flag2 ? $"{vertexIndexMap[i0]}//{normalIndexMap[i0]}" : vertexIndexMap[i0].ToString();
		};
		if (m.TriangleIndices != null)
		{
			for (int num2 = 0; num2 < m.TriangleIndices.Count; num2 += 3)
			{
				int arg = m.TriangleIndices[num2];
				int arg2 = m.TriangleIndices[num2 + 1];
				int arg3 = m.TriangleIndices[num2 + 2];
				writer.WriteLine("f {0} {1} {2}", func(arg), func(arg2), func(arg3));
			}
			writer.WriteLine($"# {m.TriangleIndices.Count / 3} faces");
		}
		writer.WriteLine();
	}

	protected override ObjWriters Create(Stream stream)
	{
		if (MaterialsFile == null)
		{
			throw new InvalidOperationException("The `MaterialsFile` property must be set.");
		}
		StreamWriter streamWriter = new StreamWriter(stream);
		if (!string.IsNullOrEmpty(Comment))
		{
			streamWriter.WriteLine("# {0}", Comment);
		}
		streamWriter.WriteLine("mtllib ./" + MaterialsFile);
		Stream stream2 = FileCreator(MaterialsFile);
		StreamWriter materialsWriter = new StreamWriter(stream2);
		return new ObjWriters
		{
			ObjWriter = streamWriter,
			MaterialsWriter = materialsWriter
		};
	}

	protected override void Close(ObjWriters writer)
	{
		writer.ObjWriter.Close();
		writer.MaterialsWriter.Close();
	}

	protected override void ExportModel(ObjWriters writer, GeometryModel3D model, Transform3D transform)
	{
		writer.ObjWriter.WriteLine("o object{0}", objectNo++);
		writer.ObjWriter.WriteLine("g group{0}", groupNo++);
		if (exportedMaterials.ContainsKey(model.Material))
		{
			string arg = exportedMaterials[model.Material];
			writer.ObjWriter.WriteLine("usemtl {0}", arg);
		}
		else
		{
			string text = $"mat{matNo++}";
			writer.ObjWriter.WriteLine("usemtl {0}", text);
			ExportMaterial(writer.MaterialsWriter, text, model.Material, model.BackMaterial);
			exportedMaterials.Add(model.Material, text);
		}
		MeshGeometry3D m = model.Geometry as MeshGeometry3D;
		ExportMesh(writer.ObjWriter, m, Transform3DHelper.CombineTransform(transform, model.Transform));
	}

	private void ExportMaterial(StreamWriter materialWriter, string matName, Material material, Material backMaterial)
	{
		materialWriter.WriteLine("newmtl {0}", matName);
		DiffuseMaterial diffuseMaterial = material as DiffuseMaterial;
		SpecularMaterial specularMaterial = material as SpecularMaterial;
		if (material is MaterialGroup materialGroup)
		{
			foreach (Material child in materialGroup.Children)
			{
				if (child is DiffuseMaterial)
				{
					diffuseMaterial = child as DiffuseMaterial;
				}
				if (child is SpecularMaterial)
				{
					specularMaterial = child as SpecularMaterial;
				}
			}
		}
		if (diffuseMaterial != null)
		{
			Color color = diffuseMaterial.AmbientColor.ChangeIntensity(0.2);
			if (diffuseMaterial.Brush is SolidColorBrush solidColorBrush)
			{
				materialWriter.WriteLine($"Kd {ToColorString(solidColorBrush.Color)}");
				if (UseDissolveForTransparency)
				{
					materialWriter.WriteLine(string.Format(CultureInfo.InvariantCulture, "d {0:F4}", new object[1] { (double)(int)solidColorBrush.Color.A / 255.0 }));
				}
				else
				{
					materialWriter.WriteLine(string.Format(CultureInfo.InvariantCulture, "Tr {0:F4}", new object[1] { (double)(int)solidColorBrush.Color.A / 255.0 }));
				}
			}
			else
			{
				string text = matName + TextureExtension;
				string arg = Path.Combine(TextureFolder, text);
				using (Stream stm = FileCreator(arg))
				{
					if (TextureExtension == ".jpg")
					{
						RenderBrush(stm, diffuseMaterial.Brush, TextureSize, TextureSize, TextureQualityLevel);
					}
					else
					{
						RenderBrush(stm, diffuseMaterial.Brush, TextureSize, TextureSize);
					}
				}
				materialWriter.WriteLine($"map_Kd {text}");
			}
		}
		int num = 1;
		if (specularMaterial != null)
		{
			materialWriter.WriteLine($"Ks {ToColorString((specularMaterial.Brush as SolidColorBrush)?.Color ?? Color.FromScRgb(1f, 0.2f, 0.2f, 0.2f))}");
			num = 2;
			materialWriter.WriteLine(string.Format(CultureInfo.InvariantCulture, "Ns {0:F4}", new object[1] { specularMaterial.SpecularPower }));
		}
		materialWriter.WriteLine($"Ns {2}");
		materialWriter.WriteLine($"Ni {1}");
		materialWriter.WriteLine($"Tf {1} {1} {1}");
		materialWriter.WriteLine("illum {0}", num);
	}

	private string ToColorString(Color color)
	{
		return string.Format(CultureInfo.InvariantCulture, "{0:F4} {1:F4} {2:F4}", new object[3]
		{
			(double)(int)color.R / 255.0,
			(double)(int)color.G / 255.0,
			(double)(int)color.B / 255.0
		});
	}
}
