using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Threading;

namespace HelixToolkit.Wpf;

public class StLReader : ModelReader
{
	private static readonly Regex NormalRegex = new Regex("normal\\s*(\\S*)\\s*(\\S*)\\s*(\\S*)", RegexOptions.Compiled);

	private static readonly Regex VertexRegex = new Regex("vertex\\s*(\\S*)\\s*(\\S*)\\s*(\\S*)", RegexOptions.Compiled);

	private int index;

	private Color lastColor;

	public string Header { get; private set; }

	public IList<Material> Materials { get; private set; }

	public IList<MeshBuilder> Meshes { get; private set; }

	public StLReader(Dispatcher dispatcher = null)
		: base(dispatcher)
	{
		Meshes = new List<MeshBuilder>();
		Materials = new List<Material>();
	}

	public override Model3DGroup Read(Stream stream)
	{
		bool flag = TryReadBinary(stream);
		if (!flag)
		{
			stream.Position = 0L;
			flag = TryReadAscii(stream);
		}
		if (flag)
		{
			return ToModel3D();
		}
		return null;
	}

	public Model3DGroup ToModel3D()
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

	private static void ParseLine(string line, out string id, out string values)
	{
		line = line.Trim();
		int num = line.IndexOf(' ');
		if (num == -1)
		{
			id = line;
			values = string.Empty;
		}
		else
		{
			id = line.Substring(0, num).ToLower();
			values = line.Substring(num + 1);
		}
	}

	private static Vector3D ParseNormal(string input)
	{
		Match match = NormalRegex.Match(input);
		if (!match.Success)
		{
			throw new FileFormatException("Unexpected line.");
		}
		double x = double.Parse(match.Groups[1].Value, CultureInfo.InvariantCulture);
		double y = double.Parse(match.Groups[2].Value, CultureInfo.InvariantCulture);
		double z = double.Parse(match.Groups[3].Value, CultureInfo.InvariantCulture);
		return new Vector3D(x, y, z);
	}

	private static float ReadFloat(BinaryReader reader)
	{
		byte[] value = reader.ReadBytes(4);
		return BitConverter.ToSingle(value, 0);
	}

	private static void ReadLine(StreamReader reader, string token)
	{
		if (token == null)
		{
			throw new ArgumentNullException("token");
		}
		string line = reader.ReadLine();
		ParseLine(line, out var id, out var _);
		if (!string.Equals(token, id, StringComparison.OrdinalIgnoreCase))
		{
			throw new FileFormatException("Unexpected line.");
		}
	}

	private static ushort ReadUInt16(BinaryReader reader)
	{
		byte[] value = reader.ReadBytes(2);
		return BitConverter.ToUInt16(value, 0);
	}

	private static uint ReadUInt32(BinaryReader reader)
	{
		byte[] value = reader.ReadBytes(4);
		return BitConverter.ToUInt32(value, 0);
	}

	private static bool TryParseVertex(string line, out Point3D point)
	{
		Match match = VertexRegex.Match(line);
		if (!match.Success)
		{
			point = default(Point3D);
			return false;
		}
		double x = double.Parse(match.Groups[1].Value, CultureInfo.InvariantCulture);
		double y = double.Parse(match.Groups[2].Value, CultureInfo.InvariantCulture);
		double z = double.Parse(match.Groups[3].Value, CultureInfo.InvariantCulture);
		point = new Point3D(x, y, z);
		return true;
	}

	private void ReadFacet(StreamReader reader, string normal)
	{
		Vector3D vector3D = ParseNormal(normal);
		List<Point3D> list = new List<Point3D>();
		ReadLine(reader, "outer");
		while (true)
		{
			string line = reader.ReadLine();
			if (TryParseVertex(line, out var point))
			{
				list.Add(point);
				continue;
			}
			ParseLine(line, out var id, out var _);
			if (!(id == "endloop"))
			{
				continue;
			}
			break;
		}
		ReadLine(reader, "endfacet");
		if (Materials.Count < index + 1)
		{
			Materials.Add(base.DefaultMaterial);
		}
		if (Meshes.Count < index + 1)
		{
			Meshes.Add(new MeshBuilder(true, true, false));
		}
		Meshes[index].AddPolygon(list);
	}

