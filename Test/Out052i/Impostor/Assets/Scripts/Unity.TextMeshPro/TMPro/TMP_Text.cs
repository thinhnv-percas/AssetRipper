using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using Cpp2ILInjected;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace TMPro
{
	[Token(Token = "0x2000093")]
	public abstract class TMP_Text : MaskableGraphic
	{
		[Token(Token = "0x2000094")]
		protected struct CharacterSubstitution
		{
			[Token(Token = "0x40005A5")]
			[FieldOffset(Offset = "0x0")]
			public int index;

			[Token(Token = "0x40005A6")]
			[FieldOffset(Offset = "0x4")]
			public uint unicode;

			[Token(Token = "0x60005D1")]
			[Address(RVA = "0x1610134", Offset = "0x1610134", Length = "0x8")]
			public CharacterSubstitution(int index, uint unicode)
			{
				this.index = 0;
				this.unicode = 0u;
			}
		}

		[Token(Token = "0x2000095")]
		internal enum TextInputSources
		{
			[Token(Token = "0x40005A8")]
			TextInputBox = 0,
			[Token(Token = "0x40005A9")]
			SetText = 1,
			[Token(Token = "0x40005AA")]
			SetTextArray = 2,
			[Token(Token = "0x40005AB")]
			TextString = 3
		}

		[DebuggerDisplay("Unicode ({unicode})  '{(char)unicode}'")]
		[Token(Token = "0x2000096")]
		internal struct UnicodeChar
		{
			[Token(Token = "0x40005AC")]
			[FieldOffset(Offset = "0x0")]
			public int unicode;

			[Token(Token = "0x40005AD")]
			[FieldOffset(Offset = "0x4")]
			public int stringIndex;

			[Token(Token = "0x40005AE")]
			[FieldOffset(Offset = "0x8")]
			public int length;
		}

		[Token(Token = "0x2000097")]
		protected struct SpecialCharacter
		{
			[Token(Token = "0x40005AF")]
			[FieldOffset(Offset = "0x0")]
			public TMP_Character character;

			[Token(Token = "0x40005B0")]
			[FieldOffset(Offset = "0x8")]
			public TMP_FontAsset fontAsset;

			[Token(Token = "0x40005B1")]
			[FieldOffset(Offset = "0x10")]
			public Material material;

			[Token(Token = "0x40005B2")]
			[FieldOffset(Offset = "0x18")]
			public int materialIndex;

			[Token(Token = "0x60005D2")]
			[Address(RVA = "0x161013C", Offset = "0x161013C", Length = "0xEC")]
			public SpecialCharacter(TMP_Character character, int materialIndex)
			{
				this.character = null;
				fontAsset = null;
				material = null;
				this.materialIndex = 0;
			}
		}

		[Token(Token = "0x2000098")]
		private struct TextBackingContainer
		{
			[Token(Token = "0x40005B3")]
			[FieldOffset(Offset = "0x0")]
			private uint[] m_Array;

			[Token(Token = "0x40005B4")]
			[FieldOffset(Offset = "0x8")]
			private int m_Count;

			[Token(Token = "0x17000164")]
			public int Capacity
			{
				[Token(Token = "0x60005D3")]
				[Address(RVA = "0x1610228", Offset = "0x1610228", Length = "0x1C")]
				get
				{
					return 0;
				}
			}

			[Token(Token = "0x17000165")]
			public int Count
			{
				[Token(Token = "0x60005D4")]
				[Address(RVA = "0x1610244", Offset = "0x1610244", Length = "0x8")]
				get
				{
					return 0;
				}
				[Token(Token = "0x60005D5")]
				[Address(RVA = "0x161024C", Offset = "0x161024C", Length = "0x8")]
				set
				{
				}
			}

			[Token(Token = "0x17000166")]
			public uint this[int index]
			{
				[Token(Token = "0x60005D6")]
				[Address(RVA = "0x1610254", Offset = "0x1610254", Length = "0x30")]
				get
				{
					return 0u;
				}
				[Token(Token = "0x60005D7")]
				[Address(RVA = "0x1610284", Offset = "0x1610284", Length = "0x60")]
				set
				{
				}
			}

			[Token(Token = "0x60005D8")]
			[Address(RVA = "0x1610348", Offset = "0x1610348", Length = "0x60")]
			public TextBackingContainer(int size)
			{
				m_Array = null;
				m_Count = 0;
			}

			[Token(Token = "0x60005D9")]
			[Address(RVA = "0x16102E4", Offset = "0x16102E4", Length = "0x64")]
			public void Resize(int size)
			{
			}
		}

		[TextArea(5, 10)]
		[SerializeField]
		[Token(Token = "0x40004C0")]
		[FieldOffset(Offset = "0xD8")]
		protected string m_text;

		[Token(Token = "0x40004C1")]
		[FieldOffset(Offset = "0xE0")]
		private bool m_IsTextBackingStringDirty;

		[SerializeField]
		[Token(Token = "0x40004C2")]
		[FieldOffset(Offset = "0xE8")]
		protected ITextPreprocessor m_TextPreprocessor;

		[SerializeField]
		[Token(Token = "0x40004C3")]
		[FieldOffset(Offset = "0xF0")]
		protected bool m_isRightToLeft;

		[SerializeField]
		[Token(Token = "0x40004C4")]
		[FieldOffset(Offset = "0xF8")]
		protected TMP_FontAsset m_fontAsset;

		[Token(Token = "0x40004C5")]
		[FieldOffset(Offset = "0x100")]
		protected TMP_FontAsset m_currentFontAsset;

		[Token(Token = "0x40004C6")]
		[FieldOffset(Offset = "0x108")]
		protected bool m_isSDFShader;

		[SerializeField]
		[Token(Token = "0x40004C7")]
		[FieldOffset(Offset = "0x110")]
		protected Material m_sharedMaterial;

		[Token(Token = "0x40004C8")]
		[FieldOffset(Offset = "0x118")]
		protected Material m_currentMaterial;

		[Token(Token = "0x40004C9")]
		protected static MaterialReference[] m_materialReferences;

		[Token(Token = "0x40004CA")]
		protected static Dictionary<int, int> m_materialReferenceIndexLookup;

		[Token(Token = "0x40004CB")]
		protected static TMP_TextProcessingStack<MaterialReference> m_materialReferenceStack;

		[Token(Token = "0x40004CC")]
		[FieldOffset(Offset = "0x120")]
		protected int m_currentMaterialIndex;

		[SerializeField]
		[Token(Token = "0x40004CD")]
		[FieldOffset(Offset = "0x128")]
		protected Material[] m_fontSharedMaterials;

		[SerializeField]
		[Token(Token = "0x40004CE")]
		[FieldOffset(Offset = "0x130")]
		protected Material m_fontMaterial;

		[SerializeField]
		[Token(Token = "0x40004CF")]
		[FieldOffset(Offset = "0x138")]
		protected Material[] m_fontMaterials;

		[Token(Token = "0x40004D0")]
		[FieldOffset(Offset = "0x140")]
		protected bool m_isMaterialDirty;

		[SerializeField]
		[Token(Token = "0x40004D1")]
		[FieldOffset(Offset = "0x144")]
		protected Color32 m_fontColor32;

		[SerializeField]
		[Token(Token = "0x40004D2")]
		[FieldOffset(Offset = "0x148")]
		protected Color m_fontColor;

		[Token(Token = "0x40004D3")]
		protected static Color32 s_colorWhite;

		[Token(Token = "0x40004D4")]
		[FieldOffset(Offset = "0x158")]
		protected Color32 m_underlineColor;

		[Token(Token = "0x40004D5")]
		[FieldOffset(Offset = "0x15C")]
		protected Color32 m_strikethroughColor;

		[SerializeField]
		[Token(Token = "0x40004D6")]
		[FieldOffset(Offset = "0x160")]
		protected bool m_enableVertexGradient;

		[SerializeField]
		[Token(Token = "0x40004D7")]
		[FieldOffset(Offset = "0x164")]
		protected ColorMode m_colorMode;

		[SerializeField]
		[Token(Token = "0x40004D8")]
		[FieldOffset(Offset = "0x168")]
		protected VertexGradient m_fontColorGradient;

		[SerializeField]
		[Token(Token = "0x40004D9")]
		[FieldOffset(Offset = "0x1A8")]
		protected TMP_ColorGradient m_fontColorGradientPreset;

		[SerializeField]
		[Token(Token = "0x40004DA")]
		[FieldOffset(Offset = "0x1B0")]
		protected TMP_SpriteAsset m_spriteAsset;

		[SerializeField]
		[Token(Token = "0x40004DB")]
		[FieldOffset(Offset = "0x1B8")]
		protected bool m_tintAllSprites;

		[Token(Token = "0x40004DC")]
		[FieldOffset(Offset = "0x1B9")]
		protected bool m_tintSprite;

		[Token(Token = "0x40004DD")]
		[FieldOffset(Offset = "0x1BC")]
		protected Color32 m_spriteColor;

		[SerializeField]
		[Token(Token = "0x40004DE")]
		[FieldOffset(Offset = "0x1C0")]
		protected TMP_StyleSheet m_StyleSheet;

		[Token(Token = "0x40004DF")]
		[FieldOffset(Offset = "0x1C8")]
		internal TMP_Style m_TextStyle;

		[SerializeField]
		[Token(Token = "0x40004E0")]
		[FieldOffset(Offset = "0x1D0")]
		protected int m_TextStyleHashCode;

		[SerializeField]
		[Token(Token = "0x40004E1")]
		[FieldOffset(Offset = "0x1D4")]
		protected bool m_overrideHtmlColors;

		[SerializeField]
		[Token(Token = "0x40004E2")]
		[FieldOffset(Offset = "0x1D8")]
		protected Color32 m_faceColor;

		[Token(Token = "0x40004E3")]
		[FieldOffset(Offset = "0x1DC")]
		protected Color32 m_outlineColor;

		[Token(Token = "0x40004E4")]
		[FieldOffset(Offset = "0x1E0")]
		protected float m_outlineWidth;

		[SerializeField]
		[Token(Token = "0x40004E5")]
		[FieldOffset(Offset = "0x1E4")]
		protected float m_fontSize;

		[Token(Token = "0x40004E6")]
		[FieldOffset(Offset = "0x1E8")]
		protected float m_currentFontSize;

		[SerializeField]
		[Token(Token = "0x40004E7")]
		[FieldOffset(Offset = "0x1EC")]
		protected float m_fontSizeBase;

		[Token(Token = "0x40004E8")]
		[FieldOffset(Offset = "0x1F0")]
		protected TMP_TextProcessingStack<float> m_sizeStack;

		[SerializeField]
		[Token(Token = "0x40004E9")]
		[FieldOffset(Offset = "0x210")]
		protected FontWeight m_fontWeight;

		[Token(Token = "0x40004EA")]
		[FieldOffset(Offset = "0x214")]
		protected FontWeight m_FontWeightInternal;

		[Token(Token = "0x40004EB")]
		[FieldOffset(Offset = "0x218")]
		protected TMP_TextProcessingStack<FontWeight> m_FontWeightStack;

		[SerializeField]
		[Token(Token = "0x40004EC")]
		[FieldOffset(Offset = "0x238")]
		protected bool m_enableAutoSizing;

		[Token(Token = "0x40004ED")]
		[FieldOffset(Offset = "0x23C")]
		protected float m_maxFontSize;

		[Token(Token = "0x40004EE")]
		[FieldOffset(Offset = "0x240")]
		protected float m_minFontSize;

		[Token(Token = "0x40004EF")]
		[FieldOffset(Offset = "0x244")]
		protected int m_AutoSizeIterationCount;

		[Token(Token = "0x40004F0")]
		[FieldOffset(Offset = "0x248")]
		protected int m_AutoSizeMaxIterationCount;

		[Token(Token = "0x40004F1")]
		[FieldOffset(Offset = "0x24C")]
		protected bool m_IsAutoSizePointSizeSet;

		[SerializeField]
		[Token(Token = "0x40004F2")]
		[FieldOffset(Offset = "0x250")]
		protected float m_fontSizeMin;

		[SerializeField]
		[Token(Token = "0x40004F3")]
		[FieldOffset(Offset = "0x254")]
		protected float m_fontSizeMax;

		[SerializeField]
		[Token(Token = "0x40004F4")]
		[FieldOffset(Offset = "0x258")]
		protected FontStyles m_fontStyle;

		[Token(Token = "0x40004F5")]
		[FieldOffset(Offset = "0x25C")]
		protected FontStyles m_FontStyleInternal;

		[Token(Token = "0x40004F6")]
		[FieldOffset(Offset = "0x260")]
		protected TMP_FontStyleStack m_fontStyleStack;

		[Token(Token = "0x40004F7")]
		[FieldOffset(Offset = "0x26A")]
		protected bool m_isUsingBold;

		[SerializeField]
		[Token(Token = "0x40004F8")]
		[FieldOffset(Offset = "0x26C")]
		protected HorizontalAlignmentOptions m_HorizontalAlignment;

		[SerializeField]
		[Token(Token = "0x40004F9")]
		[FieldOffset(Offset = "0x270")]
		protected VerticalAlignmentOptions m_VerticalAlignment;

		[SerializeField]
		[FormerlySerializedAs("m_lineJustification")]
		[Token(Token = "0x40004FA")]
		[FieldOffset(Offset = "0x274")]
		protected TextAlignmentOptions m_textAlignment;

		[Token(Token = "0x40004FB")]
		[FieldOffset(Offset = "0x278")]
		protected HorizontalAlignmentOptions m_lineJustification;

		[Token(Token = "0x40004FC")]
		[FieldOffset(Offset = "0x280")]
		protected TMP_TextProcessingStack<HorizontalAlignmentOptions> m_lineJustificationStack;

		[Token(Token = "0x40004FD")]
		[FieldOffset(Offset = "0x2A0")]
		protected Vector3[] m_textContainerLocalCorners;

		[SerializeField]
		[Token(Token = "0x40004FE")]
		[FieldOffset(Offset = "0x2A8")]
		protected float m_characterSpacing;

		[Token(Token = "0x40004FF")]
		[FieldOffset(Offset = "0x2AC")]
		protected float m_cSpacing;

		[Token(Token = "0x4000500")]
		[FieldOffset(Offset = "0x2B0")]
		protected float m_monoSpacing;

		[SerializeField]
		[Token(Token = "0x4000501")]
		[FieldOffset(Offset = "0x2B4")]
		protected float m_wordSpacing;

		[SerializeField]
		[Token(Token = "0x4000502")]
		[FieldOffset(Offset = "0x2B8")]
		protected float m_lineSpacing;

		[Token(Token = "0x4000503")]
		[FieldOffset(Offset = "0x2BC")]
		protected float m_lineSpacingDelta;

		[Token(Token = "0x4000504")]
		[FieldOffset(Offset = "0x2C0")]
		protected float m_lineHeight;

		[Token(Token = "0x4000505")]
		[FieldOffset(Offset = "0x2C4")]
		protected bool m_IsDrivenLineSpacing;

		[SerializeField]
		[Token(Token = "0x4000506")]
		[FieldOffset(Offset = "0x2C8")]
		protected float m_lineSpacingMax;

		[SerializeField]
		[Token(Token = "0x4000507")]
		[FieldOffset(Offset = "0x2CC")]
		protected float m_paragraphSpacing;

		[SerializeField]
		[Token(Token = "0x4000508")]
		[FieldOffset(Offset = "0x2D0")]
		protected float m_charWidthMaxAdj;

		[Token(Token = "0x4000509")]
		[FieldOffset(Offset = "0x2D4")]
		protected float m_charWidthAdjDelta;

		[SerializeField]
		[Token(Token = "0x400050A")]
		[FieldOffset(Offset = "0x2D8")]
		protected bool m_enableWordWrapping;

		[Token(Token = "0x400050B")]
		[FieldOffset(Offset = "0x2D9")]
		protected bool m_isCharacterWrappingEnabled;

		[Token(Token = "0x400050C")]
		[FieldOffset(Offset = "0x2DA")]
		protected bool m_isNonBreakingSpace;

		[Token(Token = "0x400050D")]
		[FieldOffset(Offset = "0x2DB")]
		protected bool m_isIgnoringAlignment;

		[SerializeField]
		[Token(Token = "0x400050E")]
		[FieldOffset(Offset = "0x2DC")]
		protected float m_wordWrappingRatios;

		[SerializeField]
		[Token(Token = "0x400050F")]
		[FieldOffset(Offset = "0x2E0")]
		protected TextOverflowModes m_overflowMode;

		[Token(Token = "0x4000510")]
		[FieldOffset(Offset = "0x2E4")]
		protected int m_firstOverflowCharacterIndex;

		[SerializeField]
		[Token(Token = "0x4000511")]
		[FieldOffset(Offset = "0x2E8")]
		protected TMP_Text m_linkedTextComponent;

		[SerializeField]
		[Token(Token = "0x4000512")]
		[FieldOffset(Offset = "0x2F0")]
		internal TMP_Text parentLinkedComponent;

		[Token(Token = "0x4000513")]
		[FieldOffset(Offset = "0x2F8")]
		protected bool m_isTextTruncated;

		[SerializeField]
		[Token(Token = "0x4000514")]
		[FieldOffset(Offset = "0x2F9")]
		protected bool m_enableKerning;

		[Token(Token = "0x4000515")]
		[FieldOffset(Offset = "0x2FC")]
		protected float m_GlyphHorizontalAdvanceAdjustment;

		[SerializeField]
		[Token(Token = "0x4000516")]
		[FieldOffset(Offset = "0x300")]
		protected bool m_enableExtraPadding;

		[SerializeField]
		[Token(Token = "0x4000517")]
		[FieldOffset(Offset = "0x301")]
		protected bool checkPaddingRequired;

		[SerializeField]
		[Token(Token = "0x4000518")]
		[FieldOffset(Offset = "0x302")]
		protected bool m_isRichText;

		[SerializeField]
		[Token(Token = "0x4000519")]
		[FieldOffset(Offset = "0x303")]
		protected bool m_parseCtrlCharacters;

		[Token(Token = "0x400051A")]
		[FieldOffset(Offset = "0x304")]
		protected bool m_isOverlay;

		[SerializeField]
		[Token(Token = "0x400051B")]
		[FieldOffset(Offset = "0x305")]
		protected bool m_isOrthographic;

		[SerializeField]
		[Token(Token = "0x400051C")]
		[FieldOffset(Offset = "0x306")]
		protected bool m_isCullingEnabled;

		[Token(Token = "0x400051D")]
		[FieldOffset(Offset = "0x307")]
		protected bool m_isMaskingEnabled;

		[Token(Token = "0x400051E")]
		[FieldOffset(Offset = "0x308")]
		protected bool isMaskUpdateRequired;

		[Token(Token = "0x400051F")]
		[FieldOffset(Offset = "0x309")]
		protected bool m_ignoreCulling;

		[SerializeField]
		[Token(Token = "0x4000520")]
		[FieldOffset(Offset = "0x30C")]
		protected TextureMappingOptions m_horizontalMapping;

		[SerializeField]
		[Token(Token = "0x4000521")]
		[FieldOffset(Offset = "0x310")]
		protected TextureMappingOptions m_verticalMapping;

		[SerializeField]
		[Token(Token = "0x4000522")]
		[FieldOffset(Offset = "0x314")]
		protected float m_uvLineOffset;

		[Token(Token = "0x4000523")]
		[FieldOffset(Offset = "0x318")]
		protected TextRenderFlags m_renderMode;

		[SerializeField]
		[Token(Token = "0x4000524")]
		[FieldOffset(Offset = "0x31C")]
		protected VertexSortingOrder m_geometrySortingOrder;

		[SerializeField]
		[Token(Token = "0x4000525")]
		[FieldOffset(Offset = "0x320")]
		protected bool m_IsTextObjectScaleStatic;

		[SerializeField]
		[Token(Token = "0x4000526")]
		[FieldOffset(Offset = "0x321")]
		protected bool m_VertexBufferAutoSizeReduction;

		[Token(Token = "0x4000527")]
		[FieldOffset(Offset = "0x324")]
		protected int m_firstVisibleCharacter;

		[Token(Token = "0x4000528")]
		[FieldOffset(Offset = "0x328")]
		protected int m_maxVisibleCharacters;

		[Token(Token = "0x4000529")]
		[FieldOffset(Offset = "0x32C")]
		protected int m_maxVisibleWords;

		[Token(Token = "0x400052A")]
		[FieldOffset(Offset = "0x330")]
		protected int m_maxVisibleLines;

		[SerializeField]
		[Token(Token = "0x400052B")]
		[FieldOffset(Offset = "0x334")]
		protected bool m_useMaxVisibleDescender;

		[SerializeField]
		[Token(Token = "0x400052C")]
		[FieldOffset(Offset = "0x338")]
		protected int m_pageToDisplay;

		[Token(Token = "0x400052D")]
		[FieldOffset(Offset = "0x33C")]
		protected bool m_isNewPage;

		[SerializeField]
		[Token(Token = "0x400052E")]
		[FieldOffset(Offset = "0x340")]
		protected Vector4 m_margin;

		[Token(Token = "0x400052F")]
		[FieldOffset(Offset = "0x350")]
		protected float m_marginLeft;

		[Token(Token = "0x4000530")]
		[FieldOffset(Offset = "0x354")]
		protected float m_marginRight;

		[Token(Token = "0x4000531")]
		[FieldOffset(Offset = "0x358")]
		protected float m_marginWidth;

		[Token(Token = "0x4000532")]
		[FieldOffset(Offset = "0x35C")]
		protected float m_marginHeight;

		[Token(Token = "0x4000533")]
		[FieldOffset(Offset = "0x360")]
		protected float m_width;

		[Token(Token = "0x4000534")]
		[FieldOffset(Offset = "0x368")]
		protected TMP_TextInfo m_textInfo;

		[Token(Token = "0x4000535")]
		[FieldOffset(Offset = "0x370")]
		protected bool m_havePropertiesChanged;

		[SerializeField]
		[Token(Token = "0x4000536")]
		[FieldOffset(Offset = "0x371")]
		protected bool m_isUsingLegacyAnimationComponent;

		[Token(Token = "0x4000537")]
		[FieldOffset(Offset = "0x378")]
		protected Transform m_transform;

		[Token(Token = "0x4000538")]
		[FieldOffset(Offset = "0x380")]
		protected RectTransform m_rectTransform;

		[Token(Token = "0x4000539")]
		[FieldOffset(Offset = "0x388")]
		protected Vector2 m_PreviousRectTransformSize;

		[Token(Token = "0x400053A")]
		[FieldOffset(Offset = "0x390")]
		protected Vector2 m_PreviousPivotPosition;

		[Token(Token = "0x400053C")]
		[FieldOffset(Offset = "0x399")]
		protected bool m_autoSizeTextContainer;

		[Token(Token = "0x400053D")]
		[FieldOffset(Offset = "0x3A0")]
		protected Mesh m_mesh;

		[SerializeField]
		[Token(Token = "0x400053E")]
		[FieldOffset(Offset = "0x3A8")]
		protected bool m_isVolumetricText;

		[Token(Token = "0x4000542")]
		[FieldOffset(Offset = "0x3B8")]
		protected TMP_SpriteAnimator m_spriteAnimator;

		[Token(Token = "0x4000543")]
		[FieldOffset(Offset = "0x3C0")]
		protected float m_flexibleHeight;

		[Token(Token = "0x4000544")]
		[FieldOffset(Offset = "0x3C4")]
		protected float m_flexibleWidth;

		[Token(Token = "0x4000545")]
		[FieldOffset(Offset = "0x3C8")]
		protected float m_minWidth;

		[Token(Token = "0x4000546")]
		[FieldOffset(Offset = "0x3CC")]
		protected float m_minHeight;

		[Token(Token = "0x4000547")]
		[FieldOffset(Offset = "0x3D0")]
		protected float m_maxWidth;

		[Token(Token = "0x4000548")]
		[FieldOffset(Offset = "0x3D4")]
		protected float m_maxHeight;

		[Token(Token = "0x4000549")]
		[FieldOffset(Offset = "0x3D8")]
		protected LayoutElement m_LayoutElement;

		[Token(Token = "0x400054A")]
		[FieldOffset(Offset = "0x3E0")]
		protected float m_preferredWidth;

		[Token(Token = "0x400054B")]
		[FieldOffset(Offset = "0x3E4")]
		protected float m_renderedWidth;

		[Token(Token = "0x400054C")]
		[FieldOffset(Offset = "0x3E8")]
		protected bool m_isPreferredWidthDirty;

		[Token(Token = "0x400054D")]
		[FieldOffset(Offset = "0x3EC")]
		protected float m_preferredHeight;

		[Token(Token = "0x400054E")]
		[FieldOffset(Offset = "0x3F0")]
		protected float m_renderedHeight;

		[Token(Token = "0x400054F")]
		[FieldOffset(Offset = "0x3F4")]
		protected bool m_isPreferredHeightDirty;

		[Token(Token = "0x4000550")]
		[FieldOffset(Offset = "0x3F5")]
		protected bool m_isCalculatingPreferredValues;

		[Token(Token = "0x4000551")]
		[FieldOffset(Offset = "0x3F8")]
		protected int m_layoutPriority;

		[Token(Token = "0x4000552")]
		[FieldOffset(Offset = "0x3FC")]
		protected bool m_isLayoutDirty;

		[Token(Token = "0x4000553")]
		[FieldOffset(Offset = "0x3FD")]
		protected bool m_isAwake;

		[Token(Token = "0x4000554")]
		[FieldOffset(Offset = "0x3FE")]
		internal bool m_isWaitingOnResourceLoad;

		[Token(Token = "0x4000555")]
		[FieldOffset(Offset = "0x400")]
		internal TextInputSources m_inputSource;

		[Token(Token = "0x4000556")]
		[FieldOffset(Offset = "0x404")]
		protected float m_fontScaleMultiplier;

		[Token(Token = "0x4000557")]
		private static char[] m_htmlTag;

		[Token(Token = "0x4000558")]
		private static RichTextTagAttribute[] m_xmlAttribute;

		[Token(Token = "0x4000559")]
		private static float[] m_attributeParameterValues;

		[Token(Token = "0x400055A")]
		[FieldOffset(Offset = "0x408")]
		protected float tag_LineIndent;

		[Token(Token = "0x400055B")]
		[FieldOffset(Offset = "0x40C")]
		protected float tag_Indent;

		[Token(Token = "0x400055C")]
		[FieldOffset(Offset = "0x410")]
		protected TMP_TextProcessingStack<float> m_indentStack;

		[Token(Token = "0x400055D")]
		[FieldOffset(Offset = "0x430")]
		protected bool tag_NoParsing;

		[Token(Token = "0x400055E")]
		[FieldOffset(Offset = "0x431")]
		protected bool m_isParsingText;

		[Token(Token = "0x400055F")]
		[FieldOffset(Offset = "0x434")]
		protected Matrix4x4 m_FXMatrix;

		[Token(Token = "0x4000560")]
		[FieldOffset(Offset = "0x474")]
		protected bool m_isFXMatrixSet;

		[Token(Token = "0x4000561")]
		[FieldOffset(Offset = "0x478")]
		internal UnicodeChar[] m_TextProcessingArray;

		[Token(Token = "0x4000562")]
		[FieldOffset(Offset = "0x480")]
		internal int m_InternalTextProcessingArraySize;

		[Token(Token = "0x4000563")]
		[FieldOffset(Offset = "0x488")]
		private TMP_CharacterInfo[] m_internalCharacterInfo;

		[Token(Token = "0x4000564")]
		[FieldOffset(Offset = "0x490")]
		protected int m_totalCharacterCount;

		[Token(Token = "0x4000565")]
		protected static WordWrapState m_SavedWordWrapState;

		[Token(Token = "0x4000566")]
		protected static WordWrapState m_SavedLineState;

		[Token(Token = "0x4000567")]
		protected static WordWrapState m_SavedEllipsisState;

		[Token(Token = "0x4000568")]
		protected static WordWrapState m_SavedLastValidState;

		[Token(Token = "0x4000569")]
		protected static WordWrapState m_SavedSoftLineBreakState;

		[Token(Token = "0x400056A")]
		internal static TMP_TextProcessingStack<WordWrapState> m_EllipsisInsertionCandidateStack;

		[Token(Token = "0x400056B")]
		[FieldOffset(Offset = "0x494")]
		protected int m_characterCount;

		[Token(Token = "0x400056C")]
		[FieldOffset(Offset = "0x498")]
		protected int m_firstCharacterOfLine;

		[Token(Token = "0x400056D")]
		[FieldOffset(Offset = "0x49C")]
		protected int m_firstVisibleCharacterOfLine;

		[Token(Token = "0x400056E")]
		[FieldOffset(Offset = "0x4A0")]
		protected int m_lastCharacterOfLine;

		[Token(Token = "0x400056F")]
		[FieldOffset(Offset = "0x4A4")]
		protected int m_lastVisibleCharacterOfLine;

		[Token(Token = "0x4000570")]
		[FieldOffset(Offset = "0x4A8")]
		protected int m_lineNumber;

		[Token(Token = "0x4000571")]
		[FieldOffset(Offset = "0x4AC")]
		protected int m_lineVisibleCharacterCount;

		[Token(Token = "0x4000572")]
		[FieldOffset(Offset = "0x4B0")]
		protected int m_pageNumber;

		[Token(Token = "0x4000573")]
		[FieldOffset(Offset = "0x4B4")]
		protected float m_PageAscender;

		[Token(Token = "0x4000574")]
		[FieldOffset(Offset = "0x4B8")]
		protected float m_maxTextAscender;

		[Token(Token = "0x4000575")]
		[FieldOffset(Offset = "0x4BC")]
		protected float m_maxCapHeight;

		[Token(Token = "0x4000576")]
		[FieldOffset(Offset = "0x4C0")]
		protected float m_ElementAscender;

		[Token(Token = "0x4000577")]
		[FieldOffset(Offset = "0x4C4")]
		protected float m_ElementDescender;

		[Token(Token = "0x4000578")]
		[FieldOffset(Offset = "0x4C8")]
		protected float m_maxLineAscender;

		[Token(Token = "0x4000579")]
		[FieldOffset(Offset = "0x4CC")]
		protected float m_maxLineDescender;

		[Token(Token = "0x400057A")]
		[FieldOffset(Offset = "0x4D0")]
		protected float m_startOfLineAscender;

		[Token(Token = "0x400057B")]
		[FieldOffset(Offset = "0x4D4")]
		protected float m_startOfLineDescender;

		[Token(Token = "0x400057C")]
		[FieldOffset(Offset = "0x4D8")]
		protected float m_lineOffset;

		[Token(Token = "0x400057D")]
		[FieldOffset(Offset = "0x4DC")]
		protected Extents m_meshExtents;

		[Token(Token = "0x400057E")]
		[FieldOffset(Offset = "0x4EC")]
		protected Color32 m_htmlColor;

		[Token(Token = "0x400057F")]
		[FieldOffset(Offset = "0x4F0")]
		protected TMP_TextProcessingStack<Color32> m_colorStack;

		[Token(Token = "0x4000580")]
		[FieldOffset(Offset = "0x510")]
		protected TMP_TextProcessingStack<Color32> m_underlineColorStack;

		[Token(Token = "0x4000581")]
		[FieldOffset(Offset = "0x530")]
		protected TMP_TextProcessingStack<Color32> m_strikethroughColorStack;

		[Token(Token = "0x4000582")]
		[FieldOffset(Offset = "0x550")]
		protected TMP_TextProcessingStack<HighlightState> m_HighlightStateStack;

		[Token(Token = "0x4000583")]
		[FieldOffset(Offset = "0x580")]
		protected TMP_ColorGradient m_colorGradientPreset;

		[Token(Token = "0x4000584")]
		[FieldOffset(Offset = "0x588")]
		protected TMP_TextProcessingStack<TMP_ColorGradient> m_colorGradientStack;

		[Token(Token = "0x4000585")]
		[FieldOffset(Offset = "0x5B0")]
		protected bool m_colorGradientPresetIsTinted;

		[Token(Token = "0x4000586")]
		[FieldOffset(Offset = "0x5B4")]
		protected float m_tabSpacing;

		[Token(Token = "0x4000587")]
		[FieldOffset(Offset = "0x5B8")]
		protected float m_spacing;

		[Token(Token = "0x4000588")]
		[FieldOffset(Offset = "0x5C0")]
		protected TMP_TextProcessingStack<int>[] m_TextStyleStacks;

		[Token(Token = "0x4000589")]
		[FieldOffset(Offset = "0x5C8")]
		protected int m_TextStyleStackDepth;

		[Token(Token = "0x400058A")]
		[FieldOffset(Offset = "0x5D0")]
		protected TMP_TextProcessingStack<int> m_ItalicAngleStack;

		[Token(Token = "0x400058B")]
		[FieldOffset(Offset = "0x5F0")]
		protected int m_ItalicAngle;

		[Token(Token = "0x400058C")]
		[FieldOffset(Offset = "0x5F8")]
		protected TMP_TextProcessingStack<int> m_actionStack;

		[Token(Token = "0x400058D")]
		[FieldOffset(Offset = "0x618")]
		protected float m_padding;

		[Token(Token = "0x400058E")]
		[FieldOffset(Offset = "0x61C")]
		protected float m_baselineOffset;

		[Token(Token = "0x400058F")]
		[FieldOffset(Offset = "0x620")]
		protected TMP_TextProcessingStack<float> m_baselineOffsetStack;

		[Token(Token = "0x4000590")]
		[FieldOffset(Offset = "0x640")]
		protected float m_xAdvance;

		[Token(Token = "0x4000591")]
		[FieldOffset(Offset = "0x644")]
		protected TMP_TextElementType m_textElementType;

		[Token(Token = "0x4000592")]
		[FieldOffset(Offset = "0x648")]
		protected TMP_TextElement m_cached_TextElement;

		[Token(Token = "0x4000593")]
		[FieldOffset(Offset = "0x650")]
		protected SpecialCharacter m_Ellipsis;

		[Token(Token = "0x4000594")]
		[FieldOffset(Offset = "0x670")]
		protected SpecialCharacter m_Underline;

		[Token(Token = "0x4000595")]
		[FieldOffset(Offset = "0x690")]
		protected TMP_SpriteAsset m_defaultSpriteAsset;

		[Token(Token = "0x4000596")]
		[FieldOffset(Offset = "0x698")]
		protected TMP_SpriteAsset m_currentSpriteAsset;

		[Token(Token = "0x4000597")]
		[FieldOffset(Offset = "0x6A0")]
		protected int m_spriteCount;

		[Token(Token = "0x4000598")]
		[FieldOffset(Offset = "0x6A4")]
		protected int m_spriteIndex;

		[Token(Token = "0x4000599")]
		[FieldOffset(Offset = "0x6A8")]
		protected int m_spriteAnimationID;

		[Token(Token = "0x400059A")]
		private static ProfilerMarker k_ParseTextMarker;

		[Token(Token = "0x400059B")]
		private static ProfilerMarker k_InsertNewLineMarker;

		[Token(Token = "0x400059C")]
		[FieldOffset(Offset = "0x6AC")]
		protected bool m_ignoreActiveState;

		[Token(Token = "0x400059D")]
		[FieldOffset(Offset = "0x6B0")]
		private TextBackingContainer m_TextBackingArray;

		[Token(Token = "0x400059E")]
		[FieldOffset(Offset = "0x6C0")]
		private readonly decimal[] k_Power;

		[Token(Token = "0x400059F")]
		protected static Vector2 k_LargePositiveVector2;

		[Token(Token = "0x40005A0")]
		protected static Vector2 k_LargeNegativeVector2;

		[Token(Token = "0x40005A1")]
		protected static float k_LargePositiveFloat;

		[Token(Token = "0x40005A2")]
		protected static float k_LargeNegativeFloat;

		[Token(Token = "0x40005A3")]
		protected static int k_LargePositiveInt;

		[Token(Token = "0x40005A4")]
		protected static int k_LargeNegativeInt;

		[Token(Token = "0x1700010A")]
		public virtual string text
		{
			[Token(Token = "0x60004A5")]
			[Address(RVA = "0x15EB66C", Offset = "0x15EB66C", Length = "0x14")]
			get
			{
				return null;
			}
			[Token(Token = "0x60004A6")]
			[Address(RVA = "0x15EB754", Offset = "0x15EB754", Length = "0x98")]
			set
			{
			}
		}

		[Token(Token = "0x1700010B")]
		public ITextPreprocessor textPreprocessor
		{
			[Token(Token = "0x60004A7")]
			[Address(RVA = "0x15EB7EC", Offset = "0x15EB7EC", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60004A8")]
			[Address(RVA = "0x15EB7F4", Offset = "0x15EB7F4", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700010C")]
		public bool isRightToLeftText
		{
			[Token(Token = "0x60004A9")]
			[Address(RVA = "0x15EB7FC", Offset = "0x15EB7FC", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60004AA")]
			[Address(RVA = "0x15EB804", Offset = "0x15EB804", Length = "0x54")]
			set
			{
			}
		}

		[Token(Token = "0x1700010D")]
		public TMP_FontAsset font
		{
			[Token(Token = "0x60004AB")]
			[Address(RVA = "0x15EB858", Offset = "0x15EB858", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60004AC")]
			[Address(RVA = "0x15EB860", Offset = "0x15EB860", Length = "0xC8")]
			set
			{
			}
		}

		[Token(Token = "0x1700010E")]
		public virtual Material fontSharedMaterial
		{
			[Token(Token = "0x60004AD")]
			[Address(RVA = "0x15EB928", Offset = "0x15EB928", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60004AE")]
			[Address(RVA = "0x15EB930", Offset = "0x15EB930", Length = "0xC8")]
			set
			{
			}
		}

		[Token(Token = "0x1700010F")]
		public virtual Material[] fontSharedMaterials
		{
			[Token(Token = "0x60004AF")]
			[Address(RVA = "0x15EB9F8", Offset = "0x15EB9F8", Length = "0x10")]
			get
			{
				return null;
			}
			[Token(Token = "0x60004B0")]
			[Address(RVA = "0x15EBA08", Offset = "0x15EBA08", Length = "0x4C")]
			set
			{
			}
		}

		[Token(Token = "0x17000110")]
		public Material fontMaterial
		{
			[Token(Token = "0x60004B1")]
			[Address(RVA = "0x15EBA54", Offset = "0x15EBA54", Length = "0x14")]
			get
			{
				return null;
			}
			[Token(Token = "0x60004B2")]
			[Address(RVA = "0x15EBA68", Offset = "0x15EBA68", Length = "0xFC")]
			set
			{
			}
		}

		[Token(Token = "0x17000111")]
		public virtual Material[] fontMaterials
		{
			[Token(Token = "0x60004B3")]
			[Address(RVA = "0x15EBB64", Offset = "0x15EBB64", Length = "0x14")]
			get
			{
				return null;
			}
			[Token(Token = "0x60004B4")]
			[Address(RVA = "0x15EBB78", Offset = "0x15EBB78", Length = "0x4C")]
			set
			{
			}
		}

		[Token(Token = "0x17000112")]
		public override Color color
		{
			[Token(Token = "0x60004B5")]
			[Address(RVA = "0x15EBBC4", Offset = "0x15EBBC4", Length = "0x14")]
			get
			{
				return default(Color);
			}
			[Token(Token = "0x60004B6")]
			[Address(RVA = "0x15EBBD8", Offset = "0x15EBBD8", Length = "0x78")]
			set
			{
			}
		}

		[Token(Token = "0x17000113")]
		public float alpha
		{
			[Token(Token = "0x60004B7")]
			[Address(RVA = "0x15EBC50", Offset = "0x15EBC50", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60004B8")]
			[Address(RVA = "0x15EBC58", Offset = "0x15EBC58", Length = "0x2C")]
			set
			{
			}
		}

		[Token(Token = "0x17000114")]
		public bool enableVertexGradient
		{
			[Token(Token = "0x60004B9")]
			[Address(RVA = "0x15EBC84", Offset = "0x15EBC84", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60004BA")]
			[Address(RVA = "0x15EBC8C", Offset = "0x15EBC8C", Length = "0x30")]
			set
			{
			}
		}

		[Token(Token = "0x17000115")]
		public VertexGradient colorGradient
		{
			[Token(Token = "0x60004BB")]
			[Address(RVA = "0x15EBCBC", Offset = "0x15EBCBC", Length = "0x18")]
			get
			{
				return default(VertexGradient);
			}
			[Token(Token = "0x60004BC")]
			[Address(RVA = "0x15EBCD4", Offset = "0x15EBCD4", Length = "0x2C")]
			set
			{
			}
		}

		[Token(Token = "0x17000116")]
		public TMP_ColorGradient colorGradientPreset
		{
			[Token(Token = "0x60004BD")]
			[Address(RVA = "0x15EBD00", Offset = "0x15EBD00", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60004BE")]
			[Address(RVA = "0x15EBD08", Offset = "0x15EBD08", Length = "0x1C")]
			set
			{
			}
		}

		[Token(Token = "0x17000117")]
		public TMP_SpriteAsset spriteAsset
		{
			[Token(Token = "0x60004BF")]
			[Address(RVA = "0x15EBD24", Offset = "0x15EBD24", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60004C0")]
			[Address(RVA = "0x15EBD2C", Offset = "0x15EBD2C", Length = "0x3C")]
			set
			{
			}
		}

		[Token(Token = "0x17000118")]
		public bool tintAllSprites
		{
			[Token(Token = "0x60004C1")]
			[Address(RVA = "0x15EBD68", Offset = "0x15EBD68", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60004C2")]
			[Address(RVA = "0x15EBD70", Offset = "0x15EBD70", Length = "0x30")]
			set
			{
			}
		}

		[Token(Token = "0x17000119")]
		public TMP_StyleSheet styleSheet
		{
			[Token(Token = "0x60004C3")]
			[Address(RVA = "0x15EBDA0", Offset = "0x15EBDA0", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60004C4")]
			[Address(RVA = "0x15EBDA8", Offset = "0x15EBDA8", Length = "0x3C")]
			set
			{
			}
		}

		[Token(Token = "0x1700011A")]
		public TMP_Style textStyle
		{
			[Token(Token = "0x60004C5")]
			[Address(RVA = "0x15EBDE4", Offset = "0x15EBDE4", Length = "0x38")]
			get
			{
				return null;
			}
			[Token(Token = "0x60004C6")]
			[Address(RVA = "0x15EBF0C", Offset = "0x15EBF0C", Length = "0x4C")]
			set
			{
			}
		}

		[Token(Token = "0x1700011B")]
		public bool overrideColorTags
		{
			[Token(Token = "0x60004C7")]
			[Address(RVA = "0x15EBF58", Offset = "0x15EBF58", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60004C8")]
			[Address(RVA = "0x15EBF60", Offset = "0x15EBF60", Length = "0x30")]
			set
			{
			}
		}

		[Token(Token = "0x1700011C")]
		public Color32 faceColor
		{
			[Token(Token = "0x60004C9")]
			[Address(RVA = "0x15EBF90", Offset = "0x15EBF90", Length = "0xC8")]
			get
			{
				return default(Color32);
			}
			[Token(Token = "0x60004CA")]
			[Address(RVA = "0x15EC058", Offset = "0x15EC058", Length = "0x88")]
			set
			{
			}
		}

		[Token(Token = "0x1700011D")]
		public Color32 outlineColor
		{
			[Token(Token = "0x60004CB")]
			[Address(RVA = "0x15EC0E0", Offset = "0x15EC0E0", Length = "0xC8")]
			get
			{
				return default(Color32);
			}
			[Token(Token = "0x60004CC")]
			[Address(RVA = "0x15EC1A8", Offset = "0x15EC1A8", Length = "0x74")]
			set
			{
			}
		}

		[Token(Token = "0x1700011E")]
		public float outlineWidth
		{
			[Token(Token = "0x60004CD")]
			[Address(RVA = "0x15EC21C", Offset = "0x15EC21C", Length = "0xBC")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60004CE")]
			[Address(RVA = "0x15EC2D8", Offset = "0x15EC2D8", Length = "0x60")]
			set
			{
			}
		}

		[Token(Token = "0x1700011F")]
		public float fontSize
		{
			[Token(Token = "0x60004CF")]
			[Address(RVA = "0x15EC338", Offset = "0x15EC338", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60004D0")]
			[Address(RVA = "0x15EC340", Offset = "0x15EC340", Length = "0x60")]
			set
			{
			}
		}

		[Token(Token = "0x17000120")]
		public FontWeight fontWeight
		{
			[Token(Token = "0x60004D1")]
			[Address(RVA = "0x15EC3A0", Offset = "0x15EC3A0", Length = "0x8")]
			get
			{
				return (FontWeight)0;
			}
			[Token(Token = "0x60004D2")]
			[Address(RVA = "0x15EC3A8", Offset = "0x15EC3A8", Length = "0x50")]
			set
			{
			}
		}

		[Token(Token = "0x17000121")]
		public float pixelsPerUnit
		{
			[Token(Token = "0x60004D3")]
			[Address(RVA = "0x15EC3F8", Offset = "0x15EC3F8", Length = "0x170")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000122")]
		public bool enableAutoSizing
		{
			[Token(Token = "0x60004D4")]
			[Address(RVA = "0x15EC568", Offset = "0x15EC568", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60004D5")]
			[Address(RVA = "0x15EC570", Offset = "0x15EC570", Length = "0x4C")]
			set
			{
			}
		}

		[Token(Token = "0x17000123")]
		public float fontSizeMin
		{
			[Token(Token = "0x60004D6")]
			[Address(RVA = "0x15EC5BC", Offset = "0x15EC5BC", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60004D7")]
			[Address(RVA = "0x15EC5C4", Offset = "0x15EC5C4", Length = "0x48")]
			set
			{
			}
		}

		[Token(Token = "0x17000124")]
		public float fontSizeMax
		{
			[Token(Token = "0x60004D8")]
			[Address(RVA = "0x15EC60C", Offset = "0x15EC60C", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60004D9")]
			[Address(RVA = "0x15EC614", Offset = "0x15EC614", Length = "0x48")]
			set
			{
			}
		}

		[Token(Token = "0x17000125")]
		public FontStyles fontStyle
		{
			[Token(Token = "0x60004DA")]
			[Address(RVA = "0x15EC65C", Offset = "0x15EC65C", Length = "0x8")]
			get
			{
				return FontStyles.Normal;
			}
			[Token(Token = "0x60004DB")]
			[Address(RVA = "0x15EC664", Offset = "0x15EC664", Length = "0x50")]
			set
			{
			}
		}

		[Token(Token = "0x17000126")]
		public bool isUsingBold
		{
			[Token(Token = "0x60004DC")]
			[Address(RVA = "0x15EC6B4", Offset = "0x15EC6B4", Length = "0x8")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x17000127")]
		public HorizontalAlignmentOptions horizontalAlignment
		{
			[Token(Token = "0x60004DD")]
			[Address(RVA = "0x15EC6BC", Offset = "0x15EC6BC", Length = "0x8")]
			get
			{
				return (HorizontalAlignmentOptions)0;
			}
			[Token(Token = "0x60004DE")]
			[Address(RVA = "0x15EC6C4", Offset = "0x15EC6C4", Length = "0x2C")]
			set
			{
			}
		}

		[Token(Token = "0x17000128")]
		public VerticalAlignmentOptions verticalAlignment
		{
			[Token(Token = "0x60004DF")]
			[Address(RVA = "0x15EC6F0", Offset = "0x15EC6F0", Length = "0x8")]
			get
			{
				return (VerticalAlignmentOptions)0;
			}
			[Token(Token = "0x60004E0")]
			[Address(RVA = "0x15EC6F8", Offset = "0x15EC6F8", Length = "0x2C")]
			set
			{
			}
		}

		[Token(Token = "0x17000129")]
		public TextAlignmentOptions alignment
		{
			[Token(Token = "0x60004E1")]
			[Address(RVA = "0x15EC724", Offset = "0x15EC724", Length = "0x10")]
			get
			{
				return (TextAlignmentOptions)0;
			}
			[Token(Token = "0x60004E2")]
			[Address(RVA = "0x15EC734", Offset = "0x15EC734", Length = "0x44")]
			set
			{
			}
		}

		[Token(Token = "0x1700012A")]
		public float characterSpacing
		{
			[Token(Token = "0x60004E3")]
			[Address(RVA = "0x15EC778", Offset = "0x15EC778", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60004E4")]
			[Address(RVA = "0x15EC780", Offset = "0x15EC780", Length = "0x50")]
			set
			{
			}
		}

		[Token(Token = "0x1700012B")]
		public float wordSpacing
		{
			[Token(Token = "0x60004E5")]
			[Address(RVA = "0x15EC7D0", Offset = "0x15EC7D0", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60004E6")]
			[Address(RVA = "0x15EC7D8", Offset = "0x15EC7D8", Length = "0x50")]
			set
			{
			}
		}

		[Token(Token = "0x1700012C")]
		public float lineSpacing
		{
			[Token(Token = "0x60004E7")]
			[Address(RVA = "0x15EC828", Offset = "0x15EC828", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60004E8")]
			[Address(RVA = "0x15EC830", Offset = "0x15EC830", Length = "0x50")]
			set
			{
			}
		}

		[Token(Token = "0x1700012D")]
		public float lineSpacingAdjustment
		{
			[Token(Token = "0x60004E9")]
			[Address(RVA = "0x15EC880", Offset = "0x15EC880", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60004EA")]
			[Address(RVA = "0x15EC888", Offset = "0x15EC888", Length = "0x50")]
			set
			{
			}
		}

		[Token(Token = "0x1700012E")]
		public float paragraphSpacing
		{
			[Token(Token = "0x60004EB")]
			[Address(RVA = "0x15EC8D8", Offset = "0x15EC8D8", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60004EC")]
			[Address(RVA = "0x15EC8E0", Offset = "0x15EC8E0", Length = "0x50")]
			set
			{
			}
		}

		[Token(Token = "0x1700012F")]
		public float characterWidthAdjustment
		{
			[Token(Token = "0x60004ED")]
			[Address(RVA = "0x15EC930", Offset = "0x15EC930", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60004EE")]
			[Address(RVA = "0x15EC938", Offset = "0x15EC938", Length = "0x50")]
			set
			{
			}
		}

		[Token(Token = "0x17000130")]
		public bool enableWordWrapping
		{
			[Token(Token = "0x60004EF")]
			[Address(RVA = "0x15EC988", Offset = "0x15EC988", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60004F0")]
			[Address(RVA = "0x15EC990", Offset = "0x15EC990", Length = "0x54")]
			set
			{
			}
		}

		[Token(Token = "0x17000131")]
		public float wordWrappingRatios
		{
			[Token(Token = "0x60004F1")]
			[Address(RVA = "0x15EC9E4", Offset = "0x15EC9E4", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60004F2")]
			[Address(RVA = "0x15EC9EC", Offset = "0x15EC9EC", Length = "0x50")]
			set
			{
			}
		}

		[Token(Token = "0x17000132")]
		public TextOverflowModes overflowMode
		{
			[Token(Token = "0x60004F3")]
			[Address(RVA = "0x15ECA3C", Offset = "0x15ECA3C", Length = "0x8")]
			get
			{
				return TextOverflowModes.Overflow;
			}
			[Token(Token = "0x60004F4")]
			[Address(RVA = "0x15ECA44", Offset = "0x15ECA44", Length = "0x50")]
			set
			{
			}
		}

		[Token(Token = "0x17000133")]
		public bool isTextOverflowing
		{
			[Token(Token = "0x60004F5")]
			[Address(RVA = "0x15ECA94", Offset = "0x15ECA94", Length = "0x10")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x17000134")]
		public int firstOverflowCharacterIndex
		{
			[Token(Token = "0x60004F6")]
			[Address(RVA = "0x15ECAA4", Offset = "0x15ECAA4", Length = "0x8")]
			get
			{
				return 0;
			}
		}

		[Token(Token = "0x17000135")]
		public TMP_Text linkedTextComponent
		{
			[Token(Token = "0x60004F7")]
			[Address(RVA = "0x15ECAAC", Offset = "0x15ECAAC", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60004F8")]
			[Address(RVA = "0x15ECAB4", Offset = "0x15ECAB4", Length = "0xEC")]
			set
			{
			}
		}

		[Token(Token = "0x17000136")]
		public bool isTextTruncated
		{
			[Token(Token = "0x60004F9")]
			[Address(RVA = "0x15ECD98", Offset = "0x15ECD98", Length = "0x8")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x17000137")]
		public bool enableKerning
		{
			[Token(Token = "0x60004FA")]
			[Address(RVA = "0x15ECDA0", Offset = "0x15ECDA0", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60004FB")]
			[Address(RVA = "0x15ECDA8", Offset = "0x15ECDA8", Length = "0x54")]
			set
			{
			}
		}

		[Token(Token = "0x17000138")]
		public bool extraPadding
		{
			[Token(Token = "0x60004FC")]
			[Address(RVA = "0x15ECDFC", Offset = "0x15ECDFC", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60004FD")]
			[Address(RVA = "0x15ECE04", Offset = "0x15ECE04", Length = "0x54")]
			set
			{
			}
		}

		[Token(Token = "0x17000139")]
		public bool richText
		{
			[Token(Token = "0x60004FE")]
			[Address(RVA = "0x15ECE58", Offset = "0x15ECE58", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60004FF")]
			[Address(RVA = "0x15ECE60", Offset = "0x15ECE60", Length = "0x54")]
			set
			{
			}
		}

		[Token(Token = "0x1700013A")]
		public bool parseCtrlCharacters
		{
			[Token(Token = "0x6000500")]
			[Address(RVA = "0x15ECEB4", Offset = "0x15ECEB4", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000501")]
			[Address(RVA = "0x15ECEBC", Offset = "0x15ECEBC", Length = "0x54")]
			set
			{
			}
		}

		[Token(Token = "0x1700013B")]
		public bool isOverlay
		{
			[Token(Token = "0x6000502")]
			[Address(RVA = "0x15ECF10", Offset = "0x15ECF10", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000503")]
			[Address(RVA = "0x15ECF18", Offset = "0x15ECF18", Length = "0x54")]
			set
			{
			}
		}

		[Token(Token = "0x1700013C")]
		public bool isOrthographic
		{
			[Token(Token = "0x6000504")]
			[Address(RVA = "0x15ECF6C", Offset = "0x15ECF6C", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000505")]
			[Address(RVA = "0x15ECF74", Offset = "0x15ECF74", Length = "0x30")]
			set
			{
			}
		}

		[Token(Token = "0x1700013D")]
		public bool enableCulling
		{
			[Token(Token = "0x6000506")]
			[Address(RVA = "0x15ECFA4", Offset = "0x15ECFA4", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000507")]
			[Address(RVA = "0x15ECFAC", Offset = "0x15ECFAC", Length = "0x3C")]
			set
			{
			}
		}

		[Token(Token = "0x1700013E")]
		public bool ignoreVisibility
		{
			[Token(Token = "0x6000508")]
			[Address(RVA = "0x15ECFE8", Offset = "0x15ECFE8", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000509")]
			[Address(RVA = "0x15ECFF0", Offset = "0x15ECFF0", Length = "0x20")]
			set
			{
			}
		}

		[Token(Token = "0x1700013F")]
		public TextureMappingOptions horizontalMapping
		{
			[Token(Token = "0x600050A")]
			[Address(RVA = "0x15ED010", Offset = "0x15ED010", Length = "0x8")]
			get
			{
				return TextureMappingOptions.Character;
			}
			[Token(Token = "0x600050B")]
			[Address(RVA = "0x15ED018", Offset = "0x15ED018", Length = "0x2C")]
			set
			{
			}
		}

		[Token(Token = "0x17000140")]
		public TextureMappingOptions verticalMapping
		{
			[Token(Token = "0x600050C")]
			[Address(RVA = "0x15ED044", Offset = "0x15ED044", Length = "0x8")]
			get
			{
				return TextureMappingOptions.Character;
			}
			[Token(Token = "0x600050D")]
			[Address(RVA = "0x15ED04C", Offset = "0x15ED04C", Length = "0x2C")]
			set
			{
			}
		}

		[Token(Token = "0x17000141")]
		public float mappingUvLineOffset
		{
			[Token(Token = "0x600050E")]
			[Address(RVA = "0x15ED078", Offset = "0x15ED078", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x600050F")]
			[Address(RVA = "0x15ED080", Offset = "0x15ED080", Length = "0x2C")]
			set
			{
			}
		}

		[Token(Token = "0x17000142")]
		public TextRenderFlags renderMode
		{
			[Token(Token = "0x6000510")]
			[Address(RVA = "0x15ED0AC", Offset = "0x15ED0AC", Length = "0x8")]
			get
			{
				return TextRenderFlags.DontRender;
			}
			[Token(Token = "0x6000511")]
			[Address(RVA = "0x15ED0B4", Offset = "0x15ED0B4", Length = "0x1C")]
			set
			{
			}
		}

		[Token(Token = "0x17000143")]
		public VertexSortingOrder geometrySortingOrder
		{
			[Token(Token = "0x6000512")]
			[Address(RVA = "0x15ED0D0", Offset = "0x15ED0D0", Length = "0x8")]
			get
			{
				return VertexSortingOrder.Normal;
			}
			[Token(Token = "0x6000513")]
			[Address(RVA = "0x15ED0D8", Offset = "0x15ED0D8", Length = "0x1C")]
			set
			{
			}
		}

		[Token(Token = "0x17000144")]
		public bool isTextObjectScaleStatic
		{
			[Token(Token = "0x6000514")]
			[Address(RVA = "0x15ED0F4", Offset = "0x15ED0F4", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000515")]
			[Address(RVA = "0x15ED0FC", Offset = "0x15ED0FC", Length = "0x80")]
			set
			{
			}
		}

		[Token(Token = "0x17000145")]
		public bool vertexBufferAutoSizeReduction
		{
			[Token(Token = "0x6000516")]
			[Address(RVA = "0x15ED17C", Offset = "0x15ED17C", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000517")]
			[Address(RVA = "0x15ED184", Offset = "0x15ED184", Length = "0x20")]
			set
			{
			}
		}

		[Token(Token = "0x17000146")]
		public int firstVisibleCharacter
		{
			[Token(Token = "0x6000518")]
			[Address(RVA = "0x15ED1A4", Offset = "0x15ED1A4", Length = "0x8")]
			get
			{
				return 0;
			}
			[Token(Token = "0x6000519")]
			[Address(RVA = "0x15ED1AC", Offset = "0x15ED1AC", Length = "0x2C")]
			set
			{
			}
		}

		[Token(Token = "0x17000147")]
		public int maxVisibleCharacters
		{
			[Token(Token = "0x600051A")]
			[Address(RVA = "0x15ED1D8", Offset = "0x15ED1D8", Length = "0x8")]
			get
			{
				return 0;
			}
			[Token(Token = "0x600051B")]
			[Address(RVA = "0x15ED1E0", Offset = "0x15ED1E0", Length = "0x2C")]
			set
			{
			}
		}

		[Token(Token = "0x17000148")]
		public int maxVisibleWords
		{
			[Token(Token = "0x600051C")]
			[Address(RVA = "0x15ED20C", Offset = "0x15ED20C", Length = "0x8")]
			get
			{
				return 0;
			}
			[Token(Token = "0x600051D")]
			[Address(RVA = "0x15ED214", Offset = "0x15ED214", Length = "0x2C")]
			set
			{
			}
		}

		[Token(Token = "0x17000149")]
		public int maxVisibleLines
		{
			[Token(Token = "0x600051E")]
			[Address(RVA = "0x15ED240", Offset = "0x15ED240", Length = "0x8")]
			get
			{
				return 0;
			}
			[Token(Token = "0x600051F")]
			[Address(RVA = "0x15ED248", Offset = "0x15ED248", Length = "0x2C")]
			set
			{
			}
		}

		[Token(Token = "0x1700014A")]
		public bool useMaxVisibleDescender
		{
			[Token(Token = "0x6000520")]
			[Address(RVA = "0x15ED274", Offset = "0x15ED274", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000521")]
			[Address(RVA = "0x15ED27C", Offset = "0x15ED27C", Length = "0x30")]
			set
			{
			}
		}

		[Token(Token = "0x1700014B")]
		public int pageToDisplay
		{
			[Token(Token = "0x6000522")]
			[Address(RVA = "0x15ED2AC", Offset = "0x15ED2AC", Length = "0x8")]
			get
			{
				return 0;
			}
			[Token(Token = "0x6000523")]
			[Address(RVA = "0x15ED2B4", Offset = "0x15ED2B4", Length = "0x2C")]
			set
			{
			}
		}

		[Token(Token = "0x1700014C")]
		public virtual Vector4 margin
		{
			[Token(Token = "0x6000524")]
			[Address(RVA = "0x15ED2E0", Offset = "0x15ED2E0", Length = "0x14")]
			get
			{
				return default(Vector4);
			}
			[Token(Token = "0x6000525")]
			[Address(RVA = "0x15ED2F4", Offset = "0x15ED2F4", Length = "0x9C")]
			set
			{
			}
		}

		[Token(Token = "0x1700014D")]
		public TMP_TextInfo textInfo
		{
			[Token(Token = "0x6000526")]
			[Address(RVA = "0x15ED390", Offset = "0x15ED390", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700014E")]
		public bool havePropertiesChanged
		{
			[Token(Token = "0x6000527")]
			[Address(RVA = "0x15ED398", Offset = "0x15ED398", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000528")]
			[Address(RVA = "0x15ED3A0", Offset = "0x15ED3A0", Length = "0x28")]
			set
			{
			}
		}

		[Token(Token = "0x1700014F")]
		public bool isUsingLegacyAnimationComponent
		{
			[Token(Token = "0x6000529")]
			[Address(RVA = "0x15ED3C8", Offset = "0x15ED3C8", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x600052A")]
			[Address(RVA = "0x15ED3D0", Offset = "0x15ED3D0", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x17000150")]
		public new Transform transform
		{
			[Token(Token = "0x600052B")]
			[Address(RVA = "0x15ED3DC", Offset = "0x15ED3DC", Length = "0x94")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000151")]
		public new RectTransform rectTransform
		{
			[Token(Token = "0x600052C")]
			[Address(RVA = "0x15ED470", Offset = "0x15ED470", Length = "0x94")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000152")]
		[field: Token(Token = "0x400053B")]
		[field: FieldOffset(Offset = "0x398")]
		public virtual bool autoSizeTextContainer
		{
			[Token(Token = "0x600052D")]
			[Address(RVA = "0x15ED504", Offset = "0x15ED504", Length = "0x8")]
			get;
			[Token(Token = "0x600052E")]
			[Address(RVA = "0x15ED50C", Offset = "0x15ED50C", Length = "0xC")]
			set;
		}

		[Token(Token = "0x17000153")]
		public virtual Mesh mesh
		{
			[Token(Token = "0x600052F")]
			[Address(RVA = "0x15ED518", Offset = "0x15ED518", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000154")]
		public bool isVolumetricText
		{
			[Token(Token = "0x6000530")]
			[Address(RVA = "0x15ED520", Offset = "0x15ED520", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000531")]
			[Address(RVA = "0x15ED528", Offset = "0x15ED528", Length = "0x68")]
			set
			{
			}
		}

		[Token(Token = "0x17000155")]
		public Bounds bounds
		{
			[Token(Token = "0x6000532")]
			[Address(RVA = "0x15ED590", Offset = "0x15ED590", Length = "0xB0")]
			get
			{
				return default(Bounds);
			}
		}

		[Token(Token = "0x17000156")]
		public Bounds textBounds
		{
			[Token(Token = "0x6000533")]
			[Address(RVA = "0x15ED640", Offset = "0x15ED640", Length = "0x44")]
			get
			{
				return default(Bounds);
			}
		}

		[Token(Token = "0x17000157")]
		protected TMP_SpriteAnimator spriteAnimator
		{
			[Token(Token = "0x600053A")]
			[Address(RVA = "0x15EDD68", Offset = "0x15EDD68", Length = "0xEC")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000158")]
		public float flexibleHeight
		{
			[Token(Token = "0x600053B")]
			[Address(RVA = "0x15EDE54", Offset = "0x15EDE54", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000159")]
		public float flexibleWidth
		{
			[Token(Token = "0x600053C")]
			[Address(RVA = "0x15EDE5C", Offset = "0x15EDE5C", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x1700015A")]
		public float minWidth
		{
			[Token(Token = "0x600053D")]
			[Address(RVA = "0x15EDE64", Offset = "0x15EDE64", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x1700015B")]
		public float minHeight
		{
			[Token(Token = "0x600053E")]
			[Address(RVA = "0x15EDE6C", Offset = "0x15EDE6C", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x1700015C")]
		public float maxWidth
		{
			[Token(Token = "0x600053F")]
			[Address(RVA = "0x15EDE74", Offset = "0x15EDE74", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x1700015D")]
		public float maxHeight
		{
			[Token(Token = "0x6000540")]
			[Address(RVA = "0x15EDE7C", Offset = "0x15EDE7C", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x1700015E")]
		protected LayoutElement layoutElement
		{
			[Token(Token = "0x6000541")]
			[Address(RVA = "0x15EDE84", Offset = "0x15EDE84", Length = "0x94")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700015F")]
		public virtual float preferredWidth
		{
			[Token(Token = "0x6000542")]
			[Address(RVA = "0x15EDF18", Offset = "0x15EDF18", Length = "0x18")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000160")]
		public virtual float preferredHeight
		{
			[Token(Token = "0x6000543")]
			[Address(RVA = "0x15EE06C", Offset = "0x15EE06C", Length = "0x18")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000161")]
		public virtual float renderedWidth
		{
			[Token(Token = "0x6000544")]
			[Address(RVA = "0x15EE1FC", Offset = "0x15EE1FC", Length = "0x24")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000162")]
		public virtual float renderedHeight
		{
			[Token(Token = "0x6000545")]
			[Address(RVA = "0x15EE244", Offset = "0x15EE244", Length = "0x24")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000163")]
		public int layoutPriority
		{
			[Token(Token = "0x6000546")]
			[Address(RVA = "0x15EE28C", Offset = "0x15EE28C", Length = "0x8")]
			get
			{
				return 0;
			}
		}

		[Token(Token = "0x14000003")]
		public static event Func<int, string, TMP_FontAsset> OnFontAssetRequest
		{
			[CompilerGenerated]
			[Token(Token = "0x6000534")]
			[Address(RVA = "0x15ED830", Offset = "0x15ED830", Length = "0xF4")]
			add
			{
			}
			[CompilerGenerated]
			[Token(Token = "0x6000535")]
			[Address(RVA = "0x15ED924", Offset = "0x15ED924", Length = "0xF4")]
			remove
			{
			}
		}

		[Token(Token = "0x14000004")]
		public static event Func<int, string, TMP_SpriteAsset> OnSpriteAssetRequest
		{
			[CompilerGenerated]
			[Token(Token = "0x6000536")]
			[Address(RVA = "0x15EDA18", Offset = "0x15EDA18", Length = "0xF4")]
			add
			{
			}
			[CompilerGenerated]
			[Token(Token = "0x6000537")]
			[Address(RVA = "0x15EDB0C", Offset = "0x15EDB0C", Length = "0xF4")]
			remove
			{
			}
		}

		[Token(Token = "0x14000005")]
		public virtual event Action<TMP_TextInfo> OnPreRenderText
		{
			[CompilerGenerated]
			[Token(Token = "0x6000538")]
			[Address(RVA = "0x15EDC00", Offset = "0x15EDC00", Length = "0xB4")]
			add
			{
			}
			[CompilerGenerated]
			[Token(Token = "0x6000539")]
			[Address(RVA = "0x15EDCB4", Offset = "0x15EDCB4", Length = "0xB4")]
			remove
			{
			}
		}

		[Token(Token = "0x6000547")]
		[Address(RVA = "0x15EE294", Offset = "0x15EE294", Length = "0x4")]
		protected virtual void LoadFontAsset()
		{
		}

		[Token(Token = "0x6000548")]
		[Address(RVA = "0x15EE298", Offset = "0x15EE298", Length = "0x4")]
		protected virtual void SetSharedMaterial(Material mat)
		{
		}

		[Token(Token = "0x6000549")]
		[Address(RVA = "0x15EE29C", Offset = "0x15EE29C", Length = "0x8")]
		protected virtual Material GetMaterial(Material mat)
		{
			return null;
		}

		[Token(Token = "0x600054A")]
		[Address(RVA = "0x15EE2A4", Offset = "0x15EE2A4", Length = "0x4")]
		protected virtual void SetFontBaseMaterial(Material mat)
		{
		}

		[Token(Token = "0x600054B")]
		[Address(RVA = "0x15EE2A8", Offset = "0x15EE2A8", Length = "0x8")]
		protected virtual Material[] GetSharedMaterials()
		{
			return null;
		}

		[Token(Token = "0x600054C")]
		[Address(RVA = "0x15EE2B0", Offset = "0x15EE2B0", Length = "0x4")]
		protected virtual void SetSharedMaterials(Material[] materials)
		{
		}

		[Token(Token = "0x600054D")]
		[Address(RVA = "0x15EE2B4", Offset = "0x15EE2B4", Length = "0x8")]
		protected virtual Material[] GetMaterials(Material[] mats)
		{
			return null;
		}

		[Token(Token = "0x600054E")]
		[Address(RVA = "0x15EE2BC", Offset = "0x15EE2BC", Length = "0xC0")]
		protected virtual Material CreateMaterialInstance(Material source)
		{
			return null;
		}

		[Token(Token = "0x600054F")]
		[Address(RVA = "0x15EE37C", Offset = "0x15EE37C", Length = "0xBC")]
		protected void SetVertexColorGradient(TMP_ColorGradient gradient)
		{
		}

		[Token(Token = "0x6000550")]
		[Address(RVA = "0x15EE438", Offset = "0x15EE438", Length = "0x4")]
		protected void SetTextSortingOrder(VertexSortingOrder order)
		{
		}

		[Token(Token = "0x6000551")]
		[Address(RVA = "0x15EE43C", Offset = "0x15EE43C", Length = "0x4")]
		protected void SetTextSortingOrder(int[] order)
		{
		}

		[Token(Token = "0x6000552")]
		[Address(RVA = "0x15EE440", Offset = "0x15EE440", Length = "0x4")]
		protected virtual void SetFaceColor(Color32 color)
		{
		}

		[Token(Token = "0x6000553")]
		[Address(RVA = "0x15EE444", Offset = "0x15EE444", Length = "0x4")]
		protected virtual void SetOutlineColor(Color32 color)
		{
		}

		[Token(Token = "0x6000554")]
		[Address(RVA = "0x15EE448", Offset = "0x15EE448", Length = "0x4")]
		protected virtual void SetOutlineThickness(float thickness)
		{
		}

		[Token(Token = "0x6000555")]
		[Address(RVA = "0x15EE44C", Offset = "0x15EE44C", Length = "0x4")]
		protected virtual void SetShaderDepth()
		{
		}

		[Token(Token = "0x6000556")]
		[Address(RVA = "0x15EE450", Offset = "0x15EE450", Length = "0x4")]
		protected virtual void SetCulling()
		{
		}

		[Token(Token = "0x6000557")]
		[Address(RVA = "0x15EE454", Offset = "0x15EE454", Length = "0x4")]
		internal virtual void UpdateCulling()
		{
		}

		[Token(Token = "0x6000558")]
		[Address(RVA = "0x15EE458", Offset = "0x15EE458", Length = "0x120")]
		protected virtual float GetPaddingForMaterial()
		{
			return 0f;
		}

		[Token(Token = "0x6000559")]
		[Address(RVA = "0x15EE578", Offset = "0x15EE578", Length = "0x100")]
		protected virtual float GetPaddingForMaterial(Material mat)
		{
			return 0f;
		}

		[Token(Token = "0x600055A")]
		[Address(RVA = "0x15EE678", Offset = "0x15EE678", Length = "0x8")]
		protected virtual Vector3[] GetTextContainerLocalCorners()
		{
			return null;
		}

		[Token(Token = "0x600055B")]
		[Address(RVA = "0x15EE680", Offset = "0x15EE680", Length = "0x4")]
		public virtual void ForceMeshUpdate(bool ignoreActiveState = false, bool forceTextReparsing = false)
		{
		}

		[Token(Token = "0x600055C")]
		[Address(RVA = "0x15EE684", Offset = "0x15EE684", Length = "0x4")]
		public virtual void UpdateGeometry(Mesh mesh, int index)
		{
		}

		[Token(Token = "0x600055D")]
		[Address(RVA = "0x15EE688", Offset = "0x15EE688", Length = "0x4")]
		public virtual void UpdateVertexData(TMP_VertexDataUpdateFlags flags)
		{
		}

		[Token(Token = "0x600055E")]
		[Address(RVA = "0x15EE68C", Offset = "0x15EE68C", Length = "0x4")]
		public virtual void UpdateVertexData()
		{
		}

		[Token(Token = "0x600055F")]
		[Address(RVA = "0x15EE690", Offset = "0x15EE690", Length = "0x4")]
		public virtual void SetVertices(Vector3[] vertices)
		{
		}

		[Token(Token = "0x6000560")]
		[Address(RVA = "0x15EE694", Offset = "0x15EE694", Length = "0x4")]
		public virtual void UpdateMeshPadding()
		{
		}

		[Token(Token = "0x6000561")]
		[Address(RVA = "0x15EE698", Offset = "0x15EE698", Length = "0x88")]
		public override void CrossFadeColor(Color targetColor, float duration, bool ignoreTimeScale, bool useAlpha)
		{
		}

		[Token(Token = "0x6000562")]
		[Address(RVA = "0x15EE720", Offset = "0x15EE720", Length = "0x54")]
		public override void CrossFadeAlpha(float alpha, float duration, bool ignoreTimeScale)
		{
		}

		[Token(Token = "0x6000563")]
		[Address(RVA = "0x15EE774", Offset = "0x15EE774", Length = "0x4")]
		protected virtual void InternalCrossFadeColor(Color targetColor, float duration, bool ignoreTimeScale, bool useAlpha)
		{
		}

		[Token(Token = "0x6000564")]
		[Address(RVA = "0x15EE778", Offset = "0x15EE778", Length = "0x4")]
		protected virtual void InternalCrossFadeAlpha(float alpha, float duration, bool ignoreTimeScale)
		{
		}

		[Token(Token = "0x6000565")]
		[Address(RVA = "0x15EE77C", Offset = "0x15EE77C", Length = "0x118")]
		protected void ParseInputText()
		{
		}

		[Token(Token = "0x6000566")]
		[Address(RVA = "0x15EE894", Offset = "0x15EE894", Length = "0x18")]
		private void PopulateTextBackingArray(string sourceText)
		{
		}

		[Token(Token = "0x6000567")]
		[Address(RVA = "0x15EF31C", Offset = "0x15EF31C", Length = "0xF8")]
		private void PopulateTextBackingArray(string sourceText, int start, int length)
		{
		}

		[Token(Token = "0x6000568")]
		[Address(RVA = "0x15EF414", Offset = "0x15EF414", Length = "0x128")]
		private void PopulateTextBackingArray(StringBuilder sourceText, int start, int length)
		{
		}

		[Token(Token = "0x6000569")]
		[Address(RVA = "0x15EF53C", Offset = "0x15EF53C", Length = "0x114")]
		private void PopulateTextBackingArray(char[] sourceText, int start, int length)
		{
		}

		[Token(Token = "0x600056A")]
		[Address(RVA = "0x15EE8AC", Offset = "0x15EE8AC", Length = "0xA70")]
		private void PopulateTextProcessingArray()
		{
		}

		[Token(Token = "0x600056B")]
		[Address(RVA = "0x15F08D0", Offset = "0x15F08D0", Length = "0x4C")]
		private void SetTextInternal(string sourceText)
		{
		}

		[Token(Token = "0x600056C")]
		[Address(RVA = "0x15F091C", Offset = "0x15F091C", Length = "0x7C")]
		public void SetText(string sourceText, bool syncTextInputBox = true)
		{
		}

		[Token(Token = "0x600056D")]
		[Address(RVA = "0x15F0998", Offset = "0x15F0998", Length = "0x20")]
		public void SetText(string sourceText, float arg0)
		{
		}

		[Token(Token = "0x600056E")]
		[Address(RVA = "0x15F0C78", Offset = "0x15F0C78", Length = "0x1C")]
		public void SetText(string sourceText, float arg0, float arg1)
		{
		}

		[Token(Token = "0x600056F")]
		[Address(RVA = "0x15F0C94", Offset = "0x15F0C94", Length = "0x18")]
		public void SetText(string sourceText, float arg0, float arg1, float arg2)
		{
		}

		[Token(Token = "0x6000570")]
		[Address(RVA = "0x15F0CAC", Offset = "0x15F0CAC", Length = "0x14")]
		public void SetText(string sourceText, float arg0, float arg1, float arg2, float arg3)
		{
		}

		[Token(Token = "0x6000571")]
		[Address(RVA = "0x15F0CC0", Offset = "0x15F0CC0", Length = "0x10")]
		public void SetText(string sourceText, float arg0, float arg1, float arg2, float arg3, float arg4)
		{
		}

		[Token(Token = "0x6000572")]
		[Address(RVA = "0x15F0CD0", Offset = "0x15F0CD0", Length = "0xC")]
		public void SetText(string sourceText, float arg0, float arg1, float arg2, float arg3, float arg4, float arg5)
		{
		}

		[Token(Token = "0x6000573")]
		[Address(RVA = "0x15F0CDC", Offset = "0x15F0CDC", Length = "0x8")]
		public void SetText(string sourceText, float arg0, float arg1, float arg2, float arg3, float arg4, float arg5, float arg6)
		{
		}

		[Token(Token = "0x6000574")]
		[Address(RVA = "0x15F09B8", Offset = "0x15F09B8", Length = "0x2C0")]
		public void SetText(string sourceText, float arg0, float arg1, float arg2, float arg3, float arg4, float arg5, float arg6, float arg7)
		{
		}

		[Token(Token = "0x6000575")]
		[Address(RVA = "0x15F0FC0", Offset = "0x15F0FC0", Length = "0x44")]
		public void SetText(StringBuilder sourceText)
		{
		}

		[Token(Token = "0x6000576")]
		[Address(RVA = "0x15F1004", Offset = "0x15F1004", Length = "0x5C")]
		private void SetText(StringBuilder sourceText, int start, int length)
		{
		}

		[Token(Token = "0x6000577")]
		[Address(RVA = "0x15F1060", Offset = "0x15F1060", Length = "0x18")]
		public void SetText(char[] sourceText)
		{
		}

		[Token(Token = "0x6000578")]
		[Address(RVA = "0x15F10D4", Offset = "0x15F10D4", Length = "0x4")]
		public void SetText(char[] sourceText, int start, int length)
		{
		}

		[Token(Token = "0x6000579")]
		[Address(RVA = "0x15F10D8", Offset = "0x15F10D8", Length = "0x18")]
		public void SetCharArray(char[] sourceText)
		{
		}

		[Token(Token = "0x600057A")]
		[Address(RVA = "0x15F1078", Offset = "0x15F1078", Length = "0x5C")]
		public void SetCharArray(char[] sourceText, int start, int length)
		{
		}

		[Token(Token = "0x600057B")]
		[Address(RVA = "0x15EBE1C", Offset = "0x15EBE1C", Length = "0xF0")]
		private TMP_Style GetStyle(int hashCode)
		{
			return null;
		}

		[Token(Token = "0x600057C")]
		[Address(RVA = "0x15EFD04", Offset = "0x15EFD04", Length = "0x41C")]
		private bool ReplaceOpeningStyleTag(ref TextBackingContainer sourceText, int srcIndex, out int srcOffset, ref UnicodeChar[] charBuffer, ref int writeIndex)
		{
			srcOffset = default(int);
			return false;
		}

		[Token(Token = "0x600057D")]
		[Address(RVA = "0x15F1508", Offset = "0x15F1508", Length = "0x41C")]
		private bool ReplaceOpeningStyleTag(ref int[] sourceText, int srcIndex, out int srcOffset, ref UnicodeChar[] charBuffer, ref int writeIndex)
		{
			srcOffset = default(int);
			return false;
		}

		[Token(Token = "0x600057E")]
		[Address(RVA = "0x15F0120", Offset = "0x15F0120", Length = "0x3EC")]
		private void ReplaceClosingStyleTag(ref TextBackingContainer sourceText, int srcIndex, ref UnicodeChar[] charBuffer, ref int writeIndex)
		{
		}

		[Token(Token = "0x600057F")]
		[Address(RVA = "0x15F1924", Offset = "0x15F1924", Length = "0x3EC")]
		private void ReplaceClosingStyleTag(ref int[] sourceText, int srcIndex, ref UnicodeChar[] charBuffer, ref int writeIndex)
		{
		}

		[Token(Token = "0x6000580")]
		[Address(RVA = "0x15EF650", Offset = "0x15EF650", Length = "0x3C8")]
		private bool InsertOpeningStyleTag(TMP_Style style, int srcIndex, ref UnicodeChar[] charBuffer, ref int writeIndex)
		{
			return false;
		}

		[Token(Token = "0x6000581")]
		[Address(RVA = "0x15F050C", Offset = "0x15F050C", Length = "0x3C4")]
		private void InsertClosingStyleTag(ref UnicodeChar[] charBuffer, ref int writeIndex)
		{
		}

		[Token(Token = "0x6000582")]
		[Address(RVA = "0x15F13EC", Offset = "0x15F13EC", Length = "0x11C")]
		private int GetMarkupTagHashCode(int[] tagDefinition, int readIndex)
		{
			return 0;
		}

		[Token(Token = "0x6000583")]
		[Address(RVA = "0x15EFBF8", Offset = "0x15EFBF8", Length = "0x10C")]
		private int GetMarkupTagHashCode(TextBackingContainer tagDefinition, int readIndex)
		{
			return 0;
		}

		[Token(Token = "0x6000584")]
		[Address(RVA = "0x15F1D10", Offset = "0x15F1D10", Length = "0xDC")]
		private int GetStyleHashCode(ref int[] text, int index, out int closeIndex)
		{
			closeIndex = default(int);
			return 0;
		}

		[Token(Token = "0x6000585")]
		[Address(RVA = "0x15F10F0", Offset = "0x15F10F0", Length = "0x10C")]
		private int GetStyleHashCode(ref TextBackingContainer text, int index, out int closeIndex)
		{
			closeIndex = default(int);
			return 0;
		}

		[Token(Token = "0x6000586")]
		[Address(RVA = "0xCABFAC", Offset = "0xCABFAC", Length = "0x5C")]
		private void ResizeInternalArray<T>(ref T[] array)
		{
		}

		[Token(Token = "0x6000587")]
		[Address(RVA = "0xCAC060", Offset = "0xCAC060", Length = "0x50")]
		private void ResizeInternalArray<T>(ref T[] array, int size)
		{
		}

		[Token(Token = "0x6000588")]
		[Address(RVA = "0x15F0CE4", Offset = "0x15F0CE4", Length = "0x2DC")]
		private void AddFloatToInternalTextBackingArray(float value, int padding, int precision, ref int writeIndex)
		{
		}

		[Token(Token = "0x6000589")]
		[Address(RVA = "0x15F1DEC", Offset = "0x15F1DEC", Length = "0x130")]
		private void AddIntegerToInternalTextBackingArray(double number, int padding, ref int writeIndex)
		{
		}

		[Token(Token = "0x600058A")]
		[Address(RVA = "0x15EB680", Offset = "0x15EB680", Length = "0xD4")]
		private string InternalTextBackingArrayToString()
		{
			return null;
		}

		[Token(Token = "0x600058B")]
		[Address(RVA = "0x15F1F1C", Offset = "0x15F1F1C", Length = "0x8")]
		internal virtual int SetArraySizes(UnicodeChar[] unicodeChars)
		{
			return 0;
		}

		[Token(Token = "0x600058C")]
		[Address(RVA = "0x15F1F24", Offset = "0x15F1F24", Length = "0x4C")]
		public Vector2 GetPreferredValues()
		{
			return default(Vector2);
		}

		[Token(Token = "0x600058D")]
		[Address(RVA = "0x15F1F70", Offset = "0x15F1F70", Length = "0xAC")]
		public Vector2 GetPreferredValues(float width, float height)
		{
			return default(Vector2);
		}

		[Token(Token = "0x600058E")]
		[Address(RVA = "0x15F2124", Offset = "0x15F2124", Length = "0x128")]
		public Vector2 GetPreferredValues(string text)
		{
			return default(Vector2);
		}

		[Token(Token = "0x600058F")]
		[Address(RVA = "0x15F224C", Offset = "0x15F224C", Length = "0xC4")]
		public Vector2 GetPreferredValues(string text, float width, float height)
		{
			return default(Vector2);
		}

		[Token(Token = "0x6000590")]
		[Address(RVA = "0x15EDF30", Offset = "0x15EDF30", Length = "0x13C")]
		protected float GetPreferredWidth()
		{
			return 0f;
		}

		[Token(Token = "0x6000591")]
		[Address(RVA = "0x15F201C", Offset = "0x15F201C", Length = "0x5C")]
		private float GetPreferredWidth(Vector2 margin)
		{
			return 0f;
		}

		[Token(Token = "0x6000592")]
		[Address(RVA = "0x15EE084", Offset = "0x15EE084", Length = "0x178")]
		protected float GetPreferredHeight()
		{
			return 0f;
		}

		[Token(Token = "0x6000593")]
		[Address(RVA = "0x15F2078", Offset = "0x15F2078", Length = "0xAC")]
		private float GetPreferredHeight(Vector2 margin)
		{
			return 0f;
		}

		[Token(Token = "0x6000594")]
		[Address(RVA = "0x15F2310", Offset = "0x15F2310", Length = "0x28")]
		public Vector2 GetRenderedValues()
		{
			return default(Vector2);
		}

		[Token(Token = "0x6000595")]
		[Address(RVA = "0x15F2338", Offset = "0x15F2338", Length = "0x2C")]
		public Vector2 GetRenderedValues(bool onlyVisibleCharacters)
		{
			return default(Vector2);
		}

		[Token(Token = "0x6000596")]
		[Address(RVA = "0x15EE220", Offset = "0x15EE220", Length = "0x24")]
		private float GetRenderedWidth()
		{
			return 0f;
		}

		[Token(Token = "0x6000597")]
		[Address(RVA = "0x15F256C", Offset = "0x15F256C", Length = "0x28")]
		protected float GetRenderedWidth(bool onlyVisibleCharacters)
		{
			return 0f;
		}

		[Token(Token = "0x6000598")]
		[Address(RVA = "0x15EE268", Offset = "0x15EE268", Length = "0x24")]
		private float GetRenderedHeight()
		{
			return 0f;
		}

		[Token(Token = "0x6000599")]
		[Address(RVA = "0x15F2594", Offset = "0x15F2594", Length = "0x28")]
		protected float GetRenderedHeight(bool onlyVisibleCharacters)
		{
			return 0f;
		}

		[Token(Token = "0x600059A")]
		[Address(RVA = "0x15F25BC", Offset = "0x15F25BC", Length = "0x208C")]
		protected virtual Vector2 CalculatePreferredValues(ref float fontSize, Vector2 marginSize, bool isTextAutoSizingEnabled, bool isWordWrappingEnabled)
		{
			return default(Vector2);
		}

		[Token(Token = "0x600059B")]
		[Address(RVA = "0x15FA6D0", Offset = "0x15FA6D0", Length = "0xC")]
		protected virtual Bounds GetCompoundBounds()
		{
			return default(Bounds);
		}

		[Token(Token = "0x600059C")]
		[Address(RVA = "0x15FA6DC", Offset = "0x15FA6DC", Length = "0x8")]
		internal virtual Rect GetCanvasSpaceClippingRect()
		{
			return default(Rect);
		}

		[Token(Token = "0x600059D")]
		[Address(RVA = "0x15ED684", Offset = "0x15ED684", Length = "0x1AC")]
		protected Bounds GetTextBounds()
		{
			return default(Bounds);
		}

		[Token(Token = "0x600059E")]
		[Address(RVA = "0x15F2364", Offset = "0x15F2364", Length = "0x208")]
		protected Bounds GetTextBounds(bool onlyVisibleCharacters)
		{
			return default(Bounds);
		}

		[Token(Token = "0x600059F")]
		[Address(RVA = "0x15FA6E4", Offset = "0x15FA6E4", Length = "0x1B8")]
		protected void AdjustLineOffset(int startIndex, int endIndex, float offset)
		{
		}

		[Token(Token = "0x60005A0")]
		[Address(RVA = "0x15FA89C", Offset = "0x15FA89C", Length = "0x1A8")]
		protected void ResizeLineExtents(int size)
		{
		}

		[Token(Token = "0x60005A1")]
		[Address(RVA = "0x15FAA44", Offset = "0x15FAA44", Length = "0x8")]
		public virtual TMP_TextInfo GetTextInfo(string text)
		{
			return null;
		}

		[Token(Token = "0x60005A2")]
		[Address(RVA = "0x15FAA4C", Offset = "0x15FAA4C", Length = "0x4")]
		public virtual void ComputeMarginSize()
		{
		}

		[Token(Token = "0x60005A3")]
		[Address(RVA = "0x15FAA50", Offset = "0x15FAA50", Length = "0x4D0")]
		protected void InsertNewLine(int i, float baseScale, float currentElementScale, float currentEmScale, float glyphAdjustment, float boldSpacingAdjustment, float characterSpacingAdjustment, float width, float lineGap, ref bool isMaxVisibleDescenderSet, ref float maxVisibleDescender)
		{
		}

		[Token(Token = "0x60005A4")]
		[Address(RVA = "0x15FA418", Offset = "0x15FA418", Length = "0x2B8")]
		protected void SaveWordWrappingState(ref WordWrapState state, int index, int count)
		{
		}

		[Token(Token = "0x60005A5")]
		[Address(RVA = "0x15FA134", Offset = "0x15FA134", Length = "0x2E4")]
		protected int RestoreWordWrappingState(ref WordWrapState state)
		{
			return 0;
		}

		[Token(Token = "0x60005A6")]
		[Address(RVA = "0x15FAF20", Offset = "0x15FAF20", Length = "0xB78")]
		protected virtual void SaveGlyphVertexInfo(float padding, float style_padding, Color32 vertexColor)
		{
		}

		[Token(Token = "0x60005A7")]
		[Address(RVA = "0x15FBA98", Offset = "0x15FBA98", Length = "0x760")]
		protected virtual void SaveSpriteVertexInfo(Color32 vertexColor)
		{
		}

		[Token(Token = "0x60005A8")]
		[Address(RVA = "0x15FC1F8", Offset = "0x15FC1F8", Length = "0x720")]
		protected virtual void FillCharacterVertexBuffers(int i, int index_X4)
		{
		}

		[Token(Token = "0x60005A9")]
		[Address(RVA = "0x15FC918", Offset = "0x15FC918", Length = "0xB30")]
		protected virtual void FillCharacterVertexBuffers(int i, int index_X4, bool isVolumetric)
		{
		}

		[Token(Token = "0x60005AA")]
		[Address(RVA = "0x15FD448", Offset = "0x15FD448", Length = "0x720")]
		protected virtual void FillSpriteVertexBuffers(int i, int index_X4)
		{
		}

		[Token(Token = "0x60005AB")]
		[Address(RVA = "0x15FDB68", Offset = "0x15FDB68", Length = "0xE84")]
		protected virtual void DrawUnderlineMesh(Vector3 start, Vector3 end, ref int index, float startScale, float endScale, float maxScale, float sdfScale, Color32 underlineColor)
		{
		}

		[Token(Token = "0x60005AC")]
		[Address(RVA = "0x15FEB9C", Offset = "0x15FEB9C", Length = "0x528")]
		protected virtual void DrawTextHighlight(Vector3 start, Vector3 end, ref int index, Color32 highlightColor)
		{
		}

		[Token(Token = "0x60005AD")]
		[Address(RVA = "0x15FF0C4", Offset = "0x15FF0C4", Length = "0x274")]
		protected void LoadDefaultSettings()
		{
		}

		[Token(Token = "0x60005AE")]
		[Address(RVA = "0x15FF338", Offset = "0x15FF338", Length = "0x28")]
		protected void GetSpecialCharacters(TMP_FontAsset fontAsset)
		{
		}

		[Token(Token = "0x60005AF")]
		[Address(RVA = "0x15FF360", Offset = "0x15FF360", Length = "0x244")]
		protected void GetEllipsisSpecialCharacter(TMP_FontAsset fontAsset)
		{
		}

		[Token(Token = "0x60005B0")]
		[Address(RVA = "0x15FE9EC", Offset = "0x15FE9EC", Length = "0x150")]
		protected void GetUnderlineSpecialCharacter(TMP_FontAsset fontAsset)
		{
		}

		[Token(Token = "0x60005B1")]
		[Address(RVA = "0x15FF5A4", Offset = "0x15FF5A4", Length = "0x74")]
		protected void ReplaceTagWithCharacter(int[] chars, int insertionIndex, int tagLength, char c)
		{
		}

		[Token(Token = "0x60005B2")]
		[Address(RVA = "0x15FF618", Offset = "0x15FF618", Length = "0x7C")]
		protected TMP_FontAsset GetFontAssetForWeight(int fontWeight)
		{
			return null;
		}

		[Token(Token = "0x60005B3")]
		[Address(RVA = "0x15FF694", Offset = "0x15FF694", Length = "0x3E4")]
		internal TMP_TextElement GetTextElement(uint unicode, TMP_FontAsset fontAsset, FontStyles fontStyle, FontWeight fontWeight, out bool isUsingAlternativeTypeface)
		{
			isUsingAlternativeTypeface = default(bool);
			return null;
		}

		[Token(Token = "0x60005B4")]
		[Address(RVA = "0x15FFA78", Offset = "0x15FFA78", Length = "0x4")]
		protected virtual void SetActiveSubMeshes(bool state)
		{
		}

		[Token(Token = "0x60005B5")]
		[Address(RVA = "0x15FFA7C", Offset = "0x15FFA7C", Length = "0x4")]
		protected virtual void DestroySubMeshObjects()
		{
		}

		[Token(Token = "0x60005B6")]
		[Address(RVA = "0x15FFA80", Offset = "0x15FFA80", Length = "0x4")]
		public virtual void ClearMesh()
		{
		}

		[Token(Token = "0x60005B7")]
		[Address(RVA = "0x15FFA84", Offset = "0x15FFA84", Length = "0x4")]
		public virtual void ClearMesh(bool uploadGeometry)
		{
		}

		[Token(Token = "0x60005B8")]
		[Address(RVA = "0x15FFA88", Offset = "0x15FFA88", Length = "0xF8")]
		public virtual string GetParsedText()
		{
			return null;
		}

		[Token(Token = "0x60005B9")]
		[Address(RVA = "0x15ECCB8", Offset = "0x15ECCB8", Length = "0xE0")]
		internal bool IsSelfOrLinkedAncestor(TMP_Text targetTextComponent)
		{
			return false;
		}

		[Token(Token = "0x60005BA")]
		[Address(RVA = "0x15ECBA0", Offset = "0x15ECBA0", Length = "0x118")]
		internal void ReleaseLinkedTextComponent(TMP_Text targetTextComponent)
		{
		}

		[Token(Token = "0x60005BB")]
		[Address(RVA = "0x15FEB3C", Offset = "0x15FEB3C", Length = "0x60")]
		protected Vector2 PackUV(float x, float y, float scale)
		{
			return default(Vector2);
		}

		[Token(Token = "0x60005BC")]
		[Address(RVA = "0x15FFB80", Offset = "0x15FFB80", Length = "0x60")]
		protected float PackUV(float x, float y)
		{
			return 0f;
		}

		[Token(Token = "0x60005BD")]
		[Address(RVA = "0x15FFBE0", Offset = "0x15FFBE0", Length = "0x4")]
		internal virtual void InternalUpdate()
		{
		}

		[Token(Token = "0x60005BE")]
		[Address(RVA = "0x15FFBE4", Offset = "0x15FFBE4", Length = "0x2C")]
		protected int HexToInt(char hex)
		{
			return 0;
		}

		[Token(Token = "0x60005BF")]
		[Address(RVA = "0x15FFC10", Offset = "0x15FFC10", Length = "0xA8")]
		protected int GetUTF16(string text, int i)
		{
			return 0;
		}

		[Token(Token = "0x60005C0")]
		[Address(RVA = "0x15F11FC", Offset = "0x15F11FC", Length = "0xA8")]
		protected int GetUTF16(int[] text, int i)
		{
			return 0;
		}

		[Token(Token = "0x60005C1")]
		[Address(RVA = "0x15FFCB8", Offset = "0x15FFCB8", Length = "0xA8")]
		internal int GetUTF16(uint[] text, int i)
		{
			return 0;
		}

		[Token(Token = "0x60005C2")]
		[Address(RVA = "0x15FFD60", Offset = "0x15FFD60", Length = "0xA8")]
		protected int GetUTF16(StringBuilder text, int i)
		{
			return 0;
		}

		[Token(Token = "0x60005C3")]
		[Address(RVA = "0x15EFA18", Offset = "0x15EFA18", Length = "0xA8")]
		private int GetUTF16(TextBackingContainer text, int i)
		{
			return 0;
		}

		[Token(Token = "0x60005C4")]
		[Address(RVA = "0x15FFE08", Offset = "0x15FFE08", Length = "0x138")]
		protected int GetUTF32(string text, int i)
		{
			return 0;
		}

		[Token(Token = "0x60005C5")]
		[Address(RVA = "0x15F12A4", Offset = "0x15F12A4", Length = "0x148")]
		protected int GetUTF32(int[] text, int i)
		{
			return 0;
		}

		[Token(Token = "0x60005C6")]
		[Address(RVA = "0x15FFF40", Offset = "0x15FFF40", Length = "0x148")]
		internal int GetUTF32(uint[] text, int i)
		{
			return 0;
		}

		[Token(Token = "0x60005C7")]
		[Address(RVA = "0x1600088", Offset = "0x1600088", Length = "0x138")]
		protected int GetUTF32(StringBuilder text, int i)
		{
			return 0;
		}

		[Token(Token = "0x60005C8")]
		[Address(RVA = "0x15EFAC0", Offset = "0x15EFAC0", Length = "0x138")]
		private int GetUTF32(TextBackingContainer text, int i)
		{
			return 0;
		}

		[Token(Token = "0x60005C9")]
		[Address(RVA = "0x16001C0", Offset = "0x16001C0", Length = "0x414")]
		protected Color32 HexCharsToColor(char[] hexChars, int tagCount)
		{
			return default(Color32);
		}

		[Token(Token = "0x60005CA")]
		[Address(RVA = "0x16005D4", Offset = "0x16005D4", Length = "0x24C")]
		protected Color32 HexCharsToColor(char[] hexChars, int startIndex, int length)
		{
			return default(Color32);
		}

		[Token(Token = "0x60005CB")]
		[Address(RVA = "0x1600820", Offset = "0x1600820", Length = "0xAC")]
		private int GetAttributeParameters(char[] chars, int startIndex, int length, ref float[] parameters)
		{
			return 0;
		}

		[Token(Token = "0x60005CC")]
		[Address(RVA = "0x1600A4C", Offset = "0x1600A4C", Length = "0x18")]
		protected float ConvertToFloat(char[] chars, int startIndex, int length)
		{
			return 0f;
		}

		[Token(Token = "0x60005CD")]
		[Address(RVA = "0x16008CC", Offset = "0x16008CC", Length = "0x180")]
		protected float ConvertToFloat(char[] chars, int startIndex, int length, out int lastIndex)
		{
			lastIndex = default(int);
			return 0f;
		}

		[Token(Token = "0x60005CE")]
		[Address(RVA = "0x15F4648", Offset = "0x15F4648", Length = "0x5AEC")]
		internal bool ValidateHtmlTag(UnicodeChar[] chars, int startIndex, out int endIndex)
		{
			endIndex = default(int);
			return false;
		}

		[Token(Token = "0x60005CF")]
		[Address(RVA = "0x1600A64", Offset = "0x1600A64", Length = "0x934")]
		protected internal TMP_Text()
		{
		}
	}
}
