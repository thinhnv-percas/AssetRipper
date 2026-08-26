#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using dnlib.DotNet;
using Microsoft.Win32;

namespace dnSpy.Contracts.Utilities;

public static class GacInfo
{
	private sealed class GacDirInfo
	{
		public readonly int Version;

		public readonly string Path;

		public readonly string Prefix;

		public readonly IList<string> SubDirs;

		public GacDirInfo(int version, string prefix, string path, IList<string> subDirs)
		{
			Version = version;
			Prefix = prefix;
			Path = path;
			SubDirs = subDirs;
		}
	}

	private static readonly GacDirInfo[] gacDirInfos;

	private static readonly string[] extraMonoPaths;

	private static readonly string[] monoVerDirs;

	private static readonly Regex gac2Regex;

	private static readonly Regex gac4Regex;

	public static string[] GacPaths { get; }

	public static string[] OtherGacPaths { get; }

	public static string[] WinmdPaths { get; }

	static GacInfo()
	{
		monoVerDirs = new string[14]
		{
			"4.5", "4.5\\Facades", "4.5-api", "4.5-api\\Facades", "4.0", "4.0-api", "3.5", "3.5-api", "3.0", "3.0-api",
			"2.0", "2.0-api", "1.1", "1.0"
		};
		gac2Regex = new Regex("^([^_]+)_([^_]*)_([a-fA-F0-9]{16})$", RegexOptions.Compiled);
		gac4Regex = new Regex("^v[^_]+_([^_]+)_([^_]*)_([a-fA-F0-9]{16})$", RegexOptions.Compiled);
		List<GacDirInfo> list = new List<GacDirInfo>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		if (Type.GetType("Mono.Runtime") != null)
		{
			Dictionary<string, bool> dictionary = new Dictionary<string, bool>(StringComparer.OrdinalIgnoreCase);
			List<string> list4 = new List<string>();
			foreach (string item in FindMonoPrefixes())
			{
				string text = Path.Combine(Path.Combine(Path.Combine(item, "lib"), "mono"), "gac");
				if (dictionary.ContainsKey(text))
				{
					continue;
				}
				dictionary[text] = true;
				if (Directory.Exists(text))
				{
					list.Add(new GacDirInfo(4, "", Path.GetDirectoryName(text), new string[1] { Path.GetFileName(text) }));
				}
				text = Path.GetDirectoryName(text);
				string[] array = monoVerDirs;
				foreach (string text2 in array)
				{
					string text3 = text;
					string[] array2 = text2.Split('\\');
					foreach (string path in array2)
					{
						text3 = Path.Combine(text3, path);
					}
					if (Directory.Exists(text3))
					{
						list4.Add(text3);
					}
				}
			}
			string environmentVariable = Environment.GetEnvironmentVariable("MONO_PATH");
			if (environmentVariable != null)
			{
				string[] array3 = environmentVariable.Split(Path.PathSeparator);
				foreach (string text4 in array3)
				{
					string text5 = text4.Trim();
					if (text5 != string.Empty && Directory.Exists(text5))
					{
						list4.Add(text5);
					}
				}
			}
			extraMonoPaths = list4.ToArray();
			list2.AddRange(extraMonoPaths);
		}
		else
		{
			string environmentVariable2 = Environment.GetEnvironmentVariable("WINDIR");
			if (!string.IsNullOrEmpty(environmentVariable2))
			{
				string path2 = Path.Combine(environmentVariable2, "assembly");
				if (Directory.Exists(path2))
				{
					list.Add(new GacDirInfo(2, "", path2, new string[4] { "GAC_32", "GAC_64", "GAC_MSIL", "GAC" }));
				}
				path2 = Path.Combine(Path.Combine(environmentVariable2, "Microsoft.NET"), "assembly");
				if (Directory.Exists(path2))
				{
					list.Add(new GacDirInfo(4, "v4.0_", path2, new string[3] { "GAC_32", "GAC_64", "GAC_MSIL" }));
				}
				AddIfExists(list2, environmentVariable2, "Microsoft.NET\\Framework\\v1.1.4322");
				AddIfExists(list2, environmentVariable2, "Microsoft.NET\\Framework\\v1.0.3705");
			}
			foreach (string dotNetInstallDirectory in GetDotNetInstallDirectories())
			{
				AddIfExists(list2, dotNetInstallDirectory, string.Empty);
			}
			string environmentVariable3 = Environment.GetEnvironmentVariable("ProgramFiles");
			AddWinMDPaths(list3, environmentVariable3);
			string environmentVariable4 = Environment.GetEnvironmentVariable("ProgramFiles(x86)");
			if (!StringComparer.OrdinalIgnoreCase.Equals(environmentVariable3, environmentVariable4))
			{
				AddWinMDPaths(list3, environmentVariable4);
			}
			AddIfExists(list3, Environment.SystemDirectory, "WinMetadata");
		}
		OtherGacPaths = list2.ToArray();
		WinmdPaths = list3.ToArray();
		gacDirInfos = list.ToArray();
		GacPaths = gacDirInfos.Select((GacDirInfo a) => a.Path).ToArray();
	}

