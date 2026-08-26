using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Text;

namespace DecompTools.Decompiler.Metadata;

public class UniversalAssemblyResolver : IAssemblyResolver
{
	private enum TargetFrameworkIdentifier
	{
		NETFramework,
		NETCoreApp,
		NETStandard,
		Silverlight
	}

	private DotNetCorePathFinder dotNetCorePathFinder;

	private readonly bool throwOnError;

	private readonly PEStreamOptions streamOptions;

	private readonly MetadataReaderOptions metadataOptions;

	private readonly string mainAssemblyFileName;

	private readonly string baseDirectory;

	private readonly List<string> directories = new List<string>();

	private readonly List<string> gac_paths = GetGacPaths();

	private HashSet<string> targetFrameworkSearchPaths;

	private string targetFramework;

	private TargetFrameworkIdentifier targetFrameworkIdentifier;

	private Version targetFrameworkVersion;

	internal static Version ZeroVersion = new Version(0, 0, 0, 0);

	private static bool DetectMono()
	{
		if (Type.GetType("Mono.Runtime") != null)
		{
			return true;
		}
		if (Environment.OSVersion.Platform == PlatformID.Unix)
		{
			return true;
		}
		return false;
	}

	public void AddSearchDirectory(string directory)
	{
		directories.Add(directory);
	}

	public void RemoveSearchDirectory(string directory)
	{
		directories.Remove(directory);
	}

	public string[] GetSearchDirectories()
	{
		return directories.ToArray();
	}

	public UniversalAssemblyResolver(string mainAssemblyFileName, bool throwOnError, string targetFramework, PEStreamOptions streamOptions = PEStreamOptions.Default, MetadataReaderOptions metadataOptions = MetadataReaderOptions.Default)
	{
		this.streamOptions = streamOptions;
		this.metadataOptions = metadataOptions;
		this.targetFramework = targetFramework ?? string.Empty;
		(TargetFrameworkIdentifier, Version) tuple = ParseTargetFramework(this.targetFramework);
		targetFrameworkIdentifier = tuple.Item1;
		targetFrameworkVersion = tuple.Item2;
		this.mainAssemblyFileName = mainAssemblyFileName;
		baseDirectory = Path.GetDirectoryName(mainAssemblyFileName);
		this.throwOnError = throwOnError;
		if (string.IsNullOrWhiteSpace(baseDirectory))
		{
			baseDirectory = Environment.CurrentDirectory;
		}
		AddSearchDirectory(baseDirectory);
	}

	private (TargetFrameworkIdentifier, Version) ParseTargetFramework(string targetFramework)
	{
		string[] array = targetFramework.Split(new char[1] { ',' });
		TargetFrameworkIdentifier targetFrameworkIdentifier = array[0].Trim().ToUpperInvariant() switch
		{
			".NETCOREAPP" => TargetFrameworkIdentifier.NETCoreApp, 
			".NETSTANDARD" => TargetFrameworkIdentifier.NETStandard, 
			"SILVERLIGHT" => TargetFrameworkIdentifier.Silverlight, 
			_ => TargetFrameworkIdentifier.NETFramework, 
		};
		Version result = null;
		for (int i = 1; i < array.Length; i = checked(i + 1))
		{
			string[] array2 = array[i].Trim().Split(new char[1] { '=' });
			if (array2.Length != 2)
			{
				continue;
			}
			string text = array2[0].Trim().ToUpperInvariant();
			if (text == "VERSION")
			{
				string text2 = array2[1].TrimStart(new char[1] { 'v' });
				if ((targetFrameworkIdentifier == TargetFrameworkIdentifier.NETCoreApp || targetFrameworkIdentifier == TargetFrameworkIdentifier.NETStandard) && text2.Length == 3)
				{
					text2 += ".0";
				}
				if (!Version.TryParse(text2, out result))
				{
					result = null;
				}
			}
		}
		return (targetFrameworkIdentifier, result ?? ZeroVersion);
	}

	public PEFile Resolve(IAssemblyReference name)
	{
		string text = FindAssemblyFile(name);
		if (text == null)
		{
			if (throwOnError)
			{
				throw new AssemblyResolutionException(name);
			}
			return null;
		}
		return new PEFile(text, new FileStream(text, FileMode.Open, FileAccess.Read), streamOptions, metadataOptions);
	}

