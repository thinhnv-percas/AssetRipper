using AssetRipperInjected;
using Cpp2ILInjected;

namespace DG.Tweening.Plugins.Options
{
	[Token(Token = "0x2000090")]
	public struct RectOptions : IPlugOptions
	{
		[Token(Token = "0x400018C")]
		[FieldOffset(Offset = "0x0")]
		public bool snapping;

		[Token(Token = "0x6000372")]
		[Address(RVA = "0xC282B8", Offset = "0xC282B8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.snapping = 0;\n\treturn;\n")]
		public void Reset()
		{
			snapping = false;
		}
	}
}
