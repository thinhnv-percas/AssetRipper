using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.Purchasing.Extension;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x200004F")]
	internal class FakeManagedStoreConfig : IManagedStoreConfig, IStoreConfiguration
	{
		[Token(Token = "0x40000ED")]
		[FieldOffset(Offset = "0x10")]
		internal bool catalogDisabled;

		[Token(Token = "0x40000EE")]
		[FieldOffset(Offset = "0x11")]
		internal bool testStore;

		[Token(Token = "0x40000EF")]
		[FieldOffset(Offset = "0x18")]
		internal string iapBaseUrl;

		[Token(Token = "0x40000F0")]
		[FieldOffset(Offset = "0x20")]
		internal string eventBaseUrl;

		[Token(Token = "0x40000F1")]
		[FieldOffset(Offset = "0x28")]
		internal bool? trackingOptedOut;

		[Token(Token = "0x6000137")]
		[Address(RVA = "0xC5F020", Offset = "0xC5F020", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.catalogDisabled = 0;\n\tthis.trackingOptedOut = 0;\n\tthis.iapBaseUrl = 0;\n\tthis.eventBaseUrl = 0;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FakeManagedStoreConfig()
		{
			catalogDisabled = false;
			testStore = false;
			trackingOptedOut = null;
			iapBaseUrl = null;
			eventBaseUrl = null;
		}
	}
}
