using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Threading;
using DecompTools.Decompiler.CSharp;
using DecompTools.Decompiler.DebugInfo;
using DecompTools.Decompiler.Disassembler;
using DecompTools.Decompiler.Metadata;
using DecompTools.Decompiler.TypeSystem;
using McMaster.Extensions.CommandLineUtils;

namespace DecompTools.Decompiler.Console;

[Command(Name = "DecompilerFi", Description = "s", ExtendedHelpText = "")]
[ProjectOptionRequiresOutputDirectoryValidation]
internal class ILSpyCmdProgram
{
	[FileExists]
	[Required]
	[Argument(0, "Assembly file name", "")]
	public string InputAssemblyName { get; }

	[DirectoryExists]
	[Option("-o|--outputdir <directory>", "", CommandOptionType.SingleValue)]
	public string OutputDirectory { get; }

	[Option("-p|--project", "", CommandOptionType.NoValue)]
	public bool CreateCompilableProjectFlag { get; }

	[Option("-t|--type <type-name>", ".", CommandOptionType.SingleValue)]
	public string TypeName { get; }

	public bool ShowILCodeFlag { get; }

	public bool CreateDebugInfoFlag { get; }

	public string[] EntityTypes { get; } = new string[0];

	public bool ShowVersion { get; }

	[DirectoryExists]
	[Option("-r|--referencepath <path>", ".", CommandOptionType.MultipleValue)]
	public string[] ReferencePaths { get; } = new string[0];

	[Option("-s|--skipfile <path>", "Newline-separated list of output file keys (from _wpd_progress.log) to skip instead of decompiling, for -p runs. See ROADMAP.md P1a.", CommandOptionType.SingleValue)]
	public string SkipFile { get; }

	public static int Main(string[] args)
	{
		// This is an unattended CLI tool: a failed Debug.Assert/Trace.Assert must never pop up
		// DefaultTraceListener's modal "Assertion Failed" dialog, which blocks the process
		// forever waiting for a human to click Abort/Retry/Ignore. Debug.Listeners and
		// Trace.Listeners are the same underlying collection, so clearing this one covers both.
		System.Diagnostics.Trace.Listeners.Clear();
		return CommandLineApplication.Execute<ILSpyCmdProgram>(args);
	}

	private int OnExecute(CommandLineApplication app)
	{
		TextWriter textWriter = System.Console.Out;
		bool flag = !string.IsNullOrEmpty(OutputDirectory);
		try
		{
			if (CreateCompilableProjectFlag)
			{
				DecompileAsProject(InputAssemblyName, OutputDirectory, ReferencePaths, SkipFile);
			}
			else if (EntityTypes.Any())
			{
				string[] values = EntityTypes.SelectMany((string v) => v.Split(',', ';')).ToArray();
				HashSet<TypeKind> kinds = TypesParser.ParseSelection(values);
				if (flag)
				{
					string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(InputAssemblyName);
					textWriter = File.CreateText(Path.Combine(OutputDirectory, fileNameWithoutExtension) + ".list.txt");
				}
				ListContent(InputAssemblyName, textWriter, kinds, ReferencePaths);
			}
			else if (ShowILCodeFlag)
			{
				if (flag)
				{
					string fileNameWithoutExtension2 = Path.GetFileNameWithoutExtension(InputAssemblyName);
					textWriter = File.CreateText(Path.Combine(OutputDirectory, fileNameWithoutExtension2) + ".il");
				}
				ShowIL(InputAssemblyName, textWriter, ReferencePaths);
			}
			else
			{
				if (CreateDebugInfoFlag)
				{
					string text = null;
					if (flag)
					{
						string fileNameWithoutExtension3 = Path.GetFileNameWithoutExtension(InputAssemblyName);
						text = Path.Combine(OutputDirectory, fileNameWithoutExtension3) + ".pdb";
					}
					else
					{
						text = Path.ChangeExtension(InputAssemblyName, ".pdb");
					}
					return GeneratePdbForAssembly(InputAssemblyName, text, ReferencePaths, app);
				}
				if (ShowVersion)
				{
					string value = "ilspycmd: " + typeof(ILSpyCmdProgram).Assembly.GetName().Version.ToString() + Environment.NewLine + "DecompTools.Decompiler: " + typeof(FullTypeName).Assembly.GetName().Version.ToString();
					textWriter.WriteLine(value);
				}
				else
				{
					if (flag)
					{
						string fileNameWithoutExtension4 = Path.GetFileNameWithoutExtension(InputAssemblyName);
						textWriter = File.CreateText(Path.Combine(OutputDirectory, (string.IsNullOrEmpty(TypeName) ? fileNameWithoutExtension4 : TypeName) + ".decompiled.cs"));
					}
					Decompile(InputAssemblyName, textWriter, ReferencePaths, TypeName);
				}
			}
		}
		catch (Exception ex)
		{
			app.Error.WriteLine(ex.ToString());
			return 70;
		}
		finally
		{
			textWriter.Close();
		}
		return 0;
	}

