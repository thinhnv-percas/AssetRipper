using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000035")]
	public class FakeUDPExtension : IUDPExtensions, IStoreExtension
	{
		[Token(Token = "0x60000B1")]
		[Address(RVA = "0xC611A4", Offset = "0xC611A4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FakeUDPExtension()
		{
		}
	}
}
