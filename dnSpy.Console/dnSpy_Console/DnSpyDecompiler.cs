#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Text;
using System.Threading;
using dnlib.DotNet;
using dnSpy_Console.Properties;
using dnSpy.Contracts.Decompiler;
using dnSpy.Contracts.Text;
using dnSpy.Contracts.Utilities;
using dnSpy.Decompiler.MSBuild;

namespace dnSpy_Console;

internal sealed class DnSpyDecompiler : IMSBuildProjectWriterLogger
{
	private readonly struct UsageInfo
	{
		public string Option { get; }

		public string OptionArgument { get; }

		public string Description { get; }

		public UsageInfo(string option, string optionArgument, string description)
		{
			Option = option;
			OptionArgument = optionArgument;
			Description = description;
		}
	}

	private readonly struct HelpInfo
	{
		public string CommandLine { get; }

		public string Description { get; }

		public HelpInfo(string description, string commandLine)
		{
			CommandLine = commandLine;
			Description = description;
		}
	}

	private bool isRecursive = false;

	private bool useGac = true;

	private bool addCorlibRef = true;

	private bool createSlnFile = true;

	private bool unpackResources = true;

	private bool createResX = true;

	private bool decompileBaml = true;

	private bool colorizeOutput;

	private Guid projectGuid = Guid.NewGuid();

	private int numThreads;

	private int mdToken;

	private int spaces;

	private string typeName;

	private ProjectVersion projectVersion = ProjectVersion.VS2010;

	private string outputDir;

	private string slnName = "solution.sln";

	private readonly List<string> files;

	private readonly List<string> asmPaths;

	private readonly List<string> userGacPaths;

	private readonly List<string> gacFiles;

	private string language = DecompilerConstants.LANGUAGE_CSHARP.ToString();

	private readonly DecompilationContext decompilationContext;

	private readonly ModuleContext moduleContext;

	private readonly AssemblyResolver assemblyResolver;

	private readonly IBamlDecompiler bamlDecompiler;

	private readonly HashSet<string> reservedOptions;

	private static readonly char PATHS_SEP = Path.PathSeparator;

	private static readonly UsageInfo[] usageInfos = new UsageInfo[21]
	{
		new UsageInfo("--asm-path", dnSpy_Console_Resources.CmdLinePath, dnSpy_Console_Resources.CmdLineDescription_AsmPath),
		new UsageInfo("--user-gac", dnSpy_Console_Resources.CmdLinePath, dnSpy_Console_Resources.CmdLineDescription_UserGAC),
		new UsageInfo("--no-gac", null, dnSpy_Console_Resources.CmdLineDescription_NoGAC),
		new UsageInfo("--no-stdlib", null, dnSpy_Console_Resources.CmdLineDescription_NoStdLib),
		new UsageInfo("--no-sln", null, dnSpy_Console_Resources.CmdLineDescription_NoSLN),
		new UsageInfo("--sln-name", dnSpy_Console_Resources.CmdLineName, dnSpy_Console_Resources.CmdLineDescription_SlnName),
		new UsageInfo("--threads", "N", dnSpy_Console_Resources.CmdLineDescription_NumberOfThreads),
		new UsageInfo("--no-resources", null, dnSpy_Console_Resources.CmdLineDescription_NoResources),
		new UsageInfo("--no-resx", null, dnSpy_Console_Resources.CmdLineDescription_NoResX),
		new UsageInfo("--no-baml", null, dnSpy_Console_Resources.CmdLineDescription_NoBAML),
		new UsageInfo("--no-color", null, dnSpy_Console_Resources.CmdLineDescription_NoColor),
		new UsageInfo("--spaces", "N", dnSpy_Console_Resources.CmdLineDescription_Spaces),
		new UsageInfo("--vs", "N", string.Format(dnSpy_Console_Resources.CmdLineDescription_VSVersion, 2017)),
		new UsageInfo("--project-guid", "N", dnSpy_Console_Resources.CmdLineDescription_ProjectGUID),
		new UsageInfo("-t", dnSpy_Console_Resources.CmdLineName, dnSpy_Console_Resources.CmdLineDescription_Type1),
		new UsageInfo("--type", dnSpy_Console_Resources.CmdLineName, dnSpy_Console_Resources.CmdLineDescription_Type2),
		new UsageInfo("--md", "N", dnSpy_Console_Resources.CmdLineDescription_MDToken),
		new UsageInfo("--gac-file", dnSpy_Console_Resources.CmdLineAssembly, dnSpy_Console_Resources.CmdLineDescription_GACFile),
		new UsageInfo("-r", null, dnSpy_Console_Resources.CmdLineDescription_RecursiveSearch),
		new UsageInfo("-o", dnSpy_Console_Resources.CmdLineOutputDir, dnSpy_Console_Resources.CmdLineDescription_OutputDirectory),
		new UsageInfo("-l", dnSpy_Console_Resources.CmdLineLanguage, dnSpy_Console_Resources.CmdLineDescription_Language)
	};

