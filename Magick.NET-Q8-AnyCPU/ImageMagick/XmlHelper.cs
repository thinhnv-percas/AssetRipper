using System;
using System.Globalization;
using System.Xml;

namespace ImageMagick;

internal static class XmlHelper
{
	public static XmlElement CreateElement(XmlNode node, string name)
	{
		XmlElement xmlElement = ((node.GetType() == typeof(XmlDocument)) ? ((XmlDocument)node) : node.OwnerDocument).CreateElement(name);
		node.AppendChild(xmlElement);
		return xmlElement;
	}

	public static T GetAttribute<T>(XmlElement element, string name)
	{
		if (element == null || !element.HasAttribute(name))
		{
			return default(T);
		}
		return MagickConverter.Convert<T>(element.GetAttribute(name));
	}

	public static T GetValue<T>(XmlAttribute attribute)
	{
		if (attribute == null)
		{
			return default(T);
		}
		return MagickConverter.Convert<T>(attribute.Value);
	}

	public static void SetAttribute<TType>(XmlElement element, string name, TType value)
	{
		if (element != null)
		{
			XmlAttribute xmlAttribute = ((!element.HasAttribute(name)) ? element.Attributes.Append(element.OwnerDocument.CreateAttribute(name)) : element.Attributes[name]);
			if (typeof(TType) == typeof(string))
			{
				xmlAttribute.Value = (string)(object)value;
			}
			else
			{
				xmlAttribute.Value = (string)Convert.ChangeType(value, typeof(string), CultureInfo.InvariantCulture);
			}
		}
	}
}
