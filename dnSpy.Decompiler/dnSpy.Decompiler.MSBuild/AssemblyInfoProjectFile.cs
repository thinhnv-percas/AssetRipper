using System;
using System.IO;
using System.Text;
using dnlib.DotNet;
using dnSpy.Contracts.Decompiler;
using dnSpy.Decompiler.Properties;

namespace dnSpy.Decompiler.MSBuild;

internal sealed class AssemblyInfoProjectFile : ProjectFile
{
	private readonly ModuleDef module;

	private readonly DecompilationContext decompilationContext;

	private readonly IDecompiler decompiler;

	private readonly Func<TextWriter, IDecompilerOutput> createDecompilerOutput;

	public override string Description => string.Format(dnSpy_Decompiler_Resources.MSBuild_DecompileAssemblyInfoAndFileExtension, decompiler.FileExtension);

	public override BuildAction BuildAction => BuildAction.Compile;

	public override string Filename { get; }

	public AssemblyInfoProjectFile(ModuleDef module, string filename, DecompilationContext decompilationContext, IDecompiler decompiler, Func<TextWriter, IDecompilerOutput> createDecompilerOutput)
	{
		this.module = module;
		Filename = filename;
		this.decompilationContext = decompilationContext;
		this.decompiler = decompiler;
		this.createDecompilerOutput = createDecompilerOutput;
	}

	public override void Create(DecompileContext ctx)
	{
		using StreamWriter arg = new StreamWriter(Filename, append: false, Encoding.UTF8);
		IDecompilerOutput output = createDecompilerOutput(arg);
		decompiler.Decompile(DecompilationType.AssemblyInfo, new DecompileAssemblyInfo(output, decompilationContext, module));
	}
}
