using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.TextCore;
using UnityEngine.TextCore.LowLevel;

namespace TMPro
{
	[Serializable]
	[ExcludeFromPreset]
	[Token(Token = "0x200003E")]
	public class TMP_FontAsset : TMP_Asset
	{
		[SerializeField]
		[Token(Token = "0x40001A9")]
		[FieldOffset(Offset = "0x30")]
		private string m_Version;

		[SerializeField]
		[Token(Token = "0x40001AA")]
		[FieldOffset(Offset = "0x38")]
		internal string m_SourceFontFileGUID;

		[SerializeField]
		[Token(Token = "0x40001AB")]
		[FieldOffset(Offset = "0x40")]
		private Font m_SourceFontFile;

		[SerializeField]
		[Token(Token = "0x40001AC")]
		[FieldOffset(Offset = "0x48")]
		private AtlasPopulationMode m_AtlasPopulationMode;

		[SerializeField]
		[Token(Token = "0x40001AD")]
		[FieldOffset(Offset = "0x50")]
		internal FaceInfo m_FaceInfo;

		[SerializeField]
		[Token(Token = "0x40001AE")]
		[FieldOffset(Offset = "0xB0")]
		internal List<Glyph> m_GlyphTable;

		[Token(Token = "0x40001AF")]
		[FieldOffset(Offset = "0xB8")]
		internal Dictionary<uint, Glyph> m_GlyphLookupDictionary;

		[SerializeField]
		[Token(Token = "0x40001B0")]
		[FieldOffset(Offset = "0xC0")]
		internal List<TMP_Character> m_CharacterTable;

		[Token(Token = "0x40001B1")]
		[FieldOffset(Offset = "0xC8")]
		internal Dictionary<uint, TMP_Character> m_CharacterLookupDictionary;

		[Token(Token = "0x40001B2")]
		[FieldOffset(Offset = "0xD0")]
		internal Texture2D m_AtlasTexture;

		[SerializeField]
		[Token(Token = "0x40001B3")]
		[FieldOffset(Offset = "0xD8")]
		internal Texture2D[] m_AtlasTextures;

		[SerializeField]
		[Token(Token = "0x40001B4")]
		[FieldOffset(Offset = "0xE0")]
		internal int m_AtlasTextureIndex;

		[SerializeField]
		[Token(Token = "0x40001B5")]
		[FieldOffset(Offset = "0xE4")]
		private bool m_IsMultiAtlasTexturesEnabled;

		[SerializeField]
		[Token(Token = "0x40001B6")]
		[FieldOffset(Offset = "0xE5")]
		private bool m_ClearDynamicDataOnBuild;

		[SerializeField]
		[Token(Token = "0x40001B7")]
		[FieldOffset(Offset = "0xE8")]
		private List<GlyphRect> m_UsedGlyphRects;

		[SerializeField]
		[Token(Token = "0x40001B8")]
		[FieldOffset(Offset = "0xF0")]
		private List<GlyphRect> m_FreeGlyphRects;

		[SerializeField]
		[Token(Token = "0x40001B9")]
		[FieldOffset(Offset = "0xF8")]
		private FaceInfo_Legacy m_fontInfo;

		[SerializeField]
		[Token(Token = "0x40001BA")]
		[FieldOffset(Offset = "0x100")]
		public Texture2D atlas;

		[SerializeField]
		[Token(Token = "0x40001BB")]
		[FieldOffset(Offset = "0x108")]
		internal int m_AtlasWidth;

		[SerializeField]
		[Token(Token = "0x40001BC")]
		[FieldOffset(Offset = "0x10C")]
		internal int m_AtlasHeight;

		[SerializeField]
		[Token(Token = "0x40001BD")]
		[FieldOffset(Offset = "0x110")]
		internal int m_AtlasPadding;

		[SerializeField]
		[Token(Token = "0x40001BE")]
		[FieldOffset(Offset = "0x114")]
		internal GlyphRenderMode m_AtlasRenderMode;

		[SerializeField]
		[Token(Token = "0x40001BF")]
		[FieldOffset(Offset = "0x118")]
		internal List<TMP_Glyph> m_glyphInfoList;

		[SerializeField]
		[FormerlySerializedAs("m_kerningInfo")]
		[Token(Token = "0x40001C0")]
		[FieldOffset(Offset = "0x120")]
		internal KerningTable m_KerningTable;