	private static CSharpDecompiler GetDecompiler(string assemblyFileName, string[] referencePaths)
	{
		PEFile pEFile = new PEFile(assemblyFileName);
		UniversalAssemblyResolver universalAssemblyResolver = new UniversalAssemblyResolver(assemblyFileName, throwOnError: false, pEFile.Reader.DetectTargetFrameworkId());
		foreach (string directory in referencePaths)
		{
			universalAssemblyResolver.AddSearchDirectory(directory);
		}
		return new CSharpDecompiler(assemblyFileName, universalAssemblyResolver, new DecompilerSettings());
	}

	private static void ListContent(string assemblyFileName, TextWriter output, ISet<TypeKind> kinds, string[] referencePaths)
	{
		CSharpDecompiler decompiler = GetDecompiler(assemblyFileName, referencePaths);
		foreach (ITypeDefinition typeDefinition in decompiler.TypeSystem.MainModule.TypeDefinitions)
		{
			if (kinds.Contains(typeDefinition.Kind))
			{
				output.WriteLine($"{typeDefinition.Kind} {typeDefinition.FullName}");
			}
		}
	}

	private static void ShowIL(string assemblyFileName, TextWriter output, string[] referencePaths)
	{
		CSharpDecompiler decompiler = GetDecompiler(assemblyFileName, referencePaths);
		ITextOutput textOutput = new PlainTextOutput();
		ReflectionDisassembler reflectionDisassembler = new ReflectionDisassembler(textOutput, CancellationToken.None);
		reflectionDisassembler.DisassembleNamespace(decompiler.TypeSystem.MainModule.RootNamespace.Name, decompiler.TypeSystem.MainModule.PEFile, decompiler.TypeSystem.MainModule.TypeDefinitions.Select((ITypeDefinition x) => (TypeDefinitionHandle)x.MetadataToken));
		output.WriteLine("// IL code: " + decompiler.TypeSystem.MainModule.AssemblyName);
		output.WriteLine(textOutput.ToString());
	}

	private static void DecompileAsProject(string assemblyFileName, string outputDirectory, string[] referencePaths, string skipFile)
	{
		WholeProjectDecompiler wholeProjectDecompiler = new WholeProjectDecompiler();
		PEFile pEFile = new PEFile(assemblyFileName);
		UniversalAssemblyResolver universalAssemblyResolver = new UniversalAssemblyResolver(assemblyFileName, throwOnError: false, pEFile.Reader.DetectTargetFrameworkId());
		foreach (string directory in referencePaths)
		{
			universalAssemblyResolver.AddSearchDirectory(directory);
		}
		wholeProjectDecompiler.AssemblyResolver = universalAssemblyResolver;
		if (!string.IsNullOrEmpty(skipFile) && File.Exists(skipFile))
		{
			wholeProjectDecompiler.SkipGroupKeys = new HashSet<string>(File.ReadAllLines(skipFile), StringComparer.OrdinalIgnoreCase);
		}
		wholeProjectDecompiler.DecompileProject(pEFile, outputDirectory);
	}

	private static void Decompile(string assemblyFileName, TextWriter output, string[] referencePaths, string typeName = null)
	{
		CSharpDecompiler decompiler = GetDecompiler(assemblyFileName, referencePaths);
		if (typeName == null)
		{
			output.Write(decompiler.DecompileWholeModuleAsString());
			return;
		}
		FullTypeName fullTypeName = new FullTypeName(typeName);
		output.Write(decompiler.DecompileTypeAsString(fullTypeName));
	}

	private static int GeneratePdbForAssembly(string assemblyFileName, string pdbFileName, string[] referencePaths, CommandLineApplication app)
	{
		PEFile file = new PEFile(assemblyFileName, new FileStream(assemblyFileName, FileMode.Open, FileAccess.Read), PEStreamOptions.PrefetchEntireImage, MetadataReaderOptions.None);
		if (!PortablePdbWriter.HasCodeViewDebugDirectoryEntry(file))
		{
			app.Error.WriteLine("Cannot create PDB file for " + assemblyFileName + ", because it does not contain a PE Debug Directory Entry of type 'CodeView'.");
			return 65;
		}
		using (FileStream targetStream = new FileStream(pdbFileName, FileMode.OpenOrCreate, FileAccess.Write))
		{
			CSharpDecompiler decompiler = GetDecompiler(assemblyFileName, referencePaths);
			PortablePdbWriter.WritePdb(file, decompiler, new DecompilerSettings
			{
				ThrowOnAssemblyResolveErrors = false
			}, targetStream);
		}
		return 0;
	}
}
