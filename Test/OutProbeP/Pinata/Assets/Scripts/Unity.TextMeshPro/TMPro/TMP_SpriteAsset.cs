using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Token(Token = "0x200003F")]
	public class TMP_SpriteAsset : TMP_Asset
	{
		[Token(Token = "0x4000264")]
		[FieldOffset(Offset = "0x30")]
		internal Dictionary<uint, int> m_UnicodeLookup;

		[Token(Token = "0x4000265")]
		[FieldOffset(Offset = "0x38")]
		internal Dictionary<int, int> m_NameLookup;

		[Token(Token = "0x4000266")]
		[FieldOffset(Offset = "0x40")]
		internal Dictionary<uint, int> m_GlyphIndexLookup;

		[SerializeField]
		[Token(Token = "0x4000267")]
		[FieldOffset(Offset = "0x48")]
		private string m_Version;

		[Token(Token = "0x4000268")]
		[FieldOffset(Offset = "0x50")]
		public Texture spriteSheet;

		[SerializeField]
		[Token(Token = "0x4000269")]
		[FieldOffset(Offset = "0x58")]
		private List<TMP_SpriteCharacter> m_SpriteCharacterTable;

		[SerializeField]
		[Token(Token = "0x400026A")]
		[FieldOffset(Offset = "0x60")]
		private List<TMP_SpriteGlyph> m_SpriteGlyphTable;

		[Token(Token = "0x400026B")]
		[FieldOffset(Offset = "0x68")]
		public List<TMP_Sprite> spriteInfoList;

		[SerializeField]
		[Token(Token = "0x400026C")]
		[FieldOffset(Offset = "0x70")]
		public List<TMP_SpriteAsset> fallbackSpriteAssets;

		[Token(Token = "0x400026D")]
		[FieldOffset(Offset = "0x78")]
		internal bool m_IsSpriteAssetLookupTablesDirty;

		[Token(Token = "0x400026E")]
		private static List<int> k_searchedSpriteAssets;

		[Token(Token = "0x170000BA")]
		public string version
		{
			[Token(Token = "0x600032E")]
			[Address(RVA = "0x93C650", Offset = "0x93C650", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x600032F")]
			[Address(RVA = "0x93C658", Offset = "0x93C658", Length = "0x8")]
			internal set
			{
			}
		}

		[Token(Token = "0x170000BB")]
		public List<TMP_SpriteCharacter> spriteCharacterTable
		{
			[Token(Token = "0x6000330")]
			[Address(RVA = "0x93C5AC", Offset = "0x93C5AC", Length = "0x30")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000331")]
			[Address(RVA = "0x93CA28", Offset = "0x93CA28", Length = "0x8")]
			internal set
			{
			}
		}

		[Token(Token = "0x170000BC")]
		public List<TMP_SpriteGlyph> spriteGlyphTable
		{
			[Token(Token = "0x6000332")]
			[Address(RVA = "0x93CA30", Offset = "0x93CA30", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000333")]
			[Address(RVA = "0x93CA38", Offset = "0x93CA38", Length = "0x8")]
			internal set
			{
			}
		}

		[Token(Token = "0x6000334")]
		[Address(RVA = "0x93CA40", Offset = "0x93CA40", Length = "0x98")]
		private void Awake()
		{
		}

		[Token(Token = "0x6000335")]
		[Address(RVA = "0x93CE9C", Offset = "0x93CE9C", Length = "0xE8")]
		private Material GetDefaultSpriteMaterial()
		{
			return null;
		}

		[Token(Token = "0x6000336")]
		[Address(RVA = "0x93C660", Offset = "0x93C660", Length = "0x3C8")]
		public void UpdateLookupTables()
		{
		}

		[Token(Token = "0x6000337")]
		[Address(RVA = "0x93CF84", Offset = "0x93CF84", Length = "0x90")]
		public int GetSpriteIndexFromHashcode(int hashCode)
		{
			return 0;
		}

		[Token(Token = "0x6000338")]
		[Address(RVA = "0x93D014", Offset = "0x93D014", Length = "0x90")]
		public int GetSpriteIndexFromUnicode(uint unicode)
		{
			return 0;
		}

		[Token(Token = "0x6000339")]
		[Address(RVA = "0x93D0A4", Offset = "0x93D0A4", Length = "0x90")]
		public int GetSpriteIndexFromName(string name)
		{
			return 0;
		}

		[Token(Token = "0x600033A")]
		[Address(RVA = "0x93D134", Offset = "0x93D134", Length = "0x208")]
		public static TMP_SpriteAsset SearchForSpriteByUnicode(TMP_SpriteAsset spriteAsset, uint unicode, bool includeFallbacks, out int spriteIndex)
		{
			spriteIndex = default(int);
			return null;
		}

		[Token(Token = "0x600033B")]
		[Address(RVA = "0x93D33C", Offset = "0x93D33C", Length = "0x1B0")]
		private static TMP_SpriteAsset SearchForSpriteByUnicodeInternal(List<TMP_SpriteAsset> spriteAssets, uint unicode, bool includeFallbacks, out int spriteIndex)
		{
			spriteIndex = default(int);
			return null;
		}

		[Token(Token = "0x600033C")]
		[Address(RVA = "0x93D4EC", Offset = "0x93D4EC", Length = "0xC8")]
		private static TMP_SpriteAsset SearchForSpriteByUnicodeInternal(TMP_SpriteAsset spriteAsset, uint unicode, bool includeFallbacks, out int spriteIndex)
		{
			spriteIndex = default(int);
			return null;
		}

		[Token(Token = "0x600033D")]
		[Address(RVA = "0x93D5B4", Offset = "0x93D5B4", Length = "0x208")]
		public static TMP_SpriteAsset SearchForSpriteByHashCode(TMP_SpriteAsset spriteAsset, int hashCode, bool includeFallbacks, out int spriteIndex)
		{
			spriteIndex = default(int);
			return null;
		}

		[Token(Token = "0x600033E")]
		[Address(RVA = "0x93D7BC", Offset = "0x93D7BC", Length = "0x1B0")]
		private static TMP_SpriteAsset SearchForSpriteByHashCodeInternal(List<TMP_SpriteAsset> spriteAssets, int hashCode, bool searchFallbacks, out int spriteIndex)
		{
			spriteIndex = default(int);
			return null;
		}

		[Token(Token = "0x600033F")]
		[Address(RVA = "0x93D96C", Offset = "0x93D96C", Length = "0xC8")]
		private static TMP_SpriteAsset SearchForSpriteByHashCodeInternal(TMP_SpriteAsset spriteAsset, int hashCode, bool searchFallbacks, out int spriteIndex)
		{
			spriteIndex = default(int);
			return null;
		}

		[Token(Token = "0x6000340")]
		[Address(RVA = "0x93DA34", Offset = "0x93DA34", Length = "0x11C")]
		public void SortGlyphTable()
		{
		}

		[Token(Token = "0x6000341")]
		[Address(RVA = "0x93DB50", Offset = "0x93DB50", Length = "0x120")]
		internal void SortCharacterTable()
		{
		}

		[Token(Token = "0x6000342")]
		[Address(RVA = "0x93DC70", Offset = "0x93DC70", Length = "0x24")]
		internal void SortGlyphAndCharacterTables()
		{
		}

		[Token(Token = "0x6000343")]
		[Address(RVA = "0x93CAD8", Offset = "0x93CAD8", Length = "0x3C4")]
		private void UpgradeSpriteAsset()
		{
		}

		[Token(Token = "0x6000344")]
		[Address(RVA = "0x93DD94", Offset = "0x93DD94", Length = "0x98")]
		public TMP_SpriteAsset()
		{
		}
	}
}
