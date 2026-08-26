#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using dnlib.DotNet;

namespace dnSpy.Decompiler.MSBuild;

internal readonly struct DefaultNamespaceFinder
{
	private readonly struct Info
	{
		public readonly string FirstPart;

		public readonly string CommonPrefix;

		public readonly string[] Namespaces;

		public Info(string first, string common, string[] namespaces)
		{
			FirstPart = first;
			CommonPrefix = common;
			Namespaces = namespaces;
		}
	}

	private readonly ModuleDef module;

	public DefaultNamespaceFinder(ModuleDef module)
	{
		this.module = module;
	}

	public string Find()
	{
		HashSet<string> source = new HashSet<string>(module.Types.Select((TypeDef a) => a.Namespace.String).Where(IsValidNamespace), StringComparer.Ordinal);
		List<Info> list = new List<Info>();
		foreach (string f in source.Select((string a) => GetFirstPart(a)).Distinct())
		{
			string[] namespaces = source.Where((string a) => a.Equals(f) || a.StartsWith(f + ".", StringComparison.Ordinal)).ToArray();
			Info item = new Info(f, GetCommon(namespaces), namespaces);
			list.Add(item);
		}
		Info info = PickNamespace(list);
		string moduleNamespace = GetModuleNamespace(module);
		string text = info.CommonPrefix;
		if (!string.IsNullOrEmpty(moduleNamespace) && text != null && text.StartsWith(moduleNamespace + "."))
		{
			text = moduleNamespace;
		}
		return text ?? string.Empty;
	}

	private Info PickNamespace(List<Info> infos)
	{
		if (infos.Count == 0)
		{
			return default(Info);
		}
		if (infos.Count == 1)
		{
			return infos[0];
		}
		string modNs = GetModuleNamespace(module);
		Info result = infos.FirstOrDefault((Info a) => modNs.Equals(a.CommonPrefix) || a.CommonPrefix.StartsWith(modNs));
		if (result.CommonPrefix != null)
		{
			return result;
		}
		return default(Info);
	}

	private static string GetCommon(string[] namespaces)
	{
		string text = null;
		StringBuilder sb = new StringBuilder();
		foreach (string text2 in namespaces)
		{
			Debug.Assert(IsValidNamespace(text2));
			text = ((text != null) ? GetCommonNamespace(sb, text, text2) : text2);
		}
		Debug.Assert(text != null);
		return text ?? string.Empty;
	}

	private static string GetFirstPart(string ns)
	{
		int num = ns.IndexOf('.');
		return (num < 0) ? ns : ns.Substring(0, num);
	}

	private static bool IsValidNamespace(string ns)
	{
		return !string.IsNullOrEmpty(ns) && ns != "XamlGeneratedNamespace";
	}

	private static string GetCommonNamespace(StringBuilder sb, string a, string b)
	{
		sb.Clear();
		string[] array = a.Split('.');
		string[] array2 = b.Split('.');
		for (int i = 0; i < array.Length && i < array2.Length && StringComparer.Ordinal.Equals(array[i], array2[i]); i++)
		{
			if (sb.Length > 0)
			{
				sb.Append('.');
			}
			sb.Append(array[i]);
		}
		return sb.ToString();
	}

	private static string GetModuleNamespace(ModuleDef module)
	{
		AssemblyDef assembly = module.Assembly;
		string text;
		if (assembly != null && module.IsManifestModule)
		{
			text = assembly.Name;
		}
		else
		{
			text = module.Name;
			if (text.EndsWith(".exe", StringComparison.OrdinalIgnoreCase) || text.EndsWith(".dll", StringComparison.OrdinalIgnoreCase))
			{
				text = text.Substring(0, text.Length - 4);
			}
			text = ((!text.EndsWith(".netmodule", StringComparison.OrdinalIgnoreCase)) ? string.Empty : text.Substring(0, text.Length - 10));
		}
		return text.Replace('-', '_');
	}
}
