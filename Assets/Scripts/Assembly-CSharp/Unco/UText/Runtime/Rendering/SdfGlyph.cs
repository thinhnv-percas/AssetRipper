using System;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.UText.Runtime.Rendering
{
	[Serializable]
	[Token(Token = "0x20007B0")]
	public struct SdfGlyph
	{
		[Tooltip("Unicode codepoint.")]
		[Token(Token = "0x400199B")]
		[FieldOffset(Offset = "0x0")]
		public uint Codepoint;

		[Tooltip("UV rectangle in atlas (0..1). Includes the SDF padding band.")]
		[Token(Token = "0x400199C")]
		[FieldOffset(Offset = "0x4")]
		public Rect UvRect;

		[Tooltip("Quad size in em, including padding on every side.")]
		[Token(Token = "0x400199D")]
		[FieldOffset(Offset = "0x14")]
		public Vector2 SizeEm;

		[Tooltip("Offset from pen position (left edge of advance, on baseline) to the quad's bottom-left, in em. Already accounts for padding.")]
		[Token(Token = "0x400199E")]
		[FieldOffset(Offset = "0x1C")]
		public Vector2 OffsetEm;

		[Tooltip("Horizontal pen advance after this glyph, in em.")]
		[Token(Token = "0x400199F")]
		[FieldOffset(Offset = "0x24")]
		public float AdvanceEm;
	}
}
