#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Threading;

namespace HelixToolkit.Wpf;

public class StudioReader : ModelReader
{
	private enum ChunkID
	{
		MAIN3DS = 19789,
		EDIT3DS = 15677,
		KEYF3DS = 45056,
		VERSION = 2,
		MESHVERSION = 15678,
		EDIT_MATERIAL = 45055,
		EDIT_CONFIG1 = 256,
		EDIT_CONFIG2 = 15933,
		EDIT_VIEW_P1 = 28690,
		EDIT_VIEW_P2 = 28689,
		EDIT_VIEW_P3 = 28704,
		EDIT_VIEW1 = 28673,
		EDIT_BACKGR = 4608,
		EDIT_AMBIENT = 8448,
		EDIT_OBJECT = 16384,
		EDIT_UNKNW01 = 4352,
		EDIT_UNKNW02 = 4609,
		EDIT_UNKNW03 = 4864,
		EDIT_UNKNW04 = 5120,
		EDIT_UNKNW05 = 5152,
		EDIT_UNKNW06 = 5200,
		EDIT_UNKNW07 = 5376,
		EDIT_UNKNW08 = 8704,
		EDIT_UNKNW09 = 8705,
		EDIT_UNKNW10 = 8720,
		EDIT_UNKNW11 = 8960,
		EDIT_UNKNW12 = 8962,
		EDIT_UNKNW13 = 12288,
		EDIT_UNKNW14 = EDIT_MATERIAL,
		MAT_NAME01 = 40960,
		MAT_LUMINANCE = 40976,
		MAT_DIFFUSE = 40992,
		MAT_SPECULAR = 41008,
		MAT_SHININESS = 41024,
		MAT_MAP = 41472,
		MAT_MAPFILE = 41728,
		OBJ_TRIMESH = 16640,
		OBJ_LIGHT = 17920,
		OBJ_CAMERA = 18176,
		OBJ_UNKNWN01 = 16400,
		OBJ_UNKNWN02 = 16402,
		CAM_UNKNWN01 = 18192,
		CAM_UNKNWN02 = 18208,
		LIT_OFF = 17952,
		LIT_SPOT = 17936,
		LIT_UNKNWN01 = 18010,
		TRI_VERTEXL = 16656,
		TRI_FACEL2 = 16657,
		TRI_FACEL1 = 16672,
		TRI_FACEMAT = 16688,
		TRI_TEXCOORD = 16704,
		TRI_SMOOTH = 16720,
		TRI_LOCAL = 16736,
		TRI_VISIBLE = 16741,
		KEYF_UNKNWN01 = 45065,
		KEYF_UNKNWN02 = 45066,
		KEYF_FRAMES = 45064,
		KEYF_OBJDES = 45058,
		KEYF_HIERARCHY = 45104,
		KFNAME = 45072,
		COL_RGB = 16,
		COL_TRU = 17,
		COL_UNK = 19,
		TOP = 1,
		BOTTOM = VERSION,
		LEFT = 3,
		RIGHT = 4,
		FRONT = 5,
		BACK = 6,
		USER = 7,
		CAMERA = 8,
		LIGHT = 9,
		DISABLED = COL_RGB,
		BOGUS = COL_TRU
	}

	private class Mesh
	{
		public List<Point3D> Positions { get; set; }

		public List<int> TriangleIndices { get; set; }

		public List<Point> TextureCoordinates { get; set; }

		public Material Material { get; set; }

		public Material BackMaterial { get; set; }

		public Model3D CreateModel()
		{
			MeshGeometry3D meshGeometry3D = new MeshGeometry3D
			{
				Positions = new Point3DCollection(Positions),
				TriangleIndices = new Int32Collection(TriangleIndices)
			};
			if (TextureCoordinates != null)
			{
				meshGeometry3D.TextureCoordinates = new PointCollection(TextureCoordinates);
			}
			return new GeometryModel3D(meshGeometry3D, Material)
			{
				BackMaterial = BackMaterial
			};
		}
	}

	private class FaceSet
	{
		public List<int> Faces { get; set; }

		public string Name { get; set; }
	}

	private readonly Dictionary<string, Material> materials = new Dictionary<string, Material>();