	private static string GetCurrentMonoPrefix()
	{
		string text = typeof(object).Module.FullyQualifiedName;
		for (int i = 0; i < 4; i++)
		{
			text = Path.GetDirectoryName(text);
		}
		return text;
	}

	private static IEnumerable<string> FindMonoPrefixes()
	{
		yield return GetCurrentMonoPrefix();
		string prefixes = Environment.GetEnvironmentVariable("MONO_GAC_PREFIX");
		if (string.IsNullOrEmpty(prefixes))
		{
			yield break;
		}
		string[] array = prefixes.Split(Path.PathSeparator);
		foreach (string tmp in array)
		{
			string prefix = tmp.Trim();
			if (prefix != string.Empty)
			{
				yield return prefix;
			}
		}
	}

	private static IEnumerable<string> GetDotNetInstallDirectories()
	{
		HashSet<string> hashSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		try
		{
			using RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\.NETFramework");
			string text = ((registryKey == null) ? null : (registryKey.GetValue("InstallRoot") as string));
			if (Directory.Exists(text))
			{
				hashSet.Add(text);
			}
		}
		catch
		{
		}
		try
		{
			using RegistryKey registryKey2 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Microsoft\\.NETFramework");
			string text2 = ((registryKey2 == null) ? null : (registryKey2.GetValue("InstallRoot") as string));
			if (Directory.Exists(text2))
			{
				hashSet.Add(text2);
			}
		}
		catch
		{
		}
		string[] array = hashSet.ToArray();
		hashSet.Clear();
		hashSet.Add(Path.GetDirectoryName(typeof(int).Assembly.Location));
		string[] array2 = array;
		foreach (string path in array2)
		{
			string text3 = Path.Combine(Path.GetDirectoryName(path), Path.GetFileName(path));
			hashSet.Add(text3);
			string fileName = Path.GetFileName(text3);
			if (fileName.Equals("Framework", StringComparison.OrdinalIgnoreCase) || fileName.Equals("Framework64", StringComparison.OrdinalIgnoreCase))
			{
				string directoryName = Path.GetDirectoryName(text3);
				hashSet.Add(Path.Combine(directoryName, "Framework"));
				hashSet.Add(Path.Combine(directoryName, "Framework64"));
			}
		}
		return hashSet;
	}

	private static void AddWinMDPaths(IList<string> paths, string path)
	{
		if (!string.IsNullOrEmpty(path))
		{
			AddIfExists(paths, path, "Windows Kits\\10\\UnionMetadata");
			AddIfExists(paths, path, "Windows Kits\\8.1\\References\\CommonConfiguration\\Neutral");
			AddIfExists(paths, path, "Windows Kits\\8.0\\References\\CommonConfiguration\\Neutral");
		}
	}

	private static void AddIfExists(IList<string> paths, string basePath, string extraPath)
	{
		string text = Path.Combine(basePath, extraPath);
		if (Directory.Exists(text))
		{
			paths.Add(text);
		}
	}

	public static bool IsGacPath(string filename)
	{
		if (!File.Exists(filename))
		{
			return false;
		}
		string[] gacPaths = GacPaths;
		foreach (string path in gacPaths)
		{
			if (IsSubPath(path, filename))
			{
				return true;
			}
		}
		string[] otherGacPaths = OtherGacPaths;
		foreach (string path2 in otherGacPaths)
		{
			if (IsSubPath(path2, filename))
			{
				return true;
			}
		}
		return false;
	}

	private static bool IsSubPath(string path, string filename)
	{
		filename = Path.GetFullPath(Path.GetDirectoryName(filename));
		string pathRoot = Path.GetPathRoot(filename);
		while (!StringComparer.OrdinalIgnoreCase.Equals(filename, pathRoot))
		{
			if (StringComparer.OrdinalIgnoreCase.Equals(path, filename))
			{
				return true;
			}
			filename = Path.GetDirectoryName(filename);
		}
		return false;
	}

