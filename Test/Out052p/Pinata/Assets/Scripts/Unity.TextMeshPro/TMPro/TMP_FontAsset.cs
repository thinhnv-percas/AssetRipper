using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.TextCore;
using UnityEngine.TextCore.LowLevel;

namespace TMPro
{
	[Serializable]
	[Token(Token = "0x2000019")]
	public class TMP_FontAsset : TMP_Asset
	{
		[SerializeField]
		[Token(Token = "0x40000AE")]
		[FieldOffset(Offset = "0x30")]
		private string m_Version;

		[SerializeField]
		[Token(Token = "0x40000AF")]
		[FieldOffset(Offset = "0x38")]
		internal string m_SourceFontFileGUID;

		[SerializeField]
		[Token(Token = "0x40000B0")]
		[FieldOffset(Offset = "0x40")]
		private Font m_SourceFontFile;

		[SerializeField]
		[Token(Token = "0x40000B1")]
		[FieldOffset(Offset = "0x48")]
		private AtlasPopulationMode m_AtlasPopulationMode;

		[SerializeField]
		[Token(Token = "0x40000B2")]
		[FieldOffset(Offset = "0x50")]
		private FaceInfo m_FaceInfo;

		[SerializeField]
		[Token(Token = "0x40000B3")]
		[FieldOffset(Offset = "0xA8")]
		private List<Glyph> m_GlyphTable;

		[Token(Token = "0x40000B4")]
		[FieldOffset(Offset = "0xB0")]
		private Dictionary<uint, Glyph> m_GlyphLookupDictionary;

		[SerializeField]
		[Token(Token = "0x40000B5")]
		[FieldOffset(Offset = "0xB8")]
		private List<TMP_Character> m_CharacterTable;

		[Token(Token = "0x40000B6")]
		[FieldOffset(Offset = "0xC0")]
		private Dictionary<uint, TMP_Character> m_CharacterLookupDictionary;

		[Token(Token = "0x40000B7")]
		[FieldOffset(Offset = "0xC8")]
		private Texture2D m_AtlasTexture;

		[SerializeField]
		[Token(Token = "0x40000B8")]
		[FieldOffset(Offset = "0xD0")]
		private Texture2D[] m_AtlasTextures;

		[SerializeField]
		[Token(Token = "0x40000B9")]
		[FieldOffset(Offset = "0xD8")]
		internal int m_AtlasTextureIndex;

		[SerializeField]
		[Token(Token = "0x40000BA")]
		[FieldOffset(Offset = "0xE0")]
		private List<GlyphRect> m_UsedGlyphRects;

		[SerializeField]
		[Token(Token = "0x40000BB")]
		[FieldOffset(Offset = "0xE8")]
		private List<GlyphRect> m_FreeGlyphRects;

		[SerializeField]
		[Token(Token = "0x40000BC")]
		[FieldOffset(Offset = "0xF0")]
		private FaceInfo_Legacy m_fontInfo;

		[SerializeField]
		[Token(Token = "0x40000BD")]
		[FieldOffset(Offset = "0xF8")]
		public Texture2D atlas;

		[SerializeField]
		[Token(Token = "0x40000BE")]
		[FieldOffset(Offset = "0x100")]
		private int m_AtlasWidth;

		[SerializeField]
		[Token(Token = "0x40000BF")]
		[FieldOffset(Offset = "0x104")]
		private int m_AtlasHeight;

		[SerializeField]
		[Token(Token = "0x40000C0")]
		[FieldOffset(Offset = "0x108")]
		private int m_AtlasPadding;

		[SerializeField]
		[Token(Token = "0x40000C1")]
		[FieldOffset(Offset = "0x10C")]
		private GlyphRenderMode m_AtlasRenderMode;

		[SerializeField]
		[Token(Token = "0x40000C2")]
		[FieldOffset(Offset = "0x110")]
		internal List<TMP_Glyph> m_glyphInfoList;

		[SerializeField]
		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x7486F0", Offset = "0x7486F0")]
		[Token(Token = "0x40000C3")]
		[FieldOffset(Offset = "0x118")]
		internal KerningTable m_KerningTable;

		[SerializeField]
		[Token(Token = "0x40000C4")]
		[FieldOffset(Offset = "0x120")]
		private TMP_FontFeatureTable m_FontFeatureTable;