	private static readonly HelpInfo[] helpInfos = new HelpInfo[5]
	{
		new HelpInfo(dnSpy_Console_Resources.ExampleDescription1, "-o C:\\out\\path C:\\some\\path"),
		new HelpInfo(dnSpy_Console_Resources.ExampleDescription2, "-o C:\\out\\path -r C:\\some\\path"),
		new HelpInfo(dnSpy_Console_Resources.ExampleDescription3, "-o C:\\out\\path C:\\some\\path\\*.dll"),
		new HelpInfo(dnSpy_Console_Resources.ExampleDescription4, "--md 0x06000123 file.dll"),
		new HelpInfo(dnSpy_Console_Resources.ExampleDescription5, "-t system.int32 --gac-file \"mscorlib, Version=4.0.0.0\"")
	};

	private const string BOOLEAN_NO_PREFIX = "no-";

	private const string BOOLEAN_DONT_PREFIX = "dont-";

	private static readonly string[] ourOptions = new string[20]
	{
		"recursive", "output-dir", "lang", "asm-path", "user-gac", "gac", "stdlib", "sln", "sln-name", "threads",
		"vs", "resources", "resx", "baml", "color", "spaces", "type", "md", "gac-file", "project-guid"
	};

	private readonly HashSet<string> addedPaths = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

	private readonly IDecompiler[] allLanguages;

	private int errors;

	private IDecompiler[] AllLanguages => allLanguages;

	public DnSpyDecompiler()
	{
		files = new List<string>();
		asmPaths = new List<string>();
		userGacPaths = new List<string>();
		gacFiles = new List<string>();
		decompilationContext = new DecompilationContext();
		moduleContext = ModuleDef.CreateModuleContext(addOtherSearchPaths: false);
		assemblyResolver = (AssemblyResolver)moduleContext.AssemblyResolver;
		assemblyResolver.EnableFrameworkRedirect = false;
		assemblyResolver.FindExactMatch = true;
		assemblyResolver.EnableTypeDefCache = true;
		bamlDecompiler = TryLoadBamlDecompiler();
		decompileBaml = bamlDecompiler != null;
		reservedOptions = GetReservedOptions();
		colorizeOutput = !Console.IsOutputRedirected;
		List<IDecompiler> list = new List<IDecompiler>();
		list.AddRange(GetAllLanguages());
		list.Sort((IDecompiler a, IDecompiler b) => a.OrderUI.CompareTo(b.OrderUI));
		allLanguages = list.ToArray();
	}

	private static IEnumerable<IDecompiler> GetAllLanguages()
	{
		string[] asmNames = new string[1] { "dnSpy.Decompiler.ILSpy.Core" };
		string[] array = asmNames;
		foreach (string asmName in array)
		{
			foreach (IDecompiler item in GetLanguagesInAssembly(asmName))
			{
				yield return item;
			}
		}
	}

	private static IEnumerable<IDecompiler> GetLanguagesInAssembly(string asmName)
	{
		Assembly asm = TryLoad(asmName);
		if (!(asm != null))
		{
			yield break;
		}
		Type[] types = asm.GetTypes();
		foreach (Type type in types)
		{
			if (type.IsAbstract || type.IsInterface || !typeof(IDecompilerProvider).IsAssignableFrom(type))
			{
				continue;
			}
			IDecompilerProvider p = (IDecompilerProvider)Activator.CreateInstance(type);
			foreach (IDecompiler item in p.Create())
			{
				yield return item;
			}
		}
	}

	private static IBamlDecompiler TryLoadBamlDecompiler()
	{
		return TryCreateType<IBamlDecompiler>("dnSpy.BamlDecompiler.x", "dnSpy.BamlDecompiler.BamlDecompiler");
	}

	private static Assembly TryLoad(string asmName)
	{
		try
		{
			return Assembly.Load(asmName);
		}
		catch
		{
		}
		return null;
	}

	private static T TryCreateType<T>(string asmName, string typeFullName)
	{
		Type type = TryLoad(asmName)?.GetType(typeFullName);
		return (type == null) ? default(T) : ((T)Activator.CreateInstance(type));
	}

	public int Run(string[] args)
	{
		try
		{
			ParseCommandLine(args);
			if (allLanguages.Length == 0)
			{
				throw new ErrorException(dnSpy_Console_Resources.NoLanguagesFound);
			}
			if (GetLanguage() == null)
			{
				throw new ErrorException(string.Format(dnSpy_Console_Resources.LanguageXDoesNotExist, language));
			}
			Decompile();
		}
		catch (ErrorException ex)
		{
			PrintHelp();
			Console.WriteLine();
			Console.WriteLine(dnSpy_Console_Resources.Error1, ex.Message);
			return 1;
		}
		catch (Exception ex2)
		{
			Dump(ex2);
			return 1;
		}
		return (errors != 0) ? 1 : 0;
	}

