using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.Purchasing.Extension;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000025")]
	internal class FakeGooglePlayConfiguration : IGooglePlayConfiguration, IStoreConfiguration
	{
		[Token(Token = "0x6000097")]
		[Address(RVA = "0xC5F00C", Offset = "0xC5F00C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FakeGooglePlayConfiguration()
		{
		}
	}
}