	public static string FindInGac(IAssembly asm)
	{
		if (asm == null)
		{
			return null;
		}
		PublicKeyToken publicKeyToken = PublicKeyBase.ToPublicKeyToken(asm.PublicKeyOrToken);
		if (PublicKeyBase.IsNullOrEmpty2(publicKeyToken))
		{
			return null;
		}
		GacDirInfo[] array = gacDirInfos;
		foreach (GacDirInfo gacInfo in array)
		{
			using IEnumerator<string> enumerator = GetAssemblies(gacInfo, publicKeyToken, asm).GetEnumerator();
			if (enumerator.MoveNext())
			{
				return enumerator.Current;
			}
		}
		return null;
	}

	private static IEnumerable<string> GetAssemblies(GacDirInfo gacInfo, PublicKeyToken pkt, IAssembly assembly)
	{
		string pktString = pkt.ToString();
		string verString = assembly.Version.ToString();
		string cultureString = UTF8String.ToSystemStringOrEmpty(assembly.Culture);
		if (cultureString.Equals("neutral", StringComparison.OrdinalIgnoreCase))
		{
			cultureString = string.Empty;
		}
		string asmSimpleName = UTF8String.ToSystemStringOrEmpty(assembly.Name);
		using IEnumerator<string> enumerator = gacInfo.SubDirs.GetEnumerator();
		while (enumerator.MoveNext())
		{
			string baseDir = Path.Combine(path2: enumerator.Current, path1: gacInfo.Path);
			string pathName;
			try
			{
				baseDir = Path.Combine(baseDir, asmSimpleName);
				baseDir = Path.Combine(baseDir, $"{gacInfo.Prefix}{verString}_{cultureString}_{pktString}");
				pathName = Path.Combine(baseDir, asmSimpleName + ".dll");
			}
			catch (ArgumentException)
			{
				yield break;
			}
			if (File.Exists(pathName))
			{
				yield return pathName;
			}
		}
	}

	public static IEnumerable<GacFileInfo> GetAssemblies(int majorVersion)
	{
		GacDirInfo[] array = gacDirInfos;
		foreach (GacDirInfo gacDirInfo in array)
		{
			if (gacDirInfo.Version == majorVersion)
			{
				return GetAssemblies(gacDirInfo);
			}
		}
		Debug.Fail("Invalid version");
		return Array.Empty<GacFileInfo>();
	}

	private static IEnumerable<GacFileInfo> GetAssemblies(GacDirInfo gacInfo)
	{
		using IEnumerator<string> enumerator = gacInfo.SubDirs.GetEnumerator();
		while (enumerator.MoveNext())
		{
			string baseDir = Path.Combine(path2: enumerator.Current, path1: gacInfo.Path);
			string[] directories = GetDirectories(baseDir);
			foreach (string dir in directories)
			{
				string[] directories2 = GetDirectories(dir);
				foreach (string dir2 in directories2)
				{
					Version version;
					string culture;
					PublicKeyToken pkt;
					if (gacInfo.Version == 2)
					{
						Match m = gac2Regex.Match(Path.GetFileName(dir2));
						if (!m.Success || m.Groups.Count != 4 || !Version.TryParse(m.Groups[1].Value, out version))
						{
							continue;
						}
						culture = m.Groups[2].Value;
						pkt = new PublicKeyToken(m.Groups[3].Value);
						if (PublicKeyBase.IsNullOrEmpty2(pkt))
						{
							continue;
						}
					}
					else
					{
						if (gacInfo.Version != 4)
						{
							throw new InvalidOperationException();
						}
						Match m2 = gac4Regex.Match(Path.GetFileName(dir2));
						if (!m2.Success || m2.Groups.Count != 4 || !Version.TryParse(m2.Groups[1].Value, out version))
						{
							continue;
						}
						culture = m2.Groups[2].Value;
						pkt = new PublicKeyToken(m2.Groups[3].Value);
						if (PublicKeyBase.IsNullOrEmpty2(pkt))
						{
							continue;
						}
					}
					string asmName = Path.GetFileName(dir);
					string file = Path.Combine(dir2, asmName) + ".dll";
					if (!File.Exists(file))
					{
						file = Path.Combine(dir2, asmName) + ".exe";
						if (!File.Exists(file))
						{
							continue;
						}
					}
					AssemblyNameInfo asmInfo = new AssemblyNameInfo
					{
						Name = asmName,
						Version = version,
						Culture = culture,
						PublicKeyOrToken = pkt
					};
					yield return new GacFileInfo(asmInfo, file);
					version = null;
				}
			}
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
}
