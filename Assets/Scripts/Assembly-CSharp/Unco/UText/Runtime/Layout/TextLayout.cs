using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unco.UText.Runtime.Rendering;
using UnityEngine;
using UnityEngine.Pool;

namespace Unco.UText.Runtime.Layout
{
	[Token(Token = "0x20007BF")]
	public static class TextLayout
	{
		[Token(Token = "0x20007C0")]
		public struct PlacedGlyph
		{
			[Token(Token = "0x40019D9")]
			[FieldOffset(Offset = "0x0")]
			public SdfGlyph Glyph;

			[Token(Token = "0x40019DA")]
			[FieldOffset(Offset = "0x28")]
			public Vector2 PenEm;
		}

		[Token(Token = "0x600208D")]
		[Address(RVA = "0x3DA1934", Offset = "0x3DA1934", Length = "0xC34")]
		public unsafe static void Layout(string text, UTextSdfFontAsset atlas, LayoutSettings settings, List<PlacedGlyph> output, out Vector2 minEm, out Vector2 maxEm, float wrapWidthEm = 0f)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TextLayout::Layout");
			minEm = default;
			maxEm = default;
		}

		[Token(Token = "0x600208E")]
		[Address(RVA = "0x3D9AC28", Offset = "0x3D9AC28", Length = "0x1700")]
		public unsafe static void LayoutElements(IReadOnlyList<Element> elements, IReadOnlyList<RunStyle> runStyles, UTextSdfFontAsset atlas, LayoutSettings settings, List<PlacedElement> output, out Vector2 minEm, out Vector2 maxEm, float wrapWidthEm = 0f, IReadOnlyList<UTextSpriteAsset> resolvedSpriteAtlases = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TextLayout::LayoutElements");
			minEm = default;
			maxEm = default;
		}
	}
}
