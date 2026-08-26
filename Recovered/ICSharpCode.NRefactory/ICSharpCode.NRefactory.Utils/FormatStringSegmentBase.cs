using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.NRefactory.Utils
{
	public abstract class FormatStringSegmentBase : IFormatStringSegment
	{
		public int StartLocation
		{
			get;
			set;
		}

		public int EndLocation
		{
			get;
			set;
		}

		public bool HasErrors => Errors.Any();

		public IList<IFormatStringError> Errors
		{
			get;
			set;
		}

		IEnumerable<IFormatStringError> IFormatStringSegment.Errors => Errors;

		public FormatStringSegmentBase()
		{
			Errors = new List<IFormatStringError>();
		}
	}
}
