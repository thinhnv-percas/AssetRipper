using System.Collections.Generic;

namespace ICSharpCode.Decompiler.ILAst;

public static class ILAstBuilderExtensionMethods
{
	public static List<T> CutRange<T>(this List<T> list, int start, int count)
	{
		List<T> list2 = new List<T>(count);
		for (int i = 0; i < count; i++)
		{
			list2.Add(list[start + i]);
		}
		list.RemoveRange(start, count);
		return list2;
	}
}
