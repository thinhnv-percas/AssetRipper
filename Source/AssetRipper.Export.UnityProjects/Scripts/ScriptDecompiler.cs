using AsmResolver.DotNet;
using AssetRipper.Export.Scripts;
using AssetRipper.Import.Configuration;
using AssetRipper.Import.Logging;
using AssetRipper.Import.Structure.Assembly;
using AssetRipper.Import.Structure.Assembly.Managers;
using ICSharpCode.Decompiler;
using ICSharpCode.Decompiler.CSharp;
using ICSharpCode.Decompiler.CSharp.ProjectDecompiler;
using ICSharpCode.Decompiler.Metadata;
using MetadataTypeDefinition = System.Reflection.Metadata.TypeDefinition;
using MetadataTypeDefinitionHandle = System.Reflection.Metadata.TypeDefinitionHandle;
using System.Text.RegularExpressions;

namespace AssetRipper.Export.UnityProjects.Scripts;

internal class ScriptDecompiler
{
	private readonly ILSpyAssemblyResolver assemblyResolver;
	public LanguageVersion LanguageVersion { get; set; } = LanguageVersion.CSharp7_3;
	public ScriptContentLevel ScriptContentLevel { get; set; } = ScriptContentLevel.Level2;
	public ScriptingBackend ScriptingBackend { get; set; } = ScriptingBackend.Unknown;
	public bool FullyQualifiedTypeNames { get; set; } = false;

	public ScriptDecompiler(IAssemblyManager assemblyManager) : this(new ILSpyAssemblyResolver(assemblyManager), assemblyManager.ScriptingBackend) { }
	private ScriptDecompiler(ILSpyAssemblyResolver assemblyResolver, ScriptingBackend scriptingBackend)
	{
		this.assemblyResolver = assemblyResolver;
		ScriptingBackend = scriptingBackend;
	}

	public void DecompileWholeProject(AssemblyDefinition assembly, string outputFolder, FileSystem fileSystem)
	{
		DecompilerSettings settings = new();

		settings.SetLanguageVersion(LanguageVersion);

		settings.AlwaysShowEnumMemberValues = true;
		settings.ShowXmlDocumentation = true;

		settings.UseNestedDirectoriesForNamespaces = true;

		if (FullyQualifiedTypeNames)
		{
			settings.AlwaysUseGlobal = true;
			settings.UsingDeclarations = false;
		}

		CustomWholeProjectDecompiler decompiler = new(settings, assemblyResolver, fileSystem);

		DecompileWholeProject(decompiler, assembly, outputFolder);
	}

	/// <summary>How many types may be skipped before an assembly is given up on.</summary>
	private const int MaximumSkippedTypes = 16;

	private void DecompileWholeProject(WholeProjectDecompiler decompiler, AssemblyDefinition assembly, string outputFolder)
	{
		// ILSpy decompiles an assembly as one parallel unit, so a single type it cannot read throws out
		// of the whole thing and every remaining file in this assembly goes unwritten. It names the file
		// it failed on, so the type behind it is skipped and the assembly is decompiled again: one bad
		// type then costs itself rather than everything after it.
		HashSet<string> skipped = new(StringComparer.OrdinalIgnoreCase);
		Exception? lastFailure = null;

		while (skipped.Count <= MaximumSkippedTypes)
		{
			try
			{
				if (decompiler is CustomWholeProjectDecompiler custom)
				{
					custom.SkippedTypePaths = skipped;
				}

				decompiler.DecompileProject(assemblyResolver.Resolve(assembly), outputFolder, TextWriter.Null);

				if (skipped.Count > 0)
				{
					Logger.Warning(LogCategory.Export,
						$"Decompilation of '{assembly.Name}' needed {skipped.Count} type(s) skipped before it would finish: " +
						$"{string.Join(", ", skipped)}. Those types have no scripts; everything else in the assembly does.");
				}

				return;
			}
			catch (Exception exception)
			{
				lastFailure = exception;

				int before = skipped.Count;

				foreach (string path in FailingFilePaths(exception))
				{
					skipped.Add(path);
				}

				if (skipped.Count == before)
				{
					break; // nothing new to skip, so retrying would fail the same way
				}
			}
		}

		Logger.Error(LogCategory.Export,
			$"Decompilation of '{assembly.Name}' was abandoned part way through, so its scripts are incomplete" +
			(skipped.Count > 0 ? $" even with {string.Join(", ", skipped)} skipped" : "") +
			". The methods named below are the ones ILSpy could not read.");

		if (lastFailure is not null)
		{
			Logger.Error(lastFailure);
		}
	}

	/// <summary>The source paths ILSpy names in a decompilation failure, without their extension.</summary>
	private static IEnumerable<string> FailingFilePaths(Exception exception)
	{
		foreach (Match match in Regex.Matches(exception.ToString(), @"Error decompiling for '([^']+)'"))
		{
			string path = match.Groups[1].Value.Replace('\\', '/');

			if (path.EndsWith(".cs", StringComparison.OrdinalIgnoreCase))
			{
				path = path[..^3];
			}

			if (path.Length > 0)
			{
				yield return path;
			}
		}
	}

	private sealed class CustomWholeProjectDecompiler(DecompilerSettings settings, ILSpyAssemblyResolver assemblyResolver, FileSystem fileSystem) : ILSpyWholeProjectDecompiler(settings, assemblyResolver, NullProjectFileWriter.Instance, fileSystem)
	{
		/// <summary>Namespace-and-name paths of the types to leave out of this run.</summary>
		public HashSet<string> SkippedTypePaths { get; set; } = new(StringComparer.OrdinalIgnoreCase);

		protected override bool IncludeTypeWhenDecompilingProject(MetadataFile module, MetadataTypeDefinitionHandle type)
		{
			if (SkippedTypePaths.Count > 0 && SkippedTypePaths.Contains(PathFor(module, type)))
			{
				return false;
			}

			return base.IncludeTypeWhenDecompilingProject(module, type);
		}

		/// <summary>Where ILSpy would put this type, as namespace directories and the type's own name.</summary>
		private static string PathFor(MetadataFile module, MetadataTypeDefinitionHandle handle)
		{
			MetadataTypeDefinition definition = module.Metadata.GetTypeDefinition(handle);
			string name = module.Metadata.GetString(definition.Name);
			string containingNamespace = module.Metadata.GetString(definition.Namespace);

			int arity = name.IndexOf('`');
			if (arity >= 0)
			{
				name = name[..arity];
			}

			return string.IsNullOrEmpty(containingNamespace) ? name : containingNamespace.Replace('.', '/') + '/' + name;
		}

		protected override TextWriter CreateFile(string path)
		{
			if (FileSystem.Path.GetFileName(path) is "UnitySourceGeneratedAssemblyMonoScriptTypes_v1.cs")
			{
				// UnitySourceGeneratedAssemblyMonoScriptTypes_v1 is generated by Unity and should not be decompiled
				return TextWriter.Null;
			}

			return base.CreateFile(path);
		}
	}
}
