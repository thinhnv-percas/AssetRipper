using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Xml;

namespace HelixToolkit.Wpf;

public class ColladaExporter : Exporter<XmlWriter>
{
	private readonly Dictionary<Material, string> effects = new Dictionary<Material, string>();

	private readonly Dictionary<MeshGeometry3D, string> geometries = new Dictionary<MeshGeometry3D, string>();

	private readonly Dictionary<Light, string> lights = new Dictionary<Light, string>();

	private readonly Dictionary<Material, string> materials = new Dictionary<Material, string>();

	private readonly Dictionary<Model3D, string> nodes = new Dictionary<Model3D, string>();

	public string Author { get; set; }

	public string Comments { get; set; }

	public string Copyright { get; set; }

	public override void Export(Viewport3D viewport, Stream stream)
	{
		XmlWriter writer = Create(stream);
		WriteAssets(writer, viewport);
		viewport.Children.Traverse(delegate(Light l, Transform3D t)
		{
			base.ExportLight(writer, l, t);
		});
		writer.WriteStartElement("library_materials");
		viewport.Children.Traverse(delegate(GeometryModel3D gm, Transform3D t)
		{
			ExportMaterial(writer, gm);
		});
		writer.WriteEndElement();
		writer.WriteStartElement("library_effects");
		viewport.Children.Traverse(delegate(GeometryModel3D gm, Transform3D t)
		{
			ExportEffect(writer, gm);
		});
		writer.WriteEndElement();
		writer.WriteStartElement("library_geometries");
		viewport.Children.Traverse(delegate(GeometryModel3D gm, Transform3D t)
		{
			ExportGeometry(writer, gm, t);
		});
		writer.WriteEndElement();
		writer.WriteStartElement("library_nodes");
		viewport.Children.Traverse(delegate(GeometryModel3D gm, Transform3D t)
		{
			ExportNode(writer, gm, t);
		});
		writer.WriteEndElement();
		writer.WriteStartElement("library_visual_scenes");
		writer.WriteStartElement("visual_scene");
		writer.WriteAttributeString("id", "RootNode");
		writer.WriteAttributeString("name", "RootNode");
		viewport.Children.Traverse(delegate(GeometryModel3D gm, Transform3D t)
		{
			ExportSceneNode(writer, gm, t);
		});
		writer.WriteEndElement();
		writer.WriteEndElement();
		writer.WriteStartElement("scene");
		writer.WriteStartElement("instance_visual_scene");
		writer.WriteAttributeString("url", "#RootNode");
		writer.WriteEndElement();
		writer.WriteEndElement();
		Close(writer);
	}

	protected override XmlWriter Create(Stream stream)
	{
		XmlTextWriter xmlTextWriter = new XmlTextWriter(stream, Encoding.UTF8)
		{
			Formatting = Formatting.Indented
		};
		xmlTextWriter.WriteStartDocument(standalone: false);
		xmlTextWriter.WriteStartElement("COLLADA");
		xmlTextWriter.WriteAttributeString("xmlns", "http://www.collada.org/2008/03/COLLADASchema");
		xmlTextWriter.WriteAttributeString("version", "1.5.0");
		return xmlTextWriter;
	}

	protected override void Close(XmlWriter writer)
	{
		writer.WriteEndElement();
		writer.WriteEndDocument();
		writer.Close();
	}

	protected override void ExportModel(XmlWriter writer, GeometryModel3D model, Transform3D inheritedTransform)
	{
	}

	private void WriteAssets(XmlWriter writer, Viewport3D viewport)
	{
		Assembly assembly = Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly();
		AssemblyName name = assembly.GetName();
		string value = $"{name.Name} {name.Version.ToString(3)}";
		string value2 = DateTime.Now.ToString("u").Replace(' ', 'T');
		ProjectionCamera projectionCamera = viewport.Camera as ProjectionCamera;
		string value3 = "Z_UP";
		if (projectionCamera != null && projectionCamera.UpDirection.Y > projectionCamera.UpDirection.Z)
		{
			value3 = "Y_UP";
		}
		writer.WriteStartElement("asset");
		writer.WriteStartElement("contributor");
		if (Author != null)
		{
			writer.WriteElementString("author", Author);
		}
		if (Copyright != null)
		{
			writer.WriteElementString("copyright", Copyright);
		}
		if (Comments != null)
		{
			writer.WriteElementString("comments", Comments);
		}
		writer.WriteElementString("authoring_tool", value);
		writer.WriteEndElement();
		writer.WriteElementString("created", value2);
		writer.WriteElementString("modified", value2);
		writer.WriteElementString("up_axis", value3);
		writer.WriteEndElement();
	}

	private void BindMaterial(XmlWriter writer, string geometryId, string materialId)
	{
		writer.WriteStartElement("instance_geometry");
		writer.WriteAttributeString("url", "#" + geometryId);
		writer.WriteStartElement("bind_material");
		writer.WriteStartElement("technique_common");
		writer.WriteStartElement("instance_material");
		writer.WriteAttributeString("symbol", "Material2");
		writer.WriteAttributeString("target", "#" + materialId);
		writer.WriteStartElement("bind_vertex_input");
		writer.WriteAttributeString("semantic", "UVSET0");
		writer.WriteAttributeString("input_semantic", "TEXCOORD");
		writer.WriteAttributeString("input_set", "0");
		writer.WriteEndElement();
		writer.WriteEndElement();
		writer.WriteEndElement();
		writer.WriteEndElement();
		writer.WriteEndElement();
	}

