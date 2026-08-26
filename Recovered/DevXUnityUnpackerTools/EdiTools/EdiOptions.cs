using System.Runtime.CompilerServices;

namespace EdiTools
{
	public class EdiOptions
	{
		public static char DefaultSegmentTerminator = '\r';

		public static char DefaultElementSeparator = '*';

		public static char DefaultComponentSeparator = '>';

		public static char DefaultRepetitionSeparator = '^';

		[CompilerGenerated]
		private char? _0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_000A;

		[CompilerGenerated]
		private char? _0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020;

		[CompilerGenerated]
		private char? _0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A;

		[CompilerGenerated]
		private char? _0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020;

		[CompilerGenerated]
		private char? _0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A;

		[CompilerGenerated]
		private char? _0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020;

		[CompilerGenerated]
		private bool _0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A;

		public char? SegmentTerminator
		{
			get;
			set;
		}

		public char? ElementSeparator
		{
			get;
			set;
		}

		public char? ComponentSeparator
		{
			get;
			set;
		}

		public char? RepetitionSeparator
		{
			get;
			set;
		}

		public char? DecimalIndicator
		{
			get;
			set;
		}

		public char? ReleaseCharacter
		{
			get;
			set;
		}

		public bool AddLineBreaks
		{
			get;
			set;
		}

		public EdiOptions()
		{
		}

		public EdiOptions(EdiOptions source)
		{
			SegmentTerminator = source.SegmentTerminator;
			ElementSeparator = source.ElementSeparator;
			ComponentSeparator = source.ComponentSeparator;
			RepetitionSeparator = source.RepetitionSeparator;
			DecimalIndicator = source.DecimalIndicator;
			ReleaseCharacter = source.ReleaseCharacter;
			AddLineBreaks = source.AddLineBreaks;
		}
	}
}
