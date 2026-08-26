using ICSharpCode.Decompiler.ILAst;
using ICSharpCode.NRefactory;

namespace ICSharpCode.Decompiler
{
	public class SequencePoint
	{
		public ILRange[] ILRanges
		{
			get;
			set;
		}

		public TextLocation StartLocation
		{
			get;
			set;
		}

		public TextLocation EndLocation
		{
			get;
			set;
		}

		public int ILOffset => ILRanges[0].From;

		public override string ToString()
		{
			return string.Join(" ", ILRanges) + " " + StartLocation + "-" + EndLocation;
		}
	}
}
