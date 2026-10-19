using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace AlmostEngine.Screenshot.Extra
{
	[Token(Token = "0x2000064")]
	public class ResizeScreenshotPostProcess : ScreenshotProcess
	{
		[Token(Token = "0x2000065")]
		public enum ResizeMode
		{
			[Token(Token = "0x4000248")]
			SCALE = 0,
			[Token(Token = "0x4000249")]
			FIXED_RESOLUTION = 1
		}

		[Header("Resize mode")]
		[Token(Token = "0x4000240")]
		[FieldOffset(Offset = "0x28")]
		public ResizeMode m_ResizeType;

		[Token(Token = "0x4000241")]
		[FieldOffset(Offset = "0x2C")]
		public FilterMode m_FilterMode;

		[Token(Token = "0x4000242")]
		[FieldOffset(Offset = "0x30")]
		public TextureWrapMode m_WrapMode;

		[Header("Scale settings")]
		[Token(Token = "0x4000243")]
		[FieldOffset(Offset = "0x34")]
		public float m_Scale;

		[Header("Fixed resolution settings")]
		[Token(Token = "0x4000244")]
		[FieldOffset(Offset = "0x38")]
		public int m_TargetWidth;

		[Token(Token = "0x4000245")]
		[FieldOffset(Offset = "0x3C")]
		public int m_TargetHeight;

		[Token(Token = "0x4000246")]
		[FieldOffset(Offset = "0x40")]
		public bool m_PreserveOriginalRatio;

		[Token(Token = "0x60001DA")]
		[Address(RVA = "0x3C49270", Offset = "0x3C49270", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv28 = this.m_ResizeType != 1;\n\tif (v28) goto L_0022;\nL_FFFFFFFF:\n\tv144 = this.m_TargetWidth;\n\tgoto L_0031;\nL_0022:\n\tv38 = UnityEngine.Texture::get_width(res.m_Texture);\n\tv43 = this.m_Scale * v38;\n\tv47 = this.m_ResizeType != 1;\nL_FFFFFFFF:\n\tv144 = v43;\n\tif (v47) goto L_0068;\nL_0031:\n\tv145 = this.m_TargetHeight;\nL_FFFFFFFF:\n\tv183 = 0xFFFFFFFF80000000;\n\tgoto L_0048;\nL_FFFFFFFF:\n\tv183 = v145;\nL_FFFFFFFF:\n\tv185 = 0xFFFFFFFF80000000;\n\tgoto L_005F;\nL_FFFFFFFF:\n\tv185 = v144;\nL_0068:\n\tv109 = UnityEngine.Texture::get_height(res.m_Texture);\n\tv113 = this.m_Scale * v109;\n\tv124 = this.m_ResizeType == 1;\nL_FFFFFFFF:\n\tv144 = v43;\nL_FFFFFFFF:\n\tv145 = v113;\n\tif (v124) goto L_0033;\nL_FFFFFFFF:\n\tv137 = 0;\nL_FFFFFFFF:\n\tv144 = v43;\nL_FFFFFFFF:\n\tv145 = v113;\n\tgoto L_0038;\nL_0048:\n\tv201 = v144 == 0x7F800000;\n\tv177 = ~v201;\n\tif (v177) goto L_FFFFFFFF;\nL_005F:\n\tAlmostEngine.Screenshot.Extra.ScreenshotResize::ResizeScreenshot(res, v185, v183, v137, this.m_FilterMode, this.m_WrapMode);\n\treturn;\nL_0033:\n\tv137 = this.m_PreserveOriginalRatio;\nL_0038:\n\tv160 = v145 == 0x7F800000;\n\tv168 = ~v160;\n\tif (v168) goto L_FFFFFFFF;\n")]
		public override void Process(ScreenshotResolution res)
		{
			//IL_0071: Expected I4, but got F4
			//IL_0101: Expected I4, but got F4
			//IL_0109: Expected I4, but got F4
			//IL_0128: Expected I4, but got F4
			//IL_0130: Expected I4, but got F4
			int num;
			int num4;
			bool preserveOriginalRatio;
			if (m_ResizeType == ResizeMode.FIXED_RESOLUTION)
			{
				num = m_TargetWidth;
			}
			else
			{
				int width = res.m_Texture.width;
				float num2 = m_Scale * (float)width;
				bool flag = m_ResizeType != ResizeMode.FIXED_RESOLUTION;
				num = (int)num2;
				if (flag)
				{
					int height = res.m_Texture.height;
					float num3 = m_Scale * (float)height;
					bool flag2 = m_ResizeType == ResizeMode.FIXED_RESOLUTION;
					num = (int)num2;
					num4 = (int)num3;
					if (flag2)
					{
						goto IL_017f;
					}
					preserveOriginalRatio = false;
					num = (int)num2;
					num4 = (int)num3;
					goto IL_018e;
				}
			}
			num4 = m_TargetHeight;
			goto IL_017f;
			IL_018e:
			int height2 = ((num4 != 2139095040) ? num4 : (-2147483648));
			int width2 = ((num != 2139095040) ? num : (-2147483648));
			ScreenshotResize.ResizeScreenshot(res, width2, height2, preserveOriginalRatio, m_FilterMode, m_WrapMode);
			return;
			IL_017f:
			preserveOriginalRatio = m_PreserveOriginalRatio;
			goto IL_018e;
		}

		[Token(Token = "0x60001DB")]
		[Address(RVA = "0x3C49350", Offset = "0x3C49350", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_FilterMode = 1;\n\tthis.m_Scale = 0.5f;\n\tthis.m_TargetWidth = 1.2731974749744E-311d;\n\tthis.m_PreserveOriginalRatio = 1;\n\tAlmostEngine.Screenshot.ScreenshotProcess::.ctor(this);\n\treturn;\n")]
		public ResizeScreenshotPostProcess()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ResizeScreenshotPostProcess::.ctor");
		}
	}
}
