using System.Text;

namespace McMaster.Extensions.CommandLineUtils;

internal static class StringExtensions
{
	public static string ToKebabCase(this string str)
	{
		if (string.IsNullOrEmpty(str))
		{
			return str;
		}
		StringBuilder stringBuilder = new StringBuilder();
		int i = 0;
		bool flag = false;
		for (; i < str.Length; i++)
		{
			char c = str[i];
			if (char.IsLetterOrDigit(c))
			{
				flag = !char.IsUpper(c);
				stringBuilder.Append(char.ToLowerInvariant(c));
				i++;
				break;
			}
		}
		for (; i < str.Length; i++)
		{
			char c2 = str[i];
			if (char.IsUpper(c2))
			{
				if (flag)
				{
					flag = false;
					stringBuilder.Append('-');
				}
				stringBuilder.Append(char.ToLowerInvariant(c2));
			}
			else if (char.IsLetterOrDigit(c2))
			{
				flag = true;
				stringBuilder.Append(c2);
			}
			else
			{
				flag = false;
				stringBuilder.Append('-');
			}
		}
		while (stringBuilder.Length > 0 && stringBuilder[stringBuilder.Length - 1] == '-')
		{
			stringBuilder.Remove(stringBuilder.Length - 1, 1);
		}
		return stringBuilder.ToString();
	}

	public static string ToConstantCase(this string str)
	{
		if (string.IsNullOrEmpty(str))
		{
			return str;
		}
		StringBuilder stringBuilder = new StringBuilder();
		int i = 0;
		bool flag = false;
		for (; i < str.Length; i++)
		{
			char c = str[i];
			if (char.IsLetterOrDigit(c))
			{
				flag = !char.IsUpper(c);
				stringBuilder.Append(char.ToUpperInvariant(c));
				i++;
				break;
			}
		}
		for (; i < str.Length; i++)
		{
			char c2 = str[i];
			if (char.IsUpper(c2))
			{
				if (flag)
				{
					flag = false;
					stringBuilder.Append('_');
				}
				stringBuilder.Append(char.ToUpperInvariant(c2));
			}
			else if (char.IsLetterOrDigit(c2))
			{
				flag = true;
				stringBuilder.Append(char.ToUpperInvariant(c2));
			}
			else
			{
				flag = false;
				stringBuilder.Append('_');
			}
		}
		return stringBuilder.ToString();
	}
}
