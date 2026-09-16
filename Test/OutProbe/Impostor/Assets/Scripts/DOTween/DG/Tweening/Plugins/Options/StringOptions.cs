using AssetRipperInjected;
using Cpp2ILInjected;

namespace DG.Tweening.Plugins.Options
{
	[Token(Token = "0x2000091")]
	public struct StringOptions : IPlugOptions
	{
		[Token(Token = "0x400018D")]
		[FieldOffset(Offset = "0x0")]
		public bool richTextEnabled;

		[Token(Token = "0x400018E")]
		[FieldOffset(Offset = "0x4")]
		public ScrambleMode scrambleMode;

		[Token(Token = "0x400018F")]
		[FieldOffset(Offset = "0x8")]
		public char[] scrambledChars;

		[Token(Token = "0x4000190")]
		[FieldOffset(Offset = "0x10")]
		internal int startValueStrippedLength;

		[Token(Token = "0x4000191")]
		[FieldOffset(Offset = "0x14")]
		internal int changeValueStrippedLength;

		[Token(Token = "0x6000373")]
		[Address(RVA = "0xC282C0", Offset = "0xC282C0", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.richTextEnabled = 0;\n\t*([this @ X0 (DG.Tweening.Plugins.Options.StringOptions)+C]) = 0;\n\tthis.scrambleMode = 0;\n\tthis.changeValueStrippedLength = 0;\n\treturn;\n")]
		public void Reset()
		{
			richTextEnabled = false;
			_ = 0;
			scrambleMode = default(ScrambleMode);
			changeValueStrippedLength = 0;
		}
	}
}
