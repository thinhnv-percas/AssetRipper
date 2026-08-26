using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace ICSharpCode.TextEditor.Document;

public class ResourceSyntaxModeProvider : ISyntaxModeFileProvider
{
	private List<SyntaxMode> syntaxModes;

	public ICollection<SyntaxMode> SyntaxModes => syntaxModes;

	public ResourceSyntaxModeProvider()
	{
		Stream manifestResourceStream = typeof(SyntaxMode).Assembly.GetManifestResourceStream("ICSharpCode.TextEditor.Resources.SyntaxModes.xml");
		if (manifestResourceStream != null)
		{
			syntaxModes = SyntaxMode.GetSyntaxModes(manifestResourceStream);
		}
		else
		{
			syntaxModes = new List<SyntaxMode>();
		}
	}

	public XmlTextReader GetSyntaxModeFile(SyntaxMode syntaxMode)
	{
		return new XmlTextReader(typeof(SyntaxMode).Assembly.GetManifestResourceStream("ICSharpCode.TextEditor.Resources." + syntaxMode.FileName));
	}

	public void UpdateSyntaxModeList()
	{
	}
}
