namespace ICSharpCode.NRefactory.CSharp.Analysis
{
	public enum NullValueStatus
	{
		Unknown,
		CapturedUnknown,
		Unassigned,
		DefinitelyNull,
		PotentiallyNull,
		DefinitelyNotNull,
		UnreachableOrInexistent,
		Error
	}
}
