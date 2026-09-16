using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Token(Token = "0x200006A")]
	public struct WordWrapState
	{
		[Token(Token = "0x4000440")]
		[FieldOffset(Offset = "0x0")]
		public int previous_WordBreak;

		[Token(Token = "0x4000441")]
		[FieldOffset(Offset = "0x4")]
		public int total_CharacterCount;

		[Token(Token = "0x4000442")]
		[FieldOffset(Offset = "0x8")]
		public int visible_CharacterCount;

		[Token(Token = "0x4000443")]
		[FieldOffset(Offset = "0xC")]
		public int visible_SpriteCount;

		[Token(Token = "0x4000444")]
		[FieldOffset(Offset = "0x10")]
		public int visible_LinkCount;

		[Token(Token = "0x4000445")]
		[FieldOffset(Offset = "0x14")]
		public int firstCharacterIndex;

		[Token(Token = "0x4000446")]
		[FieldOffset(Offset = "0x18")]
		public int firstVisibleCharacterIndex;

		[Token(Token = "0x4000447")]
		[FieldOffset(Offset = "0x1C")]
		public int lastCharacterIndex;

		[Token(Token = "0x4000448")]
		[FieldOffset(Offset = "0x20")]
		public int lastVisibleCharIndex;

		[Token(Token = "0x4000449")]
		[FieldOffset(Offset = "0x24")]
		public int lineNumber;

		[Token(Token = "0x400044A")]
		[FieldOffset(Offset = "0x28")]
		public float maxCapHeight;

		[Token(Token = "0x400044B")]
		[FieldOffset(Offset = "0x2C")]
		public float maxAscender;

		[Token(Token = "0x400044C")]
		[FieldOffset(Offset = "0x30")]
		public float maxDescender;

		[Token(Token = "0x400044D")]
		[FieldOffset(Offset = "0x34")]
		public float maxLineAscender;

		[Token(Token = "0x400044E")]
		[FieldOffset(Offset = "0x38")]
		public float maxLineDescender;

		[Token(Token = "0x400044F")]
		[FieldOffset(Offset = "0x3C")]
		public float previousLineAscender;

		[Token(Token = "0x4000450")]
		[FieldOffset(Offset = "0x40")]
		public float xAdvance;

		[Token(Token = "0x4000451")]
		[FieldOffset(Offset = "0x44")]
		public float preferredWidth;

		[Token(Token = "0x4000452")]
		[FieldOffset(Offset = "0x48")]
		public float preferredHeight;

		[Token(Token = "0x4000453")]
		[FieldOffset(Offset = "0x4C")]
		public float previousLineScale;

		[Token(Token = "0x4000454")]
		[FieldOffset(Offset = "0x50")]
		public int wordCount;

		[Token(Token = "0x4000455")]
		[FieldOffset(Offset = "0x54")]
		public FontStyles fontStyle;

		[Token(Token = "0x4000456")]
		[FieldOffset(Offset = "0x58")]
		public float fontScale;

		[Token(Token = "0x4000457")]
		[FieldOffset(Offset = "0x5C")]
		public float fontScaleMultiplier;

		[Token(Token = "0x4000458")]
		[FieldOffset(Offset = "0x60")]
		public float currentFontSize;

		[Token(Token = "0x4000459")]
		[FieldOffset(Offset = "0x64")]
		public float baselineOffset;

		[Token(Token = "0x400045A")]
		[FieldOffset(Offset = "0x68")]
		public float lineOffset;

		[Token(Token = "0x400045B")]
		[FieldOffset(Offset = "0x70")]
		public TMP_TextInfo textInfo;

		[Token(Token = "0x400045C")]
		[FieldOffset(Offset = "0x78")]
		public TMP_LineInfo lineInfo;

		[Token(Token = "0x400045D")]
		[FieldOffset(Offset = "0xD4")]
		public Color32 vertexColor;

		[Token(Token = "0x400045E")]
		[FieldOffset(Offset = "0xD8")]
		public Color32 underlineColor;

		[Token(Token = "0x400045F")]
		[FieldOffset(Offset = "0xDC")]
		public Color32 strikethroughColor;

		[Token(Token = "0x4000460")]
		[FieldOffset(Offset = "0xE0")]
		public Color32 highlightColor;

		[Token(Token = "0x4000461")]
		[FieldOffset(Offset = "0xE4")]
		public TMP_FontStyleStack basicStyleStack;

		[Token(Token = "0x4000462")]
		[FieldOffset(Offset = "0xF0")]
		public TMP_RichTextTagStack<Color32> colorStack;

		[Token(Token = "0x4000463")]
		[FieldOffset(Offset = "0x108")]
		public TMP_RichTextTagStack<Color32> underlineColorStack;

		[Token(Token = "0x4000464")]
		[FieldOffset(Offset = "0x120")]
		public TMP_RichTextTagStack<Color32> strikethroughColorStack;

		[Token(Token = "0x4000465")]
		[FieldOffset(Offset = "0x138")]
		public TMP_RichTextTagStack<Color32> highlightColorStack;

		[Token(Token = "0x4000466")]
		[FieldOffset(Offset = "0x150")]
		public TMP_RichTextTagStack<TMP_ColorGradient> colorGradientStack;

		[Token(Token = "0x4000467")]
		[FieldOffset(Offset = "0x168")]
		public TMP_RichTextTagStack<float> sizeStack;

		[Token(Token = "0x4000468")]
		[FieldOffset(Offset = "0x180")]
		public TMP_RichTextTagStack<float> indentStack;

		[Token(Token = "0x4000469")]
		[FieldOffset(Offset = "0x198")]
		public TMP_RichTextTagStack<FontWeight> fontWeightStack;

		[Token(Token = "0x400046A")]
		[FieldOffset(Offset = "0x1B0")]
		public TMP_RichTextTagStack<int> styleStack;

		[Token(Token = "0x400046B")]
		[FieldOffset(Offset = "0x1C8")]
		public TMP_RichTextTagStack<float> baselineStack;

		[Token(Token = "0x400046C")]
		[FieldOffset(Offset = "0x1E0")]
		public TMP_RichTextTagStack<int> actionStack;

		[Token(Token = "0x400046D")]
		[FieldOffset(Offset = "0x1F8")]
		public TMP_RichTextTagStack<MaterialReference> materialReferenceStack;

		[Token(Token = "0x400046E")]
		[FieldOffset(Offset = "0x240")]
		public TMP_RichTextTagStack<TextAlignmentOptions> lineJustificationStack;

		[Token(Token = "0x400046F")]
		[FieldOffset(Offset = "0x258")]
		public int spriteAnimationID;

		[Token(Token = "0x4000470")]
		[FieldOffset(Offset = "0x260")]
		public TMP_FontAsset currentFontAsset;

		[Token(Token = "0x4000471")]
		[FieldOffset(Offset = "0x268")]
		public TMP_SpriteAsset currentSpriteAsset;

		[Token(Token = "0x4000472")]
		[FieldOffset(Offset = "0x270")]
		public Material currentMaterial;

		[Token(Token = "0x4000473")]
		[FieldOffset(Offset = "0x278")]
		public int currentMaterialIndex;

		[Token(Token = "0x4000474")]
		[FieldOffset(Offset = "0x27C")]
		public Extents meshExtents;

		[Token(Token = "0x4000475")]
		[FieldOffset(Offset = "0x28C")]
		public bool tagNoParsing;

		[Token(Token = "0x4000476")]
		[FieldOffset(Offset = "0x28D")]
		public bool isNonBreakingSpace;
	}
}
