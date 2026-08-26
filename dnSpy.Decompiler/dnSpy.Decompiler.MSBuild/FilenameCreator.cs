#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using dnlib.DotNet;

namespace dnSpy.Decompiler.MSBuild;

internal sealed class FilenameCreator
{
	private readonly string defaultNamespace;

	private readonly HashSet<string> usedNames;

	private readonly string baseDir;

	public string DefaultNamespace => defaultNamespace;

	public FilenameCreator(string baseDir)
	{
		Debug.Assert(Path.IsPathRooted(baseDir));
		this.baseDir = baseDir;
		defaultNamespace = string.Empty;
		usedNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
	}

	public FilenameCreator(string baseDir, string defaultNamespace)
	{
		Debug.Assert(Path.IsPathRooted(baseDir));
		this.baseDir = baseDir;
		this.defaultNamespace = defaultNamespace;
		usedNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
	}

	public string Create(string fileExt, string fullName)
	{
		Debug.Assert(fileExt != null && fileExt.Length > 1 && fileExt[0] == '.');
		string text = StripDefaultNamespace(fullName);
		if (string.IsNullOrEmpty(text))
		{
			text = fullName;
		}
		return Create(text.Split('.'), fileExt);
	}

	public string CreateFromNamespaceName(string fileExt, string ns, string name)
	{
		Debug.Assert(fileExt != null && fileExt.Length > 1 && fileExt[0] == '.');
		List<string> namespaceParts = GetNamespaceParts(ns);
		namespaceParts.Add(name);
		return Create(namespaceParts.ToArray(), fileExt);
	}

	private List<string> GetNamespaceParts(string ns)
	{
		ns = StripDefaultNamespace(ns);
		List<string> list = new List<string>();
		if (!string.IsNullOrEmpty(ns))
		{
			list.AddRange(ns.Split('.'));
		}
		return list;
	}

	private string StripDefaultNamespace(string name)
	{
		if (defaultNamespace.Equals(name))
		{
			return string.Empty;
		}
		if (name.StartsWith(defaultNamespace + "."))
		{
			return name.Substring(defaultNamespace.Length + 1);
		}
		return name;
	}

	public string CreateFromRelativePath(string relPath, string fileExt)
	{
		relPath = relPath.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
		return Create(relPath.Split(Path.DirectorySeparatorChar), fileExt);
	}

	private string Create(string[] parts, string fileExt)
	{
		fileExt = FilenameUtils.CleanName(fileExt);
		string text = string.Empty;
		foreach (string text2 in parts)
		{
			text = Path.Combine(text, FilenameUtils.CleanName(text2));
		}
		text = Path.Combine(baseDir, text);
		string text3 = text + fileExt;
		if (usedNames.Contains(text3))
		{
			int num = 2;
			while (true)
			{
				text3 = text + "." + num + fileExt;
				if (!usedNames.Contains(text3))
				{
					break;
				}
				num++;
			}
		}
		usedNames.Add(text3);
		return text3;
	}

	public string Create(ModuleDef module)
	{
		AssemblyDef assembly = module.Assembly;
		string name = ((assembly == null || !module.IsManifestModule) ? FileUtils.GetFilename(module.Name) : ((string)module.Assembly.Name));
		return Create(name);
	}

	private string Create(string name)
	{
		name = Path.Combine(baseDir, FilenameUtils.CleanName(name));
		if (usedNames.Contains(name))
		{
			string text = name;
			int num = 2;
			while (true)
			{
				name = text + "." + num;
				if (!usedNames.Contains(name))
				{
					break;
				}
				num++;
			}
		}
		usedNames.Add(name);
		return name;
	}

	public string CreateFromNamespaceFilename(string @namespace, string filename)
	{
		string extension = FileUtils.GetExtension(filename);
		string relPath = filename.Substring(0, filename.Length - extension.Length);
		ExtractNamespace(relPath, out var ns, out var name);
		if (!string.IsNullOrEmpty(ns))
		{
			@namespace = ((!string.IsNullOrEmpty(@namespace)) ? (@namespace + "." + ns) : ns);
		}
		List<string> namespaceParts = GetNamespaceParts(@namespace);
		namespaceParts.Add(FileUtils.GetFileNameWithoutExtension(name));
		return Create(namespaceParts.ToArray(), extension);
	}

	private static void ExtractNamespace(string relPath, out string ns, out string name)
	{
		int num = relPath.LastIndexOf('.');
		if (num < 0)
		{
			ns = string.Empty;
			name = relPath;
		}
		else
		{
			ns = relPath.Substring(0, num);
			name = relPath.Substring(num + 1);
		}
	}

	public string CreateName(string nameOnly)
	{
		string extension = FileUtils.GetExtension(nameOnly);
		string[] parts = new string[1] { FileUtils.GetFileNameWithoutExtension(nameOnly) };
		return Create(parts, extension);
	}
}
