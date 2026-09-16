using AssetRipperInjected;
using Cpp2ILInjected;

namespace DG.Tweening.Plugins.Options
{
	[Token(Token = "0x200008F")]
	public struct FloatOptions : IPlugOptions
	{
		[Token(Token = "0x400018B")]
		[FieldOffset(Offset = "0x0")]
		public bool snapping;

		[Token(Token = "0x6000371")]
		[Address(RVA = "0xC282B0", Offset = "0xC282B0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.snapping = 0;\n\treturn;\n")]
		public void Reset()
		{
			snapping = false;
		}
	}
}
