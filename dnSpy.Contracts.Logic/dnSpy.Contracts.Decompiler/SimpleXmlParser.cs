using System.Collections.Generic;
using dnSpy.Contracts.Text;

namespace dnSpy.Contracts.Decompiler;

internal static class SimpleXmlParser
{
	private static readonly char[] specialChars = new char[1] { '<' };

	private static readonly char[] specialCharsTag = new char[3] { '<', '>', '"' };

	public static IEnumerable<(string text, object color)> Parse(string text)
	{
		bool inTag = true;
		int index = 0;
		while (index < text.Length)
		{
			int specialIndex = text.IndexOfAny(inTag ? specialCharsTag : specialChars, index);
			if (specialIndex < 0)
			{
				yield return (text: text.Substring(index), color: BoxedTextColor.XmlDocCommentText);
				break;
			}
			char c = text[specialIndex];
			if (c == '>')
			{
				yield return (text: text.Substring(index, specialIndex - index + 1), color: BoxedTextColor.XmlDocCommentText);
				index = specialIndex + 1;
			}
			else
			{
				if (specialIndex - index > 0)
				{
					if (c == '<')
					{
						yield return (text: text.Substring(index, specialIndex - index), color: BoxedTextColor.XmlDocCommentText);
					}
					else
					{
						yield return (text: text.Substring(index, specialIndex - index), color: inTag ? BoxedTextColor.XmlDocCommentName : BoxedTextColor.XmlDocCommentText);
					}
				}
				index = specialIndex;
				int endIndex = text.IndexOf('>', index);
				endIndex = ((endIndex < 0) ? text.Length : (endIndex + 1));
				while (index < endIndex)
				{
					int attrIndex = text.IndexOf('"', index, endIndex - index);
					if (attrIndex < 0)
					{
						yield return (text: text.Substring(index, endIndex - index), color: BoxedTextColor.XmlDocCommentName);
						break;
					}
					if (attrIndex - index > 0)
					{
						yield return (text: text.Substring(index, attrIndex - index), color: BoxedTextColor.XmlDocCommentName);
					}
					int endAttrIndex = text.IndexOf('"', attrIndex + 1, endIndex - attrIndex - 1);
					if (endAttrIndex < 0)
					{
						yield return (text: text.Substring(attrIndex, endIndex - attrIndex), color: BoxedTextColor.XmlDocCommentAttributeValue);
						break;
					}
					yield return (text: text.Substring(attrIndex, endAttrIndex - attrIndex + 1), color: BoxedTextColor.XmlDocCommentAttributeValue);
					index = endAttrIndex + 1;
				}
				index = endIndex;
			}
			inTag = false;
		}
	}
}
