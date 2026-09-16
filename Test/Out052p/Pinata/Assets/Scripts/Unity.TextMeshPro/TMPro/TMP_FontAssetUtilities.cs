using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine.TextCore;

namespace TMPro
{
	[Token(Token = "0x2000023")]
	public class TMP_FontAssetUtilities
	{
		[Token(Token = "0x4000110")]
		private static readonly TMP_FontAssetUtilities s_Instance;

		[Token(Token = "0x4000111")]
		private static List<int> k_SearchedFontAssets;

		[Token(Token = "0x4000112")]
		private static bool k_IsFontEngineInitialized;

		[Token(Token = "0x1700004D")]
		public static TMP_FontAssetUtilities instance
		{
			[Token(Token = "0x60001AC")]
			[Address(RVA = "0x9269C8", Offset = "0x9269C8", Length = "0x68")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x60001AB")]
		[Address(RVA = "0x92695C", Offset = "0x92695C", Length = "0x64")]
		static TMP_FontAssetUtilities()
		{
		}

		[Token(Token = "0x60001AD")]
		[Address(RVA = "0x926A30", Offset = "0x926A30", Length = "0x174")]
		public static TMP_Character GetCharacterFromFontAsset(uint unicode, TMP_FontAsset sourceFontAsset, bool includeFallbacks, FontStyles fontStyle, FontWeight fontWeight, out bool isAlternativeTypeface, out TMP_FontAsset fontAsset)
		{
			isAlternativeTypeface = default(bool);
			fontAsset = null;
			return null;
		}

		[Token(Token = "0x60001AE")]
		[Address(RVA = "0x926BA4", Offset = "0x926BA4", Length = "0x414")]
		private static TMP_Character GetCharacterFromFontAsset_Internal(uint unicode, TMP_FontAsset sourceFontAsset, bool includeFallbacks, FontStyles fontStyle, FontWeight fontWeight, out bool isAlternativeTypeface, out TMP_FontAsset fontAsset)
		{
			isAlternativeTypeface = default(bool);
			fontAsset = null;
			return null;
		}

		[Token(Token = "0x60001AF")]
		[Address(RVA = "0x926FB8", Offset = "0x926FB8", Length = "0x22C")]
		public static TMP_Character GetCharacterFromFontAssets(uint unicode, List<TMP_FontAsset> fontAssets, bool includeFallbacks, FontStyles fontStyle, FontWeight fontWeight, out bool isAlternativeTypeface, out TMP_FontAsset fontAsset)
		{
			isAlternativeTypeface = default(bool);
			fontAsset = null;
			return null;
		}

		[Token(Token = "0x60001B0")]
		[Address(RVA = "0x9271E4", Offset = "0x9271E4", Length = "0x20C")]
		private static bool TryGetCharacterFromFontFile(uint unicode, TMP_FontAsset fontAsset, out TMP_Character character)
		{
			character = null;
			return false;
		}

		[Token(Token = "0x60001B1")]
		[Address(RVA = "0x9273F0", Offset = "0x9273F0", Length = "0x19C")]
		public static bool TryGetGlyphFromFontFile(uint glyphIndex, TMP_FontAsset fontAsset, out Glyph glyph)
		{
			glyph = null;
			return false;
		}

		[Token(Token = "0x60001B2")]
		[Address(RVA = "0x9269C0", Offset = "0x9269C0", Length = "0x8")]
		public TMP_FontAssetUtilities()
		{
		}
	}
}
