using System.Collections.Generic;
using Cpp2ILInjected;

namespace TMPro
{
	[Token(Token = "0x200004D")]
	public class TMP_FontAssetUtilities
	{
		[Token(Token = "0x400022A")]
		private static readonly TMP_FontAssetUtilities s_Instance;

		[Token(Token = "0x400022B")]
		private static HashSet<int> k_SearchedAssets;

		[Token(Token = "0x400022C")]
		private static bool k_IsFontEngineInitialized;

		[Token(Token = "0x1700006A")]
		public static TMP_FontAssetUtilities instance
		{
			[Token(Token = "0x6000261")]
			[Address(RVA = "0x15DF820", Offset = "0x15DF820", Length = "0x58")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x6000260")]
		[Address(RVA = "0x15DF7BC", Offset = "0x15DF7BC", Length = "0x5C")]
		static TMP_FontAssetUtilities()
		{
		}

		[Token(Token = "0x6000262")]
		[Address(RVA = "0x15DF878", Offset = "0x15DF878", Length = "0x154")]
		public static TMP_Character GetCharacterFromFontAsset(uint unicode, TMP_FontAsset sourceFontAsset, bool includeFallbacks, FontStyles fontStyle, FontWeight fontWeight, out bool isAlternativeTypeface)
		{
			isAlternativeTypeface = default(bool);
			return null;
		}

		[Token(Token = "0x6000263")]
		[Address(RVA = "0x15DF9CC", Offset = "0x15DF9CC", Length = "0x3C4")]
		private static TMP_Character GetCharacterFromFontAsset_Internal(uint unicode, TMP_FontAsset sourceFontAsset, bool includeFallbacks, FontStyles fontStyle, FontWeight fontWeight, out bool isAlternativeTypeface)
		{
			isAlternativeTypeface = default(bool);
			return null;
		}

		[Token(Token = "0x6000264")]
		[Address(RVA = "0x15DFD90", Offset = "0x15DFD90", Length = "0x25C")]
		public static TMP_Character GetCharacterFromFontAssets(uint unicode, TMP_FontAsset sourceFontAsset, List<TMP_FontAsset> fontAssets, bool includeFallbacks, FontStyles fontStyle, FontWeight fontWeight, out bool isAlternativeTypeface)
		{
			isAlternativeTypeface = default(bool);
			return null;
		}

		[Token(Token = "0x6000265")]
		[Address(RVA = "0x15DFFEC", Offset = "0x15DFFEC", Length = "0x308")]
		public static TMP_SpriteCharacter GetSpriteCharacterFromSpriteAsset(uint unicode, TMP_SpriteAsset spriteAsset, bool includeFallbacks)
		{
			return null;
		}

		[Token(Token = "0x6000266")]
		[Address(RVA = "0x15E02F4", Offset = "0x15E02F4", Length = "0x1DC")]
		private static TMP_SpriteCharacter GetSpriteCharacterFromSpriteAsset_Internal(uint unicode, TMP_SpriteAsset spriteAsset, bool includeFallbacks)
		{
			return null;
		}

		[Token(Token = "0x6000267")]
		[Address(RVA = "0x15DF818", Offset = "0x15DF818", Length = "0x8")]
		public TMP_FontAssetUtilities()
		{
		}
	}
}
