using System;
using Cpp2ILInjected;
using UnityEngine.TextCore.LowLevel;

namespace TMPro
{
	[Serializable]
	[Token(Token = "0x2000045")]
	public struct GlyphValueRecord_Legacy
	{
		[Token(Token = "0x4000214")]
		[FieldOffset(Offset = "0x0")]
		public float xPlacement;

		[Token(Token = "0x4000215")]
		[FieldOffset(Offset = "0x4")]
		public float yPlacement;

		[Token(Token = "0x4000216")]
		[FieldOffset(Offset = "0x8")]
		public float xAdvance;

		[Token(Token = "0x4000217")]
		[FieldOffset(Offset = "0xC")]
		public float yAdvance;

		[Token(Token = "0x600023D")]
		[Address(RVA = "0x15DE71C", Offset = "0x15DE71C", Length = "0x60")]
		internal GlyphValueRecord_Legacy(GlyphValueRecord valueRecord)
		{
			xPlacement = 0f;
			yPlacement = 0f;
			xAdvance = 0f;
			yAdvance = 0f;
		}

		[Token(Token = "0x600023E")]
		[Address(RVA = "0x15DE77C", Offset = "0x15DE77C", Length = "0x14")]
		public static GlyphValueRecord_Legacy operator +(GlyphValueRecord_Legacy a, GlyphValueRecord_Legacy b)
		{
			return default(GlyphValueRecord_Legacy);
		}
	}
}
