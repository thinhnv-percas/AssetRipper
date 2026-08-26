using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using dnSpy.Contracts.Text;

namespace dnSpy.Contracts.Decompiler.XmlDoc;

public class XmlDocRenderer : IXmlDocOutput
{
	private readonly StringBuilder ret = new StringBuilder();

	private static readonly Regex whitespace = new Regex("\\s+");

	public static Regex WhitespaceRegex => whitespace;

	void IXmlDocOutput.WriteNewLine()
	{
		ret.AppendLine();
	}

	void IXmlDocOutput.WriteSpace()
	{
		ret.Append(' ');
	}

	void IXmlDocOutput.Write(string s, object data)
	{
		ret.Append(s);
	}

	public void AppendText(string text)
	{
		ret.Append(text);
	}

	public void AddXmlDocumentation(string xmlDocumentation)
	{
		WriteXmlDoc(this, xmlDocumentation);
	}

	public static bool WriteXmlDoc(IXmlDocOutput output, string xmlDocumentation)
	{
		if (xmlDocumentation == null)
		{
			return false;
		}
		try
		{
			XmlTextReader xmlTextReader = new XmlTextReader(new StringReader("<docroot>" + xmlDocumentation + "</docroot>"));
			xmlTextReader.XmlResolver = null;
			AddXmlDocumentation(output, xmlTextReader);
		}
		catch (XmlException)
		{
		}
		return true;
	}

	private static void AddXmlDocumentation(IXmlDocOutput output, XmlReader xml)
	{
		bool flag = true;
		while (xml.Read())
		{
			if (xml.NodeType == XmlNodeType.Element)
			{
				switch (xml.Name.ToLowerInvariant())
				{
				case "filterpriority":
				case "remarks":
					xml.Skip();
					break;
				case "example":
					output.WriteNewLine();
					output.Write("Example", BoxedTextColor.XmlDocToolTipHeader);
					output.Write(":", BoxedTextColor.Text);
					output.WriteNewLine();
					flag = true;
					break;
				case "exception":
					output.WriteNewLine();
					output.Write(GetCref(xml["cref"]), BoxedTextColor.XmlDocToolTipHeader);
					output.Write(":", BoxedTextColor.Text);
					output.WriteSpace();
					flag = false;
					break;
				case "returns":
					output.WriteNewLine();
					output.Write("Returns", BoxedTextColor.XmlDocToolTipHeader);
					output.Write(":", BoxedTextColor.Text);
					output.WriteSpace();
					flag = false;
					break;
				case "see":
					output.Write(GetCref(xml["cref"]), BoxedTextColor.Text);
					output.Write((xml["langword"] ?? string.Empty).Trim(), BoxedTextColor.Keyword);
					flag = false;
					break;
				case "seealso":
					output.WriteNewLine();
					output.Write("See also", BoxedTextColor.XmlDocToolTipHeader);
					output.Write(":", BoxedTextColor.Text);
					output.WriteSpace();
					output.Write(GetCref(xml["cref"]), BoxedTextColor.Text);
					flag = false;
					break;
				case "paramref":
					output.Write((xml["name"] ?? string.Empty).Trim(), BoxedTextColor.Parameter);
					flag = false;
					break;
				case "param":
					output.WriteNewLine();
					output.Write(whitespace.Replace((xml["name"] ?? string.Empty).Trim(), " "), BoxedTextColor.Parameter);
					output.Write(":", BoxedTextColor.Text);
					output.WriteSpace();
					flag = false;
					break;
				case "typeparam":
					output.WriteNewLine();
					output.Write(whitespace.Replace((xml["name"] ?? string.Empty).Trim(), " "), BoxedTextColor.TypeGenericParameter);
					output.Write(":", BoxedTextColor.Text);
					output.WriteSpace();
					flag = false;
					break;
				case "value":
					output.WriteNewLine();
					output.Write("Value", BoxedTextColor.Keyword);
					output.Write(":", BoxedTextColor.Text);
					output.WriteNewLine();
					flag = true;
					break;
				case "br":
				case "para":
					output.WriteNewLine();
					flag = true;
					break;
				}
			}
			else if (xml.NodeType == XmlNodeType.Text)
			{
				string text = whitespace.Replace(xml.Value, " ");
				if (flag)
				{
					text = text.TrimStart();
				}
				output.Write(text, BoxedTextColor.Text);
				flag = false;
			}
		}
	}

	public static string GetCref(string cref)
	{
		if (string.IsNullOrWhiteSpace(cref))
		{
			return string.Empty;
		}
		if (cref.Length < 2)
		{
			return cref.Trim();
		}
		if (cref.Substring(1, 1) == ":")
		{
			return cref.Substring(2, cref.Length - 2).Trim();
		}
		return cref.Trim();
	}

	public override string ToString()
	{
		return ret.ToString();
	}
}
