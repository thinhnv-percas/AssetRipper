#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Xml;

namespace HelixToolkit.Wpf;

public class KerkytheaExporter : Exporter<KerkytheaExporter.KerkytheaWriter>
{
	public enum RenderSettings
	{
		RayTracer,
		PhotonMap,
		MetropolisLightTransport
	}

	public class KerkytheaWriter
	{
		private readonly XmlWriter writer;

		private readonly HashSet<string> names = new HashSet<string>();

		private readonly Dictionary<Brush, string> textureFiles = new Dictionary<Brush, string>();

		public KerkytheaWriter(Stream stream)
		{
			XmlWriterSettings settings = new XmlWriterSettings
			{
				Indent = true
			};
			writer = XmlWriter.Create(stream, settings);
		}

		public void WriteStartElement(string localName)
		{
			writer.WriteStartElement(localName);
		}

		public void WriteAttributeString(string name, string value)
		{
			writer.WriteAttributeString(name, value);
		}

		public void WriteEndElement()
		{
			writer.WriteEndElement();
		}

		public void WriteFullEndElement()
		{
			writer.WriteFullEndElement();
		}

		public void WriteStartDocument()
		{
			writer.WriteStartDocument();
		}

		public void Close()
		{
			writer.Close();
		}

		public void WriteParameter(string name, string type, string value)
		{
			writer.WriteStartElement("Parameter");
			writer.WriteAttributeString("Name", name);
			writer.WriteAttributeString("Type", type);
			writer.WriteAttributeString("Value", value);
			writer.WriteEndElement();
		}

		public void WriteParameter(string name, string value)
		{
			WriteParameter(name, "String", value);
		}

		public void WriteParameter(string name, Color color)
		{
			WriteParameter(name, "RGB", ToKerkytheaString(color));
		}

		public void WriteParameter(string name, bool flag)
		{
			WriteParameter(name, "Boolean", flag ? "1" : "0");
		}

		public void WriteParameter(string name, double value)
		{
			WriteParameter(name, "Real", value.ToString(CultureInfo.InvariantCulture));
		}

		public void WriteParameter(string name, int value)
		{
			WriteParameter(name, "Integer", value.ToString(CultureInfo.InvariantCulture));
		}

		public void WriteTransform(string name, Matrix3D m)
		{
			string value = string.Format(CultureInfo.InvariantCulture, "{0:0.######} {1:0.######} {2:0.######} {3:0.######} {4:0.######} {5:0.######} {6:0.######} {7:0.######} {8:0.######} {9:0.######} {10:0.######} {11:0.######}", m.M11, m.M12, m.M13, m.OffsetX, m.M21, m.M22, m.M23, m.OffsetY, m.M31, m.M32, m.M33, m.OffsetZ);
			WriteParameter(name, "Transform", value);
		}

		public void WriteEndObject()
		{
			writer.WriteFullEndElement();
		}

		public void WriteObject(string identifier, string label, string name, string type)
		{
			WriteStartObject(identifier, label, name, type);
			WriteEndObject();
		}

		public void WriteStartObject(string identifier, string label, string name, string type)
		{
			writer.WriteStartElement("Object");
			writer.WriteAttributeString("Identifier", identifier);
			writer.WriteAttributeString("Label", label);
			writer.WriteAttributeString("Name", name);
			writer.WriteAttributeString("Type", type);
		}

		public void WriteEndDocument()
		{
			writer.WriteEndDocument();
		}

		public void Write(XmlNode xmlNode)
		{
			xmlNode.WriteTo(writer);
		}

		public bool TryGetTexture(Brush brush, out string textureFile)
		{
			return textureFiles.TryGetValue(brush, out textureFile);
		}

		public void AddTexture(Brush brush, string filename)
		{
			textureFiles.Add(brush, filename);
		}

		public string GetUniqueName(string name, string defaultName)
		{
			if (string.IsNullOrEmpty(name))
			{
				int num = 1;
				while (true)
				{
					name = defaultName + num;
					if (!names.Contains(name))
					{
						break;
					}
					num++;
				}
			}
			names.Add(name);
			return name;
		}
	}

	private readonly Dictionary<Material, XmlDocument> registeredMaterials = new Dictionary<Material, XmlDocument>();

	public string Aperture { get; set; }

	public Color BackgroundColor { get; set; }

	public Func<string, Stream> FileCreator { get; set; }

	public double FocalLength { get; set; }

	public double FocusDistance { get; set; }

	public int Height { get; set; }

	public int LensSamples { get; set; }

