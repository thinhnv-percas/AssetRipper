namespace ICSharpCode.Decompiler.FlowAnalysis
{
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
			switch (Type)
			{
			case JumpType.Normal:
				return "#" + Target.BlockIndex;
			case JumpType.JumpToExceptionHandler:
				return "e:#" + Target.BlockIndex;
			default:
				return Type.ToString() + ":#" + Target.BlockIndex;
			}
		}
	}
}