	private void PrintHelp()
	{
		string programBaseName = GetProgramBaseName();
		Console.WriteLine(programBaseName + " " + dnSpy_Console_Resources.UsageHeader, programBaseName);
		Console.WriteLine();
		UsageInfo[] array = usageInfos;
		for (int i = 0; i < array.Length; i++)
		{
			UsageInfo usageInfo = array[i];
			string text = usageInfo.Option;
			if (usageInfo.OptionArgument != null)
			{
				text = text + " " + usageInfo.OptionArgument;
			}
			Console.WriteLine("  {0,-12}   {1}", text, string.Format(usageInfo.Description, PATHS_SEP));
		}
		Console.WriteLine();
		Console.WriteLine(dnSpy_Console_Resources.Languages);
		IDecompiler[] array2 = AllLanguages;
		foreach (IDecompiler decompiler in array2)
		{
			Console.WriteLine("  {0} ({1})", decompiler.UniqueNameUI, decompiler.UniqueGuid.ToString("B"));
		}
		List<IDecompiler>[] array3 = (from a in GetLanguageOptions()
			where a[0].Settings.Options.Any()
			select a).ToArray();
		if (array3.Length != 0)
		{
			Console.WriteLine();
			Console.WriteLine(dnSpy_Console_Resources.LanguageOptions);
			Console.WriteLine(dnSpy_Console_Resources.LanguageOptionsDesc);
			List<IDecompiler>[] array4 = array3;
			foreach (List<IDecompiler> list in array4)
			{
				Console.WriteLine();
				foreach (IDecompiler item in list)
				{
					Console.WriteLine("  {0} ({1})", item.UniqueNameUI, item.UniqueGuid.ToString("B"));
				}
				foreach (IDecompilerOption option in list[0].Settings.Options)
				{
					Console.WriteLine("    {0}\t({1} = {2}) {3}", GetOptionName(option), option.Type.Name, option.Value, option.Description);
				}
			}
		}
		Console.WriteLine();
		Console.WriteLine(dnSpy_Console_Resources.ExamplesHeader);
		HelpInfo[] array5 = helpInfos;
		for (int num2 = 0; num2 < array5.Length; num2++)
		{
			HelpInfo helpInfo = array5[num2];
			Console.WriteLine("  " + programBaseName + " " + helpInfo.CommandLine);
			Console.WriteLine("      " + helpInfo.Description);
		}
	}

	private string GetOptionName(IDecompilerOption opt, string extraPrefix = null)
	{
		string text = "--" + extraPrefix;
		string text2 = text + FixInvalidSwitchChars((opt.Name != null) ? opt.Name : opt.Guid.ToString());
		if (reservedOptions.Contains(text2))
		{
			text2 = text + FixInvalidSwitchChars(opt.Guid.ToString());
		}
		return text2;
	}

	private static string FixInvalidSwitchChars(string s)
	{
		return s.Replace(' ', '-');
	}

	private List<List<IDecompiler>> GetLanguageOptions()
	{
		List<List<IDecompiler>> list = new List<List<IDecompiler>>();
		Dictionary<object, List<IDecompiler>> dictionary = new Dictionary<object, List<IDecompiler>>();
		IDecompiler[] array = AllLanguages;
		foreach (IDecompiler decompiler in array)
		{
			if (!dictionary.TryGetValue(decompiler.Settings, out var value))
			{
				dictionary.Add(decompiler.Settings, value = new List<IDecompiler>());
				list.Add(value);
			}
			value.Add(decompiler);
		}
		return list;
	}

	private void Dump(Exception ex)
	{
		while (ex != null)
		{
			Console.WriteLine(dnSpy_Console_Resources.Error1, ex.GetType());
			Console.WriteLine("  {0}", ex.Message);
			Console.WriteLine("  {0}", ex.StackTrace);
			ex = ex.InnerException;
		}
	}

	private string GetProgramBaseName()
	{
		return GetBaseName(Environment.GetCommandLineArgs()[0]);
	}

	private string GetBaseName(string name)
	{
		int num = name.LastIndexOf(Path.DirectorySeparatorChar);
		if (num < 0)
		{
			return name;
		}
		return name.Substring(num + 1);
	}

	private HashSet<string> GetReservedOptions()
	{
		HashSet<string> hashSet = new HashSet<string>(StringComparer.Ordinal);
		string[] array = ourOptions;
		foreach (string text in array)
		{
			hashSet.Add("--" + text);
			hashSet.Add("--no-" + text);
			hashSet.Add("--dont-" + text);
		}
		return hashSet;
	}

