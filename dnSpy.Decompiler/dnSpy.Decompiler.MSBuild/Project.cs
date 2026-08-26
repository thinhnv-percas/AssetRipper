#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnlib.DotNet.Resources;
using dnlib.PE;
using dnSpy.Contracts.Decompiler;
using dnSpy.Decompiler.Properties;

namespace dnSpy.Decompiler.MSBuild;

internal sealed class Project
{
	private ApplicationIcon applicationIcon;

	private ApplicationManifest applicationManifest;

	private readonly SatelliteAssemblyFinder satelliteAssemblyFinder;

	private readonly Func<TextWriter, IDecompilerOutput> createDecompilerOutput;

	private string splashScreenImageName;

	private TypeProjectFile appTypeProjFile;

	private Dictionary<string, BamlResourceProjectFile> typeFullNameToBamlFile;

	private bool hasXamlClasses;

	private Dictionary<string, ResXProjectFile> typeFullNameToResXFile;

	public ProjectModuleOptions Options { get; }

	public string DefaultNamespace { get; }

	public string AssemblyName { get; }

	public ModuleDef Module => Options.Module;

	public List<ProjectFile> Files { get; }

	public Guid Guid => Options.ProjectGuid;

	public Guid LanguageGuid { get; }

	public string Filename { get; }

	public string Directory { get; }

	public string Platform { get; set; }

	public HashSet<Guid> ProjectTypeGuids { get; }

	public HashSet<string> ExtraAssemblyReferences { get; }

	public string StartupObject { get; private set; }

	public bool AllowUnsafeBlocks { get; private set; }

	public string PropertiesFolder { get; }

	public ApplicationIcon ApplicationIcon => applicationIcon;

	public ApplicationManifest ApplicationManifest => applicationManifest;

	public Project(ProjectModuleOptions options, string projDir, SatelliteAssemblyFinder satelliteAssemblyFinder, Func<TextWriter, IDecompilerOutput> createDecompilerOutput)
	{
		Options = options ?? throw new ArgumentNullException("options");
		Directory = projDir;
		this.satelliteAssemblyFinder = satelliteAssemblyFinder;
		this.createDecompilerOutput = createDecompilerOutput;
		Files = new List<ProjectFile>();
		DefaultNamespace = new DefaultNamespaceFinder(options.Module).Find();
		Filename = Path.Combine(projDir, Path.GetFileName(projDir) + options.Decompiler.ProjectFileExtension);
		AssemblyName = ((options.Module.Assembly == null) ? string.Empty : options.Module.Assembly.Name.String);
		ProjectTypeGuids = new HashSet<Guid>();
		PropertiesFolder = CalculatePropertiesFolder();
		ExtraAssemblyReferences = new HashSet<string>();
		LanguageGuid = CalculateLanguageGuid(options.Decompiler);
	}

	private static Guid CalculateLanguageGuid(IDecompiler decompiler)
	{
		if (decompiler.GenericGuid == DecompilerConstants.LANGUAGE_VISUALBASIC)
		{
			return new Guid("F184B08F-C81C-45F6-A57F-5ABD9991F28F");
		}
		Debug.Assert(decompiler.GenericGuid == DecompilerConstants.LANGUAGE_CSHARP);
		return new Guid("FAE04EC0-301F-11D3-BF4B-00C04F79EFBC");
	}

	private string CalculatePropertiesFolder()
	{
		if (Options.Decompiler.GenericGuid == DecompilerConstants.LANGUAGE_VISUALBASIC)
		{
			return "My Project";
		}
		return "Properties";
	}

