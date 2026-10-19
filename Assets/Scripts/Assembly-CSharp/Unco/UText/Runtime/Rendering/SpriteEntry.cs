using System;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.UText.Runtime.Rendering
{
	[Serializable]
	[Token(Token = "0x20007B2")]
	public struct SpriteEntry
	{
		[Tooltip("Lookup name for <sprite=Name>. Optional — index-only entries can leave this empty.")]
		[Token(Token = "0x40019A4")]
		[FieldOffset(Offset = "0x0")]
		public string Name;

		[Tooltip("UV rectangle in the atlas (0..1).")]
		[Token(Token = "0x40019A5")]
		[FieldOffset(Offset = "0x8")]
		public Rect UvRect;

		[Tooltip("Quad size in em.")]
		[Token(Token = "0x40019A6")]
		[FieldOffset(Offset = "0x18")]
		public Vector2 SizeEm;

		[Tooltip("Horizontal pen advance applied BEFORE the sprite quad, in em. Lets the entry reserve space on its left without baking the gap into the texture.")]
		[Token(Token = "0x40019A7")]
		[FieldOffset(Offset = "0x20")]
		public float LeadingAdvanceEm;

		[Tooltip("Horizontal pen advance after this sprite, in em.")]
		[Token(Token = "0x40019A8")]
		[FieldOffset(Offset = "0x24")]
		public float AdvanceEm;

		[Tooltip("Shift of the quad's bottom edge above the baseline, in em. 0 = quad sits on the baseline; positive values raise the sprite.")]
		[Token(Token = "0x40019A9")]
		[FieldOffset(Offset = "0x28")]
		public float BaselineOffsetEm;
	}
}
