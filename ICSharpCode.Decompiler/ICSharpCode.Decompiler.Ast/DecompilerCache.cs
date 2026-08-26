using ICSharpCode.Decompiler.Ast.Cache;
using ICSharpCode.Decompiler.Ast.Transforms;
using ICSharpCode.Decompiler.ILAst;

namespace ICSharpCode.Decompiler.Ast;

public sealed class DecompilerCache
{
	private readonly ObjectPool<IAstTransformPoolObject[]> pipelinePool;

	private readonly ObjectPool<ILAstBuilder> ilAstBuilderPool;

	private readonly ObjectPool<ILAstOptimizer> ilAstOptimizerPool;

	private readonly ObjectPool<GotoRemoval> gotoRemovalPool;

	private readonly ObjectPool<AstMethodBodyBuilder> astMethodBodyBuilderPool;

	public DecompilerCache(DecompilerContext ctx)
	{
		pipelinePool = new ObjectPool<IAstTransformPoolObject[]>(() => TransformationPipeline.CreatePipeline(ctx), null);
		ilAstBuilderPool = new ObjectPool<ILAstBuilder>(() => new ILAstBuilder(), delegate(ILAstBuilder a)
		{
			a.Reset();
		});
		ilAstOptimizerPool = new ObjectPool<ILAstOptimizer>(() => new ILAstOptimizer(), delegate(ILAstOptimizer a)
		{
			a.Reset();
		});
		gotoRemovalPool = new ObjectPool<GotoRemoval>(() => new GotoRemoval(ctx), delegate(GotoRemoval a)
		{
			a.Reset();
		});
		astMethodBodyBuilderPool = new ObjectPool<AstMethodBodyBuilder>(() => new AstMethodBodyBuilder(), delegate(AstMethodBodyBuilder a)
		{
			a.Reset();
		});
	}

	public void Reset()
	{
		pipelinePool.ReuseAllObjects();
		ilAstBuilderPool.ReuseAllObjects();
		ilAstOptimizerPool.ReuseAllObjects();
		gotoRemovalPool.ReuseAllObjects();
		astMethodBodyBuilderPool.ReuseAllObjects();
	}

	public IAstTransformPoolObject[] GetPipelinePool()
	{
		return pipelinePool.Allocate();
	}

	public void Return(IAstTransformPoolObject[] pipeline)
	{
		pipelinePool.Free(pipeline);
	}

	public ILAstBuilder GetILAstBuilder()
	{
		return ilAstBuilderPool.Allocate();
	}

	public void Return(ILAstBuilder builder)
	{
		ilAstBuilderPool.Free(builder);
	}

	public ILAstOptimizer GetILAstOptimizer()
	{
		return ilAstOptimizerPool.Allocate();
	}

	public void Return(ILAstOptimizer opt)
	{
		ilAstOptimizerPool.Free(opt);
	}

	public GotoRemoval GetGotoRemoval()
	{
		return gotoRemovalPool.Allocate();
	}

	public void Return(GotoRemoval gr)
	{
		gotoRemovalPool.Free(gr);
	}

	public AstMethodBodyBuilder GetAstMethodBodyBuilder()
	{
		return astMethodBodyBuilderPool.Allocate();
	}

	public void Return(AstMethodBodyBuilder builder)
	{
		astMethodBodyBuilderPool.Free(builder);
	}
}
