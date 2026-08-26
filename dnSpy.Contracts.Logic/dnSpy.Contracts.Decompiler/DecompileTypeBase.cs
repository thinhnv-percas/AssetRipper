using System;

namespace dnSpy.Contracts.Decompiler;

public abstract class DecompileTypeBase
{
	public IDecompilerOutput Output { get; }

	public DecompilationContext Context { get; }

	protected DecompileTypeBase(IDecompilerOutput output, DecompilationContext ctx)
	{
		Output = output ?? throw new ArgumentNullException("output");
		Context = ctx ?? throw new ArgumentNullException("ctx");
	}
}
