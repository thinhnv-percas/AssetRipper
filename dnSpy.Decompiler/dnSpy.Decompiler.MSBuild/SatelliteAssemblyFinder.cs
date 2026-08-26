using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using dnlib.DotNet;

namespace dnSpy.Decompiler.MSBuild;

internal sealed class SatelliteAssemblyFinder : IDisposable
{
	private readonly HashSet<string> cultures;

	private readonly Dictionary<string, ModuleDef> openedModules;

	public SatelliteAssemblyFinder()
	{
		cultures = new HashSet<string>(from a in CultureInfo.GetCultures(CultureTypes.AllCultures)
			select a.Name, StringComparer.OrdinalIgnoreCase);
		openedModules = new Dictionary<string, ModuleDef>(StringComparer.OrdinalIgnoreCase);
	}

	private bool IsValidCulture(string name)
	{
		return !string.IsNullOrEmpty(name) && cultures.Contains(name);
	}

	public IEnumerable<ModuleDef> GetSatelliteAssemblies(ModuleDef module)
	{
		AssemblyDef asm = module.Assembly;
		if (asm == null)
		{
			yield break;
		}
		AssemblyNameInfo satAsmName = new AssemblyNameInfo(asm)
		{
			Name = string.Concat(asm.Name, ".resources")
		};
		foreach (string filename in GetFiles(asm, module))
		{
			if (File.Exists(filename))
			{
				AssemblyDef satAsm = TryOpenAssembly(filename);
				if (satAsm != null && AssemblyNameComparer.NameAndPublicKeyTokenOnly.Equals(satAsmName, satAsm))
				{
					yield return satAsm.ManifestModule;
				}
			}
		}
	}

	private IEnumerable<string> GetFiles(AssemblyDef asm, ModuleDef mod)
	{
		string baseDir = GetBaseDirectory(asm, mod);
		if (string.IsNullOrEmpty(baseDir))
		{
			yield break;
		}
		foreach (string bd in new List<string> { baseDir })
		{
			string[] directories = GetDirectories(bd);
			foreach (string dir in directories)
			{
				string name = Path.GetFileName(dir);
				if (IsValidCulture(name))
				{
					yield return Path.Combine(dir, string.Concat(asm.Name, ".resources.dll"));
					yield return Path.Combine(dir, asm.Name, string.Concat(asm.Name, ".resources.dll"));
				}
			}
		}
	}

	private string GetBaseDirectory(AssemblyDef asm, ModuleDef mod)
	{
		if (string.IsNullOrEmpty(mod.Location))
		{
			return string.Empty;
		}
		try
		{
			return Path.GetDirectoryName(mod.Location);
		}
		catch
		{
			return string.Empty;
		}
	}

	private static string[] GetDirectories(string dir)
	{
		try
		{
			return Directory.GetDirectories(dir);
		}
		catch
		{
		}
		return Array.Empty<string>();
	}

	private AssemblyDef TryOpenAssembly(string filename)
	{
		lock (openedModules)
		{
			if (openedModules.TryGetValue(filename, out var value))
			{
				return value.Assembly;
			}
			openedModules[filename] = null;
			if (!File.Exists(filename))
			{
				return null;
			}
			try
			{
				value = ModuleDefMD.Load(filename);
				if (value.Assembly == null || UTF8String.IsNullOrEmpty(value.Assembly.Culture))
				{
					value.Dispose();
					return null;
				}
				openedModules[filename] = value;
				return value.Assembly;
			}
			catch
			{
				return null;
			}
		}
	}

	public void Dispose()
	{
		foreach (ModuleDef value in openedModules.Values)
		{
			value.Dispose();
		}
	}
}
