using System.Collections.Generic;
using Cpp2ILInjected;

namespace TMPro
{
	[Token(Token = "0x2000022")]
	public static class TMP_FontUtilities
	{
		[Token(Token = "0x400010F")]
		private static List<int> k_searchedFontAssets;

		[Token(Token = "0x60001A7")]
		[Address(RVA = "0x9279E8", Offset = "0x9279E8", Length = "0xD0")]
		public static TMP_FontAsset SearchForCharacter(TMP_FontAsset font, uint unicode, out TMP_Character character)
		{
			character = null;
			return null;
		}

		[Token(Token = "0x60001A8")]
		[Address(RVA = "0x927CDC", Offset = "0x927CDC", Length = "0x4")]
		public static TMP_FontAsset SearchForCharacter(List<TMP_FontAsset> fonts, uint unicode, out TMP_Character character)
		{
			character = null;
			return null;
		}

		[Token(Token = "0x60001A9")]
		[Address(RVA = "0x927AB8", Offset = "0x927AB8", Length = "0x224")]
		private static TMP_FontAsset SearchForCharacterInternal(TMP_FontAsset font, uint unicode, out TMP_Character character)
		{
			character = null;
			return null;
		}

		[Token(Token = "0x60001AA")]
		[Address(RVA = "0x927CE0", Offset = "0x927CE0", Length = "0xEC")]
		private static TMP_FontAsset SearchForCharacterInternal(List<TMP_FontAsset> fonts, uint unicode, out TMP_Character character)
		{
			character = null;
			return null;
		}
	}
}
