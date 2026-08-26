using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Microsoft.VisualStudio.Composition;

internal static class Dgml
{
	internal const string Namespace = "http://schemas.microsoft.com/vs/2009/dgml";

	private static readonly XName NodeName = XName.Get("Node", "http://schemas.microsoft.com/vs/2009/dgml");

	private static readonly XName NodesName = XName.Get("Nodes", "http://schemas.microsoft.com/vs/2009/dgml");

	private static readonly XName LinkName = XName.Get("Link", "http://schemas.microsoft.com/vs/2009/dgml");

	private static readonly XName LinksName = XName.Get("Links", "http://schemas.microsoft.com/vs/2009/dgml");

	private static readonly XName StylesName = XName.Get("Styles", "http://schemas.microsoft.com/vs/2009/dgml");

	private static readonly XName StyleName = XName.Get("Style", "http://schemas.microsoft.com/vs/2009/dgml");

	internal static XDocument Create(out XElement nodes, out XElement links, string layout = "Sugiyama", string direction = null)
	{
		XDocument xDocument = new XDocument();
		xDocument.Add(new XElement(XName.Get("DirectedGraph", "http://schemas.microsoft.com/vs/2009/dgml"), new XAttribute("Layout", layout)));
		if (direction != null)
		{
			xDocument.Root.Add(new XAttribute("GraphDirection", direction));
		}
		nodes = new XElement(XName.Get("Nodes", "http://schemas.microsoft.com/vs/2009/dgml"));
		links = new XElement(XName.Get("Links", "http://schemas.microsoft.com/vs/2009/dgml"));
		xDocument.Root.Add(nodes);
		xDocument.Root.Add(links);
		xDocument.WithCategories(Category("Contains", null, null, null, null, isTag: false, isContainment: true));
		return xDocument;
	}

	private static XElement GetRootElement(this XDocument document, XName name)
	{
		Requires.NotNull(document, "document");
		Requires.NotNull(name, "name");
		XElement xElement = document.Root.Element(name);
		if (xElement == null)
		{
			document.Root.Add(xElement = new XElement(name));
		}
		return xElement;
	}

	private static XElement GetRootElement(XDocument document, string elementName)
	{
		Requires.NotNull(document, "document");
		Requires.NotNullOrEmpty(elementName, "elementName");
		return document.GetRootElement(XName.Get(elementName, "http://schemas.microsoft.com/vs/2009/dgml"));
	}

	internal static XDocument WithCategories(this XDocument document, params string[] categories)
	{
		Requires.NotNull(document, "document");
		Requires.NotNull(categories, "categories");
		GetRootElement(document, "Categories").Add(categories.Select((string c) => Category(c)));
		return document;
	}

	internal static XDocument WithCategories(this XDocument document, params XElement[] categories)
	{
		Requires.NotNull(document, "document");
		Requires.NotNull(categories, "categories");
		GetRootElement(document, "Categories").Add(categories);
		return document;
	}

	internal static XElement Node(string id = null, string label = null, string group = null)
	{
		XElement xElement = new XElement(NodeName);
		if (!string.IsNullOrEmpty(id))
		{
			xElement.SetAttributeValue("Id", id);
		}
		if (!string.IsNullOrEmpty(label))
		{
			xElement.SetAttributeValue("Label", label);
		}
		if (!string.IsNullOrEmpty(group))
		{
			xElement.SetAttributeValue("Group", group);
		}
		return xElement;
	}

	internal static XDocument WithNode(this XDocument document, XElement node)
	{
		Requires.NotNull(document, "document");
		Requires.NotNull(node, "node");
		document.GetRootElement(NodesName).Add(node);
		return document;
	}

	internal static XElement Link(string source, string target, string label)
	{
		Requires.NotNullOrEmpty(source, "source");
		Requires.NotNullOrEmpty(target, "target");
		XElement xElement = new XElement(LinkName, new XAttribute("Source", source), new XAttribute("Target", target));
		if (!string.IsNullOrEmpty(label))
		{
			xElement.SetAttributeValue("Label", label);
		}
		return xElement;
	}

	internal static XElement Link(XElement source, XElement target, string label)
	{
		return Link(source.Attribute("Id").Value, target.Attribute("Id").Value, label);
	}

