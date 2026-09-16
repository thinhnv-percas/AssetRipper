using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.TextCore;

namespace TMPro
{
	[ExcludeFromPreset]
	[Token(Token = "0x200007F")]
	public class TMP_SpriteAsset : TMP_Asset
	{
		[Token(Token = "0x4000423")]
		[FieldOffset(Offset = "0x30")]
		internal Dictionary<int, int> m_NameLookup;

		[Token(Token = "0x4000424")]
		[FieldOffset(Offset = "0x38")]
		internal Dictionary<uint, int> m_GlyphIndexLookup;

		[SerializeField]
		[Token(Token = "0x4000425")]
		[FieldOffset(Offset = "0x40")]
		private string m_Version;

		[SerializeField]
		[Token(Token = "0x4000426")]
		[FieldOffset(Offset = "0x48")]
		internal FaceInfo m_FaceInfo;

		[Token(Token = "0x4000427")]
		[FieldOffset(Offset = "0xA8")]
		public Texture spriteSheet;

		[SerializeField]
		[Token(Token = "0x4000428")]
		[FieldOffset(Offset = "0xB0")]
		private List<TMP_SpriteCharacter> m_SpriteCharacterTable;

		[Token(Token = "0x4000429")]
		[FieldOffset(Offset = "0xB8")]
		internal Dictionary<uint, TMP_SpriteCharacter> m_SpriteCharacterLookup;

		[SerializeField]
		[Token(Token = "0x400042A")]
		[FieldOffset(Offset = "0xC0")]
		private List<TMP_SpriteGlyph> m_SpriteGlyphTable;

		[Token(Token = "0x400042B")]
		[FieldOffset(Offset = "0xC8")]
		internal Dictionary<uint, TMP_SpriteGlyph> m_SpriteGlyphLookup;

		[Token(Token = "0x400042C")]
		[FieldOffset(Offset = "0xD0")]
		public List<TMP_Sprite> spriteInfoList;

		[SerializeField]
		[Token(Token = "0x400042D")]
		[FieldOffset(Offset = "0xD8")]
		public List<TMP_SpriteAsset> fallbackSpriteAssets;

		[Token(Token = "0x400042E")]
		[FieldOffset(Offset = "0xE0")]
		internal bool m_IsSpriteAssetLookupTablesDirty;

		[Token(Token = "0x400042F")]
		private static HashSet<int> k_searchedSpriteAssets;

