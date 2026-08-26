namespace ICSharpCode.Decompiler.FlowAnalysis;

public sealed class ControlFlowEdge
{
	public readonly ControlFlowNode Source;

	public readonly ControlFlowNode Target;

	public readonly JumpType Type;

	public ControlFlowEdge(ControlFlowNode source, ControlFlowNode target, JumpType type)
	{
		Source = source;
		Target = target;
		Type = type;
	}

	public override string ToString()
	{
		return Type switch
		{
			JumpType.Normal => "#" + Target.BlockIndex, 
			JumpType.JumpToExceptionHandler => "e:#" + Target.BlockIndex, 
			_ => Type.ToString() + ":#" + Target.BlockIndex, 
		};
	}
}
