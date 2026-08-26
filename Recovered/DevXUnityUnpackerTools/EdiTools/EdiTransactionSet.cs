using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace EdiTools
{
	public class EdiTransactionSet
	{
		[CompilerGenerated]
		private EdiSegment _0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020;

		[CompilerGenerated]
		private EdiSegment _0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A;

		[CompilerGenerated]
		private IList<EdiSegment> _0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020;

		public EdiSegment InterchangeHeader
		{
			get;
			private set;
		}

		public EdiSegment FunctionalGroupHeader
		{
			get;
			private set;
		}

		public IList<EdiSegment> Segments
		{
			get;
			private set;
		}

		public EdiTransactionSet(EdiSegment interchangeHeader, EdiSegment functionalGroupHeader)
		{
			InterchangeHeader = interchangeHeader;
			FunctionalGroupHeader = functionalGroupHeader;
			Segments = new List<EdiSegment>();
		}
	}
}
