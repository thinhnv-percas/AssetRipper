using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace EnhancedScrollerDemos.RemoteResourcesDemo
{
	[Serializable]
	[Token(Token = "0x200006E")]
	public class RemoteImage
	{
		[Token(Token = "0x40001C1")]
		[FieldOffset(Offset = "0x10")]
		public string url;

		[Token(Token = "0x40001C2")]
		[FieldOffset(Offset = "0x18")]
		public RemoteImageSize size;

		[Token(Token = "0x6000222")]
		[Address(RVA = "0x402F558", Offset = "0x402F558", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public RemoteImage()
		{
		}
	}
}