	private void ReadTriangle(BinaryReader reader)
	{
		float num = ReadFloat(reader);
		float num2 = ReadFloat(reader);
		float num3 = ReadFloat(reader);
		Vector3D vector3D = new Vector3D(num, num2, num3);
		float num4 = ReadFloat(reader);
		float num5 = ReadFloat(reader);
		float num6 = ReadFloat(reader);
		Point3D p = new Point3D(num4, num5, num6);
		float num7 = ReadFloat(reader);
		float num8 = ReadFloat(reader);
		float num9 = ReadFloat(reader);
		Point3D p2 = new Point3D(num7, num8, num9);
		float num10 = ReadFloat(reader);
		float num11 = ReadFloat(reader);
		float num12 = ReadFloat(reader);
		Point3D p3 = new Point3D(num10, num11, num12);
		char[] array = Convert.ToString(ReadUInt16(reader), 2).PadLeft(16, '0').ToCharArray();
		if (array[0].Equals('1'))
		{
			int num13 = (array[15].Equals('1') ? 1 : 0);
			num13 = (array[14].Equals('1') ? (num13 + 2) : num13);
			num13 = (array[13].Equals('1') ? (num13 + 4) : num13);
			num13 = (array[12].Equals('1') ? (num13 + 8) : num13);
			num13 = (array[11].Equals('1') ? (num13 + 16) : num13);
			int value = num13 * 8;
			int num14 = (array[10].Equals('1') ? 1 : 0);
			num14 = (array[9].Equals('1') ? (num14 + 2) : num14);
			num14 = (array[8].Equals('1') ? (num14 + 4) : num14);
			num14 = (array[7].Equals('1') ? (num14 + 8) : num14);
			num14 = (array[6].Equals('1') ? (num14 + 16) : num14);
			int value2 = num14 * 8;
			int num15 = (array[5].Equals('1') ? 1 : 0);
			num15 = (array[4].Equals('1') ? (num15 + 2) : num15);
			num15 = (array[3].Equals('1') ? (num15 + 4) : num15);
			num15 = (array[2].Equals('1') ? (num15 + 8) : num15);
			num15 = (array[1].Equals('1') ? (num15 + 16) : num15);
			int value3 = num15 * 8;
			Color color = Color.FromRgb(Convert.ToByte(value3), Convert.ToByte(value2), Convert.ToByte(value));
			if (!Color.Equals(lastColor, color))
			{
				lastColor = color;
				index++;
			}
			if (Materials.Count < index + 1)
			{
				Materials.Add(MaterialHelper.CreateMaterial(color));
			}
		}
		else if (Materials.Count < index + 1)
		{
			Materials.Add(base.DefaultMaterial);
		}
		if (Meshes.Count < index + 1)
		{
			Meshes.Add(new MeshBuilder(true, true, false));
		}
		Meshes[index].AddTriangle(p, p2, p3);
	}

	private bool TryReadAscii(Stream stream)
	{
		StreamReader streamReader = new StreamReader(stream);
		Meshes.Add(new MeshBuilder(true, true, false));
		Materials.Add(base.DefaultMaterial);
		while (!streamReader.EndOfStream)
		{
			string text = streamReader.ReadLine();
			if (text == null)
			{
				continue;
			}
			text = text.Trim();
			if (text.Length != 0 && !text.StartsWith("\0") && !text.StartsWith("#") && !text.StartsWith("!") && !text.StartsWith("$"))
			{
				ParseLine(text, out var id, out var values);
				switch (id)
				{
				case "solid":
					Header = values.Trim();
					break;
				case "facet":
					ReadFacet(streamReader, values);
					break;
				}
			}
		}
		return true;
	}

	private bool TryReadBinary(Stream stream)
	{
		long length = stream.Length;
		if (length < 84)
		{
			throw new FileFormatException("Incomplete file");
		}
		BinaryReader binaryReader = new BinaryReader(stream);
		Header = Encoding.ASCII.GetString(binaryReader.ReadBytes(80)).Trim();
		uint num = ReadUInt32(binaryReader);
		if (length - 84 != num * 50)
		{
			return false;
		}
		index = 0;
		Meshes.Add(new MeshBuilder(true, true, false));
		Materials.Add(base.DefaultMaterial);
		for (int i = 0; i < num; i++)
		{
			ReadTriangle(binaryReader);
		}
		return true;
	}
}
