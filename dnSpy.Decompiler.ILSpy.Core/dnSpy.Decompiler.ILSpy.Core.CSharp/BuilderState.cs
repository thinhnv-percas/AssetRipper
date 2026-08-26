using System;
using dnSpy.Contracts.Decompiler;
using ICSharpCode.Decompiler.Ast;

namespace dnSpy.Decompiler.ILSpy.Core.CSharp;

internal struct BuilderState : IDisposable
{
	public readonly AstBuilderState State;

	private readonly BuilderCache cache;

	public AstBuilder AstBuilder => State.AstBuilder;

	public BuilderState(DecompilationContext ctx, BuilderCache cache, MetadataTextColorProvider metadataTextColorProvider)
	{
		this.cache = cache;
		State = cache.AllocateAstBuilderState();
		State.AstBuilder.Context.CalculateILSpans = ctx.CalculateILSpans;
		State.AstBuilder.Context.MetadataTextColorProvider = metadataTextColorProvider;
		State.AstBuilder.Context.AsyncMethodBodyDecompilation = ctx.AsyncMethodBodyDecompilation;
	}

	public void Dispose()
	{
		cache.Free(State);
	}
}
