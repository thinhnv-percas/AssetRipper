using System.Runtime.InteropServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace DG.Tweening.Plugins.Options
{
	[StructLayout((LayoutKind)0, Size = 4)]
	[Token(Token = "0x2000037")]
	public struct FloatOptions : IPlugOptions
	{
		[Token(Token = "0x40000F7")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public bool snapping;

		[Token(Token = "0x6000228")]
		[Address(RVA = "0x85681C", Offset = "0x85681C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (DG.Tweening.Plugins.Options.FloatOptions)+10]) = 0;\n\treturn;\n")]
		public void Reset()
		{
			_ = 0;
		}
	}
}