		[SerializeField]
		[Token(Token = "0x40001C1")]
		[FieldOffset(Offset = "0x128")]
		internal TMP_FontFeatureTable m_FontFeatureTable;

		[SerializeField]
		[Token(Token = "0x40001C2")]
		[FieldOffset(Offset = "0x130")]
		private List<TMP_FontAsset> fallbackFontAssets;

		[SerializeField]
		[Token(Token = "0x40001C3")]
		[FieldOffset(Offset = "0x138")]
		internal List<TMP_FontAsset> m_FallbackFontAssetTable;

		[SerializeField]
		[Token(Token = "0x40001C4")]
		[FieldOffset(Offset = "0x140")]
		internal FontAssetCreationSettings m_CreationSettings;

		[SerializeField]
		[Token(Token = "0x40001C5")]
		[FieldOffset(Offset = "0x198")]
		private TMP_FontWeightPair[] m_FontWeightTable;

		[SerializeField]
		[Token(Token = "0x40001C6")]
		[FieldOffset(Offset = "0x1A0")]
		private TMP_FontWeightPair[] fontWeights;

		[Token(Token = "0x40001C7")]
		[FieldOffset(Offset = "0x1A8")]
		public float normalStyle;

		[Token(Token = "0x40001C8")]
		[FieldOffset(Offset = "0x1AC")]
		public float normalSpacingOffset;

		[Token(Token = "0x40001C9")]
		[FieldOffset(Offset = "0x1B0")]
		public float boldStyle;

		[Token(Token = "0x40001CA")]
		[FieldOffset(Offset = "0x1B4")]
		public float boldSpacing;

		[Token(Token = "0x40001CB")]
		[FieldOffset(Offset = "0x1B8")]
		public byte italicStyle;

		[Token(Token = "0x40001CC")]
		[FieldOffset(Offset = "0x1B9")]
		public byte tabSize;

		[Token(Token = "0x40001CD")]
		[FieldOffset(Offset = "0x1BA")]
		internal bool IsFontAssetLookupTablesDirty;

		[Token(Token = "0x40001CE")]
		private static ProfilerMarker k_ReadFontAssetDefinitionMarker;

		[Token(Token = "0x40001CF")]
		private static ProfilerMarker k_AddSynthesizedCharactersMarker;

		[Token(Token = "0x40001D0")]
		private static ProfilerMarker k_TryAddCharacterMarker;

		[Token(Token = "0x40001D1")]
		private static ProfilerMarker k_TryAddCharactersMarker;

		[Token(Token = "0x40001D2")]
		private static ProfilerMarker k_UpdateGlyphAdjustmentRecordsMarker;

		[Token(Token = "0x40001D3")]
		private static ProfilerMarker k_ClearFontAssetDataMarker;

		[Token(Token = "0x40001D4")]
		private static ProfilerMarker k_UpdateFontAssetDataMarker;

		[Token(Token = "0x40001D5")]
		private static string s_DefaultMaterialSuffix;

		[Token(Token = "0x40001D6")]
		[FieldOffset(Offset = "0x1C0")]
		internal HashSet<int> FallbackSearchQueryLookup;

		[Token(Token = "0x40001D7")]
		private static HashSet<int> k_SearchedFontAssetLookup;

		[Token(Token = "0x40001D8")]
		private static List<TMP_FontAsset> k_FontAssets_FontFeaturesUpdateQueue;

		[Token(Token = "0x40001D9")]
		private static HashSet<int> k_FontAssets_FontFeaturesUpdateQueueLookup;

		[Token(Token = "0x40001DA")]
		private static List<TMP_FontAsset> k_FontAssets_AtlasTexturesUpdateQueue;

		[Token(Token = "0x40001DB")]
		private static HashSet<int> k_FontAssets_AtlasTexturesUpdateQueueLookup;

		[Token(Token = "0x40001DC")]
		[FieldOffset(Offset = "0x1C8")]
		private List<Glyph> m_GlyphsToRender;

		[Token(Token = "0x40001DD")]
		[FieldOffset(Offset = "0x1D0")]
		private List<Glyph> m_GlyphsRendered;

		[Token(Token = "0x40001DE")]
		[FieldOffset(Offset = "0x1D8")]
		private List<uint> m_GlyphIndexList;

		[Token(Token = "0x40001DF")]
		[FieldOffset(Offset = "0x1E0")]
		private List<uint> m_GlyphIndexListNewlyAdded;

