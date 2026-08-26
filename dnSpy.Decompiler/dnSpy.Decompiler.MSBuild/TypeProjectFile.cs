using System;
using System.IO;
using System.Text;
using dnlib.DotNet;
using dnSpy.Contracts.Decompiler;
using dnSpy.Decompiler.Properties;

namespace dnSpy.Decompiler.MSBuild;

internal class TypeProjectFile : ProjectFile
{
	private readonly string filename;

	protected readonly DecompilationContext decompilationContext;

	protected readonly IDecompiler decompiler;

	private readonly Func<TextWriter, IDecompilerOutput> createDecompilerOutput;

	public override string Description => string.Format(dnSpy_Decompiler_Resources.MSBuild_DecompileType, Type.FullName);

	public override BuildAction BuildAction => BuildAction.Compile;

	public override string Filename => filename;

	public TypeDef Type { get; }

	public TypeProjectFile(TypeDef type, string filename, DecompilationContext decompilationContext, IDecompiler decompiler, Func<TextWriter, IDecompilerOutput> createDecompilerOutput)
	{
		Type = type;
		this.filename = filename;
		this.decompilationContext = decompilationContext;
		this.decompiler = decompiler;
		this.createDecompilerOutput = createDecompilerOutput;
	}

	public override void Create(DecompileContext ctx)
	{
		using StreamWriter arg = new StreamWriter(Filename, append: false, Encoding.UTF8);
		IDecompilerOutput output = createDecompilerOutput(arg);
		Decompile(ctx, output);
	}

	protected virtual void Decompile(DecompileContext ctx, IDecompilerOutput output)
	{
		decompiler.Decompile(Type, output, decompilationContext);
	}
}