	public void CreateProjectFiles(DecompileContext ctx)
	{
		FilenameCreator filenameCreator = new FilenameCreator(Directory, DefaultNamespace);
		ResourceNameCreator resourceNameCreator = new ResourceNameCreator(Options.Module, filenameCreator);
		AllowUnsafeBlocks = DotNetUtils.IsUnsafe(Options.Module);
		InitializeSplashScreen();
		if (Options.Decompiler.CanDecompile(DecompilationType.AssemblyInfo))
		{
			string filename = filenameCreator.CreateFromRelativePath(Path.Combine(PropertiesFolder, "AssemblyInfo"), Options.Decompiler.FileExtension);
			Files.Add(new AssemblyInfoProjectFile(Options.Module, filename, Options.DecompilationContext, Options.Decompiler, createDecompilerOutput));
		}
		MethodDef entryPoint = Options.Module.EntryPoint;
		if (entryPoint != null && entryPoint.DeclaringType != null)
		{
			StartupObject = entryPoint.DeclaringType.ReflectionFullName;
		}
		applicationManifest = ApplicationManifest.TryCreate(Options.Module.Win32Resources, filenameCreator);
		if (ApplicationManifest != null)
		{
			Files.Add(new ApplicationManifestProjectFile(ApplicationManifest.Filename));
		}
		foreach (Resource resource in Options.Module.Resources)
		{
			ctx.CancellationToken.ThrowIfCancellationRequested();
			switch (resource.ResourceType)
			{
			case ResourceType.Embedded:
				foreach (ProjectFile item in CreateEmbeddedResourceFiles(Options.Module, resourceNameCreator, (EmbeddedResource)resource))
				{
					Files.Add(item);
					Files.AddRange(CreateSatelliteFiles(resource.Name, filenameCreator, item));
				}
				break;
			}
		}
		InitializeXaml();
		InitializeResX();
		foreach (TypeDef type in Options.Module.Types)
		{
			ctx.CancellationToken.ThrowIfCancellationRequested();
			if (DecompileType(type))
			{
				Files.Add(CreateTypeProjectFile(type, filenameCreator));
			}
		}
		CreateEmptyAppXamlFile();
		string text = Options.Module.Location + ".config";
		if (File.Exists(text))
		{
			Files.Add(new AppConfigProjectFile(filenameCreator.CreateName("App.config"), text));
		}
		applicationIcon = ApplicationIcon.TryCreate(Options.Module.Win32Resources, Path.GetFileName(Directory), filenameCreator);
		HashSet<string> hashSet = new HashSet<string>(from a in Files
			select GetDirectoryName(a.Filename) into a
			where a != null
			select a, StringComparer.OrdinalIgnoreCase);
		int num = 0;
		foreach (string item2 in hashSet)
		{
			ctx.CancellationToken.ThrowIfCancellationRequested();
			try
			{
				System.IO.Directory.CreateDirectory(item2);
			}
			catch (Exception ex)
			{
				if (num++ < 20)
				{
					ctx.Logger.Error(string.Format(dnSpy_Decompiler_Resources.MSBuild_CouldNotCreateDirectory2, item2, ex.Message));
				}
			}
		}
	}

	private static string GetDirectoryName(string s)
	{
		try
		{
			return Path.GetDirectoryName(s);
		}
		catch (ArgumentException)
		{
		}
		catch (PathTooLongException)
		{
		}
		return null;
	}

	private void InitializeSplashScreen()
	{
		MethodDef entryPoint = Options.Module.EntryPoint;
		if (entryPoint == null || entryPoint.Body == null)
		{
			return;
		}
		IList<Instruction> instructions = entryPoint.Body.Instructions;
		for (int i = 0; i + 1 < instructions.Count; i++)
		{
			Instruction instruction = instructions[i + 1];
			if (instruction.OpCode.Code == Code.Newobj && instructions[i].Operand is string text && instruction.Operand is IMethod { MethodSig: not null } method && (!(method.FullName != "System.Void System.Windows.SplashScreen::.ctor(System.String)") || !(method.FullName != "System.Void System.Windows.SplashScreen::.ctor(System.Reflection.Assembly,System.String)")))
			{
				splashScreenImageName = text;
				break;
			}
		}
	}

