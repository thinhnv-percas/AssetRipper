using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace TMPro
{
	[Token(Token = "0x2000052")]
	public abstract class TMP_Text : MaskableGraphic
	{
		[Token(Token = "0x2000098")]
		internal enum TextInputSources
		{
			[Token(Token = "0x40004FA")]
			Text = 0,
			[Token(Token = "0x40004FB")]
			SetText = 1,
			[Token(Token = "0x40004FC")]
			SetCharArray = 2,
			[Token(Token = "0x40004FD")]
			String = 3
		}

		[StructLayout((LayoutKind)0, Size = 12)]
		[Token(Token = "0x2000099")]
		protected struct UnicodeChar
		{
			[Token(Token = "0x40004FE")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int unicode;

			[Token(Token = "0x40004FF")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x4")]
			public int stringIndex;

			[Token(Token = "0x4000500")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public int length;
		}

		[SerializeField]
		[Attribute(Type = typeof(TextAreaAttribute), RVA = "0x74900C", Offset = "0x74900C")]
		[Token(Token = "0x40002F9")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xC0")]
		protected string m_text;

		[SerializeField]
		[Token(Token = "0x40002FA")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xC8")]
		protected bool m_isRightToLeft;

		[SerializeField]
		[Token(Token = "0x40002FB")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xD0")]
		protected TMP_FontAsset m_fontAsset;

		[Token(Token = "0x40002FC")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xD8")]
		protected TMP_FontAsset m_currentFontAsset;

		[Token(Token = "0x40002FD")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xE0")]
		protected bool m_isSDFShader;

		[SerializeField]
		[Token(Token = "0x40002FE")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xE8")]
		protected Material m_sharedMaterial;

		[Token(Token = "0x40002FF")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xF0")]
		protected Material m_currentMaterial;

		[Token(Token = "0x4000300")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xF8")]
		protected MaterialReference[] m_materialReferences;

		[Token(Token = "0x4000301")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x100")]
		protected Dictionary<int, int> m_materialReferenceIndexLookup;

		[Token(Token = "0x4000302")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x108")]
		protected TMP_RichTextTagStack<MaterialReference> m_materialReferenceStack;

		[Token(Token = "0x4000303")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x150")]
		protected int m_currentMaterialIndex;

		[SerializeField]
		[Token(Token = "0x4000304")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x158")]
		protected Material[] m_fontSharedMaterials;

		[SerializeField]
		[Token(Token = "0x4000305")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x160")]
		protected Material m_fontMaterial;

		[SerializeField]
		[Token(Token = "0x4000306")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x168")]
		protected Material[] m_fontMaterials;

		[Token(Token = "0x4000307")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x170")]
		protected bool m_isMaterialDirty;

		[SerializeField]
		[Token(Token = "0x4000308")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x174")]
		protected Color32 m_fontColor32;

		[SerializeField]
		[Token(Token = "0x4000309")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x178")]
		protected Color m_fontColor;

		[Token(Token = "0x400030A")]
		protected static Color32 s_colorWhite;

		[Token(Token = "0x400030B")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x188")]
		protected Color32 m_underlineColor;

		[Token(Token = "0x400030C")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x18C")]
		protected Color32 m_strikethroughColor;

		[Token(Token = "0x400030D")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x190")]
		protected Color32 m_highlightColor;

		[Token(Token = "0x400030E")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x194")]
		protected Vector4 m_highlightPadding;

		[SerializeField]
		[Token(Token = "0x400030F")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x1A4")]
		protected bool m_enableVertexGradient;

		[SerializeField]
		[Token(Token = "0x4000310")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x1A8")]
		protected ColorMode m_colorMode;

		[SerializeField]
		[Token(Token = "0x4000311")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x1AC")]
		protected VertexGradient m_fontColorGradient;

		[SerializeField]
		[Token(Token = "0x4000312")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x1F0")]
		protected TMP_ColorGradient m_fontColorGradientPreset;

		[SerializeField]
		[Token(Token = "0x4000313")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x1F8")]
		protected TMP_SpriteAsset m_spriteAsset;

		[SerializeField]
		[Token(Token = "0x4000314")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x200")]
		protected bool m_tintAllSprites;

		[Token(Token = "0x4000315")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x201")]
		protected bool m_tintSprite;

		[Token(Token = "0x4000316")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x204")]
		protected Color32 m_spriteColor;

		[SerializeField]
		[Token(Token = "0x4000317")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x208")]
		protected bool m_overrideHtmlColors;

		[SerializeField]
		[Token(Token = "0x4000318")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x20C")]
		protected Color32 m_faceColor;

		[SerializeField]
		[Token(Token = "0x4000319")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x210")]
		protected Color32 m_outlineColor;

		[Token(Token = "0x400031A")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x214")]
		protected float m_outlineWidth;

		[SerializeField]
		[Token(Token = "0x400031B")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x218")]
		protected float m_fontSize;

		[Token(Token = "0x400031C")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x21C")]
		protected float m_currentFontSize;

		[SerializeField]
		[Token(Token = "0x400031D")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x220")]
		protected float m_fontSizeBase;

		[Token(Token = "0x400031E")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x228")]
		protected TMP_RichTextTagStack<float> m_sizeStack;

		[SerializeField]
		[Token(Token = "0x400031F")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x240")]
		protected FontWeight m_fontWeight;

		[Token(Token = "0x4000320")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x244")]
		protected FontWeight m_FontWeightInternal;

		[Token(Token = "0x4000321")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x248")]
		protected TMP_RichTextTagStack<FontWeight> m_FontWeightStack;

		[SerializeField]
		[Token(Token = "0x4000322")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x260")]
		protected bool m_enableAutoSizing;

		[Token(Token = "0x4000323")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x264")]
		protected float m_maxFontSize;

		[Token(Token = "0x4000324")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x268")]
		protected float m_minFontSize;

		[SerializeField]
		[Token(Token = "0x4000325")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x26C")]
		protected float m_fontSizeMin;

		[SerializeField]
		[Token(Token = "0x4000326")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x270")]
		protected float m_fontSizeMax;

		[SerializeField]
		[Token(Token = "0x4000327")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x274")]
		protected FontStyles m_fontStyle;

		[Token(Token = "0x4000328")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x278")]
		protected FontStyles m_FontStyleInternal;

		[Token(Token = "0x4000329")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x27C")]
		protected TMP_FontStyleStack m_fontStyleStack;

		[Token(Token = "0x400032A")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x286")]
		protected bool m_isUsingBold;

		[SerializeField]
		[Attribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x7491CC", Offset = "0x7491CC")]
		[Token(Token = "0x400032B")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x288")]
		protected TextAlignmentOptions m_textAlignment;

		[Token(Token = "0x400032C")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x28C")]
		protected TextAlignmentOptions m_lineJustification;

		[Token(Token = "0x400032D")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x290")]
		protected TMP_RichTextTagStack<TextAlignmentOptions> m_lineJustificationStack;

		[Token(Token = "0x400032E")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x2A8")]
		protected Vector3[] m_textContainerLocalCorners;

		[SerializeField]
		[Token(Token = "0x400032F")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x2B0")]
		protected float m_characterSpacing;

		[Token(Token = "0x4000330")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x2B4")]
		protected float m_cSpacing;

		[Token(Token = "0x4000331")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x2B8")]
		protected float m_monoSpacing;

		[SerializeField]
		[Token(Token = "0x4000332")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x2BC")]
		protected float m_wordSpacing;

		[SerializeField]
		[Token(Token = "0x4000333")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x2C0")]
		protected float m_lineSpacing;

		[Token(Token = "0x4000334")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x2C4")]
		protected float m_lineSpacingDelta;

		[Token(Token = "0x4000335")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x2C8")]
		protected float m_lineHeight;

		[SerializeField]
		[Token(Token = "0x4000336")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x2CC")]
		protected float m_lineSpacingMax;

		[SerializeField]
		[Token(Token = "0x4000337")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x2D0")]
		protected float m_paragraphSpacing;

		[SerializeField]
		[Token(Token = "0x4000338")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x2D4")]
		protected float m_charWidthMaxAdj;

		[Token(Token = "0x4000339")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x2D8")]
		protected float m_charWidthAdjDelta;

		[SerializeField]
		[Token(Token = "0x400033A")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x2DC")]
		protected bool m_enableWordWrapping;

		[Token(Token = "0x400033B")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x2DD")]
		protected bool m_isCharacterWrappingEnabled;

		[Token(Token = "0x400033C")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x2DE")]
		protected bool m_isNonBreakingSpace;

		[Token(Token = "0x400033D")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x2DF")]
		protected bool m_isIgnoringAlignment;

		[SerializeField]
		[Token(Token = "0x400033E")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x2E0")]
		protected float m_wordWrappingRatios;

		[SerializeField]
		[Token(Token = "0x400033F")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x2E4")]
		protected TextOverflowModes m_overflowMode;

		[SerializeField]
		[Token(Token = "0x4000340")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x2E8")]
		protected int m_firstOverflowCharacterIndex;

		[SerializeField]
		[Token(Token = "0x4000341")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x2F0")]
		protected TMP_Text m_linkedTextComponent;

		[SerializeField]
		[Token(Token = "0x4000342")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x2F8")]
		protected bool m_isLinkedTextComponent;

		[SerializeField]
		[Token(Token = "0x4000343")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x2F9")]
		protected bool m_isTextTruncated;

		[SerializeField]
		[Token(Token = "0x4000344")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x2FA")]
		protected bool m_enableKerning;

		[SerializeField]
		[Token(Token = "0x4000345")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x2FB")]
		protected bool m_enableExtraPadding;

		[SerializeField]
		[Token(Token = "0x4000346")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x2FC")]
		protected bool checkPaddingRequired;

		[SerializeField]
		[Token(Token = "0x4000347")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x2FD")]
		protected bool m_isRichText;

		[SerializeField]
		[Token(Token = "0x4000348")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x2FE")]
		protected bool m_parseCtrlCharacters;

		[Token(Token = "0x4000349")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x2FF")]
		protected bool m_isOverlay;

		[SerializeField]
		[Token(Token = "0x400034A")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x300")]
		protected bool m_isOrthographic;

		[SerializeField]
		[Token(Token = "0x400034B")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x301")]
		protected bool m_isCullingEnabled;

		[SerializeField]
		[Token(Token = "0x400034C")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x302")]
		protected bool m_ignoreRectMaskCulling;

		[SerializeField]
		[Token(Token = "0x400034D")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x303")]
		protected bool m_ignoreCulling;

		[SerializeField]
		[Token(Token = "0x400034E")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x304")]
		protected TextureMappingOptions m_horizontalMapping;

		[SerializeField]
		[Token(Token = "0x400034F")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x308")]
		protected TextureMappingOptions m_verticalMapping;

		[SerializeField]
		[Token(Token = "0x4000350")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x30C")]
		protected float m_uvLineOffset;

		[Token(Token = "0x4000351")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x310")]
		protected TextRenderFlags m_renderMode;

		[SerializeField]
		[Token(Token = "0x4000352")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x314")]
		protected VertexSortingOrder m_geometrySortingOrder;

		[SerializeField]
		[Token(Token = "0x4000353")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x318")]
		protected bool m_VertexBufferAutoSizeReduction;

		[SerializeField]
		[Token(Token = "0x4000354")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x31C")]
		protected int m_firstVisibleCharacter;

		[Token(Token = "0x4000355")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x320")]
		protected int m_maxVisibleCharacters;

		[Token(Token = "0x4000356")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x324")]
		protected int m_maxVisibleWords;

		[Token(Token = "0x4000357")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x328")]
		protected int m_maxVisibleLines;

		[SerializeField]
		[Token(Token = "0x4000358")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x32C")]
		protected bool m_useMaxVisibleDescender;

		[SerializeField]
		[Token(Token = "0x4000359")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x330")]
		protected int m_pageToDisplay;

		[Token(Token = "0x400035A")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x334")]
		protected bool m_isNewPage;

		[SerializeField]
		[Token(Token = "0x400035B")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x338")]
		protected Vector4 m_margin;

		[Token(Token = "0x400035C")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x348")]
		protected float m_marginLeft;

		[Token(Token = "0x400035D")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x34C")]
		protected float m_marginRight;

		[Token(Token = "0x400035E")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x350")]
		protected float m_marginWidth;

		[Token(Token = "0x400035F")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x354")]
		protected float m_marginHeight;

		[Token(Token = "0x4000360")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x358")]
		protected float m_width;

		[SerializeField]
		[Token(Token = "0x4000361")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x360")]
		protected TMP_TextInfo m_textInfo;

		[Token(Token = "0x4000362")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x368")]
		protected bool m_havePropertiesChanged;

		[SerializeField]
		[Token(Token = "0x4000363")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x369")]
		protected bool m_isUsingLegacyAnimationComponent;

		[Token(Token = "0x4000364")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x370")]
		protected Transform m_transform;

		[Token(Token = "0x4000365")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x378")]
		protected RectTransform m_rectTransform;

		[Token(Token = "0x4000367")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x381")]
		protected bool m_autoSizeTextContainer;

		[Token(Token = "0x4000368")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x388")]
		protected Mesh m_mesh;

		[SerializeField]
		[Token(Token = "0x4000369")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x390")]
		protected bool m_isVolumetricText;

		[SerializeField]
		[Token(Token = "0x400036A")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x398")]
		protected TMP_SpriteAnimator m_spriteAnimator;

		[Token(Token = "0x400036B")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x3A0")]
		protected float m_flexibleHeight;

		[Token(Token = "0x400036C")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x3A4")]
		protected float m_flexibleWidth;

		[Token(Token = "0x400036D")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x3A8")]
		protected float m_minWidth;

		[Token(Token = "0x400036E")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x3AC")]
		protected float m_minHeight;

		[Token(Token = "0x400036F")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x3B0")]
		protected float m_maxWidth;

		[Token(Token = "0x4000370")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x3B4")]
		protected float m_maxHeight;

		[Token(Token = "0x4000371")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x3B8")]
		protected LayoutElement m_LayoutElement;

		[Token(Token = "0x4000372")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x3C0")]
		protected float m_preferredWidth;

		[Token(Token = "0x4000373")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x3C4")]
		protected float m_renderedWidth;

		[Token(Token = "0x4000374")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x3C8")]
		protected bool m_isPreferredWidthDirty;

		[Token(Token = "0x4000375")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x3CC")]
		protected float m_preferredHeight;

		[Token(Token = "0x4000376")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x3D0")]
		protected float m_renderedHeight;

		[Token(Token = "0x4000377")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x3D4")]
		protected bool m_isPreferredHeightDirty;

		[Token(Token = "0x4000378")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x3D5")]
		protected bool m_isCalculatingPreferredValues;

		[Token(Token = "0x4000379")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x3D8")]
		private int m_recursiveCount;

		[Token(Token = "0x400037A")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x3DC")]
		protected int m_layoutPriority;

		[Token(Token = "0x400037B")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x3E0")]
		protected bool m_isCalculateSizeRequired;

		[Token(Token = "0x400037C")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x3E1")]
		protected bool m_isLayoutDirty;

		[Token(Token = "0x400037D")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x3E2")]
		protected bool m_verticesAlreadyDirty;

		[Token(Token = "0x400037E")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x3E3")]
		protected bool m_layoutAlreadyDirty;

		[Token(Token = "0x400037F")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x3E4")]
		protected bool m_isAwake;

		[Token(Token = "0x4000380")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x3E5")]
		internal bool m_isWaitingOnResourceLoad;

		[Token(Token = "0x4000381")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x3E6")]
		internal bool m_isInputParsingRequired;

		[Token(Token = "0x4000382")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x3E8")]
		internal TextInputSources m_inputSource;

		[Token(Token = "0x4000383")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x3F0")]
		protected string old_text;

		[Token(Token = "0x4000384")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x3F8")]
		protected float m_fontScale;

		[Token(Token = "0x4000385")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x3FC")]
		protected float m_fontScaleMultiplier;

		[Token(Token = "0x4000386")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x400")]
		protected char[] m_htmlTag;

		[Token(Token = "0x4000387")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x408")]
		protected RichTextTagAttribute[] m_xmlAttribute;

		[Token(Token = "0x4000388")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x410")]
		protected float[] m_attributeParameterValues;

		[Token(Token = "0x4000389")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x418")]
		protected float tag_LineIndent;

		[Token(Token = "0x400038A")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x41C")]
		protected float tag_Indent;

		[Token(Token = "0x400038B")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x420")]
		protected TMP_RichTextTagStack<float> m_indentStack;

		[Token(Token = "0x400038C")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x438")]
		protected bool tag_NoParsing;

		[Token(Token = "0x400038D")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x439")]
		protected bool m_isParsingText;

		[Token(Token = "0x400038E")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x43C")]
		protected Matrix4x4 m_FXMatrix;

		[Token(Token = "0x400038F")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x47C")]
		protected bool m_isFXMatrixSet;

		[Token(Token = "0x4000390")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x480")]
		protected UnicodeChar[] m_TextParsingBuffer;

		[Token(Token = "0x4000391")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x488")]
		private TMP_CharacterInfo[] m_internalCharacterInfo;

		[Token(Token = "0x4000392")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x490")]
		protected char[] m_input_CharArray;

		[Token(Token = "0x4000393")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x498")]
		private int m_charArray_Length;

		[Token(Token = "0x4000394")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x49C")]
		protected int m_totalCharacterCount;

		[Token(Token = "0x4000395")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x4A0")]
		protected WordWrapState m_SavedWordWrapState;

		[Token(Token = "0x4000396")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x730")]
		protected WordWrapState m_SavedLineState;

		[Token(Token = "0x4000397")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x9C0")]
		protected int m_characterCount;

		[Token(Token = "0x4000398")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x9C4")]
		protected int m_firstCharacterOfLine;

		[Token(Token = "0x4000399")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x9C8")]
		protected int m_firstVisibleCharacterOfLine;

		[Token(Token = "0x400039A")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x9CC")]
		protected int m_lastCharacterOfLine;

		[Token(Token = "0x400039B")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x9D0")]
		protected int m_lastVisibleCharacterOfLine;

		[Token(Token = "0x400039C")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x9D4")]
		protected int m_lineNumber;

		[Token(Token = "0x400039D")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x9D8")]
		protected int m_lineVisibleCharacterCount;

		[Token(Token = "0x400039E")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x9DC")]
		protected int m_pageNumber;

		[Token(Token = "0x400039F")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x9E0")]
		protected float m_maxAscender;

		[Token(Token = "0x40003A0")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x9E4")]
		protected float m_maxCapHeight;

		[Token(Token = "0x40003A1")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x9E8")]
		protected float m_maxDescender;

		[Token(Token = "0x40003A2")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x9EC")]
		protected float m_maxLineAscender;

		[Token(Token = "0x40003A3")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x9F0")]
		protected float m_maxLineDescender;

		[Token(Token = "0x40003A4")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x9F4")]
		protected float m_startOfLineAscender;

		[Token(Token = "0x40003A5")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x9F8")]
		protected float m_lineOffset;

		[Token(Token = "0x40003A6")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x9FC")]
		protected Extents m_meshExtents;

		[Token(Token = "0x40003A7")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xA0C")]
		protected Color32 m_htmlColor;

		[Token(Token = "0x40003A8")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xA10")]
		protected TMP_RichTextTagStack<Color32> m_colorStack;

		[Token(Token = "0x40003A9")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xA28")]
		protected TMP_RichTextTagStack<Color32> m_underlineColorStack;

		[Token(Token = "0x40003AA")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xA40")]
		protected TMP_RichTextTagStack<Color32> m_strikethroughColorStack;

		[Token(Token = "0x40003AB")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xA58")]
		protected TMP_RichTextTagStack<Color32> m_highlightColorStack;

		[Token(Token = "0x40003AC")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xA70")]
		protected TMP_ColorGradient m_colorGradientPreset;

		[Token(Token = "0x40003AD")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xA78")]
		protected TMP_RichTextTagStack<TMP_ColorGradient> m_colorGradientStack;

		[Token(Token = "0x40003AE")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xA90")]
		protected float m_tabSpacing;

		[Token(Token = "0x40003AF")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xA94")]
		protected float m_spacing;

		[Token(Token = "0x40003B0")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xA98")]
		protected TMP_RichTextTagStack<int> m_styleStack;

		[Token(Token = "0x40003B1")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xAB0")]
		protected TMP_RichTextTagStack<int> m_actionStack;

		[Token(Token = "0x40003B2")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xAC8")]
		protected float m_padding;

		[Token(Token = "0x40003B3")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xACC")]
		protected float m_baselineOffset;

		[Token(Token = "0x40003B4")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xAD0")]
		protected TMP_RichTextTagStack<float> m_baselineOffsetStack;

		[Token(Token = "0x40003B5")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xAE8")]
		protected float m_xAdvance;

		[Token(Token = "0x40003B6")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xAEC")]
		protected TMP_TextElementType m_textElementType;

		[Token(Token = "0x40003B7")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xAF0")]
		protected TMP_TextElement m_cached_TextElement;

		[Token(Token = "0x40003B8")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xAF8")]
		protected TMP_Character m_cached_Underline_Character;

		[Token(Token = "0x40003B9")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xB00")]
		protected TMP_Character m_cached_Ellipsis_Character;

		[Token(Token = "0x40003BA")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xB08")]
		protected TMP_SpriteAsset m_defaultSpriteAsset;

		[Token(Token = "0x40003BB")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xB10")]
		protected TMP_SpriteAsset m_currentSpriteAsset;

		[Token(Token = "0x40003BC")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xB18")]
		protected int m_spriteCount;

		[Token(Token = "0x40003BD")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xB1C")]
		protected int m_spriteIndex;

		[Token(Token = "0x40003BE")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xB20")]
		protected int m_spriteAnimationID;

		[Token(Token = "0x40003BF")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xB24")]
		protected bool m_ignoreActiveState;

		[Token(Token = "0x40003C0")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xB28")]
		private readonly float[] k_Power;

		[Token(Token = "0x40003C1")]
		protected static Vector2 k_LargePositiveVector2;

		[Token(Token = "0x40003C2")]
		protected static Vector2 k_LargeNegativeVector2;

		[Token(Token = "0x40003C3")]
		protected static float k_LargePositiveFloat;

		[Token(Token = "0x40003C4")]
		protected static float k_LargeNegativeFloat;

		[Token(Token = "0x40003C5")]
		protected static int k_LargePositiveInt;

		[Token(Token = "0x40003C6")]
		protected static int k_LargeNegativeInt;

		[Token(Token = "0x170000DE")]
		public string text
		{
			[Token(Token = "0x60003B6")]
			[Address(RVA = "0x940FEC", Offset = "0x940FEC", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60003B7")]
			[Address(RVA = "0x940FF4", Offset = "0x940FF4", Length = "0x80")]
			set
			{
			}
		}

		[Token(Token = "0x170000DF")]
		public bool isRightToLeftText
		{
			[Token(Token = "0x60003B8")]
			[Address(RVA = "0x941074", Offset = "0x941074", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60003B9")]
			[Address(RVA = "0x94107C", Offset = "0x94107C", Length = "0x78")]
			set
			{
			}
		}

		[Token(Token = "0x170000E0")]
		public TMP_FontAsset font
		{
			[Token(Token = "0x60003BA")]
			[Address(RVA = "0x9410F4", Offset = "0x9410F4", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60003BB")]
			[Address(RVA = "0x9410FC", Offset = "0x9410FC", Length = "0xE0")]
			set
			{
			}
		}

		[Token(Token = "0x170000E1")]
		public virtual Material fontSharedMaterial
		{
			[Token(Token = "0x60003BC")]
			[Address(RVA = "0x9411DC", Offset = "0x9411DC", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60003BD")]
			[Address(RVA = "0x9411E4", Offset = "0x9411E4", Length = "0xDC")]
			set
			{
			}
		}

		[Token(Token = "0x170000E2")]
		public virtual Material[] fontSharedMaterials
		{
			[Token(Token = "0x60003BE")]
			[Address(RVA = "0x9412C0", Offset = "0x9412C0", Length = "0x10")]
			get
			{
				return null;
			}
			[Token(Token = "0x60003BF")]
			[Address(RVA = "0x9412D0", Offset = "0x9412D0", Length = "0x5C")]
			set
			{
			}
		}

		[Token(Token = "0x170000E3")]
		public Material fontMaterial
		{
			[Token(Token = "0x60003C0")]
			[Address(RVA = "0x94132C", Offset = "0x94132C", Length = "0x14")]
			get
			{
				return null;
			}
			[Token(Token = "0x60003C1")]
			[Address(RVA = "0x941340", Offset = "0x941340", Length = "0x118")]
			set
			{
			}
		}

		[Token(Token = "0x170000E4")]
		public virtual Material[] fontMaterials
		{
			[Token(Token = "0x60003C2")]
			[Address(RVA = "0x941458", Offset = "0x941458", Length = "0x14")]
			get
			{
				return null;
			}
			[Token(Token = "0x60003C3")]
			[Address(RVA = "0x94146C", Offset = "0x94146C", Length = "0x5C")]
			set
			{
			}
		}

		[Token(Token = "0x170000E5")]
		public override Color color
		{
			[Token(Token = "0x60003C4")]
			[Address(RVA = "0x9414C8", Offset = "0x9414C8", Length = "0x14")]
			get
			{
				return default(Color);
			}
			[Token(Token = "0x60003C5")]
			[Address(RVA = "0x9414DC", Offset = "0x9414DC", Length = "0xA8")]
			set
			{
			}
		}

		[Token(Token = "0x170000E6")]
		public float alpha
		{
			[Token(Token = "0x60003C6")]
			[Address(RVA = "0x941584", Offset = "0x941584", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60003C7")]
			[Address(RVA = "0x94158C", Offset = "0x94158C", Length = "0x2C")]
			set
			{
			}
		}

		[Token(Token = "0x170000E7")]
		public bool enableVertexGradient
		{
			[Token(Token = "0x60003C8")]
			[Address(RVA = "0x9415B8", Offset = "0x9415B8", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60003C9")]
			[Address(RVA = "0x9415C0", Offset = "0x9415C0", Length = "0x38")]
			set
			{
			}
		}

		[Token(Token = "0x170000E8")]
		public VertexGradient colorGradient
		{
			[Token(Token = "0x60003CA")]
			[Address(RVA = "0x9415F8", Offset = "0x9415F8", Length = "0x34")]
			get
			{
				return default(VertexGradient);
			}
			[Token(Token = "0x60003CB")]
			[Address(RVA = "0x94162C", Offset = "0x94162C", Length = "0x40")]
			set
			{
			}
		}

		[Token(Token = "0x170000E9")]
		public TMP_ColorGradient colorGradientPreset
		{
			[Token(Token = "0x60003CC")]
			[Address(RVA = "0x94166C", Offset = "0x94166C", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60003CD")]
			[Address(RVA = "0x941674", Offset = "0x941674", Length = "0x1C")]
			set
			{
			}
		}

		[Token(Token = "0x170000EA")]
		public TMP_SpriteAsset spriteAsset
		{
			[Token(Token = "0x60003CE")]
			[Address(RVA = "0x941690", Offset = "0x941690", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60003CF")]
			[Address(RVA = "0x941698", Offset = "0x941698", Length = "0x50")]
			set
			{
			}
		}

		[Token(Token = "0x170000EB")]
		public bool tintAllSprites
		{
			[Token(Token = "0x60003D0")]
			[Address(RVA = "0x9416E8", Offset = "0x9416E8", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60003D1")]
			[Address(RVA = "0x9416F0", Offset = "0x9416F0", Length = "0x38")]
			set
			{
			}
		}

		[Token(Token = "0x170000EC")]
		public bool overrideColorTags
		{
			[Token(Token = "0x60003D2")]
			[Address(RVA = "0x941728", Offset = "0x941728", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60003D3")]
			[Address(RVA = "0x941730", Offset = "0x941730", Length = "0x38")]
			set
			{
			}
		}

		[Token(Token = "0x170000ED")]
		public Color32 faceColor
		{
			[Token(Token = "0x60003D4")]
			[Address(RVA = "0x941768", Offset = "0x941768", Length = "0xE0")]
			get
			{
				return default(Color32);
			}
			[Token(Token = "0x60003D5")]
			[Address(RVA = "0x941848", Offset = "0x941848", Length = "0x98")]
			set
			{
			}
		}

		[Token(Token = "0x170000EE")]
		public Color32 outlineColor
		{
			[Token(Token = "0x60003D6")]
			[Address(RVA = "0x9418E0", Offset = "0x9418E0", Length = "0xE0")]
			get
			{
				return default(Color32);
			}
			[Token(Token = "0x60003D7")]
			[Address(RVA = "0x9419C0", Offset = "0x9419C0", Length = "0x84")]
			set
			{
			}
		}

		[Token(Token = "0x170000EF")]
		public float outlineWidth
		{
			[Token(Token = "0x60003D8")]
			[Address(RVA = "0x941A44", Offset = "0x941A44", Length = "0xD4")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60003D9")]
			[Address(RVA = "0x941B18", Offset = "0x941B18", Length = "0x78")]
			set
			{
			}
		}

		[Token(Token = "0x170000F0")]
		public float fontSize
		{
			[Token(Token = "0x60003DA")]
			[Address(RVA = "0x941B90", Offset = "0x941B90", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60003DB")]
			[Address(RVA = "0x941B98", Offset = "0x941B98", Length = "0x74")]
			set
			{
			}
		}

		[Token(Token = "0x170000F1")]
		public float fontScale
		{
			[Token(Token = "0x60003DC")]
			[Address(RVA = "0x941C0C", Offset = "0x941C0C", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x170000F2")]
		public FontWeight fontWeight
		{
			[Token(Token = "0x60003DD")]
			[Address(RVA = "0x941C14", Offset = "0x941C14", Length = "0x8")]
			get
			{
				return (FontWeight)0;
			}
			[Token(Token = "0x60003DE")]
			[Address(RVA = "0x941C1C", Offset = "0x941C1C", Length = "0x6C")]
			set
			{
			}
		}

		[Token(Token = "0x170000F3")]
		public float pixelsPerUnit
		{
			[Token(Token = "0x60003DF")]
			[Address(RVA = "0x941C88", Offset = "0x941C88", Length = "0x194")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x170000F4")]
		public bool enableAutoSizing
		{
			[Token(Token = "0x60003E0")]
			[Address(RVA = "0x941E1C", Offset = "0x941E1C", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60003E1")]
			[Address(RVA = "0x941E24", Offset = "0x941E24", Length = "0x68")]
			set
			{
			}
		}

		[Token(Token = "0x170000F5")]
		public float fontSizeMin
		{
			[Token(Token = "0x60003E2")]
			[Address(RVA = "0x941E8C", Offset = "0x941E8C", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60003E3")]
			[Address(RVA = "0x941E94", Offset = "0x941E94", Length = "0x5C")]
			set
			{
			}
		}

		[Token(Token = "0x170000F6")]
		public float fontSizeMax
		{
			[Token(Token = "0x60003E4")]
			[Address(RVA = "0x941EF0", Offset = "0x941EF0", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60003E5")]
			[Address(RVA = "0x941EF8", Offset = "0x941EF8", Length = "0x5C")]
			set
			{
			}
		}

		[Token(Token = "0x170000F7")]
		public FontStyles fontStyle
		{
			[Token(Token = "0x60003E6")]
			[Address(RVA = "0x941F54", Offset = "0x941F54", Length = "0x8")]
			get
			{
				return FontStyles.Normal;
			}
			[Token(Token = "0x60003E7")]
			[Address(RVA = "0x941F5C", Offset = "0x941F5C", Length = "0x6C")]
			set
			{
			}
		}

		[Token(Token = "0x170000F8")]
		public bool isUsingBold
		{
			[Token(Token = "0x60003E8")]
			[Address(RVA = "0x941FC8", Offset = "0x941FC8", Length = "0x8")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x170000F9")]
		public TextAlignmentOptions alignment
		{
			[Token(Token = "0x60003E9")]
			[Address(RVA = "0x941FD0", Offset = "0x941FD0", Length = "0x8")]
			get
			{
				return (TextAlignmentOptions)0;
			}
			[Token(Token = "0x60003EA")]
			[Address(RVA = "0x941FD8", Offset = "0x941FD8", Length = "0x2C")]
			set
			{
			}
		}

		[Token(Token = "0x170000FA")]
		public float characterSpacing
		{
			[Token(Token = "0x60003EB")]
			[Address(RVA = "0x942004", Offset = "0x942004", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60003EC")]
			[Address(RVA = "0x94200C", Offset = "0x94200C", Length = "0x68")]
			set
			{
			}
		}

		[Token(Token = "0x170000FB")]
		public float wordSpacing
		{
			[Token(Token = "0x60003ED")]
			[Address(RVA = "0x942074", Offset = "0x942074", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60003EE")]
			[Address(RVA = "0x94207C", Offset = "0x94207C", Length = "0x68")]
			set
			{
			}
		}

		[Token(Token = "0x170000FC")]
		public float lineSpacing
		{
			[Token(Token = "0x60003EF")]
			[Address(RVA = "0x9420E4", Offset = "0x9420E4", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60003F0")]
			[Address(RVA = "0x9420EC", Offset = "0x9420EC", Length = "0x68")]
			set
			{
			}
		}

		[Token(Token = "0x170000FD")]
		public float lineSpacingAdjustment
		{
			[Token(Token = "0x60003F1")]
			[Address(RVA = "0x942154", Offset = "0x942154", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60003F2")]
			[Address(RVA = "0x94215C", Offset = "0x94215C", Length = "0x68")]
			set
			{
			}
		}

		[Token(Token = "0x170000FE")]
		public float paragraphSpacing
		{
			[Token(Token = "0x60003F3")]
			[Address(RVA = "0x9421C4", Offset = "0x9421C4", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60003F4")]
			[Address(RVA = "0x9421CC", Offset = "0x9421CC", Length = "0x68")]
			set
			{
			}
		}

		[Token(Token = "0x170000FF")]
		public float characterWidthAdjustment
		{
			[Token(Token = "0x60003F5")]
			[Address(RVA = "0x942234", Offset = "0x942234", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60003F6")]
			[Address(RVA = "0x94223C", Offset = "0x94223C", Length = "0x68")]
			set
			{
			}
		}

		[Token(Token = "0x17000100")]
		public bool enableWordWrapping
		{
			[Token(Token = "0x60003F7")]
			[Address(RVA = "0x9422A4", Offset = "0x9422A4", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60003F8")]
			[Address(RVA = "0x9422AC", Offset = "0x9422AC", Length = "0x78")]
			set
			{
			}
		}

		[Token(Token = "0x17000101")]
		public float wordWrappingRatios
		{
			[Token(Token = "0x60003F9")]
			[Address(RVA = "0x942324", Offset = "0x942324", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60003FA")]
			[Address(RVA = "0x94232C", Offset = "0x94232C", Length = "0x68")]
			set
			{
			}
		}

		[Token(Token = "0x17000102")]
		public TextOverflowModes overflowMode
		{
			[Token(Token = "0x60003FB")]
			[Address(RVA = "0x942394", Offset = "0x942394", Length = "0x8")]
			get
			{
				return TextOverflowModes.Overflow;
			}
			[Token(Token = "0x60003FC")]
			[Address(RVA = "0x94239C", Offset = "0x94239C", Length = "0x68")]
			set
			{
			}
		}

		[Token(Token = "0x17000103")]
		public bool isTextOverflowing
		{
			[Token(Token = "0x60003FD")]
			[Address(RVA = "0x942404", Offset = "0x942404", Length = "0x10")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x17000104")]
		public int firstOverflowCharacterIndex
		{
			[Token(Token = "0x60003FE")]
			[Address(RVA = "0x942414", Offset = "0x942414", Length = "0x8")]
			get
			{
				return 0;
			}
		}

		[Token(Token = "0x17000105")]
		public TMP_Text linkedTextComponent
		{
			[Token(Token = "0x60003FF")]
			[Address(RVA = "0x94241C", Offset = "0x94241C", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000400")]
			[Address(RVA = "0x942424", Offset = "0x942424", Length = "0x1FC")]
			set
			{
			}
		}

		[Token(Token = "0x17000106")]
		public bool isLinkedTextComponent
		{
			[Token(Token = "0x6000401")]
			[Address(RVA = "0x94267C", Offset = "0x94267C", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000402")]
			[Address(RVA = "0x942620", Offset = "0x942620", Length = "0x5C")]
			set
			{
			}
		}

		[Token(Token = "0x17000107")]
		public bool isTextTruncated
		{
			[Token(Token = "0x6000403")]
			[Address(RVA = "0x942684", Offset = "0x942684", Length = "0x8")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x17000108")]
		public bool enableKerning
		{
			[Token(Token = "0x6000404")]
			[Address(RVA = "0x94268C", Offset = "0x94268C", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000405")]
			[Address(RVA = "0x942694", Offset = "0x942694", Length = "0x74")]
			set
			{
			}
		}

		[Token(Token = "0x17000109")]
		public bool extraPadding
		{
			[Token(Token = "0x6000406")]
			[Address(RVA = "0x942708", Offset = "0x942708", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000407")]
			[Address(RVA = "0x942710", Offset = "0x942710", Length = "0x70")]
			set
			{
			}
		}

		[Token(Token = "0x1700010A")]
		public bool richText
		{
			[Token(Token = "0x6000408")]
			[Address(RVA = "0x942780", Offset = "0x942780", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000409")]
			[Address(RVA = "0x942788", Offset = "0x942788", Length = "0x78")]
			set
			{
			}
		}

		[Token(Token = "0x1700010B")]
		public bool parseCtrlCharacters
		{
			[Token(Token = "0x600040A")]
			[Address(RVA = "0x942800", Offset = "0x942800", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x600040B")]
			[Address(RVA = "0x942808", Offset = "0x942808", Length = "0x78")]
			set
			{
			}
		}

		[Token(Token = "0x1700010C")]
		public bool isOverlay
		{
			[Token(Token = "0x600040C")]
			[Address(RVA = "0x942880", Offset = "0x942880", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x600040D")]
			[Address(RVA = "0x942888", Offset = "0x942888", Length = "0x70")]
			set
			{
			}
		}

		[Token(Token = "0x1700010D")]
		public bool isOrthographic
		{
			[Token(Token = "0x600040E")]
			[Address(RVA = "0x9428F8", Offset = "0x9428F8", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x600040F")]
			[Address(RVA = "0x942900", Offset = "0x942900", Length = "0x38")]
			set
			{
			}
		}

		[Token(Token = "0x1700010E")]
		public bool enableCulling
		{
			[Token(Token = "0x6000410")]
			[Address(RVA = "0x942938", Offset = "0x942938", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000411")]
			[Address(RVA = "0x942940", Offset = "0x942940", Length = "0x54")]
			set
			{
			}
		}

		[Token(Token = "0x1700010F")]
		public bool ignoreRectMaskCulling
		{
			[Token(Token = "0x6000412")]
			[Address(RVA = "0x942994", Offset = "0x942994", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000413")]
			[Address(RVA = "0x94299C", Offset = "0x94299C", Length = "0x28")]
			set
			{
			}
		}

		[Token(Token = "0x17000110")]
		public bool ignoreVisibility
		{
			[Token(Token = "0x6000414")]
			[Address(RVA = "0x9429C4", Offset = "0x9429C4", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000415")]
			[Address(RVA = "0x9429CC", Offset = "0x9429CC", Length = "0x28")]
			set
			{
			}
		}

		[Token(Token = "0x17000111")]
		public TextureMappingOptions horizontalMapping
		{
			[Token(Token = "0x6000416")]
			[Address(RVA = "0x9429F4", Offset = "0x9429F4", Length = "0x8")]
			get
			{
				return TextureMappingOptions.Character;
			}
			[Token(Token = "0x6000417")]
			[Address(RVA = "0x9429FC", Offset = "0x9429FC", Length = "0x2C")]
			set
			{
			}
		}

		[Token(Token = "0x17000112")]
		public TextureMappingOptions verticalMapping
		{
			[Token(Token = "0x6000418")]
			[Address(RVA = "0x942A28", Offset = "0x942A28", Length = "0x8")]
			get
			{
				return TextureMappingOptions.Character;
			}
			[Token(Token = "0x6000419")]
			[Address(RVA = "0x942A30", Offset = "0x942A30", Length = "0x2C")]
			set
			{
			}
		}

		[Token(Token = "0x17000113")]
		public float mappingUvLineOffset
		{
			[Token(Token = "0x600041A")]
			[Address(RVA = "0x942A5C", Offset = "0x942A5C", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x600041B")]
			[Address(RVA = "0x942A64", Offset = "0x942A64", Length = "0x2C")]
			set
			{
			}
		}

		[Token(Token = "0x17000114")]
		public TextRenderFlags renderMode
		{
			[Token(Token = "0x600041C")]
			[Address(RVA = "0x942A90", Offset = "0x942A90", Length = "0x8")]
			get
			{
				return TextRenderFlags.DontRender;
			}
			[Token(Token = "0x600041D")]
			[Address(RVA = "0x942A98", Offset = "0x942A98", Length = "0x1C")]
			set
			{
			}
		}

		[Token(Token = "0x17000115")]
		public VertexSortingOrder geometrySortingOrder
		{
			[Token(Token = "0x600041E")]
			[Address(RVA = "0x942AB4", Offset = "0x942AB4", Length = "0x8")]
			get
			{
				return VertexSortingOrder.Normal;
			}
			[Token(Token = "0x600041F")]
			[Address(RVA = "0x942ABC", Offset = "0x942ABC", Length = "0x1C")]
			set
			{
			}
		}

		[Token(Token = "0x17000116")]
		public bool vertexBufferAutoSizeReduction
		{
			[Token(Token = "0x6000420")]
			[Address(RVA = "0x942AD8", Offset = "0x942AD8", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000421")]
			[Address(RVA = "0x942AE0", Offset = "0x942AE0", Length = "0x20")]
			set
			{
			}
		}

		[Token(Token = "0x17000117")]
		public int firstVisibleCharacter
		{
			[Token(Token = "0x6000422")]
			[Address(RVA = "0x942B00", Offset = "0x942B00", Length = "0x8")]
			get
			{
				return 0;
			}
			[Token(Token = "0x6000423")]
			[Address(RVA = "0x942B08", Offset = "0x942B08", Length = "0x2C")]
			set
			{
			}
		}

		[Token(Token = "0x17000118")]
		public int maxVisibleCharacters
		{
			[Token(Token = "0x6000424")]
			[Address(RVA = "0x942B34", Offset = "0x942B34", Length = "0x8")]
			get
			{
				return 0;
			}
			[Token(Token = "0x6000425")]
			[Address(RVA = "0x942B3C", Offset = "0x942B3C", Length = "0x2C")]
			set
			{
			}
		}

		[Token(Token = "0x17000119")]
		public int maxVisibleWords
		{
			[Token(Token = "0x6000426")]
			[Address(RVA = "0x942B68", Offset = "0x942B68", Length = "0x8")]
			get
			{
				return 0;
			}
			[Token(Token = "0x6000427")]
			[Address(RVA = "0x942B70", Offset = "0x942B70", Length = "0x2C")]
			set
			{
			}
		}

		[Token(Token = "0x1700011A")]
		public int maxVisibleLines
		{
			[Token(Token = "0x6000428")]
			[Address(RVA = "0x942B9C", Offset = "0x942B9C", Length = "0x8")]
			get
			{
				return 0;
			}
			[Token(Token = "0x6000429")]
			[Address(RVA = "0x942BA4", Offset = "0x942BA4", Length = "0x30")]
			set
			{
			}
		}

		[Token(Token = "0x1700011B")]
		public bool useMaxVisibleDescender
		{
			[Token(Token = "0x600042A")]
			[Address(RVA = "0x942BD4", Offset = "0x942BD4", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x600042B")]
			[Address(RVA = "0x942BDC", Offset = "0x942BDC", Length = "0x34")]
			set
			{
			}
		}

		[Token(Token = "0x1700011C")]
		public int pageToDisplay
		{
			[Token(Token = "0x600042C")]
			[Address(RVA = "0x942C10", Offset = "0x942C10", Length = "0x8")]
			get
			{
				return 0;
			}
			[Token(Token = "0x600042D")]
			[Address(RVA = "0x942C18", Offset = "0x942C18", Length = "0x2C")]
			set
			{
			}
		}

		[Token(Token = "0x1700011D")]
		public virtual Vector4 margin
		{
			[Token(Token = "0x600042E")]
			[Address(RVA = "0x942C44", Offset = "0x942C44", Length = "0x14")]
			get
			{
				return default(Vector4);
			}
			[Token(Token = "0x600042F")]
			[Address(RVA = "0x942C58", Offset = "0x942C58", Length = "0x124")]
			set
			{
			}
		}

		[Token(Token = "0x1700011E")]
		public TMP_TextInfo textInfo
		{
			[Token(Token = "0x6000430")]
			[Address(RVA = "0x942D7C", Offset = "0x942D7C", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700011F")]
		public bool havePropertiesChanged
		{
			[Token(Token = "0x6000431")]
			[Address(RVA = "0x942D84", Offset = "0x942D84", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000432")]
			[Address(RVA = "0x93F878", Offset = "0x93F878", Length = "0x38")]
			set
			{
			}
		}

		[Token(Token = "0x17000120")]
		public bool isUsingLegacyAnimationComponent
		{
			[Token(Token = "0x6000433")]
			[Address(RVA = "0x942D8C", Offset = "0x942D8C", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000434")]
			[Address(RVA = "0x942D94", Offset = "0x942D94", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x17000121")]
		public new Transform transform
		{
			[Token(Token = "0x6000435")]
			[Address(RVA = "0x9403C4", Offset = "0x9403C4", Length = "0x98")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000122")]
		public new RectTransform rectTransform
		{
			[Token(Token = "0x6000436")]
			[Address(RVA = "0x94045C", Offset = "0x94045C", Length = "0x98")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000123")]
		[field: Token(Token = "0x4000366")]
		[field: Cpp2ILInjected.FieldOffset(Offset = "0x380")]
		public virtual bool autoSizeTextContainer
		{
			[Token(Token = "0x6000437")]
			[Address(RVA = "0x942DA0", Offset = "0x942DA0", Length = "0x8")]
			get;
			[Token(Token = "0x6000438")]
			[Address(RVA = "0x942DA8", Offset = "0x942DA8", Length = "0xC")]
			set;
		}

		[Token(Token = "0x17000124")]
		public virtual Mesh mesh
		{
			[Token(Token = "0x6000439")]
			[Address(RVA = "0x942DB4", Offset = "0x942DB4", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000125")]
		public bool isVolumetricText
		{
			[Token(Token = "0x600043A")]
			[Address(RVA = "0x942DBC", Offset = "0x942DBC", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x600043B")]
			[Address(RVA = "0x942DC4", Offset = "0x942DC4", Length = "0x84")]
			set
			{
			}
		}

		[Token(Token = "0x17000126")]
		public Bounds bounds
		{
			[Token(Token = "0x600043C")]
			[Address(RVA = "0x942E48", Offset = "0x942E48", Length = "0xB0")]
			get
			{
				return default(Bounds);
			}
		}

		[Token(Token = "0x17000127")]
		public Bounds textBounds
		{
			[Token(Token = "0x600043D")]
			[Address(RVA = "0x942EF8", Offset = "0x942EF8", Length = "0x18")]
			get
			{
				return default(Bounds);
			}
		}

		[Token(Token = "0x17000128")]
		protected TMP_SpriteAnimator spriteAnimator
		{
			[Token(Token = "0x600043E")]
			[Address(RVA = "0x9431F0", Offset = "0x9431F0", Length = "0xF4")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000129")]
		public float flexibleHeight
		{
			[Token(Token = "0x600043F")]
			[Address(RVA = "0x9432E4", Offset = "0x9432E4", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x1700012A")]
		public float flexibleWidth
		{
			[Token(Token = "0x6000440")]
			[Address(RVA = "0x9432EC", Offset = "0x9432EC", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x1700012B")]
		public float minWidth
		{
			[Token(Token = "0x6000441")]
			[Address(RVA = "0x9432F4", Offset = "0x9432F4", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x1700012C")]
		public float minHeight
		{
			[Token(Token = "0x6000442")]
			[Address(RVA = "0x9432FC", Offset = "0x9432FC", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x1700012D")]
		public float maxWidth
		{
			[Token(Token = "0x6000443")]
			[Address(RVA = "0x943304", Offset = "0x943304", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x1700012E")]
		public float maxHeight
		{
			[Token(Token = "0x6000444")]
			[Address(RVA = "0x94330C", Offset = "0x94330C", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x1700012F")]
		protected LayoutElement layoutElement
		{
			[Token(Token = "0x6000445")]
			[Address(RVA = "0x943314", Offset = "0x943314", Length = "0x98")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000130")]
		public virtual float preferredWidth
		{
			[Token(Token = "0x6000446")]
			[Address(RVA = "0x9433AC", Offset = "0x9433AC", Length = "0x38")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000131")]
		public virtual float preferredHeight
		{
			[Token(Token = "0x6000447")]
			[Address(RVA = "0x94351C", Offset = "0x94351C", Length = "0x38")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000132")]
		public virtual float renderedWidth
		{
			[Token(Token = "0x6000448")]
			[Address(RVA = "0x9436D4", Offset = "0x9436D4", Length = "0x4")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000133")]
		public virtual float renderedHeight
		{
			[Token(Token = "0x6000449")]
			[Address(RVA = "0x9436DC", Offset = "0x9436DC", Length = "0x18")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000134")]
		public int layoutPriority
		{
			[Token(Token = "0x600044A")]
			[Address(RVA = "0x94370C", Offset = "0x94370C", Length = "0x8")]
			get
			{
				return 0;
			}
		}

		[Token(Token = "0x600044B")]
		[Address(RVA = "0x943714", Offset = "0x943714", Length = "0x4")]
		protected virtual void LoadFontAsset()
		{
		}

		[Token(Token = "0x600044C")]
		[Address(RVA = "0x943718", Offset = "0x943718", Length = "0x4")]
		protected virtual void SetSharedMaterial(Material mat)
		{
		}

		[Token(Token = "0x600044D")]
		[Address(RVA = "0x94371C", Offset = "0x94371C", Length = "0x8")]
		protected virtual Material GetMaterial(Material mat)
		{
			return null;
		}

		[Token(Token = "0x600044E")]
		[Address(RVA = "0x943724", Offset = "0x943724", Length = "0x4")]
		protected virtual void SetFontBaseMaterial(Material mat)
		{
		}

		[Token(Token = "0x600044F")]
		[Address(RVA = "0x943728", Offset = "0x943728", Length = "0x8")]
		protected virtual Material[] GetSharedMaterials()
		{
			return null;
		}

		[Token(Token = "0x6000450")]
		[Address(RVA = "0x943730", Offset = "0x943730", Length = "0x4")]
		protected virtual void SetSharedMaterials(Material[] materials)
		{
		}

		[Token(Token = "0x6000451")]
		[Address(RVA = "0x943734", Offset = "0x943734", Length = "0x8")]
		protected virtual Material[] GetMaterials(Material[] mats)
		{
			return null;
		}

		[Token(Token = "0x6000452")]
		[Address(RVA = "0x94373C", Offset = "0x94373C", Length = "0xC0")]
		protected virtual Material CreateMaterialInstance(Material source)
		{
			return null;
		}

		[Token(Token = "0x6000453")]
		[Address(RVA = "0x9437FC", Offset = "0x9437FC", Length = "0x10C")]
		protected void SetVertexColorGradient(TMP_ColorGradient gradient)
		{
		}

		[Token(Token = "0x6000454")]
		[Address(RVA = "0x943908", Offset = "0x943908", Length = "0x4")]
		protected void SetTextSortingOrder(VertexSortingOrder order)
		{
		}

		[Token(Token = "0x6000455")]
		[Address(RVA = "0x94390C", Offset = "0x94390C", Length = "0x4")]
		protected void SetTextSortingOrder(int[] order)
		{
		}

		[Token(Token = "0x6000456")]
		[Address(RVA = "0x943910", Offset = "0x943910", Length = "0x4")]
		protected virtual void SetFaceColor(Color32 color)
		{
		}

		[Token(Token = "0x6000457")]
		[Address(RVA = "0x943914", Offset = "0x943914", Length = "0x4")]
		protected virtual void SetOutlineColor(Color32 color)
		{
		}

		[Token(Token = "0x6000458")]
		[Address(RVA = "0x943918", Offset = "0x943918", Length = "0x4")]
		protected virtual void SetOutlineThickness(float thickness)
		{
		}

		[Token(Token = "0x6000459")]
		[Address(RVA = "0x94391C", Offset = "0x94391C", Length = "0x4")]
		protected virtual void SetShaderDepth()
		{
		}

		[Token(Token = "0x600045A")]
		[Address(RVA = "0x943920", Offset = "0x943920", Length = "0x4")]
		protected virtual void SetCulling()
		{
		}

		[Token(Token = "0x600045B")]
		[Address(RVA = "0x943924", Offset = "0x943924", Length = "0x8")]
		protected virtual float GetPaddingForMaterial()
		{
			return 0f;
		}

		[Token(Token = "0x600045C")]
		[Address(RVA = "0x94392C", Offset = "0x94392C", Length = "0x8")]
		protected virtual float GetPaddingForMaterial(Material mat)
		{
			return 0f;
		}

		[Token(Token = "0x600045D")]
		[Address(RVA = "0x943934", Offset = "0x943934", Length = "0x8")]
		protected virtual Vector3[] GetTextContainerLocalCorners()
		{
			return null;
		}

		[Token(Token = "0x600045E")]
		[Address(RVA = "0x94393C", Offset = "0x94393C", Length = "0x4")]
		public virtual void ForceMeshUpdate()
		{
		}

		[Token(Token = "0x600045F")]
		[Address(RVA = "0x943940", Offset = "0x943940", Length = "0x4")]
		public virtual void ForceMeshUpdate(bool ignoreActiveState)
		{
		}

		[Token(Token = "0x6000460")]
		[Address(RVA = "0x943944", Offset = "0x943944", Length = "0x44")]
		internal void SetTextInternal(string text)
		{
		}

		[Token(Token = "0x6000461")]
		[Address(RVA = "0x943988", Offset = "0x943988", Length = "0x4")]
		public virtual void UpdateGeometry(Mesh mesh, int index)
		{
		}

		[Token(Token = "0x6000462")]
		[Address(RVA = "0x94398C", Offset = "0x94398C", Length = "0x4")]
		public virtual void UpdateVertexData(TMP_VertexDataUpdateFlags flags)
		{
		}

		[Token(Token = "0x6000463")]
		[Address(RVA = "0x943990", Offset = "0x943990", Length = "0x4")]
		public virtual void UpdateVertexData()
		{
		}

		[Token(Token = "0x6000464")]
		[Address(RVA = "0x943994", Offset = "0x943994", Length = "0x4")]
		public virtual void SetVertices(Vector3[] vertices)
		{
		}

		[Token(Token = "0x6000465")]
		[Address(RVA = "0x943998", Offset = "0x943998", Length = "0x4")]
		public virtual void UpdateMeshPadding()
		{
		}

		[Token(Token = "0x6000466")]
		[Address(RVA = "0x94399C", Offset = "0x94399C", Length = "0x94")]
		public override void CrossFadeColor(Color targetColor, float duration, bool ignoreTimeScale, bool useAlpha)
		{
		}

		[Token(Token = "0x6000467")]
		[Address(RVA = "0x943A30", Offset = "0x943A30", Length = "0x58")]
		public override void CrossFadeAlpha(float alpha, float duration, bool ignoreTimeScale)
		{
		}

		[Token(Token = "0x6000468")]
		[Address(RVA = "0x943A88", Offset = "0x943A88", Length = "0x4")]
		protected virtual void InternalCrossFadeColor(Color targetColor, float duration, bool ignoreTimeScale, bool useAlpha)
		{
		}

		[Token(Token = "0x6000469")]
		[Address(RVA = "0x943A8C", Offset = "0x943A8C", Length = "0x4")]
		protected virtual void InternalCrossFadeAlpha(float alpha, float duration, bool ignoreTimeScale)
		{
		}

		[Token(Token = "0x600046A")]
		[Address(RVA = "0x943A90", Offset = "0x943A90", Length = "0x70")]
		protected void ParseInputText()
		{
		}

		[Token(Token = "0x600046B")]
		[Address(RVA = "0x944808", Offset = "0x944808", Length = "0x8")]
		public void SetText(string text)
		{
		}

		[Token(Token = "0x600046C")]
		[Address(RVA = "0x944810", Offset = "0x944810", Length = "0x60")]
		public void SetText(string text, bool syncTextInputBox)
		{
		}

		[Token(Token = "0x600046D")]
		[Address(RVA = "0x944870", Offset = "0x944870", Length = "0x10")]
		public void SetText(string text, float arg0)
		{
		}

		[Token(Token = "0x600046E")]
		[Address(RVA = "0x944A7C", Offset = "0x944A7C", Length = "0xC")]
		public void SetText(string text, float arg0, float arg1)
		{
		}

		[Token(Token = "0x600046F")]
		[Address(RVA = "0x944880", Offset = "0x944880", Length = "0x1FC")]
		public void SetText(string text, float arg0, float arg1, float arg2)
		{
		}

		[Token(Token = "0x6000470")]
		[Address(RVA = "0x944C50", Offset = "0x944C50", Length = "0x60")]
		public void SetText(StringBuilder text)
		{
		}

		[Token(Token = "0x6000471")]
		[Address(RVA = "0x9453E0", Offset = "0x9453E0", Length = "0x408")]
		public void SetCharArray(char[] sourceText)
		{
		}

		[Token(Token = "0x6000472")]
		[Address(RVA = "0x945DE0", Offset = "0x945DE0", Length = "0x40C")]
		public void SetCharArray(char[] sourceText, int start, int length)
		{
		}

		[Token(Token = "0x6000473")]
		[Address(RVA = "0x9461EC", Offset = "0x9461EC", Length = "0x410")]
		public void SetCharArray(int[] sourceText, int start, int length)
		{
		}

		[Token(Token = "0x6000474")]
		[Address(RVA = "0x944410", Offset = "0x944410", Length = "0x3F8")]
		protected void SetTextArrayToCharArray(char[] sourceText, ref UnicodeChar[] charBuffer)
		{
		}

		[Token(Token = "0x6000475")]
		[Address(RVA = "0x943B00", Offset = "0x943B00", Length = "0x910")]
		protected void StringToCharArray(string sourceText, ref UnicodeChar[] charBuffer)
		{
		}

		[Token(Token = "0x6000476")]
		[Address(RVA = "0x944CB0", Offset = "0x944CB0", Length = "0x730")]
		protected void StringBuilderToIntArray(StringBuilder sourceText, ref UnicodeChar[] charBuffer)
		{
		}

		[Token(Token = "0x6000477")]
		[Address(RVA = "0x946F04", Offset = "0x946F04", Length = "0x274")]
		private bool ReplaceOpeningStyleTag(ref string sourceText, int srcIndex, out int srcOffset, ref UnicodeChar[] charBuffer, ref int writeIndex)
		{
			srcOffset = default(int);
			return false;
		}

		[Token(Token = "0x6000478")]
		[Address(RVA = "0x94671C", Offset = "0x94671C", Length = "0x274")]
		private bool ReplaceOpeningStyleTag(ref int[] sourceText, int srcIndex, out int srcOffset, ref UnicodeChar[] charBuffer, ref int writeIndex)
		{
			srcOffset = default(int);
			return false;
		}

		[Token(Token = "0x6000479")]
		[Address(RVA = "0x945908", Offset = "0x945908", Length = "0x274")]
		private bool ReplaceOpeningStyleTag(ref char[] sourceText, int srcIndex, out int srcOffset, ref UnicodeChar[] charBuffer, ref int writeIndex)
		{
			srcOffset = default(int);
			return false;
		}

		[Token(Token = "0x600047A")]
		[Address(RVA = "0x9476F0", Offset = "0x9476F0", Length = "0x274")]
		private bool ReplaceOpeningStyleTag(ref StringBuilder sourceText, int srcIndex, out int srcOffset, ref UnicodeChar[] charBuffer, ref int writeIndex)
		{
			srcOffset = default(int);
			return false;
		}

		[Token(Token = "0x600047B")]
		[Address(RVA = "0x947178", Offset = "0x947178", Length = "0x264")]
		private bool ReplaceClosingStyleTag(ref string sourceText, int srcIndex, ref UnicodeChar[] charBuffer, ref int writeIndex)
		{
			return false;
		}

		[Token(Token = "0x600047C")]
		[Address(RVA = "0x946990", Offset = "0x946990", Length = "0x264")]
		private bool ReplaceClosingStyleTag(ref int[] sourceText, int srcIndex, ref UnicodeChar[] charBuffer, ref int writeIndex)
		{
			return false;
		}

		[Token(Token = "0x600047D")]
		[Address(RVA = "0x945B7C", Offset = "0x945B7C", Length = "0x264")]
		private bool ReplaceClosingStyleTag(ref char[] sourceText, int srcIndex, ref UnicodeChar[] charBuffer, ref int writeIndex)
		{
			return false;
		}

		[Token(Token = "0x600047E")]
		[Address(RVA = "0x947964", Offset = "0x947964", Length = "0x264")]
		private bool ReplaceClosingStyleTag(ref StringBuilder sourceText, int srcIndex, ref UnicodeChar[] charBuffer, ref int writeIndex)
		{
			return false;
		}

		[Token(Token = "0x600047F")]
		[Address(RVA = "0x946DF4", Offset = "0x946DF4", Length = "0x110")]
		private bool IsTagName(ref string text, string tag, int index)
		{
			return false;
		}

		[Token(Token = "0x6000480")]
		[Address(RVA = "0x9457E8", Offset = "0x9457E8", Length = "0x120")]
		private bool IsTagName(ref char[] text, string tag, int index)
		{
			return false;
		}

		[Token(Token = "0x6000481")]
		[Address(RVA = "0x9465FC", Offset = "0x9465FC", Length = "0x120")]
		private bool IsTagName(ref int[] text, string tag, int index)
		{
			return false;
		}

		[Token(Token = "0x6000482")]
		[Address(RVA = "0x9475DC", Offset = "0x9475DC", Length = "0x114")]
		private bool IsTagName(ref StringBuilder text, string tag, int index)
		{
			return false;
		}

		[Token(Token = "0x6000483")]
		[Address(RVA = "0x947BC8", Offset = "0x947BC8", Length = "0xC0")]
		private int GetTagHashCode(ref string text, int index, out int closeIndex)
		{
			closeIndex = default(int);
			return 0;
		}

		[Token(Token = "0x6000484")]
		[Address(RVA = "0x947D10", Offset = "0x947D10", Length = "0x88")]
		private int GetTagHashCode(ref char[] text, int index, out int closeIndex)
		{
			closeIndex = default(int);
			return 0;
		}

		[Token(Token = "0x6000485")]
		[Address(RVA = "0x947C88", Offset = "0x947C88", Length = "0x88")]
		private int GetTagHashCode(ref int[] text, int index, out int closeIndex)
		{
			closeIndex = default(int);
			return 0;
		}

		[Token(Token = "0x6000486")]
		[Address(RVA = "0x947D98", Offset = "0x947D98", Length = "0xCC")]
		private int GetTagHashCode(ref StringBuilder text, int index, out int closeIndex)
		{
			closeIndex = default(int);
			return 0;
		}

		[Token(Token = "0x6000487")]
		[Address(RVA = "0xCE00B8", Offset = "0xCE00B8", Length = "0xA0")]
		private void ResizeInternalArray<T>(ref T[] array)
		{
		}

		[Token(Token = "0x6000488")]
		[Address(RVA = "0x944A88", Offset = "0x944A88", Length = "0x1C8")]
		protected void AddFloatToCharArray(double number, ref int index, int precision)
		{
		}

		[Token(Token = "0x6000489")]
		[Address(RVA = "0x947E64", Offset = "0x947E64", Length = "0x16C")]
		protected void AddIntToCharArray(double number, ref int index, int precision)
		{
		}

		[Token(Token = "0x600048A")]
		[Address(RVA = "0x947FD0", Offset = "0x947FD0", Length = "0x8")]
		protected virtual int SetArraySizes(UnicodeChar[] chars)
		{
			return 0;
		}

		[Token(Token = "0x600048B")]
		[Address(RVA = "0x947FD8", Offset = "0x947FD8", Length = "0x4")]
		protected virtual void GenerateTextMesh()
		{
		}

		[Token(Token = "0x600048C")]
		[Address(RVA = "0x947FDC", Offset = "0x947FDC", Length = "0x7C")]
		public Vector2 GetPreferredValues()
		{
			return default(Vector2);
		}

		[Token(Token = "0x600048D")]
		[Address(RVA = "0x948058", Offset = "0x948058", Length = "0x124")]
		public Vector2 GetPreferredValues(float width, float height)
		{
			return default(Vector2);
		}

		[Token(Token = "0x600048E")]
		[Address(RVA = "0x948238", Offset = "0x948238", Length = "0x178")]
		public Vector2 GetPreferredValues(string text)
		{
			return default(Vector2);
		}

		[Token(Token = "0x600048F")]
		[Address(RVA = "0x9483B0", Offset = "0x9483B0", Length = "0x12C")]
		public Vector2 GetPreferredValues(string text, float width, float height)
		{
			return default(Vector2);
		}

		[Token(Token = "0x6000490")]
		[Address(RVA = "0x9433E4", Offset = "0x9433E4", Length = "0x138")]
		protected float GetPreferredWidth()
		{
			return 0f;
		}

		[Token(Token = "0x6000491")]
		[Address(RVA = "0x94817C", Offset = "0x94817C", Length = "0x54")]
		protected float GetPreferredWidth(Vector2 margin)
		{
			return 0f;
		}

		[Token(Token = "0x6000492")]
		[Address(RVA = "0x943554", Offset = "0x943554", Length = "0x180")]
		protected float GetPreferredHeight()
		{
			return 0f;
		}

		[Token(Token = "0x6000493")]
		[Address(RVA = "0x9481D0", Offset = "0x9481D0", Length = "0x68")]
		protected float GetPreferredHeight(Vector2 margin)
		{
			return 0f;
		}

		[Token(Token = "0x6000494")]
		[Address(RVA = "0x9484DC", Offset = "0x9484DC", Length = "0xC8")]
		public Vector2 GetRenderedValues()
		{
			return default(Vector2);
		}

		[Token(Token = "0x6000495")]
		[Address(RVA = "0x9485A4", Offset = "0x9485A4", Length = "0xD8")]
		public Vector2 GetRenderedValues(bool onlyVisibleCharacters)
		{
			return default(Vector2);
		}

		[Token(Token = "0x6000496")]
		[Address(RVA = "0x9436D8", Offset = "0x9436D8", Length = "0x4")]
		protected float GetRenderedWidth()
		{
			return 0f;
		}

		[Token(Token = "0x6000497")]
		[Address(RVA = "0x9489A8", Offset = "0x9489A8", Length = "0x8")]
		protected float GetRenderedWidth(bool onlyVisibleCharacters)
		{
			return 0f;
		}

		[Token(Token = "0x6000498")]
		[Address(RVA = "0x9436F4", Offset = "0x9436F4", Length = "0x18")]
		protected float GetRenderedHeight()
		{
			return 0f;
		}

		[Token(Token = "0x6000499")]
		[Address(RVA = "0x9489B0", Offset = "0x9489B0", Length = "0x1C")]
		protected float GetRenderedHeight(bool onlyVisibleCharacters)
		{
			return 0f;
		}

		[Token(Token = "0x600049A")]
		[Address(RVA = "0x9489CC", Offset = "0x9489CC", Length = "0x1E84")]
		protected virtual Vector2 CalculatePreferredValues(float defaultFontSize, Vector2 marginSize, bool ignoreTextAutoSizing)
		{
			return default(Vector2);
		}

		[Token(Token = "0x600049B")]
		[Address(RVA = "0x94F54C", Offset = "0x94F54C", Length = "0xC")]
		protected virtual Bounds GetCompoundBounds()
		{
			return default(Bounds);
		}

		[Token(Token = "0x600049C")]
		[Address(RVA = "0x942F10", Offset = "0x942F10", Length = "0x2E0")]
		protected Bounds GetTextBounds()
		{
			return default(Bounds);
		}

		[Token(Token = "0x600049D")]
		[Address(RVA = "0x94867C", Offset = "0x94867C", Length = "0x32C")]
		protected Bounds GetTextBounds(bool onlyVisibleCharacters)
		{
			return default(Bounds);
		}

		[Token(Token = "0x600049E")]
		[Address(RVA = "0x94F558", Offset = "0x94F558", Length = "0x4")]
		protected virtual void AdjustLineOffset(int startIndex, int endIndex, float offset)
		{
		}

		[Token(Token = "0x600049F")]
		[Address(RVA = "0x94F55C", Offset = "0x94F55C", Length = "0x208")]
		protected void ResizeLineExtents(int size)
		{
		}

		[Token(Token = "0x60004A0")]
		[Address(RVA = "0x94F764", Offset = "0x94F764", Length = "0x8")]
		public virtual TMP_TextInfo GetTextInfo(string text)
		{
			return null;
		}

		[Token(Token = "0x60004A1")]
		[Address(RVA = "0x94F76C", Offset = "0x94F76C", Length = "0x4")]
		public virtual void ComputeMarginSize()
		{
		}

		[Token(Token = "0x60004A2")]
		[Address(RVA = "0x94A850", Offset = "0x94A850", Length = "0x2AC")]
		protected void SaveWordWrappingState(ref WordWrapState state, int index, int count)
		{
		}

		[Token(Token = "0x60004A3")]
		[Address(RVA = "0x94F258", Offset = "0x94F258", Length = "0x2F4")]
		protected int RestoreWordWrappingState(ref WordWrapState state)
		{
			return 0;
		}

		[Token(Token = "0x60004A4")]
		[Address(RVA = "0x94F770", Offset = "0x94F770", Length = "0x9FC")]
		protected virtual void SaveGlyphVertexInfo(float padding, float style_padding, Color32 vertexColor)
		{
		}

		[Token(Token = "0x60004A5")]
		[Address(RVA = "0x95016C", Offset = "0x95016C", Length = "0x83C")]
		protected virtual void SaveSpriteVertexInfo(Color32 vertexColor)
		{
		}

		[Token(Token = "0x60004A6")]
		[Address(RVA = "0x9509A8", Offset = "0x9509A8", Length = "0x674")]
		protected virtual void FillCharacterVertexBuffers(int i, int index_X4)
		{
		}

		[Token(Token = "0x60004A7")]
		[Address(RVA = "0x95101C", Offset = "0x95101C", Length = "0xE54")]
		protected virtual void FillCharacterVertexBuffers(int i, int index_X4, bool isVolumetric)
		{
		}

		[Token(Token = "0x60004A8")]
		[Address(RVA = "0x951E70", Offset = "0x951E70", Length = "0x674")]
		protected virtual void FillSpriteVertexBuffers(int i, int index_X4)
		{
		}

		[Token(Token = "0x60004A9")]
		[Address(RVA = "0x9524E4", Offset = "0x9524E4", Length = "0x11B0")]
		protected virtual void DrawUnderlineMesh(Vector3 start, Vector3 end, ref int index, float startScale, float endScale, float maxScale, float sdfScale, Color32 underlineColor)
		{
		}

		[Token(Token = "0x60004AA")]
		[Address(RVA = "0x9536CC", Offset = "0x9536CC", Length = "0x580")]
		protected virtual void DrawTextHighlight(Vector3 start, Vector3 end, ref int index, Color32 highlightColor)
		{
		}

		[Token(Token = "0x60004AB")]
		[Address(RVA = "0x953C4C", Offset = "0x953C4C", Length = "0x1B0")]
		protected void LoadDefaultSettings()
		{
		}

		[Token(Token = "0x60004AC")]
		[Address(RVA = "0x953DFC", Offset = "0x953DFC", Length = "0x260")]
		protected void GetSpecialCharacters(TMP_FontAsset fontAsset)
		{
		}

		[Token(Token = "0x60004AD")]
		[Address(RVA = "0x95405C", Offset = "0x95405C", Length = "0x80")]
		protected void ReplaceTagWithCharacter(int[] chars, int insertionIndex, int tagLength, char c)
		{
		}

		[Token(Token = "0x60004AE")]
		[Address(RVA = "0x9540DC", Offset = "0x9540DC", Length = "0x90")]
		protected TMP_FontAsset GetFontAssetForWeight(int fontWeight)
		{
			return null;
		}

		[Token(Token = "0x60004AF")]
		[Address(RVA = "0x95416C", Offset = "0x95416C", Length = "0x4")]
		protected virtual void SetActiveSubMeshes(bool state)
		{
		}

		[Token(Token = "0x60004B0")]
		[Address(RVA = "0x954170", Offset = "0x954170", Length = "0x4")]
		protected virtual void ClearSubMeshObjects()
		{
		}

		[Token(Token = "0x60004B1")]
		[Address(RVA = "0x954174", Offset = "0x954174", Length = "0x4")]
		public virtual void ClearMesh()
		{
		}

		[Token(Token = "0x60004B2")]
		[Address(RVA = "0x954178", Offset = "0x954178", Length = "0x4")]
		public virtual void ClearMesh(bool uploadGeometry)
		{
		}

		[Token(Token = "0x60004B3")]
		[Address(RVA = "0x95417C", Offset = "0x95417C", Length = "0x10C")]
		public virtual string GetParsedText()
		{
			return null;
		}

		[Token(Token = "0x60004B4")]
		[Address(RVA = "0x953694", Offset = "0x953694", Length = "0x38")]
		protected Vector2 PackUV(float x, float y, float scale)
		{
			return default(Vector2);
		}

		[Token(Token = "0x60004B5")]
		[Address(RVA = "0x954288", Offset = "0x954288", Length = "0x38")]
		protected float PackUV(float x, float y)
		{
			return 0f;
		}

		[Token(Token = "0x60004B6")]
		[Address(RVA = "0x9542C0", Offset = "0x9542C0", Length = "0x4")]
		internal virtual void InternalUpdate()
		{
		}

		[Token(Token = "0x60004B7")]
		[Address(RVA = "0x9542C4", Offset = "0x9542C4", Length = "0x60")]
		protected int HexToInt(char hex)
		{
			return 0;
		}

		[Token(Token = "0x60004B8")]
		[Address(RVA = "0x946D3C", Offset = "0x946D3C", Length = "0xB8")]
		protected int GetUTF16(string text, int i)
		{
			return 0;
		}

		[Token(Token = "0x60004B9")]
		[Address(RVA = "0x947524", Offset = "0x947524", Length = "0xB8")]
		protected int GetUTF16(StringBuilder text, int i)
		{
			return 0;
		}

		[Token(Token = "0x60004BA")]
		[Address(RVA = "0x946BF4", Offset = "0x946BF4", Length = "0x148")]
		protected int GetUTF32(string text, int i)
		{
			return 0;
		}

		[Token(Token = "0x60004BB")]
		[Address(RVA = "0x9473DC", Offset = "0x9473DC", Length = "0x148")]
		protected int GetUTF32(StringBuilder text, int i)
		{
			return 0;
		}

		[Token(Token = "0x60004BC")]
		[Address(RVA = "0x954324", Offset = "0x954324", Length = "0x460")]
		protected Color32 HexCharsToColor(char[] hexChars, int tagCount)
		{
			return default(Color32);
		}

		[Token(Token = "0x60004BD")]
		[Address(RVA = "0x954784", Offset = "0x954784", Length = "0x284")]
		protected Color32 HexCharsToColor(char[] hexChars, int startIndex, int length)
		{
			return default(Color32);
		}

		[Token(Token = "0x60004BE")]
		[Address(RVA = "0x954A08", Offset = "0x954A08", Length = "0xC0")]
		private int GetAttributeParameters(char[] chars, int startIndex, int length, ref float[] parameters)
		{
			return 0;
		}

		[Token(Token = "0x60004BF")]
		[Address(RVA = "0x954C34", Offset = "0x954C34", Length = "0x24")]
		protected float ConvertToFloat(char[] chars, int startIndex, int length)
		{
			return 0f;
		}

		[Token(Token = "0x60004C0")]
		[Address(RVA = "0x954AC8", Offset = "0x954AC8", Length = "0x16C")]
		protected float ConvertToFloat(char[] chars, int startIndex, int length, out int lastIndex)
		{
			lastIndex = default(int);
			return 0f;
		}

		[Token(Token = "0x60004C1")]
		[Address(RVA = "0x94AAFC", Offset = "0x94AAFC", Length = "0x475C")]
		protected bool ValidateHtmlTag(UnicodeChar[] chars, int startIndex, out int endIndex)
		{
			endIndex = default(int);
			return false;
		}

		[Token(Token = "0x60004C2")]
		[Address(RVA = "0x954C58", Offset = "0x954C58", Length = "0x68C")]
		protected internal TMP_Text()
		{
		}
	}
}
