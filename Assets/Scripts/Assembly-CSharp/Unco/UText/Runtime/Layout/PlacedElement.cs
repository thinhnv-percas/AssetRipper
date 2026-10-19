using Cpp2ILInjected;
using Unco.UText.Runtime.Rendering;
using UnityEngine;

namespace Unco.UText.Runtime.Layout
{
	[Token(Token = "0x20007BA")]
	public struct PlacedElement
	{
		[Token(Token = "0x40019D0")]
		[FieldOffset(Offset = "0x0")]
		public ElementKind Kind;

		[Token(Token = "0x40019D1")]
		[FieldOffset(Offset = "0x4")]
		public SdfGlyph Glyph;

		[Token(Token = "0x40019D2")]
		[FieldOffset(Offset = "0x2C")]
		public int SpriteAtlasIndex;

		[Token(Token = "0x40019D3")]
		[FieldOffset(Offset = "0x30")]
		public int SpriteEntryIndex;

		[Token(Token = "0x40019D4")]
		[FieldOffset(Offset = "0x34")]
		public Vector2 PenEm;

		[Token(Token = "0x40019D5")]
		[FieldOffset(Offset = "0x3C")]
		public float SizeScale;

		[Token(Token = "0x40019D6")]
		[FieldOffset(Offset = "0x40")]
		public int RunStyleIndex;
	}
}
