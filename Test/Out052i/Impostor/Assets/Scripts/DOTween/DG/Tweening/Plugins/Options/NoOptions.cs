using System.Runtime.InteropServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace DG.Tweening.Plugins.Options
{
	[StructLayout((LayoutKind)0, Size = 1)]
	[Token(Token = "0x200008D")]
	public struct NoOptions : IPlugOptions
	{
		[Token(Token = "0x600036F")]
		[Address(RVA = "0xC282A4", Offset = "0xC282A4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void Reset()
		{
		}
	}
}
