using System.Collections;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media.Media3D;
using System.Xml;

namespace HelixToolkit.Wpf;

public class XamlExporter : Exporter<XmlWriter>
{
	public bool CreateResourceDictionary { get; set; }

	public XamlExporter()
	{
		CreateResourceDictionary = true;
	}

	public static ResourceDictionary WrapInResourceDictionary(object obj)
	{
		ResourceDictionary resourceDictionary = new ResourceDictionary();
		if (obj is IEnumerable enumerable)
		{
			int num = 1;
			foreach (object item in enumerable)
			{
				resourceDictionary.Add("Model" + num, item);
				num++;
			}
		}
		else
		{
			resourceDictionary.Add("Model", obj);
		}
		return resourceDictionary;
	}

	public override void Export(Viewport3D viewport, Stream stream)
	{
		XmlWriter xmlWriter = Create(stream);
		object obj = viewport;
		if (CreateResourceDictionary)
		{
			obj = WrapInResourceDictionary(obj);
		}
		XamlWriter.Save(obj, xmlWriter);
		Close(xmlWriter);
	}

	public override void Export(Visual3D visual, Stream stream)
	{
		XmlWriter xmlWriter = Create(stream);
		object obj = visual;
		if (CreateResourceDictionary)
		{
			obj = WrapInResourceDictionary(obj);
		}
		XamlWriter.Save(obj, xmlWriter);
		Close(xmlWriter);
	}

	public override void Export(Model3D model, Stream stream)
	{
		XmlWriter xmlWriter = Create(stream);
		object obj = model;
		if (CreateResourceDictionary)
		{
			obj = WrapInResourceDictionary(obj);
		}
		XamlWriter.Save(obj, xmlWriter);
		Close(xmlWriter);
	}

	protected override XmlWriter Create(Stream stream)
	{
		return new XmlTextWriter(stream, Encoding.UTF8)
		{
			Formatting = Formatting.Indented
		};
	}

	protected override void Close(XmlWriter writer)
	{
		writer.Close();
	}
}