	private void ParseCommandLine(string[] args)
	{
		if (args.Length == 0)
		{
			throw new ErrorException(dnSpy_Console_Resources.MissingOptions);
		}
		bool flag = true;
		IDecompiler decompiler = null;
		Dictionary<string, (IDecompilerOption, Action<string>)> dictionary = null;
		for (int i = 0; i < args.Length; i++)
		{
			if (decompiler == null)
			{
				decompiler = GetLanguage();
				dictionary = CreateDecompilerOptionsDictionary(decompiler);
			}
			string text = args[i];
			string text2 = ((i + 1 < args.Length) ? args[i + 1] : null);
			if (text.Length == 0)
			{
				continue;
			}
			if (flag && text[0] == '-')
			{
				string error;
				switch (text)
				{
				case "--":
					flag = false;
					continue;
				case "-r":
				case "--recursive":
					isRecursive = true;
					continue;
				case "-o":
				case "--output-dir":
					if (text2 == null)
					{
						throw new ErrorException(dnSpy_Console_Resources.MissingOutputDir);
					}
					outputDir = Path.GetFullPath(text2);
					i++;
					continue;
				case "-l":
				case "--lang":
					if (text2 == null)
					{
						throw new ErrorException(dnSpy_Console_Resources.MissingLanguageName);
					}
					language = text2;
					i++;
					if (GetLanguage() == null)
					{
						throw new ErrorException(string.Format(dnSpy_Console_Resources.LanguageDoesNotExist, language));
					}
					decompiler = null;
					dictionary = null;
					continue;
				case "--asm-path":
					if (text2 == null)
					{
						throw new ErrorException(dnSpy_Console_Resources.MissingAsmSearchPath);
					}
					asmPaths.AddRange(text2.Split(new char[1] { PATHS_SEP }, StringSplitOptions.RemoveEmptyEntries));
					i++;
					continue;
				case "--user-gac":
					if (text2 == null)
					{
						throw new ErrorException(dnSpy_Console_Resources.MissingUserGacPath);
					}
					userGacPaths.AddRange(text2.Split(new char[1] { PATHS_SEP }, StringSplitOptions.RemoveEmptyEntries));
					i++;
					continue;
				case "--no-gac":
					useGac = false;
					continue;
				case "--no-stdlib":
					addCorlibRef = false;
					continue;
				case "--no-sln":
					createSlnFile = false;
					continue;
				case "--sln-name":
					if (text2 == null)
					{
						throw new ErrorException(dnSpy_Console_Resources.MissingSolutionName);
					}
					slnName = text2;
					i++;
					if (Path.IsPathRooted(slnName))
					{
						throw new ErrorException(string.Format(dnSpy_Console_Resources.InvalidSolutionName, slnName));
					}
					continue;
				case "--threads":
					if (text2 == null)
					{
						throw new ErrorException(dnSpy_Console_Resources.MissingNumberOfThreads);
					}
					i++;
					numThreads = SimpleTypeConverter.ParseInt32(text2, int.MinValue, int.MaxValue, out error);
					if (!string.IsNullOrEmpty(error))
					{
						throw new ErrorException(error);
					}
					continue;
				case "--vs":
				{
					if (text2 == null)
					{
						throw new ErrorException(dnSpy_Console_Resources.MissingVSVersion);
					}
					i++;
					int num = SimpleTypeConverter.ParseInt32(text2, int.MinValue, int.MaxValue, out error);
					if (!string.IsNullOrEmpty(error))
					{
						throw new ErrorException(error);
					}
					switch (num)
					{
					case 2005:
						projectVersion = ProjectVersion.VS2005;
						break;
					case 2008:
						projectVersion = ProjectVersion.VS2008;
						break;
					case 2010:
						projectVersion = ProjectVersion.VS2010;
						break;
					case 2012:
						projectVersion = ProjectVersion.VS2012;
						break;
					case 2013:
						projectVersion = ProjectVersion.VS2013;
						break;
					case 2015:
						projectVersion = ProjectVersion.VS2015;
						break;
					case 2017:
						projectVersion = ProjectVersion.VS2017;
						break;
					default:
						throw new ErrorException(string.Format(dnSpy_Console_Resources.InvalidVSVersion, num));
					}
					continue;
				}
				case "--no-resources":
					unpackResources = false;
					continue;
				case "--no-resx":
					createResX = false;
					continue;
				case "--no-baml":
					decompileBaml = false;
					continue;
				case "--no-color":
					colorizeOutput = false;
					continue;
				case "--spaces":
					if (text2 == null)
					{
						throw new ErrorException(dnSpy_Console_Resources.MissingArgument);
					}
					if (!int.TryParse(text2, out spaces) || spaces < 0 || spaces > 100)
					{
						throw new ErrorException(string.Format(dnSpy_Console_Resources.InvalidSpacesArgument, 0, 100));
					}
					i++;
					continue;
				case "-t":
				case "--type":
					if (text2 == null)
					{
						throw new ErrorException(dnSpy_Console_Resources.MissingTypeName);
					}
					i++;
					typeName = text2;
					continue;
				case "--md":
					if (text2 == null)
					{
						throw new ErrorException(dnSpy_Console_Resources.MissingMDToken);
					}
					i++;
					mdToken = SimpleTypeConverter.ParseInt32(text2, int.MinValue, int.MaxValue, out error);
					if (!string.IsNullOrEmpty(error))
					{
						throw new ErrorException(error);
					}
					continue;
				case "--gac-file":
					if (text2 == null)
					{
						throw new ErrorException(dnSpy_Console_Resources.MissingGacFile);
					}
					i++;
					gacFiles.Add(text2);
					continue;
				case "--project-guid":
					if (text2 == null || !Guid.TryParse(text2, out projectGuid))
					{
						throw new ErrorException(dnSpy_Console_Resources.InvalidGuid);
					}
					i++;
					continue;
				}
				if (dictionary.TryGetValue(text, out var value))
				{
					bool flag2 = value.Item1.Type != typeof(bool);
					if (flag2 && text2 == null)
					{
						throw new ErrorException(dnSpy_Console_Resources.MissingOptionArgument);
					}
					if (flag2)
					{
						i++;
					}
					value.Item2(text2);
					continue;
				}
				throw new ErrorException(string.Format(dnSpy_Console_Resources.InvalidOption, text));
			}
			files.Add(text);
		}
	}

