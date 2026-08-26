using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Threading;

namespace HelixToolkit.Wpf;

public class ObjReader : ModelReader
{
	public class Group
	{
		private readonly List<MeshBuilder> meshBuilders;

		private readonly List<Material> materials;

		public Material Material
		{
			set
			{
				materials[materials.Count - 1] = value;
			}
		}

		public MeshBuilder MeshBuilder => meshBuilders[meshBuilders.Count - 1];

		public string Name { get; set; }

		public Group(string name, Material material)
		{
			Name = name;
			meshBuilders = new List<MeshBuilder>();
			materials = new List<Material>();
			AddMesh(material);
		}

		public void AddMesh(Material material)
		{
			MeshBuilder item = new MeshBuilder(true, true, false);
			meshBuilders.Add(item);
			materials.Add(material);
		}

		public IEnumerable<Model3D> CreateModels()
		{
			for (int i = 0; i < meshBuilders.Count; i++)
			{
				Material material = materials[i];
				MeshGeometry3D mesh = meshBuilders[i].ToMesh();
				yield return new GeometryModel3D
				{
					Geometry = mesh,
					Material = material,
					BackMaterial = material
				};
			}
		}
	}

	public class MaterialDefinition
	{
		public string AlphaMap { get; set; }

		public Color Ambient { get; set; }

		public string AmbientMap { get; set; }

		public string BumpMap { get; set; }

		public Color Diffuse { get; set; }

		public string DiffuseMap { get; set; }

		public double Dissolved { get; set; }

		public int Illumination { get; set; }

		public string Name { get; set; }

		public Color Specular { get; set; }

		public double SpecularCoefficient { get; set; }

		public string SpecularMap { get; set; }

		public Material Material { get; set; }

		public MaterialDefinition(string name)
		{
			Name = name;
			Dissolved = 1.0;
		}

		public Material GetMaterial(string texturePath)
		{
			if (Material == null)
			{
				Material = CreateMaterial(texturePath);
			}
			return Material;
		}

		private Material CreateMaterial(string texturePath)
		{
			MaterialGroup materialGroup = new MaterialGroup();
			materialGroup.SetName(Name);
			if (DiffuseMap == null)
			{
				SolidColorBrush brush = new SolidColorBrush(Diffuse)
				{
					Opacity = Dissolved
				};
				materialGroup.Children.Add(new DiffuseMaterial(brush));
			}
			else
			{
				string fullPath = Path.GetFullPath(Path.Combine(texturePath, "./" + DiffuseMap));
				if (File.Exists(fullPath))
				{
					materialGroup.Children.Add(new DiffuseMaterial(CreateTextureBrush(fullPath)));
				}
			}
			if (AmbientMap != null)
			{
				string fullPath2 = Path.GetFullPath(Path.Combine(texturePath, "./" + AmbientMap));
				if (File.Exists(fullPath2))
				{
					materialGroup.Children.Add(new EmissiveMaterial(CreateTextureBrush(fullPath2)));
				}
			}
			if (Specular.R > 0 || Specular.G > 0 || Specular.B > 0)
			{
				materialGroup.Children.Add(new SpecularMaterial(new SolidColorBrush(Specular), SpecularCoefficient));
			}
			return (materialGroup.Children.Count != 1) ? materialGroup : materialGroup.Children[0];
		}

		private ImageBrush CreateTextureBrush(string path)
		{
			BitmapImage image = new BitmapImage(new Uri(path, UriKind.Relative));
			return new ImageBrush(image)
			{
				Opacity = Dissolved,
				ViewportUnits = BrushMappingMode.Absolute,
				TileMode = TileMode.Tile
			};
		}
	}

	private readonly Dictionary<long, Dictionary<Tuple<int, int, int>, int>> smoothingGroupMaps;

	private long currentSmoothingGroup;

	private int currentLineNo;

	public bool IgnoreErrors { get; set; }

	public bool SwitchYZ { get; set; }

	public bool SkipTransparencyValues { get; set; }

	public bool IsSmoothingDefault
	{
		set
		{
			currentSmoothingGroup = (value ? 1 : 0);
		}
	}

	public IList<Group> Groups { get; private set; }

