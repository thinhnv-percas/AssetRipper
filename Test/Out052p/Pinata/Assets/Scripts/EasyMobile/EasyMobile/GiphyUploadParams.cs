using System.Runtime.InteropServices;
using Cpp2ILInjected;

namespace EasyMobile
{
	[StructLayout((LayoutKind)0, Size = 40)]
	[Token(Token = "0x200005A")]
	public struct GiphyUploadParams
	{
		[Token(Token = "0x400021E")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public string localImagePath;

		[Token(Token = "0x400021F")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
		public string sourceImageUrl;

		[Token(Token = "0x4000220")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
		public string tags;

		[Token(Token = "0x4000221")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
		public string sourcePostUrl;

		[Token(Token = "0x4000222")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
		public bool isHidden;
	}
}