	private static int ParseInt32(string s)
	{
		int result = SimpleTypeConverter.ParseInt32(s, int.MinValue, int.MaxValue, out var error);
		if (!string.IsNullOrEmpty(error))
		{
			throw new ErrorException(error);
		}
		return result;
	}

	private static string ParseString(string s)
	{
		return s;
	}

	private Dictionary<string, (IDecompilerOption option, Action<string> setOptionValue)> CreateDecompilerOptionsDictionary(IDecompiler decompiler)
	{
		Dictionary<string, (IDecompilerOption, Action<string>)> dictionary = new Dictionary<string, (IDecompilerOption, Action<string>)>();
		if (decompiler == null)
		{
			return dictionary;
		}
		foreach (IDecompilerOption option in decompiler.Settings.Options)
		{
			IDecompilerOption opt = option;
			if (opt.Type == typeof(bool))
			{
				dictionary[GetOptionName(opt)] = (opt, delegate
				{
					opt.Value = true;
				});
				dictionary[GetOptionName(opt, "no-")] = (opt, delegate
				{
					opt.Value = false;
				});
				dictionary[GetOptionName(opt, "dont-")] = (opt, delegate
				{
					opt.Value = false;
				});
			}
			else if (opt.Type == typeof(int))
			{
				dictionary[GetOptionName(opt)] = (opt, delegate(string a)
				{
					opt.Value = ParseInt32(a);
				});
			}
			else if (opt.Type == typeof(string))
			{
				dictionary[GetOptionName(opt)] = (opt, delegate(string a)
				{
					opt.Value = ParseString(a);
				});
			}
			else
			{
				Debug.Fail($"Unsupported type: {opt.Type}");
			}
		}
		return dictionary;
	}

	private void AddSearchPath(string dir)
	{
		if (Directory.Exists(dir) && !addedPaths.Contains(dir))
		{
			addedPaths.Add(dir);
			assemblyResolver.PreSearchPaths.Add(dir);
		}
	}

	private void Decompile()
	{
		foreach (string asmPath in asmPaths)
		{
			AddSearchPath(asmPath);
		}
		foreach (string userGacPath in userGacPaths)
		{
			AddSearchPath(userGacPath);
		}
		assemblyResolver.UseGAC = useGac;
		List<ProjectModuleOptions> list = new List<ProjectModuleOptions>(GetDotNetFiles());
		string text = projectGuid.ToString();
		int num = int.Parse(text.Substring(28, 8), NumberStyles.HexNumber);
		string format = text.Substring(0, 28) + "{0:X8}";
		foreach (ProjectModuleOptions item in list.OrderBy((ProjectModuleOptions a) => a.Module.Location, StringComparer.InvariantCultureIgnoreCase))
		{
			item.ProjectGuid = new Guid(string.Format(format, num++));
		}
		if (mdToken != 0 || typeName != null)
		{
			if (list.Count == 0)
			{
				throw new ErrorException(dnSpy_Console_Resources.MissingDotNetFilename);
			}
			if (list.Count != 1)
			{
				throw new ErrorException(dnSpy_Console_Resources.OnlyOneFileCanBeDecompiled);
			}
			IMemberDef memberDef = ((typeName == null) ? (list[0].Module.ResolveToken(mdToken) as IMemberDef) : FindType(list[0].Module, typeName));
			if (memberDef == null)
			{
				if (typeName != null)
				{
					throw new ErrorException(string.Format(dnSpy_Console_Resources.CouldNotFindTypeX, typeName));
				}
				throw new ErrorException(dnSpy_Console_Resources.InvalidToken);
			}
			TextWriter writer = Console.Out;
			IDecompilerOutput output = ((!colorizeOutput) ? ((IDecompilerOutput)new TextWriterDecompilerOutput(writer, GetIndenter())) : ((IDecompilerOutput)new ConsoleColorizerOutput(writer, CreateColorProvider(), GetIndenter())));
			IDecompiler decompiler = GetLanguage();
			if (memberDef is MethodDef)
			{
				decompiler.Decompile((MethodDef)memberDef, output, decompilationContext);
				return;
			}
			if (memberDef is FieldDef)
			{
				decompiler.Decompile((FieldDef)memberDef, output, decompilationContext);
				return;
			}
			if (memberDef is PropertyDef)
			{
				decompiler.Decompile((PropertyDef)memberDef, output, decompilationContext);
				return;
			}
			if (memberDef is EventDef)
			{
				decompiler.Decompile((EventDef)memberDef, output, decompilationContext);
				return;
			}
			if (!(memberDef is TypeDef))
			{
				throw new ErrorException(dnSpy_Console_Resources.InvalidMemberToDecompile);
			}
			decompiler.Decompile((TypeDef)memberDef, output, decompilationContext);
		}
		else
		{
			if (string.IsNullOrEmpty(outputDir))
			{
				throw new ErrorException(dnSpy_Console_Resources.MissingOutputDir);
			}
			if (GetLanguage().ProjectFileExtension == null)
			{
				throw new ErrorException(string.Format(dnSpy_Console_Resources.LanguageXDoesNotSupportProjects, GetLanguage().UniqueNameUI));
			}
			decompilationContext.AsyncMethodBodyDecompilation = false;
			ProjectCreatorOptions projectCreatorOptions = new ProjectCreatorOptions(outputDir, decompilationContext.CancellationToken);
			projectCreatorOptions.Logger = this;
			projectCreatorOptions.ProjectVersion = projectVersion;
			projectCreatorOptions.NumberOfThreads = numThreads;
			projectCreatorOptions.ProjectModules.AddRange(list);
			projectCreatorOptions.UserGACPaths.AddRange(userGacPaths);
			projectCreatorOptions.CreateDecompilerOutput = (TextWriter textWriter) => new TextWriterDecompilerOutput(textWriter, GetIndenter());
			if (createSlnFile && !string.IsNullOrEmpty(slnName))
			{
				projectCreatorOptions.SolutionFilename = slnName;
			}
			MSBuildProjectCreator mSBuildProjectCreator = new MSBuildProjectCreator(projectCreatorOptions);
			mSBuildProjectCreator.Create();
		}
	}