	public Dictionary<string, MaterialDefinition> Materials { get; private set; }

	private Material CurrentMaterial { get; set; }

	private Group CurrentGroup
	{
		get
		{
			if (Groups.Count == 0)
			{
				AddGroup("default");
			}
			return Groups[Groups.Count - 1];
		}
	}

	private IList<Vector3D> Normals { get; set; }

	private IList<Point3D> Points { get; set; }

	private StreamReader Reader { get; set; }

	private IList<Point> TextureCoordinates { get; set; }

	public ObjReader(Dispatcher dispatcher = null)
		: base(dispatcher)
	{
		IgnoreErrors = false;
		SwitchYZ = false;
		IsSmoothingDefault = true;
		SkipTransparencyValues = true;
		Points = new List<Point3D>();
		TextureCoordinates = new List<Point>();
		Normals = new List<Vector3D>();
		Groups = new List<Group>();
		Materials = new Dictionary<string, MaterialDefinition>();
		smoothingGroupMaps = new Dictionary<long, Dictionary<Tuple<int, int, int>, int>>();
	}

	public override Model3DGroup Read(string path)
	{
		base.TexturePath = Path.GetDirectoryName(path);
		using FileStream s = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
		return Read(s);
	}

	public override Model3DGroup Read(Stream s)
	{
		StreamReader streamReader = (Reader = new StreamReader(s));
		using (streamReader)
		{
			currentLineNo = 0;
			while (!Reader.EndOfStream)
			{
				currentLineNo++;
				string text = Reader.ReadLine();
				if (text == null)
				{
					break;
				}
				text = text.Trim();
				while (text.EndsWith("\\"))
				{
					string text2 = Reader.ReadLine();
					while (text2.Length == 0)
					{
						text2 = Reader.ReadLine();
					}
					text = text.TrimEnd('\\') + text2;
				}
				if (!text.StartsWith("#") && text.Length != 0)
				{
					SplitLine(text, out var keyword, out var arguments);
					switch (keyword.ToLower())
					{
					case "v":
						AddVertex(arguments);
						break;
					case "vt":
						AddTexCoord(arguments);
						break;
					case "vn":
						AddNormal(arguments);
						break;
					case "f":
						AddFace(arguments);
						break;
					case "g":
						AddGroup(arguments);
						break;
					case "s":
						SetSmoothingGroup(arguments);
						break;
					case "mtllib":
						LoadMaterialLib(arguments);
						break;
					case "usemtl":
						EnsureNewMesh();
						SetMaterial(arguments);
						break;
					case "usemap":
						EnsureNewMesh();
						break;
					}
				}
			}
		}
		return BuildModel();
	}

	public Model3DGroup ReadZ(string path)
	{
		base.TexturePath = Path.GetDirectoryName(path);
		using FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
		GZipStream s = new GZipStream(stream, CompressionMode.Decompress, leaveOpen: true);
		return Read(s);
	}

	private static Color ColorParse(string values)
	{
		IList<double> list = Split(values);
		return Color.FromRgb((byte)(list[0] * 255.0), (byte)(list[1] * 255.0), (byte)(list[2] * 255.0));
	}

	private static double DoubleParse(string input)
	{
		return double.Parse(input, CultureInfo.InvariantCulture);
	}

	private static IList<double> Split(string input)
	{
		input = input.Trim();
		string[] array = input.SplitOnWhitespace();
		double[] array2 = new double[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = DoubleParse(array[i]);
		}
		return array2;
	}

	private static void SplitLine(string line, out string keyword, out string arguments)
	{
		int num = line.IndexOf(' ');
		if (num < 0)
		{
			keyword = line;
			arguments = null;
		}
		else
		{
			keyword = line.Substring(0, num);
			arguments = line.Substring(num + 1);
		}
	}

	private void AddGroup(string name)
	{
		Groups.Add(new Group(name, CurrentMaterial ?? base.DefaultMaterial));
		smoothingGroupMaps.Clear();
	}

	private void EnsureNewMesh()
	{
		if (CurrentGroup.MeshBuilder.TriangleIndices.Count != 0)
		{
			CurrentGroup.AddMesh(CurrentMaterial ?? base.DefaultMaterial);
			smoothingGroupMaps.Clear();
		}
	}

