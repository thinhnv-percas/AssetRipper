using System.Runtime.InteropServices;
using Cpp2ILInjected;

namespace EasyMobile.Internal.Gif
{
	[StructLayout((LayoutKind)0, Size = 12)]
	[Token(Token = "0x20000FE")]
	internal struct GifMetadata
	{
		[Token(Token = "0x4000468")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public int width;

		[Token(Token = "0x4000469")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x4")]
		public int height;

		[Token(Token = "0x400046A")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
		public int frameCount;
	}
}