	public double LightMultiplier { get; set; }

	public string Name { get; set; }

	public Color ReflectionColor { get; set; }

	public bool Reflections { get; set; }

	public RenderSettings RenderSetting { get; set; }

	public Color ShadowColor { get; set; }

	public bool Shadows { get; set; }

	public bool SoftShadows { get; set; }

	public int TextureHeight { get; set; }

	public string TexturePath { get; set; }

	public int TextureWidth { get; set; }

	public int Threads { get; set; }

	public int Width { get; set; }

	public KerkytheaExporter()
	{
		Name = "My Scene";
		BackgroundColor = Colors.Black;
		ReflectionColor = Colors.Gray;
		Reflections = true;
		Shadows = true;
		SoftShadows = true;
		LightMultiplier = 3.0;
		Threads = 2;
		ShadowColor = Color.FromArgb(byte.MaxValue, 100, 100, 100);
		RenderSetting = RenderSettings.RayTracer;
		Aperture = "Pinhole";
		FocusDistance = 1.0;
		LensSamples = 3;
		Width = 500;
		Height = 500;
		TextureWidth = 1024;
		TextureHeight = 1024;
		FileCreator = File.Create;
	}

	public void ExportMesh(KerkytheaWriter writer, MeshGeometry3D m)
	{
		writer.WriteStartObject("Triangular Mesh", "Triangular Mesh", string.Empty, "Surface");
		writer.WriteStartElement("Parameter");
		writer.WriteAttributeString("Name", "Vertex List");
		writer.WriteAttributeString("Type", "Point3D List");
		writer.WriteAttributeString("Value", m.Positions.Count.ToString());
		foreach (Point3D position in m.Positions)
		{
			writer.WriteStartElement("P");
			writer.WriteAttributeString("xyz", ToKerkytheaString(position));
			writer.WriteEndElement();
		}
		writer.WriteFullEndElement();
		int num = m.TriangleIndices.Count / 3;
		if (m.Normals != null && m.Normals.Count > 0)
		{
			writer.WriteStartElement("Parameter");
			writer.WriteAttributeString("Name", "Normal List");
			writer.WriteAttributeString("Type", "Point3D List");
			writer.WriteAttributeString("Value", m.TriangleIndices.Count.ToString());
			foreach (int triangleIndex in m.TriangleIndices)
			{
				if (triangleIndex < m.Normals.Count)
				{
					Vector3D vector = m.Normals[triangleIndex];
					writer.WriteStartElement("P");
					writer.WriteAttributeString("xyz", ToKerkytheaString(vector));
					writer.WriteEndElement();
				}
			}
			writer.WriteFullEndElement();
		}
		writer.WriteStartElement("Parameter");
		writer.WriteAttributeString("Name", "Index List");
		writer.WriteAttributeString("Type", "Triangle Index List");
		writer.WriteAttributeString("Value", num.ToString());
		for (int i = 0; i < num; i++)
		{
			int num2 = i * 3;
			int num3 = m.TriangleIndices[num2];
			int num4 = m.TriangleIndices[num2 + 1];
			int num5 = m.TriangleIndices[num2 + 2];
			writer.WriteStartElement("F");
			writer.WriteAttributeString("ijk", $"{num3} {num4} {num5}");
			writer.WriteEndElement();
		}
		writer.WriteFullEndElement();
		writer.WriteParameter("Smooth", flag: true);
		writer.WriteParameter("AA Tolerance", 15.0);
		writer.WriteEndObject();
	}

