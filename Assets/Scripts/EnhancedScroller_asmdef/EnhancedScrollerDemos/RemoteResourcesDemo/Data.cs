using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EnhancedScrollerDemos.RemoteResourcesDemo
{
	[Token(Token = "0x200006C")]
	public class Data
	{
		[Token(Token = "0x40001BE")]
		[FieldOffset(Offset = "0x10")]
		public Vector2 imageDimensions;

		[Token(Token = "0x40001BF")]
		[FieldOffset(Offset = "0x18")]
		public string imageUrl;

		[Token(Token = "0x6000220")]
		[Address(RVA = "0x402F294", Offset = "0x402F294", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public Data()
		{
		}
	}
}
