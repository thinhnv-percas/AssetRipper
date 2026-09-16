using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.Purchasing.Extension;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000031")]
	internal class FakeUnityChannelConfiguration : IUnityChannelConfiguration, IStoreConfiguration
	{
		[Token(Token = "0x60000AF")]
		[Address(RVA = "0xC611AC", Offset = "0xC611AC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FakeUnityChannelConfiguration()
		{
		}
	}
}
