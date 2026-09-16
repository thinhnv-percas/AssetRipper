using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Token(Token = "0x200007B")]
	public static class ShaderUtilities
	{
		[Token(Token = "0x40003C8")]
		public static int ID_MainTex;

		[Token(Token = "0x40003C9")]
		public static int ID_FaceTex;

		[Token(Token = "0x40003CA")]
		public static int ID_FaceColor;

		[Token(Token = "0x40003CB")]
		public static int ID_FaceDilate;

		[Token(Token = "0x40003CC")]
		public static int ID_Shininess;

		[Token(Token = "0x40003CD")]
		public static int ID_UnderlayColor;

		[Token(Token = "0x40003CE")]
		public static int ID_UnderlayOffsetX;

		[Token(Token = "0x40003CF")]
		public static int ID_UnderlayOffsetY;

		[Token(Token = "0x40003D0")]
		public static int ID_UnderlayDilate;

		[Token(Token = "0x40003D1")]
		public static int ID_UnderlaySoftness;

		[Token(Token = "0x40003D2")]
		public static int ID_UnderlayOffset;

		[Token(Token = "0x40003D3")]
		public static int ID_UnderlayIsoPerimeter;

		[Token(Token = "0x40003D4")]
		public static int ID_WeightNormal;

		[Token(Token = "0x40003D5")]
		public static int ID_WeightBold;

		[Token(Token = "0x40003D6")]
		public static int ID_OutlineTex;

		[Token(Token = "0x40003D7")]
		public static int ID_OutlineWidth;

		[Token(Token = "0x40003D8")]
		public static int ID_OutlineSoftness;

		[Token(Token = "0x40003D9")]
		public static int ID_OutlineColor;

		[Token(Token = "0x40003DA")]
		public static int ID_Outline2Color;

		[Token(Token = "0x40003DB")]
		public static int ID_Outline2Width;

		[Token(Token = "0x40003DC")]
		public static int ID_Padding;

		[Token(Token = "0x40003DD")]
		public static int ID_GradientScale;

		[Token(Token = "0x40003DE")]
		public static int ID_ScaleX;

		[Token(Token = "0x40003DF")]
		public static int ID_ScaleY;

		[Token(Token = "0x40003E0")]
		public static int ID_PerspectiveFilter;

		[Token(Token = "0x40003E1")]
		public static int ID_Sharpness;

		[Token(Token = "0x40003E2")]
		public static int ID_TextureWidth;

		[Token(Token = "0x40003E3")]
		public static int ID_TextureHeight;

		[Token(Token = "0x40003E4")]
		public static int ID_BevelAmount;

		[Token(Token = "0x40003E5")]
		public static int ID_GlowColor;

		[Token(Token = "0x40003E6")]
		public static int ID_GlowOffset;

		[Token(Token = "0x40003E7")]
		public static int ID_GlowPower;

		[Token(Token = "0x40003E8")]
		public static int ID_GlowOuter;

		[Token(Token = "0x40003E9")]
		public static int ID_GlowInner;

		[Token(Token = "0x40003EA")]
		public static int ID_LightAngle;

		[Token(Token = "0x40003EB")]
		public static int ID_EnvMap;

		[Token(Token = "0x40003EC")]
		public static int ID_EnvMatrix;

		[Token(Token = "0x40003ED")]
		public static int ID_EnvMatrixRotation;

		[Token(Token = "0x40003EE")]
		public static int ID_MaskCoord;

		[Token(Token = "0x40003EF")]
		public static int ID_ClipRect;

		[Token(Token = "0x40003F0")]
		public static int ID_MaskSoftnessX;

		[Token(Token = "0x40003F1")]
		public static int ID_MaskSoftnessY;

		[Token(Token = "0x40003F2")]
		public static int ID_VertexOffsetX;

		[Token(Token = "0x40003F3")]
		public static int ID_VertexOffsetY;

		[Token(Token = "0x40003F4")]
		public static int ID_UseClipRect;

		[Token(Token = "0x40003F5")]
		public static int ID_StencilID;

		[Token(Token = "0x40003F6")]
		public static int ID_StencilOp;

		[Token(Token = "0x40003F7")]
		public static int ID_StencilComp;

		[Token(Token = "0x40003F8")]
		public static int ID_StencilReadMask;

		[Token(Token = "0x40003F9")]
		public static int ID_StencilWriteMask;

		[Token(Token = "0x40003FA")]
		public static int ID_ShaderFlags;

		[Token(Token = "0x40003FB")]
		public static int ID_ScaleRatio_A;

		[Token(Token = "0x40003FC")]
		public static int ID_ScaleRatio_B;

		[Token(Token = "0x40003FD")]
		public static int ID_ScaleRatio_C;

		[Token(Token = "0x40003FE")]
		public static string Keyword_Bevel;

		[Token(Token = "0x40003FF")]
		public static string Keyword_Glow;

		[Token(Token = "0x4000400")]
		public static string Keyword_Underlay;

		[Token(Token = "0x4000401")]
		public static string Keyword_Ratios;

		[Token(Token = "0x4000402")]
		public static string Keyword_MASK_SOFT;

		[Token(Token = "0x4000403")]
		public static string Keyword_MASK_HARD;

		[Token(Token = "0x4000404")]
		public static string Keyword_MASK_TEX;

		[Token(Token = "0x4000405")]
		public static string Keyword_Outline;

		[Token(Token = "0x4000406")]
		public static string ShaderTag_ZTestMode;

		[Token(Token = "0x4000407")]
		public static string ShaderTag_CullMode;

		[Token(Token = "0x4000408")]
		private static float m_clamp;

		[Token(Token = "0x4000409")]
		public static bool isInitialized;

		[Token(Token = "0x400040A")]
		private static Shader k_ShaderRef_MobileSDF;

		[Token(Token = "0x400040B")]
		private static Shader k_ShaderRef_MobileBitmap;

		[Token(Token = "0x170000DE")]
		internal static Shader ShaderRef_MobileSDF
		{
			[Token(Token = "0x60003FC")]
			[Address(RVA = "0x1608D08", Offset = "0x1608D08", Length = "0xFC")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000DF")]
		internal static Shader ShaderRef_MobileBitmap
		{
			[Token(Token = "0x60003FD")]
			[Address(RVA = "0x1608E04", Offset = "0x1608E04", Length = "0xFC")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x60003FE")]
		[Address(RVA = "0x1608F00", Offset = "0x1608F00", Length = "0x17C")]
		static ShaderUtilities()
		{
		}

		[Token(Token = "0x60003FF")]
		[Address(RVA = "0x1602610", Offset = "0x1602610", Length = "0xACC")]
		public static void GetShaderPropertyIDs()
		{
		}

		[Token(Token = "0x6000400")]
		[Address(RVA = "0x160907C", Offset = "0x160907C", Length = "0x45C")]
		public static void UpdateShaderRatios(Material mat)
		{
		}

		[Token(Token = "0x6000401")]
		[Address(RVA = "0x16094D8", Offset = "0x16094D8", Length = "0x44")]
		public static Vector4 GetFontExtent(Material material)
		{
			return default(Vector4);
		}

		[Token(Token = "0x6000402")]
		[Address(RVA = "0x160951C", Offset = "0x160951C", Length = "0x19C")]
		public static bool IsMaskingEnabled(Material material)
		{
			return false;
		}

		[Token(Token = "0x6000403")]
		[Address(RVA = "0x16096B8", Offset = "0x16096B8", Length = "0x6A8")]
		public static float GetPadding(Material material, bool enableExtraPadding, bool isBold)
		{
			return 0f;
		}

		[Token(Token = "0x6000404")]
		[Address(RVA = "0x1609D60", Offset = "0x1609D60", Length = "0x8F0")]
		public static float GetPadding(Material[] materials, bool enableExtraPadding, bool isBold)
		{
			return 0f;
		}
	}
}
