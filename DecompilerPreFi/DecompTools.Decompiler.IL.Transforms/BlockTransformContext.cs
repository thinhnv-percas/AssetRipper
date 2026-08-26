using DecompTools.Decompiler.FlowAnalysis;
using DecompTools.Decompiler.IL.ControlFlow;

namespace DecompTools.Decompiler.IL.Transforms;

public class BlockTransformContext : ILTransformContext
{
	public Block Block { get; set; }

	public ControlFlowNode ControlFlowNode { get; set; }

	public ControlFlowGraph ControlFlowGraph { get; set; }

	public BlockTransformContext(ILTransformContext context)
		: base(context)
	{
	}
}
