using System.Runtime.InteropServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace DG.Tweening.Plugins.Options
{
	[StructLayout((LayoutKind)0, Size = 16)]
	[Token(Token = "0x2000034")]
	public struct Vector3ArrayOptions : IPlugOptions
	{
		[Token(Token = "0x40000F3")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public AxisConstraint axisConstraint;

		[Token(Token = "0x40000F4")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x4")]
		public bool snapping;

		[Token(Token = "0x40000F5")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
		internal float[] durations;

		[Token(Token = "0x6000225")]
		[Address(RVA = "0x858390", Offset = "0x858390", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (DG.Tweening.Plugins.Options.Vector3ArrayOptions)+10]) = 0;\n\t*([this @ X0 (DG.Tweening.Plugins.Options.Vector3ArrayOptions)+14]) = 0;\n\t*([this @ X0 (DG.Tweening.Plugins.Options.Vector3ArrayOptions)+18]) = 0;\n\treturn;\n\tX8 = *([X0]);\n\t*([X1]) = X8;\n\tX8 = *([X0+4]);\n\t*([X1+4]) = X8;\n\treturn;\n\tX8 = *([X0]);\n\t*([X1]) = X8;\n\tX8 = *([X0+4]);\n\tC = X8 < 0;\n\tC = ~C;\n\tTEMP1 = X8 - 0;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 0;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tX8 = TEMPCOND;\n\t*([X1+4]) = X8;\n\treturn;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Reset()
		{
			_ = 0;
			_ = 0;
			_ = 0;
		}
	}
}