	private void SetSmoothingGroup(string values)
	{
		long result;
		if (values == "off")
		{
			currentSmoothingGroup = 0L;
		}
		else if (long.TryParse(values, out result))
		{
			currentSmoothingGroup = result;
		}
		else if (!IgnoreErrors)
		{
			throw new FileFormatException($"Invalid smoothing group ({values}) at line {currentLineNo}.");
		}
	}

	private void AddFace(string values)
	{
		Group currentGroup = CurrentGroup;
		MeshBuilder meshBuilder = currentGroup.MeshBuilder;
		Point3DCollection positions = meshBuilder.Positions;
		PointCollection textureCoordinates = meshBuilder.TextureCoordinates;
		Vector3DCollection normals = meshBuilder.Normals;
		Dictionary<Tuple<int, int, int>, int> value = null;
		if (currentSmoothingGroup != 0 && !smoothingGroupMaps.TryGetValue(currentSmoothingGroup, out value))
		{
			value = new Dictionary<Tuple<int, int, int>, int>();
			smoothingGroupMaps.Add(currentSmoothingGroup, value);
		}
		string[] array = values.SplitOnWhitespace();
		List<int> list = new List<int>();
		string[] array2 = array;
		foreach (string text in array2)
		{
			if (string.IsNullOrEmpty(text))
			{
				continue;
			}
			string[] array3 = text.Split('/');
			int num = int.Parse(array3[0]);
			int num2 = ((array3.Length > 1 && array3[1].Length > 0) ? int.Parse(array3[1]) : int.MaxValue);
			int num3 = ((array3.Length > 2 && array3[2].Length > 0) ? int.Parse(array3[2]) : int.MaxValue);
			if (num < 0)
			{
				num = Points.Count + num + 1;
			}
			if (num2 < 0)
			{
				num2 = TextureCoordinates.Count + num2 + 1;
			}
			if (num3 < 0)
			{
				num3 = Normals.Count + num3 + 1;
			}
			if (num - 1 >= Points.Count)
			{
				if (IgnoreErrors)
				{
					return;
				}
				throw new FileFormatException($"Invalid vertex index ({num}) on line {currentLineNo}.");
			}
			if (num2 == int.MaxValue)
			{
				meshBuilder.CreateTextureCoordinates = false;
			}
			if (num3 == int.MaxValue)
			{
				meshBuilder.CreateNormals = false;
			}
			if (meshBuilder.CreateTextureCoordinates && num2 - 1 >= TextureCoordinates.Count)
			{
				if (IgnoreErrors)
				{
					return;
				}
				throw new FileFormatException($"Invalid texture coordinate index ({num2}) on line {currentLineNo}.");
			}
			if (meshBuilder.CreateNormals && num3 - 1 >= Normals.Count)
			{
				if (IgnoreErrors)
				{
					return;
				}
				throw new FileFormatException($"Invalid normal index ({num3}) on line {currentLineNo}.");
			}
			bool flag = true;
			if (value != null)
			{
				Tuple<int, int, int> key = Tuple.Create(num, num2, num3);
				if (value.TryGetValue(key, out var value2))
				{
					flag = false;
				}
				else
				{
					value2 = positions.Count;
					value.Add(key, value2);
				}
				list.Add(value2);
			}
			else
			{
				list.Add(positions.Count);
			}
			if (flag)
			{
				positions.Add(Points[num - 1]);
				if (meshBuilder.CreateTextureCoordinates)
				{
					textureCoordinates.Add(TextureCoordinates[num2 - 1]);
				}
				if (meshBuilder.CreateNormals)
				{
					normals.Add(Normals[num3 - 1]);
				}
			}
		}
		if (list.Count <= 4)
		{
			meshBuilder.AddPolygon(list);
		}
		else
		{
			meshBuilder.AddPolygonByTriangulation(list);
		}
	}

	private void AddNormal(string values)
	{
		IList<double> list = Split(values);
		if (SwitchYZ)
		{
			Normals.Add(new Vector3D(list[0], 0.0 - list[2], list[1]));
		}
		else
		{
			Normals.Add(new Vector3D(list[0], list[1], list[2]));
		}
	}

