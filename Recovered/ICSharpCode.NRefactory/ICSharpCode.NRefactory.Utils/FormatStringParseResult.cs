using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.NRefactory.Utils
{
	public class FormatStringParseResult
	{
		public IList<IFormatStringSegment> Segments
		{
			get;
			private set;
		}

		public bool HasErrors => Segments.SelectMany((IFormatStringSegment segment) => segment.Errors).Any();

		public FormatStringParseResult()
		{
			Segments = new List<IFormatStringSegment>();
		}
	}
}
