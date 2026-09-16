using AssetRipperInjected;
using Cpp2ILInjected;

namespace DG.Tweening.Plugins.Options
{
	[Token(Token = "0x200008E")]
	public struct ColorOptions : IPlugOptions
	{
		[Token(Token = "0x400018A")]
		[FieldOffset(Offset = "0x0")]
		public bool alphaOnly;

		[Token(Token = "0x6000370")]
		[Address(RVA = "0xC282A8", Offset = "0xC282A8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.alphaOnly = 0;\n\treturn;\n")]
		public void Reset()
		{
			alphaOnly = false;
		}
	}
}
