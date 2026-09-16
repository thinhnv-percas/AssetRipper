using System.Collections.Generic;
using Cpp2ILInjected;

namespace TMPro
{
	[Token(Token = "0x200004C")]
	public static class TMP_FontUtilities
	{
		[Token(Token = "0x4000229")]
		private static List<int> k_searchedFontAssets;

		[Token(Token = "0x600025C")]
		[Address(RVA = "0x15DF35C", Offset = "0x15DF35C", Length = "0xE0")]
		public static TMP_FontAsset SearchForCharacter(TMP_FontAsset font, uint unicode, out TMP_Character character)
		{
			character = null;
			return null;
		}

		[Token(Token = "0x600025D")]
		[Address(RVA = "0x15DF6C8", Offset = "0x15DF6C8", Length = "0x4")]
		public static TMP_FontAsset SearchForCharacter(List<TMP_FontAsset> fonts, uint unicode, out TMP_Character character)
		{
			character = null;
			return null;
		}

		[Token(Token = "0x600025E")]
		[Address(RVA = "0x15DF43C", Offset = "0x15DF43C", Length = "0x28C")]
		private static TMP_FontAsset SearchForCharacterInternal(TMP_FontAsset font, uint unicode, out TMP_Character character)
		{
			character = null;
			return null;
		}

		[Token(Token = "0x600025F")]
		[Address(RVA = "0x15DF6CC", Offset = "0x15DF6CC", Length = "0xF0")]
		private static TMP_FontAsset SearchForCharacterInternal(List<TMP_FontAsset> fonts, uint unicode, out TMP_Character character)
		{
			character = null;
			return null;
		}
	}
}
