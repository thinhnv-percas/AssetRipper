using System.Collections.Generic;

namespace ICSharpCode.NRefactory.PatternMatching
{
	public class BacktrackingInfo
	{
		internal Stack<Pattern.PossibleMatch> backtrackingStack = new Stack<Pattern.PossibleMatch>();
	}
}
