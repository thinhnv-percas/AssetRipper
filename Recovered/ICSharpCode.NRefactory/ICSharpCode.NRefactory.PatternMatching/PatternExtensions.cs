using System;

namespace ICSharpCode.NRefactory.PatternMatching
{
	public static class PatternExtensions
	{
		public static Match Match(this INode pattern, INode other)
		{
			if (pattern == null)
			{
				throw new ArgumentNullException("pattern");
			}
			Match match = ICSharpCode.NRefactory.PatternMatching.Match.CreateNew();
			if (pattern.DoMatch(other, match))
			{
				return match;
			}
			return default(Match);
		}

		public static bool IsMatch(this INode pattern, INode other)
		{
			if (pattern == null)
			{
				throw new ArgumentNullException("pattern");
			}
			return pattern.DoMatch(other, ICSharpCode.NRefactory.PatternMatching.Match.CreateNew());
		}
	}
}
