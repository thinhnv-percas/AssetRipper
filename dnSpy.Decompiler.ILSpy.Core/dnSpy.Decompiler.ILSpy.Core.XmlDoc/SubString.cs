using System.Text;

namespace dnSpy.Decompiler.ILSpy.Core.XmlDoc;

internal struct SubString
{
	public readonly string String;

	public readonly int Index;

	public readonly int Length;

	public SubString(string s, int index, int length)
	{
		String = s;
		Index = index;
		Length = length;
	}

	public override string ToString()
	{
		return String.Substring(Index, Length);
	}

	public void WriteTo(StringBuilder sb)
	{
		sb.Append(String, Index, Length);
	}
}