		[Token(Token = "0x170000E2")]
		public string version
		{
			[Token(Token = "0x6000413")]
			[Address(RVA = "0x160B2BC", Offset = "0x160B2BC", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000414")]
			[Address(RVA = "0x160B2C4", Offset = "0x160B2C4", Length = "0x8")]
			internal set
			{
			}
		}

		[Token(Token = "0x170000E3")]
		public FaceInfo faceInfo
		{
			[Token(Token = "0x6000415")]
			[Address(RVA = "0x160B2CC", Offset = "0x160B2CC", Length = "0x10")]
			get
			{
				return default(FaceInfo);
			}
			[Token(Token = "0x6000416")]
			[Address(RVA = "0x160B2DC", Offset = "0x160B2DC", Length = "0x18")]
			internal set
			{
			}
		}

		[Token(Token = "0x170000E4")]
		public List<TMP_SpriteCharacter> spriteCharacterTable
		{
			[Token(Token = "0x6000417")]
			[Address(RVA = "0x160B250", Offset = "0x160B250", Length = "0x24")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000418")]
			[Address(RVA = "0x160B7F0", Offset = "0x160B7F0", Length = "0x8")]
			internal set
			{
			}
		}

		[Token(Token = "0x170000E5")]
		public Dictionary<uint, TMP_SpriteCharacter> spriteCharacterLookupTable
		{
			[Token(Token = "0x6000419")]
			[Address(RVA = "0x160B7F8", Offset = "0x160B7F8", Length = "0x24")]
			get
			{
				return null;
			}
			[Token(Token = "0x600041A")]
			[Address(RVA = "0x160B81C", Offset = "0x160B81C", Length = "0x8")]
			internal set
			{
			}
		}

		[Token(Token = "0x170000E6")]
		public List<TMP_SpriteGlyph> spriteGlyphTable
		{
			[Token(Token = "0x600041B")]
			[Address(RVA = "0x160B824", Offset = "0x160B824", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x600041C")]
			[Address(RVA = "0x160B82C", Offset = "0x160B82C", Length = "0x8")]
			internal set
			{
			}
		}

		[Token(Token = "0x600041D")]
		[Address(RVA = "0x160B834", Offset = "0x160B834", Length = "0x88")]
		private void Awake()
		{
		}

		[Token(Token = "0x600041E")]
		[Address(RVA = "0x160BD4C", Offset = "0x160BD4C", Length = "0xE8")]
		private Material GetDefaultSpriteMaterial()
		{
			return null;
		}

		[Token(Token = "0x600041F")]
		[Address(RVA = "0x160B2F4", Offset = "0x160B2F4", Length = "0x4FC")]
		public void UpdateLookupTables()
		{
		}

		[Token(Token = "0x6000420")]
		[Address(RVA = "0x160BE34", Offset = "0x160BE34", Length = "0x88")]
		public int GetSpriteIndexFromHashcode(int hashCode)
		{
			return 0;
		}

		[Token(Token = "0x6000421")]
		[Address(RVA = "0x160BEBC", Offset = "0x160BEBC", Length = "0x94")]
		public int GetSpriteIndexFromUnicode(uint unicode)
		{
			return 0;
		}

		[Token(Token = "0x6000422")]
		[Address(RVA = "0x160BF50", Offset = "0x160BF50", Length = "0x74")]
		public int GetSpriteIndexFromName(string name)
		{
			return 0;
		}

		[Token(Token = "0x6000423")]
		[Address(RVA = "0x160C030", Offset = "0x160C030", Length = "0x224")]
		public static TMP_SpriteAsset SearchForSpriteByUnicode(TMP_SpriteAsset spriteAsset, uint unicode, bool includeFallbacks, out int spriteIndex)
		{
			spriteIndex = default(int);
			return null;
		}

		[Token(Token = "0x6000424")]
		[Address(RVA = "0x160C254", Offset = "0x160C254", Length = "0x1A0")]
		private static TMP_SpriteAsset SearchForSpriteByUnicodeInternal(List<TMP_SpriteAsset> spriteAssets, uint unicode, bool includeFallbacks, out int spriteIndex)
		{
			spriteIndex = default(int);
			return null;
		}

		[Token(Token = "0x6000425")]
		[Address(RVA = "0x160C3F4", Offset = "0x160C3F4", Length = "0xB0")]
		private static TMP_SpriteAsset SearchForSpriteByUnicodeInternal(TMP_SpriteAsset spriteAsset, uint unicode, bool includeFallbacks, out int spriteIndex)
		{
			spriteIndex = default(int);
			return null;
		}

		[Token(Token = "0x6000426")]
		[Address(RVA = "0x160C4A4", Offset = "0x160C4A4", Length = "0x31C")]
		public static TMP_SpriteAsset SearchForSpriteByHashCode(TMP_SpriteAsset spriteAsset, int hashCode, bool includeFallbacks, out int spriteIndex)
		{
			spriteIndex = default(int);
			return null;
		}

		[Token(Token = "0x6000427")]
		[Address(RVA = "0x160C7C0", Offset = "0x160C7C0", Length = "0x1A0")]
		private static TMP_SpriteAsset SearchForSpriteByHashCodeInternal(List<TMP_SpriteAsset> spriteAssets, int hashCode, bool searchFallbacks, out int spriteIndex)
		{
			spriteIndex = default(int);
			return null;
		}

		[Token(Token = "0x6000428")]
		[Address(RVA = "0x160C960", Offset = "0x160C960", Length = "0xB0")]
		private static TMP_SpriteAsset SearchForSpriteByHashCodeInternal(TMP_SpriteAsset spriteAsset, int hashCode, bool searchFallbacks, out int spriteIndex)
		{
			spriteIndex = default(int);
			return null;
		}

		[Token(Token = "0x6000429")]
		[Address(RVA = "0x160CA10", Offset = "0x160CA10", Length = "0x130")]
		public void SortGlyphTable()
		{
		}

		[Token(Token = "0x600042A")]
		[Address(RVA = "0x160CB40", Offset = "0x160CB40", Length = "0x134")]
		internal void SortCharacterTable()
		{
		}

		[Token(Token = "0x600042B")]
		[Address(RVA = "0x160CC74", Offset = "0x160CC74", Length = "0x18")]
		internal void SortGlyphAndCharacterTables()
		{
		}

		[Token(Token = "0x600042C")]
		[Address(RVA = "0x160B8BC", Offset = "0x160B8BC", Length = "0x490")]
		private void UpgradeSpriteAsset()
		{
		}

		[Token(Token = "0x600042D")]
		[Address(RVA = "0x160CD2C", Offset = "0x160CD2C", Length = "0xC4")]
		public TMP_SpriteAsset()
		{
		}
	}
}