	private ProjectFile CreateTypeProjectFile(TypeDef type, FilenameCreator filenameCreator)
	{
		BamlResourceProjectFile bamlResourceProjectFile = TryGetBamlFile(type);
		if (bamlResourceProjectFile != null)
		{
			string filename = filenameCreator.Create(GetTypeExtension(type), type.FullName);
			bool flag = DotNetUtils.IsSystemWindowsApplication(type);
			TypeProjectFile typeProjectFile = (Options.Decompiler.CanDecompile(DecompilationType.PartialType) ? new XamlTypeProjectFile(type, filename, Options.DecompilationContext, Options.Decompiler, createDecompilerOutput) : new TypeProjectFile(type, filename, Options.DecompilationContext, Options.Decompiler, createDecompilerOutput));
			typeProjectFile.DependentUpon = bamlResourceProjectFile;
			if (flag && DotNetUtils.IsStartUpClass(type))
			{
				bamlResourceProjectFile.IsAppDef = true;
				StartupObject = null;
			}
			if (flag)
			{
				appTypeProjFile = typeProjectFile;
			}
			return typeProjectFile;
		}
		ResXProjectFile resXProjectFile = TryGetResXFile(type);
		if (DotNetUtils.IsWinForm(type))
		{
			string text = ((resXProjectFile != null) ? Path.GetFileNameWithoutExtension(resXProjectFile.Filename) : type.Name.String);
			string filename2 = filenameCreator.CreateFromNamespaceName(GetTypeExtension(type), type.ReflectionNamespace, text);
			string filename3 = filenameCreator.CreateFromNamespaceName(GetTypeExtension(type), type.ReflectionNamespace, text + ".Designer");
			WinFormsProjectFile winFormsProjectFile = new WinFormsProjectFile(type, filename2, Options.DecompilationContext, Options.Decompiler, createDecompilerOutput);
			if (resXProjectFile != null)
			{
				resXProjectFile.DependentUpon = winFormsProjectFile;
			}
			WinFormsDesignerProjectFile winFormsDesignerProjectFile = new WinFormsDesignerProjectFile(winFormsProjectFile, filename3, createDecompilerOutput);
			winFormsDesignerProjectFile.DependentUpon = winFormsProjectFile;
			Files.Add(winFormsDesignerProjectFile);
			return winFormsProjectFile;
		}
		if (resXProjectFile != null)
		{
			string filename4 = filenameCreator.CreateFromNamespaceName(GetTypeExtension(type), type.ReflectionNamespace, Path.GetFileNameWithoutExtension(resXProjectFile.Filename) + ".Designer");
			TypeProjectFile typeProjectFile2 = new TypeProjectFile(type, filename4, Options.DecompilationContext, Options.Decompiler, createDecompilerOutput);
			typeProjectFile2.DependentUpon = resXProjectFile;
			typeProjectFile2.AutoGen = true;
			typeProjectFile2.DesignTime = true;
			resXProjectFile.Generator = (type.IsPublic ? "PublicResXFileCodeGenerator" : "ResXFileCodeGenerator");
			resXProjectFile.LastGenOutput = typeProjectFile2;
			return typeProjectFile2;
		}
		ITypeDefOrRef baseType = type.BaseType;
		if (baseType != null && baseType.FullName == "System.Configuration.ApplicationSettingsBase")
		{
			string filename5 = filenameCreator.Create(".Designer" + GetTypeExtension(type), type.FullName);
			string filename6 = filenameCreator.Create(".settings", type.FullName);
			ProjectFile projectFile;
			if (Options.Decompiler.CanDecompile(DecompilationType.PartialType))
			{
				string filename7 = filenameCreator.Create(GetTypeExtension(type), type.FullName);
				SettingsTypeProjectFile settingsTypeProjectFile = new SettingsTypeProjectFile(type, filename7, Options.DecompilationContext, Options.Decompiler, createDecompilerOutput);
				projectFile = new SettingsDesignerTypeProjectFile(settingsTypeProjectFile, filename5, createDecompilerOutput);
				Files.Add(settingsTypeProjectFile);
			}
			else
			{
				projectFile = new TypeProjectFile(type, filename5, Options.DecompilationContext, Options.Decompiler, createDecompilerOutput);
			}
			SettingsProjectFile settingsProjectFile = (SettingsProjectFile)(projectFile.DependentUpon = new SettingsProjectFile(type, filename6));
			projectFile.AutoGen = true;
			projectFile.DesignTimeSharedInput = true;
			settingsProjectFile.Generator = (type.IsPublic ? "PublicSettingsSingleFileGenerator" : "SettingsSingleFileGenerator");
			settingsProjectFile.LastGenOutput = projectFile;
			Files.Add(settingsProjectFile);
			return projectFile;
		}
		string filename8 = filenameCreator.Create(GetTypeExtension(type), type.FullName);
		return new TypeProjectFile(type, filename8, Options.DecompilationContext, Options.Decompiler, createDecompilerOutput);
	}

