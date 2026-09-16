using AssetRipperInjected;
using Cpp2ILInjected;

namespace Facebook.Unity.IOS
{
	[Token(Token = "0x2000002")]
	public class IOSWrapper
	{
		[Token(Token = "0x6000001")]
		[Address(RVA = "0x168194C", Offset = "0x168194C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IOSWrapper()
		{
		}
	}
}
