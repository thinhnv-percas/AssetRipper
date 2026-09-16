using System.Runtime.InteropServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace DG.Tweening.Plugins.Options
{
	[StructLayout((LayoutKind)0, Size = 4)]
	[Token(Token = "0x2000036")]
	public struct ColorOptions : IPlugOptions
	{
		[Token(Token = "0x40000F6")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public bool alphaOnly;

		[Token(Token = "0x6000227")]
		[Address(RVA = "0x8567F0", Offset = "0x8567F0", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (DG.Tweening.Plugins.Options.ColorOptions)+10]) = 0;\n\treturn;\n\tX8 = *([X0]);\n\t*([X1]) = X8;\n\treturn;\n\tX8 = *([X0]);\n\tC = X8 < 0;\n\tC = ~C;\n\tTEMP1 = X8 - 0;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 0;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tX8 = TEMPCOND;\n\t*([X1]) = X8;\n\treturn;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Reset()
		{
			_ = 0;
		}
	}
}
