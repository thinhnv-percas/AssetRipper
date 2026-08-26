using System.IO;
using System.Text;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Xml;

namespace HelixToolkit.Wpf;

public class XamlHelper
{
	public static string GetXaml(Viewport3D view)
	{
		StringBuilder stringBuilder = new StringBuilder();
		using StringWriter w = new StringWriter(stringBuilder);
		XmlTextWriter xmlWriter = new XmlTextWriter(w)
		{
			Formatting = Formatting.Indented
		};
		XamlWriter.Save(view, xmlWriter);
		string text = stringBuilder.ToString();
		return text.Replace($"<Viewport3D Height=\"{view.ActualHeight}\" Width=\"{view.ActualWidth}\" ", "<Viewport3D ");
	}

	public static string GetXaml(object obj)
	{
		StringBuilder stringBuilder = new StringBuilder();
		using (StringWriter w = new StringWriter(stringBuilder))
		{
			XmlTextWriter xmlWriter = new XmlTextWriter(w)
			{
				Formatting = Formatting.Indented
			};
			XamlWriter.Save(obj, xmlWriter);
		}
		return stringBuilder.ToString();
	}
}
