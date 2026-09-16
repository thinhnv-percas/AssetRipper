using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000050")]
	internal class FakeManagedStoreExtensions : IManagedStoreExtensions, IStoreExtension
	{
		[Token(Token = "0x6000138")]
		[Address(RVA = "0xC5F034", Offset = "0xC5F034", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FakeManagedStoreExtensions()
		{
		}
	}
}
