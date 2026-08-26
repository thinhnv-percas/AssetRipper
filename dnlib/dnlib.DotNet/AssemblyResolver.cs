using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using dnlib.Threading;

namespace dnlib.DotNet;

public class AssemblyResolver : IAssemblyResolver
{
	private sealed class GacInfo
	{
		public readonly int Version;

		public readonly string Path;

		public readonly string Prefix;

		public readonly IList<string> SubDirs;

		public GacInfo(int version, string prefix, string path, IList<string> subDirs)
		{
			Version = version;
			Prefix = prefix;
			Path = path;
			SubDirs = subDirs;
		}
	}

	private static readonly ModuleDef nullModule;

	private static readonly string[] assemblyExtensions;

	private static readonly string[] winMDAssemblyExtensions;

	private static readonly List<GacInfo> gacInfos;

	private static readonly string[] extraMonoPaths;

	private static readonly string[] monoVerDirs;

	private ModuleContext defaultModuleContext;

	private readonly Dictionary<ModuleDef, IList<string>> moduleSearchPaths = new Dictionary<ModuleDef, IList<string>>();

	private readonly Dictionary<string, AssemblyDef> cachedAssemblies = new Dictionary<string, AssemblyDef>(StringComparer.Ordinal);

	private readonly IList<string> preSearchPaths = new List<string>();

	private readonly IList<string> postSearchPaths = new List<string>();

	private bool findExactMatch;

	private bool enableFrameworkRedirect;

	private bool enableTypeDefCache = true;

	private bool useGac = true;

	private readonly Lock theLock = Lock.Create();

	public ModuleContext DefaultModuleContext
	{
		get
		{
			return defaultModuleContext;
		}
		set
		{
			defaultModuleContext = value;
		}
	}

	public bool FindExactMatch
	{
		get
		{
			return findExactMatch;
		}
		set
		{
			findExactMatch = value;
		}
	}

	public bool EnableFrameworkRedirect
	{
		get
		{
			return enableFrameworkRedirect;
		}
		set
		{
			enableFrameworkRedirect = value;
		}
	}

	public bool EnableTypeDefCache
	{
		get
		{
			return enableTypeDefCache;
		}
		set
		{
			enableTypeDefCache = value;
		}
	}

	public bool UseGAC
	{
		get
		{
			return useGac;
		}
		set
		{
			useGac = value;
		}
	}

	public IList<string> PreSearchPaths => preSearchPaths;

	public IList<string> PostSearchPaths => postSearchPaths;

