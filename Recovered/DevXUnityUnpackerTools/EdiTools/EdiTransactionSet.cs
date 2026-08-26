using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace EdiTools
{
	public class EdiTransactionSet
	{
		[CompilerGenerated]
		internal EdiSegment _0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020;

		[CompilerGenerated]
		internal EdiSegment _0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A;

		[CompilerGenerated]
		internal IList<EdiSegment> _0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020;

		public EdiSegment InterchangeHeader
		{
			get;
			internal set;
		}

		public EdiSegment FunctionalGroupHeader
		{
			get;
			internal set;
		}

		public IList<EdiSegment> Segments
		{
			get;
			internal set;
		}

		public EdiTransactionSet(EdiSegment interchangeHeader, EdiSegment functionalGroupHeader)
		{
			InterchangeHeader = interchangeHeader;
			FunctionalGroupHeader = functionalGroupHeader;
			Segments = new List<EdiSegment>();
		}
	}
}
