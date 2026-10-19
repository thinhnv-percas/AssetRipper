using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HighlightPlus
{
	[Token(Token = "0x2000040")]
	public static class ShaderParams
	{
		[Token(Token = "0x4000348")]
		public static int Cull;

		[Token(Token = "0x4000349")]
		public static int BlurScale;

		[Token(Token = "0x400034A")]
		public static int BlurScaleFirstHoriz;

		[Token(Token = "0x400034B")]
		public static int Speed;

		[Token(Token = "0x400034C")]
		public static int ConstantWidth;

		[Token(Token = "0x400034D")]
		public static int MinimumWidth;

		[Token(Token = "0x400034E")]
		public static int CutOff;

		[Token(Token = "0x400034F")]
		public static int ZTest;

		[Token(Token = "0x4000350")]
		public static int Flip;

		[Token(Token = "0x4000351")]
		public static int Debug;

		[Token(Token = "0x4000352")]
		public static int Color;

		[Token(Token = "0x4000353")]
		public static int MainTex;

		[Token(Token = "0x4000354")]
		public static int BaseMap;

		[Token(Token = "0x4000355")]
		public static int BaseMapST;

		[Token(Token = "0x4000356")]
		public static int BlendSrc;

		[Token(Token = "0x4000357")]
		public static int BlendDst;

		[Token(Token = "0x4000358")]
		public static int FadeFactor;

		[Token(Token = "0x4000359")]
		public static int Padding;

		[Token(Token = "0x400035A")]
		public static int ResampleScale;

		[Token(Token = "0x400035B")]
		public static int NoiseTex;

		[Token(Token = "0x400035C")]
		public static int Pixelation;

		[Token(Token = "0x400035D")]
		public static int OutlineWidth;

		[Token(Token = "0x400035E")]
		public static int OutlineZTest;

		[Token(Token = "0x400035F")]
		public static int OutlineDirection;

		[Token(Token = "0x4000360")]
		public static int OutlineColor;

		[Token(Token = "0x4000361")]
		public static int OutlineVertexWidth;

		[Token(Token = "0x4000362")]
		public static int OutlineGradientTex;

		[Token(Token = "0x4000363")]
		public static int OutlineVertexData;

		[Token(Token = "0x4000364")]
		public static int OutlineStencilComp;

		[Token(Token = "0x4000365")]
		public static int OutlineEdgeThreshold;

		[Token(Token = "0x4000366")]
		public static int OutlineSharpness;

		[Token(Token = "0x4000367")]
		public static int GlowZTest;

		[Token(Token = "0x4000368")]
		public static int GlowStencilComp;

		[Token(Token = "0x4000369")]
		public static int GlowStencilOp;

		[Token(Token = "0x400036A")]
		public static int GlowDirection;

		[Token(Token = "0x400036B")]
		public static int Glow;

		[Token(Token = "0x400036C")]
		public static int GlowColor;

		[Token(Token = "0x400036D")]
		public static int Glow2;

		[Token(Token = "0x400036E")]
		public static int SeeThrough;

		[Token(Token = "0x400036F")]
		public static int SeeThroughNoise;

		[Token(Token = "0x4000370")]
		public static int SeeThroughBorderWidth;

		[Token(Token = "0x4000371")]
		public static int SeeThroughBorderConstantWidth;

		[Token(Token = "0x4000372")]
		public static int SeeThroughTintColor;

		[Token(Token = "0x4000373")]
		public static int SeeThroughBorderColor;

		[Token(Token = "0x4000374")]
		public static int SeeThroughStencilRef;

		[Token(Token = "0x4000375")]
		public static int SeeThroughStencilComp;

		[Token(Token = "0x4000376")]
		public static int SeeThroughStencilPassOp;

		[Token(Token = "0x4000377")]
		public static int SeeThroughDepthOffset;

		[Token(Token = "0x4000378")]
		public static int SeeThroughMaxDepth;

		[Token(Token = "0x4000379")]
		public static int SeeThroughFadeRange;

		[Token(Token = "0x400037A")]
		public static int SeeThroughTexture;

		[Token(Token = "0x400037B")]
		public static int SeeThroughTextureScale;

		[Token(Token = "0x400037C")]
		public static int InnerGlowData;

		[Token(Token = "0x400037D")]
		public static int InnerGlowZTest;

		[Token(Token = "0x400037E")]
		public static int InnerGlowColor;

		[Token(Token = "0x400037F")]
		public static int InnerGlowBlendMode;

		[Token(Token = "0x4000380")]
		public static int MaskStencilRef;

		[Token(Token = "0x4000381")]
		public static int MaskWriteMask;

		[Token(Token = "0x4000382")]
		public static int FocusColor;

		[Token(Token = "0x4000383")]
		public static int FocusBlurTex;

		[Token(Token = "0x4000384")]
		public static int FocusBlurRT;

		[Token(Token = "0x4000385")]
		public static int FocusBlurTempRT;

		[Token(Token = "0x4000386")]
		public static int FocusDesaturation;

		[Token(Token = "0x4000387")]
		public static int OverlayData;

		[Token(Token = "0x4000388")]
		public static int OverlayBackColor;

		[Token(Token = "0x4000389")]
		public static int OverlayColor;

		[Token(Token = "0x400038A")]
		public static int OverlayHitPosData;

		[Token(Token = "0x400038B")]
		public static int OverlayHitStartTime;

		[Token(Token = "0x400038C")]
		public static int OverlayTexture;

		[Token(Token = "0x400038D")]
		public static int OverlayTextureScrolling;

		[Token(Token = "0x400038E")]
		public static int OverlayZTest;

		[Token(Token = "0x400038F")]
		public static int OverlayPatternScrolling;

		[Token(Token = "0x4000390")]
		public static int OverlayPatternData;

		[Token(Token = "0x4000391")]
		public static int TargetFXRenderData;

		[Token(Token = "0x4000392")]
		public static int TargetFXFrameData;

		[Token(Token = "0x4000393")]
		public static int GlowRT;

		[Token(Token = "0x4000394")]
		public static int OutlineRT;

		[Token(Token = "0x4000395")]
		public static int IconFXDarkColor;

		[Token(Token = "0x4000396")]
		public static int VertexTransformMode;

		[Token(Token = "0x4000397")]
		public static int PatternTex;

		[Token(Token = "0x4000398")]
		public static int DistortionTex;

		[Token(Token = "0x4000399")]
		public static int PatternData;

		[Token(Token = "0x400039A")]
		public static int DashData;

		[Token(Token = "0x400039B")]
		public static int OutlineGradientData;

		[Token(Token = "0x400039C")]
		public const string SKW_ALPHACLIP = "HP_ALPHACLIP";

		[Token(Token = "0x400039D")]
		public const string SKW_OUTLINE_GRADIENT_WS = "HP_OUTLINE_GRADIENT_WS";

		[Token(Token = "0x400039E")]
		public const string SKW_OUTLINE_GRADIENT_LS = "HP_OUTLINE_GRADIENT_LS";

		[Token(Token = "0x400039F")]
		public const string SKW_ALL_EDGES = "HP_ALL_EDGES";

		[Token(Token = "0x40003A0")]
		public const string SKW_DEPTHCLIP = "HP_DEPTHCLIP";

		[Token(Token = "0x40003A1")]
		public const string SKW_DEPTHCLIP_INV = "HP_DEPTHCLIP_INV";

		[Token(Token = "0x40003A2")]
		public const string SKW_DEPTH_OFFSET = "HP_DEPTH_OFFSET";

		[Token(Token = "0x40003A3")]
		public const string SKW_TEXTURE_TRIPLANAR = "HP_TEXTURE_TRIPLANAR";

		[Token(Token = "0x40003A4")]
		public const string SKW_TEXTURE_SCREENSPACE = "HP_TEXTURE_SCREENSPACE";

		[Token(Token = "0x40003A5")]
		public const string SKW_TEXTURE_OBJECTSPACE = "HP_TEXTURE_OBJECTSPACE";

		[Token(Token = "0x40003A6")]
		public const string SKW_SEETHROUGH_ONLY_BORDER = "HP_SEETHROUGH_ONLY_BORDER";

		[Token(Token = "0x40003A7")]
		public const string SKW_MASK_CUTOUT = "HP_MASK_CUTOUT";

		[Token(Token = "0x40003A8")]
		public const string SKW_DITHER_BLUENOISE = "HP_DITHER_BLUENOISE";

		[Token(Token = "0x40003A9")]
		public const string SKW_OUTLINE_STYLIZED = "HP_STYLIZED";

		[Token(Token = "0x40003AA")]
		public const string SKW_OUTLINE_DASHED = "HP_DASHED";

		[Token(Token = "0x40003AB")]
		public const string SKW_TARGET_FRAME = "HP_TARGET_FRAME";

		[Token(Token = "0x40003AC")]
		public const string SKW_TARGET_INWARD_CORNERS = "HP_TARGET_INWARD_CORNERS";

		[Token(Token = "0x40003AD")]
		public const string SKW_TARGET_CROSS = "HP_TARGET_CROSS";

		[Token(Token = "0x40003AE")]
		public const string SKW_PATTERN_POLKADOTS = "HP_PATTERN_POLKADOTS";

		[Token(Token = "0x40003AF")]
		public const string SKW_PATTERN_GRID = "HP_PATTERN_GRID";

		[Token(Token = "0x40003B0")]
		public const string SKW_PATTERN_STAGGERED_LINES = "HP_PATTERN_STAGGERED_LINES";

		[Token(Token = "0x40003B1")]
		public const string SKW_PATTERN_ZIGZAG = "HP_PATTERN_ZIGZAG";

		[Token(Token = "0x40003B2")]
		public const string SKW_SOURCE_SOLID_COLOR = "SOURCE_SOLID_COLOR";

		[Token(Token = "0x600013E")]
		[Address(RVA = "0x7733434", Offset = "0x7733434", Length = "0xED0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0129;\n\tv95.BlurScaleFirstHoriz = v90;\n\tv98 = UnityEngine.Shader::PropertyToID(\"_Speed\");\n\tv103.Speed = v98;\n\tv106 = UnityEngine.Shader::PropertyToID(\"_ConstantWidth\");\n\tv111.ConstantWidth = v106;\n\tv114 = UnityEngine.Shader::PropertyToID(\"_MinimumWidth\");\n\tv119.MinimumWidth = v114;\n\tv122 = UnityEngine.Shader::PropertyToID(\"_CutOff\");\n\tv127.CutOff = v122;\n\tv130 = UnityEngine.Shader::PropertyToID(\"_ZTest\");\n\tv135.ZTest = v130;\n\tv140 = UnityEngine.Shader::PropertyToID(\"_Flip\");\n\tv145.Flip = v140;\n\tv150 = UnityEngine.Shader::PropertyToID(\"_Debug\");\n\tv155.Debug = v150;\n\tv160 = UnityEngine.Shader::PropertyToID(\"_Color\");\n\tv165.Color = v160;\n\tv170 = UnityEngine.Shader::PropertyToID(\"_MainTex\");\n\tv175.MainTex = v170;\n\tv180 = UnityEngine.Shader::PropertyToID(\"_BaseMap\");\n\tv185.BaseMap = v180;\n\tv190 = UnityEngine.Shader::PropertyToID(\"_BaseMap_ST\");\n\tv195.BaseMapST = v190;\n\tv200 = UnityEngine.Shader::PropertyToID(\"_BlendSrc\");\n\tv205.BlendSrc = v200;\n\tv210 = UnityEngine.Shader::PropertyToID(\"_BlendDst\");\n\tv215.BlendDst = v210;\n\tv220 = UnityEngine.Shader::PropertyToID(\"_HP_Fade\");\n\tv225.FadeFactor = v220;\n\tv230 = UnityEngine.Shader::PropertyToID(\"_Padding\");\n\tv235.Padding = v230;\n\tv240 = UnityEngine.Shader::PropertyToID(\"_ResampleScale\");\n\tv245.ResampleScale = v240;\n\tv250 = UnityEngine.Shader::PropertyToID(\"_NoiseTex\");\n\tv255.NoiseTex = v250;\n\tv260 = UnityEngine.Shader::PropertyToID(\"_Pixelation\");\n\tv265.Pixelation = v260;\n\tv270 = UnityEngine.Shader::PropertyToID(\"_OutlineWidth\");\n\tv275.OutlineWidth = v270;\n\tv280 = UnityEngine.Shader::PropertyToID(\"_OutlineZTest\");\n\tv285.OutlineZTest = v280;\n\tv290 = UnityEngine.Shader::PropertyToID(\"_OutlineDirection\");\n\tv295.OutlineDirection = v290;\n\tv300 = UnityEngine.Shader::PropertyToID(\"_OutlineColor\");\n\tv305.OutlineColor = v300;\n\tv310 = UnityEngine.Shader::PropertyToID(\"_OutlineVertexWidth\");\n\tv315.OutlineVertexWidth = v310;\n\tv320 = UnityEngine.Shader::PropertyToID(\"_OutlineGradientTex\");\n\tv325.OutlineGradientTex = v320;\n\tv330 = UnityEngine.Shader::PropertyToID(\"_OutlineVertexData\");\n\tv335.OutlineVertexData = v330;\n\tv340 = UnityEngine.Shader::PropertyToID(\"_OutlineStencilComp\");\n\tv345.OutlineStencilComp = v340;\n\tv350 = UnityEngine.Shader::PropertyToID(\"_EdgeThreshold\");\n\tv355.OutlineEdgeThreshold = v350;\n\tv360 = UnityEngine.Shader::PropertyToID(\"_OutlineSharpness\");\n\tv365.OutlineSharpness = v360;\n\tv370 = UnityEngine.Shader::PropertyToID(\"_GlowZTest\");\n\tv375.GlowZTest = v370;\n\tv380 = UnityEngine.Shader::PropertyToID(\"_GlowStencilComp\");\n\tv385.GlowStencilComp = v380;\n\tv390 = UnityEngine.Shader::PropertyToID(\"_GlowStencilOp\");\n\tv395.GlowStencilOp = v390;\n\tv400 = UnityEngine.Shader::PropertyToID(\"_GlowDirection\");\n\tv405.GlowDirection = v400;\n\tv410 = UnityEngine.Shader::PropertyToID(\"_Glow\");\n\tv415.Glow = v410;\n\tv420 = UnityEngine.Shader::PropertyToID(\"_GlowColor\");\n\tv425.GlowColor = v420;\n\tv430 = UnityEngine.Shader::PropertyToID(\"_Glow2\");\n\tv435.Glow2 = v430;\n\tv440 = UnityEngine.Shader::PropertyToID(\"_SeeThrough\");\n\tv445.SeeThrough = v440;\n\tv450 = UnityEngine.Shader::PropertyToID(\"_SeeThroughNoise\");\n\tv455.SeeThroughNoise = v450;\n\tv460 = UnityEngine.Shader::PropertyToID(\"_SeeThroughBorderWidth\");\n\tv465.SeeThroughBorderWidth = v460;\n\tv470 = UnityEngine.Shader::PropertyToID(\"_SeeThroughBorderConstantWidth\");\n\tv475.SeeThroughBorderConstantWidth = v470;\n\tv480 = UnityEngine.Shader::PropertyToID(\"_SeeThroughTintColor\");\n\tv485.SeeThroughTintColor = v480;\n\tv490 = UnityEngine.Shader::PropertyToID(\"_SeeThroughBorderColor\");\n\tv495.SeeThroughBorderColor = v490;\n\tv500 = UnityEngine.Shader::PropertyToID(\"_SeeThroughStencilRef\");\n\tv505.SeeThroughStencilRef = v500;\n\tv510 = UnityEngine.Shader::PropertyToID(\"_SeeThroughStencilComp\");\n\tv515.SeeThroughStencilComp = v510;\n\tv520 = UnityEngine.Shader::PropertyToID(\"_SeeThroughStencilPassOp\");\n\tv525.SeeThroughStencilPassOp = v520;\n\tv530 = UnityEngine.Shader::PropertyToID(\"_SeeThroughDepthOffset\");\n\tv535.SeeThroughDepthOffset = v530;\n\tv540 = UnityEngine.Shader::PropertyToID(\"_SeeThroughMaxDepth\");\n\tv545.SeeThroughMaxDepth = v540;\n\tv550 = UnityEngine.Shader::PropertyToID(\"_SeeThroughFadeRange\");\n\tv555.SeeThroughFadeRange = v550;\n\tv560 = UnityEngine.Shader::PropertyToID(\"_SeeThroughTexture\");\n\tv565.SeeThroughTexture = v560;\n\tv570 = UnityEngine.Shader::PropertyToID(\"_SeeThroughTextureScale\");\n\tv575.SeeThroughTextureScale = v570;\n\tv580 = UnityEngine.Shader::PropertyToID(\"_InnerGlowData\");\n\tv585.InnerGlowData = v580;\n\tv590 = UnityEngine.Shader::PropertyToID(\"_InnerGlowZTest\");\n\tv595.InnerGlowZTest = v590;\n\tv600 = UnityEngine.Shader::PropertyToID(\"_InnerGlowColor\");\n\tv605.InnerGlowColor = v600;\n\tv610 = UnityEngine.Shader::PropertyToID(\"_InnerGlowBlendMode\");\n\tv615.InnerGlowBlendMode = v610;\n\tv620 = UnityEngine.Shader::PropertyToID(\"_MaskStencilRef\");\n\tv625.MaskStencilRef = v620;\n\tv630 = UnityEngine.Shader::PropertyToID(\"_MaskWriteMask\");\n\tv635.MaskWriteMask = v630;\n\tv640 = UnityEngine.Shader::PropertyToID(\"_FocusColor\");\n\tv645.FocusColor = v640;\n\tv650 = UnityEngine.Shader::PropertyToID(\"_FocusBlurTex\");\n\tv655.FocusBlurTex = v650;\n\tv660 = UnityEngine.Shader::PropertyToID(\"_HPFocusBlurRT\");\n\tv665.FocusBlurRT = v660;\n\tv670 = UnityEngine.Shader::PropertyToID(\"_HPFocusBlurTempRT\");\n\tv675.FocusBlurTempRT = v670;\n\tv680 = UnityEngine.Shader::PropertyToID(\"_FocusDesaturation\");\n\tv685.FocusDesaturation = v680;\n\tv690 = UnityEngine.Shader::PropertyToID(\"_OverlayData\");\n\tv695.OverlayData = v690;\n\tv700 = UnityEngine.Shader::PropertyToID(\"_OverlayBackColor\");\n\tv705.OverlayBackColor = v700;\n\tv710 = UnityEngine.Shader::PropertyToID(\"_OverlayColor\");\n\tv715.OverlayColor = v710;\n\tv720 = UnityEngine.Shader::PropertyToID(\"_OverlayHitPosData\");\n\tv725.OverlayHitPosData = v720;\n\tv730 = UnityEngine.Shader::PropertyToID(\"_OverlayHitStartTime\");\n\tv735.OverlayHitStartTime = v730;\n\tv740 = UnityEngine.Shader::PropertyToID(\"_OverlayTexture\");\n\tv745.OverlayTexture = v740;\n\tv750 = UnityEngine.Shader::PropertyToID(\"_OverlayTextureScrolling\");\n\tv755.OverlayTextureScrolling = v750;\n\tv760 = UnityEngine.Shader::PropertyToID(\"_OverlayZTest\");\n\tv765.OverlayZTest = v760;\n\tv770 = UnityEngine.Shader::PropertyToID(\"_OverlayPatternScrolling\");\n\tv775.OverlayPatternScrolling = v770;\n\tv780 = UnityEngine.Shader::PropertyToID(\"_OverlayPatternData\");\n\tv785.OverlayPatternData = v780;\n\tv790 = UnityEngine.Shader::PropertyToID(\"_TargetFXRenderData\");\n\tv795.TargetFXRenderData = v790;\n\tv800 = UnityEngine.Shader::PropertyToID(\"_TargetFXFrameData\");\n\tv805.TargetFXFrameData = v800;\n\tv810 = UnityEngine.Shader::PropertyToID(\"_HPComposeGlowFinal\");\n\tv815.GlowRT = v810;\n\tv820 = UnityEngine.Shader::PropertyToID(\"_HPComposeOutlineFinal\");\n\tv825.OutlineRT = v820;\n\tv830 = UnityEngine.Shader::PropertyToID(\"_DarkColor\");\n\tv835.IconFXDarkColor = v830;\n\tv840 = UnityEngine.Shader::PropertyToID(\"_HP_VertexTransformMode\");\n\tv845.VertexTransformMode = v840;\n\tv850 = UnityEngine.Shader::PropertyToID(\"_PatternTex\");\n\tv855.PatternTex = v850;\n\tv860 = UnityEngine.Shader::PropertyToID(\"_DistortionTex\");\n\tv865.DistortionTex = v860;\n\tv870 = UnityEngine.Shader::PropertyToID(\"_PatternData\");\n\tv875.PatternData = v870;\n\tv880 = UnityEngine.Shader::PropertyToID(\"_DashData\");\n\tv885.DashData = v880;\n\tv890 = UnityEngine.Shader::PropertyToID(\"_OutlineGradientData\");\n\tv894.OutlineGradientData = v890;\n\treturn;\nL_0129:\n\tv74 = UnityEngine.Shader::PropertyToID(\"_Cull\");\n\tv79.Cull = v74;\n\tv82 = UnityEngine.Shader::PropertyToID(\"_BlurScale\");\n\tv87.BlurScale = v82;\n\tv90 = UnityEngine.Shader::PropertyToID(\"_BlurScaleFirstHoriz\");\n")]
		static ShaderParams()
		{
			int cull = Shader.PropertyToID("_Cull");
			Cull = cull;
			int blurScale = Shader.PropertyToID("_BlurScale");
			BlurScale = blurScale;
			int blurScaleFirstHoriz = Shader.PropertyToID("_BlurScaleFirstHoriz");
			BlurScaleFirstHoriz = blurScaleFirstHoriz;
			int speed = Shader.PropertyToID("_Speed");
			Speed = speed;
			int constantWidth = Shader.PropertyToID("_ConstantWidth");
			ConstantWidth = constantWidth;
			int minimumWidth = Shader.PropertyToID("_MinimumWidth");
			MinimumWidth = minimumWidth;
			int cutOff = Shader.PropertyToID("_CutOff");
			CutOff = cutOff;
			int zTest = Shader.PropertyToID("_ZTest");
			ZTest = zTest;
			int flip = Shader.PropertyToID("_Flip");
			Flip = flip;
			int debug = Shader.PropertyToID("_Debug");
			Debug = debug;
			int color = Shader.PropertyToID("_Color");
			Color = color;
			int mainTex = Shader.PropertyToID("_MainTex");
			MainTex = mainTex;
			int baseMap = Shader.PropertyToID("_BaseMap");
			BaseMap = baseMap;
			int baseMapST = Shader.PropertyToID("_BaseMap_ST");
			BaseMapST = baseMapST;
			int blendSrc = Shader.PropertyToID("_BlendSrc");
			BlendSrc = blendSrc;
			int blendDst = Shader.PropertyToID("_BlendDst");
			BlendDst = blendDst;
			int fadeFactor = Shader.PropertyToID("_HP_Fade");
			FadeFactor = fadeFactor;
			int padding = Shader.PropertyToID("_Padding");
			Padding = padding;
			int resampleScale = Shader.PropertyToID("_ResampleScale");
			ResampleScale = resampleScale;
			int noiseTex = Shader.PropertyToID("_NoiseTex");
			NoiseTex = noiseTex;
			int pixelation = Shader.PropertyToID("_Pixelation");
			Pixelation = pixelation;
			int outlineWidth = Shader.PropertyToID("_OutlineWidth");
			OutlineWidth = outlineWidth;
			int outlineZTest = Shader.PropertyToID("_OutlineZTest");
			OutlineZTest = outlineZTest;
			int outlineDirection = Shader.PropertyToID("_OutlineDirection");
			OutlineDirection = outlineDirection;
			int outlineColor = Shader.PropertyToID("_OutlineColor");
			OutlineColor = outlineColor;
			int outlineVertexWidth = Shader.PropertyToID("_OutlineVertexWidth");
			OutlineVertexWidth = outlineVertexWidth;
			int outlineGradientTex = Shader.PropertyToID("_OutlineGradientTex");
			OutlineGradientTex = outlineGradientTex;
			int outlineVertexData = Shader.PropertyToID("_OutlineVertexData");
			OutlineVertexData = outlineVertexData;
			int outlineStencilComp = Shader.PropertyToID("_OutlineStencilComp");
			OutlineStencilComp = outlineStencilComp;
			int outlineEdgeThreshold = Shader.PropertyToID("_EdgeThreshold");
			OutlineEdgeThreshold = outlineEdgeThreshold;
			int outlineSharpness = Shader.PropertyToID("_OutlineSharpness");
			OutlineSharpness = outlineSharpness;
			int glowZTest = Shader.PropertyToID("_GlowZTest");
			GlowZTest = glowZTest;
			int glowStencilComp = Shader.PropertyToID("_GlowStencilComp");
			GlowStencilComp = glowStencilComp;
			int glowStencilOp = Shader.PropertyToID("_GlowStencilOp");
			GlowStencilOp = glowStencilOp;
			int glowDirection = Shader.PropertyToID("_GlowDirection");
			GlowDirection = glowDirection;
			int glow = Shader.PropertyToID("_Glow");
			Glow = glow;
			int glowColor = Shader.PropertyToID("_GlowColor");
			GlowColor = glowColor;
			int glow2 = Shader.PropertyToID("_Glow2");
			Glow2 = glow2;
			int seeThrough = Shader.PropertyToID("_SeeThrough");
			SeeThrough = seeThrough;
			int seeThroughNoise = Shader.PropertyToID("_SeeThroughNoise");
			SeeThroughNoise = seeThroughNoise;
			int seeThroughBorderWidth = Shader.PropertyToID("_SeeThroughBorderWidth");
			SeeThroughBorderWidth = seeThroughBorderWidth;
			int seeThroughBorderConstantWidth = Shader.PropertyToID("_SeeThroughBorderConstantWidth");
			SeeThroughBorderConstantWidth = seeThroughBorderConstantWidth;
			int seeThroughTintColor = Shader.PropertyToID("_SeeThroughTintColor");
			SeeThroughTintColor = seeThroughTintColor;
			int seeThroughBorderColor = Shader.PropertyToID("_SeeThroughBorderColor");
			SeeThroughBorderColor = seeThroughBorderColor;
			int seeThroughStencilRef = Shader.PropertyToID("_SeeThroughStencilRef");
			SeeThroughStencilRef = seeThroughStencilRef;
			int seeThroughStencilComp = Shader.PropertyToID("_SeeThroughStencilComp");
			SeeThroughStencilComp = seeThroughStencilComp;
			int seeThroughStencilPassOp = Shader.PropertyToID("_SeeThroughStencilPassOp");
			SeeThroughStencilPassOp = seeThroughStencilPassOp;
			int seeThroughDepthOffset = Shader.PropertyToID("_SeeThroughDepthOffset");
			SeeThroughDepthOffset = seeThroughDepthOffset;
			int seeThroughMaxDepth = Shader.PropertyToID("_SeeThroughMaxDepth");
			SeeThroughMaxDepth = seeThroughMaxDepth;
			int seeThroughFadeRange = Shader.PropertyToID("_SeeThroughFadeRange");
			SeeThroughFadeRange = seeThroughFadeRange;
			int seeThroughTexture = Shader.PropertyToID("_SeeThroughTexture");
			SeeThroughTexture = seeThroughTexture;
			int seeThroughTextureScale = Shader.PropertyToID("_SeeThroughTextureScale");
			SeeThroughTextureScale = seeThroughTextureScale;
			int innerGlowData = Shader.PropertyToID("_InnerGlowData");
			InnerGlowData = innerGlowData;
			int innerGlowZTest = Shader.PropertyToID("_InnerGlowZTest");
			InnerGlowZTest = innerGlowZTest;
			int innerGlowColor = Shader.PropertyToID("_InnerGlowColor");
			InnerGlowColor = innerGlowColor;
			int innerGlowBlendMode = Shader.PropertyToID("_InnerGlowBlendMode");
			InnerGlowBlendMode = innerGlowBlendMode;
			int maskStencilRef = Shader.PropertyToID("_MaskStencilRef");
			MaskStencilRef = maskStencilRef;
			int maskWriteMask = Shader.PropertyToID("_MaskWriteMask");
			MaskWriteMask = maskWriteMask;
			int focusColor = Shader.PropertyToID("_FocusColor");
			FocusColor = focusColor;
			int focusBlurTex = Shader.PropertyToID("_FocusBlurTex");
			FocusBlurTex = focusBlurTex;
			int focusBlurRT = Shader.PropertyToID("_HPFocusBlurRT");
			FocusBlurRT = focusBlurRT;
			int focusBlurTempRT = Shader.PropertyToID("_HPFocusBlurTempRT");
			FocusBlurTempRT = focusBlurTempRT;
			int focusDesaturation = Shader.PropertyToID("_FocusDesaturation");
			FocusDesaturation = focusDesaturation;
			int overlayData = Shader.PropertyToID("_OverlayData");
			OverlayData = overlayData;
			int overlayBackColor = Shader.PropertyToID("_OverlayBackColor");
			OverlayBackColor = overlayBackColor;
			int overlayColor = Shader.PropertyToID("_OverlayColor");
			OverlayColor = overlayColor;
			int overlayHitPosData = Shader.PropertyToID("_OverlayHitPosData");
			OverlayHitPosData = overlayHitPosData;
			int overlayHitStartTime = Shader.PropertyToID("_OverlayHitStartTime");
			OverlayHitStartTime = overlayHitStartTime;
			int overlayTexture = Shader.PropertyToID("_OverlayTexture");
			OverlayTexture = overlayTexture;
			int overlayTextureScrolling = Shader.PropertyToID("_OverlayTextureScrolling");
			OverlayTextureScrolling = overlayTextureScrolling;
			int overlayZTest = Shader.PropertyToID("_OverlayZTest");
			OverlayZTest = overlayZTest;
			int overlayPatternScrolling = Shader.PropertyToID("_OverlayPatternScrolling");
			OverlayPatternScrolling = overlayPatternScrolling;
			int overlayPatternData = Shader.PropertyToID("_OverlayPatternData");
			OverlayPatternData = overlayPatternData;
			int targetFXRenderData = Shader.PropertyToID("_TargetFXRenderData");
			TargetFXRenderData = targetFXRenderData;
			int targetFXFrameData = Shader.PropertyToID("_TargetFXFrameData");
			TargetFXFrameData = targetFXFrameData;
			int glowRT = Shader.PropertyToID("_HPComposeGlowFinal");
			GlowRT = glowRT;
			int outlineRT = Shader.PropertyToID("_HPComposeOutlineFinal");
			OutlineRT = outlineRT;
			int iconFXDarkColor = Shader.PropertyToID("_DarkColor");
			IconFXDarkColor = iconFXDarkColor;
			int vertexTransformMode = Shader.PropertyToID("_HP_VertexTransformMode");
			VertexTransformMode = vertexTransformMode;
			int patternTex = Shader.PropertyToID("_PatternTex");
			PatternTex = patternTex;
			int distortionTex = Shader.PropertyToID("_DistortionTex");
			DistortionTex = distortionTex;
			int patternData = Shader.PropertyToID("_PatternData");
			PatternData = patternData;
			int dashData = Shader.PropertyToID("_DashData");
			DashData = dashData;
			int outlineGradientData = Shader.PropertyToID("_OutlineGradientData");
			OutlineGradientData = outlineGradientData;
		}
	}
}