	private void CreateEmptyAppXamlFile()
	{
		if (!hasXamlClasses || appTypeProjFile != null || (Options.Module.Characteristics & Characteristics.Dll) != 0)
		{
			return;
		}
		TypeProjectFile typeProjectFile = (from a in Files.OfType<TypeProjectFile>()
			where DotNetUtils.IsSystemWindowsApplication(a.Type)
			select a).FirstOrDefault();
		Debug.Assert(typeProjectFile != null);
		if (typeProjectFile != null)
		{
			Debug.Assert(typeProjectFile.DependentUpon == null);
			if (typeProjectFile.DependentUpon == null)
			{
				Files.Remove(typeProjectFile);
				string filename = typeProjectFile.Filename;
				string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(typeProjectFile.Filename);
				filename = Path.Combine(Path.GetDirectoryName(filename), fileNameWithoutExtension + ".xaml");
				XamlTypeProjectFile xamlTypeProjectFile = new XamlTypeProjectFile(typeProjectFile.Type, filename + Options.Decompiler.FileExtension, Options.DecompilationContext, Options.Decompiler, createDecompilerOutput);
				Files.Add(xamlTypeProjectFile);
				AppBamlResourceProjectFile item = (AppBamlResourceProjectFile)(xamlTypeProjectFile.DependentUpon = new AppBamlResourceProjectFile(filename, typeProjectFile.Type, Options.Decompiler));
				Files.Add(item);
			}
		}
	}

	private void InitializeXaml()
	{
		typeFullNameToBamlFile = new Dictionary<string, BamlResourceProjectFile>(StringComparer.OrdinalIgnoreCase);
		foreach (BamlResourceProjectFile item in Files.OfType<BamlResourceProjectFile>())
		{
			hasXamlClasses = true;
			if (!string.IsNullOrEmpty(item.TypeFullName) && !item.IsSatelliteFile)
			{
				typeFullNameToBamlFile[item.TypeFullName] = item;
			}
		}
		if (hasXamlClasses)
		{
			ExtraAssemblyReferences.Add("WindowsBase");
			ExtraAssemblyReferences.Add("PresentationCore");
			ExtraAssemblyReferences.Add("PresentationFramework");
			if (!Options.Module.IsClr1x && !Options.Module.IsClr20)
			{
				ExtraAssemblyReferences.Add("System.Xaml");
			}
		}
		if (hasXamlClasses || ReferencesWPFClasses())
		{
			ProjectTypeGuids.Add(new Guid("60DC8134-EBA5-43B8-BCC9-BB4BC16C2548"));
			if (Options.Decompiler.GenericGuid == DecompilerConstants.LANGUAGE_VISUALBASIC)
			{
				ProjectTypeGuids.Add(new Guid("F184B08F-C81C-45F6-A57F-5ABD9991F28F"));
			}
			else if (Options.Decompiler.GenericGuid == DecompilerConstants.LANGUAGE_CSHARP)
			{
				ProjectTypeGuids.Add(new Guid("FAE04EC0-301F-11D3-BF4B-00C04F79EFBC"));
			}
		}
	}

	private bool ReferencesWPFClasses()
	{
		foreach (AssemblyRef assemblyRef in Options.Module.GetAssemblyRefs())
		{
			switch (assemblyRef.Name)
			{
			case "WindowsBase":
			case "PresentationCore":
			case "PresentationFramework":
				return true;
			}
		}
		return false;
	}

	private BamlResourceProjectFile TryGetBamlFile(TypeDef type)
	{
		typeFullNameToBamlFile.TryGetValue(type.FullName, out var value);
		return value;
	}

	private void InitializeResX()
	{
		typeFullNameToResXFile = new Dictionary<string, ResXProjectFile>(StringComparer.Ordinal);
		foreach (ResXProjectFile item in Files.OfType<ResXProjectFile>())
		{
			if (!string.IsNullOrEmpty(item.TypeFullName) && !item.IsSatelliteFile)
			{
				typeFullNameToResXFile[item.TypeFullName] = item;
			}
		}
	}

	private ResXProjectFile TryGetResXFile(TypeDef type)
	{
		typeFullNameToResXFile.TryGetValue(type.FullName, out var value);
		return value;
	}

	private string GetTypeExtension(TypeDef type)
	{
		if (typeFullNameToBamlFile.TryGetValue(type.FullName, out var _))
		{
			return ".xaml" + Options.Decompiler.FileExtension;
		}
		return Options.Decompiler.FileExtension;
	}

