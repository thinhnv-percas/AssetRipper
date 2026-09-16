using AssetRipperInjected;
using Cpp2ILInjected;

namespace DG.Tweening.Plugins.Options
{
	[Token(Token = "0x200008B")]
	public struct UintOptions : IPlugOptions
	{
		[Token(Token = "0x4000186")]
		[FieldOffset(Offset = "0x0")]
		public bool isNegativeChangeValue;

		[Token(Token = "0x600036D")]
		[Address(RVA = "0xC2828C", Offset = "0xC2828C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.isNegativeChangeValue = 0;\n\treturn;\n")]
		public void Reset()
		{
			isNegativeChangeValue = false;
		}
	}
}
