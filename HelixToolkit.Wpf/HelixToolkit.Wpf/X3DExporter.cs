using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Media.Media3D;
using System.Xml;

namespace HelixToolkit.Wpf;

public class X3DExporter : Exporter<XmlWriter>
{
	public Dictionary<string, string> Metadata { get; private set; }

	public string Title
	{
		set
		{
			Metadata["title"] = value;
		}
	}

	public X3DExporter()
	{
		Metadata = new Dictionary<string, string>();
	}

	protected override XmlWriter Create(Stream stream)
	{
		XmlTextWriter xmlTextWriter = new XmlTextWriter(stream, Encoding.UTF8)
		{
			Formatting = Formatting.Indented
		};
		xmlTextWriter.WriteStartDocument(standalone: false);
		xmlTextWriter.WriteDocType("X3D", "ISO//Web3D//DTD X3D 3.0//EN", "http://www.web3d.org/specifications/x3d-3.1.dtd", null);
		xmlTextWriter.WriteStartElement("X3D");
		xmlTextWriter.WriteAttributeString("profile", "Immersive");
		xmlTextWriter.WriteAttributeString("version", "3.1");
		xmlTextWriter.WriteAttributeString("xmlns:xsd", "http://www.w3.org/2001/XMLSchema-instance");
		xmlTextWriter.WriteAttributeString("xsd:noNamespaceSchemaLocation", "http://www.web3d.org/specifications/x3d-3.1.xsd");
		return xmlTextWriter;
	}

	protected override void Close(XmlWriter writer)
	{
		writer.WriteEndElement();
		writer.WriteEndElement();
		writer.WriteEndDocument();
		writer.Close();
	}

	protected override void ExportHeader(XmlWriter writer)
	{
		writer.WriteStartElement("head");
		foreach (KeyValuePair<string, string> item in Metadata)
		{
			writer.WriteStartElement("meta");
			writer.WriteAttributeString("name", item.Key);
			writer.WriteAttributeString("value", item.Value);
			writer.WriteEndElement();
		}
		writer.WriteEndElement();
		writer.WriteStartElement("Scene");
	}

	protected override void ExportModel(XmlWriter writer, GeometryModel3D model, Transform3D inheritedTransform)
	{
		if (!(model.Geometry is MeshGeometry3D meshGeometry3D))
		{
			return;
		}
		StringBuilder stringBuilder = new StringBuilder();
		foreach (int triangleIndex in meshGeometry3D.TriangleIndices)
		{
			stringBuilder.Append(triangleIndex + " ");
		}
		StringBuilder stringBuilder2 = new StringBuilder();
		foreach (Point3D position in meshGeometry3D.Positions)
		{
			stringBuilder2.AppendFormat(CultureInfo.InvariantCulture, "{0} {1} {2} ", new object[3] { position.X, position.Y, position.Z });
		}
		writer.WriteStartElement("Transform");
		writer.WriteStartElement("Shape");
		writer.WriteStartElement("IndexedFaceSet");
		writer.WriteAttributeString("coordIndex", stringBuilder.ToString());
		writer.WriteStartElement("Coordinate");
		writer.WriteAttributeString("point", stringBuilder2.ToString());
		writer.WriteEndElement();
		writer.WriteEndElement();
		writer.WriteStartElement("Appearance");
		writer.WriteStartElement("Material");
		writer.WriteAttributeString("diffuseColor", "0.8 0.8 0.2");
		writer.WriteAttributeString("specularColor", "0.5 0.5 0.5");
		writer.WriteEndElement();
		writer.WriteEndElement();
		writer.WriteEndElement();
		writer.WriteEndElement();
	}
}
