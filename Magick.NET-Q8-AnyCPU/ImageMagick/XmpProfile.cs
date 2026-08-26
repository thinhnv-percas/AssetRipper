using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace ImageMagick;

public sealed class XmpProfile : ImageProfile
{
	public XmpProfile(byte[] data)
		: base("xmp", CheckTrailingNULL(data))
	{
	}

	public XmpProfile(IXPathNavigable document)
		: base("xmp")
	{
		Throw.IfNull("document", document);
		MemoryStream memoryStream = new MemoryStream();
		using XmlWriter xmlWriter = XmlWriter.Create(memoryStream);
		document.CreateNavigator().WriteSubtree(xmlWriter);
		xmlWriter.Flush();
		base.Data = memoryStream.ToArray();
	}

	public XmpProfile(XDocument document)
		: base("xmp")
	{
		Throw.IfNull("document", document);
		MemoryStream memoryStream = new MemoryStream();
		using XmlWriter xmlWriter = XmlWriter.Create(memoryStream);
		document.WriteTo(xmlWriter);
		xmlWriter.Flush();
		base.Data = memoryStream.ToArray();
	}

	public XmpProfile(Stream stream)
		: base("xmp", stream)
	{
	}

	public XmpProfile(string fileName)
		: base("xmp", fileName)
	{
	}

	public static XmpProfile FromIXPathNavigable(IXPathNavigable document)
	{
		return new XmpProfile(document);
	}

	public static XmpProfile FromXDocument(XDocument document)
	{
		return new XmpProfile(document);
	}

	public XmlReader CreateReader()
	{
		return XmlReader.Create(new MemoryStream(base.Data, 0, base.Data.Length), new XmlReaderSettings
		{
			CloseInput = true
		});
	}

	public IXPathNavigable ToIXPathNavigable()
	{
		using XmlReader reader = CreateReader();
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.Load(reader);
		return xmlDocument.CreateNavigator();
	}

	public XDocument ToXDocument()
	{
		using XmlReader reader = CreateReader();
		return XDocument.Load(reader);
	}

	private static byte[] CheckTrailingNULL(byte[] data)
	{
		Throw.IfNull("data", data);
		int num = data.Length;
		while (num > 2 && data[num - 1] == 0)
		{
			num--;
		}
		if (num == data.Length)
		{
			return data;
		}
		byte[] array = new byte[num];
		Buffer.BlockCopy(data, 0, array, 0, num);
		return array;
	}
}