	private Indenter GetIndenter()
	{
		if (spaces <= 0)
		{
			return new Indenter(4, 4, useTabs: true);
		}
		return new Indenter(spaces, spaces, useTabs: false);
	}

	private static TypeDef FindType(ModuleDef module, string name)
	{
		return FindTypeFullName(module, name, StringComparer.Ordinal) ?? FindTypeFullName(module, name, StringComparer.OrdinalIgnoreCase) ?? FindTypeName(module, name, StringComparer.Ordinal) ?? FindTypeName(module, name, StringComparer.OrdinalIgnoreCase);
	}

	private static TypeDef FindTypeFullName(ModuleDef module, string name, StringComparer comparer)
	{
		StringBuilder sb = new StringBuilder();
		return module.GetTypes().FirstOrDefault(delegate(TypeDef a)
		{
			sb.Clear();
			string s;
			if (comparer.Equals(s = FullNameFactory.FullName(a, isReflection: false, null, sb), name))
			{
				return true;
			}
			sb.Clear();
			string s2;
			if (comparer.Equals(s2 = FullNameFactory.FullName(a, isReflection: true, null, sb), name))
			{
				return true;
			}
			sb.Clear();
			if (comparer.Equals(CleanTypeName(s), name))
			{
				return true;
			}
			sb.Clear();
			return comparer.Equals(CleanTypeName(s2), name);
		});
	}

	private static TypeDef FindTypeName(ModuleDef module, string name, StringComparer comparer)
	{
		StringBuilder sb = new StringBuilder();
		return module.GetTypes().FirstOrDefault(delegate(TypeDef a)
		{
			sb.Clear();
			string s;
			if (comparer.Equals(s = FullNameFactory.Name(a, isReflection: false, sb), name))
			{
				return true;
			}
			sb.Clear();
			string s2;
			if (comparer.Equals(s2 = FullNameFactory.Name(a, isReflection: true, sb), name))
			{
				return true;
			}
			sb.Clear();
			if (comparer.Equals(CleanTypeName(s), name))
			{
				return true;
			}
			sb.Clear();
			return comparer.Equals(CleanTypeName(s2), name);
		});
	}

	private static string CleanTypeName(string s)
	{
		int num = s.LastIndexOf('`');
		if (num < 0)
		{
			return s;
		}
		return s.Substring(0, num);
	}

	private IEnumerable<ProjectModuleOptions> GetDotNetFiles()
	{
		foreach (string file in files)
		{
			if (File.Exists(file))
			{
				ProjectModuleOptions info = OpenNetFile(file);
				if (info == null)
				{
					throw new Exception(string.Format(dnSpy_Console_Resources.NotDotNetFile, file));
				}
				yield return info;
				continue;
			}
			if (Directory.Exists(file))
			{
				foreach (ProjectModuleOptions item in DumpDir(file, null))
				{
					yield return item;
				}
				continue;
			}
			string path = Path.GetDirectoryName(file);
			string name = Path.GetFileName(file);
			if (Directory.Exists(path))
			{
				foreach (ProjectModuleOptions item2 in DumpDir(path, name))
				{
					yield return item2;
				}
				continue;
			}
			throw new ErrorException(string.Format(dnSpy_Console_Resources.FileOrDirDoesNotExist, file));
		}
		bool oldFindExactMatch = assemblyResolver.FindExactMatch;
		assemblyResolver.FindExactMatch = false;
		foreach (string asmName in gacFiles)
		{
			AssemblyDef asm = assemblyResolver.Resolve(new AssemblyNameInfo(asmName), null);
			if (asm == null)
			{
				throw new ErrorException(string.Format(dnSpy_Console_Resources.CouldNotResolveGacFileX, asmName));
			}
			yield return CreateProjectModuleOptions(asm.ManifestModule);
		}
		assemblyResolver.FindExactMatch = oldFindExactMatch;
	}