	private readonly List<Mesh> meshes = new List<Mesh>();

	public StudioReader(Dispatcher dispatcher = null)
		: base(dispatcher)
	{
	}

	public override Model3DGroup Read(Stream s)
	{
		using BinaryReader binaryReader = new BinaryReader(s);
		long length = binaryReader.BaseStream.Length;
		ChunkID chunkID = ReadChunkId(binaryReader);
		if (chunkID != ChunkID.MAIN3DS)
		{
			throw new FileFormatException("Unknown file");
		}
		int num = ReadChunkSize(binaryReader);
		if (num != length)
		{
			throw new FileFormatException("Incomplete file (file length does not match header)");
		}
		while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length)
		{
			ChunkID chunkID2 = ReadChunkId(binaryReader);
			int num2 = ReadChunkSize(binaryReader);
			switch (chunkID2)
			{
			case ChunkID.EDIT_MATERIAL:
				ReadMaterial(binaryReader, num2);
				break;
			case ChunkID.EDIT_OBJECT:
				ReadObject(binaryReader, num2);
				break;
			default:
				ReadData(binaryReader, num2 - 6);
				break;
			case ChunkID.EDIT3DS:
			case ChunkID.OBJ_TRIMESH:
			case ChunkID.OBJ_LIGHT:
			case ChunkID.OBJ_CAMERA:
				break;
			}
		}
		Model3DGroup mg = null;
		Dispatch(delegate
		{
			mg = new Model3DGroup();
			foreach (Mesh mesh in meshes)
			{
				Model3D model3D = mesh.CreateModel();
				if (base.Freeze)
				{
					model3D.Freeze();
				}
				mg.Children.Add(model3D);
			}
			if (base.Freeze)
			{
				mg.Freeze();
			}
		});
		return mg;
	}

	private ChunkID ReadChunkId(BinaryReader reader)
	{
		return (ChunkID)reader.ReadUInt16();
	}

	private int ReadChunkSize(BinaryReader reader)
	{
		return (int)reader.ReadUInt32();
	}

	private Color ReadColor(BinaryReader reader)
	{
		ChunkID chunkID = ReadChunkId(reader);
		int size = ReadChunkSize(reader);
		switch (chunkID)
		{
		case ChunkID.COL_RGB:
		{
			Debug.Assert(condition: false);
			float r2 = reader.ReadSingle();
			float g2 = reader.ReadSingle();
			float b2 = reader.ReadSingle();
			return Color.FromScRgb(1f, r2, g2, b2);
		}
		case ChunkID.COL_TRU:
		{
			byte r = reader.ReadByte();
			byte g = reader.ReadByte();
			byte b = reader.ReadByte();
			return Color.FromArgb(byte.MaxValue, r, g, b);
		}
		default:
			ReadData(reader, size);
			return Colors.White;
		}
	}

	private byte[] ReadData(BinaryReader reader, int size)
	{
		return reader.ReadBytes(size);
	}

	private List<int> ReadFaceList(BinaryReader reader)
	{
		int num = reader.ReadUInt16();
		List<int> list = new List<int>(num * 3);
		for (int i = 0; i < num; i++)
		{
			list.Add(reader.ReadUInt16());
			list.Add(reader.ReadUInt16());
			list.Add(reader.ReadUInt16());
			reader.ReadUInt16();
		}
		return list;
	}

	private List<FaceSet> ReadFaceSets(BinaryReader reader, int chunkSize)
	{
		int num = 6;
		List<FaceSet> list = new List<FaceSet>();
		while (num < chunkSize)
		{
			ChunkID chunkID = ReadChunkId(reader);
			int num2 = ReadChunkSize(reader);
			num += num2;
			switch (chunkID)
			{
			case ChunkID.TRI_FACEMAT:
			{
				string name = ReadString(reader);
				int num3 = reader.ReadUInt16();
				List<int> list2 = new List<int>();
				for (int i = 0; i < num3; i++)
				{
					list2.Add(reader.ReadUInt16());
				}
				FaceSet item = new FaceSet
				{
					Name = name,
					Faces = list2
				};
				list.Add(item);
				break;
			}
			case ChunkID.TRI_SMOOTH:
				ReadData(reader, num2 - 6);
				break;
			default:
				ReadData(reader, num2 - 6);
				break;
			}
		}
		return list;
	}

	private string ReadMatMap(BinaryReader reader, int size)
	{
		ChunkID chunkID = ReadChunkId(reader);
		int num = ReadChunkSize(reader);
		ushort num2 = reader.ReadUInt16();
		ushort num3 = reader.ReadUInt16();
		ushort num4 = reader.ReadUInt16();
		ushort num5 = reader.ReadUInt16();
		size -= 14;
		string text = ReadString(reader);
		size -= text.Length + 1;
		byte[] array = ReadData(reader, size);
		return text;
	}

	private void ReadMaterial(BinaryReader reader, int chunkSize)
	{
		int num = 6;
		string name = null;
		Color transparent = Colors.Transparent;
		Color diffuse = Colors.Transparent;
		Color specular = Colors.Transparent;
		Color transparent2 = Colors.Transparent;
		string texture = null;
		while (num < chunkSize)
		{
			ChunkID chunkID = ReadChunkId(reader);
			int num2 = ReadChunkSize(reader);
			num += num2;
			switch (chunkID)
			{
			case ChunkID.MAT_NAME01:
				name = ReadString(reader);
				break;
			case ChunkID.MAT_LUMINANCE:
				transparent = ReadColor(reader);
				break;
			case ChunkID.MAT_DIFFUSE:
				diffuse = ReadColor(reader);
				break;
			case ChunkID.MAT_SPECULAR:
				specular = ReadColor(reader);
				break;
			case ChunkID.MAT_SHININESS:
			{
				byte[] array = ReadData(reader, num2 - 6);
				break;
			}
			case ChunkID.MAT_MAP:
				texture = ReadMatMap(reader, num2 - 6);
				break;
			case ChunkID.MAT_MAPFILE:
				ReadData(reader, num2 - 6);
				break;
			default:
				ReadData(reader, num2 - 6);
				break;
			}
		}
		int specularPower = 100;
		Dispatch(delegate
		{
			MaterialGroup materialGroup = new MaterialGroup();
			if (texture != null)
			{
				string text = Path.GetExtension(texture);
				if (text != null)
				{
					text = text.ToLower();
				}
				if (text == ".tga")
				{
					texture = Path.ChangeExtension(texture, ".png");
				}
				string path = base.TexturePath ?? string.Empty;
				string text2 = Path.Combine(path, texture);
				if (File.Exists(text2))
				{
					BitmapImage image = new BitmapImage(new Uri(text2, UriKind.Relative));
					ImageBrush brush = new ImageBrush(image)
					{
						ViewportUnits = BrushMappingMode.Absolute,
						TileMode = TileMode.Tile
					};
					materialGroup.Children.Add(new DiffuseMaterial(brush));
				}
				else
				{
					materialGroup.Children.Add(new DiffuseMaterial(new SolidColorBrush(diffuse)));
				}
			}
			else
			{
				materialGroup.Children.Add(new DiffuseMaterial(new SolidColorBrush(diffuse)));
			}
			materialGroup.Children.Add(new SpecularMaterial(new SolidColorBrush(specular), specularPower));
			if (name != null)
			{
				materials[name] = materialGroup;
			}
		});
	}

	private void ReadObject(BinaryReader reader, int chunkSize)
	{
		int num = 6;
		string text = ReadString(reader);
		num += text.Length + 1;
		while (num < chunkSize)
		{
			ChunkID chunkID = ReadChunkId(reader);
			int num2 = ReadChunkSize(reader);
			num += num2;
			ChunkID chunkID2 = chunkID;
			if (chunkID2 == ChunkID.OBJ_TRIMESH)
			{
				ReadTriangularMesh(reader, num2);
			}
			else
			{
				ReadData(reader, num2 - 6);
			}
		}
	}

	private string ReadString(BinaryReader reader)
	{
		StringBuilder stringBuilder = new StringBuilder();
		while (true)
		{
			char c = (char)reader.ReadByte();
			if (c == '\0')
			{
				break;
			}
			stringBuilder.Append(c);
		}
		return stringBuilder.ToString();
	}

	private List<Point> ReadTexCoords(BinaryReader reader)
	{
		int num = reader.ReadUInt16();
		List<Point> list = new List<Point>(num);
		for (int i = 0; i < num; i++)
		{
			float num2 = reader.ReadSingle();
			float num3 = reader.ReadSingle();
			list.Add(new Point(num2, 1f - num3));
		}
		return list;
	}

	private Matrix3D ReadTransformation(BinaryReader reader)
	{
		Vector3D vector3D = ReadVector(reader);
		Vector3D vector3D2 = ReadVector(reader);
		Vector3D vector3D3 = ReadVector(reader);
		Vector3D vector3D4 = ReadVector(reader);
		return new Matrix3D
		{
			M11 = vector3D.X,
			M21 = vector3D.Y,
			M31 = vector3D.Z,
			M12 = vector3D2.X,
			M22 = vector3D2.Y,
			M32 = vector3D2.Z,
			M13 = vector3D3.X,
			M23 = vector3D3.Y,
			M33 = vector3D3.Z,
			OffsetX = vector3D4.X,
			OffsetY = vector3D4.Y,
			OffsetZ = vector3D4.Z,
			M14 = 0.0,
			M24 = 0.0,
			M34 = 0.0,
			M44 = 1.0
		};
	}

	private void ReadTriangularMesh(BinaryReader reader, int chunkSize)
	{
		int num = 6;
		List<Point3D> positions = null;
		List<int> list = null;
		List<Point> textureCoordinates = null;
		List<FaceSet> list2 = null;
		while (num < chunkSize)
		{
			ChunkID chunkID = ReadChunkId(reader);
			int num2 = ReadChunkSize(reader);
			num += num2;
			switch (chunkID)
			{
			case ChunkID.TRI_VERTEXL:
				positions = ReadVertexList(reader);
				break;
			case ChunkID.TRI_FACEL1:
				list = ReadFaceList(reader);
				num2 -= list.Count / 3 * 8 + 2;
				list2 = ReadFaceSets(reader, num2 - 6);
				break;
			case ChunkID.TRI_TEXCOORD:
				textureCoordinates = ReadTexCoords(reader);
				break;
			case ChunkID.TRI_LOCAL:
				ReadTransformation(reader);
				break;
			default:
				ReadData(reader, num2 - 6);
				break;
			}
		}
		if (list == null)
		{
			return;
		}
		if (list2 == null || list2.Count == 0)
		{
			meshes.Add(new Mesh
			{
				Positions = positions,
				TriangleIndices = ConvertFaceIndices(list, list),
				TextureCoordinates = textureCoordinates,
				Material = base.DefaultMaterial,
				BackMaterial = base.DefaultMaterial
			});
			return;
		}
		foreach (FaceSet item in list2)
		{
			List<int> triangleIndices = ConvertFaceIndices(item.Faces, list);
			Material material = null;
			if (materials.ContainsKey(item.Name))
			{
				material = materials[item.Name];
			}
			meshes.Add(new Mesh
			{
				Positions = positions,
				TriangleIndices = triangleIndices,
				TextureCoordinates = textureCoordinates,
				Material = material,
				BackMaterial = material
			});
		}
	}

	private static List<int> ConvertFaceIndices(List<int> subFaces, List<int> faces)
	{
		List<int> list = new List<int>(subFaces.Count * 3);
		foreach (int subFace in subFaces)
		{
			list.Add(faces[subFace * 3]);
			list.Add(faces[subFace * 3 + 1]);
			list.Add(faces[subFace * 3 + 2]);
		}
		return list;
	}

	private Vector3D ReadVector(BinaryReader reader)
	{
		return new Vector3D(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
	}

	private List<Point3D> ReadVertexList(BinaryReader reader)
	{
		int num = reader.ReadUInt16();
		List<Point3D> list = new List<Point3D>(num);
		for (int i = 0; i < num; i++)
		{
			float num2 = reader.ReadSingle();
			float num3 = reader.ReadSingle();
			float num4 = reader.ReadSingle();
			list.Add(new Point3D(num2, num3, num4));
		}
		return list;
	}
}
