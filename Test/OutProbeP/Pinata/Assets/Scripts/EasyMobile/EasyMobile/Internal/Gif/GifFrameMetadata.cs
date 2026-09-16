using System.Runtime.InteropServices;
using Cpp2ILInjected;

namespace EasyMobile.Internal.Gif
{
	[StructLayout((LayoutKind)0, Size = 8)]
	[Token(Token = "0x20000FF")]
	internal struct GifFrameMetadata
	{
		[Token(Token = "0x400046B")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public int delayTime;

		[Token(Token = "0x400046C")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x4")]
		public int transparentColor;
	}
}
