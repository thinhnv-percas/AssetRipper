using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using DecompTools.Decompiler.Util;
using LightJson;
using LightJson.Serialization;

namespace DecompTools.Decompiler.Metadata;

public class DotNetCorePathFinder
{
	private class DotNetCorePackageInfo
	{
		public readonly string Name;

		public readonly string Version;

		public readonly string Type;

		public readonly string Path;

		public readonly string[] RuntimeComponents;

		public DotNetCorePackageInfo(string fullName, string type, string path, string[] runtimeComponents)
		{
			string[] array = fullName.Split(new char[1] { '/' });
			Name = array[0];
			Version = array[1];
			Type = type;
			Path = path;
			RuntimeComponents = runtimeComponents ?? Empty<string>.Array;
		}
	}

	private static readonly string[] LookupPaths = new string[1] { Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".nuget", "packages") };

	private readonly Dictionary<string, DotNetCorePackageInfo> packages;

	private ISet<string> packageBasePaths = (ISet<string>)new HashSet<string>((IEqualityComparer<string>)StringComparer.Ordinal);

	private readonly string assemblyName;

	private readonly string basePath;

	private readonly Version version;

	private readonly string dotnetBasePath = FindDotNetExeDirectory();

	public DotNetCorePathFinder(string parentAssemblyFileName, string targetFrameworkId, Version version, ReferenceLoadInfo loadInfo = null)
	{
		assemblyName = Path.GetFileNameWithoutExtension(parentAssemblyFileName);
		basePath = Path.GetDirectoryName(parentAssemblyFileName);
		this.version = version;
		string text = Path.Combine(basePath, assemblyName + ".deps.json");
		if (!File.Exists(text))
		{
			loadInfo?.AddMessage(assemblyName, MessageKind.Warning, assemblyName + ".deps.json could not be found!");
			return;
		}
		packages = Enumerable.ToDictionary<DotNetCorePackageInfo, string>(LoadPackageInfos(text, targetFrameworkId), (Func<DotNetCorePackageInfo, string>)((DotNetCorePackageInfo i) => i.Name));
		string[] lookupPaths = LookupPaths;
		foreach (string path in lookupPaths)
		{
			foreach (KeyValuePair<string, DotNetCorePackageInfo> package in packages)
			{
				string[] runtimeComponents = package.Value.RuntimeComponents;
				foreach (string path2 in runtimeComponents)
				{
					string directoryName = Path.GetDirectoryName(path2);
					string text2 = Path.Combine(path, package.Value.Name, package.Value.Version, directoryName).ToLowerInvariant();
					if (Directory.Exists(text2))
					{
						packageBasePaths.Add(text2);
					}
				}
			}
		}
	}

	public string TryResolveDotNetCore(IAssemblyReference name)
	{
		foreach (string packageBasePath in packageBasePaths)
		{
			if (File.Exists(Path.Combine(packageBasePath, name.Name + ".dll")))
			{
				return Path.Combine(packageBasePath, name.Name + ".dll");
			}
			if (File.Exists(Path.Combine(packageBasePath, name.Name + ".exe")))
			{
				return Path.Combine(packageBasePath, name.Name + ".exe");
			}
		}
		return FallbackToDotNetSharedDirectory(name, version);
	}

	private static IEnumerable<DotNetCorePackageInfo> LoadPackageInfos(string depsJsonFileName, string targetFramework)
	{
		JsonValue dependencies = JsonReader.Parse(File.ReadAllText(depsJsonFileName));
		JsonObject runtimeInfos = dependencies["targets"][targetFramework + "/"].AsJsonObject;
		JsonObject libraries = dependencies["libraries"].AsJsonObject;
		if (runtimeInfos == null || libraries == null)
		{
			yield break;
		}
		foreach (KeyValuePair<string, JsonValue> library in libraries)
		{
			string type = library.Value["type"].AsString;
			string path = library.Value["path"].AsString;
			JsonObject runtimeInfo = runtimeInfos[library.Key].AsJsonObject?["runtime"].AsJsonObject;
			string[] components = new string[runtimeInfo?.Count ?? 0];
			if (runtimeInfo != null)
			{
				int i = 0;
				foreach (KeyValuePair<string, JsonValue> item in runtimeInfo)
				{
					components[i] = item.Key;
					i = checked(i + 1);
				}
			}
			yield return new DotNetCorePackageInfo(library.Key, type, path, components);
		}
	}

	private string FallbackToDotNetSharedDirectory(IAssemblyReference name, Version version)
	{
		if (dotnetBasePath == null)
		{
			return null;
		}
		string path = Path.Combine(dotnetBasePath, "shared", "Microsoft.NETCore.App");
		string closestVersionFolder = GetClosestVersionFolder(path, version);
		if (File.Exists(Path.Combine(path, closestVersionFolder, name.Name + ".dll")))
		{
			return Path.Combine(path, closestVersionFolder, name.Name + ".dll");
		}
		if (File.Exists(Path.Combine(path, closestVersionFolder, name.Name + ".exe")))
		{
			return Path.Combine(path, closestVersionFolder, name.Name + ".exe");
		}
		return null;
	}

	private static string GetClosestVersionFolder(string basePath, Version version)
	{
		string text = null;
		foreach (var item in (IEnumerable<(Version, string)>)Enumerable.OrderByDescending<(Version, string), Version>(Enumerable.Where<(Version, string)>(Enumerable.Select<DirectoryInfo, (Version, string)>((IEnumerable<DirectoryInfo>)new DirectoryInfo(basePath).GetDirectories(), (Func<DirectoryInfo, (Version, string)>)((DirectoryInfo d) => ConvertToVersion(d.Name))), (Func<(Version, string), bool>)(((Version, string) v) => v.Item1 != null)), (Func<(Version, string), Version>)(((Version, string) v) => v.Item1)))
		{
			if (item.Item1 >= version)
			{
				text = item.Item2;
			}
		}
		return text ?? version.ToString();
	}

	internal static (Version, string) ConvertToVersion(string name)
	{
		try
		{
			return (new Version(RemoveTrailingVersionInfo()), name);
		}
		catch (Exception ex)
		{
			Trace.TraceWarning(ex.ToString());
			return (null, null);
		}
		string RemoveTrailingVersionInfo()
		{
			string text = name;
			int num = text.IndexOf('-');
			if (num > 0)
			{
				text = text.Remove(num);
			}
			return text;
		}
	}

	private static string FindDotNetExeDirectory()
	{
		string path = ((Environment.OSVersion.Platform == PlatformID.Unix) ? "dotnet" : "dotnet.exe");
		string[] array = Environment.GetEnvironmentVariable("PATH").Split(new char[1] { Path.PathSeparator });
		foreach (string path2 in array)
		{
			try
			{
				string text = Path.Combine(path2, path);
				if (File.Exists(text))
				{
					if (Environment.OSVersion.Platform != PlatformID.Unix || (new FileInfo(text).Attributes & FileAttributes.ReparsePoint) != FileAttributes.ReparsePoint)
					{
						goto IL_00c4;
					}
					StringBuilder stringBuilder = new StringBuilder();
					realpath(text, stringBuilder);
					text = stringBuilder.ToString();
					if (File.Exists(text))
					{
						goto IL_00c4;
					}
				}
				goto end_IL_0046;
				IL_00c4:
				return Path.GetDirectoryName(text);
				end_IL_0046:;
			}
			catch (ArgumentException)
			{
			}
		}
		return null;
	}

	[DllImport("libc")]
	private static extern void realpath(string path, StringBuilder resolvedPath);
}
