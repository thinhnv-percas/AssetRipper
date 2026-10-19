using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace AlmostEngine.Screenshot.Extra
{
	[Token(Token = "0x2000063")]
	public class DownscaleScreenshotPostProcess : ScreenshotProcess
	{
		[Token(Token = "0x400023E")]
		[FieldOffset(Offset = "0x28")]
		public FilterMode m_FilterMode;

		[Token(Token = "0x400023F")]
		[FieldOffset(Offset = "0x2C")]
		public TextureWrapMode m_WrapMode;

		[Token(Token = "0x60001D8")]
		[Address(RVA = "0x3C48FF0", Offset = "0x3C48FF0", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv55 = UnityEngine.Texture::get_width(res.m_Texture);\n\tv58 = v55 / res.m_Scale;\n\tv63 = v58 == 0x7F800000;\n\tv71 = ~v63;\n\tif (v71) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv132 = 0xFFFFFFFF80000000;\n\tgoto L_0031;\nL_FFFFFFFF:\n\tv132 = v58;\nL_FFFFFFFF:\n\tv83 = 0xFFFFFFFF80000000;\n\tgoto L_0052;\nL_FFFFFFFF:\n\tv83 = v114;\nL_0031:\n\tv135 = UnityEngine.Texture::get_height(res.m_Texture);\n\tv114 = v135 / res.m_Scale;\n\tv104 = v114 == 0x7F800000;\n\tv87 = ~v104;\n\tif (v87) goto L_FFFFFFFF;\nL_0052:\n\tAlmostEngine.Screenshot.Extra.ScreenshotResize::ResizeScreenshot(res, v132, v83, 0, this.m_FilterMode, this.m_WrapMode);\n\treturn;\n")]
		public override void Process(ScreenshotResolution res)
		{
			//IL_006c: Expected I4, but got F4
			//IL_0087: Expected I4, but got F4
			int width = res.m_Texture.width;
			float num = (float)width / res.m_Scale;
			int width2 = ((num != 1f / 0f) ? ((int)num) : (-2147483648));
			int height = res.m_Texture.height;
			float num2 = (float)height / res.m_Scale;
			int height2 = ((num2 != 1f / 0f) ? ((int)num2) : (-2147483648));
			ScreenshotResize.ResizeScreenshot(res, width2, height2, preserveOriginalRatio: false, m_FilterMode, m_WrapMode);
		}

		[Token(Token = "0x60001D9")]
		[Address(RVA = "0x3C49260", Offset = "0x3C49260", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_FilterMode = 1;\n\tAlmostEngine.Screenshot.ScreenshotProcess::.ctor(this);\n\treturn;\n")]
		public DownscaleScreenshotPostProcess()
		{
			m_FilterMode = FilterMode.Bilinear;
		}
	}
}
