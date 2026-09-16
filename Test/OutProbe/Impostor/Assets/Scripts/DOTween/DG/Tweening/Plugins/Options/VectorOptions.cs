using AssetRipperInjected;
using Cpp2ILInjected;

namespace DG.Tweening.Plugins.Options
{
	[Token(Token = "0x2000092")]
	public struct VectorOptions : IPlugOptions
	{
		[Token(Token = "0x4000192")]
		[FieldOffset(Offset = "0x0")]
		public AxisConstraint axisConstraint;

		[Token(Token = "0x4000193")]
		[FieldOffset(Offset = "0x4")]
		public bool snapping;

		[Token(Token = "0x6000374")]
		[Address(RVA = "0xC282D4", Offset = "0xC282D4", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.axisConstraint = 0;\n\tthis.snapping = 0;\n\treturn;\n")]
		public void Reset()
		{
			axisConstraint = default(AxisConstraint);
			snapping = false;
		}
	}
}
