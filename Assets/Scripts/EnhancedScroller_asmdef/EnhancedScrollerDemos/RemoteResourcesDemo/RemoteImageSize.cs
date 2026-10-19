using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace EnhancedScrollerDemos.RemoteResourcesDemo
{
	[Serializable]
	[Token(Token = "0x200006F")]
	public class RemoteImageSize
	{
		[Token(Token = "0x40001C3")]
		[FieldOffset(Offset = "0x10")]
		public float x;

		[Token(Token = "0x40001C4")]
		[FieldOffset(Offset = "0x14")]
		public float y;

		[Token(Token = "0x6000223")]
		[Address(RVA = "0x402F560", Offset = "0x402F560", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public RemoteImageSize()
		{
		}
	}
}
