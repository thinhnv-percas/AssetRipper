using System.Collections.Generic;
using System.Globalization;

namespace ICSharpCode.NRefactory.CSharp
{
	public static class WordParser
	{
		public static List<string> BreakWords(string identifier)
		{
			List<string> list = new List<string>();
			int num = 0;
			bool flag = false;
			bool flag2 = false;
			for (int i = 0; i < identifier.Length; i++)
			{
				char c = identifier[i];
				switch (char.GetUnicodeCategory(c))
				{
				case UnicodeCategory.LowercaseLetter:
					if (flag2 && i - num > 2)
					{
						list.Add(identifier.Substring(num, i - num - 1));
						num = i - 1;
					}
					flag = true;
					flag2 = false;
					continue;
				case UnicodeCategory.UppercaseLetter:
					if (flag)
					{
						list.Add(identifier.Substring(num, i - num));
						num = i;
					}
					flag = false;
					flag2 = true;
					continue;
				}
				if (c == '_')
				{
					if (i - num > 0)
					{
						list.Add(identifier.Substring(num, i - num));
					}
					num = i + 1;
					flag = (flag2 = false);
				}
			}
			if (num < identifier.Length)
			{
				list.Add(identifier.Substring(num));
			}
			return list;
		}
	}
}
