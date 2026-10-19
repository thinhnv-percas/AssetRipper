using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace AlmostEngine.Screenshot.Extra
{
	[Token(Token = "0x200006B")]
	public class ScreenshotResize
	{
		[Token(Token = "0x60001EC")]
		[Address(RVA = "0x3C490A0", Offset = "0x3C490A0", Length = "0x1C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tgoto L_0033;\nL_0033:\n\tv81 = UnityEngine.Object::op_Equality(res.m_Texture, 0);\n\tv84 = ~v81;\n\tif (v84) goto L_0059;\nL_003E:\n\tgoto L_004F;\nL_004F:\n\tUnityEngine.Debug::LogError(\"Can not resize, null texture.\");\n\treturn;\nL_0059:\n\tv121 = ~preserveOriginalRatio;\nL_FFFFFFFF:\n\tv237 = width;\nL_FFFFFFFF:\n\tv240 = height;\n\tif (v121) goto L_009A;\n\tv202 = res.m_Width / res.m_Height;\n\tv213 = width < 1;\n\tif (v213) goto L_0082;\n\tv232 = width / v202;\n\tv222 = v232 == 0x7F800000;\n\tv214 = ~v222;\n\tif (v214) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv240 = 0xFFFFFFFF80000000;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv240 = v232;\nL_0082:\n\tv233 = v202 * height;\n\tv223 = v233 == 0x7F800000;\n\tv215 = ~v223;\n\tif (v215) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv237 = 0xFFFFFFFF80000000;\nL_FFFFFFFF:\n\tv240 = height;\n\tgoto L_009A;\nL_FFFFFFFF:\n\tv237 = v233;\nL_FFFFFFFF:\n\tv240 = height;\nL_00A5:\n\tUnityEngine.Object::DestroyImmediate(res.m_Texture);\n\tres.m_Texture = v244;\n\treturn;\nL_0025:\n\tv60 = res == 0;\n\tif (v60) goto L_003E;\nL_009A:\n\tv244 = AlmostEngine.Screenshot.Extra.ScreenshotResize::ResizeTexture(res.m_Texture, v237, v240, filterMode, wrapMode);\n\tgoto L_00A5;\nL_FFFFFFFF:\n\tv237 = width;\n\tgoto L_009A;\n")]
		public static void ResizeScreenshot(ScreenshotResolution res, int width, int height, bool preserveOriginalRatio, FilterMode filterMode, TextureWrapMode wrapMode)
		{
			if (res == null || res.m_Texture == null)
			{
				Debug.LogError("Can not resize, null texture.");
				return;
			}
			bool flag = !preserveOriginalRatio;
			int width2 = width;
			int height2 = height;
			if (!flag)
			{
				int num = res.m_Width / res.m_Height;
				if (width >= 1)
				{
					int num2 = width / num;
					height2 = ((num2 != 2139095040) ? num2 : (-2147483648));
					width2 = width;
				}
				else
				{
					int num3 = num * height;
					if (num3 == 2139095040)
					{
						width2 = -2147483648;
						height2 = height;
					}
					else
					{
						width2 = num3;
						height2 = height;
					}
				}
			}
			Texture2D texture = ResizeTexture(res.m_Texture, width2, height2, filterMode, wrapMode);
			Object.DestroyImmediate(res.m_Texture);
			res.m_Texture = texture;
		}

		[Token(Token = "0x60001ED")]
		[Address(RVA = "0x3C4A084", Offset = "0x3C4A084", Length = "0x1A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002E;\nL_002E:\n\tv71 = UnityEngine.Texture::get_filterMode(src);\n\tv100 = UnityEngine.Texture::get_wrapMode(src);\n\tUnityEngine.Texture::set_filterMode(src, filterMode);\n\tUnityEngine.Texture::set_wrapMode(src, wrapMode);\n\tv154 = new UnityEngine.RenderTexture();\n\tUnityEngine.RenderTexture::.ctor(v154, width, height, 0x18);\n\tUnityEngine.RenderTexture::set_active(v154);\n\tgoto L_0050;\nL_0050:\n\tUnityEngine.Graphics::Blit(src, v154);\n\tv86 = new UnityEngine.Texture2D();\n\tUnityEngine.Texture2D::.ctor(v86, width, height);\n\t// 98 MakeStruct v107 @ AGG3C4A1D4_1_v1 (UnityEngine.Rect), typeof(UnityEngine.Rect), 0, 0, width @ X1 (System.Int32), height @ X2 (System.Int32)\n\tUnityEngine.Texture2D::ReadPixels(v86, v107, 0, 0);\n\tUnityEngine.Texture2D::Apply(v86);\n\tUnityEngine.Texture::set_filterMode(src, v71);\n\tUnityEngine.Texture::set_wrapMode(src, v100);\n\treturn v86;\n")]
		public static Texture2D ResizeTexture(Texture2D src, int width, int height, FilterMode filterMode, TextureWrapMode wrapMode)
		{
			FilterMode filterMode2 = src.filterMode;
			TextureWrapMode wrapMode2 = src.wrapMode;
			src.filterMode = filterMode;
			src.wrapMode = wrapMode;
			RenderTexture dest = (RenderTexture.active = new RenderTexture(width, height, 24));
			Graphics.Blit(src, dest);
			Texture2D texture2D = new Texture2D(width, height);
			Rect source = default(Rect);
			source.x = 0f;
			source.y = 0f;
			source.width = width;
			source.height = height;
			texture2D.ReadPixels(source, 0, 0);
			texture2D.Apply();
			src.filterMode = filterMode2;
			src.wrapMode = wrapMode2;
			return texture2D;
		}

		[Token(Token = "0x60001EE")]
		[Address(RVA = "0x3C4A228", Offset = "0x3C4A228", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public ScreenshotResize()
		{
		}
	}
}