	private IEnumerable<ProjectFile> CreateEmbeddedResourceFiles(ModuleDef module, ResourceNameCreator resourceNameCreator, EmbeddedResource er)
	{
		if (!Options.UnpackResources)
		{
			yield return CreateRawEmbeddedResourceProjectFile(module, resourceNameCreator, er);
			yield break;
		}
		if (ResourceReader.CouldBeResourcesFile(er.CreateReader()))
		{
			List<ProjectFile> files = TryCreateResourceFiles(module, resourceNameCreator, er);
			if (files != null)
			{
				foreach (ProjectFile item in files)
				{
					yield return item;
				}
				yield break;
			}
		}
		yield return CreateRawEmbeddedResourceProjectFile(module, resourceNameCreator, er);
	}

	private List<ProjectFile> TryCreateResourceFiles(ModuleDef module, ResourceNameCreator resourceNameCreator, EmbeddedResource er)
	{
		ResourceElementSet set;
		try
		{
			set = ResourceReader.Read(module, er.CreateReader());
		}
		catch
		{
			return null;
		}
		if (IsXamlResource(module, er.Name, set))
		{
			return CreateXamlResourceFiles(module, resourceNameCreator, set).ToList();
		}
		if (Options.CreateResX)
		{
			string resxFilename = resourceNameCreator.GetResxFilename(er.Name, out var typeFullName);
			return new List<ProjectFile> { CreateResXFile(module, er, set, resxFilename, typeFullName, isSatellite: false) };
		}
		return null;
	}

	private bool IsXamlResource(ModuleDef module, string name, ResourceElementSet set)
	{
		AssemblyDef assembly = module.Assembly;
		if (assembly == null || !module.IsManifestModule)
		{
			return false;
		}
		string text = (UTF8String.IsNullOrEmpty(assembly.Culture) ? string.Empty : ("." + assembly.Culture));
		if (!StringComparer.OrdinalIgnoreCase.Equals(string.Concat(assembly.Name, ".g", text, ".resources"), name))
		{
			return false;
		}
		ResourceElement[] array = set.ResourceElements.ToArray();
		if (array.Length == 0)
		{
			return false;
		}
		ResourceElement[] array2 = array;
		foreach (ResourceElement resourceElement in array2)
		{
			if (resourceElement.ResourceData.Code != ResourceTypeCode.ByteArray && resourceElement.ResourceData.Code != ResourceTypeCode.Stream)
			{
				return false;
			}
		}
		return true;
	}

	private IEnumerable<ProjectFile> CreateXamlResourceFiles(ModuleDef module, ResourceNameCreator resourceNameCreator, ResourceElementSet set)
	{
		bool decompileBaml = Options.DecompileXaml && Options.DecompileBaml != null;
		foreach (ResourceElement e in set.ResourceElements)
		{
			Debug.Assert(e.ResourceData.Code == ResourceTypeCode.ByteArray || e.ResourceData.Code == ResourceTypeCode.Stream);
			byte[] data = (byte[])((BuiltInResourceData)e.ResourceData).Data;
			if (decompileBaml && e.Name.EndsWith(".baml", StringComparison.OrdinalIgnoreCase))
			{
				string filename = resourceNameCreator.GetBamlResourceName(e.Name, out var typeFullName);
				yield return new BamlResourceProjectFile(filename, data, typeFullName, (byte[] bamlData, Stream stream) => Options.DecompileBaml(module, bamlData, Options.DecompilationContext.CancellationToken, stream));
				typeFullName = null;
			}
			else if (StringComparer.InvariantCultureIgnoreCase.Equals(splashScreenImageName, e.Name))
			{
				string filename2 = resourceNameCreator.GetXamlResourceFilename(e.Name);
				yield return new SplashScreenProjectFile(filename2, data, e.Name);
			}
			else
			{
				string filename3 = resourceNameCreator.GetXamlResourceFilename(e.Name);
				yield return new ResourceProjectFile(filename3, data, e.Name);
			}
		}
	}

	private ResXProjectFile CreateResXFile(ModuleDef module, EmbeddedResource er, ResourceElementSet set, string filename, string typeFullName, bool isSatellite)
	{
		Debug.Assert(Options.CreateResX);
		if (!Options.CreateResX)
		{
			throw new InvalidOperationException();
		}
		return new ResXProjectFile(module, filename, typeFullName, er)
		{
			IsSatelliteFile = isSatellite
		};
	}

