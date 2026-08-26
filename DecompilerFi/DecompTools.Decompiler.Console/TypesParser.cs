using System;
using System.Collections.Generic;
using System.Linq;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.Console;

public static class TypesParser
{
	public static HashSet<TypeKind> ParseSelection(string[] values)
	{
		Dictionary<string, TypeKind> dictionary = new Dictionary<string, TypeKind>(StringComparer.OrdinalIgnoreCase)
		{
			["class"] = TypeKind.Class,
			["struct"] = TypeKind.Struct,
			["interface"] = TypeKind.Interface,
			["enum"] = TypeKind.Enum,
			["delegate"] = TypeKind.Delegate
		};
		HashSet<TypeKind> hashSet = new HashSet<TypeKind>();
		if (values.Length == 1 && !dictionary.Keys.Any((string v) => values[0].StartsWith(v, StringComparison.OrdinalIgnoreCase)))
		{
			string text = values[0];
			for (int num = 0; num < text.Length; num++)
			{
				switch (text[num])
				{
				case 'c':
					hashSet.Add(TypeKind.Class);
					break;
				case 'i':
					hashSet.Add(TypeKind.Interface);
					break;
				case 's':
					hashSet.Add(TypeKind.Struct);
					break;
				case 'd':
					hashSet.Add(TypeKind.Delegate);
					break;
				case 'e':
					hashSet.Add(TypeKind.Enum);
					break;
				}
			}
		}
		else
		{
			string[] array = values;
			foreach (string text2 in array)
			{
				string text3 = text2;
				while (text3.Length > 0 && !dictionary.ContainsKey(text3))
				{
					text3 = text3.Remove(checked(text3.Length - 1));
				}
				if (dictionary.TryGetValue(text3, out var value))
				{
					hashSet.Add(value);
				}
			}
		}
		return hashSet;
	}
}
