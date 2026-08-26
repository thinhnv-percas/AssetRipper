using System.Collections.Generic;

namespace ICSharpCode.NRefactory.Utils;

public interface IFormatStringSegment
{
	int StartLocation { get; set; }

	int EndLocation { get; set; }

	bool HasErrors { get; }

	IEnumerable<IFormatStringError> Errors { get; }
}