		[Token(Token = "0x40001E0")]
		[FieldOffset(Offset = "0x1E8")]
		internal List<uint> m_GlyphsToAdd;

		[Token(Token = "0x40001E1")]
		[FieldOffset(Offset = "0x1F0")]
		internal HashSet<uint> m_GlyphsToAddLookup;

		[Token(Token = "0x40001E2")]
		[FieldOffset(Offset = "0x1F8")]
		internal List<TMP_Character> m_CharactersToAdd;

		[Token(Token = "0x40001E3")]
		[FieldOffset(Offset = "0x200")]
		internal HashSet<uint> m_CharactersToAddLookup;

		[Token(Token = "0x40001E4")]
		[FieldOffset(Offset = "0x208")]
		internal List<uint> s_MissingCharacterList;

		[Token(Token = "0x40001E5")]
		[FieldOffset(Offset = "0x210")]
		internal HashSet<uint> m_MissingUnicodesFromFontFile;

		[Token(Token = "0x40001E6")]
		internal static uint[] k_GlyphIndexArray;

		[Token(Token = "0x1700004D")]
		public string version
		{
			[Token(Token = "0x60001D5")]
			[Address(RVA = "0x15D6034", Offset = "0x15D6034", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60001D6")]
			[Address(RVA = "0x15D603C", Offset = "0x15D603C", Length = "0x8")]
			internal set
			{
			}
		}

		[Token(Token = "0x1700004E")]
		public Font sourceFontFile
		{
			[Token(Token = "0x60001D7")]
			[Address(RVA = "0x15D6044", Offset = "0x15D6044", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60001D8")]
			[Address(RVA = "0x15D604C", Offset = "0x15D604C", Length = "0x8")]
			internal set
			{
			}
		}

		[Token(Token = "0x1700004F")]
		public AtlasPopulationMode atlasPopulationMode
		{
			[Token(Token = "0x60001D9")]
			[Address(RVA = "0x15D6054", Offset = "0x15D6054", Length = "0x8")]
			get
			{
				return AtlasPopulationMode.Static;
			}
			[Token(Token = "0x60001DA")]
			[Address(RVA = "0x15D605C", Offset = "0x15D605C", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000050")]
		public FaceInfo faceInfo
		{
			[Token(Token = "0x60001DB")]
			[Address(RVA = "0x15D6064", Offset = "0x15D6064", Length = "0x10")]
			get
			{
				return default(FaceInfo);
			}
			[Token(Token = "0x60001DC")]
			[Address(RVA = "0x15D6074", Offset = "0x15D6074", Length = "0x18")]
			set
			{
			}
		}

		[Token(Token = "0x17000051")]
		public List<Glyph> glyphTable
		{
			[Token(Token = "0x60001DD")]
			[Address(RVA = "0x15D608C", Offset = "0x15D608C", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60001DE")]
			[Address(RVA = "0x15D6094", Offset = "0x15D6094", Length = "0x8")]
			internal set
			{
			}
		}

		[Token(Token = "0x17000052")]
		public Dictionary<uint, Glyph> glyphLookupTable
		{
			[Token(Token = "0x60001DF")]
			[Address(RVA = "0x15D609C", Offset = "0x15D609C", Length = "0x24")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000053")]
		public List<TMP_Character> characterTable
		{
			[Token(Token = "0x60001E0")]
			[Address(RVA = "0x15D62F8", Offset = "0x15D62F8", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60001E1")]
			[Address(RVA = "0x15D6300", Offset = "0x15D6300", Length = "0x8")]
			internal set
			{
			}
		}

		[Token(Token = "0x17000054")]
		public Dictionary<uint, TMP_Character> characterLookupTable
		{
			[Token(Token = "0x60001E2")]
			[Address(RVA = "0x15D6308", Offset = "0x15D6308", Length = "0x24")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000055")]
		public Texture2D atlasTexture
		{
			[Token(Token = "0x60001E3")]
			[Address(RVA = "0x15D632C", Offset = "0x15D632C", Length = "0x90")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000056")]
		public Texture2D[] atlasTextures
		{
			[Token(Token = "0x60001E4")]
			[Address(RVA = "0x15D63BC", Offset = "0x15D63BC", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60001E5")]
			[Address(RVA = "0x15D63C4", Offset = "0x15D63C4", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000057")]
		public int atlasTextureCount
		{
			[Token(Token = "0x60001E6")]
			[Address(RVA = "0x15D63CC", Offset = "0x15D63CC", Length = "0xC")]
			get
			{
				return 0;
			}
		}

		[Token(Token = "0x17000058")]
		public bool isMultiAtlasTexturesEnabled
		{
			[Token(Token = "0x60001E7")]
			[Address(RVA = "0x15D63D8", Offset = "0x15D63D8", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60001E8")]
			[Address(RVA = "0x15D63E0", Offset = "0x15D63E0", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x17000059")]
		internal bool clearDynamicDataOnBuild
		{
			[Token(Token = "0x60001E9")]
			[Address(RVA = "0x15D63EC", Offset = "0x15D63EC", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60001EA")]
			[Address(RVA = "0x15D63F4", Offset = "0x15D63F4", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x1700005A")]
		internal List<GlyphRect> usedGlyphRects
		{
			[Token(Token = "0x60001EB")]
			[Address(RVA = "0x15D6400", Offset = "0x15D6400", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60001EC")]
			[Address(RVA = "0x15D6408", Offset = "0x15D6408", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700005B")]
		internal List<GlyphRect> freeGlyphRects
		{
			[Token(Token = "0x60001ED")]
			[Address(RVA = "0x15D6410", Offset = "0x15D6410", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60001EE")]
			[Address(RVA = "0x15D6418", Offset = "0x15D6418", Length = "0x8")]
			set
			{
			}
		}

		[Obsolete("The fontInfo property and underlying type is now obsolete. Please use the faceInfo property and FaceInfo type instead.")]
		[Token(Token = "0x1700005C")]
		public FaceInfo_Legacy fontInfo
		{
			[Token(Token = "0x60001EF")]
			[Address(RVA = "0x15D6420", Offset = "0x15D6420", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700005D")]
		public int atlasWidth
		{
			[Token(Token = "0x60001F0")]
			[Address(RVA = "0x15D6428", Offset = "0x15D6428", Length = "0x8")]
			get
			{
				return 0;
			}
			[Token(Token = "0x60001F1")]
			[Address(RVA = "0x15D6430", Offset = "0x15D6430", Length = "0x8")]
			internal set
			{
			}
		}

		[Token(Token = "0x1700005E")]
		public int atlasHeight
		{
			[Token(Token = "0x60001F2")]
			[Address(RVA = "0x15D6438", Offset = "0x15D6438", Length = "0x8")]
			get
			{
				return 0;
			}
			[Token(Token = "0x60001F3")]
			[Address(RVA = "0x15D6440", Offset = "0x15D6440", Length = "0x8")]
			internal set
			{
			}
		}

		[Token(Token = "0x1700005F")]
		public int atlasPadding
		{
			[Token(Token = "0x60001F4")]
			[Address(RVA = "0x15D6448", Offset = "0x15D6448", Length = "0x8")]
			get
			{
				return 0;
			}
			[Token(Token = "0x60001F5")]
			[Address(RVA = "0x15D6450", Offset = "0x15D6450", Length = "0x8")]
			internal set
			{
			}
		}

		[Token(Token = "0x17000060")]
		public GlyphRenderMode atlasRenderMode
		{
			[Token(Token = "0x60001F6")]
			[Address(RVA = "0x15D6458", Offset = "0x15D6458", Length = "0x8")]
			get
			{
				return (GlyphRenderMode)0;
			}
			[Token(Token = "0x60001F7")]
			[Address(RVA = "0x15D6460", Offset = "0x15D6460", Length = "0x8")]
			internal set
			{
			}
		}

		[Token(Token = "0x17000061")]
		public TMP_FontFeatureTable fontFeatureTable
		{
			[Token(Token = "0x60001F8")]
			[Address(RVA = "0x15D6468", Offset = "0x15D6468", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60001F9")]
			[Address(RVA = "0x15D6470", Offset = "0x15D6470", Length = "0x8")]
			internal set
			{
			}
		}

		[Token(Token = "0x17000062")]
		public List<TMP_FontAsset> fallbackFontAssetTable
		{
			[Token(Token = "0x60001FA")]
			[Address(RVA = "0x15D6478", Offset = "0x15D6478", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60001FB")]
			[Address(RVA = "0x15D6480", Offset = "0x15D6480", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000063")]
		public FontAssetCreationSettings creationSettings
		{
			[Token(Token = "0x60001FC")]
			[Address(RVA = "0x15D6488", Offset = "0x15D6488", Length = "0x10")]
			get
			{
				return default(FontAssetCreationSettings);
			}
			[Token(Token = "0x60001FD")]
			[Address(RVA = "0x15D6498", Offset = "0x15D6498", Length = "0x18")]
			set
			{
			}
		}

		[Token(Token = "0x17000064")]
		public TMP_FontWeightPair[] fontWeightTable
		{
			[Token(Token = "0x60001FE")]
			[Address(RVA = "0x15D64B0", Offset = "0x15D64B0", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60001FF")]
			[Address(RVA = "0x15D64B8", Offset = "0x15D64B8", Length = "0x8")]
			internal set
			{
			}
		}

		[Token(Token = "0x6000200")]
		[Address(RVA = "0x15D64C0", Offset = "0x15D64C0", Length = "0x7C")]
		public static TMP_FontAsset CreateFontAsset(Font font)
		{
			return null;
		}

		[Token(Token = "0x6000201")]
		[Address(RVA = "0x15D653C", Offset = "0x15D653C", Length = "0x500")]
		public static TMP_FontAsset CreateFontAsset(Font font, int samplingPointSize, int atlasPadding, GlyphRenderMode renderMode, int atlasWidth, int atlasHeight, AtlasPopulationMode atlasPopulationMode = AtlasPopulationMode.Dynamic, bool enableMultiAtlasSupport = true)
		{
			return null;
		}

		[Token(Token = "0x6000202")]
		[Address(RVA = "0x15D6A3C", Offset = "0x15D6A3C", Length = "0x88")]
		private void Awake()
		{
		}

		[Token(Token = "0x6000203")]
		[Address(RVA = "0x15D60C0", Offset = "0x15D60C0", Length = "0x238")]
		public void ReadFontAssetDefinition()
		{
		}

		[Token(Token = "0x6000204")]
		[Address(RVA = "0x15D7644", Offset = "0x15D7644", Length = "0x20")]
		internal void InitializeDictionaryLookupTables()
		{
		}

		[Token(Token = "0x6000205")]
		[Address(RVA = "0x15D7970", Offset = "0x15D7970", Length = "0x288")]
		internal void InitializeGlyphLookupDictionary()
		{
		}

		[Token(Token = "0x6000206")]
		[Address(RVA = "0x15D7BF8", Offset = "0x15D7BF8", Length = "0x21C")]
		internal void InitializeCharacterLookupDictionary()
		{
		}

		[Token(Token = "0x6000207")]
		[Address(RVA = "0x15D7E14", Offset = "0x15D7E14", Length = "0x1C4")]
		internal void InitializeGlyphPaidAdjustmentRecordsLookupDictionary()
		{
		}

		[Token(Token = "0x6000208")]
		[Address(RVA = "0x15D7664", Offset = "0x15D7664", Length = "0x30C")]
		internal void AddSynthesizedCharactersAndFaceMetrics()
		{
		}

		[Token(Token = "0x6000209")]
		[Address(RVA = "0x15D8314", Offset = "0x15D8314", Length = "0x218")]
		private void AddSynthesizedCharacter(uint unicode, bool isFontFaceLoaded, bool addImmediately = false)
		{
		}

		[Token(Token = "0x600020A")]
		[Address(RVA = "0x15D852C", Offset = "0x15D852C", Length = "0xB8")]
		internal void AddCharacterToLookupCache(uint unicode, TMP_Character character)
		{
		}

		[Token(Token = "0x600020B")]
		[Address(RVA = "0x15D85E4", Offset = "0x15D85E4", Length = "0x134")]
		internal void SortCharacterTable()
		{
		}

		[Token(Token = "0x600020C")]
		[Address(RVA = "0x15D8718", Offset = "0x15D8718", Length = "0x134")]
		internal void SortGlyphTable()
		{
		}

		[Token(Token = "0x600020D")]
		[Address(RVA = "0x15D884C", Offset = "0x15D884C", Length = "0x18")]
		internal void SortFontFeatureTable()
		{
		}

		[Token(Token = "0x600020E")]
		[Address(RVA = "0x15D8A50", Offset = "0x15D8A50", Length = "0x28")]
		internal void SortAllTables()
		{
		}

		[Token(Token = "0x600020F")]
		[Address(RVA = "0x15D8A78", Offset = "0x15D8A78", Length = "0x60")]
		public bool HasCharacter(int character)
		{
			return false;
		}

		[Token(Token = "0x6000210")]
		[Address(RVA = "0x15D8AD8", Offset = "0x15D8AD8", Length = "0x4D4")]
		public bool HasCharacter(char character, bool searchFallbacks = false, bool tryAddCharacter = false)
		{
			return false;
		}

		[Token(Token = "0x6000211")]
		[Address(RVA = "0x15D9814", Offset = "0x15D9814", Length = "0x21C")]
		private bool HasCharacter_Internal(uint character, bool searchFallbacks = false, bool tryAddCharacter = false)
		{
			return false;
		}

		[Token(Token = "0x6000212")]
		[Address(RVA = "0x15D9A30", Offset = "0x15D9A30", Length = "0x1A0")]
		public bool HasCharacters(string text, out List<char> missingCharacters)
		{
			missingCharacters = null;
			return false;
		}

		[Token(Token = "0x6000213")]
		[Address(RVA = "0x15D9BD0", Offset = "0x15D9BD0", Length = "0x5F0")]
		public bool HasCharacters(string text, out uint[] missingCharacters, bool searchFallbacks = false, bool tryAddCharacter = false)
		{
			missingCharacters = null;
			return false;
		}

		[Token(Token = "0x6000214")]
		[Address(RVA = "0x15DA1C0", Offset = "0x15DA1C0", Length = "0xC4")]
		public bool HasCharacters(string text)
		{
			return false;
		}

		[Token(Token = "0x6000215")]
		[Address(RVA = "0x15DA284", Offset = "0x15DA284", Length = "0x10C")]
		public static string GetCharacters(TMP_FontAsset fontAsset)
		{
			return null;
		}

		[Token(Token = "0x6000216")]
		[Address(RVA = "0x15DA390", Offset = "0x15DA390", Length = "0xE4")]
		public static int[] GetCharactersArray(TMP_FontAsset fontAsset)
		{
			return null;
		}

		[Token(Token = "0x6000217")]
		[Address(RVA = "0x15DA474", Offset = "0x15DA474", Length = "0x118")]
		internal uint GetGlyphIndex(uint unicode)
		{
			return 0u;
		}

		[Token(Token = "0x6000218")]
		[Address(RVA = "0x15DA58C", Offset = "0x15DA58C", Length = "0x130")]
		internal static void RegisterFontAssetForFontFeatureUpdate(TMP_FontAsset fontAsset)
		{
		}

		[Token(Token = "0x6000219")]
		[Address(RVA = "0x15DA6BC", Offset = "0x15DA6BC", Length = "0x16C")]
		internal static void UpdateFontFeaturesForFontAssetsInQueue()
		{
		}

		[Token(Token = "0x600021A")]
		[Address(RVA = "0x15DAB34", Offset = "0x15DAB34", Length = "0x130")]
		internal static void RegisterFontAssetForAtlasTextureUpdate(TMP_FontAsset fontAsset)
		{
		}

		[Token(Token = "0x600021B")]
		[Address(RVA = "0x15DAC64", Offset = "0x15DAC64", Length = "0x168")]
		internal static void UpdateAtlasTexturesForFontAssetsInQueue()
		{
		}

		[Token(Token = "0x600021C")]
		[Address(RVA = "0x15DADD0", Offset = "0x15DADD0", Length = "0x20")]
		public bool TryAddCharacters(uint[] unicodes, bool includeFontFeatures = false)
		{
			return false;
		}

		[Token(Token = "0x600021D")]
		[Address(RVA = "0x15DADF0", Offset = "0x15DADF0", Length = "0xBF8")]
		public bool TryAddCharacters(uint[] unicodes, out uint[] missingUnicodes, bool includeFontFeatures = false)
		{
			missingUnicodes = null;
			return false;
		}

		[Token(Token = "0x600021E")]
		[Address(RVA = "0x15DBE60", Offset = "0x15DBE60", Length = "0x20")]
		public bool TryAddCharacters(string characters, bool includeFontFeatures = false)
		{
			return false;
		}

		[Token(Token = "0x600021F")]
		[Address(RVA = "0x15DBE80", Offset = "0x15DBE80", Length = "0xBDC")]
		public bool TryAddCharacters(string characters, out string missingCharacters, bool includeFontFeatures = false)
		{
			missingCharacters = null;
			return false;
		}

		[Token(Token = "0x6000220")]
		[Address(RVA = "0x15D8FAC", Offset = "0x15D8FAC", Length = "0x868")]
		internal bool TryAddCharacterInternal(uint unicode, out TMP_Character character)
		{
			character = null;
			return false;
		}

		[Token(Token = "0x6000221")]
		[Address(RVA = "0x15DCC6C", Offset = "0x15DCC6C", Length = "0x5AC")]
		internal bool TryGetCharacter_and_QueueRenderToTexture(uint unicode, out TMP_Character character)
		{
			character = null;
			return false;
		}

		[Token(Token = "0x6000222")]
		[Address(RVA = "0x15DADCC", Offset = "0x15DADCC", Length = "0x4")]
		internal void TryAddGlyphsToAtlasTextures()
		{
		}

		[Token(Token = "0x6000223")]
		[Address(RVA = "0x15DB9E8", Offset = "0x15DB9E8", Length = "0x478")]
		private bool TryAddGlyphsToNewAtlasTexture()
		{
			return false;
		}

		[Token(Token = "0x6000224")]
		[Address(RVA = "0x15DCA5C", Offset = "0x15DCA5C", Length = "0x210")]
		private void SetupNewAtlasTexture()
		{
		}

		[Token(Token = "0x6000225")]
		[Address(RVA = "0x15DD218", Offset = "0x15DD218", Length = "0x178")]
		internal void UpdateAtlasTexture()
		{
		}

		[Token(Token = "0x6000226")]
		[Address(RVA = "0x15DA828", Offset = "0x15DA828", Length = "0x30C")]
		internal void UpdateGlyphAdjustmentRecords()
		{
		}

		[Token(Token = "0x6000227")]
		[Address(RVA = "0x15DD50C", Offset = "0x15DD50C", Length = "0x2E4")]
		internal void UpdateGlyphAdjustmentRecords(uint[] glyphIndexes)
		{
		}

		[Token(Token = "0x6000228")]
		[Address(RVA = "0x15DD7F0", Offset = "0x15DD7F0", Length = "0x4")]
		internal void UpdateGlyphAdjustmentRecords(List<uint> glyphIndexes)
		{
		}

		[Token(Token = "0x6000229")]
		[Address(RVA = "0x15DD7F4", Offset = "0x15DD7F4", Length = "0x4")]
		internal void UpdateGlyphAdjustmentRecords(List<uint> newGlyphIndexes, List<uint> allGlyphIndexes)
		{
		}

		[Token(Token = "0x600022A")]
		[Address(RVA = "0xCABE0C", Offset = "0xCABE0C", Length = "0x1A0")]
		private void CopyListDataToArray<T>(List<T> srcList, ref T[] dstArray)
		{
		}

		[Token(Token = "0x600022B")]
		[Address(RVA = "0x15DD7F8", Offset = "0x15DD7F8", Length = "0x30")]
		public void ClearFontAssetData(bool setAtlasSizeToZero = false)
		{
		}

		[Token(Token = "0x600022C")]
		[Address(RVA = "0x15DDD48", Offset = "0x15DDD48", Length = "0x1C")]
		internal void ClearFontAssetDataInternal()
		{
		}

		[Token(Token = "0x600022D")]
		[Address(RVA = "0x15DDD64", Offset = "0x15DDD64", Length = "0x124")]
		internal void UpdateFontAssetData()
		{
		}

		[Token(Token = "0x600022E")]
		[Address(RVA = "0x15DD828", Offset = "0x15DD828", Length = "0x210")]
		internal void ClearFontAssetTables()
		{
		}

		[Token(Token = "0x600022F")]
		[Address(RVA = "0x15DDA38", Offset = "0x15DDA38", Length = "0x310")]
		internal void ClearAtlasTextures(bool setAtlasSizeToZero = false)
		{
		}

		[Token(Token = "0x6000230")]
		[Address(RVA = "0x15D6AC4", Offset = "0x15D6AC4", Length = "0xB80")]
		internal void UpgradeFontAsset()
		{
		}

		[Token(Token = "0x6000231")]
		[Address(RVA = "0x15D7FD8", Offset = "0x15D7FD8", Length = "0x314")]
		private void UpgradeGlyphAdjustmentTableToFontFeatureTable()
		{
		}

		[Token(Token = "0x6000232")]
		[Address(RVA = "0x15DDEEC", Offset = "0x15DDEEC", Length = "0x2DC")]
		public TMP_FontAsset()
		{
		}
	}
}