	static AssemblyResolver()
	{
		nullModule = new ModuleDefUser();
		assemblyExtensions = new string[2] { ".dll", ".exe" };
		winMDAssemblyExtensions = new string[1] { ".winmd" };
		monoVerDirs = new string[14]
		{
			"4.5", "4.5\\Facades", "4.5-api", "4.5-api\\Facades", "4.0", "4.0-api", "3.5", "3.5-api", "3.0", "3.0-api",
			"2.0", "2.0-api", "1.1", "1.0"
		};
		gacInfos = new List<GacInfo>();
		if (Type.GetType("Mono.Runtime") != null)
		{
			Dictionary<string, bool> dictionary = new Dictionary<string, bool>(StringComparer.OrdinalIgnoreCase);
			List<string> list = new List<string>();
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
					gacInfos.Add(new GacInfo(-1, "", Path.GetDirectoryName(text), new string[1] { Path.GetFileName(text) }));
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
						list.Add(text3);
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
						list.Add(text5);
					}
				}
			}
			extraMonoPaths = list.ToArray();
			return;
		}
		string environmentVariable2 = Environment.GetEnvironmentVariable("WINDIR");
		if (!string.IsNullOrEmpty(environmentVariable2))
		{
			string path2 = Path.Combine(environmentVariable2, "assembly");
			if (Directory.Exists(path2))
			{
				gacInfos.Add(new GacInfo(2, "", path2, new string[4] { "GAC_32", "GAC_64", "GAC_MSIL", "GAC" }));
			}
			path2 = Path.Combine(Path.Combine(environmentVariable2, "Microsoft.NET"), "assembly");
			if (Directory.Exists(path2))
			{
				gacInfos.Add(new GacInfo(4, "v4.0_", path2, new string[3] { "GAC_32", "GAC_64", "GAC_MSIL" }));
			}
		}
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

	public AssemblyResolver()
		: this(null, addOtherSearchPaths: true)
	{
	}

	public AssemblyResolver(ModuleContext defaultModuleContext)
		: this(defaultModuleContext, addOtherSearchPaths: true)
	{
	}

	public AssemblyResolver(ModuleContext defaultModuleContext, bool addOtherSearchPaths)
	{
		this.defaultModuleContext = defaultModuleContext;
		enableFrameworkRedirect = true;
		if (addOtherSearchPaths)
		{
			AddOtherSearchPaths(postSearchPaths);
		}
	}

	public AssemblyDef Resolve(IAssembly assembly, ModuleDef sourceModule)
	{
		if (assembly == null)
		{
			return null;
		}
		if (EnableFrameworkRedirect && !FindExactMatch)
		{
			FrameworkRedirect.ApplyFrameworkRedirect(ref assembly, sourceModule);
		}
		theLock.EnterWriteLock();
		try
		{
			AssemblyDef assemblyDef = Resolve2(assembly, sourceModule);
			if (assemblyDef == null)
			{
				string text = UTF8String.ToSystemStringOrEmpty(assembly.Name);
				string text2 = text.Trim();
				if (text != text2)
				{
					assembly = new AssemblyNameInfo
					{
						Name = text2,
						Version = assembly.Version,
						PublicKeyOrToken = assembly.PublicKeyOrToken,
						Culture = assembly.Culture
					};
					assemblyDef = Resolve2(assembly, sourceModule);
				}
			}
			if (assemblyDef == null)
			{
				cachedAssemblies[GetAssemblyNameKey(assembly)] = null;
				return null;
			}
			string assemblyNameKey = GetAssemblyNameKey(assemblyDef);
			string assemblyNameKey2 = GetAssemblyNameKey(assembly);
			cachedAssemblies.TryGetValue(assemblyNameKey, out var value);
			cachedAssemblies.TryGetValue(assemblyNameKey2, out var value2);
			if (value != assemblyDef && value2 != assemblyDef && enableTypeDefCache)
			{
				IList<ModuleDef> modules = assemblyDef.Modules;
				int count = modules.Count;
				for (int i = 0; i < count; i++)
				{
					ModuleDef moduleDef = modules[i];
					if (moduleDef != null)
					{
						moduleDef.EnableTypeDefFindCache = true;
					}
				}
			}
			bool flag = false;
			if (!cachedAssemblies.ContainsKey(assemblyNameKey))
			{
				cachedAssemblies.Add(assemblyNameKey, assemblyDef);
				flag = true;
			}
			if (!cachedAssemblies.ContainsKey(assemblyNameKey2))
			{
				cachedAssemblies.Add(assemblyNameKey2, assemblyDef);
				flag = true;
			}
			if (flag || value == assemblyDef || value2 == assemblyDef)
			{
				return assemblyDef;
			}
			assemblyDef.ManifestModule?.Dispose();
			return value ?? value2;
		}
		finally
		{
			theLock.ExitWriteLock();
		}
	}

	public bool AddToCache(ModuleDef module)
	{
		return module != null && AddToCache(module.Assembly);
	}

	public bool AddToCache(AssemblyDef asm)
	{
		if (asm == null)
		{
			return false;
		}
		string assemblyNameKey = GetAssemblyNameKey(asm);
		theLock.EnterWriteLock();
		try
		{
			if (cachedAssemblies.TryGetValue(assemblyNameKey, out var value) && value != null)
			{
				return asm == value;
			}
			cachedAssemblies[assemblyNameKey] = asm;
			return true;
		}
		finally
		{
			theLock.ExitWriteLock();
		}
	}

	public bool Remove(ModuleDef module)
	{
		return module != null && Remove(module.Assembly);
	}

	public bool Remove(AssemblyDef asm)
	{
		if (asm == null)
		{
			return false;
		}
		string assemblyNameKey = GetAssemblyNameKey(asm);
		theLock.EnterWriteLock();
		try
		{
			return cachedAssemblies.Remove(assemblyNameKey);
		}
		finally
		{
			theLock.ExitWriteLock();
		}
	}

	public void Clear()
	{
		theLock.EnterWriteLock();
		List<AssemblyDef> list;
		try
		{
			list = new List<AssemblyDef>(cachedAssemblies.Values);
			cachedAssemblies.Clear();
		}
		finally
		{
			theLock.ExitWriteLock();
		}
		foreach (AssemblyDef item in list)
		{
			if (item == null)
			{
				continue;
			}
			foreach (ModuleDef module in item.Modules)
			{
				module.Dispose();
			}
		}
	}

	private static string GetAssemblyNameKey(IAssembly asmName)
	{
		return asmName.FullNameToken.ToUpperInvariant();
	}

	private AssemblyDef Resolve2(IAssembly assembly, ModuleDef sourceModule)
	{
		if (cachedAssemblies.TryGetValue(GetAssemblyNameKey(assembly), out var value))
		{
			return value;
		}
		ModuleContext context = defaultModuleContext;
		if (context == null && sourceModule != null)
		{
			context = sourceModule.Context;
		}
		value = FindExactAssembly(assembly, PreFindAssemblies(assembly, sourceModule, matchExactly: true), context) ?? FindExactAssembly(assembly, FindAssemblies(assembly, sourceModule, matchExactly: true), context) ?? FindExactAssembly(assembly, PostFindAssemblies(assembly, sourceModule, matchExactly: true), context);
		if (value != null)
		{
			return value;
		}
		if (!findExactMatch)
		{
			value = FindClosestAssembly(assembly);
			value = FindClosestAssembly(assembly, value, PreFindAssemblies(assembly, sourceModule, matchExactly: false), context);
			value = FindClosestAssembly(assembly, value, FindAssemblies(assembly, sourceModule, matchExactly: false), context);
			value = FindClosestAssembly(assembly, value, PostFindAssemblies(assembly, sourceModule, matchExactly: false), context);
		}
		return value;
	}

	private AssemblyDef FindExactAssembly(IAssembly assembly, IEnumerable<string> paths, ModuleContext moduleContext)
	{
		if (paths == null)
		{
			return null;
		}
		AssemblyNameComparer compareAll = AssemblyNameComparer.CompareAll;
		foreach (string path in paths)
		{
			ModuleDefMD moduleDefMD = null;
			try
			{
				moduleDefMD = ModuleDefMD.Load(path, moduleContext);
				AssemblyDef assembly2 = moduleDefMD.Assembly;
				if (assembly2 != null && compareAll.Equals(assembly, assembly2))
				{
					moduleDefMD = null;
					return assembly2;
				}
			}
			catch
			{
			}
			finally
			{
				moduleDefMD?.Dispose();
			}
		}
		return null;
	}

	private AssemblyDef FindClosestAssembly(IAssembly assembly)
	{
		AssemblyDef assemblyDef = null;
		AssemblyNameComparer compareAll = AssemblyNameComparer.CompareAll;
		foreach (KeyValuePair<string, AssemblyDef> cachedAssembly in cachedAssemblies)
		{
			AssemblyDef value = cachedAssembly.Value;
			if (value != null && compareAll.CompareClosest(assembly, assemblyDef, value) == 1)
			{
				assemblyDef = value;
			}
		}
		return assemblyDef;
	}

	private AssemblyDef FindClosestAssembly(IAssembly assembly, AssemblyDef closest, IEnumerable<string> paths, ModuleContext moduleContext)
	{
		if (paths == null)
		{
			return closest;
		}
		AssemblyNameComparer compareAll = AssemblyNameComparer.CompareAll;
		foreach (string path in paths)
		{
			ModuleDefMD moduleDefMD = null;
			try
			{
				moduleDefMD = ModuleDefMD.Load(path, moduleContext);
				AssemblyDef assembly2 = moduleDefMD.Assembly;
				if (assembly2 != null && compareAll.CompareClosest(assembly, closest, assembly2) == 1)
				{
					if (!IsCached(closest))
					{
						closest?.ManifestModule?.Dispose();
					}
					closest = assembly2;
					moduleDefMD = null;
				}
			}
			catch
			{
			}
			finally
			{
				moduleDefMD?.Dispose();
			}
		}
		return closest;
	}

	private bool IsCached(AssemblyDef asm)
	{
		if (asm == null)
		{
			return false;
		}
		AssemblyDef value;
		return cachedAssemblies.TryGetValue(GetAssemblyNameKey(asm), out value) && value == asm;
	}

	private IEnumerable<string> FindAssemblies2(IAssembly assembly, IEnumerable<string> paths)
	{
		if (paths == null)
		{
			yield break;
		}
		string asmSimpleName = UTF8String.ToSystemStringOrEmpty(assembly.Name);
		string[] exts = (assembly.IsContentTypeWindowsRuntime ? winMDAssemblyExtensions : assemblyExtensions);
		string[] array = exts;
		foreach (string ext in array)
		{
			foreach (string path in paths)
			{
				string fullPath = Path.Combine(path, asmSimpleName + ext);
				if (File.Exists(fullPath))
				{
					yield return fullPath;
				}
			}
		}
	}

	protected virtual IEnumerable<string> PreFindAssemblies(IAssembly assembly, ModuleDef sourceModule, bool matchExactly)
	{
		foreach (string item in FindAssemblies2(assembly, preSearchPaths))
		{
			yield return item;
		}
	}

	protected virtual IEnumerable<string> PostFindAssemblies(IAssembly assembly, ModuleDef sourceModule, bool matchExactly)
	{
		foreach (string item in FindAssemblies2(assembly, postSearchPaths))
		{
			yield return item;
		}
	}

	protected virtual IEnumerable<string> FindAssemblies(IAssembly assembly, ModuleDef sourceModule, bool matchExactly)
	{
		if (assembly.IsContentTypeWindowsRuntime)
		{
			string path = Path.Combine(Path.Combine(Environment.SystemDirectory, "WinMetadata"), string.Concat(assembly.Name, ".winmd"));
			if (File.Exists(path))
			{
				yield return path;
			}
		}
		else if (UseGAC)
		{
			foreach (string item in FindAssembliesGac(assembly, sourceModule, matchExactly))
			{
				yield return item;
			}
		}
		foreach (string item2 in FindAssembliesModuleSearchPaths(assembly, sourceModule, matchExactly))
		{
			yield return item2;
		}
	}

	private IEnumerable<string> FindAssembliesGac(IAssembly assembly, ModuleDef sourceModule, bool matchExactly)
	{
		if (matchExactly)
		{
			return FindAssembliesGacExactly(assembly, sourceModule);
		}
		return FindAssembliesGacAny(assembly, sourceModule);
	}

	private IEnumerable<GacInfo> GetGacInfos(ModuleDef sourceModule)
	{
		int version = ((sourceModule == null) ? int.MinValue : (sourceModule.IsClr40 ? 4 : 2));
		foreach (GacInfo gacInfo in gacInfos)
		{
			if (gacInfo.Version == version)
			{
				yield return gacInfo;
			}
		}
		foreach (GacInfo gacInfo2 in gacInfos)
		{
			if (gacInfo2.Version != version)
			{
				yield return gacInfo2;
			}
		}
	}

	private IEnumerable<string> FindAssembliesGacExactly(IAssembly assembly, ModuleDef sourceModule)
	{
		foreach (GacInfo gacInfo in GetGacInfos(sourceModule))
		{
			foreach (string item in FindAssembliesGacExactly(gacInfo, assembly, sourceModule))
			{
				yield return item;
			}
		}
		if (extraMonoPaths == null)
		{
			yield break;
		}
		foreach (string extraMonoPath in GetExtraMonoPaths(assembly, sourceModule))
		{
			yield return extraMonoPath;
		}
	}

	private static IEnumerable<string> GetExtraMonoPaths(IAssembly assembly, ModuleDef sourceModule)
	{
		if (extraMonoPaths == null)
		{
			yield break;
		}
		string[] array = extraMonoPaths;
		foreach (string dir in array)
		{
			string file = Path.Combine(dir, string.Concat(assembly.Name, ".dll"));
			if (File.Exists(file))
			{
				yield return file;
			}
		}
	}

	private IEnumerable<string> FindAssembliesGacExactly(GacInfo gacInfo, IAssembly assembly, ModuleDef sourceModule)
	{
		PublicKeyToken pkt = PublicKeyBase.ToPublicKeyToken(assembly.PublicKeyOrToken);
		if (gacInfo == null || pkt == null)
		{
			yield break;
		}
		string pktString = pkt.ToString();
		string verString = Utils.CreateVersionWithNoUndefinedValues(assembly.Version).ToString();
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
			baseDir = Path.Combine(baseDir, asmSimpleName);
			baseDir = Path.Combine(baseDir, $"{gacInfo.Prefix}{verString}_{cultureString}_{pktString}");
			string pathName = Path.Combine(baseDir, asmSimpleName + ".dll");
			if (File.Exists(pathName))
			{
				yield return pathName;
			}
		}
	}

	private IEnumerable<string> FindAssembliesGacAny(IAssembly assembly, ModuleDef sourceModule)
	{
		foreach (GacInfo gacInfo in GetGacInfos(sourceModule))
		{
			foreach (string item in FindAssembliesGacAny(gacInfo, assembly, sourceModule))
			{
				yield return item;
			}
		}
		if (extraMonoPaths == null)
		{
			yield break;
		}
		foreach (string extraMonoPath in GetExtraMonoPaths(assembly, sourceModule))
		{
			yield return extraMonoPath;
		}
	}

	private IEnumerable<string> FindAssembliesGacAny(GacInfo gacInfo, IAssembly assembly, ModuleDef sourceModule)
	{
		if (gacInfo == null)
		{
			yield break;
		}
		string asmSimpleName = UTF8String.ToSystemStringOrEmpty(assembly.Name);
		using IEnumerator<string> enumerator = gacInfo.SubDirs.GetEnumerator();
		while (enumerator.MoveNext())
		{
			string baseDir = Path.Combine(path2: enumerator.Current, path1: gacInfo.Path);
			baseDir = Path.Combine(baseDir, asmSimpleName);
			foreach (string dir in GetDirs(baseDir))
			{
				string pathName = Path.Combine(dir, asmSimpleName + ".dll");
				if (File.Exists(pathName))
				{
					yield return pathName;
				}
			}
		}
	}

	private IEnumerable<string> GetDirs(string baseDir)
	{
		if (!Directory.Exists(baseDir))
		{
			return Array2.Empty<string>();
		}
		List<string> list = new List<string>();
		try
		{
			DirectoryInfo[] directories = new DirectoryInfo(baseDir).GetDirectories();
			foreach (DirectoryInfo directoryInfo in directories)
			{
				list.Add(directoryInfo.FullName);
			}
		}
		catch
		{
		}
		return list;
	}

	private IEnumerable<string> FindAssembliesModuleSearchPaths(IAssembly assembly, ModuleDef sourceModule, bool matchExactly)
	{
		string asmSimpleName = UTF8String.ToSystemStringOrEmpty(assembly.Name);
		IEnumerable<string> searchPaths = GetSearchPaths(sourceModule);
		string[] exts = (assembly.IsContentTypeWindowsRuntime ? winMDAssemblyExtensions : assemblyExtensions);
		string[] array = exts;
		foreach (string ext in array)
		{
			foreach (string path in searchPaths)
			{
				for (int j = 0; j < 2; j++)
				{
					string path2 = ((j != 0) ? Path.Combine(Path.Combine(path, asmSimpleName), asmSimpleName + ext) : Path.Combine(path, asmSimpleName + ext));
					if (File.Exists(path2))
					{
						yield return path2;
					}
				}
			}
		}
	}

	private IEnumerable<string> GetSearchPaths(ModuleDef module)
	{
		ModuleDef moduleDef = module;
		if (moduleDef == null)
		{
			moduleDef = nullModule;
		}
		if (moduleSearchPaths.TryGetValue(moduleDef, out var value))
		{
			return value;
		}
		return moduleSearchPaths[moduleDef] = new List<string>(GetModuleSearchPaths(module));
	}

	protected virtual IEnumerable<string> GetModuleSearchPaths(ModuleDef module)
	{
		return GetModulePrivateSearchPaths(module);
	}

	protected IEnumerable<string> GetModulePrivateSearchPaths(ModuleDef module)
	{
		if (module == null)
		{
			return Array2.Empty<string>();
		}
		AssemblyDef assembly = module.Assembly;
		if (assembly == null)
		{
			return Array2.Empty<string>();
		}
		module = assembly.ManifestModule;
		if (module == null)
		{
			return Array2.Empty<string>();
		}
		string text = null;
		try
		{
			string location = module.Location;
			if (location != string.Empty)
			{
				text = Directory.GetParent(location).FullName;
				string text2 = location + ".config";
				if (File.Exists(text2))
				{
					return GetPrivatePaths(text, text2);
				}
			}
		}
		catch
		{
		}
		if (text != null)
		{
			return new List<string> { text };
		}
		return Array2.Empty<string>();
	}

	private IEnumerable<string> GetPrivatePaths(string baseDir, string configFileName)
	{
		List<string> list = new List<string>();
		try
		{
			string directoryName = Path.GetDirectoryName(Path.GetFullPath(configFileName));
			list.Add(directoryName);
			using FileStream input = new FileStream(configFileName, FileMode.Open, FileAccess.Read, FileShare.Read);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(XmlReader.Create(input));
			foreach (object item in xmlDocument.GetElementsByTagName("probing"))
			{
				if (!(item is XmlElement xmlElement))
				{
					continue;
				}
				string attribute = xmlElement.GetAttribute("privatePath");
				if (string.IsNullOrEmpty(attribute))
				{
					continue;
				}
				string[] array = attribute.Split(';');
				foreach (string text in array)
				{
					string text2 = text.Trim();
					if (!(text2 == ""))
					{
						string fullPath = Path.GetFullPath(Path.Combine(directoryName, text2.Replace('\\', Path.DirectorySeparatorChar)));
						if (Directory.Exists(fullPath) && fullPath.StartsWith(baseDir + Path.DirectorySeparatorChar))
						{
							list.Add(fullPath);
						}
					}
				}
			}
		}
		catch (ArgumentException)
		{
		}
		catch (IOException)
		{
		}
		catch (XmlException)
		{
		}
		return list;
	}

	protected static void AddOtherSearchPaths(IList<string> paths)
	{
		string environmentVariable = Environment.GetEnvironmentVariable("ProgramFiles");
		AddOtherAssemblySearchPaths(paths, environmentVariable);
		string environmentVariable2 = Environment.GetEnvironmentVariable("ProgramFiles(x86)");
		if (!StringComparer.OrdinalIgnoreCase.Equals(environmentVariable, environmentVariable2))
		{
			AddOtherAssemblySearchPaths(paths, environmentVariable2);
		}
		string environmentVariable3 = Environment.GetEnvironmentVariable("WINDIR");
		if (!string.IsNullOrEmpty(environmentVariable3))
		{
			AddIfExists(paths, environmentVariable3, "Microsoft.NET\\Framework\\v1.1.4322");
			AddIfExists(paths, environmentVariable3, "Microsoft.NET\\Framework\\v1.0.3705");
		}
	}

	private static void AddOtherAssemblySearchPaths(IList<string> paths, string path)
	{
		if (!string.IsNullOrEmpty(path))
		{
			AddSilverlightDirs(paths, Path.Combine(path, "Microsoft Silverlight"));
			AddIfExists(paths, path, "Microsoft SDKs\\Silverlight\\v2.0\\Libraries\\Client");
			AddIfExists(paths, path, "Microsoft SDKs\\Silverlight\\v2.0\\Libraries\\Server");
			AddIfExists(paths, path, "Microsoft SDKs\\Silverlight\\v2.0\\Reference Assemblies");
			AddIfExists(paths, path, "Microsoft SDKs\\Silverlight\\v3.0\\Libraries\\Client");
			AddIfExists(paths, path, "Microsoft SDKs\\Silverlight\\v3.0\\Libraries\\Server");
			AddIfExists(paths, path, "Microsoft SDKs\\Silverlight\\v4.0\\Libraries\\Client");
			AddIfExists(paths, path, "Microsoft SDKs\\Silverlight\\v4.0\\Libraries\\Server");
			AddIfExists(paths, path, "Microsoft SDKs\\Silverlight\\v5.0\\Libraries\\Client");
			AddIfExists(paths, path, "Microsoft SDKs\\Silverlight\\v5.0\\Libraries\\Server");
			AddIfExists(paths, path, "Microsoft.NET\\SDK\\CompactFramework\\v2.0\\WindowsCE");
			AddIfExists(paths, path, "Microsoft.NET\\SDK\\CompactFramework\\v3.5\\WindowsCE");
			AddIfExists(paths, path, "Reference Assemblies\\Microsoft\\Framework\\.NETFramework\\v4.6.1");
			AddIfExists(paths, path, "Reference Assemblies\\Microsoft\\Framework\\.NETFramework\\v4.6");
			AddIfExists(paths, path, "Reference Assemblies\\Microsoft\\Framework\\.NETFramework\\v4.5.2");
			AddIfExists(paths, path, "Reference Assemblies\\Microsoft\\Framework\\.NETFramework\\v4.5.1");
			AddIfExists(paths, path, "Reference Assemblies\\Microsoft\\Framework\\.NETFramework\\v4.5");
			AddIfExists(paths, path, "Reference Assemblies\\Microsoft\\Framework\\.NETFramework\\v4.0");
			AddIfExists(paths, path, "Reference Assemblies\\Microsoft\\Framework\\.NETFramework\\v4.0\\Profile\\Client");
			AddIfExists(paths, path, "Reference Assemblies\\Microsoft\\Framework\\.NETFramework\\v3.5\\Profile\\Client");
			AddIfExists(paths, path, "Reference Assemblies\\Microsoft\\Framework\\.NETCore\\v5.0");
			AddIfExists(paths, path, "Reference Assemblies\\Microsoft\\Framework\\.NETCore\\v4.5.1");
			AddIfExists(paths, path, "Reference Assemblies\\Microsoft\\Framework\\.NETCore\\v4.5");
			AddIfExists(paths, path, "Reference Assemblies\\Microsoft\\Framework\\.NETMicroFramework\\v3.0");
			AddIfExists(paths, path, "Reference Assemblies\\Microsoft\\Framework\\.NETMicroFramework\\v4.0");
			AddIfExists(paths, path, "Reference Assemblies\\Microsoft\\Framework\\.NETMicroFramework\\v4.1");
			AddIfExists(paths, path, "Reference Assemblies\\Microsoft\\Framework\\.NETMicroFramework\\v4.2");
			AddIfExists(paths, path, "Reference Assemblies\\Microsoft\\Framework\\.NETMicroFramework\\v4.3");
			AddIfExists(paths, path, "Reference Assemblies\\Microsoft\\Framework\\.NETPortable\\v4.0");
			AddIfExists(paths, path, "Reference Assemblies\\Microsoft\\Framework\\.NETPortable\\v4.5");
			AddIfExists(paths, path, "Reference Assemblies\\Microsoft\\Framework\\.NETPortable\\v4.6");
			AddIfExists(paths, path, "Reference Assemblies\\Microsoft\\Framework\\.NETPortable\\v5.0");
			AddIfExists(paths, path, "Reference Assemblies\\Microsoft\\Framework\\v3.0");
			AddIfExists(paths, path, "Reference Assemblies\\Microsoft\\Framework\\v3.5");
			AddIfExists(paths, path, "Reference Assemblies\\Microsoft\\Framework\\Silverlight\\v3.0");
			AddIfExists(paths, path, "Reference Assemblies\\Microsoft\\Framework\\Silverlight\\v4.0");
			AddIfExists(paths, path, "Reference Assemblies\\Microsoft\\Framework\\Silverlight\\v5.0");
			AddIfExists(paths, path, "Reference Assemblies\\Microsoft\\Framework\\WindowsPhone\\v8.1");
			AddIfExists(paths, path, "Reference Assemblies\\Microsoft\\Framework\\WindowsPhoneApp\\v8.1");
			AddIfExists(paths, path, "Reference Assemblies\\Microsoft\\FSharp\\.NETCore\\3.259.4.0");
			AddIfExists(paths, path, "Reference Assemblies\\Microsoft\\FSharp\\.NETCore\\3.259.3.1");
			AddIfExists(paths, path, "Reference Assemblies\\Microsoft\\FSharp\\.NETCore\\3.78.4.0");
			AddIfExists(paths, path, "Reference Assemblies\\Microsoft\\FSharp\\.NETCore\\3.78.3.1");
			AddIfExists(paths, path, "Reference Assemblies\\Microsoft\\FSharp\\.NETCore\\3.7.4.0");
			AddIfExists(paths, path, "Reference Assemblies\\Microsoft\\FSharp\\.NETCore\\3.3.1.0");
			AddIfExists(paths, path, "Reference Assemblies\\Microsoft\\FSharp\\.NETFramework\\v2.0\\2.3.0.0");
			AddIfExists(paths, path, "Reference Assemblies\\Microsoft\\FSharp\\.NETFramework\\v4.0\\4.3.0.0");
			AddIfExists(paths, path, "Reference Assemblies\\Microsoft\\FSharp\\.NETFramework\\v4.0\\4.3.1.0");
			AddIfExists(paths, path, "Reference Assemblies\\Microsoft\\FSharp\\.NETFramework\\v4.0\\4.4.0.0");
			AddIfExists(paths, path, "Reference Assemblies\\Microsoft\\FSharp\\.NETPortable\\2.3.5.0");
			AddIfExists(paths, path, "Reference Assemblies\\Microsoft\\FSharp\\.NETPortable\\2.3.5.1");
			AddIfExists(paths, path, "Reference Assemblies\\Microsoft\\FSharp\\.NETPortable\\3.47.4.0");
			AddIfExists(paths, path, "Reference Assemblies\\Microsoft\\FSharp\\2.0\\Runtime\\v2.0");
			AddIfExists(paths, path, "Reference Assemblies\\Microsoft\\FSharp\\2.0\\Runtime\\v4.0");
			AddIfExists(paths, path, "Reference Assemblies\\Microsoft\\FSharp\\3.0\\Runtime\\.NETPortable");
			AddIfExists(paths, path, "Reference Assemblies\\Microsoft\\FSharp\\3.0\\Runtime\\v2.0");
			AddIfExists(paths, path, "Reference Assemblies\\Microsoft\\FSharp\\3.0\\Runtime\\v4.0");
			AddIfExists(paths, path, "Reference Assemblies\\Microsoft\\WindowsPowerShell\\v1.0");
			AddIfExists(paths, path, "Reference Assemblies\\Microsoft\\WindowsPowerShell\\3.0");
			AddIfExists(paths, path, "Microsoft Visual Studio .NET\\Common7\\IDE\\PublicAssemblies");
			AddIfExists(paths, path, "Microsoft Visual Studio .NET\\Common7\\IDE\\PrivateAssemblies");
			AddIfExists(paths, path, "Microsoft Visual Studio .NET 2003\\Common7\\IDE\\PublicAssemblies");
			AddIfExists(paths, path, "Microsoft Visual Studio .NET 2003\\Common7\\IDE\\PrivateAssemblies");
			AddIfExists(paths, path, "Microsoft Visual Studio 8\\Common7\\IDE\\PublicAssemblies");
			AddIfExists(paths, path, "Microsoft Visual Studio 8\\Common7\\IDE\\PrivateAssemblies");
			AddIfExists(paths, path, "Microsoft Visual Studio 9.0\\Common7\\IDE\\PublicAssemblies");
			AddIfExists(paths, path, "Microsoft Visual Studio 9.0\\Common7\\IDE\\PrivateAssemblies");
			AddIfExists(paths, path, "Microsoft Visual Studio 10.0\\Common7\\IDE\\PublicAssemblies");
			AddIfExists(paths, path, "Microsoft Visual Studio 10.0\\Common7\\IDE\\PrivateAssemblies");
			AddIfExists(paths, path, "Microsoft Visual Studio 11.0\\Common7\\IDE\\PublicAssemblies");
			AddIfExists(paths, path, "Microsoft Visual Studio 11.0\\Common7\\IDE\\PrivateAssemblies");
			AddIfExists(paths, path, "Microsoft Visual Studio 12.0\\Common7\\IDE\\PublicAssemblies");
			AddIfExists(paths, path, "Microsoft Visual Studio 12.0\\Common7\\IDE\\PrivateAssemblies");
			AddIfExists(paths, path, "Microsoft Visual Studio 14.0\\Common7\\IDE\\PublicAssemblies");
			AddIfExists(paths, path, "Microsoft Visual Studio 14.0\\Common7\\IDE\\PrivateAssemblies");
			AddIfExists(paths, path, "Microsoft XNA\\XNA Game Studio\\v2.0\\References\\Windows\\x86");
			AddIfExists(paths, path, "Microsoft XNA\\XNA Game Studio\\v2.0\\References\\Xbox360");
			AddIfExists(paths, path, "Microsoft XNA\\XNA Game Studio\\v3.0\\References\\Windows\\x86");
			AddIfExists(paths, path, "Microsoft XNA\\XNA Game Studio\\v3.0\\References\\Xbox360");
			AddIfExists(paths, path, "Microsoft XNA\\XNA Game Studio\\v3.0\\References\\Zune");
			AddIfExists(paths, path, "Microsoft XNA\\XNA Game Studio\\v3.1\\References\\Windows\\x86");
			AddIfExists(paths, path, "Microsoft XNA\\XNA Game Studio\\v3.1\\References\\Xbox360");
			AddIfExists(paths, path, "Microsoft XNA\\XNA Game Studio\\v3.1\\References\\Zune");
			AddIfExists(paths, path, "Microsoft XNA\\XNA Game Studio\\v4.0\\References\\Windows\\x86");
			AddIfExists(paths, path, "Microsoft XNA\\XNA Game Studio\\v4.0\\References\\Xbox360");
			AddIfExists(paths, path, "Windows CE Tools\\wce500\\Windows Mobile 5.0 Pocket PC SDK\\Designtimereferences");
			AddIfExists(paths, path, "Windows CE Tools\\wce500\\Windows Mobile 5.0 Smartphone SDK\\Designtimereferences");
			AddIfExists(paths, path, "Windows Mobile 5.0 SDK R2\\Managed Libraries");
			AddIfExists(paths, path, "Windows Mobile 6 SDK\\Managed Libraries");
			AddIfExists(paths, path, "Windows Mobile 6.5.3 DTK\\Managed Libraries");
			AddIfExists(paths, path, "Microsoft SQL Server\\90\\SDK\\Assemblies");
			AddIfExists(paths, path, "Microsoft SQL Server\\100\\SDK\\Assemblies");
			AddIfExists(paths, path, "Microsoft SQL Server\\110\\SDK\\Assemblies");
			AddIfExists(paths, path, "Microsoft SQL Server\\120\\SDK\\Assemblies");
			AddIfExists(paths, path, "Microsoft ASP.NET\\ASP.NET MVC 2\\Assemblies");
			AddIfExists(paths, path, "Microsoft ASP.NET\\ASP.NET MVC 3\\Assemblies");
			AddIfExists(paths, path, "Microsoft ASP.NET\\ASP.NET MVC 4\\Assemblies");
			AddIfExists(paths, path, "Microsoft ASP.NET\\ASP.NET Web Pages\\v1.0\\Assemblies");
			AddIfExists(paths, path, "Microsoft ASP.NET\\ASP.NET Web Pages\\v2.0\\Assemblies");
			AddIfExists(paths, path, "Microsoft SDKs\\F#\\3.0\\Framework\\v4.0");
		}
	}

	private static void AddSilverlightDirs(IList<string> paths, string basePath)
	{
		if (!Directory.Exists(basePath))
		{
			return;
		}
		try
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(basePath);
			DirectoryInfo[] directories = directoryInfo.GetDirectories();
			foreach (DirectoryInfo directoryInfo2 in directories)
			{
				if (Regex.IsMatch(directoryInfo2.Name, "^\\d+(?:\\.\\d+){3}$"))
				{
					AddIfExists(paths, basePath, directoryInfo2.Name);
				}
			}
		}
		catch
		{
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
}
