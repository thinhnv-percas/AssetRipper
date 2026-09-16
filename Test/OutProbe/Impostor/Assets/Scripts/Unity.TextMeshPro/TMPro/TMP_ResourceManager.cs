using System.Collections.Generic;
using Cpp2ILInjected;

namespace TMPro
{
	[Token(Token = "0x2000072")]
	public class TMP_ResourceManager
	{
		[Token(Token = "0x4000305")]
		private static readonly TMP_ResourceManager s_instance;

		[Token(Token = "0x4000306")]
		private static TMP_Settings s_TextSettings;

		[Token(Token = "0x4000307")]
		private static readonly List<TMP_FontAsset> s_FontAssetReferences;

		[Token(Token = "0x4000308")]
		private static readonly Dictionary<int, TMP_FontAsset> s_FontAssetReferenceLookup;

		[Token(Token = "0x60003C0")]
		[Address(RVA = "0x1607B48", Offset = "0x1607B48", Length = "0xFC")]
		static TMP_ResourceManager()
		{
		}

		[Token(Token = "0x60003C1")]
		[Address(RVA = "0x1607C4C", Offset = "0x1607C4C", Length = "0x110")]
		internal static TMP_Settings GetTextSettings()
		{
			return null;
		}

		[Token(Token = "0x60003C2")]
		[Address(RVA = "0x1607D5C", Offset = "0x1607D5C", Length = "0x150")]
		public static void AddFontAsset(TMP_FontAsset fontAsset)
		{
		}

		[Token(Token = "0x60003C3")]
		[Address(RVA = "0x1607EAC", Offset = "0x1607EAC", Length = "0x94")]
		public static bool TryGetFontAsset(int hashcode, out TMP_FontAsset fontAsset)
		{
			fontAsset = null;
			return false;
		}

		[Token(Token = "0x60003C4")]
		[Address(RVA = "0x1607F40", Offset = "0x1607F40", Length = "0x118")]
		internal static void RebuildFontAssetCache(int instanceID)
		{
		}

		[Token(Token = "0x60003C5")]
		[Address(RVA = "0x1607C44", Offset = "0x1607C44", Length = "0x8")]
		public TMP_ResourceManager()
		{
		}
	}
}