	private void ExportEffect(XmlWriter writer, GeometryModel3D model)
	{
		ExportEffect(writer, model.Material);
		ExportEffect(writer, model.BackMaterial);
	}

	private void ExportEffect(XmlWriter writer, Material m)
	{
		if (m != null)
		{
			string value = effects[m];
			writer.WriteStartElement("effect");
			writer.WriteAttributeString("id", value);
			writer.WriteAttributeString("name", value);
			writer.WriteStartElement("profile_COMMON");
			writer.WriteStartElement("technique");
			writer.WriteAttributeString("sid", "common");
			writer.WriteStartElement("phong");
			EmissiveMaterial first = MaterialHelper.GetFirst<EmissiveMaterial>(m);
			if (first != null)
			{
				WritePhongMaterial(writer, "emission", first.Color);
			}
			DiffuseMaterial first2 = MaterialHelper.GetFirst<DiffuseMaterial>(m);
			if (first2 != null)
			{
				WritePhongMaterial(writer, "diffuse", first2.Color);
			}
			SpecularMaterial first3 = MaterialHelper.GetFirst<SpecularMaterial>(m);
			if (first3 != null)
			{
				WritePhongMaterial(writer, "specular", first3.Color);
			}
			writer.WriteEndElement();
			writer.WriteEndElement();
			writer.WriteEndElement();
			writer.WriteEndElement();
		}
	}

