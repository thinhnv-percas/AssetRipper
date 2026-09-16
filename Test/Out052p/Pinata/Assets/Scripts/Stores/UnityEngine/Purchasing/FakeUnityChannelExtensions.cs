using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000032")]
	public class FakeUnityChannelExtensions : IUnityChannelExtensions, IStoreExtension
	{
		[Token(Token = "0x60000B0")]
		[Address(RVA = "0xC611B4", Offset = "0xC611B4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FakeUnityChannelExtensions()
		{
		}
	}
}
