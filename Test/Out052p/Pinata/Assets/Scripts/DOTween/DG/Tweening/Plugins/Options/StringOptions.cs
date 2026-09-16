using System.Runtime.InteropServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace DG.Tweening.Plugins.Options
{
	[StructLayout((LayoutKind)0, Size = 24)]
	[Token(Token = "0x2000039")]
	public struct StringOptions : IPlugOptions
	{
		[Token(Token = "0x40000F9")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public bool richTextEnabled;

		[Token(Token = "0x40000FA")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x4")]
		public ScrambleMode scrambleMode;

		[Token(Token = "0x40000FB")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
		public char[] scrambledChars;

		[Token(Token = "0x40000FC")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
		internal int startValueStrippedLength;

		[Token(Token = "0x40000FD")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x14")]
		internal int changeValueStrippedLength;

		[Token(Token = "0x600022A")]
		[Address(RVA = "0x856A6C", Offset = "0x856A6C", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.startValueStrippedLength = 0;\n\t*([this @ X0 (DG.Tweening.Plugins.Options.StringOptions)+24]) = 0;\n\t*([this @ X0 (DG.Tweening.Plugins.Options.StringOptions)+1C]) = 0;\n\tthis.changeValueStrippedLength = 0;\n\treturn;\n")]
		public void Reset()
		{
			startValueStrippedLength = 0;
			_ = 0;
			_ = 0;
			changeValueStrippedLength = 0;
		}
	}
}
