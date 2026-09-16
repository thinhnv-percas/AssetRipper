using AssetRipperInjected;
using Cpp2ILInjected;

namespace DG.Tweening.Plugins.Options
{
	[Token(Token = "0x200008C")]
	public struct Vector3ArrayOptions : IPlugOptions
	{
		[Token(Token = "0x4000187")]
		[FieldOffset(Offset = "0x0")]
		public AxisConstraint axisConstraint;

		[Token(Token = "0x4000188")]
		[FieldOffset(Offset = "0x4")]
		public bool snapping;

		[Token(Token = "0x4000189")]
		[FieldOffset(Offset = "0x8")]
		internal float[] durations;

		[Token(Token = "0x600036E")]
		[Address(RVA = "0xC28294", Offset = "0xC28294", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.axisConstraint = 0;\n\tthis.snapping = 0;\n\tthis.durations = 0;\n\treturn;\n")]
		public void Reset()
		{
			axisConstraint = default(AxisConstraint);
			snapping = false;
			durations = null;
		}
	}
}