		[SerializeField]
		[Token(Token = "0x40000C5")]
		[FieldOffset(Offset = "0x128")]
		private List<TMP_FontAsset> fallbackFontAssets;

		[SerializeField]
		[Token(Token = "0x40000C6")]
		[FieldOffset(Offset = "0x130")]
		public List<TMP_FontAsset> m_FallbackFontAssetTable;

		[SerializeField]
		[Token(Token = "0x40000C7")]
		[FieldOffset(Offset = "0x138")]
		internal FontAssetCreationSettings m_CreationSettings;

		[SerializeField]
		[Token(Token = "0x40000C8")]
		[FieldOffset(Offset = "0x190")]
		private TMP_FontWeightPair[] m_FontWeightTable;

		[SerializeField]
		[Token(Token = "0x40000C9")]
		[FieldOffset(Offset = "0x198")]
		private TMP_FontWeightPair[] fontWeights;

		[Token(Token = "0x40000CA")]
		[FieldOffset(Offset = "0x1A0")]
		public float normalStyle;

		[Token(Token = "0x40000CB")]
		[FieldOffset(Offset = "0x1A4")]
		public float normalSpacingOffset;

		[Token(Token = "0x40000CC")]
		[FieldOffset(Offset = "0x1A8")]
		public float boldStyle;

		[Token(Token = "0x40000CD")]
		[FieldOffset(Offset = "0x1AC")]
		public float boldSpacing;

		[Token(Token = "0x40000CE")]
		[FieldOffset(Offset = "0x1B0")]
		public byte italicStyle;

		[Token(Token = "0x40000CF")]
		[FieldOffset(Offset = "0x1B1")]
		public byte tabSize;

		[Token(Token = "0x40000D0")]
		[FieldOffset(Offset = "0x1B2")]
		private byte m_oldTabSize;

		[Token(Token = "0x40000D1")]
		[FieldOffset(Offset = "0x1B3")]
		internal bool m_IsFontAssetLookupTablesDirty;

		[Token(Token = "0x40000D2")]
		[FieldOffset(Offset = "0x1B8")]
		private List<Glyph> m_GlyphsToPack;

		[Token(Token = "0x40000D3")]
		[FieldOffset(Offset = "0x1C0")]
		private List<Glyph> m_GlyphsPacked;

		[Token(Token = "0x40000D4")]
		[FieldOffset(Offset = "0x1C8")]
		private List<Glyph> m_GlyphsToRender;

		[Token(Token = "0x40000D5")]
		[FieldOffset(Offset = "0x1D0")]
		private List<uint> m_GlyphIndexList;

		[Token(Token = "0x40000D6")]
		[FieldOffset(Offset = "0x1D8")]
		private List<TMP_Character> m_CharactersToAdd;

		[Token(Token = "0x40000D7")]
		internal static uint[] s_GlyphIndexArray;

		[Token(Token = "0x40000D8")]
		internal static List<uint> s_MissingCharacterList;

