using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Media.Media3D;
using System.Windows.Threading;

namespace HelixToolkit.Wpf;

public class LwoReader : ModelReader
{
	public IList<Material> Materials { get; private set; }

	public IList<MeshBuilder> Meshes { get; private set; }

	public IList<string> Surfaces { get; private set; }

	private IList<Point3D> Points { get; set; }

	public LwoReader(Dispatcher dispatcher = null)
		: base(dispatcher)
	{
	}

	public override Model3DGroup Read(Stream s)
	{
		using BinaryReader binaryReader = new BinaryReader(s);
		long length = binaryReader.BaseStream.Length;
		string text = ReadChunkId(binaryReader);
		if (text != "FORM")
		{
			throw new FileFormatException("Unknown file");
		}
		int num = ReadChunkSize(binaryReader);
		if (num + 8 != length)
		{
			throw new FileFormatException("Incomplete file (file length does not match header)");
		}
		string text2 = ReadChunkId(binaryReader);
		string text3 = text2;
		if (!(text3 == "LWOB"))
		{
			if (text3 == "LWO2")
			{
				throw new FileFormatException("LWO2 is not yet supported.");
			}
			throw new FileFormatException("Unknown file format (" + text2 + ").");
		}
		while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length)
		{
			string text4 = ReadChunkId(binaryReader);
			int size = ReadChunkSize(binaryReader);
			switch (text4)
			{
			case "PNTS":
				ReadPoints(binaryReader, size);
				break;
			case "SRFS":
				ReadSurface(binaryReader, size);
				break;
			case "POLS":
				ReadPolygons(binaryReader, size);
				break;
			default:
			{
				byte[] array = ReadData(binaryReader, size);
				break;
			}
			}
		}
		return BuildModel();
	}

	private Model3DGroup BuildModel()
	{
		Model3DGroup modelGroup = null;
		Dispatch(delegate
		{
			modelGroup = new Model3DGroup();
			int num = 0;
			foreach (MeshBuilder mesh in Meshes)
			{
				GeometryModel3D geometryModel3D = new GeometryModel3D
				{
					Geometry = mesh.ToMesh(),
					Material = Materials[num],
					BackMaterial = Materials[num]
				};
				if (base.Freeze)
				{
					geometryModel3D.Freeze();
				}
				modelGroup.Children.Add(geometryModel3D);
				num++;
			}
			if (base.Freeze)
			{
				modelGroup.Freeze();
			}
		});
		return modelGroup;
	}

	private string ReadChunkId(BinaryReader reader)
	{
		char[] value = reader.ReadChars(4);
		return new string(value);
	}

	private int ReadChunkSize(BinaryReader reader)
	{
		return ReadInt(reader);
	}

	private byte[] ReadData(BinaryReader reader, int size)
	{
		return reader.ReadBytes(size);
	}

	private float ReadFloat(BinaryReader reader)
	{
		byte[] array = reader.ReadBytes(4);
		return BitConverter.ToSingle(new byte[4]
		{
			array[3],
			array[2],
			array[1],
			array[0]
		}, 0);
	}

	private int ReadInt(BinaryReader reader)
	{
		byte[] array = reader.ReadBytes(4);
		return BitConverter.ToInt32(new byte[4]
		{
			array[3],
			array[2],
			array[1],
			array[0]
		}, 0);
	}

	private void ReadPoints(BinaryReader reader, int size)
	{
		int num = size / 4 / 3;
		Points = new List<Point3D>(num);
		for (int i = 0; i < num; i++)
		{
			float num2 = ReadFloat(reader);
			float num3 = ReadFloat(reader);
			float num4 = ReadFloat(reader);
			Points.Add(new Point3D(num2, num3, num4));
		}
	}

	private void ReadPolygons(BinaryReader reader, int size)
	{
		while (size > 0)
		{
			short num = ReadShortInt(reader);
			if (num <= 0)
			{
				throw new NotSupportedException("details are not supported");
			}
			List<Point3D> list = new List<Point3D>(num);
			for (int i = 0; i < num; i++)
			{
				int index = ReadShortInt(reader);
				list.Add(Points[index]);
			}
			short num2 = ReadShortInt(reader);
			size -= (2 + num) * 2;
			Meshes[num2 - 1].AddTriangleFan(list);
		}
	}

	private short ReadShortInt(BinaryReader reader)
	{
		byte[] array = reader.ReadBytes(2);
		return BitConverter.ToInt16(new byte[2]
		{
			array[1],
			array[0]
		}, 0);
	}

	private string ReadString(BinaryReader reader, int size)
	{
		byte[] bytes = reader.ReadBytes(size);
		ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
		string text = aSCIIEncoding.GetString(bytes);
		return text.Trim(default(char));
	}

	private void ReadSurface(BinaryReader reader, int size)
	{
		Surfaces = new List<string>();
		Meshes = new List<MeshBuilder>();
		Materials = new List<Material>();
		string text = ReadString(reader, size);
		string[] array = text.Split(default(char));
		for (int i = 0; i < array.Length; i++)
		{
			string text2 = array[i];
			Surfaces.Add(text2);
			Meshes.Add(new MeshBuilder(generateNormals: false, generateTexCoords: false));
			Materials.Add(base.DefaultMaterial);
			if ((text2.Length + 1) % 2 == 1)
			{
				i++;
			}
		}
	}
}