	public void RegisterMaterial(Material m, Stream stream)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.Load(stream);
		registeredMaterials.Add(m, xmlDocument);
	}

	public void WriteMetropolisLightTransport(KerkytheaWriter writer, string name)
	{
		writer.WriteStartObject("./Ray Tracers/" + name, "Metropolis Light Transport", name, "Ray Tracer");
		writer.WriteParameter("Max Ray Tracing Depth", 100);
		writer.WriteParameter("Max Iterations", 10000);
		writer.WriteParameter("Linear Lightflow", flag: true);
		writer.WriteParameter("Seed Paths", 50000);
		writer.WriteParameter("Large Step Probability", 0.2);
		writer.WriteParameter("Max Mutation Distance", 0.02);
		writer.WriteParameter("Live Probability", 0.7);
		writer.WriteParameter("Max Consecutive Rejections", 200);
		writer.WriteParameter("Bidirectional", flag: true);
		writer.WriteParameter("Super Sampling", "3x3");
		writer.WriteParameter("Image Filename", "temp.jpg");
		writer.WriteParameter("Random Seed", "Automatic");
		writer.WriteEndObject();
	}

	public void WriteStandardRayTracer(KerkytheaWriter writer, string name)
	{
		writer.WriteStartObject("./Ray Tracers/" + name, "Standard Ray Tracer", name, "Ray Tracer");
		writer.WriteParameter("Rasterization", "Auto");
		writer.WriteParameter("Antialiasing", "Production AA");
		writer.WriteParameter("Antialiasing Filter", "Mitchell-Netravali 0.5 0.8");
		writer.WriteParameter("Antialiasing Threshold", 0.3);
		writer.WriteParameter("Texture Filtering", flag: true);
		writer.WriteParameter("Ambient Lighting", flag: true);
		writer.WriteParameter("Direct Lighting", flag: true);
		writer.WriteParameter("Sky Lighting", flag: true);
		writer.WriteParameter("Brightness Threshold", 0.002);
		writer.WriteParameter("Max Ray Tracing Depth", 5);
		writer.WriteParameter("Max Scatter Bounces", 5);
		writer.WriteParameter("Max Dirac Bounces", 5);
		writer.WriteParameter("Irradiance Precomputation", 4);
		writer.WriteParameter("Irradiance Scale", Colors.White);
		writer.WriteParameter("Linear Lightflow", flag: true);
		writer.WriteParameter("Max Iterations", 5);
		writer.WriteParameter("Super Sampling", "None");
		writer.WriteParameter("Image Filename", "temp.jpg");
		writer.WriteParameter("./Sampling Criteria/Diffuse Samples", 1024);
		writer.WriteParameter("./Sampling Criteria/Specular Samples", 32);
		writer.WriteParameter("./Sampling Criteria/Dispersion Samples", flag: true);
		writer.WriteParameter("./Sampling Criteria/Trace Diffusers", flag: false);
		writer.WriteParameter("./Sampling Criteria/Trace Translucencies", flag: false);
		writer.WriteParameter("./Sampling Criteria/Trace Fuzzy Reflections", flag: true);
		writer.WriteParameter("./Sampling Criteria/Trace Fuzzy Refractions", flag: true);
		writer.WriteParameter("./Sampling Criteria/Trace Reflections", flag: true);
		writer.WriteParameter("./Sampling Criteria/Trace Refractions", flag: true);
		writer.WriteParameter("./Sampling Criteria/Random Generator", "Pure");
		writer.WriteEndObject();
	}

	public void WriteThreadedRaytracer(KerkytheaWriter writer, int threads)
	{
		writer.WriteStartObject("./Ray Tracers/Threaded Ray Tracer", "Threaded Ray Tracer", "Threaded Ray Tracer", "Ray Tracer");
		for (int i = 0; i < threads; i++)
		{
			writer.WriteParameter("Thread #" + i, "#" + i);
		}
		writer.WriteParameter("Network Mode", "None");
		writer.WriteParameter("Listening Port", 6200);
		writer.WriteParameter("Host", "127.0.0.1");
		writer.WriteEndObject();
	}

	protected override KerkytheaWriter Create(Stream stream)
	{
		return new KerkytheaWriter(stream);
	}

	protected override void ExportCamera(KerkytheaWriter writer, Camera c)
	{
		if (!(c is PerspectiveCamera perspectiveCamera))
		{
			throw new InvalidOperationException("Only perspective cameras are supported.");
		}
		writer.WriteStartObject("./Cameras/Camera #1", "Pinhole Camera", "Camera #1", "Camera");
		double num = (double)Width / (double)Height;
		double value = 0.5 * num * 40.0 / Math.Tan(0.5 * perspectiveCamera.FieldOfView / 180.0 * Math.PI);
		writer.WriteParameter("Focal Length (mm)", value);
		writer.WriteParameter("Film Height (mm)", 40.0);
		writer.WriteParameter("Resolution", string.Format(CultureInfo.InvariantCulture, "{0}x{1}", new object[2] { Width, Height }));
		Matrix3D m = CreateTransform(perspectiveCamera.Position, perspectiveCamera.LookDirection, perspectiveCamera.UpDirection);
		writer.WriteTransform("Frame", m);
		writer.WriteParameter("Focus Distance", FocusDistance);
		writer.WriteParameter("f-number", Aperture);
		writer.WriteParameter("Lens Samples", LensSamples);
		writer.WriteParameter("Blades", 6);
		writer.WriteParameter("Diaphragm", "Circular");
		writer.WriteParameter("Projection", "Planar");
		writer.WriteEndObject();
	}

	protected override void ExportHeader(KerkytheaWriter writer)
	{
		writer.WriteStartDocument();
		writer.WriteStartElement("Root");
		writer.WriteAttributeString("Label", "Default Kernel");
		writer.WriteAttributeString("Name", string.Empty);
		writer.WriteAttributeString("Type", "Kernel");
		writer.WriteStartObject("./Modellers/XML Modeller", "XML Modeller", "XML Modeller", "Modeller");
		writer.WriteEndObject();
		writer.WriteStartObject("./Image Handlers/Free Image Support", "Free Image Support", "Free Image Support", "Image Handler");
		writer.WriteParameter("Tone Mapping", "External");
		writer.WriteParameter("Jpeg Quality", "Higher");
		writer.WriteEndObject();
		writer.WriteStartObject("./Direct Light Estimators/Refraction Enhanced", "Refraction Enhanced", "Refraction Enhanced", "Direct Light Estimator");
		writer.WriteParameter("Enabled", "Boolean", "1");
		writer.WriteParameter("PseudoCaustics", "Boolean", "0");
		writer.WriteParameter("PseudoTranslucencies", "Boolean", "0");
		writer.WriteParameter("Area Light Evaluation", "Boolean", "1");
		writer.WriteParameter("Optimized Area Lights", "Boolean", "1");
		writer.WriteParameter("Accurate Soft Shadows", "Boolean", "0");
		writer.WriteParameter("Antialiasing", "String", "High");
		writer.WriteParameter("./Evaluation/Diffuse", "Boolean", "1");
		writer.WriteParameter("./Evaluation/Specular", "Boolean", "1");
		writer.WriteParameter("./Evaluation/Translucent", "Boolean", "1");
		writer.WriteParameter("./Evaluation/Transmitted", "Boolean", "1");
		writer.WriteEndObject();
		for (int i = 0; i < Threads; i++)
		{
			WriteStandardRayTracer(writer, "#" + i);
		}
		WriteThreadedRaytracer(writer, Threads);
		writer.WriteStartObject("./Environments/Octree Environment", "Octree Environment", "Octree Environment", "Environment");
		writer.WriteParameter("Max Objects per Cell", 20);
		writer.WriteParameter("Instancing Switch", 1000000);
		writer.WriteParameter("Caching Switch", 6000000);
		writer.WriteEndObject();
		writer.WriteStartObject("./Filters/Simple Tone Mapping", "Simple Tone Mapping", string.Empty, "Filter");
		writer.WriteParameter("Enabled", flag: true);
		writer.WriteParameter("Method", "Simple");
		writer.WriteParameter("Exposure", 1.0);
		writer.WriteParameter("Gamma", 1.0);
		writer.WriteParameter("Dark Multiplier", 1.0);
		writer.WriteParameter("Bright Multiplier", 1.0);
		writer.WriteParameter("Reverse Correction", flag: true);
		writer.WriteParameter("Reverse Gamma", 2.2);
		writer.WriteEndObject();
		writer.WriteStartObject("./Scenes/" + Name, "Default Scene", Name, "Scene");
	}

	protected override void ExportLight(KerkytheaWriter writer, Light l, Transform3D t)
	{
		if (!(l is AmbientLight))
		{
			string uniqueName = GetUniqueName(writer, l, l.GetType().Name);
			DirectionalLight directionalLight = l as DirectionalLight;
			SpotLight spotLight = l as SpotLight;
			PointLight pointLight = l as PointLight;
			writer.WriteStartObject("./Lights/" + uniqueName, "Default Light", uniqueName, "Light");
			string text = "Projector Light";
			if (spotLight != null)
			{
				text = "Spot Light";
			}
			if (pointLight != null)
			{
				text = "Omni Light";
			}
			writer.WriteStartObject(text, text, string.Empty, "Emittance");
			writer.WriteStartObject("./Radiance/Constant Texture", "Constant Texture", string.Empty, "Texture");
			Color white = Colors.White;
			writer.WriteParameter("Color", white);
			writer.WriteEndObject();
			writer.WriteParameter("Attenuation", "None");
			if (spotLight != null)
			{
				writer.WriteParameter("Fall Off", spotLight.OuterConeAngle);
				writer.WriteParameter("Hot Spot", spotLight.InnerConeAngle);
			}
			if (directionalLight != null)
			{
				writer.WriteParameter("Width", 2.0);
				writer.WriteParameter("Height", 2.0);
			}
			if (pointLight != null)
			{
			}
			writer.WriteParameter("Focal Length", 1.0);
			writer.WriteEndObject();
			writer.WriteParameter("Enabled", flag: true);
			writer.WriteParameter("Shadow", Shadows);
			writer.WriteParameter("Soft Shadow", SoftShadows);
			writer.WriteParameter("Negative Light", flag: false);
			writer.WriteParameter("Global Photons", flag: true);
			writer.WriteParameter("Caustic Photons", flag: true);
			writer.WriteParameter("Multiplier", LightMultiplier);
			Vector3D up = new Vector3D(0.0, 0.0, 1.0);
			if (spotLight != null)
			{
				Matrix3D m = CreateTransform(spotLight.Position, spotLight.Direction, up);
				writer.WriteTransform("Frame", m);
			}
			if (directionalLight != null)
			{
				Point3D origin = new Point3D(-1000.0 * directionalLight.Direction.X, -1000.0 * directionalLight.Direction.Y, -1000.0 * directionalLight.Direction.Z);
				Matrix3D m = CreateTransform(origin, directionalLight.Direction, up);
				writer.WriteTransform("Frame", m);
			}
			if (pointLight != null)
			{
				Vector3D direction = new Vector3D(0.0 - pointLight.Position.X, 0.0 - pointLight.Position.Y, 0.0 - pointLight.Position.Z);
				Matrix3D m = CreateTransform(pointLight.Position, direction, up);
				writer.WriteTransform("Frame", m);
			}
			writer.WriteParameter("Focus Distance", 4.0);
			writer.WriteParameter("Radius", 0.2);
			writer.WriteParameter("Shadow Color", ShadowColor);
			writer.WriteEndObject();
		}
	}

	protected override void ExportModel(KerkytheaWriter writer, GeometryModel3D g, Transform3D transform)
	{
		if (g.Geometry is MeshGeometry3D meshGeometry3D)
		{
			string uniqueName = GetUniqueName(writer, g, g.GetType().Name);
			writer.WriteStartObject("./Models/" + uniqueName, "Default Model", uniqueName, "Model");
			ExportMesh(writer, meshGeometry3D);
			if (g.Material != null)
			{
				ExportMaterial(writer, g.Material);
			}
			Transform3DGroup transform3DGroup = new Transform3DGroup();
			transform3DGroup.Children.Add(g.Transform);
			transform3DGroup.Children.Add(transform);
			if (meshGeometry3D.TextureCoordinates != null)
			{
				ExportMapChannel(writer, meshGeometry3D);
			}
			writer.WriteTransform("Frame", transform3DGroup.Value);
			writer.WriteParameter("Enabled", flag: true);
			writer.WriteParameter("Visible", flag: true);
			writer.WriteParameter("Shadow Caster", flag: true);
			writer.WriteParameter("Shadow Receiver", flag: true);
			writer.WriteParameter("Caustics Transmitter", flag: true);
			writer.WriteParameter("Caustics Receiver", flag: true);
			writer.WriteParameter("Exit Blocker", flag: false);
			writer.WriteEndObject();
		}
	}

	protected override void ExportViewport(KerkytheaWriter writer, Viewport3D v)
	{
		AmbientLight ambientLight = Visual3DHelper.Find<AmbientLight>(v);
		writer.WriteStartObject("Default Global Settings", "Default Global Settings", string.Empty, "Global Settings");
		if (ambientLight != null)
		{
			writer.WriteParameter("Ambient Light", ambientLight.Color);
		}
		writer.WriteParameter("Background Color", BackgroundColor);
		writer.WriteParameter("Compute Volume Transfer", flag: false);
		writer.WriteParameter("Transfer Recursion Depth", 1);
		writer.WriteParameter("Background Type", "Sky Color");
		writer.WriteParameter("Sky Intensity", 1.0);
		writer.WriteParameter("Sky Frame", "Transform", "1 0 0 0 0 1 0 0 0 0 1 0 ");
		writer.WriteParameter("Sun Direction", "0 0 1");
		writer.WriteParameter("Sky Turbidity", 2.0);
		writer.WriteParameter("Sky Luminance Gamma", 1.2);
		writer.WriteParameter("Sky Chromaticity Gamma", 1.8);
		writer.WriteParameter("Linear Lightflow", flag: true);
		writer.WriteParameter("Index of Refraction", 1.0);
		writer.WriteParameter("Scatter Density", 0.1);
		writer.WriteParameter("./Location/Latitude", 0.0);
		writer.WriteParameter("./Location/Longitude", 0.0);
		writer.WriteParameter("./Location/Timezone", 0);
		writer.WriteParameter("./Location/Date", "0/0/2007");
		writer.WriteParameter("./Location/Time", "12:0:0");
		writer.WriteParameter("./Background Image/Filename", "[No Bitmap]");
		writer.WriteParameter("./Background Image/Projection", "UV");
		writer.WriteParameter("./Background Image/Offset X", 0.0);
		writer.WriteParameter("./Background Image/Offset Y", 0.0);
		writer.WriteParameter("./Background Image/Scale X", 1.0);
		writer.WriteParameter("./Background Image/Scale Y", 1.0);
		writer.WriteParameter("./Background Image/Rotation", 0.0);
		writer.WriteParameter("./Background Image/Smooth", flag: true);
		writer.WriteParameter("./Background Image/Inverted", flag: false);
		writer.WriteParameter("./Background Image/Alpha Channel", flag: false);
		writer.WriteEndObject();
	}

	protected override void Close(KerkytheaWriter writer)
	{
		writer.WriteFullEndElement();
		writer.WriteParameter("Mip Mapping", flag: true);
		writer.WriteParameter("./Interfaces/Active", "Null Interface");
		writer.WriteParameter("./Modellers/Active", "XML Modeller");
		writer.WriteParameter("./Image Handlers/Active", "Free Image Support");
		writer.WriteParameter("./Ray Tracers/Active", "Threaded Ray Tracer");
		writer.WriteParameter("./Irradiance Estimators/Active", "Null Irradiance Estimator");
		writer.WriteParameter("./Direct Light Estimators/Active", "Refraction Enhanced");
		writer.WriteParameter("./Environments/Active", "Octree Environment");
		writer.WriteParameter("./Filters/Active", "Simple Tone Mapping");
		writer.WriteParameter("./Scenes/Active", Name);
		writer.WriteParameter("./Libraries/Active", "Material Librarian");
		writer.WriteFullEndElement();
		writer.WriteEndDocument();
		writer.Close();
	}

	private static Matrix3D CreateTransform(Point3D origin, Vector3D direction, Vector3D up)
	{
		Vector3D vector3D = direction;
		Vector3D vector3D2 = Vector3D.CrossProduct(direction, up);
		Vector3D vector3D3 = up;
		vector3D2.Normalize();
		vector3D3.Normalize();
		vector3D.Normalize();
		return new Matrix3D(vector3D2.X, vector3D3.X, vector3D.X, 0.0, vector3D2.Y, vector3D3.Y, vector3D.Y, 0.0, vector3D2.Z, vector3D3.Z, vector3D.Z, 0.0, origin.X, origin.Y, origin.Z, 1.0);
	}

	private static string ToKerkytheaString(Point p)
	{
		return string.Format(CultureInfo.InvariantCulture, "{0} {1}", new object[2] { p.X, p.Y });
	}

	private static string ToKerkytheaString(Point3D point)
	{
		return string.Format(CultureInfo.InvariantCulture, "{0:0.######} {1:0.######} {2:0.######}", new object[3]
		{
			ValueOrDefault(point.X, 1.0),
			ValueOrDefault(point.Y, 0.0),
			ValueOrDefault(point.Z, 0.0)
		});
	}

	private static string ToKerkytheaString(Vector3D vector)
	{
		return string.Format(CultureInfo.InvariantCulture, "{0:0.######} {1:0.######} {2:0.######}", new object[3]
		{
			ValueOrDefault(vector.X, 1.0),
			ValueOrDefault(vector.Y, 0.0),
			ValueOrDefault(vector.Z, 0.0)
		});
	}

	private static string ToKerkytheaString(Color c)
	{
		return string.Format(CultureInfo.InvariantCulture, "{0:0.######} {1:0.######} {2:0.######}", new object[3]
		{
			(double)(int)c.R / 255.0,
			(double)(int)c.G / 255.0,
			(double)(int)c.B / 255.0
		});
	}

	private void ExportMapChannel(KerkytheaWriter writer, MeshGeometry3D m)
	{
		writer.WriteStartElement("Parameter");
		writer.WriteAttributeString("Name", "Map Channel");
		writer.WriteAttributeString("Type", "Point2D List");
		writer.WriteAttributeString("Value", m.TriangleIndices.Count.ToString());
		foreach (int triangleIndex in m.TriangleIndices)
		{
			if (triangleIndex < m.TextureCoordinates.Count)
			{
				Point p = m.TextureCoordinates[triangleIndex];
				writer.WriteStartElement("P");
				writer.WriteAttributeString("xy", ToKerkytheaString(p));
				writer.WriteEndElement();
			}
		}
		writer.WriteFullEndElement();
	}

	private void ExportMaterial(KerkytheaWriter writer, string name, Material material, IList<double> weights)
	{
		if (material is MaterialGroup materialGroup)
		{
			foreach (Material child in materialGroup.Children)
			{
				ExportMaterial(writer, name, child, weights);
			}
		}
		if (material is DiffuseMaterial diffuseMaterial)
		{
			string texture = null;
			Color? diffuse = null;
			double num = 1.0;
			if (diffuseMaterial.Brush is SolidColorBrush)
			{
				diffuse = GetSolidColor(diffuseMaterial.Brush, diffuseMaterial.Color);
				num = (double)(int)diffuse.Value.A / 255.0;
			}
			else
			{
				texture = GetTexture(writer, diffuseMaterial.Brush, name);
			}
			if (num > 0.0)
			{
				WriteWhittedMaterial(writer, $"#{weights.Count}", texture, diffuse, null, null);
				weights.Add(num);
			}
			if (num < 1.0)
			{
				WriteWhittedMaterial(writer, $"#{weights.Count}", null, null, null, Colors.White);
				weights.Add(1.0 - num);
			}
		}
		if (material is SpecularMaterial specularMaterial)
		{
			Color solidColor = GetSolidColor(specularMaterial.Brush, specularMaterial.Color);
			WriteWhittedMaterial(writer, $"#{weights.Count}", null, null, solidColor, null, specularMaterial.SpecularPower * 0.5);
			double num2 = (double)(int)solidColor.A / 255.0;
			num2 *= 0.01;
			weights.Add(num2);
		}
		if (material is EmissiveMaterial)
		{
			Debug.WriteLine("KerkytheaExporter: Emissive materials are not yet supported.");
		}
	}

	private void ExportMaterial(KerkytheaWriter writer, Material material)
	{
		if (registeredMaterials.ContainsKey(material))
		{
			XmlDocument xmlDocument = registeredMaterials[material];
			if (xmlDocument == null || xmlDocument.DocumentElement == null)
			{
				return;
			}
			{
				foreach (XmlNode childNode in xmlDocument.DocumentElement.ChildNodes)
				{
					writer.Write(childNode);
				}
				return;
			}
		}
		string uniqueName = GetUniqueName(writer, material, "Material");
		writer.WriteStartObject(uniqueName, "Layered Material", uniqueName, "Material");
		List<double> list = new List<double>();
		ExportMaterial(writer, uniqueName, material, list);
		for (int i = 0; i < list.Count; i++)
		{
			WriteWeight(writer, "Weight #" + i, list[i]);
		}
		writer.WriteEndObject();
	}

	private Color GetSolidColor(Brush brush, Color defaultColor)
	{
		if (!(brush is SolidColorBrush { Color: var color }))
		{
			return defaultColor;
		}
		return color;
	}

	private string GetTexture(KerkytheaWriter writer, Brush brush, string name)
	{
		if (writer.TryGetTexture(brush, out var textureFile))
		{
			return textureFile;
		}
		string text = name + ".png";
		string arg = Path.Combine(TexturePath, text);
		using (Stream stm = FileCreator(arg))
		{
			RenderBrush(stm, brush, TextureWidth, TextureHeight);
		}
		writer.AddTexture(brush, text);
		return text;
	}

	private string GetUniqueName(KerkytheaWriter writer, DependencyObject o, string defaultName)
	{
		string name = o.GetValue(FrameworkElement.NameProperty) as string;
		return writer.GetUniqueName(name, defaultName);
	}

	private void WriteAshikhminMaterial(KerkytheaWriter writer, string identifier, Color? diffuse, Color? specular, Color? shininessXMap, Color? shininessYMap, Color? rotationMap, double shininessX = 100.0, double shininessY = 100.0, double rotation = 0.0, double indexOfRefraction = 1.0, string nkfile = null)
	{
		writer.WriteStartObject(identifier, "Ashikhmin Material", identifier, "Material");
		if (diffuse.HasValue)
		{
			WriteConstantTexture(writer, "Diffuse", diffuse.Value);
		}
		if (specular.HasValue)
		{
			WriteConstantTexture(writer, "Specular", specular.Value);
		}
		if (shininessXMap.HasValue)
		{
			WriteConstantTexture(writer, "Shininess X Map", shininessXMap.Value);
		}
		if (shininessYMap.HasValue)
		{
			WriteConstantTexture(writer, "Shininess Y Map", shininessYMap.Value);
		}
		if (rotationMap.HasValue)
		{
			WriteConstantTexture(writer, "RotationMap", rotationMap.Value);
		}
		writer.WriteParameter("Shininess X", shininessX);
		writer.WriteParameter("Shininess Y", shininessY);
		writer.WriteParameter("Rotation", rotation);
		writer.WriteParameter("Attenuation", "Schlick");
		writer.WriteParameter("Index of Refraction", indexOfRefraction);
		writer.WriteParameter("N-K File", nkfile);
		writer.WriteEndObject();
	}

	private void WriteBitmapTexture(KerkytheaWriter writer, string name, string filename)
	{
		if (!string.IsNullOrEmpty(filename))
		{
			writer.WriteStartObject("./" + name + "/Bitmap Texture", "Bitmap Texture", string.Empty, "Texture");
			writer.WriteParameter("Filename", filename);
			writer.WriteParameter("Projection", "UV");
			writer.WriteParameter("Offset X", 0.0);
			writer.WriteParameter("Offset Y", 0.0);
			writer.WriteParameter("Scale X", 1.0);
			writer.WriteParameter("Scale Y", 1.0);
			writer.WriteParameter("Rotation", 0.0);
			writer.WriteParameter("Smooth", flag: true);
			writer.WriteParameter("Inverted", flag: false);
			writer.WriteParameter("Alpha Channel", flag: false);
			writer.WriteEndObject();
		}
	}

	private void WriteConstantTexture(KerkytheaWriter writer, string name, Color color)
	{
		writer.WriteStartObject("./" + name + "/Constant Texture", "Constant Texture", string.Empty, "Texture");
		writer.WriteParameter("Color", color);
		writer.WriteEndObject();
	}

	private void WriteDielectricMaterial(KerkytheaWriter writer, string identifier, Color? reflection, Color? refraction, double indexOfRefraction = 1.0, double dispersion = 0.0, string nkfile = null)
	{
		writer.WriteStartObject(identifier, "Ashikhmin Material", identifier, "Material");
		if (reflection.HasValue)
		{
			WriteConstantTexture(writer, "Reflection", reflection.Value);
		}
		if (refraction.HasValue)
		{
			WriteConstantTexture(writer, "Refraction", refraction.Value);
		}
		writer.WriteParameter("Index of Refraction", indexOfRefraction);
		writer.WriteParameter("Dispersion", dispersion);
		writer.WriteParameter("N-K File", string.Empty);
		writer.WriteEndObject();
	}

	private void WriteWeight(KerkytheaWriter writer, string identifier, double weight)
	{
		writer.WriteStartObject(identifier, "Weighted Texture", identifier, "Texture");
		writer.WriteStartObject("Constant Texture", "Constant Texture", string.Empty, "Texture");
		writer.WriteParameter("Color", Colors.White);
		writer.WriteEndObject();
		writer.WriteParameter("Weight #0", weight);
		writer.WriteEndObject();
	}

	private void WriteWhittedMaterial(KerkytheaWriter writer, string identifier, string texture, Color? diffuse, Color? specular, Color? refraction, double shininess = 128.0, double indexOfRefraction = 1.0)
	{
		writer.WriteStartObject(identifier, "Whitted Material", identifier, "Material");
		if (texture != null)
		{
			WriteBitmapTexture(writer, "Diffuse", texture);
		}
		if (diffuse.HasValue)
		{
			WriteConstantTexture(writer, "Diffuse", diffuse.Value);
		}
		if (specular.HasValue)
		{
			WriteConstantTexture(writer, "Specular", specular.Value);
		}
		if (refraction.HasValue)
		{
			WriteConstantTexture(writer, "Refraction", refraction.Value);
		}
		writer.WriteParameter("Shininess", shininess);
		writer.WriteParameter("Transmitted Shininess", 128.0);
		writer.WriteParameter("Index of Refraction", indexOfRefraction);
		writer.WriteParameter("Specular Sampling", flag: false);
		writer.WriteParameter("Transmitted Sampling", flag: false);
		writer.WriteParameter("Specular Attenuation", "Cosine");
		writer.WriteParameter("Transmitted Attenuation", "Cosine");
		writer.WriteEndObject();
	}

	public static double ValueOrDefault(double value, double defaultValue)
	{
		if (double.IsNaN(value))
		{
			return defaultValue;
		}
		return value;
	}
}
