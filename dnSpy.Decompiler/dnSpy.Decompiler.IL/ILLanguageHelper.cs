using dnlib.DotNet.Emit;
using dnSpy.Contracts.Decompiler.XmlDoc;

namespace dnSpy.Decompiler.IL;

public static class ILLanguageHelper
{
	private static readonly string[] cachedOpCodeDocs = new string[512];

	public static string GetOpCodeDocumentation(OpCode code)
	{
		int num = (int)code.Code;
		switch (num >> 8)
		{
		case 254:
			num -= 64768;
			break;
		default:
			return null;
		case 0:
			break;
		}
		string text = cachedOpCodeDocs[num];
		if (text != null)
		{
			return text;
		}
		XmlDocumentationProvider mscorlibDocumentation = XmlDocLoader.MscorlibDocumentation;
		if (mscorlibDocumentation != null)
		{
			string documentation = mscorlibDocumentation.GetDocumentation("F:System.Reflection.Emit.OpCodes." + code.Code);
			if (documentation != null)
			{
				XmlDocRenderer xmlDocRenderer = new XmlDocRenderer();
				xmlDocRenderer.AddXmlDocumentation(documentation);
				return cachedOpCodeDocs[num] = xmlDocRenderer.ToString();
			}
		}
		return null;
	}
}
