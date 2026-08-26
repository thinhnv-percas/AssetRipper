using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class TerrainModel
{
	public double Bottom { get; set; }

	public double[] Data { get; set; }

	public int Height { get; set; }

	public double Left { get; set; }

	public double MaximumZ { get; set; }

	public double MinimumZ { get; set; }

	public Point3D Offset { get; set; }

	public double Right { get; set; }

	public TerrainTexture Texture { get; set; }

	public double Top { get; set; }

	public int Width { get; set; }

	public GeometryModel3D CreateModel(int lod)
	{
		int num = Height / lod;
		int num2 = Width / lod;
		List<Point3D> list = new List<Point3D>(num * num2);
		double x = (Left + Right) / 2.0;
		double y = (Top + Bottom) / 2.0;
		double z = (MinimumZ + MaximumZ) / 2.0;
		Offset = new Point3D(x, y, z);
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < num2; j++)
			{
				double num3 = Left + (Right - Left) * (double)j / (double)(num2 - 1);
				double num4 = Top + (Bottom - Top) * (double)i / (double)(num - 1);
				double num5 = Data[i * lod * Width + j * lod];
				num3 -= Offset.X;
				num4 -= Offset.Y;
				num5 -= Offset.Z;
				list.Add(new Point3D(num3, num4, num5));
			}
		}
		MeshBuilder meshBuilder = new MeshBuilder(generateNormals: false, generateTexCoords: false);
		meshBuilder.AddRectangularMesh(list, num2);
		MeshGeometry3D meshGeometry3D = meshBuilder.ToMesh();
		Material material = Materials.Green;
		if (Texture != null)
		{
			Texture.Calculate(this, meshGeometry3D);
			material = Texture.Material;
			meshGeometry3D.TextureCoordinates = Texture.TextureCoordinates;
		}
		return new GeometryModel3D
		{
			Geometry = meshGeometry3D,
			Material = material,
			BackMaterial = material
		};
	}

	public void Load(string source)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		string text = Path.GetExtension(source);
		if (text != null)
		{
			text = text.ToLower();
		}
		string text2 = text;
		if (!(text2 == ".btz"))
		{
			if (text2 == ".bt")
			{
				ReadTerrainFile(source);
			}
		}
		else
		{
			ReadZippedFile(source);
		}
	}

	public void ReadTerrainFile(Stream stream)
	{
		using BinaryReader binaryReader = new BinaryReader(stream);
		byte[] bytes = binaryReader.ReadBytes(10);
		ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
		string text = aSCIIEncoding.GetString(bytes);
		if (!text.StartsWith("binterr"))
		{
			throw new FileFormatException("Invalid marker.");
		}
		string text2 = text.Substring(7);
		Width = binaryReader.ReadInt32();
		Height = binaryReader.ReadInt32();
		short num = binaryReader.ReadInt16();
		bool flag = binaryReader.ReadInt16() == 1;
		short num2 = binaryReader.ReadInt16();
		short num3 = binaryReader.ReadInt16();
		short num4 = binaryReader.ReadInt16();
		Left = binaryReader.ReadDouble();
		Right = binaryReader.ReadDouble();
		Bottom = binaryReader.ReadDouble();
		Top = binaryReader.ReadDouble();
		short num5 = binaryReader.ReadInt16();
		float num6 = binaryReader.ReadSingle();
		byte[] array = binaryReader.ReadBytes(190);
		int num7 = 0;
		Data = new double[Width * Height];
		MinimumZ = double.MaxValue;
		MaximumZ = double.MinValue;
		for (int i = 0; i < Height; i++)
		{
			for (int j = 0; j < Width; j++)
			{
				double num8 = ((num != 2) ? ((double)(flag ? binaryReader.ReadSingle() : ((float)binaryReader.ReadUInt32()))) : ((double)(int)binaryReader.ReadUInt16()));
				Data[num7++] = num8;
				if (num8 < MinimumZ)
				{
					MinimumZ = num8;
				}
				if (num8 > MaximumZ)
				{
					MaximumZ = num8;
				}
			}
		}
	}

	private void ReadTerrainFile(string path)
	{
		using FileStream stream = File.OpenRead(path);
		ReadTerrainFile(stream);
	}

	private void ReadZippedFile(string source)
	{
		using FileStream stream = File.OpenRead(source);
		GZipStream stream2 = new GZipStream(stream, CompressionMode.Decompress, leaveOpen: true);
		ReadTerrainFile(stream2);
	}
}