		[Token(Token = "0x17000033")]
		public string version
		{
			[Token(Token = "0x6000148")]
			[Address(RVA = "0x921370", Offset = "0x921370", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000149")]
			[Address(RVA = "0x921378", Offset = "0x921378", Length = "0x8")]
			internal set
			{
			}
		}

		[Token(Token = "0x17000034")]
		public Font sourceFontFile
		{
			[Token(Token = "0x600014A")]
			[Address(RVA = "0x921380", Offset = "0x921380", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x600014B")]
			[Address(RVA = "0x921388", Offset = "0x921388", Length = "0x8")]
			internal set
			{
			}
		}

		[Token(Token = "0x17000035")]
		public AtlasPopulationMode atlasPopulationMode
		{
			[Token(Token = "0x600014C")]
			[Address(RVA = "0x921390", Offset = "0x921390", Length = "0x8")]
			get
			{
				return AtlasPopulationMode.Static;
			}
			[Token(Token = "0x600014D")]
			[Address(RVA = "0x921398", Offset = "0x921398", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000036")]
		public FaceInfo faceInfo
		{
			[Token(Token = "0x600014E")]
			[Address(RVA = "0x9213A0", Offset = "0x9213A0", Length = "0x10")]
			get
			{
				return default(FaceInfo);
			}
			[Token(Token = "0x600014F")]
			[Address(RVA = "0x9213B0", Offset = "0x9213B0", Length = "0x1C")]
			internal set
			{
			}
		}

		[Token(Token = "0x17000037")]
		public List<Glyph> glyphTable
		{
			[Token(Token = "0x6000150")]
			[Address(RVA = "0x9213CC", Offset = "0x9213CC", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000151")]
			[Address(RVA = "0x9213D4", Offset = "0x9213D4", Length = "0x8")]
			internal set
			{
			}
		}

		[Token(Token = "0x17000038")]
		public Dictionary<uint, Glyph> glyphLookupTable
		{
			[Token(Token = "0x6000152")]
			[Address(RVA = "0x9213DC", Offset = "0x9213DC", Length = "0x30")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000039")]
		public List<TMP_Character> characterTable
		{
			[Token(Token = "0x6000153")]
			[Address(RVA = "0x921BA8", Offset = "0x921BA8", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000154")]
			[Address(RVA = "0x921BB0", Offset = "0x921BB0", Length = "0x8")]
			internal set
			{
			}
		}

		[Token(Token = "0x1700003A")]
		public Dictionary<uint, TMP_Character> characterLookupTable
		{
			[Token(Token = "0x6000155")]
			[Address(RVA = "0x921BB8", Offset = "0x921BB8", Length = "0x30")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700003B")]
		public Texture2D atlasTexture
		{
			[Token(Token = "0x6000156")]
			[Address(RVA = "0x921BE8", Offset = "0x921BE8", Length = "0xB0")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700003C")]
		public Texture2D[] atlasTextures
		{
			[Token(Token = "0x6000157")]
			[Address(RVA = "0x921C98", Offset = "0x921C98", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000158")]
			[Address(RVA = "0x921CA0", Offset = "0x921CA0", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700003D")]
		internal List<GlyphRect> usedGlyphRects
		{
			[Token(Token = "0x6000159")]
			[Address(RVA = "0x921CA8", Offset = "0x921CA8", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x600015A")]
			[Address(RVA = "0x921CB0", Offset = "0x921CB0", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700003E")]
		internal List<GlyphRect> freeGlyphRects
		{
			[Token(Token = "0x600015B")]
			[Address(RVA = "0x921CB8", Offset = "0x921CB8", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x600015C")]
			[Address(RVA = "0x921CC0", Offset = "0x921CC0", Length = "0x8")]
			set
			{
			}
		}

		[Obsolete]
		[Token(Token = "0x1700003F")]
		public FaceInfo_Legacy fontInfo
		{
			[Token(Token = "0x600015D")]
			[Address(RVA = "0x921CC8", Offset = "0x921CC8", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000040")]
		public int atlasWidth
		{
			[Token(Token = "0x600015E")]
			[Address(RVA = "0x921CD0", Offset = "0x921CD0", Length = "0x8")]
			get
			{
				return 0;
			}
			[Token(Token = "0x600015F")]
			[Address(RVA = "0x921CD8", Offset = "0x921CD8", Length = "0x8")]
			internal set
			{
			}
		}

		[Token(Token = "0x17000041")]
		public int atlasHeight
		{
			[Token(Token = "0x6000160")]
			[Address(RVA = "0x921CE0", Offset = "0x921CE0", Length = "0x8")]
			get
			{
				return 0;
			}
			[Token(Token = "0x6000161")]
			[Address(RVA = "0x921CE8", Offset = "0x921CE8", Length = "0x8")]
			internal set
			{
			}
		}

		[Token(Token = "0x17000042")]
		public int atlasPadding
		{
			[Token(Token = "0x6000162")]
			[Address(RVA = "0x921CF0", Offset = "0x921CF0", Length = "0x8")]
			get
			{
				return 0;
			}
			[Token(Token = "0x6000163")]
			[Address(RVA = "0x921CF8", Offset = "0x921CF8", Length = "0x8")]
			internal set
			{
			}
		}

		[Token(Token = "0x17000043")]
		public GlyphRenderMode atlasRenderMode
		{
			[Token(Token = "0x6000164")]
			[Address(RVA = "0x921D00", Offset = "0x921D00", Length = "0x8")]
			get
			{
				return (GlyphRenderMode)0;
			}
			[Token(Token = "0x6000165")]
			[Address(RVA = "0x921D08", Offset = "0x921D08", Length = "0x8")]
			internal set
			{
			}
		}

		[Token(Token = "0x17000044")]
		public TMP_FontFeatureTable fontFeatureTable
		{
			[Token(Token = "0x6000166")]
			[Address(RVA = "0x921D10", Offset = "0x921D10", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000167")]
			[Address(RVA = "0x921D18", Offset = "0x921D18", Length = "0x8")]
			internal set
			{
			}
		}

		[Token(Token = "0x17000045")]
		public List<TMP_FontAsset> fallbackFontAssetTable
		{
			[Token(Token = "0x6000168")]
			[Address(RVA = "0x921D20", Offset = "0x921D20", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000169")]
			[Address(RVA = "0x921D28", Offset = "0x921D28", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000046")]
		public FontAssetCreationSettings creationSettings
		{
			[Token(Token = "0x600016A")]
			[Address(RVA = "0x921D30", Offset = "0x921D30", Length = "0x10")]
			get
			{
				return default(FontAssetCreationSettings);
			}
			[Token(Token = "0x600016B")]
			[Address(RVA = "0x921D40", Offset = "0x921D40", Length = "0x1C")]
			set
			{
			}
		}

		[Token(Token = "0x17000047")]
		public TMP_FontWeightPair[] fontWeightTable
		{
			[Token(Token = "0x600016C")]
			[Address(RVA = "0x921D5C", Offset = "0x921D5C", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x600016D")]
			[Address(RVA = "0x921D64", Offset = "0x921D64", Length = "0x8")]
			internal set
			{
			}
		}

		[Token(Token = "0x600016E")]
		[Address(RVA = "0x921D6C", Offset = "0x921D6C", Length = "0x7C")]
		public static TMP_FontAsset CreateFontAsset(Font font)
		{
			return null;
		}

		[Token(Token = "0x600016F")]
		[Address(RVA = "0x921DE8", Offset = "0x921DE8", Length = "0x3D4")]
		public static TMP_FontAsset CreateFontAsset(Font font, int samplingPointSize, int atlasPadding, GlyphRenderMode renderMode, int atlasWidth, int atlasHeight, AtlasPopulationMode atlasPopulationMode = AtlasPopulationMode.Dynamic)
		{
			return null;
		}

		[Token(Token = "0x6000170")]
		[Address(RVA = "0x9221BC", Offset = "0x9221BC", Length = "0x98")]
		private void Awake()
		{
		}

		[Token(Token = "0x6000171")]
		[Address(RVA = "0x922BA8", Offset = "0x922BA8", Length = "0x3B0")]
		internal void InitializeDictionaryLookupTables()
		{
		}

		[Token(Token = "0x6000172")]
		[Address(RVA = "0x92140C", Offset = "0x92140C", Length = "0x79C")]
		public void ReadFontAssetDefinition()
		{
		}

		[Token(Token = "0x6000173")]
		[Address(RVA = "0x9231E8", Offset = "0x9231E8", Length = "0x120")]
		internal void SortCharacterTable()
		{
		}

		[Token(Token = "0x6000174")]
		[Address(RVA = "0x923308", Offset = "0x923308", Length = "0x120")]
		internal void SortGlyphTable()
		{
		}

		[Token(Token = "0x6000175")]
		[Address(RVA = "0x923428", Offset = "0x923428", Length = "0x24")]
		internal void SortGlyphAndCharacterTables()
		{
		}

		[Token(Token = "0x6000176")]
		[Address(RVA = "0x92344C", Offset = "0x92344C", Length = "0x74")]
		public bool HasCharacter(int character)
		{
			return false;
		}

		[Token(Token = "0x6000177")]
		[Address(RVA = "0x9234C0", Offset = "0x9234C0", Length = "0x74")]
		public bool HasCharacter(char character)
		{
			return false;
		}

		[Token(Token = "0x6000178")]
		[Address(RVA = "0x923534", Offset = "0x923534", Length = "0x3E4")]
		public bool HasCharacter(char character, bool searchFallbacks)
		{
			return false;
		}

		[Token(Token = "0x6000179")]
		[Address(RVA = "0x923EE4", Offset = "0x923EE4", Length = "0x16C")]
		private bool HasCharacter_Internal(char character, bool searchFallbacks)
		{
			return false;
		}

		[Token(Token = "0x600017A")]
		[Address(RVA = "0x924050", Offset = "0x924050", Length = "0x140")]
		public bool HasCharacters(string text, out List<char> missingCharacters)
		{
			missingCharacters = null;
			return false;
		}

		[Token(Token = "0x600017B")]
		[Address(RVA = "0x924190", Offset = "0x924190", Length = "0xC8")]
		public bool HasCharacters(string text)
		{
			return false;
		}

		[Token(Token = "0x600017C")]
		[Address(RVA = "0x924258", Offset = "0x924258", Length = "0xE4")]
		public static string GetCharacters(TMP_FontAsset fontAsset)
		{
			return null;
		}

		[Token(Token = "0x600017D")]
		[Address(RVA = "0x92433C", Offset = "0x92433C", Length = "0xEC")]
		public static int[] GetCharactersArray(TMP_FontAsset fontAsset)
		{
			return null;
		}

		[Token(Token = "0x600017E")]
		[Address(RVA = "0x924428", Offset = "0x924428", Length = "0x28")]
		public bool TryAddCharacters(uint[] unicodes)
		{
			return false;
		}

		[Token(Token = "0x600017F")]
		[Address(RVA = "0x924450", Offset = "0x924450", Length = "0x70C")]
		public bool TryAddCharacters(uint[] unicodes, out uint[] missingUnicodes)
		{
			missingUnicodes = null;
			return false;
		}

		[Token(Token = "0x6000180")]
		[Address(RVA = "0x924B5C", Offset = "0x924B5C", Length = "0x28")]
		public bool TryAddCharacters(string characters)
		{
			return false;
		}

		[Token(Token = "0x6000181")]
		[Address(RVA = "0x924B84", Offset = "0x924B84", Length = "0x648")]
		public bool TryAddCharacters(string characters, out string missingCharacters)
		{
			missingCharacters = null;
			return false;
		}

		[Token(Token = "0x6000182")]
		[Address(RVA = "0x9251CC", Offset = "0x9251CC", Length = "0x324")]
		internal bool TryAddCharacter_Internal(uint unicode)
		{
			return false;
		}

		[Token(Token = "0x6000183")]
		[Address(RVA = "0x9254F0", Offset = "0x9254F0", Length = "0x324")]
		internal TMP_Character AddCharacter_Internal(uint unicode, Glyph glyph)
		{
			return null;
		}

		[Token(Token = "0x6000184")]
		[Address(RVA = "0x923918", Offset = "0x923918", Length = "0x5CC")]
		internal bool TryAddCharacterInternal(uint unicode, out TMP_Character character)
		{
			character = null;
			return false;
		}

		[Token(Token = "0x6000185")]
		[Address(RVA = "0x925EF8", Offset = "0x925EF8", Length = "0xCC")]
		internal uint GetGlyphIndex(uint unicode)
		{
			return 0u;
		}

		[Token(Token = "0x6000186")]
		[Address(RVA = "0x925814", Offset = "0x925814", Length = "0x2CC")]
		internal void UpdateAtlasTexture()
		{
		}

		[Token(Token = "0x6000187")]
		[Address(RVA = "0x925AE0", Offset = "0x925AE0", Length = "0x418")]
		internal void UpdateGlyphAdjustmentRecords(uint unicode, uint glyphIndex)
		{
		}

		[Token(Token = "0x6000188")]
		[Address(RVA = "0x926118", Offset = "0x926118", Length = "0x51C")]
		public void ClearFontAssetData(bool setAtlasSizeToZero = false)
		{
		}

		[Token(Token = "0x6000189")]
		[Address(RVA = "0x922254", Offset = "0x922254", Length = "0x954")]
		private void UpgradeFontAsset()
		{
		}

		[Token(Token = "0x600018A")]
		[Address(RVA = "0x922F58", Offset = "0x922F58", Length = "0x290")]
		private void UpgradeGlyphAdjustmentTableToFontFeatureTable()
		{
		}

		[Token(Token = "0x600018B")]
		[Address(RVA = "0x926688", Offset = "0x926688", Length = "0x194")]
		public TMP_FontAsset()
		{
		}
	}
}