	private void AddTexCoord(string values)
	{
		IList<double> list = Split(values);
		TextureCoordinates.Add(new Point(list[0], 1.0 - list[1]));
	}

	private void AddVertex(string values)
	{
		IList<double> list = Split(values);
		if (SwitchYZ)
		{
			Points.Add(new Point3D(list[0], 0.0 - list[2], list[1]));
		}
		else
		{
			Points.Add(new Point3D(list[0], list[1], list[2]));
		}
	}

	private Model3DGroup BuildModel()
	{
		Model3DGroup modelGroup = null;
		Dispatch(delegate
		{
			modelGroup = new Model3DGroup();
			foreach (Group group in Groups)
			{
				foreach (Model3D item in group.CreateModels())
				{
					if (base.Freeze)
					{
						item.Freeze();
					}
					modelGroup.Children.Add(item);
				}
			}
			if (base.Freeze)
			{
				modelGroup.Freeze();
			}
		});
		return modelGroup;
	}

	private Material GetMaterial(string materialName)
	{
		if (!string.IsNullOrEmpty(materialName) && Materials.TryGetValue(materialName, out var mat))
		{
			Material m = null;
			Dispatch(delegate
			{
				m = mat.GetMaterial(base.TexturePath);
			});
			return m;
		}
		return base.DefaultMaterial;
	}

	private void LoadMaterialLib(string mtlFile)
	{
		string fullPath = Path.GetFullPath(Path.Combine(base.TexturePath, "./" + mtlFile));
		if (!File.Exists(fullPath))
		{
			return;
		}
		using StreamReader streamReader = new StreamReader(fullPath);
		MaterialDefinition materialDefinition = null;
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
			SplitLine(text, out var keyword, out var arguments);
			switch (keyword.ToLower())
			{
			case "newmtl":
				if (arguments != null)
				{
					if (Materials.ContainsKey(arguments))
					{
						materialDefinition = null;
						break;
					}
					materialDefinition = new MaterialDefinition(arguments);
					Materials.Add(arguments, materialDefinition);
				}
				break;
			case "ka":
				if (materialDefinition != null && arguments != null)
				{
					materialDefinition.Ambient = ColorParse(arguments);
				}
				break;
			case "kd":
				if (materialDefinition != null && arguments != null)
				{
					materialDefinition.Diffuse = ColorParse(arguments);
				}
				break;
			case "ks":
				if (materialDefinition != null && arguments != null)
				{
					materialDefinition.Specular = ColorParse(arguments);
				}
				break;
			case "ns":
				if (materialDefinition != null && arguments != null)
				{
					materialDefinition.SpecularCoefficient = DoubleParse(arguments);
				}
				break;
			case "d":
				if (materialDefinition != null && arguments != null)
				{
					materialDefinition.Dissolved = DoubleParse(arguments);
				}
				break;
			case "tr":
				if (!SkipTransparencyValues && materialDefinition != null && arguments != null)
				{
					materialDefinition.Dissolved = DoubleParse(arguments);
				}
				break;
			case "illum":
				if (materialDefinition != null && arguments != null)
				{
					materialDefinition.Illumination = int.Parse(arguments);
				}
				break;
			case "map_ka":
				if (materialDefinition != null)
				{
					materialDefinition.AmbientMap = arguments;
				}
				break;
			case "map_kd":
				if (materialDefinition != null)
				{
					materialDefinition.DiffuseMap = arguments;
				}
				break;
			case "map_ks":
				if (materialDefinition != null)
				{
					materialDefinition.SpecularMap = arguments;
				}
				break;
			case "map_d":
				if (materialDefinition != null)
				{
					materialDefinition.AlphaMap = arguments;
				}
				break;
			case "map_bump":
			case "bump":
				if (materialDefinition != null)
				{
					materialDefinition.BumpMap = arguments;
				}
				break;
			}
		}
	}

	private void SetMaterial(string materialName)
	{
		Group currentGroup = CurrentGroup;
		Material material = (CurrentMaterial = GetMaterial(materialName));
		currentGroup.Material = material;
	}
}
