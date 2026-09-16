using System;
using System.Runtime.InteropServices;
using Cpp2ILInjected;
using UnityEngine.TextCore.LowLevel;

namespace TMPro
{
	[Serializable]
	[StructLayout((LayoutKind)0, Size = 16)]
	[Token(Token = "0x200001F")]
	public struct GlyphValueRecord_Legacy
	{
		[Token(Token = "0x4000103")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public float xPlacement;

		[Token(Token = "0x4000104")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x4")]
		public float yPlacement;

		[Token(Token = "0x4000105")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
		public float xAdvance;

		[Token(Token = "0x4000106")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xC")]
		public float yAdvance;

		[Token(Token = "0x6000192")]
		[Address(RVA = "0x84656C", Offset = "0x84656C", Length = "0x8")]
		internal GlyphValueRecord_Legacy(UnityEngine.TextCore.LowLevel.GlyphValueRecord valueRecord)
		{
			xPlacement = 0f;
			yPlacement = 0f;
			xAdvance = 0f;
			yAdvance = 0f;
		}

		[Token(Token = "0x6000193")]
		[Address(RVA = "0x917CFC", Offset = "0x917CFC", Length = "0x14")]
		public static GlyphValueRecord_Legacy operator +(GlyphValueRecord_Legacy a, GlyphValueRecord_Legacy b)
		{
			return default(GlyphValueRecord_Legacy);
		}
	}
}