	private IEnumerable<ProjectModuleOptions> DumpDir(string path, string pattern)
	{
		pattern = pattern ?? "*";
		Stack<string> stack = new Stack<string>();
		stack.Push(path);
		while (stack.Count > 0)
		{
			path = stack.Pop();
			foreach (ProjectModuleOptions item in DumpDir2(path, pattern))
			{
				yield return item;
			}
			if (!isRecursive)
			{
				continue;
			}
			foreach (DirectoryInfo di in GetDirs(path))
			{
				stack.Push(di.FullName);
			}
		}
	}

	private IEnumerable<DirectoryInfo> GetDirs(string path)
	{
		IEnumerable<FileSystemInfo> fsysIter = null;
		try
		{
			fsysIter = new DirectoryInfo(path).EnumerateFileSystemInfos("*", SearchOption.TopDirectoryOnly);
		}
		catch (IOException)
		{
		}
		catch (UnauthorizedAccessException)
		{
		}
		catch (SecurityException)
		{
		}
		if (fsysIter == null)
		{
			yield break;
		}
		foreach (FileSystemInfo info in fsysIter)
		{
			if ((info.Attributes & System.IO.FileAttributes.Directory) != 0)
			{
				DirectoryInfo di = null;
				try
				{
					di = new DirectoryInfo(info.FullName);
				}
				catch (IOException)
				{
				}
				catch (UnauthorizedAccessException)
				{
				}
				catch (SecurityException)
				{
				}
				if (di != null)
				{
					yield return di;
				}
			}
		}
	}

	private IEnumerable<ProjectModuleOptions> DumpDir2(string path, string pattern)
	{
		pattern = pattern ?? "*";
		foreach (FileInfo fi in GetFiles(path, pattern))
		{
			ProjectModuleOptions info = OpenNetFile(fi.FullName);
			if (info != null)
			{
				yield return info;
			}
		}
	}

	private IEnumerable<FileInfo> GetFiles(string path, string pattern)
	{
		IEnumerable<FileSystemInfo> fsysIter = null;
		try
		{
			fsysIter = new DirectoryInfo(path).EnumerateFileSystemInfos(pattern, SearchOption.TopDirectoryOnly);
		}
		catch (IOException)
		{
		}
		catch (UnauthorizedAccessException)
		{
		}
		catch (SecurityException)
		{
		}
		if (fsysIter == null)
		{
			yield break;
		}
		foreach (FileSystemInfo info in fsysIter)
		{
			if ((info.Attributes & System.IO.FileAttributes.Directory) == 0)
			{
				FileInfo fi = null;
				try
				{
					fi = new FileInfo(info.FullName);
				}
				catch (IOException)
				{
				}
				catch (UnauthorizedAccessException)
				{
				}
				catch (SecurityException)
				{
				}
				if (fi != null)
				{
					yield return fi;
				}
			}
		}
	}

	private ProjectModuleOptions OpenNetFile(string file)
	{
		try
		{
			file = Path.GetFullPath(file);
			if (!File.Exists(file))
			{
				return null;
			}
			return CreateProjectModuleOptions(ModuleDefMD.Load(file, moduleContext));
		}
		catch
		{
		}
		return null;
	}

	private ProjectModuleOptions CreateProjectModuleOptions(ModuleDef mod)
	{
		mod.EnableTypeDefFindCache = true;
		((AssemblyResolver)moduleContext.AssemblyResolver).AddToCache(mod);
		AddSearchPath(Path.GetDirectoryName(mod.Location));
		ProjectModuleOptions projectModuleOptions = new ProjectModuleOptions(mod, GetLanguage(), decompilationContext);
		projectModuleOptions.DontReferenceStdLib = !addCorlibRef;
		projectModuleOptions.UnpackResources = unpackResources;
		projectModuleOptions.CreateResX = createResX;
		projectModuleOptions.DecompileXaml = decompileBaml && bamlDecompiler != null;
		BamlDecompilerOptions o = BamlDecompilerOptions.Create(GetLanguage());
		XamlOutputOptions outputOptions = new XamlOutputOptions
		{
			IndentChars = "\t",
			NewLineChars = Environment.NewLine,
			NewLineOnAttributes = true
		};
		if (bamlDecompiler != null)
		{
			projectModuleOptions.DecompileBaml = (ModuleDef a, byte[] b, CancellationToken c, Stream d) => bamlDecompiler.Decompile(a, b, c, o, d, outputOptions);
		}
		return projectModuleOptions;
	}

