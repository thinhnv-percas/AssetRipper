using System.Runtime.CompilerServices;

namespace Wasm.Binary
{
	public struct SectionHeader
	{
		[CompilerGenerated]
		private SectionName _0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_000A_000A;

		[CompilerGenerated]
		private uint _0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A;

		public SectionName Name
		{
			get;
			private set;
		}

		public uint PayloadLength
		{
			get;
			private set;
		}

		public SectionHeader(SectionName name, uint payloadLength)
		{
			Name = name;
			PayloadLength = payloadLength;
		}

		public override string ToString()
		{
			return Name + ", payload size: " + PayloadLength;
		}
	}
}
