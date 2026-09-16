using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EM_Moments.Encoder
{
	[Token(Token = "0x2000006")]
	public class GifFrame
	{
		[Token(Token = "0x400001C")]
		[FieldOffset(Offset = "0x10")]
		public int Width;

		[Token(Token = "0x400001D")]
		[FieldOffset(Offset = "0x14")]
		public int Height;

		[Token(Token = "0x400001E")]
		[FieldOffset(Offset = "0x18")]
		public Color32[] Data;

		[Token(Token = "0x6000020")]
		[Address(RVA = "0xA40784", Offset = "0xA40784", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GifFrame()
		{
		}
	}
}
