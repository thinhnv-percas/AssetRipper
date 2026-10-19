using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace AlmostEngine.Screenshot.Extra
{
	[Token(Token = "0x2000062")]
	public class CutScreenshotPostProcess : ScreenshotProcess
	{
		[Token(Token = "0x400023C")]
		[FieldOffset(Offset = "0x28")]
		public RectTransform m_SelectionArea;

		[Token(Token = "0x400023D")]
		[FieldOffset(Offset = "0x30")]
		public int m_Border;

		[Token(Token = "0x60001D6")]
		[Address(RVA = "0x3C48EA4", Offset = "0x3C48EA4", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tAlmostEngine.Screenshot.Extra.ScreenshotCutter::CropScreenshot(res, this.m_SelectionArea, this.m_Border);\n\treturn;\n")]
		public override void Process(ScreenshotResolution res)
		{
			ScreenshotCutter.CropScreenshot(res, m_SelectionArea, m_Border);
		}

		[Token(Token = "0x60001D7")]
		[Address(RVA = "0x3C48FE8", Offset = "0x3C48FE8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tAlmostEngine.Screenshot.ScreenshotProcess::.ctor(this);\n\treturn;\n")]
		public CutScreenshotPostProcess()
		{
		}
	}
}
