using System.Xml.XPath;

namespace ImageMagick;

public sealed class ClipPath
{
	public string Name { get; private set; }

	public IXPathNavigable Path { get; private set; }

	internal ClipPath(string name, IXPathNavigable path)
	{
		Name = name;
		Path = path;
	}
}