	internal static XDocument WithLink(this XDocument document, XElement link)
	{
		Requires.NotNull(document, "document");
		Requires.NotNull(link, "link");
		document.GetRootElement(LinksName).Add(link);
		return document;
	}

	internal static XElement Category(string id, string label = null, string background = null, string foreground = null, string icon = null, bool isTag = false, bool isContainment = false)
	{
		Requires.NotNullOrEmpty(id, "id");
		XElement xElement = new XElement(XName.Get("Category", "http://schemas.microsoft.com/vs/2009/dgml"), new XAttribute("Id", id));
		if (!string.IsNullOrEmpty(label))
		{
			xElement.SetAttributeValue("Label", label);
		}
		if (!string.IsNullOrEmpty(background))
		{
			xElement.SetAttributeValue("Background", background);
		}
		if (!string.IsNullOrEmpty(foreground))
		{
			xElement.SetAttributeValue("Foreground", foreground);
		}
		if (!string.IsNullOrEmpty(icon))
		{
			xElement.SetAttributeValue("Icon", icon);
		}
		if (isTag)
		{
			xElement.SetAttributeValue("IsTag", "True");
		}
		if (isContainment)
		{
			xElement.SetAttributeValue("IsContainment", "True");
		}
		return xElement;
	}

	internal static XElement Comment(string label)
	{
		return Node(null, label).WithCategories("Comment");
	}

	internal static XElement Container(string id, string label = null)
	{
		return Node(id, label, "Expanded");
	}

	internal static XDocument WithContainers(this XDocument document, IEnumerable<XElement> containers)
	{
		foreach (XElement container in containers)
		{
			document.WithNode(container);
		}
		return document;
	}

	internal static XElement ContainedBy(this XElement node, XElement container)
	{
		Requires.NotNull(node, "node");
		Requires.NotNull(container, "container");
		Link(container, node, null).WithCategories("Contains");
		return node;
	}

	internal static XElement ContainedBy(this XElement node, string containerId, XDocument document)
	{
		Requires.NotNull(node, "node");
		Requires.NotNullOrEmpty(containerId, "containerId");
		document.WithLink(Link(containerId, node.Attribute("Id").Value, null).WithCategories("Contains"));
		return node;
	}

	internal static XElement WithCategories(this XElement element, params string[] categories)
	{
		Requires.NotNull(element, "element");
		foreach (string value in categories)
		{
			if (element.Attribute("Category") == null)
			{
				element.SetAttributeValue("Category", value);
			}
			else
			{
				element.Add(new XElement(XName.Get("Category", "http://schemas.microsoft.com/vs/2009/dgml"), new XAttribute("Ref", value)));
			}
		}
		return element;
	}

	internal static XDocument WithStyle(this XDocument document, string categoryId, IEnumerable<KeyValuePair<string, string>> properties, string targetType = "Node")
	{
		Requires.NotNull(document, "document");
		Requires.NotNullOrEmpty(categoryId, "categoryId");
		Requires.NotNull(properties, "properties");
		Requires.NotNullOrEmpty(targetType, "targetType");
		XElement xElement = document.Root.Element(StylesName);
		if (xElement == null)
		{
			document.Root.Add(xElement = new XElement(StylesName));
		}
		XElement xElement2 = new XElement(StyleName, new XAttribute("TargetType", targetType), new XAttribute("GroupLabel", categoryId), new XElement(XName.Get("Condition", "http://schemas.microsoft.com/vs/2009/dgml"), new XAttribute("Expression", "HasCategory('" + categoryId + "')")));
		xElement2.Add(properties.Select((KeyValuePair<string, string> p) => new XElement(XName.Get("Setter", "http://schemas.microsoft.com/vs/2009/dgml"), new XAttribute("Property", p.Key), new XAttribute("Value", p.Value))));
		xElement.Add(xElement2);
		return document;
	}

	internal static XDocument WithStyle(this XDocument document, string categoryId, string targetType = "Node", string foreground = null, string background = null, string icon = null)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		if (!string.IsNullOrEmpty(foreground))
		{
			dictionary.Add("Foreground", foreground);
		}
		if (!string.IsNullOrEmpty(background))
		{
			dictionary.Add("Background", background);
		}
		if (!string.IsNullOrEmpty(icon))
		{
			dictionary.Add("Icon", icon);
		}
		return document.WithStyle(categoryId, dictionary, targetType);
	}
}
