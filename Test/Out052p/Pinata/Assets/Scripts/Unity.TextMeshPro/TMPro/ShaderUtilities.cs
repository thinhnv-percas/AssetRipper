using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Token(Token = "0x200003C")]
	public static class ShaderUtilities
	{
		[Token(Token = "0x400021E")]
		public static int ID_MainTex;

		[Token(Token = "0x400021F")]
		public static int ID_FaceTex;

		[Token(Token = "0x4000220")]
		public static int ID_FaceColor;

		[Token(Token = "0x4000221")]
		public static int ID_FaceDilate;

		[Token(Token = "0x4000222")]
		public static int ID_Shininess;

		[Token(Token = "0x4000223")]
		public static int ID_UnderlayColor;

		[Token(Token = "0x4000224")]
		public static int ID_UnderlayOffsetX;

		[Token(Token = "0x4000225")]
		public static int ID_UnderlayOffsetY;

		[Token(Token = "0x4000226")]
		public static int ID_UnderlayDilate;

		[Token(Token = "0x4000227")]
		public static int ID_UnderlaySoftness;

		[Token(Token = "0x4000228")]
		public static int ID_WeightNormal;

		[Token(Token = "0x4000229")]
		public static int ID_WeightBold;

		[Token(Token = "0x400022A")]
		public static int ID_OutlineTex;

		[Token(Token = "0x400022B")]
		public static int ID_OutlineWidth;

		[Token(Token = "0x400022C")]
		public static int ID_OutlineSoftness;

		[Token(Token = "0x400022D")]
		public static int ID_OutlineColor;

		[Token(Token = "0x400022E")]
		public static int ID_Padding;

		[Token(Token = "0x400022F")]
		public static int ID_GradientScale;

		[Token(Token = "0x4000230")]
		public static int ID_ScaleX;

		[Token(Token = "0x4000231")]
		public static int ID_ScaleY;

		[Token(Token = "0x4000232")]
		public static int ID_PerspectiveFilter;

		[Token(Token = "0x4000233")]
		public static int ID_Sharpness;

		[Token(Token = "0x4000234")]
		public static int ID_TextureWidth;

		[Token(Token = "0x4000235")]
		public static int ID_TextureHeight;

		[Token(Token = "0x4000236")]
		public static int ID_BevelAmount;

		[Token(Token = "0x4000237")]
		public static int ID_GlowColor;

		[Token(Token = "0x4000238")]
		public static int ID_GlowOffset;

		[Token(Token = "0x4000239")]
		public static int ID_GlowPower;

		[Token(Token = "0x400023A")]
		public static int ID_GlowOuter;

		[Token(Token = "0x400023B")]
		public static int ID_LightAngle;

		[Token(Token = "0x400023C")]
		public static int ID_EnvMap;

		[Token(Token = "0x400023D")]
		public static int ID_EnvMatrix;

		[Token(Token = "0x400023E")]
		public static int ID_EnvMatrixRotation;

		[Token(Token = "0x400023F")]
		public static int ID_MaskCoord;

		[Token(Token = "0x4000240")]
		public static int ID_ClipRect;

		[Token(Token = "0x4000241")]
		public static int ID_MaskSoftnessX;

		[Token(Token = "0x4000242")]
		public static int ID_MaskSoftnessY;

		[Token(Token = "0x4000243")]
		public static int ID_VertexOffsetX;

		[Token(Token = "0x4000244")]
		public static int ID_VertexOffsetY;

		[Token(Token = "0x4000245")]
		public static int ID_UseClipRect;

		[Token(Token = "0x4000246")]
		public static int ID_StencilID;

		[Token(Token = "0x4000247")]
		public static int ID_StencilOp;

		[Token(Token = "0x4000248")]
		public static int ID_StencilComp;

		[Token(Token = "0x4000249")]
		public static int ID_StencilReadMask;

		[Token(Token = "0x400024A")]
		public static int ID_StencilWriteMask;

		[Token(Token = "0x400024B")]
		public static int ID_ShaderFlags;

		[Token(Token = "0x400024C")]
		public static int ID_ScaleRatio_A;

		[Token(Token = "0x400024D")]
		public static int ID_ScaleRatio_B;

		[Token(Token = "0x400024E")]
		public static int ID_ScaleRatio_C;

		[Token(Token = "0x400024F")]
		public static string Keyword_Bevel;

		[Token(Token = "0x4000250")]
		public static string Keyword_Glow;

		[Token(Token = "0x4000251")]
		public static string Keyword_Underlay;

		[Token(Token = "0x4000252")]
		public static string Keyword_Ratios;

		[Token(Token = "0x4000253")]
		public static string Keyword_MASK_SOFT;

		[Token(Token = "0x4000254")]
		public static string Keyword_MASK_HARD;

		[Token(Token = "0x4000255")]
		public static string Keyword_MASK_TEX;

		[Token(Token = "0x4000256")]
		public static string Keyword_Outline;

		[Token(Token = "0x4000257")]
		public static string ShaderTag_ZTestMode;

		[Token(Token = "0x4000258")]
		public static string ShaderTag_CullMode;

		[Token(Token = "0x4000259")]
		private static float m_clamp;

		[Token(Token = "0x400025A")]
		public static bool isInitialized;

		[Token(Token = "0x400025B")]
		private static Shader k_ShaderRef_MobileSDF;

		[Token(Token = "0x400025C")]
		private static Shader k_ShaderRef_MobileBitmap;

		[Token(Token = "0x170000B8")]
		internal static Shader ShaderRef_MobileSDF
		{
			[Token(Token = "0x600031D")]
			[Address(RVA = "0x919918", Offset = "0x919918", Length = "0x10C")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000B9")]
		internal static Shader ShaderRef_MobileBitmap
		{
			[Token(Token = "0x600031E")]
			[Address(RVA = "0x919A24", Offset = "0x919A24", Length = "0x10C")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x600031F")]
		[Address(RVA = "0x919B30", Offset = "0x919B30", Length = "0x124")]
		static ShaderUtilities()
		{
		}

		[Token(Token = "0x6000320")]
		[Address(RVA = "0x919C54", Offset = "0x919C54", Length = "0x7CC")]
		public static void GetShaderPropertyIDs()
		{
		}

		[Token(Token = "0x6000321")]
		[Address(RVA = "0x91A420", Offset = "0x91A420", Length = "0x538")]
		public static void UpdateShaderRatios(Material mat)
		{
		}

		[Token(Token = "0x6000322")]
		[Address(RVA = "0x91A958", Offset = "0x91A958", Length = "0x60")]
		public static Vector4 GetFontExtent(Material material)
		{
			return default(Vector4);
		}

		[Token(Token = "0x6000323")]
		[Address(RVA = "0x91A9B8", Offset = "0x91A9B8", Length = "0x1B8")]
		public static bool IsMaskingEnabled(Material material)
		{
			return false;
		}

		[Token(Token = "0x6000324")]
		[Address(RVA = "0x91AB70", Offset = "0x91AB70", Length = "0x8C8")]
		public static float GetPadding(Material material, bool enableExtraPadding, bool isBold)
		{
			return 0f;
		}

		[Token(Token = "0x6000325")]
		[Address(RVA = "0x91B438", Offset = "0x91B438", Length = "0xAB0")]
		public static float GetPadding(Material[] materials, bool enableExtraPadding, bool isBold)
		{
			return 0f;
		}
	}
}
