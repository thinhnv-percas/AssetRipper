using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Token(Token = "0x200001F")]
	public struct WordWrapState
	{
		[Token(Token = "0x40000C8")]
		[FieldOffset(Offset = "0x0")]
		public int previous_WordBreak;

		[Token(Token = "0x40000C9")]
		[FieldOffset(Offset = "0x4")]
		public int total_CharacterCount;

		[Token(Token = "0x40000CA")]
		[FieldOffset(Offset = "0x8")]
		public int visible_CharacterCount;

		[Token(Token = "0x40000CB")]
		[FieldOffset(Offset = "0xC")]
		public int visible_SpriteCount;

		[Token(Token = "0x40000CC")]
		[FieldOffset(Offset = "0x10")]
		public int visible_LinkCount;

		[Token(Token = "0x40000CD")]
		[FieldOffset(Offset = "0x14")]
		public int firstCharacterIndex;

		[Token(Token = "0x40000CE")]
		[FieldOffset(Offset = "0x18")]
		public int firstVisibleCharacterIndex;

		[Token(Token = "0x40000CF")]
		[FieldOffset(Offset = "0x1C")]
		public int lastCharacterIndex;

		[Token(Token = "0x40000D0")]
		[FieldOffset(Offset = "0x20")]
		public int lastVisibleCharIndex;

		[Token(Token = "0x40000D1")]
		[FieldOffset(Offset = "0x24")]
		public int lineNumber;

		[Token(Token = "0x40000D2")]
		[FieldOffset(Offset = "0x28")]
		public float maxCapHeight;

		[Token(Token = "0x40000D3")]
		[FieldOffset(Offset = "0x2C")]
		public float maxAscender;

		[Token(Token = "0x40000D4")]
		[FieldOffset(Offset = "0x30")]
		public float maxDescender;

		[Token(Token = "0x40000D5")]
		[FieldOffset(Offset = "0x34")]
		public float startOfLineAscender;

		[Token(Token = "0x40000D6")]
		[FieldOffset(Offset = "0x38")]
		public float maxLineAscender;

		[Token(Token = "0x40000D7")]
		[FieldOffset(Offset = "0x3C")]
		public float maxLineDescender;

		[Token(Token = "0x40000D8")]
		[FieldOffset(Offset = "0x40")]
		public float pageAscender;

		[Token(Token = "0x40000D9")]
		[FieldOffset(Offset = "0x44")]
		public HorizontalAlignmentOptions horizontalAlignment;

		[Token(Token = "0x40000DA")]
		[FieldOffset(Offset = "0x48")]
		public float marginLeft;

		[Token(Token = "0x40000DB")]
		[FieldOffset(Offset = "0x4C")]
		public float marginRight;

		[Token(Token = "0x40000DC")]
		[FieldOffset(Offset = "0x50")]
		public float xAdvance;

		[Token(Token = "0x40000DD")]
		[FieldOffset(Offset = "0x54")]
		public float preferredWidth;

		[Token(Token = "0x40000DE")]
		[FieldOffset(Offset = "0x58")]
		public float preferredHeight;

		[Token(Token = "0x40000DF")]
		[FieldOffset(Offset = "0x5C")]
		public float previousLineScale;

		[Token(Token = "0x40000E0")]
		[FieldOffset(Offset = "0x60")]
		public int wordCount;

		[Token(Token = "0x40000E1")]
		[FieldOffset(Offset = "0x64")]
		public FontStyles fontStyle;

		[Token(Token = "0x40000E2")]
		[FieldOffset(Offset = "0x68")]
		public int italicAngle;

		[Token(Token = "0x40000E3")]
		[FieldOffset(Offset = "0x6C")]
		public float fontScaleMultiplier;

		[Token(Token = "0x40000E4")]
		[FieldOffset(Offset = "0x70")]
		public float currentFontSize;

		[Token(Token = "0x40000E5")]
		[FieldOffset(Offset = "0x74")]
		public float baselineOffset;

		[Token(Token = "0x40000E6")]
		[FieldOffset(Offset = "0x78")]
		public float lineOffset;

		[Token(Token = "0x40000E7")]
		[FieldOffset(Offset = "0x7C")]
		public bool isDrivenLineSpacing;

		[Token(Token = "0x40000E8")]
		[FieldOffset(Offset = "0x80")]
		public float glyphHorizontalAdvanceAdjustment;

		[Token(Token = "0x40000E9")]
		[FieldOffset(Offset = "0x84")]
		public float cSpace;

		[Token(Token = "0x40000EA")]
		[FieldOffset(Offset = "0x88")]
		public float mSpace;

		[Token(Token = "0x40000EB")]
		[FieldOffset(Offset = "0x90")]
		public TMP_TextInfo textInfo;

		[Token(Token = "0x40000EC")]
		[FieldOffset(Offset = "0x98")]
		public TMP_LineInfo lineInfo;

		[Token(Token = "0x40000ED")]
		[FieldOffset(Offset = "0xF4")]
		public Color32 vertexColor;

		[Token(Token = "0x40000EE")]
		[FieldOffset(Offset = "0xF8")]
		public Color32 underlineColor;

		[Token(Token = "0x40000EF")]
		[FieldOffset(Offset = "0xFC")]
		public Color32 strikethroughColor;

		[Token(Token = "0x40000F0")]
		[FieldOffset(Offset = "0x100")]
		public Color32 highlightColor;

		[Token(Token = "0x40000F1")]
		[FieldOffset(Offset = "0x104")]
		public TMP_FontStyleStack basicStyleStack;

		[Token(Token = "0x40000F2")]
		[FieldOffset(Offset = "0x110")]
		public TMP_TextProcessingStack<int> italicAngleStack;

		[Token(Token = "0x40000F3")]
		[FieldOffset(Offset = "0x130")]
		public TMP_TextProcessingStack<Color32> colorStack;

		[Token(Token = "0x40000F4")]
		[FieldOffset(Offset = "0x150")]
		public TMP_TextProcessingStack<Color32> underlineColorStack;

		[Token(Token = "0x40000F5")]
		[FieldOffset(Offset = "0x170")]
		public TMP_TextProcessingStack<Color32> strikethroughColorStack;

		[Token(Token = "0x40000F6")]
		[FieldOffset(Offset = "0x190")]
		public TMP_TextProcessingStack<Color32> highlightColorStack;

		[Token(Token = "0x40000F7")]
		[FieldOffset(Offset = "0x1B0")]
		public TMP_TextProcessingStack<HighlightState> highlightStateStack;

		[Token(Token = "0x40000F8")]
		[FieldOffset(Offset = "0x1E0")]
		public TMP_TextProcessingStack<TMP_ColorGradient> colorGradientStack;

		[Token(Token = "0x40000F9")]
		[FieldOffset(Offset = "0x208")]
		public TMP_TextProcessingStack<float> sizeStack;

		[Token(Token = "0x40000FA")]
		[FieldOffset(Offset = "0x228")]
		public TMP_TextProcessingStack<float> indentStack;

		[Token(Token = "0x40000FB")]
		[FieldOffset(Offset = "0x248")]
		public TMP_TextProcessingStack<FontWeight> fontWeightStack;

		[Token(Token = "0x40000FC")]
		[FieldOffset(Offset = "0x268")]
		public TMP_TextProcessingStack<int> styleStack;

		[Token(Token = "0x40000FD")]
		[FieldOffset(Offset = "0x288")]
		public TMP_TextProcessingStack<float> baselineStack;

		[Token(Token = "0x40000FE")]
		[FieldOffset(Offset = "0x2A8")]
		public TMP_TextProcessingStack<int> actionStack;

		[Token(Token = "0x40000FF")]
		[FieldOffset(Offset = "0x2C8")]
		public TMP_TextProcessingStack<MaterialReference> materialReferenceStack;

		[Token(Token = "0x4000100")]
		[FieldOffset(Offset = "0x320")]
		public TMP_TextProcessingStack<HorizontalAlignmentOptions> lineJustificationStack;

		[Token(Token = "0x4000101")]
		[FieldOffset(Offset = "0x340")]
		public int spriteAnimationID;

		[Token(Token = "0x4000102")]
		[FieldOffset(Offset = "0x348")]
		public TMP_FontAsset currentFontAsset;

		[Token(Token = "0x4000103")]
		[FieldOffset(Offset = "0x350")]
		public TMP_SpriteAsset currentSpriteAsset;

		[Token(Token = "0x4000104")]
		[FieldOffset(Offset = "0x358")]
		public Material currentMaterial;

		[Token(Token = "0x4000105")]
		[FieldOffset(Offset = "0x360")]
		public int currentMaterialIndex;

		[Token(Token = "0x4000106")]
		[FieldOffset(Offset = "0x364")]
		public Extents meshExtents;

		[Token(Token = "0x4000107")]
		[FieldOffset(Offset = "0x374")]
		public bool tagNoParsing;

		[Token(Token = "0x4000108")]
		[FieldOffset(Offset = "0x375")]
		public bool isNonBreakingSpace;
	}
}