	private IDecompiler GetLanguage()
	{
		bool hasGuid = Guid.TryParse(language, out var guid);
		return AllLanguages.FirstOrDefault(delegate(IDecompiler a)
		{
			if (StringComparer.OrdinalIgnoreCase.Equals(language, a.UniqueNameUI))
			{
				return true;
			}
			return (hasGuid && (guid.Equals(a.UniqueGuid) || guid.Equals(a.GenericGuid))) ? true : false;
		});
	}

	public void Error(string message)
	{
		errors++;
		Console.Error.WriteLine(string.Format(dnSpy_Console_Resources.Error1, message));
	}

	private ColorProvider CreateColorProvider()
	{
		ColorProvider colorProvider = new ColorProvider();
		colorProvider.Add(TextColor.Operator, null);
		colorProvider.Add(TextColor.Punctuation, null);
		colorProvider.Add(TextColor.Number, null);
		colorProvider.Add(TextColor.Comment, ConsoleColor.Green);
		colorProvider.Add(TextColor.Keyword, ConsoleColor.Cyan);
		colorProvider.Add(TextColor.String, ConsoleColor.DarkYellow);
		colorProvider.Add(TextColor.VerbatimString, ConsoleColor.DarkYellow);
		colorProvider.Add(TextColor.Char, ConsoleColor.DarkYellow);
		colorProvider.Add(TextColor.Namespace, ConsoleColor.Yellow);
		colorProvider.Add(TextColor.Type, ConsoleColor.Magenta);
		colorProvider.Add(TextColor.SealedType, ConsoleColor.Magenta);
		colorProvider.Add(TextColor.StaticType, ConsoleColor.Magenta);
		colorProvider.Add(TextColor.Delegate, ConsoleColor.Magenta);
		colorProvider.Add(TextColor.Enum, ConsoleColor.Magenta);
		colorProvider.Add(TextColor.Interface, ConsoleColor.Magenta);
		colorProvider.Add(TextColor.ValueType, ConsoleColor.Green);
		colorProvider.Add(TextColor.Module, ConsoleColor.DarkMagenta);
		colorProvider.Add(TextColor.TypeGenericParameter, ConsoleColor.Magenta);
		colorProvider.Add(TextColor.MethodGenericParameter, ConsoleColor.Magenta);
		colorProvider.Add(TextColor.InstanceMethod, ConsoleColor.DarkYellow);
		colorProvider.Add(TextColor.StaticMethod, ConsoleColor.DarkYellow);
		colorProvider.Add(TextColor.ExtensionMethod, ConsoleColor.DarkYellow);
		colorProvider.Add(TextColor.InstanceField, ConsoleColor.Magenta);
		colorProvider.Add(TextColor.EnumField, ConsoleColor.Magenta);
		colorProvider.Add(TextColor.LiteralField, ConsoleColor.Magenta);
		colorProvider.Add(TextColor.StaticField, ConsoleColor.Magenta);
		colorProvider.Add(TextColor.InstanceEvent, ConsoleColor.Magenta);
		colorProvider.Add(TextColor.StaticEvent, ConsoleColor.Magenta);
		colorProvider.Add(TextColor.InstanceProperty, ConsoleColor.Magenta);
		colorProvider.Add(TextColor.StaticProperty, ConsoleColor.Magenta);
		colorProvider.Add(TextColor.Local, ConsoleColor.White);
		colorProvider.Add(TextColor.Parameter, ConsoleColor.White);
		colorProvider.Add(TextColor.PreprocessorKeyword, ConsoleColor.Blue);
		colorProvider.Add(TextColor.PreprocessorText, null);
		colorProvider.Add(TextColor.Label, ConsoleColor.DarkRed);
		colorProvider.Add(TextColor.OpCode, ConsoleColor.Cyan);
		colorProvider.Add(TextColor.ILDirective, ConsoleColor.Cyan);
		colorProvider.Add(TextColor.ILModule, ConsoleColor.DarkMagenta);
		colorProvider.Add(TextColor.ExcludedCode, null);
		colorProvider.Add(TextColor.XmlDocCommentAttributeName, ConsoleColor.DarkGreen);
		colorProvider.Add(TextColor.XmlDocCommentAttributeQuotes, ConsoleColor.DarkGreen);
		colorProvider.Add(TextColor.XmlDocCommentAttributeValue, ConsoleColor.DarkGreen);
		colorProvider.Add(TextColor.XmlDocCommentCDataSection, ConsoleColor.DarkGreen);
		colorProvider.Add(TextColor.XmlDocCommentComment, ConsoleColor.DarkGreen);
		colorProvider.Add(TextColor.XmlDocCommentDelimiter, ConsoleColor.DarkGreen);
		colorProvider.Add(TextColor.XmlDocCommentEntityReference, ConsoleColor.DarkGreen);
		colorProvider.Add(TextColor.XmlDocCommentName, ConsoleColor.DarkGreen);
		colorProvider.Add(TextColor.XmlDocCommentProcessingInstruction, ConsoleColor.DarkGreen);
		colorProvider.Add(TextColor.XmlDocCommentText, ConsoleColor.DarkGreen);
		colorProvider.Add(TextColor.Error, ConsoleColor.Red);
		return colorProvider;
	}
}