	public PEFile ResolveModule(PEFile mainModule, string moduleName)
	{
		string directoryName = Path.GetDirectoryName(mainModule.FileName);
		string text = Path.Combine(directoryName, moduleName);
		if (!File.Exists(text))
		{
			if (throwOnError)
			{
				throw new Exception("Module " + moduleName + " could not be found!");
			}
			return null;
		}
		return new PEFile(text, new FileStream(text, FileMode.Open, FileAccess.Read), streamOptions, metadataOptions);
	}

	public string FindAssemblyFile(IAssemblyReference name)
	{
		if (name.IsWindowsRuntime)
		{
			return FindWindowsMetadataFile(name);
		}
		string text = null;
		switch (targetFrameworkIdentifier)
		{
		case TargetFrameworkIdentifier.NETCoreApp:
		case TargetFrameworkIdentifier.NETStandard:
			if (!IsZeroOrAllOnes(targetFrameworkVersion))
			{
				if (dotNetCorePathFinder == null)
				{
					dotNetCorePathFinder = new DotNetCorePathFinder(mainAssemblyFileName, targetFramework, targetFrameworkVersion);
				}
				text = dotNetCorePathFinder.TryResolveDotNetCore(name);
				if (text != null)
				{
					return text;
				}
			}
			break;
		case TargetFrameworkIdentifier.Silverlight:
			if (!IsZeroOrAllOnes(targetFrameworkVersion))
			{
				text = ResolveSilverlight(name, targetFrameworkVersion);
				if (text != null)
				{
					return text;
				}
			}
			break;
		}
		return ResolveInternal(name);
	}

