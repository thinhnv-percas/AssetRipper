using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Token(Token = "0x200000F")]
	public struct TMP_CharacterInfo
	{
		[Token(Token = "0x4000059")]
		[FieldOffset(Offset = "0x0")]
		public char character;

		[Token(Token = "0x400005A")]
		[FieldOffset(Offset = "0x4")]
		public int index;

		[Token(Token = "0x400005B")]
		[FieldOffset(Offset = "0x8")]
		public int stringLength;

		[Token(Token = "0x400005C")]
		[FieldOffset(Offset = "0xC")]
		public TMP_TextElementType elementType;

		[Token(Token = "0x400005D")]
		[FieldOffset(Offset = "0x10")]
		public TMP_TextElement textElement;

		[Token(Token = "0x400005E")]
		[FieldOffset(Offset = "0x18")]
		public TMP_FontAsset fontAsset;

		[Token(Token = "0x400005F")]
		[FieldOffset(Offset = "0x20")]
		public TMP_SpriteAsset spriteAsset;

		[Token(Token = "0x4000060")]
		[FieldOffset(Offset = "0x28")]
		public int spriteIndex;

		[Token(Token = "0x4000061")]
		[FieldOffset(Offset = "0x30")]
		public Material material;

		[Token(Token = "0x4000062")]
		[FieldOffset(Offset = "0x38")]
		public int materialReferenceIndex;

		[Token(Token = "0x4000063")]
		[FieldOffset(Offset = "0x3C")]
		public bool isUsingAlternateTypeface;

		[Token(Token = "0x4000064")]
		[FieldOffset(Offset = "0x40")]
		public float pointSize;

		[Token(Token = "0x4000065")]
		[FieldOffset(Offset = "0x44")]
		public int lineNumber;

		[Token(Token = "0x4000066")]
		[FieldOffset(Offset = "0x48")]
		public int pageNumber;

		[Token(Token = "0x4000067")]
		[FieldOffset(Offset = "0x4C")]
		public int vertexIndex;

		[Token(Token = "0x4000068")]
		[FieldOffset(Offset = "0x50")]
		public TMP_Vertex vertex_BL;

		[Token(Token = "0x4000069")]
		[FieldOffset(Offset = "0x78")]
		public TMP_Vertex vertex_TL;

		[Token(Token = "0x400006A")]
		[FieldOffset(Offset = "0xA0")]
		public TMP_Vertex vertex_TR;

		[Token(Token = "0x400006B")]
		[FieldOffset(Offset = "0xC8")]
		public TMP_Vertex vertex_BR;

		[Token(Token = "0x400006C")]
		[FieldOffset(Offset = "0xF0")]
		public Vector3 topLeft;

		[Token(Token = "0x400006D")]
		[FieldOffset(Offset = "0xFC")]
		public Vector3 bottomLeft;

		[Token(Token = "0x400006E")]
		[FieldOffset(Offset = "0x108")]
		public Vector3 topRight;

		[Token(Token = "0x400006F")]
		[FieldOffset(Offset = "0x114")]
		public Vector3 bottomRight;

		[Token(Token = "0x4000070")]
		[FieldOffset(Offset = "0x120")]
		public float origin;

		[Token(Token = "0x4000071")]
		[FieldOffset(Offset = "0x124")]
		public float ascender;

		[Token(Token = "0x4000072")]
		[FieldOffset(Offset = "0x128")]
		public float baseLine;

		[Token(Token = "0x4000073")]
		[FieldOffset(Offset = "0x12C")]
		public float descender;

		[Token(Token = "0x4000074")]
		[FieldOffset(Offset = "0x130")]
		public float xAdvance;

		[Token(Token = "0x4000075")]
		[FieldOffset(Offset = "0x134")]
		public float aspectRatio;

		[Token(Token = "0x4000076")]
		[FieldOffset(Offset = "0x138")]
		public float scale;

		[Token(Token = "0x4000077")]
		[FieldOffset(Offset = "0x13C")]
		public Color32 color;

		[Token(Token = "0x4000078")]
		[FieldOffset(Offset = "0x140")]
		public Color32 underlineColor;

		[Token(Token = "0x4000079")]
		[FieldOffset(Offset = "0x144")]
		public Color32 strikethroughColor;

		[Token(Token = "0x400007A")]
		[FieldOffset(Offset = "0x148")]
		public Color32 highlightColor;

		[Token(Token = "0x400007B")]
		[FieldOffset(Offset = "0x14C")]
		public FontStyles style;

		[Token(Token = "0x400007C")]
		[FieldOffset(Offset = "0x150")]
		public bool isVisible;
	}
}
