using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using DecompTools.Decompiler.CSharp.OutputVisitor;
using DecompTools.Decompiler.CSharp.Syntax;
using DecompTools.Decompiler.CSharp.Transforms;
using DecompTools.Decompiler.Metadata;
using DecompTools.Decompiler.TypeSystem;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.CSharp;

public class WholeProjectDecompiler
{
	private enum LanguageTargets
	{
		None,
		Portable
	}

	private DecompilerSettings settings = new DecompilerSettings();

	private LanguageVersion? languageVersion;

	private HashSet<string> directories = new HashSet<string>((IEqualityComparer<string>)Platform.FileNameComparer);

	protected string targetDirectory;

	public DecompilerSettings Settings
	{
		get
		{
			return settings;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException();
			}
			settings = value;
		}
	}

	public LanguageVersion LanguageVersion
	{
		get
		{
			return languageVersion ?? Settings.GetMinimumRequiredVersion();
		}
		set
		{
			LanguageVersion minimumRequiredVersion = Settings.GetMinimumRequiredVersion();
			if (value < minimumRequiredVersion)
			{
				throw new InvalidOperationException($"The chosen settings require at least {minimumRequiredVersion}." + " Please change the DecompilerSettings accordingly.");
			}
			languageVersion = value;
		}
	}

	public IAssemblyResolver AssemblyResolver { get; set; }

	public Guid? ProjectGuid { get; set; }

	public int MaxDegreeOfParallelism { get; set; } = Environment.ProcessorCount;

	public void DecompileProject(PEFile moduleDefinition, string targetDirectory, CancellationToken cancellationToken = default(CancellationToken))
	{
		string path = Path.Combine(targetDirectory, CleanUpFileName(moduleDefinition.Name) + ".csproj");
		using StreamWriter projectFileWriter = new StreamWriter(path);
		DecompileProject(moduleDefinition, targetDirectory, projectFileWriter, cancellationToken);
	}

	public void DecompileProject(PEFile moduleDefinition, string targetDirectory, TextWriter projectFileWriter, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (string.IsNullOrEmpty(targetDirectory))
		{
			throw new InvalidOperationException("Must set TargetDirectory");
		}
		this.targetDirectory = targetDirectory;
		directories.Clear();
		List<Tuple<string, string>> list = Enumerable.ToList<Tuple<string, string>>(WriteCodeFilesInProject(moduleDefinition, cancellationToken));
		list.AddRange(WriteResourceFilesInProject(moduleDefinition));
		WriteProjectFile(projectFileWriter, list, moduleDefinition);
	}

	private void WriteProjectFile(TextWriter writer, IEnumerable<Tuple<string, string>> files, PEFile module)
	{
		string platformName = GetPlatformName(module);
		Guid guid = ProjectGuid ?? Guid.NewGuid();
		using XmlTextWriter xmlTextWriter = new XmlTextWriter(writer);
		xmlTextWriter.Formatting = Formatting.Indented;
		xmlTextWriter.WriteStartDocument();
		xmlTextWriter.WriteStartElement("Project", "http://schemas.microsoft.com/developer/msbuild/2003");
		xmlTextWriter.WriteAttributeString("ToolsVersion", "4.0");
		xmlTextWriter.WriteAttributeString("DefaultTargets", "Build");
		xmlTextWriter.WriteStartElement("PropertyGroup");
		xmlTextWriter.WriteElementString("ProjectGuid", guid.ToString("B").ToUpperInvariant());
		xmlTextWriter.WriteStartElement("Configuration");
		xmlTextWriter.WriteAttributeString("Condition", " '$(Configuration)' == '' ");
		xmlTextWriter.WriteValue("Debug");
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteStartElement("Platform");
		xmlTextWriter.WriteAttributeString("Condition", " '$(Platform)' == '' ");
		xmlTextWriter.WriteValue(platformName);
		xmlTextWriter.WriteEndElement();
		if (module.Reader.PEHeaders.IsDll)
		{
			xmlTextWriter.WriteElementString("OutputType", "Library");
		}
		else
		{
			switch (module.Reader.PEHeaders.PEHeader.Subsystem)
			{
			case Subsystem.WindowsGui:
				xmlTextWriter.WriteElementString("OutputType", "WinExe");
				break;
			case Subsystem.WindowsCui:
				xmlTextWriter.WriteElementString("OutputType", "Exe");
				break;
			default:
				xmlTextWriter.WriteElementString("OutputType", "Library");
				break;
			}
		}
		xmlTextWriter.WriteElementString("LangVersion", LanguageVersion.ToString().Replace("CSharp", "").Replace('_', '.'));
		xmlTextWriter.WriteElementString("AssemblyName", module.Name);
		bool flag = false;
		LanguageTargets languageTargets = LanguageTargets.None;
		string text = module.Reader.DetectTargetFrameworkId();
		if (!string.IsNullOrEmpty(text))
		{
			string[] array = text.Split(new char[1] { ',' });
			string text2 = array.FirstOrDefault((string a) => !a.StartsWith("Version=", StringComparison.OrdinalIgnoreCase) && !a.StartsWith("Profile=", StringComparison.OrdinalIgnoreCase));
			if (text2 != null)
			{
				xmlTextWriter.WriteElementString("TargetFrameworkIdentifier", text2);
				string text3 = text2;
				if (text3 == ".NETPortable")
				{
					languageTargets = LanguageTargets.Portable;
				}
			}
			string text4 = array.FirstOrDefault((string a) => a.StartsWith("Version=", StringComparison.OrdinalIgnoreCase));
			if (text4 != null)
			{
				xmlTextWriter.WriteElementString("TargetFrameworkVersion", text4.Substring("Version=".Length));
				flag = true;
			}
			string text5 = array.FirstOrDefault((string a) => a.StartsWith("Profile=", StringComparison.OrdinalIgnoreCase));
			if (text5 != null)
			{
				xmlTextWriter.WriteElementString("TargetFrameworkProfile", text5.Substring("Profile=".Length));
			}
		}
		if (!flag)
		{
			switch (module.GetRuntime())
			{
			case TargetRuntime.Net_1_0:
				xmlTextWriter.WriteElementString("TargetFrameworkVersion", "v1.0");
				break;
			case TargetRuntime.Net_1_1:
				xmlTextWriter.WriteElementString("TargetFrameworkVersion", "v1.1");
				break;
			case TargetRuntime.Net_2_0:
				xmlTextWriter.WriteElementString("TargetFrameworkVersion", "v2.0");
				break;
			default:
				xmlTextWriter.WriteElementString("TargetFrameworkVersion", "v4.0");
				break;
			}
		}
		xmlTextWriter.WriteElementString("WarningLevel", "4");
		xmlTextWriter.WriteElementString("AllowUnsafeBlocks", "True");
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteStartElement("PropertyGroup");
		xmlTextWriter.WriteAttributeString("Condition", " '$(Platform)' == '" + platformName + "' ");
		xmlTextWriter.WriteElementString("PlatformTarget", platformName);
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteStartElement("PropertyGroup");
		xmlTextWriter.WriteAttributeString("Condition", " '$(Configuration)' == 'Debug' ");
		xmlTextWriter.WriteElementString("OutputPath", "bin\\Debug\\");
		xmlTextWriter.WriteElementString("DebugSymbols", "true");
		xmlTextWriter.WriteElementString("DebugType", "full");
		xmlTextWriter.WriteElementString("Optimize", "false");
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteStartElement("PropertyGroup");
		xmlTextWriter.WriteAttributeString("Condition", " '$(Configuration)' == 'Release' ");
		xmlTextWriter.WriteElementString("OutputPath", "bin\\Release\\");
		xmlTextWriter.WriteElementString("DebugSymbols", "true");
		xmlTextWriter.WriteElementString("DebugType", "pdbonly");
		xmlTextWriter.WriteElementString("Optimize", "true");
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteStartElement("ItemGroup");
		foreach (DecompTools.Decompiler.Metadata.AssemblyReference assemblyReference in module.AssemblyReferences)
		{
			if (assemblyReference.Name != "mscorlib")
			{
				xmlTextWriter.WriteStartElement("Reference");
				xmlTextWriter.WriteAttributeString("Include", assemblyReference.Name);
				PEFile pEFile = AssemblyResolver.Resolve(assemblyReference);
				if (!IsGacAssembly(assemblyReference, pEFile) && pEFile != null)
				{
					xmlTextWriter.WriteElementString("HintPath", pEFile.FileName);
				}
				xmlTextWriter.WriteEndElement();
			}
		}
		xmlTextWriter.WriteEndElement();
		foreach (IGrouping<string, string> item in (IEnumerable<IGrouping<string, string>>)Enumerable.OrderBy<IGrouping<string, string>, string>(Enumerable.GroupBy<Tuple<string, string>, string, string>(files, (Func<Tuple<string, string>, string>)((Tuple<string, string> f) => f.Item1), (Func<Tuple<string, string>, string>)((Tuple<string, string> f) => f.Item2)), (Func<IGrouping<string, string>, string>)((IGrouping<string, string> g) => g.Key)))
		{
			xmlTextWriter.WriteStartElement("ItemGroup");
			foreach (string item2 in (IEnumerable<string>)Enumerable.OrderBy<string, string>((IEnumerable<string>)item, (Func<string, string>)((string f) => f), (IComparer<string>)StringComparer.OrdinalIgnoreCase))
			{
				xmlTextWriter.WriteStartElement(item.Key);
				xmlTextWriter.WriteAttributeString("Include", item2);
				xmlTextWriter.WriteEndElement();
			}
			xmlTextWriter.WriteEndElement();
		}
		LanguageTargets languageTargets2 = languageTargets;
		if (languageTargets2 == LanguageTargets.Portable)
		{
			xmlTextWriter.WriteStartElement("Import");
			xmlTextWriter.WriteAttributeString("Project", "$(MSBuildExtensionsPath32)\\Microsoft\\Portable\\$(TargetFrameworkVersion)\\Microsoft.Portable.CSharp.targets");
			xmlTextWriter.WriteEndElement();
		}
		else
		{
			xmlTextWriter.WriteStartElement("Import");
			xmlTextWriter.WriteAttributeString("Project", "$(MSBuildToolsPath)\\Microsoft.CSharp.targets");
			xmlTextWriter.WriteEndElement();
		}
		xmlTextWriter.WriteEndDocument();
	}

	protected virtual bool IsGacAssembly(IAssemblyReference r, PEFile asm)
	{
		return false;
	}

	protected virtual bool IncludeTypeWhenDecompilingProject(PEFile module, TypeDefinitionHandle type)
	{
		MetadataReader metadata = module.Metadata;
		TypeDefinition typeDefinition = metadata.GetTypeDefinition(type);
		if (metadata.GetString(typeDefinition.Name) == "<Module>" || CSharpDecompiler.MemberIsHidden(module, type, settings))
		{
			return false;
		}
		if (metadata.GetString(typeDefinition.Namespace) == "XamlGeneratedNamespace" && metadata.GetString(typeDefinition.Name) == "GeneratedInternalTypeHelper")
		{
			return false;
		}
		return true;
	}

	private CSharpDecompiler CreateDecompiler(DecompilerTypeSystem ts)
	{
		CSharpDecompiler cSharpDecompiler = new CSharpDecompiler(ts, settings);
		cSharpDecompiler.AstTransforms.Add(new EscapeInvalidIdentifiers());
		cSharpDecompiler.AstTransforms.Add(new RemoveCLSCompliantAttribute());
		return cSharpDecompiler;
	}

	private IEnumerable<Tuple<string, string>> WriteAssemblyInfo(DecompilerTypeSystem ts, CancellationToken cancellationToken)
	{
		CSharpDecompiler cSharpDecompiler = CreateDecompiler(ts);
		cSharpDecompiler.CancellationToken = cancellationToken;
		cSharpDecompiler.AstTransforms.Add(new RemoveCompilerGeneratedAssemblyAttributes());
		SyntaxTree syntaxTree = cSharpDecompiler.DecompileModuleAndAssemblyAttributes();
		if (directories.Add("Properties"))
		{
			Directory.CreateDirectory(Path.Combine(targetDirectory, "Properties"));
		}
		string text = Path.Combine("Properties", "AssemblyInfo.cs");
		using (StreamWriter textWriter = new StreamWriter(Path.Combine(targetDirectory, text)))
		{
			syntaxTree.AcceptVisitor(new CSharpOutputVisitor(textWriter, settings.CSharpFormattingOptions));
		}
		return new Tuple<string, string>[1] { Tuple.Create("Compile", text) };
	}

	private IEnumerable<Tuple<string, string>> WriteCodeFilesInProject(PEFile module, CancellationToken cancellationToken)
	{
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected O, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		MetadataReader metadata = module.Metadata;
		List<IGrouping<string, TypeDefinitionHandle>> list = Enumerable.ToList<IGrouping<string, TypeDefinitionHandle>>(Enumerable.GroupBy<TypeDefinitionHandle, string>(Enumerable.Where<TypeDefinitionHandle>(module.Metadata.GetTopLevelTypeDefinitions(), (Func<TypeDefinitionHandle, bool>)((TypeDefinitionHandle td) => IncludeTypeWhenDecompilingProject(module, td))), (Func<TypeDefinitionHandle, string>)delegate(TypeDefinitionHandle h)
		{
			TypeDefinition typeDefinition = metadata.GetTypeDefinition(h);
			string text = CleanUpFileName(metadata.GetString(typeDefinition.Name)) + ".cs";
			if (string.IsNullOrEmpty(metadata.GetString(typeDefinition.Namespace)))
			{
				return text;
			}
			string text2 = CleanUpFileName(metadata.GetString(typeDefinition.Namespace));
			if (directories.Add(text2))
			{
				Directory.CreateDirectory(Path.Combine(targetDirectory, text2));
			}
			return Path.Combine(text2, text);
		}, (IEqualityComparer<string>)StringComparer.OrdinalIgnoreCase));
		DecompilerTypeSystem ts = new DecompilerTypeSystem(module, AssemblyResolver, settings);
		Parallel.ForEach<IGrouping<string, TypeDefinitionHandle>>((IEnumerable<IGrouping<string, TypeDefinitionHandle>>)list, new ParallelOptions
		{
			MaxDegreeOfParallelism = MaxDegreeOfParallelism,
			CancellationToken = cancellationToken
		}, (Action<IGrouping<string, TypeDefinitionHandle>>)delegate(IGrouping<string, TypeDefinitionHandle> file)
		{
			using StreamWriter textWriter = new StreamWriter(Path.Combine(targetDirectory, file.Key));
			CSharpDecompiler cSharpDecompiler = CreateDecompiler(ts);
			cSharpDecompiler.CancellationToken = cancellationToken;
			SyntaxTree syntaxTree = cSharpDecompiler.DecompileTypes(Enumerable.ToArray<TypeDefinitionHandle>((IEnumerable<TypeDefinitionHandle>)file));
			syntaxTree.AcceptVisitor(new CSharpOutputVisitor(textWriter, settings.CSharpFormattingOptions));
		});
		return Enumerable.Concat<Tuple<string, string>>(Enumerable.Select<IGrouping<string, TypeDefinitionHandle>, Tuple<string, string>>((IEnumerable<IGrouping<string, TypeDefinitionHandle>>)list, (Func<IGrouping<string, TypeDefinitionHandle>, Tuple<string, string>>)((IGrouping<string, TypeDefinitionHandle> f) => Tuple.Create("Compile", f.Key))), WriteAssemblyInfo(ts, cancellationToken));
	}

	protected virtual IEnumerable<Tuple<string, string>> WriteResourceFilesInProject(PEFile module)
	{
		foreach (Resource r in module.Resources.Where((Resource resource) => resource.ResourceType == ResourceType.Embedded))
		{
			Stream stream = r.TryOpenStream();
			stream.Position = 0L;
			if (r.Name.EndsWith(".resources", StringComparison.OrdinalIgnoreCase))
			{
				List<Tuple<string, string>> individualResources = new List<Tuple<string, string>>();
				bool decodedIntoIndividualFiles;
				try
				{
					ResourcesFile resourcesFile = new ResourcesFile(stream);
					if (resourcesFile.AllEntriesAreStreams())
					{
						foreach (var (name, value) in resourcesFile)
						{
							string fileName = Path.Combine(Enumerable.ToArray<string>(Enumerable.Select<string, string>((IEnumerable<string>)name.Split(new char[1] { '/' }), (Func<string, string>)((string p) => CleanUpFileName(p)))));
							string dirName = Path.GetDirectoryName(fileName);
							if (!string.IsNullOrEmpty(dirName) && directories.Add(dirName))
							{
								Directory.CreateDirectory(Path.Combine(targetDirectory, dirName));
							}
							Stream entryStream = (Stream)value;
							entryStream.Position = 0L;
							individualResources.AddRange(WriteResourceToFile(fileName, name, entryStream));
						}
						decodedIntoIndividualFiles = true;
					}
					else
					{
						decodedIntoIndividualFiles = false;
					}
				}
				catch (BadImageFormatException)
				{
					decodedIntoIndividualFiles = false;
				}
				if (decodedIntoIndividualFiles)
				{
					foreach (Tuple<string, string> item in individualResources)
					{
						yield return item;
					}
					continue;
				}
				stream.Position = 0L;
				string fileName2 = GetFileNameForResource(r.Name);
				foreach (Tuple<string, string> item2 in WriteResourceToFile(fileName2, r.Name, stream))
				{
					yield return item2;
				}
			}
			else
			{
				string fileName3 = GetFileNameForResource(r.Name);
				using (FileStream fs = new FileStream(Path.Combine(targetDirectory, fileName3), FileMode.Create, FileAccess.Write))
				{
					stream.Position = 0L;
					stream.CopyTo(fs);
				}
				yield return Tuple.Create("EmbeddedResource", fileName3);
			}
		}
	}

	protected virtual IEnumerable<Tuple<string, string>> WriteResourceToFile(string fileName, string resourceName, Stream entryStream)
	{
		if (fileName.EndsWith(".resources", StringComparison.OrdinalIgnoreCase))
		{
			string text = Path.ChangeExtension(fileName, ".resx");
			try
			{
				using (FileStream stream = new FileStream(Path.Combine(targetDirectory, text), FileMode.Create, FileAccess.Write))
				{
					using ResXResourceWriter resXResourceWriter = new ResXResourceWriter(stream);
					foreach (KeyValuePair<string, object> item in new ResourcesFile(entryStream))
					{
						resXResourceWriter.AddResource(item.Key, item.Value);
					}
				}
				return new Tuple<string, string>[1] { Tuple.Create("EmbeddedResource", text) };
			}
			catch (BadImageFormatException)
			{
			}
		}
		using (FileStream destination = new FileStream(Path.Combine(targetDirectory, fileName), FileMode.Create, FileAccess.Write))
		{
			entryStream.CopyTo(destination);
		}
		return new Tuple<string, string>[1] { Tuple.Create("EmbeddedResource", fileName) };
	}

	private string GetFileNameForResource(string fullName)
	{
		string[] array = fullName.Split(new char[1] { '.' });
		string result = CleanUpFileName(fullName);
		checked
		{
			for (int num = array.Length - 1; num > 0; num--)
			{
				string text = string.Join(".", array, 0, num);
				if (directories.Contains(text))
				{
					string text2 = string.Join(".", array, num, array.Length - num);
					result = Path.Combine(text, CleanUpFileName(text2));
					break;
				}
			}
			return result;
		}
	}

	public static string CleanUpFileName(string text)
	{
		int num = text.IndexOf(':');
		if (num > 0)
		{
			text = text.Substring(0, num);
		}
		num = text.IndexOf('`');
		if (num > 0)
		{
			text = text.Substring(0, num);
		}
		text = text.Trim();
		StringBuilder stringBuilder = new StringBuilder(text.Length);
		string text2 = text;
		foreach (char c in text2)
		{
			if (char.IsLetterOrDigit(c) || c == '-' || c == '_')
			{
				stringBuilder.Append(c);
			}
			else if (c == '.' && stringBuilder.Length > 0 && stringBuilder[checked(stringBuilder.Length - 1)] != '.')
			{
				stringBuilder.Append('.');
			}
			else
			{
				stringBuilder.Append('-');
			}
			if (stringBuilder.Length >= 200)
			{
				break;
			}
		}
		if (stringBuilder.Length == 0)
		{
			stringBuilder.Append('-');
		}
		return stringBuilder.ToString();
	}

	public static string GetPlatformName(PEFile module)
	{
		PEHeaders pEHeaders = module.Reader.PEHeaders;
		switch (pEHeaders.CoffHeader.Machine)
		{
		case Machine.I386:
			if ((pEHeaders.CorHeader.Flags & CorFlags.Prefers32Bit) != 0)
			{
				return "AnyCPU";
			}
			if ((pEHeaders.CorHeader.Flags & CorFlags.Requires32Bit) != 0)
			{
				return "x86";
			}
			return "AnyCPU";
		case Machine.Amd64:
			return "x64";
		case Machine.IA64:
			return "Itanium";
		default:
			return pEHeaders.CoffHeader.Machine.ToString();
		}
	}
}
