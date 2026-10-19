using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace EnhancedScrollerDemos.RemoteResourcesDemo
{
	[Serializable]
	[Token(Token = "0x200006D")]
	public class RemoteImageList
	{
		[Token(Token = "0x40001C0")]
		[FieldOffset(Offset = "0x10")]
		public RemoteImage[] images;

		[Token(Token = "0x6000221")]
		[Address(RVA = "0x402F550", Offset = "0x402F550", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public RemoteImageList()
		{
		}
	}
}
