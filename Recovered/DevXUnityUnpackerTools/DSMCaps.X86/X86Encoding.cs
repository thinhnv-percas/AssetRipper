using System.Runtime.CompilerServices;

namespace DSMCaps.X86
{
	public sealed class X86Encoding
	{
		[CompilerGenerated]
		private readonly byte _0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A;

		[CompilerGenerated]
		private readonly byte _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_000A;

		[CompilerGenerated]
		private readonly byte _0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020;

		[CompilerGenerated]
		private readonly byte _0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A;

		[CompilerGenerated]
		private readonly byte _0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_0020;

		public byte DisplacementOffset
		{
			get;
		}

		public byte DisplacementSize
		{
			get;
		}

		public byte ImmediateOffset
		{
			get;
		}

		public byte ImmediateSize
		{
			get;
		}

		public byte ModRmOffset
		{
			get;
		}

		internal X86Encoding(ref _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A_0020 nativeEncoding)
		{
			_0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A = nativeEncoding.DisplacementOffset;
			_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_000A = nativeEncoding.DisplacementSize;
			_0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020 = nativeEncoding.ImmediateOffset;
			_0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A = nativeEncoding.ImmediateSize;
			_0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_0020 = nativeEncoding.ModRmOffset;
		}
	}
}
