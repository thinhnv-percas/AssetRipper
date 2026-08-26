namespace ICSharpCode.NRefactory.CSharp.Analysis
{
	public enum DefiniteAssignmentStatus
	{
		PotentiallyAssigned,
		DefinitelyAssigned,
		AssignedAfterTrueExpression,
		AssignedAfterFalseExpression,
		CodeUnreachable
	}
}