	private void ExportGeometry(XmlWriter writer, GeometryModel3D model, Transform3D transform)
	{
		if (!(model.Geometry is MeshGeometry3D meshGeometry3D))
		{
			throw new InvalidOperationException("Model is not a MeshGeometry3D.");
		}
		writer.WriteStartElement("geometry");
		writer.WriteStartElement("mesh");
		int count = geometries.Count;
		string value = "mesh" + count;
		geometries.Add(meshGeometry3D, value);
		writer.WriteStartElement("source");
		string text = "p" + count;
		writer.WriteAttributeString("id", text);
		writer.WriteStartElement("float_array");
		string text2 = text + "-array";
		writer.WriteAttributeString("id", text2);
		writer.WriteAttributeString("count", (meshGeometry3D.Positions.Count * 3).ToString(CultureInfo.InvariantCulture));
		StringBuilder stringBuilder = new StringBuilder();
		foreach (Point3D position in meshGeometry3D.Positions)
		{
			stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "{0} {1} {2} ", new object[3] { position.X, position.Y, position.Z });
		}
		writer.WriteRaw(stringBuilder.ToString());
		writer.WriteEndElement();
		writer.WriteStartElement("technique_common");
		writer.WriteStartElement("accessor");
		writer.WriteAttributeString("source", "#" + text2);
		writer.WriteAttributeString("count", meshGeometry3D.Positions.Count.ToString(CultureInfo.InvariantCulture));
		writer.WriteAttributeString("stride", "3");
		writer.WriteStartElement("param");
		writer.WriteAttributeString("name", "X");
		writer.WriteAttributeString("type", "float");
		writer.WriteEndElement();
		writer.WriteStartElement("param");
		writer.WriteAttributeString("name", "Y");
		writer.WriteAttributeString("type", "float");
		writer.WriteEndElement();
		writer.WriteStartElement("param");
		writer.WriteAttributeString("name", "Z");
		writer.WriteAttributeString("type", "float");
		writer.WriteEndElement();
		writer.WriteEndElement();
		writer.WriteEndElement();
		writer.WriteEndElement();
		writer.WriteStartElement("vertices");
		string text3 = "v" + count;
		writer.WriteAttributeString("id", text3);
		writer.WriteStartElement("input");
		writer.WriteAttributeString("semantic", "POSITION");
		writer.WriteAttributeString("source", "#" + text);
		writer.WriteEndElement();
		writer.WriteEndElement();
		writer.WriteStartElement("triangles");
		writer.WriteAttributeString("count", meshGeometry3D.TriangleIndices.Count.ToString(CultureInfo.InvariantCulture));
		writer.WriteAttributeString("material", "xx");
		writer.WriteStartElement("input");
		writer.WriteAttributeString("offset", "0");
		writer.WriteAttributeString("semantic", "VERTEX");
		writer.WriteAttributeString("source", "#" + text3);
		writer.WriteEndElement();
		StringBuilder stringBuilder2 = new StringBuilder();
		foreach (int triangleIndex in meshGeometry3D.TriangleIndices)
		{
			stringBuilder2.Append(triangleIndex + " ");
		}
		writer.WriteElementString("p", stringBuilder2.ToString());
		writer.WriteEndElement();
		writer.WriteEndElement();
		writer.WriteEndElement();
	}

	private void ExportLight(XmlWriter writer, Light light)
	{
		if (light != null && !lights.ContainsKey(light))
		{
			string value = "light_" + lights.Count;
			lights.Add(light, value);
			writer.WriteStartElement("light");
			writer.WriteAttributeString("id", value);
			writer.WriteAttributeString("name", value);
			writer.WriteStartElement("technique_common");
			if (light is AmbientLight ambientLight)
			{
				writer.WriteStartElement("ambient");
				WriteColor(writer, ambientLight.Color);
				writer.WriteEndElement();
			}
			if (light is DirectionalLight directionalLight)
			{
				writer.WriteStartElement("directional");
				WriteColor(writer, directionalLight.Color);
				writer.WriteEndElement();
			}
			if (light is PointLight pointLight)
			{
				writer.WriteStartElement("point");
				WriteColor(writer, pointLight.Color);
				WriteDouble(writer, "constant_attenuation", pointLight.ConstantAttenuation);
				WriteDouble(writer, "linear_attenuation", pointLight.LinearAttenuation);
				WriteDouble(writer, "quadratic_attenuation", pointLight.QuadraticAttenuation);
				writer.WriteEndElement();
			}
			if (light is SpotLight spotLight)
			{
				writer.WriteStartElement("spot");
				WriteColor(writer, spotLight.Color);
				WriteDouble(writer, "constant_attenuation", spotLight.ConstantAttenuation);
				WriteDouble(writer, "linear_attenuation", spotLight.LinearAttenuation);
				WriteDouble(writer, "quadratic_attenuation", spotLight.QuadraticAttenuation);
				WriteDouble(writer, "falloff_angle", spotLight.InnerConeAngle);
				writer.WriteEndElement();
			}
			writer.WriteEndElement();
			writer.WriteEndElement();
		}
	}

	private void ExportMaterial(XmlWriter writer, GeometryModel3D model)
	{
		ExportMaterial(writer, model.Material);
		ExportMaterial(writer, model.BackMaterial);
	}

	private void ExportMaterial(XmlWriter writer, Material m)
	{
		if (m != null && !materials.ContainsKey(m))
		{
			string value = "material_" + materials.Count;
			string text = "effect_" + materials.Count;
			materials.Add(m, value);
			effects.Add(m, text);
			writer.WriteStartElement("material");
			writer.WriteAttributeString("id", value);
			writer.WriteAttributeString("name", value);
			writer.WriteStartElement("instance_effect");
			writer.WriteAttributeString("url", "#" + text);
			writer.WriteEndElement();
			writer.WriteEndElement();
		}
	}

	private void ExportNode(XmlWriter writer, GeometryModel3D gm, Transform3D transform)
	{
		if (!(gm.Geometry is MeshGeometry3D key))
		{
			throw new InvalidOperationException("Model is not a MeshGeometry3D.");
		}
		string text = geometries[key];
		string value = text + "-node";
		nodes.Add(gm, value);
		writer.WriteStartElement("node");
		writer.WriteAttributeString("id", value);
		writer.WriteAttributeString("name", value);
		if (gm.Material != null && materials.TryGetValue(gm.Material, out var value2))
		{
			BindMaterial(writer, text, value2);
		}
		if (gm.BackMaterial != null && materials.TryGetValue(gm.BackMaterial, out var value3))
		{
			BindMaterial(writer, text, value3);
		}
		writer.WriteEndElement();
	}

	private void ExportSceneNode(XmlWriter writer, Model3D gm, Transform3D transform)
	{
		string text = nodes[gm];
		string value = text + "-instance";
		writer.WriteStartElement("node");
		writer.WriteAttributeString("id", value);
		writer.WriteAttributeString("name", value);
		Transform3D transform3D = Transform3DHelper.CombineTransform(transform, gm.Transform);
		WriteMatrix(writer, "matrix", transform3D.Value);
		writer.WriteStartElement("instance_node");
		writer.WriteAttributeString("url", "#" + text);
		writer.WriteEndElement();
		writer.WriteEndElement();
	}

	private void WriteColor(XmlWriter writer, Color color)
	{
		writer.WriteElementString("color", string.Format(CultureInfo.InvariantCulture, "{0} {1} {2} {3}", (double)(int)color.R / 255.0, (double)(int)color.G / 255.0, (double)(int)color.B / 255.0, (double)(int)color.A / 255.0));
	}

	private void WriteDouble(XmlWriter writer, string name, double value)
	{
		writer.WriteElementString(name, value.ToString(CultureInfo.InvariantCulture));
	}

	private void WriteMatrix(XmlWriter writer, string name, Matrix3D m)
	{
		string value = string.Format(CultureInfo.InvariantCulture, "{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13} {14} {15}", m.M11, m.M12, m.M13, m.OffsetX, m.M21, m.M22, m.M23, m.OffsetY, m.M31, m.M32, m.M33, m.OffsetZ, 0, 0, 0, 1);
		writer.WriteElementString(name, value);
	}

	private void WritePhongMaterial(XmlWriter writer, string name, Color color)
	{
		writer.WriteStartElement(name);
		WriteColor(writer, color);
		writer.WriteEndElement();
	}
}
