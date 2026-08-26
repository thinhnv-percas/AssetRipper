using System;
using dnlib.DotNet;

namespace dnSpy.Contracts.Decompiler;

public sealed class DecompileAssemblyInfo : DecompileTypeBase
{
	public ModuleDef Module { get; }

	public bool KeepAllAttributes { get; set; }

	public DecompileAssemblyInfo(IDecompilerOutput output, DecompilationContext ctx, ModuleDef module)
		: base(output, ctx)
	{
		Module = module ?? throw new ArgumentNullException("module");
		KeepAllAttributes = false;
	}
}
