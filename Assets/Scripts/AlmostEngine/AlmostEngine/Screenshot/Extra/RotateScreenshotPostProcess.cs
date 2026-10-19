using AssetRipperInjected;
using Cpp2ILInjected;

namespace AlmostEngine.Screenshot.Extra
{
	[Token(Token = "0x2000066")]
	public class RotateScreenshotPostProcess : ScreenshotProcess
	{
		[Token(Token = "0x2000067")]
		public enum RotationType
		{
			[Token(Token = "0x400024C")]
			ROTATE_LEFT = 0,
			[Token(Token = "0x400024D")]
			ROTATE_RIGHT = 1
		}

		[Token(Token = "0x400024A")]
		[FieldOffset(Offset = "0x28")]
		public RotationType m_Type;

		[Token(Token = "0x60001DC")]
		[Address(RVA = "0x3C4937C", Offset = "0x3C4937C", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.m_Type == 0;\n\tif (v2) goto L_0007;\n\tAlmostEngine.Screenshot.Extra.ScreenshotRotation::RotateScreenshotRight(res);\n\treturn;\nL_0007:\n\tAlmostEngine.Screenshot.Extra.ScreenshotRotation::RotateScreenshotLeft(res);\n\treturn;\n")]
		public override void Process(ScreenshotResolution res)
		{
			if (m_Type != RotationType.ROTATE_LEFT)
			{
				ScreenshotRotation.RotateScreenshotRight(res);
			}
			else
			{
				ScreenshotRotation.RotateScreenshotLeft(res);
			}
		}

		[Token(Token = "0x60001DD")]
		[Address(RVA = "0x3C495EC", Offset = "0x3C495EC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tAlmostEngine.Screenshot.ScreenshotProcess::.ctor(this);\n\treturn;\n")]
		public RotateScreenshotPostProcess()
		{
		}
	}
}
