using System;

namespace dnSpy.Decompiler.ILSpy.Core.CSharp;

internal sealed class BuilderCache
{
	private readonly ThreadSafeObjectPool<AstBuilderState> astBuilderStatePool;

	private static readonly Action<AstBuilderState> resetAstBuilderState = delegate(AstBuilderState abs)
	{
		abs.Reset();
	};

	public BuilderCache(int settingsVersion)
	{
		astBuilderStatePool = new ThreadSafeObjectPool<AstBuilderState>(Environment.ProcessorCount, () => new AstBuilderState(settingsVersion), resetAstBuilderState);
	}

	public AstBuilderState AllocateAstBuilderState()
	{
		return astBuilderStatePool.Allocate();
	}

	public void Free(AstBuilderState state)
	{
		astBuilderStatePool.Free(state);
	}
}