	private string FindWindowsMetadataFile(IAssemblyReference name)
	{
		if (Environment.OSVersion.Platform != PlatformID.Win32NT)
		{
			return null;
		}
		string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "Windows Kits", "10", "References");
		if (!Directory.Exists(path))
		{
			return FindWindowsMetadataInSystemDirectory(name);
		}
		DirectoryInfo directoryInfo = new DirectoryInfo(path);
		path = null;
		foreach (DirectoryInfo item in directoryInfo.EnumerateDirectories())
		{
			path = item.FullName;
		}
		if (path == null)
		{
			return FindWindowsMetadataInSystemDirectory(name);
		}
		path = Path.Combine(path, name.Name);
		if (!Directory.Exists(path))
		{
			return FindWindowsMetadataInSystemDirectory(name);
		}
		path = Path.Combine(path, FindClosestVersionDirectory(path, name.Version));
		if (!Directory.Exists(path))
		{
			return FindWindowsMetadataInSystemDirectory(name);
		}
		string text = Path.Combine(path, name.Name + ".winmd");
		if (!File.Exists(text))
		{
			return FindWindowsMetadataInSystemDirectory(name);
		}
		return text;
	}

	private string FindWindowsMetadataInSystemDirectory(IAssemblyReference name)
	{
		string text = Path.Combine(Environment.SystemDirectory, "WinMetadata", name.Name + ".winmd");
		if (File.Exists(text))
		{
			return text;
		}
		return null;
	}

	private void AddTargetFrameworkSearchPathIfExists(string path)
	{
		if (targetFrameworkSearchPaths == null)
		{
			targetFrameworkSearchPaths = new HashSet<string>();
		}
		if (Directory.Exists(path))
		{
			targetFrameworkSearchPaths.Add(path);
		}
	}

	private string ResolveSilverlight(IAssemblyReference name, Version version)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		AddTargetFrameworkSearchPathIfExists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "Microsoft Silverlight"));
		AddTargetFrameworkSearchPathIfExists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "Microsoft Silverlight"));
		Enumerator<string> enumerator = targetFrameworkSearchPaths.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				string current = enumerator.Current;
				string directory = Path.Combine(current, FindClosestVersionDirectory(current, version));
				string text = SearchDirectory(name, directory);
				if (text != null)
				{
					return text;
				}
			}
		}
		finally
		{
			((IDisposable)enumerator/*cast due to constrained. prefix*/).Dispose();
		}
		return null;
	}

	private string FindClosestVersionDirectory(string basePath, Version version)
	{
		string text = null;
		foreach (var item in (IEnumerable<(Version, string)>)Enumerable.OrderByDescending<(Version, string), Version>(Enumerable.Where<(Version, string)>(Enumerable.Select<DirectoryInfo, (Version, string)>((IEnumerable<DirectoryInfo>)new DirectoryInfo(basePath).GetDirectories(), (Func<DirectoryInfo, (Version, string)>)((DirectoryInfo d) => DotNetCorePathFinder.ConvertToVersion(d.Name))), (Func<(Version, string), bool>)(((Version, string) v) => v.Item1 != null)), (Func<(Version, string), Version>)(((Version, string) v) => v.Item1)))
		{
			if (text == null || item.Item1 >= version)
			{
				text = item.Item2;
			}
		}
		return text ?? version.ToString();
	}

	private string ResolveInternal(IAssemblyReference name)
	{
		if (name == null)
		{
			throw new ArgumentNullException("name");
		}
		string text = SearchDirectory(name, directories);
		if (text != null)
		{
			return text;
		}
		string directoryName = Path.GetDirectoryName(typeof(object).Module.FullyQualifiedName);
		string[] array = ((!DetectMono()) ? new string[1] { directoryName } : new string[2]
		{
			directoryName,
			Path.Combine(directoryName, "Facades")
		});
		if (IsSpecialVersionOrRetargetable(name))
		{
			text = SearchDirectory(name, array);
			if (text != null)
			{
				return text;
			}
		}
		if (name.Name == "mscorlib")
		{
			text = GetCorlib(name);
			if (text != null)
			{
				return text;
			}
		}
		text = GetAssemblyInGac(name);
		if (text != null)
		{
			return text;
		}
		text = SearchDirectory(name, array);
		if (text != null)
		{
			return text;
		}
		if (throwOnError)
		{
			throw new AssemblyResolutionException(name);
		}
		return null;
	}

	private string SearchDirectory(IAssemblyReference name, IEnumerable<string> directories)
	{
		foreach (string directory in directories)
		{
			string text = SearchDirectory(name, directory);
			if (text != null)
			{
				return text;
			}
		}
		return null;
	}

	private static bool IsSpecialVersionOrRetargetable(IAssemblyReference reference)
	{
		return IsZeroOrAllOnes(reference.Version) || reference.IsRetargetable;
	}

	private string SearchDirectory(IAssemblyReference name, string directory)
	{
		string[] array = ((!name.IsWindowsRuntime) ? new string[2] { ".exe", ".dll" } : new string[2] { ".winmd", ".dll" });
		string[] array2 = array;
		foreach (string text in array2)
		{
			string text2 = Path.Combine(directory, name.Name + text);
			if (File.Exists(text2))
			{
				try
				{
					return text2;
				}
				catch (BadImageFormatException)
				{
				}
			}
		}
		return null;
	}

	private static bool IsZeroOrAllOnes(Version version)
	{
		return version == null || (version.Major == 0 && version.Minor == 0 && version.Build == 0 && version.Revision == 0) || (version.Major == 65535 && version.Minor == 65535 && version.Build == 65535 && version.Revision == 65535);
	}

	private string GetCorlib(IAssemblyReference reference)
	{
		Version version = reference.Version;
		AssemblyName name = typeof(object).Assembly.GetName();
		if (name.Version == version || IsSpecialVersionOrRetargetable(reference))
		{
			return typeof(object).Module.FullyQualifiedName;
		}
		string text = ((!DetectMono()) ? GetMscorlibBasePath(version, reference.PublicKeyToken.ToHexString(8)) : GetMonoMscorlibBasePath(version));
		if (text == null)
		{
			return null;
		}
		string text2 = Path.Combine(text, "mscorlib.dll");
		if (File.Exists(text2))
		{
			return text2;
		}
		return null;
	}

	private string GetMscorlibBasePath(Version version, string publicKeyToken)
	{
		if (publicKeyToken == "969db8053d3322ac")
		{
			string path = (Environment.Is64BitOperatingSystem ? Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) : Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles));
			string path2 = $"Microsoft.NET\\SDK\\CompactFramework\\v{version.Major}.{version.Minor}\\WindowsCE\\";
			string text = Path.Combine(path, path2);
			if (Directory.Exists(text))
			{
				return text;
			}
		}
		else
		{
			string path3 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "Microsoft.NET");
			string[] array = new string[2]
			{
				Path.Combine(path3, "Framework"),
				Path.Combine(path3, "Framework64")
			};
			string text2 = GetSubFolderForVersion();
			if (text2 != null)
			{
				string[] array2 = array;
				foreach (string path4 in array2)
				{
					string text3 = Path.Combine(path4, text2);
					if (Directory.Exists(text3))
					{
						return text3;
					}
				}
			}
		}
		if (throwOnError)
		{
			throw new NotSupportedException("Version not supported: " + version);
		}
		return null;
		string GetSubFolderForVersion()
		{
			switch (version.Major)
			{
			case 1:
				if (version.MajorRevision == 3300)
				{
					return "v1.0.3705";
				}
				return "v1.1.4322";
			case 2:
				return "v2.0.50727";
			case 4:
				return "v4.0.30319";
			default:
				if (throwOnError)
				{
					throw new NotSupportedException("Version not supported: " + version);
				}
				return null;
			}
		}
	}

	private string GetMonoMscorlibBasePath(Version version)
	{
		string fullName = Directory.GetParent(typeof(object).Module.FullyQualifiedName).Parent.FullName;
		if (version.Major == 1)
		{
			fullName = Path.Combine(fullName, "1.0");
		}
		else if (version.Major == 2)
		{
			fullName = ((version.MajorRevision != 5) ? Path.Combine(fullName, "2.0") : Path.Combine(fullName, "2.1"));
		}
		else
		{
			if (version.Major != 4)
			{
				if (throwOnError)
				{
					throw new NotSupportedException("Version not supported: " + version);
				}
				return null;
			}
			fullName = Path.Combine(fullName, "4.0");
		}
		return fullName;
	}

	private static List<string> GetGacPaths()
	{
		if (DetectMono())
		{
			return GetDefaultMonoGacPaths();
		}
		List<string> list = new List<string>(2);
		string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
		if (folderPath == null)
		{
			return list;
		}
		list.Add(Path.Combine(folderPath, "assembly"));
		list.Add(Path.Combine(folderPath, "Microsoft.NET", "assembly"));
		return list;
	}

	private static List<string> GetDefaultMonoGacPaths()
	{
		List<string> list = new List<string>(1);
		string currentMonoGac = GetCurrentMonoGac();
		if (currentMonoGac != null)
		{
			list.Add(currentMonoGac);
		}
		string environmentVariable = Environment.GetEnvironmentVariable("MONO_GAC_PREFIX");
		if (string.IsNullOrEmpty(environmentVariable))
		{
			return list;
		}
		string[] array = environmentVariable.Split(new char[1] { Path.PathSeparator });
		string[] array2 = array;
		foreach (string text in array2)
		{
			if (!string.IsNullOrEmpty(text))
			{
				string text2 = Path.Combine(Path.Combine(Path.Combine(text, "lib"), "mono"), "gac");
				if (Directory.Exists(text2) && !list.Contains(currentMonoGac))
				{
					list.Add(text2);
				}
			}
		}
		return list;
	}

	private static string GetCurrentMonoGac()
	{
		return Path.Combine(Directory.GetParent(Path.GetDirectoryName(typeof(object).Module.FullyQualifiedName)).FullName, "gac");
	}

	private string GetAssemblyInGac(IAssemblyReference reference)
	{
		if (reference.PublicKeyToken == null || reference.PublicKeyToken.Length == 0)
		{
			return null;
		}
		if (DetectMono())
		{
			return GetAssemblyInMonoGac(reference);
		}
		return GetAssemblyInNetGac(reference);
	}

	private string GetAssemblyInMonoGac(IAssemblyReference reference)
	{
		for (int i = 0; i < gac_paths.Count; i = checked(i + 1))
		{
			string gac = gac_paths[i];
			string assemblyFile = GetAssemblyFile(reference, string.Empty, gac);
			if (File.Exists(assemblyFile))
			{
				return assemblyFile;
			}
		}
		return null;
	}

	private string GetAssemblyInNetGac(IAssemblyReference reference)
	{
		string[] array = new string[4] { "GAC_MSIL", "GAC_32", "GAC_64", "GAC" };
		string[] array2 = new string[2]
		{
			string.Empty,
			"v4.0_"
		};
		checked
		{
			for (int i = 0; i < gac_paths.Count; i++)
			{
				for (int j = 0; j < array.Length; j++)
				{
					string text = Path.Combine(gac_paths[i], array[j]);
					string assemblyFile = GetAssemblyFile(reference, array2[i], text);
					if (Directory.Exists(text) && File.Exists(assemblyFile))
					{
						return assemblyFile;
					}
				}
			}
			return null;
		}
	}

	private static string GetAssemblyFile(IAssemblyReference reference, string prefix, string gac)
	{
		StringBuilder stringBuilder = new StringBuilder().Append(prefix).Append(reference.Version).Append("__");
		for (int i = 0; i < reference.PublicKeyToken.Length; i = checked(i + 1))
		{
			stringBuilder.Append(reference.PublicKeyToken[i].ToString("x2"));
		}
		return Path.Combine(Path.Combine(Path.Combine(gac, reference.Name), stringBuilder.ToString()), reference.Name + ".dll");
	}
}
