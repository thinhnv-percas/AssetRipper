using System.Text;
using dnSpy.Contracts.Decompiler;

namespace dnSpy.Contracts.Text;

public static class NameUtilities
{
	public static string CleanName(string n)
	{
		if (n == null)
		{
			return n;
		}
		if (n.Length > 256)
		{
			n = n.Substring(0, 256);
		}
		StringBuilder stringBuilder = new StringBuilder(n.Length);
		for (int i = 0; i < n.Length; i++)
		{
			char c = n[i];
			if (c < ' ')
			{
				c = '_';
			}
			stringBuilder.Append(c);
		}
		return stringBuilder.ToString();
	}

	public static string CleanIdentifier(string id)
	{
		if (id == null)
		{
			return id;
		}
		id = IdentifierEscaper.Escape(id);
		return CleanName(id);
	}
}
