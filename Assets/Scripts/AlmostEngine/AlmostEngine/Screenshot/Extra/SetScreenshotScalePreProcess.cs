using AssetRipperInjected;
using Cpp2ILInjected;

namespace AlmostEngine.Screenshot.Extra
{
	[Token(Token = "0x2000068")]
	public class SetScreenshotScalePreProcess : ScreenshotProcess
	{
		[Token(Token = "0x400024E")]
		[FieldOffset(Offset = "0x28")]
		public float m_NewScale;

		[Token(Token = "0x60001DE")]
		[Address(RVA = "0x3C495F4", Offset = "0x3C495F4", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tres.m_Scale = this.m_NewScale;\n\treturn;\n")]
		public override void Process(ScreenshotResolution res)
		{
			res.m_Scale = m_NewScale;
		}

		[Token(Token = "0x60001DF")]
		[Address(RVA = "0x3C49610", Offset = "0x3C49610", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_NewScale = 2f;\n\tAlmostEngine.Screenshot.ScreenshotProcess::.ctor(this);\n\treturn;\n")]
		public SetScreenshotScalePreProcess()
		{
			m_NewScale = 2f;
		}
	}
}
