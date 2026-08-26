using System.Runtime.CompilerServices;

namespace Wasm
{
	public struct VersionHeader
	{
		[CompilerGenerated]
		internal uint _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_0020_0020_0020;

		[CompilerGenerated]
		internal uint _0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A;

		public uint Magic
		{
			get;
			internal set;
		}

		public uint Version
		{
			get;
			internal set;
		}

		public static uint WasmMagic => 1836278016u;

		public static uint PreMvpVersion => 13u;

		public static uint MvpVersion => 1u;

		public static VersionHeader MvpHeader => new VersionHeader(WasmMagic, MvpVersion);

		public VersionHeader(uint magic, uint version)
		{
			Magic = magic;
			Version = version;
		}

		public void Verify()
		{
			if (Magic != WasmMagic)
			{
				throw new BadHeaderException(this, $"Invalid magic number. Got '{DumpHelpers.FormatHex(Magic)}', expected '{DumpHelpers.FormatHex(WasmMagic)}'.");
			}
			if (Version != PreMvpVersion && Version != MvpVersion)
			{
				throw new BadHeaderException(this, "Invalid version number '" + Version + "'.");
			}
		}
	}
}
