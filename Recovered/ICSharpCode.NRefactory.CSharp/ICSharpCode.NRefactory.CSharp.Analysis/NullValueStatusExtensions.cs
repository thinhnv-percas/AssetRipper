namespace ICSharpCode.NRefactory.CSharp.Analysis
{
	public static class NullValueStatusExtensions
	{
		public static bool IsDefiniteValue(this NullValueStatus self)
		{
			if (self != NullValueStatus.DefinitelyNull)
			{
				return self == NullValueStatus.DefinitelyNotNull;
			}
			return true;
		}
	}
}
