namespace dnSpy.Contracts.Decompiler.XmlDoc;

public interface IXmlDocOutput
{
	void WriteNewLine();

	void WriteSpace();

	void Write(string s, object data);
}
