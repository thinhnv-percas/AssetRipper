using System.Runtime.InteropServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace DG.Tweening.Plugins.Options
{
	[StructLayout((LayoutKind)0, Size = 8)]
	[Token(Token = "0x200003A")]
	public struct VectorOptions : IPlugOptions
	{
		[Token(Token = "0x40000FE")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public AxisConstraint axisConstraint;

		[Token(Token = "0x40000FF")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x4")]
		public bool snapping;

		[Token(Token = "0x600022B")]
		[Address(RVA = "0x8583D4", Offset = "0x8583D4", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (DG.Tweening.Plugins.Options.VectorOptions)+10]) = 0;\n\t*([this @ X0 (DG.Tweening.Plugins.Options.VectorOptions)+14]) = 0;\n\treturn;\n\t// 3 ShiftStack -16\n\tstack[0] = X29;\n\tstack[8] = X30;\n\tX29 = &stack[0];\n\tX0 = X0 + 0x4C0;\n\tX0 = 0x8D82DC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t// 13 ShiftStack -16\n\tstack[0] = X29;\n\tstack[8] = X30;\n\tX29 = &stack[0];\n\tX0 = X0 + 0x4C0;\n\tX0 = 0x8D82DC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Reset()
		{
			_ = 0;
			_ = 0;
		}
	}
}