	private RawEmbeddedResourceProjectFile CreateRawEmbeddedResourceProjectFile(ModuleDef module, ResourceNameCreator resourceNameCreator, EmbeddedResource er)
	{
		return new RawEmbeddedResourceProjectFile(resourceNameCreator.GetResourceFilename(er.Name), er);
	}

	private bool DecompileType(TypeDef type)
	{
		if (!Options.Decompiler.ShowMember(type))
		{
			return false;
		}
		if (type.IsGlobalModuleType && type.Methods.Count == 0 && type.Fields.Count == 0 && type.Properties.Count == 0 && type.Events.Count == 0 && type.NestedTypes.Count == 0)
		{
			return false;
		}
		if (type.Namespace == "XamlGeneratedNamespace" && type.Name == "GeneratedInternalTypeHelper")
		{
			return false;
		}
		return true;
	}

	private IEnumerable<ProjectFile> CreateSatelliteFiles(string rsrcName, FilenameCreator filenameCreator, ProjectFile nonSatFile)
	{
		foreach (ModuleDef satMod in satelliteAssemblyFinder.GetSatelliteAssemblies(Options.Module))
		{
			ProjectFile satFile = TryCreateSatelliteFile(satMod, rsrcName, filenameCreator, nonSatFile);
			if (satFile != null)
			{
				yield return satFile;
			}
		}
	}

	private ProjectFile TryCreateSatelliteFile(ModuleDef module, string rsrcName, FilenameCreator filenameCreator, ProjectFile nonSatFile)
	{
		if (!Options.CreateResX)
		{
			return null;
		}
		AssemblyDef assembly = module.Assembly;
		Debug.Assert(assembly != null && !UTF8String.IsNullOrEmpty(assembly.Culture));
		if (assembly == null || UTF8String.IsNullOrEmpty(assembly.Culture))
		{
			return null;
		}
		string text = FileUtils.RemoveExtension(rsrcName);
		string extension = FileUtils.GetExtension(rsrcName);
		string locName = string.Concat(text, ".", assembly.Culture, extension);
		EmbeddedResource er = module.Resources.OfType<EmbeddedResource>().FirstOrDefault((EmbeddedResource a) => StringComparer.Ordinal.Equals(a.Name, locName));
		ResourceElementSet resourceElementSet = TryCreateResourceElementSet(module, er);
		if (resourceElementSet == null)
		{
			return null;
		}
		string directoryName = Path.GetDirectoryName(nonSatFile.Filename);
		string path = ((Directory.Length + 1 > directoryName.Length) ? string.Empty : directoryName.Substring(Directory.Length + 1));
		text = Path.GetFileNameWithoutExtension(nonSatFile.Filename);
		extension = Path.GetExtension(nonSatFile.Filename);
		string filename = filenameCreator.CreateFromRelativePath(Path.Combine(path, text) + "." + assembly.Culture, extension);
		return CreateResXFile(module, er, resourceElementSet, filename, string.Empty, isSatellite: true);
	}

	private static ResourceElementSet TryCreateResourceElementSet(ModuleDef module, EmbeddedResource er)
	{
		if (er == null)
		{
			return null;
		}
		if (!ResourceReader.CouldBeResourcesFile(er.CreateReader()))
		{
			return null;
		}
		try
		{
			return ResourceReader.Read(module, er.CreateReader());
		}
		catch
		{
			return null;
		}
	}

	public IEnumerable<IJob> GetJobs()
	{
		if (ApplicationIcon != null)
		{
			yield return ApplicationIcon;
		}
		if (ApplicationManifest != null)
		{
			yield return ApplicationManifest;
		}
		foreach (ProjectFile file in Files)
		{
			yield return file;
		}
	}

	public void OnWrite()
	{
		string text = ((Options.Module.Assembly != null && Options.Module.IsManifestModule) ? Options.Module.Assembly.Name : null);
		foreach (BamlResourceProjectFile item in Files.OfType<BamlResourceProjectFile>())
		{
			foreach (IAssembly assemblyReference in item.AssemblyReferences)
			{
				if (text != null && !StringComparer.Ordinal.Equals(text, assemblyReference.Name))
				{
					ExtraAssemblyReferences.Add(assemblyReference.Name);
				}
			}
		}
	}
}
