using System.Diagnostics;
using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[DebuggerDisplay("Unicode '{character}'  ({((uint)character).ToString(\"X\")})")]
	[Token(Token = "0x2000027")]
	public struct TMP_CharacterInfo
	{
		[Token(Token = "0x4000123")]
		[FieldOffset(Offset = "0x0")]
		public char character;

		[Token(Token = "0x4000124")]
		[FieldOffset(Offset = "0x4")]
		public int index;

		[Token(Token = "0x4000125")]
		[FieldOffset(Offset = "0x8")]
		public int stringLength;

		[Token(Token = "0x4000126")]
		[FieldOffset(Offset = "0xC")]
		public TMP_TextElementType elementType;

		[Token(Token = "0x4000127")]
		[FieldOffset(Offset = "0x10")]
		public TMP_TextElement textElement;

		[Token(Token = "0x4000128")]
		[FieldOffset(Offset = "0x18")]
		public TMP_FontAsset fontAsset;

		[Token(Token = "0x4000129")]
		[FieldOffset(Offset = "0x20")]
		public TMP_SpriteAsset spriteAsset;

		[Token(Token = "0x400012A")]
		[FieldOffset(Offset = "0x28")]
		public int spriteIndex;

		[Token(Token = "0x400012B")]
		[FieldOffset(Offset = "0x30")]
		public Material material;

		[Token(Token = "0x400012C")]
		[FieldOffset(Offset = "0x38")]
		public int materialReferenceIndex;

		[Token(Token = "0x400012D")]
		[FieldOffset(Offset = "0x3C")]
		public bool isUsingAlternateTypeface;

		[Token(Token = "0x400012E")]
		[FieldOffset(Offset = "0x40")]
		public float pointSize;

		[Token(Token = "0x400012F")]
		[FieldOffset(Offset = "0x44")]
		public int lineNumber;

		[Token(Token = "0x4000130")]
		[FieldOffset(Offset = "0x48")]
		public int pageNumber;

		[Token(Token = "0x4000131")]
		[FieldOffset(Offset = "0x4C")]
		public int vertexIndex;

		[Token(Token = "0x4000132")]
		[FieldOffset(Offset = "0x50")]
		public TMP_Vertex vertex_BL;

		[Token(Token = "0x4000133")]
		[FieldOffset(Offset = "0x78")]
		public TMP_Vertex vertex_TL;

		[Token(Token = "0x4000134")]
		[FieldOffset(Offset = "0xA0")]
		public TMP_Vertex vertex_TR;

		[Token(Token = "0x4000135")]
		[FieldOffset(Offset = "0xC8")]
		public TMP_Vertex vertex_BR;

		[Token(Token = "0x4000136")]
		[FieldOffset(Offset = "0xF0")]
		public Vector3 topLeft;

		[Token(Token = "0x4000137")]
		[FieldOffset(Offset = "0xFC")]
		public Vector3 bottomLeft;

		[Token(Token = "0x4000138")]
		[FieldOffset(Offset = "0x108")]
		public Vector3 topRight;

		[Token(Token = "0x4000139")]
		[FieldOffset(Offset = "0x114")]
		public Vector3 bottomRight;

		[Token(Token = "0x400013A")]
		[FieldOffset(Offset = "0x120")]
		public float origin;

		[Token(Token = "0x400013B")]
		[FieldOffset(Offset = "0x124")]
		public float xAdvance;

		[Token(Token = "0x400013C")]
		[FieldOffset(Offset = "0x128")]
		public float ascender;

		[Token(Token = "0x400013D")]
		[FieldOffset(Offset = "0x12C")]
		public float baseLine;

		[Token(Token = "0x400013E")]
		[FieldOffset(Offset = "0x130")]
		public float descender;

		[Token(Token = "0x400013F")]
		[FieldOffset(Offset = "0x134")]
		internal float adjustedAscender;

		[Token(Token = "0x4000140")]
		[FieldOffset(Offset = "0x138")]
		internal float adjustedDescender;

		[Token(Token = "0x4000141")]
		[FieldOffset(Offset = "0x13C")]
		public float aspectRatio;

		[Token(Token = "0x4000142")]
		[FieldOffset(Offset = "0x140")]
		public float scale;

		[Token(Token = "0x4000143")]
		[FieldOffset(Offset = "0x144")]
		public Color32 color;

		[Token(Token = "0x4000144")]
		[FieldOffset(Offset = "0x148")]
		public Color32 underlineColor;

		[Token(Token = "0x4000145")]
		[FieldOffset(Offset = "0x14C")]
		public int underlineVertexIndex;

		[Token(Token = "0x4000146")]
		[FieldOffset(Offset = "0x150")]
		public Color32 strikethroughColor;

		[Token(Token = "0x4000147")]
		[FieldOffset(Offset = "0x154")]
		public int strikethroughVertexIndex;

		[Token(Token = "0x4000148")]
		[FieldOffset(Offset = "0x158")]
		public Color32 highlightColor;

		[Token(Token = "0x4000149")]
		[FieldOffset(Offset = "0x15C")]
		public HighlightState highlightState;

		[Token(Token = "0x400014A")]
		[FieldOffset(Offset = "0x170")]
		public FontStyles style;

		[Token(Token = "0x400014B")]
		[FieldOffset(Offset = "0x174")]
		public bool isVisible;
	}
}
